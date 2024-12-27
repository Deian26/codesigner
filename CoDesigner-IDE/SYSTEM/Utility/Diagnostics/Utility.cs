using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Handles utility actions
    /// </summary>
    internal static class Utility
    {
        /// <summary>
        /// Defines the status of security properties
        /// </summary>
        public struct SecurityProperties
        {
            public bool ADMIN_WORKSTATION { get; }

            public SecurityProperties(bool ADMIN_WORKSTATION)
            {
                this.ADMIN_WORKSTATION = ADMIN_WORKSTATION;
            }
        }

        internal static SecurityProperties CurrentSecurityProperties { get; set; }
        private static bool CurrentSecurityPropertiesLoaded = false; // if true, new security properties cannot be loaded (reset when the program is started)
        /// <summary>
        /// Loads local properties from the disk
        /// </summary>
        public static void LoadProperties()
        {
            if (Utility.CurrentSecurityPropertiesLoaded == false)
            {
                bool adminWorkstation = false;

                try
                {
                    Security.Decrypt(GeneralPaths.SEC_PROPERTIES_FILE_PATH);

                    XmlDocument xml = new XmlDocument();
                    xml.Load(GeneralPaths.SEC_PROPERTIES_FILE_PATH);
                    XmlNode root = xml.DocumentElement;

                    // load security properties (only valid for the current machine)
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "ADMIN-WORKSTATION":
                                {
                                    if (Utility.GetHashedUuid().Equals(node.Attributes["id"].Value) == true)
                                    {
                                        adminWorkstation = true;
                                    }
                                    break;
                                }
                            default: // unknown property => ignore it
                                break;
                        }
                    }

                    Security.Encrypt(GeneralPaths.SEC_PROPERTIES_FILE_PATH);
                }
                catch (Exception ex)
                {
                    Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERROR_LOADING_SECURITY_PROPERTIES, ex.Message);
                }
                
                Utility.CurrentSecurityProperties = new Utility.SecurityProperties(
                    adminWorkstation);
                Utility.CurrentSecurityPropertiesLoaded = true;

            }

        }

        /// <summary>
        /// Returns the hashed UUID of this computer
        /// </summary>
        /// <returns>The hashed ID or null (if an error occurs)</returns>
        public static string GetHashedUuid()
        {
            string id = null;
            ManagementClass mng = new ManagementClass("Win32_ComputerSystemProduct");

            foreach (ManagementObject obj in mng.GetInstances())
            {
                id = obj.Properties["UUID"].Value.ToString(); //=> get the machine UUID

                id = id.Replace("-", ""); //=> remove separators
            }

            // hash ID
            if(id!=null)
                id = Security.GenerateHash(id);

            return id;
        }
    
        /// <summary>
        /// Sets the security properties that will be used starting with the next application start
        /// </summary>
        /// <param name="adminWorkstation">If true, the diagnostic utility and other admin features are enabled without requiring a token</param>
        public static void StoreSecurityProperties(bool adminWorkstation)
        {
            try
            {
                // combine new and currnet security properties
                Utility.SecurityProperties newSecurityProperties = new Utility.SecurityProperties(
                    Utility.CurrentSecurityProperties.ADMIN_WORKSTATION | adminWorkstation
                    );

                // create the properties file, if it does not exist already
                if (File.Exists(GeneralPaths.SEC_PROPERTIES_FILE_PATH) == false)
                {
                    File.Create(GeneralPaths.SEC_PROPERTIES_FILE_PATH).Close();
                }

                // write new properties
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.Encoding = Encoding.UTF8;
                xmlWriterSettings.IndentChars = "\t";
                xmlWriterSettings.NewLineChars = "\n";
                StringBuilder xmlText = new StringBuilder();

                XmlWriter xmlWriter = XmlWriter.Create(xmlText,xmlWriterSettings);
                
                //=// Write properties
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("SEC-PROPERTIES");

                //==// admin workstation
                xmlWriter.WriteStartElement("ADMIN-WORKSTATION");

                xmlWriter.WriteAttributeString("value",newSecurityProperties.ADMIN_WORKSTATION.ToString());
                
                xmlWriter.WriteEndElement();
                //=//
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                
                xmlWriter.Close();

                string enc = Security.Encrypt(xmlText.ToString());
                File.WriteAllText(GeneralPaths.SEC_PROPERTIES_FILE_PATH, enc); //locally encrypt the file
                Security.Decrypt(enc);
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERROR_STORING_SECURITY_PROPERTIES, ex.Message);
            }
        }
        
    }
}

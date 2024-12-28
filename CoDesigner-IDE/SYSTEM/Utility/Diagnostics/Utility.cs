using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Handles utility actions
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class Utility
    {
        private static string HASHED_UUID = null;
        
        #region colours
        public static Color BACKCOLOUR_ERROR { get; } = Color.Salmon;
        public static Color BACKCOLOUR_DEFAULT_CONTROL { get; } = Color.White;
        #endregion

        private static FileStream SEC_USED_TOKENS_FILESTREAM = null; 

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
        public static void LoadSecurityProperties()
        {
            if (Utility.CurrentSecurityPropertiesLoaded == false)
            {
                bool adminWorkstation = false;

                try
                {
                    string plainText = Security.Decrypt(File.ReadAllText(GeneralPaths.SEC_PROPERTIES_FILE_PATH));

                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(plainText);
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
                                        adminWorkstation = Convert.ToBoolean(node.Attributes["value"].Value.ToString());
                                    }
                                    break;
                                }
                            default: // unknown property => ignore it
                                break;
                        }
                    }

                    
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
            if (Utility.HASHED_UUID == null) // hashed ID not previously obtained
            {
                string id = null;
                ManagementClass mng = new ManagementClass("Win32_ComputerSystemProduct");

                foreach (ManagementObject obj in mng.GetInstances())
                {
                    id = obj.Properties["UUID"].Value.ToString(); //=> get the machine UUID

                    id = id.Replace("-", ""); //=> remove separators
                }

                // hash ID
                if (id != null)
                    id = Security.GenerateHash(id);

                Utility.HASHED_UUID = id; // store hashed id
            }

            return Utility.HASHED_UUID;
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
                xmlWriterSettings.NewLineChars = "\r\n";
                StringBuilder xmlText = new StringBuilder();

                XmlWriter xmlWriter = XmlWriter.Create(xmlText,xmlWriterSettings);
                
                //=// Write properties
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("SEC-PROPERTIES");

                //==// admin workstation
                xmlWriter.WriteStartElement("ADMIN-WORKSTATION");

                xmlWriter.WriteAttributeString("id", Utility.GetHashedUuid());
                xmlWriter.WriteAttributeString("value",newSecurityProperties.ADMIN_WORKSTATION.ToString());
                
                xmlWriter.WriteEndElement();
                //=//
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                
                xmlWriter.Close();

                string enc = Security.Encrypt(xmlText.ToString());
                File.WriteAllText(GeneralPaths.SEC_PROPERTIES_FILE_PATH, enc); //locally encrypt the file
                
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERROR_STORING_SECURITY_PROPERTIES, ex.Message);
            }
        }
        
        /// <summary>
        /// Loads into memory the tokens used so far, accross different sessions
        /// </summary>
        public static void LoadUsedSecurityTokens()
        {
            try
            {
                // read the file, if it exists
                string usedTokensPlainText = null;
                if (File.Exists(GeneralPaths.SEC_USED_TOKENS_FILE_PATH) == true)
                {
                    usedTokensPlainText = Security.Decrypt(File.ReadAllText(GeneralPaths.SEC_USED_TOKENS_FILE_PATH)); // load already used tokens in memory
                    
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(usedTokensPlainText);
                    XmlNode root = xml.DocumentElement;

                    foreach(XmlNode usedToken in root.ChildNodes)
                    {
                        switch(usedToken.Name)
                        {
                            case "USED-TOKEN":
                                {
                                    // verify machine id
                                    if (usedToken.Attributes["machine-id"].Value.Equals(Utility.GetHashedUuid()) == true)
                                    {
                                        // create a Token object and add it to the list of used tokens
                                        Security.AddUsedToken(new Security.Token(usedToken.Attributes["token-string"].Value));
                                    }
                                    break;
                                }
                            default: // unrecognized node => ignore it
                                {
                                    break;
                                }
                        }
                    }
                }
                else // error: the used tokens file was deleted => stop application
                {
                    Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_LOADING_USED_SEC_TOKENS);
                }

                // lock file; this will be closed when the application is closed
                Utility.SEC_USED_TOKENS_FILESTREAM = File.Open(GeneralPaths.SEC_USED_TOKENS_FILE_PATH,FileMode.Open);
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_LOADING_USED_SEC_TOKENS, ex.Message);
            }
        }

        /// <summary>
        /// Perform any non-critical actions before the application is closed
        /// </summary>
        public static void ApplicationExitActions()
        {
            try
            {
                // store tokens (used accross all sessions so far)
                if (File.Exists(GeneralPaths.SEC_USED_TOKENS_FILE_PATH) == false) //=> overwrite/create file 
                {
                    File.Create(GeneralPaths.SEC_USED_TOKENS_FILE_PATH).Close();
                }

                // parse XML file
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.Encoding = Encoding.UTF8;
                xmlWriterSettings.IndentChars = "\t";
                xmlWriterSettings.NewLineChars = "\r\n";
                StringBuilder xmlText = new StringBuilder();

                XmlWriter xmlWriter = XmlWriter.Create(xmlText, xmlWriterSettings);

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("USED-TOKENS");

                foreach (Security.Token usedToken in Security.GetUsedTokens())
                {
                    xmlWriter.WriteStartElement("USED-TOKEN");

                    xmlWriter.WriteAttributeString("machine-id",Utility.GetHashedUuid());
                    xmlWriter.WriteAttributeString("token-string",usedToken.TOKEN_STRING);

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();

                // unlock the file
                Utility.SEC_USED_TOKENS_FILESTREAM.Close();

                // write details on the disk
                File.WriteAllText(GeneralPaths.SEC_USED_TOKENS_FILE_PATH,Security.Encrypt(xmlText.ToString()));
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_STORING_APP_EXIT_DATA, ex.Message);
            }


        }
    }
}

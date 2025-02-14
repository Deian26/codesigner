using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoDesigner_IDE.SYSTEM.Utility
{
    /// <summary>
    /// Handles utility actions
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class Utility
    {
        public static bool PROGRAM_ACTIVATED { get; set; } = false; // is set to true when the program is activated using data from an Admin-Utility program
        #region colours
        public static Color BACKCOLOUR_ERROR { get; } = Color.Salmon;
        public static Color BACKCOLOUR_DEFAULT_CONTROL { get; } = Color.White;
        #endregion

        /// <summary>
        /// Headers for configuration file segments
        /// </summary>
        public struct ConfigFileSegmentHeaders
        {
            public const string SIGNATURE = "S";
            public const string XML_DATA = "X";
        }

        private const string CONFIG_FILE_SEGMENT_SEPARATOR = "#";
        private const string CONFIG_FILE_SEGMENT_HEADER_END_MARKER = "\\@";

        /// <summary>
        /// Sets the security properties that will be used starting with the next application start
        /// </summary>
        /// <param name="adminWorkstation">If true, the diagnostic utility and other admin features are enabled without requiring a token</param>
        public static void StoreSecurityProperties(bool adminWorkstation)
        {
            try
            {
                // combine new and current security properties
                Security.SecurityProperties newSecurityProperties = new Security.SecurityProperties(
                    Security.CurrentSecurityProperties.ADMIN_WORKSTATION | adminWorkstation
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

                XmlWriter xmlWriter = XmlWriter.Create(xmlText, xmlWriterSettings);

                //=// Write properties
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("SEC-PROPERTIES");

                //==// admin workstation
                xmlWriter.WriteStartElement("ADMIN-WORKSTATION");

                xmlWriter.WriteAttributeString("id", Security.GetHashedGuid());
                xmlWriter.WriteAttributeString("value", newSecurityProperties.ADMIN_WORKSTATION.ToString());

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
        /// Perform any non-critical actions before the application is closed
        /// </summary>
        public static void ApplicationExitActions()
        {
            // store used tokens
            Security.StoreUsedTokens(false);

            // store approved generator IDs
            Security.StoreGeneratorIds();

        }

        /// <summary>
        /// Extracts and returns and array of the segments of a configuration file
        /// </summary>
        /// <param name="configFilePath">The path to the configuration file to be parsed</param>
        /// <returns>An array containing the configuration file segments found, or null if an error occurs</returns>
        public static Dictionary<string, string> GetConfigFileSegments(string configFilePath)
        {
            Dictionary<string, string> configFileSegments = new Dictionary<string, string>();

            try
            {
                // parse file
                string configFileText = File.ReadAllText(configFilePath);
                string[] segmentSubsegments;

                // get segments
                foreach (string segment in configFileText.Split(CONFIG_FILE_SEGMENT_SEPARATOR))
                {
                    if (segment.Equals(string.Empty) == true) continue; //=> skip empty strings

                    // extract segment details
                    segmentSubsegments = segment.Split(CONFIG_FILE_SEGMENT_HEADER_END_MARKER);

                    // check signature
                    configFileSegments.Add(segmentSubsegments[0], segmentSubsegments[1]); //=> key = header, value = config data

                }
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_PARSING_CONFIG_FILES, ex.Message);
                configFileSegments = null;
            }

            if (configFileSegments != null) return configFileSegments;
            else return null;
        }
    }
}

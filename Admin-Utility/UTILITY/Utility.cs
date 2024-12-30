using Admin_Utility.UTILITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Utility
{
    /// <summary>
    /// Handles utility functions
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class Utility
    {
        #region setup
        private static readonly string[] SETUP_CONFIG_FILES = // files to be generated when setting up the utility and associated programs
        {
            "SEC_PUBLIC_REPORT_ENC_KEY.sec"
        };

        /// <summary>
        /// Checks if the setup configuration data archive exists
        /// </summary>
        /// <returns>true if the data exists, false otherwise</returns>
        public static bool ConfigDataExists()
        {
            bool configDataExists = true;
            

            if (File.Exists(GeneralPaths.OUTPUT_CONFIG_DIR_ZIP_ARCHIVE) == true) // open archive
            {

                ZipArchive configDataArchive = ZipFile.OpenRead(GeneralPaths.OUTPUT_CONFIG_DIR_ZIP_ARCHIVE);

                foreach (string file in Utility.SETUP_CONFIG_FILES) // parse the list of expected configuration file names
                {
                    if (configDataArchive.GetEntry(file) == null) // missing configuration data
                    {
                        configDataExists = false;
                    }
                }
            }
            else // the config output directory and config archive do not exist
            {
                configDataExists = false;
            }

            return configDataExists;
        }

        /// <summary>
        /// Checks if the necessary configuration data already exist and if not, this method creates it.
        /// </summary>
        /// <returns>true if configuration data was generated, false otherwise</returns>
        public static bool GenerateSetupConfigData()
        {
            try
            {
                //=// Generate data

                //==// RSA Encryption keys
                Directory.CreateDirectory(GeneralPaths.OUTPUT_CONFIG_DIR); // create the folder, if needed
                File.WriteAllText(GeneralPaths.OUTPUT_CONFIG_RSA_PUBLIC_KEY, Security.CreateAndStoreRsaParameters());

                //=// Generate setup config archive file, for easier distribution
                ZipFile.CreateFromDirectory(GeneralPaths.OUTPUT_CONFIG_DIR, GeneralPaths.OUTPUT_CONFIG_DIR_ZIP_ARCHIVE); // create archive
                Directory.Delete(GeneralPaths.OUTPUT_CONFIG_DIR,true);// delete the original directory and sub-directories


                return true; // the config data was generated
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating configuration data: {ex.Message}", "Setup data generation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // the data was not successfully generated
        }
        #endregion
    }
}

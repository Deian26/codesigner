using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Utility.UTILITY
{
    /// <summary>
    /// Paths and names
    /// </summary>
    internal static class GeneralPaths
    {
        #region paths
        public const string TOP_REL_PATH = "../../../"; // relative path from the binary to the top folder of the project

        //=// Output
        public static readonly string OUTPUT = Path.Combine(GeneralPaths.TOP_REL_PATH,"OUTPUT");

        //==// Configuration
        public static readonly string OUTPUT_CONFIG_DIR = Path.Combine(new string[] { GeneralPaths.OUTPUT, "Configuration" });
        public static readonly string OUTPUT_CONFIG_DIR_ZIP_ARCHIVE = Path.Combine(new string[] { GeneralPaths.OUTPUT, "Configuration.zip" });
        public static readonly string OUTPUT_CONFIG_RSA_PUBLIC_KEY = Path.Combine(new string[] { GeneralPaths.OUTPUT_CONFIG_DIR, "SEC_PUBLIC_REPORT_ENC_KEY.sec" }); // public RSA key
        public static readonly string OUTPUT_CONFIG_CRT_GEN_ID = Path.Combine(new string[] { GeneralPaths.OUTPUT_CONFIG_DIR, "SEC_CONFIG_GEN_ID.sec" }); // this machine's generator ID

        //=// Storage
        public static readonly string STORAGE = Path.Combine(new string[] { GeneralPaths.TOP_REL_PATH, "STORAGE" }); // local storage folder

        //=// User-specific
        public static readonly string LOCAL_USERS_STORAGE_DIR = Path.Combine(new string[] {GeneralPaths.STORAGE, "UserData" }); // directory used to store user-specific data
        #endregion

        #region names
        //==// Security
        public static readonly string SEC_GENERATED_TOKENS_SUBDIR_NAME = "GeneratedTokens";
        public static readonly string GENERATED_TOKEN_FILE_EXT = ".tok"; // the extension used for files storing generated tokens
        #endregion
    }
}

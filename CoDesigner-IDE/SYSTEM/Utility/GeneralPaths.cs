using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines paths used within the applicationThread.
    /// </summary>
    internal class GeneralPaths
    {
        #region paths
        //=// Relative path to the top folder
        public static readonly string TOP_REL_PATH_BIN = Path.Combine(new string[] { "..","..",".." }); //=> the path from the IDE executable to the top folder of the IDE's folder structure

        //=// 1st level directories
        public static readonly string SYSTEM = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN,"SYSTEM");
        public static readonly string COMPONENTS = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN, "COMPONENTS");
        public static readonly string FORMS = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN, "FORMS");
        public static readonly string TEMP = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN, "TEMP");

        //==// 2nd level main directories
        public static readonly string RESOURCES = Path.Combine(GeneralPaths.SYSTEM,"Resources");
        public static readonly string STORAGE = Path.Combine(GeneralPaths.SYSTEM, "Storage");

        //===// Resource sub-directories and files
        public static readonly string DEFAULT_EVENTS_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "Diagnostics", "EVENTS.appconfig" }); //default events
        public static readonly string DEFAULT_MESSAGES_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "MESSAGES.appconfig" }); //default messages
        public static readonly string ACTIVE_PROJECTS_FILEPATH = Path.Combine(new string[] { GeneralPaths.STORAGE, "Projects", "ActiveProjects.xml" });
        public static readonly string VERSIONS_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "Diagnostics", "VERSIONS.appconfig" }); //program element versions
        public static readonly string LOG_FOLDER_PATH = Path.Combine(new string[] { GeneralPaths.SYSTEM, "Utility", "Diagnostics", "Logs" }); //logs stored on the disk; the file sizes are limited to the value defined in 'LOG_FILE_MAXSIZE'
        public static readonly string LOG_FILE_PATH = Path.Combine(GeneralPaths.LOG_FOLDER_PATH, "Events.log"); // automatically filled log file path
        
        //====// Storage sub-directories and files
        public static readonly string SEC_PROPERTIES_FILE_PATH = Path.Combine(new string[] { GeneralPaths.STORAGE, "Data", "Security", "SEC_PROPERTIES.sec" }); // data used by the application
        public static readonly string SEC_USED_TOKENS_FILE_PATH = Path.Combine(new string[] { GeneralPaths.STORAGE, "Data", "Security", "SEC_USED_TOKENS.sec" }); // valid tokens used across sessions
        public static readonly string SEC_GEN_IDS_FILE_PATH = Path.Combine(new string[] { GeneralPaths.STORAGE, "Data", "Security", "SEC_GEN_IDS.sec" }); // approved generator IDs file (encrypted)
        public static readonly string SEC_PUBLIC_REPORT_ENC_KEY = Path.Combine(new string[] { GeneralPaths.STORAGE, "Data", "Security", "SEC_PUBLIC_REPORT_ENC_KEY.sec" }); // public key used to encrypt data before being sent for analysis
        
        //===// Paths to the project structure images
        public struct ProjectStructure{
            //=// Tree node
            public static readonly string PROJECT_STRUCTURE_FILE_UNSEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "UnselFileImg.bmp" });
            public static readonly string PROJECT_STRUCTURE_DIRECTORY_UNSEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "UnselDirectoryImg.bmp" });
            public static readonly string PROJECT_STRUCTURE_PROJECT_UNSEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "UnselProjectImg.bmp" });
            
            public static readonly string PROJECT_STRUCTURE_FILE_SEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "SelFileImg.bmp" });
            public static readonly string PROJECT_STRUCTURE_DIRECTORY_SEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "SelDirectoryImg.bmp" });
            public static readonly string PROJECT_STRUCTURE_PROJECT_SEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "SelProjectImg.bmp" });

            public static readonly string TEXT_EDITOR_ICON_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "FormIcons", "TextEditorIcon.bmp" });

            //=// Code editor
            public static readonly string CODE_BUILD_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "BuildCode.bmp" });
            public static readonly string CODE_RUN_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "RunCode.bmp" });
            public static readonly string CODE_SAVE_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "Save.bmp" });
            public static readonly string LOAD_CODE_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "Load.bmp" });
            public static readonly string CODE_INFO_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "Info.bmp" });
            
        }

        #endregion

        #region names
        public const string COMPONENT_CONFIGURATION_FILENAME = "CONFIGURATION.xml"; //defines the component
        #endregion
    }
}

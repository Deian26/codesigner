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
        public static string TOP_REL_PATH_BIN = Path.Combine(new string[] { "..",".." }); //=> the path from the IDE executable to the top folder of the IDE's folder structure

        //=// 1st level directories
        public static string SYSTEM = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN,"SYSTEM");
        public static string COMPONENTS = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN, "COMPONENTS");
        public static string FORMS = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN, "FORMS");
        public static string TEMP = Path.Combine(GeneralPaths.TOP_REL_PATH_BIN, "TEMP");

        //==// 2nd level main directories
        public static string RESOURCES = Path.Combine(GeneralPaths.SYSTEM,"Resources");
        public static string STORAGE = Path.Combine(GeneralPaths.SYSTEM, "Storage");

        //===// Resource sub-directories and files
        public static string DEFAULT_EVENTS_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "Diagnostics", "EVENTS.xml" }); //default events
        public static string DEFAULT_MESSAGES_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "MESSAGES.xml" }); //default messages
        public static string ACTIVE_PROJECTS_FILEPATH = Path.Combine(new string[] { GeneralPaths.STORAGE, "Projects", "ActiveProjects.xml" });
        public static string VERSIONS_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "Diagnostics", "VERSIONS.xml" }); //program element versions
        public static string LOG_FOLDER_PATH = Path.Combine(new string[] { GeneralPaths.SYSTEM, "Utility", "Diagnostics", "Logs" }); //logs stored on the disk; the file sizes are limited to the value defined in 'LOG_FILE_MAXSIZE'
        public static string LOG_FILE_PATH = Path.Combine(GeneralPaths.LOG_FOLDER_PATH, "Events.log"); // automatically filled log file path
        
        //====// Storage sub-directories and files
        public static string SEC_PROPERTIES_FILE_PATH = Path.Combine(new string[] { GeneralPaths.STORAGE, "Data", "Security", "SEC_PROPERTIES.xml" }); // data used by the application
        

        //===// Paths to the project structure images
        public struct ProjectStructure{
            //=// Tree node
            public static string PROJECT_STRUCTURE_FILE_UNSEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "UnselFileImg.bmp" });
            public static string PROJECT_STRUCTURE_DIRECTORY_UNSEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "UnselDirectoryImg.bmp" });
            public static string PROJECT_STRUCTURE_PROJECT_UNSEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "UnselProjectImg.bmp" });
            
            public static string PROJECT_STRUCTURE_FILE_SEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "SelFileImg.bmp" });
            public static string PROJECT_STRUCTURE_DIRECTORY_SEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "SelDirectoryImg.bmp" });
            public static string PROJECT_STRUCTURE_PROJECT_SEL_IMAGE_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "ProjectStructureImg", "SelProjectImg.bmp" });

            public static string TEXT_EDITOR_ICON_FILEPATH = Path.Combine(new string[] { GeneralPaths.RESOURCES, "GUI", "FormIcons", "TextEditorIcon.bmp" });

            //=// Code editor
            public static string CODE_BUILD_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "BuildCode.bmp" });
            public static string CODE_RUN_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "RunCode.bmp" });
            public static string CODE_SAVE_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "Save.bmp" });
            public static string LOAD_CODE_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "Load.bmp" });
            public static string CODE_INFO_IMG_FILEPATH = Path.Combine(new string[] {GeneralPaths.RESOURCES, "GUI", "Code", "Info.bmp" });
            
        }

        #endregion

        #region names
        public const string COMPONENT_CONFIGURATION_FILENAME = "CONFIGURATION.xml"; //defines the component
        #endregion
    }
}

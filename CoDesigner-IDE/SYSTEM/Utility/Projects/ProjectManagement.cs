using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Tracks IDE projects
    /// </summary>
    [SupportedOSPlatform("windows")]
    public static class ProjectManagement
    {
        /// <summary>
        /// List of actively; project filepath, Project object loaded projects
        /// </summary>
        public static Dictionary<string,Project> Projects = new Dictionary<string, Project>();
        
        /// <summary>
        /// Project structure display
        /// </summary>
        public static ImageList ProjectStructureImages = new ImageList();//=> file and folder images
                                                                         //=> key = the TAGNAME variables defined below, for each supported file / directory type
                                                                         //=// Project structure tree node image keys
        /// <summary>
        /// Image keys for project structure element types (i.e., folders and files from the tree-view)
        /// </summary>
        public struct ProjectStructureImageKeys
        {
            /// <summary>
            /// Unselected directory
            /// </summary>
            public const string PROJECT_STRUCTURE_DIRECTORY_UNSEL_IMGKEY = "UNSEL_DIR";
            /// <summary>
            /// Selected directory
            /// </summary>
            public const string PROJECT_STRUCTURE_DIRECTORY_SEL_IMGKEY = "SEL_DIR";

            /// <summary>
            /// Unselected file
            /// </summary>
            public const string PROJECT_STRUCTURE_GENERAL_FILE_UNSEL_IMGKEY = "UNSEL_FILE";
            /// <summary>
            /// Selected file
            /// </summary>
            public const string PROJECT_STRUCTURE_GENERAL_FILE_SEL_IMGKEY = "SEL_FILE";

            /// <summary>
            /// Unselected project
            /// </summary>
            public const string PROJECT_STRUCTURE_PROJECT_UNSEL_IMGKEY = "UNSEL_PROJ";
            /// <summary>
            /// Selected project
            /// </summary>
            public const string PROJECT_STRUCTURE_PROJECT_SEL_IMGKEY = "SEL_PROJ";
        }

        /// <summary>
        /// File types supported by default
        /// </summary>
        public struct DefaultSupportedFileTypes
        {
            /// <summary>
            /// Text files
            /// </summary>
            public const string TXT = "txt"; // text file
            /// <summary>
            /// Simulation files
            /// </summary>
            public const string SIM = "sim"; // simulation file
            /// <summary>
            /// Tables
            /// </summary>
            public const string TABLE = "tbl"; // table
        }

        /// <summary>
        /// Console notifications
        /// </summary>
        public enum ConsoleNotificationTypes { 
            /// <summary>
            /// Error related to the project's code
            /// </summary>
            ERROR = 0, 
            /// <summary>
            /// Warning related to the project's code
            /// </summary>
            WARNING = 1, 
            /// <summary>
            /// Info message (could be from the project's code or the IDE itself)
            /// </summary>
            INFO = 2 };

        /// <summary>
        /// Images for the console notifications
        /// </summary>
        public static Bitmap[] ConsoleNotificationImages = { // array index >=> (int)ConsoleNotificationTypes
            Bitmap.FromHicon(SystemIcons.Error.Handle),
            Bitmap.FromHicon(SystemIcons.Warning.Handle),
            Bitmap.FromHicon(SystemIcons.Information.Handle)
        };

        /// <summary>
        /// Text (code) editor images
        /// </summary>
        public enum TextEditorIconTypes {
            /// <summary>
            /// Build project code
            /// </summary>
            BUILD = 0, 
            /// <summary>
            /// Run built project code
            /// </summary>
            RUN = 1, 
            /// <summary>
            /// Save current file (text/code)
            /// </summary>
            SAVE = 2, 
            /// <summary>
            /// Load a new text/code file
            /// </summary>
            LOAD = 3, 
            /// <summary>
            /// Display more information about the current context
            /// </summary>
            INFO = 4 };
        
        /// <summary>
        /// Images used within the text (code) editor
        /// </summary>
        public static Image[] TextEditorImages = { // array index >=> (int)TextEditorIconTypes
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_BUILD_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_RUN_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_SAVE_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.LOAD_CODE_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_INFO_IMG_FILEPATH)
        };

    }
}

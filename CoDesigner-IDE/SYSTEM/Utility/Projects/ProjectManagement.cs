using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Tracks IDE projects
    /// </summary>
    public static class ProjectManagement
    {
        public static Dictionary<string,Project> Projects = new Dictionary<string, Project>(); //list of actively; project filepath, Project object loaded projects
        
        //=// Project structure display
        public static ImageList ProjectStructureImages = new ImageList();//=> file and folder images
                                                                         //=> key = the TAGNAME variables defined below, for each supported file / directory type
                                                                         //=// Project structure tree node image keys
        public struct ProjectStructureImageKeys
        {
            public const string PROJECT_STRUCTURE_DIRECTORY_UNSEL_IMGKEY = "UNSEL_DIR";
            public const string PROJECT_STRUCTURE_DIRECTORY_SEL_IMGKEY = "SEL_DIR";

            public const string PROJECT_STRUCTURE_GENERAL_FILE_UNSEL_IMGKEY = "UNSEL_FILE";
            public const string PROJECT_STRUCTURE_GENERAL_FILE_SEL_IMGKEY = "SEL_FILE";

            public const string PROJECT_STRUCTURE_PROJECT_UNSEL_IMGKEY = "UNSEL_PROJ";
            public const string PROJECT_STRUCTURE_PROJECT_SEL_IMGKEY = "SEL_PROJ";
        }

        public struct DefaultSupportedFileTypes
        {
            public const string TXT = "txt"; // text file
            public const string SIM = "sim"; // simulation file
            public const string TABLE = "tbl"; // table
        }

        //=// Console notifications
        public enum ConsoleNotificationTypes { ERROR = 0, WARNING = 1, INFO = 2 };
        public static Bitmap[] ConsoleNotificationImages = { // array index >=> (int)ConsoleNotificationTypes
            Bitmap.FromHicon(SystemIcons.Error.Handle),
            Bitmap.FromHicon(SystemIcons.Warning.Handle),
            Bitmap.FromHicon(SystemIcons.Information.Handle)
        };

        //=// Text Editor images
        public enum TextEditorIconTypes { BUILD = 0, RUN = 1, SAVE = 2, LOAD = 3, INFO = 4 };
        public static Image[] TextEditorImages = { // array index >=> (int)TextEditorIconTypes
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_BUILD_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_RUN_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_SAVE_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.LOAD_CODE_IMG_FILEPATH),
            Image.FromFile(GeneralPaths.ProjectStructure.CODE_INFO_IMG_FILEPATH)
        };

    }
}

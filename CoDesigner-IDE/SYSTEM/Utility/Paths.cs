using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines paths used within the application.
    /// </summary>
    internal class Paths
    {
        #region paths
        public static string COMPONENT_INSTALLATION_FOLDER = "../../COMPONENTS/";
        public static string DEFAULT_EVENTS_FILEPATH = "../../SYSTEM/Resources/Diagnostics/EVENTS.xml"; //default events
        public static string DEFAULT_MESSAGES_FILEPATH = "../../SYSTEM/Resources/GUI/MESSAGES.xml"; //default messages
        public static string ACTIVE_PROJECTS_FILEPATH = "../../SYSTEM/Memory/Projects/ActiveProjects.xml";
        #endregion

        #region names
        public static string COMPONENT_CONFIGURATION_FILENAME = "CONFIGURATION.xml"; //defines the component
        #endregion
    }
}

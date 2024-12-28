using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static CoDesigner_IDE.Diagnostics;

namespace CoDesigner_IDE
{

    /// <summary>
    /// Defines a component
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class Component
    {
        //=// Component details
        /// <summary>
        /// Instance of the current component
        /// </summary>
        public dynamic componentInstance { get; } = null; //=> the public, singleton class that implements IIDEComponent, with the same name as the component
        /// <summary>
        /// Component name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Description of the component
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime Timestamp { get; }
        /// <summary>
        /// Component version
        /// </summary>
        public string Version { get;  }

        /// <summary>
        /// Creates a new component with the given details
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Version"></param>
        /// <param name="Timestamp">Creation date</param>
        /// <param name="Description"></param>
        public Component(string Name, string Version, DateTime Timestamp, string Description)
        {
            this.Name = Name;
            this.Description = Description;
            this.Version = Version;
            this.Timestamp = Timestamp;

            // get class instance
            try
            {
                this.componentInstance = Type.GetType(Name)
                    .GetMethod(ComponentFactory.SINGLETON_GETTER_NAME)
                    .Invoke(null, null); //=> create the component instance which will be used within the IDE
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DefaultEventCodes.GENERAL_ERR_LOADING_COMPONENT,ex.Message);
            }
        }

        /// <summary>
        /// Returns details about the current object, as a string
        /// </summary>
        /// <returns>The string representation of the component's details</returns>
        new public virtual string ToString()
        {
            string str;

            str = "Component\n";

            str += ("FileNameAndExt: " + this.Name + "\n");
            str += ("Version: " + this.Version + "\n");
            str += ("Description: " + this.Description + "\n");

            return str;
        }

        /// <summary>
        /// Returns a list of controls which represent additional settings to be configured if this component is used to create a new project.
        /// The specific implementation may be implemented by the derived classes, as this list is optional, but this method's existence is required in some IDE-based operations.
        /// If the derived class does not have such options, the method may not be implemented (instead, this method will be used).
        /// </summary>
        /// <returns>A list of additional options for the component</returns>
        public virtual List<ProjectComboBoxDetails> GetAdditionOptionControls()
        {
            return new List<ProjectComboBoxDetails>(); //empty list
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoDesigner_IDE.Diagnostics;
using System.Xml;
using System.Globalization;
using System.Runtime.Versioning;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Stores details for the creation of combo boxes used for defining project-specific options
    /// </summary>
    public class ProjectComboBoxDetails
    {
        /// <summary>
        /// Label associated with the combo box
        /// </summary>
        public string labelText = "";
        /// <summary>
        /// Combo box values
        /// </summary>
        public List<string> comboValues = new List<string>();

        /// <summary>
        /// Creates a new Combo box details object
        /// </summary>
        /// <param name="labelText"></param>
        /// <param name="comboValues"></param>
        public ProjectComboBoxDetails(string labelText, List<string> comboValues)
        {
            this.labelText = labelText;
            this.comboValues = comboValues;
        }
    }

    /// <summary>
    /// Manages components and component configuration files
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class ComponentFactory
    {
        /// <summary>
        /// Component types (identical to the XML tag names which define the respective components in configuration files)
        /// </summary>
        private static class COMPONENT_TYPE_NAMES
        {
            public const string ProgrammingLanguage = "programming-language";
            public const string SimulationAddon = "simulation-addon";
            public const string LanguagePack = "language-pack";
            public const string ThemePack = "theme-pack";
        }

        public static Dictionary<string,Component> LoadedComponents = new Dictionary<string, Component>(); // key = component name
        public static bool FLAG_AllowThirdPartyComponents = true;
        public const string SINGLETON_GETTER_NAME = "GetInstance"; // the name of the method from the mandatory singleton component class, which will return 1 instance of the class

        /// <summary>
        /// Creates a new component and adds it to the LoadedComponents list.
        /// </summary>
        public static void CreateComponent(string componentFolderPath)
        {
            
            //default attributes
            string Name, Version, Description = "", Type;
            DateTime Timestamp;
            string componentConfigPath;
            Component component = null;

            //open the XML file containing component details
            componentConfigPath = Path.Combine(componentFolderPath, GeneralPaths.COMPONENT_CONFIGURATION_FILENAME);
            
            XmlDocument componentDefinition = new XmlDocument();
            XmlReaderSettings componentDefinitionReaderSettings = new XmlReaderSettings();
            componentDefinitionReaderSettings.IgnoreComments = true;

            XmlReader componentDefinitionReader = XmlReader.Create(componentConfigPath, componentDefinitionReaderSettings);

            componentDefinition.Load(componentDefinitionReader);
            XmlNode rootElement = componentDefinition.DocumentElement;
            
            try
            {
                if (ComponentFactory.FLAG_AllowThirdPartyComponents == true)
                {
                    //get component details
                    Name = rootElement.Attributes["name"].Value.Trim();

                    Version = rootElement.Attributes["version"].Value.Trim();

                    Timestamp = DateTime.ParseExact(rootElement.Attributes["timestamp"].Value.Trim(), TimeManagement.TimestampFormat, null, DateTimeStyles.None);

                    Type = rootElement.Attributes["type"].Value.Trim();

                    // get description
                    foreach (XmlNode componentSubNode in rootElement.ChildNodes)
                    {
                        if (componentSubNode.Name.Equals("description"))
                        {
                            Description = componentSubNode.InnerText.Trim();
                            break;
                        }
                    }

                    //get component type
                    switch (Type)
                    {
                        case COMPONENT_TYPE_NAMES.ProgrammingLanguage:
                            {
                                component = new ProgrammingLanguage(Name, Version, Timestamp, Description, rootElement);
                                break;
                            }

                        case COMPONENT_TYPE_NAMES.SimulationAddon:
                            {
                                component = new SimulationAddon(Name, Version, Timestamp, Description, rootElement);
                                break;
                            }

                        case COMPONENT_TYPE_NAMES.LanguagePack:
                            {

                                break;
                            }

                        case COMPONENT_TYPE_NAMES.ThemePack:
                            {

                                break;
                            }


                        default: //unrecognized component type
                            {
                                // log error
                                //TODO: Log error
                                break;
                            }


                    }
                // add component to the loaded components list
                ComponentFactory.LoadedComponents.Add(component.Name, component);

                }
            }
            catch (Exception ex)
            {
                // log error
                //TODO: Log error
            }

        }
    }
}

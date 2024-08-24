using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Stores details for the creation of combo boxes to define a new project for this component
    /// </summary>
    public class ProjectComboBoxDetails
    {
        public string labelText = "";
        public List<string> comboValues = new List<string>();

        public ProjectComboBoxDetails(string labelText, List<string> comboValues)
        {
            this.labelText = labelText;
            this.comboValues = comboValues;
        }
    }

    /// <summary>
    /// Defines a component
    /// </summary>
    public class Component
    {
        //component details
        public string Name { get; }
        public string Description { get; }

        public string Version { get;  }        
        
        //only filled if the component represents a programming language
        private string ProgrammingLanguage;
        public List<string> MandatorySubfolders = new List<string>(); 

        List<ProjectComboBoxDetails> comboBoxDetails = new List<ProjectComboBoxDetails>();

        public Component(string folderPath) 
        {
            this.ProgrammingLanguage = null;

            //load component configuration
            bool configurationRead = false; //true if the project configuration was successfully read
            List<string> components = Directory.EnumerateDirectories(Paths.COMPONENT_INSTALLATION_FOLDER).ToList();
            string xmlPath = Path.Combine(folderPath, Paths.COMPONENT_CONFIGURATION_FILENAME);
            
            //open the XML file containing project type details (installed with the project type)
            //the configuration document for a programming language contain the 'project' element:
            /*
                * <component name="component1">
                * ...
                *     <project>
                *         <control name="program_execution" values="real_time, offline" /> <!-- each control is a combo-box; values are comma-separated -->
                *         ...
                *     </project>
                * </component>
                */
            XmlDocument projectTypeFile = new XmlDocument();
            projectTypeFile.Load(xmlPath);
            XmlNode rootElement = projectTypeFile.DocumentElement;
            
            configurationRead = true;

            try
            {
                if ((rootElement.Attributes.GetNamedItem("default_component") != null && rootElement.Attributes["default_component"].Value == "true") || Components.FLAG_AllowThirdPartyComponents == true)
                {
                    //get component details
                    this.Name = rootElement.Attributes["name"].Value.Trim();

                    //add component to the loaded components list
                    Components.LoadedComponents.Add(this.Name, this);

                    this.Version = rootElement.Attributes["version"].Value.Trim();

                    //get component type
                    switch (rootElement.Attributes["type"].Value.Trim())
                    {
                        case "programming-language":
                            {
                                foreach (XmlNode configElement in rootElement.ChildNodes)
                                {
                                    //determine configuration element type
                                    switch (configElement.Name)
                                    {
                                        case "description":
                                            {
                                                this.Description = configElement.InnerText.Trim();
                                                break;
                                            }
                                        case "project": //defines the project to be set up for the component
                                            {
                                                //determine controls to be added to the new project configuration form
                                                foreach (XmlNode projectControl in configElement.ChildNodes)
                                                {
                                                    switch (projectControl.Name)
                                                    {
                                                        case "control":
                                                            {
                                                                //  add a combo-box control to the new project configuration list of controls
                                                                comboBoxDetails.Add(new ProjectComboBoxDetails(projectControl.Attributes["name"].Value, projectControl.Attributes["values"].Value.Split(',').ToList()));
                                                                break;
                                                            }
                                                        case "subfolder": // subfolder(s) to add to add in the root folder of the project (if this is a path, all subfolders will be created)
                                                            {
                                                                this.MandatorySubfolders.Add(projectControl.Attributes["relative_path"].Value.Trim());
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                break;
                                                            }
                                                    }
                                                }
                                                break;
                                            }
                                        case "programming-language":
                                            {
                                                this.ProgrammingLanguage = configElement.Attributes["name"].Value.Trim();
                                                break;
                                            }

                                        default: //undefined
                                            {
                                                break;
                                            }
                                    }
                                }
                                break;
                            }

                        case "language-pack":
                            {

                                break;
                            }

                        case "theme-pack":
                            {

                                break;
                            }


                        default:
                            {
                                break;
                            }


                    }
                    if (configurationRead == false) throw new Exception();
                }    
            }
            catch (Exception ex)
            {
                //log error
                //dev

                throw ex;
            }
            
        }

        /// <summary>
        /// Only relevant for components that define programming languages; for all other components, this method will return null
        /// </summary>
        /// <returns></returns>
        public string GetProgrammingLanguage()
        {
            return this.ProgrammingLanguage;
        }

        public List<ProjectComboBoxDetails> GetProjectComboboxDetails()
        {
            
            return this.comboBoxDetails;
        }

        /// <summary>
        /// Returns details about the current object, as a string
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string str;

            str = "Component\n";

            str += ("Name: " + this.Name + "\n");
            str += ("Version: " + this.Version + "\n");
            str += ("Description: " + this.Description + "\n");
            str += ("Programming language: " + this.ProgrammingLanguage.ToString() + "\n");
            str += "\n";

            return str;
        }
    }
}

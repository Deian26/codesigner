using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static CoDesigner_IDE.Diagnostics;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines a project
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class Project
    {
        /// <summary>
        /// Determines some workspace attributes
        /// </summary>
        public dynamic Component { get; }

        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Project description
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Project location on the disk
        /// </summary>
        public string Location { get; } //directory location
        /// <summary>
        /// Project creation timestamp
        /// </summary>
        public DateTime DateCreated { get; }

        public string ProjectFilePath { get; } = null;
        private FileStream ProjectFileStream;

        /// <summary>
        /// Constructs a new project, including disk folder structures and files
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="location"></param>
        /// <param name="component"></param>
        public Project (string name, string description, string location, Component component)
        {  
            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Component = component;
            this.DateCreated = DateTime.Now;

            this.ProjectFilePath = Path.Combine(this.Location, this.Name + ".xml");

            // determine project type
            if(component is ProgrammingLanguage) //=> programming language
            {
                this.Component = (ProgrammingLanguage)component;
            }else if(component is SimulationAddon) //=> simulation
            {
                this.Component = (SimulationAddon)component;
            }
            else // unsupported project type
            {
                Diagnostics.LogEvent(Diagnostics.DefaultEventCodes.ERROR_CREATING_NEW_PROJECT, component.Name);
            }
            
            this.createProjectFile();
            
        }

        /// <summary>
        /// Loads a project from the specified project file
        /// </summary>
        /// <param name="projectFilePath"></param>
        public Project(string projectFilePath)
        {
            if(File.Exists(projectFilePath) == true)
            {
                try
                {
                    XmlDocument projectFile = new XmlDocument();
                    projectFile.Load(projectFilePath);
                    XmlNode root = projectFile.DocumentElement;

                    this.Name = root.Attributes["name"].Value;
                    this.DateCreated = DateTime.Parse(root.Attributes["date_created"].Value);

                    foreach (XmlNode projectConfig in root.ChildNodes)
                    {
                        switch (projectConfig.Name)
                        {
                            case "description":
                                {
                                    this.Description = projectConfig.InnerText;
                                    break;
                                }
                            case "programming-language":
                                {
                                    //TODO: Implement programming language project loading
                                    break;
                                }
                            case "component":
                                {
                                    //get component object based on the component name
                                    this.Component = ComponentFactory.LoadedComponents[projectConfig.Attributes["name"].Value];
                                    break;
                                }

                            default: //undefined
                                {
                                    break;
                                }
                        }

                    }
                } catch (Exception ex) 
                {
                    Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, DefaultEventCodes.ERR_LOADING_PROJECT, ex.Message);
                    throw ex;
                }
            }
            else
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, DefaultEventCodes.ERR_LOADING_PROJECT, projectFilePath);
                throw new Exception("Invalid project file path: "+projectFilePath);
            }
        }

        /// <summary>
        /// Create the project file for the current project
        /// </summary>
        private void createProjectFile()
        {
            this.ProjectFileStream = File.Create(this.ProjectFilePath);

            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = true; xws.IndentChars = "  ";
            XmlWriter xw = XmlWriter.Create(this.ProjectFileStream,xws);

            xw.WriteStartDocument();

                //<project name=this.FileNameAndExt>
                xw.WriteStartElement("project");
                xw.WriteAttributeString("name", this.Name);
                xw.WriteAttributeString("date_created", this.DateCreated.ToString());
                    //<description>
                    xw.WriteStartElement("description");
                    xw.WriteString(this.Description);
                    xw.WriteEndElement();
                    //</description>

                    //<specifications />
                    xw.WriteStartElement("specifications");

                    if (this.Component.GetType() == typeof(ProgrammingLanguage)) //programming language
                    {
                        if (this.Component.Name != null)
                        {
                            //<programming_language />
                            xw.WriteStartElement("programming-language");
                            xw.WriteAttributeString("name", this.Component.Name);
                            xw.WriteEndElement();

                            //<component />
                            xw.WriteStartElement("component");
                            xw.WriteAttributeString("name", this.Component.Name);
                            xw.WriteAttributeString("version", this.Component.Version);
                        }
                        else //error
                        {
                            Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, DefaultEventCodes.UNSUPPORTED_COMPONENT); //event defined in the default events file
                        }
                    }

                    xw.WriteEndElement();
                
                xw.WriteEndElement();
                //</project>
            xw.WriteEndDocument();
            
            xw.Close();
            this.ProjectFileStream.Close();
        }
        
    }
}

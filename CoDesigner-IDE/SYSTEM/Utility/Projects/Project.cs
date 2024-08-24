using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines a project
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Determines some workspace attributes
        /// </summary>
        public Component Component { get; }

        public string Name { get; }
        public string Description { get; }

        public string Location { get; } //directory location

        public DateTime DateCreated { get; }

        public string ProgrammingLanguage { get; }

        private string ProjectFilePath = null;
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
            this.ProgrammingLanguage = this.Component.GetProgrammingLanguage();

            //create mandatory sub-folders, if there are any and if they do not already exist
            foreach (string subfolderRelativePath in this.Component.MandatorySubfolders)
            {
                try
                {
                    Directory.CreateDirectory(Path.Combine(this.Location, subfolderRelativePath));
                }
                catch (Exception ex)
                {
                    //Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE,,ex.PromptMessage)
                    //dev implement component event origin codes

                    throw new Exception();
                }
            }

            this.createProjectFile();

            //add this project to the list of active projects
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
                                    this.ProgrammingLanguage = projectConfig.Attributes["name"].Value;
                                    break;
                                }
                            case "component":
                                {
                                    //get component object based on the component name
                                    this.Component = Components.LoadedComponents[projectConfig.Attributes["name"].Value];
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
                    Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE,7,ex.Message);
                    throw ex;
                }
            }
            else
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE,7,projectFilePath);
                throw new Exception("Invalid project file path: "+projectFilePath);
            }
        }

        /// <summary>
        /// Create the project file for the current project
        /// </summary>
        private void createProjectFile()
        {
            this.ProjectFilePath = Path.Combine(this.Location, this.Name + ".xml");
            this.ProjectFileStream = File.Create(this.ProjectFilePath);

            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = true; xws.IndentChars = "  ";
            XmlWriter xw = XmlWriter.Create(this.ProjectFileStream,xws);

            xw.WriteStartDocument();

                //<project name=this.Name>
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

                    //programming language
                    if (this.Component.GetProgrammingLanguage() != null)
                    {
                        //<programming_language />
                        xw.WriteStartElement("programming-language");
                        xw.WriteAttributeString("name", this.Component.GetProgrammingLanguage());
                        xw.WriteEndElement();

                        //<component />
                        xw.WriteStartElement("component");
                        xw.WriteAttributeString("name", this.Component.Name);
                        xw.WriteAttributeString("version", this.Component.Version);
                    }
                    else //error
                    {
                        Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, 1); //event defined in the default events file
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

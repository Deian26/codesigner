using System;
using System.Collections.Generic;
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

        private string ProjectFilePath = null;
        private FileStream ProjectFileStream;

        public Project (string name, string description, string location, Component component)
        {
            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Component = component;


            if (Directory.Exists(this.Location) == false) //check the project location (again)
            {
                Diagnostics.LogEvent(0,3);

            }else //valid location
            {
                this.createProjectFile();
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
                xw.WriteAttributeString("date_created", DateTime.Now.ToString());
                
                    //<specifications />
                    xw.WriteStartElement("specifications");
                    
                    //programming language
                    if(this.Component.GetProgrammingLanguage() != null) xw.WriteAttributeString("programming_language",this.Component.GetProgrammingLanguage());
                    else //error
                    {
                        Diagnostics.LogEvent(0,1); //event defined in the default events file
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static CoDesigner_IDE.Diagnostics;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines a Programming Language
    /// </summary>
    public class ProgrammingLanguage : Component
    {
        /// <summary>
        /// Configuration tag names
        /// </summary>
        private static class CONFIG_TAGS
        {
            // categories
            public const string project = "project";
            public const string grammar = "grammar";
            public const string description = "description";

            // project configuration
            public const string project_options = "options";
            public const string project_subfolders = "folder-substructure";
            public const string project_executable_file_formats = "executable-files";
            public const string executable_file_tag = "executable-file";
            public const string src_files = "src-files";
            public const string src_file = "src";
            public const string subfolder = "subfolder";
            public const string subfolder_relpath_attr = "relative_path";
            public const string options_ctrl_name_attr = "name";
            public const string options_control_tag_name = "control";
            public const string options_ctrl_values_attr = "values";

            // special characters
            public const char options_ctrl_values_separator = ',';
        }
        const int MAX_SUBFOLDER_RELPATH_LEN = 64;

        public List<ProjectComboBoxDetails> projectAdditionalOptions { get; } = new List<ProjectComboBoxDetails>(); // additional project options for a project which uses this component
        public List<string> ExecutableFileFormats { get; } = new List<string>();
        
        public List<string> SrcExtensions { get; } = new List<string>() ; // key = file extension; value = method used to analyze the contents of a corresponding file type; if the first character of the extension int the component configuration is not a dot ('.'), the dot is prepended to the string when it is added to this list

        /// <summary>
        /// Creates a new Programming Language component
        /// </summary>
        /// <param name="Name"> Must be unique </param>
        /// <param name="Version"> Component version </param>
        /// <param name="Timestamp"> InvariantCulture, universal time </param>
        /// <param name="Description"> Component description (from the configuration file) </param>
        /// <param name="configRoot"> Configuration root element </param>
        public ProgrammingLanguage(string Name, string Version, DateTime Timestamp, string Description, XmlNode configRoot) : base(Name, Version, Timestamp, Description)
        {
            try
            {
                // parse programming language configuration
                foreach (XmlNode componentConfigElement in configRoot.ChildNodes)
                {

                    switch (componentConfigElement.Name)
                    {
                        case ProgrammingLanguage.CONFIG_TAGS.description:
                            {
                                // the description is kept as a read-only property, thus is extracted before the constructor is called
                                break;
                            }

                        case ProgrammingLanguage.CONFIG_TAGS.project:
                            {
                                //determine controls to be added to the new project configuration form
                                foreach (XmlNode projectConfigElement in componentConfigElement.ChildNodes)
                                {
                                    switch (projectConfigElement.Name)
                                    {
                                        case ProgrammingLanguage.CONFIG_TAGS.project_options:
                                            {
                                                //  add the label and combo-box controls to the new project configuration list of controls
                                                foreach (XmlNode projectOption in projectConfigElement.ChildNodes)
                                                    if(projectOption.Name.Equals(ProgrammingLanguage.CONFIG_TAGS.options_control_tag_name)) this.projectAdditionalOptions.Add(new ProjectComboBoxDetails(projectOption.Attributes[ProgrammingLanguage.CONFIG_TAGS.options_ctrl_name_attr].Value, projectOption.Attributes[ProgrammingLanguage.CONFIG_TAGS.options_ctrl_values_attr].Value.Split(ProgrammingLanguage.CONFIG_TAGS.options_ctrl_values_separator).ToList()));

                                                break;
                                            }
                                        case ProgrammingLanguage.CONFIG_TAGS.project_subfolders: // subfolder(s) to add to add in the root folder of the project (if this is a path, all subfolders will be created)
                                            {
                                                //create sub-folder
                                                string subfolderPath;

                                                foreach (XmlNode projectSubfolder in projectConfigElement.ChildNodes)
                                                {
                                                    subfolderPath = projectSubfolder.Attributes[ProgrammingLanguage.CONFIG_TAGS.subfolder_relpath_attr].Value.Trim();
                                                    if (projectSubfolder.Name.Equals(ProgrammingLanguage.CONFIG_TAGS.subfolder) &&
                                                            subfolderPath.Length < MAX_SUBFOLDER_RELPATH_LEN)
                                                        Directory.CreateDirectory(subfolderPath);
                                                }

                                                break;
                                            }
                                        case ProgrammingLanguage.CONFIG_TAGS.project_executable_file_formats: // subfolder(s) to add to add in the root folder of the project (if this is a path, all subfolders will be created)
                                            {
                                                string[] extensionList;

                                                foreach (XmlNode executableFileFormat in projectConfigElement.ChildNodes)
                                                {
                                                    if (executableFileFormat.Name.Equals(ProgrammingLanguage.CONFIG_TAGS.executable_file_tag))
                                                        if (executableFileFormat.Attributes["extension"] != null)
                                                        {
                                                            //=// Add supported executable file extension (only the last extension is considered; e.g., if the string ".abc.def.ghi" is provided, ".ghi" will be considered the extension)
                                                            extensionList = executableFileFormat.Attributes["extension"].Value.Trim().ToLower().Split('.');
                                                            
                                                            if (extensionList.Length==1 || extensionList[extensionList.Length-1].StartsWith(".") == false) 
                                                                extensionList[extensionList.Length-1] = '.' + extensionList[extensionList.Length-1]; //=> prepend dot if not existent
                                                            
                                                            if (this.ExecutableFileFormats.Contains(extensionList[extensionList.Length-1])==false) 
                                                                this.ExecutableFileFormats.Add(extensionList[extensionList.Length-1]); //=> add file extension to the list of executable file formats
                                                        }
                                                }

                                                break;
                                            }

                                        case ProgrammingLanguage.CONFIG_TAGS.src_files: // subfolder(s) to add to add in the root folder of the project (if this is a path, all subfolders will be created)
                                            {
                                                string[] extensionList;

                                                foreach (XmlNode srcFileFormat in projectConfigElement.ChildNodes)
                                                {
                                                    if (srcFileFormat.Name.Equals(ProgrammingLanguage.CONFIG_TAGS.src_file))
                                                        if (srcFileFormat.Attributes["extension"] != null)
                                                        {
                                                            //=// Add supported executable file extension (only the last extension is considered; e.g., if the string ".abc.def.ghi" is provided, ".ghi" will be considered the extension)
                                                            extensionList = srcFileFormat.Attributes["extension"].Value.Trim().ToLower().Split('.');
                                                            
                                                            if (extensionList.Length == 1 || extensionList[extensionList.Length - 1].StartsWith(".") == false) 
                                                                extensionList[extensionList.Length - 1] = '.' + extensionList[extensionList.Length - 1]; //=> prepend dot if not existent

                                                            if (this.SrcExtensions.Contains(extensionList[extensionList.Length - 1]) == false)
                                                                this.SrcExtensions.Add(extensionList[extensionList.Length - 1]); //=> extension
                                                        }
                                                }

                                                break;
                                            }

                                        default: // unrecognized control
                                            {
                                                Diagnostics.LogSilentEvent(DefaultEventCodes.ERR_LOADING_COMPONENT_CTRL_FROM_FILE, projectConfigElement.Name);
                                                break;
                                            }
                                    }
                                }
                                break;
                            }

                        case ProgrammingLanguage.CONFIG_TAGS.grammar:
                            {
                                //TODO: Implement gramamr loading
                                break;
                            }

                        default: // unrecognized configuration node
                            {
                                Diagnostics.LogSilentEvent(DefaultEventCodes.GENERAL_ERR_LOADING_COMPONENT, componentConfigElement.Name);
                                break;
                            }
                    }
                }

                //=// Search for and link to the other required classes and methods
            

            }
            catch (Exception ex) // error loading the component configuration
            {
                Diagnostics.LogSilentEvent(DefaultEventCodes.GENERAL_ERR_LOADING_COMPONENT, ex.Message);
            }

            

        }

        /// <summary>
        /// Display the Programming Language component details
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string str;

            str = base.ToString();

            // add type-specific attributes
            str += "Type: Programming Language\n";
            str += "\n";

            return str;
        }

        /// <summary>
        /// Returns a list of controls which represent additional settings to be configured if this component is used to create a new project.
        /// </summary>
        /// <returns> List ProjectComboBoxDetail </returns>
        override public List<ProjectComboBoxDetails> GetAdditionOptionControls()
        {
            return this.projectAdditionalOptions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Contains attributes used to store details about a given project item (displayed in the project structure tree view), 
    /// such as if is a supported file type or an executable file type for a given project.
    /// </summary>
    internal class ProjectItemInfo
    {
        public string FileNameAndExt { get; } = null; //=> item name (displayed in the project structure tree view); it must be a file containing an extension
        public string FilePath { get; } = null;

        public bool srcFile { get; } //=> true if the file extension is one of the supported src file formats for the given project
        public bool execFile { get; } //=> true if the file extension is one of the supported executable file formats for the given project
        
        public ProjectItemInfo(string Name, string FilePath, Project project) 
        {             
            if(project != null)
            {
                string extension;

                this.FileNameAndExt = Name;
                this.FilePath = FilePath;
                extension = "." + this.FileNameAndExt.Split('.')[1]; //=> get file extension string

                //=// Determine if this file type is supported by the project and if it is an executable file type
                this.srcFile = project.Component.SrcExtensions.Contains(extension);
                this.execFile = project.Component.ExecutableFileFormats.Contains(extension);
            }
            // else //=> invalid project
            
        }
    }
}

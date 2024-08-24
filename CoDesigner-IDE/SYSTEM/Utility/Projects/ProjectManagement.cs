using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Tracks IDE projects
    /// </summary>
    public static class ProjectManagement
    {
        public static Dictionary<string,Project> Projects = new Dictionary<string, Project>(); //list of actively; project filepath, Project object loaded projects
    }
}

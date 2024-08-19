using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Tracks IDE projects
    /// </summary>
    internal static class ProjectManagement
    {
        public static List<Project> Projects = new List<Project>(); //list of actively loaded projects
    }
}

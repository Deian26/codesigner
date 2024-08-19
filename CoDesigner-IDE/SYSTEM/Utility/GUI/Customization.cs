using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Handles user preferences
    /// </summary>
    public static class Customization
    {
        public static string Language { get; set; } = "EN"; //GUI language
        public static string Theme { get; set; } = "DEFAULT"; //GUI theme
    }
}

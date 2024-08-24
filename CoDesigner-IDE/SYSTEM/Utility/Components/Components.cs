using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Tracks used components
    /// </summary>
    internal static class Components
    {
        public static Dictionary<string,Component> LoadedComponents = new Dictionary<string, Component>();
    }
}

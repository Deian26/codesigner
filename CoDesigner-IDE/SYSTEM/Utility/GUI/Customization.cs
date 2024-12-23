using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// <summary>
        /// Defines default fonts
        /// </summary>
        public static class DefaultFonts
        {
            public static Font DefaultFont = new Font(new FontFamily(Customization.FONT_FAMILIY_NAME),Customization.FontSizePts,FontStyle.Bold);
        }

        public static string Language { get; set; } = "EN"; //GUI language
        public static string Theme { get; set; } = "DEFAULT"; //GUI theme
        public static int FontSizePts { get; set; } = 12;

        public const string FONT_FAMILIY_NAME = "Cascadia Code";
    }
}

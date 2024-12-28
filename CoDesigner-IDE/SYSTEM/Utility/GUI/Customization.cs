using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
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
        [SupportedOSPlatform("windows")]
        public static class DefaultFonts
        {
            /// <summary>
            /// Default font
            /// </summary>
            public static Font DefaultFont = new Font(new FontFamily(Customization.FONT_FAMILIY_NAME),Customization.FontSizePts,FontStyle.Bold);
        }

        /// <summary>
        /// GUI Language
        /// </summary>
        public static string Language { get; set; } = "EN";

        /// <summary>
        /// GUI Theme
        /// </summary>
        public static string Theme { get; set; } = "DEFAULT";

        /// <summary>
        /// Font size (in points)
        /// </summary>
        public static int FontSizePts { get; set; } = 12;

        /// <summary>
        /// Font family name
        /// </summary>
        public const string FONT_FAMILIY_NAME = "Cascadia Code";
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE.FORMS.IDE.Utility
{
    /// <summary>
    /// Displays text in a separate, dialog form
    /// </summary>
    public partial class F5_DisplayText : Form
    {
        private string text { get; } = null;
        private string filePath { get; } = null;

        /// <summary>
        /// Constructs a form that displays text in a separate, dialog form
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="filePath">Can be null, if the text is not read from a file</param>
        [SupportedOSPlatform("windows")]
        public F5_DisplayText(string text, string filePath)
        {
            InitializeComponent();

            // store text details
            this.text = text;
            this.filePath = filePath;

            // display text
            this.F5_richTextBox_Text.Text = text;
            this.F5_textBox_FilePath.Text = filePath;
        }

        private void F5_DisplayLog_Load(object sender, EventArgs e)
        {

        }

        private void F5_DisplayText_ResizeBegin(object sender, EventArgs e)
        {

        }
    }
}

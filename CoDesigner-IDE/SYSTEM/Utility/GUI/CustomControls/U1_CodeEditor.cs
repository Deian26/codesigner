using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    [SupportedOSPlatform("windows")]
    public partial class U1_CodeEditor : UserControl
    {
        private F3_1_TextEditor containerForm { get; } = null;

        /// <summary>
        /// Creates a user form (control) designed for code editing
        /// </summary>
        /// <param name="containerForm">The form which contains this form (control)</param>
        /// <param name="code">Code to be displayed and edited</param>
        public U1_CodeEditor(F3_1_TextEditor containerForm, string code)
        {
            InitializeComponent();

            this.containerForm = containerForm;

            // add line labels for the initial code
            this.U1_richTextBox_CodeEditor.Text = code;
            int codeLines = code.Split('\n').Length;

            for (int i = 1; i <= codeLines; i++)
            {
                this.U1_listBox_CodeLines.Items.Add(i);
            }

            if (this.U1_listBox_CodeLines.Items.Count == 0)
            {
                this.U1_listBox_CodeLines.Items.Add("1"); //=> add the first line by default
            }
        }

        private void U1_CodeEditor_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Returns the rich text box used to edit the code
        /// </summary>
        /// <returns> RichTextBox control </returns>
        public RichTextBox GetCodeTextEditor()
        {
            return this.U1_richTextBox_CodeEditor;
        }

        #region utility
        /// <summary>
        /// Adds a new line label in the left panel of the control (form)
        /// </summary>
        private void addLineLabel()
        {
            this.U1_listBox_CodeLines.Items.Add((this.U1_listBox_CodeLines.Items.Count + 1).ToString());
            //=// Automatically sync scroll with the code editor textbox
            this.U1_listBox_CodeLines.TopIndex = this.U1_listBox_CodeLines.Items.Count - 1;
        }
        #endregion

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Call container form methods for code processing
        private void U1_richTextBox_CodeEditor_TextChanged(object sender, EventArgs e)
        {
            this.containerForm.CodeUpdated(); //=> main editor form actions

        }

        private void U1_richTextBox_CodeEditor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void U1_richTextBox_CodeEditor_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) //=> Enter key pressed (new line)
            {
                this.addLineLabel(); //=> add new line label in the left panel
            }
        }

        private void U1_listBox_CodeLines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void U1_listBox_CodeLines_ControlAdded(object sender, ControlEventArgs e)
        {
            //=// New line (item) added
        }
    }
}

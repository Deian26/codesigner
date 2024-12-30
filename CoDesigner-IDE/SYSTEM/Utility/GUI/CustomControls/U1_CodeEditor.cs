using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    public partial class U1_CodeEditor : UserControl
    {
        private F3_1_TextEditor containerForm { get; } = null;
        public U1_CodeEditor(F3_1_TextEditor containerForm)
        {
            InitializeComponent();

            this.containerForm = containerForm;
        }

        private void U1_CodeEditor_Load(object sender, EventArgs e)
        {
            this.U1_listBox_CodeLines.Items.Clear();
            this.U1_listBox_CodeLines.Items.Add("1"); //=> add the first line by default
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
            this.U1_listBox_CodeLines.Items.Add((this.U1_listBox_CodeLines.Items.Count+1).ToString());
            //=// Automatically sync scroll with the code editor textbox
            this.U1_listBox_CodeLines.TopIndex = this.U1_listBox_CodeLines.Items.Count-1;
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
    }
}

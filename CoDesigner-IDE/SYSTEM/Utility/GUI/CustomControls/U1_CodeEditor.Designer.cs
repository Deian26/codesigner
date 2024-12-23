namespace CoDesigner_IDE
{
    partial class U1_CodeEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.U1_richTextBox_CodeEditor = new System.Windows.Forms.RichTextBox();
            this.U1_splitContainer_CodeEditor = new System.Windows.Forms.SplitContainer();
            this.U1_listBox_CodeLines = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.U1_splitContainer_CodeEditor)).BeginInit();
            this.U1_splitContainer_CodeEditor.Panel1.SuspendLayout();
            this.U1_splitContainer_CodeEditor.Panel2.SuspendLayout();
            this.U1_splitContainer_CodeEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // U1_richTextBox_CodeEditor
            // 
            this.U1_richTextBox_CodeEditor.AcceptsTab = true;
            this.U1_richTextBox_CodeEditor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.U1_richTextBox_CodeEditor.DetectUrls = false;
            this.U1_richTextBox_CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.U1_richTextBox_CodeEditor.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.U1_richTextBox_CodeEditor.Location = new System.Drawing.Point(0, 0);
            this.U1_richTextBox_CodeEditor.Name = "U1_richTextBox_CodeEditor";
            this.U1_richTextBox_CodeEditor.Size = new System.Drawing.Size(686, 423);
            this.U1_richTextBox_CodeEditor.TabIndex = 0;
            this.U1_richTextBox_CodeEditor.Text = "";
            this.U1_richTextBox_CodeEditor.WordWrap = false;
            this.U1_richTextBox_CodeEditor.TextChanged += new System.EventHandler(this.U1_richTextBox_CodeEditor_TextChanged);
            this.U1_richTextBox_CodeEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.U1_richTextBox_CodeEditor_KeyDown);
            this.U1_richTextBox_CodeEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.U1_richTextBox_CodeEditor_KeyPress);
            // 
            // U1_splitContainer_CodeEditor
            // 
            this.U1_splitContainer_CodeEditor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.U1_splitContainer_CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.U1_splitContainer_CodeEditor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.U1_splitContainer_CodeEditor.IsSplitterFixed = true;
            this.U1_splitContainer_CodeEditor.Location = new System.Drawing.Point(0, 0);
            this.U1_splitContainer_CodeEditor.Name = "U1_splitContainer_CodeEditor";
            // 
            // U1_splitContainer_CodeEditor.Panel1
            // 
            this.U1_splitContainer_CodeEditor.Panel1.Controls.Add(this.U1_listBox_CodeLines);
            this.U1_splitContainer_CodeEditor.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // U1_splitContainer_CodeEditor.Panel2
            // 
            this.U1_splitContainer_CodeEditor.Panel2.Controls.Add(this.U1_richTextBox_CodeEditor);
            this.U1_splitContainer_CodeEditor.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.U1_splitContainer_CodeEditor.Size = new System.Drawing.Size(738, 423);
            this.U1_splitContainer_CodeEditor.SplitterDistance = 48;
            this.U1_splitContainer_CodeEditor.TabIndex = 2;
            // 
            // U1_listBox_CodeLines
            // 
            this.U1_listBox_CodeLines.BackColor = System.Drawing.SystemColors.ControlDark;
            this.U1_listBox_CodeLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.U1_listBox_CodeLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.U1_listBox_CodeLines.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.U1_listBox_CodeLines.FormattingEnabled = true;
            this.U1_listBox_CodeLines.ItemHeight = 27;
            this.U1_listBox_CodeLines.Location = new System.Drawing.Point(0, 0);
            this.U1_listBox_CodeLines.Name = "U1_listBox_CodeLines";
            this.U1_listBox_CodeLines.Size = new System.Drawing.Size(48, 423);
            this.U1_listBox_CodeLines.TabIndex = 0;
            this.U1_listBox_CodeLines.SelectedIndexChanged += new System.EventHandler(this.U1_listBox_CodeLines_SelectedIndexChanged);
            // 
            // U1_CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.U1_splitContainer_CodeEditor);
            this.Name = "U1_CodeEditor";
            this.Size = new System.Drawing.Size(738, 423);
            this.Load += new System.EventHandler(this.U1_CodeEditor_Load);
            this.U1_splitContainer_CodeEditor.Panel1.ResumeLayout(false);
            this.U1_splitContainer_CodeEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.U1_splitContainer_CodeEditor)).EndInit();
            this.U1_splitContainer_CodeEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox U1_richTextBox_CodeEditor;
        private System.Windows.Forms.SplitContainer U1_splitContainer_CodeEditor;
        private System.Windows.Forms.ListBox U1_listBox_CodeLines;
    }
}

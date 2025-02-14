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
            U1_richTextBox_CodeEditor = new System.Windows.Forms.RichTextBox();
            U1_splitContainer_CodeEditor = new System.Windows.Forms.SplitContainer();
            U1_listBox_CodeLines = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)U1_splitContainer_CodeEditor).BeginInit();
            U1_splitContainer_CodeEditor.Panel1.SuspendLayout();
            U1_splitContainer_CodeEditor.Panel2.SuspendLayout();
            U1_splitContainer_CodeEditor.SuspendLayout();
            SuspendLayout();
            // 
            // U1_richTextBox_CodeEditor
            // 
            U1_richTextBox_CodeEditor.AcceptsTab = true;
            U1_richTextBox_CodeEditor.BackColor = System.Drawing.SystemColors.ControlLight;
            U1_richTextBox_CodeEditor.DetectUrls = false;
            U1_richTextBox_CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            U1_richTextBox_CodeEditor.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            U1_richTextBox_CodeEditor.Location = new System.Drawing.Point(0, 0);
            U1_richTextBox_CodeEditor.Name = "U1_richTextBox_CodeEditor";
            U1_richTextBox_CodeEditor.Size = new System.Drawing.Size(549, 397);
            U1_richTextBox_CodeEditor.TabIndex = 0;
            U1_richTextBox_CodeEditor.Text = "";
            U1_richTextBox_CodeEditor.WordWrap = false;
            U1_richTextBox_CodeEditor.TextChanged += U1_richTextBox_CodeEditor_TextChanged;
            U1_richTextBox_CodeEditor.KeyDown += U1_richTextBox_CodeEditor_KeyDown;
            U1_richTextBox_CodeEditor.KeyPress += U1_richTextBox_CodeEditor_KeyPress;
            // 
            // U1_splitContainer_CodeEditor
            // 
            U1_splitContainer_CodeEditor.BackColor = System.Drawing.SystemColors.ControlDark;
            U1_splitContainer_CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            U1_splitContainer_CodeEditor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            U1_splitContainer_CodeEditor.Location = new System.Drawing.Point(0, 0);
            U1_splitContainer_CodeEditor.Name = "U1_splitContainer_CodeEditor";
            // 
            // U1_splitContainer_CodeEditor.Panel1
            // 
            U1_splitContainer_CodeEditor.Panel1.Controls.Add(U1_listBox_CodeLines);
            U1_splitContainer_CodeEditor.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // U1_splitContainer_CodeEditor.Panel2
            // 
            U1_splitContainer_CodeEditor.Panel2.Controls.Add(U1_richTextBox_CodeEditor);
            U1_splitContainer_CodeEditor.Panel2.Paint += splitContainer1_Panel2_Paint;
            U1_splitContainer_CodeEditor.Size = new System.Drawing.Size(646, 397);
            U1_splitContainer_CodeEditor.SplitterDistance = 93;
            U1_splitContainer_CodeEditor.TabIndex = 2;
            // 
            // U1_listBox_CodeLines
            // 
            U1_listBox_CodeLines.BackColor = System.Drawing.SystemColors.ControlDark;
            U1_listBox_CodeLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            U1_listBox_CodeLines.Dock = System.Windows.Forms.DockStyle.Fill;
            U1_listBox_CodeLines.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            U1_listBox_CodeLines.FormattingEnabled = true;
            U1_listBox_CodeLines.ItemHeight = 21;
            U1_listBox_CodeLines.Location = new System.Drawing.Point(0, 0);
            U1_listBox_CodeLines.Name = "U1_listBox_CodeLines";
            U1_listBox_CodeLines.Size = new System.Drawing.Size(93, 397);
            U1_listBox_CodeLines.TabIndex = 0;
            U1_listBox_CodeLines.SelectedIndexChanged += U1_listBox_CodeLines_SelectedIndexChanged;
            U1_listBox_CodeLines.ControlAdded += U1_listBox_CodeLines_ControlAdded;
            // 
            // U1_CodeEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLight;
            Controls.Add(U1_splitContainer_CodeEditor);
            Name = "U1_CodeEditor";
            Size = new System.Drawing.Size(646, 397);
            Load += U1_CodeEditor_Load;
            U1_splitContainer_CodeEditor.Panel1.ResumeLayout(false);
            U1_splitContainer_CodeEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)U1_splitContainer_CodeEditor).EndInit();
            U1_splitContainer_CodeEditor.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox U1_richTextBox_CodeEditor;
        private System.Windows.Forms.SplitContainer U1_splitContainer_CodeEditor;
        private System.Windows.Forms.ListBox U1_listBox_CodeLines;
    }
}

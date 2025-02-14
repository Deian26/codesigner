namespace CoDesigner_IDE.FORMS.IDE.Utility
{
    partial class F5_DisplayText
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            F5_richTextBox_Text = new System.Windows.Forms.RichTextBox();
            F5_textBox_FilePath = new System.Windows.Forms.TextBox();
            F5_splitContainer_TextContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)F5_splitContainer_TextContainer).BeginInit();
            F5_splitContainer_TextContainer.Panel1.SuspendLayout();
            F5_splitContainer_TextContainer.Panel2.SuspendLayout();
            F5_splitContainer_TextContainer.SuspendLayout();
            SuspendLayout();
            // 
            // F5_richTextBox_Text
            // 
            F5_richTextBox_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            F5_richTextBox_Text.Location = new System.Drawing.Point(0, 0);
            F5_richTextBox_Text.Name = "F5_richTextBox_Text";
            F5_richTextBox_Text.ReadOnly = true;
            F5_richTextBox_Text.Size = new System.Drawing.Size(651, 451);
            F5_richTextBox_Text.TabIndex = 0;
            F5_richTextBox_Text.Text = "";
            // 
            // F5_textBox_FilePath
            // 
            F5_textBox_FilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            F5_textBox_FilePath.Location = new System.Drawing.Point(0, 0);
            F5_textBox_FilePath.Name = "F5_textBox_FilePath";
            F5_textBox_FilePath.ReadOnly = true;
            F5_textBox_FilePath.Size = new System.Drawing.Size(651, 21);
            F5_textBox_FilePath.TabIndex = 1;
            // 
            // F5_splitContainer_TextContainer
            // 
            F5_splitContainer_TextContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            F5_splitContainer_TextContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            F5_splitContainer_TextContainer.IsSplitterFixed = true;
            F5_splitContainer_TextContainer.Location = new System.Drawing.Point(0, 0);
            F5_splitContainer_TextContainer.Name = "F5_splitContainer_TextContainer";
            F5_splitContainer_TextContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // F5_splitContainer_TextContainer.Panel1
            // 
            F5_splitContainer_TextContainer.Panel1.Controls.Add(F5_textBox_FilePath);
            // 
            // F5_splitContainer_TextContainer.Panel2
            // 
            F5_splitContainer_TextContainer.Panel2.Controls.Add(F5_richTextBox_Text);
            F5_splitContainer_TextContainer.Size = new System.Drawing.Size(651, 480);
            F5_splitContainer_TextContainer.SplitterDistance = 25;
            F5_splitContainer_TextContainer.TabIndex = 2;
            // 
            // F5_DisplayText
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(651, 480);
            Controls.Add(F5_splitContainer_TextContainer);
            Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Name = "F5_DisplayText";
            Text = "Log";
            Load += F5_DisplayLog_Load;
            ResizeBegin += F5_DisplayText_ResizeBegin;
            F5_splitContainer_TextContainer.Panel1.ResumeLayout(false);
            F5_splitContainer_TextContainer.Panel1.PerformLayout();
            F5_splitContainer_TextContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)F5_splitContainer_TextContainer).EndInit();
            F5_splitContainer_TextContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox F5_richTextBox_Text;
        private System.Windows.Forms.TextBox F5_textBox_FilePath;
        private System.Windows.Forms.SplitContainer F5_splitContainer_TextContainer;
    }
}
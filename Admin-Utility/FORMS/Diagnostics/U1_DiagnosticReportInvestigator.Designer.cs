namespace Admin_Utility.FORMS.Diagnostics
{
    partial class U1_DiagnosticReportInvestigator
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
            U1_splitContainer_DiagReportViewerContainer = new System.Windows.Forms.SplitContainer();
            U1_textBox_DiagReportFilePath = new System.Windows.Forms.TextBox();
            U1_treeView_DiagReportViewer = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)U1_splitContainer_DiagReportViewerContainer).BeginInit();
            U1_splitContainer_DiagReportViewerContainer.Panel1.SuspendLayout();
            U1_splitContainer_DiagReportViewerContainer.Panel2.SuspendLayout();
            U1_splitContainer_DiagReportViewerContainer.SuspendLayout();
            SuspendLayout();
            // 
            // U1_splitContainer_DiagReportViewerContainer
            // 
            U1_splitContainer_DiagReportViewerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            U1_splitContainer_DiagReportViewerContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            U1_splitContainer_DiagReportViewerContainer.IsSplitterFixed = true;
            U1_splitContainer_DiagReportViewerContainer.Location = new System.Drawing.Point(0, 0);
            U1_splitContainer_DiagReportViewerContainer.Name = "U1_splitContainer_DiagReportViewerContainer";
            U1_splitContainer_DiagReportViewerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // U1_splitContainer_DiagReportViewerContainer.Panel1
            // 
            U1_splitContainer_DiagReportViewerContainer.Panel1.Controls.Add(U1_textBox_DiagReportFilePath);
            // 
            // U1_splitContainer_DiagReportViewerContainer.Panel2
            // 
            U1_splitContainer_DiagReportViewerContainer.Panel2.Controls.Add(U1_treeView_DiagReportViewer);
            U1_splitContainer_DiagReportViewerContainer.Size = new System.Drawing.Size(800, 480);
            U1_splitContainer_DiagReportViewerContainer.SplitterDistance = 25;
            U1_splitContainer_DiagReportViewerContainer.TabIndex = 0;
            // 
            // U1_textBox_DiagReportFilePath
            // 
            U1_textBox_DiagReportFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            U1_textBox_DiagReportFilePath.Location = new System.Drawing.Point(0, 0);
            U1_textBox_DiagReportFilePath.Name = "U1_textBox_DiagReportFilePath";
            U1_textBox_DiagReportFilePath.ReadOnly = true;
            U1_textBox_DiagReportFilePath.Size = new System.Drawing.Size(800, 21);
            U1_textBox_DiagReportFilePath.TabIndex = 0;
            // 
            // U1_treeView_DiagReportViewer
            // 
            U1_treeView_DiagReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            U1_treeView_DiagReportViewer.Location = new System.Drawing.Point(0, 0);
            U1_treeView_DiagReportViewer.Name = "U1_treeView_DiagReportViewer";
            U1_treeView_DiagReportViewer.Size = new System.Drawing.Size(800, 451);
            U1_treeView_DiagReportViewer.TabIndex = 0;
            U1_treeView_DiagReportViewer.AfterSelect += U1_treeView_DiagReportViewer_AfterSelect;
            // 
            // U1_DiagnosticReportInvestigator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(800, 480);
            Controls.Add(U1_splitContainer_DiagReportViewerContainer);
            Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Name = "U1_DiagnosticReportInvestigator";
            Text = "Diagnostic Report Investigator";
            Load += U1_DiagnosticReportInvestigator_Load;
            U1_splitContainer_DiagReportViewerContainer.Panel1.ResumeLayout(false);
            U1_splitContainer_DiagReportViewerContainer.Panel1.PerformLayout();
            U1_splitContainer_DiagReportViewerContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)U1_splitContainer_DiagReportViewerContainer).EndInit();
            U1_splitContainer_DiagReportViewerContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer U1_splitContainer_DiagReportViewerContainer;
        private System.Windows.Forms.TreeView U1_treeView_DiagReportViewer;
        private System.Windows.Forms.TextBox U1_textBox_DiagReportFilePath;
    }
}
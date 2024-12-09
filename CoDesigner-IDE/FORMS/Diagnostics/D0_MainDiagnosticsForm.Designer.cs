namespace CoDesigner_IDE
{
    partial class D0_MainDiagnosticsForm
    {
        /// <summary>
        /// Required designer Variable.
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
            this.D0_listBox_DiagnosticLog = new System.Windows.Forms.ListBox();
            this.D0_groupBox_DiagnosticLog = new System.Windows.Forms.GroupBox();
            this.D0_groupBox_Status = new System.Windows.Forms.GroupBox();
            this.D0_groupBox_Actions = new System.Windows.Forms.GroupBox();
            this.D0_textBox_SelectedControlActions = new System.Windows.Forms.TextBox();
            this.D0_groupBox_Elements = new System.Windows.Forms.GroupBox();
            this.D0_treeView_LoadedElements = new System.Windows.Forms.TreeView();
            this.D0_richTextBox_DetailsAboutSelectedElement = new System.Windows.Forms.RichTextBox();
            this.D0_groupBox_ElementDetails = new System.Windows.Forms.GroupBox();
            this.D0_button_Actions_CheckLocalFiles = new System.Windows.Forms.Button();
            this.D0_checkBox_AllowThirdPartyComponents = new System.Windows.Forms.CheckBox();
            this.D0_richTextBox_StatusVersions = new System.Windows.Forms.RichTextBox();
            this.D0_label_StatusVersions = new System.Windows.Forms.Label();
            this.D0_groupBox_DiagnosticLog.SuspendLayout();
            this.D0_groupBox_Status.SuspendLayout();
            this.D0_groupBox_Actions.SuspendLayout();
            this.D0_groupBox_Elements.SuspendLayout();
            this.D0_groupBox_ElementDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // D0_listBox_DiagnosticLog
            // 
            this.D0_listBox_DiagnosticLog.FormattingEnabled = true;
            this.D0_listBox_DiagnosticLog.ItemHeight = 20;
            this.D0_listBox_DiagnosticLog.Location = new System.Drawing.Point(13, 46);
            this.D0_listBox_DiagnosticLog.Margin = new System.Windows.Forms.Padding(4);
            this.D0_listBox_DiagnosticLog.Name = "D0_listBox_DiagnosticLog";
            this.D0_listBox_DiagnosticLog.Size = new System.Drawing.Size(860, 344);
            this.D0_listBox_DiagnosticLog.TabIndex = 0;
            // 
            // D0_groupBox_DiagnosticLog
            // 
            this.D0_groupBox_DiagnosticLog.Controls.Add(this.D0_listBox_DiagnosticLog);
            this.D0_groupBox_DiagnosticLog.Location = new System.Drawing.Point(20, 349);
            this.D0_groupBox_DiagnosticLog.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_DiagnosticLog.Name = "D0_groupBox_DiagnosticLog";
            this.D0_groupBox_DiagnosticLog.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_DiagnosticLog.Size = new System.Drawing.Size(881, 404);
            this.D0_groupBox_DiagnosticLog.TabIndex = 1;
            this.D0_groupBox_DiagnosticLog.TabStop = false;
            this.D0_groupBox_DiagnosticLog.Text = "Log";
            // 
            // D0_groupBox_Status
            // 
            this.D0_groupBox_Status.Controls.Add(this.D0_label_StatusVersions);
            this.D0_groupBox_Status.Controls.Add(this.D0_richTextBox_StatusVersions);
            this.D0_groupBox_Status.Location = new System.Drawing.Point(19, 20);
            this.D0_groupBox_Status.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Status.Name = "D0_groupBox_Status";
            this.D0_groupBox_Status.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Status.Size = new System.Drawing.Size(247, 321);
            this.D0_groupBox_Status.TabIndex = 2;
            this.D0_groupBox_Status.TabStop = false;
            this.D0_groupBox_Status.Text = "Status";
            // 
            // D0_groupBox_Actions
            // 
            this.D0_groupBox_Actions.Controls.Add(this.D0_checkBox_AllowThirdPartyComponents);
            this.D0_groupBox_Actions.Controls.Add(this.D0_button_Actions_CheckLocalFiles);
            this.D0_groupBox_Actions.Location = new System.Drawing.Point(274, 20);
            this.D0_groupBox_Actions.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Actions.Name = "D0_groupBox_Actions";
            this.D0_groupBox_Actions.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Actions.Size = new System.Drawing.Size(626, 321);
            this.D0_groupBox_Actions.TabIndex = 3;
            this.D0_groupBox_Actions.TabStop = false;
            this.D0_groupBox_Actions.Text = "Actions";
            // 
            // D0_textBox_SelectedControlActions
            // 
            this.D0_textBox_SelectedControlActions.Location = new System.Drawing.Point(6, 31);
            this.D0_textBox_SelectedControlActions.Name = "D0_textBox_SelectedControlActions";
            this.D0_textBox_SelectedControlActions.ReadOnly = true;
            this.D0_textBox_SelectedControlActions.Size = new System.Drawing.Size(429, 27);
            this.D0_textBox_SelectedControlActions.TabIndex = 1;
            // 
            // D0_groupBox_Elements
            // 
            this.D0_groupBox_Elements.Controls.Add(this.D0_treeView_LoadedElements);
            this.D0_groupBox_Elements.Location = new System.Drawing.Point(908, 20);
            this.D0_groupBox_Elements.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Elements.Name = "D0_groupBox_Elements";
            this.D0_groupBox_Elements.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Elements.Size = new System.Drawing.Size(450, 381);
            this.D0_groupBox_Elements.TabIndex = 4;
            this.D0_groupBox_Elements.TabStop = false;
            this.D0_groupBox_Elements.Text = "Elements";
            // 
            // D0_treeView_LoadedElements
            // 
            this.D0_treeView_LoadedElements.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.D0_treeView_LoadedElements.FullRowSelect = true;
            this.D0_treeView_LoadedElements.HideSelection = false;
            this.D0_treeView_LoadedElements.Location = new System.Drawing.Point(10, 31);
            this.D0_treeView_LoadedElements.Margin = new System.Windows.Forms.Padding(4);
            this.D0_treeView_LoadedElements.Name = "D0_treeView_LoadedElements";
            this.D0_treeView_LoadedElements.ShowNodeToolTips = true;
            this.D0_treeView_LoadedElements.Size = new System.Drawing.Size(425, 342);
            this.D0_treeView_LoadedElements.TabIndex = 0;
            this.D0_treeView_LoadedElements.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.D0_treeView_LoadedElements_NodeMouseDoubleClick);
            // 
            // D0_richTextBox_DetailsAboutSelectedElement
            // 
            this.D0_richTextBox_DetailsAboutSelectedElement.Location = new System.Drawing.Point(6, 64);
            this.D0_richTextBox_DetailsAboutSelectedElement.Name = "D0_richTextBox_DetailsAboutSelectedElement";
            this.D0_richTextBox_DetailsAboutSelectedElement.ReadOnly = true;
            this.D0_richTextBox_DetailsAboutSelectedElement.Size = new System.Drawing.Size(429, 264);
            this.D0_richTextBox_DetailsAboutSelectedElement.TabIndex = 2;
            this.D0_richTextBox_DetailsAboutSelectedElement.Text = "";
            // 
            // D0_groupBox_ElementDetails
            // 
            this.D0_groupBox_ElementDetails.Controls.Add(this.D0_textBox_SelectedControlActions);
            this.D0_groupBox_ElementDetails.Controls.Add(this.D0_richTextBox_DetailsAboutSelectedElement);
            this.D0_groupBox_ElementDetails.Location = new System.Drawing.Point(908, 411);
            this.D0_groupBox_ElementDetails.Name = "D0_groupBox_ElementDetails";
            this.D0_groupBox_ElementDetails.Size = new System.Drawing.Size(450, 342);
            this.D0_groupBox_ElementDetails.TabIndex = 5;
            this.D0_groupBox_ElementDetails.TabStop = false;
            this.D0_groupBox_ElementDetails.Text = "Details";
            // 
            // D0_button_Actions_CheckLocalFiles
            // 
            this.D0_button_Actions_CheckLocalFiles.Location = new System.Drawing.Point(7, 31);
            this.D0_button_Actions_CheckLocalFiles.Name = "D0_button_Actions_CheckLocalFiles";
            this.D0_button_Actions_CheckLocalFiles.Size = new System.Drawing.Size(153, 34);
            this.D0_button_Actions_CheckLocalFiles.TabIndex = 0;
            this.D0_button_Actions_CheckLocalFiles.Text = "Check files";
            this.D0_button_Actions_CheckLocalFiles.UseVisualStyleBackColor = true;
            this.D0_button_Actions_CheckLocalFiles.Click += new System.EventHandler(this.D0_button_Actions_CheckLocalFiles_Click);
            // 
            // D0_checkBox_AllowThirdPartyComponents
            // 
            this.D0_checkBox_AllowThirdPartyComponents.AutoSize = true;
            this.D0_checkBox_AllowThirdPartyComponents.Checked = true;
            this.D0_checkBox_AllowThirdPartyComponents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.D0_checkBox_AllowThirdPartyComponents.Location = new System.Drawing.Point(7, 82);
            this.D0_checkBox_AllowThirdPartyComponents.Name = "D0_checkBox_AllowThirdPartyComponents";
            this.D0_checkBox_AllowThirdPartyComponents.Size = new System.Drawing.Size(283, 24);
            this.D0_checkBox_AllowThirdPartyComponents.TabIndex = 1;
            this.D0_checkBox_AllowThirdPartyComponents.Text = "Allow third party components";
            this.D0_checkBox_AllowThirdPartyComponents.UseVisualStyleBackColor = true;
            this.D0_checkBox_AllowThirdPartyComponents.CheckedChanged += new System.EventHandler(this.D0_checkBox_AllowThirdPartyComponents_CheckedChanged);
            // 
            // D0_richTextBox_StatusVersions
            // 
            this.D0_richTextBox_StatusVersions.Location = new System.Drawing.Point(7, 170);
            this.D0_richTextBox_StatusVersions.Name = "D0_richTextBox_StatusVersions";
            this.D0_richTextBox_StatusVersions.ReadOnly = true;
            this.D0_richTextBox_StatusVersions.Size = new System.Drawing.Size(233, 144);
            this.D0_richTextBox_StatusVersions.TabIndex = 3;
            this.D0_richTextBox_StatusVersions.Text = "";
            // 
            // D0_label_StatusVersions
            // 
            this.D0_label_StatusVersions.AutoSize = true;
            this.D0_label_StatusVersions.Location = new System.Drawing.Point(7, 142);
            this.D0_label_StatusVersions.Name = "D0_label_StatusVersions";
            this.D0_label_StatusVersions.Size = new System.Drawing.Size(90, 20);
            this.D0_label_StatusVersions.TabIndex = 4;
            this.D0_label_StatusVersions.Text = "Versions:";
            // 
            // D0_MainDiagnosticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1368, 765);
            this.Controls.Add(this.D0_groupBox_ElementDetails);
            this.Controls.Add(this.D0_groupBox_Elements);
            this.Controls.Add(this.D0_groupBox_Actions);
            this.Controls.Add(this.D0_groupBox_Status);
            this.Controls.Add(this.D0_groupBox_DiagnosticLog);
            this.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "D0_MainDiagnosticsForm";
            this.Text = "Diagnostics";
            this.Load += new System.EventHandler(this.D0_MainDiagnosticsPanel_Load);
            this.D0_groupBox_DiagnosticLog.ResumeLayout(false);
            this.D0_groupBox_Status.ResumeLayout(false);
            this.D0_groupBox_Status.PerformLayout();
            this.D0_groupBox_Actions.ResumeLayout(false);
            this.D0_groupBox_Actions.PerformLayout();
            this.D0_groupBox_Elements.ResumeLayout(false);
            this.D0_groupBox_ElementDetails.ResumeLayout(false);
            this.D0_groupBox_ElementDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox D0_listBox_DiagnosticLog;
        private System.Windows.Forms.GroupBox D0_groupBox_DiagnosticLog;
        private System.Windows.Forms.GroupBox D0_groupBox_Status;
        private System.Windows.Forms.GroupBox D0_groupBox_Actions;
        private System.Windows.Forms.GroupBox D0_groupBox_Elements;
        private System.Windows.Forms.TreeView D0_treeView_LoadedElements;
        private System.Windows.Forms.TextBox D0_textBox_SelectedControlActions;
        private System.Windows.Forms.RichTextBox D0_richTextBox_DetailsAboutSelectedElement;
        private System.Windows.Forms.GroupBox D0_groupBox_ElementDetails;
        private System.Windows.Forms.Button D0_button_Actions_CheckLocalFiles;
        private System.Windows.Forms.CheckBox D0_checkBox_AllowThirdPartyComponents;
        private System.Windows.Forms.RichTextBox D0_richTextBox_StatusVersions;
        private System.Windows.Forms.Label D0_label_StatusVersions;
    }
}
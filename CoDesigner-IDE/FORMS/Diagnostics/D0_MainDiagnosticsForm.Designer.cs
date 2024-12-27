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
            this.D0_button_ExportLog = new System.Windows.Forms.Button();
            this.D0_button_OpenLogsFolder = new System.Windows.Forms.Button();
            this.D0_groupBox_Status = new System.Windows.Forms.GroupBox();
            this.D0_richTextBox_UserStatus = new System.Windows.Forms.RichTextBox();
            this.D0_label_UserStatusLabel = new System.Windows.Forms.Label();
            this.D0_label_StatusVersions = new System.Windows.Forms.Label();
            this.D0_richTextBox_StatusVersions = new System.Windows.Forms.RichTextBox();
            this.D0_groupBox_Actions = new System.Windows.Forms.GroupBox();
            this.D0_groupBox_PerformanceOptions = new System.Windows.Forms.GroupBox();
            this.D0_button_SimPerformanceCheck = new System.Windows.Forms.Button();
            this.D0_groupBox_Customization = new System.Windows.Forms.GroupBox();
            this.D0_button_OpenCustomizationUtility = new System.Windows.Forms.Button();
            this.D0_groupBox_Security = new System.Windows.Forms.GroupBox();
            this.D0_button_Actions_CheckLocalFiles = new System.Windows.Forms.Button();
            this.D0_checkBox_AllowThirdPartyComponents = new System.Windows.Forms.CheckBox();
            this.D0_textBox_SelectedControlActions = new System.Windows.Forms.TextBox();
            this.D0_groupBox_Elements = new System.Windows.Forms.GroupBox();
            this.D0_treeView_LoadedElements = new System.Windows.Forms.TreeView();
            this.D0_richTextBox_DetailsAboutSelectedElement = new System.Windows.Forms.RichTextBox();
            this.D0_groupBox_ElementDetails = new System.Windows.Forms.GroupBox();
            this.D0_saveFileDialog_ExportLog = new System.Windows.Forms.SaveFileDialog();
            this.D0_groupBox_Diagnostics = new System.Windows.Forms.GroupBox();
            this.D0_button_GenerateDiagnosticReport = new System.Windows.Forms.Button();
            this.D0_groupBox_DiagnosticLog.SuspendLayout();
            this.D0_groupBox_Status.SuspendLayout();
            this.D0_groupBox_Actions.SuspendLayout();
            this.D0_groupBox_PerformanceOptions.SuspendLayout();
            this.D0_groupBox_Customization.SuspendLayout();
            this.D0_groupBox_Security.SuspendLayout();
            this.D0_groupBox_Elements.SuspendLayout();
            this.D0_groupBox_ElementDetails.SuspendLayout();
            this.D0_groupBox_Diagnostics.SuspendLayout();
            this.SuspendLayout();
            // 
            // D0_listBox_DiagnosticLog
            // 
            this.D0_listBox_DiagnosticLog.FormattingEnabled = true;
            this.D0_listBox_DiagnosticLog.ItemHeight = 18;
            this.D0_listBox_DiagnosticLog.Location = new System.Drawing.Point(9, 24);
            this.D0_listBox_DiagnosticLog.Margin = new System.Windows.Forms.Padding(4);
            this.D0_listBox_DiagnosticLog.Name = "D0_listBox_DiagnosticLog";
            this.D0_listBox_DiagnosticLog.Size = new System.Drawing.Size(664, 238);
            this.D0_listBox_DiagnosticLog.TabIndex = 0;
            // 
            // D0_groupBox_DiagnosticLog
            // 
            this.D0_groupBox_DiagnosticLog.Controls.Add(this.D0_button_ExportLog);
            this.D0_groupBox_DiagnosticLog.Controls.Add(this.D0_button_OpenLogsFolder);
            this.D0_groupBox_DiagnosticLog.Controls.Add(this.D0_listBox_DiagnosticLog);
            this.D0_groupBox_DiagnosticLog.Location = new System.Drawing.Point(20, 349);
            this.D0_groupBox_DiagnosticLog.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_DiagnosticLog.Name = "D0_groupBox_DiagnosticLog";
            this.D0_groupBox_DiagnosticLog.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_DiagnosticLog.Size = new System.Drawing.Size(681, 311);
            this.D0_groupBox_DiagnosticLog.TabIndex = 1;
            this.D0_groupBox_DiagnosticLog.TabStop = false;
            this.D0_groupBox_DiagnosticLog.Text = "Log";
            // 
            // D0_button_ExportLog
            // 
            this.D0_button_ExportLog.Location = new System.Drawing.Point(521, 269);
            this.D0_button_ExportLog.Name = "D0_button_ExportLog";
            this.D0_button_ExportLog.Size = new System.Drawing.Size(153, 34);
            this.D0_button_ExportLog.TabIndex = 3;
            this.D0_button_ExportLog.Text = "Export log";
            this.D0_button_ExportLog.UseVisualStyleBackColor = true;
            this.D0_button_ExportLog.Click += new System.EventHandler(this.D0_button_ExportLog_Click);
            // 
            // D0_button_OpenLogsFolder
            // 
            this.D0_button_OpenLogsFolder.Location = new System.Drawing.Point(9, 269);
            this.D0_button_OpenLogsFolder.Name = "D0_button_OpenLogsFolder";
            this.D0_button_OpenLogsFolder.Size = new System.Drawing.Size(153, 34);
            this.D0_button_OpenLogsFolder.TabIndex = 2;
            this.D0_button_OpenLogsFolder.Text = "Open logs folder";
            this.D0_button_OpenLogsFolder.UseVisualStyleBackColor = true;
            this.D0_button_OpenLogsFolder.Click += new System.EventHandler(this.D0_button_OpenLogsFolder_Click);
            // 
            // D0_groupBox_Status
            // 
            this.D0_groupBox_Status.Controls.Add(this.D0_richTextBox_UserStatus);
            this.D0_groupBox_Status.Controls.Add(this.D0_label_UserStatusLabel);
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
            // D0_richTextBox_UserStatus
            // 
            this.D0_richTextBox_UserStatus.Location = new System.Drawing.Point(7, 44);
            this.D0_richTextBox_UserStatus.Name = "D0_richTextBox_UserStatus";
            this.D0_richTextBox_UserStatus.ReadOnly = true;
            this.D0_richTextBox_UserStatus.Size = new System.Drawing.Size(233, 94);
            this.D0_richTextBox_UserStatus.TabIndex = 7;
            this.D0_richTextBox_UserStatus.Text = "";
            // 
            // D0_label_UserStatusLabel
            // 
            this.D0_label_UserStatusLabel.AutoSize = true;
            this.D0_label_UserStatusLabel.Location = new System.Drawing.Point(10, 23);
            this.D0_label_UserStatusLabel.Name = "D0_label_UserStatusLabel";
            this.D0_label_UserStatusLabel.Size = new System.Drawing.Size(48, 18);
            this.D0_label_UserStatusLabel.TabIndex = 6;
            this.D0_label_UserStatusLabel.Text = "User:";
            // 
            // D0_label_StatusVersions
            // 
            this.D0_label_StatusVersions.AutoSize = true;
            this.D0_label_StatusVersions.Location = new System.Drawing.Point(7, 142);
            this.D0_label_StatusVersions.Name = "D0_label_StatusVersions";
            this.D0_label_StatusVersions.Size = new System.Drawing.Size(80, 18);
            this.D0_label_StatusVersions.TabIndex = 4;
            this.D0_label_StatusVersions.Text = "Versions:";
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
            // D0_groupBox_Actions
            // 
            this.D0_groupBox_Actions.Controls.Add(this.D0_groupBox_Diagnostics);
            this.D0_groupBox_Actions.Controls.Add(this.D0_groupBox_PerformanceOptions);
            this.D0_groupBox_Actions.Controls.Add(this.D0_groupBox_Customization);
            this.D0_groupBox_Actions.Controls.Add(this.D0_groupBox_Security);
            this.D0_groupBox_Actions.Location = new System.Drawing.Point(274, 20);
            this.D0_groupBox_Actions.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Actions.Name = "D0_groupBox_Actions";
            this.D0_groupBox_Actions.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Actions.Size = new System.Drawing.Size(427, 321);
            this.D0_groupBox_Actions.TabIndex = 3;
            this.D0_groupBox_Actions.TabStop = false;
            this.D0_groupBox_Actions.Text = "Actions";
            // 
            // D0_groupBox_PerformanceOptions
            // 
            this.D0_groupBox_PerformanceOptions.Controls.Add(this.D0_button_SimPerformanceCheck);
            this.D0_groupBox_PerformanceOptions.Location = new System.Drawing.Point(7, 217);
            this.D0_groupBox_PerformanceOptions.Name = "D0_groupBox_PerformanceOptions";
            this.D0_groupBox_PerformanceOptions.Size = new System.Drawing.Size(200, 82);
            this.D0_groupBox_PerformanceOptions.TabIndex = 5;
            this.D0_groupBox_PerformanceOptions.TabStop = false;
            this.D0_groupBox_PerformanceOptions.Text = "Performance";
            // 
            // D0_button_SimPerformanceCheck
            // 
            this.D0_button_SimPerformanceCheck.Location = new System.Drawing.Point(6, 22);
            this.D0_button_SimPerformanceCheck.Name = "D0_button_SimPerformanceCheck";
            this.D0_button_SimPerformanceCheck.Size = new System.Drawing.Size(180, 50);
            this.D0_button_SimPerformanceCheck.TabIndex = 2;
            this.D0_button_SimPerformanceCheck.Text = "Check Simulation Performance";
            this.D0_button_SimPerformanceCheck.UseVisualStyleBackColor = true;
            this.D0_button_SimPerformanceCheck.Click += new System.EventHandler(this.D0_button_SimPerformanceCheck_Click);
            // 
            // D0_groupBox_Customization
            // 
            this.D0_groupBox_Customization.Controls.Add(this.D0_button_OpenCustomizationUtility);
            this.D0_groupBox_Customization.Location = new System.Drawing.Point(213, 217);
            this.D0_groupBox_Customization.Name = "D0_groupBox_Customization";
            this.D0_groupBox_Customization.Size = new System.Drawing.Size(200, 82);
            this.D0_groupBox_Customization.TabIndex = 4;
            this.D0_groupBox_Customization.TabStop = false;
            this.D0_groupBox_Customization.Text = "Customization";
            // 
            // D0_button_OpenCustomizationUtility
            // 
            this.D0_button_OpenCustomizationUtility.Location = new System.Drawing.Point(6, 22);
            this.D0_button_OpenCustomizationUtility.Name = "D0_button_OpenCustomizationUtility";
            this.D0_button_OpenCustomizationUtility.Size = new System.Drawing.Size(180, 50);
            this.D0_button_OpenCustomizationUtility.TabIndex = 2;
            this.D0_button_OpenCustomizationUtility.Text = "Customization Utility";
            this.D0_button_OpenCustomizationUtility.UseVisualStyleBackColor = true;
            this.D0_button_OpenCustomizationUtility.Click += new System.EventHandler(this.D0_button_OpenCustomizationUtility_Click);
            // 
            // D0_groupBox_Security
            // 
            this.D0_groupBox_Security.Controls.Add(this.D0_button_Actions_CheckLocalFiles);
            this.D0_groupBox_Security.Controls.Add(this.D0_checkBox_AllowThirdPartyComponents);
            this.D0_groupBox_Security.Location = new System.Drawing.Point(7, 23);
            this.D0_groupBox_Security.Name = "D0_groupBox_Security";
            this.D0_groupBox_Security.Size = new System.Drawing.Size(413, 100);
            this.D0_groupBox_Security.TabIndex = 3;
            this.D0_groupBox_Security.TabStop = false;
            this.D0_groupBox_Security.Text = "Security";
            // 
            // D0_button_Actions_CheckLocalFiles
            // 
            this.D0_button_Actions_CheckLocalFiles.Location = new System.Drawing.Point(6, 22);
            this.D0_button_Actions_CheckLocalFiles.Name = "D0_button_Actions_CheckLocalFiles";
            this.D0_button_Actions_CheckLocalFiles.Size = new System.Drawing.Size(180, 34);
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
            this.D0_checkBox_AllowThirdPartyComponents.Location = new System.Drawing.Point(6, 62);
            this.D0_checkBox_AllowThirdPartyComponents.Name = "D0_checkBox_AllowThirdPartyComponents";
            this.D0_checkBox_AllowThirdPartyComponents.Size = new System.Drawing.Size(251, 22);
            this.D0_checkBox_AllowThirdPartyComponents.TabIndex = 1;
            this.D0_checkBox_AllowThirdPartyComponents.Text = "Allow third party components";
            this.D0_checkBox_AllowThirdPartyComponents.UseVisualStyleBackColor = true;
            this.D0_checkBox_AllowThirdPartyComponents.CheckedChanged += new System.EventHandler(this.D0_checkBox_AllowThirdPartyComponents_CheckedChanged);
            // 
            // D0_textBox_SelectedControlActions
            // 
            this.D0_textBox_SelectedControlActions.Location = new System.Drawing.Point(6, 31);
            this.D0_textBox_SelectedControlActions.Name = "D0_textBox_SelectedControlActions";
            this.D0_textBox_SelectedControlActions.ReadOnly = true;
            this.D0_textBox_SelectedControlActions.Size = new System.Drawing.Size(370, 23);
            this.D0_textBox_SelectedControlActions.TabIndex = 1;
            // 
            // D0_groupBox_Elements
            // 
            this.D0_groupBox_Elements.Controls.Add(this.D0_treeView_LoadedElements);
            this.D0_groupBox_Elements.Location = new System.Drawing.Point(709, 20);
            this.D0_groupBox_Elements.Margin = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Elements.Name = "D0_groupBox_Elements";
            this.D0_groupBox_Elements.Padding = new System.Windows.Forms.Padding(4);
            this.D0_groupBox_Elements.Size = new System.Drawing.Size(383, 321);
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
            this.D0_treeView_LoadedElements.Size = new System.Drawing.Size(365, 282);
            this.D0_treeView_LoadedElements.TabIndex = 0;
            this.D0_treeView_LoadedElements.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.D0_treeView_LoadedElements_NodeMouseDoubleClick);
            // 
            // D0_richTextBox_DetailsAboutSelectedElement
            // 
            this.D0_richTextBox_DetailsAboutSelectedElement.Location = new System.Drawing.Point(6, 64);
            this.D0_richTextBox_DetailsAboutSelectedElement.Name = "D0_richTextBox_DetailsAboutSelectedElement";
            this.D0_richTextBox_DetailsAboutSelectedElement.ReadOnly = true;
            this.D0_richTextBox_DetailsAboutSelectedElement.Size = new System.Drawing.Size(370, 239);
            this.D0_richTextBox_DetailsAboutSelectedElement.TabIndex = 2;
            this.D0_richTextBox_DetailsAboutSelectedElement.Text = "";
            // 
            // D0_groupBox_ElementDetails
            // 
            this.D0_groupBox_ElementDetails.Controls.Add(this.D0_textBox_SelectedControlActions);
            this.D0_groupBox_ElementDetails.Controls.Add(this.D0_richTextBox_DetailsAboutSelectedElement);
            this.D0_groupBox_ElementDetails.Location = new System.Drawing.Point(709, 349);
            this.D0_groupBox_ElementDetails.Name = "D0_groupBox_ElementDetails";
            this.D0_groupBox_ElementDetails.Size = new System.Drawing.Size(384, 312);
            this.D0_groupBox_ElementDetails.TabIndex = 5;
            this.D0_groupBox_ElementDetails.TabStop = false;
            this.D0_groupBox_ElementDetails.Text = "Details";
            // 
            // D0_groupBox_Diagnostics
            // 
            this.D0_groupBox_Diagnostics.Controls.Add(this.D0_button_GenerateDiagnosticReport);
            this.D0_groupBox_Diagnostics.Location = new System.Drawing.Point(7, 129);
            this.D0_groupBox_Diagnostics.Name = "D0_groupBox_Diagnostics";
            this.D0_groupBox_Diagnostics.Size = new System.Drawing.Size(413, 82);
            this.D0_groupBox_Diagnostics.TabIndex = 5;
            this.D0_groupBox_Diagnostics.TabStop = false;
            this.D0_groupBox_Diagnostics.Text = "Diagnostics";
            // 
            // D0_button_GenerateDiagnosticReport
            // 
            this.D0_button_GenerateDiagnosticReport.Location = new System.Drawing.Point(6, 22);
            this.D0_button_GenerateDiagnosticReport.Name = "D0_button_GenerateDiagnosticReport";
            this.D0_button_GenerateDiagnosticReport.Size = new System.Drawing.Size(105, 50);
            this.D0_button_GenerateDiagnosticReport.TabIndex = 2;
            this.D0_button_GenerateDiagnosticReport.Text = "Generate Report";
            this.D0_button_GenerateDiagnosticReport.UseVisualStyleBackColor = true;
            // 
            // D0_MainDiagnosticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1100, 668);
            this.Controls.Add(this.D0_groupBox_ElementDetails);
            this.Controls.Add(this.D0_groupBox_Elements);
            this.Controls.Add(this.D0_groupBox_Actions);
            this.Controls.Add(this.D0_groupBox_Status);
            this.Controls.Add(this.D0_groupBox_DiagnosticLog);
            this.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "D0_MainDiagnosticsForm";
            this.Text = "Diagnostics";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.D0_MainDiagnosticsForm_FormClosing);
            this.Load += new System.EventHandler(this.D0_MainDiagnosticsPanel_Load);
            this.D0_groupBox_DiagnosticLog.ResumeLayout(false);
            this.D0_groupBox_Status.ResumeLayout(false);
            this.D0_groupBox_Status.PerformLayout();
            this.D0_groupBox_Actions.ResumeLayout(false);
            this.D0_groupBox_PerformanceOptions.ResumeLayout(false);
            this.D0_groupBox_Customization.ResumeLayout(false);
            this.D0_groupBox_Security.ResumeLayout(false);
            this.D0_groupBox_Security.PerformLayout();
            this.D0_groupBox_Elements.ResumeLayout(false);
            this.D0_groupBox_ElementDetails.ResumeLayout(false);
            this.D0_groupBox_ElementDetails.PerformLayout();
            this.D0_groupBox_Diagnostics.ResumeLayout(false);
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
        private System.Windows.Forms.Button D0_button_ExportLog;
        private System.Windows.Forms.Button D0_button_OpenLogsFolder;
        private System.Windows.Forms.SaveFileDialog D0_saveFileDialog_ExportLog;
        private System.Windows.Forms.Button D0_button_OpenCustomizationUtility;
        private System.Windows.Forms.GroupBox D0_groupBox_Customization;
        private System.Windows.Forms.GroupBox D0_groupBox_Security;
        private System.Windows.Forms.GroupBox D0_groupBox_PerformanceOptions;
        private System.Windows.Forms.Button D0_button_SimPerformanceCheck;
        private System.Windows.Forms.RichTextBox D0_richTextBox_UserStatus;
        private System.Windows.Forms.Label D0_label_UserStatusLabel;
        private System.Windows.Forms.GroupBox D0_groupBox_Diagnostics;
        private System.Windows.Forms.Button D0_button_GenerateDiagnosticReport;
    }
}
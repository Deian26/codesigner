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
            components = new System.ComponentModel.Container();
            D0_groupBox_DiagnosticLog = new System.Windows.Forms.GroupBox();
            D0_treeView_DiagnosticEventLog = new System.Windows.Forms.TreeView();
            D0_button_ExportLog = new System.Windows.Forms.Button();
            D0_button_OpenLog = new System.Windows.Forms.Button();
            D0_groupBox_Status = new System.Windows.Forms.GroupBox();
            D0_treeView_DefaultElementsVersions = new System.Windows.Forms.TreeView();
            D0_richTextBox_AccessDetails = new System.Windows.Forms.RichTextBox();
            D0_label_AccessDetailsLabel = new System.Windows.Forms.Label();
            D0_label_StatusVersions = new System.Windows.Forms.Label();
            D0_groupBox_Actions = new System.Windows.Forms.GroupBox();
            D0_groupBox_Diagnostics = new System.Windows.Forms.GroupBox();
            D0_button_GenerateDiagnosticStatusReport = new System.Windows.Forms.Button();
            D0_groupBox_PerformanceOptions = new System.Windows.Forms.GroupBox();
            D0_button_SimPerformanceCheck = new System.Windows.Forms.Button();
            D0_groupBox_Customization = new System.Windows.Forms.GroupBox();
            D0_button_OpenCustomizationUtility = new System.Windows.Forms.Button();
            D0_groupBox_Security = new System.Windows.Forms.GroupBox();
            D0_button_AddApprovedGeneratorId = new System.Windows.Forms.Button();
            D0_button_Actions_CheckLocalFiles = new System.Windows.Forms.Button();
            D0_checkBox_AllowThirdPartyComponents = new System.Windows.Forms.CheckBox();
            D0_textBox_ActionDetailsTitle = new System.Windows.Forms.TextBox();
            D0_groupBox_Elements = new System.Windows.Forms.GroupBox();
            D0_treeView_LoadedElements = new System.Windows.Forms.TreeView();
            D0_groupBox_ElementDetails = new System.Windows.Forms.GroupBox();
            D0_button_ExportActionResults = new System.Windows.Forms.Button();
            D0_treeView_ActionDetails = new System.Windows.Forms.TreeView();
            D0_saveFileDialog_ExportLog = new System.Windows.Forms.SaveFileDialog();
            D0_saveFileDialog_SaveActionReport = new System.Windows.Forms.SaveFileDialog();
            D0_errorProvider_DiagnosticsActionsErrors = new System.Windows.Forms.ErrorProvider(components);
            D0_openFileDialog_LoadLog = new System.Windows.Forms.OpenFileDialog();
            D0_groupBox_DiagnosticLog.SuspendLayout();
            D0_groupBox_Status.SuspendLayout();
            D0_groupBox_Actions.SuspendLayout();
            D0_groupBox_Diagnostics.SuspendLayout();
            D0_groupBox_PerformanceOptions.SuspendLayout();
            D0_groupBox_Customization.SuspendLayout();
            D0_groupBox_Security.SuspendLayout();
            D0_groupBox_Elements.SuspendLayout();
            D0_groupBox_ElementDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)D0_errorProvider_DiagnosticsActionsErrors).BeginInit();
            SuspendLayout();
            // 
            // D0_groupBox_DiagnosticLog
            // 
            D0_groupBox_DiagnosticLog.Controls.Add(D0_treeView_DiagnosticEventLog);
            D0_groupBox_DiagnosticLog.Controls.Add(D0_button_ExportLog);
            D0_groupBox_DiagnosticLog.Controls.Add(D0_button_OpenLog);
            D0_groupBox_DiagnosticLog.Location = new System.Drawing.Point(20, 349);
            D0_groupBox_DiagnosticLog.Margin = new System.Windows.Forms.Padding(4);
            D0_groupBox_DiagnosticLog.Name = "D0_groupBox_DiagnosticLog";
            D0_groupBox_DiagnosticLog.Padding = new System.Windows.Forms.Padding(4);
            D0_groupBox_DiagnosticLog.Size = new System.Drawing.Size(700, 311);
            D0_groupBox_DiagnosticLog.TabIndex = 1;
            D0_groupBox_DiagnosticLog.TabStop = false;
            D0_groupBox_DiagnosticLog.Text = "Log";
            // 
            // D0_treeView_DiagnosticEventLog
            // 
            D0_treeView_DiagnosticEventLog.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            D0_treeView_DiagnosticEventLog.FullRowSelect = true;
            D0_treeView_DiagnosticEventLog.HideSelection = false;
            D0_treeView_DiagnosticEventLog.Location = new System.Drawing.Point(9, 24);
            D0_treeView_DiagnosticEventLog.Margin = new System.Windows.Forms.Padding(4);
            D0_treeView_DiagnosticEventLog.Name = "D0_treeView_DiagnosticEventLog";
            D0_treeView_DiagnosticEventLog.ShowNodeToolTips = true;
            D0_treeView_DiagnosticEventLog.Size = new System.Drawing.Size(684, 235);
            D0_treeView_DiagnosticEventLog.TabIndex = 1;
            D0_treeView_DiagnosticEventLog.NodeMouseClick += D0_treeView_DiagnosticEventLog_NodeMouseClick;
            // 
            // D0_button_ExportLog
            // 
            D0_button_ExportLog.Location = new System.Drawing.Point(540, 269);
            D0_button_ExportLog.Name = "D0_button_ExportLog";
            D0_button_ExportLog.Size = new System.Drawing.Size(153, 34);
            D0_button_ExportLog.TabIndex = 3;
            D0_button_ExportLog.Text = "Export log";
            D0_button_ExportLog.UseVisualStyleBackColor = true;
            D0_button_ExportLog.Click += D0_button_ExportLog_Click;
            // 
            // D0_button_OpenLog
            // 
            D0_button_OpenLog.Location = new System.Drawing.Point(9, 269);
            D0_button_OpenLog.Name = "D0_button_OpenLog";
            D0_button_OpenLog.Size = new System.Drawing.Size(153, 34);
            D0_button_OpenLog.TabIndex = 2;
            D0_button_OpenLog.Text = "Open log";
            D0_button_OpenLog.UseVisualStyleBackColor = true;
            D0_button_OpenLog.Click += D0_button_OpenLog_Click;
            // 
            // D0_groupBox_Status
            // 
            D0_groupBox_Status.Controls.Add(D0_treeView_DefaultElementsVersions);
            D0_groupBox_Status.Controls.Add(D0_richTextBox_AccessDetails);
            D0_groupBox_Status.Controls.Add(D0_label_AccessDetailsLabel);
            D0_groupBox_Status.Controls.Add(D0_label_StatusVersions);
            D0_groupBox_Status.Location = new System.Drawing.Point(19, 20);
            D0_groupBox_Status.Margin = new System.Windows.Forms.Padding(4);
            D0_groupBox_Status.Name = "D0_groupBox_Status";
            D0_groupBox_Status.Padding = new System.Windows.Forms.Padding(4);
            D0_groupBox_Status.Size = new System.Drawing.Size(247, 321);
            D0_groupBox_Status.TabIndex = 2;
            D0_groupBox_Status.TabStop = false;
            D0_groupBox_Status.Text = "Status";
            // 
            // D0_treeView_DefaultElementsVersions
            // 
            D0_treeView_DefaultElementsVersions.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            D0_treeView_DefaultElementsVersions.FullRowSelect = true;
            D0_treeView_DefaultElementsVersions.HideSelection = false;
            D0_treeView_DefaultElementsVersions.Location = new System.Drawing.Point(10, 151);
            D0_treeView_DefaultElementsVersions.Margin = new System.Windows.Forms.Padding(4);
            D0_treeView_DefaultElementsVersions.Name = "D0_treeView_DefaultElementsVersions";
            D0_treeView_DefaultElementsVersions.ShowNodeToolTips = true;
            D0_treeView_DefaultElementsVersions.Size = new System.Drawing.Size(230, 162);
            D0_treeView_DefaultElementsVersions.TabIndex = 1;
            // 
            // D0_richTextBox_AccessDetails
            // 
            D0_richTextBox_AccessDetails.Location = new System.Drawing.Point(7, 44);
            D0_richTextBox_AccessDetails.Name = "D0_richTextBox_AccessDetails";
            D0_richTextBox_AccessDetails.ReadOnly = true;
            D0_richTextBox_AccessDetails.Size = new System.Drawing.Size(233, 63);
            D0_richTextBox_AccessDetails.TabIndex = 7;
            D0_richTextBox_AccessDetails.Text = "";
            // 
            // D0_label_AccessDetailsLabel
            // 
            D0_label_AccessDetailsLabel.AutoSize = true;
            D0_label_AccessDetailsLabel.Location = new System.Drawing.Point(10, 23);
            D0_label_AccessDetailsLabel.Name = "D0_label_AccessDetailsLabel";
            D0_label_AccessDetailsLabel.Size = new System.Drawing.Size(64, 18);
            D0_label_AccessDetailsLabel.TabIndex = 6;
            D0_label_AccessDetailsLabel.Text = "Access:";
            // 
            // D0_label_StatusVersions
            // 
            D0_label_StatusVersions.AutoSize = true;
            D0_label_StatusVersions.Location = new System.Drawing.Point(7, 129);
            D0_label_StatusVersions.Name = "D0_label_StatusVersions";
            D0_label_StatusVersions.Size = new System.Drawing.Size(80, 18);
            D0_label_StatusVersions.TabIndex = 4;
            D0_label_StatusVersions.Text = "Versions:";
            // 
            // D0_groupBox_Actions
            // 
            D0_groupBox_Actions.Controls.Add(D0_groupBox_Diagnostics);
            D0_groupBox_Actions.Controls.Add(D0_groupBox_PerformanceOptions);
            D0_groupBox_Actions.Controls.Add(D0_groupBox_Customization);
            D0_groupBox_Actions.Controls.Add(D0_groupBox_Security);
            D0_groupBox_Actions.Location = new System.Drawing.Point(274, 20);
            D0_groupBox_Actions.Margin = new System.Windows.Forms.Padding(4);
            D0_groupBox_Actions.Name = "D0_groupBox_Actions";
            D0_groupBox_Actions.Padding = new System.Windows.Forms.Padding(4);
            D0_groupBox_Actions.Size = new System.Drawing.Size(446, 321);
            D0_groupBox_Actions.TabIndex = 3;
            D0_groupBox_Actions.TabStop = false;
            D0_groupBox_Actions.Text = "Actions";
            // 
            // D0_groupBox_Diagnostics
            // 
            D0_groupBox_Diagnostics.Controls.Add(D0_button_GenerateDiagnosticStatusReport);
            D0_groupBox_Diagnostics.Location = new System.Drawing.Point(7, 129);
            D0_groupBox_Diagnostics.Name = "D0_groupBox_Diagnostics";
            D0_groupBox_Diagnostics.Size = new System.Drawing.Size(432, 82);
            D0_groupBox_Diagnostics.TabIndex = 5;
            D0_groupBox_Diagnostics.TabStop = false;
            D0_groupBox_Diagnostics.Text = "Diagnostics";
            // 
            // D0_button_GenerateDiagnosticStatusReport
            // 
            D0_button_GenerateDiagnosticStatusReport.Location = new System.Drawing.Point(6, 22);
            D0_button_GenerateDiagnosticStatusReport.Name = "D0_button_GenerateDiagnosticStatusReport";
            D0_button_GenerateDiagnosticStatusReport.Size = new System.Drawing.Size(133, 50);
            D0_button_GenerateDiagnosticStatusReport.TabIndex = 2;
            D0_button_GenerateDiagnosticStatusReport.Text = "Generate Status Report";
            D0_button_GenerateDiagnosticStatusReport.UseVisualStyleBackColor = true;
            D0_button_GenerateDiagnosticStatusReport.Click += D0_button_GenerateDiagnosticStatusReport_Click;
            // 
            // D0_groupBox_PerformanceOptions
            // 
            D0_groupBox_PerformanceOptions.Controls.Add(D0_button_SimPerformanceCheck);
            D0_groupBox_PerformanceOptions.Location = new System.Drawing.Point(7, 217);
            D0_groupBox_PerformanceOptions.Name = "D0_groupBox_PerformanceOptions";
            D0_groupBox_PerformanceOptions.Size = new System.Drawing.Size(219, 82);
            D0_groupBox_PerformanceOptions.TabIndex = 5;
            D0_groupBox_PerformanceOptions.TabStop = false;
            D0_groupBox_PerformanceOptions.Text = "Performance";
            // 
            // D0_button_SimPerformanceCheck
            // 
            D0_button_SimPerformanceCheck.Location = new System.Drawing.Point(21, 22);
            D0_button_SimPerformanceCheck.Name = "D0_button_SimPerformanceCheck";
            D0_button_SimPerformanceCheck.Size = new System.Drawing.Size(180, 50);
            D0_button_SimPerformanceCheck.TabIndex = 2;
            D0_button_SimPerformanceCheck.Text = "Check Simulation Performance";
            D0_button_SimPerformanceCheck.UseVisualStyleBackColor = true;
            D0_button_SimPerformanceCheck.Click += D0_button_SimPerformanceCheck_Click;
            // 
            // D0_groupBox_Customization
            // 
            D0_groupBox_Customization.Controls.Add(D0_button_OpenCustomizationUtility);
            D0_groupBox_Customization.Location = new System.Drawing.Point(232, 217);
            D0_groupBox_Customization.Name = "D0_groupBox_Customization";
            D0_groupBox_Customization.Size = new System.Drawing.Size(207, 82);
            D0_groupBox_Customization.TabIndex = 4;
            D0_groupBox_Customization.TabStop = false;
            D0_groupBox_Customization.Text = "Customization";
            // 
            // D0_button_OpenCustomizationUtility
            // 
            D0_button_OpenCustomizationUtility.Location = new System.Drawing.Point(15, 22);
            D0_button_OpenCustomizationUtility.Name = "D0_button_OpenCustomizationUtility";
            D0_button_OpenCustomizationUtility.Size = new System.Drawing.Size(180, 50);
            D0_button_OpenCustomizationUtility.TabIndex = 2;
            D0_button_OpenCustomizationUtility.Text = "Customization Utility";
            D0_button_OpenCustomizationUtility.UseVisualStyleBackColor = true;
            D0_button_OpenCustomizationUtility.Click += D0_button_OpenCustomizationUtility_Click;
            // 
            // D0_groupBox_Security
            // 
            D0_groupBox_Security.Controls.Add(D0_button_AddApprovedGeneratorId);
            D0_groupBox_Security.Controls.Add(D0_button_Actions_CheckLocalFiles);
            D0_groupBox_Security.Controls.Add(D0_checkBox_AllowThirdPartyComponents);
            D0_groupBox_Security.Location = new System.Drawing.Point(7, 23);
            D0_groupBox_Security.Name = "D0_groupBox_Security";
            D0_groupBox_Security.Size = new System.Drawing.Size(432, 100);
            D0_groupBox_Security.TabIndex = 3;
            D0_groupBox_Security.TabStop = false;
            D0_groupBox_Security.Text = "Security";
            // 
            // D0_button_AddApprovedGeneratorId
            // 
            D0_button_AddApprovedGeneratorId.Location = new System.Drawing.Point(6, 62);
            D0_button_AddApprovedGeneratorId.Name = "D0_button_AddApprovedGeneratorId";
            D0_button_AddApprovedGeneratorId.Size = new System.Drawing.Size(144, 32);
            D0_button_AddApprovedGeneratorId.TabIndex = 3;
            D0_button_AddApprovedGeneratorId.Text = "Add Generator ID";
            D0_button_AddApprovedGeneratorId.UseVisualStyleBackColor = true;
            D0_button_AddApprovedGeneratorId.Click += D0_button_AddApprovedGeneratorId_Click;
            // 
            // D0_button_Actions_CheckLocalFiles
            // 
            D0_button_Actions_CheckLocalFiles.Location = new System.Drawing.Point(6, 22);
            D0_button_Actions_CheckLocalFiles.Name = "D0_button_Actions_CheckLocalFiles";
            D0_button_Actions_CheckLocalFiles.Size = new System.Drawing.Size(144, 34);
            D0_button_Actions_CheckLocalFiles.TabIndex = 0;
            D0_button_Actions_CheckLocalFiles.Text = "Check files";
            D0_button_Actions_CheckLocalFiles.UseVisualStyleBackColor = true;
            D0_button_Actions_CheckLocalFiles.Click += D0_button_Actions_CheckLocalFiles_Click;
            // 
            // D0_checkBox_AllowThirdPartyComponents
            // 
            D0_checkBox_AllowThirdPartyComponents.AutoSize = true;
            D0_checkBox_AllowThirdPartyComponents.Checked = true;
            D0_checkBox_AllowThirdPartyComponents.CheckState = System.Windows.Forms.CheckState.Checked;
            D0_checkBox_AllowThirdPartyComponents.Location = new System.Drawing.Point(156, 23);
            D0_checkBox_AllowThirdPartyComponents.Name = "D0_checkBox_AllowThirdPartyComponents";
            D0_checkBox_AllowThirdPartyComponents.Size = new System.Drawing.Size(251, 22);
            D0_checkBox_AllowThirdPartyComponents.TabIndex = 1;
            D0_checkBox_AllowThirdPartyComponents.Text = "Allow third party components";
            D0_checkBox_AllowThirdPartyComponents.UseVisualStyleBackColor = true;
            D0_checkBox_AllowThirdPartyComponents.CheckedChanged += D0_checkBox_AllowThirdPartyComponents_CheckedChanged;
            // 
            // D0_textBox_ActionDetailsTitle
            // 
            D0_textBox_ActionDetailsTitle.Location = new System.Drawing.Point(11, 29);
            D0_textBox_ActionDetailsTitle.Name = "D0_textBox_ActionDetailsTitle";
            D0_textBox_ActionDetailsTitle.ReadOnly = true;
            D0_textBox_ActionDetailsTitle.Size = new System.Drawing.Size(250, 23);
            D0_textBox_ActionDetailsTitle.TabIndex = 1;
            // 
            // D0_groupBox_Elements
            // 
            D0_groupBox_Elements.Controls.Add(D0_treeView_LoadedElements);
            D0_groupBox_Elements.Location = new System.Drawing.Point(728, 20);
            D0_groupBox_Elements.Margin = new System.Windows.Forms.Padding(4);
            D0_groupBox_Elements.Name = "D0_groupBox_Elements";
            D0_groupBox_Elements.Padding = new System.Windows.Forms.Padding(4);
            D0_groupBox_Elements.Size = new System.Drawing.Size(364, 321);
            D0_groupBox_Elements.TabIndex = 4;
            D0_groupBox_Elements.TabStop = false;
            D0_groupBox_Elements.Text = "Elements";
            // 
            // D0_treeView_LoadedElements
            // 
            D0_treeView_LoadedElements.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            D0_treeView_LoadedElements.FullRowSelect = true;
            D0_treeView_LoadedElements.HideSelection = false;
            D0_treeView_LoadedElements.Location = new System.Drawing.Point(11, 31);
            D0_treeView_LoadedElements.Margin = new System.Windows.Forms.Padding(4);
            D0_treeView_LoadedElements.Name = "D0_treeView_LoadedElements";
            D0_treeView_LoadedElements.ShowNodeToolTips = true;
            D0_treeView_LoadedElements.Size = new System.Drawing.Size(345, 282);
            D0_treeView_LoadedElements.TabIndex = 0;
            D0_treeView_LoadedElements.NodeMouseDoubleClick += D0_treeView_LoadedElements_NodeMouseDoubleClick;
            // 
            // D0_groupBox_ElementDetails
            // 
            D0_groupBox_ElementDetails.Controls.Add(D0_button_ExportActionResults);
            D0_groupBox_ElementDetails.Controls.Add(D0_treeView_ActionDetails);
            D0_groupBox_ElementDetails.Controls.Add(D0_textBox_ActionDetailsTitle);
            D0_groupBox_ElementDetails.Location = new System.Drawing.Point(728, 349);
            D0_groupBox_ElementDetails.Name = "D0_groupBox_ElementDetails";
            D0_groupBox_ElementDetails.Size = new System.Drawing.Size(365, 312);
            D0_groupBox_ElementDetails.TabIndex = 5;
            D0_groupBox_ElementDetails.TabStop = false;
            D0_groupBox_ElementDetails.Text = "Action details";
            // 
            // D0_button_ExportActionResults
            // 
            D0_button_ExportActionResults.Location = new System.Drawing.Point(267, 24);
            D0_button_ExportActionResults.Name = "D0_button_ExportActionResults";
            D0_button_ExportActionResults.Size = new System.Drawing.Size(75, 30);
            D0_button_ExportActionResults.TabIndex = 2;
            D0_button_ExportActionResults.Text = "Export";
            D0_button_ExportActionResults.UseVisualStyleBackColor = true;
            D0_button_ExportActionResults.Click += D0_button_ExportActionResults_Click;
            // 
            // D0_treeView_ActionDetails
            // 
            D0_treeView_ActionDetails.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            D0_treeView_ActionDetails.FullRowSelect = true;
            D0_treeView_ActionDetails.HideSelection = false;
            D0_treeView_ActionDetails.Location = new System.Drawing.Point(11, 63);
            D0_treeView_ActionDetails.Margin = new System.Windows.Forms.Padding(4);
            D0_treeView_ActionDetails.Name = "D0_treeView_ActionDetails";
            D0_treeView_ActionDetails.ShowNodeToolTips = true;
            D0_treeView_ActionDetails.Size = new System.Drawing.Size(345, 242);
            D0_treeView_ActionDetails.TabIndex = 1;
            // 
            // D0_saveFileDialog_ExportLog
            // 
            D0_saveFileDialog_ExportLog.FileName = "Log";
            // 
            // D0_errorProvider_DiagnosticsActionsErrors
            // 
            D0_errorProvider_DiagnosticsActionsErrors.ContainerControl = this;
            // 
            // D0_MainDiagnosticsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDarkDark;
            ClientSize = new System.Drawing.Size(1100, 668);
            Controls.Add(D0_groupBox_ElementDetails);
            Controls.Add(D0_groupBox_Elements);
            Controls.Add(D0_groupBox_Actions);
            Controls.Add(D0_groupBox_Status);
            Controls.Add(D0_groupBox_DiagnosticLog);
            Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "D0_MainDiagnosticsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Diagnostics";
            FormClosing += D0_MainDiagnosticsForm_FormClosing;
            Load += D0_MainDiagnosticsPanel_Load;
            D0_groupBox_DiagnosticLog.ResumeLayout(false);
            D0_groupBox_Status.ResumeLayout(false);
            D0_groupBox_Status.PerformLayout();
            D0_groupBox_Actions.ResumeLayout(false);
            D0_groupBox_Diagnostics.ResumeLayout(false);
            D0_groupBox_PerformanceOptions.ResumeLayout(false);
            D0_groupBox_Customization.ResumeLayout(false);
            D0_groupBox_Security.ResumeLayout(false);
            D0_groupBox_Security.PerformLayout();
            D0_groupBox_Elements.ResumeLayout(false);
            D0_groupBox_ElementDetails.ResumeLayout(false);
            D0_groupBox_ElementDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)D0_errorProvider_DiagnosticsActionsErrors).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox D0_groupBox_DiagnosticLog;
        private System.Windows.Forms.GroupBox D0_groupBox_Status;
        private System.Windows.Forms.GroupBox D0_groupBox_Actions;
        private System.Windows.Forms.GroupBox D0_groupBox_Elements;
        private System.Windows.Forms.TreeView D0_treeView_LoadedElements;
        private System.Windows.Forms.TextBox D0_textBox_ActionDetailsTitle;
        private System.Windows.Forms.GroupBox D0_groupBox_ElementDetails;
        private System.Windows.Forms.Button D0_button_Actions_CheckLocalFiles;
        private System.Windows.Forms.CheckBox D0_checkBox_AllowThirdPartyComponents;
        private System.Windows.Forms.Label D0_label_StatusVersions;
        private System.Windows.Forms.Button D0_button_ExportLog;
        private System.Windows.Forms.Button D0_button_OpenLog;
        private System.Windows.Forms.SaveFileDialog D0_saveFileDialog_ExportLog;
        private System.Windows.Forms.Button D0_button_OpenCustomizationUtility;
        private System.Windows.Forms.GroupBox D0_groupBox_Customization;
        private System.Windows.Forms.GroupBox D0_groupBox_Security;
        private System.Windows.Forms.GroupBox D0_groupBox_PerformanceOptions;
        private System.Windows.Forms.Button D0_button_SimPerformanceCheck;
        private System.Windows.Forms.RichTextBox D0_richTextBox_AccessDetails;
        private System.Windows.Forms.Label D0_label_AccessDetailsLabel;
        private System.Windows.Forms.GroupBox D0_groupBox_Diagnostics;
        private System.Windows.Forms.Button D0_button_GenerateDiagnosticStatusReport;
        private System.Windows.Forms.TreeView D0_treeView_DefaultElementsVersions;
        private System.Windows.Forms.TreeView D0_treeView_ActionDetails;
        private System.Windows.Forms.Button D0_button_ExportActionResults;
        private System.Windows.Forms.SaveFileDialog D0_saveFileDialog_SaveActionReport;
        private System.Windows.Forms.ErrorProvider D0_errorProvider_DiagnosticsActionsErrors;
        private System.Windows.Forms.Button D0_button_AddApprovedGeneratorId;
        private System.Windows.Forms.TreeView D0_treeView_DiagnosticEventLog;
        private System.Windows.Forms.OpenFileDialog D0_openFileDialog_LoadLog;
    }
}
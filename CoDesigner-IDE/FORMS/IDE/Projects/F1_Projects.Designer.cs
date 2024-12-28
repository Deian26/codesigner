namespace CoDesigner_IDE.FORMS.IDE
{
    partial class F1_Projects
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
            F1_label_ExistingProjectsList = new System.Windows.Forms.Label();
            F1_button_ConfigureProject = new System.Windows.Forms.Button();
            F1_comboBox_ExistingProjects = new System.Windows.Forms.ComboBox();
            F1_groupBox_ExistingProjects = new System.Windows.Forms.GroupBox();
            F1_button_BrowseForExistingProject = new System.Windows.Forms.Button();
            F1_folderBrowserDialog_BrowseExistingProject = new System.Windows.Forms.FolderBrowserDialog();
            F1_groupBox_NewProject = new System.Windows.Forms.GroupBox();
            F1_comboBox_NewProjectComponent = new System.Windows.Forms.ComboBox();
            F1_label_NewProjectType = new System.Windows.Forms.Label();
            F1_groupBox_Admin = new System.Windows.Forms.GroupBox();
            F1_button_AdminWorkstationOpenDiagnostiUtility = new System.Windows.Forms.Button();
            F1_button_AuthorizeAdmin = new System.Windows.Forms.Button();
            F1_textBox_Token = new System.Windows.Forms.TextBox();
            F1_label_TokenLabel = new System.Windows.Forms.Label();
            F1_errorProvider_ErrorMessages = new System.Windows.Forms.ErrorProvider(components);
            F1_groupBox_ExistingProjects.SuspendLayout();
            F1_groupBox_NewProject.SuspendLayout();
            F1_groupBox_Admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_ErrorMessages).BeginInit();
            SuspendLayout();
            // 
            // F1_label_ExistingProjectsList
            // 
            F1_label_ExistingProjectsList.AutoSize = true;
            F1_label_ExistingProjectsList.Location = new System.Drawing.Point(15, 56);
            F1_label_ExistingProjectsList.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            F1_label_ExistingProjectsList.Name = "F1_label_ExistingProjectsList";
            F1_label_ExistingProjectsList.Size = new System.Drawing.Size(136, 21);
            F1_label_ExistingProjectsList.TabIndex = 1;
            F1_label_ExistingProjectsList.Text = "Projects list:";
            // 
            // F1_button_ConfigureProject
            // 
            F1_button_ConfigureProject.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            F1_button_ConfigureProject.Location = new System.Drawing.Point(257, 85);
            F1_button_ConfigureProject.Margin = new System.Windows.Forms.Padding(5);
            F1_button_ConfigureProject.Name = "F1_button_ConfigureProject";
            F1_button_ConfigureProject.Size = new System.Drawing.Size(144, 34);
            F1_button_ConfigureProject.TabIndex = 0;
            F1_button_ConfigureProject.Text = "Configure New Project";
            F1_button_ConfigureProject.UseVisualStyleBackColor = true;
            F1_button_ConfigureProject.Click += F1_button_ConfigureProject_Click;
            // 
            // F1_comboBox_ExistingProjects
            // 
            F1_comboBox_ExistingProjects.FormattingEnabled = true;
            F1_comboBox_ExistingProjects.Location = new System.Drawing.Point(176, 53);
            F1_comboBox_ExistingProjects.Name = "F1_comboBox_ExistingProjects";
            F1_comboBox_ExistingProjects.Size = new System.Drawing.Size(301, 29);
            F1_comboBox_ExistingProjects.TabIndex = 2;
            // 
            // F1_groupBox_ExistingProjects
            // 
            F1_groupBox_ExistingProjects.Controls.Add(F1_button_BrowseForExistingProject);
            F1_groupBox_ExistingProjects.Controls.Add(F1_comboBox_ExistingProjects);
            F1_groupBox_ExistingProjects.Controls.Add(F1_label_ExistingProjectsList);
            F1_groupBox_ExistingProjects.Location = new System.Drawing.Point(12, 12);
            F1_groupBox_ExistingProjects.Name = "F1_groupBox_ExistingProjects";
            F1_groupBox_ExistingProjects.Size = new System.Drawing.Size(503, 173);
            F1_groupBox_ExistingProjects.TabIndex = 3;
            F1_groupBox_ExistingProjects.TabStop = false;
            F1_groupBox_ExistingProjects.Text = "Existing Projects";
            // 
            // F1_button_BrowseForExistingProject
            // 
            F1_button_BrowseForExistingProject.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            F1_button_BrowseForExistingProject.Location = new System.Drawing.Point(367, 90);
            F1_button_BrowseForExistingProject.Margin = new System.Windows.Forms.Padding(5);
            F1_button_BrowseForExistingProject.Name = "F1_button_BrowseForExistingProject";
            F1_button_BrowseForExistingProject.Size = new System.Drawing.Size(110, 34);
            F1_button_BrowseForExistingProject.TabIndex = 4;
            F1_button_BrowseForExistingProject.Text = "Browse";
            F1_button_BrowseForExistingProject.UseVisualStyleBackColor = true;
            F1_button_BrowseForExistingProject.Click += F1_button_BrowseForExistingProject_Click;
            // 
            // F1_groupBox_NewProject
            // 
            F1_groupBox_NewProject.Controls.Add(F1_comboBox_NewProjectComponent);
            F1_groupBox_NewProject.Controls.Add(F1_label_NewProjectType);
            F1_groupBox_NewProject.Controls.Add(F1_button_ConfigureProject);
            F1_groupBox_NewProject.Location = new System.Drawing.Point(521, 12);
            F1_groupBox_NewProject.Name = "F1_groupBox_NewProject";
            F1_groupBox_NewProject.Size = new System.Drawing.Size(423, 173);
            F1_groupBox_NewProject.TabIndex = 4;
            F1_groupBox_NewProject.TabStop = false;
            F1_groupBox_NewProject.Text = "New Project";
            // 
            // F1_comboBox_NewProjectComponent
            // 
            F1_comboBox_NewProjectComponent.FormattingEnabled = true;
            F1_comboBox_NewProjectComponent.Location = new System.Drawing.Point(166, 48);
            F1_comboBox_NewProjectComponent.Name = "F1_comboBox_NewProjectComponent";
            F1_comboBox_NewProjectComponent.Size = new System.Drawing.Size(235, 29);
            F1_comboBox_NewProjectComponent.TabIndex = 6;
            // 
            // F1_label_NewProjectType
            // 
            F1_label_NewProjectType.AutoSize = true;
            F1_label_NewProjectType.Location = new System.Drawing.Point(5, 51);
            F1_label_NewProjectType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            F1_label_NewProjectType.Name = "F1_label_NewProjectType";
            F1_label_NewProjectType.Size = new System.Drawing.Size(127, 21);
            F1_label_NewProjectType.TabIndex = 5;
            F1_label_NewProjectType.Text = "Project type:";
            // 
            // F1_groupBox_Admin
            // 
            F1_groupBox_Admin.Controls.Add(F1_button_AdminWorkstationOpenDiagnostiUtility);
            F1_groupBox_Admin.Controls.Add(F1_button_AuthorizeAdmin);
            F1_groupBox_Admin.Controls.Add(F1_textBox_Token);
            F1_groupBox_Admin.Controls.Add(F1_label_TokenLabel);
            F1_groupBox_Admin.Location = new System.Drawing.Point(12, 196);
            F1_groupBox_Admin.Name = "F1_groupBox_Admin";
            F1_groupBox_Admin.Size = new System.Drawing.Size(503, 130);
            F1_groupBox_Admin.TabIndex = 5;
            F1_groupBox_Admin.TabStop = false;
            F1_groupBox_Admin.Text = "Administration";
            // 
            // F1_button_AdminWorkstationOpenDiagnostiUtility
            // 
            F1_button_AdminWorkstationOpenDiagnostiUtility.Enabled = false;
            F1_button_AdminWorkstationOpenDiagnostiUtility.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            F1_button_AdminWorkstationOpenDiagnostiUtility.Location = new System.Drawing.Point(329, 81);
            F1_button_AdminWorkstationOpenDiagnostiUtility.Margin = new System.Windows.Forms.Padding(5);
            F1_button_AdminWorkstationOpenDiagnostiUtility.Name = "F1_button_AdminWorkstationOpenDiagnostiUtility";
            F1_button_AdminWorkstationOpenDiagnostiUtility.Size = new System.Drawing.Size(110, 34);
            F1_button_AdminWorkstationOpenDiagnostiUtility.TabIndex = 7;
            F1_button_AdminWorkstationOpenDiagnostiUtility.Text = "Diagnostics";
            F1_button_AdminWorkstationOpenDiagnostiUtility.UseVisualStyleBackColor = true;
            F1_button_AdminWorkstationOpenDiagnostiUtility.Visible = false;
            F1_button_AdminWorkstationOpenDiagnostiUtility.Click += F1_button_AdminWorkstationOpenDiagnostiUtility_Click;
            // 
            // F1_button_AuthorizeAdmin
            // 
            F1_button_AuthorizeAdmin.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
            F1_button_AuthorizeAdmin.Location = new System.Drawing.Point(367, 81);
            F1_button_AuthorizeAdmin.Margin = new System.Windows.Forms.Padding(5);
            F1_button_AuthorizeAdmin.Name = "F1_button_AuthorizeAdmin";
            F1_button_AuthorizeAdmin.Size = new System.Drawing.Size(110, 34);
            F1_button_AuthorizeAdmin.TabIndex = 5;
            F1_button_AuthorizeAdmin.Text = "Authorize";
            F1_button_AuthorizeAdmin.UseVisualStyleBackColor = true;
            F1_button_AuthorizeAdmin.Click += F1_button_AuthorizeAdmin_Click;
            // 
            // F1_textBox_Token
            // 
            F1_textBox_Token.Location = new System.Drawing.Point(176, 47);
            F1_textBox_Token.Name = "F1_textBox_Token";
            F1_textBox_Token.Size = new System.Drawing.Size(301, 26);
            F1_textBox_Token.TabIndex = 6;
            // 
            // F1_label_TokenLabel
            // 
            F1_label_TokenLabel.AutoSize = true;
            F1_label_TokenLabel.Location = new System.Drawing.Point(15, 52);
            F1_label_TokenLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            F1_label_TokenLabel.Name = "F1_label_TokenLabel";
            F1_label_TokenLabel.Size = new System.Drawing.Size(64, 21);
            F1_label_TokenLabel.TabIndex = 5;
            F1_label_TokenLabel.Text = "Token:";
            // 
            // F1_errorProvider_ErrorMessages
            // 
            F1_errorProvider_ErrorMessages.ContainerControl = this;
            // 
            // F1_Projects
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(956, 336);
            Controls.Add(F1_groupBox_Admin);
            Controls.Add(F1_groupBox_NewProject);
            Controls.Add(F1_groupBox_ExistingProjects);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            Margin = new System.Windows.Forms.Padding(5);
            Name = "F1_Projects";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Projects";
            FormClosed += F1_Projects_FormClosed;
            Load += F1_Projects_Load;
            F1_groupBox_ExistingProjects.ResumeLayout(false);
            F1_groupBox_ExistingProjects.PerformLayout();
            F1_groupBox_NewProject.ResumeLayout(false);
            F1_groupBox_NewProject.PerformLayout();
            F1_groupBox_Admin.ResumeLayout(false);
            F1_groupBox_Admin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)F1_errorProvider_ErrorMessages).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label F1_label_ExistingProjectsList;
        private System.Windows.Forms.Button F1_button_ConfigureProject;
        private System.Windows.Forms.ComboBox F1_comboBox_ExistingProjects;
        private System.Windows.Forms.GroupBox F1_groupBox_ExistingProjects;
        private System.Windows.Forms.FolderBrowserDialog F1_folderBrowserDialog_BrowseExistingProject;
        private System.Windows.Forms.Button F1_button_BrowseForExistingProject;
        private System.Windows.Forms.GroupBox F1_groupBox_NewProject;
        private System.Windows.Forms.ComboBox F1_comboBox_NewProjectComponent;
        private System.Windows.Forms.Label F1_label_NewProjectType;
        private System.Windows.Forms.GroupBox F1_groupBox_Admin;
        private System.Windows.Forms.TextBox F1_textBox_Token;
        private System.Windows.Forms.Label F1_label_TokenLabel;
        private System.Windows.Forms.Button F1_button_AuthorizeAdmin;
        private System.Windows.Forms.ErrorProvider F1_errorProvider_ErrorMessages;
        private System.Windows.Forms.Button F1_button_AdminWorkstationOpenDiagnostiUtility;
    }
}
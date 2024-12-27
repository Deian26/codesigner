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
            this.components = new System.ComponentModel.Container();
            this.F1_label_ExistingProjectsList = new System.Windows.Forms.Label();
            this.F1_button_ConfigureProject = new System.Windows.Forms.Button();
            this.F1_comboBox_ExistingProjects = new System.Windows.Forms.ComboBox();
            this.F1_groupBox_ExistingProjects = new System.Windows.Forms.GroupBox();
            this.F1_button_BrowseForExistingProject = new System.Windows.Forms.Button();
            this.F1_folderBrowserDialog_BrowseExistingProject = new System.Windows.Forms.FolderBrowserDialog();
            this.F1_groupBox_NewProject = new System.Windows.Forms.GroupBox();
            this.F1_comboBox_NewProjectComponent = new System.Windows.Forms.ComboBox();
            this.F1_label_NewProjectType = new System.Windows.Forms.Label();
            this.F1_groupBox_Admin = new System.Windows.Forms.GroupBox();
            this.F1_button_AuthorizeAdmin = new System.Windows.Forms.Button();
            this.F1_textBox_Token = new System.Windows.Forms.TextBox();
            this.F1_label_TokenLabel = new System.Windows.Forms.Label();
            this.F1_errorProvider_ErrorMessages = new System.Windows.Forms.ErrorProvider(this.components);
            this.F1_button_AdminWorkstationOpenDiagnostiUtility = new System.Windows.Forms.Button();
            this.F1_groupBox_ExistingProjects.SuspendLayout();
            this.F1_groupBox_NewProject.SuspendLayout();
            this.F1_groupBox_Admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F1_errorProvider_ErrorMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // F1_label_ExistingProjectsList
            // 
            this.F1_label_ExistingProjectsList.AutoSize = true;
            this.F1_label_ExistingProjectsList.Location = new System.Drawing.Point(15, 56);
            this.F1_label_ExistingProjectsList.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.F1_label_ExistingProjectsList.Name = "F1_label_ExistingProjectsList";
            this.F1_label_ExistingProjectsList.Size = new System.Drawing.Size(136, 21);
            this.F1_label_ExistingProjectsList.TabIndex = 1;
            this.F1_label_ExistingProjectsList.Text = "Projects list:";
            // 
            // F1_button_ConfigureProject
            // 
            this.F1_button_ConfigureProject.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F1_button_ConfigureProject.Location = new System.Drawing.Point(257, 85);
            this.F1_button_ConfigureProject.Margin = new System.Windows.Forms.Padding(5);
            this.F1_button_ConfigureProject.Name = "F1_button_ConfigureProject";
            this.F1_button_ConfigureProject.Size = new System.Drawing.Size(144, 34);
            this.F1_button_ConfigureProject.TabIndex = 0;
            this.F1_button_ConfigureProject.Text = "Configure New Project";
            this.F1_button_ConfigureProject.UseVisualStyleBackColor = true;
            this.F1_button_ConfigureProject.Click += new System.EventHandler(this.F1_button_ConfigureProject_Click);
            // 
            // F1_comboBox_ExistingProjects
            // 
            this.F1_comboBox_ExistingProjects.FormattingEnabled = true;
            this.F1_comboBox_ExistingProjects.Location = new System.Drawing.Point(176, 53);
            this.F1_comboBox_ExistingProjects.Name = "F1_comboBox_ExistingProjects";
            this.F1_comboBox_ExistingProjects.Size = new System.Drawing.Size(301, 29);
            this.F1_comboBox_ExistingProjects.TabIndex = 2;
            // 
            // F1_groupBox_ExistingProjects
            // 
            this.F1_groupBox_ExistingProjects.Controls.Add(this.F1_button_BrowseForExistingProject);
            this.F1_groupBox_ExistingProjects.Controls.Add(this.F1_comboBox_ExistingProjects);
            this.F1_groupBox_ExistingProjects.Controls.Add(this.F1_label_ExistingProjectsList);
            this.F1_groupBox_ExistingProjects.Location = new System.Drawing.Point(12, 12);
            this.F1_groupBox_ExistingProjects.Name = "F1_groupBox_ExistingProjects";
            this.F1_groupBox_ExistingProjects.Size = new System.Drawing.Size(503, 173);
            this.F1_groupBox_ExistingProjects.TabIndex = 3;
            this.F1_groupBox_ExistingProjects.TabStop = false;
            this.F1_groupBox_ExistingProjects.Text = "Existing Projects";
            // 
            // F1_button_BrowseForExistingProject
            // 
            this.F1_button_BrowseForExistingProject.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F1_button_BrowseForExistingProject.Location = new System.Drawing.Point(367, 90);
            this.F1_button_BrowseForExistingProject.Margin = new System.Windows.Forms.Padding(5);
            this.F1_button_BrowseForExistingProject.Name = "F1_button_BrowseForExistingProject";
            this.F1_button_BrowseForExistingProject.Size = new System.Drawing.Size(110, 34);
            this.F1_button_BrowseForExistingProject.TabIndex = 4;
            this.F1_button_BrowseForExistingProject.Text = "Browse";
            this.F1_button_BrowseForExistingProject.UseVisualStyleBackColor = true;
            this.F1_button_BrowseForExistingProject.Click += new System.EventHandler(this.F1_button_BrowseForExistingProject_Click);
            // 
            // F1_groupBox_NewProject
            // 
            this.F1_groupBox_NewProject.Controls.Add(this.F1_comboBox_NewProjectComponent);
            this.F1_groupBox_NewProject.Controls.Add(this.F1_label_NewProjectType);
            this.F1_groupBox_NewProject.Controls.Add(this.F1_button_ConfigureProject);
            this.F1_groupBox_NewProject.Location = new System.Drawing.Point(521, 12);
            this.F1_groupBox_NewProject.Name = "F1_groupBox_NewProject";
            this.F1_groupBox_NewProject.Size = new System.Drawing.Size(423, 173);
            this.F1_groupBox_NewProject.TabIndex = 4;
            this.F1_groupBox_NewProject.TabStop = false;
            this.F1_groupBox_NewProject.Text = "New Project";
            // 
            // F1_comboBox_NewProjectComponent
            // 
            this.F1_comboBox_NewProjectComponent.FormattingEnabled = true;
            this.F1_comboBox_NewProjectComponent.Location = new System.Drawing.Point(166, 48);
            this.F1_comboBox_NewProjectComponent.Name = "F1_comboBox_NewProjectComponent";
            this.F1_comboBox_NewProjectComponent.Size = new System.Drawing.Size(235, 29);
            this.F1_comboBox_NewProjectComponent.TabIndex = 6;
            // 
            // F1_label_NewProjectType
            // 
            this.F1_label_NewProjectType.AutoSize = true;
            this.F1_label_NewProjectType.Location = new System.Drawing.Point(5, 51);
            this.F1_label_NewProjectType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.F1_label_NewProjectType.Name = "F1_label_NewProjectType";
            this.F1_label_NewProjectType.Size = new System.Drawing.Size(127, 21);
            this.F1_label_NewProjectType.TabIndex = 5;
            this.F1_label_NewProjectType.Text = "Project type:";
            // 
            // F1_groupBox_Admin
            // 
            this.F1_groupBox_Admin.Controls.Add(this.F1_button_AdminWorkstationOpenDiagnostiUtility);
            this.F1_groupBox_Admin.Controls.Add(this.F1_button_AuthorizeAdmin);
            this.F1_groupBox_Admin.Controls.Add(this.F1_textBox_Token);
            this.F1_groupBox_Admin.Controls.Add(this.F1_label_TokenLabel);
            this.F1_groupBox_Admin.Location = new System.Drawing.Point(12, 196);
            this.F1_groupBox_Admin.Name = "F1_groupBox_Admin";
            this.F1_groupBox_Admin.Size = new System.Drawing.Size(503, 130);
            this.F1_groupBox_Admin.TabIndex = 5;
            this.F1_groupBox_Admin.TabStop = false;
            this.F1_groupBox_Admin.Text = "Administration";
            // 
            // F1_button_AuthorizeAdmin
            // 
            this.F1_button_AuthorizeAdmin.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F1_button_AuthorizeAdmin.Location = new System.Drawing.Point(367, 81);
            this.F1_button_AuthorizeAdmin.Margin = new System.Windows.Forms.Padding(5);
            this.F1_button_AuthorizeAdmin.Name = "F1_button_AuthorizeAdmin";
            this.F1_button_AuthorizeAdmin.Size = new System.Drawing.Size(110, 34);
            this.F1_button_AuthorizeAdmin.TabIndex = 5;
            this.F1_button_AuthorizeAdmin.Text = "Authorize";
            this.F1_button_AuthorizeAdmin.UseVisualStyleBackColor = true;
            this.F1_button_AuthorizeAdmin.Click += new System.EventHandler(this.F1_button_AuthorizeAdmin_Click);
            // 
            // F1_textBox_Token
            // 
            this.F1_textBox_Token.Location = new System.Drawing.Point(176, 47);
            this.F1_textBox_Token.Name = "F1_textBox_Token";
            this.F1_textBox_Token.Size = new System.Drawing.Size(301, 26);
            this.F1_textBox_Token.TabIndex = 6;
            // 
            // F1_label_TokenLabel
            // 
            this.F1_label_TokenLabel.AutoSize = true;
            this.F1_label_TokenLabel.Location = new System.Drawing.Point(15, 52);
            this.F1_label_TokenLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.F1_label_TokenLabel.Name = "F1_label_TokenLabel";
            this.F1_label_TokenLabel.Size = new System.Drawing.Size(64, 21);
            this.F1_label_TokenLabel.TabIndex = 5;
            this.F1_label_TokenLabel.Text = "Token:";
            // 
            // F1_errorProvider_ErrorMessages
            // 
            this.F1_errorProvider_ErrorMessages.ContainerControl = this;
            // 
            // F1_button_AdminWorkstationOpenDiagnostiUtility
            // 
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Enabled = false;
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Location = new System.Drawing.Point(247, 81);
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Margin = new System.Windows.Forms.Padding(5);
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Name = "F1_button_AdminWorkstationOpenDiagnostiUtility";
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Size = new System.Drawing.Size(110, 34);
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.TabIndex = 7;
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Text = "Diagnostics";
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.UseVisualStyleBackColor = true;
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Visible = false;
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Click += new System.EventHandler(this.F1_button_AdminWorkstationOpenDiagnostiUtility_Click);
            // 
            // F1_Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(956, 336);
            this.Controls.Add(this.F1_groupBox_Admin);
            this.Controls.Add(this.F1_groupBox_NewProject);
            this.Controls.Add(this.F1_groupBox_ExistingProjects);
            this.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "F1_Projects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projects";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.F1_Projects_FormClosed);
            this.Load += new System.EventHandler(this.F1_Projects_Load);
            this.F1_groupBox_ExistingProjects.ResumeLayout(false);
            this.F1_groupBox_ExistingProjects.PerformLayout();
            this.F1_groupBox_NewProject.ResumeLayout(false);
            this.F1_groupBox_NewProject.PerformLayout();
            this.F1_groupBox_Admin.ResumeLayout(false);
            this.F1_groupBox_Admin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F1_errorProvider_ErrorMessages)).EndInit();
            this.ResumeLayout(false);

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
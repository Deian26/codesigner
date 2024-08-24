namespace CoDesigner_IDE.FORMS.IDE
{
    partial class F1_Projects
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
            this.F1_label_ExistingProjectsList = new System.Windows.Forms.Label();
            this.F1_button_ConfigureProject = new System.Windows.Forms.Button();
            this.F1_comboBox_ExistingProjects = new System.Windows.Forms.ComboBox();
            this.F1_groupBox_ExistingProjects = new System.Windows.Forms.GroupBox();
            this.F1_button_BrowseForExistingProject = new System.Windows.Forms.Button();
            this.F1_folderBrowserDialog_BrowseExistingProject = new System.Windows.Forms.FolderBrowserDialog();
            this.F1_groupBox_NewProject = new System.Windows.Forms.GroupBox();
            this.F1_comboBox_NewProjectComponent = new System.Windows.Forms.ComboBox();
            this.F1_label_NewProjectType = new System.Windows.Forms.Label();
            this.F1_groupBox_ExistingProjects.SuspendLayout();
            this.F1_groupBox_NewProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // F1_label_ExistingProjectsList
            // 
            this.F1_label_ExistingProjectsList.AutoSize = true;
            this.F1_label_ExistingProjectsList.Location = new System.Drawing.Point(15, 56);
            this.F1_label_ExistingProjectsList.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.F1_label_ExistingProjectsList.Name = "F1_label_ExistingProjectsList";
            this.F1_label_ExistingProjectsList.Size = new System.Drawing.Size(164, 23);
            this.F1_label_ExistingProjectsList.TabIndex = 1;
            this.F1_label_ExistingProjectsList.Text = "Projects list:";
            // 
            // F1_button_ConfigureProject
            // 
            this.F1_button_ConfigureProject.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F1_button_ConfigureProject.Location = new System.Drawing.Point(271, 111);
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
            this.F1_comboBox_ExistingProjects.Size = new System.Drawing.Size(321, 31);
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
            this.F1_button_BrowseForExistingProject.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F1_button_BrowseForExistingProject.Location = new System.Drawing.Point(176, 111);
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
            this.F1_comboBox_NewProjectComponent.Size = new System.Drawing.Size(249, 31);
            this.F1_comboBox_NewProjectComponent.TabIndex = 6;
            // 
            // F1_label_NewProjectType
            // 
            this.F1_label_NewProjectType.AutoSize = true;
            this.F1_label_NewProjectType.Location = new System.Drawing.Point(5, 51);
            this.F1_label_NewProjectType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.F1_label_NewProjectType.Name = "F1_label_NewProjectType";
            this.F1_label_NewProjectType.Size = new System.Drawing.Size(153, 23);
            this.F1_label_NewProjectType.TabIndex = 5;
            this.F1_label_NewProjectType.Text = "Project type:";
            // 
            // F1_Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(956, 203);
            this.Controls.Add(this.F1_groupBox_NewProject);
            this.Controls.Add(this.F1_groupBox_ExistingProjects);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
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
    }
}
namespace CoDesigner_IDE
{
    partial class F2_ConfigureNewProject
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
            this.F2_flowLayoutPanel_ConfigureNewProject_Controls = new System.Windows.Forms.FlowLayoutPanel();
            this.F2_button_CreateNewProject = new System.Windows.Forms.Button();
            this.F2_label_NewProjectName = new System.Windows.Forms.Label();
            this.F2_label_NewProjectLocation = new System.Windows.Forms.Label();
            this.F2_button_BrowseNewProjectLocation = new System.Windows.Forms.Button();
            this.F2_textBox_NewProjectName = new System.Windows.Forms.TextBox();
            this.F2_label_NewProjectDescription = new System.Windows.Forms.Label();
            this.F2_textBox_NewProjectDescription = new System.Windows.Forms.TextBox();
            this.F2_folderBrowserDialog_NewProjectLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.F2_textBox_SelectedProjectLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // F2_flowLayoutPanel_ConfigureNewProject_Controls
            // 
            this.F2_flowLayoutPanel_ConfigureNewProject_Controls.Location = new System.Drawing.Point(14, 195);
            this.F2_flowLayoutPanel_ConfigureNewProject_Controls.Name = "F2_flowLayoutPanel_ConfigureNewProject_Controls";
            this.F2_flowLayoutPanel_ConfigureNewProject_Controls.Size = new System.Drawing.Size(651, 269);
            this.F2_flowLayoutPanel_ConfigureNewProject_Controls.TabIndex = 0;
            // 
            // F2_button_CreateNewProject
            // 
            this.F2_button_CreateNewProject.Location = new System.Drawing.Point(515, 470);
            this.F2_button_CreateNewProject.Name = "F2_button_CreateNewProject";
            this.F2_button_CreateNewProject.Size = new System.Drawing.Size(150, 34);
            this.F2_button_CreateNewProject.TabIndex = 1;
            this.F2_button_CreateNewProject.Text = "Create";
            this.F2_button_CreateNewProject.UseVisualStyleBackColor = true;
            this.F2_button_CreateNewProject.Click += new System.EventHandler(this.F2_button_CreateNewProject_Click);
            // 
            // F2_label_NewProjectName
            // 
            this.F2_label_NewProjectName.AutoSize = true;
            this.F2_label_NewProjectName.Location = new System.Drawing.Point(12, 29);
            this.F2_label_NewProjectName.Name = "F2_label_NewProjectName";
            this.F2_label_NewProjectName.Size = new System.Drawing.Size(65, 24);
            this.F2_label_NewProjectName.TabIndex = 2;
            this.F2_label_NewProjectName.Text = "FileNameAndExt:";
            // 
            // F2_label_NewProjectLocation
            // 
            this.F2_label_NewProjectLocation.AutoSize = true;
            this.F2_label_NewProjectLocation.Location = new System.Drawing.Point(12, 149);
            this.F2_label_NewProjectLocation.Name = "F2_label_NewProjectLocation";
            this.F2_label_NewProjectLocation.Size = new System.Drawing.Size(109, 24);
            this.F2_label_NewProjectLocation.TabIndex = 3;
            this.F2_label_NewProjectLocation.Text = "Location:";
            // 
            // F2_button_BrowseNewProjectLocation
            // 
            this.F2_button_BrowseNewProjectLocation.Location = new System.Drawing.Point(579, 146);
            this.F2_button_BrowseNewProjectLocation.Name = "F2_button_BrowseNewProjectLocation";
            this.F2_button_BrowseNewProjectLocation.Size = new System.Drawing.Size(86, 29);
            this.F2_button_BrowseNewProjectLocation.TabIndex = 4;
            this.F2_button_BrowseNewProjectLocation.Text = "Browse";
            this.F2_button_BrowseNewProjectLocation.UseVisualStyleBackColor = true;
            this.F2_button_BrowseNewProjectLocation.Click += new System.EventHandler(this.F2_button_BrowseNewProjectLocation_Click);
            // 
            // F2_textBox_NewProjectName
            // 
            this.F2_textBox_NewProjectName.Location = new System.Drawing.Point(148, 29);
            this.F2_textBox_NewProjectName.Name = "F2_textBox_NewProjectName";
            this.F2_textBox_NewProjectName.Size = new System.Drawing.Size(425, 28);
            this.F2_textBox_NewProjectName.TabIndex = 5;
            // 
            // F2_label_NewProjectDescription
            // 
            this.F2_label_NewProjectDescription.AutoSize = true;
            this.F2_label_NewProjectDescription.Location = new System.Drawing.Point(12, 72);
            this.F2_label_NewProjectDescription.Name = "F2_label_NewProjectDescription";
            this.F2_label_NewProjectDescription.Size = new System.Drawing.Size(142, 24);
            this.F2_label_NewProjectDescription.TabIndex = 6;
            this.F2_label_NewProjectDescription.Text = "Description:";
            // 
            // F2_textBox_NewProjectDescription
            // 
            this.F2_textBox_NewProjectDescription.AcceptsReturn = true;
            this.F2_textBox_NewProjectDescription.Location = new System.Drawing.Point(148, 69);
            this.F2_textBox_NewProjectDescription.Multiline = true;
            this.F2_textBox_NewProjectDescription.Name = "F2_textBox_NewProjectDescription";
            this.F2_textBox_NewProjectDescription.Size = new System.Drawing.Size(425, 61);
            this.F2_textBox_NewProjectDescription.TabIndex = 7;
            // 
            // F2_folderBrowserDialog_NewProjectLocation
            // 
            this.F2_folderBrowserDialog_NewProjectLocation.Description = "Select project folder";
            // 
            // F2_textBox_SelectedProjectLocation
            // 
            this.F2_textBox_SelectedProjectLocation.Location = new System.Drawing.Point(148, 146);
            this.F2_textBox_SelectedProjectLocation.Name = "F2_textBox_SelectedProjectLocation";
            this.F2_textBox_SelectedProjectLocation.Size = new System.Drawing.Size(425, 28);
            this.F2_textBox_SelectedProjectLocation.TabIndex = 8;
            // 
            // F2_ConfigureNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(677, 517);
            this.Controls.Add(this.F2_textBox_SelectedProjectLocation);
            this.Controls.Add(this.F2_textBox_NewProjectDescription);
            this.Controls.Add(this.F2_label_NewProjectDescription);
            this.Controls.Add(this.F2_textBox_NewProjectName);
            this.Controls.Add(this.F2_button_BrowseNewProjectLocation);
            this.Controls.Add(this.F2_label_NewProjectLocation);
            this.Controls.Add(this.F2_label_NewProjectName);
            this.Controls.Add(this.F2_button_CreateNewProject);
            this.Controls.Add(this.F2_flowLayoutPanel_ConfigureNewProject_Controls);
            this.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F2_ConfigureNewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure New Project";
            this.Load += new System.EventHandler(this.F2_ConfigureNewProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel F2_flowLayoutPanel_ConfigureNewProject_Controls;
        private System.Windows.Forms.Button F2_button_CreateNewProject;
        private System.Windows.Forms.Label F2_label_NewProjectName;
        private System.Windows.Forms.Label F2_label_NewProjectLocation;
        private System.Windows.Forms.Button F2_button_BrowseNewProjectLocation;
        private System.Windows.Forms.TextBox F2_textBox_NewProjectName;
        private System.Windows.Forms.Label F2_label_NewProjectDescription;
        private System.Windows.Forms.TextBox F2_textBox_NewProjectDescription;
        private System.Windows.Forms.FolderBrowserDialog F2_folderBrowserDialog_NewProjectLocation;
        private System.Windows.Forms.TextBox F2_textBox_SelectedProjectLocation;
    }
}
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
            F2_flowLayoutPanel_ConfigureNewProject_Controls = new System.Windows.Forms.FlowLayoutPanel();
            F2_button_CreateNewProject = new System.Windows.Forms.Button();
            F2_label_NewProjectName = new System.Windows.Forms.Label();
            F2_label_NewProjectLocation = new System.Windows.Forms.Label();
            F2_button_BrowseNewProjectLocation = new System.Windows.Forms.Button();
            F2_textBox_NewProjectName = new System.Windows.Forms.TextBox();
            F2_label_NewProjectDescription = new System.Windows.Forms.Label();
            F2_textBox_NewProjectDescription = new System.Windows.Forms.TextBox();
            F2_folderBrowserDialog_NewProjectLocation = new System.Windows.Forms.FolderBrowserDialog();
            F2_textBox_SelectedProjectLocation = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // F2_flowLayoutPanel_ConfigureNewProject_Controls
            // 
            F2_flowLayoutPanel_ConfigureNewProject_Controls.Location = new System.Drawing.Point(14, 195);
            F2_flowLayoutPanel_ConfigureNewProject_Controls.Name = "F2_flowLayoutPanel_ConfigureNewProject_Controls";
            F2_flowLayoutPanel_ConfigureNewProject_Controls.Size = new System.Drawing.Size(760, 269);
            F2_flowLayoutPanel_ConfigureNewProject_Controls.TabIndex = 0;
            // 
            // F2_button_CreateNewProject
            // 
            F2_button_CreateNewProject.Location = new System.Drawing.Point(624, 471);
            F2_button_CreateNewProject.Name = "F2_button_CreateNewProject";
            F2_button_CreateNewProject.Size = new System.Drawing.Size(150, 34);
            F2_button_CreateNewProject.TabIndex = 1;
            F2_button_CreateNewProject.Text = "Create";
            F2_button_CreateNewProject.UseVisualStyleBackColor = true;
            F2_button_CreateNewProject.Click += F2_button_CreateNewProject_Click;
            // 
            // F2_label_NewProjectName
            // 
            F2_label_NewProjectName.AutoSize = true;
            F2_label_NewProjectName.Location = new System.Drawing.Point(12, 29);
            F2_label_NewProjectName.Name = "F2_label_NewProjectName";
            F2_label_NewProjectName.Size = new System.Drawing.Size(144, 20);
            F2_label_NewProjectName.TabIndex = 2;
            F2_label_NewProjectName.Text = "FileNameAndExt:";
            // 
            // F2_label_NewProjectLocation
            // 
            F2_label_NewProjectLocation.AutoSize = true;
            F2_label_NewProjectLocation.Location = new System.Drawing.Point(66, 146);
            F2_label_NewProjectLocation.Name = "F2_label_NewProjectLocation";
            F2_label_NewProjectLocation.Size = new System.Drawing.Size(90, 20);
            F2_label_NewProjectLocation.TabIndex = 3;
            F2_label_NewProjectLocation.Text = "Location:";
            // 
            // F2_button_BrowseNewProjectLocation
            // 
            F2_button_BrowseNewProjectLocation.Location = new System.Drawing.Point(688, 146);
            F2_button_BrowseNewProjectLocation.Name = "F2_button_BrowseNewProjectLocation";
            F2_button_BrowseNewProjectLocation.Size = new System.Drawing.Size(86, 29);
            F2_button_BrowseNewProjectLocation.TabIndex = 4;
            F2_button_BrowseNewProjectLocation.Text = "Browse";
            F2_button_BrowseNewProjectLocation.UseVisualStyleBackColor = true;
            F2_button_BrowseNewProjectLocation.Click += F2_button_BrowseNewProjectLocation_Click;
            // 
            // F2_textBox_NewProjectName
            // 
            F2_textBox_NewProjectName.Location = new System.Drawing.Point(191, 25);
            F2_textBox_NewProjectName.Name = "F2_textBox_NewProjectName";
            F2_textBox_NewProjectName.Size = new System.Drawing.Size(491, 24);
            F2_textBox_NewProjectName.TabIndex = 5;
            // 
            // F2_label_NewProjectDescription
            // 
            F2_label_NewProjectDescription.AutoSize = true;
            F2_label_NewProjectDescription.Location = new System.Drawing.Point(39, 72);
            F2_label_NewProjectDescription.Name = "F2_label_NewProjectDescription";
            F2_label_NewProjectDescription.Size = new System.Drawing.Size(117, 20);
            F2_label_NewProjectDescription.TabIndex = 6;
            F2_label_NewProjectDescription.Text = "Description:";
            // 
            // F2_textBox_NewProjectDescription
            // 
            F2_textBox_NewProjectDescription.AcceptsReturn = true;
            F2_textBox_NewProjectDescription.Location = new System.Drawing.Point(191, 69);
            F2_textBox_NewProjectDescription.Multiline = true;
            F2_textBox_NewProjectDescription.Name = "F2_textBox_NewProjectDescription";
            F2_textBox_NewProjectDescription.Size = new System.Drawing.Size(491, 61);
            F2_textBox_NewProjectDescription.TabIndex = 7;
            // 
            // F2_folderBrowserDialog_NewProjectLocation
            // 
            F2_folderBrowserDialog_NewProjectLocation.Description = "Select project folder";
            // 
            // F2_textBox_SelectedProjectLocation
            // 
            F2_textBox_SelectedProjectLocation.Location = new System.Drawing.Point(191, 146);
            F2_textBox_SelectedProjectLocation.Name = "F2_textBox_SelectedProjectLocation";
            F2_textBox_SelectedProjectLocation.Size = new System.Drawing.Size(491, 24);
            F2_textBox_SelectedProjectLocation.TabIndex = 8;
            // 
            // F2_ConfigureNewProject
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(786, 517);
            Controls.Add(F2_textBox_SelectedProjectLocation);
            Controls.Add(F2_textBox_NewProjectDescription);
            Controls.Add(F2_label_NewProjectDescription);
            Controls.Add(F2_textBox_NewProjectName);
            Controls.Add(F2_button_BrowseNewProjectLocation);
            Controls.Add(F2_label_NewProjectLocation);
            Controls.Add(F2_label_NewProjectName);
            Controls.Add(F2_button_CreateNewProject);
            Controls.Add(F2_flowLayoutPanel_ConfigureNewProject_Controls);
            Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "F2_ConfigureNewProject";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Configure New Project";
            Load += F2_ConfigureNewProject_Load;
            ResumeLayout(false);
            PerformLayout();
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
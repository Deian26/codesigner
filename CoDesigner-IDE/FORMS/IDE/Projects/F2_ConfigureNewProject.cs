﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    public partial class F2_ConfigureNewProject : Form
    {
        private Component component = null;

        /// <summary>
        /// Display controls for configuring a new project, based on the project type selected in form F1.
        /// </summary>
        /// <param name="projectType"> determines some workspace attributes </param>
        public F2_ConfigureNewProject(Component component)
        {
            Label projectControlLabel;
            ComboBox projectControlComboBox;

            InitializeComponent();

            this.component = component;

            //display project controls for this component
            foreach (ProjectComboBoxDetails projectControl in component.GetAdditionOptionControls())
            {
                // label
                projectControlLabel = new Label();
                projectControlComboBox = new ComboBox();

                projectControlLabel.Text = projectControl.labelText;
                projectControlLabel.Width = 250;

                // combo-box
                projectControlComboBox.Items.AddRange(projectControl.comboValues.ToArray());

                projectControlComboBox.Width = 300;
                projectControlComboBox.Text = "";

                if(projectControlComboBox.Items.Count>=1) projectControlComboBox.SelectedIndex = 0; //select the first element
                
                this.F2_flowLayoutPanel_ConfigureNewProject_Controls.Controls.Add(projectControlLabel); //add label
                this.F2_flowLayoutPanel_ConfigureNewProject_Controls.Controls.Add(projectControlComboBox); //add combobox
            }
        }

        #region utility
        /// <summary>
        /// Determines if the given name is valid
        /// </summary>
        /// <param name="name"></param>
        /// <returns>'true' is the provided name is valid, 'false' otherwise </returns>
        private bool isValidName(string name)
        {
            if (name.Length == 0) return false;

            for(int i=0;i<name.Length;i++)
            {
                if (((name[i] < 'a' && name[i] > 'Z') || (name[i] > 'z') || (name[i] < 'A') || (i==0 && name[i] >='0' && name[i] <='9')) && name[i]!= '_') return false;
            }

            return true;
        }
        #endregion

        /// <summary>
        /// Load the controls specific to the selected project type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F2_ConfigureNewProject_Load(object sender, EventArgs e)
        {
#if DEBUG
            this.F2_textBox_SelectedProjectLocation.Text = "A:\\Development_Software\\Playground\\MCL_Project\\MCL_Project";
#endif
            //set minimum and maximum form sizes
            this.MinimumSize = this.MaximumSize = this.Size;

            //load default values
            this.F2_textBox_NewProjectName.Text = this.component.Name + "_Project";
        }

        private void F2_button_BrowseNewProjectLocation_Click(object sender, EventArgs e)
        {
            //browse for a project location
            this.F2_folderBrowserDialog_NewProjectLocation.ShowDialog();
            
            //display location
            this.F2_textBox_SelectedProjectLocation.Text = Path.Combine(this.F2_folderBrowserDialog_NewProjectLocation.SelectedPath, this.F2_textBox_NewProjectName.Text);

        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F2_button_CreateNewProject_Click(object sender, EventArgs e)
        {
            //check project name
            if (isValidName(this.F2_textBox_NewProjectName.Text.ToString().Trim()) == false)
            {
                Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_PROJECT_NAME);
                return;
            }

            //create project folder, if it does not already exist
            try
            {
                // create the project's directory, if needed
                Directory.CreateDirectory(this.F2_textBox_SelectedProjectLocation.Text);

                // if the directory already exists and it is not empty, prompt the user for confirmation (the folder will be merged with the incoming files and directories)
                if (Directory.Exists(this.F2_textBox_SelectedProjectLocation.Text) && 
                    (Directory.GetFiles(this.F2_textBox_SelectedProjectLocation.Text).Length!=0 || Directory.GetDirectories(this.F2_textBox_SelectedProjectLocation.Text).Length!=0))
                    {
                    DialogResult locationConfirmation = Prompts.OpenDialog(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, 1);

                    if(locationConfirmation.Equals(DialogResult.Yes) == false) // do not create project
                        {
                        return;
                        }
                    }
                
            }catch (Exception ex)
            {
                Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_PROJECT_FOLDER_LOC, ex.Message); //error creating a folder for the new project
                return;
            }

            //create project
            Project project = null;
            try
            {
                project = new Project(
                    this.F2_textBox_NewProjectName.Text.ToString().Trim(),
                    this.F2_textBox_NewProjectDescription.Text.ToString().Trim(),
                    this.F2_textBox_SelectedProjectLocation.Text,
                    this.component
                    );

                //create a new project object and add it to the loaded projects list
                ProjectManagement.Projects.Add(project.Name,project);

                //open the main editor form
                Program.Crt_F3 = new F3_MainEditor(project);
                this.Close(); // close the new project form

                Program.Crt_F3.Show();
            } catch (Exception ex) // project creation error
            {
                Diagnostics.LogEvent(Diagnostics.DefaultEventCodes.ERROR_CREATING_NEW_PROJECT,ex.Message);
            }

        }
    }
}

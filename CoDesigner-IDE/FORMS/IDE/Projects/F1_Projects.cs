using CoDesigner_IDE.FORMS.IDE.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE.FORMS.IDE
{
    public partial class F1_Projects : Form
    {
        public F1_Projects()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open new project configuration form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F1_button_ConfigureProject_Click(object sender, EventArgs e)
        {
            F2_ConfigureNewProject f2_ConfigureNewProject;

            f2_ConfigureNewProject = new F2_ConfigureNewProject(Components.LoadedComponents[this.F1_comboBox_NewProjectComponent.SelectedItem.ToString()]);
            f2_ConfigureNewProject.Show();
        }

        private void F1_Projects_Load(object sender, EventArgs e)
        {
            //load active projects
            foreach(string activeProjectName in ProjectManagement.Projects.Keys)
            {
                this.F1_comboBox_ExistingProjects.Items.Add(activeProjectName);
            }

            //load component names
            foreach(string componentName in Components.LoadedComponents.Keys)
            {
                this.F1_comboBox_NewProjectComponent.Items.Add(componentName);
            }

            //select the first element
            if(this.F1_comboBox_NewProjectComponent.Items.Count>=1) 
                this.F1_comboBox_NewProjectComponent.SelectedIndex = 0;

        }

        private void F1_Projects_FormClosed(object sender, FormClosedEventArgs e)
        {
            //stop program
            Program.StopAll();
        }

        private void F1_button_BrowseForExistingProject_Click(object sender, EventArgs e)
        {
            //browse for project file
            this.F1_folderBrowserDialog_BrowseExistingProject.ShowDialog();

            //dev - add project browsing
        }
    }
}

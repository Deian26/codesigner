using CoDesigner_IDE.FORMS.IDE.Projects;
using System;
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
using static CoDesigner_IDE.Security;

namespace CoDesigner_IDE.FORMS.IDE
{
    public partial class F1_Projects : Form
    {
        delegate bool Delegate_DisplayForm(Security.Token token);
        
        public F1_Projects()
        {
            InitializeComponent();

            // if this is a admin-workstation, skip token verification for the diagnostic utility
            if(Utility.CurrentSecurityProperties.ADMIN_WORKSTATION==true)
            {
                // hide token controls
                this.F1_label_TokenLabel.Enabled = false;
                this.F1_label_TokenLabel.Visible = false;

                this.F1_textBox_Token.Enabled = false;
                this.F1_textBox_Token.Visible = false;

                // display diagnostic utility button

            }
        }

        /// <summary>
        /// Open new project configuration form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F1_button_ConfigureProject_Click(object sender, EventArgs e)
        {
            F2_ConfigureNewProject f2_ConfigureNewProject;

            if (this.F1_comboBox_NewProjectComponent.SelectedItem != null &&
                ComponentFactory.LoadedComponents.ContainsKey(this.F1_comboBox_NewProjectComponent.SelectedItem.ToString()))
            {
                f2_ConfigureNewProject = new F2_ConfigureNewProject(ComponentFactory.LoadedComponents[this.F1_comboBox_NewProjectComponent.SelectedItem.ToString()]);
                f2_ConfigureNewProject.Show();
            }
        }

        private void F1_Projects_Load(object sender, EventArgs e)
        {
            //set minimum and maximum form sizes
            this.MinimumSize = this.MaximumSize = this.Size;

            //load active projects
            foreach(string activeProjectName in ProjectManagement.Projects.Keys)
            {
                this.F1_comboBox_ExistingProjects.Items.Add(activeProjectName);
            }

            //load component names
            foreach(string componentName in ComponentFactory.LoadedComponents.Keys)
            {
                this.F1_comboBox_NewProjectComponent.Items.Add(componentName);
            }

            //select the first element
            if(this.F1_comboBox_NewProjectComponent.Items.Count>=1) 
                this.F1_comboBox_NewProjectComponent.SelectedIndex = 0;

        }

        private void F1_Projects_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Stop program
            Program.StopAll();
        }

        private void F1_button_BrowseForExistingProject_Click(object sender, EventArgs e)
        {
            // Browse for project file
            this.F1_folderBrowserDialog_BrowseExistingProject.ShowDialog();

            //TODO: Implement project browsing  
        }
        
        private void F1_button_AuthorizeAdmin_Click(object sender, EventArgs e)
        {
            // reset error
            this.F1_errorProvider_ErrorMessages.Clear();

            // process token
            if (this.F1_textBox_Token.Text.Length > 0) //=> basic length check (a more detailed length check is done when the token is generated)
            {
                // Check if the token is valid and authorize access
                Security.TokenVerificationStatus tokenVerificationStatus = Security.VerifyToken(this.F1_textBox_Token.Text.Trim());

                if (tokenVerificationStatus.token != null &&
                    tokenVerificationStatus.token.VALID == true) //=> double check
                {
                    // if the diagnostics utility has been shut down, re-start it and display an error
                    if(Program.D0.IsDisposed == true)
                    {
                        MessageBox.Show("DIAGNOSTICS FATAL ERROR","The Diagnostics Utility has been previously shut down!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.StopAll();
                    }
                    // open the Diagnostics utility
                    bool accessGranted = (bool)this.Invoke(new Delegate_DisplayForm(Program.D0.DisplayForm), tokenVerificationStatus.token);

                    if (accessGranted == false) // form was not displayed due to the access level not being accepted
                    {
                        string eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INSUFFICIENT_TOKEN_ACCESS_LEVEL);
                        this.F1_errorProvider_ErrorMessages.SetError(this.F1_textBox_Token, eventMessage);
                    }
                }
                else //=> invalid token
                {
                    this.F1_errorProvider_ErrorMessages.SetError(this.F1_textBox_Token, tokenVerificationStatus.eventMessage);
                }
            }
            else //=> no token provided
            {
                this.F1_errorProvider_ErrorMessages.SetError(this.F1_textBox_Token, Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_TOKEN_LENGTH));
            }

        }

        private void F1_button_AdminWorkstationOpenDiagnostiUtility_Click(object sender, EventArgs e)
        {
            // open the diagnostic utility without a token (admin-workstation)
            bool accessGranted = (bool)this.Invoke(new Delegate_DisplayForm(Program.D0.DisplayForm), null);

            if (accessGranted == false) // form was not displayed due to the access level not being accepted
            {
                string eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INSUFFICIENT_TOKEN_ACCESS_LEVEL);
                this.F1_errorProvider_ErrorMessages.SetError(this.F1_button_AdminWorkstationOpenDiagnostiUtility, eventMessage);
            }
        }
    }
}

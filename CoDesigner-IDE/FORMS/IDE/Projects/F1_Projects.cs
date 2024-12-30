using CoDesigner_IDE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Displays project management options
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class F1_Projects : Form
    {
        delegate bool Delegate_DisplayForm(Security.Token token);

        /// <summary>
        /// Handles project creation and management
        /// </summary>
        [SupportedOSPlatform("windows")]
        public F1_Projects()
        {
            InitializeComponent();

            // if this is a admin-workstation, skip token verification for the diagnostic utility
            if(Security.CurrentSecurityProperties.ADMIN_WORKSTATION==true)
            {
                // change how the controls are displayed
                this.setAdminWorkstation();
            }
        }

        #region utility
        private void setAdminWorkstation()
        {
            // hide token controls
            this.F1_label_TokenLabel.Enabled = false;
            this.F1_label_TokenLabel.Visible = false;

            this.F1_textBox_Token.Enabled = false;
            this.F1_textBox_Token.Visible = false;

            this.F1_button_AuthorizeAdmin.Enabled = false;
            this.F1_button_AuthorizeAdmin.Visible = false;

            // display diagnostic utility button
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Location = this.F1_button_AuthorizeAdmin.Location;
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Enabled = true;
            this.F1_button_AdminWorkstationOpenDiagnostiUtility.Visible = true;

            // display a message stating that this is an admin workstation
            this.F1_groupBox_Admin.Text += " - ADMIN";
        }
        #endregion

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

        [SupportedOSPlatform("windows")]
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

        [SupportedOSPlatform("windows")]
        private void F1_button_BrowseForExistingProject_Click(object sender, EventArgs e)
        {
            // Browse for project file
            this.F1_folderBrowserDialog_BrowseExistingProject.ShowDialog();

            //TODO: Implement project browsing  
        }

        [SupportedOSPlatform("windows")]
        private void F1_button_AuthorizeAdmin_Click(object sender, EventArgs e)
        {
            // reset error
            this.F1_errorProvider_ErrorMessages.Clear();
            this.F1_textBox_Token.BackColor = Utility.BACKCOLOUR_DEFAULT_CONTROL;
            // process token

            // Check if the token is valid and authorize access
            Security.TokenVerificationStatus tokenVerificationStatus = Security.VerifyToken(this.F1_textBox_Token.Text.Trim());
                
            if (tokenVerificationStatus.token != null)
            {
                if (tokenVerificationStatus.token.VALID == true) //=> double check validity
                {
                    // if the diagnostics utility has been shut down, re-start it and display an error
                    if (Program.D0.IsDisposed == true)
                    {
                        MessageBox.Show("DIAGNOSTICS FATAL ERROR", "The Diagnostics Utility has been previously shut down!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.StopAll();
                    }

                    // open the Diagnostics utility
                    bool accessGranted = (bool)Program.D0.Invoke(new Delegate_DisplayForm(Program.D0.DisplayForm), tokenVerificationStatus.token);
                    
                    // if this machine is an admin workstation, change how the controls are displayed
                    if (tokenVerificationStatus.token.ACCESS_LEVEL == Security.AccessLevel.ADMIN_WORKSTATION)
                    { 
                        this.setAdminWorkstation();
                    }

                    if (accessGranted == false) // form was not displayed due to the access level not being accepted
                    {
                        string eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INSUFFICIENT_TOKEN_ACCESS_LEVEL);
                        this.F1_errorProvider_ErrorMessages.SetError(this.F1_textBox_Token, eventMessage);
                        this.F1_textBox_Token.BackColor = Utility.BACKCOLOUR_ERROR;
                    }
                }
            }
            else //=> invalid token
            {
                if (tokenVerificationStatus.eventMessage != null) // reason for token invalidity provided
                { 
                    this.F1_errorProvider_ErrorMessages.SetError(this.F1_textBox_Token, tokenVerificationStatus.eventMessage);
                    this.F1_textBox_Token.BackColor = Utility.BACKCOLOUR_ERROR;
                }
                else //=> no reason provided for the token's invalidity
                {
                    this.F1_errorProvider_ErrorMessages.SetError(this.F1_textBox_Token, Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_TOKEN_STRING_FORMAT));
                    this.F1_textBox_Token.BackColor = Utility.BACKCOLOUR_ERROR;
                }
            }

            
        }

        [SupportedOSPlatform("windows")]
        private void F1_button_AdminWorkstationOpenDiagnostiUtility_Click(object sender, EventArgs e)
        {
            // open the diagnostic utility without a token (admin-workstation)
            bool accessGranted = (bool)Program.D0.Invoke(new Delegate_DisplayForm(Program.D0.DisplayForm), new object[] {null});

            if (accessGranted == false) // form was not displayed due to the access level not being accepted
            {
                string eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INSUFFICIENT_TOKEN_ACCESS_LEVEL);
                this.F1_errorProvider_ErrorMessages.SetError(this.F1_button_AdminWorkstationOpenDiagnostiUtility, eventMessage);
            }
        }
    }
}

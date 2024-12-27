using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoDesigner_IDE.Diagnostics;

namespace CoDesigner_IDE
{
    public partial class D0_MainDiagnosticsForm : Form
    {
        private string D0_TreeViewNodeTitle_COMPONENTS = "ComponentFactory";
        private string D0_TreeViewNodeTitle_DEFAULTS = "Defaults";
        private string D0_TreeViewNodeTitle_DEFAULT_EVENTS = "Events";
        private string D0_TreeViewNodeTitle_DEFAULT_PROMPTS = "Prompts";
        private string D0_TreeViewNodeTitle_DEFAULT_LANGUAGES = "Languages";
        private string D0_TreeViewNodeTitle_DEFAULT_THEMES = "Themes";

        //node tags
        private const string D0_TreeViewNodeTitleTag = "Title";
        private const string D0_TreeViewNodeComponentTag = "Component";
        private const string D0_TreeViewNodeEventTag = "Event";
        private const string D0_TreeViewNodePromptTag = "Prompt";
        private const string D0_TreeViewNodeLanguageTag = "Language";
        private const string D0_TreeViewNodeThemeTag = "Theme";
        
        #region delegates
        public delegate void DelegateType_UpdateDiagnosticLog();
        public DelegateType_UpdateDiagnosticLog Delegate_UpdateLoadedElementsDisplay;
        #endregion

        private enum AccessLevelGroup { ADMIN = 1, ADMIN_WORKSTATION = 3 } // access levels with permision to access this form

        // form properties
        private Size NormalSize { get; } // default form size to be used

        public D0_MainDiagnosticsForm()
        {
            InitializeComponent();

            // set initial form properties
            this.NormalSize = this.Size;

            // instantiate delegates
            this.Delegate_UpdateLoadedElementsDisplay = UpdateLoadedElementsDisplay;
        }

        private void D0_MainDiagnosticsPanel_Load(object sender, EventArgs e)
        {
            this.SetFormDefaultSize();
        }

        //set minimum and maximum form sizes
        public void SetFormDefaultSize()
        {
            this.MaximumSize = this.MinimumSize = this.NormalSize;
        }

        /// <summary>
        /// Displays the form, if the security access level allows it
        /// </summary>
        /// <param name="token">Token to be used or null, if a token is not required (admin-workstation)</param>
        /// <returns>true if the diagnostic form can be displayed, based on the access level of the given token; false otherwise</returns>
        internal bool DisplayForm(Security.Token token)
        {
            if (token == null)
            {
                return Utility.CurrentSecurityProperties.ADMIN_WORKSTATION == true;
            }

            bool accessGranted = false;
            // check security access
            if (token.VALID == true && 
                Enum.IsDefined(typeof(D0_MainDiagnosticsForm.AccessLevelGroup), (int)token.ACCESS_LEVEL) == true)
            {
                // store this property in a local file
                if (token.ACCESS_LEVEL == Security.AccessLevel.ADMIN_WORKSTATION)
                { 
                    Utility.StoreSecurityProperties(
                        true
                        );
                }

                this.SetFormDefaultSize();
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                accessGranted = true;
            }

            return accessGranted;
        }

        #region diagnostic-functions
        /// <summary>
        /// Updates the D0 controls displaying the loaded elements (components, events, prompts etc.)
        /// </summary>
        public void UpdateLoadedElementsDisplay()
        {
            //create base nodes for the loaded elements tree view
            this.D0_treeView_LoadedElements.Nodes.Clear();

            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_COMPONENTS, this.D0_TreeViewNodeTitle_COMPONENTS);
            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS].Tag = D0_TreeViewNodeTitleTag; //mark this node as a title node

            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_DEFAULTS, this.D0_TreeViewNodeTitle_DEFAULTS);
            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Tag = D0_TreeViewNodeTitleTag;

            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes.Add(this.D0_TreeViewNodeTitle_DEFAULT_EVENTS, this.D0_TreeViewNodeTitle_DEFAULT_EVENTS);
            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS].Tag = D0_TreeViewNodeTitleTag;

            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes.Add(this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS, this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS);
            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS].Tag = D0_TreeViewNodeTitleTag;

            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes.Add(this.D0_TreeViewNodeTitle_DEFAULT_LANGUAGES, this.D0_TreeViewNodeTitle_DEFAULT_LANGUAGES);
            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_LANGUAGES].Tag = D0_TreeViewNodeTitleTag;

            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes.Add(this.D0_TreeViewNodeTitle_DEFAULT_THEMES, this.D0_TreeViewNodeTitle_DEFAULT_THEMES);
            this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_THEMES].Tag = D0_TreeViewNodeTitleTag;


            //  components
            //clear sub-tree
            //if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS]!=null && 
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS].GetNodeCount(true) != 0) 
            //        this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS].Nodes.Clear();

            //add components
            foreach (string componentName in ComponentFactory.LoadedComponents.Keys)
            {
                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_COMPONENTS]
                    .Nodes
                    .Add(componentName, componentName);
                this.D0_treeView_LoadedElements
                .Nodes[this.D0_TreeViewNodeTitle_COMPONENTS]
                .Nodes[componentName]
                .Tag = D0_TreeViewNodeComponentTag;
            }


            //  event definitions (including defaults)
            //if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS] != null && 
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS].GetNodeCount(true) != 0) 
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS].Nodes.Clear();

            foreach (Diagnostics.Event _event in Diagnostics.PossibleEvents.Values)
            {
                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULTS]
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS]
                    .Nodes
                    .Add(_event.code.ToString(), "Event code: " + "0x" + _event.code.ToString("X8"));

                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULTS]
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS]
                    .Nodes[_event.code.ToString()].ToolTipText = _event.message.ToString();

                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULTS]
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULT_EVENTS]
                    .Nodes[_event.code.ToString()].Tag = D0_TreeViewNodeEventTag;

            }

            //  prompts (including defaults)
            //if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS] != null && 
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS].GetNodeCount(true) != 0)
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS].Nodes.Clear();

            foreach (int promptKey in Prompts.Messages.Keys)
            {
                PromptMessage prompt;
                prompt = Prompts.Messages[promptKey];

                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULTS]
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS]
                    .Nodes
                    .Add(promptKey.ToString(), "Prompt: " + prompt.Caption.ToString());

                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULTS]
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS]
                    .Nodes[promptKey.ToString()].ToolTipText = prompt.Text.ToString();

                this.D0_treeView_LoadedElements
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULTS]
                    .Nodes[this.D0_TreeViewNodeTitle_DEFAULT_PROMPTS]
                    .Nodes[promptKey.ToString()].Tag = D0_TreeViewNodePromptTag;
            }

            //  languages (including defaults)
            //if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_LANGUAGES] != null && 
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_LANGUAGES].GetNodeCount(true) != 0)
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_LANGUAGES].Nodes.Clear();
            //TODO: Add language loading first, then display the loaded languages here

            //  themes (including defaults)
            //if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_THEMES] != null && 
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_THEMES].GetNodeCount(true) != 0)
            //    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_DEFAULTS].Nodes[this.D0_TreeViewNodeTitle_DEFAULT_THEMES].Nodes.Clear();
            //TODO: Add theme loading first, then display the loaded themes here

            //  versions
            this.D0_richTextBox_StatusVersions.Text = "";
            foreach (string name in Diagnostics.DefaultVersions.Keys)
            {
                this.D0_richTextBox_StatusVersions.Text += ( name + " : " + Diagnostics.DefaultVersions[name] + "\n") ;
            }

        }
        #endregion

        /// <summary>
        /// Double-click on an element (node)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D0_treeView_LoadedElements_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if this is an element (not a title node), load data about the element in the corresponding 'About' control
            if(e.Node.Tag == null || e.Node.Tag.Equals(D0_TreeViewNodeTitleTag) == false)
            {
                string details;
                details = ""; //element details to display

                this.D0_richTextBox_DetailsAboutSelectedElement.Clear();
                this.D0_textBox_SelectedControlActions.Text = e.Node.Text; //display selected element

                //load details about the selected element, based on the tag
                switch (e.Node.Tag)
                {
                    case D0_TreeViewNodeComponentTag: 
                        {
                            details += ComponentFactory.LoadedComponents[e.Node.Name].ToString();
                            break;
                        }

                    case D0_TreeViewNodeEventTag:
                        {
                            details += Diagnostics.PossibleEvents[Convert.ToInt32(e.Node.Name)].ToString();
                            break;
                        }

                    case D0_TreeViewNodePromptTag:
                        {
                            details += Prompts.Messages[Convert.ToInt32(e.Node.Name)].ToString();
                            break;
                        }

                    case D0_TreeViewNodeLanguageTag:
                        {
                            // nothing to display
                            break;
                        }

                    case D0_TreeViewNodeThemeTag:
                        {
                            //TODO: Implement displaying theme details
                            break;
                        }

                    case null: //unspecified element type
                        {
                            details += "No details to display";
                            break;
                        }

                    default: //unrecognized element type
                        {
                            details += "Unrecognized element type";
                            break;
                        }
                }

                //display element details
                this.D0_richTextBox_DetailsAboutSelectedElement.Text = details;

            }
        }

        /// <summary>
        /// Check local files for inconsistencies and flag them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D0_button_Actions_CheckLocalFiles_Click(object sender, EventArgs e)
        {
            //TODO: Implement file signatures first
        }

        //if checked, allows the loading of third-party components
        private void D0_checkBox_AllowThirdPartyComponents_CheckedChanged(object sender, EventArgs e)
        {
            ComponentFactory.FLAG_AllowThirdPartyComponents = this.D0_checkBox_AllowThirdPartyComponents.Checked;
        }

        private void D0_button_OpenLogsFolder_Click(object sender, EventArgs e)
        {
            // open the logs folder
            Process.Start("explorer.exe", Path.GetFullPath(GeneralPaths.LOG_FOLDER_PATH));
        }

        private void D0_button_ExportLog_Click(object sender, EventArgs e)
        {
            this.D0_saveFileDialog_ExportLog.DefaultExt = Diagnostics.DEFAULT_LOGFILE_EXT;
            this.D0_saveFileDialog_ExportLog.Filter = $"Logfile |* {Diagnostics.DEFAULT_LOGFILE_EXT}";

            DialogResult result = this.D0_saveFileDialog_ExportLog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // export the log to a new file
                string logText = $"{Diagnostics.LOGFILE_HEADER_PREFIX} {DateTime.Now.ToString()}\n\n";

                foreach (string line in this.D0_listBox_DiagnosticLog.Items)
                {
                    logText += line + "\n";
                }

                // create / overwrite file
                File.AppendAllText(this.D0_saveFileDialog_ExportLog.FileName,logText);
            }
        }

        private void D0_button_SimPerformanceCheck_Click(object sender, EventArgs e)
        {
            //TODO: Implement sim performance check
        }

        private void D0_button_OpenCustomizationUtility_Click(object sender, EventArgs e)
        {
            //TODO: Implement customization utility form
        }
        
        public void D0_MainDiagnosticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.ApplicationExitCall) //=> only the form is closing cancel form closing and hide it instead
            {
                this.Hide();
                e.Cancel = true;
            }// else => the application is being closed
        }
    }
}

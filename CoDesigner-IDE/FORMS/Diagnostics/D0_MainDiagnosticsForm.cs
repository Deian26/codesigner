using CoDesigner_IDE.FORMS.IDE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static CoDesigner_IDE.Diagnostics;

namespace CoDesigner_IDE
{
    [SupportedOSPlatform("windows")]
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
        /// <summary>
        /// Delegate type used to update the diagnostic log from a different thread
        /// </summary>
        public delegate void DelegateType_UpdateDiagnosticLog();
        /// <summary>
        /// Delegate type used to update the diagnostic log from a different thread
        /// </summary>
        public DelegateType_UpdateDiagnosticLog Delegate_UpdateLoadedElementsDisplay;
        #endregion

        private enum AccessLevelGroup { ADMIN = 1, ADMIN_WORKSTATION = 3 } // access levels with permision to access this form

        // form properties
        private Size NormalSize { get; } // default form size to be used

        /// <summary>
        /// Provides user access to the diagnostic utility
        /// </summary>
        public D0_MainDiagnosticsForm()
        {
            InitializeComponent();

            // by default, this form should be invisible
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;

            // set initial form properties
            this.NormalSize = this.Size;

            // instantiate delegates
            this.Delegate_UpdateLoadedElementsDisplay = UpdateLoadedElementsDisplay;
        }

        private void D0_MainDiagnosticsPanel_Load(object sender, EventArgs e)
        {
            this.SetFormDefaultSize();
        }

        /// <summary>
        /// Sets the min/max form sizes
        /// </summary>
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
            bool accessGranted = false;

            if (token == null)
            {
                accessGranted = Security.CurrentSecurityProperties.ADMIN_WORKSTATION == true;
            }
            else
            {
                // check security access
                if (token.VALID == true &&
                    Enum.IsDefined(typeof(D0_MainDiagnosticsForm.AccessLevelGroup), (int)token.ACCESS_LEVEL) == true)
                {
                    // if this token is used to activate an admin workstation, store this property in a local file
                    if (token.ACCESS_LEVEL == Security.AccessLevel.ADMIN_WORKSTATION)
                    {
                        Utility.StoreSecurityProperties(
                            true
                            );

                    }

                    accessGranted = true;
                }
            }


            if (accessGranted == true)
            {
                this.SetFormDefaultSize();
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
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
            this.D0_treeView_DefaultElementsVersions.Nodes.Clear();
            foreach (string name in Diagnostics.DefaultVersions.Keys)
            {
                /* Format:
                 * elements name
                 * |- version
                 * ... other details
                 */

                TreeNode elementDetailsNode = this.D0_treeView_DefaultElementsVersions.Nodes.Add(name, name);

                //=// Version
                TreeNode versionSubNode = elementDetailsNode.Nodes.Add(Diagnostics.DEFAULT_ELEMENT_DETAILS_VERSION_KEY, Diagnostics.DefaultVersions[name]);
                versionSubNode.ToolTipText = Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.DIAGNOSTICS_ELEMENT_DETAILS_TOOLTIP_VERSION); // extra details (visible when the mouse is hovering over the node)

                //=// Origin
                TreeNode originSubNode = elementDetailsNode.Nodes.Add(Diagnostics.DEFAULT_ELEMENT_DETAILS_ORIGIN_KEY, Diagnostics.DEFAULY_ELEMENT_DETAILS_ORIGIN_DEFAULT); // origin = Default, for the default elements
                originSubNode.ToolTipText = Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.DIAGNOSTICS_ELEMENT_DETAILS_TOOLTIP_ORIGIN); ; // extra details (visible when the mouse is hovering over the node)
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
            if (e.Node.Tag == null || e.Node.Tag.Equals(D0_TreeViewNodeTitleTag) == false)
            {
                string details;
                details = ""; //element details to display

                this.D0_treeView_ActionDetails.Nodes.Clear();
                this.D0_textBox_ActionDetailsTitle.Text = e.Node.Text; //display selected element

                //TODO: Implement tree-view report for element loading
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

            }
        }

        /// <summary>
        /// Check local files for inconsistencies and flag them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void D0_button_Actions_CheckLocalFiles_Click(object sender, EventArgs e)
        {
            // reset display controls
            this.D0_textBox_ActionDetailsTitle.Text = Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.DIAGNOSTICS_CHECK_FILES_ACTION_TITLE);
            this.D0_treeView_ActionDetails.Nodes.Clear();

            // set the tag for the actions report tree view control
            this.D0_treeView_ActionDetails.Tag = Diagnostics.ACTON_REPORT_TAG_CHECK_FILES;

            try
            {
                // recursively parse program files for files to be checked
                string[] filePaths = Directory.EnumerateFiles(GeneralPaths.TOP_REL_PATH_BIN, "", SearchOption.AllDirectories).ToArray();

                foreach (string filePath in filePaths)
                {
                    Security.FileCheckResults fileCheckResults = Security.CheckFileIntegrity(filePath);

                    if (fileCheckResults.recognized == true && fileCheckResults.validFile == false) // invalid, but recognized file
                    {
                        string[] filePathSegments = filePath.Split(".");

                        /* Format:
                         * filename (key = full path)
                         * |- full path
                         * |- check timestamp
                         */
                        TreeNode invalidFileNode = this.D0_treeView_ActionDetails.Nodes.Add(filePath, filePathSegments[filePathSegments.Length - 1]);
                        invalidFileNode.ToolTipText = Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.DIAGNOSTICS_CHECK_FILES_INVALID_FILE_TOOLTIP);
                        invalidFileNode.Nodes.Add(filePath); // full path
                        invalidFileNode.Nodes.Add(DateTime.UtcNow.ToString()); // UTC timestamp for when the file was checked (now)
                    }
                }
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_INAUTHENTIC_FILE, ex.Message);
            }
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
                File.AppendAllText(this.D0_saveFileDialog_ExportLog.FileName, logText);
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

        /// <summary>
        /// Handles form closing actions for the D0 form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void D0_MainDiagnosticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.ApplicationExitCall) //=> only the form is closing cancel form closing and hide it instead
            {
                this.Hide();
                //this.ShowInTaskbar = false;
                e.Cancel = true;
            }// else => the application is being closed
        }

        // Export the report generated by a diagnostic action
        private void D0_button_ExportActionResults_Click(object sender, EventArgs e)
        {
            try
            {
                this.D0_errorProvider_DiagnosticsActionsErrors.Clear();

                // check if the action report tag is set
                if (this.D0_treeView_ActionDetails.Tag == null)
                {
                    string errorMessage = Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.DIAGNOSTICS_ERR_MESSAGE_NO_DIAGNOSTIC_ACTION_SELECTED);

                    if (errorMessage == null || errorMessage == string.Empty) // set default error message
                    {
                        errorMessage = "Error";
                    }

                    this.D0_errorProvider_DiagnosticsActionsErrors.SetError(
                        this.D0_button_ExportActionResults,
                        errorMessage);

                    return; // stop generating the report
                }

                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.Encoding = Encoding.UTF8;
                xmlWriterSettings.IndentChars = "\t";
                xmlWriterSettings.NewLineChars = "\r\n";

                StringBuilder xmlText = new StringBuilder();
                XmlWriter xmlWriter = XmlWriter.Create(xmlText, xmlWriterSettings);

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("report");

                // generate a report based on the tree view control's contents
                switch (this.D0_treeView_ActionDetails.Tag)
                {
                    case Diagnostics.ACTON_REPORT_TAG_CHECK_FILES: // check files action report
                        {
                            foreach (XmlNode invalidFileNode in this.D0_treeView_ActionDetails.Nodes)
                            {
                                // each node contains the details of a file marked as invalid
                                xmlWriter.WriteStartElement("invalid-file");

                                xmlWriter.WriteAttributeString("file-path", invalidFileNode.ChildNodes[0].Value);
                                xmlWriter.WriteAttributeString("check-timestamp", invalidFileNode.ChildNodes[1].Value);

                                xmlWriter.WriteEndElement();
                            }

                            break;
                        }
                    default: // unrecognized tag => ignore control
                        {
                            break;
                        }
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Close();

                // prompt the user for a path to save the report at
                this.D0_saveFileDialog_SaveActionReport.FileName = $"Report_{this.D0_treeView_ActionDetails.Tag}.xml";
                this.D0_saveFileDialog_SaveActionReport.DefaultExt = "xml";
                this.D0_saveFileDialog_SaveActionReport.Filter = "Report (*.xml)|*.xml";
                DialogResult saveReportDialogResult = this.D0_saveFileDialog_SaveActionReport.ShowDialog();

                if (saveReportDialogResult == DialogResult.OK)
                {
                    File.WriteAllText(this.D0_saveFileDialog_SaveActionReport.FileName, Security.DiagnosisEncrypt(xmlText.ToString()));
                }

            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_GENERATING_ACTION_REPORT, ex.Message);
            }
        }

        private void D0_button_AddApprovedGeneratorId_Click(object sender, EventArgs e)
        {
            // adds a new generator ID to the list of approved generator IDs
            F4_RegisterGenId f4_AddGenId = new F4_RegisterGenId(false); //=> do not create the used tokens local file
            if (f4_AddGenId.ShowDialog() != DialogResult.OK)
            {
                Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.SEC_ERROR_ADDING_GEN_ID);
            }
        }

        private void D0_button_GenerateDiagnosticStatusReport_Click(object sender, EventArgs e)
        {
            //TODO: Implement status report generation
        }
    }
}

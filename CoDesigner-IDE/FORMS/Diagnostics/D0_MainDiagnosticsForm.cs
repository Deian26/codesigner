using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public D0_MainDiagnosticsForm()
        {
            InitializeComponent();

            //instantiate delegates
            this.Delegate_UpdateLoadedElementsDisplay = UpdateLoadedElementsDisplay;
        }

        private void D0_MainDiagnosticsPanel_Load(object sender, EventArgs e)
        {
            //set minimum and maximum form sizes
            this.MaximumSize = this.MinimumSize = this.Size;
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
    }
}

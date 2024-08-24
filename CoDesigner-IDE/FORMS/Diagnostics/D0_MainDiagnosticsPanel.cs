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
    public partial class D0_MainDiagnosticsPanel : Form
    {
        private string D0_TreeViewNodeTitle_COMPONENTS = "Components";
        private string D0_TreeViewNodeTitle_EVENTS = "Events";
        private string D0_TreeViewNodeTitle_PROMPTS = "Prompts";
        private string D0_TreeViewNodeTitle_LANGUAGES = "Languages";
        private string D0_TreeViewNodeTitle_THEMES = "Themes";

        #region delegates
        public delegate void DelegateType_UpdateDiagnosticLog();
        public DelegateType_UpdateDiagnosticLog Delegate_UpdateLoadedElementsDisplay;
        #endregion

        public D0_MainDiagnosticsPanel()
        {
            InitializeComponent();

            //instantiate delegates
            this.Delegate_UpdateLoadedElementsDisplay = UpdateLoadedElementsDisplay;


            //create base nodes for the loaded elements tree view
            this.D0_treeView_LoadedElements.Nodes.Clear();
            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_COMPONENTS, this.D0_TreeViewNodeTitle_COMPONENTS);
            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_EVENTS, this.D0_TreeViewNodeTitle_EVENTS);
            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_PROMPTS, this.D0_TreeViewNodeTitle_PROMPTS);
            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_LANGUAGES, this.D0_TreeViewNodeTitle_LANGUAGES);
            this.D0_treeView_LoadedElements.Nodes.Add(this.D0_TreeViewNodeTitle_THEMES, this.D0_TreeViewNodeTitle_THEMES);
        }

        private void D0_MainDiagnosticsPanel_Load(object sender, EventArgs e)
        {
            
        }

        #region diagnostic-functions
        /// <summary>
        /// Updates the D0 controls displaying the loaded elements (components, events, prompts etc.)
        /// </summary>
        public void UpdateLoadedElementsDisplay()
        {
            //  components
            //clear sub-tree
            if(this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS]!=null && 
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS].GetNodeCount(true) != 0) 
                    this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS].Nodes.Clear();

            //add components
            foreach (string componentName in Components.LoadedComponents.Keys)
            {
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_COMPONENTS].Nodes.Add(componentName, componentName);
            }


            //  event definitions (including defaults)
            if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_EVENTS] != null && 
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_EVENTS].GetNodeCount(true) != 0) 
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_EVENTS].Nodes.Clear();

            foreach (Diagnostics.Event _event in Diagnostics.PossibleEvents.Values)
            {
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_EVENTS].Nodes.Add(_event.code.ToString(), _event.code.ToString());
            }

            //  prompts (including defaults)
            if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_PROMPTS] != null && 
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_PROMPTS].GetNodeCount(true) != 0)
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_PROMPTS].Nodes.Clear();

            foreach (PromptMessage prompt in Prompts.Messages.Values)
            {
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_PROMPTS].Nodes.Add(prompt.Caption.ToString(), prompt.Text.ToString());
            }

            //  languages (including defaults)
            if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_LANGUAGES] != null && 
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_LANGUAGES].GetNodeCount(true) != 0)
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_LANGUAGES].Nodes.Clear();
            //DEV - add language detection based on loaded elements

            //  themes (including defaults)
            if (this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_THEMES] != null && 
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_THEMES].GetNodeCount(true) != 0)
                this.D0_treeView_LoadedElements.Nodes[this.D0_TreeViewNodeTitle_THEMES].Nodes.Clear();
            // DEV - add theme loading first, then display the loaded themes here

        }
        #endregion
    }
}

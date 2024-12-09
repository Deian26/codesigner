using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    public partial class F1_1_SimBlueprints : Form
    {
        public F1_1_SimBlueprints()
        {
            InitializeComponent();
        }

        private void F2_SimBlueprints_Load(object sender, EventArgs e)
        {
            // load the imagelist into the treeview
            this.F2_treeView_Blueprints.ImageList = SimulationManager.BlueprintImagelist;

            // add blueprints to the corresponding treeview
            foreach(var abstractSimElement in SimulationManager.SimBlueprints)
            {
               if(this.F2_treeView_Blueprints.Nodes.ContainsKey(abstractSimElement.Key)==false) // create this element's category, if it does not exist
               {
                   this.F2_treeView_Blueprints.Nodes.Add(abstractSimElement.Key, abstractSimElement.Key);
               }

                // add the blueprint to the treeview
                this.F2_treeView_Blueprints.Nodes[abstractSimElement.Key].Nodes.Add(
                    abstractSimElement.Value.name, //key (abstract component name)
                    abstractSimElement.Value.name, // value
                    abstractSimElement.Value.name  // image key (the name of the abstract simulation element)
                );
               
            }
        }

        /// <summary>
        /// Start dragging a blueprint to create a new concrete element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F2_treeView_Blueprints_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                // store the data of the blueprint to be used
                DoDragDrop(
                            e.Item,
                            DragDropEffects.Copy
                            );
            }
        }
    }
}

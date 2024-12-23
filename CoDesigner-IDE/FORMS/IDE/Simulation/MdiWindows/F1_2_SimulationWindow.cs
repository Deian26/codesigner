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
    public partial class F1_2_SimulationWindow : Form
    {
        private SimulationEngine SimEngine = null; // handles simulation interactions
        private int simulationIndex { get; } = -1;

        public F1_2_SimulationWindow(SimulationEngine SimEngine, int simIndex)
        {
            InitializeComponent();

            this.SimEngine = SimEngine;
            this.simulationIndex = simIndex;
        }

        /// <summary>
        /// Create a new concrete element in the current simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F1_2_SimulationWindow_DragDrop(object sender, DragEventArgs e)
        {

            TreeNode blueprint = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if(SimulationManager.SimBlueprints.ContainsKey(blueprint.Name) == false) // unsupported / invalid concrete element type
            {
                Diagnostics.LogEvent(Diagnostics.DefaultEventCodes.UNSUPPORTED_CONCRETE_ELEMENT_TYPE, blueprint.Name);
                return;
            }

            AbstractSimElement abstractElement = SimulationManager.SimBlueprints[blueprint.Name];

            // create concrete object
            if (abstractElement.concreteType.Equals(typeof(ConcreteMicroprocessor)))
            {
                this.SimEngine.ConcreteElements.Add(
                    new ConcreteMicroprocessor(
                        abstractElement,
                        blueprint.Name,
                        (byte)this.SimEngine.simulationIndex,
                        (this.SimEngine.ConcreteElements.Count + 1), // current concrete element
                        new Point(e.X, e.Y)
                        )
                    );

            }else if(abstractElement.concreteType.Equals(typeof(ConcreteTransportMedium)))
            {
                this.SimEngine.ConcreteElements.Add(
                    new ConcreteTransportMedium(
                        abstractElement,
                        blueprint.Name,
                        (byte)this.SimEngine.simulationIndex,
                        (this.SimEngine.ConcreteElements.Count + 1), // current concrete element
                        new Point(e.X, e.Y)
                        )
                    );
            }else if (abstractElement.concreteType.Equals(typeof(ConcreteLogicalInput)))
            {
                this.SimEngine.ConcreteElements.Add(
                    new ConcreteLogicalInput(
                        abstractElement,
                        blueprint.Name,
                        (byte)this.SimEngine.simulationIndex,
                        (this.SimEngine.ConcreteElements.Count + 1), // current concrete element
                        new Point(e.X, e.Y)
                        )
                    );
            }else if (abstractElement.concreteType.Equals(typeof(ConcreteLogicalOutput)))
            {
                this.SimEngine.ConcreteElements.Add(
                    new ConcreteLogicalOutput(
                        abstractElement,
                        blueprint.Name,
                        (byte)this.SimEngine.simulationIndex,
                        (this.SimEngine.ConcreteElements.Count + 1), // current concrete element
                        new Point(e.X, e.Y)
                        )
                    );
            }
            else // unsupported concrete element type
            {
                Diagnostics.LogEvent(Diagnostics.DefaultEventCodes.UNSUPPORTED_CONCRETE_ELEMENT_TYPE, abstractElement.concreteType.ToString());
            }


        }

        private void F1_2_SimulationWindow_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validate blueprint being dragged into the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Must be a treeview item defining a blueprint </param>
        private void F1_2_SimulationWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else // unsupported format
            {
                e.Effect= DragDropEffects.None;
            }

        }
    }
}

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
    public partial class F1_SimulationContainer : Form
    {
        //configuration
        const string SIM_WINDOW_PREFIX = "F1_SimulationContainer "; // prepends the simulation window index

        // MDI windows
        private F1_1_SimBlueprints f1_1_SimBlueprints = new F1_1_SimBlueprints(); // abstract simulation element blueprints
        private List<F1_2_SimulationWindow> SimulationWindows = new List<F1_2_SimulationWindow>(); // simulation MDI windows
        
        public F1_SimulationContainer()
        {
            InitializeComponent();

            // load default MDI windows and setting buttons
            this.f1_1_SimBlueprints.MdiParent = this;
            this.f1_1_SimBlueprints.Visible = true;
            int simIndex;

            simIndex = this.SimulationWindows.Count + 1;
            F1_2_SimulationWindow defSimForm = new F1_2_SimulationWindow(new SimulationEngine(simIndex), simIndex); // create a default simulation window
            defSimForm.Text = F1_SimulationContainer.SIM_WINDOW_PREFIX + (simIndex).ToString();
            defSimForm.Visible = true;
            defSimForm.MdiParent = this;
            this.SimulationWindows.Add(defSimForm);
        }

        private void Simulation_Load(object sender, EventArgs e)
        {
               
        }
    }
}

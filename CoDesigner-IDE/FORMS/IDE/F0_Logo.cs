using CoDesigner_IDE.FORMS.IDE;
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

namespace CoDesigner_IDE
{
    public partial class F0_Logo : Form
    {
        private int delayTimerIntervalMs = 2000;
        private int cancelTimerIntervalMs = 10000; //maximum time to wait for component loading; after that, the program is stopped

        public F0_Logo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load installed components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F0_Logo_Load(object sender, EventArgs e)
        {
            this.F0_timer_CancelLoadTimer.Interval = this.cancelTimerIntervalMs;
            this.F0_timer_CancelLoadTimer.Start();

            List<string> installedComponents = Directory.EnumerateDirectories(Paths.COMPONENT_INSTALLATION_FOLDER).ToList();
            this.F0_progressBar_IdeLoading.Maximum = installedComponents.Count;
            this.F0_progressBar_IdeLoading.Step = 1;

            //load components
            foreach (string componentFolder in installedComponents)
            {
                string fullPath = Path.GetFullPath(componentFolder);

                //create new component and add it to the loaded components list
                this.F0_listBox_LoadedComponents.Items.Add("Loading... " + fullPath);

                Components.LoadedComponents.Add(new Component(componentFolder));

                this.F0_listBox_LoadedComponents.Items.Add("Loaded: " + fullPath);

                this.F0_progressBar_IdeLoading.PerformStep();
            }

            if (this.F0_progressBar_IdeLoading.Value == this.F0_progressBar_IdeLoading.Maximum)
            {
                this.F0_listBox_LoadedComponents.Items.Add("All components were loaded");

                this.F0_timer_LoadIdeDelayTimer.Interval = this.delayTimerIntervalMs;
                this.F0_timer_LoadIdeDelayTimer.Start();
            }
        }

        private void F0_timer_LoadIdeDelayTimer_Tick(object sender, EventArgs e)
        {
            //open the F1 form
            this.F0_timer_CancelLoadTimer.Stop();
            this.F0_timer_LoadIdeDelayTimer.Stop();


            Program.F1 = new F1_Projects();

            this.Hide();
            Program.F1.Show();


        }

        private void F0_timer_CancelLoadTimer_Tick(object sender, EventArgs e)
        {
            //cancel program loading
            MessageBox.Show("FATAL ERROR","Could not load elements",MessageBoxButtons.OK, MessageBoxIcon.Error);

            Program.StopAll();
        }
    }
}

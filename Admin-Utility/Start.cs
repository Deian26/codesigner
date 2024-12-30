using Admin_Utility.UTILITY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Utility
{
    [SupportedOSPlatform("windows")]
    internal static class Start
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check if setup resources for the network have been generated
            if (Utility.ConfigDataExists() == false)
            {
                if (MessageBox.Show($"No configuration archive could be found in {GeneralPaths.OUTPUT_CONFIG_DIR_ZIP_ARCHIVE}. Should a new configuration archive be generated?", "No configuration setup archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)// ask the user if a new configuration archive should be generated
                {
                    if (Utility.GenerateSetupConfigData() == true)
                    {
                        MessageBox.Show($"Configuration setup files successfully generated and archived in {GeneralPaths.OUTPUT_CONFIG_DIR_ZIP_ARCHIVE}", "Configuration generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } // else => error messages are displayed in message boxes within the config data generation method
                }
            }

            // start application
            Application.Run(new U0_MainForm());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Utility
{
    internal static class Start
    {
        [STAThread]
        [SupportedOSPlatform("windows")]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new U0_MainForm());
        }
    }
}

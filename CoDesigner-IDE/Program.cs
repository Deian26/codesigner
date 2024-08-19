using CoDesigner_IDE.FORMS.IDE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{

    internal static class Program
    {
        //forms
        //Diagnostics
        public static D0_MainDiagnosticsPanel D0 = null;
        //IDE
        public static F1_Projects F1 = null;
        public static F1_Projects F2 = null;
        public static F1_Projects F3 = null;

        //threads
        static Thread application = new Thread(startApplication);
        static Thread diagnostics = new Thread(startDiagnostics);

        private static void startApplication()
        {

            Application.Run(new F0_Logo());
        }

        private static void startDiagnostics()
        {
            Program.D0 = new D0_MainDiagnosticsPanel();
            Program.D0.Visible = false;
            
            Application.Run();
        }

        public static void StopAll()
        {
            Application.Exit();
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Diagnostics.DeleteLogs();

            Diagnostics.LoadDefaultPossibleEvents(); //load a list of default possible event; each component can defined their own events, in the configuration file
            Prompts.LoadDefaultMessages(); //load default messages

            //start application and diagnostics threads
            application.SetApartmentState(ApartmentState.STA);
            application.Start();

            diagnostics.SetApartmentState(ApartmentState.STA);
            diagnostics.Start();
            
        }
    }
}

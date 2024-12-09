using CoDesigner_IDE.FORMS.IDE;
using CoDesigner_IDE.FORMS.IDE.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{

    internal static class Program
    {
        //forms
        //Diagnostics
        public static D0_MainDiagnosticsForm D0 = null;
        //IDE
        public static F1_Projects F1 = null;
        public static F1_Projects F2 = null;
        public static F1_Projects F3 = null;
        public static F3_MainEditor Crt_F3 = null; // current project main editor form

        //threads
        static Thread application = new Thread(startApplication);
        static Thread diagnostics = new Thread(startDiagnostics);

        private static void startApplication()
        {

            Application.Run(new F0_Logo());
        }

        private static void startDiagnostics()
        {
            Program.D0 = new D0_MainDiagnosticsForm();
            Program.D0.Visible = false;
            
            Application.Run(Program.D0);
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
            //DEV DEBUG -- remove before release
#if DEBUG
            //Application.Run(new F1_SimulationContainer()); //TODO: REMOVE DEBUG STARTUP
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Diagnostics.DeleteLogs();

            //start application and diagnostics threads
            application.SetApartmentState(ApartmentState.STA);
            application.Name = "Application";
            application.Start();

            diagnostics.SetApartmentState(ApartmentState.STA);
            diagnostics.Name = "Diagnostics";
            diagnostics.Start();

#else // release

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Diagnostics.DeleteLogs();

            //start application and diagnostics threads
            application.SetApartmentState(ApartmentState.STA);
            application.Name = "Application";
            application.Start();

            diagnostics.SetApartmentState(ApartmentState.STA);
            diagnostics.Name = "Diagnostics";
            diagnostics.Start();
            
#endif


        }
    }
}

using CoDesigner_IDE.FORMS.IDE;
using CoDesigner_IDE.FORMS.IDE.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    [SupportedOSPlatform("windows")]
    internal static class Program
    {
        //forms
        //Diagnostics
        public static D0_MainDiagnosticsForm D0 = null;
        public static F0_Logo F0 = null;

        //IDE
        public static F1_Projects F1 = null;
        public static F1_Projects F2 = null;
        public static F1_Projects F3 = null;
        public static F3_MainEditor Crt_F3 = null; // current project main editor form

        //threads
        public static Thread applicationThread = new Thread(startApplication);
        public static Thread diagnosticsThread = new Thread(startDiagnostics);

        private static void startApplication()
        {
            Program.F0 = new F0_Logo();
            Application.Run(Program.F0);
        }

        private static void startDiagnostics()
        {
            Program.D0 = new D0_MainDiagnosticsForm();
            Application.Run(Program.D0);
        }

        public static void StopAll()
        {
            Utility.ApplicationExitActions();// perform any non-critical, cleanup actions

            Application.Exit(); // stop the other segments of the application
        }


        /// <summary>
        /// The main entry point for the applicationThread.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DEV DEBUG -- remove before release
#if DEBUG
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Diagnostics.DeleteLogs();

            //start applicationThread and diagnosticsThread threads
            applicationThread.SetApartmentState(ApartmentState.STA);
            applicationThread.Name = "Application";
            applicationThread.Start();

            diagnosticsThread.SetApartmentState(ApartmentState.STA);
            diagnosticsThread.Name = "Diagnostics";
            diagnosticsThread.Start();

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

using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Each object of this class defines an event to be logged
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal class LogEvent
    {
        Diagnostics.EVENT_ORIGIN origin { get; }
        Diagnostics.EVENT_SEVERITY severity { get; }
        int code { get; }
        string message { get; }

        /// <summary>
        /// Logs an event
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="severity"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="showMessageBox">ignored for FATAL and UNDEFINED events </param>
        public LogEvent(Diagnostics.EVENT_ORIGIN origin, Diagnostics.EVENT_SEVERITY severity, int code, string message, bool showMessageBox)
        {
            this.origin = origin;
            this.severity = severity;
            this.code = code;
            this.message = message;

            // log the event to the log file
            if (File.Exists(GeneralPaths.LOG_FILE_PATH) == false) //=> create file
            {
                StreamWriter logFile = File.CreateText(GeneralPaths.LOG_FILE_PATH);

                logFile.WriteLine($"{Diagnostics.LOGFILE_HEADER_PREFIX} {DateTime.Now.ToString()}\n");

                logFile.Close();
            }

            File.AppendAllText(GeneralPaths.LOG_FILE_PATH,$"[{DateTime.Now.ToString()}] > {message}\n");

            // show a message box and stop applicationThread, depending on the options
            switch (severity)
            {
                case Diagnostics.EVENT_SEVERITY.Info:
                    {
                        if(showMessageBox==true) MessageBox.Show(message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Debug:
                    {
                        
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Warning:
                    {
                        if (showMessageBox == true) MessageBox.Show(message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Error:
                    {
                        if (showMessageBox == true) MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Fatal:
                    {
                        MessageBox.Show(message, "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.StopAll();
                        break;
                    }

                default: //undefined
                    {
                        MessageBox.Show(message, "UNDEFINED ERROR (FATAL)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.StopAll();
                        break;
                    }
            }

        }

    }
}

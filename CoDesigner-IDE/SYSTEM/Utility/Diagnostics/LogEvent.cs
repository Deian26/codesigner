using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Each object of this class defines an event to be logged
    /// </summary>
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
            
            switch(severity)
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

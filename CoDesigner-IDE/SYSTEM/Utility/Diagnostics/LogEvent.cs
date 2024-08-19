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
        short code { get; }
        string message { get; }

        public LogEvent(Diagnostics.EVENT_ORIGIN origin, Diagnostics.EVENT_SEVERITY severity, short code, string message)
        {
            this.origin = origin;
            this.severity = severity;
            this.code = code;
            this.message = message;
            
            switch(severity)
            {
                case Diagnostics.EVENT_SEVERITY.Info:
                    {
                        MessageBox.Show(message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Debug:
                    {
                        
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Warning:
                    {
                        MessageBox.Show(message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                case Diagnostics.EVENT_SEVERITY.Error:
                    {
                        MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

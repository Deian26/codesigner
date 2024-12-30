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
    public class LogEvent
    {
        
        #region static
        public static ImageList eventImageList = new ImageList
        {
           
        };
        #endregion

        public Diagnostics.EVENT_ORIGIN origin { get; }
        public Diagnostics.EVENT_SEVERITY severity { get; }
        public int code { get; }
        public string message { get; }
        public int fullCode { get; } // origin and event code (origin << 16 | code)
        public DateTime timestamp { get; }

        /// <summary>
        /// Logs an event
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="severity"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="showMessageBox">Ignored for FATAL and UNDEFINED events </param>
        public LogEvent(Diagnostics.EVENT_ORIGIN origin, Diagnostics.EVENT_SEVERITY severity, int code, string message, bool showMessageBox)
        {
            this.origin = origin;
            this.severity = severity;
            this.code = code;
            this.fullCode = (int)this.origin << 16 | this.code;
            this.message = message;

            string text = $"[{timestamp.ToString()}] > {message}\n"; // text to append to the log file
            // log the event to the log file
            if (File.Exists(GeneralPaths.LOG_FILE_PATH) == false) //=> create file
            {
                text = $"{Diagnostics.LOGFILE_HEADER_PREFIX} {DateTime.Now.ToString()}\n" + text;

                File.WriteAllText(GeneralPaths.LOG_FILE_PATH, Security.Encrypt(text));
            }
            else
            {
                text = Security.Decrypt(File.ReadAllText(GeneralPaths.LOG_FILE_PATH)) + text;
                File.AppendAllText(GeneralPaths.LOG_FILE_PATH, Security.Encrypt(text));
            }
            
            // show a message box and stop applicationThread, depending on the options
            switch (severity)
            {
                case Diagnostics.EVENT_SEVERITY.Info:
                    {
                        if (showMessageBox == true) MessageBox.Show(message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        // fatal errors always display a message box
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

            Program.D0.BeginInvoke(Program.D0.LogEvent, this); // log event in the diagnostic form

        }

        /// <summary>
        /// Logs an event with a silent (hidden) message that is only logged and not displayed
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="severity"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="showMessageBox">Ignored for FATAL and UNDEFINED events </param>
        /// <param name="silentMessage">Message to be logged but not displayed, even if a message box is requested; this is appended to the regular message</param>
        public LogEvent(Diagnostics.EVENT_ORIGIN origin, Diagnostics.EVENT_SEVERITY severity, int code, string message, bool showMessageBox, string silentMessage)
        {
            this.origin = origin;
            this.severity = severity;
            this.code = code;
            this.fullCode = (int)this.origin << 16 | this.code;
            this.message = message + ":" +silentMessage;
            this.timestamp = DateTime.Now;

            string text = $"[{timestamp.ToString()}] > {message}\n"; // text to append to the log file
            // log the event to the log file
            if (File.Exists(GeneralPaths.LOG_FILE_PATH) == false) //=> create file
            {
                text = $"{Diagnostics.LOGFILE_HEADER_PREFIX} {DateTime.Now.ToString()}\n" + text;

                File.WriteAllText(GeneralPaths.LOG_FILE_PATH, Security.Encrypt(text));
            }
            else
            {
                text = Security.Decrypt(File.ReadAllText(GeneralPaths.LOG_FILE_PATH)) + text;
                File.AppendAllText(GeneralPaths.LOG_FILE_PATH, Security.Encrypt(text));
            }

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
            Program.D0.BeginInvoke(Program.D0.LogEvent, this); // log event in the diagnostic form

        }

        /// <summary>
        /// Returns the current log event's string representation
        /// </summary>
        /// <returns>Details about the current event as a string</returns>
        public new string ToString()
        {
            string eventText = "";

            eventText += $"[{this.timestamp.ToString()}][{this.severity}][{this.fullCode}] > {this.message}";
                

            return eventText;
        }
    }
}

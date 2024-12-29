using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Handles IDE diagnosticsThread
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class Diagnostics
    {
        #region logging
        public struct Event
        {
            public Diagnostics.EVENT_ORIGIN origin;
            public Diagnostics.EVENT_SEVERITY severity;
            public int code;
            public string message;

            public Event(Diagnostics.EVENT_ORIGIN origin, Diagnostics.EVENT_SEVERITY severity, int code, string message)
            {
                this.origin = origin;
                this.severity = severity;
                this.code = code;
                this.message = message;
            }

            override public string ToString()
            {
                string str;

                str = "Event\n";

                str += ("Code: "+"0x"+this.code.ToString("X8")+"\n");
                str += ("Message: "+this.message+"\n");
                str += ("Origin: "+Enum.GetName(typeof(Diagnostics.EVENT_ORIGIN),this.origin)+"\n");
                str += ("Severity: "+Enum.GetName(typeof(Diagnostics.EVENT_SEVERITY), this.severity)+"\n");
                str += "\n";

                return str;
            }
        }
        /// <summary>
        /// List of possible events, based on read EVENTS files
        /// </summary>
        public static Dictionary<int,Event> PossibleEvents = new Dictionary<int,Event>(); //format: code,event

        public static Dictionary<string, string> DefaultVersions = new Dictionary<string, string>(); // list of default item versions

        /// <summary>
        /// Key for the version sub-node of the element versions tree (D0 form)
        /// </summary>
        public const string DEFAULT_ELEMENT_DETAILS_VERSION_KEY = "Version";
        /// <summary>
        /// Key for the origin sub-node of the element versions tree (D0 form)
        /// </summary>
        public const string DEFAULT_ELEMENT_DETAILS_ORIGIN_KEY = "Origin";
        /// <summary>
        /// The current element is provided by default, with the IDE
        /// </summary>
        public const string DEFAULY_ELEMENT_DETAILS_ORIGIN_DEFAULT = "Default";
        /// <summary>
        /// Used for selecting the format report, when exporting the tree view node report
        /// </summary>
        public const string ACTON_REPORT_TAG_CHECK_FILES = "CheckFiles";
        /// <summary>
        /// Logged event severity; does not include the user program
        /// </summary>
        public enum EVENT_SEVERITY { Info = 0, Debug = 1, Warning = 2, Error = 3, Fatal = 4 };
        /// <summary>
        /// Logged event origin; does not include the errors within the user's program(s) (only indicates whether the program caused an error outside itself)
        /// </summary>
        public enum EVENT_ORIGIN { Undefined = 0, IDE = 1, Component = 2, UserProgram = 3};

        public const string LOGFILE_HEADER_PREFIX = "#> Logfile created at ";
        public const string DEFAULT_LOGFILE_EXT = ".log";
        public static List<LogEvent> EventLog = new  List<LogEvent>(); //list of logged events

        public static short UNDEFINED_ERROR_CODE = 0x0000;
        public static short UNDEFINED_FATAL_ERROR_CODE = 0x00FF;

        public const short DEFAULT_UNDEFINED_ORIGIN_CODE = 0x0000;
        public const short DEFAULT_IDE_ORIGIN_CODE = 0x0001;
        public const short DEFAULT_COMPONENT_ORIGIN_CODE = 0x0002;

        public const short DEFAULT_UNDEFINED_EVENT_CODE = 0x0000; // no events are defined for this error

        public static class DefaultEventCodes
        {
            public const int UNSUPPORTED_COMPONENT                          = 1;
            public const int INVALID_PROJECT_NAME                           = 2;
            public const int INVALID_PROJECT_FOLDER_LOC                     = 3;
            public const int INVALID_MSGBOX_BUTONS_OR_ICON_CODE             = 4;
            public const int ERR_LOADING_GUI_DEF_MSGS                       = 5;
            public const int ERR_LOADING_GUI_TRANSLATED_MSGS                = 6;
            public const int ERR_LOADING_PROJECT                            = 7;
            public const int ERR_LOADING_EVENT                              = 8;
            public const int ERR_LOADING_ACTIVE_PROJECTS                    = 9;
            public const int INVALID_PROGR_ITEMS_DEFINITIONS                = 10;
            public const int ERR_LOADING_VERSIONS                           = 11;
            public const int ERR_LOADING_COMPONENT_CTRL_FROM_FILE           = 12;
            public const int UNDEFINED_COMPONENT                            = 13;
            public const int INVALID_SIM_ADDON_DEFINITION                   = 14;
            public const int INVALID_SIM_ADDON_ELEM_DEFINITION              = 15;
            public const int GENERAL_ERR_LOADING_COMPONENT                  = 16;
            public const int SIGNAL_GENERATOR_UNSUPPORTED_VALUE_TYPE        = 17;
            public const int UNSUPPORTED_CONCRETE_ELEMENT_TYPE              = 18;
            public const int ERROR_CREATING_NEW_PROJECT                     = 19;
            public const int INVALID_PROJ_ITEMPATH_OR_UNSUPPORTED_ITEM      = 20;
            public const int ERROR_GENERATING_SIGNATURE                     = 21;
            public const int ERROR_LOADING_SECURITY_PROPERTIES              = 22;
            public const int INVALID_TOKEN                                  = 23;
            public const int INVALID_TOKEN_STRING_FORMAT                    = 24;
            public const int TOKEN_EXPIRED                                  = 25;
            public const int INSUFFICIENT_TOKEN_ACCESS_LEVEL                = 26;
            public const int ERROR_STORING_SECURITY_PROPERTIES              = 27;
            public const int ENC_ERROR                                      = 28;
            public const int DEC_ERROR                                      = 29;
            public const int ENC_ERROR_UNSUPPORTED_OS                       = 30;
            public const int DEC_ERROR_UNSUPPORTED_OS                       = 31;
            public const int ERR_STORING_APP_EXIT_DATA                      = 32;
            public const int ERR_LOADING_USED_SEC_TOKENS                    = 33;
            public const int ALREADY_USED_TOKEN                             = 34;
            public const int ERR_PARSING_CONFIG_FILES                       = 35;
            public const int ERR_INAUTHENTIC_FILE                           = 36;
            public const int ERR_GENERATING_ACTION_REPORT                   = 37;
            public const int ERR_ENCRYPTING_DIAGNOSTIC_REPORT               = 38;
            public const int GENERAL_FATAL_SECURITY_ERROR                   = 39;
            public const int ERROR_ACTIVATING_PROGRAM                       = 40;
            public const int SEC_ERROR_ADDING_GEN_ID                        = 41;
        }

        /// <summary>
        /// Deletes old log files
        /// </summary>
        public static void DeleteLogs()
        {
            List<string> logs = Directory.EnumerateFiles(GeneralPaths.LOG_FOLDER_PATH).ToList();
            
            foreach(string log in logs) 
            { 
                if(log.EndsWith(".log") == true) File.Delete(log);
            }
        }

        /// <summary>
        /// Logs an event based on the given code (the event details must be defined in one of the loaded components' configuration files)
        /// </summary>
        /// <param name="code"> 4 bytes: byte0-byte1 = origin (component code, IDE code etc.), byte2-byte3 = event defined in the component's configuration file </param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogEvent(int code)
        {
            string message = null;
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message,
                    true
                    ));
                message = Diagnostics.PossibleEvents[code].message;
            }
            catch (Exception ex)
            {
                MessageBox.Show( $"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return message;
        }

        /// <summary>
        /// Logs an event without displaying a message box
        /// </summary>
        /// <param name="code">Event code</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogSilentEvent(int code)
        {
            string message = null;
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message,
                    false //silent
                    ));

                message = Diagnostics.PossibleEvents[code].message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return message;
        }

        /// <summary>
        /// Logs an event based on the given origin and event code (same as the 1 integer overload, but that method expects the full code)
        /// </summary>
        /// <param name="originCode">Origin code</param>
        /// <param name="eventCode">Event code</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogEvent(int originCode, int eventCode)
        {
            string message = null;
            int code;
            code = (originCode<<16) | eventCode;

            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message,
                    true //a MessageBox is displayed
                    ));

                message = Diagnostics.PossibleEvents[code].message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return message;
        }

        /// <summary>
        /// Logs an event without displaying a message box
        /// </summary>
        /// <param name="originCode">Origin code</param>
        /// <param name="eventCode">Event code</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogSilentEvent(int originCode, int eventCode)
        {
            string message = null;
            int code;
            code = (originCode << 16) | eventCode;

            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message,
                    false //silent (no MessageBox is displayed) 
                    ));

                message = Diagnostics.PossibleEvents[code].message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return message;
        }

        /// <summary>
        /// Logs an event based on the given code, but also appends 'message' to the message loaded from the event / configuration file
        /// </summary>
        /// <param name="code">Full event code</param>
        /// <param name="message">Message</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogEvent(int code, string message)
        {
            string _message = null;
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message + message,
                    true
                    ));

                _message = Diagnostics.PossibleEvents[code].message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _message;
        }

        /// <summary>
        /// Logs an event without displaying a message box
        /// </summary>
        /// <param name="code">Full event code</param>
        /// <param name="message">Event message</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogSilentEvent(int code, string message)
        {
            string _message = null;
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message + message,
                    false //silent
                    ));

                _message = Diagnostics.PossibleEvents[code].message + message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _message;
        }

        /// <summary>
        /// Logs an event with a custom message based on the given origin and event codes
        /// </summary>
        /// <param name="originCode">Origin code</param>
        /// <param name="eventCode">Event code</param>
        /// <param name="message">Event message</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogEvent(int originCode, int eventCode, string message)
        {
            string _message = null;
            int code;
            code = (originCode << 16) | eventCode;
            try 
            { 
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message + message,
                    true
                    ));

                _message = Diagnostics.PossibleEvents[code].message + message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _message;
        }

        /// <summary>
        /// Logs an event without displaying a message box
        /// </summary>
        /// <param name="originCode">Origin code</param>
        /// <param name="eventCode">Event code</param>
        /// <param name="message">Event message</param>
        /// <returns>The event's message, if found; otherwise, null</returns>
        public static string LogSilentEvent(int originCode, int eventCode, string message)
        {
            string _message = null;
            int code;
            code = (originCode << 16) | eventCode;
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    Diagnostics.PossibleEvents[code].origin,
                    Diagnostics.PossibleEvents[code].severity,
                    Diagnostics.PossibleEvents[code].code,
                    Diagnostics.PossibleEvents[code].message + message,
                    false //silent
                    ));

                _message = Diagnostics.PossibleEvents[code].message + message;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _message;
        }

        /// <summary>
        /// Logs an anonymous event with the given detiails, without looking it up in the events list
        /// </summary>
        /// <param name="originCode"></param>
        /// <param name="eventCode"></param>
        /// <param name="eventSeverity"></param>
        /// <param name="message"></param>
        /// <returns>For uniformity with the other logger methods, the message is returned</returns>
        public static string LogDirectSilentEvent(int originCode, int eventCode, EVENT_SEVERITY eventSeverity, string message)
        {
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    (EVENT_ORIGIN)originCode,
                    (EVENT_SEVERITY)eventSeverity,
                    eventCode,
                    message,
                    false
                    ));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return message;
        }

        /// <summary>
        /// Logs an anonymous event with the given detiails, without looking it up in the events list and opens a message box for it
        /// </summary>
        /// <param name="originCode"></param>
        /// <param name="eventCode"></param>
        /// <param name="eventSeverity"></param>
        /// <param name="message"></param>
        /// <param name="silentMessage">Message to be logged, but not displayed to the user</param>
        /// <returns>For uniformity with the other logger methods, the message is returned</returns>
        public static string LogDirectEvent(int originCode, int eventCode, EVENT_SEVERITY eventSeverity, string message, string silentMessage)
        {
            try
            {
                Diagnostics.EventLog.Add(new LogEvent(
                    (EVENT_ORIGIN)originCode,
                    (EVENT_SEVERITY)eventSeverity,
                    eventCode,
                    message,
                    true,
                    silentMessage
                    ));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging an event. Details: {ex.Message}", "LOGGING ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return message;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Handles IDE diagnostics
    /// </summary>
    internal static class Diagnostics
    {
        #region logging
        public struct Event
        {
            public Diagnostics.EVENT_ORIGIN origin;
            public Diagnostics.EVENT_SEVERITY severity;
            public short code;
            public string message;

            public Event(Diagnostics.EVENT_ORIGIN origin, Diagnostics.EVENT_SEVERITY severity, short code, string message)
            {
                this.origin = origin;
                this.severity = severity;
                this.code = code;
                this.message = message;
            }
        }
        /// <summary>
        /// List of possible events, based on read EVENTS files
        /// </summary>
        public static Dictionary<int,Event> PossibleEvents = new Dictionary<int,Event>(); //format: code,event

        /// <summary>
        /// Logged event severity; does not include the user program
        /// </summary>
        public enum EVENT_SEVERITY { Info = 0, Debug = 1, Warning = 2, Error = 3, Fatal = 4 };
        /// <summary>
        /// Logged event origin; does not include the errors within the user's program(s) (only indicates whether the program caused an error outside itself)
        /// </summary>
        public enum EVENT_ORIGIN { Undefined = -1, IDE = 0, Component = 1, UserProgram = 2};

        public static string LOG_FOLDER_PATH = "../../SYSTEM/Utility/Diagnostics/Logs/"; //logs stored on the disk; the file sizes are limited to the value defined in 'LOG_FILE_MAXSIZE'
        public static string LOG_EventLogFilename = "Events.log"; //filename for the general log; the extension for all logs is '.log'
        
        public static List<LogEvent> EventLog = new List<LogEvent>(); //list of logged events

        public static short UNDEFINED_ERROR_CODE = 0x0000;
        public static short UNDEFINED_FATAL_ERROR_CODE = 0x00FF;

        /// <summary>
        /// Loads a list of default possible events and their codes
        /// </summary>
        public static void LoadDefaultPossibleEvents()
        {
            //get default events
            if(File.Exists(Paths.DEFAULT_EVENTS_FILEPATH) == true)
            {
                XmlDocument eventsFile = new XmlDocument();
                eventsFile.Load(Paths.DEFAULT_EVENTS_FILEPATH);
                XmlNode root = eventsFile.DocumentElement;

                foreach(XmlNode _event in root.ChildNodes)
                {
                    if(_event.Name.Equals("event")==true)
                    {
                        try
                        {
                            short code;
                            Diagnostics.EVENT_ORIGIN origin;
                            string message = null;

                            code = Convert.ToInt16(_event.Attributes["code"].Value.ToString());
                            origin = (Diagnostics.EVENT_ORIGIN)Convert.ToInt32(_event.Attributes["origin"].Value.ToString());

                            //get event message, based on the current language
                            foreach(XmlNode messageTranslation in _event.ChildNodes)
                            {
                                if (messageTranslation.Name.Equals(Customization.Language) == true)
                                {
                                    message = messageTranslation.Attributes["message"].Value.ToString();
                                    break;
                                }
                            }

                            Diagnostics.PossibleEvents.Add(((int)origin<<16)|(code&0xFFFF), new Event(
                                origin,
                                (Diagnostics.EVENT_SEVERITY)Convert.ToInt32(_event.Attributes["severity"].Value.ToString()),
                                code,
                                message
                                ));
                        }catch (Exception ex)
                        {
                            //invalid event definition
                            Diagnostics.EventLog.Add(new LogEvent(EVENT_ORIGIN.Undefined, EVENT_SEVERITY.Error, Diagnostics.UNDEFINED_ERROR_CODE, "Invalid event definition: "+ex.Message.ToString()));
                        }
                    }
                }

            }
            else //fatal error -> could not load default events
            {
                new LogEvent(EVENT_ORIGIN.Undefined, EVENT_SEVERITY.Fatal, Diagnostics.UNDEFINED_FATAL_ERROR_CODE, "COULD NOT LOAD DEFAULT LOG EVENTS!");
            }
        }

        /// <summary>
        /// Deletes old log files
        /// </summary>
        public static void DeleteLogs()
        {
            List<string> logs = Directory.EnumerateFiles(Diagnostics.LOG_FOLDER_PATH).ToList();

            foreach(string log in logs) 
            { 
                if(log.EndsWith(".log") == true) File.Delete(log);
            }
        }

        /// <summary>
        /// Logs an event based on the given code (the event details must be defined in one of the loaded components' configuration files)
        /// </summary>
        /// <param name="code"> 4 bytes: byte0-byte1 = origin (component code, IDE code etc.), byte2-byte3 = event defined in the component's configuration file </param>
        public static void LogEvent(int code)
        {
            Diagnostics.EventLog.Add(new LogEvent(
                Diagnostics.PossibleEvents[code].origin,
                Diagnostics.PossibleEvents[code].severity,
                Diagnostics.PossibleEvents[code].code,
                Diagnostics.PossibleEvents[code].message));
        }

        /// <summary>
        /// Logs an event based on the given origin and event code (same as the 1 integer overload, but that method expects the full code)
        /// </summary>
        /// <param name="originCode"></param>
        /// <param name="eventCode"></param>
        public static void LogEvent(int originCode, int eventCode)
        {
            int code;
            code = (originCode<<16) | eventCode;

            Diagnostics.EventLog.Add(new LogEvent(
                Diagnostics.PossibleEvents[code].origin,
                Diagnostics.PossibleEvents[code].severity,
                Diagnostics.PossibleEvents[code].code,
                Diagnostics.PossibleEvents[code].message));
        }

        /// <summary>
        /// Logs an event based on the given code, but also appends 'message' to the message loaded from the event / configuration file
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public static void LogEvent(int code, string message)
        {
            Diagnostics.EventLog.Add(new LogEvent(
                Diagnostics.PossibleEvents[code].origin,
                Diagnostics.PossibleEvents[code].severity,
                Diagnostics.PossibleEvents[code].code,
                Diagnostics.PossibleEvents[code].message + message));
        }
        
        /// <summary>
        /// Logs an event with a custom message based on the given origin and event codes
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public static void LogEvent(int originCode, int eventCode, string message)
        {
            int code;
            code = (originCode << 16) | eventCode;

            Diagnostics.EventLog.Add(new LogEvent(
                Diagnostics.PossibleEvents[code].origin,
                Diagnostics.PossibleEvents[code].severity,
                Diagnostics.PossibleEvents[code].code,
                Diagnostics.PossibleEvents[code].message + message));
        }

        #endregion
    }
}

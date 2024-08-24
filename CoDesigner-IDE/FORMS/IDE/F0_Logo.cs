﻿using CoDesigner_IDE.FORMS.IDE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoDesigner_IDE.Diagnostics;
using System.Xml;

namespace CoDesigner_IDE
{
    public partial class F0_Logo : Form
    {
        private int delayTimerIntervalMs = 500;
        private int cancelLoadingTimerFactor = 2000; //factor by which to multiply the number of elements to be loaded, which will then be used as a maximum amount of time to wait for them to be loaded

        public F0_Logo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load installed components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F0_Logo_Load(object sender, EventArgs e)
        {
            //set minimum and maximum form sizes
            this.MinimumSize = this.MaximumSize = this.Size;

            List<string> installedComponents = Directory.EnumerateDirectories(Paths.COMPONENT_INSTALLATION_FOLDER).ToList();
            XmlDocument eventsFile = new XmlDocument();
            XmlDocument activeProjectsFile = new XmlDocument();
            XmlDocument defaultMessages = new XmlDocument();
            XmlDocument versions = new XmlDocument();

            try
            {
                eventsFile.Load(Paths.DEFAULT_EVENTS_FILEPATH);
                activeProjectsFile.Load(Paths.ACTIVE_PROJECTS_FILEPATH);
                defaultMessages.Load(Paths.DEFAULT_MESSAGES_FILEPATH);
                versions.Load(Paths.VERSIONS_FILEPATH);
            }catch(Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE,10,ex.Message);
            }

            this.F0_progressBar_IdeLoading.Maximum = installedComponents.Count +  
                                                     activeProjectsFile.DocumentElement.ChildNodes.Count +
                                                     versions.DocumentElement.ChildNodes.Count +
                                                     2 ; //events + messages (1 step each)
            this.F0_progressBar_IdeLoading.Step = 1;

            //start the timer used to cancel the loading of elements, if a certain time limit is reached (dynamic, based on the number of elements to load)
            this.F0_timer_CancelLoadTimer.Interval = this.F0_progressBar_IdeLoading.Maximum * this.cancelLoadingTimerFactor;
            this.F0_timer_CancelLoadTimer.Start();

            //  load versions
            if(File.Exists(Paths.VERSIONS_FILEPATH) == true)
            {
                try
                {
                    foreach (XmlNode version in versions.DocumentElement.ChildNodes)
                    {
                        if (version.Name.Equals("item") == true)
                        {
                            Diagnostics.DefaultVersions.Add(version.Attributes["name"].Value, version.Attributes["version"].Value);
                        }
                    }
                }catch(Exception ex)
                {
                    Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, 11, ex.Message);
                }
            }

            //  load event and message definitions
            //load a list of default possible event; each component can defined their own events, in the configuration file
            //get default events
            this.F0_listBox_LoadingElements.Items.Add("Loading events from " + Paths.DEFAULT_EVENTS_FILEPATH + " ... ");
            bool allEventsLoaded = true;

            if (File.Exists(Paths.DEFAULT_EVENTS_FILEPATH) == true)
            {

                XmlNode root = eventsFile.DocumentElement;

                foreach (XmlNode _event in root.ChildNodes)
                {
                    if (_event.Name.Equals("event") == true)
                    {
                        try
                        {
                            int code;
                            Diagnostics.EVENT_ORIGIN origin;
                            string message = null;

                            origin = (Diagnostics.EVENT_ORIGIN)Convert.ToInt32(_event.Attributes["origin"].Value.ToString());
                            code = ((Convert.ToInt32(_event.Attributes["code"].Value) & 0xFFFF) | (((int)origin & 0xFFFF) << 16));

                            //get event message, based on the current language
                            foreach (XmlNode messageTranslation in _event.ChildNodes)
                            {
                                if (messageTranslation.Name.Equals(Customization.Language) == true)
                                {
                                    message = messageTranslation.Attributes["message"].Value.ToString();
                                    break;
                                }
                            }

                            Diagnostics.PossibleEvents.Add(((int)origin << 16) | (code & 0xFFFF), new Event(
                                origin,
                                (Diagnostics.EVENT_SEVERITY)Convert.ToInt32(_event.Attributes["severity"].Value.ToString()),
                                code,
                                message
                                ));

                            this.F0_progressBar_IdeLoading.PerformStep();
                        }
                        catch (Exception ex)
                        {
                            allEventsLoaded = false;
                            //invalid event definition
                            Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, 8, ex.Message);
                        }
                    }
                }

            }
            else //fatal error -> could not load default events
            {
                allEventsLoaded = false;
                this.F0_listBox_LoadingElements.Items.Add(" X ERROR: COULD NOT LOAD DEFAULT LOG EVENTS!");
                new LogEvent(EVENT_ORIGIN.Undefined, EVENT_SEVERITY.Fatal, Diagnostics.UNDEFINED_FATAL_ERROR_CODE, "COULD NOT LOAD DEFAULT LOG EVENTS!", true);
            }

            if (allEventsLoaded == false)
            {
                this.F0_listBox_LoadingElements.Items.Add("X ERROR:Could not load all events! See the diagnostic log for details.");
            }
            else
            {
                this.F0_listBox_LoadingElements.Items.Add("Loaded events.");
            }


            //load default messages
            bool allMessagesLoaded = true;
            this.F0_listBox_LoadingElements.Items.Add("Loading prompts from "+ Paths.DEFAULT_MESSAGES_FILEPATH + " ... ");
            try
            {
                XmlNode root = defaultMessages.DocumentElement;

                foreach (XmlNode message in root.ChildNodes)
                {
                    if (message.Name.Equals("message"))
                    {

                        string caption = null, text = null;
                        int code;

                        code = (Prompts.DEFAULT_MESSAGES_ORIGIN_CODE << 16) | (Convert.ToInt32(message.Attributes["code"].Value.Trim()) & 0xFFFF);
                        //get translation
                        foreach (XmlNode translation in message.ChildNodes)
                        {
                            if (translation.Name.Equals(Customization.Language) == true)
                            {
                                caption = translation.Attributes["caption"].Value;
                                text = translation.Attributes["text"].Value;
                                break;
                            }
                        }


                        if (caption != null && text != null)
                        {
   
                            Prompts.Messages.Add(
                                code,
                                new PromptMessage(
                                    caption,
                                    text,
                                    Convert.ToInt32(message.Attributes["dialog_buttons"].Value.Trim()),
                                    Convert.ToInt32(message.Attributes["dialog_icon"].Value.Trim())
                                    )
                                );
                        }
                        else //translation not found
                        {
                            allMessagesLoaded = false;
                            Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, 6, "Language: " + Customization.Language.ToString() + "; message code: " + code.ToString());
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                allMessagesLoaded = false;
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE,5, ex.Message);
            }

            if(allMessagesLoaded == false)
            {
                this.F0_listBox_LoadingElements.Items.Add("X ERROR:Could not load all default messages! See the diagnostic log for details.");
            }
            else
            {
                this.F0_listBox_LoadingElements.Items.Add("Loaded default messages.");
            }

            //load active projects
            bool allActiveProjectsLoaded = true;
            try
            {
                XmlNode root = activeProjectsFile.DocumentElement;

                foreach (XmlNode project in root.ChildNodes)
                {
                    if (project.Name.Equals("project") == true)
                    {
                        try
                        {
                            this.F0_listBox_LoadingElements.Items.Add("Loading project: " + project.Name + " ...");

                            ProjectManagement.Projects.Add(
                                project.Attributes["project_filepath"].Value,
                                new Project(project.Attributes["project_filepath"].Value)
                                );
                            this.F0_listBox_LoadingElements.Items[this.F0_listBox_LoadingElements.Items.Count - 1] += " | Loaded";
                        }
                        catch (Exception ex)
                        {
                            //event logged in the constructor
                            allActiveProjectsLoaded = false;
                            this.F0_listBox_LoadingElements.Items[this.F0_listBox_LoadingElements.Items.Count - 1] += (" X ERROR: "+ex.Message);
                        }
                    }
                    else
                    {
                        this.F0_progressBar_IdeLoading.Maximum -= 1;
                        continue;
                    }

                    this.F0_progressBar_IdeLoading.PerformStep();
                }

            }
            catch (Exception ex)
            {
                allActiveProjectsLoaded = false;
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, 9, ex.Message);
                this.F0_listBox_LoadingElements.Items.Add(" X ERROR: COULD NOT LOAD ACTIVE PROJECTS: " + ex.Message);
            }

            if(allActiveProjectsLoaded == false)
            {
                this.F0_listBox_LoadingElements.Items.Add("X ERROR:Could not load all active projects! See the diagnostic log for details.");
            }
            else
            {
                this.F0_listBox_LoadingElements.Items.Add("Loaded active projects.");
            }

            //load components
            this.F0_listBox_LoadingElements.Items.Add("Loading components from " + Paths.COMPONENT_INSTALLATION_FOLDER +" ...");
            bool allComponentsLoaded = true;

            foreach (string componentFolder in installedComponents)
            {
                string fullPath = Path.GetFullPath(componentFolder);

                //create new component and add it to the loaded components list
                this.F0_listBox_LoadingElements.Items.Add("Loading component: " + fullPath);

                try
                {
                      new Component(componentFolder); //the component will be added to the loaded components list in the constructor
                }
                catch (Exception ex)
                {
                    allComponentsLoaded = false;
                    Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_COMPONENT_ORIGIN_CODE, 8, componentFolder+"; "+ex.Message);
                    //event logged in the constructor
                    this.F0_listBox_LoadingElements.Items[this.F0_listBox_LoadingElements.Items.Count - 1] += (" X ERROR: " + ex.Message);
                    continue;
                }

                this.F0_listBox_LoadingElements.Items[this.F0_listBox_LoadingElements.Items.Count-1] += " | Loaded";

                this.F0_progressBar_IdeLoading.PerformStep();
            }

            if(allComponentsLoaded == false)
            {
                this.F0_listBox_LoadingElements.Items.Add("X ERROR:Could not load all installed components! See the diagnostic log for details.");
            }
            else
            {
                this.F0_listBox_LoadingElements.Items.Add("Loaded all components.");
            }

            //close form
            if (this.F0_progressBar_IdeLoading.Value == this.F0_progressBar_IdeLoading.Maximum)
            {

                this.F0_timer_LoadIdeDelayTimer.Interval = this.delayTimerIntervalMs;
                this.F0_timer_LoadIdeDelayTimer.Start();
            }
        }

        private void F0_timer_LoadIdeDelayTimer_Tick(object sender, EventArgs e)
        {
            //add loaded elements to the diagnostic service
            Program.D0.Invoke(Program.D0.Delegate_UpdateLoadedElementsDisplay);

            //open the F1 form
            this.F0_timer_CancelLoadTimer.Stop();
            this.F0_timer_LoadIdeDelayTimer.Stop();


            Program.F1 = new F1_Projects();

            this.Hide();
            Program.F1.Show();
        }

        private void F0_timer_CancelLoadTimer_Tick(object sender, EventArgs e)
        {
            //cancel program loading
            MessageBox.Show("Could not load elements", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Program.StopAll();
        }
    }
}

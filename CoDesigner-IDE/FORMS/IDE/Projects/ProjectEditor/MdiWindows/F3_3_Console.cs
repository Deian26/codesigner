using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines the console and its components. This form is mainly used as a way to display information; most / all data 
    /// displayed should be processed and stored in the F3 Main editor form that contains this form.
    /// 
    /// The console form class is a singleton.
    /// </summary>
    public partial class F3_3_Console : Form
    {
        #region singleton
        public static F3_3_Console instance = new F3_3_Console(); // create singleton instance

        /// <summary>
        /// Retrieves the singleton instance; the instance would also be transformed into an MDI window of the 
        /// provided 'containerEditorForm' object moved to that object
        /// </summary>
        /// <param name="containerEditorForm"> The containing F3_MainEditor instance </param>
        /// <returns></returns>
        public static F3_3_Console GetInstance(F3_MainEditor containerEditorForm)
        {
            // configure form settings
            F3_3_Console.instance.containerEditorForm = containerEditorForm;
            F3_3_Console.instance.MdiParent = containerEditorForm;
            F3_3_Console.instance.Dock = DockStyle.Bottom;
            F3_3_Console.instance.Visible = true;
            F3_3_Console.instance.Size = new Size(containerEditorForm.Width, (int)(containerEditorForm.Height * 0.25));
            return F3_3_Console.instance; //=> retrieve the singletin instance
        }

        /// <summary>
        /// Create the console
        /// </summary>
        private F3_3_Console()
        {
            InitializeComponent();

            // clear console
            this.F3_3_dataGridView_ConsoleNotifications.Rows.Clear();
            this.F3_3_richTextBox_ConsoleOutput.Clear();
        }
        #endregion

        private F3_MainEditor containerEditorForm = null; // the containing form (this form would usually be an MDI window)

        private void F3_3_Console_Load(object sender, EventArgs e)
        {

        }

        private void F3_3_dataGridView_ConsoleNotifications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region code-editting-output
        /// <summary>
        /// Logs a new notification in the console
        /// </summary>
        /// <param name="type"> Notification type </param>
        /// <param name="message"> Message to be displayed </param>
        /// <param name="location"> The location of the error/warning/info (if any); if the location is unknown or not applicable, 'null' should be passed to this parameter </param>
        public void LogConsoleNotification(ProjectManagement.ConsoleNotificationTypes type, string message, string location)
        {
            DataGridViewRow row = new DataGridViewRow();

            //=// Configure the new row
            row.ReadOnly = true;

            row.Cells["F3_3_dataGridView_ConsoleNotifications_Column_Type"].Value = ProjectManagement.ConsoleNotificationImages[(int)type];
            row.Cells["F3_3_dataGridView_ConsoleNotifications_Column_Message"].Value = message;
            row.Cells["F3_3_dataGridView_ConsoleNotifications_Column_Location"].Value = location;

            this.F3_3_dataGridView_ConsoleNotifications.Rows.Add(row); //=> add the new row
        }
        
        
        /// <summary>
        /// Prints the specified output on a new line in the output tab of the console
        /// </summary>
        /// <param name="output"> The text to be output </param>
        public void PrintOutputLine(string output)
        {
            this.F3_3_richTextBox_ConsoleOutput.Text += ("\n" + output);
        }
        #endregion
    }
}

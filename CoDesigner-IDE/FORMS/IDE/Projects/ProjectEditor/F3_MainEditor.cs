using CoDesigner_IDE.FORMS.IDE.Projects.ProjectEditor.MdiWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE.FORMS.IDE.Projects
{
    public partial class F3_MainEditor : Form
    {
        public Dictionary<string,F3_1_TextEditor> TextEditors = new Dictionary<string,F3_1_TextEditor>(); //=> this project's list of text editors
                                                                                                           //=> key = filepath
        public F3_2_ProjectStructureStatus f3_2_ProjectStructure { get; } = null; //=> project files

        public F3_3_Console f3_3_Console { get; } = null; //=> project console

        internal Project project { get;  } = null;
        public F3_MainEditor(Project project)
        {
            InitializeComponent();

            //=//Form settings
            this.WindowState = FormWindowState.Maximized;
            
            //==//Customize form based on the project details
            this.project = project;
            this.Text = this.project.Name;
            this.IsMdiContainer = true;

            //===// Project structure
            this.f3_2_ProjectStructure = new F3_2_ProjectStructureStatus(this);

            //===// Console
            this.f3_3_Console = F3_3_Console.GetInstance(this);
        }

        private void F3_MainEditor_Load(object sender, EventArgs e)
        {
            this.f3_2_ProjectStructure.SetSize(this);
        }

        private void F3_MainEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //stop program
            Program.StopAll();
        }

        /// <summary>
        /// Create a new text editor instance for the given file
        /// </summary>
        /// <param name="filePath"> Assumes to be a correct filepath </param>
        /// <param name="fileName"> File name to be displayed </param>
        public void CreateTextEditor(string filePath, string fileName)
        {
            if (this.TextEditors.ContainsKey(filePath) == false)
            {
                this.TextEditors.Add(filePath, new F3_1_TextEditor(this, filePath, fileName));
                this.TextEditors[filePath].MdiParent = this;
                this.TextEditors[filePath].StartPosition = FormStartPosition.CenterParent;
                this.TextEditors[filePath].Show();
            }
            else
            {
                this.TextEditors[filePath].BringToFront(); //=> evidentiate the already existing text editor for this file

            }
        }
    
    }
}

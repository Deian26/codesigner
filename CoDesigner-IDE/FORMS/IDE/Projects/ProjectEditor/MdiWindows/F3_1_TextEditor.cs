using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE.FORMS.IDE.Projects
{
    public partial class F3_1_TextEditor : Form
    {
        private F3_MainEditor containerEditorForm { get; } = null;
        private U1_CodeEditor u1_CodeEditor { get; } = null; //=> custom control used for code editting
        private string filePath { get; } = null;
        private string fileName { get; } = null;
        private string fileExtension { get; } = null;
        private bool src { get; } = false; //=> true if the current file is a source file for the current project
        private bool exec {  get; } = false; //=> true of the current file is an executable file for the current project
        private dynamic component { get; } //=> the component to be used for interpreting the text from this form

        public F3_1_TextEditor(F3_MainEditor containerEditorForm, string filePath, string fileName)
        {
            InitializeComponent();

            this.u1_CodeEditor = new U1_CodeEditor(this);

            //==// Code editor control
            u1_CodeEditor.Parent = this.F3_1_panel_CodeEditorContainer;
            u1_CodeEditor.Dock = DockStyle.Fill;

            //=// Set form details
            Bitmap bitmapFile = new Bitmap(GeneralPaths.ProjectStructure.TEXT_EDITOR_ICON_FILEPATH);
            this.Icon = Icon.FromHandle(bitmapFile.GetHicon());
            bitmapFile.Dispose();
            
            this.containerEditorForm = containerEditorForm;
            this.Text = this.fileName = fileName;
            this.filePath = filePath;

            string[] fileNameSegments;
            fileNameSegments = filePath.Split('.');

            this.fileExtension = "."+fileNameSegments[fileNameSegments.Length-1];
            this.F3_1_toolStripStatusLabel_TextEditorStatus_Interpretation.Text = this.containerEditorForm.project.Component.Name; //=> component (likely a programming language) language name

            //=// Init status values
            this.F3_1_toolStripStatusLabel_TextEditorStatus_WordCountNr.Text = "0";
            this.F3_1_toolStripStatusLabel_TextEditorStatus_ErrorsNr.Text = "0";
            this.F3_1_toolStripStatusLabel_TextEditorStatus_WarningsNr.Text = "0";

            //=// Load images
            this.F3_1_toolStripButton_Exec_Build.Image = ProjectManagement.TextEditorImages[(int)ProjectManagement.TextEditorIconTypes.BUILD];
            this.F3_1_toolStripButton_Exec_Run.Image = ProjectManagement.TextEditorImages[(int)ProjectManagement.TextEditorIconTypes.RUN];
            this.F3_1_toolStripButton_Save.Image = ProjectManagement.TextEditorImages[(int)ProjectManagement.TextEditorIconTypes.SAVE];
            this.F3_1_toolStripButton_LoadFile.Image = ProjectManagement.TextEditorImages[(int)ProjectManagement.TextEditorIconTypes.LOAD];
            this.F3_1_toolStripButton_Info.Image = ProjectManagement.TextEditorImages[(int)ProjectManagement.TextEditorIconTypes.INFO];

            //=// Determine if the type of this file is supported by a component
            //==// src
            if (this.containerEditorForm.project.Component.SrcExtensions.Contains(this.fileExtension))
            {
                this.src = true; //=> the available tools differ if this file is a source file for the current project

                // link to the base analyzer
                this.component = this.containerEditorForm.project.Component.componentInstance;

                // interpret file contents
                this.analyzeCode();
            }
            else // hide source file tools
            {
                //=//=/ Source code and execution tools /=//==//

                //=/ |> Errors
                this.F3_1_toolStripStatusLabel_TextEditorStatus_ErrorsNr.Enabled = false; 
                this.F3_1_toolStripStatusLabel_TextEditorStatus_ErrorsNr.Visible = false;
                
                //=/ !! Warnings
                this.F3_1_toolStripStatusLabel_TextEditorStatus_WarningsNr.Enabled = false;
                this.F3_1_toolStripStatusLabel_TextEditorStatus_WarningsNr.Visible = false;

                //=/ ::: Refactor
                //TODO: Implement refactoring interfaces / connections to the programming language methods or implement default IDE ones

                //=/ >=> Build
                this.F3_1_toolStripButton_Exec_Build.Enabled = false;
                this.F3_1_toolStripButton_Exec_Build.Visible = false;

                this.F3_1_toolStripProgressBar_CompilationStatus.Enabled = false;
                this.F3_1_toolStripProgressBar_CompilationStatus.Visible = false;

                //=/ |> Run
                this.F3_1_toolStripButton_Exec_Run.Enabled = false;
                this.F3_1_toolStripButton_Exec_Run.Visible = false;
            }

            //==// exec
            if (this.containerEditorForm.project.Component.ExecutableFileFormats.Contains(this.fileExtension))
            {
                this.exec = true;
            }
            else //=> hide executable tools
            {
                //TODO: Design bitmap images for exec tools, instantiate and assign them to the exec tool buttons (toolstrip)
                //TODO: Implement executable toolstrip


            }

            //TODO: Implement translations
            //TODO: Implement themes
        }

        private void F3_1_TextEditor_Load(object sender, EventArgs e)
        {

        }

        private void F3_1_TextEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.containerEditorForm.TextEditors.Remove(this.filePath); //=> remove the current editor from the list of active editors
            this.Dispose(); //=> destroy object
        }
        
        private void F3_1_richTextBox_TextEditor_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        #region utility
        /// <summary>
        /// The action delegate passed to the task(s) used to count the words in the current text editor
        /// </summary>
        private void countWords()
        {
            int wordCount = 0;
            char[] text;
            char[] whitespaces;
            List<string> lineNrStr = new List<string>();
            
            text = this.u1_CodeEditor.GetCodeTextEditor().Text.ToCharArray();
            whitespaces = this.containerEditorForm.project.Component.componentInstance.whitespace;

            for (int i = 0; i < text.Length; i++)
            {
                if (whitespaces.Contains(text[i])) //=> the current character is a whitespace for this component
                {
                    if (text[i] == '\n') lineNrStr.Add((lineNrStr.Count+1).ToString()); //=> new code line
                    text[i] = ' '; //=> replace the character with ' '
                }
            }
            String textStr;
            textStr = new string(text);

            wordCount = textStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length; //=> count words
            this.F3_1_statusStrip_TextEditorStatus.Items["F3_1_toolStripStatusLabel_TextEditorStatus_WordCountNr"].Text = $"{wordCount.ToString()}"; //=> update wordcount

        }

        /// <summary>
        /// Calls the base analyzer method implemented by the component.
        /// The method is implemented in the programming language's component class.
        /// </summary>
        private void analyzeCode()
        {
            this.component.Analyze(
                this.u1_CodeEditor.GetCodeTextEditor()
                );
        }

        /// <summary>
        /// Saves the current contents of the text editor to the associated file.
        /// </summary>
        private void saveFile()
        {
            //TODO: Implement text file saving
        }

        #endregion

        /// <summary>
        /// Callback for events in which the code is changed
        /// </summary>
        public void CodeUpdated()
        {
            // Computes the wordcount.
            // Done in parallel with the applicationThread part of the IDE.
            Parallel.Invoke(new Action(countWords));
        }

        private void F3_1_toolStrip_TextEditor_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void F3_1_toolStripButton_TextEditor_Exec_Build_Click(object sender, EventArgs e)
        {
            //=// Build code
            this.component.Build();
        }

        private void F3_1_toolStripButton_Save_Click(object sender, EventArgs e)
        {
            this.saveFile();
        }

        private void F3_1_toolStripButton_LoadFile_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = this.F3_1_openFileDialog_LoadFile.ShowDialog();
            
            if(openFileResult == DialogResult.OK) //=> open the selected file
            {
                string filePath = this.F3_1_openFileDialog_LoadFile.FileName;

                this.u1_CodeEditor.GetCodeTextEditor().Text = File.ReadAllText(filePath); //=> load the text into the editor
                
            }
        }

        private void F3_1_toolStripButton_Info_Click(object sender, EventArgs e)
        {
            //=// Display information about the code
            //TODO: Implement code info
        }

        private void F3_1_TextEditor_SizeChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
  
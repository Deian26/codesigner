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

namespace CoDesigner_IDE.FORMS.IDE.Projects
{
    /// <summary>
    /// Handles the user interaction with the project's files
    /// </summary>
    public partial class F3_2_ProjectStructureStatus : Form
    {
        private Project project { get; } = null;
        private F3_MainEditor f3_MainEditor_containerForm { get; } = null;
        private int projectFileNumber = 0; // the number of current fles in the project
        private float projectKiByteSize { get; set; } = 0; // the size of the project's directory, in KibiBytes (1 KiB = 1024 Bytes)
        private bool projectStructureEnableDoubleClickToggle = true; // if true, nodes can be expanded/collapsed by double clicking
        private int projectStructureEnableDoubleClickToggleCooldownTime = 1000; // cooldown time in ms

        #region utility
        /// <summary>
        /// Creates or updates the tree structure associated with the given project path, based on the files located on the disk
        /// </summary>
        /// <param name="directoryPath"> Path to the directory to be parsed (where the project fle is located) </param>
        private void updateStructure(TreeNode crtNode, string directoryPath)
        {
            List<string> directories = Directory.EnumerateDirectories(directoryPath).ToList(); //=> get sub-directories    
            List<string> files = Directory.EnumerateFiles(directoryPath).ToList(); //=> get files

            //=// Parse sub-directories, add them to the structure and search for files and sub-directories
            foreach (string directory in directories)
            {
                string[] path;
                path = directory.Split(Path.DirectorySeparatorChar);

                crtNode.Nodes.Add(
                    Path.Combine(directoryPath, directory),
                    path[path.Length - 1],
                    ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_DIRECTORY_UNSEL_IMGKEY,  //=> unselected image
                    ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_DIRECTORY_SEL_IMGKEY //=> selected image
                    );
                // parse sub-directory
                this.updateStructure(crtNode.Nodes[crtNode.Nodes.Count - 1], Path.Combine(directoryPath, directory));
            }

            //=// Add files to the structure directly
            if (directoryPath == this.project.Location) files.Remove(this.project.ProjectFilePath); // skip the project file

            this.projectFileNumber += files.Count; //=> update file number

            foreach (string file in files)
            {
                string[] path;
                path = file.Split(Path.DirectorySeparatorChar);

                crtNode.Nodes.Add(
                    Path.Combine(directoryPath, file), //=> key = full filepath
                    path[path.Length - 1], //=> value = filename
                    ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_GENERAL_FILE_UNSEL_IMGKEY, //=> unselected image
                    ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_GENERAL_FILE_SEL_IMGKEY //=> selected image
                    );

                this.projectKiByteSize += ((new FileInfo(file).Length) / 1024); //=> update project size
            }
        }

        /// <summary>
        /// Opens an editor for the specified file
        /// </summary>
        /// <param name="node"></param>
        private void openEditor(TreeNode node)
        {
            if (node.IsSelected == true && node.Nodes.Count == 0 && node.SelectedImageKey == ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_GENERAL_FILE_SEL_IMGKEY)
            {
                // file => open it in a new editor
                string[] fileNameSegments;
                fileNameSegments = node.Text.Split(',');

                switch (fileNameSegments[fileNameSegments.Length - 1]) // get extension
                {
                    case ProjectManagement.DefaultSupportedFileTypes.SIM:
                        {
                            //TODO: Implement loading simulations from files
                            break;
                        }
                    case ProjectManagement.DefaultSupportedFileTypes.TABLE: //=> custom table file format
                        {
                            //TODO: Implement table editor
                            break;
                        }

                    default: // try to open the file as a text file
                        {
                            this.f3_MainEditor_containerForm.CreateTextEditor(node.Name, node.Text);
                            break;
                        }
                }
            }
        }

        #endregion
        public F3_2_ProjectStructureStatus(F3_MainEditor containerEditorForm)
        {
            InitializeComponent();

            //=// Store current project info
            this.f3_MainEditor_containerForm = containerEditorForm;
            this.MdiParent = containerEditorForm;
            this.Visible = true;
            this.Text = containerEditorForm.Text;
            if (containerEditorForm.project is Project == false) //=> invalid project
            { // log error
                Diagnostics.LogEvent(Diagnostics.DefaultEventCodes.ERROR_CREATING_NEW_PROJECT);
                return;
            }

            this.project = containerEditorForm.project;

            //=// Display project structure 
            this.F3_2_treeView_ProjectStructure.ImageList = ProjectManagement.ProjectStructureImages;
            this.F3_2_treeView_ProjectStructure.Nodes.Add(
                this.project.Location, //=> key = project location
                this.project.Name,//=> value = project name
                ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_PROJECT_UNSEL_IMGKEY, //==> unselected image
                ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_PROJECT_SEL_IMGKEY //=> selected image
                );

            this.projectKiByteSize = 0;
            this.projectFileNumber = 0; // since the project directory is already parsed to construct the tree view, the files will be counted there

            this.updateStructure(this.F3_2_treeView_ProjectStructure.Nodes[0], containerEditorForm.project.Location);

            //=// Display general project details
            char multipleFilesPluralChar;

            if (this.projectFileNumber > 1) multipleFilesPluralChar = 's';
            else multipleFilesPluralChar = '\0';

            this.F3_2_toolStripLabel_ProjectStructureFileNumber.Text = $"{this.projectFileNumber.ToString()} File{multipleFilesPluralChar}";
            this.F3_2_toolStripLabel_ProjectSize.Text = $"{this.projectKiByteSize.ToString()} KiB";

        }

        /// <summary>
        /// Sets the size of this form
        /// </summary>
        /// <param name="containerEditorForm"> Container form </param>
        public void SetSize(F3_MainEditor containerEditorForm)
        {
            //=// Configure form size
            if (containerEditorForm != null)
            {
                this.Size = this.MinimumSize = new Size(containerEditorForm.Width / 4, (int)(containerEditorForm.Height * 0.70));
                this.Height = (int)(containerEditorForm.Height * 0.70);
            }
        }

        private void F3_2_ProjectStructureStatus_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Display project item details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F3_2_treeView_ProjectStructure_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ProjectItemInfo projectItemInfo = this.displayItemInfo(e.Node);

            //=// Configure context menu for this item, if it is a file
            if (e.Button == MouseButtons.Right)
            {
                this.F3_2_treeView_ProjectStructure.SelectedNode = e.Node; //=> select the node
                if (projectItemInfo != null) //=> file
                {
                    this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Items["F3_2_editToolStripMenuItem_ProjectStructureItem_Execute"].Enabled = projectItemInfo.execFile;
                    this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Items["F3_2_editToolStripMenuItem_ProjectStructureItem_Edit"].Enabled = true;
                }
                else
                {
                    this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Items["F3_2_editToolStripMenuItem_ProjectStructureItem_Execute"].Enabled = false;
                    this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Items["F3_2_editToolStripMenuItem_ProjectStructureItem_Edit"].Enabled = false;
                }
            }
        }


        /// <summary>
        /// Display information about the selected item
        /// </summary>
        /// <param name="node"> Item node </param>
        /// <returns> The info about the item, regarding its appartenance to the current project, if it is a file; if the item is not a file, this method will return 'null' </returns>
        private ProjectItemInfo displayItemInfo(TreeNode node)
        {
            string details, itemPath;
            string[] path;
            ProjectItemInfo projectItemInfo;
            
            projectItemInfo = null;
            itemPath = node.Name;
            details = "";
            path = itemPath.Split(Path.DirectorySeparatorChar);

            this.Text = path[path.Length - 1];

            if (File.Exists(itemPath) == true) //=> file
            {
                FileInfo fileInfo = new FileInfo(itemPath);
                details += "File\n//=//\n\n";
                details += $"FileNameAndExt: {fileInfo.Name}\n";
                details += $"Full path: {fileInfo.FullName}\n";
                details += $"Size: {fileInfo.Length / 1024} KiB\n";
                details += $"Creation time: {fileInfo.CreationTimeUtc} (UTC)\n";
                details += $"Last access time: {fileInfo.LastAccessTimeUtc} (UTC)\n";
                details += $"Last write time: {fileInfo.LastWriteTimeUtc} (UTC)\n";
                details += $"Is executable for this project: {this.f3_MainEditor_containerForm.project.Component.ExecutableFileFormats.Contains(fileInfo.Extension)}";
                
                projectItemInfo = new ProjectItemInfo(node.Text, node.Name, this.project); //=> compile project item summary

            }
            else if (Directory.Exists(itemPath) == true) //=> directory
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(itemPath);

                if(node.ImageKey == ProjectManagement.ProjectStructureImageKeys.PROJECT_STRUCTURE_PROJECT_UNSEL_IMGKEY) details += "Project directory\n//=============//\n\n"; //=> project directory
                else details += "Directory\n//=====//\n\n"; //=> internal directory
                details += $"FileNameAndExt: {directoryInfo.Name}\n";
                details += $"Full path: {directoryInfo.FullName}\n";
                details += $"Creation time: {directoryInfo.CreationTimeUtc} (UTC)\n";
                details += $"Last access time: {directoryInfo.LastAccessTimeUtc} (UTC)\n";
                details += $"Last write time: {directoryInfo.LastWriteTimeUtc} (UTC)\n";

            }
            else //=> unsupported item type or invalid path
            {
                Diagnostics.LogEvent(Diagnostics.DefaultEventCodes.INVALID_PROJ_ITEMPATH_OR_UNSUPPORTED_ITEM, itemPath);
                this.F3_2_richTextBox_ProjectItemDetails.Text = Prompts.Messages[Prompts.PromptMessageCodes.INVALID_PROJ_ITEMPATH_OR_TYPE].Text;
            }

            this.F3_2_richTextBox_ProjectItemDetails.Text = details;

            return projectItemInfo;
        }

        /// <summary>
        /// If this is a file, open it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F3_2_treeView_ProjectStructure_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // open editor
            if(e.Node != null)
            {
                this.openEditor(e.Node);
            }
        }

        /// <summary>
        /// Edit source file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F3_2_editToolStripMenuItem_ProjectStructureItem_Edit_Click(object sender, EventArgs e)
        {
            if(this.F3_2_treeView_ProjectStructure.SelectedNode != null)
                this.openEditor(this.F3_2_treeView_ProjectStructure.SelectedNode);
        }


    }

}

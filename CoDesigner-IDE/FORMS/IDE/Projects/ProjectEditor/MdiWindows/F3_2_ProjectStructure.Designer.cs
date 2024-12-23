namespace CoDesigner_IDE.FORMS.IDE.Projects
{
    partial class F3_2_ProjectStructureStatus
    {
        /// <summary>
        /// Required designer Variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.F3_2_toolStrip_ProjectStructureDetails = new System.Windows.Forms.ToolStrip();
            this.F3_2_toolStripLabel_ProjectStructureFileNumber = new System.Windows.Forms.ToolStripLabel();
            this.F3_2_toolStripSeparator_ProjectStructureStatus_1 = new System.Windows.Forms.ToolStripSeparator();
            this.F3_2_toolStripLabel_ProjectSize = new System.Windows.Forms.ToolStripLabel();
            this.F3_2_treeView_ProjectStructure = new System.Windows.Forms.TreeView();
            this.F3_2_richTextBox_ProjectItemDetails = new System.Windows.Forms.RichTextBox();
            this.F3_2_splitContainer_ProjectStructure = new System.Windows.Forms.SplitContainer();
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Execute = new System.Windows.Forms.ToolStripMenuItem();
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.F3_2_toolStrip_ProjectStructureDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F3_2_splitContainer_ProjectStructure)).BeginInit();
            this.F3_2_splitContainer_ProjectStructure.Panel1.SuspendLayout();
            this.F3_2_splitContainer_ProjectStructure.Panel2.SuspendLayout();
            this.F3_2_splitContainer_ProjectStructure.SuspendLayout();
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // F3_2_toolStrip_ProjectStructureDetails
            // 
            this.F3_2_toolStrip_ProjectStructureDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.F3_2_toolStrip_ProjectStructureDetails.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_2_toolStrip_ProjectStructureDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.F3_2_toolStrip_ProjectStructureDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.F3_2_toolStripLabel_ProjectStructureFileNumber,
            this.F3_2_toolStripSeparator_ProjectStructureStatus_1,
            this.F3_2_toolStripLabel_ProjectSize});
            this.F3_2_toolStrip_ProjectStructureDetails.Location = new System.Drawing.Point(0, 453);
            this.F3_2_toolStrip_ProjectStructureDetails.Name = "F3_2_toolStrip_ProjectStructureDetails";
            this.F3_2_toolStrip_ProjectStructureDetails.Size = new System.Drawing.Size(800, 25);
            this.F3_2_toolStrip_ProjectStructureDetails.TabIndex = 0;
            // 
            // F3_2_toolStripLabel_ProjectStructureFileNumber
            // 
            this.F3_2_toolStripLabel_ProjectStructureFileNumber.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_2_toolStripLabel_ProjectStructureFileNumber.Name = "F3_2_toolStripLabel_ProjectStructureFileNumber";
            this.F3_2_toolStripLabel_ProjectStructureFileNumber.Size = new System.Drawing.Size(90, 22);
            this.F3_2_toolStripLabel_ProjectStructureFileNumber.Text = "%FILE-NR%";
            // 
            // F3_2_toolStripSeparator_ProjectStructureStatus_1
            // 
            this.F3_2_toolStripSeparator_ProjectStructureStatus_1.Name = "F3_2_toolStripSeparator_ProjectStructureStatus_1";
            this.F3_2_toolStripSeparator_ProjectStructureStatus_1.Size = new System.Drawing.Size(6, 25);
            // 
            // F3_2_toolStripLabel_ProjectSize
            // 
            this.F3_2_toolStripLabel_ProjectSize.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_2_toolStripLabel_ProjectSize.Name = "F3_2_toolStripLabel_ProjectSize";
            this.F3_2_toolStripLabel_ProjectSize.Size = new System.Drawing.Size(108, 22);
            this.F3_2_toolStripLabel_ProjectSize.Text = "%PROJ-SIZE%";
            // 
            // F3_2_treeView_ProjectStructure
            // 
            this.F3_2_treeView_ProjectStructure.ContextMenuStrip = this.F3_2_contextMenuStrip_ProjectStructureContextMenu;
            this.F3_2_treeView_ProjectStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F3_2_treeView_ProjectStructure.Location = new System.Drawing.Point(0, 0);
            this.F3_2_treeView_ProjectStructure.Name = "F3_2_treeView_ProjectStructure";
            this.F3_2_treeView_ProjectStructure.Size = new System.Drawing.Size(800, 310);
            this.F3_2_treeView_ProjectStructure.TabIndex = 1;
            this.F3_2_treeView_ProjectStructure.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.F3_2_treeView_ProjectStructure_NodeMouseClick);
            this.F3_2_treeView_ProjectStructure.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.F3_2_treeView_ProjectStructure_NodeMouseDoubleClick);
            // 
            // F3_2_richTextBox_ProjectItemDetails
            // 
            this.F3_2_richTextBox_ProjectItemDetails.DetectUrls = false;
            this.F3_2_richTextBox_ProjectItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F3_2_richTextBox_ProjectItemDetails.Location = new System.Drawing.Point(0, 0);
            this.F3_2_richTextBox_ProjectItemDetails.Name = "F3_2_richTextBox_ProjectItemDetails";
            this.F3_2_richTextBox_ProjectItemDetails.ReadOnly = true;
            this.F3_2_richTextBox_ProjectItemDetails.Size = new System.Drawing.Size(800, 164);
            this.F3_2_richTextBox_ProjectItemDetails.TabIndex = 2;
            this.F3_2_richTextBox_ProjectItemDetails.Text = "";
            this.F3_2_richTextBox_ProjectItemDetails.WordWrap = false;
            // 
            // F3_2_splitContainer_ProjectStructure
            // 
            this.F3_2_splitContainer_ProjectStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F3_2_splitContainer_ProjectStructure.Location = new System.Drawing.Point(0, 0);
            this.F3_2_splitContainer_ProjectStructure.Name = "F3_2_splitContainer_ProjectStructure";
            this.F3_2_splitContainer_ProjectStructure.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // F3_2_splitContainer_ProjectStructure.Panel1
            // 
            this.F3_2_splitContainer_ProjectStructure.Panel1.Controls.Add(this.F3_2_treeView_ProjectStructure);
            // 
            // F3_2_splitContainer_ProjectStructure.Panel2
            // 
            this.F3_2_splitContainer_ProjectStructure.Panel2.Controls.Add(this.F3_2_richTextBox_ProjectItemDetails);
            this.F3_2_splitContainer_ProjectStructure.Size = new System.Drawing.Size(800, 478);
            this.F3_2_splitContainer_ProjectStructure.SplitterDistance = 310;
            this.F3_2_splitContainer_ProjectStructure.TabIndex = 3;
            // 
            // F3_2_contextMenuStrip_ProjectStructureContextMenu
            // 
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit,
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Execute,
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Delete});
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Name = "F3_2_contextMenuStrip_ProjectStructureContextMenu";
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.Size = new System.Drawing.Size(142, 76);
            // 
            // F3_2_editToolStripMenuItem_ProjectStructureItem_Edit
            // 
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Name = "F3_2_editToolStripMenuItem_ProjectStructureItem_Edit";
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Size = new System.Drawing.Size(210, 24);
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Text = "Edit";
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Click += new System.EventHandler(this.F3_2_editToolStripMenuItem_ProjectStructureItem_Edit_Click);
            // 
            // F3_2_editToolStripMenuItem_ProjectStructureItem_Execute
            // 
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Execute.Name = "F3_2_editToolStripMenuItem_ProjectStructureItem_Execute";
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Execute.Size = new System.Drawing.Size(210, 24);
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Execute.Text = "Execute";
            // 
            // F3_2_editToolStripMenuItem_ProjectStructureItem_Delete
            // 
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Delete.Name = "F3_2_editToolStripMenuItem_ProjectStructureItem_Delete";
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Delete.Size = new System.Drawing.Size(210, 24);
            this.F3_2_editToolStripMenuItem_ProjectStructureItem_Delete.Text = "Delete";
            // 
            // F3_2_ProjectStructureStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.F3_2_toolStrip_ProjectStructureDetails);
            this.Controls.Add(this.F3_2_splitContainer_ProjectStructure);
            this.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "F3_2_ProjectStructureStatus";
            this.ShowIcon = false;
            this.Text = "$PROJECT-STRUCTURE$";
            this.Load += new System.EventHandler(this.F3_2_ProjectStructureStatus_Load);
            this.F3_2_toolStrip_ProjectStructureDetails.ResumeLayout(false);
            this.F3_2_toolStrip_ProjectStructureDetails.PerformLayout();
            this.F3_2_splitContainer_ProjectStructure.Panel1.ResumeLayout(false);
            this.F3_2_splitContainer_ProjectStructure.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.F3_2_splitContainer_ProjectStructure)).EndInit();
            this.F3_2_splitContainer_ProjectStructure.ResumeLayout(false);
            this.F3_2_contextMenuStrip_ProjectStructureContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip F3_2_toolStrip_ProjectStructureDetails;
        private System.Windows.Forms.ToolStripLabel F3_2_toolStripLabel_ProjectStructureFileNumber;
        private System.Windows.Forms.ToolStripSeparator F3_2_toolStripSeparator_ProjectStructureStatus_1;
        private System.Windows.Forms.TreeView F3_2_treeView_ProjectStructure;
        private System.Windows.Forms.ToolStripLabel F3_2_toolStripLabel_ProjectSize;
        private System.Windows.Forms.RichTextBox F3_2_richTextBox_ProjectItemDetails;
        private System.Windows.Forms.SplitContainer F3_2_splitContainer_ProjectStructure;
        private System.Windows.Forms.ContextMenuStrip F3_2_contextMenuStrip_ProjectStructureContextMenu;
        private System.Windows.Forms.ToolStripMenuItem F3_2_editToolStripMenuItem_ProjectStructureItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem F3_2_editToolStripMenuItem_ProjectStructureItem_Execute;
        private System.Windows.Forms.ToolStripMenuItem F3_2_editToolStripMenuItem_ProjectStructureItem_Delete;
    }
}
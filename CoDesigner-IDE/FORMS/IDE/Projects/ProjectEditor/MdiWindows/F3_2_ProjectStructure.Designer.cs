namespace CoDesigner_IDE
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
            components = new System.ComponentModel.Container();
            F3_2_toolStrip_ProjectStructureDetails = new System.Windows.Forms.ToolStrip();
            F3_2_toolStripLabel_ProjectStructureFileNumber = new System.Windows.Forms.ToolStripLabel();
            F3_2_toolStripSeparator_ProjectStructureStatus_1 = new System.Windows.Forms.ToolStripSeparator();
            F3_2_toolStripLabel_ProjectSize = new System.Windows.Forms.ToolStripLabel();
            F3_2_treeView_ProjectStructure = new System.Windows.Forms.TreeView();
            F3_2_contextMenuStrip_ProjectStructureContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            F3_2_editToolStripMenuItem_ProjectStructureItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            F3_2_editToolStripMenuItem_ProjectStructureItem_Execute = new System.Windows.Forms.ToolStripMenuItem();
            F3_2_editToolStripMenuItem_ProjectStructureItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            F3_2_richTextBox_ProjectItemDetails = new System.Windows.Forms.RichTextBox();
            F3_2_splitContainer_ProjectStructure = new System.Windows.Forms.SplitContainer();
            F3_2_toolStrip_ProjectStructureDetails.SuspendLayout();
            F3_2_contextMenuStrip_ProjectStructureContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)F3_2_splitContainer_ProjectStructure).BeginInit();
            F3_2_splitContainer_ProjectStructure.Panel1.SuspendLayout();
            F3_2_splitContainer_ProjectStructure.Panel2.SuspendLayout();
            F3_2_splitContainer_ProjectStructure.SuspendLayout();
            SuspendLayout();
            // 
            // F3_2_toolStrip_ProjectStructureDetails
            // 
            F3_2_toolStrip_ProjectStructureDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            F3_2_toolStrip_ProjectStructureDetails.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            F3_2_toolStrip_ProjectStructureDetails.ImageScalingSize = new System.Drawing.Size(20, 20);
            F3_2_toolStrip_ProjectStructureDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { F3_2_toolStripLabel_ProjectStructureFileNumber, F3_2_toolStripSeparator_ProjectStructureStatus_1, F3_2_toolStripLabel_ProjectSize });
            F3_2_toolStrip_ProjectStructureDetails.Location = new System.Drawing.Point(0, 453);
            F3_2_toolStrip_ProjectStructureDetails.Name = "F3_2_toolStrip_ProjectStructureDetails";
            F3_2_toolStrip_ProjectStructureDetails.Size = new System.Drawing.Size(800, 25);
            F3_2_toolStrip_ProjectStructureDetails.TabIndex = 0;
            // 
            // F3_2_toolStripLabel_ProjectStructureFileNumber
            // 
            F3_2_toolStripLabel_ProjectStructureFileNumber.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            F3_2_toolStripLabel_ProjectStructureFileNumber.Name = "F3_2_toolStripLabel_ProjectStructureFileNumber";
            F3_2_toolStripLabel_ProjectStructureFileNumber.Size = new System.Drawing.Size(70, 22);
            F3_2_toolStripLabel_ProjectStructureFileNumber.Text = "%FILE-NR%";
            // 
            // F3_2_toolStripSeparator_ProjectStructureStatus_1
            // 
            F3_2_toolStripSeparator_ProjectStructureStatus_1.Name = "F3_2_toolStripSeparator_ProjectStructureStatus_1";
            F3_2_toolStripSeparator_ProjectStructureStatus_1.Size = new System.Drawing.Size(6, 25);
            // 
            // F3_2_toolStripLabel_ProjectSize
            // 
            F3_2_toolStripLabel_ProjectSize.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            F3_2_toolStripLabel_ProjectSize.Name = "F3_2_toolStripLabel_ProjectSize";
            F3_2_toolStripLabel_ProjectSize.Size = new System.Drawing.Size(84, 22);
            F3_2_toolStripLabel_ProjectSize.Text = "%PROJ-SIZE%";
            // 
            // F3_2_treeView_ProjectStructure
            // 
            F3_2_treeView_ProjectStructure.ContextMenuStrip = F3_2_contextMenuStrip_ProjectStructureContextMenu;
            F3_2_treeView_ProjectStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            F3_2_treeView_ProjectStructure.Location = new System.Drawing.Point(0, 0);
            F3_2_treeView_ProjectStructure.Name = "F3_2_treeView_ProjectStructure";
            F3_2_treeView_ProjectStructure.Size = new System.Drawing.Size(800, 310);
            F3_2_treeView_ProjectStructure.TabIndex = 1;
            F3_2_treeView_ProjectStructure.AfterSelect += F3_2_treeView_ProjectStructure_AfterSelect;
            F3_2_treeView_ProjectStructure.NodeMouseClick += F3_2_treeView_ProjectStructure_NodeMouseClick;
            F3_2_treeView_ProjectStructure.NodeMouseDoubleClick += F3_2_treeView_ProjectStructure_NodeMouseDoubleClick;
            // 
            // F3_2_contextMenuStrip_ProjectStructureContextMenu
            // 
            F3_2_contextMenuStrip_ProjectStructureContextMenu.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            F3_2_contextMenuStrip_ProjectStructureContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            F3_2_contextMenuStrip_ProjectStructureContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { F3_2_editToolStripMenuItem_ProjectStructureItem_Edit, F3_2_editToolStripMenuItem_ProjectStructureItem_Execute, F3_2_editToolStripMenuItem_ProjectStructureItem_Delete });
            F3_2_contextMenuStrip_ProjectStructureContextMenu.Name = "F3_2_contextMenuStrip_ProjectStructureContextMenu";
            F3_2_contextMenuStrip_ProjectStructureContextMenu.Size = new System.Drawing.Size(124, 70);
            // 
            // F3_2_editToolStripMenuItem_ProjectStructureItem_Edit
            // 
            F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Name = "F3_2_editToolStripMenuItem_ProjectStructureItem_Edit";
            F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Size = new System.Drawing.Size(123, 22);
            F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Text = "Edit";
            F3_2_editToolStripMenuItem_ProjectStructureItem_Edit.Click += F3_2_editToolStripMenuItem_ProjectStructureItem_Edit_Click;
            // 
            // F3_2_editToolStripMenuItem_ProjectStructureItem_Execute
            // 
            F3_2_editToolStripMenuItem_ProjectStructureItem_Execute.Name = "F3_2_editToolStripMenuItem_ProjectStructureItem_Execute";
            F3_2_editToolStripMenuItem_ProjectStructureItem_Execute.Size = new System.Drawing.Size(123, 22);
            F3_2_editToolStripMenuItem_ProjectStructureItem_Execute.Text = "Execute";
            // 
            // F3_2_editToolStripMenuItem_ProjectStructureItem_Delete
            // 
            F3_2_editToolStripMenuItem_ProjectStructureItem_Delete.Name = "F3_2_editToolStripMenuItem_ProjectStructureItem_Delete";
            F3_2_editToolStripMenuItem_ProjectStructureItem_Delete.Size = new System.Drawing.Size(123, 22);
            F3_2_editToolStripMenuItem_ProjectStructureItem_Delete.Text = "Delete";
            // 
            // F3_2_richTextBox_ProjectItemDetails
            // 
            F3_2_richTextBox_ProjectItemDetails.DetectUrls = false;
            F3_2_richTextBox_ProjectItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            F3_2_richTextBox_ProjectItemDetails.Location = new System.Drawing.Point(0, 0);
            F3_2_richTextBox_ProjectItemDetails.Name = "F3_2_richTextBox_ProjectItemDetails";
            F3_2_richTextBox_ProjectItemDetails.ReadOnly = true;
            F3_2_richTextBox_ProjectItemDetails.Size = new System.Drawing.Size(800, 164);
            F3_2_richTextBox_ProjectItemDetails.TabIndex = 2;
            F3_2_richTextBox_ProjectItemDetails.Text = "";
            F3_2_richTextBox_ProjectItemDetails.WordWrap = false;
            // 
            // F3_2_splitContainer_ProjectStructure
            // 
            F3_2_splitContainer_ProjectStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            F3_2_splitContainer_ProjectStructure.Location = new System.Drawing.Point(0, 0);
            F3_2_splitContainer_ProjectStructure.Name = "F3_2_splitContainer_ProjectStructure";
            F3_2_splitContainer_ProjectStructure.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // F3_2_splitContainer_ProjectStructure.Panel1
            // 
            F3_2_splitContainer_ProjectStructure.Panel1.Controls.Add(F3_2_treeView_ProjectStructure);
            // 
            // F3_2_splitContainer_ProjectStructure.Panel2
            // 
            F3_2_splitContainer_ProjectStructure.Panel2.Controls.Add(F3_2_richTextBox_ProjectItemDetails);
            F3_2_splitContainer_ProjectStructure.Size = new System.Drawing.Size(800, 478);
            F3_2_splitContainer_ProjectStructure.SplitterDistance = 310;
            F3_2_splitContainer_ProjectStructure.TabIndex = 3;
            // 
            // F3_2_ProjectStructureStatus
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(800, 478);
            Controls.Add(F3_2_toolStrip_ProjectStructureDetails);
            Controls.Add(F3_2_splitContainer_ProjectStructure);
            Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            Name = "F3_2_ProjectStructureStatus";
            ShowIcon = false;
            Text = "$PROJECT-STRUCTURE$";
            Load += F3_2_ProjectStructureStatus_Load;
            F3_2_toolStrip_ProjectStructureDetails.ResumeLayout(false);
            F3_2_toolStrip_ProjectStructureDetails.PerformLayout();
            F3_2_contextMenuStrip_ProjectStructureContextMenu.ResumeLayout(false);
            F3_2_splitContainer_ProjectStructure.Panel1.ResumeLayout(false);
            F3_2_splitContainer_ProjectStructure.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)F3_2_splitContainer_ProjectStructure).EndInit();
            F3_2_splitContainer_ProjectStructure.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
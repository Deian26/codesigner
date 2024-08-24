namespace CoDesigner_IDE
{
    partial class D0_MainDiagnosticsPanel
    {
        /// <summary>
        /// Required designer variable.
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
            this.D0_listBox_DiagnosticLog = new System.Windows.Forms.ListBox();
            this.D0_groupBox_DiagnosticLog = new System.Windows.Forms.GroupBox();
            this.D0_groupBox_Status = new System.Windows.Forms.GroupBox();
            this.D0_groupBox_Actions = new System.Windows.Forms.GroupBox();
            this.D0_groupBox_Elements = new System.Windows.Forms.GroupBox();
            this.D0_treeView_LoadedElements = new System.Windows.Forms.TreeView();
            this.D0_groupBox_DiagnosticLog.SuspendLayout();
            this.D0_groupBox_Elements.SuspendLayout();
            this.SuspendLayout();
            // 
            // D0_listBox_DiagnosticLog
            // 
            this.D0_listBox_DiagnosticLog.FormattingEnabled = true;
            this.D0_listBox_DiagnosticLog.ItemHeight = 15;
            this.D0_listBox_DiagnosticLog.Location = new System.Drawing.Point(6, 22);
            this.D0_listBox_DiagnosticLog.Name = "D0_listBox_DiagnosticLog";
            this.D0_listBox_DiagnosticLog.Size = new System.Drawing.Size(844, 439);
            this.D0_listBox_DiagnosticLog.TabIndex = 0;
            // 
            // D0_groupBox_DiagnosticLog
            // 
            this.D0_groupBox_DiagnosticLog.Controls.Add(this.D0_listBox_DiagnosticLog);
            this.D0_groupBox_DiagnosticLog.Location = new System.Drawing.Point(12, 247);
            this.D0_groupBox_DiagnosticLog.Name = "D0_groupBox_DiagnosticLog";
            this.D0_groupBox_DiagnosticLog.Size = new System.Drawing.Size(856, 470);
            this.D0_groupBox_DiagnosticLog.TabIndex = 1;
            this.D0_groupBox_DiagnosticLog.TabStop = false;
            this.D0_groupBox_DiagnosticLog.Text = "Log";
            // 
            // D0_groupBox_Status
            // 
            this.D0_groupBox_Status.Location = new System.Drawing.Point(12, 12);
            this.D0_groupBox_Status.Name = "D0_groupBox_Status";
            this.D0_groupBox_Status.Size = new System.Drawing.Size(254, 229);
            this.D0_groupBox_Status.TabIndex = 2;
            this.D0_groupBox_Status.TabStop = false;
            this.D0_groupBox_Status.Text = "Status";
            // 
            // D0_groupBox_Actions
            // 
            this.D0_groupBox_Actions.Location = new System.Drawing.Point(272, 12);
            this.D0_groupBox_Actions.Name = "D0_groupBox_Actions";
            this.D0_groupBox_Actions.Size = new System.Drawing.Size(596, 229);
            this.D0_groupBox_Actions.TabIndex = 3;
            this.D0_groupBox_Actions.TabStop = false;
            this.D0_groupBox_Actions.Text = "Actions";
            // 
            // D0_groupBox_Elements
            // 
            this.D0_groupBox_Elements.Controls.Add(this.D0_treeView_LoadedElements);
            this.D0_groupBox_Elements.Location = new System.Drawing.Point(877, 12);
            this.D0_groupBox_Elements.Name = "D0_groupBox_Elements";
            this.D0_groupBox_Elements.Size = new System.Drawing.Size(363, 705);
            this.D0_groupBox_Elements.TabIndex = 4;
            this.D0_groupBox_Elements.TabStop = false;
            this.D0_groupBox_Elements.Text = "Elements";
            // 
            // D0_treeView_LoadedElements
            // 
            this.D0_treeView_LoadedElements.Location = new System.Drawing.Point(6, 22);
            this.D0_treeView_LoadedElements.Name = "D0_treeView_LoadedElements";
            this.D0_treeView_LoadedElements.Size = new System.Drawing.Size(351, 674);
            this.D0_treeView_LoadedElements.TabIndex = 0;
            // 
            // D0_MainDiagnosticsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1522, 729);
            this.Controls.Add(this.D0_groupBox_Elements);
            this.Controls.Add(this.D0_groupBox_Actions);
            this.Controls.Add(this.D0_groupBox_Status);
            this.Controls.Add(this.D0_groupBox_DiagnosticLog);
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "D0_MainDiagnosticsPanel";
            this.Text = "Diagnostics";
            this.Load += new System.EventHandler(this.D0_MainDiagnosticsPanel_Load);
            this.D0_groupBox_DiagnosticLog.ResumeLayout(false);
            this.D0_groupBox_Elements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox D0_listBox_DiagnosticLog;
        private System.Windows.Forms.GroupBox D0_groupBox_DiagnosticLog;
        private System.Windows.Forms.GroupBox D0_groupBox_Status;
        private System.Windows.Forms.GroupBox D0_groupBox_Actions;
        private System.Windows.Forms.GroupBox D0_groupBox_Elements;
        private System.Windows.Forms.TreeView D0_treeView_LoadedElements;
    }
}
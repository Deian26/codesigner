namespace CoDesigner_IDE.FORMS.IDE.Projects.ProjectEditor.MdiWindows
{
    partial class F3_3_Console
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F3_3_Console));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.F3_3_tabControl_ConsoleTabs = new System.Windows.Forms.TabControl();
            this.F3_3_tabPage_Console_Notifications = new System.Windows.Forms.TabPage();
            this.F3_3_tabPage_Console_Output = new System.Windows.Forms.TabPage();
            this.F3_3_dataGridView_ConsoleNotifications = new System.Windows.Forms.DataGridView();
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type = new System.Windows.Forms.DataGridViewImageColumn();
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F3_3_richTextBox_ConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.F3_3_tabControl_ConsoleTabs.SuspendLayout();
            this.F3_3_tabPage_Console_Notifications.SuspendLayout();
            this.F3_3_tabPage_Console_Output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F3_3_dataGridView_ConsoleNotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // F3_3_tabControl_ConsoleTabs
            // 
            this.F3_3_tabControl_ConsoleTabs.Controls.Add(this.F3_3_tabPage_Console_Notifications);
            this.F3_3_tabControl_ConsoleTabs.Controls.Add(this.F3_3_tabPage_Console_Output);
            this.F3_3_tabControl_ConsoleTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F3_3_tabControl_ConsoleTabs.Location = new System.Drawing.Point(0, 0);
            this.F3_3_tabControl_ConsoleTabs.Name = "F3_3_tabControl_ConsoleTabs";
            this.F3_3_tabControl_ConsoleTabs.SelectedIndex = 0;
            this.F3_3_tabControl_ConsoleTabs.Size = new System.Drawing.Size(800, 450);
            this.F3_3_tabControl_ConsoleTabs.TabIndex = 0;
            // 
            // F3_3_tabPage_Console_Notifications
            // 
            this.F3_3_tabPage_Console_Notifications.Controls.Add(this.F3_3_dataGridView_ConsoleNotifications);
            this.F3_3_tabPage_Console_Notifications.Location = new System.Drawing.Point(4, 25);
            this.F3_3_tabPage_Console_Notifications.Name = "F3_3_tabPage_Console_Notifications";
            this.F3_3_tabPage_Console_Notifications.Padding = new System.Windows.Forms.Padding(3);
            this.F3_3_tabPage_Console_Notifications.Size = new System.Drawing.Size(792, 421);
            this.F3_3_tabPage_Console_Notifications.TabIndex = 0;
            this.F3_3_tabPage_Console_Notifications.Text = "%NOTIFICATIONS%";
            this.F3_3_tabPage_Console_Notifications.UseVisualStyleBackColor = true;
            // 
            // F3_3_tabPage_Console_Output
            // 
            this.F3_3_tabPage_Console_Output.Controls.Add(this.F3_3_richTextBox_ConsoleOutput);
            this.F3_3_tabPage_Console_Output.Location = new System.Drawing.Point(4, 25);
            this.F3_3_tabPage_Console_Output.Name = "F3_3_tabPage_Console_Output";
            this.F3_3_tabPage_Console_Output.Padding = new System.Windows.Forms.Padding(3);
            this.F3_3_tabPage_Console_Output.Size = new System.Drawing.Size(792, 421);
            this.F3_3_tabPage_Console_Output.TabIndex = 1;
            this.F3_3_tabPage_Console_Output.Text = "%OUTPUT%";
            this.F3_3_tabPage_Console_Output.UseVisualStyleBackColor = true;
            // 
            // F3_3_dataGridView_ConsoleNotifications
            // 
            this.F3_3_dataGridView_ConsoleNotifications.AllowUserToAddRows = false;
            this.F3_3_dataGridView_ConsoleNotifications.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_3_dataGridView_ConsoleNotifications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.F3_3_dataGridView_ConsoleNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.F3_3_dataGridView_ConsoleNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type,
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message,
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location});
            this.F3_3_dataGridView_ConsoleNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F3_3_dataGridView_ConsoleNotifications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.F3_3_dataGridView_ConsoleNotifications.Location = new System.Drawing.Point(3, 3);
            this.F3_3_dataGridView_ConsoleNotifications.Name = "F3_3_dataGridView_ConsoleNotifications";
            this.F3_3_dataGridView_ConsoleNotifications.ReadOnly = true;
            this.F3_3_dataGridView_ConsoleNotifications.RowHeadersWidth = 51;
            this.F3_3_dataGridView_ConsoleNotifications.RowTemplate.Height = 24;
            this.F3_3_dataGridView_ConsoleNotifications.ShowEditingIcon = false;
            this.F3_3_dataGridView_ConsoleNotifications.Size = new System.Drawing.Size(786, 415);
            this.F3_3_dataGridView_ConsoleNotifications.TabIndex = 0;
            this.F3_3_dataGridView_ConsoleNotifications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.F3_3_dataGridView_ConsoleNotifications_CellContentClick);
            // 
            // F3_3_dataGridView_ConsoleNotifications_Column_Type
            // 
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.DefaultCellStyle = dataGridViewCellStyle2;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.HeaderText = "Type";
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.MinimumWidth = 6;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.Name = "F3_3_dataGridView_ConsoleNotifications_Column_Type";
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.ReadOnly = true;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Type.Width = 45;
            // 
            // F3_3_dataGridView_ConsoleNotifications_Column_Message
            // 
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message.DefaultCellStyle = dataGridViewCellStyle3;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message.HeaderText = "Message";
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message.MinimumWidth = 6;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message.Name = "F3_3_dataGridView_ConsoleNotifications_Column_Message";
            this.F3_3_dataGridView_ConsoleNotifications_Column_Message.ReadOnly = true;
            // 
            // F3_3_dataGridView_ConsoleNotifications_Column_Location
            // 
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location.DefaultCellStyle = dataGridViewCellStyle4;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location.HeaderText = "Location";
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location.MinimumWidth = 6;
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location.Name = "F3_3_dataGridView_ConsoleNotifications_Column_Location";
            this.F3_3_dataGridView_ConsoleNotifications_Column_Location.ReadOnly = true;
            // 
            // F3_3_richTextBox_ConsoleOutput
            // 
            this.F3_3_richTextBox_ConsoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F3_3_richTextBox_ConsoleOutput.Location = new System.Drawing.Point(3, 3);
            this.F3_3_richTextBox_ConsoleOutput.Name = "F3_3_richTextBox_ConsoleOutput";
            this.F3_3_richTextBox_ConsoleOutput.Size = new System.Drawing.Size(786, 415);
            this.F3_3_richTextBox_ConsoleOutput.TabIndex = 0;
            this.F3_3_richTextBox_ConsoleOutput.Text = "";
            // 
            // F3_3_Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.F3_3_tabControl_ConsoleTabs);
            this.Name = "F3_3_Console";
            this.Text = "%CONSOLE%";
            this.Load += new System.EventHandler(this.F3_3_Console_Load);
            this.F3_3_tabControl_ConsoleTabs.ResumeLayout(false);
            this.F3_3_tabPage_Console_Notifications.ResumeLayout(false);
            this.F3_3_tabPage_Console_Output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.F3_3_dataGridView_ConsoleNotifications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl F3_3_tabControl_ConsoleTabs;
        private System.Windows.Forms.TabPage F3_3_tabPage_Console_Notifications;
        private System.Windows.Forms.TabPage F3_3_tabPage_Console_Output;
        private System.Windows.Forms.DataGridView F3_3_dataGridView_ConsoleNotifications;
        private System.Windows.Forms.DataGridViewImageColumn F3_3_dataGridView_ConsoleNotifications_Column_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn F3_3_dataGridView_ConsoleNotifications_Column_Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn F3_3_dataGridView_ConsoleNotifications_Column_Location;
        private System.Windows.Forms.RichTextBox F3_3_richTextBox_ConsoleOutput;
    }
}
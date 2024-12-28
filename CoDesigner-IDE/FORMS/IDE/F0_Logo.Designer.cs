namespace CoDesigner_IDE
{
    partial class F0_Logo
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
            F0_progressBar_IdeLoading = new System.Windows.Forms.ProgressBar();
            F0_timer_LoadIdeDelayTimer = new System.Windows.Forms.Timer(components);
            F0_timer_CancelLoadTimer = new System.Windows.Forms.Timer(components);
            F0_listBox_LoadingElements = new System.Windows.Forms.ListBox();
            F0_label_LoadingElements = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // F0_progressBar_IdeLoading
            // 
            F0_progressBar_IdeLoading.Location = new System.Drawing.Point(12, 382);
            F0_progressBar_IdeLoading.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            F0_progressBar_IdeLoading.Name = "F0_progressBar_IdeLoading";
            F0_progressBar_IdeLoading.Size = new System.Drawing.Size(776, 27);
            F0_progressBar_IdeLoading.TabIndex = 0;
            // 
            // F0_timer_LoadIdeDelayTimer
            // 
            F0_timer_LoadIdeDelayTimer.Tick += F0_timer_LoadIdeDelayTimer_Tick;
            // 
            // F0_timer_CancelLoadTimer
            // 
            F0_timer_CancelLoadTimer.Tick += F0_timer_CancelLoadTimer_Tick;
            // 
            // F0_listBox_LoadingElements
            // 
            F0_listBox_LoadingElements.FormattingEnabled = true;
            F0_listBox_LoadingElements.ItemHeight = 17;
            F0_listBox_LoadingElements.Location = new System.Drawing.Point(12, 57);
            F0_listBox_LoadingElements.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            F0_listBox_LoadingElements.Name = "F0_listBox_LoadingElements";
            F0_listBox_LoadingElements.Size = new System.Drawing.Size(776, 293);
            F0_listBox_LoadingElements.TabIndex = 1;
            // 
            // F0_label_LoadingElements
            // 
            F0_label_LoadingElements.AutoSize = true;
            F0_label_LoadingElements.Location = new System.Drawing.Point(12, 26);
            F0_label_LoadingElements.Name = "F0_label_LoadingElements";
            F0_label_LoadingElements.Size = new System.Drawing.Size(72, 17);
            F0_label_LoadingElements.TabIndex = 2;
            F0_label_LoadingElements.Text = "Loading:";
            // 
            // F0_Logo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(801, 422);
            ControlBox = false;
            Controls.Add(F0_label_LoadingElements);
            Controls.Add(F0_listBox_LoadingElements);
            Controls.Add(F0_progressBar_IdeLoading);
            Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "F0_Logo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CoDesigner";
            Load += F0_Logo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar F0_progressBar_IdeLoading;
        private System.Windows.Forms.Timer F0_timer_LoadIdeDelayTimer;
        private System.Windows.Forms.Timer F0_timer_CancelLoadTimer;
        private System.Windows.Forms.ListBox F0_listBox_LoadingElements;
        private System.Windows.Forms.Label F0_label_LoadingElements;
    }
}


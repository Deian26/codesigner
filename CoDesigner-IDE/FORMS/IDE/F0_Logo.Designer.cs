namespace CoDesigner_IDE
{
    partial class F0_Logo
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
            this.components = new System.ComponentModel.Container();
            this.F0_progressBar_IdeLoading = new System.Windows.Forms.ProgressBar();
            this.F0_timer_LoadIdeDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.F0_timer_CancelLoadTimer = new System.Windows.Forms.Timer(this.components);
            this.F0_listBox_LoadingElements = new System.Windows.Forms.ListBox();
            this.F0_label_LoadingElements = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // F0_progressBar_IdeLoading
            // 
            this.F0_progressBar_IdeLoading.Location = new System.Drawing.Point(12, 382);
            this.F0_progressBar_IdeLoading.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.F0_progressBar_IdeLoading.Name = "F0_progressBar_IdeLoading";
            this.F0_progressBar_IdeLoading.Size = new System.Drawing.Size(776, 27);
            this.F0_progressBar_IdeLoading.TabIndex = 0;
            // 
            // F0_timer_LoadIdeDelayTimer
            // 
            this.F0_timer_LoadIdeDelayTimer.Tick += new System.EventHandler(this.F0_timer_LoadIdeDelayTimer_Tick);
            // 
            // F0_timer_CancelLoadTimer
            // 
            this.F0_timer_CancelLoadTimer.Tick += new System.EventHandler(this.F0_timer_CancelLoadTimer_Tick);
            // 
            // F0_listBox_LoadingElements
            // 
            this.F0_listBox_LoadingElements.FormattingEnabled = true;
            this.F0_listBox_LoadingElements.ItemHeight = 19;
            this.F0_listBox_LoadingElements.Location = new System.Drawing.Point(12, 57);
            this.F0_listBox_LoadingElements.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.F0_listBox_LoadingElements.Name = "F0_listBox_LoadingElements";
            this.F0_listBox_LoadingElements.Size = new System.Drawing.Size(776, 308);
            this.F0_listBox_LoadingElements.TabIndex = 1;
            // 
            // F0_label_LoadingElements
            // 
            this.F0_label_LoadingElements.AutoSize = true;
            this.F0_label_LoadingElements.Location = new System.Drawing.Point(12, 26);
            this.F0_label_LoadingElements.Name = "F0_label_LoadingElements";
            this.F0_label_LoadingElements.Size = new System.Drawing.Size(81, 20);
            this.F0_label_LoadingElements.TabIndex = 2;
            this.F0_label_LoadingElements.Text = "Loading:";
            // 
            // F0_Logo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(801, 422);
            this.ControlBox = false;
            this.Controls.Add(this.F0_label_LoadingElements);
            this.Controls.Add(this.F0_listBox_LoadingElements);
            this.Controls.Add(this.F0_progressBar_IdeLoading);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "F0_Logo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoDesigner";
            this.Load += new System.EventHandler(this.F0_Logo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar F0_progressBar_IdeLoading;
        private System.Windows.Forms.Timer F0_timer_LoadIdeDelayTimer;
        private System.Windows.Forms.Timer F0_timer_CancelLoadTimer;
        private System.Windows.Forms.ListBox F0_listBox_LoadingElements;
        private System.Windows.Forms.Label F0_label_LoadingElements;
    }
}


namespace CoDesigner_IDE
{
    partial class F1_2_SimulationWindow
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
            this.SuspendLayout();
            // 
            // F1_2_SimulationWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1064, 609);
            this.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "F1_2_SimulationWindow";
            this.Text = "F1_SimulationContainer #No.#";
            this.Load += new System.EventHandler(this.F1_2_SimulationWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.F1_2_SimulationWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.F1_2_SimulationWindow_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
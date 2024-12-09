namespace CoDesigner_IDE
{
    partial class F1_1_SimBlueprints
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
            this.F2_treeView_Blueprints = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // F2_treeView_Blueprints
            // 
            this.F2_treeView_Blueprints.BackColor = System.Drawing.SystemColors.ControlLight;
            this.F2_treeView_Blueprints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.F2_treeView_Blueprints.Location = new System.Drawing.Point(0, 0);
            this.F2_treeView_Blueprints.Name = "F2_treeView_Blueprints";
            this.F2_treeView_Blueprints.Size = new System.Drawing.Size(330, 633);
            this.F2_treeView_Blueprints.TabIndex = 0;
            this.F2_treeView_Blueprints.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.F2_treeView_Blueprints_ItemDrag);
            // 
            // F1_1_SimBlueprints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(330, 633);
            this.Controls.Add(this.F2_treeView_Blueprints);
            this.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "F1_1_SimBlueprints";
            this.Text = "Blueprints";
            this.Load += new System.EventHandler(this.F2_SimBlueprints_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView F2_treeView_Blueprints;
    }
}
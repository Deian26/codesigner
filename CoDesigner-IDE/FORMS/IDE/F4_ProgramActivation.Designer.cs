namespace CoDesigner_IDE.FORMS.IDE
{
    partial class F4_RegisterGenId
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
            components = new System.ComponentModel.Container();
            F4_textBox_ProgramActivationGeneratorId = new System.Windows.Forms.TextBox();
            F4_label_ProgramActivationGeneratorIdLabel = new System.Windows.Forms.Label();
            F4_button_RegisterGenId = new System.Windows.Forms.Button();
            F4_errorProvider_ProgramActivationErrors = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)F4_errorProvider_ProgramActivationErrors).BeginInit();
            SuspendLayout();
            // 
            // F4_textBox_ProgramActivationGeneratorId
            // 
            F4_textBox_ProgramActivationGeneratorId.Location = new System.Drawing.Point(56, 27);
            F4_textBox_ProgramActivationGeneratorId.Name = "F4_textBox_ProgramActivationGeneratorId";
            F4_textBox_ProgramActivationGeneratorId.Size = new System.Drawing.Size(292, 26);
            F4_textBox_ProgramActivationGeneratorId.TabIndex = 0;
            // 
            // F4_label_ProgramActivationGeneratorIdLabel
            // 
            F4_label_ProgramActivationGeneratorIdLabel.AutoSize = true;
            F4_label_ProgramActivationGeneratorIdLabel.Location = new System.Drawing.Point(12, 30);
            F4_label_ProgramActivationGeneratorIdLabel.Name = "F4_label_ProgramActivationGeneratorIdLabel";
            F4_label_ProgramActivationGeneratorIdLabel.Size = new System.Drawing.Size(46, 21);
            F4_label_ProgramActivationGeneratorIdLabel.TabIndex = 1;
            F4_label_ProgramActivationGeneratorIdLabel.Text = "Key:";
            // 
            // F4_button_RegisterGenId
            // 
            F4_button_RegisterGenId.Location = new System.Drawing.Point(230, 59);
            F4_button_RegisterGenId.Name = "F4_button_RegisterGenId";
            F4_button_RegisterGenId.Size = new System.Drawing.Size(118, 30);
            F4_button_RegisterGenId.TabIndex = 2;
            F4_button_RegisterGenId.Text = "Register";
            F4_button_RegisterGenId.UseVisualStyleBackColor = true;
            F4_button_RegisterGenId.Click += F4_button_ActivateProgram_Click;
            // 
            // F4_errorProvider_ProgramActivationErrors
            // 
            F4_errorProvider_ProgramActivationErrors.ContainerControl = this;
            // 
            // F4_RegisterGenId
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(360, 94);
            Controls.Add(F4_button_RegisterGenId);
            Controls.Add(F4_label_ProgramActivationGeneratorIdLabel);
            Controls.Add(F4_textBox_ProgramActivationGeneratorId);
            Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "F4_RegisterGenId";
            Text = "Register IDE";
            Load += F4_RegisterIde_Load;
            ((System.ComponentModel.ISupportInitialize)F4_errorProvider_ProgramActivationErrors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox F4_textBox_ProgramActivationGeneratorId;
        private System.Windows.Forms.Label F4_label_ProgramActivationGeneratorIdLabel;
        private System.Windows.Forms.Button F4_button_RegisterGenId;
        private System.Windows.Forms.ErrorProvider F4_errorProvider_ProgramActivationErrors;
    }
}
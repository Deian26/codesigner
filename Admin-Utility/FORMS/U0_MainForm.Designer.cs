namespace Admin_Utility
{
    partial class U0_MainForm
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
            U0_groupBox_TokenAdmin = new System.Windows.Forms.GroupBox();
            U0_label_CrtUserGeneratedTokensLabel = new System.Windows.Forms.Label();
            U0_treeView_CrtUserGeneratedTokens = new System.Windows.Forms.TreeView();
            U0_checkBox_DevelopmentToken = new System.Windows.Forms.CheckBox();
            U0_richTextBox_GeneratedToken = new System.Windows.Forms.RichTextBox();
            U0_label_GeneratedTokenLabel = new System.Windows.Forms.Label();
            U0_richTextBox_GeneratorIdDisplay = new System.Windows.Forms.RichTextBox();
            U0_button_GenerateToken = new System.Windows.Forms.Button();
            U0_label_GeneratorIdLabel = new System.Windows.Forms.Label();
            U0_comboBox_TokenExpiration = new System.Windows.Forms.ComboBox();
            U0_label_TokenExpirationLabel = new System.Windows.Forms.Label();
            U0_label_TokenAccessLevelLabel = new System.Windows.Forms.Label();
            U0_comboBox_TokenAccessLevel = new System.Windows.Forms.ComboBox();
            U0_groupBox_UserInfo = new System.Windows.Forms.GroupBox();
            U0_label_AccessLevelLabel = new System.Windows.Forms.Label();
            U0_textBox_AccessLevelDisplay = new System.Windows.Forms.TextBox();
            U0_label_UserName = new System.Windows.Forms.Label();
            U0_textBox_UsernameDisplay = new System.Windows.Forms.TextBox();
            U0_groupBox_Diagnostics = new System.Windows.Forms.GroupBox();
            U0_button_OpenDiagnosticsReport = new System.Windows.Forms.Button();
            U0_openFileDialog_OpenDiagnosticsReport = new System.Windows.Forms.OpenFileDialog();
            U0_backgroundWorker_LoadCrtUserGeneratedTokens = new System.ComponentModel.BackgroundWorker();
            U0_groupBox_CustomizationUtility = new System.Windows.Forms.GroupBox();
            U0_groupBox_TokenAdmin.SuspendLayout();
            U0_groupBox_UserInfo.SuspendLayout();
            U0_groupBox_Diagnostics.SuspendLayout();
            SuspendLayout();
            // 
            // U0_groupBox_TokenAdmin
            // 
            U0_groupBox_TokenAdmin.Controls.Add(U0_label_CrtUserGeneratedTokensLabel);
            U0_groupBox_TokenAdmin.Controls.Add(U0_treeView_CrtUserGeneratedTokens);
            U0_groupBox_TokenAdmin.Controls.Add(U0_checkBox_DevelopmentToken);
            U0_groupBox_TokenAdmin.Controls.Add(U0_richTextBox_GeneratedToken);
            U0_groupBox_TokenAdmin.Controls.Add(U0_label_GeneratedTokenLabel);
            U0_groupBox_TokenAdmin.Controls.Add(U0_richTextBox_GeneratorIdDisplay);
            U0_groupBox_TokenAdmin.Controls.Add(U0_button_GenerateToken);
            U0_groupBox_TokenAdmin.Controls.Add(U0_label_GeneratorIdLabel);
            U0_groupBox_TokenAdmin.Controls.Add(U0_comboBox_TokenExpiration);
            U0_groupBox_TokenAdmin.Controls.Add(U0_label_TokenExpirationLabel);
            U0_groupBox_TokenAdmin.Controls.Add(U0_label_TokenAccessLevelLabel);
            U0_groupBox_TokenAdmin.Controls.Add(U0_comboBox_TokenAccessLevel);
            U0_groupBox_TokenAdmin.Font = new System.Drawing.Font("Cascadia Mono", 11.1F);
            U0_groupBox_TokenAdmin.Location = new System.Drawing.Point(12, 115);
            U0_groupBox_TokenAdmin.Name = "U0_groupBox_TokenAdmin";
            U0_groupBox_TokenAdmin.Size = new System.Drawing.Size(932, 439);
            U0_groupBox_TokenAdmin.TabIndex = 0;
            U0_groupBox_TokenAdmin.TabStop = false;
            U0_groupBox_TokenAdmin.Text = "Token Administration";
            // 
            // U0_label_CrtUserGeneratedTokensLabel
            // 
            U0_label_CrtUserGeneratedTokensLabel.AutoSize = true;
            U0_label_CrtUserGeneratedTokensLabel.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_CrtUserGeneratedTokensLabel.Location = new System.Drawing.Point(6, 227);
            U0_label_CrtUserGeneratedTokensLabel.Name = "U0_label_CrtUserGeneratedTokensLabel";
            U0_label_CrtUserGeneratedTokensLabel.Size = new System.Drawing.Size(266, 16);
            U0_label_CrtUserGeneratedTokensLabel.TabIndex = 10;
            U0_label_CrtUserGeneratedTokensLabel.Text = "Generated tokens by the current user:";
            // 
            // U0_treeView_CrtUserGeneratedTokens
            // 
            U0_treeView_CrtUserGeneratedTokens.Location = new System.Drawing.Point(6, 246);
            U0_treeView_CrtUserGeneratedTokens.Name = "U0_treeView_CrtUserGeneratedTokens";
            U0_treeView_CrtUserGeneratedTokens.Size = new System.Drawing.Size(916, 187);
            U0_treeView_CrtUserGeneratedTokens.TabIndex = 0;
            // 
            // U0_checkBox_DevelopmentToken
            // 
            U0_checkBox_DevelopmentToken.AutoSize = true;
            U0_checkBox_DevelopmentToken.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            U0_checkBox_DevelopmentToken.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_checkBox_DevelopmentToken.Location = new System.Drawing.Point(491, 33);
            U0_checkBox_DevelopmentToken.Name = "U0_checkBox_DevelopmentToken";
            U0_checkBox_DevelopmentToken.Size = new System.Drawing.Size(152, 20);
            U0_checkBox_DevelopmentToken.TabIndex = 9;
            U0_checkBox_DevelopmentToken.Text = "Development token:";
            U0_checkBox_DevelopmentToken.UseVisualStyleBackColor = true;
            U0_checkBox_DevelopmentToken.CheckedChanged += U0_checkBox_DevelopmentToken_CheckedChanged;
            // 
            // U0_richTextBox_GeneratedToken
            // 
            U0_richTextBox_GeneratedToken.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_richTextBox_GeneratedToken.Location = new System.Drawing.Point(491, 143);
            U0_richTextBox_GeneratedToken.Name = "U0_richTextBox_GeneratedToken";
            U0_richTextBox_GeneratedToken.ReadOnly = true;
            U0_richTextBox_GeneratedToken.Size = new System.Drawing.Size(431, 67);
            U0_richTextBox_GeneratedToken.TabIndex = 8;
            U0_richTextBox_GeneratedToken.Text = "";
            // 
            // U0_label_GeneratedTokenLabel
            // 
            U0_label_GeneratedTokenLabel.AutoSize = true;
            U0_label_GeneratedTokenLabel.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_GeneratedTokenLabel.Location = new System.Drawing.Point(491, 124);
            U0_label_GeneratedTokenLabel.Name = "U0_label_GeneratedTokenLabel";
            U0_label_GeneratedTokenLabel.Size = new System.Drawing.Size(49, 16);
            U0_label_GeneratedTokenLabel.TabIndex = 7;
            U0_label_GeneratedTokenLabel.Text = "Token:";
            // 
            // U0_richTextBox_GeneratorIdDisplay
            // 
            U0_richTextBox_GeneratorIdDisplay.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_richTextBox_GeneratorIdDisplay.Location = new System.Drawing.Point(6, 143);
            U0_richTextBox_GeneratorIdDisplay.Name = "U0_richTextBox_GeneratorIdDisplay";
            U0_richTextBox_GeneratorIdDisplay.ReadOnly = true;
            U0_richTextBox_GeneratorIdDisplay.Size = new System.Drawing.Size(479, 67);
            U0_richTextBox_GeneratorIdDisplay.TabIndex = 6;
            U0_richTextBox_GeneratorIdDisplay.Text = "";
            // 
            // U0_button_GenerateToken
            // 
            U0_button_GenerateToken.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_button_GenerateToken.Location = new System.Drawing.Point(779, 24);
            U0_button_GenerateToken.Name = "U0_button_GenerateToken";
            U0_button_GenerateToken.Size = new System.Drawing.Size(143, 56);
            U0_button_GenerateToken.TabIndex = 0;
            U0_button_GenerateToken.Text = "Generate Token";
            U0_button_GenerateToken.UseVisualStyleBackColor = true;
            U0_button_GenerateToken.Click += U0_button_GenerateToken_Click;
            // 
            // U0_label_GeneratorIdLabel
            // 
            U0_label_GeneratorIdLabel.AutoSize = true;
            U0_label_GeneratorIdLabel.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_GeneratorIdLabel.Location = new System.Drawing.Point(6, 124);
            U0_label_GeneratorIdLabel.Name = "U0_label_GeneratorIdLabel";
            U0_label_GeneratorIdLabel.Size = new System.Drawing.Size(98, 16);
            U0_label_GeneratorIdLabel.TabIndex = 5;
            U0_label_GeneratorIdLabel.Text = "Generator ID:";
            // 
            // U0_comboBox_TokenExpiration
            // 
            U0_comboBox_TokenExpiration.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_comboBox_TokenExpiration.FormattingEnabled = true;
            U0_comboBox_TokenExpiration.Location = new System.Drawing.Point(184, 60);
            U0_comboBox_TokenExpiration.Name = "U0_comboBox_TokenExpiration";
            U0_comboBox_TokenExpiration.Size = new System.Drawing.Size(301, 24);
            U0_comboBox_TokenExpiration.TabIndex = 4;
            // 
            // U0_label_TokenExpirationLabel
            // 
            U0_label_TokenExpirationLabel.AutoSize = true;
            U0_label_TokenExpirationLabel.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_TokenExpirationLabel.Location = new System.Drawing.Point(52, 68);
            U0_label_TokenExpirationLabel.Name = "U0_label_TokenExpirationLabel";
            U0_label_TokenExpirationLabel.Size = new System.Drawing.Size(126, 16);
            U0_label_TokenExpirationLabel.TabIndex = 3;
            U0_label_TokenExpirationLabel.Text = "Expiration (sec):";
            // 
            // U0_label_TokenAccessLevelLabel
            // 
            U0_label_TokenAccessLevelLabel.AutoSize = true;
            U0_label_TokenAccessLevelLabel.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_TokenAccessLevelLabel.Location = new System.Drawing.Point(80, 32);
            U0_label_TokenAccessLevelLabel.Name = "U0_label_TokenAccessLevelLabel";
            U0_label_TokenAccessLevelLabel.Size = new System.Drawing.Size(98, 16);
            U0_label_TokenAccessLevelLabel.TabIndex = 2;
            U0_label_TokenAccessLevelLabel.Text = "Access Level:";
            // 
            // U0_comboBox_TokenAccessLevel
            // 
            U0_comboBox_TokenAccessLevel.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_comboBox_TokenAccessLevel.FormattingEnabled = true;
            U0_comboBox_TokenAccessLevel.Location = new System.Drawing.Point(184, 29);
            U0_comboBox_TokenAccessLevel.Name = "U0_comboBox_TokenAccessLevel";
            U0_comboBox_TokenAccessLevel.Size = new System.Drawing.Size(301, 24);
            U0_comboBox_TokenAccessLevel.TabIndex = 1;
            // 
            // U0_groupBox_UserInfo
            // 
            U0_groupBox_UserInfo.Controls.Add(U0_label_AccessLevelLabel);
            U0_groupBox_UserInfo.Controls.Add(U0_textBox_AccessLevelDisplay);
            U0_groupBox_UserInfo.Controls.Add(U0_label_UserName);
            U0_groupBox_UserInfo.Controls.Add(U0_textBox_UsernameDisplay);
            U0_groupBox_UserInfo.Font = new System.Drawing.Font("Cascadia Mono", 11.1F);
            U0_groupBox_UserInfo.Location = new System.Drawing.Point(508, 12);
            U0_groupBox_UserInfo.Name = "U0_groupBox_UserInfo";
            U0_groupBox_UserInfo.Size = new System.Drawing.Size(436, 90);
            U0_groupBox_UserInfo.TabIndex = 1;
            U0_groupBox_UserInfo.TabStop = false;
            U0_groupBox_UserInfo.Text = "User Info";
            // 
            // U0_label_AccessLevelLabel
            // 
            U0_label_AccessLevelLabel.AutoSize = true;
            U0_label_AccessLevelLabel.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_AccessLevelLabel.Location = new System.Drawing.Point(30, 57);
            U0_label_AccessLevelLabel.Name = "U0_label_AccessLevelLabel";
            U0_label_AccessLevelLabel.Size = new System.Drawing.Size(56, 16);
            U0_label_AccessLevelLabel.TabIndex = 3;
            U0_label_AccessLevelLabel.Text = "Access:";
            // 
            // U0_textBox_AccessLevelDisplay
            // 
            U0_textBox_AccessLevelDisplay.Font = new System.Drawing.Font("Cascadia Mono", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_textBox_AccessLevelDisplay.Location = new System.Drawing.Point(100, 54);
            U0_textBox_AccessLevelDisplay.Name = "U0_textBox_AccessLevelDisplay";
            U0_textBox_AccessLevelDisplay.ReadOnly = true;
            U0_textBox_AccessLevelDisplay.Size = new System.Drawing.Size(326, 23);
            U0_textBox_AccessLevelDisplay.TabIndex = 2;
            // 
            // U0_label_UserName
            // 
            U0_label_UserName.AutoSize = true;
            U0_label_UserName.Font = new System.Drawing.Font("Cascadia Mono", 9F);
            U0_label_UserName.Location = new System.Drawing.Point(46, 33);
            U0_label_UserName.Name = "U0_label_UserName";
            U0_label_UserName.Size = new System.Drawing.Size(42, 16);
            U0_label_UserName.TabIndex = 1;
            U0_label_UserName.Text = "User:";
            // 
            // U0_textBox_UsernameDisplay
            // 
            U0_textBox_UsernameDisplay.Font = new System.Drawing.Font("Cascadia Mono", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_textBox_UsernameDisplay.Location = new System.Drawing.Point(100, 25);
            U0_textBox_UsernameDisplay.Name = "U0_textBox_UsernameDisplay";
            U0_textBox_UsernameDisplay.ReadOnly = true;
            U0_textBox_UsernameDisplay.Size = new System.Drawing.Size(326, 23);
            U0_textBox_UsernameDisplay.TabIndex = 0;
            // 
            // U0_groupBox_Diagnostics
            // 
            U0_groupBox_Diagnostics.Controls.Add(U0_button_OpenDiagnosticsReport);
            U0_groupBox_Diagnostics.Font = new System.Drawing.Font("Cascadia Mono", 11.1F);
            U0_groupBox_Diagnostics.Location = new System.Drawing.Point(12, 12);
            U0_groupBox_Diagnostics.Name = "U0_groupBox_Diagnostics";
            U0_groupBox_Diagnostics.Size = new System.Drawing.Size(490, 90);
            U0_groupBox_Diagnostics.TabIndex = 3;
            U0_groupBox_Diagnostics.TabStop = false;
            U0_groupBox_Diagnostics.Text = "Diagnostics Utility";
            // 
            // U0_button_OpenDiagnosticsReport
            // 
            U0_button_OpenDiagnosticsReport.Font = new System.Drawing.Font("Cascadia Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            U0_button_OpenDiagnosticsReport.Location = new System.Drawing.Point(342, 33);
            U0_button_OpenDiagnosticsReport.Name = "U0_button_OpenDiagnosticsReport";
            U0_button_OpenDiagnosticsReport.Size = new System.Drawing.Size(143, 42);
            U0_button_OpenDiagnosticsReport.TabIndex = 0;
            U0_button_OpenDiagnosticsReport.Text = "Open Report";
            U0_button_OpenDiagnosticsReport.UseVisualStyleBackColor = true;
            U0_button_OpenDiagnosticsReport.Click += U0_button_OpenDiagnosticsReport_Click;
            // 
            // U0_backgroundWorker_LoadCrtUserGeneratedTokens
            // 
            U0_backgroundWorker_LoadCrtUserGeneratedTokens.DoWork += U0_backgroundWorker_LoadCrtUserGeneratedTokens_DoWork;
            // 
            // U0_groupBox_CustomizationUtility
            // 
            U0_groupBox_CustomizationUtility.Font = new System.Drawing.Font("Cascadia Mono", 11.1F);
            U0_groupBox_CustomizationUtility.Location = new System.Drawing.Point(950, 12);
            U0_groupBox_CustomizationUtility.Name = "U0_groupBox_CustomizationUtility";
            U0_groupBox_CustomizationUtility.Size = new System.Drawing.Size(312, 542);
            U0_groupBox_CustomizationUtility.TabIndex = 4;
            U0_groupBox_CustomizationUtility.TabStop = false;
            U0_groupBox_CustomizationUtility.Text = "Customization Utility";
            // 
            // U0_MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.AppWorkspace;
            ClientSize = new System.Drawing.Size(1274, 566);
            Controls.Add(U0_groupBox_CustomizationUtility);
            Controls.Add(U0_groupBox_Diagnostics);
            Controls.Add(U0_groupBox_UserInfo);
            Controls.Add(U0_groupBox_TokenAdmin);
            Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "U0_MainForm";
            Text = "  Admin-Utility";
            Load += U0_MainForm_Load;
            U0_groupBox_TokenAdmin.ResumeLayout(false);
            U0_groupBox_TokenAdmin.PerformLayout();
            U0_groupBox_UserInfo.ResumeLayout(false);
            U0_groupBox_UserInfo.PerformLayout();
            U0_groupBox_Diagnostics.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox U0_groupBox_TokenAdmin;
        private System.Windows.Forms.Button U0_button_GenerateToken;
        private System.Windows.Forms.ComboBox U0_comboBox_TokenAccessLevel;
        private System.Windows.Forms.Label U0_label_TokenAccessLevelLabel;
        private System.Windows.Forms.ComboBox U0_comboBox_TokenExpiration;
        private System.Windows.Forms.Label U0_label_TokenExpirationLabel;
        private System.Windows.Forms.GroupBox U0_groupBox_UserInfo;
        private System.Windows.Forms.Label U0_label_AccessLevelLabel;
        private System.Windows.Forms.TextBox U0_textBox_AccessLevelDisplay;
        private System.Windows.Forms.Label U0_label_UserName;
        private System.Windows.Forms.TextBox U0_textBox_UsernameDisplay;
        private System.Windows.Forms.GroupBox U0_groupBox_Diagnostics;
        private System.Windows.Forms.OpenFileDialog U0_openFileDialog_OpenDiagnosticsReport;
        private System.Windows.Forms.Button U0_button_OpenDiagnosticsReport;
        private System.Windows.Forms.Label U0_label_GeneratorIdLabel;
        private System.Windows.Forms.RichTextBox U0_richTextBox_GeneratorIdDisplay;
        private System.Windows.Forms.RichTextBox U0_richTextBox_GeneratedToken;
        private System.Windows.Forms.Label U0_label_GeneratedTokenLabel;
        private System.Windows.Forms.CheckBox U0_checkBox_DevelopmentToken;
        private System.Windows.Forms.TreeView U0_treeView_CrtUserGeneratedTokens;
        private System.Windows.Forms.Label U0_label_CrtUserGeneratedTokensLabel;
        private System.ComponentModel.BackgroundWorker U0_backgroundWorker_LoadCrtUserGeneratedTokens;
        private System.Windows.Forms.GroupBox U0_groupBox_CustomizationUtility;
    }
}
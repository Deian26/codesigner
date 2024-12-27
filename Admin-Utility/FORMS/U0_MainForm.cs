using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Utility
{
    public partial class U0_MainForm : Form
    {
        

        public U0_MainForm()
        {
            InitializeComponent();
#if DEBUG
            this.U0_checkBox_DevelopmentToken.Checked = true; // dev mode
#endif
            // set max expiration limits and select the first one
            this.U0_comboBox_TokenExpiration.Items.AddRange(Security.TokenExpirationLimits);
            this.U0_comboBox_TokenExpiration.SelectedIndex = 0;

            // set access levels and select the first one
            this.U0_comboBox_TokenAccessLevel.Items.AddRange(Enum.GetNames(typeof(Security.AccessLevel)));
            this.U0_comboBox_TokenAccessLevel.SelectedIndex = 0;
        }

        private void U0_button_GenerateToken_Click(object sender, EventArgs e)
        {
            // compute and display the generator ID
            this.U0_richTextBox_GeneratorIdDisplay.Text = Security.GetGeneratorId(this.U0_checkBox_DevelopmentToken.Checked); // the generator ID is computed in the first call of this method
            
            // generate a new token and display it
            this.U0_richTextBox_GeneratedToken.Text = Security.GenerateToken(
                this.U0_comboBox_TokenAccessLevel.SelectedItem.ToString(), 
                this.U0_comboBox_TokenExpiration.SelectedItem.ToString());

        }

        private void U0_button_OpenDiagnosticsReport_Click(object sender, EventArgs e)
        {
            // load a diagnostic report into a new Diagnostic Investigator form
            //TODO: Implement the Diagnostic Investigator utility
        }

        private void U0_MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}

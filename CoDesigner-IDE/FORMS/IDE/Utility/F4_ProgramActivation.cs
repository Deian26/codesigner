using CoDesigner_IDE.SYSTEM.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines a form for program activation (storing an initial, approved generator ID)
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class F4_RegisterGenId : Form
    {
        private bool createUsedTokensFile = false;

        /// <summary>
        /// Creates a form used to request the user for an activation key (generator ID)
        /// </summary>
        /// <param name="createUsedTokensFile">If true, a new used tokens local file is created; if false, a new gen ID is simply added to the list of approved gen IDs (memory)</param>
        public F4_RegisterGenId(bool createUsedTokensFile)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Abort; // init
            this.createUsedTokensFile = createUsedTokensFile;

        }

        private void F4_button_ActivateProgram_Click(object sender, EventArgs e)
        {
            // check the given ID
            if (this.F4_textBox_ProgramActivationGeneratorId.Text.Length > 0)
            {

                if (Security.IsByteString(this.F4_textBox_ProgramActivationGeneratorId.Text) == true)
                {
                    Security.MemorizeGeneratorId(this.F4_textBox_ProgramActivationGeneratorId.Text); // store this as a valid generator ID
                    this.DialogResult = DialogResult.OK;
                    Utility.PROGRAM_ACTIVATED = true;

                    // create a used tokens file with no tokens
                    if (this.createUsedTokensFile == true) Security.StoreUsedTokens(true); // create the local used tokens file, if it does not exist
                }
                else // invalid string format
                {
                    this.F4_textBox_ProgramActivationGeneratorId.BackColor = Utility.BACKCOLOUR_ERROR;
                    this.F4_errorProvider_ProgramActivationErrors.SetError(this.F4_textBox_ProgramActivationGeneratorId, Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.ERROR_ACTIVATING_PROGRAM_INVALID_PROVIDED));
                }
            }
            else // no generator ID given
            {
                this.F4_textBox_ProgramActivationGeneratorId.BackColor = Utility.BACKCOLOUR_ERROR;
                this.F4_errorProvider_ProgramActivationErrors.SetError(this.F4_textBox_ProgramActivationGeneratorId, Prompts.GetMessageText(Prompts.DEFAULT_MESSAGES_ORIGIN_CODE, Prompts.PromptMessageCodes.ERROR_ACTIVATING_PROGRAM_NO_KEY_PROVIDED));
            }
        }

        private void F4_RegisterIde_Load(object sender, EventArgs e)
        {

        }
    }
}

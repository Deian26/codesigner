using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoDesigner_IDE.FORMS.IDE.Projects
{
    public partial class F3_MainEditor : Form
    {
        public F3_MainEditor(Project project)
        {
            InitializeComponent();

            //form settings
            this.IsMdiContainer = true;

            //customize form
            this.Text = project.Name;
        }

        private void F3_MainEditor_Load(object sender, EventArgs e)
        {

        }

        private void F3_MainEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //stop program
            Program.StopAll();
        }
    }
}

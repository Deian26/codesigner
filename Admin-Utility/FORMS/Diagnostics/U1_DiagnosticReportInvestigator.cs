using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Admin_Utility.FORMS.Diagnostics
{
    /// <summary>
    /// Loads the diagnostics report found at the given path
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class U1_DiagnosticReportInvestigator : Form
    {
        private string reportPath { get; } = null;
        /// <summary>
        /// Creates a new diagnostic report investigator form
        /// </summary>
        /// <param name="reportPath">The report file path</param>
        public U1_DiagnosticReportInvestigator(string reportPath)
        {
            InitializeComponent();

            // check path
            if (Path.Exists(reportPath) == false)
                this.Close();

            // save path
            this.reportPath = reportPath;

            // open report
            if (this.openReport() == false)
                this.Close();
        }

        #region utility
        /// <summary>
        /// Recursively parses an XML tree representing a diagnostic report and displays the data contained within, in this form
        /// </summary>
        /// <param name="root">Tree / sub-tree root</param>
        /// <param name="displayRoot">Tree node used to display details about the current XML node (root)</param>
        /// <returns>The root of the next sub-tree to parse</returns>
        private XmlNode parseNodes(XmlNode root, TreeNode displayRoot)
        {
            if (root == null || root.ChildNodes.Count == 0) return null; // extra check => exit;

            // parse nodes
            foreach (XmlNode node in root.ChildNodes)
            {
                // display data
                foreach (XmlAttribute attribute in node.Attributes)
                {
                    // display current XML node details as sub-TreeNodes
                    displayRoot.Nodes.Add(attribute.Name, $"[{attribute.Name}] {attribute.Value}");
                }

                // go to the next level, if it exists
                if (node.ChildNodes.Count != 0) // parse nodes
                    this.parseNodes(node, displayRoot.Nodes.Add(node.Name)); // this sets the name of the sub-node to the XML node name
            }

            return root;
        }

        /// <summary>
        /// Opens the current report file
        /// </summary>
        /// <returns>true if the report could be opened; false, otherwise</returns>
        private bool openReport()
        {
            bool open = false;

            try
            {
                string reportPlainText = Security.RsaDecrypt(File.ReadAllText(reportPath));

                // parse report text
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(reportPlainText);
                XmlNode root = xml.DocumentElement;

                // get report type (name)
                if (root.Attributes["type"] != null)
                {
                    // initialize the tree view control
                    this.U1_treeView_DiagReportViewer.Nodes.Add($"[Type] {root.Attributes["type"].Value}");
                    
                    // parse and display items
                    this.parseNodes(root,this.U1_treeView_DiagReportViewer.TopNode);

                    open = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open diagnostics report: {ex.Message}", "ERROR OPENING REPORT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                open = false;
            }

            return open;
        }

        #endregion
        
        private void U1_DiagnosticReportInvestigator_Load(object sender, EventArgs e)
        {

        }

        private void U1_treeView_DiagReportViewer_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

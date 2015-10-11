using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tum.PDE.LanguageDSL.Setup.VSPluginDesignerWizard
{
    public partial class Wizard : Form
    {

        public Wizard()
        {
            InitializeComponent();

            string name = "mydsl";
            int counter = 0;
            while (true)
            {
                string sName = name + counter.ToString();

                if (!this.CheckExtension(sName, false))
                    break;

                counter++;
            }

            this.textBoxExtension.Text = name + counter.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.tabControlMain.SelectedIndex = this.tabControlMain.SelectedIndex + 1;

            CheckButtons();
            if (this.tabControlMain.SelectedIndex == this.tabControlMain.TabCount - 1)
                UpdateSummary();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.tabControlMain.SelectedIndex = this.tabControlMain.SelectedIndex - 1;

            CheckButtons();
        }
        private void CheckButtons()
        {
            if (this.tabControlMain.SelectedIndex == 0)
                this.btnPrev.Enabled = false;
            else
                this.btnPrev.Enabled = true;

            if (this.tabControlMain.SelectedIndex == this.tabControlMain.TabCount - 1)
                this.btnNext.Enabled = false;
            else
                this.btnNext.Enabled = true;
        }

        private void UpdateSummary()
        {
            string result = "Solution settings\r\n";
            result += "   DSL Name: " + this.txtBoxLanguageName.Text + "\r\n\r\n";

            result += "   DSL Extension: " + this.textBoxExtension.Text + "\r\n\r\n";

            result += "Product settings\r\n";
            result += "   Product name: " + this.txtProductName.Text + "\r\n";
            result += "   Company name: " + this.txtCompanyName.Text + "\r\n";
            result += "   Namespace: " + this.txtNamespace.Text + "\r\n";

            this.richTextBoxSummary.Text = result;
        }

        public string ExtensionText
        {
            get
            {
                string s = this.textBoxExtension.Text.Trim();
                if (!s.StartsWith(".", System.StringComparison.OrdinalIgnoreCase))
                    return s;
                return s.Substring(1);
            }
        }

        public bool CheckExtension(string extensionName, bool bSetErrorText)
        {
            bool bFound = false;

            string result = "";

            if (String.IsNullOrEmpty(extensionName))
            {
                return bFound;
            }

            try
            {
                List<string> list = PDERegistry.GetNonVsApplications(extensionName);

                if (list.Count > 0)
                {
                    bFound = true;
                    result += "  Applications: " + "\r\n";

                    foreach (string name in list)
                        result += "\t" + name + "\r\n";
                }

                List<VsPackageInfo> listPackages = PDERegistry.GetVsPackages(extensionName);
                List<string> listApps = new List<string>();
                foreach (VsPackageInfo info in listPackages)
                {
                    if (!listApps.Contains(info.EditorDisplayName))
                    {
                        listApps.Add(info.EditorDisplayName);
                    }
                }

                if (listApps.Count > 0)
                {
                    bFound = true;

                    result += "  Visual Studio Editors: " + "\r\n";
                    foreach (string name in listApps)
                        result += "\t" + name + "\r\n";
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

            if (bSetErrorText)
                this.richTextBoxExtensions.Text = result;

            return bFound;
        }

        private void textBoxExtension_TextChanged(object sender, EventArgs e)
        {
            if (this.CheckExtension(this.ExtensionText, true))
                this.btnFinish.Enabled = false;
            else
                this.btnFinish.Enabled = true;
        }

        private void radioButtonUseKey_CheckedChanged(object sender, EventArgs e)
        {
            this.txtKeyPath.Enabled = this.radioButtonUseKey.Checked;
            this.btnBrowse.Enabled = this.radioButtonUseKey.Checked;

            if (this.radioButtonUseKey.Checked)
                this.txtKeyPath.Focus();

            CheckKeyPath();
        }
        private void radioButtonCreateKey_CheckedChanged(object sender, EventArgs e)
        {
            this.txtKeyPath.Enabled = this.radioButtonUseKey.Checked;
            this.btnBrowse.Enabled = this.radioButtonUseKey.Checked;

            this.btnNext.Enabled = true;
            this.btnFinish.Enabled = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string s = null;
            if (!System.String.IsNullOrEmpty(this.txtKeyPath.Text))
            {
                try
                {
                    if (System.IO.Directory.Exists(this.txtKeyPath.Text))
                        s = this.txtKeyPath.Text;
                    else
                        s = System.IO.Path.GetDirectoryName(this.txtKeyPath.Text);
                }
                catch (System.IO.IOException)
                {
                }
            }
            if (!System.String.IsNullOrEmpty(s))
                openFileDialog.InitialDirectory = s;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.txtKeyPath.Text = openFileDialog.FileName;
        }

        private void txtKeyPath_TextChanged(object sender, EventArgs e)
        {
            CheckKeyPath();
        }

        private void CheckKeyPath()
        {
            string s;

            if (!this.radioButtonCreateKey.Checked)
            {
                if (StrongNameKey.IsValidKeyFile(this.txtKeyPath.Text, out s))
                {
                    this.btnNext.Enabled = true;
                    this.btnFinish.Enabled = true;

                    return;
                }
                this.btnNext.Enabled = false;
                this.btnFinish.Enabled = false;
                return;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string languageName = this.txtBoxLanguageName.Text.Trim();
            if (languageName.Contains(" "))
            {
                //this.txtBoxLanguageName.Text = languageName.Replace(" ", "");
                MessageBox.Show("The language name can not contain whitespaces.");
                return;
            }

            string namespaceStr = this.txtNamespace.Text.Trim();
            if (namespaceStr.Contains(" "))
            {
                //this.txtBoxLanguageName.Text = languageName.Replace(" ", "");
                MessageBox.Show("Namespace can not contain whitespaces.");
                return;
            }

            /*
            if (languageName == this.txtNamespace.Text.Trim())
            {
                MessageBox.Show("The language name can not be equal to the namespace.");
                return;
            }*/

            this.txtBoxLanguageName.Text = this.txtBoxLanguageName.Text.Trim();
            this.txtNamespace.Text = this.txtNamespace.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

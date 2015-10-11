using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tum.PDE.LanguageDSL.Setup.DesignerWizard
{
    public partial class Wizard : Form
    {
        //private Dictionary<Microsoft.Win32.RegistryKey, string> dictionaryNormal;
        //private Dictionary<Microsoft.Win32.RegistryKey, string> dictionaryExp;

        public Wizard()
        {
            InitializeComponent();
            //LoadExtensions();
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

            result += "Product settings\r\n";
            result += "   Product name: " + this.txtProductName.Text + "\r\n";
            result += "   Company name: " + this.txtCompanyName.Text + "\r\n";
            result += "   Namespace: " + this.txtNamespace.Text + "\r\n";

            this.richTextBoxSummary.Text = result;
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

        /*
        private string ExtensionText
        {
            get
            {
                string s = txtBoxDslExtension.Text.Trim();
                if (!s.StartsWith(".", System.StringComparison.OrdinalIgnoreCase))
                    return s;
                return s.Substring(1);
            }
        }
        private void txtBoxDslExtension_TextChanged(object sender, EventArgs e)
        {
            bool bFound = false;

            string result = "Extension ' " + this.ExtensionText + "' used in Visual Studio: " + "\r\n";
            bool bFoundLocal = false;
            foreach (Microsoft.Win32.RegistryKey key in this.dictionaryNormal.Keys)
            {
                if (dictionaryNormal[key] == this.ExtensionText)
                    result += "   " + key.Name + "\r\n";

                bFound = true;
                bFoundLocal = true;
            }
            if (!bFoundLocal)
                result += "   None!\r\n";

            result += "\r\n";
            result += "Extension ' " + this.ExtensionText + "' used in Visual Studio Experimental Hive: " + "\r\n";
            bFoundLocal = false;
            foreach (Microsoft.Win32.RegistryKey key in this.dictionaryExp.Keys)
            {
                if (dictionaryExp[key] == this.ExtensionText)
                    result += "   " + key.Name + "\r\n";

                bFound = true;
            }
            if (!bFoundLocal)
                result += "   None!\r\n";

            if (bFound)
                this.btnFinish.Enabled = false;
            else
                this.btnFinish.Enabled = true;

            this.richTextBoxExtensions.Text = result;
        }
        private void LoadExtensions()
        {
            dictionaryNormal = new Dictionary<Microsoft.Win32.RegistryKey, string>();
            dictionaryExp = new Dictionary<Microsoft.Win32.RegistryKey, string>();

            // set new extension name
            string name = "mydsl";
            int counter = 0;
            while (true)
            {
                string sName = name + counter.ToString();
                bool bFound = false;

                foreach (Microsoft.Win32.RegistryKey key in this.dictionaryNormal.Keys)
                {
                    if (dictionaryNormal[key] == sName)
                    {
                        bFound = true;
                        break;
                    }
                }
                foreach (Microsoft.Win32.RegistryKey key in this.dictionaryExp.Keys)
                {
                    if (dictionaryExp[key] == sName)
                    {
                        bFound = true;
                        break;
                    }
                }

                if (!bFound)
                    break;
                else
                    counter++;
            }
            this.txtBoxDslExtension.Text = "." + name;
        }
        private void LoadExtensions(Microsoft.Win32.RegistryKey hiveRoot, Dictionary<Microsoft.Win32.RegistryKey, string> dictionary)
        {
            if (hiveRoot == null)
                return;

            using (Microsoft.Win32.RegistryKey registryKey = hiveRoot.OpenSubKey("Editors"))
            {
                if (registryKey == null)
                    return;

                string[] sArr = registryKey.GetSubKeyNames();
                foreach (string keyName in sArr)
                {
                    using (Microsoft.Win32.RegistryKey registrySubKey = registryKey.OpenSubKey(keyName))
                    {
                        if (registrySubKey == null)
                            continue;

                        using (Microsoft.Win32.RegistryKey registryKeyExtensions = registrySubKey.OpenSubKey("Extensions"))
                        {
                            if (registryKeyExtensions == null)
                                continue;
                            string[] sArrExt = registryKeyExtensions.GetValueNames();
                            foreach (string n in sArrExt)
                            {
                                char[] chArr = new char[] { '.', ' ' };
                                string result = n.Trim(chArr).ToUpperInvariant();
                                dictionary.Add(registrySubKey, n);
                            }
                        }
                    }
                }
            }
        }

        private static Microsoft.Win32.RegistryKey VsExpHive
        {
            get
            {
                return Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\VisualStudio\\10.0Exp_Config");
            }
        }
        private static Microsoft.Win32.RegistryKey VsMainHive
        {
            get
            {
                return Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\VisualStudio\\10.0_Config");
            }
        }
        */
    }
}

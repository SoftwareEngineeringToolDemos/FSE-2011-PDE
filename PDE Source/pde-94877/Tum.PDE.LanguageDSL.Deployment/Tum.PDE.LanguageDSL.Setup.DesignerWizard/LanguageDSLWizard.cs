using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;

namespace Tum.PDE.LanguageDSL.Setup.DesignerWizard
{
    public class LanguageDSLWizard : IWizard
    {
        public LanguageDSLWizard()
        { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary,
          WizardRunKind runKind, object[] customParams)
        {
            Wizard wiz = new Wizard();

            // Setup wiz:
            wiz.txtNamespace.Text = replacementsDictionary["$safeprojectname$"];

            if (wiz.ShowDialog() == DialogResult.OK)
            {
                // Fill in the replacement values from the UI selections on the wizard page.
                replacementsDictionary.Add("$LanguageID$", Guid.NewGuid().ToString());
                replacementsDictionary.Add("$LanguageName$", wiz.txtBoxLanguageName.Text);
                replacementsDictionary.Add("$LanguageCompanyName$", wiz.txtCompanyName.Text);
                replacementsDictionary.Add("$LanguageNamespace$", wiz.txtNamespace.Text);
                replacementsDictionary.Add("$LanguageProductName$", wiz.txtProductName.Text);
                replacementsDictionary.Add("$LanguageDescription$", wiz.richTextBoxDescription.Text);

                // add guids up to 20
                for(int i = 0; i <= 20; i++ )
                    replacementsDictionary.Add("$Guid" + i.ToString()+ "$", Guid.NewGuid().ToString());

                /*
                System.ComponentModel.Design.CommandID GenerateAllCommandId = new System.ComponentModel.Design.CommandID(new System.Guid("CCD03FEB-6B80-4CDB-AB3A-04702F6E7553"), 8224);
                object obj1 = null, obj2 = null;
                System.Guid guid = GenerateAllCommandId.Guid;
                (automationObject as EnvDTE._DTE).Commands.Raise(guid.ToString("b"), GenerateAllCommandId.ID, ref obj1, ref obj2);
                */

                return;
            }

            throw new WizardCancelledException();
        }

        // Always return true; this IWizard implementation throws a WizardCancelledException
        // that is handled by Visual Studio if the user cancels the wizard.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        // The following IWizard methods are not implemented in this example.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

    }
}

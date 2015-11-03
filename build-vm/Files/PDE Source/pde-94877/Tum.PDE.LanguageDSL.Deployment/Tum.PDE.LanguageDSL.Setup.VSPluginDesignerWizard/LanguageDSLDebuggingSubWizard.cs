using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;

namespace Tum.PDE.LanguageDSL.Setup.VSPluginDesignerWizard
{
    public class LanguageDSLDebuggingSubWizard : IWizard
    {
        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            //replacementsDictionary.Add("$LanguageExtension$", LanguageDSLWizard.LanguageExtension);

            foreach (string key in LanguageDSLWizard.ReplacementsDictionaryCustom.Keys)
                replacementsDictionary.Add(key, LanguageDSLWizard.ReplacementsDictionaryCustom[key]);
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}

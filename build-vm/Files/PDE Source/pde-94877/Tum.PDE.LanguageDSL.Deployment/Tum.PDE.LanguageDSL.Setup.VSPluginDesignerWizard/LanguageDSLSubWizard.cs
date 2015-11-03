using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;

namespace Tum.PDE.LanguageDSL.Setup.VSPluginDesignerWizard
{
    public class LanguageDSLSubWizard : IWizard
    {
        string projectdir = null;

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
            foreach (string key in LanguageDSLWizard.ReplacementsDictionaryCustom.Keys)
            {
                replacementsDictionary.Add(key, LanguageDSLWizard.ReplacementsDictionaryCustom[key]);
            }
            replacementsDictionary["$safeprojectname$"] = LanguageDSLWizard.ProjectName;

            EnvDTE._DTE dte = automationObject as EnvDTE._DTE;
            string path = dte.Solution.Properties.Item("Path").Value.ToString();
            System.IO.FileInfo info = new System.IO.FileInfo(path);

            //this.projectdir = info.DirectoryName + System.IO.Path.DirectorySeparatorChar + LanguageDSLWizard.ProjectName + System.IO.Path.DirectorySeparatorChar + "VSPluginDSL" + System.IO.Path.DirectorySeparatorChar;
            this.projectdir = info.DirectoryName + System.IO.Path.DirectorySeparatorChar + LanguageDSLWizard.ProjectName + System.IO.Path.DirectorySeparatorChar;
            using (StrongNameKey strongNameKey = LanguageDSLWizard.GenerateKeyFile ? new StrongNameKey() : new StrongNameKey(LanguageDSLWizard.ExistingKeyFilePath))
            {
                strongNameKey.SaveTo(System.IO.Path.Combine(this.projectdir, "Key.snk"));
            }
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}

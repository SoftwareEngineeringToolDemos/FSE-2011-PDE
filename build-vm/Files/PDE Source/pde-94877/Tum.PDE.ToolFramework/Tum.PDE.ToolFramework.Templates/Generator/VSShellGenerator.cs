using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class VSShellGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new Shell.ConstantsGenerator(), "Constants.cs");
            this.Run(new Shell.DocDataGenerator(), "DocData.cs");
            this.Run(new Shell.DocViewGenerator(), "DocView.cs");
            this.Run(new Shell.EditorFactoryGenerator(), "EditorFactory.cs");
            this.Run(new Shell.PackageGenerator(), "Package.cs");
            this.Run(new Shell.PackageControllerGenerator(), "PackageController.cs");
            this.Run(new Shell.ToolWindowGenerator(), "ToolWindow.cs");

        }
    }
}

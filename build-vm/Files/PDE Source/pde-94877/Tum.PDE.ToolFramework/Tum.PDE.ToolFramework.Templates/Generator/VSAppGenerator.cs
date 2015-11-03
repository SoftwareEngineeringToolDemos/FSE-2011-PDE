using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Templates.ViewModel.WPFApplication;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class VSAppGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new Shell.ViewModel.WPFApplication.LayoutManagerDVGenerator(), "LayoutManagerDV.txt", T4Toolbox.BuildAction.EmbeddedResource);
            this.Run(new Shell.ViewModel.WPFApplication.LayoutManagerLayoutGenerator(), "LayoutManagerLayout.xml", T4Toolbox.BuildAction.EmbeddedResource);
            this.Run(new Shell.ViewModel.WPFApplication.UIGenerator(), "Ui.cs");
            this.Run(new ResourceDictionaryGenerator(), "UIResourceDictionary.xaml");
        }
    }
}

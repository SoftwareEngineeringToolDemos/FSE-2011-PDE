using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Templates.ViewModel.WPFApplication;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class DefaultAppGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new AppGenerator(), "App.cs");
            this.Run(new LayoutManagerDVGenerator(), "LayoutManagerDV.txt", T4Toolbox.BuildAction.EmbeddedResource);
            this.Run(new LayoutManagerLayoutGenerator(), "LayoutManagerLayout.xml", T4Toolbox.BuildAction.EmbeddedResource);
            this.Run(new UIGenerator(), "Ui.cs");
            this.Run(new ResourceDictionaryGenerator(), "UIResourceDictionary.xaml");
        }
    }
}

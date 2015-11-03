using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Templates.ViewModel.WPFApplication;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class LibraryAppGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new ResourceDictionaryGenerator(), "UIResourceDictionary.xaml");
        }
    }
}

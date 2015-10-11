using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL;

using Tum.PDE.ToolFramework.Templates.ViewModel;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class VSViewModelGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new DiagramItemViewModelGenerator(), "DiagramItemViewModel.cs");
            this.Run(new DiagramLinkViewModelGenerator(), "DiagramLinkViewModel.cs");
            this.Run(new DiagramViewModelGenerator(), "DiagramViewModel.cs");
            this.Run(new PropertyGridEditorViewModelGenerator(), "PropertyGridEditorViewModel.cs");
            this.Run(new PropertyGridViewModelGenerator(), "PropertyGridViewModel.cs");
            this.Run(new ServiceRegistrarGenerator(), "Services.cs");
            this.Run(new SpecificViewModelGenerator(), "SpecificViewModel.cs");
            this.Run(new TreeViewModelGenerator(), "TreeViewModel.cs");
            this.Run(new Shell.ViewModel.ViewModelGenerator(), "ViewModels.cs");
            this.Run(new ViewModelDataGenerator(), "ViewModelData.cs");
            this.Run(new ViewModelOptionsGenerator(), "ViewModelOptions.cs");
        }
    }
}

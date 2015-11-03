using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class SelectableViewModel : BaseModelElementViewModel
    {
        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public SelectableViewModel(ViewModelStore viewModelStore, ModelElement element)
            : base(viewModelStore, element, false)
        {
            
        }
    }
}

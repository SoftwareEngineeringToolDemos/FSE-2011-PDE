using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

using Microsoft.VisualStudio.Modeling;

namespace $safeprojectname$
{
    public class ExampleElementViewModel : BaseModelElementViewModel
    {
        /// <summary>
        /// Constructor. The view model constructed this way does not react on model changes, as such DoHookUpEvents is false.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public ExampleElementViewModel(ViewModelStore viewModelStore, DomainModelElement element)
            : base(viewModelStore, element)
        {
            LocalChildrenCount = element.GetLocalChildren().Count.ToString();
            ChildrenCount = element.GetChildren().Count.ToString();
        }

        public string LocalChildrenCount { get; private set; }
        public string ChildrenCount { get; private set; }
    }
}

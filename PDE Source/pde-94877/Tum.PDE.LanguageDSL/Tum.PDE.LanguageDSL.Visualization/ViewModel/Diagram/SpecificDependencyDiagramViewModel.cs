using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class SpecificDependencyDiagramViewModel : DependencyDiagramViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramClass">Element to be hosted by this view model.</param>
        public SpecificDependencyDiagramViewModel(ViewModelStore viewModelStore, DiagramClassView diagramClassView, DiagramViewModel parent)
            : base(viewModelStore, diagramClassView, parent)
        {
        }
    }
}

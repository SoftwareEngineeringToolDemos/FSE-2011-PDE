
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class DiagramClassSelectableViewModel : SelectableViewModel
    {
        private DiagramClass diagramClass;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public DiagramClassSelectableViewModel(ViewModelStore viewModelStore, DiagramClass element)
            : base(viewModelStore, element)
        {
            this.diagramClass = element;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public override string DomainElementName
        {
            get
            {
                return this.diagramClass.Title + " - " + this.diagramClass.Name;
            }
        }
    }
}

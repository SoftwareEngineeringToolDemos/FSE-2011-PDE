using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection
{
    public class MappingRelationshipShapeClassViewModel : SelectableViewModel
    {
        private MappingRelationshipShapeClass shapeClass;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public MappingRelationshipShapeClassViewModel(ViewModelStore viewModelStore, MappingRelationshipShapeClass element)
            : base(viewModelStore, element)
        {
            this.shapeClass = element;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public override string DomainElementName
        {
            get
            {
                return this.shapeClass.Name + " - " + this.shapeClass.DiagramClass.Name;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Base class representing a diagram item vm.
    /// </summary>
    public abstract class DiagramItemElementViewModel : BaseDiagramItemElementViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected DiagramItemElementViewModel(ViewModelStore viewModelStore, DiagramSurfaceViewModel diagram, NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }

        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        /// <remarks>
        /// Items need to delete their hosted element if they are themselves not directly hosted
        /// on the diagram's surface.
        /// </remarks>
        public override bool AutomaticallyDeletesHostedElement
        {
            get
            {
                return true;
            }
        }
    }
}

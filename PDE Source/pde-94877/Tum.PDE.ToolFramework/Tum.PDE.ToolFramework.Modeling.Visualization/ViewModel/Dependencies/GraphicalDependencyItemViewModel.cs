using System;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This view model is used for graphical dependencies shapes if there is no other shape available.
    /// </summary>
    public class GraphicalDependencyItemViewModel : DiagramItemElementViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GraphicalDependencyItemViewModel(ViewModelStore viewModelStore, GraphicalDependenciesViewModel diagram, NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }

        /// <summary>
        /// Gets the diagram this item belongs to.
        /// </summary>
        public new GraphicalDependenciesViewModel Diagram
        {
            get { return base.Diagram as GraphicalDependenciesViewModel; }
        }

        /// <summary>
        /// Never delete hosted element.
        /// </summary>
        public override bool AutomaticallyDeletesHostedElement
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        protected override void OnNestedChildShapeElementAdded(NodeShapeReferencesNestedChildren con)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        protected override void OnRelativeChildShapeElementAdded(NodeShapeReferencesRelativeChildren con)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// No relative children.
        /// </summary>
        public override bool CanHaveRelativeChildren
        {
            get { return false; }
        }

        /// <summary>
        /// No nested children.
        /// </summary>
        public override bool CanHaveNestedChildren
        {
            get { return false; }
        }
    }
}

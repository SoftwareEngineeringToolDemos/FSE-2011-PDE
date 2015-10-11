using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This view model represents a GraphicalDependencyLinkShape.
    /// </summary>
    public partial class GraphicalDependencyLinkViewModel : BaseDiagramItemLinkViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public GraphicalDependencyLinkViewModel(ViewModelStore viewModelStore, DiagramSurfaceViewModel diagram, GraphicalDependencyLinkShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
    }
}

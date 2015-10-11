using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This view model represents a GraphicalDependencyMainShape which is the main shape dependencies
    /// are centered around.
    /// </summary>
    public class GraphicalDependencyMainItemViewModel : GraphicalDependencyItemViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GraphicalDependencyMainItemViewModel(ViewModelStore viewModelStore, GraphicalDependenciesViewModel diagram, GraphicalDependencyMainShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
    }
}

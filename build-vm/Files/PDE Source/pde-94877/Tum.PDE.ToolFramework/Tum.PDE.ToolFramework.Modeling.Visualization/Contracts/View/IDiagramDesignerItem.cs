using Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View
{
    /// <summary>
    /// Interface describing a diagram designer item.
    /// </summary>
    public interface IDiagramDesignerItem
    {
        /// <summary>
        /// Gets the absolute location of this item (relative to the DiagramDesigner).
        /// </summary>
        PointD AbsoluteLocation { get; }

        /// <summary>
        /// Gets whether this element represents a diagram link or not.
        /// </summary>
        bool IsDiagramLink { get; }
    }
}

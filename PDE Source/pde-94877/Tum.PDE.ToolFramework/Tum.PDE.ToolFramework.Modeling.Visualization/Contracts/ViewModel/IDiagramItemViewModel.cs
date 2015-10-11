using System.Collections.Generic;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface describing a diagram item view model.
    /// </summary>
    public interface IDiagramItemViewModel
    {
        /// <summary>
        /// Gets the position (LEFT) of this item on the canvas.
        /// </summary>
        double Left
        {
            get;
        }

        /// <summary>
        /// Gets the position (TOP) of this item on the canvas.
        /// </summary>
        double Top
        {
            get;
        }

        /// <summary>
        /// Gets the width of the item.
        /// </summary>
        double Width
        {
            get;
        }

        /// <summary>
        /// Gets the height of the item.
        /// </summary>
        double Height
        {
            get;
        }

        /// <summary>
        /// Gets or sets the location of this item.
        /// </summary>
        PointD Location { get; set; }

        /// <summary>
        /// Gets or sets the absolute location of this item.
        /// </summary>
        PointD AbsoluteLocation { get; }

        /// <summary>
        /// Gets or sets the size of this item.
        /// </summary>
        SizeD Size { get; set; }

        /// <summary>
        /// Gets or sets the bounds of the current element.
        /// </summary>
        RectangleD Bounds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether this item is part of any relationship or not.
        /// </summary>
        bool TakesPartInRelationship { get; }

        /// <summary>
        /// Gets the resizing behaviour of the shape.
        /// </summary>
        ShapeResizingBehaviour ResizingBehaviour { get; }

        /// <summary>
        /// Gets the movement behaviour of the shape.
        /// </summary>
        ShapeMovementBehaviour MovementBehaviour { get; }

        /// <summary>
        /// Gets whether the shape is a relative child shape or not.
        /// </summary>
        bool IsRelativeChildShape { get; }

        /// <summary>
        /// Gets the parent item of this item. Can be null, which means, that this item is a root item on the diagram.
        /// </summary>
        /// <returns>Parent item or null.</returns>
        IDiagramItemViewModel GetParent();

        /// <summary>
        /// Gets the collection of nested children.
        /// </summary>
        /// <returns>Collection of nested children.</returns>
        IEnumerable<IDiagramItemViewModel> GetNestedChildren();

        /// <summary>
        /// Gets the collection of relative children.
        /// </summary>
        /// <returns>Collection of relative children.</returns>
        IEnumerable<IDiagramItemViewModel> GetRelativeChildren();

        /// <summary>
        /// Gets the size this element is placed on, if this is a relative child shape
        /// with MovementBehaviour set to PositionOnEdgeOfParent. Otherwise, throws
        /// an InvalidOperationException.
        /// </summary>
        PortPlacement GetPlacementSide();

        /// <summary>
        /// Gets the shape element, that is hosted by this view model.
        /// </summary>
        NodeShape ShapeElement { get; }
    }
}

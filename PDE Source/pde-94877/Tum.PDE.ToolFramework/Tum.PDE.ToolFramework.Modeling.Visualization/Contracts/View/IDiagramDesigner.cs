using System;
using Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View
{
    /// <summary>
    /// Interface describing a diagram designer.
    /// </summary>
    public interface IDiagramDesigner
    {
        /// <summary>
        /// Gets the current mouse position relative to the selected element.
        /// </summary>
        /// <returns>Mouse position relative to the selected element coordinates.</returns>
        PointD GetCurrentMousePositionOnSelectedElement();
        
        /// <summary>
        /// Gets the current mouse position relative to the diagram designer.
        /// </summary>
        /// <returns>Mouse position relative to the diagram designer coordinates.</returns>
        PointD GetCurrentMousePosition();

        /// <summary>
        /// Gets the item that is directly under the mouse.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <returns>Item under the mouse or null.</returns>
        object GetItemAtPosition(PointD position);
    }
}

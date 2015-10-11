using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface describing a diagram view model.
    /// </summary>
    public interface IDiagramViewModel
    {
        /// <summary>
        /// Gets the diagram designer.
        /// </summary>
        IDiagramDesigner DiagramDesigner { get; set; }

        /// <summary>
        /// Calculates the movement info for this item based on the proposed horizontal and vertical changes.
        /// </summary>
        /// <param name="selectedItems">Items to be moved.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        /// <returns>Calculated DiagramItemMovementInfo.</returns>
        DiagramItemsMovementInfo CalcMovementInfo(IEnumerable<IDiagramItemViewModel> selectedItems, double horizontalChange, double verticalChange);
       
        /// <summary>
        /// Calculates the resize info for this item based on the proposed horizontal and vertical changes.
        /// </summary>
        /// <param name="selectedItems">Items to be resized.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        /// <param name="direction">Direction in which to resize the elements.</param>
        /// <returns>Calculated DiagramItemsResizeInfo.</returns>
        DiagramItemsResizeInfo CalcResizeInfo(IEnumerable<IDiagramItemViewModel> selectedItems, double horizontalChange, double verticalChange, DiagramItemsResizeDirection direction);

        /// <summary>
        /// Moves the selected elements as specified by the given movement info.
        /// </summary>
        /// <param name="selectedItems">Selected items to move.</param>
        /// <param name="info">Movement info.</param>
        void MoveElements(IEnumerable<IDiagramItemViewModel> selectedItems, DiagramItemsMovementInfo info);

        /// <summary>
        /// Resizes the selected elements a specified by the given resize info.
        /// </summary>
        /// <param name="selectedItems">Selected items to resize.</param>
        /// <param name="info">Resize info.</param>
        void ResizeElements(IEnumerable<IDiagramItemViewModel> selectedItems, DiagramItemsResizeInfo info);

        /// <summary>
        /// Moves the selected link anchors in the direction of the proposed location.
        /// </summary>
        /// <param name="selectedItems">Selected links (source or target anchor to be move specified via bool) to move.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        void MoveLinkAnchors(Dictionary<IDiagramLinkViewModel, bool> selectedItems, double horizontalChange, double verticalChange);

        /// <summary>
        /// Moves the selected link anchors in the direction of the proposed location.
        /// </summary>
        /// <param name="selectedItem">Selected link.</param>
        /// <param name="anchorId">Anchor id.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        void MoveLinkAnchor(IDiagramLinkViewModel selectedItem, System.Guid anchorId, double horizontalChange, double verticalChange);

        /// <summary>
        /// Calculates a path geometry between the source and the target points.
        /// </summary>
        /// <param name="sourcePoint">Source point (Absolute location).</param>
        /// <param name="targetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <returns>Calculated path geometry.</returns>
        PathGeometry CalcPathGeometry(PointD sourcePoint, PointD targetPoint, FixedGeometryPoints fixedPoints);

        /// <summary>
        /// Calculates a path geometry between the source and the target point. 
        /// </summary>
        /// <param name="proposedSourcePoint">Source point (Absolute location).</param>
        /// <param name="targetItem">Target diagram item.</param>
        /// <param name="proposedTargetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <returns>Calculated path geometry.</returns>
        PathGeometry CalcPathGeometry(PointD proposedSourcePoint, IDiagramItemViewModel targetItem, PointD proposedTargetPoint, FixedGeometryPoints fixedPoints);

        /// <summary>
        /// Handles a key down event.
        /// </summary>
        /// <param name="e">Key down event args.</param>
        /// <returns>True if the key down event was handled.</returns>
        bool HandleKeyDown(KeyEventArgs e);
    }
}

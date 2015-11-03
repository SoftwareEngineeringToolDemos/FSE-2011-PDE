using Tum.PDE.ToolFramework.Modeling.Diagrams;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel
{
    /// <summary>
    /// Interface describing a diagram link view model.
    /// </summary>
    public interface IDiagramLinkViewModel
    {
        /// <summary>
        /// Gets the start edge point.
        /// </summary>
        IEdgePointViewModel StartEdgePoint
        {
            get;
        }

        /// <summary>
        /// Gets the end edge point.
        /// </summary>
        IEdgePointViewModel EndEdgePoint
        {
            get;
        }


        /// <summary>
        /// Gets or sets the routing mode.
        /// </summary>
        RoutingMode RoutingMode
        {
            get;
            set;
        }

        /// <summary>
        /// Calculates an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        PointD CalcFromAnchorPosition(double horizontalChange, double verticalChange);

        /// <summary>
        /// Calculates an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        PointD CalcToAnchorPosition(double horizontalChange, double verticalChange);

        /// <summary>
        /// Set an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        void SetFromAnchorPosition(double horizontalChange, double verticalChange);

        /// <summary>
        /// Set an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        void SetToAnchorPosition(double horizontalChange, double verticalChange);

        /// <summary>
        /// Set an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="anchorId"></param>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        void SetAnchorPosition(System.Guid anchorId, double horizontalChange, double verticalChange);

        /// <summary>
        /// Calculates a path geometry between the source and the target points.
        /// </summary>
        /// <param name="sourcePoint">Source point (Absolute location).</param>
        /// <param name="targetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <param name="routingMode">Routing mode.</param>
        /// <returns>Calculated path geometry.</returns>
        PathGeometry CalcPathGeometry(PointD sourcePoint, PointD targetPoint, FixedGeometryPoints fixedPoints, RoutingMode routingMode);

        /// <summary>
        /// Gets the shape element, that is hosted by this view model.
        /// </summary>
        LinkShape ShapeElement { get; }
    }
}

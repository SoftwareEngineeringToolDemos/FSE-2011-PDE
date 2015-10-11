using System;

using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;
using Tum.PDE.ToolFramework.Modeling.Diagrams.Layout;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class LinkShape
    {
        internal bool IsLayoutInProgress = false;
        private LinkPlacement linkPlacementStart;
        private LinkPlacement linkPlacementEnd;

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public LinkShape(Partition partition, params PropertyAssignment[] propertyAssignments)
        	: base(partition, propertyAssignments)
        {
            if( this.EdgePoints == null )
                this.EdgePoints = new EdgePointCollection();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public LinkShape(Store store, params PropertyAssignment[] propertyAssignments)
            : this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
        {
        }
        #endregion

        /// <summary>
        /// Gets the start point.
        /// </summary>
        public PointD StartPoint
        {
            get
            {
                return this.SourceAnchor.AbsoluteLocation;
            }
        }

        /// <summary>
        /// Gets the end point.
        /// </summary>
        public PointD EndPoint
        {
            get
            {
                return this.TargetAnchor.AbsoluteLocation;
            }
        }

        /// <summary>
        /// Gets the from shape.
        /// </summary>
        public NodeShape FromShape
        {
            get
            {
                if (this.SourceAnchor != null)
                    return this.SourceAnchor.FromShape;

                return null;
            }
        }

        /// <summary>
        /// Gets the to shape.
        /// </summary>
        public NodeShape ToShape
        {
            get
            {
                if (this.TargetAnchor != null)
                    return this.TargetAnchor.ToShape;

                return null;
            }
        }

        /// <summary>
        /// Sets a new start point.
        /// </summary>
        /// <param name="newStartPoint">New start point.</param>
        public void SetStartPoint(PointD newStartPoint)
        {
            if (this.SourceAnchor.AbsoluteLocation != newStartPoint)
            {
                if (!this.Store.InSerializationTransaction)
                    this.SourceAnchor.DiscardLocationChange = true;
                this.SourceAnchor.AbsoluteLocation = newStartPoint;
            }
        }

        /// <summary>
        /// Sets a new end point.
        /// </summary>
        /// <param name="newEndPoint">New end point.</param>
        public void SetEndPoint(PointD newEndPoint)
        {
            if (this.TargetAnchor.AbsoluteLocation != newEndPoint)
            {
                if (!this.Store.InSerializationTransaction)
                    this.TargetAnchor.DiscardLocationChange = true;
                this.TargetAnchor.AbsoluteLocation = newEndPoint;
            }
        }

        /// <summary>
        /// Gets or sets the link placement.
        /// </summary>
        public LinkPlacement LinkPlacementStart
        {
            get { return this.linkPlacementStart; }
            set
            {
                this.linkPlacementStart = value;
            }
        }

        /// <summary>
        /// Gets or sets the link placement.
        /// </summary>
        public LinkPlacement LinkPlacementEnd
        {
            get { return this.linkPlacementEnd; }
            set
            {
                this.linkPlacementEnd = value;
            }
        }

        /// <summary>
        /// Update link placement.
        /// </summary>
        public void UpdateLinkPlacement()
        {
            UpdateLinkPlacementStart();
            UpdateLinkPlacementTarget();
        }

        /// <summary>
        /// Update link placement start.
        /// </summary>
        public void UpdateLinkPlacementStart()
        {
            if (this.SourceAnchor != null)
            {
                if (this.SourceAnchor.FromShape != null)
                    LinkPlacementStart = GetLinkPlacement(this.SourceAnchor.FromShape.AbsoluteBounds, this.StartPoint);

                if (this.SourceAnchor.AbsoluteLocation != this.StartPoint)
                {
                    if( !this.Store.InSerializationTransaction )
                        this.SourceAnchor.DiscardLocationChange = true;
                    this.SourceAnchor.AbsoluteLocation = this.StartPoint;
                }
            }
        }

        /// <summary>
        /// Update link placement end.
        /// </summary>
        public void UpdateLinkPlacementTarget()
        {
            if (this.TargetAnchor != null)
            {
                if (this.TargetAnchor.ToShape != null)
                    LinkPlacementEnd = GetLinkPlacement(this.TargetAnchor.ToShape.AbsoluteBounds, this.EndPoint);

                if (this.TargetAnchor.AbsoluteLocation != this.EndPoint)
                {
                    if (!this.Store.InSerializationTransaction)
                        this.TargetAnchor.DiscardLocationChange = true;
                    this.TargetAnchor.AbsoluteLocation = this.EndPoint;
                }
            }
        }

        /// <summary>
        /// Update anchor placement.
        /// </summary>
        internal void UpdateAnchorPlacement()
        {
            if (this.EdgePoints.Count > 0)
            {
                EdgePoint start = this.EdgePoints[0];
                if (this.StartPoint != start.Point)
                {
                    this.SetStartPoint(start.Point);
                }

                EdgePoint end = this.EdgePoints[this.EdgePoints.Count-1];
                if (this.EndPoint != end.Point)
                {
                    this.SetEndPoint(end.Point);
                }
            }
        }
        
        /// <summary>
        /// Layouts this link shape.
        /// </summary>
        /// <param name="fixedPoints">Fixed points.</param>
        public virtual void Layout(FixedGeometryPoints fixedPoints)
        {
            if (this.IsDeleted || this.IsDeleting)
                return;

            if( fixedPoints == FixedGeometryPoints.None)
            {
                SetStartPoint(CalculateStartPoint());
                SetEndPoint(CalculateEndPoint());
                UpdateLinkPlacement();
            }
            else if (fixedPoints == FixedGeometryPoints.Source && this.EndPoint == PointD.Empty)
            {
                SetEndPoint(CalculateEndPoint());
                UpdateLinkPlacementTarget();
            }
            else if (fixedPoints == FixedGeometryPoints.Target && this.StartPoint == PointD.Empty)
            {
                SetStartPoint(CalculateStartPoint());
                UpdateLinkPlacementStart();
            }

            Layout(this.StartPoint, this.EndPoint, fixedPoints);
        }

        /// <summary>
        /// Layouts this link shape. Called from AnchorAbsoluteLocationChanged.
        /// </summary>
        /// <param name="fixedPoints">Fixed points.</param>
        internal virtual void InternalLayout(FixedGeometryPoints fixedPoints)
        {
            if (this.IsDeleted || this.IsDeleting)
                return;

            if (fixedPoints == FixedGeometryPoints.None)
            {
                SetStartPoint(CalculateStartPoint());
                SetEndPoint(CalculateEndPoint());
                UpdateLinkPlacement();
            }
            else if (fixedPoints == FixedGeometryPoints.Source && this.EndPoint == PointD.Empty)
            {
                SetEndPoint(CalculateEndPoint());
                UpdateLinkPlacementTarget();
            }
            else if (fixedPoints == FixedGeometryPoints.Target && this.StartPoint == PointD.Empty)
            {
                SetStartPoint(CalculateStartPoint());
                UpdateLinkPlacementStart();
            }

            Layout(this.StartPoint, this.EndPoint, fixedPoints);
        }

        /// <summary>
        /// Layouts this link shape.
        /// </summary>
        /// <param name="startPoint">Start point.</param>
        /// <param name="endPoint">End point.</param>
        /// <param name="fixedPoints">Fixed points.</param>
        public virtual void Layout(PointD startPoint, PointD endPoint, FixedGeometryPoints fixedPoints)
        {
            if (this.IsDeleted || this.IsDeleting)
                return;

            IsLayoutInProgress = true;

            EdgePointCollection colNew = new EdgePointCollection();
            colNew.AddRange(LayoutEdge(startPoint, endPoint));
            this.EdgePoints = colNew;

            if (colNew.Count > 0)
            {
                if (this.SourceAnchor != null)
                    if (this.StartPoint != this.EdgePoints[0].Point)
                    {
                        if (!this.Store.InSerializationTransaction)
                            this.SourceAnchor.DiscardLocationChange = true;
                        SetStartPoint(this.EdgePoints[0].Point);
                    }

                if (this.TargetAnchor != null)
                    if (this.EndPoint != this.EdgePoints[this.EdgePoints.Count - 1].Point)
                    {
                        if (!this.Store.InSerializationTransaction)
                            this.TargetAnchor.DiscardLocationChange = true;
                        SetEndPoint(this.EdgePoints[this.EdgePoints.Count - 1].Point);
                    }
            }
 
            UpdateLinkPlacement();
            IsLayoutInProgress = false;
        }

        /// <summary>
        /// Layouts the edge betweend the given points.
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        private EdgePointCollection LayoutEdge(PointD startPoint, PointD endPoint)
        {
            return this.LayoutEdge(startPoint, endPoint, this.RoutingMode);
        }

        /// <summary>
        /// Layouts the edge betweend the given points.
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="rMode">Routing mode.</param>
        /// <returns></returns>
        public virtual EdgePointCollection LayoutEdge(PointD startPoint, PointD endPoint, RoutingMode rMode)
        {
            EdgePointCollection points = new EdgePointCollection();
            if (rMode == RoutingMode.Orthogonal)
            {
                try
                {
                    // calculate points between start and end
                    List<PointD> calcPoints = OrthogonalEdgeRouter.GetConnectionLine(this, this.FromShape, startPoint, this.ToShape, endPoint);

                    foreach (PointD p in calcPoints)
                        points.Add(new EdgePoint(p.X, p.Y));
                }
                catch
                {
                    points.Add(new EdgePoint(startPoint));
                    points.Add(new EdgePoint(endPoint));
                }
            }
            else
            {
                points.Add(new EdgePoint(startPoint));
                points.Add(new EdgePoint(endPoint));
            }
            return points;
        }

        /// <summary>
        /// Layouts the edge betweend the given points. This method is used to calculate a path that is displayed
        /// when any of the anchors is changed (via drag&drop).
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="rMode">Routing mode. TODO: Not yet supported.</param>
        /// <returns></returns>
        public virtual EdgePointCollection CalcLayoutEdge(PointD startPoint, PointD endPoint, RoutingMode rMode)
        {
            EdgePointCollection points = new EdgePointCollection();
            /*if (rMode == RoutingMode.Orthogonal)
            {
                try
                {
                    // calculate points between start and end
                    List<PointD> calcPoints = OrthogonalEdgeRouter.GetConnectionLineSimple(this, this.FromShape, startPoint, this.ToShape, endPoint, GetLinkPlacement(this.ToShape.AbsoluteBounds, endPoint));

                    foreach (PointD p in calcPoints)
                        points.Add(new EdgePoint(p.X, p.Y));
                }
                catch
                {
                    points.Add(new EdgePoint(startPoint));
                    points.Add(new EdgePoint(endPoint));
                }
            }
            else
            {*/
                points.Add(new EdgePoint(startPoint));
                points.Add(new EdgePoint(endPoint));
            //}
            return points;
        }

        /// <summary>
        /// Calculates the start point for this edge.
        /// </summary>
        /// <returns>Start point.</returns>
        public virtual PointD CalculateStartPoint()
        {
            #region Check Variables
            if (SourceAnchor == null)
                throw new ArgumentNullException("SourceAnchor");

            if (SourceAnchor.FromShape == null)
                throw new ArgumentNullException("SourceAnchor.FromShape");
            #endregion

            RectangleD sourceBounds = this.SourceAnchor.FromShape.AbsoluteBounds;

            LinkPlacement placement = GetLinkPlacement(true);
            switch (placement)
            {
                case LinkPlacement.Left:
                    return new PointD(sourceBounds.Left, sourceBounds.Center.Y);

                case LinkPlacement.Right:
                    return new PointD(sourceBounds.Right, sourceBounds.Center.Y);

                case LinkPlacement.Bottom:
                    return new PointD(sourceBounds.Center.X, sourceBounds.Bottom);

                case LinkPlacement.Top:
                    return new PointD(sourceBounds.Center.X, sourceBounds.Top);

                default:
                    throw new NotSupportedException("placement");
            }
        }

        /// <summary>
        /// Calculates the end point for this edge.
        /// </summary>
        /// <returns>End point.</returns>
        public virtual PointD CalculateEndPoint()
        {
            #region Check Variables
            if (TargetAnchor == null)
                throw new ArgumentNullException("TargetAnchor");

            if (TargetAnchor.ToShape == null)
                throw new ArgumentNullException("TargetAnchor.ToShape");
            #endregion

            LinkPlacement placement;

            if (this.FromShape == this.ToShape)
            {
                LinkPlacement pStart = GetLinkPlacement(true);
                if (pStart == LinkPlacement.Bottom || pStart == LinkPlacement.Top)
                    placement = LinkPlacement.Right;
                else
                    placement = LinkPlacement.Top;
            }
            else
            {
                placement = GetLinkPlacement(false);
            }

            RectangleD targetBounds = this.TargetAnchor.ToShape.AbsoluteBounds;
            switch (placement)
            {
                case LinkPlacement.Left:
                    return new PointD(targetBounds.Left, targetBounds.Center.Y);

                case LinkPlacement.Right:
                    return new PointD(targetBounds.Right, targetBounds.Center.Y);

                case LinkPlacement.Bottom:
                    return new PointD(targetBounds.Center.X, targetBounds.Bottom);

                case LinkPlacement.Top:
                    return new PointD(targetBounds.Center.X, targetBounds.Top);

                default:
                    throw new NotSupportedException("placement");
            }
        }

        /// <summary>
        /// Calculates the link placement for start or end point.
        /// </summary>
        /// <param name="isStartPoint"></param>
        /// <returns></returns>
        private LinkPlacement GetLinkPlacement(bool isStartPoint)
        {
            RectangleD sourceBounds = this.SourceAnchor.FromShape.AbsoluteBounds;
            RectangleD targetBounds = this.TargetAnchor.ToShape.AbsoluteBounds;

            if (!isStartPoint)
            {
                sourceBounds = targetBounds;
                targetBounds = this.SourceAnchor.FromShape.AbsoluteBounds;
            }

            double horizontalDifference = Math.Abs(targetBounds.Left - sourceBounds.Left);
            double verticalDifference = Math.Abs(targetBounds.Top - sourceBounds.Top);

            if (sourceBounds.Left <= targetBounds.Left && sourceBounds.Top <= targetBounds.Top)
            {
                double horizontalDifferenceReal = targetBounds.Left - sourceBounds.Right;
                double verticalDifferenceReal = targetBounds.Top - sourceBounds.Bottom;

                if (horizontalDifferenceReal > 0 && verticalDifferenceReal > 0)
                {
                    horizontalDifference = horizontalDifferenceReal;
                    verticalDifference = verticalDifferenceReal;
                }

                if (horizontalDifference >= verticalDifference)
                    return LinkPlacement.Right;
                else
                    return LinkPlacement.Bottom;
            }
            else if (sourceBounds.Left <= targetBounds.Left && sourceBounds.Top > targetBounds.Top)
            {
                double horizontalDifferenceReal = targetBounds.Left - sourceBounds.Right;
                double verticalDifferenceReal = sourceBounds.Top - targetBounds.Bottom;

                if (horizontalDifferenceReal > 0 && verticalDifferenceReal > 0)
                {
                    horizontalDifference = horizontalDifferenceReal;
                    verticalDifference = verticalDifferenceReal;
                }

                if (horizontalDifference >= verticalDifference)
                    return LinkPlacement.Right;
                else
                    return LinkPlacement.Top;
            }
            else if (sourceBounds.Left > targetBounds.Left && sourceBounds.Top <= targetBounds.Top)
            {
                double horizontalDifferenceReal = sourceBounds.Left - targetBounds.Right;
                double verticalDifferenceReal = targetBounds.Top - sourceBounds.Bottom;

                if (horizontalDifferenceReal > 0 && verticalDifferenceReal > 0)
                {
                    horizontalDifference = horizontalDifferenceReal;
                    verticalDifference = verticalDifferenceReal;
                }

                if (horizontalDifference >= verticalDifference)
                    return LinkPlacement.Left;
                else
                    return LinkPlacement.Bottom;
            }
            else //if (sourceBounds.Left > targetBounds.Left && sourceBounds.Top > targetBounds.Top)
            {
                double horizontalDifferenceReal = sourceBounds.Left - targetBounds.Right;
                double verticalDifferenceReal = sourceBounds.Top - targetBounds.Bottom;

                if (horizontalDifferenceReal > 0 && verticalDifferenceReal > 0)
                {
                    horizontalDifference = horizontalDifferenceReal;
                    verticalDifference = verticalDifferenceReal;
                }

                if (horizontalDifference >= verticalDifference)
                    return LinkPlacement.Left;
                else
                    return LinkPlacement.Top;
            }
        }

        /// <summary>
        /// Gets the link placement based on the shape dimensions as well as the proposed location.
        /// </summary>
        /// <param name="shapeDimensions">Dimensions of the shape, this link start/end is created at.</param>
        /// <param name="proposedLocation">Proposed location of the link start/end.</param>
        /// <returns>LinkPlacement.</returns>
        public static LinkPlacement GetLinkPlacement(RectangleD shapeDimensions, PointD proposedLocation)
        {
            PointD pointD1 = new PointD(proposedLocation.X + 3.5 - shapeDimensions.Left, proposedLocation.Y + 3.5 - shapeDimensions.Top);
            PointD pointD2 = new PointD(shapeDimensions.Width / 2.0, shapeDimensions.Height / 2.0);
            double d1 = System.Math.Atan2(pointD2.Y, pointD2.X);
            double d2 = System.Math.Atan2(pointD1.Y - pointD2.Y, pointD1.X - pointD2.X);
            if ((d2 <= d1) && (d2 >= -d1))
                return LinkPlacement.Right;
            if ((d2 > d1) && (d2 < (Math.PI - d1)))
                return LinkPlacement.Bottom;
            if ((d2 > -(Math.PI - d1)) && (d2 < -d1))
                return LinkPlacement.Top;
            if ((d2 >= (Math.PI - d1)) || (d2 <= -(Math.PI - d1)))
                return LinkPlacement.Left;

            throw new System.InvalidOperationException();
        }

        /// <summary>
        /// Calculates a location based on the shape dimensions as well as the proposed location.
        /// </summary>
        /// <param name="shapeDimensions">Dimensions of the shape, this link start/end is created at.</param>
        /// <param name="proposedLocation">Proposed location of the link start/end.</param>
        /// <returns>Calculated location.</returns>
        public static PointD CalculateLocation(RectangleD shapeDimensions, PointD proposedLocation)
        {
            LinkPlacement placement = GetLinkPlacement(shapeDimensions, proposedLocation);
            return CalculateLocation(placement, shapeDimensions, proposedLocation);
        }

        /// <summary>
        /// Calculates a location based on the shape dimensions as well as the proposed location.
        /// </summary>
        /// <param name="placement">Link placement.</param>
        /// <param name="shapeDimensions">Dimensions of the shape, this link start/end is created at.</param>
        /// <param name="proposedLocation">Proposed location of the link start/end.</param>
        /// <returns>Calculated location.</returns>
        public static PointD CalculateLocation(LinkPlacement placement, RectangleD shapeDimensions, PointD proposedLocation)
        {
            double x = proposedLocation.X;
            double y = proposedLocation.Y;

            double itemWidth = 7;
            double itemHeight = 7;

            switch (placement)
            {
                case LinkPlacement.Left:
                    x = shapeDimensions.Left - itemWidth;
                    if (y <= (shapeDimensions.Top - itemHeight))
                        y = shapeDimensions.Top - itemHeight;
                    else if (y > shapeDimensions.Bottom)
                        y = shapeDimensions.Bottom;
                    break;

                case LinkPlacement.Top:
                    y = shapeDimensions.Top - itemHeight;
                    if (x <= (shapeDimensions.Left - itemWidth))
                        x = shapeDimensions.Left - itemWidth;
                    else if (x > shapeDimensions.Right)
                        x = shapeDimensions.Right;
                    break;

                case LinkPlacement.Right:
                    x = shapeDimensions.Right + 3.4 * 2;
                    if (y <= (shapeDimensions.Top - itemHeight))
                        y = shapeDimensions.Top - itemHeight;
                    else if (y > shapeDimensions.Bottom)
                        y = shapeDimensions.Bottom;
                    break;

                case LinkPlacement.Bottom:
                    y = shapeDimensions.Bottom + 3.4 * 2;
                    if (x <= (shapeDimensions.Left - itemWidth))
                        x = shapeDimensions.Left - itemWidth;
                    else if (x > shapeDimensions.Right)
                        x = shapeDimensions.Right;
                    break;
            }

            return new PointD(x, y);
        }

    }
}

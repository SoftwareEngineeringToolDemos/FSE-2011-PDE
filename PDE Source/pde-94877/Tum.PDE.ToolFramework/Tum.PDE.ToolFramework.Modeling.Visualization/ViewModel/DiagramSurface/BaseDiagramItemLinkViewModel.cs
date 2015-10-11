using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;
using System.Collections.ObjectModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// Base abstract class for a diagram link vm.
    /// </summary>
    public abstract class BaseDiagramItemLinkViewModel : BaseDiagramItemViewModel, IDiagramLinkViewModel
    {
        PathGeometry pathGeometry;

        PointD fromAnchorPosition = PointD.Empty;
        PointD toAnchorPosition = PointD.Empty;

        double fromAnchorAngle = 0;
        double toAnchorAngle = 0;

        ObservableCollection<EdgePointViewModel> edgePointsVM;


        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="linkShape">Linkshape to be associated with this vm.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected BaseDiagramItemLinkViewModel(ViewModelStore viewModelStore, DiagramSurfaceViewModel diagram, LinkShape linkShape)
            : base(viewModelStore, diagram, linkShape)
        {
            this.Geometry = ConvertEdgePointsToGeometry(linkShape.EdgePoints);
            this.edgePointsVM = new ObservableCollection<EdgePointViewModel>();

            UpdateEdgePoints();

            Subscribe();
        }

        /// <summary>
        /// Gets the path geometry for this link.
        /// </summary>
        public PathGeometry Geometry
        {
            get
            {
                return this.pathGeometry;
            }
            protected set
            {
                this.pathGeometry = value;
                UpdateAnchorPoints();
                OnPropertyChanged("Geometry");
            }
        }

        /// <summary>
        /// Gets the edge points.
        /// </summary>
        public ObservableCollection<EdgePointViewModel> EdgePoints
        {
            get
            {
                return edgePointsVM;
            }
        }

        /// <summary>
        /// Update anchor points. Called after source or target was moved.
        /// </summary>
        protected virtual void UpdateAnchorPoints()
        {
            if (this.ShapeElement.EdgePoints.Count == 0)
            {
                this.fromAnchorPosition = PointD.Empty;
                this.toAnchorPosition = PointD.Empty;
            }
            else
            {
                this.fromAnchorPosition = new PointD(this.ShapeElement.EdgePoints[0].X, this.ShapeElement.EdgePoints[0].Y);
                this.toAnchorPosition = new PointD(this.ShapeElement.EdgePoints[this.ShapeElement.EdgePoints.Count - 1].X,
                                                   this.ShapeElement.EdgePoints[this.ShapeElement.EdgePoints.Count - 1].Y);
            }

            UpdateEdgePoints();

            try
            {
                Point pathStartPoint, pathTangentAtStartPoint;
                Point pathEndPoint, pathTangentAtEndPoint;
                Point pathMidPoint, pathTangentAtMidPoint;

                // the PathGeometry.GetPointAtFractionLength method gets the point and a tangent vector 
                // on PathGeometry at the specified fraction of its length
                this.Geometry.GetPointAtFractionLength(0, out pathStartPoint, out pathTangentAtStartPoint);
                this.Geometry.GetPointAtFractionLength(1, out pathEndPoint, out pathTangentAtEndPoint);
                this.Geometry.GetPointAtFractionLength(0.5, out pathMidPoint, out pathTangentAtMidPoint);

                // get angle from tangent vector
                this.FromAnchorAngle = Math.Atan2(-pathTangentAtStartPoint.Y, -pathTangentAtStartPoint.X) * (180 / Math.PI);
                this.ToAnchorAngle = Math.Atan2(pathTangentAtEndPoint.Y, pathTangentAtEndPoint.X) * (180 / Math.PI);
            }
            catch
            {
                this.FromAnchorAngle = 0.0;
                this.ToAnchorAngle = 0.0;
            }
        }

        /// <summary>
        /// Updates edge points.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected virtual void UpdateEdgePoints()
        {
            if (EdgePoints == null)
                this.edgePointsVM = new ObservableCollection<EdgePointViewModel>();

            EdgePoints.Clear();
            for (int i = 0; i < this.ShapeElement.EdgePoints.Count; i++)
            {
                EdgePointVMType t = EdgePointVMType.Normal;
                if (i == 0)
                    t = EdgePointVMType.Start;
                else if (i == this.ShapeElement.EdgePoints.Count - 1)
                    t = EdgePointVMType.End;
                else
                    continue;   // TODO

                EdgePointViewModel vm = new EdgePointViewModel(this.ViewModelStore, this.ShapeElement.EdgePoints[i], t);
                if (i > 0 && i < this.ShapeElement.EdgePoints.Count - 1)
                {
                    //vm.EdgePointOperation = EdgePointVMOperation.m
                }
                else
                {
                    RectangleD bounds;
                    if (t == EdgePointVMType.Start)
                        bounds = this.ShapeElement.FromShape.AbsoluteBounds;
                    else
                        bounds = this.ShapeElement.ToShape.AbsoluteBounds;

                    EdgePoint p = this.ShapeElement.EdgePoints[i];
                    LinkPlacement placement = LinkShape.GetLinkPlacement(bounds, new PointD(p.X, p.Y));
                    switch (placement)
                    {
                        case LinkPlacement.Bottom:
                            vm.EdgePointSide = EdgePointVMSide.Bottom;
                            break;

                        case LinkPlacement.Left:
                            vm.EdgePointSide = EdgePointVMSide.Left;
                            break;

                        case LinkPlacement.Right:
                            vm.EdgePointSide = EdgePointVMSide.Right;
                            break;

                        case LinkPlacement.Top:
                            vm.EdgePointSide = EdgePointVMSide.Top;
                            break;
                    }
                }
                EdgePoints.Add(vm);
            }

            OnPropertyChanged("EdgePoints");
            OnPropertyChanged("StartEdgePoint");
            OnPropertyChanged("EndEdgePoint");
            OnPropertyChanged("MiddleEdgePoint");
        }

        /// <summary>
        /// Gets or sets the shape element, that is hosted by this view model.
        /// </summary>
        public new LinkShape ShapeElement
        {
            get { return base.ShapeElement as LinkShape; }
            set
            {
                base.ShapeElement = value;
            }
        }

        #region IDiagramLinkViewModel
        /// <summary>
        /// Gets the start edge point.
        /// </summary>
        public IEdgePointViewModel StartEdgePoint
        {
            get
            {
                if (this.EdgePoints.Count > 0)
                    return this.EdgePoints[0];

                throw new InvalidOperationException("StartEdgePoint can not be null");
            }
        }

        /// <summary>
        /// Gets the start edge point.
        /// </summary>
        public IEdgePointViewModel MiddleEdgePoint
        {
            get
            {
                if (this.EdgePoints.Count == 0)
                    throw new InvalidOperationException("MiddleEdgePoint can not be null");

                // TODO: http://msdn.microsoft.com/de-de/magazine/dd263097.aspx
                Point pathMidPoint, pathTangentAtMidPoint;
                this.Geometry.GetPointAtFractionLength(0.5, out pathMidPoint, out pathTangentAtMidPoint);

                return new EdgePointViewModel(this.ViewModelStore,
                            new EdgePoint(pathMidPoint.X, pathMidPoint.Y, EdgePointType.Normal), EdgePointVMType.Normal);
                /*
                if( this.EdgePoints.Count == 1 )
                    return this.EdgePoints[0];

                if (this.EdgePoints.Count % 2 == 1)
                    return this.EdgePoints[(this.EdgePoints.Count - 1) / 2];
                else
                {
                    IEdgePointViewModel edge1 = this.EdgePoints[this.EdgePoints.Count / 2 - 1];
                    IEdgePointViewModel edge2 = this.EdgePoints[this.EdgePoints.Count / 2];

                    // change to work by length ...

                    if (edge1.X == edge2.X && edge1.Y != edge2.Y)
                    {
                        return new EdgePointViewModel(this.ViewModelStore,
                            new EdgePoint((edge1.X + edge2.X) / 2.0, edge1.Y, EdgePointType.Normal), EdgePointVMType.Normal);
                    }
                    else if (edge1.X != edge2.X && edge1.Y == edge2.Y)
                    {
                        return new EdgePointViewModel(this.ViewModelStore,
                            new EdgePoint(edge1.X, (edge1.Y + edge2.Y) / 2.0, EdgePointType.Normal), EdgePointVMType.Normal);
                    }
                    else
                        return new EdgePointViewModel(this.ViewModelStore, 
                            new EdgePoint((edge1.X + edge2.X) / 2.0, (edge1.Y + edge2.Y) / 2.0, EdgePointType.Normal), EdgePointVMType.Normal);
                }
                */
            }
        }

        /// <summary>
        /// Gets the end edge point.
        /// </summary>
        public IEdgePointViewModel EndEdgePoint
        {
            get
            {
                if (this.EdgePoints.Count > 0)
                    return this.EdgePoints[this.EdgePoints.Count-1];

                throw new InvalidOperationException("EndEdgePoint can not be null");
            }
        }

        /// <summary>
        /// Gets or sets the from anchor angle.
        /// </summary>
        public double FromAnchorAngle
        {
            get
            {
                return this.fromAnchorAngle;
            }
            set
            {
                this.fromAnchorAngle = value;
                OnPropertyChanged("FromAnchorAngle");
            }
        }

        /// <summary>
        /// Gets or sets the to anchor angle.
        /// </summary>
        public double ToAnchorAngle
        {
            get
            {
                return this.toAnchorAngle;
            }
            set
            {
                this.toAnchorAngle = value;
                OnPropertyChanged("ToAnchorAngle");
            }
        }

        /// <summary>
        /// Calculates an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        public virtual PointD CalcFromAnchorPosition(double horizontalChange, double verticalChange)
        {
            PointD proposedPoint = new PointD(this.StartEdgePoint.X + horizontalChange, this.StartEdgePoint.Y + verticalChange);

            return LinkShape.CalculateLocation(this.ShapeElement.FromShape.AbsoluteBounds, proposedPoint);
        }

        /// <summary>
        /// Calculates an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        public virtual PointD CalcToAnchorPosition(double horizontalChange, double verticalChange)
        {
            PointD proposedPoint = new PointD(this.EndEdgePoint.X + horizontalChange, this.EndEdgePoint.Y + verticalChange);

            return LinkShape.CalculateLocation(this.ShapeElement.ToShape.AbsoluteBounds, proposedPoint);
        }

        /// <summary>
        /// Set an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        public virtual void SetFromAnchorPosition(double horizontalChange, double verticalChange)
        {
            PointD proposedPoint = new PointD(this.StartEdgePoint.X + horizontalChange, this.StartEdgePoint.Y + verticalChange);
            LinkPlacement placement = LinkShape.GetLinkPlacement(this.ShapeElement.FromShape.AbsoluteBounds, proposedPoint);

            PointD calculatedLocation = LinkShape.CalculateLocation(placement, this.ShapeElement.FromShape.AbsoluteBounds, proposedPoint);
            if( this.ShapeElement.StartPoint != calculatedLocation )
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move From Anchor"))
                {
                    this.ShapeElement.LinkPlacementStart = placement;
                    this.ShapeElement.SetStartPoint(calculatedLocation);
                    this.ShapeElement.Layout(FixedGeometryPoints.Source);

                    transaction.Commit();
                }
        }

        /// <summary>
        /// Set an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        public virtual void SetToAnchorPosition(double horizontalChange, double verticalChange)
        {
            PointD proposedPoint = new PointD(this.EndEdgePoint.X + horizontalChange, this.EndEdgePoint.Y + verticalChange);
            LinkPlacement placement = LinkShape.GetLinkPlacement(this.ShapeElement.ToShape.AbsoluteBounds, proposedPoint);

            PointD calculatedLocation = LinkShape.CalculateLocation(placement, this.ShapeElement.ToShape.AbsoluteBounds, proposedPoint);
            if( this.ShapeElement.EndPoint != calculatedLocation )
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move To Anchor"))
                {
                    this.ShapeElement.LinkPlacementEnd = placement;
                    this.ShapeElement.SetEndPoint(calculatedLocation);
                    this.ShapeElement.Layout(FixedGeometryPoints.Target);

                    transaction.Commit();
                }
        }

        /// <summary>
        /// Set an anchor position based on a horizontal and verical changes proposed.
        /// </summary>
        /// <param name="anchorId"></param>
        /// <param name="horizontalChange">Horizontal change.</param>
        /// <param name="verticalChange">Vertical change.</param>
        /// <returns>Calculated position.</returns>
        public virtual void SetAnchorPosition(Guid anchorId, double horizontalChange, double verticalChange)
        {
            foreach (EdgePointViewModel p in this.EdgePoints)
                if (p.EdgeId == anchorId)
                {
                    if (p.EdgePointType == EdgePointVMType.Start)
                        SetFromAnchorPosition(horizontalChange, verticalChange);
                    else if (p.EdgePointType == EdgePointVMType.End)
                        SetToAnchorPosition(horizontalChange, verticalChange);
                    else
                    {
                        // TODO
                    }
                }

        }

        /// <summary>
        /// Calculates a path geometry between the source and the target points.
        /// </summary>
        /// <param name="sourcePoint">Source point (Absolute location).</param>
        /// <param name="targetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <param name="routingMode">Routing mode.</param>
        /// <returns>Calculated path geometry.</returns>
        public virtual PathGeometry CalcPathGeometry(PointD sourcePoint, PointD targetPoint, FixedGeometryPoints fixedPoints, RoutingMode routingMode)
        {
            // fixedPoints: not required yet...
            EdgePointCollection col = this.ShapeElement.CalcLayoutEdge(sourcePoint, targetPoint, routingMode);

            PathGeometry geometry = new PathGeometry();

            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(col[0].X, col[0].Y);

            List<System.Windows.Point> points = new List<System.Windows.Point>();
            for (int i = 1; i < col.Count; i++)
            {
                points.Add(new System.Windows.Point(col[i].X, col[i].Y));
            }
            figure.Segments.Add(new PolyLineSegment(points, true));
            geometry.Figures.Add(figure);

            return geometry;
        }
        #endregion

        /// <summary>
        /// Gets wheter this shape can be moved in the UI.
        /// </summary>
        public virtual bool IsUIFixedPosition
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Converts a collection of edge points to the corresponding path geometry.
        /// </summary>
        /// <param name="edgePoints">Collection of edge points.</param>
        /// <returns>Path geometry.</returns>
        protected virtual PathGeometry ConvertEdgePointsToGeometry(EdgePointCollection edgePoints)
        {
            PathGeometry geometry = new PathGeometry();

            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(edgePoints[0].X, edgePoints[0].Y);
            
            List<System.Windows.Point> points = new List<System.Windows.Point>();
            for(int i = 1; i < edgePoints.Count; i++ )
            {
                points.Add(new System.Windows.Point(edgePoints[i].X, edgePoints[i].Y));
            }
            figure.Segments.Add(new PolyLineSegment(points, true));
            geometry.Figures.Add(figure);

            return geometry;
        }

        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        /// <remarks>Links are required to delete model elements if they are deleted.</remarks>
        public override bool AutomaticallyDeletesHostedElement
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Called whenever the edge point collection changes.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnEdgePointsChanged(ElementPropertyChangedEventArgs args)
        {
            if (this.ShapeElement != null && this.ShapeElement.EdgePoints != null)
            {
                if (this.ShapeElement.IsDeleted || this.ShapeElement.IsDeleting)
                    return;
                Geometry = ConvertEdgePointsToGeometry(this.ShapeElement.EdgePoints);
            }
        }

        /// <summary>
        /// Gets or sets the routing mode.
        /// </summary>
        public RoutingMode RoutingMode
        {
            get
            {
                return this.ShapeElement.RoutingMode;
            }
            set
            {
                if (this.RoutingMode != value)
                {
                    using (Transaction t = this.Store.TransactionManager.BeginTransaction("Change routing mode."))
                    {
                        this.ShapeElement.RoutingMode = value;

                        t.Commit();
                    }
                }
            }
        }

        /// <summary>
        /// Subscribes to events for the current hosted diagram.
        /// </summary>
        protected virtual void Subscribe()
        {
            // subscribe to property changed events
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(LinkShape.EdgePointsDomainPropertyId), this.ShapeElement.Id, OnEdgePointsChanged);
        }

        /// <summary>
        /// Unsubscribes from events for the current hosted diagram.
        /// </summary>
        protected virtual void Unsubscribe()
        {
            // unsubscribe from property changed events
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(LinkShape.EdgePointsDomainPropertyId), this.ShapeElement.Id, OnEdgePointsChanged);
        }
    }
}

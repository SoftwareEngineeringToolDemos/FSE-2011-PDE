using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;
using System.Drawing;
using Tum.PDE.ToolFramework.Modeling.Diagrams.Layout;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Node shape class.
    /// </summary>
    public partial class NodeShape
    {
        private Dictionary<Guid, List<Guid>> shapeMapping = new Dictionary<Guid, List<Guid>>();

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public NodeShape(Store store, params PropertyAssignment[] propertyAssignments)
        	: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NodeShape(Partition partition, params PropertyAssignment[] propertyAssignments)
        	: base(partition, propertyAssignments)
        {
            bool bHandledSize = false;
            bool bHandledLocation = false;
            bool bHandledAbsoluteLocation = false;

            if (propertyAssignments != null)
                foreach (PropertyAssignment propertyAssignment in propertyAssignments)
                {
                    if (propertyAssignment.PropertyId == NodeShape.SizeDomainPropertyId)
                        bHandledSize = true;
                    else if (propertyAssignment.PropertyId == NodeShape.LocationDomainPropertyId)
                        bHandledLocation = true;
                    else if (propertyAssignment.PropertyId == NodeShape.AbsoluteLocationDomainPropertyId)
                        bHandledAbsoluteLocation = true;
                }

            if (!bHandledSize)
                this.Size = this.DefaultSize;
            if (!bHandledLocation)
                this.Location = PointD.Empty;
            if (!bHandledAbsoluteLocation)
                this.AbsoluteLocation = PointD.Empty;
        }
        #endregion

        /// <summary>
        /// Gets the port placement based on the parent and child shapes bounds.
        /// </summary>
        /// <param name="parentShapeDimensions"></param>
        /// <param name="childShapeRelativeBounds"></param>
        /// <returns></returns>
        /// <remarks>Source: Dsl-Tools Diagrams</remarks>
        public static PortPlacement GetPortPlacement(RectangleD parentShapeDimensions, RectangleD childShapeRelativeBounds)
        {
            PointD pointD1 = new PointD(childShapeRelativeBounds.X + (childShapeRelativeBounds.Width / 2.0), childShapeRelativeBounds.Y + (childShapeRelativeBounds.Height / 2.0));
            PointD pointD2 = new PointD(parentShapeDimensions.Width / 2.0, parentShapeDimensions.Height / 2.0);
            double d1 = System.Math.Atan2(pointD2.Y, pointD2.X);
            double d2 = System.Math.Atan2(pointD1.Y - pointD2.Y, pointD1.X - pointD2.X);
            if ((d2 <= d1) && (d2 >= -d1))
                return PortPlacement.Right;
            if ((d2 > d1) && (d2 < (Math.PI - d1)))
                return PortPlacement.Bottom;
            if ((d2 > -(Math.PI - d1)) && (d2 < -d1))
                return PortPlacement.Top;
            if ((d2 >= (Math.PI - d1)) || (d2 <= -(Math.PI - d1)))
                return PortPlacement.Left;

            throw new System.InvalidOperationException();
        }

        /// <summary>
        /// This function corrects the given proposed location if the given child shape is a relative shape and
        /// is only allowed to be placed on the edge of its parent.
        /// </summary>
        /// <param name="parentShape">Parent shape.</param>
        /// <param name="childShape">Child shape.</param>
        /// <param name="proposedLocation">Proposed location.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// 
        /// This function assigns new values to Location and PortPlacement if necessary.
        /// </remarks>
        /// <returns>
        /// Location that was assigned to the shape. It might have the same value as the location 
        /// the shape had before calling this function.
        /// </returns>
        public static PointD CorrectPortLocation(NodeShape parentShape, NodeShape childShape, PointD proposedLocation)
        {
            if (parentShape == null)
                throw new ArgumentNullException("parentShape");

            if (childShape == null)
                throw new ArgumentNullException("childShape");

            if (!childShape.IsRelativeChildShape || childShape.MovementBehaviour != ShapeMovementBehaviour.PositionOnEdgeOfParent)
                return proposedLocation;

            RectangleD rectParent = parentShape.Bounds;
            RectangleD proposedBounds = new RectangleD(proposedLocation, childShape.Size);

            PortPlacement placement = NodeShape.GetPortPlacement(rectParent, proposedBounds);
            
            return CorrectPortLocation(placement, parentShape, childShape, proposedLocation);
        }
        
        /// <summary>
        /// This function corrects the given proposed location if the given child shape is a relative shape and
        /// is only allowed to be placed on the edge of its parent.
        /// </summary>
        /// <param name="placement">Proposed placement.</param>
        /// <param name="parentShape">Parent shape.</param>
        /// <param name="childShape">Child shape.</param>
        /// <param name="proposedLocation">Proposed location.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// 
        /// This function assigns new values to Location and PortPlacement if necessary.
        /// </remarks>
        /// <returns>
        /// Location that was assigned to the shape. It might have the same value as the location 
        /// the shape had before calling this function.
        /// </returns>
        public static PointD CorrectPortLocation(PortPlacement placement, NodeShape parentShape, NodeShape childShape, PointD proposedLocation)
        {
            PointD newLocation = proposedLocation;
            RectangleD rectParent = parentShape.Bounds;

            switch (placement)
            {
                case PortPlacement.Left:
                    newLocation.X = -childShape.Size.Width / 2.0;
                    if (newLocation.Y < 0.0)
                        newLocation.Y = 0.0;
                    else if (newLocation.Y > (rectParent.Height - childShape.Size.Height))
                        newLocation.Y = rectParent.Height - childShape.Size.Height;
                    break;

                case PortPlacement.Top:
                    newLocation.Y = -childShape.Size.Height / 2.0;
                    if (newLocation.X < 0.0)
                        newLocation.X = 0.0;
                    else if (newLocation.X > (rectParent.Width - childShape.Size.Width))
                        newLocation.X = rectParent.Width - childShape.Size.Width;
                    break;

                case PortPlacement.Right:
                    newLocation.X = rectParent.Width - (childShape.Size.Width / 2.0);
                    if (newLocation.Y < 0.0)
                        newLocation.Y = 0.0;
                    else if (newLocation.Y > (rectParent.Height - childShape.Size.Height))
                        newLocation.Y = rectParent.Height - childShape.Size.Height;
                    break;

                case PortPlacement.Bottom:
                    newLocation.Y = rectParent.Height - (childShape.Size.Height / 2.0);
                    if (newLocation.X < 0.0)
                        newLocation.X = 0.0;
                    else if (newLocation.X > (rectParent.Width - childShape.Size.Width))
                        newLocation.X = rectParent.Width - childShape.Size.Width;
                    break;
            }

            if (childShape.Location != newLocation)
            {
                childShape.Location = newLocation;
                childShape.PlacementSide = placement;
                childShape.UpdateAbsoluteLocation();
            }

            return newLocation;
        }

        /// <summary>
        /// Gets the absolute bounds of this item.
        /// </summary>
        public RectangleD AbsoluteBounds
        {
            get { return new RectangleD(this.AbsoluteLocation, this.Size); }
        }

        /// <summary>
        /// Gets the bounds of this item.
        /// </summary>
        public RectangleD Bounds
        {
            get { return new RectangleD(this.Location, this.Size); }
        }

        /// <summary>
        /// Gets the default size of the shape.
        /// </summary>
        public virtual SizeD DefaultSize
        {
            get
            {
                return new SizeD(50, 50);
            }
        }

        /// <summary>
        /// Gets the list of outgoing link shapes.
        /// </summary>
        public List<LinkShape> OutgoingLinkShapes
        {
            get
            {
                List<LinkShape> shapes = new List<LinkShape>();
                foreach (SourceAnchor anchor in this.SourceAnchors)
                    shapes.Add(anchor.LinkShape);

                return shapes;
            }
        }

        /// <summary>
        /// Gets the list of incoming link shapes.
        /// </summary>
        public List<LinkShape> IncomingLinkShapes
        {
            get
            {
                List<LinkShape> shapes = new List<LinkShape>();
                foreach (TargetAnchor anchor in this.TargetAnchors)
                    shapes.Add(anchor.LinkShape);

                return shapes;
            }
        }

        /// <summary>
        /// Gets a read-only collection of children.
        /// </summary>
        public ReadOnlyLinkedElementCollection<NodeShape> Children
        {
            get
            {
                return this.InternalChildren.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets if this shape is a top most item.
        /// </summary>
        public virtual bool IsTopMostItem { get{ return false;} }

        /// <summary>
        /// Adds a nested child.
        /// </summary>
        /// <param name="shape">Shape to add as a nested child.</param>
        public void AddNestedChild(NodeShape shape)
        {
            this.InternalChildren.Add(shape);
            this.NestedChildren.Add(shape);
        }

        /// <summary>
        /// Adds a relative child.
        /// </summary>
        /// <param name="shape">Shape to add as a relative child.</param>
        public void AddRelativeChild(NodeShape shape)
        {
            this.InternalChildren.Add(shape);
            this.RelativeChildren.Add(shape);
        }

        /// <summary>
        /// Corret link shapes placement.
        /// </summary>
        /// <param name="parentLocationOld"></param>
        /// <param name="parentLocationNew"></param>
        public void CorrectLinkShapesOnParentChanged(PointD parentLocationOld, PointD parentLocationNew)
        {
            CorrectLinkShapesOnLocationChanged(parentLocationOld, parentLocationNew);
        }

        /// <summary>
        /// Corret link shapes placement.
        /// </summary>
        /// <param name="locationOld"></param>
        /// <param name="locationNew"></param>
        internal void CorrectLinkShapesOnLocationChanged(PointD locationOld, PointD locationNew)
        {
            //double horizontalChange = locationNew.X - locationOld.X;
            //double verticalChange = locationNew.Y - locationOld.Y;

            //List<LinkShape> shapesToLayout = new List<LinkShape>();
            foreach (SourceAnchor anchor in this.SourceAnchors)
            {
                if (anchor.IsDeleted || anchor.IsDeleting)
                    continue;

                double hor = anchor.AbsoluteLocation.X - locationOld.X;
                double vert = anchor.AbsoluteLocation.Y - locationOld.Y;

                anchor.AbsoluteLocation = new PointD(locationNew.X + hor, locationNew.Y + vert);
                //if (!shapesToLayout.Contains(anchor.LinkShape))
                //    shapesToLayout.Add(anchor.LinkShape);
                //anchor.AbsoluteLocation = new PointD(anchor.AbsoluteLocation.X + horizontalChange, anchor.AbsoluteLocation.Y + verticalChange);
            }

            foreach (TargetAnchor anchor in this.TargetAnchors)
            {
                if (anchor.IsDeleted || anchor.IsDeleting)
                    continue;

                double hor = anchor.AbsoluteLocation.X - locationOld.X;
                double vert = anchor.AbsoluteLocation.Y - locationOld.Y;

                anchor.AbsoluteLocation = new PointD(locationNew.X + hor, locationNew.Y + vert);
                //if (!shapesToLayout.Contains(anchor.LinkShape))
                //    shapesToLayout.Add(anchor.LinkShape);

                //anchor.AbsoluteLocation = new PointD(anchor.AbsoluteLocation.X + horizontalChange, anchor.AbsoluteLocation.Y + verticalChange);
            }

            CorrectChildLinkShapesOnLocationChanged(locationOld, locationNew);

            //foreach (LinkShape s in shapesToLayout)
            //    s.Layout(FixedGeometryPoints.SourceAndTarget);
        }

        /// <summary>
        /// Corret link shapes placement.
        /// </summary>
        /// <param name="locationOld"></param>
        /// <param name="locationNew"></param>
        internal void CorrectChildLinkShapesOnLocationChanged(PointD locationOld, PointD locationNew)
        {
            foreach (NodeShape shape in this.NestedChildren)
                shape.CorrectLinkShapesOnLocationChanged(locationOld, locationNew);

            foreach (NodeShape shape in this.RelativeChildren)
                shape.CorrectLinkShapesOnLocationChanged(locationOld, locationNew);
        }

        /// <summary>
        /// Corret link shapes placement.
        /// </summary>
        /// <param name="sizeOld"></param>
        /// <param name="sizeNew"></param>
        internal void CorrectLinkShapesOnSizeChanged(SizeD sizeOld, SizeD sizeNew)
        {
            // List<LinkShape> shapesToLayout = new List<LinkShape>();

            double widthChange = (sizeNew.Width - sizeOld.Width);
            double heightChange = (sizeNew.Height - sizeOld.Height);

            double widthFactor = sizeNew.Width / sizeOld.Width;
            double heightFactor = sizeNew.Height / sizeOld.Height;
   
            foreach (SourceAnchor anchor in this.SourceAnchors)
            {
                if (anchor.FromShape == null)
                    continue;

                if (anchor.IsDeleted || anchor.IsDeleting)
                    continue;

                NodeShape shape = anchor.FromShape;
                LinkShape linkShape = anchor.LinkShape;

                double newLeft = (anchor.AbsoluteLocation.X - shape.AbsoluteLocation.X) * widthFactor + shape.AbsoluteLocation.X;
                double newTop = (anchor.AbsoluteLocation.Y - shape.AbsoluteLocation.Y) * heightFactor + shape.AbsoluteLocation.Y;

                if (linkShape.LinkPlacementStart == LinkPlacement.Bottom)
                {
                    anchor.AbsoluteLocation = new PointD(newLeft, anchor.AbsoluteLocation.Y + heightChange);
                }
                else if (linkShape.LinkPlacementStart == LinkPlacement.Top)
                {
                    anchor.AbsoluteLocation = new PointD(newLeft, anchor.AbsoluteLocation.Y);
                }
                else if (linkShape.LinkPlacementStart == LinkPlacement.Right)
                {
                    anchor.AbsoluteLocation = new PointD(anchor.AbsoluteLocation.X + widthChange, newTop);
                }
                else if (linkShape.LinkPlacementStart == LinkPlacement.Left)
                {
                    anchor.AbsoluteLocation = new PointD(anchor.AbsoluteLocation.X, newTop);
                }

                //if (!shapesToLayout.Contains(anchor.LinkShape))
                //    shapesToLayout.Add(anchor.LinkShape);
            }

            foreach (TargetAnchor anchor in this.TargetAnchors)
            {
                if (anchor.ToShape == null)
                    continue;

                if (anchor.IsDeleted || anchor.IsDeleting)
                    continue;

                NodeShape shape = anchor.ToShape;
                LinkShape linkShape = anchor.LinkShape;

                double newLeft = (anchor.AbsoluteLocation.X - shape.AbsoluteLocation.X) * widthFactor + shape.AbsoluteLocation.X;
                double newTop = (anchor.AbsoluteLocation.Y - shape.AbsoluteLocation.Y) * heightFactor + shape.AbsoluteLocation.Y;

                if (linkShape.LinkPlacementEnd == LinkPlacement.Bottom)
                {
                    anchor.AbsoluteLocation = new PointD(newLeft, anchor.AbsoluteLocation.Y + heightChange);
                }
                else if (linkShape.LinkPlacementEnd == LinkPlacement.Top)
                {
                    anchor.AbsoluteLocation = new PointD(newLeft, anchor.AbsoluteLocation.Y);
                }
                else if (linkShape.LinkPlacementEnd == LinkPlacement.Right)
                {
                    anchor.AbsoluteLocation = new PointD(anchor.AbsoluteLocation.X + widthChange, newTop);
                }
                else if (linkShape.LinkPlacementEnd == LinkPlacement.Left)
                {
                    anchor.AbsoluteLocation = new PointD(anchor.AbsoluteLocation.X, newTop);
                }

                //if (!shapesToLayout.Contains(anchor.LinkShape))
                //   shapesToLayout.Add(anchor.LinkShape);
            }

            //foreach (LinkShape s in shapesToLayout)
            //    s.Layout(FixedGeometryPoints.SourceAndTarget);
        }

        /// <summary>
        /// Updates the absolute location of this shape and its child shapes.
        /// </summary>
        internal void UpdateAbsoluteLocation()
        {
            PointD location = new PointD(0, 0);
            NodeShape shape = this;
            while (shape != null)
            {
                location.X += shape.Location.X;
                location.Y += shape.Location.Y;

                shape = shape.Parent;
            }

            PointD oldAbsoluteLocation = this.AbsoluteLocation;
            UpdateAbsoluteLocation(location.X - this.AbsoluteLocation.X, location.Y - this.AbsoluteLocation.Y);
        }

        /// <summary>
        /// Updates the absolute location of this shape and its child shapes.
        /// </summary>
        /// <param name="xChange"></param>
        /// <param name="yChange"></param>
        internal void UpdateAbsoluteLocation(double xChange, double yChange)
        {
            this.AbsoluteLocation = new PointD(this.AbsoluteLocation.X + xChange, this.AbsoluteLocation.Y + yChange);

            foreach (NodeShape childShape in this.NestedChildren)
                childShape.UpdateAbsoluteLocation(xChange, yChange);

            foreach (NodeShape childShape in this.RelativeChildren)
                childShape.UpdateAbsoluteLocation(xChange, yChange);
        }

        /// <summary>
        /// This function corrects the assigned location if this shape is a relative shape and
        /// is only allowed to be placed on the edge of its parent.
        /// </summary>
        /// <remarks>
        /// This function needs to be called within a modeling transaction.
        /// </remarks>
        public virtual void CorrectLocation()
        {
            if (this.IsRelativeChildShape && this.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent && this.Parent != null)
            {
                PointD locationOld = this.AbsoluteLocation;
                CorrectPortLocation(this.Parent, this, this.Location);
                if (locationOld != this.AbsoluteLocation)
                {
                    List<LinkShape> linkShapes = new List<LinkShape>();
                    foreach (SourceAnchor anchor in this.SourceAnchors)
                        linkShapes.Add(anchor.LinkShape);
                    foreach (TargetAnchor anchor in this.TargetAnchors)
                        if( !linkShapes.Contains(anchor.LinkShape) )
                            linkShapes.Add(anchor.LinkShape);

                    this.CorrectLinkShapesOnLocationChanged(locationOld, this.AbsoluteLocation);

                    foreach (LinkShape l in linkShapes)
                        l.Layout(FixedGeometryPoints.SourceAndTarget);
                }
            }
        }

        /// <summary>
        /// Tries to find a free position on parent and update the location of the shape to that location.
        /// </summary>
        /// <returns>
        /// Coordinates of a free position.
        /// </returns>
        /// <remarks>
        /// Needs to be called within a modeling transaction.
        /// </remarks>
        public virtual void SetAtFreePositionOnParent()
        {
            NodePlacementHelper.SetAtFreePositionOnParent(this);
        }

        /*
        /// <summary>
        /// Tries to find a free position on parent and update the location of the shape to that location.
        /// </summary>
        /// <returns>
        /// Coordinates of a free position.
        /// </returns>
        /// <remarks>
        /// Needs to be called within a modeling transaction.
        /// </remarks>
        public virtual void SetAtFreePositionOnParent()
        {
            IList<NodeShape> shapes;
            if (this.Parent == null)
            {
                // free position on diagram
                Diagram diagram = this.Diagram;
                shapes = diagram.Children;
            }
            else
            {
                if (this.IsRelativeChildShape)
                {
                    float width = (float)this.Bounds.Width;
                    float height = (float)this.Bounds.Height;

                    float parentWidth = (float)this.Parent.Bounds.Width;
                    float parentHeight = (float)this.Parent.Bounds.Height;

                    Dictionary<PortPlacement, int> dict = new Dictionary<PortPlacement, int>();
                    dict.Add(PortPlacement.Left, 0);
                    dict.Add(PortPlacement.Top, 0);
                    dict.Add(PortPlacement.Bottom, 0);
                    dict.Add(PortPlacement.Right, 0);
                    for (int i = 0; i < this.Parent.RelativeChildren.Count; i++)
                    {
                        if (this.Parent.RelativeChildren[i] == this)
                            continue;

                        dict[this.Parent.RelativeChildren[i].PlacementSide]++;
                    }
                    List<KeyValuePair<PortPlacement, int>> myList = new List<KeyValuePair<PortPlacement, int>>(dict);
                    myList.Sort((firstPair, nextPair) =>
                    {
                        return firstPair.Value.CompareTo(nextPair.Value);
                    });

                    foreach (KeyValuePair<PortPlacement, int> p in myList)
                    {
                        RectangleF rectH;
                        switch (p.Key)
                        {
                            case PortPlacement.Left:
                                rectH = new RectangleF(-width / 2, 0, width, parentHeight);
                                break;

                            case PortPlacement.Top:
                                rectH = new RectangleF(0, -height / 2, parentWidth, height);
                                break;

                            case PortPlacement.Right:
                                rectH = new RectangleF(parentWidth - width / 2, 0, width, parentHeight);
                                break;

                            case PortPlacement.Bottom:
                                rectH = new RectangleF(0, parentHeight - height / 2, parentWidth, height);
                                break;

                            default:
                                throw new NotSupportedException();
                        }

                        if (SetPortAtFreePositionOnParent(p.Key, rectH))
                        {
                            return;
                        }
                    }

                    this.SetLocation(NodeShape.CorrectPortLocation(this.Parent, this, new PointD(0, 0)));
                    return;
                }

                // free position on parent shape
                shapes = this.Parent.NestedChildren;
            }            

            // trivial algo.. TODO: find something good
            RectangleF rect = new RectangleF(0, 0, (float)this.Size.Width, (float)this.Size.Height);

            // find area that is already filled
            RectangleF completeBounds = new RectangleF(0, 0, 0, 0);
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] == this)
                    continue;

                if (i == 0)
                    completeBounds = shapes[i].Bounds.ToRectangleF();
                else 
                {
                    RectangleF f = shapes[i].Bounds.ToRectangleF();
                    if (completeBounds.X > f.X)
                        completeBounds.X = f.X;
                    if (completeBounds.Y > f.Y)
                        completeBounds.Y = f.Y;
                    
                    if (completeBounds.Right < f.Right)
                        completeBounds.Width = f.Right - completeBounds.X;

                    if (completeBounds.Bottom < f.Bottom)
                        completeBounds.Height = f.Bottom - completeBounds.Y;
                }
            }

            /*
            // see if we can insert shape somewhere in that area
            // if not, add shape right at the edge of that area
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] == this)
                    continue;

                // TODO ... (not necessaraly required)
            }

            // could not add shape in the completeBounds are, so add it outside of it
            */
        /*
            if( completeBounds.Width < completeBounds.Height )
                this.SetLocation(new PointD(completeBounds.Right + 5, 5));
            else
                this.SetLocation(new PointD(5, completeBounds.Bottom + 5));
            this.UpdateAbsoluteLocation();
        }

        private bool SetPortAtFreePositionOnParent(PortPlacement side, RectangleF freeRectangle)
        {
            List<RectangleF> freeRectangles = new List<RectangleF>();
            freeRectangles.Add(freeRectangle);

            for (int i = 0; i < this.Parent.RelativeChildren.Count; i++)
            {
                if (this.Parent.RelativeChildren[i] == this)
                    continue;

                if (this.Parent.RelativeChildren[i].PlacementSide != side)
                    continue;

                RectangleF s = this.Parent.RelativeChildren[i].Bounds.ToRectangleF();
                for (int y = freeRectangles.Count - 1; y >= 0; y--)
                {
                    RectangleF r = freeRectangles[y];
                    RectangleF t = r;
                    r.Intersect(s);

                    if (!r.IsEmpty)
                    {
                        // remove r from freeRectangley[y] --> yields <=2 rects
                        // add 2 rects to freeRectangles
                        freeRectangles.RemoveAt(y);

                        switch (side)
                        {
                            case PortPlacement.Left:
                            case PortPlacement.Right:
                                if (t.Y < r.Y)
                                {
                                    // first r
                                    RectangleF r1 = new RectangleF(t.X, t.Y, t.Width, r.Y - t.Y);
                                    freeRectangles.Add(r1);
                                }

                                if (r.Bottom < t.Bottom)
                                {
                                    // second r
                                    RectangleF r2 = new RectangleF(t.X, r.Bottom, t.Width, t.Bottom - r.Bottom);
                                    freeRectangles.Add(r2);
                                }
                                break;

                            case PortPlacement.Top:
                            case PortPlacement.Bottom:
                                if (t.X < r.X)
                                {
                                    // first r
                                    RectangleF r1 = new RectangleF(t.X, t.Y, r.X-t.X, t.Height);
                                    freeRectangles.Add(r1);
                                }

                                if (r.Right < t.Right)
                                {
                                    // second r
                                    RectangleF r2 = new RectangleF(r.Right, t.Y, t.Right-r.Right, t.Height);
                                    freeRectangles.Add(r2);
                                }
                                break;
                        }

                    }
                }
            }

            // try to place at a fitting free rectangle
            foreach (RectangleF r in freeRectangles)
            {
                if (r.Width >= this.Bounds.Width && r.Height >= this.Bounds.Height)
                {
                    this.Location = new PointD(r.X, r.Y);
                    this.PlacementSide = side;
                    this.UpdateAbsoluteLocation();
                    return true;
                }
            }

            return false;
        }
        */

        /// <summary>
        /// Create missing shapes.
        /// </summary>
        public virtual void FixUpMissingShapes()
        {
            if (this.Element == null)
                return;

            DomainModelElement e = this.Element as DomainModelElement;

            IDomainModelServices topMost = e.GetDomainModelServices().TopMostService;
            DiagramDomainDataDirectory data = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();

            List<EmbeddingRelationshipAdvancedInfo> infos = this.Store.DomainDataAdvDirectory.FindDomainClassSourceEmbeddings(e.GetDomainClassId());
            if( infos != null )
                foreach (EmbeddingRelationshipAdvancedInfo info in infos)
                {
                    List<Guid> shapes = data.GetShapeTypesForElement(info.TargetElementDomainClassId);
                    if( shapes == null )
                        continue;
                    if( shapes.Count == 0 )
                        continue;

                    ReadOnlyCollection<ElementLink> instances = DomainRoleInfo.GetElementLinks<ElementLink>(this.Element, info.SourceRoleId);
                    foreach (ElementLink link in instances)
                    {
                        DomainModelElement child = DomainRoleInfo.GetTargetRolePlayer(link) as DomainModelElement;
                        if (child == null)
                            continue;

                        // see if we need to add shape
                        foreach (Guid elementShapeId in data.GetShapeTypesForElement(child.GetDomainClassId(), this.GetDomainClassId()))
                        {
                            if (!DiagramHelper.IsElementDisplayedOn(this, elementShapeId, child.Id))
                            {
                                NodeShape shape = topMost.ShapeProvider.CreateShapeForElement(elementShapeId, child) as NodeShape;
                                if (shape.IsRelativeChildShape)
                                    this.AddRelativeChild(shape);
                                else
                                    this.AddNestedChild(shape);

                                shape.FixUpMissingShapes();
                            }
                        }
                    }
                }
        }

        /// <summary>
        /// Creates missing links.
        /// </summary>
        public virtual void FixUpMissingLinkShapes()
        {
            if (this.Diagram == null)
                return;

            this.Diagram.FixUpMissingLinkShapes(this);
        }

        /// <summary>
        /// Verifies if the current shape can host a shape of a specific type.
        /// </summary>
        /// <param name="nodeShapeDomainClassId">Type of the shape specified by the domain class ID.</param>
        /// <returns>True if that specific type of shapes can be hosted by this shape. False otherwise.</returns>
        public virtual bool CanHostShape(Guid nodeShapeDomainClassId)
        {
            DiagramDomainDataDirectory data = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
            if (data == null)
                throw new ArgumentNullException("DiagramDomainDataDirectory can not be null");

            List<Guid> vals = data.GetChildrenShapeTypes(this.GetDomainClass().Id);
            if (vals.Contains(nodeShapeDomainClassId))
                return true;

            return false;
        }

        /// <summary>
        /// Sets the size of this item and propagates it to the hosted shape element if allowed.
        /// </summary>
        /// <param name="newWidth">Size to apply.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void SetSize(SizeD newSize)
        {
            SizeD oldSize = this.Size;
            this.Size = newSize;

            UpdateAbsoluteLocation();
            ResizeParentIfRequired();

            // for children: we need to change position if they are left of right side of this shape
            foreach(NodeShape shape in this.RelativeChildren )
            {
                if (shape.MovementBehaviour == ShapeMovementBehaviour.PositionRelativeToParent)
                {
                    PointD newPosition = new PointD(shape.Location.X, shape.Location.Y);
                    if (newPosition.X >= oldSize.Width)
                        newPosition.X += this.Size.Width - oldSize.Width;
                    if (newPosition.Y >= oldSize.Height)
                        newPosition.Y += this.Size.Height - oldSize.Height;

                    shape.SetLocationOnParentChange(newPosition);
                }
                else if (shape.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                {
                    if (newSize.Width != oldSize.Width && shape.PlacementSide == PortPlacement.Right)
                        shape.SetLocationOnParentChange(shape.Location);
                    else if (newSize.Height != oldSize.Height && shape.PlacementSide == PortPlacement.Bottom)
                        shape.SetLocationOnParentChange(shape.Location);
                }
            }

            if (this.IsRelativeChildShape)
                if (this.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                {
                    // size of this element changed, need to reposition it on the edge of the parent element
                    this.SetLocationOnParentChange(this.Location);
                }
        }

        /// <summary>
        /// Sets the location of this item and propagates it to the hosted shape element if allowed.
        /// </summary>
        /// <param name="proposedLocation">Location to apply.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void SetLocation(PointD proposedLocation)
        {
            SetLocation(proposedLocation, true);
        }

        /// <summary>
        /// Sets the location of this item and propagates it to the hosted shape element if allowed.
        /// </summary>
        /// <param name="proposedLocation">Location to apply.</param>
        /// <param name="bResizeParentIfRequired">Resize parent if required.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void SetLocation(PointD proposedLocation, bool bResizeParentIfRequired)
        {
            PointD newLocation = proposedLocation;
            if (this.IsRelativeChildShape)
                // correct the proposed location
                if (this.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                {
                    if (this.Parent != null)
                    {
                        newLocation = NodeShape.CorrectPortLocation(this.Parent, this, proposedLocation);
                    }
                }

            PointD oldLocation = this.Location;
            this.Location = newLocation;

            this.UpdateAbsoluteLocation();

            if( bResizeParentIfRequired )
                this.ResizeParentIfRequired();
        }

        /// <summary>
        /// Sets the location of this item and propagates it to the hosted shape element if allowed.
        /// </summary>
        /// <param name="proposedLocation">Location to apply.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void SetLocationOnParentChange(PointD proposedLocation)
        {
            PointD newLocation = proposedLocation;
            if (this.IsRelativeChildShape)
                // correct the proposed location
                if (this.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                {
                    if (this.Parent != null)
                    {
                        newLocation = NodeShape.CorrectPortLocation(this.PlacementSide, this.Parent, this, proposedLocation);
                    }
                }

            PointD oldLocation = this.Location;
            this.Location = newLocation;

            this.UpdateAbsoluteLocation();
            this.ResizeParentIfRequired();
        }

        /// <summary>
        /// Resizes the parent of this item if this is required.
        /// </summary>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void ResizeParentIfRequired()
        {
            if (this.Parent != null && !this.IsRelativeChildShape)
            {
                RectangleD bounds = this.Bounds;
                SizeD parentSize = this.Parent.Size;

                SizeD size = new SizeD(
                    Math.Max(parentSize.Width, bounds.Right),
                    Math.Max(parentSize.Height, bounds.Bottom));

                if (parentSize.Width < size.Width || parentSize.Height < size.Height)
                {
                    this.Parent.SetSize(
                        new SizeD(this.Parent.Size.Width + (size.Width - parentSize.Width) + 3.0,
                                  this.Parent.Size.Height + (size.Height - parentSize.Height) + 3.0));
                }
            }
        }

        /// <summary>
        /// Correct the children elements.
        /// </summary>
        public virtual bool CorrectChildren()
        {
            bool bRet = false;
            for (int i = this.Children.Count - 1; i >= 0; i--)
            {
                NodeShape shape = this.Children[i];
                if (!this.CanHostShape(shape.GetDomainClassId()))
                {
                    shape.Delete();
                    bRet = true;
                }
                else
                {
                    if (shape.IsRelativeChildShape && !this.RelativeChildren.Contains(shape))
                    {
                        if (this.NestedChildren.Contains(shape))
                            this.NestedChildren.Remove(shape);
                        this.RelativeChildren.Add(shape);
                    }
                    else if (!shape.IsRelativeChildShape && !this.NestedChildren.Contains(shape))
                    {
                        if (this.RelativeChildren.Contains(shape))
                            this.RelativeChildren.Remove(shape);
                        this.NestedChildren.Add(shape);
                    }

                    shape.CorrectChildren();
                }                
            }
            return bRet;
        }
    }
}

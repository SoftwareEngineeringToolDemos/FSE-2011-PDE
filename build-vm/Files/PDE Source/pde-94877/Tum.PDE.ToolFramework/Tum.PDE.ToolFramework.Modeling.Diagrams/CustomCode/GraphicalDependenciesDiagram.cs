using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class GraphicalDependenciesDiagram
    {
        private const double SourceMarginLeft = 15.0;
        private const double TargetMarginLeft = 85.0;
        private const double MarginRight = 30.0;
        private const double MarginMainElementLeft = 85.0;
        private const double MarginMainElementTop = 85.0;

        private const double MarginMainNoElementLeft = 15.0;
        private const double MarginMainNoElementTop = 15.0;

        private const double VerticalSpaceBetweenElements = 15.0;
        private const double MarginTopStart = 5.0;
        private const double MarginTopEnd = 5.0;

        private const double ChildMarginLeft = 15.0;
        private const double ChildMarginTopStart = 15.0;

        private const double RelationshipNameSpace = 25.0;
        
        private const double LinkAnchorMargin = 5.0;

        private static bool SubscribedToDeleteEvent = false;

        /// <summary>
        /// GraphicalDependenciesDiagram domain class Id.
        /// </summary>
        public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x05507902, 0x864b, 0x41c9, 0x93, 0xa9, 0x12, 0xac, 0x60, 0x56, 0x57, 0x8f);
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public GraphicalDependenciesDiagram(Store store, params PropertyAssignment[] propertyAssignments)
        	: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public GraphicalDependenciesDiagram(Partition partition, params PropertyAssignment[] propertyAssignments)
        	: base(partition, propertyAssignments)
        {
            if (SubscribedToDeleteEvent == false)
            {
                SubscribedToDeleteEvent = true;
                this.Store.EventManagerDirectory.ElementDeleted.Add(new EventHandler<ElementDeletedEventArgs>(OnElementDeleted));
            }
        }

        /// <summary>
        /// Called whenever a model element is deleted from the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the removal of an ModelElement.</param>
        private void OnElementDeleted(object sender, ElementDeletedEventArgs args)
        {
            if (args.ModelElement is DomainModelElement)
            {
                DomainModelElement modelElement = args.ModelElement as DomainModelElement;

                List<Guid> shapes = GraphicalDependencyShapeStore.GetFromStore(modelElement.Id);
                if (shapes != null)
                    if (shapes.Count > 0)
                    {
                        modelElement.Store.UndoManager.UndoState = UndoState.DisabledNoFlush;
                        using (Transaction t = modelElement.Store.TransactionManager.BeginTransaction("", true))
                        {

                            for (int i = shapes.Count - 1; i >= 0; i--)
                            {
                                ShapeElement shape = modelElement.Store.ElementDirectory.FindElement(shapes[i]) as ShapeElement;
                                if (shape != null)
                                    shape.Delete();
                            }
                            t.Commit();
                        }
                        modelElement.Store.UndoManager.UndoState = UndoState.Enabled;
                        GraphicalDependencyShapeStore.RemoveFromStore(modelElement.Id);
                    }
            }
        }

        /// <summary>
        /// Layouts the diagram.
        /// </summary>
        public virtual void Layout()
        {
            RectangleD rectSource = new RectangleD(new PointD(0, 0), new SizeD(0, 0));
            RectangleD rectTarget = new RectangleD(new PointD(0, 0), new SizeD(0, 0));

            double maineElementTop = 0.0;
            double maineElementLeft = MarginMainElementLeft;
            double maineElementLeftTemp = 0.0;

            if (this.SourceDependencyShapes.Count == 0)
                maineElementLeft = MarginMainNoElementLeft;

            for (int i = 0; i < this.SourceDependencyShapes.Count; i++)
            {
                GraphicalDependencyShape shape = this.SourceDependencyShapes[i];
                UpdateShapeLayout(shape);

                rectSource.Width += shape.Size.Width;
                rectSource.Height += shape.Size.Height + VerticalSpaceBetweenElements;

                if (shape.Size.Width > maineElementLeftTemp)
                    maineElementLeftTemp = shape.Size.Width;
            }
            for (int i = 0; i < this.TargetDependencyShapes.Count; i++)
            {
                GraphicalDependencyShape shape = this.TargetDependencyShapes[i];
                UpdateShapeLayout(shape);

                rectTarget.Width += shape.Size.Width;
                rectTarget.Height += shape.Size.Height + VerticalSpaceBetweenElements;
            }

            if (this.SourceDependencyShapes.Count == 0 && this.TargetDependencyShapes.Count == 0)
            {
                this.MainElementShape.SetLocation(
                       new PointD(MarginMainNoElementLeft, MarginMainNoElementTop));
            }
            else
            {
                // position elements
                if (rectSource.Height > rectTarget.Height)
                {
                    // first source element is positioned at 0,0 (+margins)
                    // first target element is poisitioned at (rectSource.Height - rectTaget.Height)/2.0
                    // following elements are positioned at *prev element height* + margin

                    double start = (rectSource.Height - rectTarget.Height) / 2.0 + MarginTopStart;
                    double x = maineElementLeft + maineElementLeftTemp + this.MainElementShape.Size.Width + TargetMarginLeft;
                    for (int i = 0; i < this.TargetDependencyShapes.Count; i++)
                    {
                        double y = this.TargetDependencyShapes[i].Size.Height;
                        this.TargetDependencyShapes[i].SetLocation(new PointD(x, start));
                        start = start + y + VerticalSpaceBetweenElements;
                    }

                    start = MarginTopStart;
                    x = SourceMarginLeft;
                    for (int i = 0; i < this.SourceDependencyShapes.Count; i++)
                    {
                        double y = this.SourceDependencyShapes[i].Size.Height;
                        this.SourceDependencyShapes[i].SetLocation(new PointD(x, start));
                        start = start + y + VerticalSpaceBetweenElements;
                    }

                    maineElementTop = rectSource.Height / 2.0 - this.MainElementShape.Size.Height / 2.0 + MarginTopStart;
                }
                else
                {
                    // first target element is positioned at 0,0 (+margins)
                    // first source element is poisitioned at (rectTaget.Height - rectSource.Height)/2.0
                    // following elements are positioned at *prev element height* + margin

                    double start = (rectTarget.Height - rectSource.Height) / 2.0 + MarginTopStart;
                    double x = SourceMarginLeft;
                    for (int i = 0; i < this.SourceDependencyShapes.Count; i++)
                    {
                        double y = this.SourceDependencyShapes[i].Size.Height;
                        this.SourceDependencyShapes[i].SetLocation(new PointD(x, start));
                        start = start + y + VerticalSpaceBetweenElements;
                    }

                    start = MarginTopStart;
                    x = maineElementLeft + maineElementLeftTemp + this.MainElementShape.Size.Width + TargetMarginLeft;
                    for (int i = 0; i < this.TargetDependencyShapes.Count; i++)
                    {
                        double y = this.TargetDependencyShapes[i].Size.Height;
                        this.TargetDependencyShapes[i].SetLocation(new PointD(x, start));
                        start = start + y + VerticalSpaceBetweenElements;
                    }

                    maineElementTop = rectTarget.Height / 2.0 - this.MainElementShape.Size.Height / 2.0 + MarginTopStart;
                }

                this.MainElementShape.SetLocation(
                    new PointD(maineElementLeft + maineElementLeftTemp, maineElementTop));
                
                UpdateLinkShapePositions();
            }
        }

        /// <summary>
        /// Layouts the diagram.
        /// </summary>
        /// <param name="dWidth">Diagram width.</param>
        /// <param name="dWidth">Diagram height.</param>
        public virtual void Layout(double dWidth, double dHeight)
        {
            double diagramWidth = dWidth;
            double diagramHeight = dHeight;
            double minWidth = 150.0 + MarginMainElementLeft * 2;
            double minHeight = 150.0 + MarginMainNoElementTop * 2;

            double maxElementWidth = diagramWidth - 150.0;

            if (this.SourceDependencyShapes.Count > 0)
            {
                minWidth += 150.0;
                maxElementWidth -= MarginMainElementLeft;
            }

            if (this.TargetDependencyShapes.Count > 0)
            {
                minWidth += 150.0;
                maxElementWidth -= TargetMarginLeft;
            }

            if (this.SourceDependencyShapes.Count > 0 && this.TargetDependencyShapes.Count > 0)
                maxElementWidth /= 2.0;

            if (diagramWidth < minWidth)
                diagramWidth = minWidth;

            if (diagramHeight < minHeight)
                diagramHeight = minHeight;

            // position main element
            if (this.SourceDependencyShapes.Count > 0 && this.TargetDependencyShapes.Count > 0)
            {
                MainElementShape.SetLocation(new PointD(
                    diagramWidth / 2.0 - MainElementShape.Size.Width / 2.0,
                    diagramHeight / 2.0 - MainElementShape.Size.Height / 2.0));
            }

            double widthLeft = 0;
            double widthRight = 0;

            double start = MarginTopStart;
            for (int i = 0; i < this.SourceDependencyShapes.Count; i++)
            {
                UpdateShapeLayout(this.SourceDependencyShapes[i], maxElementWidth);
                if (this.SourceDependencyShapes[i].Bounds.Width > widthLeft)
                    widthLeft = this.SourceDependencyShapes[i].Bounds.Width;

                double y = this.SourceDependencyShapes[i].Size.Height;
                this.SourceDependencyShapes[i].SetLocation(new PointD(SourceMarginLeft, start));
                start = start + y + VerticalSpaceBetweenElements;
            }

            start = MarginTopStart + 45;
            double x = this.MainElementShape.AbsoluteBounds.Right + TargetMarginLeft;
            for (int i = 0; i < this.TargetDependencyShapes.Count; i++)
            {
                UpdateShapeLayout(this.TargetDependencyShapes[i], maxElementWidth);
                if (this.TargetDependencyShapes[i].Bounds.Width > widthRight)
                    widthRight = this.TargetDependencyShapes[i].Bounds.Width;

                double y = this.TargetDependencyShapes[i].Size.Height;
                this.TargetDependencyShapes[i].SetLocation(new PointD(x, start));
                start = start + y + VerticalSpaceBetweenElements;
            }

            // reposition main element if required
            if (this.SourceDependencyShapes.Count == 0 && this.TargetDependencyShapes.Count > 0)
            {
                MainElementShape.SetLocation(new PointD(
                      (diagramWidth - widthRight - MainElementShape.Size.Width - TargetMarginLeft) / 2.0,
                      diagramHeight / 2.0 - MainElementShape.Size.Height / 2.0));

                // correct position of target shapes (x)
                for (int i = 0; i < this.TargetDependencyShapes.Count; i++)
                {
                    this.TargetDependencyShapes[i].SetLocation(new PointD(MainElementShape.Bounds.Right + TargetMarginLeft, this.TargetDependencyShapes[i].Bounds.Y));
                }
            }
            else if (this.TargetDependencyShapes.Count == 0 && this.SourceDependencyShapes.Count > 0)
            {
                MainElementShape.SetLocation(new PointD(
                      (diagramWidth - widthLeft - MainElementShape.Size.Width + MarginMainElementLeft) / 2.0,
                      diagramHeight / 2.0 - MainElementShape.Size.Height / 2.0));

                // correct position of source shapes (x)
                for (int i = 0; i < this.SourceDependencyShapes.Count; i++)
                {
                    this.SourceDependencyShapes[i].SetLocation(new PointD(MainElementShape.Bounds.X - widthLeft - SourceMarginLeft - MarginMainElementLeft, this.SourceDependencyShapes[i].Bounds.Y));
                }
            }

            UpdateLinkShapePositions();            
        }

        private void UpdateLinkShapePositions()
        {
            for (int i = 0; i < this.SourceDependencyShapes.Count; i++)
            {
                UpdateLinkShapePosition(this.SourceDependencyShapes[i], this.MainElementShape, true);
            }
            for (int i = 0; i < this.TargetDependencyShapes.Count; i++)
            {
                UpdateLinkShapePosition(this.TargetDependencyShapes[i], this.MainElementShape, false);
            }
        }
        private void UpdateLinkShapePosition(GraphicalDependencyShape shape, NodeShape mainShape, bool bSource)
        {
            UpdateLinkShapePosition(shape.LinkShape, shape, mainShape, bSource);
        }
        
        /// <summary>
        /// Updates the position of a link shape.
        /// </summary>
        /// <param name="linkShape">Link shape.</param>
        /// <param name="shape">Graphical dependency shape.</param>
        /// <param name="mainShape">Node shape.</param>
        /// <param name="bSource">True if graphical dependency shape is source.</param>
        public void UpdateLinkShapePosition(LinkShape linkShape, GraphicalDependencyShape shape, NodeShape mainShape, bool bSource)
        {
            if (linkShape == null)
                return;

            if (bSource)
            {
                linkShape.SourceAnchor.AbsoluteLocation = new PointD(shape.AbsoluteBounds.Right + LinkAnchorMargin, shape.AbsoluteBounds.Center.Y);
                linkShape.TargetAnchor.AbsoluteLocation = new PointD(mainShape.AbsoluteBounds.Left - LinkAnchorMargin, mainShape.AbsoluteBounds.Center.Y);
                linkShape.Layout(FixedGeometryPoints.SourceAndTarget);
            }
            else
            {
                linkShape.SourceAnchor.AbsoluteLocation = new PointD(mainShape.AbsoluteBounds.Right + LinkAnchorMargin, mainShape.AbsoluteBounds.Center.Y);
                linkShape.TargetAnchor.AbsoluteLocation = new PointD(shape.AbsoluteBounds.Left - LinkAnchorMargin, shape.AbsoluteBounds.Center.Y);
                linkShape.Layout(FixedGeometryPoints.SourceAndTarget);
            }

            /*
            if (bSource)
            {
                linkShape.SourceAnchor.AbsoluteLocation = LinkShape.CalculateLocation(
                    LinkPlacement.Right, shape.AbsoluteBounds, new PointD(shape.AbsoluteBounds.Right + LinkAnchorMargin, shape.AbsoluteBounds.Center.Y));
                linkShape.TargetAnchor.AbsoluteLocation = LinkShape.CalculateLocation(
                    LinkPlacement.Left, mainShape.AbsoluteBounds, new PointD(mainShape.AbsoluteBounds.Left - LinkAnchorMargin, mainShape.AbsoluteBounds.Center.Y));
            }
            else
            {
                linkShape.SourceAnchor.AbsoluteLocation = LinkShape.CalculateLocation(LinkPlacement.Right,
                    mainShape.AbsoluteBounds, new PointD(mainShape.AbsoluteBounds.Right + LinkAnchorMargin, mainShape.AbsoluteBounds.Center.Y));
                linkShape.TargetAnchor.AbsoluteLocation = LinkShape.CalculateLocation(LinkPlacement.Left, shape.AbsoluteBounds,
                    new PointD(shape.AbsoluteBounds.Left - LinkAnchorMargin, shape.AbsoluteBounds.Center.Y));
            }
            */
        }

        private void UpdateShapeLayout(GraphicalDependencyShape shape)
        {
            double x = ChildMarginLeft;
            double y = ChildMarginTopStart;

            shape.SetLocation(new PointD(MarginMainElementLeft, MarginTopStart));

            double maxWidth = 0;
            for (int i = 0; i < shape.Children.Count; i++)
            {
                double temp = shape.Children[i].Size.Height;
                shape.Children[i].SetLocation(new PointD(x, y), false);
                y += temp + VerticalSpaceBetweenElements;

                if (shape.Children[i].Size.Width > maxWidth)
                    maxWidth = shape.Children[i].Size.Width;
            }

            shape.SetSize(new SizeD(maxWidth + MarginRight, y - VerticalSpaceBetweenElements + MarginTopEnd + RelationshipNameSpace));
        }
        private void UpdateShapeLayout(GraphicalDependencyShape shape, double maxShapeWidth)
        {
            double x = ChildMarginLeft;
            double y = ChildMarginTopStart;

            shape.SetLocation(new PointD(MarginMainElementLeft, MarginTopStart));

            double maxWidth = 0;
            for (int i = 0; i < shape.Children.Count; i++)
            {
                double temp = shape.Children[i].Size.Height;
                shape.Children[i].SetLocation(new PointD(x, y), false);
                y += temp + VerticalSpaceBetweenElements;

                if (shape.Children[i].Size.Width > maxWidth)
                    maxWidth = shape.Children[i].Size.Width;
            }

            //double desiredWidth = GetDesiredWidth(shape.RelationshipName);
            //if (maxWidth < desiredWidth)
            //    maxWidth = desiredWidth;
            shape.SetSize(new SizeD(maxWidth + MarginRight, y - VerticalSpaceBetweenElements + MarginTopEnd + RelationshipNameSpace));
        }

        /// <summary>
        /// Add to shape mapping override.
        /// </summary>
        /// <param name="shapeElement"></param>
        public override void AddToShapeMapping(ShapeElement shapeElement)
        {
            if (shapeElement == this.MainElementShape)
            {
                GraphicalDependencyShapeStore.AddToStore(shapeElement.Element.Id, shapeElement.Id);
            }
            //else
            //    base.AddToShapeMapping(shapeElement);
        }
        
        /// <summary>
        /// Remove from shape mapping override.
        /// </summary>
        /// <param name="shapeElement"></param>
        public override void RemoveFromShapeMapping(ShapeElement shapeElement)
        {
            if( shapeElement == this.MainElementShape )
                if (shapeElement.Element != null)
                {
                    GraphicalDependencyShapeStore.RemoveFromStore(shapeElement.Element.Id, shapeElement.Id);
                }
            //else
            //    base.RemoveFromShapeMapping(shapeElement);
        }
    }
}

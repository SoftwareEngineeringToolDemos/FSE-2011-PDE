using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Drag adorner class, used to represent a movement operation.
    /// </summary>
    public class DragAdorner : Adorner
    {
        /// <summary>
        /// Adorned child.
        /// </summary>
        protected UIElement adornedChild;

        /// <summary>
        /// X-Center.
        /// </summary>
        protected double XCenter;

        /// <summary>
        /// Y-Center.
        /// </summary>
        protected double YCenter;
        
        private double leftOffset;
        private double topOffset;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="owner">Owner of this adorner element</param>
        public DragAdorner(UIElement owner) : base(owner) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="owner">Owner of this adorner element</param>
        /// <param name="adornElement">Element to display on the adorner.</param>
        /// <param name="useVisualBrush">True if visual brush should be used for display. False otherwise.</param>
        /// <param name="opacity">Opacity to apply to the visual brush.</param>
        public DragAdorner(UIElement owner, UIElement adornElement, bool useVisualBrush, double opacity)
            : base(owner)
        {
            if (useVisualBrush)
            {
                VisualBrush _brush = new VisualBrush(adornElement);
                _brush.Opacity = opacity;

                Rectangle r = new Rectangle();
                r.Width = adornElement.DesiredSize.Width;
                r.Height = adornElement.DesiredSize.Height;

                XCenter = adornElement.DesiredSize.Width / 2;
                YCenter = adornElement.DesiredSize.Height / 2;

                r.Fill = _brush;
                this.adornedChild = r;

            }
            else
                this.adornedChild = adornElement;
        }
        
        /// <summary>
        /// Gets or sets the left offset.
        /// </summary>
        public double LeftOffset
        {
            get { return leftOffset; }
            set
            {
                leftOffset = value - XCenter;
                Update();
            }
        }

        /// <summary>
        /// Gets or sets the top offset.
        /// </summary>
        public double TopOffset
        {
            get { return topOffset; }
            set
            {
                topOffset = value - YCenter;

                Update();
            }
        }

        /// <summary>
        /// Updates the position of this adorner.
        /// </summary>
        public void Update()
        {
            AdornerLayer adorner = (AdornerLayer)this.Parent;
            if (adorner != null)
            {
                adorner.Update(this.AdornedElement);
            }
        }

        /// <summary>
        /// Gets the visual child.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
            return this.adornedChild;
        }

        /// <summary>
        /// Gets the visual child count.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Measure override routine.
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size finalSize)
        {
            this.adornedChild.Measure(finalSize);
            return this.adornedChild.DesiredSize;
        }

        /// <summary>
        /// Arrange override routine.
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            this.adornedChild.Arrange(new Rect(this.adornedChild.DesiredSize));
            return finalSize;
        }

        /// <summary>
        /// Tranformation.
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(LeftOffset, TopOffset));
            return result;
        }
    }
}

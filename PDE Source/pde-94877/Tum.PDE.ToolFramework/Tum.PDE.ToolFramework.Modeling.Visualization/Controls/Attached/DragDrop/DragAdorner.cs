using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    
    /// <summary>
    /// Drag adorner.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public class DragAdorner : Adorner
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="adornedElement"></param>
        /// <param name="adornment"></param>
        public DragAdorner(UIElement adornedElement, UIElement adornment)
            : base(adornedElement)
        {
            m_AdornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);
            m_AdornerLayer.Add(this);
            m_Adornment = adornment;
            IsHitTestVisible = false;
        }

        /// <summary>
        /// Gets or sets the position of the mouse.
        /// </summary>
        public Point MousePosition 
        {
            get { return m_MousePosition; }
            set
            {
                if (m_MousePosition != value)
                {
                    m_MousePosition = value;
                    m_AdornerLayer.Update(AdornedElement);
                }
            }
        }

        /// <summary>
        /// Detach.
        /// </summary>
        public void Detatch()
        {
            m_AdornerLayer.Remove(this);
        }

        /// <summary>
        /// Arrange override.
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            m_Adornment.Arrange(new Rect(finalSize));
            return finalSize;
        }
        
        /// <summary>
        /// Desired transformation.
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(MousePosition.X - 4, MousePosition.Y - 4));

            return result;
        }

        /// <summary>
        /// Gets the visual child.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
            return m_Adornment;
        }

        /// <summary>
        /// Measure override.
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size constraint)
        {
            m_Adornment.Measure(constraint);
            return m_Adornment.DesiredSize;
        }

        /// <summary>
        /// Gets the visual children count.
        /// </summary>
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        AdornerLayer m_AdornerLayer;
        UIElement m_Adornment;
        Point m_MousePosition;
    }
}

using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This items control is used as the bindable host for child items, which can either be elements or links.
    /// </summary>
    public class DiagramDesignerItems : ItemsControl
    {
        /// <summary>
        /// Creates a DiagramDesignerItem to use to display content.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DiagramDesignerItem();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DiagramDesignerItem;
        }

        /// <summary>
        /// Verifies if this is the top most items host.
        /// </summary>
        /// <returns>True if this is the top most items host; False otherwise.</returns>
        public virtual bool IsTopMostHost()
        {
            if (DiagramHelper.GetDiagramDesignerItem(this) == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ActsAsTopMost-Property.
        /// </summary>
        public bool ActsAsTopMost
        {
            get { return (bool)GetValue(ActsAsTopMostProperty); }
            set
            {
                SetValue(ActsAsTopMostProperty, value);
            }
        }

        /// <summary>
        /// Selected items property.
        /// </summary>
        public static readonly DependencyProperty ActsAsTopMostProperty =
          DependencyProperty.Register("ActsAsTopMost", typeof(bool), typeof(DiagramDesignerItems), new PropertyMetadata(false, new PropertyChangedCallback(OnActsAsTopMostChanged)));

        private static void OnActsAsTopMostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DiagramDesignerItems items = d as DiagramDesignerItems;
            if (items != null)
            {
                if (items.ActsAsTopMost)
                    items.SecondaryMargin = new Size(2000, 2000);
                else
                    items.SecondaryMargin = new Size(0, 0);

                items.InvalidateMeasure();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size constraint)
        {
            Size size = base.MeasureOverride(constraint);
            if (SecondaryMargin != Size.Empty)
            {
                size.Width += SecondaryMargin.Width;
                size.Height += SecondaryMargin.Height;
            }

            return size;
        }

        /// <summary>
        /// Gets or sets the secondary margin, which is used to extend the size of this control on the surface.
        /// </summary>
        public Size SecondaryMargin
        {
            get;
            set;
        }
    }
}

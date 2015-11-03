using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon
{
    /// <summary>
    /// Gallery item for the ribbon InGallery control.
    /// </summary>
    public class RibbonInGalleryItem : ListBoxItem
    {
        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static RibbonInGalleryItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RibbonInGalleryItem),
                new FrameworkPropertyMetadata(typeof(RibbonInGalleryItem)));
        }

        /// <summary>
        /// Property to notify the control that it is selected.
        /// </summary>
        public bool IsSelectedItem
        {
            get { return (bool)GetValue(IsSelectedItemProperty); }
            set
            {
                SetValue(IsSelectedItemProperty, value);
            }
        }

        /// <summary>
        /// Is selected dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedItemProperty =
          DependencyProperty.Register("IsSelectedItem", typeof(bool), typeof(RibbonInGalleryItem), new PropertyMetadata(false));
    }
}

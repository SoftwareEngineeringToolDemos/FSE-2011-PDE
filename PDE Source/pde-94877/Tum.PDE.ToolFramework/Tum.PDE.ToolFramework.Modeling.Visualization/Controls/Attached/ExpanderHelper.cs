using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached
{
    /// <summary>
    /// Expander attached properties.
    /// </summary>
    /// <remarks>
    /// http://stackoverflow.com/questions/1070685/hidding-the-arrows-for-the-wpf-expander-control
    /// </remarks>
    public class ExpanderHelper
    {

        #region HideExpanderArrow AttachedProperty

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AttachedPropertyBrowsableForType(typeof(Expander))]
        public static bool GetHideExpanderArrow(DependencyObject obj)
        {
            return (bool)obj.GetValue(HideExpanderArrowProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        [AttachedPropertyBrowsableForType(typeof(Expander))]
        public static void SetHideExpanderArrow(DependencyObject obj, bool value)
        {
            obj.SetValue(HideExpanderArrowProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for HideExpanderArrow.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HideExpanderArrowProperty =
                DependencyProperty.RegisterAttached("HideExpanderArrow", typeof(bool), typeof(ExpanderHelper), new UIPropertyMetadata(false, OnHideExpanderArrowChanged));

        private static void OnHideExpanderArrowChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Expander expander = (Expander)o;

            if (expander.IsLoaded)
            {
                UpdateExpanderArrow(expander, (bool)e.NewValue);
            }
            else
            {
                expander.Loaded += new RoutedEventHandler((x, y) => UpdateExpanderArrow(expander, (bool)e.NewValue));
            }
        }

        private static void UpdateExpanderArrow(Expander expander, bool visible)
        {
            Grid headerGrid =
                    VisualTreeHelper.GetChild(
                            VisualTreeHelper.GetChild(
                                            VisualTreeHelper.GetChild(
                                                    VisualTreeHelper.GetChild(
                                                            VisualTreeHelper.GetChild(
                                                                    expander,
                                                                    0),
                                                            0),
                                                    0),
                                            0),
                                    0) as Grid;

            headerGrid.Children[0].Visibility = visible ? Visibility.Collapsed : Visibility.Visible; // Hide or show the Ellipse
            headerGrid.Children[1].Visibility = visible ? Visibility.Collapsed : Visibility.Visible; // Hide or show the Arrow
            headerGrid.Children[2].SetValue(Grid.ColumnProperty, visible ? 0 : 1); // If the Arrow is not visible, then shift the Header Content to the first column.
            headerGrid.Children[2].SetValue(Grid.ColumnSpanProperty, visible ? 2 : 1); // If the Arrow is not visible, then set the Header Content to span both rows.
            headerGrid.Children[2].SetValue(ContentPresenter.MarginProperty, visible ? new Thickness(0) : new Thickness(4, 0, 0, 0)); // If the Arrow is not visible, then remove the margin from the Content.
        }

        #endregion

    }
}

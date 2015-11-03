using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Idea from http://tomlev2.wordpress.com/2009/03/27/wpf-automatically-sort-a-gridview-when-a-column-header-is-clicked/
    /// </remarks>
    public class ListViewSortHelper
    {
        /// <summary>
        /// Gets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Value of the property.</returns>
        public static bool GetEnableSorting(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableSortingProperty);
        }

        /// <summary>
        /// Sets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Vlue.</param>
        /// <returns>Value of the property.</returns>
        public static void SetEnableSorting(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableSortingProperty, value);
        }

        /// <summary>
        /// Enable sorting property
        /// </summary>
        public static readonly DependencyProperty EnableSortingProperty =
            DependencyProperty.RegisterAttached(
                "EnableSorting",
                typeof(bool),
                typeof(ListViewSortHelper),
                new UIPropertyMetadata(
                    false,
                    (o, e) =>
                    {
                        ListView listView = o as ListView;
                        if (listView != null)
                        {
                            bool oldValue = (bool)e.OldValue;
                            bool newValue = (bool)e.NewValue;
                            if (oldValue && !newValue)
                            {
                                listView.RemoveHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ColumnHeader_Click));
                            }
                            if (!oldValue && newValue)
                            {
                                listView.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ColumnHeader_Click));
                            }
                        }
                    }
                )
            );

        private static void ColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked != null)
            {
                ICommand command = GetSortingCommand(headerClicked.Column);
                if (command != null)
                {
                    if (command.CanExecute(null))
                        command.Execute(null);
                }
            }
        }

        /// <summary>
        /// Gets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Value of the property.</returns>
        public static ICommand GetSortingCommand(DependencyObject obj)
        {
            return obj.GetValue(SortingCommandProperty) as ICommand;
        }

        /// <summary>
        /// Gets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">value.</param>
        /// <returns>Value of the property.</returns>
        public static void SetSortingCommand(DependencyObject obj, string value)
        {
            obj.SetValue(SortingCommandProperty, value);
        }

        /// <summary>
        /// Sorting command property
        /// </summary>
        public static readonly DependencyProperty SortingCommandProperty =
            DependencyProperty.RegisterAttached(
                "SortingCommand",
                typeof(ICommand),
                typeof(ListViewSortHelper),
                new UIPropertyMetadata(null)
            );

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{
    /// <summary>
    /// Behavior to maximaze the size of the columns of a listview, that dont have a fixed width specified.
    /// </summary>
    public class ListViewColumnWidthBehavior : Behavior<ListView>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.SizeChanged += new System.Windows.SizeChangedEventHandler(AssociatedObject_SizeChanged);
        }


        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.SizeChanged -= new System.Windows.SizeChangedEventHandler(AssociatedObject_SizeChanged);

            base.OnDetaching();
        }


        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Set our initial widths.
            SetColumnWidths(this.AssociatedObject);
        }
        void AssociatedObject_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            SetColumnWidths(this.AssociatedObject);
        }
        /// <summary>
        /// Sets the column widths.
        /// </summary>
        private void SetColumnWidths(ListView listView)
        {
            //Pull the stretch columns fromt the tag property.
            List<GridViewColumn> columns = (listView.Tag as List<GridViewColumn>);
            double specifiedWidth = 0;
            GridView gridView = listView.View as GridView;
            if (gridView != null)
            {
                if (columns == null)
                {
                    //Instance if its our first run.
                    columns = new List<GridViewColumn>();
                    // Get all columns with no width having been set.
                    foreach (GridViewColumn column in gridView.Columns)
                    {
                        if (!(column.Width >= 0))
                            columns.Add(column);
                        else specifiedWidth += column.ActualWidth;
                    }
                }
                else
                {
                    // Get all columns with no width having been set.
                    foreach (GridViewColumn column in gridView.Columns)
                        if (!columns.Contains(column))
                            specifiedWidth += column.ActualWidth;
                }

                // Allocate remaining space equally.
                foreach (GridViewColumn column in columns)
                {
                    double newWidth = (listView.ActualWidth - specifiedWidth) / columns.Count;
                    if (newWidth >= 0)
                        column.Width = newWidth;
                }

                //Store the columns in the TAG property for later use. 
                listView.Tag = columns;
            }
        }
    }
}

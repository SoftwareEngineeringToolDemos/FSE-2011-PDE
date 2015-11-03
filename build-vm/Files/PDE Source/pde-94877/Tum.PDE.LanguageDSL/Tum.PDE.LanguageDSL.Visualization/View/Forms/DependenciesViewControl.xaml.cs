using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tum.PDE.LanguageDSL.Visualization.View.Forms
{
    /// <summary>
    /// Interaction logic for DependenciesViewControl.xaml
    /// </summary>
    public partial class DependenciesViewControl : UserControl
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public DependenciesViewControl()
        {
            InitializeComponent();
        }

        #region List Column Width
        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView lv = (sender as ListView);
            if (lv.IsLoaded)
            {
                //Set our initial widths.
                SetColumnWidths(lv);
            }

        }
        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            ListView lv = (sender as ListView);
            //Set our initial widths.
            SetColumnWidths(lv);


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
        #endregion
    }
}

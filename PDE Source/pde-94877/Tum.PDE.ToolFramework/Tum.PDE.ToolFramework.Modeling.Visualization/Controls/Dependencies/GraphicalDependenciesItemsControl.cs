using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Dependencies
{
    /// <summary>
    /// Items control hosting dependencies.
    /// </summary>
    public class GraphicalDependenciesItemsControl : ItemsControl, IGraphicalDependenciesView
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GraphicalDependenciesItemsControl()
            : base()
        {
            selectedDItems = new Collection<GraphicalDependenciesItem>();

            this.DataContextChanged += new DependencyPropertyChangedEventHandler(GraphicalDependenciesItemsControl_DataContextChanged);
        }
        void GraphicalDependenciesItemsControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is IGraphicalDependenciesViewModel)
                (this.DataContext as IGraphicalDependenciesViewModel).View = this;
        }

        /// <summary>
        /// Updates the clicked point value, which is always relative to the source of the click event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            ClearSelection();

        }

        /// <summary>
        /// Sets the selection to the specified item.
        /// </summary>
        /// <param name="item">Item to set selection to.</param>
        public void SetSelection(GraphicalDependenciesItem item)
        {
            ClearSelection();

            selectedDItems.Add(item);
            item.IsSelected = true;

            System.Collections.ObjectModel.Collection<object> col = new System.Collections.ObjectModel.Collection<object>();
            col.Add(item.SelectedData);
            this.SelectedItems = col;
        }

        /// <summary>
        /// Clear selection.
        /// </summary>
        public void ClearSelection()
        {
            for (int i = 0; i < selectedDItems.Count; i++)
                selectedDItems[i].IsSelected = false;

            selectedDItems.Clear();
            SelectedItems = null;
        }

        private Collection<GraphicalDependenciesItem> selectedDItems;

        /// <summary>
        /// Property to notify of selected items.
        /// </summary>
        public Collection<object> SelectedItems
        {
            get { return GetValue(SelectedItemsProperty) as Collection<object>; }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }

        /// <summary>
        /// Selected items property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
          DependencyProperty.Register("SelectedItems", typeof(Collection<object>), typeof(GraphicalDependenciesItemsControl), new PropertyMetadata(null, new PropertyChangedCallback(SelectedItemsPropertyChanged)));
        private static void SelectedItemsPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
        }

        /// <summary>
        /// Creates a GraphicalDependenciesItem to use to display content.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new GraphicalDependenciesItem();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is GraphicalDependenciesItem;
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns></returns>
        public Diagrams.SizeD GetSize()
        {
            /*
            for(int i = 0; i < this.Items.Count; i++ )
            {
                GraphicalDependenciesItem c = this.ItemContainerGenerator.ContainerFromItem(this.Items[i]) as GraphicalDependenciesItem;
                if (c != null)
                {
                    c.UpdateLayout();

                }
            }*/

            this.UpdateLayout();
            //this.InvalidateVisual();
            //this.InvalidateMeasure();
            //this.InvalidateArrange();

            
            return new Diagrams.SizeD(this.ActualWidth, this.ActualHeight);
        }
    }
}

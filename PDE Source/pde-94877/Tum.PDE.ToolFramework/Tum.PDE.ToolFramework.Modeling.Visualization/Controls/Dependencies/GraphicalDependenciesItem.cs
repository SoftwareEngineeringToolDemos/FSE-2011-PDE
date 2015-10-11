using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface;
using System.Windows.Input;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Dependencies
{
    /// <summary>
    /// Item representing a dependency.
    /// </summary>
    public class GraphicalDependenciesItem : ContentControl, ISelectable
    {
        #region ISelectable
        /// <summary>
        /// Property to notify the control that it is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }

        /// <summary>
        /// Is selected dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
          DependencyProperty.Register("IsSelected", typeof(bool), typeof(GraphicalDependenciesItem), new PropertyMetadata(false, new PropertyChangedCallback(IsSelectedPropertyChanged)));
        private static void IsSelectedPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            GraphicalDependenciesItem item = obj as GraphicalDependenciesItem;
            if (item.DataContext != null)
                if (item != null)
                {
                }
        }

        /// <summary>
        /// Gets the selected data.
        /// </summary>
        public virtual object SelectedData
        {
            get
            {
                return this.DataContext;
            }
        }
        #endregion

        /// <summary>
        /// Update selection.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            if (GetDiagramDesignerItem((DependencyObject)e.MouseDevice.DirectlyOver) == this)
            {
                UpdateSelection(true);
                if (!this.IsFocused)
                    this.Focus();

                e.Handled = false;
            }

            base.OnPreviewMouseDown(e);
        }

        /// <summary>
        /// Updates the selection for this item.
        /// </summary>
        /// <param name="bSelect">True if this item should be selected; false otherwise.</param>
        protected virtual void UpdateSelection(bool bSelect)
        {
            GraphicalDependenciesItemsControl designer = GetDiagramDesigner(this) as GraphicalDependenciesItemsControl;

            // update selection
            if (designer != null)
            {
                designer.SetSelection(this);
            }
        }

        /// <summary>
        /// Gets the dependencies items control.
        /// </summary>
        /// <param name="startObject"></param>
        /// <returns></returns>
        public static GraphicalDependenciesItemsControl GetDiagramDesigner(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is GraphicalDependenciesItemsControl)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as GraphicalDependenciesItemsControl;
        }
        /// <summary>
        /// Gets the parent object of the type DiagramDesignerItem that represents an element
        /// starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        public static GraphicalDependenciesItem GetDiagramDesignerItem(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is GraphicalDependenciesItem)
                {
                    break;
                }
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as GraphicalDependenciesItem;
        }
    }
}

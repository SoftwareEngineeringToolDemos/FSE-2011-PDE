using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{
    /// <summary>
    /// Clicked item behavior for the treeview.
    /// </summary>
    public class TreeViewClickedAndSelectedItemBehavior : Behavior<TreeView>
    {
        bool bSelectionChanged = false;

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseDown);
            this.AssociatedObject.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseUp);
            this.AssociatedObject.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(AssociatedObject_PreviewMouseMove);
            this.AssociatedObject.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(AssociatedObject_SelectedItemChanged);
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewMouseDown -= new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseDown);
            this.AssociatedObject.PreviewMouseUp -= new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseUp);
            this.AssociatedObject.PreviewMouseMove -= new System.Windows.Input.MouseEventHandler(AssociatedObject_PreviewMouseMove);
            this.AssociatedObject.SelectedItemChanged -= new RoutedPropertyChangedEventHandler<object>(AssociatedObject_SelectedItemChanged);

            base.OnDetaching();
        }

        void AssociatedObject_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DependencyObject obj = GetParentFromVisualTree((DependencyObject)e.MouseDevice.DirectlyOver);
            if (obj is ToggleButton)
            {
                obj = GetParentFromVisualTree(VisualTreeHelper.GetParent(obj));

                if (obj is TreeViewItem)
                {
                    ClickedItem = (obj as TreeViewItem).DataContext;
                    TreeViewItem item = obj as TreeViewItem;
                    item.IsExpanded = !item.IsExpanded;

                    bSelectionChanged = false;
                    e.Handled = true;
                }

            }
            else if (obj is TreeViewItem)
            {
                ClickedItem = (obj as TreeViewItem).DataContext;

                if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                {
                    if (e.ClickCount == 2)
                    {
                        //this.SelectedItem = this.ClickedItem;

                        TreeViewItem item = obj as TreeViewItem;
                        item.IsExpanded = !item.IsExpanded;
                        item.Focus();

                        bSelectionChanged = false;
                    }
                    else
                    {
                        bSelectionChanged = true;
                        
                    }
                    e.Handled = true;
                    
                }
                else if (e.ChangedButton == System.Windows.Input.MouseButton.Right)
                {
                    bSelectionChanged = false;
                }
            }
            else
                ClickedItem = null;

            if( ClickedItem == null )
                this.AssociatedObject.Focus();
        }
        void AssociatedObject_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                if (bSelectionChanged)
                {
                    DependencyObject obj = GetParentFromVisualTree((DependencyObject)e.MouseDevice.DirectlyOver);
                    if (!(obj is ToggleButton) && this.ClickedItem != null)
                    {
                        if( this.SelectedItem != this.ClickedItem )
                            this.SelectedItem = this.ClickedItem;
                        (obj as TreeViewItem).Focus();
                    }
                }

            bSelectionChanged = false;
        }
        void AssociatedObject_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.ClickedItem = null;
            if( this.SelectedItem != this.AssociatedObject.SelectedItem )
                this.SelectedItem = this.AssociatedObject.SelectedItem;
        }
        void AssociatedObject_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (bSelectionChanged && e.LeftButton == System.Windows.Input.MouseButtonState.Released)
            {
                DependencyObject obj = GetParentFromVisualTree((DependencyObject)e.MouseDevice.DirectlyOver);
                if (!(obj is ToggleButton) && this.ClickedItem != null)
                {
                    if( this.SelectedItem != this.ClickedItem )
                        this.SelectedItem = this.ClickedItem;
                }
            }

            bSelectionChanged = false;
        }  

        /// <summary>
        /// Gets the parent object of the type TreeViewItem or ToggleButton starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        DependencyObject GetParentFromVisualTree(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is TreeViewItem || parent is ToggleButton)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }
        
        #region DProperties
        /// <summary>
        /// Clicked item dependency property.
        /// </summary>
        public static readonly DependencyProperty ClickedItemProperty = DependencyProperty.Register(
            "ClickedItem", typeof(object), typeof(TreeViewClickedAndSelectedItemBehavior),
            new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets the object that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public object ClickedItem
        {
            get { return (object)GetValue(ClickedItemProperty); }
            set { SetValue(ClickedItemProperty, value); }
        }

        /// <summary>
        /// Selected item dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(TreeViewClickedAndSelectedItemBehavior),
            new PropertyMetadata(null));


        /// <summary>
        /// Gets or sets the object that this trigger is bound to. This
        /// is a DependencyProperty.
        /// </summary>
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        #endregion
    }
}

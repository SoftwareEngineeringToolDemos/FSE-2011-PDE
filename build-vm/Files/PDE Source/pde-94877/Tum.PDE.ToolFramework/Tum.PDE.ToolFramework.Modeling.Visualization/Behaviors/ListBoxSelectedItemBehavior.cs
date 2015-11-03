using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{
    /// <summary>
    /// Selection in the list box doesn't really work reliable enough to bind something to the selected item. (Even
    /// with IsSynchronizedWithCurrentItem set to true, it is possible to select an item in the data template, 
    /// without setting the selected item.
    /// 
    /// This behavior provides an extra property, where the selected item (based on where the user clicked) is always
    /// updated.
    /// </summary>
    public class ListBoxSelectedItemBehavior : Behavior<ListBox>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseDown);
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewMouseDown -= new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseDown);

            base.OnDetaching();
        }

        void AssociatedObject_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // update the selected item
            DependencyObject obj = GetParentFromVisualTree((DependencyObject)e.MouseDevice.DirectlyOver);
            if (obj is ListBoxItem)
            {
                SelectedItem = (obj as ListBoxItem).DataContext;
            }
            else
                SelectedItem = null;
        }

        /// <summary>
        /// Gets the parent object of the type ListBoxItem starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        private DependencyObject GetParentFromVisualTree(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is ListBoxItem)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }

        #region Command
        /// <summary>
        /// Selected item dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(ListBoxSelectedItemBehavior),
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{
    /// <summary>
    /// Context menu behavior, which supresses the context menu opening twice. Additionally, whenever the items of the context menu are binded and the
    /// user opens the menu very fast and the menu items change, there is an ugly visual update, which is suppressed here as well. Furthermore, 
    /// if the menu is empty, it is not shown.
    /// </summary>
    public class FrameworkElementContextMenuBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.PreviewMouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseRightButtonDown);
            this.AssociatedObject.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseUp);
            this.AssociatedObject.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseLeftButtonDown);

            this.AssociatedObject.DataContextChanged += new DependencyPropertyChangedEventHandler(AssociatedObject_DataContextChanged);
            this.AssociatedObject.ContextMenuOpening += new ContextMenuEventHandler(AssociatedObject_ContextMenuOpening);
        }
        
        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewMouseRightButtonDown -= new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseRightButtonDown);
            this.AssociatedObject.PreviewMouseUp -= new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseUp);
            this.AssociatedObject.PreviewMouseLeftButtonDown -= new System.Windows.Input.MouseButtonEventHandler(AssociatedObject_PreviewMouseLeftButtonDown);

            this.AssociatedObject.DataContextChanged -= new DependencyPropertyChangedEventHandler(AssociatedObject_DataContextChanged);
            this.AssociatedObject.ContextMenuOpening -= new ContextMenuEventHandler(AssociatedObject_ContextMenuOpening);

            base.OnDetaching();
        }

        void AssociatedObject_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.AssociatedObject.ContextMenu != null)
                this.AssociatedObject.ContextMenu.Visibility = Visibility.Hidden;
        }
        void AssociatedObject_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.AssociatedObject.ContextMenu != null)
                this.AssociatedObject.ContextMenu.Visibility = Visibility.Visible;
        }
        void AssociatedObject_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.AssociatedObject.ContextMenu != null)
                this.AssociatedObject.ContextMenu.Visibility = Visibility.Hidden;
        }
        void AssociatedObject_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.AssociatedObject.ContextMenu != null)
                this.AssociatedObject.ContextMenu.DataContext = this.AssociatedObject.DataContext;
        }
        void AssociatedObject_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if( this.AssociatedObject.ContextMenu.Items.Count == 0)
                e.Handled = true;
        }
    }
}

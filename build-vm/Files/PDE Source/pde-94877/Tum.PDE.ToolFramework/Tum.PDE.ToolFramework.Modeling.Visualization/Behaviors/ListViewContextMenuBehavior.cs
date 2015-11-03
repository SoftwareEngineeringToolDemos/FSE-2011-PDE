using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{
    /// <summary>
    /// Extends the context menu behavior to hide the context menu if no items are selected.
    /// </summary>
    public class ListViewContextMenuBehavior : FrameworkElementContextMenuBehavior
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.ContextMenuOpening += new ContextMenuEventHandler(AssociatedObject_ContextMenuOpening);
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {

            this.AssociatedObject.ContextMenuOpening -= new ContextMenuEventHandler(AssociatedObject_ContextMenuOpening);

            base.OnDetaching();
        }

        void AssociatedObject_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if ((this.AssociatedObject as ListView).SelectedItems.Count == 0)
                e.Handled = true;
        }
    }
}

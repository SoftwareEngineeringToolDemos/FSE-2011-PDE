using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Behaviors
{   
    /// <summary>
    /// Selected item behavior for the treeview.
    /// </summary>
    public class TreeViewSelectedItemBehavior : Behavior<TreeView>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(AssociatedObject_SelectedItemChanged);
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectedItemChanged -= new RoutedPropertyChangedEventHandler<object>(AssociatedObject_SelectedItemChanged);

            base.OnDetaching();
        }

        void AssociatedObject_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.SelectedItem = this.AssociatedObject.SelectedItem;
        }

        #region Command
        /// <summary>
        /// Selected item dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(TreeViewSelectedItemBehavior),
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

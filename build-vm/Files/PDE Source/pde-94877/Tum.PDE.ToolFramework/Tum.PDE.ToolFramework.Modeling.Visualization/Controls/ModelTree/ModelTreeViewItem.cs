using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.ModelTree
{
    /// <summary>
    /// Control representing an item in the model tree.
    /// </summary>
    public class ModelTreeViewItem : TreeViewItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ModelTreeViewItem()
        {
        }
       
        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static ModelTreeViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModelTreeViewItem),
                new FrameworkPropertyMetadata(typeof(ModelTreeViewItem)));
        }

        /// <summary>
        /// Whenever selected, bring control into view.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);

            this.BringIntoView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ModelTreeViewItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ModelTreeViewItem;
        }

    }
}

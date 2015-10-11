using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.PropertyGrid
{
    /// <summary>
    /// Property grid editors control.
    /// </summary>
    public class PropertyGridEditors : ItemsControl
    {
        /// <summary>
        /// Creates a PropertyGridItem to use to display content.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PropertyGridItem();
        }

        /// <summary>
        /// Method to find out if the given item is the desired container item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PropertyGridItem;
        }
    }
}

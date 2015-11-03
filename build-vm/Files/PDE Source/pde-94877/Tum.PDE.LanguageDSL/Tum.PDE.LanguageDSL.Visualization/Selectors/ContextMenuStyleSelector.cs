using System.Windows;
using System.Windows.Controls;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu;


namespace Tum.PDE.LanguageDSL.Visualization.Selectors
{
    /// <summary>
    /// Style selector for the context menu items.
    /// </summary>
    public class ContextMenuStyleSelector : StyleSelector
    {
        /// <summary>
        /// Normal menu item style.
        /// </summary>
        public Style MenuItemStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Separator menu item style.
        /// </summary>
        public Style MenuItemSeparatorStyle
        {
            get;
            set;
        }


        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            if (item is SeparatorMenuItemViewModel)
                return MenuItemSeparatorStyle;
            else if (item is MenuItemViewModel)
                return MenuItemStyle;
            else
                return base.SelectStyle(item, container);
        }
    }
}

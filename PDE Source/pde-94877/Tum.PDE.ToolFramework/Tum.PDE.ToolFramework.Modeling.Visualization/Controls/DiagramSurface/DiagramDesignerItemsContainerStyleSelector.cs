using System.Windows;
using System.Windows.Controls;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// Style selector for the context menu items.
    /// </summary>
    public class DiagramDesignerItemsContainerStyleSelector : StyleSelector
    {
        /// <summary>
        /// Normal menu item style.
        /// </summary>
        public Style ItemStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Separator menu item style.
        /// </summary>
        public Style LinkStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Selects a style based on the current item.
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="container">Container</param>
        /// <returns>Style or null.</returns>
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            if (item is IDiagramLinkViewModel)
                return LinkStyle;
            else
                return ItemStyle;
        }
    }
}

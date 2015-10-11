using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.DiagramSurface
{
    /// <summary>
    /// This items control is used as the bindable host for child items.
    /// </summary>
    public class DiagramDesignerRelativeItems : ItemsControl
    {
        /// <summary>
        /// Creates a DiagramDesignerItem to use to display content.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DiagramDesignerItem();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DiagramDesignerItem;
        }
    }
}

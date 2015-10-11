using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.LanguageDSL.Visualization.View.Controls
{
    public class ModelContextTree : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ModelContextItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ModelContextItem;
        }
    }
}

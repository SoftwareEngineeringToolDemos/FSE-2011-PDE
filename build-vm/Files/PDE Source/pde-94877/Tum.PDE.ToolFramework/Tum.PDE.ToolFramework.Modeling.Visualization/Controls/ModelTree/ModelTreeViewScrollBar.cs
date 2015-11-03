using System.Windows;
using System.Windows.Controls.Primitives;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.ModelTree
{
    /// <summary>
    /// Scrollbar for the model tree view.
    /// </summary>
    public class ModelTreeViewScrollBar : ScrollBar
    {
        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static ModelTreeViewScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModelTreeViewScrollBar),
                new FrameworkPropertyMetadata(typeof(ModelTreeViewScrollBar)));
        }
    }
}

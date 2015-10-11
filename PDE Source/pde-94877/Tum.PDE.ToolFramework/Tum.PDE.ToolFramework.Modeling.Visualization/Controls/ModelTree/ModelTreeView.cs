using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.ModelTree
{
    /// <summary>
    /// This class extends the default tree view.
    /// </summary>
    public class ModelTreeView : TreeView
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ModelTreeView()
            : base()
        {
        }

        /// <summary>
        /// Static constructor to set style.
        /// </summary>
        static ModelTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModelTreeView),
                new FrameworkPropertyMetadata(typeof(ModelTreeView)));
        }

        /// <summary>
        /// Container for item override.
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

        /// <summary>
        /// Gets the parent object of the type TreeViewItem or ToggleButton starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        private DependencyObject GetParentFromVisualTree(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is TreeViewItem || parent is ToggleButton )
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }
    }
}

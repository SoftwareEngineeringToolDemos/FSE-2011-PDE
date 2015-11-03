using System.Linq;
using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Default drag handler class.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public class DefaultDragHandler : IDragSource
    {
        /// <summary>
        /// Starts drag drop.
        /// </summary>
        /// <param name="dragInfo">Info.</param>
        public virtual void StartDrag(DragInfo dragInfo)
        {
            int itemCount = dragInfo.SourceItems.Cast<object>().Count();

            if (itemCount == 1)
            {
                dragInfo.Data = dragInfo.SourceItems.Cast<object>().First();
            }
            else if (itemCount > 1)
            {
                dragInfo.Data = TypeUtilities.CreateDynamicallyTypedList(dragInfo.SourceItems);
            }

            dragInfo.Effects = (dragInfo.Data != null) ? 
                DragDropEffects.Copy | DragDropEffects.Move : 
                DragDropEffects.None;
        }
    }
}

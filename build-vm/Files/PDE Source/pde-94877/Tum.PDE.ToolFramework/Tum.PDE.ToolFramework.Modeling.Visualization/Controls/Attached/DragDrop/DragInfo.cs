using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Drag info class.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public class DragInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public DragInfo(object sender, MouseButtonEventArgs e)
        {
            DragStartPosition = e.GetPosition(null);
            Effects = DragDropEffects.None;
            MouseButton = e.ChangedButton;
            VisualSource = sender as UIElement;

            if (sender is ItemsControl)
            {
                ItemsControl itemsControl = (ItemsControl)sender;
                UIElement item = itemsControl.GetItemContainer((UIElement)e.OriginalSource);

                if (item != null)
                {
                    ItemsControl itemParent = ItemsControl.ItemsControlFromItemContainer(item);

                    SourceCollection = itemParent.ItemsSource ?? itemParent.Items;
                    SourceItem = itemParent.ItemContainerGenerator.ItemFromContainer(item);
                    SourceItems = itemsControl.GetSelectedItems();

                    // Some controls (I'm looking at you TreeView!) haven't updated their
                    // SelectedItem by this point. Check to see if there 1 or less item in 
                    // the SourceItems collection, and if so, override the SelectedItems
                    // with the clicked item.
                    if (SourceItems.Cast<object>().Count() <= 1)
                    {
                        SourceItems = Enumerable.Repeat(SourceItem, 1);
                    }

                    VisualSourceItem = item;
                }
                else
                {
                    SourceCollection = itemsControl.ItemsSource ?? itemsControl.Items;
                }
            }

            if (SourceItems == null)
            {
                SourceItems = Enumerable.Empty<object>();
            }
            
            this.IsNotHandled = false;
        }

        /// <summary>
        /// Gets or sets the dragged data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets the drag start position.
        /// </summary>
        public Point DragStartPosition { get; private set; }

        /// <summary>
        /// Gets or sets the drag drop effects.
        /// </summary>
        public DragDropEffects Effects { get; set; }

        /// <summary>
        /// Gets the pressed mouse buttons.
        /// </summary>
        public MouseButton MouseButton { get; private set; }

        /// <summary>
        /// Gets the source elements.
        /// </summary>
        public IEnumerable SourceCollection { get; private set; }

        /// <summary>
        /// Gets the source item.
        /// </summary>
        public object SourceItem { get; private set; }

        /// <summary>
        /// Gets the source items.
        /// </summary>
        public IEnumerable SourceItems { get; private set; }

        /// <summary>
        /// Gets the visual source.
        /// </summary>
        public UIElement VisualSource { get; private set; }

        /// <summary>
        /// Gets the visual source item.
        /// </summary>
        public UIElement VisualSourceItem { get; private set; }

        /// <summary>
        /// Extension: Property to allow for bubbling of events.
        /// </summary>
        public bool IsNotHandled { get; set; }
    }
}

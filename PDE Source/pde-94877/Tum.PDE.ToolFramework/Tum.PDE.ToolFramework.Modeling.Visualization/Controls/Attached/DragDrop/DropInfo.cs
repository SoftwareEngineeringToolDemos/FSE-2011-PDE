using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// Drop info class.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public class DropInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="dragInfo"></param>
        /// <param name="dataFormat"></param>
        public DropInfo(object sender, DragEventArgs e, DragInfo dragInfo, string dataFormat)
        {
            Data = (e.Data.GetDataPresent(dataFormat)) ? e.Data.GetData(dataFormat) : e.Data;
            DragInfo = dragInfo;

            VisualTarget = sender as UIElement;

            if (sender is ItemsControl)
            {
                ItemsControl itemsControl = (ItemsControl)sender;
                Point p = e.GetPosition(itemsControl);
                UIElement item = itemsControl.GetItemContainerAt(p);
                if (item == null)
                {
                    // try again with margins
                    p.X -= 15;
                    p.Y -= 15;

                    item = itemsControl.GetItemContainerAt(p);
                }

                VisualTargetOrientation = itemsControl.GetItemsPanelOrientation();

                if (item != null)
                {
                    ItemsControl itemParent = ItemsControl.ItemsControlFromItemContainer(item);

                    InsertIndex = itemParent.ItemContainerGenerator.IndexFromContainer(item);
                    TargetCollection = itemParent.ItemsSource ?? itemParent.Items;
                    TargetItem = itemParent.ItemContainerGenerator.ItemFromContainer(item);
                    VisualTargetItem = item;

                    if (VisualTargetOrientation == Orientation.Vertical)
                    {
                        if (e.GetPosition(item).Y > item.RenderSize.Height / 2) InsertIndex++;
                    }
                    else
                    {
                        if (e.GetPosition(item).X > item.RenderSize.Width / 2) InsertIndex++;
                    }
                }
                else
                {
                    TargetCollection = itemsControl.ItemsSource ?? itemsControl.Items;
                    InsertIndex = itemsControl.Items.Count;
                }
            }

            this.IsNotHandled = false;
        }

        /// <summary>
        /// Gets the dragged data.
        /// </summary>
        public object Data { get; private set; }

        /// <summary>
        /// Gets the drag info.
        /// </summary>
        public DragInfo DragInfo { get; private set; }

        /// <summary>
        /// Gets or sets the drop adorner.
        /// </summary>
        public Type DropTargetAdorner { get; set; }

        /// <summary>
        /// Gets or sets the drag drop effects.
        /// </summary>
        public DragDropEffects Effects { get; set; }

        /// <summary>
        /// Gets the insert index.
        /// </summary>
        public int InsertIndex { get; private set; }

        /// <summary>
        /// Gets the target collection.
        /// </summary>
        public IEnumerable TargetCollection { get; private set; }

        /// <summary>
        /// Gets the target item.
        /// </summary>
        public object TargetItem { get; private set; }

        /// <summary>
        /// Gets the visual target.
        /// </summary>
        public UIElement VisualTarget { get; private set; }

        /// <summary>
        /// Gets the visual target item.
        /// </summary>
        public UIElement VisualTargetItem { get; private set; }

        /// <summary>
        /// Gets the visual target orientation.
        /// </summary>
        public Orientation VisualTargetOrientation { get; private set; }

        /// <summary>
        /// Extension: Property to allow for bubbling of events.
        /// </summary>
        public bool IsNotHandled { get; set; }
    }
}

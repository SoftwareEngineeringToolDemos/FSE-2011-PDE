﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;
using System.Collections;
using System.Windows.Controls.Primitives;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities
{
    /// <summary>
    /// ItemsControl extensions.
    /// </summary>
    public static class ItemsControlExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <returns></returns>
        public static bool CanSelectMultipleItems(this ItemsControl itemsControl)
        {
            if (itemsControl is MultiSelector)
            {
                // The CanSelectMultipleItems property is protected. Use reflection to
                // get it's value anyway.
                return (bool)itemsControl.GetType()
                    .GetProperty("CanSelectMultipleItems", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(itemsControl, null);
            }
            else if (itemsControl is ListBox)
            {
                return ((ListBox)itemsControl).SelectionMode != SelectionMode.Single;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static UIElement GetItemContainer(this ItemsControl itemsControl, UIElement child)
        {
            Type itemType = GetItemContainerType(itemsControl);

            if (itemType != null)
            {
                return (UIElement)child.GetVisualAncestor(itemType);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static UIElement GetItemContainerAt(this ItemsControl itemsControl, Point position)
        {
            IInputElement inputElement = itemsControl.InputHitTest(position);
            UIElement uiElement = inputElement as UIElement;

            if (uiElement != null)
            {
                return GetItemContainer(itemsControl, uiElement);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <returns></returns>
        public static Type GetItemContainerType(this ItemsControl itemsControl)
        {
            // There is no safe way to get the item container type for an ItemsControl. The
            // best we can do is to look for the control's ItemsPresenter, get it's child 
            // panel and the first child of that *should* be an item container.
            //
            // If the control currently has no items, we're out of luck.
            if (itemsControl.Items.Count > 0)
            {
                IEnumerable<ItemsPresenter> itemsPresenters = itemsControl.GetVisualDescendents<ItemsPresenter>();
                foreach (ItemsPresenter itemsPresenter in itemsPresenters)
                {
                    DependencyObject panel = VisualTreeHelper.GetChild(itemsPresenter, 0);
                    DependencyObject itemContainer = VisualTreeHelper.GetChild(panel, 0);

                    // Ensure that this actually *is* an item container by checking it with
                    // ItemContainerGenerator.
                    if (itemContainer != null &&
                        itemsControl.ItemContainerGenerator.IndexFromContainer(itemContainer) != -1)
                    {
                        return itemContainer.GetType();
                    }
                }

                // workaround for panels with IsItemsHost = true
                Panel itemsHost = itemsControl.GetVisualDescendents<Panel>().FirstOrDefault(p => p.IsItemsHost);
                if (itemsHost != null)
                {
                    DependencyObject itemContainer = VisualTreeHelper.GetChild(itemsHost, 0);

                    // Ensure that this actually *is* an item container by checking it with
                    // ItemContainerGenerator.
                    if (itemContainer != null &&
                        itemsControl.ItemContainerGenerator.IndexFromContainer(itemContainer) != -1)
                    {
                        return itemContainer.GetType();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <returns></returns>
        public static Orientation GetItemsPanelOrientation(this ItemsControl itemsControl)
        {
            ItemsPresenter itemsPresenter = itemsControl.GetVisualDescendent<ItemsPresenter>();
            if (itemsPresenter != null)
            {
                DependencyObject itemsPanel = VisualTreeHelper.GetChild(itemsPresenter, 0);
                PropertyInfo orientationProperty = itemsPanel.GetType().GetProperty("Orientation", typeof(Orientation));

                if (orientationProperty != null)
                {
                    return (Orientation)orientationProperty.GetValue(itemsPanel, null);
                }
                else
                {
                    // Make a guess!
                    return Orientation.Vertical;
                }
            }
            else
            {
                Panel itemsPanel = itemsControl.GetVisualDescendents<Panel>().FirstOrDefault(p => p.IsItemsHost);
                if (itemsPanel != null)
                {
                    PropertyInfo orientationProperty = itemsPanel.GetType().GetProperty("Orientation", typeof(Orientation));

                    if (orientationProperty != null)
                    {
                        return (Orientation)orientationProperty.GetValue(itemsPanel, null);
                    }
                    else
                    {
                        // Make a guess!
                        return Orientation.Vertical;
                    }
                }
            }

            // Make a guess!
            return Orientation.Vertical;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <returns></returns>
        public static IEnumerable GetSelectedItems(this ItemsControl itemsControl)
        {
            if (itemsControl is MultiSelector)
            {
                return ((MultiSelector)itemsControl).SelectedItems;
            }
            else if (itemsControl is ListBox)
            {
                ListBox listBox = (ListBox)itemsControl;

                if (listBox.SelectionMode == SelectionMode.Single)
                {
                    return Enumerable.Repeat(listBox.SelectedItem, 1);
                }
                else
                {
                    return listBox.SelectedItems;
                }
            }
            else if (itemsControl is TreeView)
            {
                return Enumerable.Repeat(((TreeView)itemsControl).SelectedItem, 1);
            }
            else if (itemsControl is Selector)
            {
                return Enumerable.Repeat(((Selector)itemsControl).SelectedItem, 1);
            }
            else
            {
                return Enumerable.Empty<object>();
            }
        }
    }
}

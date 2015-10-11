﻿#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Fluent
{
    /// <summary>
    /// Reprsents ribbon tab control
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(RibbonTabItem))]
    [TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
    [TemplatePart(Name = "PART_TabsContainer", Type = typeof(IScrollInfo))]
    [TemplatePart(Name = "PART_ToolbarPanel", Type = typeof(Panel))]
    public class RibbonTabControl : Selector
    {
        #region Fields

        // Popup
        Popup popup;
        // Old selected item
        object oldSelectedItem;
        // Collection of toolbar items
        ObservableCollection<UIElement> toolBarItems;
        // ToolBar panel
        Panel toolbarPanel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets content of selected tab item
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedContent
        {
            get
            {
                return base.GetValue(SelectedContentProperty);
            }
            internal set
            {
                base.SetValue(SelectedContentPropertyKey, value);
            }
        }

        // DependencyProperty key for SelectedContent
        static readonly DependencyPropertyKey SelectedContentPropertyKey = DependencyProperty.RegisterReadOnly("SelectedContent", typeof(object), typeof(RibbonTabControl), new FrameworkPropertyMetadata(null));
        
        /// <summary>
        /// Using a DependencyProperty as the backing store for SelectedContent.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty SelectedContentProperty = SelectedContentPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets or sets whether ribbon is minimized
        /// </summary>
        public bool IsMinimized
        {
            get { return (bool)GetValue(IsMinimizedProperty); }
            set { SetValue(IsMinimizedProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsMinimized.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsMinimizedProperty = DependencyProperty.Register("IsMinimized", typeof(bool), typeof(RibbonTabControl), new UIPropertyMetadata(false, OnMinimizedChanged));

        /// <summary>
        /// Gets or sets whether ribbon popup is opened
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(RibbonTabControl), new UIPropertyMetadata(false, OnIsOpenChanged));

        /// <summary>
        /// Gets whether ribbon tabs can scroll
        /// </summary>
        internal bool CanScroll
        {
            get 
            {
                IScrollInfo scrollInfo = GetTemplateChild("PART_TabsContainer") as IScrollInfo;
                if(scrollInfo!=null)return (scrollInfo.ExtentWidth >scrollInfo.ViewportWidth); 
                else return false;
            }
        }

        /// <summary>
        /// Gets or sets selected tab item
        /// </summary>
        internal RibbonTabItem SelectedTabItem
        {
            get { return (RibbonTabItem)GetValue(SelectedTabItemProperty); }
            set { SetValue(SelectedTabItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedTabItem.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty SelectedTabItemProperty =
            DependencyProperty.Register("SelectedTabItem", typeof(RibbonTabItem), typeof(RibbonTabControl), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets collection of ribbon toolbar items
        /// </summary>
        public ObservableCollection<UIElement> ToolBarItems
        {
            get
            {
                if (this.toolBarItems == null)
                {
                    this.toolBarItems = new ObservableCollection<UIElement>();
                    this.toolBarItems.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnToolbarItemsCollectionChanged);
                }
                return this.toolBarItems;
            }
        }

        internal Panel ToolbarPanel
        {
            get { return toolbarPanel; }
        }

        // Handle toolbar iitems changes
        private void OnToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object obj2 in e.NewItems)
                    {
                        if (ToolbarPanel != null) ToolbarPanel.Children.Add(obj2 as UIElement);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object obj3 in e.OldItems)
                    {
                        if (ToolbarPanel != null) ToolbarPanel.Children.Remove(obj3 as UIElement);
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (object obj4 in e.OldItems)
                    {
                        if (ToolbarPanel != null) ToolbarPanel.Children.Remove(obj4 as UIElement);
                    }
                    foreach (object obj5 in e.NewItems)
                    {
                        if (ToolbarPanel != null) ToolbarPanel.Children.Add(obj5 as UIElement);
                    }
                    break;
            }

        }

        #endregion

        #region Initializion

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static RibbonTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RibbonTabControl), new FrameworkPropertyMetadata(typeof(RibbonTabControl)));
        }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public RibbonTabControl()
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the System.Windows.FrameworkElement.Initialized event. 
        /// This method is invoked whenever System.Windows.
        /// FrameworkElement.IsInitialized is set to true internally.
        /// </summary>
        /// <param name="e">The System.Windows.RoutedEventArgs that contains the event data.</param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            base.ItemContainerGenerator.StatusChanged += OnGeneratorStatusChanged;
        }

        /// <summary>
        /// Creates or identifies the element that is used to display the given item.
        /// </summary>
        /// <returns>The element that is used to display the given item.</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RibbonTabItem();
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or 
        /// internal processes call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            popup = GetTemplateChild("PART_Popup") as Popup;
            if (popup != null)
            {
                Binding binding = new Binding("IsOpen");
                binding.Mode = BindingMode.TwoWay;
                binding.Source = this;
                popup.SetBinding(Popup.IsOpenProperty, binding);

                popup.CustomPopupPlacementCallback = CustomPopupPlacementMethod;
            }
            if ((ToolbarPanel != null) && (toolBarItems != null))
            {
                for (int i = 0; i < toolBarItems.Count; i++)
                {
                    ToolbarPanel.Children.Remove(toolBarItems[i]);
                }
            }
            toolbarPanel = GetTemplateChild("PART_ToolbarPanel") as Panel;
            if ((ToolbarPanel != null) && (toolBarItems != null))
            {
                for (int i = 0; i < toolBarItems.Count; i++)
                {
                    ToolbarPanel.Children.Add(toolBarItems[i]);
                }
            }
        }

        /// <summary>
        /// Determines if the specified item is (or is eligible to be) its own container.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>true if the item is (or is eligible to be) its own container; otherwise, false.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is RibbonTabItem);
        }

        /// <summary>
        /// Updates the current selection when an item in the System.Windows.Controls.Primitives.Selector has changed
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            if ((e.Action == NotifyCollectionChangedAction.Remove) && (base.SelectedIndex == -1))
            {
                int startIndex = e.OldStartingIndex + 1;
                if (startIndex > base.Items.Count)
                {
                    startIndex = 0;
                }
                RibbonTabItem item = this.FindNextTabItem(startIndex, -1);
                if (item != null)
                {
                    item.IsSelected = true;
                }
                else SelectedContent = null;
            }
        }

        /// <summary>
        /// Called when the selection changes.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {            
            if (e.AddedItems.Count > 0)
            {
                if (IsMinimized)
                {
                    if (oldSelectedItem == e.AddedItems[0])
                        IsOpen = !IsOpen;
                    else
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle,new ThreadStart(delegate{IsOpen = true;}));                    
                    }
                    ((RibbonTabItem)e.AddedItems[0]).IsHitTestVisible = false;
                }

                UpdateSelectedContent();
            }
            if (e.RemovedItems.Count > 0)
            {
                oldSelectedItem = e.RemovedItems[0];
                ((RibbonTabItem)e.RemovedItems[0]).IsHitTestVisible = true;
            }
            base.OnSelectionChanged(e);
        }
               
        /// <summary>
        /// Invoked when an unhandled System.Windows.Input.Mouse.PreviewMouseWheel 
        /// attached event reaches an element in its route that is derived from this class. 
        /// Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.MouseWheelEventArgs that contains the event data.</param>
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (RibbonPopup.GetActivePopup() != null) return;
            ProcessMouseWheel(e);
            e.Handled = true;
        }

        #endregion

        #region Private methods

        // Find parent ribbon
        private Ribbon FindParentRibbon()
        {
            DependencyObject element = this;
            while(LogicalTreeHelper.GetParent(element)!=null)
            {
                element = LogicalTreeHelper.GetParent(element);
                Ribbon ribbon = element as Ribbon;
                if (ribbon!=null) return ribbon;
            }
            return null;
        }

        // Proccess mouse wheel event
        internal void ProcessMouseWheel(MouseWheelEventArgs e)
        {
            if (IsMinimized) return;
            Ribbon parentRibbon = FindParentRibbon();
            if((parentRibbon!=null)&&(parentRibbon.Focusable)) return;
            if(SelectedItem==null) return;
            List<RibbonTabItem> visualItems = new List<RibbonTabItem>();
            int selectedIndex = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                if ((Items[i] as RibbonTabItem).Visibility == Visibility.Visible)
                {
                    visualItems.Add((Items[i] as RibbonTabItem));
                    if ((Items[i] as RibbonTabItem).IsSelected) selectedIndex = visualItems.Count - 1;
                }
            }
            if (e.Delta > 0)
            {
                if (selectedIndex > 0)
                {
                    visualItems[selectedIndex].IsSelected = false;
                    selectedIndex--;
                    visualItems[selectedIndex].IsSelected = true;
                }
            }
            if (e.Delta < 0)
            {
                if (selectedIndex < visualItems.Count - 1)
                {
                    visualItems[selectedIndex].IsSelected = false;
                    selectedIndex++;
                    visualItems[selectedIndex].IsSelected = true;
                }
            }
        }

        // Get selected ribbon tab item
        private RibbonTabItem GetSelectedTabItem()
        {
            object selectedItem = base.SelectedItem;
            if (selectedItem == null)
            {
                return null;
            }
            RibbonTabItem item = selectedItem as RibbonTabItem;
            if (item == null)
            {
                item = base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) as RibbonTabItem;
            }
            return item;
        }

        // Find next tab item
        private RibbonTabItem FindNextTabItem(int startIndex, int direction)
        {
            if (direction != 0)
            {
                int index = startIndex;
                for (int i = 0; i < base.Items.Count; i++)
                {
                    index += direction;
                    if (index >= base.Items.Count)
                    {
                        index = 0;
                    }
                    else if (index < 0)
                    {
                        index = base.Items.Count - 1;
                    }
                    RibbonTabItem item2 = base.ItemContainerGenerator.ContainerFromIndex(index) as RibbonTabItem;
                    if (((item2 != null) && item2.IsEnabled) && (item2.Visibility == Visibility.Visible))
                    {
                        return item2;
                    }
                }
            }
            return null;
        }

        // Updates selected content
        void UpdateSelectedContent()
        {
            if (SelectedIndex < 0)
            {

                SelectedContent = null;
                SelectedTabItem = null;
            }
            else
            {
                RibbonTabItem selectedTabItem = GetSelectedTabItem();
                if (selectedTabItem != null)
                {                    
                    this.SelectedContent = selectedTabItem.GroupsContainer;
                    UpdateLayout();
                    SelectedTabItem = selectedTabItem;
                }
            }
        }        

        #endregion

        #region Event handling

        // Handles GeneratorStatus changed
        void OnGeneratorStatusChanged(object sender, EventArgs e)
        {
            if (ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {   
                UpdateSelectedContent();
            }
        }

        // Handles IsMinimized changed
        static void OnMinimizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTabControl tab = (RibbonTabControl)d;
            if (!tab.IsMinimized)
            {
                tab.IsOpen = false;
            }
        }

        // Handles ribbon popup closing
        void OnRibbonTabPopupClosing()
        {
            if (SelectedItem is RibbonTabItem) (SelectedItem as RibbonTabItem).IsHitTestVisible = true;
         }

        // handles ribbon popup opening
        void OnRibbonTabPopupOpening()
        {
            if (SelectedItem is RibbonTabItem) (SelectedItem as RibbonTabItem).IsHitTestVisible = false;            
        }


        /// <summary>
        /// Implements custom placement for ribbon popup
        /// </summary>
        /// <param name="popupsize"></param>
        /// <param name="targetsize"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        CustomPopupPlacement[] CustomPopupPlacementMethod(Size popupsize, Size targetsize, Point offset)
        {
            if ((popup != null) && (SelectedTabItem != null))
            {
                // Get current workarea                
                Point tabItemPos = SelectedTabItem.PointToScreen(new Point(0, 0));
                NativeMethods.Rect tabItemRect = new NativeMethods.Rect();
                tabItemRect.Left = (int)tabItemPos.X;
                tabItemRect.Top = (int)tabItemPos.Y;
                tabItemRect.Right = (int)tabItemPos.X + (int)SelectedTabItem.ActualWidth;
                tabItemRect.Bottom = (int)tabItemPos.Y + (int)SelectedTabItem.ActualHeight;

                uint MONITOR_DEFAULTTONEAREST = 0x00000002;
                System.IntPtr monitor = NativeMethods.MonitorFromRect(ref tabItemRect, MONITOR_DEFAULTTONEAREST);
                if (monitor != System.IntPtr.Zero)
                {
                    NativeMethods.MonitorInfo monitorInfo = new NativeMethods.MonitorInfo();
                    monitorInfo.Size = Marshal.SizeOf(monitorInfo);
                    NativeMethods.GetMonitorInfo(monitor, monitorInfo);

                    Point startPoint = PointToScreen(new Point(0, 0));
                    if (FlowDirection == FlowDirection.RightToLeft) startPoint.X -= ActualWidth;
                    double inWindowRibbonWidth = monitorInfo.Work.Right - Math.Max(monitorInfo.Work.Left, startPoint.X);

                    double actualWidth = ActualWidth;
                    if (startPoint.X < monitorInfo.Work.Left)
                    {
                        actualWidth -= monitorInfo.Work.Left - startPoint.X;                        
                        startPoint.X = monitorInfo.Work.Left;
                    }
                    // Set width
                    popup.Width = Math.Min(actualWidth, inWindowRibbonWidth);
                    return new CustomPopupPlacement[]
                               {
                                   new CustomPopupPlacement(new Point(startPoint.X - tabItemPos.X, SelectedTabItem.ActualHeight-(popup.Child as FrameworkElement).Margin.Top), PopupPrimaryAxis.None),
                                   new CustomPopupPlacement(new Point(startPoint.X - tabItemPos.X, -(SelectedContent as RibbonGroupsContainer).ActualHeight-(popup.Child as FrameworkElement).Margin.Bottom), PopupPrimaryAxis.None),
                               };
                }
            }
            return null;
        }

        // Handles IsOpen property changed
        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTabControl ribbon = (RibbonTabControl)d;

            if (ribbon.IsOpen)
            {
                ribbon.OnRibbonTabPopupOpening();
            }
            else
            {
                ribbon.OnRibbonTabPopupClosing();
            }
        }

        #endregion
    }
}

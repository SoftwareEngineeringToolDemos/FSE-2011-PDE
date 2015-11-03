﻿#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Fluent
{
    /// <summary>
    /// Represents quick access toolbar
    /// </summary>
    [TemplatePart(Name = "PART_ShowAbove", Type = typeof(MenuItem))]
    [TemplatePart(Name = "PART_ShowBelow", Type = typeof(MenuItem))]
    [TemplatePart(Name = "PART_MenuPanel", Type = typeof(Panel))]
    [TemplatePart(Name = "PART_RootPanel", Type = typeof(Panel))]
    [ContentProperty("QuickAccessItems")]
    public class QuickAccessToolBar:Control
    {
        #region Events

        /// <summary>
        /// Occured when items are added or removed from Quick Access toolbar
        /// </summary>
        public event NotifyCollectionChangedEventHandler ItemsChanged;

        #endregion

        #region Fields

        private DropDownButton menuButton;

        // Show above menu item
        private MenuItem showAbove;
        // Show below menu item
        private MenuItem showBelow;
        // Menu panel
        private Panel menuPanel;
        // Items of quick access menu
        private ObservableCollection<QuickAccessMenuItem> quickAccessItems;


        // Root panel
        private Panel rootPanel;
        // ToolBar panel
        private Panel toolBarPanel;
        // ToolBar overflow panel
        private Panel toolBarOverflowPanel;
        // Items of quick access menu
        private ObservableCollection<UIElement> items;

        private Size cachedConstraint;
        private int cachedCount=-1;

        // Itemc collection was changed
        private bool itemsHadChanged;

        private double cachedDeltaWidth;

        #endregion

        #region Properties

        #region Items

        /// <summary>
        /// Gets items collection
        /// </summary>
        internal ObservableCollection<UIElement> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ObservableCollection<UIElement>();
                    this.items.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnItemsCollectionChanged);
                }
                return this.items;
            }
        }

        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {                        
            cachedCount = GetNonOverflowItemsCount(DesiredSize.Width);
            HasOverflowItems = cachedCount<Items.Count;
            itemsHadChanged = true;
            InvalidateMeasure();
            if (this.Parent is Ribbon) (this.Parent as Ribbon).TitleBar.InvalidateMeasure();

            UpdateKeyTips();

            // Raise items changed event
            if (ItemsChanged != null) ItemsChanged(this, e);
        }

        #endregion

        #region HasOverflowItems

        /// <summary>
        /// Gets whether QuickAccessToolBar has overflow items
        /// </summary>
        public bool HasOverflowItems
        {
            get { return (bool)GetValue(HasOverflowItemsProperty); }
            private set { SetValue(HasOverflowItemsPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey HasOverflowItemsPropertyKey =
            DependencyProperty.RegisterReadOnly("HasOverflowItems", typeof(bool), typeof(QuickAccessToolBar), new UIPropertyMetadata(false));

        /// <summary>
        /// Using a DependencyProperty as the backing store for HasOverflowItems.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HasOverflowItemsProperty = HasOverflowItemsPropertyKey.DependencyProperty;

        #endregion

        #region QuickAccessItems

        /// <summary>
        /// Gets quick access menu items
        /// </summary>
        public ObservableCollection<QuickAccessMenuItem> QuickAccessItems
        {
            get
            {
                if (quickAccessItems == null)
                {
                    quickAccessItems = new ObservableCollection<QuickAccessMenuItem>();
                    quickAccessItems.CollectionChanged += OnQuickAccessItemsCollectionChanged;
                }
                return quickAccessItems;
            }
        }
        /// <summary>
        /// Handles quick access menu items chages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnQuickAccessItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object item in e.NewItems)
                    {
                        if (menuPanel != null) menuPanel.Children.Add((QuickAccessMenuItem)item);
                        else AddLogicalChild(item);     
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object item in e.OldItems)
                    {
                        if (menuPanel != null) menuPanel.Children.Remove((QuickAccessMenuItem)item);
                        else RemoveLogicalChild(item);
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (object item in e.OldItems)
                    {
                        if (menuPanel != null) menuPanel.Children.Remove((QuickAccessMenuItem)item);
                        else RemoveLogicalChild(item);
                    }
                    foreach (object item in e.NewItems)
                    {
                        if (menuPanel != null) menuPanel.Children.Add((QuickAccessMenuItem)item);
                        else AddLogicalChild(item);
                    }
                    break;
            }

        }

        #endregion

        #region ShowAboveRibbon

        /// <summary>
        /// Gets or sets whether quick access toolbar showes above ribbon
        /// </summary>
        public bool ShowAboveRibbon
        {
            get { return (bool)GetValue(ShowAboveRibbonProperty); }
            set { SetValue(ShowAboveRibbonProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ShowAboveRibbon.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ShowAboveRibbonProperty =
            DependencyProperty.Register("ShowAboveRibbon", typeof(bool),
            typeof(QuickAccessToolBar), new UIPropertyMetadata(true));

        #endregion

        #region LogicalChildren

        /// <summary>
        /// Gets an enumerator to the logical child elements
        /// </summary>
        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList array = new ArrayList();                                
                
                foreach(var item in QuickAccessItems)
                {
                    array.Add(item);
                }
                for (int i = 0; i < cachedCount; i++)
                {
                    array.Add(Items[i]);
                }
                if (menuButton != null) array.Add(menuButton);
                return array.GetEnumerator();
            }
        }

        #endregion

        #region CanQuickAccessLocationChanging

        /// <summary>
        /// Gets or sets whether user can change location of QAT
        /// </summary>
        public bool CanQuickAccessLocationChanging
        {
            get { return (bool)GetValue(CanQuickAccessLocationChangingProperty); }
            set { SetValue(CanQuickAccessLocationChangingProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for CanQuickAccessLocationChanging.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CanQuickAccessLocationChangingProperty =
            DependencyProperty.Register("CanQuickAccessLocationChanging", typeof(bool), typeof(QuickAccessToolBar), new UIPropertyMetadata(true));

        #endregion

        #endregion

        #region Initialization

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static QuickAccessToolBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickAccessToolBar), new FrameworkPropertyMetadata(typeof(QuickAccessToolBar)));            
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public QuickAccessToolBar()
        {
         
        }

        #endregion

        #region Override

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or 
        /// internal processes call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            if (showAbove != null) showAbove.Click -= OnShowAboveClick;
            if (showBelow != null) showBelow.Click -= OnShowBelowClick;
            
            showAbove = GetTemplateChild("PART_ShowAbove") as MenuItem;            
            showBelow = GetTemplateChild("PART_ShowBelow") as MenuItem;

            if (showAbove != null) showAbove.Click += OnShowAboveClick;
            if (showBelow != null) showBelow.Click += OnShowBelowClick;

            if (menuPanel != null)
            {
                for (int i = 0; i < QuickAccessItems.Count; i++)
                {
                    menuPanel.Children.Remove(QuickAccessItems[i]);
                    QuickAccessItems[i].InvalidateProperty(QuickAccessMenuItem.TargetProperty);
                }
            }
            else if(quickAccessItems!=null)
            {
                for (int i = 0; i < quickAccessItems.Count; i++)
                {
                    RemoveLogicalChild(quickAccessItems[i]);
                }
            }
            menuPanel = GetTemplateChild("PART_MenuPanel") as Panel;
            if ((menuPanel != null) && (quickAccessItems != null))
            {
                for (int i = 0; i < quickAccessItems.Count; i++)
                {
                    menuPanel.Children.Add(quickAccessItems[i]);
                    quickAccessItems[i].InvalidateProperty(QuickAccessMenuItem.TargetProperty);
                }
            }

            if (menuButton != null)
            {
                menuButton.Opened -= OnMenuOpened;
                menuButton.Closed -= OnMenuClosed;
            }
            menuButton = GetTemplateChild("PART_ToolbarDownButton") as DropDownButton;
            if (menuButton != null)
            {
                menuButton.Opened += OnMenuOpened;
                menuButton.Closed += OnMenuClosed;
            }

            DropDownButton btn = GetTemplateChild("PART_MenuDownButton") as DropDownButton;
            if (btn != null) btn.ContextMenu = btn.DropDownMenu;

            // ToolBar panels
            
            toolBarPanel = GetTemplateChild("PART_ToolBarPanel") as Panel;
            toolBarOverflowPanel = GetTemplateChild("PART_ToolBarOverflowPanel") as Panel;
            rootPanel = GetTemplateChild("PART_RootPanel") as Panel;

            // Clears cache
            cachedDeltaWidth = 0;
            cachedCount = GetNonOverflowItemsCount(ActualWidth);
            cachedConstraint = new Size();
        }

        private void OnMenuClosed(object sender, EventArgs e)
        {
            toolBarOverflowPanel.Children.Clear();
        }

        private void OnMenuOpened(object sender, EventArgs e)
        {            
            for(int i=cachedCount;i<Items.Count;i++)
            {
                toolBarOverflowPanel.Children.Add(Items[i]);
            }
        }

        /// <summary>
        /// Handles show below menu item click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">The event data</param>
        private void OnShowBelowClick(object sender, RoutedEventArgs e)
        {
            ShowAboveRibbon = false;
        }

        /// <summary>
        /// Handles show above menu item click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">The event data</param>
        private void OnShowAboveClick(object sender, RoutedEventArgs e)
        {
            ShowAboveRibbon = true;
        }

        /// <summary>
        /// Called to remeasure a control. 
        /// </summary>
        /// <returns>The size of the control, up to the maximum specified by constraint</returns>
        /// <param name="constraint">The maximum size that the method can return</param>
        protected override Size MeasureOverride(Size constraint)
        {
            if ((cachedConstraint == constraint)&&!itemsHadChanged) return base.MeasureOverride(constraint);
            
            cachedCount = GetNonOverflowItemsCount(constraint.Width);
            HasOverflowItems = cachedCount < Items.Count;
            cachedConstraint = constraint;
            
            toolBarOverflowPanel.Children.Clear();
            if (itemsHadChanged)
            {
                // Refill toolbar
                toolBarPanel.Children.Clear();
                for (int i = 0; i < cachedCount; i++)
                {
                    toolBarPanel.Children.Add(Items[i]);
                }
                itemsHadChanged = false;
            }
            else
            {                
                if (cachedCount > toolBarPanel.Children.Count)
                {
                    // Add needed items
                    int savedCount = toolBarPanel.Children.Count;
                    for (int i = savedCount; i < cachedCount; i++)
                    {
                        toolBarPanel.Children.Add(Items[i]);
                    }
                }
                else
                {
                    // Remove nonneeded items
                    for (int i = toolBarPanel.Children.Count-1; i >= cachedCount; i--)
                    {
                        toolBarPanel.Children.Remove(Items[i]);
                    }
                }
            }
            return base.MeasureOverride(constraint);
        }

        #endregion

        #region Methods

        // Updates keys for keytip access
        void UpdateKeyTips()
        {
            for (int i = 0; i < Math.Min(9, Items.Count); i++)
            {
                // 1, 2, 3, ... , 9
                KeyTip.SetKeys(Items[i], (i + 1).ToString(CultureInfo.InvariantCulture));
            }
            for (int i = 9; i < Math.Min(18, Items.Count); i++)
            {
                // 09, 08, 07, ... , 01
                KeyTip.SetKeys(Items[i], "0" + (18 - i).ToString(CultureInfo.InvariantCulture));
            }
            char startChar = 'A';
            for (int i = 18; i < Math.Min(9 + 9 + 26, Items.Count); i++)
            {
                // 0A, 0B, 0C, ... , 0Z
                KeyTip.SetKeys(Items[i], "0" + startChar++);
            }
        }

        int GetNonOverflowItemsCount(double width)
        {            
            if(cachedDeltaWidth==0 && rootPanel != null && toolBarPanel != null)
            {
                rootPanel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                cachedDeltaWidth = rootPanel.DesiredSize.Width - toolBarPanel.DesiredSize.Width;
            }
            double currentWidth = 0;
            for (int i = 0; i < Items.Count;i++ )
            {
                Items[i].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                currentWidth += Items[i].DesiredSize.Width;
                if (currentWidth + cachedDeltaWidth > width) return i;
            }
            return Items.Count;
        }

        #endregion
    }
}

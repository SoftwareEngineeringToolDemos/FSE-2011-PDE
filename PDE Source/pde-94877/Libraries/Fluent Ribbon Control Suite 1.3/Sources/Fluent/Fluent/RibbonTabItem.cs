#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright � Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Fluent
{
    /// <summary>
    /// Represents ribbon tab item
    /// </summary>
    [TemplatePart(Name = "PART_ContentContainer", Type = typeof(Border))]
    [ContentProperty("Groups")]
    public class RibbonTabItem : Control
    {
        #region Fields

        // Content container
        private Border contentContainer;
        
        // Desired width
        private double desiredWidth;

        // Collection of ribbon groups
        private ObservableCollection<RibbonGroupBox> groups;

        // Ribbon groups container
        private RibbonGroupsContainer groupsContainer = new RibbonGroupsContainer();

        // Cached width
        private double cachedWidth;

        #endregion

        #region Properties

        /// <summary>
        /// Gets ribbon groups container
        /// </summary>
        public RibbonGroupsContainer GroupsContainer
        {
            get { return groupsContainer; }
        }

        /// <summary>
        /// Gets or sets whether ribbon is minimized
        /// </summary>
        public bool IsMinimized
        {
            get { return (bool)GetValue(IsMinimizedProperty); }
            set { SetValue(IsMinimizedProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsMinimized.  
        /// This enables animation, styling, binding, etc...
        /// </summary>  
        public static readonly DependencyProperty IsMinimizedProperty = DependencyProperty.Register("IsMinimized", typeof(bool), typeof(RibbonTabItem), new UIPropertyMetadata(false));

        /// <summary>
        /// Gets or sets whether ribbon is opened
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsOpen.  
        /// This enables animation, styling, binding, etc...
        /// </summary>  
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(RibbonTabItem), new UIPropertyMetadata(false));

        /// <summary>
        /// Gets or sets reduce order
        /// </summary>
        public string ReduceOrder
        {
            get { return groupsContainer.ReduceOrder; }
            set { groupsContainer.ReduceOrder = value; }
        }

        #region IsContextual

        /// <summary>
        /// Gets or sets whether tab item is contextual
        /// </summary>
        public bool IsContextual
        {
            get { return (bool)GetValue(IsContextualProperty); }
            private set { SetValue(IsContextualPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsContextualPropertyKey =
            DependencyProperty.RegisterReadOnly("IsContextual", typeof(bool), typeof(RibbonTabItem), new UIPropertyMetadata(false));

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsContextual.  
        /// This enables animation, styling, binding, etc...
        /// </summary>  
        public static readonly DependencyProperty IsContextualProperty = IsContextualPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets an enumerator for logical child elements of this element.
        /// </summary>
        protected override System.Collections.IEnumerator LogicalChildren
        {
            get
            {
                /*ArrayList array = new ArrayList();
                array.Add(groupsContainer);
                return array.GetEnumerator();*/
                if (Groups != null) return Groups.GetEnumerator();
                else return (new ArrayList()).GetEnumerator();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets whether tab item is selected
        /// </summary>
        [Bindable(true), Category("Appearance")]
        public bool IsSelected
        {
            get
            {                
                return (bool)base.GetValue(IsSelectedProperty);
            }
            set
            {
                base.SetValue(IsSelectedProperty, value);
            }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsSelected.  
        /// This enables animation, styling, binding, etc...
        /// </summary>  
        public static readonly DependencyProperty IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof(RibbonTabItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsParentMeasure, new PropertyChangedCallback(RibbonTabItem.OnIsSelectedChanged)));

        /// <summary>
        /// Gets ribbon tab control parent
        /// </summary>
        internal RibbonTabControl TabControlParent
        {
            get
            {
                return (ItemsControl.ItemsControlFromItemContainer(this) as RibbonTabControl);
            }
        }


        /// <summary>
        /// Gets or sets indent
        /// </summary>
        public double Indent
        {
            get { return (double)GetValue(IndentProperty); }
            set { SetValue(IndentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for HeaderMargin.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IndentProperty =
            DependencyProperty.Register("Indent", typeof(double), typeof(RibbonTabItem), new UIPropertyMetadata((double)12.0));


        /// <summary>
        /// Gets or sets whether separator is visible
        /// </summary>
        public bool IsSeparatorVisible
        {
            get { return (bool)GetValue(IsSeparatorVisibleProperty); }
            set { SetValue(IsSeparatorVisibleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsSeparatorVisible.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsSeparatorVisibleProperty =
            DependencyProperty.Register("IsSeparatorVisible", typeof(bool), typeof(RibbonTabItem), new UIPropertyMetadata(false));

        /// <summary>
        /// Gets or sets ribbon contextual tab group
        /// </summary>
        public RibbonContextualTabGroup Group
        {
            get { return (RibbonContextualTabGroup)GetValue(GroupProperty); }
            set { SetValue(GroupProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Group.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty GroupProperty =
            DependencyProperty.Register("Group", typeof(RibbonContextualTabGroup), typeof(RibbonTabItem), new UIPropertyMetadata(null, OnGroupChanged));

        // handles Group property chanhged
        private static void OnGroupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTabItem tab = d as RibbonTabItem;
            if (e.OldValue != null) (e.OldValue as RibbonContextualTabGroup).RemoveTabItem(tab);
            if (e.NewValue != null)
            {
                (e.NewValue as RibbonContextualTabGroup).AppendTabItem(tab);
                tab.IsContextual = true;
            }
            else tab.IsContextual = false;
        }

        /// <summary>
        /// Gets or sets desired width of the tab item
        /// </summary>
        internal double DesiredWidth
        {
            get { return desiredWidth; }
            set { desiredWidth = value; InvalidateMeasure(); }
        }

        /// <summary>
        /// Gets or sets whether tab item has left group border
        /// </summary>
        public bool HasLeftGroupBorder
        {
            get { return (bool)GetValue(HasLeftGroupBorderProperty); }
            set { SetValue(HasLeftGroupBorderProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for HaseLeftGroupBorder.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HasLeftGroupBorderProperty =
            DependencyProperty.Register("HasLeftGroupBorder", typeof(bool), typeof(RibbonTabItem), new UIPropertyMetadata(false));

        /// <summary>
        /// Gets or sets whether tab item has right group border
        /// </summary>
        public bool HasRightGroupBorder
        {
            get { return (bool)GetValue(HasRightGroupBorderProperty); }
            set { SetValue(HasRightGroupBorderProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for HaseLeftGroupBorder.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HasRightGroupBorderProperty =
            DependencyProperty.Register("HasRightGroupBorder", typeof(bool), typeof(RibbonTabItem), new UIPropertyMetadata(false));

        /// <summary>
        /// get collection of ribbon groups
        /// </summary>
        public ObservableCollection<RibbonGroupBox> Groups
        {
            get
            {
                if (this.groups == null)
                {
                    this.groups = new ObservableCollection<RibbonGroupBox>();
                    this.groups.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnGroupsCollectionChanged);
                }
                return this.groups;
            }
        }
        // handles ribbon groups collection changes
        private void OnGroupsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object obj2 in e.NewItems)
                    {
                        if (groupsContainer != null) groupsContainer.Children.Add(obj2 as UIElement);                        
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object obj3 in e.OldItems)
                    {
                        if (groupsContainer != null) groupsContainer.Children.Remove(obj3 as UIElement);
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (object obj4 in e.OldItems)
                    {
                        if (groupsContainer != null) groupsContainer.Children.Remove(obj4 as UIElement);
                    }
                    foreach (object obj5 in e.NewItems)
                    {
                        if (groupsContainer != null) groupsContainer.Children.Add(obj5 as UIElement);
                    }
                    break;
            }

        }

        #region Header Property

        /// <summary>
        /// Gets or sets header of tab item
        /// </summary>
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(RibbonTabItem), new UIPropertyMetadata(null, OnHeaderChanged));

        // Header changed handler
        static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTabItem tabItem = (RibbonTabItem)d;
            tabItem.CoerceValue(ToolTipProperty);
        }

        #endregion

        #region Focusable

        /// <summary>
        /// Handles IsEnabled changes
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e">The event data.</param>
        private static void OnFocusableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// Coerces IsEnabled 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="basevalue"></param>
        /// <returns></returns>
        private static object CoerceFocusable(DependencyObject d, object basevalue)
        {
            RibbonTabItem control = (d as RibbonTabItem);
            if (control!=null)
            {                
                Ribbon ribbon = control.FindParentRibbon();
                if (ribbon != null)
                {
                    return ((bool)basevalue) && ribbon.Focusable;
                }
            }
            return basevalue;
        }
        
        // Find parent ribbon
        private Ribbon FindParentRibbon()
        {
            DependencyObject element = this.Parent;
            while (element != null)
            {
                Ribbon ribbon = element as Ribbon;
                if (ribbon!=null) return ribbon;
                element = VisualTreeHelper.GetParent(element);
            }
            return null;
        }

        #endregion 

        #endregion

        #region Initialize

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static RibbonTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RibbonTabItem), new FrameworkPropertyMetadata(typeof(RibbonTabItem)));
            FocusableProperty.AddOwner(typeof(RibbonTabItem), new FrameworkPropertyMetadata(OnFocusableChanged, CoerceFocusable));
            ToolTipProperty.OverrideMetadata(typeof(RibbonTabItem), new FrameworkPropertyMetadata(null, CoerceToolTip));
            VisibilityProperty.AddOwner(typeof (RibbonTabItem), new FrameworkPropertyMetadata(OnVisibilityChanged));
            StyleProperty.OverrideMetadata(typeof(RibbonTabItem), new FrameworkPropertyMetadata(null, new CoerceValueCallback(OnCoerceStyle)));
        }

        static object OnCoerceStyle(DependencyObject d, object basevalue)
        {
            if (basevalue == null)
            {
                basevalue = ((FrameworkElement)d).Resources["RibbonTabItemStyle"] as Style ??
                              Application.Current.Resources["RibbonTabItemStyle"] as Style;
            }

            return basevalue;
        }

        // Handles visibility changes
        static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTabItem item = d as RibbonTabItem;
            if((item.IsSelected)&&((Visibility)e.NewValue==Visibility.Collapsed))
            {
                if (item.TabControlParent != null) item.TabControlParent.SelectedItem = item.TabControlParent.Items[0];
            }
        }

        // Coerce ToolTip to ensure that tooltip displays name of the tabitem
        static object CoerceToolTip(DependencyObject d, object basevalue)
        {
            RibbonTabItem tabItem = (RibbonTabItem)d;
            if ((basevalue == null) && (tabItem.Header is string)) basevalue = tabItem.Header;
            return basevalue;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RibbonTabItem()
        {
            AddHandler(RibbonControl.ClickEvent, new RoutedEventHandler(OnClick));
            AddLogicalChild(groupsContainer);
            Binding binding = new Binding("DataContext");
            binding.Source = this;
            binding.Mode = BindingMode.OneWay;
            groupsContainer.SetBinding(DataContextProperty, binding);
        }
        
        // Handles Click event
        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (TabControlParent != null) if (TabControlParent.SelectedItem is RibbonTabItem)
                    (TabControlParent.SelectedItem as RibbonTabItem).IsSelected = false;
            IsSelected = true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Called to remeasure a control.
        /// </summary>
        /// <param name="constraint">The maximum size that the method can return.</param>
        /// <returns>The size of the control, up to the maximum specified by constraint.</returns>
        protected override Size MeasureOverride(Size constraint)
        {
            if (contentContainer == null) return base.MeasureOverride(constraint);
            contentContainer.Padding = new Thickness(Indent, contentContainer.Padding.Top, Indent, contentContainer.Padding.Bottom);
            Size baseConstraint = base.MeasureOverride(constraint);
            double totalWidth = contentContainer.DesiredSize.Width -contentContainer.Margin.Left - contentContainer.Margin.Right;
            (contentContainer.Child).Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            double headerWidth = contentContainer.Child.DesiredSize.Width;
            if (totalWidth < headerWidth + Indent * 2)
            {
                double newPaddings = Math.Max(0, (totalWidth - headerWidth) / 2);
                contentContainer.Padding = new Thickness(newPaddings, contentContainer.Padding.Top, newPaddings, contentContainer.Padding.Bottom);
            }
            else
            {
                if (desiredWidth != 0)
                {
                    // If header width is larger then tab increase tab width
                    if ((constraint.Width > desiredWidth)&&(desiredWidth>totalWidth)) baseConstraint.Width = desiredWidth;
                    else
                        baseConstraint.Width = headerWidth + Indent*2 + contentContainer.Margin.Left +
                                               contentContainer.Margin.Right;
                }
            }
            
            if ((cachedWidth!=baseConstraint.Width)&&(IsContextual)&&(Group!=null))
            {
                cachedWidth = baseConstraint.Width;
                FrameworkElement parent = (VisualTreeHelper.GetParent(Group) as FrameworkElement);
                if(parent != null) parent.InvalidateMeasure();
            }

            return baseConstraint;
        }

        /// <summary>
        /// On new style applying
        /// </summary>
        public override void OnApplyTemplate()
        {
            contentContainer = GetTemplateChild("PART_ContentContainer") as Border;
        }

        /// <summary>
        /// Invoked when an unhandled System.Windows.UIElement.MouseLeftButtonDown�routed event is raised 
        /// on this element. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.MouseButtonEventArgs that contains the event data. 
        /// The event data reports that the left mouse button was pressed.</param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (((e.Source == this) &&(e.ClickCount==2)))
            {
                e.Handled = true;
                if (TabControlParent != null) TabControlParent.IsMinimized = !TabControlParent.IsMinimized;
            }
            else if (((e.Source == this) || !this.IsSelected))
            {
                if (TabControlParent!=null) if (TabControlParent.SelectedItem is RibbonTabItem)
                    (TabControlParent.SelectedItem as RibbonTabItem).IsSelected = false;
                e.Handled = true;
                this.IsSelected = true;
            }            
        }

        #endregion

        #region Private methods

        // Handles IsSelected property changes
        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTabItem container = d as RibbonTabItem;
            bool newValue = (bool)e.NewValue;
            if (newValue)
            {
                if ((container.TabControlParent != null) && (container.TabControlParent.SelectedItem is RibbonTabItem) && (container.TabControlParent.SelectedItem != container))
                    (container.TabControlParent.SelectedItem as RibbonTabItem).IsSelected = false;
                container.OnSelected(new RoutedEventArgs(Selector.SelectedEvent, container));
            }
            else
            {
                container.OnUnselected(new RoutedEventArgs(Selector.UnselectedEvent, container));
            }
            
        }
        /// <summary>
        /// Handles selected
        /// </summary>
        /// <param name="e">The event data</param>
        protected virtual void OnSelected(RoutedEventArgs e)
        {
            this.HandleIsSelectedChanged(e);
        }
        /// <summary>
        /// handles unselected
        /// </summary>
        /// <param name="e">The event data</param>
        protected virtual void OnUnselected(RoutedEventArgs e)
        {
            this.HandleIsSelectedChanged(e);
        }

        #endregion

        #region Event handling

        // Handles IsSelected property changes
        private void HandleIsSelectedChanged(RoutedEventArgs e)
        {
            base.RaiseEvent(e);
        }

        #endregion
    }
}

#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright � Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace Fluent
{
    /// <summary>
    /// Represents title bar
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(RibbonContextualTabGroup))]
    [TemplatePart(Name = "PART_QuickAccessToolbarHolder", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "PART_HeaderHolder", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "PART_ItemsContainer", Type = typeof(Panel))]
    public class RibbonTitleBar: HeaderedItemsControl
    {
        #region Fields

        // Quick access toolbar holder
        private FrameworkElement quickAccessToolbarHolder;
        // Header holder
        private FrameworkElement headerHolder;
        // Items container
        private Panel itemsContainer;
        // Quick access toolbar rect
        private Rect quickAccessToolbarRect;
        // Header rect
        private Rect headerRect;
        // Items rect
        private Rect itemsRect;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets quick access toolbar
        /// </summary>
        public UIElement QuickAccessToolBar
        {
            get { return (UIElement)GetValue(QuickAccessToolBarProperty); }
            set { SetValue(QuickAccessToolBarProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for QuickAccessToolBar.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty QuickAccessToolBarProperty =
            DependencyProperty.Register("QuickAccessToolBar", typeof(UIElement), typeof(RibbonTitleBar), new UIPropertyMetadata(null,OnQuickAccessToolbarChanged));

        // Handles QuickAccessToolBar property chages
        private static void OnQuickAccessToolbarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RibbonTitleBar titleBar = (RibbonTitleBar)d;
            titleBar.InvalidateMeasure();
        }

        /// <summary>
        /// Gets or sets header alignment
        /// </summary>
        public HorizontalAlignment HeaderAlignment
        {
            get { return (HorizontalAlignment)GetValue(HeaderAlignmentProperty); }
            set { SetValue(HeaderAlignmentProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for HeaderAlignment.  This enables animation, styling, binding, etc...
        /// </summary> 
        public static readonly DependencyProperty HeaderAlignmentProperty =
            DependencyProperty.Register("HeaderAlignment", typeof(HorizontalAlignment), typeof(RibbonTitleBar), new UIPropertyMetadata(HorizontalAlignment.Center));

        /*/// <summary>
        /// Gets an enumerator to the logical child elements of the System.Windows.Controls.HeaderedItemsControl.
        /// </summary>
        protected override IEnumerator LogicalChildren
        {
            get
            {
                ArrayList list = new ArrayList();
                if (QuickAccessToolBar != null) list.Add(QuickAccessToolBar);
                return list.GetEnumerator();
            }
        }*/

        #endregion

        #region Initialize

        /// <summary>
        /// Static constructor
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static RibbonTitleBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RibbonTitleBar), new FrameworkPropertyMetadata(typeof(RibbonTitleBar)));
        }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public RibbonTitleBar()
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Creates or identifies the element that is used to display the given item.
        /// </summary>
        /// <returns>The element that is used to display the given item.</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RibbonContextualTabGroup();
        }

        /// <summary>
        /// Determines if the specified item is (or is eligible to be) its own container.
        /// </summary>
        /// <param name="item"> The item to check.</param>
        /// <returns>true if the item is (or is eligible to be) its own container; otherwise, false.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is RibbonContextualTabGroup);
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes 
        /// call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            quickAccessToolbarHolder = GetTemplateChild("PART_QuickAccessToolbarHolder") as FrameworkElement;
            headerHolder = GetTemplateChild("PART_HeaderHolder") as FrameworkElement;
            itemsContainer = GetTemplateChild("PART_ItemsContainer") as Panel;
        }

        /// <summary>
        /// Called to remeasure a control.
        /// </summary>
        /// <param name="constraint">The maximum size that the method can return.</param>
        /// <returns>The size of the control, up to the maximum specified by constraint.</returns>
        protected override Size MeasureOverride(Size constraint)
        {
            if ((quickAccessToolbarHolder == null) || (headerHolder == null) || (itemsContainer == null)) return base.MeasureOverride(constraint);
            Size resultSize = constraint;
            if((double.IsPositiveInfinity(resultSize.Width))||(double.IsPositiveInfinity(resultSize.Height))) resultSize = base.MeasureOverride(resultSize);
            Update(resultSize);
            
            itemsContainer.Measure(itemsRect.Size);
            headerHolder.Measure(headerRect.Size);
            quickAccessToolbarHolder.Measure(quickAccessToolbarRect.Size);

            return resultSize;
        }

        /// <summary>
        /// Called to arrange and size the content of a System.Windows.Controls.Control object.
        /// </summary>
        /// <param name="arrangeBounds">The computed size that is used to arrange the content.</param>
        /// <returns>The size of the control.</returns>
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            if ((quickAccessToolbarHolder == null) || (headerHolder == null) || (itemsContainer == null)) return base.ArrangeOverride(arrangeBounds);
            itemsContainer.Arrange(itemsRect);
            headerHolder.Arrange(headerRect);
            quickAccessToolbarHolder.Arrange(quickAccessToolbarRect);
            return arrangeBounds;
        }

        #endregion

        #region Private methods

        // Update items size and positions
        private void Update(Size constraint)
        {
            List<RibbonContextualTabGroup> visibleGroups = new List<RibbonContextualTabGroup>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] is RibbonContextualTabGroup)
                {
                    RibbonContextualTabGroup group = Items[i] as RibbonContextualTabGroup;
                    if ((group.Visibility == Visibility.Visible) && (group.Items.Count > 0)) visibleGroups.Add(group);
                }
            }

            Size infinity = new Size(double.PositiveInfinity, double.PositiveInfinity);

            if ((visibleGroups.Count == 0)||((visibleGroups[0].Items[0].Parent as RibbonTabControl).CanScroll))
            {
                // Collapse itemRect
                itemsRect = new Rect(0, 0, 0, 0);
                // Set quick launch toolbar and header position and size
                quickAccessToolbarHolder.Measure(infinity);
                if (constraint.Width > quickAccessToolbarHolder.DesiredSize.Width + 50)
                {
                    quickAccessToolbarRect = new Rect(0, 0, quickAccessToolbarHolder.DesiredSize.Width, quickAccessToolbarHolder.DesiredSize.Height);
                    headerHolder.Measure(infinity);
                    double allTextWidth = constraint.Width - quickAccessToolbarHolder.DesiredSize.Width;
                    if (HeaderAlignment == HorizontalAlignment.Left)
                    {
                        headerRect = new Rect(quickAccessToolbarHolder.DesiredSize.Width, 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                    else if (HeaderAlignment == HorizontalAlignment.Center)
                    {
                        headerRect = new Rect(quickAccessToolbarHolder.DesiredSize.Width + Math.Max(0, allTextWidth / 2 - headerHolder.DesiredSize.Width/2), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                    else if (HeaderAlignment == HorizontalAlignment.Right)
                    {
                        headerRect = new Rect(quickAccessToolbarHolder.DesiredSize.Width + Math.Max(0, allTextWidth - headerHolder.DesiredSize.Width), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                    else if (HeaderAlignment == HorizontalAlignment.Stretch)
                    {
                        headerRect = new Rect(quickAccessToolbarHolder.DesiredSize.Width, 0, allTextWidth, constraint.Height);
                    }                    
                }
                else
                {
                    quickAccessToolbarRect = new Rect(0, 0, Math.Max(0, constraint.Width-50), quickAccessToolbarHolder.DesiredSize.Height);
                    headerRect = new Rect(Math.Max(0, constraint.Width - 50), 0, 50, constraint.Height);
                    
                }
            }
            else
            {
                // Set items container size and position
                RibbonTabItem firstItem = visibleGroups[0].Items[0];
                RibbonTabItem lastItem = visibleGroups[visibleGroups.Count - 1].Items[visibleGroups[visibleGroups.Count - 1].Items.Count - 1];

                double startX = firstItem.TranslatePoint(new Point(0, 0), this).X;
                double endX = lastItem.TranslatePoint(new Point(lastItem.DesiredSize.Width, 0), this).X;

                itemsRect = new Rect(startX, 0, Math.Max(0, Math.Min(endX, constraint.Width) - startX), constraint.Height);
                // Set quick launch toolbar position and size
                quickAccessToolbarHolder.Measure(infinity);
                double quickAccessToolbarWidth = quickAccessToolbarHolder.DesiredSize.Width;
                if( startX < 0 )
                    quickAccessToolbarRect = new Rect(0, 0, Math.Min(quickAccessToolbarWidth, 0), quickAccessToolbarHolder.DesiredSize.Height);
                else
                    quickAccessToolbarRect = new Rect(0, 0, Math.Min(quickAccessToolbarWidth, startX), quickAccessToolbarHolder.DesiredSize.Height);
                
                // Set header
                headerHolder.Measure(infinity);
                if(HeaderAlignment==HorizontalAlignment.Left)
                {
                    if(startX-quickAccessToolbarWidth>150)
                    {
                        double allTextWidth = startX - quickAccessToolbarWidth;
                        headerRect = new Rect(quickAccessToolbarRect.Width, 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                    else
                    {
                        double allTextWidth = Math.Max(0,constraint.Width-endX);
                        headerRect = new Rect(Math.Min(endX,constraint.Width), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                }
                else if(HeaderAlignment==HorizontalAlignment.Center)
                {
                    if (((startX - quickAccessToolbarWidth < 150) && (startX - quickAccessToolbarWidth > 0) && (startX - quickAccessToolbarWidth < constraint.Width - endX)) || (endX < constraint.Width / 2))
                    {
                        double allTextWidth = Math.Max(0, constraint.Width - endX);
                        headerRect = new Rect(Math.Min(Math.Max(endX, constraint.Width / 2 - headerHolder.DesiredSize.Width / 2), constraint.Width), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);                        
                    }
                    else
                    {
                        double allTextWidth = Math.Max(0,startX - quickAccessToolbarWidth);
                        headerRect = new Rect(quickAccessToolbarHolder.DesiredSize.Width + Math.Max(0, allTextWidth / 2 - headerHolder.DesiredSize.Width / 2), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                }
                else if (HeaderAlignment == HorizontalAlignment.Right)
                {
                    if (startX - quickAccessToolbarWidth > 150)
                    {
                        double allTextWidth = Math.Max(0,startX - quickAccessToolbarWidth);
                        headerRect = new Rect(quickAccessToolbarHolder.DesiredSize.Width + Math.Max(0, allTextWidth - headerHolder.DesiredSize.Width), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                    else
                    {
                        double allTextWidth = Math.Max(0, constraint.Width - endX);
                        headerRect = new Rect(Math.Min(Math.Max(endX, constraint.Width - headerHolder.DesiredSize.Width), constraint.Width), 0, Math.Min(allTextWidth, headerHolder.DesiredSize.Width), constraint.Height);
                    }
                }
                else if(HeaderAlignment==HorizontalAlignment.Stretch)
                {
                    if(startX-quickAccessToolbarWidth>150)
                    {
                        double allTextWidth = startX - quickAccessToolbarWidth;
                        headerRect = new Rect(quickAccessToolbarRect.Width, 0, allTextWidth, constraint.Height);
                    }
                    else
                    {
                        double allTextWidth = Math.Max(0,constraint.Width-endX);
                        headerRect = new Rect(Math.Min(endX, constraint.Width), 0, allTextWidth, constraint.Height);
                    }
                }
            }
        }

        #endregion
    }
}

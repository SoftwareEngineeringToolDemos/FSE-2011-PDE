#region Copyright and License Information
// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright � Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Fluent
{
    /// <summary>
    /// Represents host for context menu items
    /// </summary>
    [TemplatePart(Name = "PART_ResizeBothThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_ResizeVerticalThumb", Type = typeof(Thumb))]
    public class ContextMenuBar : ItemsControl
    {
        #region Fields

        // Thumb to resize in both directions
        Thumb resizeBothThumb;
        // Thumb to resize vertical
        Thumb resizeVerticalThumb;
        // The main panel with Items
        Panel itemsHost;

        #endregion

        #region Properties

        #region ResizeMode Property

        /// <summary>
        /// Gets or sets context menu resize mode
        /// </summary>
        public ContextMenuResizeMode ResizeMode
        {
            get { return (ContextMenuResizeMode)GetValue(ResizeModeProperty); }
            set { SetValue(ResizeModeProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ResizeMode. 
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ResizeModeProperty =
            DependencyProperty.Register("ResizeMode", typeof(ContextMenuResizeMode),
            typeof(ContextMenuBar), new UIPropertyMetadata(ContextMenuResizeMode.None));

        #endregion

        #region ParentContextMenu Property

        /// <summary>
        /// Gets or sets owner context menue
        /// </summary>       
        public ContextMenu ParentContextMenu
        {
            get { return (ContextMenu)GetValue(ParentContextMenuProperty); }
            set { SetValue(ParentContextMenuProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for OwnerContextMenu.  
        /// This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ParentContextMenuProperty =
            DependencyProperty.Register("ParentContextMenu", typeof(ContextMenu), typeof(ContextMenuBar), new UIPropertyMetadata(null));

        #endregion

        #endregion

        #region Constructors

        [SuppressMessage("Microsoft.Performance", "CA1810")]
        static ContextMenuBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContextMenuBar), new FrameworkPropertyMetadata(typeof(ContextMenuBar)));
            FocusVisualStyleProperty.OverrideMetadata(typeof(ContextMenuBar), new FrameworkPropertyMetadata(null));            
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ContextMenuBar()
        {
            Focusable = false;
            FocusManager.SetIsFocusScope(this,true);
            KeyboardNavigation.SetDirectionalNavigation(this, KeyboardNavigationMode.Cycle);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Creates or identifies the element that is used to display the given item.
        /// </summary>
        /// <returns>The element that is used to display the given item.</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MenuItem();
        }

        /// <summary>
        /// Determines if the specified item is (or is eligible to be) its own container.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>true if the item is (or is eligible to be) its own container; otherwise, false.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is FrameworkElement);
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or 
        /// internal processes call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            if (resizeVerticalThumb != null)
            {
                resizeVerticalThumb.DragDelta -= OnResizeVerticalDelta;
            }
            resizeVerticalThumb = GetTemplateChild("PART_ResizeVerticalThumb") as Thumb;
            if (resizeVerticalThumb != null)
            {
                resizeVerticalThumb.DragDelta += OnResizeVerticalDelta;
            }

            if (resizeBothThumb != null)
            {
                resizeBothThumb.DragDelta -= OnResizeBothDelta;
            }
            resizeBothThumb = GetTemplateChild("PART_ResizeBothThumb") as Thumb;
            if (resizeBothThumb != null)
            {
                resizeBothThumb.DragDelta += OnResizeBothDelta;
            }

            itemsHost = GetTemplateChild("PART_ItemsHost") as Panel;
        }

        /// <summary>
        /// Invoked when an unhandled System.Windows.Input.Keyboard.KeyDown�attached event 
        /// reaches an element in its route that is derived from this class. 
        /// Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The System.Windows.Input.KeyEventArgs that contains the event data.</param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {

        }

        #endregion

        #region Private methods
       
        // Handles resize both drag
        private void OnResizeBothDelta(object sender, DragDeltaEventArgs e)
        {
            if (double.IsNaN(itemsHost.Width)) itemsHost.Width = itemsHost.ActualWidth;
            if (double.IsNaN(itemsHost.Height)) itemsHost.Height = itemsHost.ActualHeight;
            itemsHost.Width = Math.Max(itemsHost.MinWidth, itemsHost.Width + e.HorizontalChange);
            itemsHost.Height = Math.Max(itemsHost.MinHeight, itemsHost.Height + e.VerticalChange);
        }

        // Handles resize vertical drag
        private void OnResizeVerticalDelta(object sender, DragDeltaEventArgs e)
        {
            if (double.IsNaN(itemsHost.Height)) itemsHost.Height = itemsHost.ActualHeight;
            itemsHost.Height = Math.Max(itemsHost.MinHeight, itemsHost.Height + e.VerticalChange);
        }

        #endregion
    }
}

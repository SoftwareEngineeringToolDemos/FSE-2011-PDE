using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities;
using System.Windows.Controls.Primitives;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop
{
    /// <summary>
    /// This class provides drag and drop behavior.
    /// </summary>
    /// <remarks>
    /// Source: http://www.codeproject.com/KB/WPF/gong-wpf-dragdrop-ii.aspx
    /// </remarks>
    public static class DragDrop
    {
        #region Attached Properties
        /// <summary>
        /// Get drag adorner template.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static DataTemplate GetDragAdornerTemplate(UIElement target)
        {
            return (DataTemplate)target.GetValue(DragAdornerTemplateProperty);
        }

        /// <summary>
        /// Set drag adorner template.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetDragAdornerTemplate(UIElement target, DataTemplate value)
        {
            target.SetValue(DragAdornerTemplateProperty, value);
        }

        /// <summary>
        /// Get is drag source.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool GetIsDragSource(UIElement target)
        {
            return (bool)target.GetValue(IsDragSourceProperty);
        }

        /// <summary>
        /// Set is drag source.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetIsDragSource(UIElement target, bool value)
        {
            target.SetValue(IsDragSourceProperty, value);
        }

        /// <summary>
        /// Get is drop target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool GetIsDropTarget(UIElement target)
        {
            return (bool)target.GetValue(IsDropTargetProperty);
        }

        /// <summary>
        /// Set is drop target.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetIsDropTarget(UIElement target, bool value)
        {
            target.SetValue(IsDropTargetProperty, value);
        }

        /// <summary>
        /// Get drag handler.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IDragSource GetDragHandler(UIElement target)
        {
            return (IDragSource)target.GetValue(DragHandlerProperty);
        }

        /// <summary>
        /// Set drag handler.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetDragHandler(UIElement target, IDragSource value)
        {
            target.SetValue(DragHandlerProperty, value);
        }

        /// <summary>
        /// Get drop handler.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IDropTarget GetDropHandler(UIElement target)
        {
            return (IDropTarget)target.GetValue(DropHandlerProperty);
        }

        /// <summary>
        /// Set drop handler.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetDropHandler(UIElement target, IDropTarget value)
        {
            target.SetValue(DropHandlerProperty, value);
        }

        /// <summary>
        /// Default drag handler.
        /// </summary>
        public static IDragSource DefaultDragHandler
        {
            get
            {
                if (m_DefaultDragHandler == null)
                {
                    m_DefaultDragHandler = new DefaultDragHandler();
                }

                return m_DefaultDragHandler;
            }
            set
            {
                m_DefaultDragHandler = value;
            }
        }

        /// <summary>
        /// Default drop handler.
        /// </summary>
        public static IDropTarget DefaultDropHandler
        {
            get
            {
                if (m_DefaultDropHandler == null)
                {
                    m_DefaultDropHandler = new DefaultDropHandler();
                }

                return m_DefaultDropHandler;
            }
            set
            {
                m_DefaultDropHandler = value;
            }
        }

        /// <summary>
        /// Drag adorner template.
        /// </summary>
        public static readonly DependencyProperty DragAdornerTemplateProperty =
            DependencyProperty.RegisterAttached("DragAdornerTemplate", typeof(DataTemplate), typeof(DragDrop));

        /// <summary>
        /// Drag handler.
        /// </summary>
        public static readonly DependencyProperty DragHandlerProperty =
            DependencyProperty.RegisterAttached("DragHandler", typeof(IDragSource), typeof(DragDrop));

        /// <summary>
        /// Drop handler.
        /// </summary>
        public static readonly DependencyProperty DropHandlerProperty =
            DependencyProperty.RegisterAttached("DropHandler", typeof(IDropTarget), typeof(DragDrop));

        /// <summary>
        /// Is drag source.
        /// </summary>
        public static readonly DependencyProperty IsDragSourceProperty =
            DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(DragDrop),
                new UIPropertyMetadata(false, IsDragSourceChanged));

        /// <summary>
        /// Is drop target.
        /// </summary>
        public static readonly DependencyProperty IsDropTargetProperty =
            DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(DragDrop),
                new UIPropertyMetadata(false, IsDropTargetChanged));
        #endregion

        static void IsDragSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiElement = (UIElement)d;
            if ((bool)e.NewValue == true)
            {
                uiElement.PreviewMouseLeftButtonDown += DragSource_PreviewMouseLeftButtonDown;
                uiElement.PreviewMouseLeftButtonUp += DragSource_PreviewMouseLeftButtonUp;
                uiElement.PreviewMouseMove += DragSource_PreviewMouseMove;
            }
            else
            {
                uiElement.PreviewMouseLeftButtonDown -= DragSource_PreviewMouseLeftButtonDown;
                uiElement.PreviewMouseLeftButtonUp -= DragSource_PreviewMouseLeftButtonUp;
                uiElement.PreviewMouseMove -= DragSource_PreviewMouseMove;
            }
        }
        static void IsDropTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiElement = (UIElement)d;

            if ((bool)e.NewValue == true)
            {
                uiElement.AllowDrop = true;
                uiElement.PreviewDragEnter += DropTarget_PreviewDragEnter;
                uiElement.PreviewDragLeave += DropTarget_PreviewDragLeave;
                uiElement.PreviewDragOver += DropTarget_PreviewDragOver;
                uiElement.PreviewDrop += DropTarget_PreviewDrop;
            }
            else
            {
                uiElement.AllowDrop = false;
                uiElement.PreviewDragEnter -= DropTarget_PreviewDragEnter;
                uiElement.PreviewDragLeave -= DropTarget_PreviewDragLeave;
                uiElement.PreviewDragOver -= DropTarget_PreviewDragOver;
                uiElement.PreviewDrop -= DropTarget_PreviewDrop;
            }
        }

        static void CreateDragAdorner()
        {
            DataTemplate template = GetDragAdornerTemplate(m_DragInfo.VisualSource);

            if (template != null)
            {
                UIElement rootElement = (UIElement)Application.Current.MainWindow.Content;
                UIElement adornment = null;

                if (m_DragInfo.Data is IEnumerable && !(m_DragInfo.Data is string))
                {
                    if (((IEnumerable)m_DragInfo.Data).Cast<object>().Count() <= 10)
                    {
                        ItemsControl itemsControl = new ItemsControl();
                        itemsControl.ItemsSource = (IEnumerable)m_DragInfo.Data;
                        itemsControl.ItemTemplate = template;

                        // The ItemsControl doesn't display unless we create a border to contain it.
                        // Not quite sure why this is...
                        Border border = new Border();
                        border.Child = itemsControl;
                        adornment = border;
                    }
                }
                else
                {
                    ContentPresenter contentPresenter = new ContentPresenter();
                    contentPresenter.Content = m_DragInfo.Data;
                    contentPresenter.ContentTemplate = template;
                    adornment = contentPresenter;
                }

                if (adornment != null)
                {
                    adornment.Opacity = 0.5;
                    DragAdorner = new DragAdorner(rootElement, adornment);
                }
            }
        }

        static bool HitTestScrollBar(object sender, MouseButtonEventArgs e)
        {
            HitTestResult hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            return hit.VisualHit.GetVisualAncestor<System.Windows.Controls.Primitives.ScrollBar>() != null;
        }

        static void Scroll(DependencyObject o, DragEventArgs e)
        {
            ScrollViewer scrollViewer = o.GetVisualDescendent<ScrollViewer>();

            if (scrollViewer != null)
            {
                Point position = e.GetPosition(scrollViewer);
                double scrollMargin = Math.Min(scrollViewer.FontSize * 2, scrollViewer.ActualHeight / 2);

                if (position.X >= scrollViewer.ActualWidth - scrollMargin &&
                    scrollViewer.HorizontalOffset < scrollViewer.ExtentWidth - scrollViewer.ViewportWidth)
                {
                    scrollViewer.LineRight();
                }
                else if (position.X < scrollMargin && scrollViewer.HorizontalOffset > 0)
                {
                    scrollViewer.LineLeft();
                }
                else if (position.Y >= scrollViewer.ActualHeight - scrollMargin &&
                    scrollViewer.VerticalOffset < scrollViewer.ExtentHeight - scrollViewer.ViewportHeight)
                {
                    scrollViewer.LineDown();
                }
                else if (position.Y < scrollMargin && scrollViewer.VerticalOffset > 0)
                {
                    scrollViewer.LineUp();
                }
            }
        }

        private static MouseButtonEventArgs argsSaved = null;
        private static bool ignoreEventOnce = false;
        private static object sourceItemTemp = null;
        static void DragSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Ignore the click if the user has clicked on a scrollbar.
            if (HitTestScrollBar(sender, e))
            {
                m_DragInfo = null;
                return;
            }

            m_DragInfo = new DragInfo(sender, e);
            
            // If the sender is a list box that allows multiple selections, ensure that clicking on an 
            // already selected item does not change the selection, otherwise dragging multiple items 
            // is made impossible.
            ItemsControl itemsControl = sender as ItemsControl;


            // ignore the event if we reraised it to assure correct behavior
            if (ignoreEventOnce)
            {
                if (itemsControl is Selector && sourceItemTemp != null)
                    ((Selector)itemsControl).SelectedItem = null;
                ignoreEventOnce = false;
                return;
            }

            if (m_DragInfo.VisualSourceItem != null && itemsControl != null && itemsControl.CanSelectMultipleItems())
            {
                IEnumerable selectedItems = itemsControl.GetSelectedItems();

                if (selectedItems.Cast<object>().Contains(m_DragInfo.SourceItem))
                {
                    if( e.ClickCount == 1 )
                        if (itemsControl is Selector && Keyboard.Modifiers != ModifierKeys.Shift && Keyboard.Modifiers != ModifierKeys.Control)
                        {
                            sourceItemTemp = m_DragInfo.SourceItem;
                            argsSaved = e;
                            e.Handled = true;
                        }
                }
            }             
        }
        static void DragSource_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (m_DragInfo != null)
            {
                m_DragInfo = null;
            }
            
            UIElement element = sender as UIElement;
            if (element.IsMouseCaptured)
                element.ReleaseMouseCapture();

            if (argsSaved != null)
            {
                ignoreEventOnce = true;
                element.RaiseEvent(argsSaved);
                argsSaved = null;
            }
        }
        static void DragSource_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (m_DragInfo != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Point dragStart = m_DragInfo.DragStartPosition;
                Point position = e.GetPosition(null);

                if (Math.Abs(position.X - dragStart.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - dragStart.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    IDragSource dragHandler = GetDragHandler(m_DragInfo.VisualSource);

                    // drag started
                    argsSaved = null;
                    sourceItemTemp = null;

                    if (dragHandler != null)
                    {
                        dragHandler.StartDrag(m_DragInfo);
                    }
                    else
                    {
                        DefaultDragHandler.StartDrag(m_DragInfo);
                    }

                    if (m_DragInfo.Effects != DragDropEffects.None && m_DragInfo.Data != null)
                    {
                        DataObject data = new DataObject(m_Format.Name, m_DragInfo.Data);
                        System.Windows.DragDrop.DoDragDrop(m_DragInfo.VisualSource, data, m_DragInfo.Effects);
                        m_DragInfo = null;
                    }
                }
            }
            else
            {
                m_DragInfo = null;

                UIElement element = sender as UIElement;
                if (element.IsMouseCaptured)
                    element.ReleaseMouseCapture();
            }
        }
        static void DropTarget_PreviewDragEnter(object sender, DragEventArgs e)
        {
            DropTarget_PreviewDragOver(sender, e);
        }
        static void DropTarget_PreviewDragLeave(object sender, DragEventArgs e)
        {
            DragAdorner = null;
            DropTargetAdorner = null;
        }
        static void DropTarget_PreviewDragOver(object sender, DragEventArgs e)
        {
            DropInfo dropInfo = new DropInfo(sender, e, m_DragInfo, m_Format.Name);
            IDropTarget dropHandler = GetDropHandler((UIElement)sender);

            if (dropHandler != null)
            {
                dropHandler.DragOver(dropInfo);
            }
            else
            {
                DefaultDropHandler.DragOver(dropInfo);
            }

            // Update the drag adorner.
            if (dropInfo.Effects != DragDropEffects.None)
            {
                if (DragAdorner == null && m_DragInfo != null)
                {
                    CreateDragAdorner();
                }

                if (DragAdorner != null)
                {
                    DragAdorner.MousePosition = e.GetPosition(DragAdorner.AdornedElement);
                    DragAdorner.InvalidateVisual();
                }
            }
            else
            {
                DragAdorner = null;
            }

            // If the target is an ItemsControl then update the drop target adorner.
            if (sender is ItemsControl)
            {
                UIElement adornedElement = ((ItemsControl)sender).GetVisualDescendent<ItemsPresenter>();
                if (adornedElement == null)
                {
                    adornedElement = ((ItemsControl)sender).GetVisualDescendents<Panel>().FirstOrDefault(p => p.IsItemsHost);
                }


                if (dropInfo.DropTargetAdorner == null)
                {
                    DropTargetAdorner = null;
                }
                else if (!dropInfo.DropTargetAdorner.IsInstanceOfType(DropTargetAdorner))
                {
                    DropTargetAdorner = DropTargetAdorner.Create(dropInfo.DropTargetAdorner, adornedElement);
                }

                if (DropTargetAdorner != null)
                {
                    DropTargetAdorner.DropInfo = dropInfo;
                    DropTargetAdorner.InvalidateVisual();
                }
            }

            e.Effects = dropInfo.Effects;
            e.Handled = !dropInfo.IsNotHandled; // Allows bubbling

            Scroll((DependencyObject)sender, e);
        }
        static void DropTarget_PreviewDrop(object sender, DragEventArgs e)
        {
            DropInfo dropInfo = new DropInfo(sender, e, m_DragInfo, m_Format.Name);
            IDropTarget dropHandler = GetDropHandler((UIElement)sender);

            DragAdorner = null;
            DropTargetAdorner = null;

            if (dropHandler != null)
            {
                dropHandler.Drop(dropInfo);
            }
            else
            {
                DefaultDropHandler.Drop(dropInfo);
            }

            e.Handled = !dropInfo.IsNotHandled; // Allows bubbling
        }

        static DragAdorner DragAdorner
        {
            get { return m_DragAdorner; }
            set
            {
                if (m_DragAdorner != null)
                {
                    m_DragAdorner.Detatch();
                }

                m_DragAdorner = value;
            }
        }
        static DropTargetAdorner DropTargetAdorner
        {
            get { return m_DropTargetAdorner; }
            set
            {
                if (m_DropTargetAdorner != null)
                {
                    m_DropTargetAdorner.Detatch();
                }

                m_DropTargetAdorner = value;
            }
        }

        static IDragSource m_DefaultDragHandler;
        static IDropTarget m_DefaultDropHandler;
        static DragAdorner m_DragAdorner;
        static DragInfo m_DragInfo;
        static DropTargetAdorner m_DropTargetAdorner;
        static DataFormat m_Format = DataFormats.GetDataFormat("GongSolutions.Wpf.DragDrop");
    }
}

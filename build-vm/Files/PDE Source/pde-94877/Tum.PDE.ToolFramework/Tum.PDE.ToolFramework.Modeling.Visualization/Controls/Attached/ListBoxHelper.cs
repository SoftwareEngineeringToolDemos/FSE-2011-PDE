using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached
{
    /// <summary>
    /// Attached properties for ListBox-Control: 
    /// 
    /// - DoubleClickDialogResultProperty: Simulates DialogResult as known in WinForms (on double click on an ListBoxItem).
    /// - DisgardsScrollViewOnMouseWheel:
    /// 
    /// </summary>
    public class ListBoxHelper
    {
        #region DoubleClickDialogResultProperty
        /// <summary>
        /// Gets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Value of the property.</returns>
        public static bool? GetDoubleClickDialogResult(DependencyObject obj) { return (bool?)obj.GetValue(DoubleClickDialogResultProperty); }

        /// <summary>
        /// Sets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Value.</param>
        /// <returns>Value of the property.</returns>
        public static void SetDoubleClickDialogResult(DependencyObject obj, bool? value) { obj.SetValue(DoubleClickDialogResultProperty, value); }

        /// <summary>
        /// Double click dialog result property.
        /// </summary>
        public static readonly DependencyProperty DoubleClickDialogResultProperty = DependencyProperty.RegisterAttached("DoubleClickDialogResult", typeof(bool?), typeof(ListBoxHelper), new UIPropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                // Implementation of DialogResult functionality
                ListBox listbox = obj as ListBox;
                if (listbox == null)
                    throw new InvalidOperationException("Can only use ListBoxHelper.DialogResult on a ListBox control");

                listbox.MouseDoubleClick += (sender, e2) =>
                {
                    if ( DoubleClickOnListboxItem(e2) )
                        Window.GetWindow(listbox).DialogResult = GetDoubleClickDialogResult(listbox);
                };
            }
        });

        /// <summary>
        /// Double click on listbox item handler.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool DoubleClickOnListboxItem(MouseButtonEventArgs args)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = (DependencyObject)args.MouseDevice.DirectlyOver;
            while (parent != null)
            {
                if (parent is ListBox)
                    return false;
                else if (parent is ListBoxItem)
                    return true;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }
            return false;
        }
        #endregion

        #region Preventing ScrollViewer from handling the mouse wheel
        /// <summary>
        /// Gets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Value of the property.</returns>
        public static bool? GetDisgardsScrollViewOnMouseWheel(DependencyObject obj) { return (bool)obj.GetValue(DisgardsScrollViewOnMouseWheelProperty); }

        /// <summary>
        /// Sets the value for the property on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Value.</param>
        /// <returns>Value of the property.</returns>
        public static void SetDisgardsScrollViewOnMouseWheel(DependencyObject obj, bool value) { obj.SetValue(DisgardsScrollViewOnMouseWheelProperty, value); }

        /// <summary>
        /// Disgards scroll view on mouse wheel property.
        /// </summary>
        public static readonly DependencyProperty DisgardsScrollViewOnMouseWheelProperty = DependencyProperty.RegisterAttached("DisgardsScrollViewOnMouseWheel", typeof(bool), typeof(ListBoxHelper), new UIPropertyMetadata(false,
            (obj, e) =>
            {
                ListBox listbox = obj as ListBox;
                if (listbox != null)
                {
                    bool oldValue = (bool)e.OldValue;
                    bool newValue = (bool)e.NewValue;
                    if (oldValue && !newValue)
                    {
                        listbox.PreviewMouseWheel -= new MouseWheelEventHandler(PreviewMouseWheelOnListboxItem);
                    }
                    if (!oldValue && newValue)
                    {
                        listbox.PreviewMouseWheel += new MouseWheelEventHandler(PreviewMouseWheelOnListboxItem);
                    }
                }
            })
        );

        static void PreviewMouseWheelOnListboxItem(object sender, MouseWheelEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            if( listbox != null )
                if (!e.Handled)
                {
                    e.Handled = true;
                    var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                    eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                    eventArg.Source = sender;

                    var parent = listbox.Parent as UIElement;
                    parent.RaiseEvent(eventArg);
                }
        }
        #endregion
    }
}

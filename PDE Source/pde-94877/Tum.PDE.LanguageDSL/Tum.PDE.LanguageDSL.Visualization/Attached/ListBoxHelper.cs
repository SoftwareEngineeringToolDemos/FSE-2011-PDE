using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Tum.PDE.LanguageDSL.Visualization.Attached
{
    // <summary>
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
                    if (DoubleClickOnListboxItem(e2))
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
    }
}

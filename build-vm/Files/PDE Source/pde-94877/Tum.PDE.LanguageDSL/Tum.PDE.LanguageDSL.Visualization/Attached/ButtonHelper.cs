using System;
using System.Windows;
using System.Windows.Controls;

namespace Tum.PDE.LanguageDSL.Visualization.Attached
{
    /// <summary>
    /// Attached properties for Button-Control: 
    /// 
    /// - DialogResultProperty: Simulates DialogResult as known in WinForms.
    /// 
    /// 
    /// </summary>
    public class ButtonHelper
    {
        #region Boilerplate code to register attached property "bool? DialogResult"
        /// <summary>
        /// Gets the dialog result value for the DialogResultProperty on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Value of the property.</returns>
        public static bool? GetDialogResult(DependencyObject obj) { return (bool?)obj.GetValue(DialogResultProperty); }
        /// <summary>
        /// Sets the dialog result value for the DialogResultProperty on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Value.</param>
        /// <returns>Value of the property.</returns>
        public static void SetDialogResult(DependencyObject obj, bool? value) { obj.SetValue(DialogResultProperty, value); }

        /// <summary>
        /// Dialog result property.
        /// </summary>
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(ButtonHelper), new UIPropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                // Implementation of DialogResult functionality
                Button button = obj as Button;
                if (button == null)
                    throw new InvalidOperationException("Can only use ButtonHelper.DialogResult on a Button control");

                button.Click += (sender, e2) =>
                {
                    Window.GetWindow(button).DialogResult = GetDialogResult(button);
                };
            }
        });
        #endregion
    }

}

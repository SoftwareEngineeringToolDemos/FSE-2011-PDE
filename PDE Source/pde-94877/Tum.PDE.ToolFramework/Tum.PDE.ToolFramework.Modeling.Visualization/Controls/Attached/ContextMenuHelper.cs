using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached
{
    /// <summary>
    /// Behaviors for the context menu.
    /// </summary>
    public class ContextMenuHelper
    {
        #region ShouldHideIfEmpty
        /// <summary>
        /// Gets the dialog result value for the ShouldHideIfEmptyProperty on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Value of the property.</returns>
        public static bool? GetShouldHideIfEmpty(DependencyObject obj) { return (bool?)obj.GetValue(ShouldHideIfEmptyProperty); }
        /// <summary>
        /// Sets the dialog result value for the ShouldHideIfEmptyProperty on the given dependency object.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Value.</param>
        /// <returns>Value of the property.</returns>
        public static void SetShouldHideIfEmpty(DependencyObject obj, bool? value) { obj.SetValue(ShouldHideIfEmptyProperty, value); }

        /// <summary>
        /// Dialog result property.
        /// </summary>
        public static readonly DependencyProperty ShouldHideIfEmptyProperty = DependencyProperty.RegisterAttached("ShouldHideIfEmpty", typeof(bool?), typeof(ContextMenuHelper), new UIPropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                System.Windows.Controls.ContextMenu menu = obj as System.Windows.Controls.ContextMenu;
                if (menu == null)
                    throw new InvalidOperationException("Can only use ContextMenu.ShouldHideIfEmpty on a ContextMenu");

                bool? val = GetShouldHideIfEmpty(menu);
                if (val == true)
                {
                    
                }
            }
        });
        #endregion
    }
}

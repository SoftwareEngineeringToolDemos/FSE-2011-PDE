using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Controls;
using System.Windows;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Common
{
    /// <summary>
    /// Combobox with a display text dependency property.
    /// </summary>
    public class ComboBoxWithDisplayText : ComboBox
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static ComboBoxWithDisplayText()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxWithDisplayText), new FrameworkPropertyMetadata(typeof(ComboBoxWithDisplayText)));
        }

        /// <summary>
        /// Gets or sets the text displayed in the ComboBox
        /// </summary>
        public string DisplayText
        {
            get { return (string)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        /// <summary>
        /// DisplayText dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText", typeof(string), typeof(ComboBoxWithDisplayText), new UIPropertyMetadata(string.Empty));
    }
}

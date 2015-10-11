using System;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Converters
{
    /// <summary>
    /// Converts bool to "Underline" if true; to null if false.
    /// </summary>
    public class BoolToUnderlineConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to its target type.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Optional parameter to use during conversion.</param>
        /// <param name="culture">CultureInfo to use during conversion.</param>
        /// <returns>Converted value</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
                if ((bool)value)
                    return "Underline";

            return null;
        }

        /// <summary>
        /// Converts a value to its target type.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Optional parameter to use during conversion.</param>
        /// <param name="culture">CultureInfo to use during conversion.</param>
        /// <returns>Converted value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

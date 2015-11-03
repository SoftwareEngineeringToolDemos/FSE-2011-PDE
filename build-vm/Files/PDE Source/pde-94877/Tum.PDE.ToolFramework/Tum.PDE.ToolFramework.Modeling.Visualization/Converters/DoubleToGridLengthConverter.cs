using System;
using System.Windows;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Converters
{
    /// <summary>
    /// Converts a double value to GridLength and vice versa.
    /// </summary>
    public class DoubleToGridLengthConverter : IValueConverter
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
            if (value is double)
                return new GridLength((double)value);

            return value;
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
            if (value is GridLength)
                return ((GridLength)value).Value;

            return value;
        }

    }
}

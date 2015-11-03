using System;
using System.Windows;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Converters
{
    /// <summary>
    /// This class converts boolean to visibility and vice versa. Should the incoming values be null,
    /// 'Visibility.Collapsed' or 'false' are returned.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
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
            if (value == null || !(value is bool))
                return Visibility.Collapsed;

            bool val = (bool)value;
            if (val)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
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
            if (value == null || !(value is Visibility))
                return false;

            Visibility val = (Visibility)value;
            if (val == Visibility.Visible)
                return true;
            else
                return false;

            throw new NotImplementedException();
        }
    }
}

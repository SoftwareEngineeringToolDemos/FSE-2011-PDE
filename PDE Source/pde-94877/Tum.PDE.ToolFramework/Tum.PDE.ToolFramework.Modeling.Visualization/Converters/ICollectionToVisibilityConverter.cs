using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Converters
{
    /// <summary>
    /// This converters returns Visibility.Collapsed if the given ICollection is empty. Visibility.Visible otherwise.
    /// Visibility.Visible is also returned if the given value is null.
    /// </summary>
    public class ICollectionToVisibilityConverter : IValueConverter
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
            if( value == null || !(value is ICollection) )
                return Visibility.Visible;

            if( (value as ICollection).Count == 0 )
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
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

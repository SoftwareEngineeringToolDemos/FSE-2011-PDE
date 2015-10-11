using System;
using System.Collections;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Converters
{
    /// <summary>
    /// Converts an ICollection to a number that represents how many elements that ICollection contains
    /// </summary>
    public class ICollectionToNumberConverter : IValueConverter
    {
        /// <summary>
        /// Value to be appended whenever the collection is empty.
        /// </summary>
        public string AppendValueOnEmpty {get; set;}

        /// <summary>
        /// Value to be appended whenever the collection consists of only one element.
        /// </summary>
        public string AppendValueOnOneElement { get; set; }

        /// <summary>
        /// Value to be appended whenever the collection contains multiple elements.
        /// </summary>
        public string AppendValueOnMultipleElements { get; set; }

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
            int count = 0;

            if( value == null || !(value is ICollection))
                count = 0;
            else
                count = (value as ICollection).Count;

            string ret = count.ToString();
            if( count == 0 && AppendValueOnEmpty != null)
                return ret + " " + AppendValueOnEmpty;
            else if( count == 1 && AppendValueOnOneElement != null)
                return ret + " " + AppendValueOnOneElement;
            else if( count > 0 && AppendValueOnMultipleElements != null)
                return ret + " " + AppendValueOnMultipleElements;
            else
                return ret;
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

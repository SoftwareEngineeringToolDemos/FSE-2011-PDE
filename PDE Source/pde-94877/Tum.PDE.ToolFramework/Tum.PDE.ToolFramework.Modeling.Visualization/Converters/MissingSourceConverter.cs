using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Converters
{
    /// <summary>
    /// Missing source converter provides a text if the source is missing.
    /// </summary>
    public class MissingSourceConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the missing source text.
        /// </summary>
        public string MissingSourceText
        {
            get;
            set;
        }

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if( value == null )
                return MissingSourceText;

            if (String.IsNullOrEmpty(value.ToString()) || String.IsNullOrWhiteSpace(value.ToString()))
                return MissingSourceText;
            else
                return value;
        }

        /// <summary>
        /// Convert back.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

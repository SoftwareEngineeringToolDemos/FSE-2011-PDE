using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Search
{
    /// <summary>
    /// Value converter or the search modus property.
    /// </summary>
    public class SearchModusConverter : IValueConverter
    {
        /// <summary>
        /// Convert from SearchModus to int.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is SearchModus))
                throw new NotSupportedException("Source type not supported " + value.ToString());

            if (targetType == typeof(int))
            {
                SearchModus modus = (SearchModus)value;
                if (modus == SearchModus.SearchAdvanced)
                    return 0;
                else
                    return 1;
            }

            throw new NotSupportedException("Target type unknown " + targetType.ToString());
        }

        /// <summary>
        /// Convert from integer value to SearchModus-Value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(SearchModus))
            {
                int val = (int)value;
                if (val == 0)
                    return SearchModus.SearchAdvanced;
                else
                    return SearchModus.SearchAndReplace;
            }

            throw new NotSupportedException("Target type unknown " + targetType.ToString());
        }
    }
}

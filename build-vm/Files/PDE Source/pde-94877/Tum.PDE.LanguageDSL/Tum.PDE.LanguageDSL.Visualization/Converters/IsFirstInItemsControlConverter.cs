using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;

namespace Tum.PDE.LanguageDSL.Visualization.Converters
{
    public class IsFirstInItemsControlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TabItem)
            {
                TabItem item = value as TabItem;
                TabControl c = item.Parent as TabControl;
                if (c != null)
                {
                    if (c.Items[0] == item)
                        return true; 
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

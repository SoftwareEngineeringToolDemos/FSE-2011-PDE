using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Tum.PDE.LanguageDSL.Visualization.Converters
{
    public class RelationshipMultiplicityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Multiplicity m = (Multiplicity)value;
            switch (m)
            {
                case Multiplicity.One:
                    return "[1..1]";

                case Multiplicity.OneMany:
                    return "[1..*]";

                case Multiplicity.ZeroMany:
                    return "[0..*]";

                case Multiplicity.ZeroOne:
                    return "[0..1]";
            }

            throw new NotSupportedException("RelationshipMultiplicityConverter.Convert: " + value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

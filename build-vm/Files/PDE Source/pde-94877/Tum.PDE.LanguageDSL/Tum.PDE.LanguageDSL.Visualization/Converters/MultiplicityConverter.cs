using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Tum.PDE.LanguageDSL.Visualization.Converters
{
    public class MultiplicityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Multiplicity m = (Multiplicity)value;
            switch (m)
            {
                case Multiplicity.One:
                    return "1..1";

                case Multiplicity.OneMany:
                    return "1..*";

                case Multiplicity.ZeroMany:
                    return "0..*";

                case Multiplicity.ZeroOne:
                    return "0..1";
            }

            throw new NotSupportedException("MultiplicityConverter.Convert: " + value.ToString());
        }



        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string mStr = value.ToString().Trim();
            switch (mStr)
            {
                case "1":
                case "1..1":
                    return Multiplicity.One;

                case "0":
                case "0..1":
                    return Multiplicity.ZeroOne;

                case "*":
                case "0..*":
                    return Multiplicity.ZeroMany;

                case "1..*":
                    return Multiplicity.OneMany;
            }


            System.Windows.MessageBox.Show("Not a valid Multiplicity. Value is set to default 0..*");
            return Multiplicity.ZeroMany;
        }
    }
}

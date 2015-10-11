using System;
using System.ComponentModel;
using System.Globalization;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams.Converters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Based on Dsl-Tools Diagrams EdgePointConverter implementation.
    /// </remarks>
    public sealed class EdgePointConverter : TypeConverter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EdgePointConverter()
        {
        }

        /// <summary>
        /// Can convert from logic.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException("sourceType");

            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Can convert to logic.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Convert from logic.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string s = value as string;
            if (s != null)
            {
                if (s.Length == 0)
                    return null;

                return EdgePointConverter.ConvertFromString(culture, s);
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Convert to logic.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            EdgePoint edgePoint = value as EdgePoint;
            if ((edgePoint != null) && destinationType == typeof(string))
                return EdgePointConverter.ConvertToString(culture, edgePoint);

            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// Convert to edge point from string.
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static EdgePoint ConvertFromString(CultureInfo culture, string value)
        {
            double d1, d2;
            value = value.Trim();
            if (culture == null)
                culture = CultureInfo.InvariantCulture;

            if (value.StartsWith("(", false, culture) && value.EndsWith(")", false, culture))
            {
                value = value.Substring(1, value.Length - 2);

                char[] chArr = new char[] { ':' };
                string[] sArr = value.Split(chArr, System.StringSplitOptions.None);

                if ((sArr.Length < 2) || (sArr.Length > 3) ||
                    !Double.TryParse(sArr[0].Trim(), NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, culture, out d1) || 
                    !Double.TryParse(sArr[1].Trim(), NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, culture, out d2))
                    throw new System.InvalidCastException();
                if (sArr.Length == 3)
                {
                    EdgePointType pointType = (EdgePointType)System.Enum.Parse(typeof(EdgePointType), sArr[2].Trim(), true);
                    return new EdgePoint(d1, d2, pointType);
                }
                return new EdgePoint(d1, d2);
            }

            throw new System.InvalidCastException();
        }

        /// <summary>
        /// Converts an edge point to its string representation.
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        internal static string ConvertToString(CultureInfo culture, EdgePoint point)
        {
            object[] objArr = new object[3];
            objArr[0] = point.Point.X.ToString(culture);
            objArr[1] = point.Point.Y.ToString(culture);
            objArr[2] = point.PointType.ToString();
            return System.String.Format(culture, "({0} : {1} : {2})", objArr);
        }
    }
}

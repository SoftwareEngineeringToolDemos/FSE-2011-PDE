using System;
using System.ComponentModel;
using System.Globalization;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams.Converters
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Based on Dsl-Tools Diagrams EdgePointCollectionConverter implementation.
    /// </remarks>
    public sealed class EdgePointCollectionConverter : System.ComponentModel.TypeConverter
    {
        /// <summary>
        /// Converter.
        /// </summary>
        public EdgePointCollectionConverter()
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
                throw new System.ArgumentNullException("sourceType");

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
            string s1 = value as string;
            if (s1 != null)
            {
                s1 = s1.Trim();

                if (culture == null)
                    culture = System.Globalization.CultureInfo.InvariantCulture;

                if (s1.StartsWith("[", false, culture) && s1.EndsWith("]", false, culture))
                {
                    s1 = s1.Substring(1, s1.Length - 2);

                    char[] chArr = new char[] { ';' };
                    string[] sArr1 = s1.Split(chArr, System.StringSplitOptions.None);
                    
                    EdgePointCollection edgePointCollection = new EdgePointCollection();
                    for (int i = 0; i < sArr1.Length; i++)
                    {
                        string s2 = sArr1[i];
                        edgePointCollection.Add(EdgePointConverter.ConvertFromString(culture, s2));
                    }
                    return edgePointCollection;
                }
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
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            EdgePointCollection edgePointCollection = value as EdgePointCollection;
            if (edgePointCollection != null)
            {
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                stringBuilder.Append("[");

                for (int i = 0; i < edgePointCollection.Count; i++ )
                {
                    EdgePoint edgePoint = edgePointCollection[i];
                    stringBuilder.Append(EdgePointConverter.ConvertToString(culture, edgePoint));

                    if( i < edgePointCollection.Count-1)
                        stringBuilder.Append("; ");
                }

                stringBuilder.Append("]");
                return stringBuilder.ToString();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

    } 
}

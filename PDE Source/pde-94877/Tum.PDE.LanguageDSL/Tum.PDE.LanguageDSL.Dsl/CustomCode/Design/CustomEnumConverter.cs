using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Design
{
    // Microsoft.VisualStudio.Modeling.DslDefinition.CustomEnumConverter
    public abstract class CustomEnumConverter : System.ComponentModel.EnumConverter
    {

        private readonly string[] customValueNames;

        protected CustomEnumConverter(System.Type type, string[] customValueNames)
            : base(type)
        {
            this.customValueNames = customValueNames;
        }

        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (culture == System.Globalization.CultureInfo.InvariantCulture)
                return base.ConvertFrom(context, culture, value);
            string s = value as string;
            if (s != null)
            {
                int i = System.Array.IndexOf<string>(customValueNames, s.Trim());
                if (i >= 0)
                    return i;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == null)
                throw new System.ArgumentNullException("destinationType\uFFFD");
            if (culture == System.Globalization.CultureInfo.InvariantCulture)
                return base.ConvertTo(context, culture, value, destinationType);
            if ((destinationType == typeof(string)) && (value != null))
            {
                System.Type type = System.Enum.GetUnderlyingType(EnumType);
                System.IConvertible iconvertible = value as System.IConvertible;
                if ((iconvertible != null) && (value.GetType() != type))
                    value = iconvertible.ToType(type, culture);
                if (!EnumType.IsDefined(typeof(System.FlagsAttribute), false) && !System.Enum.IsDefined(EnumType, value))
                {
                    object[] objArr = new object[] {
                                                     value.ToString(), 
                                                     EnumType.Name };
                    throw new System.ArgumentException(System.String.Format(System.Globalization.CultureInfo.CurrentCulture, "ArgumentException_InvalidEnumValue", objArr), "value");
                }
                return customValueNames[(int)value];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

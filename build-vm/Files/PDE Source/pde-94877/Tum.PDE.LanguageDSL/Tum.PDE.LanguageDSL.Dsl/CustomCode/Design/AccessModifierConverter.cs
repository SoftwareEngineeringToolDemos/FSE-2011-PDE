using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Design
{
    internal sealed class AccessModifierConverter : CustomEnumConverter
    {
        public AccessModifierConverter()
            : base(typeof(AccessModifier), new string[] {
                                           "public", 
                                           "internal", 
                                           "private", 
                                           "protected", 
                                           "protected internal" })
        {
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            AccessModifier[] accessModifierArr = new AccessModifier[5];
            accessModifierArr[1] = AccessModifier.Assembly;
            accessModifierArr[2] = AccessModifier.Private;
            accessModifierArr[3] = AccessModifier.Family;
            accessModifierArr[4] = AccessModifier.FamilyOrAssembly;
            return new System.ComponentModel.TypeConverter.StandardValuesCollection(accessModifierArr);
        }

    }
}

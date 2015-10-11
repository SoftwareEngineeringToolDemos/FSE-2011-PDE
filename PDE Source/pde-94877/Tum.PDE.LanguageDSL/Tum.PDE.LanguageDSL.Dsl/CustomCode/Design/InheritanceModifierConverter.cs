using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Design
{
    internal sealed class InheritanceModifierConverter : CustomEnumConverter
    {
        public InheritanceModifierConverter()
            : base(typeof(InheritanceModifier), new string[] {
                                           "none", 
                                           "abstract", 
                                           "sealed" })
        {
        }
    }
}

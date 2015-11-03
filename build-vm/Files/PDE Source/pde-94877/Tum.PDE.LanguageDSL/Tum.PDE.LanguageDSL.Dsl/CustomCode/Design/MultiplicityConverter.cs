using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Design
{
    internal sealed class MultiplicityConverter : CustomEnumConverter
    {
        public MultiplicityConverter()
            : base(typeof(Multiplicity), new string[] {
                                           "0..*", 
                                           "1..1", 
                                           "0..1", 
                                           "1..*" })
        {
        }
    }
}

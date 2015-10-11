using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class DiagramClass
    {
        public override bool ModelIsCopyAllowed()
        {
            return false;
        }
    }
}

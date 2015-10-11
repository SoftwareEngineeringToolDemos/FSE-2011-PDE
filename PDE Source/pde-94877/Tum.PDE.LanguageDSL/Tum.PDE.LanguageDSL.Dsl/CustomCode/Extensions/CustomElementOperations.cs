using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public class CustomElementOperations : ElementOperations
    {
        public CustomElementOperations(IServiceProvider p, Partition partition):base(p, partition)
        {
        }
    }
}

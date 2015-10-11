using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainProperty
    {
        protected override ModelElement ChooseMergeTarget(ElementGroupPrototype elementGroupPrototype)
        {
            return base.ChooseMergeTarget(elementGroupPrototype);

        }


        protected override void MergeConfigure(Microsoft.VisualStudio.Modeling.ElementGroup elementGroup)
        {
            base.MergeConfigure(elementGroup);

            foreach (ElementLink link in elementGroup.ElementLinks)
            {
                if (link is DomainPropertyReferencesType)
                {
                    DomainType targeType = (link as DomainPropertyReferencesType).DomainType;

                }
            }
        }
    }
}

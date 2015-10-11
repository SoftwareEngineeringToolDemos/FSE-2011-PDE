using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.FamilyTreeDSL.ViewModel
{
    public partial class ParentOfShapeDiagramItemLinkViewModel
    {
        public override bool IsUIFixedPosition
        {
            get
            {
                return true;
            }
        }
    }

    public partial class MarriedToShapeDiagramItemLinkViewModel
    {
        public override bool IsUIFixedPosition
        {
            get
            {
                return true;
            }
        }
    }
}

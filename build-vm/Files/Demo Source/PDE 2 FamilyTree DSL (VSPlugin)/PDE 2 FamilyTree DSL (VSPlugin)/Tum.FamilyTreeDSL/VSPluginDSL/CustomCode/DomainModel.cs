using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.FamilyTreeDSL
{
    public partial class FamilyTreeDSLDomainModel
    {
        protected override Type[] GetCustomDomainModelTypes()
        {
            return new Type[]{
                typeof(ShapeAddRule),
                typeof(ShapeDeletingRule),
                typeof(RSShapeAddRule),
                typeof(RSShapeDeletingRule),
            };
        }
    }
}

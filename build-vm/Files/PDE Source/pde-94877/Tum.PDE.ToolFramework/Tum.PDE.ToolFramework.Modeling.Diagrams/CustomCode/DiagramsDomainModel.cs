using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Diagrams DSL domain model.
    /// </summary>
    public partial class DiagramsDSLDomainModel 
    {
        /// <summary>
        /// Get custom domain model types.
        /// </summary>
        /// <returns></returns>
        protected override Type[] GetCustomDomainModelTypes()
        {
            return new Type[]{
                typeof(AnchorAbsoluteLocationChanged),
                typeof(DiagramHasChildrenAddRule),
                typeof(DiagramHasChildrenDeleteRule),
                typeof(DiagramHasLinkShapesAddRule),
                typeof(DiagramHasLinkShapesDeleteRule),
                typeof(ShapeElementContainsChildShapesAddRule),
                typeof(ShapeElementContainsChildShapesChangeRule),
                typeof(ShapeElementContainsChildShapesDeleteRule),
                typeof(NodeShapeBoundsChangedRule),
                typeof(NodeShapeAddRule),
                typeof(NodeShapeDeleteRule),
                typeof(NodeShapeReferencesNestedChildrenAddRule),
                typeof(NodeShapeReferencesRelativeChildrenAddRule),                
                typeof(LinkShapeEdgePointsChanged),
                typeof(LinkShapeRoutingModeChanged),
                //typeof(ModelElementDeletingRuleForGRShapes),
            };
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(ShapeElementContainsChildShapes))]
    public class ShapeElementContainsChildShapesDeleteRule : DeleteRule
    {
        public override void ElementDeleted(ElementDeletedEventArgs e)
        {
            base.ElementDeleted(e);

            ShapeElementContainsChildShapes con = e.ModelElement as ShapeElementContainsChildShapes;
            if (con != null)
            {
                NodeShape childShape = con.ChildShape;
                NodeShape parentShape = con.ParentShape;

                if (childShape != null && parentShape != null)
                {
                    parentShape.RemoveFromShapeMapping(childShape);
                }
            }
        }
    }
}

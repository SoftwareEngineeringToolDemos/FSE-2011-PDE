using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(DiagramHasChildren))]
    public class DiagramHasLinkShapesDeleteRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);

            DiagramHasLinkShapes con = e.ModelElement as DiagramHasLinkShapes;
            if (con != null)
            {
                LinkShape linkShape = con.LinkShape;
                Diagram diagram = con.Diagram;

                if (linkShape != null && diagram != null)
                {
                    diagram.RemoveFromShapeMapping(linkShape);
                }
            }
        }
    }
}

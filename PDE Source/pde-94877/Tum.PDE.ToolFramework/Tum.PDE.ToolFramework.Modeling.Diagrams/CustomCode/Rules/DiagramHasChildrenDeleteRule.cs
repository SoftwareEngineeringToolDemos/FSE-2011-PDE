using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{    
    /// <summary>
    /// DiagramHasChildren delete rule.
    /// </summary>
    [RuleOn(typeof(DiagramHasChildren))]
    public class DiagramHasChildrenDeleteRule : DeleteRule
    {
        /// <summary>
        /// Called whenever a child element is deleted.
        /// </summary>
        /// <param name="e"></param>
        public override void ElementDeleted(ElementDeletedEventArgs e)
        {
            base.ElementDeleted(e);

            DiagramHasChildren con = e.ModelElement as DiagramHasChildren;
            if (con != null)
            {
                NodeShape nodeShape = con.ChildShape;
                Diagram diagram = con.Diagram;

                if (nodeShape != null && diagram != null)
                {
                    diagram.RemoveFromShapeMapping(nodeShape);
                }
            }
        }
    }
}

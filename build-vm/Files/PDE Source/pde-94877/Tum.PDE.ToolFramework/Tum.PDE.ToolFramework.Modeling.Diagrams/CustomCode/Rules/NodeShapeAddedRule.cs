using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(NodeShape), FireTime = TimeToFire.TopLevelCommit)]
    public class NodeShapeAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            NodeShape nodeShape = e.ModelElement as NodeShape;
            if (nodeShape != null)
            {
                //nodeShape.FixUpMissingLinkShapes();
            }
        }
    }
}

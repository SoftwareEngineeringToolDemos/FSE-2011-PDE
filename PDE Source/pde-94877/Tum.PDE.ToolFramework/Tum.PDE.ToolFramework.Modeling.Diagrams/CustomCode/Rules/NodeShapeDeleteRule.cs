using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(NodeShape))]
    public class NodeShapeDeleteRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            base.ElementDeleting(e);

            NodeShape nodeShape = e.ModelElement as NodeShape;
            if (nodeShape != null)
            {
                if (nodeShape.SourceAnchors.Count > 0)
                {
                    for (int i = nodeShape.SourceAnchors.Count - 1; i >= 0; i--)
                        if( nodeShape.SourceAnchors[i].LinkShape != null )
                            nodeShape.SourceAnchors[i].LinkShape.Delete();
                }

                if (nodeShape.TargetAnchors.Count > 0)
                {
                    for (int i = nodeShape.TargetAnchors.Count - 1; i >= 0; i--)
                        if (nodeShape.TargetAnchors[i].LinkShape != null)
                            nodeShape.TargetAnchors[i].LinkShape.Delete();
                }
            }
        }
    }
}

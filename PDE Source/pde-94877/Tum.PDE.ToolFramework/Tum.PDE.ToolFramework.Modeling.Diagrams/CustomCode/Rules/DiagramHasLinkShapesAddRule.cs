using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(DiagramHasLinkShapes), FireTime = TimeToFire.TopLevelCommit)]
    public class DiagramHasLinkShapesAddRule : AddRule
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
                    if (linkShape.IsDeleted)
                        return;

                    if (linkShape.SourceAnchor == null || linkShape.TargetAnchor == null)
                        throw new InvalidOperationException("LinkShape needs to have from and to anchors.");

                    if (linkShape.SourceAnchor.FromShape == null || linkShape.TargetAnchor.ToShape == null)
                        throw new InvalidOperationException("LinkShape anchors need to have from and to shape.");

                    diagram.AddToShapeMapping(linkShape);

                    if (linkShape.EdgePoints.Count == 0)
                    {
                        linkShape.Layout(FixedGeometryPoints.None);
                    }
                    else
                    {
                        linkShape.UpdateLinkPlacement();

                        if (!con.Store.InSerializationTransaction)
                            linkShape.Layout(FixedGeometryPoints.SourceAndTarget);
                    }
                }
            }
        }
    }
}

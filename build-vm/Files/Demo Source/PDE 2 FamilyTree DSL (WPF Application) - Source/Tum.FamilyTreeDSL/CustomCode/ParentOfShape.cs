using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.FamilyTreeDSL
{
    public partial class ParentOfShape
    {
        public override void Layout(PDE.ToolFramework.Modeling.Diagrams.FixedGeometryPoints fixedPoints)
        {
            RectangleD sourceBounds = this.SourceAnchor.FromShape.AbsoluteBounds;
            this.SetStartPoint(new PointD(sourceBounds.Center.X, sourceBounds.Bottom + 10));

            RectangleD targetBounds = this.TargetAnchor.ToShape.AbsoluteBounds;
            this.SetEndPoint(new PointD(targetBounds.Center.X, targetBounds.Top - 10));

            this.UpdateLinkPlacement();

            base.Layout(FixedGeometryPoints.SourceAndTarget);
        }
    }
}

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(ShapeElementContainsChildShapes), FireTime = TimeToFire.LocalCommit)]
    public class ShapeElementContainsChildShapesAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            ShapeElementContainsChildShapes con = e.ModelElement as ShapeElementContainsChildShapes;
            if (con != null)
            {
                NodeShape childShape = con.ChildShape;
                NodeShape parentShape = con.ParentShape;

                if (childShape != null && parentShape != null)
                {
                    if (childShape.IsDeleted)
                        return;
                    if (parentShape.IsDeleted)
                        return;

                    parentShape.AddToShapeMapping(childShape);
                    childShape.UpdateAbsoluteLocation();

                    if (childShape.Location == PointD.Empty)
                        childShape.SetAtFreePositionOnParent();
                }
                else 
                    con.Delete();
            }
        }
    }
}

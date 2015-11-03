using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(NodeShapeReferencesRelativeChildren), FireTime = TimeToFire.Inline)]
    public class NodeShapeReferencesRelativeChildrenAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            NodeShapeReferencesRelativeChildren con = e.ModelElement as NodeShapeReferencesRelativeChildren;
            if (con != null)
            {
                NodeShape childShape = con.ChildShape;
                NodeShape parentShape = con.ParentShape;

                if (childShape != null && parentShape != null)
                {
                    if (childShape.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                        childShape.CorrectLocation();
                }
                else
                    con.Delete();
            }
        }
    }
}

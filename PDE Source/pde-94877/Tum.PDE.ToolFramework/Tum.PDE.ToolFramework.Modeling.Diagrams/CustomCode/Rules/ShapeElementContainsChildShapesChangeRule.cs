using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(ShapeElementContainsChildShapes))]
    public class ShapeElementContainsChildShapesChangeRule : RolePlayerChangeRule
    {
        public override void RolePlayerChanged(RolePlayerChangedEventArgs e)
        {
            ShapeElementContainsChildShapes con = e.ElementLink as ShapeElementContainsChildShapes;
            if (con == null)
                return;

            if (e.DomainRole.Id == ShapeElementContainsChildShapes.DomainClassId)
            {
                NodeShape childShape = con.ChildShape;

                NodeShape parentShapeOld = e.OldRolePlayer as NodeShape;
                NodeShape parentShapeNew = e.NewRolePlayer as NodeShape;

                // delete from old parent shape
                if (childShape != null && parentShapeOld != null)
                {
                    if (childShape.IsDeleted)
                        return;

                    parentShapeOld.RemoveFromShapeMapping(childShape);
                }

                // add to new parent shape
                if (childShape != null && parentShapeNew != null)
                {
                    if (childShape.IsDeleted)
                        return;

                    parentShapeNew.AddToShapeMapping(childShape);

                    if (childShape.IsRelativeChildShape && childShape.MovementBehaviour == ShapeMovementBehaviour.PositionOnEdgeOfParent)
                        childShape.CorrectLocation();

                    if (!childShape.IsRelativeChildShape)
                        childShape.ResizeParentIfRequired();
                }
            }
        }
    }
}

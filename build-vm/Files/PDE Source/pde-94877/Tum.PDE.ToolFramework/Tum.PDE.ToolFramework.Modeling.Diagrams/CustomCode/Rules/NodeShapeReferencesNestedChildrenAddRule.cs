using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    [RuleOn(typeof(NodeShapeReferencesNestedChildren), FireTime = TimeToFire.Inline)]
    public class NodeShapeReferencesNestedChildrenAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            NodeShapeReferencesNestedChildren con = e.ModelElement as NodeShapeReferencesNestedChildren;
            if (con != null)
            {
                NodeShape childShape = con.ChildShape;
                NodeShape parentShape = con.ParentShape;

                if (childShape != null && parentShape != null)
                {
                    childShape.ResizeParentIfRequired();
                }
                else
                    con.Delete();
            }
        }
    }
}

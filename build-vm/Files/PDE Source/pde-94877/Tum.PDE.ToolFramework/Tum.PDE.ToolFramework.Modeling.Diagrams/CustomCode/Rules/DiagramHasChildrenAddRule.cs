using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// DiagramHasChildren add rule.
    /// </summary>
    [RuleOn(typeof(DiagramHasChildren), FireTime = TimeToFire.LocalCommit)]
    public class DiagramHasChildrenAddRule : AddRule
    {
        /// <summary>
        /// Called whenever a child element is added to a diagram.
        /// </summary>
        /// <param name="e"></param>
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);

            DiagramHasChildren con = e.ModelElement as DiagramHasChildren;
            if (con != null)
            {
                NodeShape nodeShape = con.ChildShape;
                Diagram diagram = con.Diagram;

                if (nodeShape != null && diagram != null)
                {
                    if (nodeShape.IsDeleted)
                        return;

                    diagram.AddToShapeMapping(nodeShape);

                    if (nodeShape.Location == PointD.Empty)
                        nodeShape.SetAtFreePositionOnParent();
                }
                else
                    con.Delete();
            }
        }
    }
}

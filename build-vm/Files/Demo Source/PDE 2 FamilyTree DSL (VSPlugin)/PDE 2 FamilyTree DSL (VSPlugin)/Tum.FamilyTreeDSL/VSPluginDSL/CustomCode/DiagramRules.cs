using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.FamilyTreeDSL
{
    [RuleOn(typeof(PersonShape), FireTime = TimeToFire.LocalCommit)]
    public class ShapeAddRule : AddRule
    {
        public override void ElementAdded(Microsoft.VisualStudio.Modeling.ElementAddedEventArgs e)
        {
            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            PersonShape shape = e.ModelElement as PersonShape;
            DiagramLayouter.Layout(shape.Diagram);
        }
    }

    [RuleOn(typeof(MarriedToShape), FireTime = TimeToFire.LocalCommit)]
    [RuleOn(typeof(ParentOfShape), FireTime = TimeToFire.LocalCommit)]
    public class RSShapeAddRule : AddRule
    {
        public override void ElementAdded(Microsoft.VisualStudio.Modeling.ElementAddedEventArgs e)
        {
            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            if (e.ModelElement is MarriedToShape)
            {
                MarriedToShape shape = e.ModelElement as MarriedToShape;
                DiagramLayouter.Layout(shape.Diagram);
            }
            else
            {
                ParentOfShape shape = e.ModelElement as ParentOfShape;
                DiagramLayouter.Layout(shape.Diagram);
            }
        }
    }

    [RuleOn(typeof(PersonShape), FireTime = TimeToFire.LocalCommit)]
    public class ShapeDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            PersonShape shape = e.ModelElement as PersonShape;
            DiagramLayouter.Layout(shape.Diagram);
        }
    }

    [RuleOn(typeof(MarriedToShape), FireTime = TimeToFire.LocalCommit)]
    [RuleOn(typeof(ParentOfShape), FireTime = TimeToFire.LocalCommit)]
    public class RSShapeDeletingRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            if (e.ModelElement is MarriedToShape)
            {
                MarriedToShape shape = e.ModelElement as MarriedToShape;
                DiagramLayouter.Layout(shape.Diagram);
            }
            else
            {
                ParentOfShape shape = e.ModelElement as ParentOfShape;
                DiagramLayouter.Layout(shape.Diagram);
            }
        }
    }
}

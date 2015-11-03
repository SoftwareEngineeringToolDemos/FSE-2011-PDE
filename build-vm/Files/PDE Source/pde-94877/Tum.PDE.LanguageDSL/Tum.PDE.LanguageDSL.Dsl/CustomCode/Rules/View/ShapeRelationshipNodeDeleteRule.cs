using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ShapeRelationshipNode), FireTime = TimeToFire.TopLevelCommit)]
    public class ShapeRelationshipNodeDeleteRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            ShapeRelationshipNode node = e.ModelElement as ShapeRelationshipNode;
            if (node != null)
            {
                if (node.RelationshipShapeClass != null)
                    node.RelationshipShapeClass.ReferenceRelationship = null;
            }
        }
    }
}

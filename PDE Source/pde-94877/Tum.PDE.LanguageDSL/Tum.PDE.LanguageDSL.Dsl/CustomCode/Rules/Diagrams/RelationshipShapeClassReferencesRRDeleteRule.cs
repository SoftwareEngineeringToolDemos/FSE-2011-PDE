using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(RelationshipShapeClassReferencesReferenceRelationship), FireTime = TimeToFire.TopLevelCommit)]
    public class RelationshipShapeClassReferencesRRDeleteRule : DeletingRule
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

            RelationshipShapeClassReferencesReferenceRelationship con = e.ModelElement as RelationshipShapeClassReferencesReferenceRelationship;
            if (con != null)
                if (con.DomainRelationship is ReferenceRelationship)
                {
                    RelationshipShapeClass shape = con.RelationshipShapeClass;
                    ShapeRelationshipNode node = shape.ShapeRelationshipNode;
                    if (node != null)
                    {

                        // delete
                        ReferenceRelationship rel = con.DomainRelationship as ReferenceRelationship;
                        ReferenceRSNode n = rel.ReferenceRSNode;
                        if (n != null)
                        {
                            if (n.ShapeRelationshipNodes.Contains(node))
                                n.ShapeRelationshipNodes.Remove(node);
                        }
                        node.Delete();
                    }
                }
        }
    }
}

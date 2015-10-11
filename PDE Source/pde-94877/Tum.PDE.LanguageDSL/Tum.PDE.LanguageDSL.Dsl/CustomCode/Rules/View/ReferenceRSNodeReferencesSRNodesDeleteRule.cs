using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ReferenceRSNodeReferencesShapeRelationshipNodes), FireTime = TimeToFire.TopLevelCommit)]
    public class ReferenceRSNodeReferencesSRNodesDeleteRule : DeletingRule
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

            ReferenceRSNodeReferencesShapeRelationshipNodes con = e.ModelElement as ReferenceRSNodeReferencesShapeRelationshipNodes;
            if (con != null)
            {
                if (con.ShapeRelationshipNode != null)
                    con.ShapeRelationshipNode.Delete();
            }
        }
    }
        
}

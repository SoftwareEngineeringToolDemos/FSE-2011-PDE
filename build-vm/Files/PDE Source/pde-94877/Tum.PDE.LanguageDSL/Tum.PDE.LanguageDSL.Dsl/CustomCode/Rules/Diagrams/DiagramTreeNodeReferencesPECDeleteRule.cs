using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DiagramTreeNodeReferencesPresentationElementClass), FireTime = TimeToFire.TopLevelCommit)]
    public class DiagramTreeNodeReferencesPECDeleteRule : DeletingRule
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

            DiagramTreeNodeReferencesPresentationElementClass con = e.ModelElement as DiagramTreeNodeReferencesPresentationElementClass;
            if (con != null)
            {
                if (con.DiagramTreeNode != null)
                    con.DiagramTreeNode.Delete();
            }
        }
    }
}

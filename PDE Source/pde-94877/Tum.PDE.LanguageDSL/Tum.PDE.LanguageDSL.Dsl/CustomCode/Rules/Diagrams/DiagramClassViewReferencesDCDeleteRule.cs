using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DiagramClassViewReferencesDiagramClass), FireTime = TimeToFire.TopLevelCommit)]
    public class DiagramClassViewReferencesDCDeleteRule : DeletingRule
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

            DiagramClassViewReferencesDiagramClass con = e.ModelElement as DiagramClassViewReferencesDiagramClass;
            if (con != null)
            {
                if (con.DiagramClassView != null)
                    con.DiagramClassView.Delete();
            }
        }
    }
}

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ShapeClassNode), FireTime=TimeToFire.TopLevelCommit)]
    public class ShapeClassNodeDeleteRule : DeletingRule
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

            ShapeClassNode node = e.ModelElement as ShapeClassNode;
            if (node != null)
            {
                if (node.ShapeClass != null)
                    node.ShapeClass.DomainClass = null;
            }
        }
    }
}

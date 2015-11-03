using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ShapeClass), FireTime = TimeToFire.TopLevelCommit)]
    public class ShapeClassDeleteRule : DeletingRule
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

            ShapeClass shapeClass = e.ModelElement as ShapeClass;
            if (shapeClass != null)
            {
                for (int i = shapeClass.Children.Count - 1; i >= 0; i--)
                    shapeClass.Children[i].Delete();
            }
        }
    }
}

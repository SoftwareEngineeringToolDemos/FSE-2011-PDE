using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ShapeClassReferencesDomainClass), FireTime = TimeToFire.TopLevelCommit)]
    public class ShapeClassReferencesDomainClassDeleteRule : DeletingRule
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

            ShapeClassReferencesDomainClass shapeCon = e.ModelElement as ShapeClassReferencesDomainClass;
            if (shapeCon != null)
            {
                PresentationDomainClassElement shapeClass = shapeCon.ShapeClass;
                ShapeClassNode node = shapeClass.ShapeClassNode;

                if (node != null)
                {
                    // delete
                    DomainClass domainClass = shapeCon.DomainClass;
                    foreach (TreeNode n in domainClass.DomainModelTreeNodes)
                    {
                        if (n.IsElementHolder)
                        {

                            if (n.ShapeClassNodes.Contains(node))
                                n.ShapeClassNodes.Remove(node);
                            break;
                        }
                    }

                    node.Delete();
                }
            }
        } 
    }
}

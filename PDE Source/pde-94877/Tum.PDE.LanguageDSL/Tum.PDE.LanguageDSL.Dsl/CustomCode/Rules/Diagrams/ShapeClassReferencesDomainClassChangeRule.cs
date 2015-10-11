using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ShapeClassReferencesDomainClass), FireTime = TimeToFire.TopLevelCommit)]
    public class ShapeClassReferencesDomainClassChangeRule : RolePlayerChangeRule
    {
        public override void RolePlayerChanged(RolePlayerChangedEventArgs e)
        {
            if (e.ElementLink != null)
                if (e.ElementLink.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ElementLink.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ElementLink == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ElementLink) != Locks.None)
                return;

            ShapeClassReferencesDomainClass shapeCon = e.ElementLink as ShapeClassReferencesDomainClass;
            if (shapeCon != null)
            {
                PresentationDomainClassElement shapeClass = shapeCon.ShapeClass;
                ShapeClassNode node = shapeClass.ShapeClassNode;

                // delete old                
                DomainClass domainClass = e.OldRolePlayer as DomainClass;
                if (node != null)
                {
                    foreach (TreeNode n in domainClass.DomainModelTreeNodes)
                    {
                        if (n.IsElementHolder)
                        {
                            if (n.ShapeClassNodes.Contains(node))
                                n.ShapeClassNodes.Remove(node);
                            break;
                        }
                    }
                }

                // add new
                domainClass = e.NewRolePlayer as DomainClass;
                foreach (TreeNode n in domainClass.DomainModelTreeNodes)
                {
                    if (n.IsElementHolder)
                    {
                        ShapeClassNode shapeNode = new ShapeClassNode(shapeCon.Store);
                        shapeClass.ShapeClassNode = shapeNode;

                        n.ShapeClassNodes.Add(shapeNode);
                        domainClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(shapeNode);
                        break;
                    }
                }
                if( node != null )
                    node.Delete();
            }
        }
    }
}

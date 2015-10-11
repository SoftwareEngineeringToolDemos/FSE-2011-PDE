using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ShapeClassReferencesDomainClass), FireTime=TimeToFire.TopLevelCommit)]
    public class ShapeClassReferencesDomainClassAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
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
                DomainClass domainClass = shapeCon.DomainClass;
                PresentationDomainClassElement shapeClass = shapeCon.ShapeClass;

                foreach (TreeNode node in domainClass.DomainModelTreeNodes)
                {
                    if (node.IsElementHolder)
                    {
                        ShapeClassNode shapeNode = new ShapeClassNode(shapeCon.Store);
                        shapeNode.ShapeClass = shapeClass;

                        node.ShapeClassNodes.Add(shapeNode);
                        domainClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(shapeNode);
                        break;
                    }
                }
            }
        } 
    }
}

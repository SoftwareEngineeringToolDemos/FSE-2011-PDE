using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ReferenceRelationship), FireTime = TimeToFire.Inline)]
    [RuleOn(typeof(EmbeddingRelationship), FireTime = TimeToFire.Inline)]
    [RuleOn(typeof(DomainClassReferencesBaseClass), FireTime = TimeToFire.Inline)]
    public class DomainRelationshipDeleteRule : DeletingRule
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

            ReferenceRelationship referenceRelationship = e.ModelElement as ReferenceRelationship;
            if (referenceRelationship != null)
            {
                if (referenceRelationship.ReferenceRSNode != null)
                    referenceRelationship.ReferenceRSNode.Delete();
            }

            EmbeddingRelationship embeddingRelationship = e.ModelElement as EmbeddingRelationship;
            if (embeddingRelationship != null)
            {
                if(embeddingRelationship.EmbeddingRSNode != null )
                    embeddingRelationship.EmbeddingRSNode.Delete();
            }

            DomainClassReferencesBaseClass inhRelationship = e.ModelElement as DomainClassReferencesBaseClass;
            if (inhRelationship != null)
            {
                InheritanceNode node = inhRelationship.Store.ElementDirectory.FindElement(inhRelationship.InhNodeId) as InheritanceNode;
                if (node != null)
                {
                    if (node.IsElementHolder)
                    {
                        RootNode rootNode = new RootNode(node.Store);
                        rootNode.DomainElement = node.DomainElement;

                        rootNode.IsElementHolder = true;
                        rootNode.IsEmbeddingTreeExpanded = node.IsEmbeddingTreeExpanded;
                        rootNode.IsExpanded = true;
                        rootNode.IsInheritanceTreeExpanded = node.IsInheritanceTreeExpanded;
                        rootNode.IsReferenceTreeExpanded = node.IsReferenceTreeExpanded;
                        rootNode.IsShapeMappingTreeExpanded = node.IsShapeMappingTreeExpanded;

                        // copy sub tree
                        for (int i = node.EmbeddingRSNodes.Count - 1; i >= 0; i--)
                            node.EmbeddingRSNodes[i].TreeNode = rootNode;

                        for (int i = node.ReferenceRSNodes.Count - 1; i >= 0; i--)
                            node.ReferenceRSNodes[i].TreeNode = rootNode;

                        for (int i = node.InheritanceNodes.Count - 1; i >= 0; i--)
                            node.InheritanceNodes[i].TreeNode = rootNode;

                        for (int i = node.ShapeClassNodes.Count - 1; i >= 0; i--)
                            node.ShapeClassNodes[i].TreeNode = rootNode;

                        node.DomainElement.ParentModelContext.ViewContext.DomainModelTreeView.RootNodes.Add(rootNode);
                        node.DomainElement.ParentModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(rootNode);
                    }

                    // connection was deleted using the property window and not the menu item, so delete the rs and the
                    // node here
                    //if (inhNode.IsElementHolder)
                    //    TreeOperations.SplitTree(inhNode);

                    node.Delete();
                }

            }
        }
    }
    
}

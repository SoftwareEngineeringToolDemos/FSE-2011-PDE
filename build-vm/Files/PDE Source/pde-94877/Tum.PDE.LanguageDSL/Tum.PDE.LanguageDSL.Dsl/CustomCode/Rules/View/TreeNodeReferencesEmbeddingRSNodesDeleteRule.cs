using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(TreeNodeReferencesEmbeddingRSNodes), FireTime = TimeToFire.TopLevelCommit)]
    public class TreeNodeReferencesEmbeddingRSNodesDeleteRule : DeletingRule
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

            TreeNodeReferencesEmbeddingRSNodes con = e.ModelElement as TreeNodeReferencesEmbeddingRSNodes;
            if (con != null)
            {
                EmbeddingRSNode rsNode = con.EmbeddingRSNode;
                if (rsNode != null)
                {
                    EmbeddingNode node = rsNode.EmbeddingNode;
                    if (node != null)
                    {
                        // since this node still exists, it isnt included in the deletion process
                        // --> move to root node if this node is the element holder, as its parent has been deleted
                        if (node.IsElementHolder)
                        {
                            RootNode rootNode = new RootNode(node.Store);
                            rootNode.DomainElement = node.DomainElement;

                            node.EmbeddingModelTreeViewModel.RootNodes.Add(rootNode);
                            node.EmbeddingModelTreeViewModel.ModelTreeNodes.Add(rootNode);

                            // copy sub tree
                            for (int i = node.EmbeddingRSNodes.Count - 1; i >= 0; i--)
                                node.EmbeddingRSNodes[i].TreeNode = rootNode;

                            for (int i = node.ReferenceRSNodes.Count - 1; i >= 0; i--)
                                node.ReferenceRSNodes[i].TreeNode = rootNode;

                            for (int i = node.InheritanceNodes.Count - 1; i >= 0; i--)
                                node.InheritanceNodes[i].TreeNode = rootNode;

                            for (int i = node.ShapeClassNodes.Count - 1; i >= 0; i--)
                                node.ShapeClassNodes[i].TreeNode = rootNode;
                            
                            rootNode.IsElementHolder = true;
                            rootNode.IsEmbeddingTreeExpanded = node.IsEmbeddingTreeExpanded;
                            rootNode.IsExpanded = true;
                            rootNode.IsInheritanceTreeExpanded = node.IsInheritanceTreeExpanded;
                            rootNode.IsReferenceTreeExpanded = node.IsReferenceTreeExpanded;
                            rootNode.IsShapeMappingTreeExpanded = node.IsShapeMappingTreeExpanded;
                        }

                        node.Delete();
                    }

                    rsNode.Delete();
                }
            }
        }
    }
}

using System;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(DomainClassReferencesBaseClass), FireTime = TimeToFire.TopLevelCommit)]
    public class DomainRelationshipChangedRule : RolePlayerChangeRule
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

            DomainClassReferencesBaseClass con = e.ElementLink as DomainClassReferencesBaseClass;
            if (con != null)
                if (con.BaseClass != null)
                {
                    TreeNode elementHolderNode = null;
                    foreach (TreeNode node in con.BaseClass.DomainModelTreeNodes)
                        if (node.IsElementHolder)
                        {
                            elementHolderNode = node;
                            break;
                        }

                    if (elementHolderNode == null)
                        throw new ArgumentNullException("elementHolderNode");

                    // we need to delte the old inheritance node and add a new one for the changed inheritance relationship
                    InheritanceNode inhNodeOld = con.Store.ElementDirectory.FindElement(con.InhNodeId) as InheritanceNode;
                    if (inhNodeOld == null)
                        return;

                    // create new inheritance node
                    InheritanceNode inhNode = new InheritanceNode(con.Store);
                    inhNode.DomainElement = con.DerivedClass;
                    inhNode.IsElementHolder = inhNodeOld.IsElementHolder;
                    inhNode.IsExpanded = inhNodeOld.IsExpanded;
                    inhNode.InhRelationshipId = con.Id;
                    inhNode.IsEmbeddingTreeExpanded = inhNodeOld.IsEmbeddingTreeExpanded;
                    inhNode.IsInheritanceTreeExpanded = inhNodeOld.IsInheritanceTreeExpanded;
                    inhNode.IsReferenceTreeExpanded = inhNodeOld.IsReferenceTreeExpanded;
                    inhNode.IsShapeMappingTreeExpanded = inhNodeOld.IsShapeMappingTreeExpanded;
                    con.InhNodeId = inhNode.Id;

                    // copy sub tree
                    for (int i = inhNodeOld.EmbeddingRSNodes.Count - 1; i >= 0; i--)
                        inhNodeOld.EmbeddingRSNodes[i].TreeNode = inhNode;

                    for (int i = inhNodeOld.ReferenceRSNodes.Count - 1; i >= 0; i--)
                        inhNodeOld.ReferenceRSNodes[i].TreeNode = inhNode;

                    for (int i = inhNodeOld.InheritanceNodes.Count - 1; i >= 0; i--)
                        inhNodeOld.InheritanceNodes[i].TreeNode = inhNode;

                    for (int i = inhNodeOld.ShapeClassNodes.Count - 1; i >= 0; i--)
                        inhNodeOld.ShapeClassNodes[i].TreeNode = inhNode;

                    elementHolderNode.InheritanceNodes.Add(inhNode);
                    con.DerivedClass.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(inhNode);

                    inhNodeOld.Delete();
                }
        }
    }
}

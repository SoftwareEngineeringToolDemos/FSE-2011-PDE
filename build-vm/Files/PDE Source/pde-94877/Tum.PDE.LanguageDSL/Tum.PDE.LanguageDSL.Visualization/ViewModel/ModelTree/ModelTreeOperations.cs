using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public class ModelTreeOperations
    {
        /// <summary>
        /// Adds a new embedding relationship instance betweend the given domain class as source and a new domain class
        /// as target (target is created by this method).
        /// </summary>
        /// <param name="source">Domain class acting as parent in the embedding relationship.</param>
        public static void AddNewEmbeddingRelationship(List<DomainClass> sources)
        {
            ModelTreeHelper.AddNewEmbeddingRelationship(sources);
        }

        /// <summary>
        /// Adds a new embedding relationship instance.
        /// </summary>
        /// <param name="source">Domain class representing the parent.</param>
        /// <param name="target">Domain class representing the child.</param>
        public static void AddNewEmbeddingRelationship(List<DomainClass> sources, AttributedDomainElement target)
        {
            ModelTreeHelper.AddNewEmbeddingRelationship(sources, target);
        }
                
        /// <summary>
        /// Adds a new referece relationship instance.
        /// </summary>
        /// <param name="source">Domain class representing the source.</param>
        /// <param name="target">Domain class representing the target.</param>
        public static void AddNewReferenceRelationship(List<DomainClass> sources, AttributedDomainElement target)
        {
            ModelTreeHelper.AddNewReferenceRelationship(sources, target);
        }

        /// <summary>
        /// Adds a new inheritance relationship instance for each source.
        /// </summary>
        /// <param name="sources">DomainClass to be the derived classes.</param>
        /// <param name="target">DomainClass to act as the base class.</param>
        public static void AddNewInheritanceRelationship(List<DomainClass> sources, DomainClass target)
        {
            ModelTreeHelper.AddNewInheritanceRelationship(sources, target);
        }

        /// <summary>
        /// Adds a new derived class to each of the given domain classes.
        /// </summary>
        /// <param name="sources">DomainClasses to add a derived from.</param>
        public static void AddNewInheritanceRelationshipNewDerivedClass(List<DomainClass> sources)
        {
            ModelTreeHelper.AddNewInheritanceRelationshipNewDerivedClass(sources);
        }
        
        /// <summary>
        /// Moves the children tree consisting of embedding, reference, inheritance and shape mapping nodes from the source
        /// element to the target element.
        /// 
        /// Needs to be called within a modeling transaction!
        /// </summary>
        /// <param name="source">TreeNode to move the tree from.</param>
        /// <param name="target">TreeNode to move the tree to.</param>
        public static void MoveTree(TreeNode source, TreeNode target)
        {
            // copy sub tree
            for (int i = source.EmbeddingRSNodes.Count - 1; i >= 0; i--)
                source.EmbeddingRSNodes[i].TreeNode = target;

            for (int i = source.ReferenceRSNodes.Count - 1; i >= 0; i--)
                source.ReferenceRSNodes[i].TreeNode = target;

            for (int i = source.InheritanceNodes.Count - 1; i >= 0; i--)
                source.InheritanceNodes[i].TreeNode = target;

            for (int i = source.ShapeClassNodes.Count - 1; i >= 0; i--)
                source.ShapeClassNodes[i].TreeNode = target;
   
        }

        /// <summary>
        /// Verifies if the "bring tree here" command is applicable for the given node.
        /// </summary>
        /// <param name="node">TreeNode in question.</param>
        /// <returns>True if the command can be applied, False otherwise.</returns>
        public static bool CanBringTreeHere(TreeNode node)
        {
            if (node == null)
                return false;

            if (node.DomainElement == null)
                return false;

            if (node is RootNode)  // Tree is already here
                return false;

            if (node.IsElementHolder)  // Tree is already here
                return false;

            // try to find the domain class the node is holding in the parent embedding path, if its
            // not there, we can safely bring the tree to the node in question
            if (node is EmbeddingNode)
            {
                if (!CanBringTreeHere((node as EmbeddingNode).EmbeddingRSNode.TreeNode, node))
                    return false;
            }
            else if (node is ReferenceNode)
            {
                if (!CanBringTreeHere((node as ReferenceNode).ReferenceRSNode.TreeNode, node))
                    return false;
            }
            else if (node is InheritanceNode)
            {
                if (!CanBringTreeHere((node as InheritanceNode).TreeNode, node))
                    return false;
            }
            else
                throw new NotSupportedException("node type in CanBringTreeHere");

            return true;
        }

        /// <summary>
        /// Verifies if the "bring tree here" command is applicable for the given node.
        /// </summary>
        /// <param name="currentNode">Current TreeNode used in the recursion.</param>
        /// <param name="node">TreeNode in question.</param>
        /// <returns>True if the command can be applied, False otherwise.</returns>
        private static bool CanBringTreeHere(TreeNode currentNode, TreeNode node)
        {
            if (currentNode.DomainElement.Id == node.DomainElement.Id)
                return false;

            if (currentNode is EmbeddingNode)
            {
                TreeNode parentNode = (currentNode as EmbeddingNode).EmbeddingRSNode.TreeNode;
                if (parentNode != null)
                    if (!CanBringTreeHere(parentNode, node))
                        return false;
            }
            else if (currentNode is ReferenceNode)
            {
                TreeNode parentNode = (currentNode as ReferenceNode).ReferenceRSNode.TreeNode;
                if (parentNode != null)
                    if (!CanBringTreeHere(parentNode, node))
                        return false;
            }
            else if (currentNode is InheritanceNode)
            {
                TreeNode parentNode = (currentNode as InheritanceNode).TreeNode;
                if (parentNode != null)
                    if (!CanBringTreeHere(parentNode, node))
                        return false;
            }
            else if (currentNode is RootNode)
            {
                // nothin to do here
            }
            else
                throw new NotSupportedException("node type in CanBringTreeHere");

            return true;
        }

        /// <summary>
        /// Verifies if the "split tree" command is applicable for the given node.
        /// </summary>
        /// <param name="node">TreeNode in question.</param>
        /// <returns>True if the command can be applied, False otherwise.</returns>
        public static bool CanSplitTree(TreeNode node)
        {
            if (node == null)
                return false;

            if (node.DomainElement == null)
                return false;

            if (node is RootNode)
                return false;

            if (node.IsElementHolder)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Creates a new root node to "hold" the tree of the given node.
        /// 
        /// Needs to be called within a modeling transaction!
        /// </summary>
        /// <param name="node">TreeNode to split the tree from.</param>
        public static void SplitTree(TreeNode node)
        {
            // create new root node
            RootNode rootNode = new RootNode(node.Store);
            rootNode.DomainElement = node.DomainElement;
            rootNode.IsElementHolder = true;
            rootNode.IsEmbeddingTreeExpanded = node.IsEmbeddingTreeExpanded;
            rootNode.IsInheritanceTreeExpanded = node.IsInheritanceTreeExpanded;
            rootNode.IsReferenceTreeExpanded = node.IsReferenceTreeExpanded;
            rootNode.IsShapeMappingTreeExpanded = node.IsShapeMappingTreeExpanded;

            // move tree
            MoveTree(node, rootNode);

            // add root node to the domain model tree for vizualisation
            rootNode.DomainElement.ParentModelContext.ViewContext.DomainModelTreeView.RootNodes.Add(rootNode);
            rootNode.DomainElement.ParentModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(rootNode);

            // collapse the source node
            node.IsElementHolder = false;
            node.IsExpanded = false;
        }

        /// <summary>
        /// Moves the tree from the current holding node to the given node.
        /// 
        /// Needs to be called within a modeling transaction!
        /// </summary>
        /// <param name="node">TreeNode to move the tree to.</param>
        public static void BringTreeHere(TreeNode node)
        {
            // find the element holder tree
            TreeNode elementHolderNode = null;
            foreach (TreeNode n in node.DomainElement.DomainModelTreeNodes)
                if (n.IsElementHolder)
                {
                    elementHolderNode = n;
                    break;
                }

            if (elementHolderNode == null)
                throw new ArgumentNullException("elementHolderNode");

            // move tree
            MoveTree(elementHolderNode, node);
            node.IsElementHolder = true;
            node.IsEmbeddingTreeExpanded = elementHolderNode.IsEmbeddingTreeExpanded;
            node.IsInheritanceTreeExpanded = elementHolderNode.IsInheritanceTreeExpanded;
            node.IsReferenceTreeExpanded = elementHolderNode.IsReferenceTreeExpanded;
            node.IsShapeMappingTreeExpanded = elementHolderNode.IsShapeMappingTreeExpanded;
            node.IsExpanded = true;

            // collapse source node
            if (elementHolderNode is RootNode)
                elementHolderNode.Delete();
            else
            {
                elementHolderNode.IsExpanded = false;
                elementHolderNode.IsElementHolder = false;
            }
        }
    }
}

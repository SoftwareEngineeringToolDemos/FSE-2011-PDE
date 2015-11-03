using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model hosts an EmbeddingNode.
    /// </summary>
    public class EmbeddingNodeViewModel : TreeNodeViewModel
    {
        private EmbeddingRSNodeViewModel parentTreeNode;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="embeddingNode">Embedding node.</param>
        /// <param name="parent">Parent.</param>
        public EmbeddingNodeViewModel(ViewModelStore viewModelStore, EmbeddingNode embeddingNode, EmbeddingRSNodeViewModel parent)
            : base(viewModelStore, embeddingNode, parent.Parent)
        {
            this.parentTreeNode = parent;
        }

        /// <summary>
        /// Gets the embedding node hosted by this view model.
        /// </summary>
        public EmbeddingNode EmbeddingNode
        {
            get
            {
                return this.TreeNode as EmbeddingNode;
            }
        }

        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public override bool CanMoveUp()
        {
            TreeNodeViewModel parent = parentTreeNode.Parent;
            if (parent.EmbeddingRSNodes.Count == 0)
                return false;

            if (parent.EmbeddingRSNodes[0].Id != parentTreeNode.Id)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Finds out if the current tree node can be moved down or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved down, false otherwise</returns>
        public override bool CanMoveDown()
        {
            TreeNodeViewModel parent = parentTreeNode.Parent;
            if (parent.EmbeddingRSNodes.Count == 0)
                return false;

            if (parent.EmbeddingRSNodes[parent.EmbeddingRSNodes.Count - 1].Id != parentTreeNode.Id)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Moves this element up or down in the display order by repositioning the element in the collection.
        /// </summary>
        /// <param name="bUp"></param>
        protected override void Move(bool bUp)
        {
            TreeNodeViewModel parent = parentTreeNode.Parent;

            // find index and move element
            for (int i = 0; i < parent.EmbeddingRSNodes.Count; ++i)
                if (parent.EmbeddingRSNodes[i].Id == parentTreeNode.Id)
                {
                    if (bUp)
                        parent.MoveEmbeddingRsNodes(i, i - 1);
                    else
                        parent.MoveEmbeddingRsNodes(i, i + 1);
                    break;
                }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public override bool IsThisLastNode()
        {
            if (this.parentTreeNode.Parent.EmbeddingRSNodes.Count == 0)
                return false;

            if (this.parentTreeNode.Parent.EmbeddingRSNodes[this.EmbeddingRSNodes.Count - 1] == parentTreeNode)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determines if the current node is the first node in the parents collection.
        /// </summary>
        /// <returns>True if this node is first in its parents collection. False otherwise.</returns>
        public override bool IsThisFirstNode()
        {
            if (this.parentTreeNode.Parent.EmbeddingRSNodes.Count == 0)
                return false;

            if (this.parentTreeNode.Parent.EmbeddingRSNodes[0] == parentTreeNode)
                return true;
            else
                return false;
        }   
    }
}

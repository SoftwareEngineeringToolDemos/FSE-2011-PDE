using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This View Model hosts a root node.
    /// </summary>
    public class RootNodeViewModel : TreeNodeViewModel
    {
        ModelTreeViewModel parentVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="rootNode">Root node.</param>
        /// <param name="parent">Parent.</param>
        public RootNodeViewModel(ViewModelStore viewModelStore, RootNode rootNode, ModelTreeViewModel parent)
            : base(viewModelStore, rootNode, null)
        {
            this.parentVM = parent;
        }
        
        /// <summary>
        /// Gets the hosted root node.
        /// </summary>
        public RootNode RootNode
        {
            get 
            {
                return this.TreeNode as RootNode;
            }
        }

        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public override bool CanMoveUp()
        {
            if (parentVM.RootNodes.Count == 0)
                return false;

            if (parentVM.RootNodes[0].Id != this.Id)
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
            if (parentVM.RootNodes.Count == 0)
                return false;

            if (parentVM.RootNodes[parentVM.RootNodes.Count - 1].Id != this.Id)
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
            // find index and move element
            for (int i = 0; i < parentVM.RootNodes.Count; ++i)
                if (parentVM.RootNodes[i].Id == this.Id)
                {
                    if (bUp)
                        parentVM.MoveRootNodes(i, i - 1);
                    else
                        parentVM.MoveRootNodes(i, i + 1);
                    break;
                }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public override bool IsThisLastNode()
        {
            if (this.parentVM.RootNodes.Count == 0)
                return false;

            if (this.parentVM.RootNodes[this.parentVM.RootNodes.Count - 1] == this)
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
            if (this.parentVM.RootNodes.Count == 0)
                return false;

            if (this.parentVM.RootNodes[0] == this)
                return true;
            else
                return false;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model hosts an InheritanceNode.
    /// </summary>
    public class InheritanceNodeViewModel : TreeNodeViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="inheritanceNode">Inheritance node.</param>
        /// <param name="parent">Parent.</param>
        public InheritanceNodeViewModel(ViewModelStore viewModelStore, InheritanceNode inheritanceNode, TreeNodeViewModel parent)
            : base(viewModelStore, inheritanceNode, parent)
        {
        }

        /// <summary>
        /// Gets the inheritance node hosted by this view model.
        /// </summary>
        public InheritanceNode InheritanceNode
        {
            get
            {
                return this.TreeNode as InheritanceNode;
            }
        }

        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public override bool CanMoveUp()
        {
            TreeNodeViewModel parentNode = this.Parent;
            if (parentNode.InheritanceNodes.Count == 0)
                return false;

            if (parentNode.InheritanceNodes[0].Id != this.Id)
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
            TreeNodeViewModel parentNode = this.Parent;
            if (parentNode.InheritanceNodes.Count == 0)
                return false;

            if (parentNode.InheritanceNodes[parentNode.InheritanceNodes.Count - 1].Id != this.Id)
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
            TreeNodeViewModel parentNode = this.Parent;

            // find index and move element
            for (int i = 0; i < parentNode.InheritanceNodes.Count; ++i)
                if (parentNode.InheritanceNodes[i].Id == this.Id)
                {
                    if (bUp)
                        parentNode.MoveInheritanceNodes(i, i - 1);
                    else
                        parentNode.MoveInheritanceNodes(i, i + 1);
                    break;
                }
        }
        
        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public override bool IsThisLastNode()
        {
            if (this.Parent.InheritanceNodes.Count == 0)
                return false;

            if (this.Parent.InheritanceNodes[this.Parent.InheritanceNodes.Count - 1].Id == this.Id)
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
            if (this.Parent.InheritanceNodes.Count == 0)
                return false;

            if (this.Parent.InheritanceNodes[0].Id == this.Id)
                return true;
            else
                return false;
        }


    }
}

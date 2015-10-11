using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class RootDiagramNodeViewModel : EmbeddingDiagramNodeViewModel
    {
        private DiagramClassViewModel parent;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="embeddingDiagramNode">Element represented by this view model.</param>
        public RootDiagramNodeViewModel(ViewModelStore viewModelStore, RootDiagramNode rootDiagramNode, DiagramClassViewModel parent)
            : base(viewModelStore, rootDiagramNode, null)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Gets the parent element.
        /// </summary>
        public new DiagramClassViewModel Parent
        {
            get
            {
                return this.parent;
            }
        }

        /// <summary>
        /// Gets the root diagram tree node.
        /// </summary>
        public RootDiagramNode RootDiagramNode
        {
            get
            {
                return this.DiagramTreeNode as RootDiagramNode;
            }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public override bool IsThisLastNode()
        {
            if (this.Parent.RootNodes.Count == 0)
                return false;

            if (this.Parent.RootNodes[this.Parent.RootNodes.Count - 1].Id == this.Id)
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
            if (this.Parent.RootNodes.Count == 0)
                return false;

            if (this.Parent.RootNodes[0].Id == this.Id)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public override bool CanMoveUp()
        {
            if (this.Parent.RootNodes.Count == 0)
                return false;

            if (this.Parent.RootNodes[0].Id != this.Id)
                return true;

            return false;
        }

        /// <summary>
        /// Finds out if the current tree node can be moved down or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved down, false otherwise</returns>
        public override bool CanMoveDown()
        {
            if (this.Parent.RootNodes.Count == 0)
                return false;

            if (this.Parent.RootNodes[this.Parent.RootNodes.Count - 1].Id != this.Id)
                return true;

            return false;
        }

        /// <summary>
        /// Moves this element up or down in the display order by repositioning the element in the collection.
        /// </summary>
        /// <param name="bUp"></param>
        protected override void Move(bool bUp)
        {
            // find index and move element
            for (int i = 0; i < this.Parent.RootNodes.Count; ++i)
                if (this.Parent.RootNodes[i].Id == this.Id)
                {
                    if (bUp)
                        this.Parent.MoveRootDiagramNodes(i, i - 1);
                    else
                        this.Parent.MoveRootDiagramNodes(i, i + 1);


                    break;
                }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model hosts an ShapeClassNode.
    /// </summary>
    public class ShapeClassNodeViewModel : BaseAttributeElementViewModel
    {
        private ShapeClassNode shapeClassNode;
        private TreeNodeViewModel parentTreeNode;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="shapeClassNode">ShapeClassNode.</param>
        /// <param name="parent">Parent.</param>
        public ShapeClassNodeViewModel(ViewModelStore viewModelStore, ShapeClassNode shapeClassNode, TreeNodeViewModel parent)
            : base(viewModelStore, shapeClassNode.ShapeClass)
        {
            this.shapeClassNode = shapeClassNode;
            this.parentTreeNode = parent;
        }

        /// <summary>
        /// Gets the reference node hosted by this view model.
        /// </summary>
        public ShapeClassNode ShapeClassNode
        {
            get
            {
                return this.shapeClassNode;
            }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public bool IsThisLastNode()
        {
            if (this.parentTreeNode.ShapeClassNodes.Count == 0)
                return false;

            if (this.parentTreeNode.ShapeClassNodes[this.parentTreeNode.ShapeClassNodes.Count - 1] == this)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets whether this is the last node in its parents collection or not. 
        /// Used for displaying the connection lines (There is no need to display the full vertical line for the last element).
        /// </summary>
        public bool IsLastNode
        {
            get
            {
                return IsThisLastNode();
            }
        }

        /// <summary>
        /// Determines if the current node is the first node in the parents collection.
        /// </summary>
        /// <returns>True if this node is first in its parents collection. False otherwise.</returns>
        public bool IsThisFirstNode()
        {
            if (this.parentTreeNode.ShapeClassNodes.Count == 0)
                return false;

            if (this.parentTreeNode.ShapeClassNodes[0] == this)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets whether this is the first node in its parents collection or not. 
        /// Used for displaying the connection lines (We display a special identification for the kind of relationship for the first element).
        /// </summary>
        public bool IsFirstNode
        {
            get
            {
                return IsThisFirstNode();
            }
        }

        /// <summary>
        /// Triggers property change notifications for IsFirstNode and IsLastNode if needed.
        /// </summary>
        public void UpdateNodePosition()
        {
            OnPropertyChanged("IsLastNode");
            OnPropertyChanged("IsFirstNode");
        }

        /// <summary>
        /// Gets the shape type.
        /// </summary>
        public string ShapeType
        {
            get
            {
                return this.ShapeClassNode.ShapeClass.ShapeType;
            }
        }

        /// <summary>
        /// Deletes the hosted element.
        /// </summary>
        public override void DeleteHostedElement()
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete hosted element"))
            {
                this.ShapeClassNode.Delete();

                transaction.Commit();
            }
        }
    }
}

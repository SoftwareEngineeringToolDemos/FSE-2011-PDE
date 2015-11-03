using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling.Immutability;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model hosts a domain relationship.
    /// </summary>
    public abstract class DomainRelationshipViewModel : BaseAttributeElementViewModel
    {
        private TreeNodeViewModel parentTreeNode;

        private DomainRoleViewModel sourceRoleVM;
        private DomainRoleViewModel targetRoleVM;

        
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="referenceRSNode">ReferenceRSNode.</param>
        /// <param name="parent">Parent.</param>
        public DomainRelationshipViewModel(ViewModelStore viewModelStore, DomainRelationship relationship, TreeNodeViewModel parent)
            : base(viewModelStore, relationship)
        {
            this.parentTreeNode = parent;

            if (relationship != null)
            {
                sourceRoleVM = new DomainRoleViewModel(this.ViewModelStore, relationship.Source, this);
                targetRoleVM = new DomainRoleViewModel(this.ViewModelStore, relationship.Target, this);

            }
        }



        /// <summary>
        /// Gets the parent node.
        /// </summary>
        public TreeNodeViewModel Parent
        {
            get
            {
                return this.parentTreeNode;
            }
        }

        /// <summary>
        /// Gets the source role VM.
        /// </summary>
        public DomainRoleViewModel Source
        {
            get
            {
                return this.sourceRoleVM;
            }
        }

        /// <summary>
        /// Gets the target role VM.
        /// </summary>
        public DomainRoleViewModel Target
        {
            get
            {
                return this.targetRoleVM;
            }
        }

        /// <summary>
        /// Finds a view model that is representing the given model element.
        /// </summary>
        /// <param name="element">Model element.</param>
        /// <returns>View model if found; Null otherwise.</returns>
        public virtual BaseModelElementViewModel FindViewModel(ModelElement element)
        {
            if (Source.Role == element)
                return Source;

            if (Target.Role == element)
                return Target;


            return null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.Commands;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class EmbeddingDiagramNodeViewModel : DiagramTreeNodeViewModel
    {
        private EmbeddingDiagramNodeViewModel parent;

        private ObservableCollection<EmbeddingDiagramNodeViewModel> embeddingNodeVMs;
        private ReadOnlyObservableCollection<EmbeddingDiagramNodeViewModel> embeddingNodeVMsRO;

        private DelegateCommand expandCollapseTreeCommand;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="embeddingDiagramNode">Element represented by this view model.</param>
        public EmbeddingDiagramNodeViewModel(ViewModelStore viewModelStore, EmbeddingDiagramNode embeddingDiagramNode, EmbeddingDiagramNodeViewModel parent)
            : base(viewModelStore, embeddingDiagramNode)
        {
            this.parent = parent;

            this.embeddingNodeVMs = new ObservableCollection<EmbeddingDiagramNodeViewModel>();
            this.embeddingNodeVMsRO = new ReadOnlyObservableCollection<EmbeddingDiagramNodeViewModel>(this.embeddingNodeVMs);

            if (this.EmbeddingDiagramNode != null)
            {
                foreach (EmbeddingDiagramNode node in this.EmbeddingDiagramNode.EmbeddingDiagramNodes)
                    this.AddEmbeddingDiagramNode(node);

                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.EmbeddingDiagramNode.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.DomainClassId),
                    true, this.EmbeddingDiagramNode.Id, new Action<ElementAddedEventArgs>(OnEmbeddingDiagramNodeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.DomainClassId),
                    true, this.EmbeddingDiagramNode.Id, new Action<ElementDeletedEventArgs>(OnEmbeddingDiagramNodeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.DomainClassId),
                    this.EmbeddingDiagramNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnEmbeddingDiagramNodeMoved));

                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.SourceEmbeddingDiagramNodeDomainRoleId),
                    new Action<RolePlayerChangedEventArgs>(OnEmbeddingDiagramNodeChanged));
            }

            expandCollapseTreeCommand = new DelegateCommand(ExpandCollapseTreeCommand_Executed);
        }

        /// <summary>
        /// Gets the parent element.
        /// </summary>
        public EmbeddingDiagramNodeViewModel Parent
        {
            get
            {
                return this.parent;
            }
        }

        /// <summary>
        /// Gets the embedding diagram node.
        /// </summary>
        public EmbeddingDiagramNode EmbeddingDiagramNode
        {
            get
            {
                return this.DiagramTreeNode as EmbeddingDiagramNode;
            }
        }

        /// <summary>
        /// Gets a read-only collection of embedding nodes.
        /// </summary>
        public ReadOnlyObservableCollection<EmbeddingDiagramNodeViewModel> EmbeddingNodes
        {
            get
            {
                return this.embeddingNodeVMsRO;
            }
        }
                
        #region Commands And Methods
        /// <summary>
        /// ExpandCollapseCommandTree command.
        /// </summary>
        public DelegateCommand ExpandCollapseCommandTree
        {
            get { return this.expandCollapseTreeCommand; }
        }

        /// <summary>
        /// ExpandCollapseCommandTree executed.
        /// </summary>
        private void ExpandCollapseTreeCommand_Executed()
        {
            using (Transaction transaction = Store.TransactionManager.BeginTransaction("Expand/Collapse Tree"))
            {
                if (this.IsChildrenTreeExpanded)
                    this.IsChildrenTreeExpanded = false;
                else
                    this.IsChildrenTreeExpanded = true;

                transaction.Commit();
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// True, if this node contains embedding nodes as children. False otherwise.
        /// </summary>
        public bool HasEmbeddingNodes
        {
            get
            {
                if (this.EmbeddingNodes.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Gets or sets whether this embedding diagram node is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.EmbeddingDiagramNode.IsExpanded;

            }
            set
            {
                if (this.EmbeddingDiagramNode.IsExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsExpanded"))
                    {
                        this.EmbeddingDiagramNode.IsExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the children tree of this embedding diagram node is expanded or not.
        /// </summary>
        public bool IsChildrenTreeExpanded
        {
            get
            {
                return this.EmbeddingDiagramNode.IsChildrenTreeExpanded;

            }
            set
            {
                if (this.EmbeddingDiagramNode.IsChildrenTreeExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsChildrenTreeExpanded"))
                    {
                        this.EmbeddingDiagramNode.IsChildrenTreeExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsChildrenTreeExpanded");
                }
            }
        }
        #endregion

        #region Model Methods
        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnElementPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == EmbeddingDiagramNode.IsExpandedDomainPropertyId)
                OnPropertyChanged("IsExpanded");
            else if (args.DomainProperty.Id == EmbeddingDiagramNode.IsChildrenTreeExpandedDomainPropertyId)
                OnPropertyChanged("IsChildrenTreeExpanded");
        }

        /// <summary>
        /// Adds a new embedding view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddEmbeddingDiagramNode(EmbeddingDiagramNode node)
        {
            // verify that node hasnt been added yet
            foreach (EmbeddingDiagramNodeViewModel viewModel in this.embeddingNodeVMs)
                if (viewModel.EmbeddingDiagramNode.Id == node.Id)
                    return;

            EmbeddingDiagramNodeViewModel vm = new EmbeddingDiagramNodeViewModel(this.ViewModelStore, node, this);
            this.embeddingNodeVMs.Add(vm);

            foreach (EmbeddingDiagramNodeViewModel viewModel in this.embeddingNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasEmbeddingNodes");
        }

        /// <summary>
        /// Deletes the view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteEmbeddingDiagramNode(EmbeddingDiagramNode node)
        {
            for (int i = this.embeddingNodeVMs.Count - 1; i >= 0; i--)
                if (this.embeddingNodeVMs[i].EmbeddingDiagramNode.Id == node.Id)
                {
                    this.embeddingNodeVMs[i].Dispose();
                    this.embeddingNodeVMs.RemoveAt(i);
                }


            foreach (EmbeddingDiagramNodeViewModel vm in this.embeddingNodeVMs)
                vm.UpdateNodePosition();

            OnPropertyChanged("HasEmbeddingNodes");
        }

        /// <summary>
        /// Called whenever a relationship of type EmbeddingDiagramNodeHasEmbeddingDiagramNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingDiagramNodeAdded(ElementAddedEventArgs args)
        {
            EmbeddingDiagramNodeHasEmbeddingDiagramNodes con = args.ModelElement as EmbeddingDiagramNodeHasEmbeddingDiagramNodes;
            if (con != null)
            {
                AddEmbeddingDiagramNode(con.TargetEmbeddingDiagramNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type EmbeddingDiagramNodeHasEmbeddingDiagramNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingDiagramNodeRemoved(ElementDeletedEventArgs args)
        {
            EmbeddingDiagramNodeHasEmbeddingDiagramNodes con = args.ModelElement as EmbeddingDiagramNodeHasEmbeddingDiagramNodes;
            if (con != null)
            {
                DeleteEmbeddingDiagramNode(con.TargetEmbeddingDiagramNode);
            }

        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingDiagramNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.EmbeddingDiagramNode)
                this.embeddingNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);

            foreach (EmbeddingDiagramNodeViewModel vm in this.embeddingNodeVMs)
                vm.UpdateNodePosition();
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingDiagramNodeChanged(RolePlayerChangedEventArgs args)
        {
            EmbeddingDiagramNodeHasEmbeddingDiagramNodes con = args.ElementLink as EmbeddingDiagramNodeHasEmbeddingDiagramNodes;
            if (con != null)
            {
                if (args.DomainRole.Id == EmbeddingDiagramNodeHasEmbeddingDiagramNodes.SourceEmbeddingDiagramNodeDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.EmbeddingDiagramNode.Id)
                    {
                        DeleteEmbeddingDiagramNode(con.TargetEmbeddingDiagramNode);
                    }

                    if (args.NewRolePlayerId == this.EmbeddingDiagramNode.Id)
                    {
                        AddEmbeddingDiagramNode(con.TargetEmbeddingDiagramNode);
                    }
                }
            }
        }
        #endregion

        #region Movement Methods
        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public override bool CanMoveUp()
        {
            if (this.Parent.EmbeddingNodes.Count == 0)
                return false;

            if (this.Parent.EmbeddingNodes[0].Id != this.Id)
                return true;

            return false;
        }

        /// <summary>
        /// Finds out if the current tree node can be moved down or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved down, false otherwise</returns>
        public override bool CanMoveDown()
        {
            if (this.Parent.EmbeddingNodes.Count == 0)
                return false;

            if (this.Parent.EmbeddingNodes[this.Parent.EmbeddingNodes.Count - 1].Id != this.Id)
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
            for (int i = 0; i < this.Parent.EmbeddingNodes.Count; ++i)
                if (this.Parent.EmbeddingNodes[i].Id == this.Id)
                {
                    if (bUp)
                        this.Parent.MoveEmbeddingDiagramNodes(i, i - 1);
                    else
                        this.Parent.MoveEmbeddingDiagramNodes(i, i + 1);


                    break;
                }
        }
        
        /// <summary>
        /// Moves embedding diagram nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveEmbeddingDiagramNodes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move diagram nodes"))
            {
                this.EmbeddingDiagramNode.EmbeddingDiagramNodes.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public virtual bool IsThisLastNode()
        {
            if (this.Parent.EmbeddingNodes.Count == 0)
                return false;

            if (this.Parent.EmbeddingNodes[this.Parent.EmbeddingNodes.Count - 1].Id == this.Id)
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
        public virtual bool IsThisFirstNode()
        {
            if (this.Parent.EmbeddingNodes.Count == 0)
                return false;

            if (this.Parent.EmbeddingNodes[0].Id == this.Id)
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
        #endregion

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.EmbeddingDiagramNode != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.EmbeddingDiagramNode.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.DomainClassId),
                    true, this.EmbeddingDiagramNode.Id, new Action<ElementAddedEventArgs>(OnEmbeddingDiagramNodeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.DomainClassId),
                    true, this.EmbeddingDiagramNode.Id, new Action<ElementDeletedEventArgs>(OnEmbeddingDiagramNodeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.DomainClassId),
                    this.EmbeddingDiagramNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnEmbeddingDiagramNodeMoved));

                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(EmbeddingDiagramNodeHasEmbeddingDiagramNodes.SourceEmbeddingDiagramNodeDomainRoleId),
                    new Action<RolePlayerChangedEventArgs>(OnEmbeddingDiagramNodeChanged));
            }

            base.OnDispose();
        }

        /// <summary>
        /// Finds a view model that is representing the given model element.
        /// </summary>
        /// <param name="element">Model element.</param>
        /// <returns>View model if found; Null otherwise.</returns>
        public BaseModelElementViewModel FindViewModel(ModelElement element)
        {
            foreach (EmbeddingDiagramNodeViewModel vm in EmbeddingNodes)
            {
                if (vm.Element == element)
                    return vm;

                BaseModelElementViewModel retVm = vm.FindViewModel(element);
                if (retVm != null)
                    return retVm;
            }

            return null;
        }
    }
}

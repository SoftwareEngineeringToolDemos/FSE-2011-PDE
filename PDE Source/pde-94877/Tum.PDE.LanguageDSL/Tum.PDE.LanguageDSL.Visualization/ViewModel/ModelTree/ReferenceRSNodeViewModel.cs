using System;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.LanguageDSL.Visualization.Commands;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model hosts an ReferenceRSNode.
    /// </summary>
    public class ReferenceRSNodeViewModel : DomainRelationshipViewModel
    {
        private ReferenceRSNode referenceRSNode;

        private ObservableCollection<ReferenceNodeViewModel> referenceNodeVMs;
        private ReadOnlyObservableCollection<ReferenceNodeViewModel> referenceNodeVMsRO;

        private ObservableCollection<ShapeRelationshipNodeViewModel> shapeNodeVMs;
        private ReadOnlyObservableCollection<ShapeRelationshipNodeViewModel> shapeNodeVMsRO;

        private DelegateCommand collapseExpandRelationshipShapeMappingCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="referenceRSNode">ReferenceRSNode.</param>
        /// <param name="parent">Parent.</param>
        public ReferenceRSNodeViewModel(ViewModelStore viewModelStore, ReferenceRSNode referenceRSNode, TreeNodeViewModel parent)
            : base(viewModelStore, referenceRSNode.ReferenceRelationship, parent)
        {
            this.referenceRSNode = referenceRSNode;

            this.referenceNodeVMs = new ObservableCollection<ReferenceNodeViewModel>();
            this.referenceNodeVMsRO = new ReadOnlyObservableCollection<ReferenceNodeViewModel>(referenceNodeVMs);

            this.shapeNodeVMs = new ObservableCollection<ShapeRelationshipNodeViewModel>();
            this.shapeNodeVMsRO = new ReadOnlyObservableCollection<ShapeRelationshipNodeViewModel>(shapeNodeVMs);

            if (referenceRSNode != null)
            {
                if (referenceRSNode.ReferenceNode != null)
                {
                    AddReferenceNode(referenceRSNode.ReferenceNode);
                }

                foreach (ShapeRelationshipNode node in referenceRSNode.ShapeRelationshipNodes)
                    if (node != null)
                        AddShapeNode(node);

                Subscribe();
            }

            this.collapseExpandRelationshipShapeMappingCommand = new DelegateCommand(CollapseExpandRelationshipShapeMappingCommand_Executed);
        }

        /// <summary>
        /// Gets the reference rs node.
        /// </summary>
        public ReferenceRSNode ReferenceRSNode
        {
            get { return this.referenceRSNode; }
        }

        /// <summary>
        /// Gets a read-only collection of reference rs nodes.
        /// </summary>
        public ReadOnlyObservableCollection<ReferenceNodeViewModel> ReferenceNodes
        {
            get
            {
                return this.referenceNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of shape rs nodes.
        /// </summary>
        public ReadOnlyObservableCollection<ShapeRelationshipNodeViewModel> ShapeRelationshipNodes
        {
            get
            {
                return this.shapeNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets or sets whether the shape mapping tree is expanded or not.
        /// </summary>
        public bool IsShapeMappingTreeExpanded
        {
            get
            {
                return this.ReferenceRSNode.IsShapeMappingTreeExpanded;

            }
            set
            {
                if (this.ReferenceRSNode.IsShapeMappingTreeExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsShapeMappingTreeExpanded"))
                    {
                        this.ReferenceRSNode.IsShapeMappingTreeExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsShapeMappingTreeExpanded");
                }
            }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public bool IsThisLastNode()
        {
            if (this.Parent.ReferenceRSNodes.Count == 0)
                return false;

            if (this.Parent.ReferenceRSNodes[this.Parent.ReferenceRSNodes.Count - 1] == this)
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
            if (this.Parent.ReferenceRSNodes.Count == 0)
                return false;

            if (this.Parent.ReferenceRSNodes[0] == this)
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
        /// True, if this node contains reference relationship nodes as children. False otherwise.
        /// </summary>
        public bool HasShapeMappingNodes
        {
            get
            {
                if (this.ShapeRelationshipNodes.Count == 0)
                    return false;

                return true;
            }
        }
        
        /// <summary>
        /// Gets the CollapseExpandRelationshipShapeMappingCommand.
        /// </summary>
        public DelegateCommand CollapseExpandRelationshipShapeMappingCommand
        {
            get
            {
                return this.collapseExpandRelationshipShapeMappingCommand;
            }
        }

        /// <summary>
        /// CollapseExpandRelationshipShapeMappingCommand executed.
        /// </summary>
        private void CollapseExpandRelationshipShapeMappingCommand_Executed()
        {
            this.IsShapeMappingTreeExpanded = !this.IsShapeMappingTreeExpanded;
        }

        /// <summary>
        /// Adds a new reference rs view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddReferenceNode(ReferenceNode node)
        {
            // verify that node hasnt been added yet
            foreach (ReferenceNodeViewModel viewModel in this.referenceNodeVMs)
                if (viewModel.ReferenceNode.Id == node.Id)
                    return;

            ReferenceNodeViewModel vm = new ReferenceNodeViewModel(this.ViewModelStore, node, this);
            this.referenceNodeVMs.Add(vm);
        }

        /// <summary>
        /// Deletes the rs view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteReferenceNode(ReferenceNode node)
        {
            for (int i = this.referenceNodeVMs.Count - 1; i >= 0; i--)
                if (this.referenceNodeVMs[i].ReferenceNode.Id == node.Id)
                {
                    this.referenceNodeVMs[i].Dispose();
                    this.referenceNodeVMs.RemoveAt(i);
                }
        }

        /// <summary>
        /// Called whenever a relationship of type ReferenceRSNodeReferencesReferenceNode is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceNodeAdded(ElementAddedEventArgs args)
        {
            ReferenceRSNodeReferencesReferenceNode con = args.ModelElement as ReferenceRSNodeReferencesReferenceNode;
            if (con != null)
            {
                AddReferenceNode(con.ReferenceNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type ReferenceRSNodeReferencesReferenceNode is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceNodeRemoved(ElementDeletedEventArgs args)
        {
            ReferenceRSNodeReferencesReferenceNode con = args.ModelElement as ReferenceRSNodeReferencesReferenceNode;
            if (con != null)
            {
                DeleteReferenceNode(con.ReferenceNode);
            }
        }

        /// <summary>
        /// Adds a new reference rs view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddShapeNode(ShapeRelationshipNode node)
        {
            // verify that node hasnt been added yet
            foreach (ShapeRelationshipNodeViewModel viewModel in this.shapeNodeVMs)
                if (viewModel.ShapeRelationshipNode.Id == node.Id)
                    return;

            ShapeRelationshipNodeViewModel vm = new ShapeRelationshipNodeViewModel(this.ViewModelStore, node, this);
            this.shapeNodeVMs.Add(vm);

            foreach (ShapeRelationshipNodeViewModel viewModel in this.shapeNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasShapeMappingNodes");
        }

        /// <summary>
        /// Deletes the shape node view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteShapeNode(ShapeRelationshipNode node)
        {
            for (int i = this.shapeNodeVMs.Count - 1; i >= 0; i--)
                if (this.shapeNodeVMs[i].ShapeRelationshipNode.Id == node.Id)
                {
                    this.shapeNodeVMs[i].Dispose();
                    this.shapeNodeVMs.RemoveAt(i);
                }

            foreach (ShapeRelationshipNodeViewModel viewModel in this.shapeNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasShapeMappingNodes");
        }

        /// <summary>
        /// Called whenever a relationship of type ReferenceRSNodeReferencesShapeRelationshipNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeNodeAdded(ElementAddedEventArgs args)
        {
            ReferenceRSNodeReferencesShapeRelationshipNodes con = args.ModelElement as ReferenceRSNodeReferencesShapeRelationshipNodes;
            if (con != null)
            {
                AddShapeNode(con.ShapeRelationshipNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type ReferenceRSNodeReferencesShapeRelationshipNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeNodeRemoved(ElementDeletedEventArgs args)
        {
            ReferenceRSNodeReferencesShapeRelationshipNodes con = args.ModelElement as ReferenceRSNodeReferencesShapeRelationshipNodes;
            if (con != null)
            {
                DeleteShapeNode(con.ShapeRelationshipNode);
            }
        }

        /// <summary>
        /// Subscribes to events.
        /// </summary>
        public void Subscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesReferenceNode.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementAddedEventArgs>(OnReferenceNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesReferenceNode.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementDeletedEventArgs>(OnReferenceNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesShapeRelationshipNodes.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementAddedEventArgs>(OnShapeNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesShapeRelationshipNodes.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementDeletedEventArgs>(OnShapeNodeRemoved));
        }

        /// <summary>
        /// Unsubscribes from events.
        /// </summary>
        public void Unsubscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesReferenceNode.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementAddedEventArgs>(OnReferenceNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesReferenceNode.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementDeletedEventArgs>(OnReferenceNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesShapeRelationshipNodes.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementAddedEventArgs>(OnShapeNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ReferenceRSNodeReferencesShapeRelationshipNodes.DomainClassId),
                true, this.referenceRSNode.Id, new Action<ElementDeletedEventArgs>(OnShapeNodeRemoved));
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        protected override void OnDispose()
        {
            if( this.referenceRSNode != null )
                Unsubscribe();

            base.OnDispose();
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            return this.ReferenceRSNode.ReferenceRelationship;
        }

        /// <summary>
        /// Finds a view model that is representing the given model element.
        /// </summary>
        /// <param name="element">Model element.</param>
        /// <returns>View model if found; Null otherwise.</returns>
        public override BaseModelElementViewModel FindViewModel(ModelElement element)
        {
            BaseModelElementViewModel m = base.FindViewModel(element);
            if (m != null)
                return m;

            foreach (ReferenceNodeViewModel vm in ReferenceNodes)
            {
                if (vm.Element == element && vm.IsElementHolder)
                    return vm;

                BaseModelElementViewModel retVm = vm.FindViewModel(element);
                if (retVm != null)
                    return retVm;
            }

            return null;
        }
    }
}

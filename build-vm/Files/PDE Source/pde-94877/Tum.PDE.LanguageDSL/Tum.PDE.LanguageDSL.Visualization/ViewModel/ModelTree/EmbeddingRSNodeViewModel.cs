using System;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{    
    /// <summary>
    /// This view model hosts an EmbeddingRSNode.
    /// </summary>
    public class EmbeddingRSNodeViewModel : DomainRelationshipViewModel
    {
        private EmbeddingRSNode embeddingRSNode;
        
        private ObservableCollection<EmbeddingNodeViewModel> embeddingNodeVMs;
        private ReadOnlyObservableCollection<EmbeddingNodeViewModel> embeddingNodeVMsRO;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="embeddingRSNode">EmbeddingRSNode.</param>
        /// <param name="parent">Parent.</param>
        public EmbeddingRSNodeViewModel(ViewModelStore viewModelStore, EmbeddingRSNode embeddingRSNode, TreeNodeViewModel parent)
            : base(viewModelStore, embeddingRSNode.Relationship, parent)
        {
            this.embeddingRSNode = embeddingRSNode;

            this.embeddingNodeVMs = new ObservableCollection<EmbeddingNodeViewModel>();
            this.embeddingNodeVMsRO = new ReadOnlyObservableCollection<EmbeddingNodeViewModel>(embeddingNodeVMs);

            if (embeddingRSNode != null)
            {
                if (embeddingRSNode.EmbeddingNode != null)
                {
                    AddEmbeddingNode(embeddingRSNode.EmbeddingNode);
                }

                Subscribe();
            }
        }

        /// <summary>
        /// Gets the embedding rs node.
        /// </summary>
        public EmbeddingRSNode EmbeddingRSNode
        {
            get
            {
                return this.embeddingRSNode;
            }
        }

        /// <summary>
        /// Gets a read-only collection of embedding rs nodes.
        /// </summary>
        public ReadOnlyObservableCollection<EmbeddingNodeViewModel> EmbeddingNodes
        {
            get
            {
                return this.embeddingNodeVMsRO;
            }
        }

        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public bool IsThisLastNode()
        {
            if (this.Parent.EmbeddingRSNodes.Count == 0)
                return false;

            if (this.Parent.EmbeddingRSNodes[this.Parent.EmbeddingRSNodes.Count - 1] == this)
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
            if (this.Parent.EmbeddingRSNodes.Count == 0)
                return false;

            if (this.Parent.EmbeddingRSNodes[0] == this)
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
        /// Adds a new embedding rs view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddEmbeddingNode(EmbeddingNode node)
        {
            // verify that node hasnt been added yet
            foreach (EmbeddingNodeViewModel viewModel in this.embeddingNodeVMs)
                if (viewModel.EmbeddingNode.Id == node.Id)
                    return;

            EmbeddingNodeViewModel vm = new EmbeddingNodeViewModel(this.ViewModelStore, node, this);
            this.embeddingNodeVMs.Add(vm);
        }

        /// <summary>
        /// Deletes the rs view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteEmbeddingNode(EmbeddingNode node)
        {
            for (int i = this.embeddingNodeVMs.Count - 1; i >= 0; i--)
                if (this.embeddingNodeVMs[i].EmbeddingNode.Id == node.Id)
                {
                    this.embeddingNodeVMs[i].Dispose();
                    this.embeddingNodeVMs.RemoveAt(i);
                }
        }

        /// <summary>
        /// Called whenever a relationship of type EmbeddingRSNodeReferencesEmbeddingNode is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingNodeAdded(ElementAddedEventArgs args)
        {
            EmbeddingRSNodeReferencesEmbeddingNode con = args.ModelElement as EmbeddingRSNodeReferencesEmbeddingNode;
            if (con != null)
            {
                AddEmbeddingNode(con.EmbeddingNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type EmbeddingRSNodeReferencesEmbeddingNode is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingNodeRemoved(ElementDeletedEventArgs args)
        {
            EmbeddingRSNodeReferencesEmbeddingNode con = args.ModelElement as EmbeddingRSNodeReferencesEmbeddingNode;
            if (con != null)
            {
                DeleteEmbeddingNode(con.EmbeddingNode);
            }
        }

        /// <summary>
        /// Subscribes to events.
        /// </summary>
        public void Subscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingRSNodeReferencesEmbeddingNode.DomainClassId),
                true, this.embeddingRSNode.Id, new Action<ElementAddedEventArgs>(OnEmbeddingNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingRSNodeReferencesEmbeddingNode.DomainClassId),
                true, this.embeddingRSNode.Id, new Action<ElementDeletedEventArgs>(OnEmbeddingNodeRemoved));

        }

        /// <summary>
        /// Unsubscribes from events.
        /// </summary>
        public void Unsubscribe()
        {
            if (this.EmbeddingRSNode != null)
            {
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingRSNodeReferencesEmbeddingNode.DomainClassId),
                    true, this.embeddingRSNode.Id, new Action<ElementAddedEventArgs>(OnEmbeddingNodeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(EmbeddingRSNodeReferencesEmbeddingNode.DomainClassId),
                    true, this.embeddingRSNode.Id, new Action<ElementDeletedEventArgs>(OnEmbeddingNodeRemoved));
            }
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        protected override void OnDispose()
        {
            Unsubscribe();

            base.OnDispose();
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            return this.EmbeddingRSNode.Relationship;
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

            foreach (EmbeddingNodeViewModel vm in EmbeddingNodes)
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

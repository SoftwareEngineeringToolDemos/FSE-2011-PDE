using System;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This is the abstract class for display a TreeNode.
    /// </summary>
    public abstract class TreeNodeViewModel : BaseAttributeElementViewModel
    {
        #region Fields
        private TreeNode treeNode;
        private TreeNodeViewModel parentTreeNode;

        private ObservableCollection<EmbeddingRSNodeViewModel> embeddingRSNodeVMs;
        private ReadOnlyObservableCollection<EmbeddingRSNodeViewModel> embeddingRSNodeVMsRO;

        private ObservableCollection<InheritanceNodeViewModel> inheritanceNodeVMs;
        private ReadOnlyObservableCollection<InheritanceNodeViewModel> inheritanceNodeVMsRO;

        private ObservableCollection<ReferenceRSNodeViewModel> referenceRSNodeVMs;
        private ReadOnlyObservableCollection<ReferenceRSNodeViewModel> referenceRSNodeVMsRO;

        private ObservableCollection<ShapeClassNodeViewModel> shapeClassNodeVMs;
        private ReadOnlyObservableCollection<ShapeClassNodeViewModel> shapeClassNodeVMsRO;

        private DelegateCommand collapseExpandEmbeddingCommand;
        private DelegateCommand collapseExpandReferencingCommand;
        private DelegateCommand collapseExpandInheritingCommand;
        private DelegateCommand collapseExpandClassShapeMappingCommand;
        #endregion

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelTreeView">Domain model tree view.</param>
        /// <param name="parent">Parent node.</param>
        protected TreeNodeViewModel(ViewModelStore viewModelStore, TreeNode treeNode, TreeNodeViewModel parent)
            : base(viewModelStore, treeNode.DomainElement)
        {
            this.treeNode = treeNode;
            this.parentTreeNode = parent;

            this.embeddingRSNodeVMs = new ObservableCollection<EmbeddingRSNodeViewModel>();
            this.embeddingRSNodeVMsRO = new ReadOnlyObservableCollection<EmbeddingRSNodeViewModel>(embeddingRSNodeVMs);

            this.inheritanceNodeVMs = new ObservableCollection<InheritanceNodeViewModel>();
            this.inheritanceNodeVMsRO = new ReadOnlyObservableCollection<InheritanceNodeViewModel>(inheritanceNodeVMs);

            this.referenceRSNodeVMs = new ObservableCollection<ReferenceRSNodeViewModel>();
            this.referenceRSNodeVMsRO = new ReadOnlyObservableCollection<ReferenceRSNodeViewModel>(referenceRSNodeVMs);

            this.shapeClassNodeVMs = new ObservableCollection<ShapeClassNodeViewModel>();
            this.shapeClassNodeVMsRO = new ReadOnlyObservableCollection<ShapeClassNodeViewModel>(shapeClassNodeVMs);

            this.collapseExpandEmbeddingCommand = new DelegateCommand(CollapseExpandEmbeddingCommand_Executed);
            this.collapseExpandReferencingCommand = new DelegateCommand(CollapseExpandReferencingCommand_Executed);
            this.collapseExpandInheritingCommand = new DelegateCommand(CollapseExpandInheritingCommand_Executed);
            this.collapseExpandClassShapeMappingCommand = new DelegateCommand(CollapseExpandClassShapeMappingCommand_Executed);

            if (this.TreeNode != null)
            {
                foreach (EmbeddingRSNode node in this.TreeNode.EmbeddingRSNodes)
                    if (node != null)
                        AddEmbeddingRSNode(node);

                foreach (ReferenceRSNode node in this.TreeNode.ReferenceRSNodes)
                    if (node != null)
                        AddReferenceRSNode(node);

                foreach (InheritanceNode node in this.TreeNode.InheritanceNodes)
                    if (node != null)
                        AddInheritanceNode(node);

                foreach (ShapeClassNode node in this.TreeNode.ShapeClassNodes)
                    if (node != null)
                        AddShapeClassNode(node);



                Subscribe();
            }
        }

        #region Properties
        public string DomainElementContextName
        {
            get
            {
                if (this.Element is DomainClass)
                    return (this.Element as DomainClass).ModelContext.Name;
                else
                    return "";
            }
        }

        public string DomainElementDslName
        {
            get
            {
                MetaModel m = this.Element.GetMetaModel();
                if (m != null)
                    return m.Name;
                else
                    return "";
            }
        }

        public string DomainElementToolTip
        {
            get
            {
                string s = this.DomainElementContextName;
                string t = this.DomainElementDslName;
                if (t != "")
                    s = s + " - " + t;

                return s;
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
        /// Gets the hosted tree node.
        /// </summary>
        public TreeNode TreeNode
        {
            get
            {
                return this.treeNode;
            }
        }

        /// <summary>
        /// Gets a read-only collection of embedding rs nodes.
        /// </summary>
        public ReadOnlyObservableCollection<EmbeddingRSNodeViewModel> EmbeddingRSNodes
        {
            get
            {
                return this.embeddingRSNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of inheritance nodes.
        /// </summary>
        public ReadOnlyObservableCollection<InheritanceNodeViewModel> InheritanceNodes
        {
            get
            {
                return this.inheritanceNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of reference rs nodes.
        /// </summary>
        public ReadOnlyObservableCollection<ReferenceRSNodeViewModel> ReferenceRSNodes
        {
            get
            {
                return this.referenceRSNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of shape class nodes.
        /// </summary>
        public ReadOnlyObservableCollection<ShapeClassNodeViewModel> ShapeClassNodes
        {
            get
            {
                return this.shapeClassNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets or sets whether the embedding tree is expanded or not.
        /// </summary>
        public bool IsEmbeddingTreeExpanded
        {
            get
            {
                return this.TreeNode.IsEmbeddingTreeExpanded;

            }
            set
            {
                if (this.TreeNode.IsEmbeddingTreeExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsEmbeddingTreeExpanded"))
                    {
                        this.TreeNode.IsEmbeddingTreeExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsEmbeddingTreeExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the inheritance tree is expanded or not.
        /// </summary>
        public bool IsInheritanceTreeExpanded
        {
            get
            {
                return this.TreeNode.IsInheritanceTreeExpanded;

            }
            set
            {
                if (this.TreeNode.IsInheritanceTreeExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsInheritanceTreeExpanded"))
                    {
                        this.TreeNode.IsInheritanceTreeExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsInheritanceTreeExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the reference tree is expanded or not.
        /// </summary>
        public bool IsReferenceTreeExpanded
        {
            get
            {
                return this.TreeNode.IsReferenceTreeExpanded;

            }
            set
            {
                if (this.TreeNode.IsReferenceTreeExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsReferenceTreeExpanded"))
                    {
                        this.TreeNode.IsReferenceTreeExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsReferenceTreeExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the shape mapping tree is expanded or not.
        /// </summary>
        public bool IsShapeMappingTreeExpanded
        {
            get
            {
                return this.TreeNode.IsShapeMappingTreeExpanded;

            }
            set
            {
                if (this.TreeNode.IsShapeMappingTreeExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsShapeMappingTreeExpanded"))
                    {
                        this.TreeNode.IsShapeMappingTreeExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsShapeMappingTreeExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether this shape is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.TreeNode.IsExpanded;

            }
            set
            {
                if (this.TreeNode.IsExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsExpanded"))
                    {
                        this.TreeNode.IsExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsExpanded");
                }
            }
        }

        /// <summary>
        /// Gets or sets whether this shape is the element holder or not.
        /// </summary>
        public bool IsElementHolder
        {
            get
            {
                return this.TreeNode.IsElementHolder;

            }
            set
            {
                if (this.TreeNode.IsElementHolder != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsElementHolder"))
                    {
                        this.TreeNode.IsElementHolder = value;

                        transaction.Commit();
                    }

                    OnPropertyChanged("IsElementHolder");
                }
            }
        }

        /// <summary>
        /// True, if this node contains embedding rs nodes as children. False otherwise.
        /// </summary>
        public bool HasEmbeddingRSNodes
        {
            get
            {
                if (this.EmbeddingRSNodes.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// True, if this node contains inheritance nodes as children. False otherwise.
        /// </summary>
        public bool HasInheritanceNodes
        {
            get
            {
                if (this.InheritanceNodes.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// True, if this node contains reference relationship nodes as children. False otherwise.
        /// </summary>
        public bool HasReferenceNodes
        {
            get
            {
                if (this.ReferenceRSNodes.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// True, if this node contains reference relationship nodes as children. False otherwise.
        /// </summary>
        public bool HasShapeMappingNodes
        {
            get
            {
                if (this.ShapeClassNodes.Count == 0)
                    return false;

                return true;
            }
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
        /// Gets whether the hosted element is a reference relationship.
        /// </summary>
        public bool IsReferenceRelationship
        {
            get
            {
                if (this.Element == null)
                    return false;

                if (this.Element is ReferenceRelationship)
                    return true;

                return false;
            }
        }
        #endregion

        #region Model Subscription/Unsubscription + Methods
        /// <summary>
        /// Adds a new embedding rs view model for the given rs node.
        /// </summary>
        /// <param name="node">Rs node.</param>
        public void AddEmbeddingRSNode(EmbeddingRSNode node)
        {
            // verify that node hasnt been added yet
            foreach (EmbeddingRSNodeViewModel viewModel in this.embeddingRSNodeVMs)
                if (viewModel.EmbeddingRSNode.Id == node.Id)
                    return;
            
            EmbeddingRSNodeViewModel vm = new EmbeddingRSNodeViewModel(this.ViewModelStore, node, this);
            this.embeddingRSNodeVMs.Add(vm);

            foreach (EmbeddingRSNodeViewModel viewModel in this.embeddingRSNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasEmbeddingRSNodes");
        }

        /// <summary>
        /// Deletes the rs view model that is hosting the given rs node.
        /// </summary>
        /// <param name="node">Rs node.</param>
        public void DeleteEmbeddingRSNode(EmbeddingRSNode node)
        {
            for (int i = this.embeddingRSNodeVMs.Count - 1; i >= 0; i--)
                if (this.embeddingRSNodeVMs[i].EmbeddingRSNode.Id == node.Id)
                {
                    this.embeddingRSNodeVMs[i].Dispose();
                    this.embeddingRSNodeVMs.RemoveAt(i);
                }


            foreach (EmbeddingRSNodeViewModel vm in this.embeddingRSNodeVMs)
                vm.UpdateNodePosition();

            OnPropertyChanged("HasEmbeddingRSNodes");
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesEmbeddingRSNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingRSNodeAdded(ElementAddedEventArgs args)
        {
            TreeNodeReferencesEmbeddingRSNodes con = args.ModelElement as TreeNodeReferencesEmbeddingRSNodes;
            if (con != null)
            {
                AddEmbeddingRSNode(con.EmbeddingRSNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesEmbeddingRSNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingRSNodeRemoved(ElementDeletedEventArgs args)
        {
            TreeNodeReferencesEmbeddingRSNodes con = args.ModelElement as TreeNodeReferencesEmbeddingRSNodes;
            if (con != null)
            {
                DeleteEmbeddingRSNode(con.EmbeddingRSNode);
            }

        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingRSNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.TreeNode)
                this.embeddingRSNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);

            foreach (EmbeddingRSNodeViewModel vm in this.embeddingRSNodeVMs)
                vm.UpdateNodePosition();
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnEmbeddingRSNodeChanged(RolePlayerChangedEventArgs args)
        {
            TreeNodeReferencesEmbeddingRSNodes con = args.ElementLink as TreeNodeReferencesEmbeddingRSNodes;
            if (con != null)
            {
                if (args.DomainRole.Id == TreeNodeReferencesEmbeddingRSNodes.TreeNodeDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.TreeNode.Id)
                    {
                        DeleteEmbeddingRSNode(con.EmbeddingRSNode);
                    }

                    if (args.NewRolePlayerId == this.TreeNode.Id)
                    {
                        AddEmbeddingRSNode(con.EmbeddingRSNode);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new inheritance view model for the given inheritance node.
        /// </summary>
        /// <param name="node">Inheritance node.</param>
        public void AddInheritanceNode(InheritanceNode node)
        {
            if (node == null)
                return;

            if (node.DomainElement == null)
                return;

            // verify that node hasnt been added yet
            foreach (InheritanceNodeViewModel viewModel in this.inheritanceNodeVMs)
                if (viewModel.InheritanceNode.Id == node.Id)
                    return;

            InheritanceNodeViewModel newVm = new InheritanceNodeViewModel(this.ViewModelStore, node, this);
            this.inheritanceNodeVMs.Add(newVm);

            foreach (InheritanceNodeViewModel vm in this.inheritanceNodeVMs)
                vm.UpdateNodePosition();

            OnPropertyChanged("HasInheritanceNodes");
        }

        /// <summary>
        /// Deletes the inheritance view model that is hosting the given inheritance node.
        /// </summary>
        /// <param name="node">Inheritance node.</param>
        public void DeleteInheritanceNode(InheritanceNode node)
        {
            if (node == null)
                return;

            for (int i = this.inheritanceNodeVMs.Count - 1; i >= 0; i--)
                if (this.inheritanceNodeVMs[i].InheritanceNode.Id == node.Id)
                {
                    this.inheritanceNodeVMs[i].Dispose();
                    this.inheritanceNodeVMs.RemoveAt(i);
                }

            foreach (InheritanceNodeViewModel vm in this.inheritanceNodeVMs)
                vm.UpdateNodePosition();

            OnPropertyChanged("HasInheritanceNodes");
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesInheritanceNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnInheritanceNodeAdded(ElementAddedEventArgs args)
        {
            TreeNodeReferencesInheritanceNodes con = args.ModelElement as TreeNodeReferencesInheritanceNodes;
            if (con != null)
            {
                AddInheritanceNode(con.InheritanceNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesInheritanceNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnInheritanceNodeRemoved(ElementDeletedEventArgs args)
        {
            TreeNodeReferencesInheritanceNodes con = args.ModelElement as TreeNodeReferencesInheritanceNodes;
            if (con != null)
            {
                DeleteInheritanceNode(con.InheritanceNode);
            }
        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnInheritanceNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.TreeNode)
                this.inheritanceNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);

            foreach (InheritanceNodeViewModel vm in this.inheritanceNodeVMs)
                vm.UpdateNodePosition();
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnInheritanceNodeChanged(RolePlayerChangedEventArgs args)
        {
            TreeNodeReferencesInheritanceNodes con = args.ElementLink as TreeNodeReferencesInheritanceNodes;
            if (con != null)
            {
                if (args.DomainRole.Id == TreeNodeReferencesInheritanceNodes.TreeNodeDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.TreeNode.Id)
                    {
                        DeleteInheritanceNode(con.InheritanceNode);
                    }

                    if (args.NewRolePlayerId == this.TreeNode.Id)
                    {
                        AddInheritanceNode(con.InheritanceNode);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new reference rs view model for the given rs node.
        /// </summary>
        /// <param name="node">Rs node.</param>
        public void AddReferenceRSNode(ReferenceRSNode node)
        {
            // verify that node hasnt been added yet
            foreach (ReferenceRSNodeViewModel viewModel in this.referenceRSNodeVMs)
                if (viewModel.ReferenceRSNode.Id == node.Id)
                    return;

            ReferenceRSNodeViewModel vm = new ReferenceRSNodeViewModel(this.ViewModelStore, node, this);
            this.referenceRSNodeVMs.Add(vm);

            foreach (ReferenceRSNodeViewModel viewModel in this.referenceRSNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasReferenceNodes");
        }

        /// <summary>
        /// Deletes the rs view model that is hosting the given rs node.
        /// </summary>
        /// <param name="node">Rs node.</param>
        public void DeleteReferenceRSNode(ReferenceRSNode node)
        {
            for (int i = this.referenceRSNodeVMs.Count - 1; i >= 0; i--)
                if (this.referenceRSNodeVMs[i].ReferenceRSNode.Id == node.Id)
                {
                    this.referenceRSNodeVMs[i].Dispose();
                    this.referenceRSNodeVMs.RemoveAt(i);
                }

            foreach (ReferenceRSNodeViewModel viewModel in this.referenceRSNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasReferenceNodes");
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesReferenceRSNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceRSNodeAdded(ElementAddedEventArgs args)
        {
            TreeNodeReferencesReferenceRSNodes con = args.ModelElement as TreeNodeReferencesReferenceRSNodes;
            if (con != null)
            {
                AddReferenceRSNode(con.ReferenceRSNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesReferenceRSNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceRSNodeRemoved(ElementDeletedEventArgs args)
        {
            TreeNodeReferencesReferenceRSNodes con = args.ModelElement as TreeNodeReferencesReferenceRSNodes;
            if (con != null)
            {
                DeleteReferenceRSNode(con.ReferenceRSNode);
            }
        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceRSNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.TreeNode)
                this.referenceRSNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);

            foreach (ReferenceRSNodeViewModel vm in this.referenceRSNodeVMs)
                vm.UpdateNodePosition();
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnReferenceRSNodeChanged(RolePlayerChangedEventArgs args)
        {
            TreeNodeReferencesReferenceRSNodes con = args.ElementLink as TreeNodeReferencesReferenceRSNodes;
            if (con != null)
            {
                if (args.DomainRole.Id == TreeNodeReferencesReferenceRSNodes.TreeNodeDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.TreeNode.Id)
                    {
                        DeleteReferenceRSNode(con.ReferenceRSNode);
                    }

                    if (args.NewRolePlayerId == this.TreeNode.Id)
                    {
                        AddReferenceRSNode(con.ReferenceRSNode);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new shape class view model for the given shape class node.
        /// </summary>
        /// <param name="node">Shape class node.</param>
        public void AddShapeClassNode(ShapeClassNode node)
        {
            // verify that node hasnt been added yet
            foreach (ShapeClassNodeViewModel viewModel in this.shapeClassNodeVMs)
                if (viewModel.ShapeClassNode.Id == node.Id)
                    return;

            ShapeClassNodeViewModel vm = new ShapeClassNodeViewModel(this.ViewModelStore, node, this);
            this.shapeClassNodeVMs.Add(vm);

            foreach (ShapeClassNodeViewModel viewModel in this.shapeClassNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasShapeMappingNodes");
        }

        /// <summary>
        /// Deletes the shape class view model that is hosting the given shape class node.
        /// </summary>
        /// <param name="node">Shape class node.</param>
        public void DeleteShapeClassNode(ShapeClassNode node)
        {
            for (int i = this.shapeClassNodeVMs.Count - 1; i >= 0; i--)
                if (this.shapeClassNodeVMs[i].ShapeClassNode.Id == node.Id)
                {
                    this.shapeClassNodeVMs[i].Dispose();
                    this.shapeClassNodeVMs.RemoveAt(i);
                }

            foreach (ShapeClassNodeViewModel viewModel in this.shapeClassNodeVMs)
                viewModel.UpdateNodePosition();

            OnPropertyChanged("HasShapeMappingNodes");
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesShapeClassNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeClassNodeAdded(ElementAddedEventArgs args)
        {
            TreeNodeReferencesShapeClassNodes con = args.ModelElement as TreeNodeReferencesShapeClassNodes;
            if (con != null)
            {
                AddShapeClassNode(con.ShapeClassNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type TreeNodeReferencesShapeClassNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeClassNodeRemoved(ElementDeletedEventArgs args)
        {
            TreeNodeReferencesShapeClassNodes con = args.ModelElement as TreeNodeReferencesShapeClassNodes;
            if (con != null)
            {
                DeleteShapeClassNode(con.ShapeClassNode);
            }
        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeClassNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.TreeNode)
                this.shapeClassNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);

            foreach (ShapeClassNodeViewModel vm in this.shapeClassNodeVMs)
                vm.UpdateNodePosition();
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnShapeClassNodeChanged(RolePlayerChangedEventArgs args)
        {
            TreeNodeReferencesShapeClassNodes con = args.ElementLink as TreeNodeReferencesShapeClassNodes;
            if (con != null)
            {
                if (args.DomainRole.Id == TreeNodeReferencesShapeClassNodes.TreeNodeDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.TreeNode.Id)
                    {
                        DeleteShapeClassNode(con.ShapeClassNode);
                    }

                    if (args.NewRolePlayerId == this.TreeNode.Id)
                    {
                        AddShapeClassNode(con.ShapeClassNode);
                    }
                }
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnTreeNodePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == TreeNode.IsElementHolderDomainPropertyId)
                OnPropertyChanged("IsElementHolder");
            else if (args.DomainProperty.Id == TreeNode.IsEmbeddingTreeExpandedDomainPropertyId)
                OnPropertyChanged("IsEmbeddingTreeExpanded");
            else if (args.DomainProperty.Id == TreeNode.IsExpandedDomainPropertyId)
                OnPropertyChanged("IsExpanded");
            else if (args.DomainProperty.Id == TreeNode.IsInheritanceTreeExpandedDomainPropertyId)
                OnPropertyChanged("IsInheritanceTreeExpanded");
            else if (args.DomainProperty.Id == TreeNode.IsReferenceTreeExpandedDomainPropertyId)
                OnPropertyChanged("IsReferenceTreeExpanded");
            else if (args.DomainProperty.Id == TreeNode.IsShapeMappingTreeExpandedDomainPropertyId)
                OnPropertyChanged("IsShapeMappingTreeExpanded");
        }
        
        /// <summary>
        /// Subscribes to events.
        /// </summary>
        public void Subscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesEmbeddingRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnEmbeddingRSNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesEmbeddingRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnEmbeddingRSNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesInheritanceNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnInheritanceNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesInheritanceNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnInheritanceNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesReferenceRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnReferenceRSNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesReferenceRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnReferenceRSNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesShapeClassNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnShapeClassNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesShapeClassNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnShapeClassNodeRemoved));

            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.TreeNode.Id, new Action<ElementPropertyChangedEventArgs>(OnTreeNodePropertyChanged));

            // move events
            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesEmbeddingRSNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnEmbeddingRSNodeMoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesInheritanceNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnInheritanceNodeMoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesReferenceRSNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnReferenceRSNodeMoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesShapeClassNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnShapeClassNodeMoved));

            // change events
            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesEmbeddingRSNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnEmbeddingRSNodeChanged));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesInheritanceNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnInheritanceNodeChanged));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesReferenceRSNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnReferenceRSNodeChanged));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesShapeClassNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnShapeClassNodeChanged));
        }

        /// <summary>
        /// Unsubscribes from events.
        /// </summary>
        public void Unsubscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesEmbeddingRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnEmbeddingRSNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesEmbeddingRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnEmbeddingRSNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesInheritanceNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnInheritanceNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesInheritanceNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnInheritanceNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesReferenceRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnReferenceRSNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesReferenceRSNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnReferenceRSNodeRemoved));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesShapeClassNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementAddedEventArgs>(OnShapeClassNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesShapeClassNodes.DomainClassId),
                true, this.TreeNode.Id, new Action<ElementDeletedEventArgs>(OnShapeClassNodeRemoved));

            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.TreeNode.Id, new Action<ElementPropertyChangedEventArgs>(OnTreeNodePropertyChanged));

            // move events
            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesEmbeddingRSNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnEmbeddingRSNodeMoved));
            
            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesInheritanceNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnInheritanceNodeMoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesReferenceRSNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnReferenceRSNodeMoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(TreeNodeReferencesShapeClassNodes.DomainClassId),
                this.TreeNode.Id, new Action<RolePlayerOrderChangedEventArgs>(OnShapeClassNodeMoved));

            // change events
            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesEmbeddingRSNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnEmbeddingRSNodeChanged));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesInheritanceNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnInheritanceNodeChanged));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesReferenceRSNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnReferenceRSNodeChanged));

            this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(TreeNodeReferencesShapeClassNodes.TreeNodeDomainRoleId),
                new Action<RolePlayerChangedEventArgs>(OnShapeClassNodeChanged));
        }

        #endregion

        #region Movement Methods
        /// <summary>
        /// Finds out if the current tree node can be moved up or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved up, false otherwise</returns>
        public abstract bool CanMoveUp();

        /// <summary>
        /// Finds out if the current tree node can be moved down or not.
        /// </summary>
        /// <returns>True if the current tree node can be moved down, false otherwise</returns>
        public abstract bool CanMoveDown();

        /// <summary>
        /// Moves this element up in the display order.
        /// </summary>
        public void MoveUp()
        {
            Move(true);
        }

        /// <summary>
        /// Moves this element down in the display order.
        /// </summary>
        public void MoveDown()
        {
            Move(false);
        }

        /// <summary>
        /// Moves embedding rs nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveEmbeddingRsNodes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move embedding rs nodes"))
            {
                this.TreeNode.EmbeddingRSNodes.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Moves reference rs nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveReferenceRsNodes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move reference rs nodes"))
            {
                this.TreeNode.ReferenceRSNodes.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Moves inheritance nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveInheritanceNodes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move inheritance nodes"))
            {
                this.TreeNode.InheritanceNodes.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Moves this element up or down in the display order by repositioning the element in the collection.
        /// </summary>
        /// <param name="bUp"></param>
        protected abstract void Move(bool bUp);
        
        /// <summary>
        /// Determines if the current node is the last node in the parents collection.
        /// </summary>
        /// <returns>True if this node is last in its parents collection. False otherwise.</returns>
        public abstract bool IsThisLastNode();

        /// <summary>
        /// Determines if the current node is the first node in the parents collection.
        /// </summary>
        /// <returns>True if this node is first in its parents collection. False otherwise.</returns>
        public abstract bool IsThisFirstNode();

        /// <summary>
        /// Triggers property change notifications for IsFirstNode and IsLastNode if needed.
        /// </summary>
        public void UpdateNodePosition()
        {
            OnPropertyChanged("IsLastNode");
            OnPropertyChanged("IsFirstNode");
        }
        #endregion

        #region Commands + Methods
        /// <summary>
        /// Gets the CollapseExpandEmbeddingCommand.
        /// </summary>
        public DelegateCommand CollapseExpandEmbeddingCommand
        {
            get
            {
                return this.collapseExpandEmbeddingCommand;
            }
        }

        /// <summary>
        /// Gets the CollapseExpandReferencingCommand.
        /// </summary>
        public DelegateCommand CollapseExpandReferencingCommand
        {
            get
            {
                return this.collapseExpandReferencingCommand;
            }
        }

        /// <summary>
        /// Gets the CollapseExpandInheritingCommand.
        /// </summary>
        public DelegateCommand CollapseExpandInheritingCommand
        {
            get
            {
                return this.collapseExpandInheritingCommand;
            }
        }

        /// <summary>
        /// Gets the CollapseExpandClassShapeMappingCommand.
        /// </summary>
        public DelegateCommand CollapseExpandClassShapeMappingCommand
        {
            get
            {
                return this.collapseExpandClassShapeMappingCommand;
            }
        }

        /// <summary>
        /// CollapseExpandEmbeddingCommand executed.
        /// </summary>
        private void CollapseExpandEmbeddingCommand_Executed()
        {
            this.IsEmbeddingTreeExpanded = !this.IsEmbeddingTreeExpanded;
        }

        /// <summary>
        /// CollapseExpandReferencingCommand executed.
        /// </summary>
        private void CollapseExpandReferencingCommand_Executed()
        {
            this.IsReferenceTreeExpanded = !this.IsReferenceTreeExpanded;
        }

        /// <summary>
        /// CollapseExpandInheritingCommand executed.
        /// </summary>
        private void CollapseExpandInheritingCommand_Executed()
        {
            this.IsInheritanceTreeExpanded = !this.IsInheritanceTreeExpanded;
        }

        /// <summary>
        /// CollapseExpandClassShapeMappingCommand executed.
        /// </summary>
        private void CollapseExpandClassShapeMappingCommand_Executed()
        {
            this.IsShapeMappingTreeExpanded = !this.IsShapeMappingTreeExpanded;
        }
        #endregion

        /// <summary>
        /// Finds a view model that is representing the given model element.
        /// </summary>
        /// <param name="element">Model element.</param>
        /// <returns>View model if found; Null otherwise.</returns>
        public BaseModelElementViewModel FindViewModel(ModelElement element)
        {
            foreach (EmbeddingRSNodeViewModel vm in EmbeddingRSNodes)
            {
                if (vm.Element == element)
                    return vm;
                
                BaseModelElementViewModel retVm = vm.FindViewModel(element);
                if (retVm != null)
                    return retVm;
            }

            foreach (InheritanceNodeViewModel vm in InheritanceNodes)
            {
                if (vm.Element == element && vm.IsElementHolder)
                    return vm;

                BaseModelElementViewModel retVm = vm.FindViewModel(element);
                if (retVm != null)
                    return retVm;
            }

            foreach (ReferenceRSNodeViewModel vm in ReferenceRSNodes)
            {
                if (vm.Element == element)
                    return vm;

                BaseModelElementViewModel retVm = vm.FindViewModel(element);
                if (retVm != null)
                    return retVm;
            }

            foreach (ShapeClassNodeViewModel vm in ShapeClassNodes)
            {
                if (vm.Element == element)
                    return vm;
            }

            return null;
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        protected override void OnDispose()
        {
            if( this.TreeNode != null )
                Unsubscribe();

            base.OnDispose();
        }
    }
}

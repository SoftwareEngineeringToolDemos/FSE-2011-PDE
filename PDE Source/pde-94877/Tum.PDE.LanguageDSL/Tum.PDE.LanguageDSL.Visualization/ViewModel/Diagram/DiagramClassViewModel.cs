using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    /// <summary>
    /// This view model hosts a diagram class element.
    /// </summary>
    public class DiagramClassViewModel : BaseModelElementViewModel
    {
        private DiagramClassView diagramClassView;
        private DiagramViewModel parent;

        private ObservableCollection<RootDiagramNodeViewModel> rootNodeVMs;
        private ReadOnlyObservableCollection<RootDiagramNodeViewModel> rootNodeVMsRO;

        private ObservableCollection<IncludedDiagramClassViewModel> includedDCVMs;
        private ReadOnlyObservableCollection<IncludedDiagramClassViewModel> includedDCVMsRO;

        private ObservableCollection<ImportedDiagramClassViewModel> importedDCCVMs;
        private ReadOnlyObservableCollection<ImportedDiagramClassViewModel> importedDCCVMsRO;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagramClass">Element to be hosted by this view model.</param>
        public DiagramClassViewModel(ViewModelStore viewModelStore, DiagramClassView diagramClassView, DiagramViewModel parent)
            : base(viewModelStore, diagramClassView.DiagramClass)
        {
            this.diagramClassView = diagramClassView;
            this.parent = parent;

            this.rootNodeVMs = new ObservableCollection<RootDiagramNodeViewModel>();
            this.rootNodeVMsRO = new ReadOnlyObservableCollection<RootDiagramNodeViewModel>(this.rootNodeVMs);

            this.includedDCVMs = new ObservableCollection<IncludedDiagramClassViewModel>();
            this.includedDCVMsRO = new ReadOnlyObservableCollection<IncludedDiagramClassViewModel>(includedDCVMs);

            this.importedDCCVMs = new ObservableCollection<ImportedDiagramClassViewModel>();
            this.importedDCCVMsRO = new ReadOnlyObservableCollection<ImportedDiagramClassViewModel>(importedDCCVMs);

            if (this.DiagramClassView != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.DiagramClassView.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
                
                if (this.DiagramClassView.DiagramClass != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.DiagramClassView.DiagramClass.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramClassViewHasRootDiagramNodes.DomainClassId),
                    true, this.DiagramClassView.Id, new Action<ElementAddedEventArgs>(OnRootDiagramNodeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramClassViewHasRootDiagramNodes.DomainClassId),
                    true, this.DiagramClassView.Id, new Action<ElementDeletedEventArgs>(OnRootDiagramNodeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramClassViewHasRootDiagramNodes.DomainClassId),
                    this.DiagramClassView.Id, new Action<RolePlayerOrderChangedEventArgs>(OnRootDiagramNodeMoved));

                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(DiagramClassViewHasRootDiagramNodes.DiagramClassViewDomainRoleId),
                    new Action<RolePlayerChangedEventArgs>(OnRootDiagramNodeChanged));
            }

            if (this.GetHostedElement() is DesignerDiagramClass)
            {
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DesignerDiagramClassReferencesIncludedDiagramClasses.DomainClassId),
                    true, this.GetHostedElement().Id, new Action<ElementAddedEventArgs>(OnIncludedDDCAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DesignerDiagramClassReferencesIncludedDiagramClasses.DomainClassId),
                    true, this.GetHostedElement().Id, new Action<ElementDeletedEventArgs>(OnIncludedDDCRemoved));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DesignerDiagramClassReferencesImportedDiagramClasses.DomainClassId),
                    true, this.GetHostedElement().Id, new Action<ElementAddedEventArgs>(OnImportedDCAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DesignerDiagramClassReferencesImportedDiagramClasses.DomainClassId),
                    true, this.GetHostedElement().Id, new Action<ElementDeletedEventArgs>(OnImportedDCRemoved));
            }
        }

        /// <summary>
        /// Gets the diagram class.
        /// </summary>
        public DiagramClassView DiagramClassView
        {
            get
            {
                return this.diagramClassView;
            }
        }

        /// <summary>
        /// Gets the parent element.
        /// </summary>
        public DiagramViewModel Parent
        {
            get
            {
                return this.parent;
            }
        }

        public bool IsDesignerDiagramClass
        {
            get
            {
                if (this.GetHostedElement() is DesignerDiagramClass)
                    return true;

                return false;
            }
        }

        public bool HasIncludedDCItems
        {
            get
            {
                if (this.includedDCVMs.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        public bool HasImportedDCCItems
        {
            get
            {
                if (this.importedDCCVMs.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Gets a read-only collection of embedding nodes.
        /// </summary>
        public ReadOnlyObservableCollection<RootDiagramNodeViewModel> RootNodes
        {
            get
            {
                return this.rootNodeVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of impored diagram class vms.
        /// </summary>
        public ReadOnlyObservableCollection<ImportedDiagramClassViewModel> ImportedDCs
        {
            get
            {
                return this.importedDCCVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of impored designer diagram class vms.
        /// </summary>
        public ReadOnlyObservableCollection<IncludedDiagramClassViewModel> IncludedDCCs
        {
            get
            {
                return this.includedDCVMsRO;
            }
        }
        
        /// <summary>
        /// Gets or sets whether this diagram class view is expanded or not.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.DiagramClassView.IsExpanded;

            }
            set
            {
                if (this.DiagramClassView.IsExpanded != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsExpanded"))
                    {
                        this.DiagramClassView.IsExpanded = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsExpanded");
                }
            }
        }

        #region Model Methods
        /// <summary>
        /// Adds a new root view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddRootDiagramNode(RootDiagramNode node)
        {
            // verify that node hasnt been added yet
            foreach (RootDiagramNodeViewModel viewModel in this.rootNodeVMs)
                if (viewModel.RootDiagramNode.Id == node.Id)
                    return;

            RootDiagramNodeViewModel vm = new RootDiagramNodeViewModel(this.ViewModelStore, node, this);
            this.rootNodeVMs.Add(vm);

            foreach (RootDiagramNodeViewModel viewModel in this.rootNodeVMs)
                viewModel.UpdateNodePosition();
        }

        /// <summary>
        /// Deletes the view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteRootDiagramNode(RootDiagramNode node)
        {
            for (int i = this.rootNodeVMs.Count - 1; i >= 0; i--)
                if (this.rootNodeVMs[i].RootDiagramNode.Id == node.Id)
                {
                    this.rootNodeVMs[i].Dispose();
                    this.rootNodeVMs.RemoveAt(i);
                }

            foreach (RootDiagramNodeViewModel viewModel in this.rootNodeVMs)
                viewModel.UpdateNodePosition();
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramClassViewHasRootDiagramNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnRootDiagramNodeAdded(ElementAddedEventArgs args)
        {
            DiagramClassViewHasRootDiagramNodes con = args.ModelElement as DiagramClassViewHasRootDiagramNodes;
            if (con != null)
            {
                AddRootDiagramNode(con.RootDiagramNode);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramClassViewHasRootDiagramNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnRootDiagramNodeRemoved(ElementDeletedEventArgs args)
        {
            DiagramClassViewHasRootDiagramNodes con = args.ModelElement as DiagramClassViewHasRootDiagramNodes;
            if (con != null)
            {
                DeleteRootDiagramNode(con.RootDiagramNode);
            }

        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnRootDiagramNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.DiagramClassView)
                this.rootNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);

            foreach (RootDiagramNodeViewModel vm in this.rootNodeVMs)
                vm.UpdateNodePosition();
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnRootDiagramNodeChanged(RolePlayerChangedEventArgs args)
        {
            DiagramClassViewHasRootDiagramNodes con = args.ElementLink as DiagramClassViewHasRootDiagramNodes;
            if (con != null)
            {
                if (args.DomainRole.Id == DiagramClassViewHasRootDiagramNodes.DiagramClassViewDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.DiagramClassView.Id)
                    {
                        DeleteRootDiagramNode(con.RootDiagramNode);
                    }

                    if (args.NewRolePlayerId == this.DiagramClassView.Id)
                    {
                        AddRootDiagramNode(con.RootDiagramNode);
                    }
                }
            }
        }        

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnElementPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == DiagramClassView.IsExpandedDomainPropertyId)
                OnPropertyChanged("IsExpanded");
            else if (args.DomainProperty.Id == DiagramClass.NameDomainPropertyId)
                OnPropertyChanged("DiagramName");
            else if (args.DomainProperty.Id == DiagramClass.TitleDomainPropertyId)
                OnPropertyChanged("DiagramTitle");
        }

        /// <summary>
        /// Adds a new root view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddIncludedDDC(DiagramClass node)
        {
            if (node == null)
                return;

            // verify that node hasnt been added yet
            foreach (BaseModelElementViewModel viewModel in this.includedDCVMs)
                if (viewModel.Element.Id == node.Id)
                    return;

            IncludedDiagramClassViewModel vm = new IncludedDiagramClassViewModel(this.ViewModelStore, node, this.GetHostedElement() as DesignerDiagramClass);
            this.includedDCVMs.Add(vm);

            OnPropertyChanged("HasIncludedDCItems");
        }

        /// <summary>
        /// Deletes the view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteIncludedDDC(DesignerDiagramClassReferencesIncludedDiagramClasses node)
        {
            for (int i = this.includedDCVMs.Count - 1; i >= 0; i--)
                if (this.includedDCVMs[i].LinkId == node.Id)
                {
                    this.includedDCVMs[i].Dispose();
                    this.includedDCVMs.RemoveAt(i);
                    break;
                }

            OnPropertyChanged("HasIncludedDCItems");
        }

        /// <summary>
        /// Called whenever a relationship of type DesignerDiagramClassReferencesTargetDesignerDiagramClasses is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnIncludedDDCAdded(ElementAddedEventArgs args)
        {
            DesignerDiagramClassReferencesIncludedDiagramClasses con = args.ModelElement as DesignerDiagramClassReferencesIncludedDiagramClasses;
            if (con != null)
            {
                AddIncludedDDC(con.DiagramClass);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DesignerDiagramClassReferencesIncludedDiagramClasses is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnIncludedDDCRemoved(ElementDeletedEventArgs args)
        {
            DesignerDiagramClassReferencesIncludedDiagramClasses con = args.ModelElement as DesignerDiagramClassReferencesIncludedDiagramClasses;
            if (con != null)
            {
                DeleteIncludedDDC(con);
            }

        }

        /// <summary>
        /// Adds a new root view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddImportedDC(DiagramClass node)
        {
            if (node == null)
                return;

            // verify that node hasnt been added yet
            foreach (BaseModelElementViewModel viewModel in this.importedDCCVMs)
                if (viewModel.Element.Id == node.Id)
                    return;

            ImportedDiagramClassViewModel vm = new ImportedDiagramClassViewModel(this.ViewModelStore, node, this.GetHostedElement() as DesignerDiagramClass);
            this.importedDCCVMs.Add(vm);

            OnPropertyChanged("HasImportedDCCItems");
        }

        /// <summary>
        /// Deletes the view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteImportedDC(DesignerDiagramClassReferencesImportedDiagramClasses node)
        {
            for (int i = this.importedDCCVMs.Count - 1; i >= 0; i--)
                if (this.importedDCCVMs[i].LinkId == node.Id)
                {
                    this.importedDCCVMs[i].Dispose();
                    this.importedDCCVMs.RemoveAt(i);
                    break;
                }

            OnPropertyChanged("HasImportedDCCItems");
        }

        /// <summary>
        /// Called whenever a relationship of type DesignerDiagramClassReferencesDiagramClasses is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnImportedDCAdded(ElementAddedEventArgs args)
        {
            DesignerDiagramClassReferencesImportedDiagramClasses con = args.ModelElement as DesignerDiagramClassReferencesImportedDiagramClasses;
            if (con != null)
            {
                AddImportedDC(con.DiagramClass);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DesignerDiagramClassReferencesDiagramClasses is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnImportedDCRemoved(ElementDeletedEventArgs args)
        {
            DesignerDiagramClassReferencesImportedDiagramClasses con = args.ModelElement as DesignerDiagramClassReferencesImportedDiagramClasses;
            if (con != null)
            {
                DeleteImportedDC(con);
            }

        }
        #endregion

        /// <summary>
        /// Gets the diagram name.
        /// </summary>
        public string DiagramName
        {
            get
            {
                return this.DiagramClassView.DiagramClass.Name;
            }
        }

        /// <summary>
        /// Gets the diagram title.
        /// </summary>
        public string DiagramTitle
        {
            get
            {
                return this.DiagramClassView.DiagramClass.Title;
            }
        }

        /// <summary>
        /// Moves embedding diagram nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveRootDiagramNodes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move root diagram nodes"))
            {
                this.DiagramClassView.RootDiagramNodes.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.DiagramClassView != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.DiagramClassView.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));

                if( this.DiagramClassView.DiagramClass != null )
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.DiagramClassView.DiagramClass.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramClassViewHasRootDiagramNodes.DomainClassId),
                    true, this.DiagramClassView.Id, new Action<ElementAddedEventArgs>(OnRootDiagramNodeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramClassViewHasRootDiagramNodes.DomainClassId),
                    true, this.DiagramClassView.Id, new Action<ElementDeletedEventArgs>(OnRootDiagramNodeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramClassViewHasRootDiagramNodes.DomainClassId),
                    this.DiagramClassView.Id, new Action<RolePlayerOrderChangedEventArgs>(OnRootDiagramNodeMoved));

                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(DiagramClassViewHasRootDiagramNodes.DiagramClassViewDomainRoleId),
                    new Action<RolePlayerChangedEventArgs>(OnRootDiagramNodeChanged));
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
            foreach (RootDiagramNodeViewModel vm in RootNodes)
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

using System;
using System.Linq;

using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu;
using System.Collections.Generic;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Services;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// View model to display the graphical model tree.
    /// </summary>
    public class ModelTreeViewModel : BaseDockingViewModel
    {
        #region Fields
        private ObservableCollection<RootNodeViewModel> rootNodeVMs;
        private ReadOnlyObservableCollection<RootNodeViewModel> rootNodeVMsRO;

        private Collection<object> selectedVMS;
        private Collection<MenuItemViewModel> contextMenuOperations;

        private DomainModelTreeView modelTreeView;

        private DelegateCommand addNewDomainPropertyCommand;
        private DelegateCommand addNewDomainClassCommand;
        private DelegateCommand addNewEmbeddingRSCommand;
        private DelegateCommand addNewEmbeddingRSToExistantCommand;
        private DelegateCommand addNewReferenceRSCommand;
        private DelegateCommand addNewReferenceRSToRSCommand;
        private DelegateCommand addNewInheritanceRSCommand;
        private DelegateCommand addNewDerivedElementCommand;

        private DelegateCommand deleteCommand;


        private DelegateCommand showTemplateHelperCommand;
        /*
        private DelegateCommand copyCommand;
        private DelegateCommand pasteCommand;
        */

        private DelegateCommand bringTreeHereCommand;
        private DelegateCommand splitTreeCommand;
        private DelegateCommand moveUpCommand;
        private DelegateCommand moveDownCommand;

        private DelegateCommand viewPropertiesCommand;

        private DelegateCommand addMappingToNewRelShapeClassCommand;
        private DelegateCommand addMappingToExtRelShapeClassCommand;
        private DelegateCommand addMappingToNewShapeClassCommand;
        private DelegateCommand addMappingToExtShapeClassCommand;
        private DelegateCommand addMappingToNewMappingShapeClassCommand;
        private DelegateCommand addMappingToExtMappingShapeClassCommand;

        private bool isLocked = false;
        private ModelContextViewModel modelContextVM;
        #endregion

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelTreeView">Domain model tree view.</param>
        public ModelTreeViewModel(ViewModelStore viewModelStore, ModelContextViewModel modelContextVM, DomainModelTreeView modelTreeView)
            : base(viewModelStore)
        {
            this.rootNodeVMs = new ObservableCollection<RootNodeViewModel>();
            this.rootNodeVMsRO = new ReadOnlyObservableCollection<RootNodeViewModel>(rootNodeVMs);

            this.modelContextVM = modelContextVM;
            this.modelTreeView = modelTreeView;
            this.selectedVMS = new Collection<object>();
            this.contextMenuOperations = new Collection<MenuItemViewModel>();

            addNewDomainPropertyCommand = new DelegateCommand(AddNewDomainPropertyCommand_Executed);
            addNewDomainClassCommand = new DelegateCommand(AddNewDomainClassCommand_Executed);
            addNewEmbeddingRSCommand = new DelegateCommand(AddNewEmbeddingRSCommand_Executed);
            addNewEmbeddingRSToExistantCommand = new DelegateCommand(AddNewEmbeddingRSToExistantCommand_Executed);
            addNewReferenceRSCommand = new DelegateCommand(AddNewReferenceRSCommand_Executed);
            addNewReferenceRSToRSCommand = new DelegateCommand(AddNewReferenceRSToRSCommand_Executed);
            addNewInheritanceRSCommand = new DelegateCommand(AddNewInheritanceRSCommand_Executed);
            addNewDerivedElementCommand = new DelegateCommand(AddNewDerivedElementCommand_Executed);

            deleteCommand = new DelegateCommand(DeleteCommand_Executed, DeleteCommand_CanExecute);

            showTemplateHelperCommand = new DelegateCommand(ShowTemplateHelperCommand_Executed);
            /*
            copyCommand = new DelegateCommand(CopyCommand_Executed, CopyCommand_CanExecute);
            pasteCommand = new DelegateCommand(PasteCommand_Executed, PasteCommand_CanExecute);
            */

            bringTreeHereCommand = new DelegateCommand(BringTreeHereCommand_Executed);
            splitTreeCommand = new DelegateCommand(SplitTreeCommand_Executed);
            moveUpCommand = new DelegateCommand(MoveUpCommand_Executed);
            moveDownCommand = new DelegateCommand(MoveDownCommand_Executed);

            viewPropertiesCommand = new DelegateCommand(ViewPropertiesCommand_Executed);

            addMappingToNewRelShapeClassCommand = new DelegateCommand(AddMappingToNewRelShapeClassCommand_Executed);
            addMappingToExtRelShapeClassCommand = new DelegateCommand(AddMappingToExtRelShapeClassCommand_Executed);
            addMappingToNewShapeClassCommand = new DelegateCommand(AddMappingToNewShapeClassCommand_Executed);
            addMappingToExtShapeClassCommand = new DelegateCommand(AddMappingToExtShapeClassCommand_Executed);
            addMappingToNewMappingShapeClassCommand = new DelegateCommand(AddMappingToNewMappingShapeClassCommand_Executed);
            addMappingToExtMappingShapeClassCommand = new DelegateCommand(AddMappingToExtMappingShapeClassCommand_Executed);

            UpdateOperations();

            foreach (RootNode n in modelTreeView.RootNodes)
                this.AddRootNode(n);

            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(OnSelectionChanged));
            Subscribe();
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name.
        /// </summary>
        public override string DockingPaneName { get { return "ModelTreeViewModel"; } }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public override string DockingPaneTitle { get { return "Domain Model Implementation and Shape Assignment"; } }
        #endregion
        public bool IsLocked
        {
            get
            {
                return this.isLocked;
            }
            set
            {
                this.isLocked = value;
                OnPropertyChanged("IsLocked");

                UpdateOperations();
            }
        }

        /// <summary>
        /// Selected data collection.
        /// </summary>
        public Collection<object> SelectedItems
        {
            get { return this.selectedVMS; }
            set
            {
                OnPropertyChanged("SelectedItems");

                // propagate selection
                SelectedItemsCollection col = new SelectedItemsCollection();
                if (value != null)
                    foreach (BaseModelElementViewModel vm in value)
                    {
                        if (vm.GetHostedElement() == null)
                            continue;

                        col.Add(vm.GetHostedElement());
                    }

                // see if we need to propagate selection --> based on what is currently selected
                bool bDiffers = false;
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    if (col.Contains(vm.GetHostedElement()))
                        continue;

                    bDiffers = true;
                    break;
                }
                if (this.SelectedItems.Count != col.Count || col.Count == 0)
                    bDiffers = true;

                this.selectedVMS = value;

                if (col.Count == 0)
                    col.Add(this.modelTreeView.ViewContext.ModelContext);

                // notify observers, that selection has changed
                if (bDiffers)
                    EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));

                // update operations
                UpdateOperations();
            }
        }

        /// <summary>
        /// Operations
        /// </summary>
        public Collection<MenuItemViewModel> Operations
        {
            get { return this.contextMenuOperations; }
            protected set
            {
                this.contextMenuOperations = value;
            }

        }
        
        /// <summary>
        /// Gets a read-only collection of root nodes.
        /// </summary>
        public ReadOnlyObservableCollection<RootNodeViewModel> RootNodes
        {
            get
            {
                return this.rootNodeVMsRO;
            }
        }

        /// <summary>
        /// Moves root nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveRootNodes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move root nodes"))
            {
                this.modelTreeView.RootNodes.Move(from, to);

                transaction.Commit();
            }
        }

        #region Model Subscription/Unsubscription + Methods
        /// <summary>
        /// Adds a new RootNode view model for the given RootNode.
        /// </summary>
        /// <param name="element">RootNode.</param>
        public void AddRootNode(RootNode element)
        {
            foreach (RootNodeViewModel viewModel in this.rootNodeVMs)
                if (viewModel.RootNode.Id == element.Id)
                    return;

            RootNodeViewModel vm = new RootNodeViewModel(this.ViewModelStore, element, this);
            this.rootNodeVMs.Add(vm);

            foreach (RootNodeViewModel vmS in this.rootNodeVMs)
                vmS.UpdateNodePosition();
        }

        /// <summary>
        /// Deletes a new RootNode view model for the given RootNode.
        /// </summary>
        /// <param name="element">ModelContext.</param>
        public void DeleteRootNode(RootNode element)
        {
            for (int i = this.rootNodeVMs.Count - 1; i >= 0; i--)
                if (this.rootNodeVMs[i].RootNode.Id == element.Id)
                {
                    this.rootNodeVMs[i].Dispose();
                    this.rootNodeVMs.RemoveAt(i);
                }

            foreach (RootNodeViewModel vm in this.rootNodeVMs)
                vm.UpdateNodePosition();
        }


        /// <summary>
        /// Called whenever a relationship of type DomainModelTreeViewReferencesRootNodes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnChildRootNodeAdded(ElementAddedEventArgs args)
        {
            DomainModelTreeViewReferencesRootNodes con = args.ModelElement as DomainModelTreeViewReferencesRootNodes;
            if (con != null)
            {
                AddRootNode(con.RootNode);               
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DomainModelTreeViewReferencesRootNodes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnChildRootNodeRemoved(ElementDeletedEventArgs args)
        {
            DomainModelTreeViewReferencesRootNodes con = args.ModelElement as DomainModelTreeViewReferencesRootNodes;
            if (con != null)
            {
                DeleteRootNode(con.RootNode);
            }

            
        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnChildRootNodeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if( args.SourceElement == this.modelTreeView )
                this.rootNodeVMs.Move(args.OldOrdinal, args.NewOrdinal);
        }

        /// <summary>
        /// Subscribes to events.
        /// </summary>
        public void Subscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainModelTreeViewReferencesRootNodes.DomainClassId),
                true, this.modelTreeView.Id, new Action<ElementAddedEventArgs>(OnChildRootNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainModelTreeViewReferencesRootNodes.DomainClassId),
                true, this.modelTreeView.Id, new Action<ElementDeletedEventArgs>(OnChildRootNodeRemoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainModelTreeViewReferencesRootNodes.DomainClassId), this.modelTreeView.Id,
                new Action<RolePlayerOrderChangedEventArgs>(OnChildRootNodeMoved));
        }

        /// <summary>
        /// Unsubscribes from events.
        /// </summary>
        public void Unsubscribe()
        {
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainModelTreeViewReferencesRootNodes.DomainClassId),
                   true, this.modelTreeView.Id, new Action<ElementAddedEventArgs>(OnChildRootNodeAdded));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainModelTreeViewReferencesRootNodes.DomainClassId),
                true, this.modelTreeView.Id, new Action<ElementDeletedEventArgs>(OnChildRootNodeRemoved));

            this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainModelTreeViewReferencesRootNodes.DomainClassId), this.modelTreeView.Id,
                new Action<RolePlayerOrderChangedEventArgs>(OnChildRootNodeMoved));
        }

        #endregion

        #region Commands + Methods
        /// <summary>
        /// ShowTemplateHelperCommand.
        /// </summary>
        public DelegateCommand ShowTemplateHelperCommand
        {
            get { return this.showTemplateHelperCommand; }
        }

        private void ShowTemplateHelperCommand_Executed()
        {
            if (this.SelectedItems.Count == 1)
                if (this.SelectedItems[0] is BaseModelElementViewModel)
                {
                    DateTemplateSelectorViewModel vm = new DateTemplateSelectorViewModel(this.ViewModelStore);
                    foreach (DataTemplateViewModel templateVm in ModelTreeDataTemplates.GetTemplates(this.SelectedItems[0] as BaseModelElementViewModel))
                        vm.TemplateVMs.Add(templateVm);

                    this.GlobalServiceProvider.Resolve<IUIVisualizerService>().Show("DataTemplatePresetsPopup", vm, true, null);
                }
        }

        /// <summary>
        /// Add new domain property command.
        /// </summary>
        public DelegateCommand AddNewDomainPropertyCommand
        {
            get { return this.addNewDomainPropertyCommand; }
        }

        /// <summary>
        /// Add new domain class command.
        /// </summary>
        public DelegateCommand AddNewDomainClassCommand
        {
            get { return this.addNewDomainClassCommand; }
        }

        /// <summary>
        /// Add new embedding relationship command.
        /// </summary>
        public DelegateCommand AddNewEmbeddingRSCommand
        {
            get { return this.addNewEmbeddingRSCommand; }
        }

        /// <summary>
        /// Add new embedding relationship command.
        /// </summary>
        public DelegateCommand AddNewEmbeddingRSToExistantCommand
        {
            get { return this.addNewEmbeddingRSToExistantCommand; }
        }

        /// <summary>
        /// Add new reference relationship command.
        /// </summary>
        public DelegateCommand AddNewReferenceRSCommand
        {
            get { return this.addNewReferenceRSCommand; }
        }

        /// <summary>
        /// Add new reference relationship command.
        /// </summary>
        public DelegateCommand AddNewReferenceRSToRSCommand
        {
            get { return this.addNewReferenceRSToRSCommand; }
        }

        /// <summary>
        /// Add new inheritance relationship command.
        /// </summary>
        public DelegateCommand AddNewInheritanceRSCommand
        {
            get { return this.addNewInheritanceRSCommand; }
        }

        /// <summary>
        /// Add new inheritance relationship command.
        /// </summary>
        public DelegateCommand AddNewDerivedElementCommand
        {
            get { return this.addNewDerivedElementCommand; }
        }

        /// <summary>
        /// Delete command.
        /// </summary>
        public DelegateCommand DeleteCommand
        {
            get { return this.deleteCommand; }
        }

        /*
        /// <summary>
        /// Copy command.
        /// </summary>
        public DelegateCommand CopyCommand
        {
            get { return this.copyCommand; }
        }

        /// <summary>
        /// Paste command.
        /// </summary>
        public DelegateCommand PasteCommand
        {
            get { return this.pasteCommand; }
        }*/

        /// <summary>
        /// Bring tree here command.
        /// </summary>
        public DelegateCommand BringTreeHereCommand
        {
            get { return this.bringTreeHereCommand; }
        }

        /// <summary>
        /// Split tree command.
        /// </summary>
        public DelegateCommand SplitTreeCommand
        {
            get { return this.splitTreeCommand; }
        }

        /// <summary>
        /// Move up command.
        /// </summary>
        public DelegateCommand MoveUpCommand
        {
            get { return this.moveUpCommand; }
        }

        /// <summary>
        /// Move down command.
        /// </summary>
        public DelegateCommand MoveDownCommand
        {
            get { return this.moveDownCommand; }
        }

        /// <summary>
        /// View properties command.
        /// </summary>
        public DelegateCommand ViewPropertiesCommand
        {
            get { return this.viewPropertiesCommand; }
        }

        /// <summary>
        /// AddMappingToNewRelShapeClass command.
        /// </summary>
        public DelegateCommand AddMappingToNewRelShapeClassCommand
        {
            get { return this.addMappingToNewRelShapeClassCommand; }
        }

        /// <summary>
        /// AddMappingToExtRelShapeClass command.
        /// </summary>
        public DelegateCommand AddMappingToExtRelShapeClassCommand
        {
            get { return this.addMappingToExtRelShapeClassCommand; }
        }

        /// <summary>
        /// AddMappingToNewShapeClass command.
        /// </summary>
        public DelegateCommand AddMappingToNewShapeClassCommand
        {
            get { return this.addMappingToNewShapeClassCommand; }
        }

        /// <summary>
        /// AddMappingToExtShapeClass command.
        /// </summary>
        public DelegateCommand AddMappingToExtShapeClassCommand
        {
            get { return this.addMappingToExtShapeClassCommand; }
        }

        /// <summary>
        /// AddMappingToNewMappingShapeClass command.
        /// </summary>
        public DelegateCommand AddMappingToNewMappingShapeClassCommand
        {
            get { return this.addMappingToNewMappingShapeClassCommand; }
        }

        /// <summary>
        /// AddMappingToExtMappingShapeClass command.
        /// </summary>
        public DelegateCommand AddMappingToExtMappingShapeClassCommand
        {
            get { return this.addMappingToExtMappingShapeClassCommand; }
        }

        /// <summary>
        /// Add new domain property command executed.
        /// </summary>
        private void AddNewDomainPropertyCommand_Executed()
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add new property"))
            {
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                {
                    if( vm is BaseAttributeElementViewModel )
                         (vm as BaseAttributeElementViewModel).Element.Properties.AddNew();
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Add new domain class command executed.
        /// </summary>
        private void AddNewDomainClassCommand_Executed()
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Create new domain class + Root node"))
            {
                // create new domain class
                DomainClass domainClass = this.Store.ElementFactory.CreateElement(DomainClass.DomainClassId) as DomainClass;
                Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(this.Store as IServiceProvider, this.Store.DefaultPartition);
                Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(this.Store.DefaultPartition);
                elementGroup.Add(domainClass);
                elementGroup.MarkAsRoot(domainClass);
                elementOperations.MergeElementGroup(this.modelTreeView.ViewContext.ModelContext, elementGroup);
                domainClass.Name = NameHelper.GetUniqueName(Store, DomainClass.DomainClassId);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Add new embedding relationship executed.
        /// </summary>
        private void AddNewEmbeddingRSCommand_Executed()
        {
            List<DomainClass> domainClasses = new List<DomainClass>();
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
                if (vm.Element is DomainClass)
                    domainClasses.Add(vm.Element as DomainClass);

            ModelTreeOperations.AddNewEmbeddingRelationship(domainClasses);
        }

        /// <summary>
        /// Add new embedding relationship executed.
        /// </summary>
        private void AddNewEmbeddingRSToExistantCommand_Executed()
        {
           CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DomainClass);
           bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
           if (result == true)
           {
               if (vm.SelectedViewModel != null)
               {
                   List<DomainClass> domainClasses = new List<DomainClass>();
                   foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                       if (selectedVM.Element is DomainClass)
                           domainClasses.Add(selectedVM.Element as DomainClass);

                   ModelTreeOperations.AddNewEmbeddingRelationship(domainClasses, vm.SelectedViewModel.Element as DomainClass);
               }
           }

           vm.Dispose();
           GC.Collect();
        }

        /// <summary>
        /// Add new reference relationship command executed.
        /// </summary>
        private void AddNewReferenceRSCommand_Executed()
        {
            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DomainClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    List<DomainClass> domainClasses = new List<DomainClass>();
                    foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                        if (selectedVM.Element is DomainClass)
                            domainClasses.Add(selectedVM.Element as DomainClass);

                    ModelTreeOperations.AddNewReferenceRelationship(domainClasses, vm.SelectedViewModel.Element as DomainClass);
                }
            }

            vm.Dispose();
            GC.Collect();
            /*
            // sort domain classes
            List<DomainClass> sortedClasses = this.modelTreeView.ViewContext.ModelContext.Classes.ToList();
            sortedClasses.Sort(CompareDomainClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (DomainClass d in sortedClasses)
                vms.Add(new SelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    List<DomainClass> domainClasses = new List<DomainClass>();
                    foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                        if (selectedVM.Element is DomainClass)
                            domainClasses.Add(selectedVM.Element as DomainClass);

                    ModelTreeOperations.AddNewReferenceRelationship(domainClasses, vm.SelectedViewModel.Element as DomainClass);
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// Add new reference relationship command executed.
        /// </summary>
        private void AddNewReferenceRSToRSCommand_Executed()
        {
            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.ReferenceRelationship);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    List<DomainClass> domainClasses = new List<DomainClass>();
                    foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                        if (selectedVM.Element is DomainClass)
                            domainClasses.Add(selectedVM.Element as DomainClass);

                    ModelTreeOperations.AddNewReferenceRelationship(domainClasses, vm.SelectedViewModel.Element as DomainRelationship);
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            // sort domain rs classes
            List<DomainRelationship> sortedRSClasses = this.modelTreeView.ViewContext.ModelContext.Relationships.ToList();
            sortedRSClasses.Sort(CompareDomainRelationshipsByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (DomainRelationship d in sortedRSClasses)
                if( d is ReferenceRelationship )
                    vms.Add(new SelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    List<DomainClass> domainClasses = new List<DomainClass>();
                    foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                        if (selectedVM.Element is DomainClass)
                            domainClasses.Add(selectedVM.Element as DomainClass);

                    ModelTreeOperations.AddNewReferenceRelationship(domainClasses, vm.SelectedViewModel.Element as DomainRelationship);
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// Add new inheritance relationship command executed.
        /// </summary>
        private void AddNewInheritanceRSCommand_Executed()
        {
            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DomainClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    List<DomainClass> domainClasses = new List<DomainClass>();
                    foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                        if (selectedVM.Element is DomainClass)
                        {
                            domainClasses.Add(selectedVM.Element as DomainClass);

                            if (selectedVM.Element == vm.SelectedViewModel.Element)
                                return;
                        }

                    ModelTreeOperations.AddNewInheritanceRelationship(domainClasses, vm.SelectedViewModel.Element as DomainClass);
                }
            }

            vm.Dispose();
            GC.Collect();

            this.UpdateOperations();

            /*
            // sort domain classes
            List<DomainClass> sortedClasses = this.modelTreeView.ViewContext.ModelContext.Classes.ToList();
            sortedClasses.Sort(CompareDomainClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (DomainClass d in sortedClasses)
                vms.Add(new SelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    List<DomainClass> domainClasses = new List<DomainClass>();
                    foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                        if (selectedVM.Element is DomainClass)
                            domainClasses.Add(selectedVM.Element as DomainClass);

                    ModelTreeOperations.AddNewInheritanceRelationship(domainClasses, vm.SelectedViewModel.Element as DomainClass);
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// Add new inheritance relationship command executed.
        /// </summary>
        private void AddNewDerivedElementCommand_Executed()
        {
            List<DomainClass> domainClasses = new List<DomainClass>();
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
                if (vm.Element is DomainClass)
                    domainClasses.Add(vm.Element as DomainClass);

            ModelTreeOperations.AddNewInheritanceRelationshipNewDerivedClass(domainClasses);
        }

        /// <summary>
        /// Delete command executed.
        /// </summary>
        private void DeleteCommand_Executed()
        {
            if (this.SelectedItems.Count > 0)
            {
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete"))
                {
                    foreach (BaseModelElementViewModel vm in this.SelectedItems)
                    {
                        vm.DeleteHostedElement();
                    }
                    transaction.Commit();
                }
            }

            UpdateOperations();
        }

        /// <summary>
        /// Delete command can execute.
        /// </summary>
        private bool DeleteCommand_CanExecute()
        {
            if (this.SelectedItems.Count > 0)
            {
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                {
                    if (vm.GetHostedElement() is DomainClass)
                    {
                        if ((vm.GetHostedElement() as DomainClass).IsDomainModel)
                            return false;
                    }

                    if (vm.IsLocked)
                        return false;
                }

                return true;
            }

            return false;
        }

        private static CustomElementOperations elementOperations = null;
        private CustomElementOperations ElementOperations
        {
            get
            {
                if (elementOperations == null)
                    elementOperations = new CustomElementOperations(this.Store as IServiceProvider, this.Store.DefaultPartition);

                return elementOperations;
            }
        }
         
        /*   
        /// <summary>
        /// Copy command executed.
        /// </summary>
        private void CopyCommand_Executed()
        {
            if (this.SelectedItems == null)
                return;

            List<ModelElement> m = new List<ModelElement>();
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
                if (vm.GetHostedElement() != null)
                    m.Add(vm.GetHostedElement());

            if (m.Count == 0)
                m.Add(this.modelTreeView.ViewContext.ModelContext);

            try
            {

                System.Windows.Forms.IDataObject dataObject = new System.Windows.Forms.DataObject();
                this.ElementOperations.Copy(dataObject, m);

                System.Windows.Clipboard.SetDataObject(dataObject, true);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Copy failed: " + ex.Message);
            }
        }

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        private bool CopyCommand_CanExecute()
        {
            if( this.SelectedItems == null )
                return false;
            
            List<ModelElement> m = new List<ModelElement>();
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
                if( vm.GetHostedElement() != null)
                    m.Add(vm.GetHostedElement());

            if (m.Count == 0)
                m.Add(this.modelTreeView.ViewContext.ModelContext);

            return this.ElementOperations.CanCopy(m);
        }

        /// <summary>
        /// Paste command executed.
        /// </summary>
        private void PasteCommand_Executed()
        {
            if (this.SelectedItems == null)
                return;

            ModelElement targetElement;
            if (this.SelectedItems.Count == 0)
                targetElement = this.modelTreeView.ViewContext.ModelContext;
            else if (this.SelectedItems.Count == 1)
                targetElement = (this.SelectedItems[0] as BaseModelElementViewModel).GetHostedElement();
            else
                return;

            try
            {
                using (Transaction t = this.Store.TransactionManager.BeginTransaction("paste"))
                {
                    System.Windows.Forms.IDataObject idataObject = System.Windows.Forms.Clipboard.GetDataObject();
                    this.ElementOperations.Merge(targetElement, idataObject);

                    t.Commit();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Paste failed: " + ex.Message);
            }
        }

        /// <summary>
        /// Paste command can execute.
        /// </summary>
        private bool PasteCommand_CanExecute()
        {
            if (this.SelectedItems == null)
                return false;

            ModelElement targetElement;
            if (this.SelectedItems.Count == 0)
                targetElement = this.modelTreeView.ViewContext.ModelContext;
            else if (this.SelectedItems.Count == 1)
                targetElement = (this.SelectedItems[0] as BaseModelElementViewModel).GetHostedElement();
            else
                return false;

            try
            {
                System.Windows.Forms.IDataObject idataObject = System.Windows.Forms.Clipboard.GetDataObject();
                return this.ElementOperations.CanMerge(targetElement, idataObject);
            }
            catch { }

            return false;
        }*/

        /// <summary>
        /// Bring tree here command executed.
        /// </summary>
        private void BringTreeHereCommand_Executed()
        {
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
            {
                if (vm is TreeNodeViewModel)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Bring tree here."))
                    {
                        ModelTreeOperations.BringTreeHere((vm as TreeNodeViewModel).TreeNode);
                        transaction.Commit();
                    }
                }
                break;
            }

            UpdateOperations();
        }

        /// <summary>
        /// Split tree command executed.
        /// </summary>
        private void SplitTreeCommand_Executed()
        {
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
            {
                if (vm is TreeNodeViewModel)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Bring tree here."))
                    {
                        ModelTreeOperations.SplitTree((vm as TreeNodeViewModel).TreeNode);
                        transaction.Commit();
                    }
                }
                break;
            }

            UpdateOperations();
        }

        /// <summary>
        /// Move up command executed.
        /// </summary>
        private void MoveUpCommand_Executed()
        {
            foreach (TreeNodeViewModel vm in this.SelectedItems)
            {
                vm.MoveUp();
                break;
            }

            UpdateOperations();
        }

        /// <summary>
        /// Move down command executed.
        /// </summary>
        private void MoveDownCommand_Executed()
        {
            foreach (TreeNodeViewModel vm in this.SelectedItems)
            {
                vm.MoveDown();
                break;
            }

            UpdateOperations();
        }

        /// <summary>
        /// View properties command executed.
        /// </summary>
        private void ViewPropertiesCommand_Executed()
        {
            SelectedItemsCollection col = new SelectedItemsCollection();
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
            {
                col.Add(vm.GetHostedElement());
            }

            EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
        }

        /// <summary>
        /// AddMappingToNewRelShapeClass command executed.
        /// </summary>
        private void AddMappingToNewRelShapeClassCommand_Executed()
        {
            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVMWithoutImported(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DiagramClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    DiagramClass diagramClass = vm.SelectedViewModel.Element as DiagramClass;
                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<ReferenceRelationship> domainClasses = new List<ReferenceRelationship>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is ReferenceRelationship)
                                domainClasses.Add(selectedVM.Element as ReferenceRelationship);

                        foreach (ReferenceRelationship domainClass in domainClasses)
                        {
                            RelationshipShapeClass shape = DiagramTreeOperations.CreateRelationshipShapeClass(diagramClass.DiagramClassView.DiagramClass);
                            RootDiagramNode node = new RootDiagramNode(this.Store);
                            node.PresentationElementClass = shape;

                            diagramClass.DiagramClassView.RootDiagramNodes.Add(node);

                            shape.ReferenceRelationship = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            List<DiagramClass> sortedClasses = this.modelTreeView.ViewContext.ModelContext.DiagramClasses.ToList();
            sortedClasses.Sort(CompareDiagramClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (DiagramClass d in sortedClasses)
                vms.Add(new DiagramClassSelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    DiagramClass diagramClass = vm.SelectedViewModel.Element as DiagramClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<ReferenceRelationship> domainClasses = new List<ReferenceRelationship>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is ReferenceRelationship)
                                domainClasses.Add(selectedVM.Element as ReferenceRelationship);

                        foreach (ReferenceRelationship domainClass in domainClasses)
                        {
                            RelationshipShapeClass shape = DiagramTreeOperations.CreateRelationshipShapeClass(diagramClass.DiagramClassView.DiagramClass);
                            RootDiagramNode node = new RootDiagramNode(this.Store);
                            node.PresentationElementClass = shape;

                            diagramClass.DiagramClassView.RootDiagramNodes.Add(node);

                            shape.ReferenceRelationship = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// AddMappingToExtRelShapeClass command executed.
        /// </summary>
        private void AddMappingToExtRelShapeClassCommand_Executed()
        {
            if (this.SelectedItems.Count != 1)
                return;

            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVMWithoutImported(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.RSShapeClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    RelationshipShapeClass shapeClass = vm.SelectedViewModel.Element as RelationshipShapeClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<ReferenceRelationship> domainClasses = new List<ReferenceRelationship>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is ReferenceRelationship)
                                domainClasses.Add(selectedVM.Element as ReferenceRelationship);

                        foreach (ReferenceRelationship domainClass in domainClasses)
                        {
                            shapeClass.ReferenceRelationship = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            List<RelationshipShapeClass> sortedClasses = new List<RelationshipShapeClass>();
            foreach (RelationshipShapeClass s in this.Store.ElementDirectory.FindElements(RelationshipShapeClass.DomainClassId))
                if( s.ReferenceRelationship == null )
                    sortedClasses.Add(s);

            sortedClasses.Sort(CompareRelationshipShapeClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (RelationshipShapeClass d in sortedClasses)
                vms.Add(new RelationshipShapeClassSelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    RelationshipShapeClass shapeClass = vm.SelectedViewModel.Element as RelationshipShapeClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<ReferenceRelationship> domainClasses = new List<ReferenceRelationship>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is ReferenceRelationship)
                                domainClasses.Add(selectedVM.Element as ReferenceRelationship);

                        foreach (ReferenceRelationship domainClass in domainClasses)
                        {
                            shapeClass.ReferenceRelationship = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();*/
        }

        /// <summary>
        /// AddMappingToNewShapeClass command executed.
        /// </summary>
        private void AddMappingToNewShapeClassCommand_Executed()
        {
            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVMWithoutImported(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DiagramClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    DiagramClass diagramClass = vm.SelectedViewModel.Element as DiagramClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            ShapeClass shape = DiagramTreeOperations.CreateShapeClass(diagramClass.DiagramClassView.DiagramClass);
                            RootDiagramNode node = new RootDiagramNode(this.Store);
                            node.PresentationElementClass = shape;

                            diagramClass.DiagramClassView.RootDiagramNodes.Add(node);

                            shape.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            List<DiagramClass> sortedClasses = this.modelTreeView.ViewContext.ModelContext.DiagramClasses.ToList();
            sortedClasses.Sort(CompareDiagramClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (DiagramClass d in sortedClasses)
                vms.Add(new DiagramClassSelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    DiagramClass diagramClass = vm.SelectedViewModel.Element as DiagramClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            ShapeClass shape = DiagramTreeOperations.CreateShapeClass(diagramClass.DiagramClassView.DiagramClass);
                            RootDiagramNode node = new RootDiagramNode(this.Store);
                            node.PresentationElementClass = shape;

                            diagramClass.DiagramClassView.RootDiagramNodes.Add(node);

                            shape.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// AddMappingToExtShapeClass command executed.
        /// </summary>
        private void AddMappingToExtShapeClassCommand_Executed()
        {
            if (this.SelectedItems.Count != 1)
                return;

            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVMWithoutImported(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.ShapeClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    ShapeClass shapeClass = vm.SelectedViewModel.Element as ShapeClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            shapeClass.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            List<ShapeClass> sortedClasses = new List<ShapeClass>();
            foreach (ShapeClass s in this.Store.ElementDirectory.FindElements(ShapeClass.DomainClassId))
                if( s.DomainClass == null )
                    sortedClasses.Add(s);

            sortedClasses.Sort(CompareShapeClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (ShapeClass d in sortedClasses)
                vms.Add(new ShapeClassSelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    ShapeClass shapeClass = vm.SelectedViewModel.Element as ShapeClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            shapeClass.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();*/
        }

        /// <summary>
        /// AddMappingToNewMappingShapeClass command executed.
        /// </summary>
        private void AddMappingToNewMappingShapeClassCommand_Executed()
        {
            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVMWithoutImported(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DiagramClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    DiagramClass diagramClass = vm.SelectedViewModel.Element as DiagramClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new mapping shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            MappingRelationshipShapeClass shape = DiagramTreeOperations.CreateMappingRelationshipShapeClass(diagramClass.DiagramClassView.DiagramClass);
                            RootDiagramNode node = new RootDiagramNode(this.Store);
                            node.PresentationElementClass = shape;

                            diagramClass.DiagramClassView.RootDiagramNodes.Add(node);

                            shape.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            List<DiagramClass> sortedClasses = this.modelTreeView.ViewContext.ModelContext.DiagramClasses.ToList();
            sortedClasses.Sort(CompareDiagramClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (DiagramClass d in sortedClasses)
                vms.Add(new DiagramClassSelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    DiagramClass diagramClass = vm.SelectedViewModel.Element as DiagramClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new mapping shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            MappingRelationshipShapeClass shape = DiagramTreeOperations.CreateMappingRelationshipShapeClass(diagramClass.DiagramClassView.DiagramClass);
                            RootDiagramNode node = new RootDiagramNode(this.Store);
                            node.PresentationElementClass = shape;

                            diagramClass.DiagramClassView.RootDiagramNodes.Add(node);

                            shape.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// AddMappingToExtMappingShapeClass command executed.
        /// </summary>
        private void AddMappingToExtMappingShapeClassCommand_Executed()
        {
            if (this.SelectedItems.Count != 1)
                return;

            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVMWithoutImported(this.modelTreeView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.MappingShapeClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    MappingRelationshipShapeClass shapeClass = vm.SelectedViewModel.Element as MappingRelationshipShapeClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            shapeClass.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();

            /*
            List<MappingRelationshipShapeClass> sortedClasses = new List<MappingRelationshipShapeClass>();
            foreach (MappingRelationshipShapeClass s in this.Store.ElementDirectory.FindElements(MappingRelationshipShapeClass.DomainClassId))
                if (s.DomainClass == null)
                    sortedClasses.Add(s);

            sortedClasses.Sort(CompareMappingRelationshipShapeClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (MappingRelationshipShapeClass d in sortedClasses)
                vms.Add(new MappingRelationshipShapeClassViewModel(this.ViewModelStore, d));

            SelectionViewModel vm = new SelectionViewModel(this.ViewModelStore, vms);

            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel != null)
                {
                    MappingRelationshipShapeClass shapeClass = vm.SelectedViewModel.Element as MappingRelationshipShapeClass;

                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
                    {
                        List<DomainClass> domainClasses = new List<DomainClass>();
                        foreach (BaseModelElementViewModel selectedVM in this.SelectedItems)
                            if (selectedVM.Element is DomainClass)
                                domainClasses.Add(selectedVM.Element as DomainClass);

                        foreach (DomainClass domainClass in domainClasses)
                        {
                            shapeClass.DomainClass = domainClass;
                        }

                        transaction.Commit();
                    }
                }
            }

            vm.Dispose();
            GC.Collect();
            */
        }

        /// <summary>
        /// Compares two shape classes by comparing their names.
        /// </summary>
        /// <param name="x">ShapeClass to be compared.</param>
        /// <param name="y">ShapeClass to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareShapeClassesByName(ShapeClass x, ShapeClass y)
        {
            return x.Name.CompareTo(y.Name);
        }

        /// <summary>
        /// Compares two shape classes by comparing their names.
        /// </summary>
        /// <param name="x">RelationshipShapeClass to be compared.</param>
        /// <param name="y">RelationshipShapeClass to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareRelationshipShapeClassesByName(RelationshipShapeClass x, RelationshipShapeClass y)
        {
            return x.Name.CompareTo(y.Name);
        }

        /// <summary>
        /// Compares two shape classes by comparing their names.
        /// </summary>
        /// <param name="x">MappingRelationshipShapeClass to be compared.</param>
        /// <param name="y">MappingRelationshipShapeClass to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareMappingRelationshipShapeClassesByName(MappingRelationshipShapeClass x, MappingRelationshipShapeClass y)
        {
            return x.Name.CompareTo(y.Name);
        }

        /// <summary>
        /// Compares two diagram classes by comparing their names.
        /// </summary>
        /// <param name="x">DiagramClass to be compared.</param>
        /// <param name="y">DiagramClass to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareDiagramClassesByName(DiagramClass x, DiagramClass y)
        {
            return x.Name.CompareTo(y.Name);
        }

        /// <summary>
        /// Compares two domain classes by comparing their names.
        /// </summary>
        /// <param name="x">DomainClass to be compared.</param>
        /// <param name="y">DomainClass to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareDomainClassesByName(DomainClass x, DomainClass y)
        {
            return x.Name.CompareTo(y.Name);
        }

        /// <summary>
        /// Compares two domain relationship by comparing their names.
        /// </summary>
        /// <param name="x">DomainRelationship to be compared.</param>
        /// <param name="y">DomainRelationship to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareDomainRelationshipsByName(DomainRelationship x, DomainRelationship y)
        {
            return x.Name.CompareTo(y.Name);
        }
        #endregion

        #region Context Menu Operations
        /// <summary>
        /// Updates operation collection.
        /// </summary>
        public virtual void UpdateOperations()
        {
            this.contextMenuOperations = new Collection<MenuItemViewModel>();

            if (this.IsLocked)
            {
                OnPropertyChanged("Operations");
                return;
            }

            MenuItemViewModel mv = new MenuItemViewModel(this.ViewModelStore, "Add new DomainClass", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Add-16.png");
            mv.Command = AddNewDomainClassCommand;
            this.contextMenuOperations.Add(mv);

            if (this.selectedVMS.Count > 0)
            {
                bool bIsDomainModelSelected = false;
                bool bAnyHasBaseClass = false;

                // keep track of selection and set command visibility/accessibility
                // count different types in selection
                List<string> selectedTypes = new List<string>();
                foreach (BaseModelElementViewModel vm in this.selectedVMS)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    if (vm.IsLocked)
                    {
                        this.contextMenuOperations.Clear();

                        if (this.SelectedItems.Count == 1)
                        {
                            BaseModelElementViewModel vmS = this.SelectedItems[0] as BaseModelElementViewModel;
                            if (vmS != null && vmS is TreeNodeViewModel)
                            {
                                TreeNodeViewModel tVm = vmS as TreeNodeViewModel;
                                if (tVm.Parent != null)
                                {
                                    if (!tVm.Parent.IsLocked)
                                    {
                                        #region MoveUp/Down
                                        TreeNodeViewModel nodeVM = this.SelectedItems[0] as TreeNodeViewModel;
                                        if (nodeVM != null)
                                        {
                                            MenuItemViewModel mvMoveUp = new MenuItemViewModel(this.ViewModelStore, "Move up", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Up-16.png");
                                            mvMoveUp.Command = MoveUpCommand;
                                            if (!nodeVM.CanMoveUp())
                                                mvMoveUp.IsEnabled = false;
                                            this.contextMenuOperations.Add(mvMoveUp);

                                            MenuItemViewModel mvMoveDown = new MenuItemViewModel(this.ViewModelStore, "Move down", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Down-16.png");
                                            mvMoveDown.Command = MoveDownCommand;
                                            if (!nodeVM.CanMoveDown())
                                                mvMoveDown.IsEnabled = false;
                                            this.contextMenuOperations.Add(mvMoveDown);
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }

                        OnPropertyChanged("Operations");
                        return;
                    }

                    string typeName = vm.GetHostedElement().GetType().Name;

                    if (!selectedTypes.Contains(typeName))
                        selectedTypes.Add(typeName);

                    if (vm.GetHostedElement() is DomainClass)
                    {
                        if ((vm.GetHostedElement() as DomainClass).IsDomainModel)
                            bIsDomainModelSelected = true;

                        if ((vm.GetHostedElement() as DomainClass).BaseClass != null)
                            bAnyHasBaseClass = true;
                    }
                }

                bool bCanAddProperties = true;
                foreach (string t in selectedTypes)
                    if (t != "DomainClass" && t != "ReferenceRelationship" && t != "EmbeddingRelationship" && t != "DomainProperty")
                    {
                        bCanAddProperties = false;
                        break;
                    }
                if (bCanAddProperties)
                {
                    MenuItemViewModel mvAddProp = new MenuItemViewModel(this.ViewModelStore, "Add new DomainProperty", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Properties-32x32-Add.png");
                    mvAddProp.Command = AddNewDomainPropertyCommand;
                    this.contextMenuOperations.Add(mvAddProp);
                }

                if (selectedTypes.Count == 1)
                {
                    if (selectedTypes[0] == "DomainClass")
                    {
                        this.AddSeparator();

                        #region DomainClass
                        MenuItemViewModel menuItemViewModelAdd = new MenuItemViewModel(this.ViewModelStore, "Add Element/Relationship");
                        this.contextMenuOperations.Add(menuItemViewModelAdd);

                        // add new embedding relationship
                        MenuItemViewModel mvAddNewEmb = new MenuItemViewModel(this.ViewModelStore, "Add new embedding relationship");
                        mvAddNewEmb.Command = AddNewEmbeddingRSCommand;
                        menuItemViewModelAdd.Children.Add(mvAddNewEmb);

                        // add new embedding relationship to existing element
                        MenuItemViewModel mvAddNewEmbToEx = new MenuItemViewModel(this.ViewModelStore, "Add new embedding relationship to existing element");
                        mvAddNewEmbToEx.Command = AddNewEmbeddingRSToExistantCommand;
                        menuItemViewModelAdd.Children.Add(mvAddNewEmbToEx);

                        // add new reference relationship to existing element
                        MenuItemViewModel mvAddNewRef = new MenuItemViewModel(this.ViewModelStore, "Add new reference relationship to existing element");
                        mvAddNewRef.Command = AddNewReferenceRSCommand;
                        menuItemViewModelAdd.Children.Add(mvAddNewRef);

                        // add new reference relationship to existing relationship
                        MenuItemViewModel mvAddNewRefToRS = new MenuItemViewModel(this.ViewModelStore, "Add new reference relationship to existing relationship");
                        mvAddNewRefToRS.Command = AddNewReferenceRSToRSCommand;
                        menuItemViewModelAdd.Children.Add(mvAddNewRefToRS);

                        // add new inheritance relationship to existing element
                        MenuItemViewModel mvAddNewInh = new MenuItemViewModel(this.ViewModelStore, "Add new inheritance relationship to existing element");
                        mvAddNewInh.Command = AddNewInheritanceRSCommand;
                        menuItemViewModelAdd.Children.Add(mvAddNewInh);
                        mvAddNewInh.IsEnabled = !bAnyHasBaseClass;

                        // add new derived class
                        MenuItemViewModel mvAddNewDerived = new MenuItemViewModel(this.ViewModelStore, "Add new derived class");
                        mvAddNewDerived.Command = AddNewDerivedElementCommand;
                        menuItemViewModelAdd.Children.Add(mvAddNewDerived);

                        MenuItemViewModel menuItemViewModelAddShape = new MenuItemViewModel(this.ViewModelStore, "Add Shape Mapping");
                        this.contextMenuOperations.Add(menuItemViewModelAddShape);

                        // add new shape mapping
                        MenuItemViewModel mvAddNewShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add mapping to new shape class");
                        mvAddNewShapeClass.Command = AddMappingToNewShapeClassCommand;
                        menuItemViewModelAddShape.Children.Add(mvAddNewShapeClass);

                        // Add new shape mapping to existing shape element
                        MenuItemViewModel mvAddExtShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add mapping to existing shape class");
                        mvAddExtShapeClass.Command = AddMappingToExtShapeClassCommand;
                        menuItemViewModelAddShape.Children.Add(mvAddExtShapeClass);

                        // add new mapping relationship shape mapping
                        MenuItemViewModel mvAddNewMapRSShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add mapping to new mapping relationship shape class");
                        mvAddNewMapRSShapeClass.Command = AddMappingToNewMappingShapeClassCommand;
                        menuItemViewModelAddShape.Children.Add(mvAddNewMapRSShapeClass);

                        // Add new shape mapping to existing shape element
                        MenuItemViewModel mvAddExtMapRSShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add mapping to existing mapping relationship shape class");
                        mvAddExtMapRSShapeClass.Command = AddMappingToExtMappingShapeClassCommand;
                        menuItemViewModelAddShape.Children.Add(mvAddExtMapRSShapeClass);

                        if (this.SelectedItems.Count == 1)
                        {
                            TreeNodeViewModel node = this.SelectedItems[0] as TreeNodeViewModel;
                            if (node != null)
                            {
                                AddSeparator();

                                // bring tree here
                                MenuItemViewModel mvBTH = new MenuItemViewModel(this.ViewModelStore, "Bring tree here");
                                mvBTH.Command = BringTreeHereCommand;
                                mvBTH.IsEnabled = ModelTreeOperations.CanBringTreeHere(node.TreeNode);
                                this.contextMenuOperations.Add(mvBTH);

                                // split tree
                                MenuItemViewModel mvSplit = new MenuItemViewModel(this.ViewModelStore, "Split tree");
                                mvSplit.Command = SplitTreeCommand;
                                mvSplit.IsEnabled = ModelTreeOperations.CanSplitTree(node.TreeNode);
                                this.contextMenuOperations.Add(mvSplit);
                            }
                        }

                        #endregion
                    }
                    else if (selectedTypes[0] == "ReferenceRelationship")
                    {
                        this.AddSeparator();

                        // add new shape mapping
                        MenuItemViewModel mvAddNewRSShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add mapping to new relationship shape class");
                        mvAddNewRSShapeClass.Command = AddMappingToNewRelShapeClassCommand;
                        this.contextMenuOperations.Add(mvAddNewRSShapeClass);

                        // Add new shape mapping to existing shape element
                        MenuItemViewModel mvAddExtRSShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add mapping to existing relationship shape class");
                        mvAddExtRSShapeClass.Command = AddMappingToExtRelShapeClassCommand;
                        this.contextMenuOperations.Add(mvAddExtRSShapeClass);
                    }
                }

                if (this.SelectedItems.Count == 1)
                {
                    #region MoveUp/Down
                    AddSeparator();

                    TreeNodeViewModel nodeVM = this.SelectedItems[0] as TreeNodeViewModel;
                    if (nodeVM != null)
                    {
                        MenuItemViewModel mvMoveUp = new MenuItemViewModel(this.ViewModelStore, "Move up", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Up-16.png");
                        mvMoveUp.Command = MoveUpCommand;
                        if (!nodeVM.CanMoveUp())
                            mvMoveUp.IsEnabled = false;
                        this.contextMenuOperations.Add(mvMoveUp);

                        MenuItemViewModel mvMoveDown = new MenuItemViewModel(this.ViewModelStore, "Move down", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Down-16.png");
                        mvMoveDown.Command = MoveDownCommand;
                        if (!nodeVM.CanMoveDown())
                            mvMoveDown.IsEnabled = false;
                        this.contextMenuOperations.Add(mvMoveDown);
                    }
                    #endregion
                }

                // copy and paste
                AddSeparator();

                //MenuItemViewModel mvCut = new MenuItemViewModel(this.ViewModelStore, "Cut", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Cut.png");
                //mvCut.Command = modelContextVM.CutCommand;
                //this.contextMenuOperations.Add(mvCut);

                MenuItemViewModel mvCopy = new MenuItemViewModel(this.ViewModelStore, "Copy", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Copy.png");
                mvCopy.Command = modelContextVM.CopyCommand;
                this.contextMenuOperations.Add(mvCopy);

                MenuItemViewModel mvPaste = new MenuItemViewModel(this.ViewModelStore, "Paste", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Paste.png");
                mvPaste.Command = modelContextVM.PasteCommand;
                this.contextMenuOperations.Add(mvPaste);

                MenuItemViewModel vmAdv = new MenuItemViewModel(this.ViewModelStore, "Advanced");
                
                MenuItemViewModel mvCopyAllTree = new MenuItemViewModel(this.ViewModelStore, "Copy all tree", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Copy.png");
                mvCopyAllTree.Command = modelContextVM.CopyAllTreeCommand;
                vmAdv.Children.Add(mvCopyAllTree);

                MenuItemViewModel mvCopyEmbTree = new MenuItemViewModel(this.ViewModelStore, "Copy with embedding tree", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Copy.png");
                mvCopyEmbTree.Command = modelContextVM.CopyEmbeddingTreeCommand;
                vmAdv.Children.Add(mvCopyEmbTree);

                MenuItemViewModel mvCopyRfTree = new MenuItemViewModel(this.ViewModelStore, "Copy with reference tree", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Copy.png");
                mvCopyRfTree.Command = modelContextVM.CopyReferenceTreeCommand;
                vmAdv.Children.Add(mvCopyRfTree);

                this.contextMenuOperations.Add(vmAdv);

                // delete:
                if (!bIsDomainModelSelected)
                {
                    AddSeparator();

                    MenuItemViewModel mvDelete = new MenuItemViewModel(this.ViewModelStore, "Delete", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Delete-16.png");
                    mvDelete.Command = DeleteCommand;
                    this.contextMenuOperations.Add(mvDelete);
                }

                // view properties:
                AddSeparator();

                MenuItemViewModel mvProp = new MenuItemViewModel(this.ViewModelStore, "Properties", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Properties-16x16.png");
                mvProp.Command = ViewPropertiesCommand;
                this.contextMenuOperations.Add(mvProp);

                if (this.SelectedItems.Count == 1)
                {
                    AddSeparator();

                    MenuItemViewModel mvTemplateHelper = new MenuItemViewModel(this.ViewModelStore, "Template Helper", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/info-16x16.png");
                    mvTemplateHelper.Command = ShowTemplateHelperCommand;
                    this.contextMenuOperations.Add(mvTemplateHelper);

                }
            }
            else
            {
                // copy and paste
                AddSeparator();

                MenuItemViewModel mvCopy = new MenuItemViewModel(this.ViewModelStore, "Copy", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Copy.png");
                mvCopy.Command = modelContextVM.CopyCommand;
                this.contextMenuOperations.Add(mvCopy);

                MenuItemViewModel mvPaste = new MenuItemViewModel(this.ViewModelStore, "Paste", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Paste.png");
                mvPaste.Command = modelContextVM.PasteCommand;
                this.contextMenuOperations.Add(mvPaste);

                // optimize
                AddSeparator();

                MenuItemViewModel mvOptimize = new MenuItemViewModel(this.ViewModelStore, "Optimize (beta)");
                mvOptimize.Command = modelContextVM.OptimizeCommand;
                this.contextMenuOperations.Add(mvOptimize);
            }

            OnPropertyChanged("Operations");
        }

        /// <summary>
        /// Adds a separtor to the context menu operations if required.
        /// </summary>
        private void AddSeparator()
        {
            if (this.contextMenuOperations.Count > 0)
                if (!(this.contextMenuOperations[this.contextMenuOperations.Count - 1] is SeparatorMenuItemViewModel))
                    this.contextMenuOperations.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));
        }
        #endregion

        /// <summary>
        /// Called whenever selection changes.
        /// </summary>
        /// <param name="args"></param>
        private void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            if (args.SelectedItems == null)
                return;

            if (this.IsActiveView || args.SourceViewModel == this)
                return;

            Collection<object> sVms = new Collection<object>();
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
            {
                if (vm != null)
                    vm.IsSelected = false;
            }

            foreach (ModelElement element in args.SelectedItems)
            {
                BaseModelElementViewModel foundModel = null;
                foreach (RootNodeViewModel m in this.RootNodes)
                {
                    if (m.Element == element && m.IsElementHolder)
                        foundModel = m;

                    if( foundModel == null )
                        foundModel = m.FindViewModel(element);

                    if (foundModel != null)
                        if( !sVms.Contains(foundModel) )
                            sVms.Add(foundModel);
                }
            }

            foreach (BaseModelElementViewModel vm in sVms)
                vm.IsSelected = true;

            this.selectedVMS = sVms;
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(OnSelectionChanged));
            Unsubscribe();

            base.OnDispose();
        }
    }
}

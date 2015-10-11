using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using System;
using System.Collections.Generic;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Selection;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Services;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram
{
    public class DiagramViewModel : BaseDockingViewModel
    {
        #region Fields
        private ModelContextViewModel modelContextVM;
        private DiagramView diagramView;

        private ObservableCollection<DiagramClassViewModel> rootNodeVMs;
        private ReadOnlyObservableCollection<DiagramClassViewModel> rootNodeVMsRO;

        private Collection<object> selectedVMS;
        private Collection<MenuItemViewModel> contextMenuOperations;

        private DelegateCommand addNewDiagramClassCommand;
        private DelegateCommand addNewDiagramClassFromTemplateCommand;
        private DelegateCommand addNewDomainPropertyCommand;

        private DelegateCommand addNewShapeClassCommand;
        private DelegateCommand addNewMappingRelationshipShapeClassCommand;
        private DelegateCommand addNewRelationshipShapeClassCommand;

        private DelegateCommand unparentCommand;
        private DelegateCommand reparentCommand;

        private DelegateCommand moveUpCommand;
        private DelegateCommand moveDownCommand;

        private DelegateCommand deleteCommand;

        private DelegateCommand viewPropertiesCommand;

        private DelegateCommand addIncludedDDCCommand;
        private DelegateCommand addImportedDCCommand;

        private DelegateCommand showTemplateHelperCommand;

        private DelegateCommand addNewDomainClassSEDCommand;
        private DelegateCommand addNewDomainRLForRLShape;
        #endregion

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelTreeView">Diagram tree view.</param>
        public DiagramViewModel(ViewModelStore viewModelStore, ModelContextViewModel modelContextVM, DiagramView diagramView)
            : base(viewModelStore)
        {
            this.diagramView = diagramView;
            this.modelContextVM = modelContextVM;
            this.contextMenuOperations = new Collection<MenuItemViewModel>();
            this.selectedVMS = new Collection<object>();

            this.rootNodeVMs = new ObservableCollection<DiagramClassViewModel>();
            this.rootNodeVMsRO = new ReadOnlyObservableCollection<DiagramClassViewModel>(this.rootNodeVMs);

            if (diagramView != null)
            {
                foreach (DiagramClassView view in diagramView.DiagramClassViews)
                    AddDiagramClassView(view);

                // subscribe
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramViewHasDiagramClassViews.DomainClassId),
                    true, this.diagramView.Id, new Action<ElementAddedEventArgs>(OnDiagramClassViewAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramViewHasDiagramClassViews.DomainClassId),
                    true, this.diagramView.Id, new Action<ElementDeletedEventArgs>(OnDiagramClassViewRemoved));
            }

            addNewDiagramClassCommand = new DelegateCommand(AddNewDiagramClassCommand_Executed);
            addNewDiagramClassFromTemplateCommand = new DelegateCommand(AddNewDiagramClassFromTemplateCommand_Executed);
            addNewShapeClassCommand = new DelegateCommand(AddNewShapeClassCommand_Executed);
            addNewMappingRelationshipShapeClassCommand = new DelegateCommand(AddNewMappingRelationshipShapeClassCommand_Executed);
            addNewRelationshipShapeClassCommand = new DelegateCommand(AddNewRelationshipShapeClassCommand_Executed);
            addNewDomainPropertyCommand = new DelegateCommand(AddNewDomainPropertyCommand_Executed);

            unparentCommand = new DelegateCommand(UnparentCommand_Executed);
            reparentCommand = new DelegateCommand(ReparentCommand_Executed);

            moveUpCommand = new DelegateCommand(MoveUpCommand_Executed);
            moveDownCommand = new DelegateCommand(MoveDownCommand_Executed);

            deleteCommand = new DelegateCommand(DeleteCommand_Executed, DeleteCommand_CanExecute);

            viewPropertiesCommand = new DelegateCommand(ViewPropertiesCommand_Executed);

            addIncludedDDCCommand = new DelegateCommand(AddIncludedDDCCommand_Executed);
            addImportedDCCommand = new DelegateCommand(AddImportedDCCommand_Executed);

            showTemplateHelperCommand = new DelegateCommand(ShowTemplateHelperCommand_Executed);

            addNewDomainClassSEDCommand = new DelegateCommand(AddNewDomainClassSEDCommand_Executed);
            addNewDomainRLForRLShape = new DelegateCommand(AddNewDomainRLForRLShape_Executed);

            UpdateOperations();

            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(OnSelectionChanged));
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name.
        /// </summary>
        public override string DockingPaneName { get { return "DiagramViewModel"; } }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public override string DockingPaneTitle { get { return "Diagram Model (Views and View/Shape - Assignment)"; } }
        #endregion
        
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
                        col.Add(vm.GetHostedElement());
                    }

                // see if we need to propagate selection --> based on what is currently selected
                bool bDiffers = false;
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                {
                    if (col.Contains(vm.GetHostedElement()))
                        continue;

                    bDiffers = true;
                    break;
                }
                if (this.SelectedItems.Count != col.Count)
                    bDiffers = true;

                this.selectedVMS = value;

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

        }

        /// <summary>
        /// Gets a read-only collection of root nodes.
        /// </summary>
        public ReadOnlyObservableCollection<DiagramClassViewModel> RootDiagramNodes
        {
            get
            {
                return this.rootNodeVMsRO;
            }
        }

        /// <summary>
        /// Adds a new diagram class view model for the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void AddDiagramClassView(DiagramClassView node)
        {
            // verify that node hasnt been added yet
            foreach (DiagramClassViewModel viewModel in this.rootNodeVMs)
                if (viewModel.DiagramClassView.Id == node.Id)
                    return;

            if (node.DiagramClass is SpecificDependencyDiagram)
            {
                SpecificDependencyDiagramViewModel vm = new SpecificDependencyDiagramViewModel(this.ViewModelStore, node, this);
                this.rootNodeVMs.Add(vm);
            }
            else if (node.DiagramClass is DependencyDiagram)
            {
                DependencyDiagramViewModel vm = new DependencyDiagramViewModel(this.ViewModelStore, node, this);
                this.rootNodeVMs.Add(vm);
            }
            else if (node.DiagramClass is ModalDiagram)
            {
                ModalDiagramViewModel vm = new ModalDiagramViewModel(this.ViewModelStore, node, this);
                this.rootNodeVMs.Add(vm);
            }
            else if (node.DiagramClass is SpecificElementsDiagram)
            {
                SpecificElementsDiagramViewModel vm = new SpecificElementsDiagramViewModel(this.ViewModelStore, node, this);
                this.rootNodeVMs.Add(vm);
            }
            else
            {
                DiagramClassViewModel vm = new DiagramClassViewModel(this.ViewModelStore, node, this);
                this.rootNodeVMs.Add(vm);
            }
        }

        /// <summary>
        /// Deletes the diagram class view model that is hosting the given node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void DeleteDiagramClassView(DiagramClassView node)
        {
            for (int i = this.rootNodeVMs.Count - 1; i >= 0; i--)
                if (this.rootNodeVMs[i].DiagramClassView.Id == node.Id)
                {
                    this.rootNodeVMs[i].Dispose();
                    this.rootNodeVMs.RemoveAt(i);
                }
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramViewHasDiagramClassViews is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnDiagramClassViewAdded(ElementAddedEventArgs args)
        {
            DiagramViewHasDiagramClassViews con = args.ModelElement as DiagramViewHasDiagramClassViews;
            if (con != null)
            {
                AddDiagramClassView(con.DiagramClassView);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramViewHasDiagramClassViews is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnDiagramClassViewRemoved(ElementDeletedEventArgs args)
        {
            DiagramViewHasDiagramClassViews con = args.ModelElement as DiagramViewHasDiagramClassViews;
            if (con != null)
            {
                DeleteDiagramClassView(con.DiagramClassView);
            }
        }

        #region Context Menu Operations
        /// <summary>
        /// Updates operation collection.
        /// </summary>
        private void UpdateOperations()
        {
            this.contextMenuOperations = new Collection<MenuItemViewModel>();

            MenuItemViewModel mv = new MenuItemViewModel(this.ViewModelStore, "Add new DiagramClass", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Add-16.png");
            mv.Command = AddNewDiagramClassCommand;
            this.contextMenuOperations.Add(mv);

            MenuItemViewModel mv2 = new MenuItemViewModel(this.ViewModelStore, "Add new DiagramClass From Template", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/AddTableHS.png");
            mv2.Command = AddNewDiagramClassFromTemplateCommand;
            this.contextMenuOperations.Add(mv2);
            
            if (this.SelectedItems.Count > 0)
            {
                bool bIsDesignerDiagramSelected = false;

                // keep track of selection and set command visibility/accessibility
                // count different types in selection
                List<string> selectedTypes = new List<string>();
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                {
                    string typeName = vm.Element.GetType().Name;

                    if (!selectedTypes.Contains(typeName))
                        selectedTypes.Add(typeName);

                    if (vm.GetHostedElement() is DesignerDiagramClass)
                    {
                        bIsDesignerDiagramSelected = true;
                    }
                }

                if (selectedTypes.Count == 1)
                {
                    if (selectedTypes.Contains("RelationshipShapeClass") || selectedTypes.Contains("MappingRelationshipShapeClass") ||
                        selectedTypes.Contains("ShapeClass"))
                    {
                        MenuItemViewModel mvAddProp = new MenuItemViewModel(this.ViewModelStore, "Add new DomainProperty", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Properties-32x32-Add.png");
                        mvAddProp.Command = AddNewDomainPropertyCommand;
                        this.contextMenuOperations.Add(mvAddProp);
                    }
                    if (selectedTypes.Contains("RelationshipShapeClass"))
                    {
                        this.AddSeparator();

                        // add new DomainClass
                        MenuItemViewModel mvAddShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add referenced Domain Relationship");
                        mvAddShapeClass.Command = addNewDomainRLForRLShape;
                        this.contextMenuOperations.Add(mvAddShapeClass);
                    }

                    if (selectedTypes.Contains("DependencyDiagram") ||
                        selectedTypes.Contains("SpecificDependencyDiagram"))
                    {
                        this.AddSeparator();

                        // add new ShapeClass
                        MenuItemViewModel mvAddShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add new Shape Class");
                        mvAddShapeClass.Command = AddNewShapeClassCommand;
                        this.contextMenuOperations.Add(mvAddShapeClass);
                    }

                    if (selectedTypes.Contains("SpecificElementsDiagram"))
                    {
                        this.AddSeparator();

                        // add new DomainClass
                        MenuItemViewModel mvAddShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add referenced Domain Class");
                        mvAddShapeClass.Command = addNewDomainClassSEDCommand;
                        this.contextMenuOperations.Add(mvAddShapeClass);
                    }

                    if (selectedTypes.Contains("DiagramClass") || selectedTypes.Contains("DesignerDiagramClass") ||
                        selectedTypes.Contains("ShapeClass"))
                    {
                        this.AddSeparator();

                        MenuItemViewModel mvAdd = new MenuItemViewModel(this.ViewModelStore, "Add");
                        this.contextMenuOperations.Add(mvAdd);

                        // add new ShapeClass
                        MenuItemViewModel mvAddShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add new Shape Class");
                        mvAddShapeClass.Command = AddNewShapeClassCommand;
                        mvAdd.Children.Add(mvAddShapeClass);

                        if (selectedTypes.Contains("DesignerDiagramClass"))
                        {
                            MenuItemViewModel mvAddAdv = new MenuItemViewModel(this.ViewModelStore, "Add Advanced");
                            this.contextMenuOperations.Add(mvAddAdv);

                            MenuItemViewModel mvAddIncludedDDC = new MenuItemViewModel(this.ViewModelStore, "Add included Designer Diagram Class");
                            mvAddIncludedDDC.Command = AddIncludedDDCCommand;
                            mvAddAdv.Children.Add(mvAddIncludedDDC);

                            MenuItemViewModel mvAddIncludedDC = new MenuItemViewModel(this.ViewModelStore, "Add imported Diagram Class");
                            mvAddIncludedDC.Command = AddImportedDCCommand;
                            mvAddAdv.Children.Add(mvAddIncludedDC);
                        }

                        if (!selectedTypes.Contains("ShapeClass"))
                        {
                            // add new RelationshipShapeClass
                            MenuItemViewModel mvAddRSShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add new Relationship Shape Class");
                            mvAddRSShapeClass.Command = AddNewRelationshipShapeClassCommand;
                            mvAdd.Children.Add(mvAddRSShapeClass);

                            // add new MappingRelationshipShapeClass
                            MenuItemViewModel mvAddMappingRSShapeClass = new MenuItemViewModel(this.ViewModelStore, "Add new Mapping Relationship Shape Class");
                            mvAddMappingRSShapeClass.Command = AddNewMappingRelationshipShapeClassCommand;
                            mvAdd.Children.Add(mvAddMappingRSShapeClass);
                        }
                        if (selectedTypes.Contains("ShapeClass") && this.SelectedItems.Count == 1)
                        {
                            this.AddSeparator();

                            MenuItemViewModel mvUnparent = new MenuItemViewModel(this.ViewModelStore, "Unparent");
                            mvUnparent.Command = UnparentCommand;
                            this.contextMenuOperations.Add(mvUnparent);

                            if (((this.SelectedItems[0] as BaseModelElementViewModel).Element as ShapeClass).DiagramTreeNode is RootDiagramNode)
                                mvUnparent.IsEnabled = false;

                            MenuItemViewModel mvReparent = new MenuItemViewModel(this.ViewModelStore, "Reparent");
                            mvReparent.Command = ReparentCommand;
                            this.contextMenuOperations.Add(mvReparent);
                        }
                    }

                    if (this.SelectedItems.Count == 1)
                    {
                        if (this.SelectedItems[0] is DiagramTreeNodeViewModel)
                        {
                            #region MoveUp/Down
                            this.AddSeparator();

                            DiagramTreeNodeViewModel node = this.SelectedItems[0] as DiagramTreeNodeViewModel;
                            if (node != null)
                            {
                                MenuItemViewModel mvMoveUp = new MenuItemViewModel(this.ViewModelStore, "Move up", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Up-16.png");
                                mvMoveUp.Command = MoveUpCommand;
                                if (!node.CanMoveUp())
                                    mvMoveUp.IsEnabled = false;
                                this.contextMenuOperations.Add(mvMoveUp);

                                MenuItemViewModel mvMoveDown = new MenuItemViewModel(this.ViewModelStore, "Move down", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Down-16.png");
                                mvMoveDown.Command = MoveDownCommand;
                                if (!node.CanMoveDown())
                                    mvMoveDown.IsEnabled = false;
                                this.contextMenuOperations.Add(mvMoveDown);
                            }
                            #endregion
                        }
                    }
                }
                this.AddSeparator();

                MenuItemViewModel mvCopy = new MenuItemViewModel(this.ViewModelStore, "Copy", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Copy.png");
                mvCopy.Command = modelContextVM.CopyCommand;
                this.contextMenuOperations.Add(mvCopy);

                MenuItemViewModel mvPaste = new MenuItemViewModel(this.ViewModelStore, "Paste", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Paste.png");
                mvPaste.Command = modelContextVM.PasteCommand;
                this.contextMenuOperations.Add(mvPaste);

                if (!bIsDesignerDiagramSelected)
                {
                    this.AddSeparator();

                    MenuItemViewModel mvDelete = new MenuItemViewModel(this.ViewModelStore, "Delete", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Delete-16.png");
                    mvDelete.Command = DeleteCommand;
                    this.contextMenuOperations.Add(mvDelete);
                }

                // view properties:
                this.AddSeparator();

                MenuItemViewModel mvProp = new MenuItemViewModel(this.ViewModelStore, "Properties", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Properties-16x16.png");
                mvProp.Command = ViewPropertiesCommand;
                this.contextMenuOperations.Add(mvProp);
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
            }

            if (this.SelectedItems.Count == 1)
            {
                AddSeparator();

                MenuItemViewModel mvTemplateHelper = new MenuItemViewModel(this.ViewModelStore, "Template Helper", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/info-16x16.png");
                mvTemplateHelper.Command = ShowTemplateHelperCommand;
                this.contextMenuOperations.Add(mvTemplateHelper);
                
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

        #region Commands And Methods
        public DelegateCommand AddNewDomainRLForRLShape
        {
            get
            {
                return this.addNewDomainRLForRLShape;
            }
        }
        /// <summary>
        /// ShowTemplateHelperCommand.
        /// </summary>
        public DelegateCommand ShowTemplateHelperCommand
        {
            get { return this.showTemplateHelperCommand; }
        }

        /// <summary>
        /// Add new domain property command.
        /// </summary>
        public DelegateCommand AddNewDomainPropertyCommand
        {
            get { return this.addNewDomainPropertyCommand; }
        }

        /// <summary>
        /// Add new diagram class command.
        /// </summary>
        public DelegateCommand AddNewDiagramClassCommand
        {
            get { return this.addNewDiagramClassCommand; }
        }

        /// <summary>
        /// Add new diagram class command.
        /// </summary>
        public DelegateCommand AddNewDiagramClassFromTemplateCommand
        {
            get { return this.addNewDiagramClassFromTemplateCommand; }
        }        

        /// <summary>
        /// Add new shape class command.
        /// </summary>
        public DelegateCommand AddNewShapeClassCommand
        {
            get { return this.addNewShapeClassCommand; }
        }

        /// <summary>
        /// AddNewMappingRelationshipShapeClass command.
        /// </summary>
        public DelegateCommand AddNewMappingRelationshipShapeClassCommand
        {
            get { return this.addNewMappingRelationshipShapeClassCommand; }
        }

        /// <summary>
        /// AddNewRelationshipShapeClass command.
        /// </summary>
        public DelegateCommand AddNewRelationshipShapeClassCommand
        {
            get { return this.addNewRelationshipShapeClassCommand; }
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
        /// unparentCommand.
        /// </summary>
        public DelegateCommand UnparentCommand
        {
            get { return this.unparentCommand; }
        }

        /// <summary>
        /// reparentCommand.
        /// </summary>
        public DelegateCommand ReparentCommand
        {
            get { return this.reparentCommand; }
        }

        /// <summary>
        /// Delete command.
        /// </summary>
        public DelegateCommand DeleteCommand
        {
            get { return this.deleteCommand; }
        }

        /// <summary>
        /// View properties command.
        /// </summary>
        public DelegateCommand ViewPropertiesCommand
        {
            get { return this.viewPropertiesCommand; }
        }

        /// <summary>
        /// AddIncludedDDCCommand.
        /// </summary>
        public DelegateCommand AddIncludedDDCCommand
        {
            get { return this.addIncludedDDCCommand; }
        }

        /// <summary>
        /// AddImportedDCCommand.
        /// </summary>
        public DelegateCommand AddImportedDCCommand
        {
            get { return this.addImportedDCCommand; }
        }

        /// <summary>
        /// Add new domain property command executed.
        /// </summary>
        private void AddNewDomainPropertyCommand_Executed()
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add new property"))
            {
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                    if( vm.Element is AttributedDomainElement)
                    {
                        AttributedDomainElement domainElement = vm.Element as AttributedDomainElement;
                        domainElement.Properties.AddNew();
                    }
                transaction.Commit();
            }
        }

        /// <summary>
        /// Add new diagram class from template command executed.
        /// </summary>
        private void AddNewDiagramClassFromTemplateCommand_Executed()
        {
            DiagramClassTemplateSelectorViewModel vm = new DiagramClassTemplateSelectorViewModel(this.ViewModelStore);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("DiagramClassTemplateSelector", vm);
            if (result == true)
            {
                using (Transaction transaction = Store.TransactionManager.BeginTransaction("Create new templated diagram class + vm"))
                {
                    // create new diagram class
                    DiagramClass diagramClass;

                    if (vm.SelectedTemplateVM.UniqueId == DiagramClassTemplateIds.GeneralGraphicalDependencyTemplate)
                        diagramClass = Store.ElementFactory.CreateElement(DependencyDiagram.DomainClassId) as DependencyDiagram;
                    else if (vm.SelectedTemplateVM.UniqueId == DiagramClassTemplateIds.SpecificGraphicalDependencyTemplate)
                        diagramClass = Store.ElementFactory.CreateElement(SpecificDependencyDiagram.DomainClassId) as SpecificDependencyDiagram;
                    else if (vm.SelectedTemplateVM.UniqueId == DiagramClassTemplateIds.ModalDiagramTemplate)
                        diagramClass = Store.ElementFactory.CreateElement(ModalDiagram.DomainClassId) as ModalDiagram;
                    else if (vm.SelectedTemplateVM.UniqueId == DiagramClassTemplateIds.SpecificElementsDiagramTemplate)
                        diagramClass = Store.ElementFactory.CreateElement(SpecificElementsDiagram.DomainClassId) as SpecificElementsDiagram;
                    else if (vm.SelectedTemplateVM.UniqueId == DiagramClassTemplateIds.DesignerSurfaceDiagramTemplate)
                        diagramClass = Store.ElementFactory.CreateElement(DesignerSurfaceDiagram.DomainClassId) as DesignerSurfaceDiagram;
                    else
                    {
                        throw new NotSupportedException();
                    }

                    (diagramClass as TemplatedDiagramClass).UniqueId = vm.SelectedTemplateVM.UniqueId;
                    (diagramClass as TemplatedDiagramClass).Name = vm.SelectedTemplateVM.Name;
                    (diagramClass as TemplatedDiagramClass).Title = vm.SelectedTemplateVM.DisplayName;
                    (diagramClass as TemplatedDiagramClass).Description = vm.SelectedTemplateVM.Description;
                    diagramClass.IsCustom = true;

                    Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(Store as IServiceProvider, Store.DefaultPartition);
                    Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(Store.DefaultPartition);
                    elementGroup.Add(diagramClass);
                    elementGroup.MarkAsRoot(diagramClass);
                    elementOperations.MergeElementGroup(this.diagramView.ViewContext.ModelContext, elementGroup);

                    DiagramClassView view = new DiagramClassView(this.Store);
                    view.DiagramClass = diagramClass;
                    this.diagramView.DiagramClassViews.Add(view);

                    transaction.Commit();
                }
            }
        }
        
        /// <summary>
        /// Add new diagram class command executed.
        /// </summary>
        private void AddNewDiagramClassCommand_Executed()
        {
            using (Transaction transaction = Store.TransactionManager.BeginTransaction("Create new diagram class + vm"))
            {
                // create new diagram class
                DiagramClass diagramClass = Store.ElementFactory.CreateElement(DiagramClass.DomainClassId) as DiagramClass;
                Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(Store as IServiceProvider, Store.DefaultPartition);
                Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(Store.DefaultPartition);
                elementGroup.Add(diagramClass);
                elementGroup.MarkAsRoot(diagramClass);
                elementOperations.MergeElementGroup(this.diagramView.ViewContext.ModelContext, elementGroup);
                diagramClass.Name = NameHelper.GetUniqueName(Store, DiagramClass.DomainClassId);

                diagramClass.Title = diagramClass.Name;

                DiagramClassView view = new DiagramClassView(this.Store);
                view.DiagramClass = diagramClass;
                this.diagramView.DiagramClassViews.Add(view);

                transaction.Commit();
            }
        }

        /// <summary>
        /// AddNewShapeClass command executed.
        /// </summary>
        private void AddNewShapeClassCommand_Executed()
        {
            using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
            {
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                    if (vm is DiagramClassViewModel)
                    {
                        ShapeClass shape = DiagramTreeOperations.CreateShapeClass((vm as DiagramClassViewModel).DiagramClassView.DiagramClass);
                        RootDiagramNode node = new RootDiagramNode(this.Store);
                        node.PresentationElementClass = shape;

                        (vm as DiagramClassViewModel).DiagramClassView.RootDiagramNodes.Add(node);
                    }
                    else if (vm is EmbeddingDiagramNodeViewModel)
                    {
                        ShapeClass orgShape = (vm as EmbeddingDiagramNodeViewModel).EmbeddingDiagramNode.PresentationElementClass as ShapeClass;

                        ShapeClass shape = DiagramTreeOperations.CreateShapeClass(orgShape.DiagramClass);
                        EmbeddingDiagramNode newNode = new EmbeddingDiagramNode(this.Store);
                        newNode.PresentationElementClass = shape;

                        orgShape.Children.Add(shape);
                        if (orgShape.DiagramTreeNode is EmbeddingDiagramNode)
                            newNode.SourceEmbeddingDiagramNode = orgShape.DiagramTreeNode as EmbeddingDiagramNode;
                    }
                
                transaction.Commit();
            }
        }
        
        /// <summary>
        /// AddNewMappingRelationshipShapeClass command executed.
        /// </summary>
        private void AddNewMappingRelationshipShapeClassCommand_Executed()
        {
            using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new shape class"))
            {
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                    if (vm is DiagramClassViewModel)
                    {
                        MappingRelationshipShapeClass shape = DiagramTreeOperations.CreateMappingRelationshipShapeClass((vm as DiagramClassViewModel).DiagramClassView.DiagramClass);
                        RootDiagramNode node = new RootDiagramNode(this.Store);
                        node.PresentationElementClass = shape;

                        (vm as DiagramClassViewModel).DiagramClassView.RootDiagramNodes.Add(node);
                    }
                transaction.Commit();
            }        
        }

        /// <summary>
        /// AddNewRelationshipShapeClass command executed.
        /// </summary>
        private void AddNewRelationshipShapeClassCommand_Executed()
        {
            using (Transaction transaction = Store.TransactionManager.BeginTransaction("Add new Shape Class"))
            {
                foreach (BaseModelElementViewModel vm in this.SelectedItems)
                    if (vm is DiagramClassViewModel)
                    {
                        RelationshipShapeClass shape = DiagramTreeOperations.CreateRelationshipShapeClass((vm as DiagramClassViewModel).DiagramClassView.DiagramClass);
                        RootDiagramNode node = new RootDiagramNode(this.Store);
                        node.PresentationElementClass = shape;

                        (vm as DiagramClassViewModel).DiagramClassView.RootDiagramNodes.Add(node);
                    }

                transaction.Commit();
            }         
        }
        
        /// <summary>
        /// MoveUpCommand executed.
        /// </summary>
        private void MoveUpCommand_Executed()
        {
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
                if (vm is DiagramTreeNodeViewModel)
                {
                    (vm as DiagramTreeNodeViewModel).MoveUp();
                    break;
                }

            UpdateOperations();
        }

        /// <summary>
        /// MoveDownCommand executed.
        /// </summary>
        private void MoveDownCommand_Executed()
        {
            foreach (BaseModelElementViewModel vm in this.SelectedItems)
                if (vm is DiagramTreeNodeViewModel)
                {
                    (vm as DiagramTreeNodeViewModel).MoveDown();
                    break;
                }

            UpdateOperations();
        }

        /// <summary>
        /// UnparentCommand executed.
        /// </summary>
        private void UnparentCommand_Executed()
        {
            if (this.SelectedItems.Count == 0)
                return;
            
            if (!(this.SelectedItems[0] is EmbeddingDiagramNodeViewModel))
                return;

            if (this.SelectedItems[0] is RootDiagramNodeViewModel)
                return;

            using (Transaction transaction = Store.TransactionManager.BeginTransaction("Unparent"))
            {
                EmbeddingDiagramNodeViewModel vm = this.SelectedItems[0] as EmbeddingDiagramNodeViewModel;
                EmbeddingDiagramNode node = vm.EmbeddingDiagramNode;
                ShapeClass shapeClass = node.PresentationElementClass as ShapeClass;

                DiagramTreeOperations.UnparentShape(shapeClass);

                node.Delete();

                transaction.Commit();
            }
        }

        /// <summary>
        /// ReparentCommand executed.
        /// </summary>
        private void ReparentCommand_Executed()
        {
            if (this.SelectedItems.Count == 0)
                return;

            if (!(this.SelectedItems[0] is EmbeddingDiagramNodeViewModel))
                return;

            EmbeddingDiagramNodeViewModel vm = this.SelectedItems[0] as EmbeddingDiagramNodeViewModel;
            EmbeddingDiagramNode node = vm.EmbeddingDiagramNode;
            ShapeClass shapeClass = node.PresentationElementClass as ShapeClass;
            if (node == null || shapeClass == null)
                return;

            List<ShapeClass> sortedClasses = new List<ShapeClass>();
            foreach (PresentationElementClass p in shapeClass.DiagramClass.PresentationElements)
                if (p is ShapeClass && p != shapeClass)
                {
                    // lets see if this element is child of node.PresentationElementClass
                    if (shapeClass.Parent == p)
                        continue;

                    if (!shapeClass.ContainsChild(p as ShapeClass))
                        sortedClasses.Add(p as ShapeClass);
                }

            sortedClasses.Sort(CompareShapeClassesByName);

            List<SelectableViewModel> vms = new List<SelectableViewModel>();
            foreach (ShapeClass d in sortedClasses)
                    vms.Add(new SelectableViewModel(this.ViewModelStore, d));

            SelectionViewModel selectionVM = new SelectionViewModel(this.ViewModelStore, vms);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("TargetSelectorForm", selectionVM);
            if (result == true)
            {
                if (selectionVM.SelectedViewModel != null)
                {
                    ShapeClass selectedShapeClass = selectionVM.SelectedViewModel.Element as ShapeClass;
                    using (Transaction transaction = Store.TransactionManager.BeginTransaction("Unparent"))
                    {
                        // move element
                        shapeClass.Parent = selectedShapeClass;

                        EmbeddingDiagramNode embeddingNode = new EmbeddingDiagramNode(this.Store);

                        List<EmbeddingDiagramNode> nodesToMove = new List<EmbeddingDiagramNode>();
                        foreach (EmbeddingDiagramNode n in node.EmbeddingDiagramNodes)
                            nodesToMove.Add(n);
                        foreach (EmbeddingDiagramNode n in nodesToMove)
                        {
                            n.SourceEmbeddingDiagramNode = embeddingNode;
                        }
                        
                        embeddingNode.SourceEmbeddingDiagramNode = selectedShapeClass.DiagramTreeNode as EmbeddingDiagramNode;
                        shapeClass.DiagramTreeNode = embeddingNode;
                        
                        node.Delete();

                        transaction.Commit();
                    }
                }
            }

            selectionVM.Dispose();
            GC.Collect();

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
                        /*
                        if (vm is ImportedDiagramClassViewModel)
                        {
                            ImportedDiagramClassViewModel d = vm as ImportedDiagramClassViewModel;
                            d.ParentDesignerClass.DiagramClasses.Remove(d.GetHostedElement() as DiagramClass);
                        }
                        else if (vm is IncludedDiagramClassViewModel)
                        {
                            IncludedDiagramClassViewModel d = vm as IncludedDiagramClassViewModel;
                            d.ParentDesignerClass.TargetDesignerDiagramClasses.Remove(d.GetHostedElement() as DesignerDiagramClass);
                        }
                        else*/
                            vm.DeleteHostedElement();
                    }
                    transaction.Commit();
                }
            }
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
                    if (vm.GetHostedElement() is DesignerDiagramClass)
                    {
                        return false;
                    }

                    if (vm.IsLocked)
                        return false;
                }

                return true;
            }

            return false;
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
        /// AddIncludedDDCCommand executed.
        /// </summary>
        private void AddIncludedDDCCommand_Executed()
        {
            if( this.SelectedItems.Count < 1 )
                return;

            DiagramClassViewModel diagVM = this.SelectedItems[0] as DiagramClassViewModel;
            if (!(diagVM.GetHostedElement() is DesignerDiagramClass))
                return;

            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.diagramView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DiagramClass);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if (vm.SelectedViewModel.GetHostedElement() == diagVM.GetHostedElement())
                {
                    System.Windows.MessageBox.Show("Can not include itself! Please select a different DesignerDiagramClass to include");
                }
                else
                {
                    // see if a reference between those classes already exists or not
                    DesignerDiagramClass d = diagVM.GetHostedElement() as DesignerDiagramClass;
                    //DesignerDiagramClass dRef = vm.SelectedViewModel.GetHostedElement() as DesignerDiagramClass;
                    DiagramClass dRef = vm.SelectedViewModel.GetHostedElement() as DiagramClass;
                    foreach(DesignerDiagramClass dAlreadyInRef in d.IncludedDiagramClasses)
                        if (dRef == dAlreadyInRef)
                        {
                            System.Windows.MessageBox.Show("There is already a reference between the specified classes!");
                            return;
                        }

                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add"))
                    {
                        new DesignerDiagramClassReferencesIncludedDiagramClasses(d, dRef);
                        transaction.Commit();
                    }
                }

                vm.Dispose();
                GC.Collect();
            }
        }

        /// <summary>
        /// AddImportedDCCommand executed.
        /// </summary>
        private void AddImportedDCCommand_Executed()
        {
            if (this.SelectedItems.Count < 1)
                return;

            DiagramClassViewModel diagVM = this.SelectedItems[0] as DiagramClassViewModel;
            if (!(diagVM.GetHostedElement() is DesignerDiagramClass))
                return;

            CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.diagramView.ViewContext.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DiagramClassWithoutDerived);
            bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
            if (result == true)
            {
                if ((vm.SelectedViewModel.GetHostedElement() as DiagramClass).ModelContext.MetaModel == (diagVM.GetHostedElement() as DesignerDiagramClass).ModelContext.MetaModel)
                {
                    System.Windows.MessageBox.Show("Can not include Diagram Classes from the same DSL");
                }
                else
                {
                    // see if a reference between those classes already exists or not
                    DesignerDiagramClass d = diagVM.GetHostedElement() as DesignerDiagramClass;
                    DiagramClass dRef = vm.SelectedViewModel.GetHostedElement() as DiagramClass;
                    foreach (DiagramClass dAlreadyInRef in d.ImportedDiagramClasses)
                        if (dRef == dAlreadyInRef)
                        {
                            System.Windows.MessageBox.Show("There is already a reference between the specified classes!");
                            return;
                        }

                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add"))
                    {
                        new DesignerDiagramClassReferencesImportedDiagramClasses(d, dRef);
                        transaction.Commit();
                    }
                }

                vm.Dispose();
                GC.Collect();
            }
        }

        private void ShowTemplateHelperCommand_Executed()
        {
            if (this.SelectedItems.Count == 1)
                if (this.SelectedItems[0] is BaseModelElementViewModel)
                {
                    DateTemplateSelectorViewModel vm = new DateTemplateSelectorViewModel(this.ViewModelStore);
                    foreach (DataTemplateViewModel templateVm in DataTemplates.GetTemplates(this.SelectedItems[0] as BaseModelElementViewModel))
                        vm.TemplateVMs.Add(templateVm);

                    this.GlobalServiceProvider.Resolve<IUIVisualizerService>().Show("DataTemplatePresetsPopup", vm, true, null);
                    //this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("DataTemplatePresetsPopup", vm);
                    //vm.Dispose();
                }
        }

        private void AddNewDomainClassSEDCommand_Executed()
        {
            if (this.SelectedItems.Count == 1)
                if (this.SelectedItems[0] is SpecificElementsDiagramViewModel)
                {
                    CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.modelContextVM.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.DomainClass);
                    bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
                    if (result == true)
                    {
                        if (vm.SelectedViewModel != null)
                        {
                            SpecificElementsDiagram diagramClass = (this.SelectedItems[0] as SpecificElementsDiagramViewModel).DiagramClassView.DiagramClass as SpecificElementsDiagram;
                            DomainClass d = vm.SelectedViewModel.Element as DomainClass;

                            if (!diagramClass.DomainClasses.Contains(d))
                            {
                                using (Transaction t = this.Store.TransactionManager.BeginTransaction())
                                {

                                    diagramClass.DomainClasses.Add(d);

                                    t.Commit();
                                }
                            }
                        }
                    }

                    vm.Dispose();
                    GC.Collect();
                }
        }

        private void AddNewDomainRLForRLShape_Executed()
        {
            if (this.SelectedItems.Count == 1)
                if (this.SelectedItems[0] is RootDiagramNodeViewModel)
                {
                    RootDiagramNodeViewModel vmRD = this.SelectedItems[0] as RootDiagramNodeViewModel;
                    if (vmRD.GetHostedElement() is RelationshipShapeClass)
                    {
                        CategorizedSelectionViewModel vm = SelectionHelper.CreateCategorizedVM(this.modelContextVM.ModelContext.MetaModel, this.ViewModelStore, SelectionHelperTarget.ReferenceRelationship | SelectionHelperTarget.EmbeddingRelationship);
                        bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("CategorizedSelectionPopup", vm);
                        if (result == true)
                        {
                            if (vm.SelectedViewModel != null)
                            {
                                RelationshipShapeClass rShape = vmRD.GetHostedElement() as RelationshipShapeClass;
                                DomainRelationship d = vm.SelectedViewModel.Element as DomainRelationship;

                                using (Transaction t = this.Store.TransactionManager.BeginTransaction())
                                {
                                    rShape.ReferenceRelationship = d;
                                    t.Commit();
                                }
                            }
                        }

                        vm.Dispose();
                        GC.Collect();
                    }
                }
        }
        #endregion

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(OnSelectionChanged));
            if (this.diagramView != null)
            {
                // unsubscribe
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramViewHasDiagramClassViews.DomainClassId),
                    true, this.diagramView.Id, new Action<ElementAddedEventArgs>(OnDiagramClassViewAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramViewHasDiagramClassViews.DomainClassId),
                    true, this.diagramView.Id, new Action<ElementDeletedEventArgs>(OnDiagramClassViewRemoved));
            }

            base.OnDispose();
        }
        
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
                foreach (DiagramClassViewModel m in this.RootDiagramNodes)
                {
                    if (m.Element == element)
                        foundModel = m;

                    if (foundModel == null)
                        foundModel = m.FindViewModel(element);

                    if (foundModel != null)
                        if (!sVms.Contains(foundModel))
                            sVms.Add(foundModel);
                }
            }

            foreach (BaseModelElementViewModel vm in sVms)
                vm.IsSelected = true;

            this.selectedVMS = sVms;
        }
    }
}

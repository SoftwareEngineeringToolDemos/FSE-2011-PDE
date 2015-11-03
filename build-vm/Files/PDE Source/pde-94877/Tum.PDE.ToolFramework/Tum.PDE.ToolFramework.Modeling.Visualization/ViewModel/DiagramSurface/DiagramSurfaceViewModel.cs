using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;
using Tum.PDE.ToolFramework.Modeling.Visualization.Operations;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// This is the base abstract class for a diagram surface implementation.
    /// </summary>
    /// <remarks>
    /// Items are added onto the surface by:
    /// - User-Command of the instance of this vm, uses AddElement function
    /// - Drag and Drop-TODO
    /// 
    /// Items are removed from the surface by:
    /// - RemoveElement
    /// - Child ShapeElement removed from diagrams children collection (OnChildShapeElementRemoved)
    /// 
    /// This equally applies to links.
    /// </remarks>
    public abstract class DiagramSurfaceViewModel : BaseDiagramSurfaceViewModel, IDiagramViewModel
    {
        private Collection<BaseDiagramItemViewModel> selectedItems;

        /// <summary>
        /// Child items storage.
        /// </summary>
        protected ObservableCollection<BaseDiagramItemViewModel> childItems;
        private ReadOnlyObservableCollection<BaseDiagramItemViewModel> childItemsRO;

        /// <summary>
        /// Elements storage.
        /// </summary>
        protected ObservableCollection<BaseDiagramItemElementViewModel> childItemElements;
        private ReadOnlyObservableCollection<BaseDiagramItemElementViewModel> childItemElementsRO;

        /// <summary>
        /// Links storage.
        /// </summary>
        protected ObservableCollection<BaseDiagramItemLinkViewModel> childItemLinks;
        private ReadOnlyObservableCollection<BaseDiagramItemLinkViewModel> childItemLinksRO;

        private ObservableCollection<MenuItemViewModel> menuOptions;

        private PointD clickedPoint = PointD.Empty;
        private ObservableCollection<MenuItemViewModel<DiagramContextMenuCreationHelper>> insertableElements;

        private IDiagramDesigner diagramDesigner = null;
        private bool bIsIncludedModelInstance = false;
        private List<DiagramSurfaceViewModel> includedSurfaceViewModels;

        private DelegateCommand<ViewModelRelationshipCreationInfo> createRelationshipCommand;
        private DelegateCommand copyAsImageCommand;
        private DelegateCommand deleteShapesAndElementsCommand;
        private DelegateCommand toggleOrthogonalConnectorCommand;
        private DelegateCommand toggleStraightConnectorCommand;

        private DelegateCommand layoutCommand;

        private DiagramVisualizationBehavior visualizationBehavior = DiagramVisualizationBehavior.Extended;
        private DiagramDomainDataDirectory diagramDomainData = null;

        /// <summary>
        /// This value is used to move elements whenever Up, Down, Left or Right keys are pressed.
        /// </summary>
        public static double MovementUnit = 1.0;

        #region Constructor
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Model context.</param>
        protected DiagramSurfaceViewModel(ViewModelStore viewModelStore, ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {

        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">Diagram.</param>
        /// <param name="modelContext">Model context.</param>
        protected DiagramSurfaceViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext)
            : this(viewModelStore, diagram, modelContext, false)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">Diagram.</param>
        /// <param name="modelContext">Model context.</param>
        /// <param name="bIsIncludedModelInstance"></param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected DiagramSurfaceViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext, bool bIsIncludedModelInstance)
            : this(viewModelStore, diagram, modelContext, false, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">Diagram.</param>
        /// <param name="modelContext">Model context.</param>
        /// <param name="bIsIncludedModelInstance"></param>
        /// <param name="bCallInitialize"></param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected DiagramSurfaceViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext, bool bIsIncludedModelInstance, bool bCallInitialize)
            : base(viewModelStore, diagram, modelContext.Name, false)
        {
            this.ModelContext = modelContext;
            base.Diagram = diagram;
            this.bIsIncludedModelInstance = bIsIncludedModelInstance;
            this.includedSurfaceViewModels = new List<DiagramSurfaceViewModel>();

            this.childItems = new ObservableCollection<BaseDiagramItemViewModel>();
            this.childItemsRO = new ReadOnlyObservableCollection<BaseDiagramItemViewModel>(childItems);
            this.childItemLinks = new ObservableCollection<BaseDiagramItemLinkViewModel>();
            this.childItemLinksRO = new ReadOnlyObservableCollection<BaseDiagramItemLinkViewModel>(childItemLinks);
            this.childItemElements = new ObservableCollection<BaseDiagramItemElementViewModel>();
            this.childItemElementsRO = new ReadOnlyObservableCollection<BaseDiagramItemElementViewModel>(childItemElements);

            this.menuOptions = new ObservableCollection<MenuItemViewModel>();
            this.selectedItems = new Collection<BaseDiagramItemViewModel>();

            this.createRelationshipCommand = new DelegateCommand<ViewModelRelationshipCreationInfo>(
                CreateRelationshipCommandExecute, CreateRelationshipCommandCanExecute);
            this.deleteShapesAndElementsCommand = new DelegateCommand(OnDeleteShapesAndElementsCommandExecuted, OnDeleteShapesAndElementsCommandCanExecute);
            this.copyAsImageCommand = new DelegateCommand(OnCopyAsImageCommandExecuted);

            this.insertableElements = new ObservableCollection<MenuItemViewModel<DiagramContextMenuCreationHelper>>();

            this.toggleOrthogonalConnectorCommand = new DelegateCommand(ToggleOrthogonalConnectorExecuted);
            this.toggleStraightConnectorCommand = new DelegateCommand(ToggleStraightConnectorExecuted);

            this.layoutCommand = new DelegateCommand(LayoutCommand_Execute, LayoutCommand_CanExecute);

            if (bCallInitialize)
            {
                this.PreInitialize();
                this.Initialize();
            }
        }
        #endregion

        #region Commands + Default Commands Overrides + Menu
        /// <summary>
        /// This method is called whenever the visibility changes.
        /// </summary>
        /// <param name="bVisible"></param>
        protected override void OnVisibilityChanged(bool bVisible)
        {
            base.OnVisibilityChanged(bVisible);

            if (this.IsIncludedModelInstance)
                return;

            if (this.Diagram != null)
            {
                this.Diagram.IsVisible = bVisible;

                foreach (DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
                    if( vm.Diagram != null )
                        vm.Diagram.IsVisible = bVisible;
            }
        }
        
        /// <summary>
        /// Gets the list of insertable elements.
        /// </summary>
        public ObservableCollection<MenuItemViewModel<DiagramContextMenuCreationHelper>> InsertableElements
        {
            get { return this.insertableElements; }
        }

        /// <summary>
        /// Gets the create relationship command.
        /// </summary>
        public DelegateCommand<ViewModelRelationshipCreationInfo> CreateRelationshipCommand
        {
            get { return this.createRelationshipCommand; }
        }

        /// <summary>
        /// Gets the DeleteShapesAndElements command.
        /// </summary>
        public DelegateCommand DeleteShapesAndElementsCommand
        {
            get
            {
                return this.deleteShapesAndElementsCommand;
            }
        }

        /// <summary>
        /// Gets the CopyAsImageCommand command.
        /// </summary>
        public DelegateCommand CopyAsImageCommand
        {
            get
            {
                return this.copyAsImageCommand;
            }
        }
        
        /// <summary>
        /// Create new rs command executed.
        /// </summary>
        /// <param name="p">Domain rs type to be created.</param>
        protected virtual void CreateNewRelationshipCommandExecute(DiagramContextMenuCreationHelper p)
        {
            DiagramRSContextMenuCreationHelper param = p as DiagramRSContextMenuCreationHelper;

            if (this.SelectedItems.Count != 2)
                return;

            if (!(this.SelectedItems[0] is BaseDiagramItemElementViewModel))
                return;

            if (!(this.SelectedItems[1] is BaseDiagramItemElementViewModel))
                return;

            BaseDiagramItemElementViewModel source;
            BaseDiagramItemElementViewModel target;
            if (this.SelectedItems[0].Id == param.SourceElementId)
            {
                source = this.SelectedItems[0] as BaseDiagramItemElementViewModel;
                target = this.SelectedItems[1] as BaseDiagramItemElementViewModel;
            }
            else
            {
                source = this.SelectedItems[1] as BaseDiagramItemElementViewModel;
                target = this.SelectedItems[0] as BaseDiagramItemElementViewModel;
            }

            this.CreateRelationship(new ViewModelRelationshipCreationInfo(source, target), param.RelationshipType);
            this.UpdateMenuOptions();
        }

        /// <summary>
        /// Create new element command executed.
        /// </summary>
        /// <param name="param">Domain class type to be created.</param>
        protected virtual void CreateNewElementCommandExecute(DiagramContextMenuCreationHelper param)
        {
            Guid domainClassType = param.RelationshipType;

            DomainModelElement element = null;
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add element"))
            {
                element = this.Store.ElementFactory.CreateElement(domainClassType) as DomainModelElement;
                DomainModelElement modelElementParent = EmbedElement(element);
                if (modelElementParent == null)
                {
                    transaction.Rollback();
                    element = null;
                }
                else
                {
                    if (element.DomainElementHasName)
                        element.GetDomainModelServices().ElementNameProvider.CreateAndAssignName(modelElementParent, element);

                    transaction.Commit();
                }
            }


            // select element
            if (element != null)
            {
                SelectedItemsCollection col = new SelectedItemsCollection();
                col.Add(element);

                EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));

                this.UpdateMenuOptions();
            }
        }
        
        /// <summary>
        /// Create new element command can execute.
        /// </summary>
        /// <param name="param">Domain class type to be created.</param>
        /// <returns></returns>
        protected virtual bool CreateNewElementCommandCanExecute(DiagramContextMenuCreationHelper param)
        {
            Guid domainClassType = param.RelationshipType;
        
            if (this.SelectedItems.Count != 1)
                return false;

            DomainModelElement parent = this.SelectedItems[0].Element as DomainModelElement;
            if (parent == null)
                return false;

            DomainClassInfo parentElementInfo = this.Store.DomainDataDirectory.GetDomainClass(parent.GetDomainClassId());
            List<EmbeddingRelationshipAdvancedInfo> infos = this.Store.DomainDataAdvDirectory.FindDomainClassTargetEmbeddings(domainClassType);
            if (infos != null)
                foreach (EmbeddingRelationshipAdvancedInfo info in infos)
                    if (!info.IsAbstract)
                    {
                        DomainClassInfo targetInfo = this.Store.DomainDataDirectory.GetDomainClass(info.SourceElementDomainClassId);
                        if (parentElementInfo.IsDerivedFrom(targetInfo))
                        {
                            DomainRelationshipInfo relInfo = this.Store.DomainDataDirectory.GetDomainRelationship(info.RelationshipDomainClassId);
                            DomainRoleInfo sourceRole = DomainModelElement.GetSourceDomainRole(relInfo);

                            // check that we wont violate multiplicity constraints by adding new elements
                            if (sourceRole.Multiplicity == Multiplicity.One || sourceRole.Multiplicity == Multiplicity.ZeroOne)
                                if (DomainRoleInfo.GetLinkedElement(parent, sourceRole.Id) != null)
                                    continue;

                            return true;
                        }
                    }

            return false;
        }

        /// <summary>
        /// Create new root element command can execute.
        /// </summary>
        /// <param name="param">Domain class type to be created.</param>
        /// <returns></returns>
        protected virtual bool CanCreateRootElement(DiagramContextMenuCreationHelper param)
        {
            Guid domainClassType = param.RelationshipType;
        
            if (this.SelectedItems.Count != 0)
                return false;

            List<EmbeddingRelationshipAdvancedInfo> infos = this.Store.DomainDataAdvDirectory.FindDomainClassTargetEmbeddings(domainClassType);
            if (infos != null)
                foreach (EmbeddingRelationshipAdvancedInfo info in infos)
                    if (!info.IsAbstract)
                    {
                        DomainClassInfo targetInfo = this.Store.DomainDataDirectory.GetDomainClass(info.SourceElementDomainClassId);
                        DomainRelationshipInfo relInfo = this.Store.DomainDataDirectory.GetDomainRelationship(info.RelationshipDomainClassId);
                        DomainRoleInfo sourceRole = DomainModelElement.GetSourceDomainRole(relInfo);

                        // check that we wont violate multiplicity constraints by adding new elements
                        ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(info.SourceElementDomainClassId, true);
                        if (sourceRole.Multiplicity == Multiplicity.One || sourceRole.Multiplicity == Multiplicity.ZeroOne)
                        {
                            foreach (ModelElement m in elements)
                                if (m is DomainModelElement)
                                    if (DomainRoleInfo.GetLinkedElement(m, sourceRole.Id) == null)
                                        return true;
                        }
                        else
                            return true;
                        //else if (elements.Count > 0)
                        //    return true;
                    }

            return false;
        }

        /// <summary>
        /// Verifies that there are items selected that can be deleted.
        /// </summary>
        /// <returns>True if items are selected and can be deleted; False otherwise.</returns>
        protected virtual bool OnDeleteShapesAndElementsCommandCanExecute()
        {
            bool bAllHostedOnSurface = true;
            foreach (BaseDiagramItemViewModel itemVM in this.SelectedItems)
                if (itemVM.AutomaticallyDeletesHostedElement)
                {
                    bAllHostedOnSurface = false;
                    break;
                }

            return bAllHostedOnSurface;
        }

        /// <summary>
        /// Delete selected shapes and their hosted elements.
        /// </summary>
        protected virtual void OnDeleteShapesAndElementsCommandExecuted()
        {
            DeleteShapesAndElements();
        }

        /// <summary>
        /// Verifies that there are items selected that can be deleted.
        /// </summary>
        /// <returns>True if items are selected and can be deleted; False otherwise.</returns>
        protected override bool OnDeleteCommandCanExecute()
        {
            if (this.SelectedItems.Count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Delete selected shapes (not deleting elements hosted by those shapes!).
        /// </summary>
        protected override void OnDeleteCommandExecuted()
        {
            this.Delete();
        }

        /// <summary>
        /// Copy as image command executed.
        /// </summary>
        protected virtual void OnCopyAsImageCommandExecuted()
        {
            // TODO
        }

        /// <summary>
        /// Undo command execute.
        /// </summary>
        protected override void OnUndoCommandExecuted()
        {
            base.OnUndoCommandExecuted();

            this.UpdateMenuOptions();
        }

        /// <summary>
        /// Redo command execute.
        /// </summary>
        protected override void OnRedoCommandExecuted()
        {
            base.OnRedoCommandExecuted();

            this.UpdateMenuOptions();
        }

        private void CreateRelationshipCommandExecute(ViewModelRelationshipCreationInfo info)
        {
            CreateRelationship(info);
        }
        private bool CreateRelationshipCommandCanExecute(ViewModelRelationshipCreationInfo info)
        {
            return CanCreateRelationship(info);
        }

        /// <summary>
        /// Verifies if a relationship can be created based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <returns>True if a relationship can be created. False otherwise.</returns>
        public virtual bool CanCreateRelationship(ViewModelRelationshipCreationInfo info)
        {
            return false;
        }

        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public virtual void CreateRelationship(ViewModelRelationshipCreationInfo info)
        {

        }

        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        /// <param name="shapeToCreate">Type of the relationship shape</param>
        public virtual void CreateRelationship(ViewModelRelationshipCreationInfo info, Guid shapeToCreate)
        {

        }

        /// <summary>
        /// Gets creatable relationship shapes.
        /// </summary>
        /// <param name="info">Info specifying the relationship to create.</param>
        public virtual List<SearchRSType.SearchRSTypeStruct> GetCreatableRelationships(ViewModelRelationshipCreationInfo info)
        {
            return new List<SearchRSType.SearchRSTypeStruct>();
        }
        
        /// <summary>
        /// Creates a relationship based on the given data.
        /// </summary>
        /// <typeparam name="T">Type of relationship to create.</typeparam>
        /// <param name="source">Source element.</param>
        /// <param name="target">Target element.</param>
        public virtual void CreateRelationship<T>(ModelElement source, ModelElement target)
        {
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("Create relationship"))
            {
                DomainRelationshipInfo info = this.Store.DomainDataDirectory.GetDomainRelationship(typeof(T));

                this.Store.ElementFactory.CreateElementLink(info,
                    new RoleAssignment[]{
                    new RoleAssignment(DomainModelElement.GetSourceDomainRole(info).Id, source),
                    new RoleAssignment(DomainModelElement.GetTargetDomainRole(info).Id, target),
                });
                
                t.Commit();
            }
        }

        /// <summary>
        /// Gets the ToggleOrthogonalConnectorCommand;
        /// </summary>
        public DelegateCommand ToggleOrthogonalConnectorCommand
        {
            get
            {
                return this.toggleOrthogonalConnectorCommand;
            }
        }

        /// <summary>
        /// Gets the ToggleStraightConnectorCommand;
        /// </summary>
        public DelegateCommand ToggleStraightConnectorCommand
        {
            get
            {
                return this.toggleStraightConnectorCommand;
            }
        }

        private void ToggleOrthogonalConnectorExecuted()
        {
            if (this.SelectedItems.Count == 1)
                if (this.SelectedItems[0] is BaseDiagramItemLinkViewModel)
                    (this.SelectedItems[0] as BaseDiagramItemLinkViewModel).RoutingMode = Diagrams.RoutingMode.Orthogonal;

            UpdateMenuOptions();
        }
        private void ToggleStraightConnectorExecuted()
        {
            if (this.SelectedItems.Count == 1)
                if (this.SelectedItems[0] is BaseDiagramItemLinkViewModel)
                    (this.SelectedItems[0] as BaseDiagramItemLinkViewModel).RoutingMode = Diagrams.RoutingMode.Straight;

            UpdateMenuOptions();
        }

        /// <summary>
        /// Cut command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected override bool OnCutCommandCanExecute()
        {
            return false;
            /*
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            foreach (BaseDiagramItemViewModel vm in this.SelectedItems)
                modelElements.Add(vm.ShapeElement);

            return CopyAndPasteOperations.CanExecuteMove(modelElements);
            */
        }

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected override bool OnCopyCommandCanExecute()
        {
            return false;
            /*
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            foreach(BaseDiagramItemViewModel vm in this.SelectedItems)
                modelElements.Add(vm.ShapeElement);

            if (modelElements.Count == 0)
                return false;

            return CopyAndPasteOperations.CanExecuteCopy(modelElements);
            */
        }

        /// <summary>
        /// Paste command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected override bool OnPasteCommandCanExecute()
        {
            return false;

            /*
            if (this.SelectedItems.Count > 1)
                return false;

            try
            {
                System.Windows.IDataObject idataObject = System.Windows.Clipboard.GetDataObject();
                if (this.ViewModelStore != null)
                {
                    if (this.EventManager != null)
                        CopyAndPasteOperations.ProcessMoveMode(this.EventManager, idataObject);
                }
                else
                {

                }
                if (idataObject != null)
                {
                    if (this.SelectedItems.Count == 1)
                        return CopyAndPasteOperations.CanExecutePaste(this.SelectedItems[0].ShapeElement, idataObject);
                    else
                        return CopyAndPasteOperations.CanExecutePaste(this.Diagram, idataObject);

                }
            }
            catch { }

            return false;
            */
        }

        /// <summary>
        /// Cut command execute.
        /// </summary>
        protected override void OnCutCommandExecuted()
        {
            /*
            using (new WaitCursor())
            {
                try
                {
                    Collection<ModelElement> modelElements = new Collection<ModelElement>();
                    foreach (BaseDiagramItemViewModel vm in this.SelectedItems)
                    {
                        modelElements.Add(vm.ShapeElement);
                    }
                    NodeShape.RelativeMinCopyPoint = PointD.Empty;
                    CopyAndPasteOperations.ExecuteCut(modelElements);
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }*/
        }

        /// <summary>
        /// Copy command execute.
        /// </summary>
        protected override void OnCopyCommandExecuted()
        {
            using (new WaitCursor())
            {
                try
                {
                    PointD minPosition = PointD.Empty;
                    bool bSetFirstPosition = false;

                    Collection<ModelElement> modelElements = new Collection<ModelElement>();
                    foreach (BaseDiagramItemViewModel vm in this.SelectedItems)
                    {
                        if (vm is BaseDiagramItemElementViewModel)
                        {
                            BaseDiagramItemElementViewModel itemVm = vm as BaseDiagramItemElementViewModel;
                            if (itemVm.IsRelativeChildShape)
                                continue;

                            if (!bSetFirstPosition)
                            {
                                bSetFirstPosition = true;
                                minPosition = itemVm.ShapeElement.Location;
                            }
                            else
                            {
                                if (minPosition.X > itemVm.ShapeElement.Location.X)
                                    minPosition.X = itemVm.ShapeElement.Location.X;

                                if (minPosition.Y > itemVm.ShapeElement.Location.Y)
                                    minPosition.Y = itemVm.ShapeElement.Location.Y;
                            }
                        }
                        modelElements.Add(vm.ShapeElement);
                    }
                    NodeShape.RelativeMinCopyPoint = minPosition;
                    CopyAndPasteOperations.ExecuteCopy(modelElements);
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Paste command execute.
        /// </summary>
        protected override void OnPasteCommandExecuted()
        {
            if (this.SelectedItems.Count > 1)
                return;

            using (new WaitCursor())
            {
                try
                {
                    NodeShape.RelativePastePoint = this.DiagramDesigner.GetCurrentMousePositionOnSelectedElement();

                    ValidationResult result;

                    if (this.SelectedItems.Count == 1)
                        result = CopyAndPasteOperations.ExecutePaste(this.SelectedItems[0].ShapeElement);
                    else
                        result = CopyAndPasteOperations.ExecutePaste(this.Diagram);

                    if (result != null)
                    {
                        List<BaseErrorListItemViewModel> errors = new List<BaseErrorListItemViewModel>();
                        foreach (IValidationMessage msg in result)
                        {
                            errors.Add(new StringErrorListItemViewModel(this.ViewModelStore,
                                msg.MessageId, ModelErrorListItemViewModel.ConvertCategory(msg.Type), msg.Description));
                        }

                        if (errors.Count > 0)
                        {
                            // clear error list
                            this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

                            // notify of change
                            this.EventManager.GetEvent<ErrorListAddItems>().Publish(errors);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Pasting failed: " + ex.Message);
                }
            }

            PasteCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Gets the layout command.
        /// </summary>
        public DelegateCommand LayoutCommand
        {
            get
            {
                return this.layoutCommand;
            }
        }
        private void LayoutCommand_Execute()
        {
            if (this.Children.Count > 0 && this.SelectedItems.Count == 0)
            {
                using (Transaction t = this.Store.TransactionManager.BeginTransaction("Layout Diagram", true))
                {
                    Tum.PDE.ToolFramework.Modeling.Diagrams.Layout.GleeLayouter.Layout(this.Diagram);
                    t.Commit();
                }
            }

            if (this.SelectedItems.Count == 1)
            {
                if (this.SelectedItems[0].ShapeElement is NodeShape)
                {
                    using (Transaction t = this.Store.TransactionManager.BeginTransaction("Layout Node", true))
                    {
                        Tum.PDE.ToolFramework.Modeling.Diagrams.Layout.GleeLayouter.Layout(this.SelectedItems[0].ShapeElement as NodeShape);

                        t.Commit();
                    }
                }
                else if (this.SelectedItems[0].ShapeElement is LinkShape)
                    {
                        using (Transaction t = this.Store.TransactionManager.BeginTransaction("Layout Edge", true))
                        {
                            (this.SelectedItems[0].ShapeElement as LinkShape).Layout(FixedGeometryPoints.None);
                            t.Commit();
                        }
                    }
            }
        }
        private bool LayoutCommand_CanExecute()
        {
            if (this.Children.Count > 0 && this.SelectedItems.Count == 0)
                return true;


            if (this.SelectedItems.Count == 1)
            {
                if (this.SelectedItems[0].ShapeElement is NodeShape)
                    return true;

                if (this.SelectedItems[0].ShapeElement is LinkShape)
                    return true;
            }
            return false;
        }
        #endregion

        #region Ribbon
        Fluent.RibbonContextualTabGroup contextualTG = null;

        /// <summary>
        /// Show ribbon menu.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void ShowRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            base.ShowRibbonMenu(ribbonMenu);
            if (contextualTG != null)
                contextualTG.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hide ribbon menu.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void HideRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            base.HideRibbonMenu(ribbonMenu);

            if (contextualTG != null)
                contextualTG.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Create ribbon menu.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void CreateRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            base.CreateRibbonMenu(ribbonMenu);

            foreach (Fluent.RibbonContextualTabGroup t in ribbonMenu.ContextualGroups)
                if (t.Name == "tabGroupDiagramDesigner")
                {
                    contextualTG = t;
                    return;
                }

            // add contextual items for the html editor
            contextualTG = new Fluent.RibbonContextualTabGroup();
            contextualTG.Name = "tabGroupDiagramDesigner";
            contextualTG.BorderBrush = new SolidColorBrush(Colors.Navy);
            contextualTG.Background = new SolidColorBrush(Colors.Navy);
            contextualTG.Header = "Diagram Designer";
            contextualTG.Visibility = Visibility.Collapsed;

            //System.Windows.Data.Binding visibilityBinding = new System.Windows.Data.Binding("ActiveViewModel.IsDiagramDesignerViewModelVisible");
            //visibilityBinding.Converter = new System.Windows.Controls.BooleanToVisibilityConverter();
            //visibilityBinding.Mode = System.Windows.Data.BindingMode.OneWay;
            //contextualTG.SetBinding(Fluent.RibbonContextualTabGroup.VisibilityProperty, visibilityBinding);

            // add the html editor tab item
            Fluent.RibbonTabItem tab = new Fluent.RibbonTabItem();
            tab.Group = contextualTG;
            tab.Header = "Design";

            Fluent.RibbonGroupBox commonGB = new Fluent.RibbonGroupBox();
            commonGB.Header = "Common";
            commonGB.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "Copy as Image", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/CopyAsImage-32.png", "Large", "ActiveViewModel.CopyAsImageCommand"));
            commonGB.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "Cut", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Cut-16.png", "Middle", "ActiveViewModel.CutCommand"));
            commonGB.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "Copy", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Copy-16.png", "Middle", "ActiveViewModel.CopyCommand"));
            commonGB.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "Paste", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Paste-16.png", "Middle", "ActiveViewModel.PasteCommand"));
            tab.Groups.Add(commonGB);

            Fluent.RibbonGroupBox deleGB = new Fluent.RibbonGroupBox();
            deleGB.Header = "Delete";

            Fluent.SplitButton splitButton = new Fluent.SplitButton();
            splitButton.Text = "Delete";
            splitButton.LargeIcon = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Delete-32.png", UriKind.Absolute));
            splitButton.Size = Fluent.RibbonControlSize.Large;

            System.Windows.Data.Binding cmdB = new System.Windows.Data.Binding("ActiveViewModel.DeleteCommand");
            cmdB.Mode = System.Windows.Data.BindingMode.OneWay;
            splitButton.SetBinding(Fluent.SplitButton.CommandProperty, cmdB);

            splitButton.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "  Delete Shape(s)", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Delete-16.png", "Middle", "ActiveViewModel.DeleteCommand"));
            splitButton.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "  Delete Shape(s) and Element(s)", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Delete-16.png", "Middle", "ActiveViewModel.DeleteShapesAndElementsCommand"));
            deleGB.Items.Add(splitButton);
            tab.Groups.Add(deleGB);

            Fluent.RibbonGroupBox commandsGB = new Fluent.RibbonGroupBox();
            commandsGB.Header = "Commands";
            commandsGB.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "Undo", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Undo-32.png", "Large", "ActiveViewModel.UndoCommand"));
            commandsGB.Items.Add(Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Ribbon.RibbonCreationHelper.CreateButton(
                "Redo", "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Redo-32.png", "Large", "ActiveViewModel.RedoCommand"));
            tab.Groups.Add(commandsGB);

            Fluent.RibbonGroupBox groupInsert = new Fluent.RibbonGroupBox();
            groupInsert.Header = "Insert";
            System.Windows.Controls.ContentControl c2 = new System.Windows.Controls.ContentControl();
            c2.Template = (System.Windows.Controls.ControlTemplate)ribbonMenu.FindResource("DiagramSurfaceRibbonInsertGroupBox");
            groupInsert.Items.Add(c2);
            tab.Groups.Add(groupInsert);

            ribbonMenu.Tabs.Add(tab);
            ribbonMenu.ContextualGroups.Add(contextualTG);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the included surface view models.
        /// </summary>
        public ReadOnlyCollection<DiagramSurfaceViewModel> IncludedSurfaceViewModels
        {
            get
            {
                return this.includedSurfaceViewModels.AsReadOnly();
            }
        }

        /// <summary>
        /// Adds an included diagram surface vm.
        /// </summary>
        /// <param name="vm">Included vm.</param>
        public void AddIncludedSurfaceViewModels(DiagramSurfaceViewModel vm)
        {
            this.includedSurfaceViewModels.Add(vm);
        }

        /// <summary>
        /// Gets whether this diagram surface vm instance represents an included dsvm instance.
        /// </summary>
        public bool IsIncludedModelInstance
        {
            get
            {
                return this.bIsIncludedModelInstance;
            }
            set
            {
                this.bIsIncludedModelInstance = value;
            }
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public virtual ModelContext ModelContext
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the diagram designer view.
        /// </summary>
        public IDiagramDesigner DiagramDesigner
        {
            get
            {
                if (this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                    return this.ParentDiagramSurfaceViewModel.DiagramDesigner;

                return this.diagramDesigner;
            }
            set
            {
                this.diagramDesigner = value;
            }
        }

        /// <summary>
        /// Gets or set the diagram that is hosted by this view model.
        /// </summary>
        public override Diagram Diagram
        {
            get
            {
                return base.Diagram;
            }
            set
            {
                base.Diagram = value;

                if (value != null)
                    if( this.DiagramDomainData.DiagramClassInfos.ContainsKey(GetDiagramClassType()) )
                        this.visualizationBehavior = this.DiagramDomainData.DiagramClassInfos[GetDiagramClassType()].VisualizationBehavior;

                if (!this.IsIncludedModelInstance && value != null)
                {
                    base.Diagram.IsVisible = this.IsDockingPaneVisible;

                    foreach (DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
                        if (vm.Diagram != null)
                            vm.Diagram.IsVisible = this.IsDockingPaneVisible;
                }

                Subscribe();

                FixupShapeVisibility();
                UpdateMenuOptions();
            }
        }

        /// <summary>
        /// Gets the diagram domain data.
        /// </summary>
        protected DiagramDomainDataDirectory DiagramDomainData
        {
            get
            {
                if( this.diagramDomainData == null )
                    this.diagramDomainData = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();

                return this.diagramDomainData;
            }
        }

        /// <summary>
        /// Gets the children collection.
        /// </summary>
        public ReadOnlyObservableCollection<BaseDiagramItemViewModel> Children
        {
            get
            {
                if (!this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                    return this.ParentDiagramSurfaceViewModel.Children;

                return this.childItemsRO;
            }
        }

        /// <summary>
        /// Gets the links collection
        /// </summary>
        public ReadOnlyObservableCollection<BaseDiagramItemLinkViewModel> Links
        {
            get
            {
                if (!this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                    return this.ParentDiagramSurfaceViewModel.Links;

                return this.childItemLinksRO;
            }
        }

        /// <summary>
        /// Gets the elements collection
        /// </summary>
        public ReadOnlyObservableCollection<BaseDiagramItemElementViewModel> Elements
        {
            get
            {
                if (!this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                    return this.ParentDiagramSurfaceViewModel.Elements;

                return this.childItemElementsRO;
            }
        }

        /// <summary>
        /// Context menu options.
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuOptions
        {
            get
            {
                return this.menuOptions;
            }
        }

        /// <summary>
        /// Selected items data collection. Used for binding
        /// </summary>
        public virtual Collection<object> SelectedItemsData
        {
            get
            {
                Collection<object> col = new Collection<object>();
                foreach (BaseDiagramItemViewModel m in this.SelectedItems)
                    col.Add(m);

                return col;
            }
            set
            {
                bool bDiffers = false;
                SelectedItemsCollection col = new SelectedItemsCollection();

                // propagate selection
                if (this.IsActiveView && !this.IsReseting)
                {
                    if (value != null)
                        foreach (BaseDiagramItemViewModel vm in value)
                            col.Add(vm.Element);

                    // see if we need to propagate selection --> based on what is currently selected
                    foreach (BaseDiagramItemViewModel vm in this.SelectedItems)
                    {
                        if (col.Contains(vm.Element))
                            continue;

                        bDiffers = true;
                        break;
                    }
                    if (this.SelectedItems.Count != col.Count)
                        bDiffers = true;
                }

                if (value != null)
                {
                    this.selectedItems.Clear();

                    foreach (BaseDiagramItemViewModel vm in value)
                        this.selectedItems.Add(vm);
                }
                else
                    this.selectedItems.Clear();

                // notify observers, that selection has changed
                if (bDiffers)
                    EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));

            }
        }

        /// <summary>
        /// Selected items collection.
        /// </summary>
        public Collection<BaseDiagramItemViewModel> SelectedItems
        {
            get
            {
                if (this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                    return this.ParentDiagramSurfaceViewModel.SelectedItems;

                return this.selectedItems;
            }

        }

        /// <summary>
        /// Gets the parent diagram surface vm. This will be null if IsIncludedModelInstance = false.
        /// </summary>
        public DiagramSurfaceViewModel ParentDiagramSurfaceViewModel
        {
            get;
            set;
        }

        /// <summary>
        /// Latests clicked point on the surface. This is used for adding items at the
        /// right place on the surface.
        /// </summary>
        public PointD ClickedPoint
        {
            get
            {
                if (this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                    return this.ParentDiagramSurfaceViewModel.ClickedPoint;

                return this.clickedPoint;
            }
            set
            {
                this.clickedPoint = value;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected override void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            base.ReactOnViewSelection(eventArgs);

            if (!this.IsDockingPaneVisible)
                return;

            if (!this.IsActiveView)
            {
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateDiagramSurfaceSelection));
            }
            else
            {
                UpdateDiagramSurfaceSelection();

                DeleteCommand.RaiseCanExecuteChanged();
                CutCommand.RaiseCanExecuteChanged();
                CopyCommand.RaiseCanExecuteChanged();
                PasteCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// No need to update here (would cause double updates).
        /// </summary>
        public override void UpdateCommandsCanExecute()
        {            
        }

        /// <summary>
        /// Adds a new element to this view model.
        /// </summary>
        /// <param name="elementVM">Element to add.</param>
        public virtual void AddElement(BaseDiagramItemElementViewModel elementVM)
        {
            if (this.IsReseting)
                return;

            this.childItemElements.Add(elementVM);
            this.childItems.Insert(this.childItemElements.Count - 1, elementVM);
        }

        /// <summary>
        /// Removes a element from this view model.
        /// </summary>
        /// <param name="elementVM">Element to remove.</param>
        public virtual void RemoveElement(BaseDiagramItemViewModel elementVM)
        {
            if (this.IsReseting)
                return;

            if (elementVM is BaseDiagramItemElementViewModel)
            {
                BaseDiagramItemElementViewModel vmItem = elementVM as BaseDiagramItemElementViewModel;

                for (int i = vmItem.NestedChildren.Count - 1; i >= 0; i--)
                {
                    BaseDiagramItemElementViewModel vm = vmItem.NestedChildren[i];
                    vmItem.RemoveNestedChild(vm);
                    vm.Dispose();
                }
                for (int i = vmItem.RelativeChildren.Count - 1; i >= 0; i--)
                {
                    BaseDiagramItemElementViewModel vm = vmItem.RelativeChildren[i];
                    vmItem.RemoveRelativeChild(vm);
                    vm.Dispose();
                }

                if (this.childItemElements.Contains(elementVM as BaseDiagramItemElementViewModel))
                    this.childItemElements.Remove(elementVM as BaseDiagramItemElementViewModel);
            }

            if (this.childItems.Contains(elementVM))
                this.childItems.Remove(elementVM);
        }

        /// <summary>
        /// Adds a new link to this view model.
        /// </summary>
        /// <param name="linkVM">Link to add.</param>
        public void AddLink(BaseDiagramItemLinkViewModel linkVM)
        {
            if (this.IsReseting)
                return;

            this.childItemLinks.Add(linkVM);
            this.childItems.Add(linkVM);
        }

        /// <summary>
        /// Removes all vms.
        /// </summary>
        public void Clear()
        {
            for (int i = this.childItemElements.Count - 1; i >= 0; i--)
                if (!this.childItemElements[i].IsDisposed)
                    this.childItemElements[i].Dispose();

            for (int i = this.childItemLinks.Count - 1; i >= 0; i--)
                if (!this.childItemLinks[i].IsDisposed)
                    this.childItemLinks[i].Dispose();

            this.childItemElements.Clear();
            this.childItemLinks.Clear();
            this.childItems.Clear();
        }

        /// <summary>
        /// Verifies if the given node shape is already displayed as a child of this view model.
        /// </summary>
        /// <param name="nodeShape">Node shape to find.</param>
        /// <returns>True if the given element is already displayed as a child of this view model. False otherwise</returns>
        public bool IsDisplayingNodeShape(NodeShape nodeShape)
        {
            foreach (BaseDiagramItemElementViewModel vm in this.Elements)
                if (vm.ShapeElement.Id == nodeShape.Id)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifies if the given node shape is already displayed as a child of this view model.
        /// </summary>
        /// <param name="nodeShape">Node shape to find.</param>
        /// <returns>True if the given element is already displayed as a child of this view model. False otherwise</returns>
        public bool IsDisplayingLinkShapes(LinkShape nodeShape)
        {
            foreach (BaseDiagramItemLinkViewModel vm in this.Links)
                if (vm.ShapeElement.Id == nodeShape.Id)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifies if the given element is already displayed as a child of this view model.
        /// </summary>
        /// <param name="modelElement">Element to find.</param>
        /// <returns>True if the given element is already displayed as a child of this view model. False otherwise</returns>
        public bool IsDisplayingRootElement(ModelElement modelElement)
        {
            foreach (BaseDiagramItemElementViewModel vm in this.Elements)
                if (vm.Element.Id == modelElement.Id)
                    return true;

            return false;
        }

        /// <summary>
        /// Deletes the shapes or shape+elements from the domain model depending on the selection context. If
        /// a shape that is directly hosted on the diagram surface is selected than we only delete its shape. 
        /// Otherwise we need to delete shape + element.
        /// </summary>
        public virtual void Delete()
        {
            if (this.visualizationBehavior == DiagramVisualizationBehavior.Extended)
            {
                bool bOnlyDeleteShapes = true;
                foreach (BaseDiagramItemViewModel itemVM in this.SelectedItems)
                    if (itemVM.AutomaticallyDeletesHostedElement)
                    {
                        bOnlyDeleteShapes = false;
                        break;
                    }

                if (bOnlyDeleteShapes)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete shapes"))
                    {
                        for (int i = this.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            // save layout first
                            if (this.SelectedItems[i].ShapeElement is NodeShape)
                                if ((this.SelectedItems[i].ShapeElement as NodeShape).IsTopMostItem)
                                    LayoutHelper.SaveLayout(this.SelectedItems[i].ShapeElement as NodeShape, this.Diagram);

                            this.SelectedItems[i].ShapeElement.Delete();
                        }

                        transaction.Commit();
                    }

                    if (this.IsActiveView)
                    {
                        this.SelectedItemsData = null;
                    }
                }
                else
                    this.DeleteShapesAndElements();
            }
            else
            {
                this.DeleteShapesAndElements();
            }
        }

        /// <summary>
        /// Deletes shapes and elements from the domain model.
        /// </summary>
        public virtual void DeleteShapesAndElements()
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete element"))
            {
                // delete layout (if one is found) as well
                // TODO

                for (int i = this.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if( this.SelectedItems[i].ShapeElement != null )
                        if( this.SelectedItems[i].ShapeElement.Element != null )
                            this.SelectedItems[i].ShapeElement.Element.Delete();
                }

                transaction.Commit();
            }

            if (this.IsActiveView)
            {
                this.SelectedItemsData = null;
            }
        }

        /// <summary>
        /// Updates the diagram surface, based on selectedItemsCollection.
        /// </summary>
        private void UpdateDiagramSurfaceSelection()
        {
            if (this.IsIncludedModelInstance)
                return;

            this.DeleteShapesAndElementsCommand.RaiseCanExecuteChanged();

            if (this.SelectedItemsCollection == null)
                return;

            if (this.SelectedItemsCollection.Count > 0)
            {
                foreach (ModelElement m in this.SelectedItemsCollection)
                    foreach (BaseDiagramItemViewModel vm in this.SelectedItems)
                        if (vm.Element != m)
                            vm.IsSelected = false;
            }
            else
                foreach (BaseDiagramItemViewModel vm in this.SelectedItems)
                    vm.IsSelected = false;

            Collection<BaseDiagramItemViewModel> embeddedVms = new Collection<BaseDiagramItemViewModel>();
            foreach (ModelElement m in this.SelectedItemsCollection)
                foreach (BaseDiagramItemViewModel vm in this.Children)
                {
                    if (vm.Element == m)
                        embeddedVms.Add(vm);

                    //if (vm is BaseDiagramItemElementViewModel)
                    //    (vm as BaseDiagramItemElementViewModel).GetEmbeddedItems(m, embeddedVms);
                }

            // TODO, Links...

            this.selectedItems = embeddedVms;
            foreach (BaseDiagramItemViewModel vm in this.selectedItems)
                vm.IsSelected = true;

            UpdateMenuOptions();
        }

        /// <summary>
        /// Makes sure child and link shapes are visible
        /// </summary>
        public virtual void FixupShapeVisibility()
        {
            ReadOnlyCollection<DiagramHasChildren> linksC = DiagramHasChildren.GetLinksToChildren(this.Diagram);
            foreach (DiagramHasChildren link in linksC)
                OnChildShapeElementAdded(link);

            foreach (BaseDiagramSurfaceViewModel inclVM in this.IncludedSurfaceViewModels)
            {
                linksC = DiagramHasChildren.GetLinksToChildren(inclVM.Diagram);
                foreach (DiagramHasChildren link in linksC)
                    OnChildShapeElementAdded(link);
            }

            foreach (BaseDiagramItemElementViewModel vm in this.childItemElements)
                vm.FixupShapeVisibility();

            ReadOnlyCollection<DiagramHasLinkShapes> linksL = DiagramHasLinkShapes.GetLinksToLinkShapes(this.Diagram);
            foreach (DiagramHasLinkShapes link in linksL)
                OnLinkShapeElementAdded(link);

            foreach (BaseDiagramSurfaceViewModel inclVM in this.IncludedSurfaceViewModels)
            {
                linksL = DiagramHasLinkShapes.GetLinksToLinkShapes(inclVM.Diagram);
                foreach (DiagramHasLinkShapes link in linksL)
                    OnLinkShapeElementAdded(link);
            }
        }
        #endregion

        #region Context Menu Methods
        /// <summary>
        /// Context menu creation helper class.
        /// </summary>
        public class DiagramContextMenuCreationHelper
        {
            /// <summary>
            /// Role player info.
            /// </summary>
            public Guid RelationshipType;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="rType"></param>
            public DiagramContextMenuCreationHelper(Guid rType)
            {
                RelationshipType = rType;
            }
        }

        /// <summary>
        /// Context menu creation helper class.
        /// </summary>
        public class DiagramRSContextMenuCreationHelper: DiagramContextMenuCreationHelper
        {
            /// <summary>
            /// Role player info.
            /// </summary>
            public Guid SourceElementId;

            /// <summary>
            /// Role player info.
            /// </summary>
            public Guid TargetElementId;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="rType"></param>
            /// <param name="sourceId"></param>
            /// <param name="targetId"></param>
            public DiagramRSContextMenuCreationHelper(Guid rType, Guid sourceId, Guid targetId)
                : base(rType)
            {
                this.SourceElementId = sourceId;
                this.TargetElementId = targetId;
            }
        }

        /// <summary>
        /// Creates the menu options based on the current context.
        /// </summary>
        public virtual void UpdateMenuOptions()
        {
            if (this.IsIncludedModelInstance && this.ParentDiagramSurfaceViewModel != null)
                this.ParentDiagramSurfaceViewModel.UpdateMenuOptions();

            MenuOptions.Clear();

            MenuItemViewModel menuItemAdd = new MenuItemViewModel(this.ViewModelStore);
            menuItemAdd.Text = "Add";
            menuItemAdd.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Add-16.png";

            InsertableElements.Clear();
            foreach (MenuItemViewModel<DiagramContextMenuCreationHelper> item in UpdateInsertableItems())
            {
                menuItemAdd.Children.Add(item);
                InsertableElements.Add(item);
            }

            if (menuItemAdd.Children.Count > 0)
                MenuOptions.Add(menuItemAdd);

            if (this.SelectedItems.Count > 0)
            {
                if (this.SelectedItems.Count == 1)
                    if (this.SelectedItems[0] is BaseDiagramItemLinkViewModel)
                    {
                        if (MenuOptions.Count > 0)
                            MenuOptions.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));

                        BaseDiagramItemLinkViewModel linkVM = this.SelectedItems[0] as BaseDiagramItemLinkViewModel;

                        MenuItemViewModel menuItemStraightRA = new MenuItemViewModel(this.ViewModelStore);
                        menuItemStraightRA.Text = "Right-Angle Connector";
                        menuItemStraightRA.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/ConnectorOrtho.png";
                        menuItemStraightRA.Command = this.ToggleOrthogonalConnectorCommand;
                        menuItemStraightRA.IsEnabled = !(linkVM.RoutingMode == RoutingMode.Orthogonal);
                        MenuOptions.Add(menuItemStraightRA);

                        MenuItemViewModel menuItemStraightC = new MenuItemViewModel(this.ViewModelStore);
                        menuItemStraightC.Text = "Straight Connector";
                        menuItemStraightC.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/ConnectorStraight.png";
                        menuItemStraightC.Command = this.ToggleStraightConnectorCommand;
                        menuItemStraightC.IsEnabled = !(linkVM.RoutingMode == RoutingMode.Straight);
                        MenuOptions.Add(menuItemStraightC);
                    }
            }


                if ((this.Children.Count > 0 && this.SelectedItems.Count == 0) || this.SelectedItems.Count == 1)
                {
                    if (MenuOptions.Count > 0)
                        MenuOptions.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));

                    MenuItemViewModel menuItemLayout = new MenuItemViewModel(this.ViewModelStore);
                    menuItemLayout.Text = "Layout";
                    //menuItemLayout.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Delete2-16.png";
                    menuItemLayout.Command = LayoutCommand;
                    MenuOptions.Add(menuItemLayout);
                }
                
            if (this.SelectedItems.Count > 0)
            {
                bool bAllHostedOnSurface = true;
                if (this.visualizationBehavior == DiagramVisualizationBehavior.Normal)
                    bAllHostedOnSurface = false;
                if( bAllHostedOnSurface )
                foreach (BaseDiagramItemViewModel itemVM in this.SelectedItems)
                    if (itemVM.AutomaticallyDeletesHostedElement)
                    {
                        bAllHostedOnSurface = false;
                        break;
                    }

                if (MenuOptions.Count > 0)
                    MenuOptions.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));

                if (bAllHostedOnSurface)
                {
                    MenuItemViewModel menuItemDelete = new MenuItemViewModel(this.ViewModelStore);
                    menuItemDelete.Text = "Delete";
                    menuItemDelete.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Delete2-16.png";
                    MenuItemViewModel itemDeleteShapes = new MenuItemViewModel(this.ViewModelStore);
                    itemDeleteShapes.Text = "Delete Shape(s)";
                    itemDeleteShapes.Command = DeleteCommand;
                    menuItemDelete.Children.Add(itemDeleteShapes);

                    MenuItemViewModel itemDeleteShapesAndElements = new MenuItemViewModel(this.ViewModelStore);
                    itemDeleteShapesAndElements.Text = "Delete Shape(s) and Element(s)";
                    itemDeleteShapesAndElements.Command = DeleteShapesAndElementsCommand;
                    menuItemDelete.Children.Add(itemDeleteShapesAndElements);

                    MenuOptions.Add(menuItemDelete);
                }
                else
                {
                    MenuItemViewModel menuItemDelete = new MenuItemViewModel(this.ViewModelStore);
                    menuItemDelete.Text = "Delete";
                    menuItemDelete.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Delete2-16.png";
                    menuItemDelete.Command = DeleteCommand;
                    MenuOptions.Add(menuItemDelete);
                }
            }
        }

        /// <summary>
        /// Verifies if a given element can be inserted as a root item.
        /// </summary>
        /// <param name="element">Element to be inserted</param>
        /// <returns>True if the element can be inserted; False otherwise.</returns>
        public virtual bool IsInsertableRootItem(DomainModelElement element)
        {
            List<Guid> shapeTypes = this.DiagramDomainData.GetShapeTypesForElement(element.GetDomainClassId());
            foreach (Guid shapeType in shapeTypes)
                if (this.DiagramDomainData.ShapeClassInfos[shapeType].DiagramClassType == this.GetDiagramClassType() &&
                    this.DiagramDomainData.ShapeClassInfos[shapeType].ParentShapeClassType == null)
                    return true;

            foreach (DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
            {
                if (vm.IsInsertableRootItem(element))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the insertable elements collection if no element is selected.
        /// </summary>
        public virtual List<MenuItemViewModel<DiagramContextMenuCreationHelper>> UpdateInsertableRootItems()
        {
            List<MenuItemViewModel<DiagramContextMenuCreationHelper>> items = new List<MenuItemViewModel<DiagramContextMenuCreationHelper>>();

            List<Guid> childShapes = this.DiagramDomainData.GetDiagramRootChildrenShapeTypes(this.GetDiagramClassType());            
            if( childShapes != null )
                foreach (Guid child in childShapes)
                {
                    ShapeClassInfo info = this.DiagramDomainData.ShapeClassInfos[child];
                    if (!CanCreateRootElement(new DiagramContextMenuCreationHelper(info.DomainClassType)))
                        continue;

                    DomainClassInfo domainClassInfo = this.Store.DomainDataDirectory.GetDomainClass(info.DomainClassType);
                    DomainClassAdvancedInfo advInfo = this.Store.DomainDataAdvDirectory.GetClassInfo(domainClassInfo.Id);
                    if (advInfo.IsAbstract)
                        continue;

                    MenuItemViewModel<DiagramContextMenuCreationHelper> item = new MenuItemViewModel<DiagramContextMenuCreationHelper>(this.ViewModelStore);
                    item.Text = "Add new " + domainClassInfo.DisplayName;
                    item.Command = new DelegateCommand<DiagramContextMenuCreationHelper>(CreateNewElementCommandExecute);
                    item.CommandParameter = new DiagramContextMenuCreationHelper(info.DomainClassType);
                    if( !String.IsNullOrEmpty(info.IconURL) )
                        item.IconUrl = info.IconURL;
                    items.Add(item);

                }

            foreach (DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
                items.AddRange(vm.UpdateInsertableRootItems());

            return items;
        }

        /// <summary>
        /// Updates the insertable elements collection.
        /// </summary>
        public virtual List<MenuItemViewModel<DiagramContextMenuCreationHelper>> UpdateInsertableItems()
        {
            if (this.SelectedItems.Count == 0)
                return UpdateInsertableRootItems();
            else if (this.SelectedItems.Count == 1)
            {
                if (this.SelectedItems[0].ShapeElement is NodeShape)
                    return UpdateInsertableChildItems(this.SelectedItems[0].ShapeElement);
            }
            else if (this.SelectedItems.Count == 2)
            {
                if( this.SelectedItems[0] is BaseDiagramItemElementViewModel && this.SelectedItems[1] is BaseDiagramItemElementViewModel )
                    if (this.SelectedItems[0].ShapeElement is NodeShape && this.SelectedItems[1].ShapeElement is NodeShape)
                    {
                        return this.UpdateCreatableRelationships(this.SelectedItems[0] as BaseDiagramItemElementViewModel, this.SelectedItems[1] as BaseDiagramItemElementViewModel);
                    }
            }

            return new System.Collections.Generic.List<MenuItemViewModel<DiagramContextMenuCreationHelper>>();
        }

        /// <summary>
        /// Updates the insertable child elements collection.
        /// </summary>
        /// <param name="selectedShape">Selected shape.</param>
        public virtual List<MenuItemViewModel<DiagramContextMenuCreationHelper>> UpdateInsertableChildItems(ShapeElement selectedShape)
        {
            List<MenuItemViewModel<DiagramContextMenuCreationHelper>> items = new List<MenuItemViewModel<DiagramContextMenuCreationHelper>>();

            List<Guid> childShapes = this.DiagramDomainData.GetChildrenShapeTypes(selectedShape.GetDomainClassId());
            if (childShapes != null)
                foreach (Guid child in childShapes)
                {
                    ShapeClassInfo info = this.DiagramDomainData.ShapeClassInfos[child];
                    if (!CreateNewElementCommandCanExecute(new DiagramContextMenuCreationHelper(info.DomainClassType)))
                        continue;
                    
                    DomainClassInfo domainClassInfo = this.Store.DomainDataDirectory.GetDomainClass(info.DomainClassType);
                    DomainClassAdvancedInfo advInfo = this.Store.DomainDataAdvDirectory.GetClassInfo(domainClassInfo.Id);
                    if (advInfo.IsAbstract)
                        continue;

                    MenuItemViewModel<DiagramContextMenuCreationHelper> item = new MenuItemViewModel<DiagramContextMenuCreationHelper>(this.ViewModelStore);
                    item.Text = "Add new " + domainClassInfo.DisplayName;
                    item.Command = new DelegateCommand<DiagramContextMenuCreationHelper>(CreateNewElementCommandExecute);
                    item.CommandParameter = new DiagramContextMenuCreationHelper(info.DomainClassType);
                    if (!String.IsNullOrEmpty(info.IconURL))
                        item.IconUrl = info.IconURL;
                    items.Add(item);

                }

            return items;
        }

        /// <summary>
        /// Updates the creatable relationships between the specified elements.
        /// </summary>
        /// <param name="element1">Element 1.</param>
        /// <param name="element2">Element 2.</param>
        public virtual List<MenuItemViewModel<DiagramContextMenuCreationHelper>> UpdateCreatableRelationships(BaseDiagramItemElementViewModel element1, BaseDiagramItemElementViewModel element2)
        {
            List<MenuItemViewModel<DiagramContextMenuCreationHelper>> list = new List<MenuItemViewModel<DiagramContextMenuCreationHelper>>();

            ViewModelRelationshipCreationInfo info1 = new ViewModelRelationshipCreationInfo(element1, element2);
            List<SearchRSType.SearchRSTypeStruct> rsList1 = this.GetCreatableRelationships(info1);

            List<Guid> addedGuids = new List<Guid>();
            foreach (SearchRSType.SearchRSTypeStruct s in rsList1)
            {
                if (addedGuids.Contains(s.DomainClassId))
                    continue;

                addedGuids.Add(s.DomainClassId);

                MenuItemViewModel<DiagramContextMenuCreationHelper> item = new MenuItemViewModel<DiagramContextMenuCreationHelper>(this.ViewModelStore);
                item.Text = s.FullName;
                item.Command = new DelegateCommand<DiagramContextMenuCreationHelper>(CreateNewRelationshipCommandExecute);
                item.CommandParameter = new DiagramRSContextMenuCreationHelper(s.DomainClassId, element1.Id, element2.Id);
                list.Add(item);
            }


            ViewModelRelationshipCreationInfo info2 = new ViewModelRelationshipCreationInfo(element2, element1);
            List<SearchRSType.SearchRSTypeStruct> rsList2 = this.GetCreatableRelationships(info2);
            foreach (SearchRSType.SearchRSTypeStruct s in rsList2)
            {
                if (addedGuids.Contains(s.DomainClassId))
                    continue;

                addedGuids.Add(s.DomainClassId);

                MenuItemViewModel<DiagramContextMenuCreationHelper> item = new MenuItemViewModel<DiagramContextMenuCreationHelper>(this.ViewModelStore);
                item.Text = s.FullName;
                item.Command = new DelegateCommand<DiagramContextMenuCreationHelper>(CreateNewRelationshipCommandExecute);
                item.CommandParameter = new DiagramRSContextMenuCreationHelper(s.DomainClassId, element2.Id, element1.Id);
                list.Add(item);
            }

            return list;
        }

        #endregion

        #region IDiagramViewModel

        /// <summary>
        /// Calculates the movement info for this item based on the proposed horizontal and vertical changes.
        /// </summary>
        /// <param name="selectedItems">Items to be resized.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        /// <returns>Calculated DiagramItemMovementInfo.</returns>
        public virtual DiagramItemsMovementInfo CalcMovementInfo(IEnumerable<IDiagramItemViewModel> selectedItems, double horizontalChange, double verticalChange)
        {
            DiagramItemsMovementInfo info = new DiagramItemsMovementInfo();

            double minLeft = double.MaxValue;
            double minTop = double.MaxValue;

            foreach (IDiagramItemViewModel vm in selectedItems)
            {
                if (vm.IsRelativeChildShape)
                    continue;       // we dont care about relative children positions at this point

                minLeft = Math.Min(vm.Left, minLeft);
                minTop = Math.Min(vm.Top, minTop);
            }

            info.HorizontalChange = Math.Max(-minLeft, horizontalChange);
            info.VerticalChange = Math.Max(-minTop, verticalChange);

            return info;
        }

        /// <summary>
        /// Calculates the resize info for this item based on the proposed horizontal and vertical changes.
        /// </summary>
        /// <param name="selectedItems">Items to be resized.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        /// <param name="direction">Direction in which to resize the elements.</param>
        /// <returns>Calculated DiagramItemsResizeInfo.</returns>
        public virtual DiagramItemsResizeInfo CalcResizeInfo(IEnumerable<IDiagramItemViewModel> selectedItems, double horizontalChange, double verticalChange, DiagramItemsResizeDirection direction)
        {
            DiagramItemsResizeInfo info = new DiagramItemsResizeInfo();
            info.WidthChange = double.MaxValue;
            info.HeightChange = double.MaxValue;
            info.LeftChange = double.MaxValue;
            info.TopChange = double.MaxValue;

            // calculate values
            double minLeft = double.MaxValue;
            double minTop = double.MaxValue;

            double minDeltaHorizontal = double.MaxValue;
            double minDeltaVertical = double.MaxValue;
            double maxDeltaHorizontal = double.MaxValue;
            double maxDeltaVertical = double.MaxValue;

            // calculate min and max value for each parameter for each item
            foreach (IDiagramItemViewModel designerItem in selectedItems)
            {
                if (designerItem.ResizingBehaviour == ShapeResizingBehaviour.Fixed)
                    continue;

                minLeft = Math.Min(designerItem.Left, minLeft);
                minTop = Math.Min(designerItem.Top, minTop);

                minDeltaVertical = Math.Min(minDeltaVertical, designerItem.Height - 12);
                minDeltaHorizontal = Math.Min(minDeltaHorizontal, designerItem.Width - 12);

                foreach (IDiagramItemViewModel relativeChild in designerItem.GetRelativeChildren())
                {
                    if (relativeChild.MovementBehaviour != ShapeMovementBehaviour.PositionOnEdgeOfParent)
                        continue;

                    // depending on the side of the item, we need to recalculate maxDeltaVertical and maxDeltaHorizontal
                    if (relativeChild.GetPlacementSide() == PortPlacement.Bottom ||
                        relativeChild.GetPlacementSide() == PortPlacement.Top)
                        maxDeltaHorizontal = Math.Min(maxDeltaHorizontal, designerItem.Width - (relativeChild.Left + relativeChild.Width));

                    if (relativeChild.GetPlacementSide() == PortPlacement.Right ||
                        relativeChild.GetPlacementSide() == PortPlacement.Left)
                        maxDeltaVertical = Math.Min(maxDeltaVertical, designerItem.Height - (relativeChild.Top + relativeChild.Height));
                }

                foreach (IDiagramItemViewModel nestedChild in designerItem.GetNestedChildren())
                {
                    maxDeltaHorizontal = Math.Min(maxDeltaHorizontal, designerItem.Size.Width - (nestedChild.Left + nestedChild.Width));
                    maxDeltaVertical = Math.Min(maxDeltaVertical, designerItem.Size.Height - (nestedChild.Top + nestedChild.Height));
                }
            }

            // apply changes 
            foreach (IDiagramItemViewModel designerItem in selectedItems)
            {
                // see what changes are allowed
                bool canResizeVertically = true;
                bool canResizeHorizontally = true;

                if (designerItem.ResizingBehaviour == Diagrams.ShapeResizingBehaviour.Fixed)
                    continue;
                else
                {
                    canResizeVertically = designerItem.ResizingBehaviour != Diagrams.ShapeResizingBehaviour.FixedHeight;
                    canResizeHorizontally = designerItem.ResizingBehaviour != Diagrams.ShapeResizingBehaviour.FixedWidth;
                }

                // apply changes
                SizeD itemSize = designerItem.Size;
                PointD itemLocation = designerItem.Location;

                double dragDeltaVertical, dragDeltaHorizontal, scale;
                if (canResizeVertically)
                    switch (direction)
                    {
                        case DiagramItemsResizeDirection.Bottom:
                        case DiagramItemsResizeDirection.LeftBottom:
                        case DiagramItemsResizeDirection.RightBottom:
                            dragDeltaVertical = Math.Min(-verticalChange, minDeltaVertical);
                            dragDeltaVertical = Math.Min(dragDeltaVertical, maxDeltaVertical);
                            scale = (designerItem.Height - dragDeltaVertical) / designerItem.Height;

                            itemSize.Height = designerItem.Height * scale;
                            break;
                        case DiagramItemsResizeDirection.Top:
                        case DiagramItemsResizeDirection.LeftTop:
                        case DiagramItemsResizeDirection.RightTop:
                            double top = designerItem.Top;
                            dragDeltaVertical = Math.Min(Math.Max(-minTop, verticalChange), minDeltaVertical);
                            dragDeltaVertical = Math.Min(dragDeltaVertical, maxDeltaVertical);
                            scale = (designerItem.Height - dragDeltaVertical) / designerItem.Height;

                            itemLocation.Y = top - (designerItem.Height) * (scale - 1);
                            itemSize.Height = designerItem.Height * scale;
                            break;
                        default:
                            break;
                    }

                if (canResizeHorizontally)
                    switch (direction)
                    {
                        case DiagramItemsResizeDirection.Left:
                        case DiagramItemsResizeDirection.LeftBottom:
                        case DiagramItemsResizeDirection.LeftTop:
                            double left = designerItem.Left;
                            dragDeltaHorizontal = Math.Min(Math.Max(-minLeft, horizontalChange), minDeltaHorizontal);
                            dragDeltaHorizontal = Math.Min(dragDeltaHorizontal, maxDeltaHorizontal);
                            scale = (designerItem.Width - dragDeltaHorizontal) / designerItem.Width;


                            itemLocation.X = left - (designerItem.Width) * (scale - 1);
                            itemSize.Width = designerItem.Width * scale;
                            break;
                        case DiagramItemsResizeDirection.Right:
                        case DiagramItemsResizeDirection.RightBottom:
                        case DiagramItemsResizeDirection.RightTop:
                            dragDeltaHorizontal = Math.Min(-horizontalChange, minDeltaHorizontal);
                            dragDeltaHorizontal = Math.Min(dragDeltaHorizontal, maxDeltaHorizontal);
                            scale = (designerItem.Width - dragDeltaHorizontal) / designerItem.Width;

                            itemSize.Width = designerItem.Width * scale;
                            break;
                        default:
                            break;
                    }

                info.WidthChange = Math.Min(info.WidthChange, itemSize.Width - designerItem.Width);
                info.HeightChange = Math.Min(info.HeightChange, itemSize.Height - designerItem.Height);
                info.LeftChange = Math.Min(info.LeftChange, itemLocation.X - designerItem.Left);
                info.TopChange = Math.Min(info.TopChange, itemLocation.Y - designerItem.Top);
            }

            return info;
        }

        /// <summary>
        /// Moves the selected link anchors in the direction of the proposed location.
        /// </summary>
        /// <param name="selectedItems">Selected links (source or target anchor to be move specified via bool) to move.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        public virtual void MoveLinkAnchors(Dictionary<IDiagramLinkViewModel, bool> selectedItems, double horizontalChange, double verticalChange)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move Link Anchors"))
            {
                foreach (IDiagramLinkViewModel item in selectedItems.Keys)
                {
                    if (selectedItems[item])
                        item.SetFromAnchorPosition(horizontalChange, verticalChange);
                    else
                        item.SetToAnchorPosition(horizontalChange, verticalChange);
                }
                transaction.Commit();
            }
        }

        /// <summary>
        /// Moves the selected link anchors in the direction of the proposed location.
        /// </summary>
        /// <param name="selectedItem">Selected link.</param>
        /// <param name="anchorId">Anchor id.</param>
        /// <param name="horizontalChange">Proposed horizontal change.</param>
        /// <param name="verticalChange">Proposed vertical change.</param>
        public virtual void MoveLinkAnchor(IDiagramLinkViewModel selectedItem, Guid anchorId, double horizontalChange, double verticalChange)
        {
            if (selectedItem == null)
                return;

            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move Link Anchors"))
            {
                selectedItem.SetAnchorPosition(anchorId, horizontalChange, verticalChange);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Moves the selected elements as specified by the given movement info.
        /// </summary>
        /// <param name="selectedItems">Selected items to move.</param>
        /// <param name="info">Movement info.</param>
        public virtual void MoveElements(IEnumerable<IDiagramItemViewModel> selectedItems, DiagramItemsMovementInfo info)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move Elements"))
            {
                foreach (IDiagramItemViewModel vm in selectedItems)
                {
                    double left = vm.Left + info.HorizontalChange;
                    double top = vm.Top + info.VerticalChange;
                    vm.Location = new PointD(left, top);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Resizes the selected elements a specified by the given resize info.
        /// </summary>
        /// <param name="selectedItems">Selected items to resize.</param>
        /// <param name="info">Resize info.</param>
        public virtual void ResizeElements(IEnumerable<IDiagramItemViewModel> selectedItems, DiagramItemsResizeInfo info)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Resize Elements"))
            {
                foreach (IDiagramItemViewModel vm in selectedItems)
                {
                    double left = vm.Left + info.LeftChange;
                    double top = vm.Top + info.TopChange;
                    double width = vm.Width + info.WidthChange;
                    double height = vm.Height + info.HeightChange;

                    vm.Bounds = new RectangleD(left, top, width, height);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Calculates a path geometry between the source and the target points.
        /// </summary>
        /// <param name="sourcePoint">Source point (Absolute location).</param>
        /// <param name="targetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <returns>Calculated path geometry.</returns>
        public virtual PathGeometry CalcPathGeometry(PointD sourcePoint, PointD targetPoint, FixedGeometryPoints fixedPoints)
        {
            List<PointD> edgePoints = this.Diagram.CalcPath(sourcePoint, targetPoint, fixedPoints);
            if (edgePoints.Count == 0)
                return null;

            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = edgePoints[0].ToPoint(); ;

            List<Point> points = new List<Point>();
            foreach (PointD p in edgePoints)
                points.Add(p.ToPoint());

            figure.Segments.Add(new PolyLineSegment(points, true));
            geometry.Figures.Add(figure);

            return geometry;
        }

        /// <summary>
        /// Calculates a path geometry between the source and the target point. 
        /// </summary>
        /// <param name="proposedSourcePoint">Source point (Absolute location).</param>
        /// <param name="targetItem">Target diagram item.</param>
        /// <param name="proposedTargetPoint">Target point (Absolute location).</param>
        /// <param name="fixedPoints">Fixed points.</param>
        /// <returns>Calculated path geometry.</returns>
        public virtual PathGeometry CalcPathGeometry(PointD proposedSourcePoint, IDiagramItemViewModel targetItem, PointD proposedTargetPoint, FixedGeometryPoints fixedPoints)
        {
            List<PointD> edgePoints = this.Diagram.CalcPath(proposedSourcePoint, targetItem.ShapeElement, proposedTargetPoint, fixedPoints);
            if (edgePoints.Count == 0)
                return null;

            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = edgePoints[0].ToPoint(); ;

            List<Point> points = new List<Point>();
            foreach (PointD p in edgePoints)
                points.Add(p.ToPoint());

            figure.Segments.Add(new PolyLineSegment(points, true));
            geometry.Figures.Add(figure);

            return geometry;
        }

        /// <summary>
        /// Handles a key down event.
        /// </summary>
        /// <param name="e">Key down event args.</param>
        /// <returns>True if the key down event was handled.</returns>
        public virtual bool HandleKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move Elements up"))
                {
                    foreach (object vmItem in selectedItems)
                    {
                        if (!(vmItem is IDiagramItemViewModel))
                            continue;

                        IDiagramItemViewModel vm = vmItem as IDiagramItemViewModel;

                        double left = vm.Left;
                        double top = vm.Top;

                        if (e.Key == Key.Up && top - MovementUnit > 0)
                            top -= MovementUnit;

                        if (e.Key == Key.Down)
                            top += MovementUnit;

                        if (e.Key == Key.Left && left - MovementUnit > 0)
                            left -= MovementUnit;

                        if (e.Key == Key.Right)
                            left += MovementUnit;

                        vm.Location = new PointD(left, top);
                    }

                    transaction.Commit();
                }

                return true;
            }

            return false;
        }
        #endregion

        #region Model Element events subscription and unsubscription + handlers
        /// <summary>
        /// Subscribes to events for the current hosted diagram.
        /// </summary>
        protected virtual void Subscribe()
        {
            if (IsIncludedModelInstance)
                return;

            Subscribe(this);
        }

        /// <summary>
        /// Subscribes to events for the current hosted diagram.
        /// </summary>
        /// <param name="diagVM"></param>
        public virtual void Subscribe(DiagramSurfaceViewModel diagVM)
        {
            if (this.Diagram != null)
            {
                // subscribe to add element events
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasChildren.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementAddedEventArgs>(diagVM.OnChildShapeElementAdded));

                // subscribe to add links events
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasLinkShapes.DomainClassId),
                                true, this.Diagram.Id, new Action<ElementAddedEventArgs>(diagVM.OnLinkShapeElementAdded));

                // subscribe to remove element events
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasChildren.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementDeletedEventArgs>(diagVM.OnChildShapeElementRemoved));

                // subscribe to remove links events
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasLinkShapes.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementDeletedEventArgs>(diagVM.OnLinkShapeElementRemoved));
            }

            foreach (DiagramSurfaceViewModel incD in this.IncludedSurfaceViewModels)
                incD.Subscribe(diagVM);
        }

        /// <summary>
        /// Unsubscribes from events for the current hosted diagram.
        /// </summary>
        protected virtual void Unsubscribe()
        {
            if (IsIncludedModelInstance)
                return;

            Unsubscribe(this);
        }

        /// <summary>
        /// Unsubscribes from events for the current hosted diagram.
        /// </summary>
        /// <param name="diagVM"></param>
        public virtual void Unsubscribe(DiagramSurfaceViewModel diagVM)
        {
            if (this.Diagram != null)
            {
                // unsubscribe from add element events
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasChildren.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementAddedEventArgs>(diagVM.OnChildShapeElementAdded));

                // unsubscribe from add links events
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasLinkShapes.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementAddedEventArgs>(diagVM.OnLinkShapeElementAdded));

                // unsubscribe from remove element events
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasChildren.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementDeletedEventArgs>(diagVM.OnChildShapeElementRemoved));

                // unsubscribe from remove links events
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DiagramHasLinkShapes.DomainClassId),
                    true, this.Diagram.Id, new Action<ElementDeletedEventArgs>(diagVM.OnLinkShapeElementRemoved));
            }

            foreach (DiagramSurfaceViewModel incD in this.IncludedSurfaceViewModels)
                incD.Unsubscribe(diagVM);
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnChildShapeElementAdded(ElementAddedEventArgs args)
        {
            OnChildShapeElementAdded(args.ModelElement as DiagramHasChildren);
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        protected virtual void OnChildShapeElementAdded(DiagramHasChildren con)
        {
            if (con.Diagram == this.Diagram)
                OnChildShapeElementAdded(con, this);

            foreach (DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
                if (con.Diagram == vm.Diagram)
                    vm.OnChildShapeElementAdded(con, this);
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="diagVm"></param>
        public virtual void OnChildShapeElementAdded(DiagramHasChildren con, DiagramSurfaceViewModel diagVm)
        {
            if (IsDisplayingNodeShape(con.ChildShape))
                return;

            DiagramItemElementViewModel itemVM = this.ViewModelStore.TopMostStore.Factory.CreateDiagramItemViewModel(con.ChildShape.GetDomainClassId(), diagVm, con.ChildShape);
            if (itemVM == null)
                throw new ArgumentNullException("Node shape vm can not be null for " + con.ChildShape.ToString());

            diagVm.AddElement(itemVM);
            itemVM.FixupShapeVisibility();
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasLinkShapes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnLinkShapeElementAdded(ElementAddedEventArgs args)
        {
            OnLinkShapeElementAdded(args.ModelElement as DiagramHasLinkShapes);
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasLinkShapes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        protected virtual void OnLinkShapeElementAdded(DiagramHasLinkShapes con)
        {
            if (con.Diagram == this.Diagram)
                OnLinkShapeElementAdded(con, this);

            foreach (DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
                if (con.Diagram == vm.Diagram)
                    vm.OnLinkShapeElementAdded(con, this);
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasLinkShapes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="diagVm"></param>
        public virtual void OnLinkShapeElementAdded(DiagramHasLinkShapes con, DiagramSurfaceViewModel diagVm)
        {
            if (IsDisplayingLinkShapes(con.LinkShape))
                return;

            LinkShape linkShape = con.LinkShape;
            BaseDiagramItemLinkViewModel linkVM = this.ViewModelStore.TopMostStore.Factory.CreateDiagramLinkViewModel(linkShape.GetDomainClassId(), diagVm, linkShape);
            if (linkVM == null)
                throw new ArgumentNullException("Link shape vm can not be null for " + linkShape.ToString());

            diagVm.AddLink(linkVM);
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasChildren is removed and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnChildShapeElementRemoved(ElementDeletedEventArgs args)
        {
            DiagramHasChildren con = args.ModelElement as DiagramHasChildren;
            NodeShape nodeShape = con.ChildShape;
            if (nodeShape != null)
            {
                for (int i = this.childItemElements.Count - 1; i >= 0; i--)
                {
                    if (this.childItemElements[i].ShapeElement.Id == nodeShape.Id)
                    {

                        if (this.childItems.Contains(this.childItemElements[i]))
                            this.childItems.Remove(this.childItemElements[i]);

                        this.childItemElements[i].Dispose();
                        this.childItemElements.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasLinkShapes is removed and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnLinkShapeElementRemoved(ElementDeletedEventArgs args)
        {
            DiagramHasLinkShapes con = args.ModelElement as DiagramHasLinkShapes;
            LinkShape linkShape = con.LinkShape;
            if (linkShape != null)
            {
                for (int i = this.childItemLinks.Count - 1; i >= 0; i--)
                {
                    if (this.childItemLinks[i].ShapeElement.Id == linkShape.Id)
                    {
                        if (this.childItems.Contains(this.childItemLinks[i]))
                            this.childItems.Remove(this.childItemLinks[i]);

                        this.childItemLinks[i].Dispose();
                        this.childItemLinks.RemoveAt(i);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Gets the diagram class type.
        /// </summary>
        /// <returns></returns>
        public abstract Guid GetDiagramClassType();

        /// <summary>
        /// Tries to embed an element as the child of the selected element.
        /// </summary>
        /// <param name="modelElement">Model element to embed.</param>
        /// <returns>Parent model element the child was embedded at on success. Null otherwise.</returns>
        public virtual DomainModelElement EmbedElement(DomainModelElement modelElement)
        {
            return this.EmbedElement(modelElement, false);
        }

        /// <summary>
        /// Tries to embed an element as the child of the selected element.
        /// </summary>
        /// <param name="modelElement">Model element to embed.</param>
        /// <param name="bForceTopMostInsertion">True if the current selection should be ignored.</param>
        /// <returns>Parent model element the child was embedded at on success. Null otherwise.</returns>
        public virtual DomainModelElement EmbedElement(DomainModelElement modelElement, bool bForceTopMostInsertion)
        {
            if (this.SelectedItems.Count > 1 && !bForceTopMostInsertion)
                return null;

            // select where to embed the element and using what kind of relationship
            // usually this code will not be relevant, because in most cases
            // there allways will only be one parent element and one embedding
            // relationship type
            DomainModelElement parent = null;
            Guid relationshipType = Guid.Empty;
            List<SearchElementWithRSType.SearchElementWithRSTypeStruct> possibleParents = new List<SearchElementWithRSType.SearchElementWithRSTypeStruct>();

            if (this.SelectedItems.Count == 1 && !bForceTopMostInsertion)
            {
                parent = this.SelectedItems[0].Element as DomainModelElement;
                if (parent == null)
                    return null;

                DomainClassInfo parentElementInfo = this.Store.DomainDataDirectory.GetDomainClass(parent.GetDomainClassId());
                List<EmbeddingRelationshipAdvancedInfo> infos = this.Store.DomainDataAdvDirectory.FindDomainClassTargetEmbeddings(modelElement.GetDomainClassId());
                if (infos != null)
                    foreach (EmbeddingRelationshipAdvancedInfo info in infos)
                        if (!info.IsAbstract)
                        {
                            DomainClassInfo targetInfo = this.Store.DomainDataDirectory.GetDomainClass(info.SourceElementDomainClassId);
                            if (parentElementInfo.IsDerivedFrom(targetInfo))
                            {
                                DomainRelationshipInfo relInfo = this.Store.DomainDataDirectory.GetDomainRelationship(info.RelationshipDomainClassId);
                                DomainRoleInfo sourceRole = DomainModelElement.GetSourceDomainRole(relInfo);

                                // check that we wont violate multiplicity constraints by adding new elements
                                if (sourceRole.Multiplicity == Multiplicity.One || sourceRole.Multiplicity == Multiplicity.ZeroOne)
                                    if (DomainRoleInfo.GetLinkedElement(parent, sourceRole.Id) != null)
                                        continue;

                                possibleParents.Add(new SearchElementWithRSType.SearchElementWithRSTypeStruct(
                                    new BaseModelElementViewModel(this.ViewModelStore, parent), relInfo.DisplayName, relInfo.Id));
                            }
                        }
            }
            else // root items
            {
                List<EmbeddingRelationshipAdvancedInfo> infos = this.Store.DomainDataAdvDirectory.FindDomainClassTargetEmbeddings(modelElement.GetDomainClassId());
                if (infos != null)
                    foreach (EmbeddingRelationshipAdvancedInfo info in infos)
                        if (!info.IsAbstract)
                        {
                            DomainRelationshipInfo relInfo = this.Store.DomainDataDirectory.GetDomainRelationship(info.RelationshipDomainClassId);
                            DomainRoleInfo sourceRole = DomainModelElement.GetSourceDomainRole(relInfo);

                            foreach (ModelElement element in this.Store.ElementDirectory.FindElements(info.SourceElementDomainClassId))
                            {
                                // check that we wont violate multiplicity constraints by adding new elements
                                if (sourceRole.Multiplicity == Multiplicity.One || sourceRole.Multiplicity == Multiplicity.ZeroOne)
                                    if (DomainRoleInfo.GetLinkedElement(element, sourceRole.Id) != null)
                                        continue;

                                possibleParents.Add(new SearchElementWithRSType.SearchElementWithRSTypeStruct(
                                    new BaseModelElementViewModel(this.ViewModelStore, element), relInfo.DisplayName, relInfo.Id));
                            }
                        }
            }

            // select parent
            if (possibleParents.Count == 1)
            {
                parent = possibleParents[0].ElementViewModel.Element as DomainModelElement;
                relationshipType = possibleParents[0].RelationshipDomainClassId;
            }
            else
            {
                // select parent
                using (SelectGenericViewModel<SearchElementWithRSType.SearchElementWithRSTypeStruct> selectionViewModel
                    = new SelectGenericViewModel<SearchElementWithRSType.SearchElementWithRSTypeStruct>(
                        this.ViewModelStore, possibleParents,
                        new GenericSearchDelegate<SearchElementWithRSType.SearchElementWithRSTypeStruct>(SearchElementWithRSType.Search),
                        new GenericSortDelegate<SearchElementWithRSType.SearchElementWithRSTypeStruct>(SearchElementWithRSType.Sort)))
                {
                    selectionViewModel.Title = "Select parent element";

                    // show dialog
                    bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("SelectElementWithRSTypePopup", selectionViewModel);
                    if (result == true && selectionViewModel.SelectedElement != null)
                    {
                        parent = selectionViewModel.SelectedElement.Value.ElementViewModel.Element as DomainModelElement;
                        relationshipType = selectionViewModel.SelectedElement.Value.RelationshipDomainClassId;
                    }
                }
                System.GC.Collect();
            }

            // dispose
            foreach (SearchElementWithRSType.SearchElementWithRSTypeStruct s in possibleParents)
                if (s.ElementViewModel != null)
                    s.ElementViewModel.Dispose();
            possibleParents.Clear();
            possibleParents = null;

            if (parent == null || relationshipType == Guid.Empty)
                return null;

            // create embedding relationship
            DomainRelationshipInfo drInfo = this.Store.DomainDataDirectory.GetDomainRelationship(relationshipType);

            this.Store.ElementFactory.CreateElementLink(drInfo,
                new RoleAssignment[]{
                    new RoleAssignment(DomainModelElement.GetSourceDomainRole(drInfo).Id, parent),
                    new RoleAssignment(DomainModelElement.GetTargetDomainRole(drInfo).Id, modelElement),
                });

            return parent;
        }

        /// <summary>
        /// Gets the curret mouse position relative to the diagram designer.
        /// </summary>
        /// <returns>Mouse position.</returns>
        public PointD GetCurrentMousePosition()
        {
            if (this.DiagramDesigner == null)
                return new PointD(0, 0);

            return DiagramDesigner.GetCurrentMousePosition();
        }

        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public override void DragOver(DropInfo dropInfo)
        {
            if (dropInfo.Data is BaseModelElementViewModel && dropInfo.VisualTarget is IDiagramDesigner)
            {
                IDiagramDesigner d = dropInfo.VisualTarget as IDiagramDesigner;
                BaseDiagramItemElementViewModel item = d.GetItemAtPosition(d.GetCurrentMousePosition()) as BaseDiagramItemElementViewModel;
                if (item == null)
                {
                    ModelElement m = (dropInfo.Data as BaseModelElementViewModel).Element;
                    if (IsInsertableRootItem(m as DomainModelElement) && !IsDisplayingRootElement(m))
                    {
                        dropInfo.Effects = System.Windows.DragDropEffects.Move;
                        return;
                    }
                }
            }

            dropInfo.Effects = System.Windows.DragDropEffects.None;
        }

        /// <summary>
        /// Drop logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public override void Drop(DropInfo dropInfo)
        {
            if (dropInfo.Data is BaseModelElementViewModel && dropInfo.VisualTarget is IDiagramDesigner)
            {
                IDiagramDesigner d = dropInfo.VisualTarget as IDiagramDesigner;
                BaseDiagramItemElementViewModel item = d.GetItemAtPosition(d.GetCurrentMousePosition()) as BaseDiagramItemElementViewModel;
                if (item == null)
                {
                    ModelElement m = (dropInfo.Data as BaseModelElementViewModel).Element;

                    using (Transaction t = this.Store.TransactionManager.BeginTransaction("Add to diagram", true))
                    {
                        NodeShape shape = null;
                        using (Transaction tShape = this.Store.TransactionManager.BeginTransaction("Create shape", true))
                        {
                            shape = CreateAndInsertShapeForElement(m);
                            shape.FixUpMissingShapes();

                            tShape.Commit();
                        }
                        if (shape != null)
                            using (Transaction tLinkShapes = this.Store.TransactionManager.BeginTransaction("Fixup missing link shapes", true))
                            {
                                shape.FixUpMissingLinkShapes();

                                if (shape != null)
                                    LayoutHelper.RestoreLayout(shape, this.Diagram);

                                tLinkShapes.Commit();
                            }

                        t.Commit();
                    }
                }
            }
        }

        /// <summary>
        /// Creates a shape for a model element.
        /// </summary>
        /// <param name="modelElement">Model element.</param>
        /// <returns>Node shape.</returns>
        public virtual NodeShape CreateAndInsertShapeForElement(ModelElement modelElement)
        {
            List<Guid> keys = this.DiagramDomainData.GetShapeTypesForElement((modelElement as DomainModelElement).GetDomainClassId());
            foreach (Guid k in keys)
            {
                ShapeClassInfo info = this.DiagramDomainData.ShapeClassInfos[k];
                if (info.ParentShapeClassType == null && info.DiagramClassType == this.GetDiagramClassType())
                {
                    NodeShape nodeShape = this.ViewModelStore.GetDomainModelServices().TopMostService.ShapeProvider.CreateShapeForElement(
                        k, modelElement) as NodeShape;

                    nodeShape.SetLocation(GetCurrentMousePosition());
                    this.Diagram.Children.Add(nodeShape);

                    return nodeShape;
                }
            }

            foreach(DiagramSurfaceViewModel vm in this.IncludedSurfaceViewModels)
			{
				NodeShape s = vm.CreateAndInsertShapeForElement(modelElement);
				if( s != null )
					return s;
			}
			
			return null;
        }

        /// <summary>
        /// Resets the current view.
        /// </summary>
        protected override void Reset()
        {
            try
            {
                if (this.Diagram != null)
                    Unsubscribe();

                this.SelectedItems.Clear();
                this.MenuOptions.Clear();

                for (int i = childItems.Count - 1; i >= 0; i--)
                {
                    BaseDiagramItemViewModel vm = childItems[i];
                    childItems.RemoveAt(i);
                    vm.Dispose();
                }

                this.childItemElements.Clear();
                this.childItemLinks.Clear();
                this.childItems.Clear();

                foreach (DiagramSurfaceViewModel d in this.IncludedSurfaceViewModels)
                {
                    d.Dispose();
                }
                this.includedSurfaceViewModels.Clear();
            }
            catch
            { 
            }

            base.Reset();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        protected override void OnDispose()
        {
            foreach (DiagramSurfaceViewModel d in this.IncludedSurfaceViewModels)
                d.Dispose();

            this.toggleOrthogonalConnectorCommand = null;
            this.toggleStraightConnectorCommand = null;

            base.OnDispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This is the vm for the graphical dependencies diagram.
    /// </summary>
    public class GraphicalDependenciesViewModel : DiagramSurfaceViewModel, IDropTarget, IGraphicalDependenciesViewModel
    {
        private DelegateCommand showDependenciesCommand;
        private DelegateCommand refreshCommand;

        private ModelElement mainElement;
        private ObservableCollection<GraphicalDependenciesFilterItem> filterItemVMs;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        /// <param name="diagram"></param>
        /// <param name="modelContext"></param>
        public GraphicalDependenciesViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext, false, false)
        {
            showDependenciesCommand = new DelegateCommand(ShowDependenciesCommandExecuted);
            refreshCommand = new DelegateCommand(RefreshCommandExecuted);

            this.filterItemVMs = new ObservableCollection<GraphicalDependenciesFilterItem>();

            this.PreInitialize();
        }

        bool bIsLoaded = false;
        bool bRequiresUpdate = false;

        /// <summary>
        /// Gets the diagram class type.
        /// </summary>
        /// <returns></returns>
        public override Guid GetDiagramClassType()
        {
            return this.Diagram.GetDomainClassId();
        }

        /// <summary>
        /// Delete command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected override bool OnDeleteCommandCanExecute()
        {
            return false;
        }

        /// <summary>
        /// Called when the view is loaded.
        /// </summary>
        protected override void OnLoaded()
        {
 	        if (bIsLoaded)
                return;

            bIsLoaded = true;

            if (bRequiresUpdate)
            {
                Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                          System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(Update));
            }
        }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public IGraphicalDependenciesView View { get; set; }

        /// <summary>
        /// Gets the diagram this item belongs to.
        /// </summary>
        public new GraphicalDependenciesDiagram Diagram
        {
            get { return base.Diagram as GraphicalDependenciesDiagram; }
        }
        
        /// <summary>
        /// Get or sets the model element, for which dependencies are to be presented graphically.
        /// </summary>
        public ModelElement MainElement
        {
            get
            {
                return mainElement;
            }
            set
            {
                if (this.mainElement != value)
                {
                    // remove prev model element deleted event notification
                    if( this.mainElement != null )
                        this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(this.mainElement.Id, OnMainElementDeleted);
                    
                    this.mainElement = value;

                    // add model element deleted event notification
                    if (this.mainElement != null)
                        this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(this.mainElement.Id, OnMainElementDeleted);

                    if (bIsLoaded)
                        RefreshCommandExecuted();
                    else
                        bRequiresUpdate = true;
                }
            }
        }
        private void OnMainElementDeleted(ElementDeletedEventArgs args)
        {
            this.MainElement = null;
        }

        /// <summary>
        /// Gets the filter item VMs.
        /// </summary>
        public ObservableCollection<GraphicalDependenciesFilterItem> FilterItemVMs
        {
            get
            {
                return this.filterItemVMs;
            }
        }
        
        /// <summary>
        /// Show dependencies command.
        /// </summary>
        public DelegateCommand ShowDependenciesCommand
        {
            get { return this.showDependenciesCommand; }
        }

        /// <summary>
        /// Execute the show dependencies command.
        /// </summary>
        public void ShowDependenciesCommandExecuted()
        {
            if( this.SelectedItemsData.Count == 1 )
                this.MainElement = (this.SelectedItemsData[0] as BaseDiagramItemViewModel).Element;
        }

        /// <summary>
        /// RefreshCommand.
        /// </summary>
        public DelegateCommand RefreshCommand
        {
            get { return this.refreshCommand; }
        }

        /// <summary>
        /// RefreshCommand executed.
        /// </summary>
        public void RefreshCommandExecuted()
        {
            this.Update();
            //Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
             //   System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(Update));
        }
        
        /// <summary>
        /// Updates the dependencies view (cause by a main model element change).
        /// </summary>
        protected virtual void Update()
        {
            this.Store.UndoManager.UndoState = UndoState.DisabledNoFlush;
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("", true))
            {
                if (this.Diagram == null || this.Diagram.Store == null)
                {
                    if (this.Diagram != null)
                        this.Unsubscribe();

                    base.Diagram = new GraphicalDependenciesDiagram(this.Store);
                    this.Subscribe();
                }

                for (int i = this.Diagram.Children.Count - 1; i >= 0; i--)
                    this.Diagram.Children[i].Delete();
                this.Diagram.SourceDependencyShapes.Clear();
                this.Diagram.TargetDependencyShapes.Clear();
                this.Diagram.Children.Clear();

                this.Clear();
                filterItemVMs.Clear();

                if (this.MainElement != null)
                {
                    this.LoadFilteredInfo();

                    UpdateElement();
                    UpdateParts();
                }

                t.Commit();
            }

            if (this.MainElement != null)
            {
                UpdateLayout();
                UpdateLinks();
            }
            this.Store.UndoManager.UndoState = UndoState.Enabled;
        }

        /// <summary>
        /// Updates the layout of the dependencies view.
        /// </summary>
        protected virtual void UpdateLayout()
        {
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("", true))
            {
                if (this.MainElement != null)
                {
                    /*
                    if (this.View != null)
                    {
                        SizeD diagramSize = this.View.GetSize();
                        if (!double.IsNaN(diagramSize.Width) && !double.IsNaN(diagramSize.Height))
                            this.Diagram.Layout(diagramSize.Width, diagramSize.Height);
                        else
                            this.Diagram.Layout();
                    }
                    else*/
                        this.Diagram.Layout();

                }

                t.Commit();
            }
        }

        private void UpdateLinks()
        {
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("", true))
            {
                if (this.MainElement != null)
                {
                    foreach (GraphicalDependencyShape shape in this.Diagram.SourceDependencyShapes)
                    {
                        UpdateLink(shape, true);
                    }

                    foreach (GraphicalDependencyShape shape in this.Diagram.TargetDependencyShapes)
                    {
                        UpdateLink(shape, false);
                    }
                }
                t.Commit();
            }
        }

        /// <summary>
        /// Updates the link between the main shape and the dependency shape.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="bSource"></param>
        protected virtual void UpdateLink(GraphicalDependencyShape shape, bool bSource)
        {
            GraphicalDependencyLinkShape linkShape = new GraphicalDependencyLinkShape(this.Store);
            linkShape.Element = shape.Element;
            linkShape.SourceAnchor = new SourceAnchor(this.Store);
            if( bSource )
                linkShape.SourceAnchor.FromShape = shape;
            else
                linkShape.SourceAnchor.FromShape = this.Diagram.MainElementShape;
            linkShape.TargetAnchor = new TargetAnchor(this.Store);
            if( bSource )
                linkShape.TargetAnchor.ToShape = this.Diagram.MainElementShape;
            else
                linkShape.TargetAnchor.ToShape = shape;
            linkShape.RoutingMode = RoutingMode.Orthogonal;

            linkShape.DependencyShape = shape;
            linkShape.MainShape = this.Diagram.MainElementShape;

            this.Diagram.UpdateLinkShapePosition(linkShape, shape, this.Diagram.MainElementShape, bSource);
            this.Diagram.LinkShapes.Add(linkShape);
        }
        private void UpdateElement()
        {
            DiagramDomainDataDirectory data = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();

            Guid domainClassId = this.MainElement.GetDomainClass().Id;            
            if (data.HasDependenciesShapeForElement(domainClassId))
            {
                this.Diagram.MainElementShape = this.ViewModelStore.TopMostStore.GetDomainModelServices().ShapeProvider.CreateDependenciesShapeForElement(domainClassId, this.MainElement) as NodeShape;
                this.Diagram.Children.Add(this.Diagram.MainElementShape);
                return;
            }

            this.Diagram.MainElementShape = new GraphicalDependencyMainShape(this.Store);
            this.Diagram.MainElementShape.Element = this.MainElement;
            this.Diagram.MainElementShape.SetSize(new SizeD(200, 40));
            this.Diagram.Children.Add(this.Diagram.MainElementShape);
        }
        
        /// <summary>
        /// Update source and target dependency parts.
        /// </summary>
        protected virtual void UpdateParts()
        {
            if (this.MainElement == null)
                return;

                DomainClassInfo elementInfo = this.MainElement.GetDomainClass();

                Dictionary<Guid, GraphicalDependencyShape> sParts = new Dictionary<Guid, GraphicalDependencyShape>();
                Dictionary<Guid, GraphicalDependencyShape> tParts = new Dictionary<Guid, GraphicalDependencyShape>();

                ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetAllElementLinks(this.MainElement);
                foreach (ElementLink link in links)
                {
                    DomainRelationshipInfo info = link.GetDomainRelationship();
                    if (this.Store.DomainDataAdvDirectory.IsReferenceIncludedInModel(info.Id))
                    {
                        if( DomainRoleInfo.GetSourceRolePlayer(link) == this.MainElement )
                            UpdatePart(elementInfo.Id, tParts, true, link, info);
                        else
                            UpdatePart(elementInfo.Id, sParts, false, link, info);
                    }
                }
  
        }

        /// <summary>
        /// Update a dependency part.
        /// </summary>
        /// <param name="domainClassId"></param>
        /// <param name="parts"></param>
        /// <param name="bSource"></param>
        /// <param name="link"></param>
        /// <param name="info"></param>
        protected virtual void UpdatePart(Guid domainClassId, Dictionary<Guid, GraphicalDependencyShape> parts, bool bSource, ElementLink link, DomainRelationshipInfo info)
        {
            GraphicalDependencyShape shape;
            parts.TryGetValue(info.Id, out shape);

            if (shape == null)
            {
                GraphicalDependenciesFilterItem filterItem = new GraphicalDependenciesFilterItem(this.ViewModelStore, this, info.Id);
                filterItem.Title = info.DisplayName;
                this.FilterItemVMs.Add(filterItem);

                shape = CreateHostShape(link, info);

                parts.Add(info.Id, shape);
                if (!bSource)
                    this.Diagram.SourceDependencyShapes.Add(shape);
                else
                    this.Diagram.TargetDependencyShapes.Add(shape);
            }

            shape.AddNestedChild(CreateChildShape(link, bSource));
        }
     
        private GraphicalDependencyShape CreateHostShape(ElementLink link, DomainRelationshipInfo info)
        {
            GraphicalDependencyShape shape = new GraphicalDependencyShape(this.Store);
            shape.RelationshipName = info.DisplayName;
            shape.Element = link;
            shape.SetLocation(new PointD(5, 5));
            shape.RelationshipTypeId = info.Id;

            this.Diagram.Children.Add(shape);

            return shape;
        }
        private NodeShape CreateChildShape(ElementLink link, bool bSource)
        {
            if (!bSource)
                return CreateShape(DomainRoleInfo.GetSourceRolePlayer(link));
            else
                return CreateShape(DomainRoleInfo.GetTargetRolePlayer(link));
        }
        
        /// <summary>
        /// Creates a shape for the specified model element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected virtual NodeShape CreateShape(ModelElement element)
        {
            DiagramDomainDataDirectory data = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();

            Guid domainClassId = element.GetDomainClass().Id;
            if (data.HasDependenciesShapeForElement(domainClassId))
                return this.ViewModelStore.TopMostStore.GetDomainModelServices().ShapeProvider.CreateDependenciesShapeForElement(domainClassId, element) as NodeShape;

            NodeShape dShape = new NodeShape(this.Store);
            dShape.Element = element;
            dShape.SetLocation(new PointD(5, 5));
            dShape.SetSize(new SizeD(200, 40));

            return dShape;
        }

        private void LoadFilteredInfo()
        {
            // TODO
        }

        /// <summary>
        /// Updates the displayed dependencies based on filter information.
        /// </summary>
        public virtual void UpdateBasedOnFilter(GraphicalDependenciesFilterItem filterItem)
        {
            this.Store.UndoManager.UndoState = UndoState.DisabledNoFlush;
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("", true))
            {
                if (filterItem.IsFiltered)
                {
                    // remove elements
                    for (int i = 0; i < this.Diagram.SourceDependencyShapes.Count; i++)
                    {
                        if (this.Diagram.SourceDependencyShapes[i].RelationshipTypeId == filterItem.RelationshipType &&
                            this.Diagram.SourceDependencyShapes[i].RelationshipTypeId != Guid.Empty)
                        {
                            RemoveHostShape(this.Diagram.SourceDependencyShapes[i]);
                            break;
                        }

                        if (this.Diagram.SourceDependencyShapes[i].CustomInfo == filterItem.CustomFilterInformation &&
                            !String.IsNullOrEmpty(this.Diagram.SourceDependencyShapes[i].CustomInfo))
                        {
                            RemoveHostShape(this.Diagram.SourceDependencyShapes[i]);
                            break;
                        }
                    }

                    for (int i = 0; i < this.Diagram.TargetDependencyShapes.Count; i++)
                    {
                        if (this.Diagram.TargetDependencyShapes[i].RelationshipTypeId == filterItem.RelationshipType &&
                            this.Diagram.TargetDependencyShapes[i].RelationshipTypeId != Guid.Empty)
                        {
                            RemoveHostShape(this.Diagram.TargetDependencyShapes[i]);
                            break;
                        }

                        if (this.Diagram.TargetDependencyShapes[i].CustomInfo == filterItem.CustomFilterInformation &&
                            !String.IsNullOrEmpty(this.Diagram.TargetDependencyShapes[i].CustomInfo))
                        {
                            RemoveHostShape(this.Diagram.TargetDependencyShapes[i]);
                            break;
                        }
                    }
                    UpdateLayout();
                }
                else
                {
                    // add elements
                    GraphicalDependencyShape hostShape = null;
                    bool bSource = true;

                    DomainClassInfo elementInfo = this.MainElement.GetDomainClass();
                    ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetAllElementLinks(this.MainElement);
                    foreach (ElementLink link in links)
                    {
                        DomainRelationshipInfo info = link.GetDomainRelationship();
                        if( info.Id == filterItem.RelationshipType )
                        {
                            if (DomainRoleInfo.GetSourceRolePlayer(link) != this.MainElement)
                                bSource = false;

                            if (hostShape == null)
                            {
                                hostShape = CreateHostShape(link, info);

                                if (bSource)
                                    this.Diagram.TargetDependencyShapes.Add(hostShape);
                                else
                                    this.Diagram.SourceDependencyShapes.Add(hostShape);
                            }

                            if (bSource)
                                hostShape.AddNestedChild(CreateChildShape(link, true));
                            else
                            {
                                hostShape.AddNestedChild(CreateChildShape(link, false));
                            }
                        }
                    }

                    UpdateLayout();

                    if (hostShape != null)
                    {
                        UpdateLink(hostShape, !bSource);
                    }
                }
                
                t.Commit();
            }
            this.Store.UndoManager.UndoState = UndoState.Enabled;
        }

        /// <summary>
        /// Removes the host shape.
        /// </summary>
        /// <param name="shape">Host shape to remove.</param>
        protected virtual void RemoveHostShape(GraphicalDependencyShape shape)
        {

            shape.LinkShape.Delete();

            for (int y = shape.NestedChildren.Count - 1; y >= 0; y--)
            {
                NodeShape nodeShape = shape.NestedChildren[y];
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

            // delete shape
            shape.Delete();
        }

        #region DiagramSurfaceViewModel override
        /// <summary>
        /// Gets whether this view model is visible or not.
        /// </summary>
        public override bool IsDiagramDesignerViewModelVisible
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public override void DragOver(DropInfo dropInfo)
        {
            if (dropInfo.Data is BaseModelElementViewModel )//&& dropInfo.VisualTarget is IDiagramDesigner)
            {
                //IDiagramDesigner d = dropInfo.VisualTarget as IDiagramDesigner;
                //BaseDiagramItemElementViewModel item = d.GetItemAtPosition(d.GetCurrentMousePosition()) as BaseDiagramItemElementViewModel;
                //if (item == null)
                //{
                    dropInfo.Effects = System.Windows.DragDropEffects.Move;
                    return;
                //}
            }

            dropInfo.Effects = System.Windows.DragDropEffects.None;
        }

        /// <summary>
        /// Drop logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public override void Drop(DropInfo dropInfo)
        {
            if (dropInfo.Data is BaseModelElementViewModel)//&& dropInfo.VisualTarget is IDiagramDesigner)
            {
                //IDiagramDesigner d = dropInfo.VisualTarget as IDiagramDesigner;
                //BaseDiagramItemElementViewModel item = d.GetItemAtPosition(d.GetCurrentMousePosition()) as BaseDiagramItemElementViewModel;
                //if (item == null)
                //{
                    ModelElement m = (dropInfo.Data as BaseModelElementViewModel).Element;
                    this.MainElement = m;
                //}
            }
        }

        /// <summary>
        /// Selected items data collection. Used for binding
        /// </summary>
        public override Collection<object> SelectedItemsData
        {
            get
            {
                return base.SelectedItemsData;
            }
            set
            {
                base.SelectedItemsData = value;

                Tum.PDE.ToolFramework.Modeling.SelectedItemsCollection col = new Tum.PDE.ToolFramework.Modeling.SelectedItemsCollection();

                // propagate selection
                if (!this.IsReseting)
                {
                    if (value != null)
                        foreach (BaseDiagramItemViewModel vm in value)
                            col.Add(vm.Element);

                    EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
                }

            }
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public override PDE.ToolFramework.Modeling.ModelContext ModelContext
        {
            get
            {
                return this.ViewModelStore.ModelData.CurrentModelContext;
            }
        }

        /// <summary>
        /// Called whenever a relationship of type DiagramHasLinkShapes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="diagVm"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public override void OnLinkShapeElementAdded(DiagramHasLinkShapes con, DiagramSurfaceViewModel diagVm)
        {
            GraphicalDependencyLinkViewModel linkVM =
                    new GraphicalDependencyLinkViewModel(this.ViewModelStore, this, con.LinkShape as GraphicalDependencyLinkShape);
            diagVm.AddLink(linkVM);
        }

        /// <summary>
        /// Called whenever a relationship of type ShapeElementContainsChildShapes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="diagVm"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public override void OnChildShapeElementAdded(DiagramHasChildren con, DiagramSurfaceViewModel diagVm)
        {
            if (IsDisplayingNodeShape(con.ChildShape))
                return;

            if (con.ChildShape is GraphicalDependencyShape)
            {
                GraphicalDependencyHostViewModel vm = new GraphicalDependencyHostViewModel(
                        this.ViewModelStore, this, con.ChildShape as GraphicalDependencyShape);
                diagVm.AddElement(vm);
            }
            else if (con.ChildShape is GraphicalDependencyMainShape)
            {
                GraphicalDependencyMainItemViewModel vm = new GraphicalDependencyMainItemViewModel(
                    this.ViewModelStore, this, con.ChildShape as GraphicalDependencyMainShape);
                diagVm.AddElement(vm);
            }
            else
            {
                DomainClassInfo info = con.ChildShape.GetDomainClass();
                if (info.Id != NodeShape.DomainClassId)
                {
                    DiagramItemElementViewModel elementVM = this.ViewModelStore.Factory.CreateDiagramItemViewModel(
                        info.Id, this, con.ChildShape);

                    if (elementVM != null)
                    {
                        diagVm.AddElement(elementVM);
                        return;
                    }
                }

                GraphicalDependencyItemViewModel vm = new GraphicalDependencyItemViewModel(
                        this.ViewModelStore, this, con.ChildShape);
                diagVm.AddElement(vm);
            }
        }

        /// <summary>
        /// Gets the docking pane name.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "GraphicalDependenciesView"; }
        }

        /// <summary>
        /// Gets the docking pane title.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "GraphicalDependenciesView"; }
        }
        #endregion

        #region Not required
        /// <summary>
        /// Not required.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void ShowRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            // not required
        }
        /// <summary>
        /// Not required.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void HideRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            // not required
        }

        /// <summary>
        /// React on view selection.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void ReactOnViewSelection(PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events.SelectionChangedEventArgs eventArgs)
        {

        }

        /// <summary>
        /// Not required.
        /// </summary>
        /// <param name="modelElement"></param>
        /// <returns></returns>
        public override NodeShape CreateAndInsertShapeForElement(ModelElement modelElement)
        {
            return null;
        }

        /// <summary>
        /// No context menu.
        /// </summary>
        public override void UpdateMenuOptions()
        {

        }

        /// <summary>
        /// Not required.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public override bool IsInsertableRootItem(DomainModelElement element)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void OnReset()
        {
            MainElement = null;

            base.OnReset();

        }
    }
}

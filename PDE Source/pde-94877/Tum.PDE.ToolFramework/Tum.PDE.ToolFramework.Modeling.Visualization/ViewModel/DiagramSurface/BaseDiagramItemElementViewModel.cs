using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.View;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// This is the base abstract class for a diagram item element implementation.
    /// </summary>
    /// <remarks>
    /// Items are added onto the surface by:
    /// - User-Command of the instance of this vm, uses AddNestedChild, AddRelativeChild function
    /// 
    /// Items are removed from the surface by:
    /// - RemoveNestedChild, RemoveRelativeChild
    /// - Child ShapeElement removed from diagrams children collection (OnLinkShapeElementRemoved)
    /// </remarks>
    public abstract class BaseDiagramItemElementViewModel : BaseDiagramItemViewModel, IDiagramItemViewModel
    {
        private PointD itemLocation;
        private SizeD itemSize;

        private BaseDiagramItemElementViewModel parentItem;

        private ObservableCollection<BaseDiagramItemElementViewModel> nestedChildItems;
        private ReadOnlyObservableCollection<BaseDiagramItemElementViewModel> nestedChildItemsRO;

        private ObservableCollection<BaseDiagramItemElementViewModel> relativeChildItems;
        private ReadOnlyObservableCollection<BaseDiagramItemElementViewModel> relativeChildItemsRO;
        private DiagramDomainDataDirectory diagramDomainData = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected BaseDiagramItemElementViewModel(ViewModelStore viewModelStore, DiagramSurfaceViewModel diagram, NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
            this.itemLocation = shapeElement.Location;
            this.itemSize = shapeElement.Size;
            
            this.parentItem = null;

            this.nestedChildItems = new ObservableCollection<BaseDiagramItemElementViewModel>();
            this.nestedChildItemsRO = new ReadOnlyObservableCollection<BaseDiagramItemElementViewModel>(nestedChildItems);

            this.relativeChildItems = new ObservableCollection<BaseDiagramItemElementViewModel>();
            this.relativeChildItemsRO = new ReadOnlyObservableCollection<BaseDiagramItemElementViewModel>(relativeChildItems);

            Subscribe();
        }

        /// <summary>
        /// Gets or sets the shape element, that is hosted by this view model.
        /// </summary>
        public new NodeShape ShapeElement
        {
            get { return base.ShapeElement as NodeShape; }
            set
            {
                base.ShapeElement = value;
            }
        }

        /// <summary>
        /// Gets the parent item of this item. Can be null, which means, that this item is a root item on the diagram.
        /// </summary>
        public BaseDiagramItemElementViewModel Parent
        {
            get { return this.parentItem; }
        }

        /// <summary>
        /// Gets the diagram domain data.
        /// </summary>
        public DiagramDomainDataDirectory DiagramDomainData
        {
            get
            {
                if (this.diagramDomainData == null)
                    this.diagramDomainData = this.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();

                return this.diagramDomainData;
            }
        }

        /// <summary>
        /// Gets the nested children of this item. A nested child is hosted within this item.
        /// </summary>
        public ReadOnlyObservableCollection<BaseDiagramItemElementViewModel> NestedChildren
        {
            get { return this.nestedChildItemsRO; }
        }

        /// <summary>
        /// Gets the relative children of this item. A relative child is hosted relative to this item.
        /// </summary>
        public ReadOnlyObservableCollection<BaseDiagramItemElementViewModel> RelativeChildren
        {
            get { return this.relativeChildItemsRO; }
        }

        #region Positioning and Sizing of the element
        /// <summary>
        /// Gets wheter this shape can be moved in the UI.
        /// </summary>
        public virtual bool IsUIFixedPosition
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets whether the width of this item is fiex.
        /// </summary>
        public bool IsWidthFixed
        {
            get
            {
                if (this.ResizingBehaviour == ShapeResizingBehaviour.Fixed ||
                    this.ResizingBehaviour == ShapeResizingBehaviour.FixedWidth)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets whether the height of this item is fixed.
        /// </summary>
        public bool IsHeightFixed
        {
            get
            {
                if (this.ResizingBehaviour == ShapeResizingBehaviour.Fixed ||
                    this.ResizingBehaviour == ShapeResizingBehaviour.FixedHeight)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets or sets the position (LEFT) of this item on the canvas.
        /// </summary>
        public double Left
        {
            get { return this.Location.X; }
        }

        /// <summary>
        /// Gets or sets the position (TOP) of this item on the canvas.
        /// </summary>
        public double Top
        {
            get { return this.Location.Y; }
        }

        /// <summary>
        /// Gets or sets the size (WIDTH) of this item.
        /// </summary>
        public double Width
        {
            get { return this.Size.Width; }
        }

        /// <summary>
        /// Gets or sets the size (HEIGHT) of this item.
        /// </summary>
        public double Height
        {
            get { return this.Size.Height; }
        }

        /// <summary>
        /// Gets or sets the location of this item.
        /// </summary>
        public PointD Location
        {
            get
            {
                return this.itemLocation;
            }
            set
            {
                if (this.itemLocation != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move Element"))
                    {
                        this.SetLocation(value);
                        transaction.Commit();
                    }
                }    
            }
        }

        /// <summary>
        /// Gets or sets the location of this item.
        /// </summary>
        public PointD AbsoluteLocation
        {
            get
            {
                return this.ShapeElement.AbsoluteLocation;
            }
        }

        /// <summary>
        /// Gets or sets the size of this item.
        /// </summary>
        public SizeD Size
        {
            get
            {
                return this.itemSize;
            }
            set
            {
                if (IsWidthFixed && IsHeightFixed)
                    return;

                if (this.itemSize != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Resize Element"))
                    {
                        this.SetSize(value);
                        transaction.Commit();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the bounds of this item.
        /// </summary>
        public RectangleD Bounds
        {
            get
            {
                return new RectangleD(this.Location, this.Size);
            }
            set
            {
                if (this.Bounds != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move/Resize Element"))
                    {
                        this.Size = value.Size;
                        this.Location = value.Location;

                        transaction.Commit();
                    }
                }    
            }
        }

        /// <summary>
        /// Gets the resizing behaviour of the shape.
        /// </summary>
        public ShapeResizingBehaviour ResizingBehaviour
        {
            get
            {
                return this.ShapeElement.ResizingBehaviour;
            }
        }

        /// <summary>
        /// Gets the movement behaviour of the shape.
        /// </summary>
        public ShapeMovementBehaviour MovementBehaviour
        {
            get
            {
                return this.ShapeElement.MovementBehaviour;
            }
        }

        /// <summary>
        /// Gets whether the shape is a relative child shape or not.
        /// </summary>
        public bool IsRelativeChildShape
        {
            get
            {
                return this.ShapeElement.IsRelativeChildShape;
            }
        }

        /// <summary>
        /// Gets whether this shape takes part in any relationship or not.
        /// </summary>
        /// <returns>True if this shape takes part in any relationship. False otherwise</returns>
        public virtual bool TakesPartInRelationship
        {
            get
            {
                return this.ShapeElement.TakesPartInRelationship;
            }
        }

        /// <summary>
        /// Gets the size this element is placed on, if this is a relative child shape
        /// with MovementBehaviour set to PositionOnEdgeOfParent. Otherwise, throws
        /// an InvalidOperationException.
        /// </summary>
        public PortPlacement GetPlacementSide()
        {
            return this.ShapeElement.PlacementSide;
        }

        /// <summary>
        /// Gets or sets the absolute position (TOP) of this item on the canvas.
        /// This is required to keep track of where the element globaly is and
        /// needs to be setup by the visualizing control.
        /// </summary>
        public double AbsoluteTop
        {
            get { return AbsoluteLocation.Y; }
        }

        /// <summary>
        /// Gets or sets the absolute position (LEFT) of this item on the canvas.
        /// This is required to keep track of where the element globaly is and
        /// needs to be setup by the visualizing control.
        /// </summary>
        public double AbsoluteLeft
        {
            get { return AbsoluteLocation.X; }
        }
              
        /// <summary>
        /// Sets the size of this item and propagates it to the hosted shape element if allowed.
        /// </summary>
        /// <param name="newSize">Size to apply.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void SetSize(SizeD newSize)
        {
            if (this.ShapeElement.Size != newSize)
                this.ShapeElement.SetSize(newSize);
        }

        /// <summary>
        /// Sets the location of this item and propagates it to the hosted shape element if allowed.
        /// </summary>
        /// <param name="proposedLocation">Location to apply.</param>
        /// <remarks>
        /// This function needs to be called withing a modeling transaction.
        /// </remarks>
        public virtual void SetLocation(PointD proposedLocation)
        {
            if (this.ShapeElement.Location != proposedLocation)
            {
                this.ShapeElement.SetLocation(proposedLocation);
            }
        }
        #endregion

        /// <summary>
        /// Gets whether this view model can have nested children or not.
        /// </summary>
        public abstract bool CanHaveNestedChildren { get; }

        /// <summary>
        /// Gets whether this view model can have relative children or not.
        /// </summary>
        public abstract bool CanHaveRelativeChildren { get; }

        /// <summary>
        /// Adds a nested child item to the current item.
        /// </summary>
        /// <param name="item">Child item to be added.</param>
        public void AddNestedChild(BaseDiagramItemElementViewModel item)
        {
            AddChild(item, true);
        }

        /// <summary>
        /// Adds a relative child item to the current item.
        /// </summary>
        /// <param name="item">Child item to be added.</param>
        public void AddRelativeChild(BaseDiagramItemElementViewModel item)
        {
            AddChild(item, false);
        }

        /// <summary>
        /// Removes the given item from the nested children collection.
        /// </summary>
        /// <param name="item">Child item to be removed.</param>
        public void RemoveNestedChild(BaseDiagramItemElementViewModel item)
        {
            RemoveChild(item, true);
        }

        /// <summary>
        /// Removes the given item from the relative children collection.
        /// </summary>
        /// <param name="item">Child item to be removed.</param>
        public void RemoveRelativeChild(BaseDiagramItemElementViewModel item)
        {
            RemoveChild(item, false);
        }

        private void AddChild(BaseDiagramItemElementViewModel item, bool bNested)
        {
            if (bNested)
                this.nestedChildItems.Add(item);
            else
                this.relativeChildItems.Add(item);

            if (item.Parent != this)
                item.SetParent(this, bNested);

            if (this.Diagram != null)
                this.Diagram.AddElement(item);
        }
        private void RemoveChild(BaseDiagramItemElementViewModel item, bool bNested)
        {
            if (bNested && this.nestedChildItems.Contains(item))
                this.nestedChildItems.Remove(item);
            else if (!bNested && this.relativeChildItems.Contains(item))
                this.relativeChildItems.Remove(item);

            if (item.Parent != null)
                item.RemoveParent(bNested);

            if( this.Diagram != null )
                this.Diagram.RemoveElement(item);
        }

        /// <summary>
        /// Assigns a parent item to the current item.
        /// </summary>
        /// <param name="parent">Parent item to be assigned.</param>
        /// <param name="bNestedChildItem">True if the child item is a nested item. False for relative item.</param>
        public void SetParent(BaseDiagramItemElementViewModel parent, bool bNestedChildItem)
        {
            this.parentItem = parent;
            
            if (bNestedChildItem && !parent.NestedChildren.Contains(this))
            {
                parent.AddNestedChild(this);
            }
            else if (!bNestedChildItem && !parent.RelativeChildren.Contains(this))
                parent.AddRelativeChild(this);
        }

        /// <summary>
        /// Removes this element from its parents collection.
        /// </summary>
        /// <param name="bNestedChildItem">True if the child item is a nested item. False for relative item.</param>
        public void RemoveParent(bool bNestedChildItem)
        {
            if (this.parentItem != null)
            {
                if (bNestedChildItem && this.parentItem.NestedChildren.Contains(this))
                    this.parentItem.RemoveNestedChild(this);
                else if (!bNestedChildItem && this.parentItem.RelativeChildren.Contains(this))
                    this.parentItem.RemoveRelativeChild(this);
            }

            this.parentItem = null;
        }

        /// <summary>
        /// Gets the parent item of this item. Can be null, which means, that this item is a root item on the diagram.
        /// </summary>
        /// <returns>Parent item or null.</returns>
        public IDiagramItemViewModel GetParent()
        {
            return this.Parent;
        }

        /// <summary>
        /// Gets the collection of nested children.
        /// </summary>
        /// <returns>Collection of nested children.</returns>
        public IEnumerable<IDiagramItemViewModel> GetNestedChildren()
        {
            return this.NestedChildren.Cast<IDiagramItemViewModel>();
        }

        /// <summary>
        /// Gets the collection of relative children.
        /// </summary>
        /// <returns>Collection of relative children.</returns>
        public IEnumerable<IDiagramItemViewModel> GetRelativeChildren()
        {
            return this.RelativeChildren.Cast<IDiagramItemViewModel>();
        }

        /// <summary>
        /// Collects all embedded vms, that host the specified model element.
        /// </summary>
        /// <param name="modelElement">Hosted model element.</param>
        /// <param name="embeddedVms">Collected collection of embedded vms.</param>
        public virtual void GetEmbeddedItems(ModelElement modelElement, Collection<BaseDiagramItemViewModel> embeddedVms)
        {
            foreach (BaseDiagramItemElementViewModel vm in this.NestedChildren)
            {
                if (vm.Element == modelElement)
                {
                    embeddedVms.Add(vm);
                }

                vm.GetEmbeddedItems(modelElement, embeddedVms);
            }

            foreach (BaseDiagramItemElementViewModel vm in this.RelativeChildren)
            {
                if (vm.Element == modelElement)
                {
                    embeddedVms.Add(vm);
                }

                vm.GetEmbeddedItems(modelElement, embeddedVms);
            }
        }

        /// <summary>
        /// Verifies if the given element is already displayed as a child of this view model.
        /// </summary>
        /// <param name="modelElement">Model element to find.</param>
        /// <returns>True if the given element is already displayed as a child of this view model. False otherwise</returns>
        public bool IsDisplayingElement(ModelElement modelElement)
        {
            foreach (BaseDiagramItemElementViewModel vm in this.NestedChildren)
                if (vm.Element.Id == modelElement.Id)
                    return true;

            foreach (BaseDiagramItemElementViewModel vm in this.RelativeChildren)
                if (vm.Element.Id == modelElement.Id)
                    return true;

            return false;
        }

        /// <summary>
        /// Verifies if the given node shape is already displayed as a child of this view model.
        /// </summary>
        /// <param name="nodeShape">Node shape to find.</param>
        /// <returns>True if the given element is already displayed as a child of this view model. False otherwise</returns>
        public bool IsDisplayingNodeShape(NodeShape nodeShape)
        {
            foreach (BaseDiagramItemElementViewModel vm in this.NestedChildren)
                if (vm.ShapeElement.Id == nodeShape.Id)
                    return true;

            foreach (BaseDiagramItemElementViewModel vm in this.RelativeChildren)
                if (vm.ShapeElement.Id == nodeShape.Id)
                    return true;

            return false;
        }

        /// <summary>
        /// Makes sure child and link shapes are visible
        /// </summary>
        public virtual void FixupShapeVisibility()
        {
            ReadOnlyCollection<NodeShapeReferencesNestedChildren> linksN = NodeShapeReferencesNestedChildren.GetLinksToNestedChildren(this.ShapeElement);
            foreach (NodeShapeReferencesNestedChildren link in linksN)
            {
                OnNestedChildShapeElementAdded(link);
            }

            ReadOnlyCollection<NodeShapeReferencesRelativeChildren> linksR = NodeShapeReferencesRelativeChildren.GetLinksToRelativeChildren(this.ShapeElement);
            foreach (NodeShapeReferencesRelativeChildren link in linksR)
            {
                OnRelativeChildShapeElementAdded(link);
            }

            foreach (BaseDiagramItemElementViewModel vm in this.NestedChildren)
                vm.FixupShapeVisibility();

            foreach (BaseDiagramItemElementViewModel vm in this.RelativeChildren)
                vm.FixupShapeVisibility();
        }

        #region Subscription event methods

        /// <summary>
        /// Called whenever a relationship of type NodeShapeReferencesNestedChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnNestedChildShapeElementAdded(ElementAddedEventArgs args)
        {
            OnNestedChildShapeElementAdded(args.ModelElement as NodeShapeReferencesNestedChildren);
        }

        /// <summary>
        /// Called whenever a relationship of type NodeShapeReferencesNestedChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        protected virtual void OnNestedChildShapeElementAdded(NodeShapeReferencesNestedChildren con)
        {
            if (IsDisplayingNodeShape(con.ChildShape))
                return;

            DiagramItemElementViewModel vm = this.ViewModelStore.Factory.CreateDiagramItemViewModel(con.ChildShape.GetDomainClassId(), this.Diagram, con.ChildShape);
            this.AddNestedChild(vm);
        }

        /// <summary>
        /// Called whenever a relationship of type NodeShapeReferencesRelativeChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnRelativeChildShapeElementAdded(ElementAddedEventArgs args)
        {
            OnRelativeChildShapeElementAdded(args.ModelElement as NodeShapeReferencesRelativeChildren);
        }

        /// <summary>
        /// Called whenever a relationship of type NodeShapeReferencesRelativeChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="con"></param>
        protected virtual void OnRelativeChildShapeElementAdded(NodeShapeReferencesRelativeChildren con)
        {
            if (IsDisplayingNodeShape(con.ChildShape))
                return;

            DiagramItemElementViewModel vm = this.ViewModelStore.Factory.CreateDiagramItemViewModel(con.ChildShape.GetDomainClassId(), this.Diagram, con.ChildShape);
            this.AddRelativeChild(vm);
        }

        /// <summary>
        /// Called whenever a relationship of type NodeShapeReferencesNestedChildren is removed and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnNestedChildShapeElementRemoved(ElementDeletedEventArgs args)
        {
            NodeShapeReferencesNestedChildren con = args.ModelElement as NodeShapeReferencesNestedChildren;
            NodeShape nodeShape = con.ChildShape;
            if (nodeShape != null)
            {
                for(int i = this.nestedChildItems.Count -1 ; i >= 0; i-- )
                {
                    if (this.nestedChildItems[i].ShapeElement.Id == nodeShape.Id)
                    {
                        BaseDiagramItemElementViewModel vm = this.nestedChildItems[i];
                        this.RemoveNestedChild(vm);
                        vm.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Called whenever a relationship of type NodeShapeReferencesRelativeChildren is removed and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnRelativeChildShapeElementRemoved(ElementDeletedEventArgs args)
        {
            NodeShapeReferencesRelativeChildren con = args.ModelElement as NodeShapeReferencesRelativeChildren;
            NodeShape nodeShape = con.ChildShape;
            if (nodeShape != null)
            {
                for (int i = this.relativeChildItems.Count - 1; i >= 0; i--)
                {
                    if (this.relativeChildItems[i].ShapeElement.Id == nodeShape.Id)
                    {
                        BaseDiagramItemElementViewModel vm = this.relativeChildItems[i];
                        this.RemoveRelativeChild(vm);
                        vm.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Called whenever the location of the hosted shape changes.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnLocationChanged(ElementPropertyChangedEventArgs args)
        {
            PointD oldLocation = this.itemLocation;
            PointD newLocation = (PointD)args.NewValue;
            if (this.Location != newLocation)
            {
                this.itemLocation = newLocation;

                if (oldLocation.X != this.itemLocation.X || oldLocation.Y != this.itemLocation.Y)
                {
                    OnPropertyChanged("Location");

                    if (oldLocation.X != this.itemLocation.X)
                    {
                        OnPropertyChanged("Left");
                    }

                    if (oldLocation.Y != this.itemLocation.Y)
                    {
                        OnPropertyChanged("Top");
                    }
                }
            }
        }

        /// <summary>
        /// Called whenever the location of the hosted shape changes.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnAbsoluteLocationChanged(ElementPropertyChangedEventArgs args)
        {
            OnPropertyChanged("AbsoluteLocation");
            OnPropertyChanged("AbsoluteLeft");
            OnPropertyChanged("AbsoluteTop");
        }        

        /// <summary>
        /// Called whenever the size of the hosted shape changes.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnSizeChanged(ElementPropertyChangedEventArgs args)
        {
            if (this.Size != (SizeD)args.NewValue)
            {
                SizeD oldSize = this.itemSize;
                this.itemSize = (SizeD)args.NewValue;

                if (oldSize.Width != this.itemSize.Width || oldSize.Height != this.itemSize.Height)
                {
                    OnPropertyChanged("Size");

                    if (oldSize.Width != this.itemSize.Width)
                        OnPropertyChanged("Width");

                    if (oldSize.Height != this.itemSize.Height)
                        OnPropertyChanged("Height");
                }
            }
        }
       
        #endregion

        /// <summary>
        /// Subscribes to events for the current hosted diagram.
        /// </summary>
        protected virtual void Subscribe()
        {
            // subscribe to add element (nested/relative) events
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesNestedChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementAddedEventArgs>(OnNestedChildShapeElementAdded));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesRelativeChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementAddedEventArgs>(OnRelativeChildShapeElementAdded));

            // subscribe to remove element (nested/relative) events
            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesNestedChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementDeletedEventArgs>(OnNestedChildShapeElementRemoved));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesRelativeChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementDeletedEventArgs>(OnRelativeChildShapeElementRemoved));

            // subscribe to property changed events
            //this.ShapeElement.LocationChanged += new NodeShape.LocationChangedEventHandler(OnLocationChanged);
            //this.ShapeElement.SizeChanged += new NodeShape.SizeChangedEventHandler(OnSizeChanged);
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(NodeShape.LocationDomainPropertyId), this.ShapeElement.Id, OnLocationChanged);
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(NodeShape.AbsoluteLocationDomainPropertyId), this.ShapeElement.Id, OnAbsoluteLocationChanged);
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(NodeShape.SizeDomainPropertyId), this.ShapeElement.Id, OnSizeChanged);
        }

        /// <summary>
        /// Unsubscribes from events for the current hosted diagram.
        /// </summary>
        protected virtual void Unsubscribe()
        {
            // unsubscribe from add element (nested/relative) events
            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesNestedChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementAddedEventArgs>(OnNestedChildShapeElementAdded));

            this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesRelativeChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementAddedEventArgs>(OnRelativeChildShapeElementAdded));

            // unsubscribe from remove element (nested/relative) events
            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesNestedChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementDeletedEventArgs>(OnNestedChildShapeElementRemoved));

            this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(NodeShapeReferencesRelativeChildren.DomainClassId),
                true, this.ShapeElement.Id, new Action<ElementDeletedEventArgs>(OnRelativeChildShapeElementRemoved));

            // unsubscribe from property changed events
            // this.ShapeElement.LocationChanged -= new NodeShape.LocationChangedEventHandler(OnLocationChanged);
            // this.ShapeElement.SizeChanged -= new NodeShape.SizeChangedEventHandler(OnSizeChanged);
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(NodeShape.LocationDomainPropertyId), this.ShapeElement.Id, OnLocationChanged);
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(NodeShape.AbsoluteLocationDomainPropertyId), this.ShapeElement.Id, OnAbsoluteLocationChanged);
            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(NodeShape.SizeDomainPropertyId), this.ShapeElement.Id, OnSizeChanged);
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.ShapeElement != null)
                Unsubscribe();

            for (int i = this.nestedChildItems.Count - 1; i >= 0; i--)
            {
                BaseDiagramItemElementViewModel vm = nestedChildItems[i];
                this.RemoveNestedChild(vm);
                vm.Dispose();
            }


            for (int i = this.relativeChildItems.Count - 1; i >= 0; i--)
            {
                BaseDiagramItemElementViewModel vm = relativeChildItems[i];
                this.RemoveRelativeChild(vm);
                vm.Dispose();
            }

            this.ShapeElement = null;
            this.parentItem = null;

            base.OnDispose();
        }

    }
}

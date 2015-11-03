using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Operations;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This is the base class for all view models displayed as tree view items.
    /// This acts as an adapter between a raw data object and a TreeViewItem.
    /// </summary>
    /// <remarks>
    /// Inspired by Josh Smith http://www.codeproject.com/KB/WPF/TreeViewWithViewModel.aspx
    /// </remarks>
    public abstract class BaseModelElementTreeViewModel : BaseModelElementViewModel
    {
        private ObservableCollection<BaseModelElementTreeViewModel> childrenCollectionStorage;
        private ReadOnlyObservableCollection<BaseModelElementTreeViewModel> childrenCollectionStorageReadOnly;

        private bool isExpanded = false;
        private bool isSelected = false;

        private bool bCreateContextMenus = false;

        private BaseModelElementTreeViewModel parent = null;
        private MainModelTreeViewModel mainModelTreeVm;

        private ElementLink elementLink;
        private Guid domainRoleId;
        
        private DomainClassInfo elementInfo = null;
        private DomainRelationshipInfo relationshipInfo = null;

        private MenuItemViewModel contextMenu = null;
        
        /// <summary>
        /// Element link order.
        /// </summary>
        private List<Guid> elementLinkOrder;

        private Guid linkDomainClassId;
        private DomainRelationshipAdvancedInfo advancedRSInfo = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing view models.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="link">Element link, targeting the hosted element.</param>
        /// <param name="domainRoleId">Domain role id of the role that the hosted element belongs to.</param>
        /// <param name="parent">Parent of this view model. Can be null.</param>
        /// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
        protected BaseModelElementTreeViewModel(ViewModelStore viewModelStore, ModelElement element, ElementLink link, Guid domainRoleId, BaseModelElementTreeViewModel parent, MainModelTreeViewModel mainModelTreeVm)
            :this(viewModelStore, element, link, domainRoleId, parent, false, false, mainModelTreeVm)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing view models.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="link">Element link, targeting the hosted element.</param>
        /// <param name="domainRoleId">Domain role id of the role that the hosted element belongs to.</param>
        /// <param name="parent">Parent of this view model. Can be null.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
        /// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected BaseModelElementTreeViewModel(ViewModelStore viewModelStore, ModelElement element, ElementLink link, Guid domainRoleId, BaseModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, MainModelTreeViewModel mainModelTreeVm)
            : base(viewModelStore, element, bHookUpEvents, false)
        {
            this.parent = parent;
            this.mainModelTreeVm = mainModelTreeVm;
                       
            this.bCreateContextMenus = bCreateContextMenus;

            this.elementLink = link;
            this.domainRoleId = domainRoleId;

            this.elementLinkOrder = new List<Guid>();
            if (link != null)
                this.linkDomainClassId = link.GetDomainClass().Id;
            else
                this.linkDomainClassId = Guid.Empty;

            Initialize();
        }

        /// <summary>
        /// Gets the sorting provider which is to be used to apply a specific sorting order while inserting new elements into the children collection.
        /// </summary>
        public abstract IModelTreeSortingProvider SortingProvider { get; }

        /// <summary>
        /// Gets or sets the global context menu provider.
        /// </summary>
        public abstract IModelTreeContextMenuProvider ContextMenuProvider { get; }

        /// <summary>
        /// Get the relationship info.
        /// </summary>
        public DomainRelationshipInfo RelationshipInfo
        {
            get
            {
                if (this.relationshipInfo == null && this.elementLink != null)
                    this.relationshipInfo = this.ElementLink.GetDomainRelationship();

                return this.relationshipInfo;
            }
            internal set
            {
                this.relationshipInfo = value;
            }
        }

        /// <summary>
        /// Get the advanced relationship info.
        /// </summary>
        public DomainRelationshipAdvancedInfo AdvancedRelationshipInfo
        {
            get
            {
                if (advancedRSInfo == null)
                {
                    if (this.RelationshipInfo != null)
                        advancedRSInfo = this.Store.DomainDataAdvDirectory.GetRelationshipInfo(this.RelationshipInfo.Id);
                    else
                        advancedRSInfo = this.Store.DomainDataAdvDirectory.GetRelationshipInfo(this.ElementLinkDomainClassId);
                }

                return this.advancedRSInfo;
            }
        }

        /// <summary>
        /// Get the element info.
        /// </summary>
        public DomainClassInfo ElementInfo
        {
            get
            {
                if (this.elementInfo == null)
                    this.elementInfo = this.Element.GetDomainClass();

                return this.elementInfo;
            }
            internal set
            {
                this.elementInfo = value;
            }
        }

        /// <summary>
        /// Gets the element link order.
        /// </summary>
        public List<Guid> ElementLinkOrder
        {
            get
            {
                return this.elementLinkOrder;
            }
        }

        /// <summary>
        /// Gets the element link, targeting the hosted element.
        /// </summary>
        public ElementLink ElementLink
        {
            get
            {
                return this.elementLink;
            }
        }

        /// <summary>
        /// Gets the element link domain class id.
        /// </summary>
        public Guid ElementLinkDomainClassId
        {
            get
            {
                return this.linkDomainClassId;
            }
        }

        /// <summary>
        /// Gets the domain role id of the role that the hosted element belongs to.
        /// </summary>
        public Guid DomainRoleId
        {
            get
            {
                return this.domainRoleId;
            }
        }

        /// <summary>
        /// Gets the nested depth of this item.
        /// </summary>
        public int Depth
        {
            get
            {
                if (this.Parent != null)
                    return 1 + this.Parent.Depth;

                return 0;
            }
        }

        /// <summary>
        /// Initialize the model.
        /// </summary>
        protected override void Initialize()
        {
            childrenCollectionStorage = new ObservableCollection<BaseModelElementTreeViewModel>();
            childrenCollectionStorageReadOnly = new ReadOnlyObservableCollection<BaseModelElementTreeViewModel>(childrenCollectionStorage);

            base.Initialize();
        }

        /// <summary>
        /// Delete the model element that is hosted by this view model.
        /// </summary>
        /// <param name="ensureDelete">Ensures if the user truly wants to delete the element.</param>
        public abstract void Delete(bool ensureDelete);

        /// <summary>
        /// Delete the model element that is hosted by this view model.
        /// </summary>
        public void Delete()
        {
            Delete(true);
        }

        /// <summary>
        /// Method which adds an element to the children property for treeview display. You can override
        /// this method to create custom sorting behaviour.
        /// </summary>
        /// <param name="link">Embedding relationship including the given model element as the child (target).</param>
        /// <param name="viewModel">Domain model representing the child element to be added to children property for treeview display.</param>
        public virtual void AddElementToCollection(ElementLink link, BaseModelElementTreeViewModel viewModel)
        {
            this.SortingProvider.InsertElement(this, this.childrenCollectionStorage, link, viewModel);
        }

        /// <summary>
        /// Method which removes the given view model from the children property
        /// </summary>
        /// <param name="viewModel">Domain model representing the child element to be removed from the children property.</param>
        public virtual void DeleteElementFromCollection(BaseModelElementTreeViewModel viewModel)
        {
            if (childrenCollectionStorage.Contains(viewModel))
                childrenCollectionStorage.Remove(viewModel);
        }

        /// <summary>
        /// Finds a view model that is representing the given model element.
        /// </summary>
        /// <param name="element">Model element.</param>
        /// <returns>View model if found; Null otherwise.</returns>
        public virtual BaseModelElementTreeViewModel FindViewModel(ModelElement element)
        {
            if (element == null)
                return null;

            if (element == this.Element)
                return this;

            // search the children (without their children) first
            foreach (BaseModelElementTreeViewModel viewModel in this.ChildrenStorage)
                if (viewModel.Element == element)
                    return viewModel;

            // continue search among children's children
            foreach (BaseModelElementTreeViewModel viewModel in this.ChildrenStorage)
            {
                BaseModelElementTreeViewModel modelFound = viewModel.FindViewModel(element);
                if (modelFound != null)
                    return modelFound;
            }

            return null;
        }

        /// <summary>
        /// Creates the context menu view model for this tree item view model. Applies the local context menu provider than the global context menu provider.
        /// </summary>
        protected abstract MenuItemViewModel CreateContextMenu();

        /// <summary>
        /// Creates context menus to add child items as children of the specified menu item vm.
        /// </summary>
        /// <param name="menuItemAdd">Menu item vm to hold newly created context menu items.</param>
        protected virtual void CreateAddElementsContextMenu(MenuItemViewModel menuItemAdd)
        {

        }

        /// <summary>
        /// Gets the context menu view model for this tree item view model.
        /// </summary>
        public MenuItemViewModel ContextMenu
        {
            get
            {
                if (contextMenu != null)
                    contextMenu.Dispose();
                contextMenu = null;

                contextMenu = CreateContextMenu();
                return contextMenu;
            }
        }

        /// <summary>
        /// Merged children of the ModelElement for TreeView.
        /// </summary>
        protected ObservableCollection<BaseModelElementTreeViewModel> ChildrenStorage
        {
            get
            {
                return childrenCollectionStorage;
            }
        }

        /// <summary>
        /// Read only collection of merged children of the ModelElement for TreeView.
        /// Dont use it to add Children as this will not update the model. Instead, add/set children to their corresponding properties.
        /// </summary>
        public ReadOnlyObservableCollection<BaseModelElementTreeViewModel> Children
        {
            get
            {
                return childrenCollectionStorageReadOnly;
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (isExpanded && parent != null)
                    parent.IsExpanded = true;
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    if (value)
                    {
                        // expand first
                        if (this.Parent != null)
                            if (!this.Parent.IsExpanded)
                            {
                                this.Parent.IsExpanded = true;
                            }
                    }

                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// Gets whether this view model host the root domain model element or not.
        /// </summary>
        public abstract bool IsDomainModel { get; }

        /// <summary>
        /// Gets whether to create context menus.
        /// </summary>
        protected bool DoCreateContextMenus
        {
            get { return bCreateContextMenus; }
        }

        /// <summary>
        /// Model tree view model containing this view model.
        /// </summary>
        public MainModelTreeViewModel MainModelTreeViewModel
        {
            get { return this.mainModelTreeVm; }
        }

        /// <summary>
        /// Parent view model of this view model.
        /// </summary>
        public BaseModelElementTreeViewModel Parent
        {
            get { return parent; }
        }

        /// <summary>
        /// Cut command executed.
        /// </summary>
        public virtual void OnCutCommandExecuted()
        {
            if (!this.IsDomainModel)
            {
                using (new WaitCursor())
                {
                    try
                    {
                        Collection<ModelElement> modelElements = new Collection<ModelElement>();
                        modelElements.Add(this.Element);

                        CopyAndPasteOperations.ExecuteCut(modelElements);
                    }
                    catch (System.Exception ex)
                    {
                        this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Cut command can execute.
        /// </summary>
        public virtual bool OnCutCommandCanExecute()
        {
            if (!this.IsDomainModel)
            {
                Collection<ModelElement> modelElements = new Collection<ModelElement>();
                modelElements.Add(this.Element);

                return CopyAndPasteOperations.CanExecuteMove(modelElements);
            }

            return false;
        }

        /// <summary>
        /// Copy command executed.
        /// </summary>
        public virtual void OnCopyCommandExecuted()
        {
            if (!this.IsDomainModel)
            {
                using (new WaitCursor())
                {
                    try
                    {
                        Collection<ModelElement> modelElements = new Collection<ModelElement>();
                        modelElements.Add(this.Element);

                        CopyAndPasteOperations.ExecuteCopy(modelElements);
                    }
                    catch (System.Exception ex)
                    {
                        this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        public virtual bool OnCopyCommandCanExecute()
        {
            if (!this.IsDomainModel)
            {
                Collection<ModelElement> modelElements = new Collection<ModelElement>();
                modelElements.Add(this.Element);

                return CopyAndPasteOperations.CanExecuteCopy(modelElements);
            }

            return false;
        }

        /// <summary>
        /// Paste command executed.
        /// </summary>
        public virtual void OnPasteCommandExecuted()
        {
            using (new WaitCursor())
            {
                try
                {
                    ValidationResult result = CopyAndPasteOperations.ExecutePaste(this.Element);
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
        }

        /// <summary>
        /// Paste command can execute.
        /// </summary>
        public virtual bool OnPasteCommandCanExecute()
        {
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
                    return CopyAndPasteOperations.CanExecutePaste(this.Element, idataObject);

                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Clear resources.
        /// </summary>
        protected override void OnDispose()
        {
            if (contextMenu != null)
                contextMenu.Dispose();
            contextMenu = null;

            base.OnDispose();

            this.IsSelected = false;

            if (this.Parent != null)
                if( Parent.Children != null )
                    this.Parent.DeleteElementFromCollection(this);

            if (this.childrenCollectionStorage != null)
            {
                for (var i = childrenCollectionStorage.Count - 1; i >= 0; i--)
                {
                    childrenCollectionStorage[i].Dispose();
                }
            }

            this.parent = null;
            this.childrenCollectionStorage = null;
            this.childrenCollectionStorageReadOnly = null;
            //this.localContextMenuProvider = null;
            //this.localSortingProvider = null;
        }
    }
}

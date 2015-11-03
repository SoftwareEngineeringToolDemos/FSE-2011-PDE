using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Deletion;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// Element view model for the tree view.
    /// 
    /// Initialization (1 and 2 only if If DoHookUpEvents = True): 
    /// 1. Subscribe to Add and Delete events specific to the children of each model element, which we represent through the view 
    ///    model. Those events are thrown whenever an item is added or deleted (Not during serialization!!!).
    /// 2. Add view models for existings elements, because when deserializing we dont get the event call mentioned above.
    ///
    /// Context Menus
    /// 1. Create default context menu items for adding and deleteting elements. 
    /// 2. During the creation of all default menu items:
    ///    Call menu providers (if not null) to process "ShouldCreateMenuItem" method.
    /// 3. After the creation of all default menu items: 
    ///    Call menu providers to postprocess the created context menu. 
    ///    This way, custom menu items can be added to the context menu.
    /// </summary>
    public class ModelElementTreeViewModel : BaseModelElementTreeViewModel
    {
        #region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="element">VModell represented by this view model.</param>
		/// <param name="link">Element link, targeting the hosted element.</param>
		/// <param name="domainRoleId">Domain role id of the role that the hosted element belongs to.</param>
		/// <param name="parent">Parent of this view model.</param>
		/// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
		/// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
		/// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelElementTreeViewModel(ViewModelStore viewModelStore, ModelElement element, ElementLink link, System.Guid domainRoleId, ModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, MainModelTreeViewModel mainModelTreeVm)
            : base(viewModelStore, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm)
        {
		}
		#endregion

        /// <summary>
        /// Gets the parent children mapping dictionary. The first Guid represents model context id, second a domain class ID of an element.
        /// The list is a collection of domain relationship DomainClassIds.
        /// </summary>
        /// <remarks>
        /// The content of this dictionary is provided in the initialize method of the derived model tree class.
        /// </remarks>
        public Dictionary<Guid, Dictionary<Guid, List<Guid>>> ParentChildrenMapping
        {
            get
            {
                return this.Store.DomainDataAdvDirectory.ParentChildrenMapping;
            }
        }

        /// <summary>
        /// Gets the parent children mapping dictionary for context menu that should not be created. 
        /// The first Guid represents model context id, second a domain class ID of an element.
        /// The list is a collection of domain relationship DomainClassIds.
        /// </summary>
        /// <remarks>
        /// The content of this dictionary is provided in the initialize method of the derived model tree class.
        /// </remarks>
        public Dictionary<Guid, Dictionary<Guid, List<Guid>>> ParentChildrenCMMapping
        {
            get
            {
                return this.Store.DomainDataAdvDirectory.ParentChildrenCMMapping;
            }
        }

        #region Initialization
        /// <summary>
        /// Initializes the view model for the VModell tree item.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void Initialize()
        {
            base.Initialize();

            List<Guid> relationshipOrder;
            ParentChildrenMapping[this.ModelData.CurrentModelContext.ModelContextId].TryGetValue(this.ElementInfo.Id, out relationshipOrder);

            if (relationshipOrder != null)
            {
                foreach (Guid relationshipDCId in relationshipOrder)
                {
                    DomainRelationshipInfo relationshipInfo = this.Store.DomainDataDirectory.GetDomainRelationship(relationshipDCId);
                    if (DoHookUpEvents)
                    {
                        DomainRelationshipAdvancedInfo advancedInfo = this.Store.DomainDataAdvDirectory.GetRelationshipInfo(relationshipDCId);
                        //if (!advancedInfo.TargetRoleIsUIBrowsable || !advancedInfo.TargetRoleIsGenerated)
                        //if (!advancedInfo.SourceRoleIsUIBrowsable || !advancedInfo.SourceRoleIsGenerated)
                        if (!advancedInfo.SourceRoleIsUIBrowsable )
                            continue;
   
                        // Subscribe to add and delete element events
                        this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id), true,
                            this.Element.Id, new System.Action<ElementAddedEventArgs>(OnChildElementAdded));

                        this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id), true,
                            this.Element.Id, new System.Action<ElementDeletedEventArgs>(OnChildElementDeleted));

                        // Subscribe to role player change events
                        this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id), true,
                            this.Element.Id, new System.Action<RolePlayerChangedEventArgs>(OnRolePlayerChanged));

                        this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id),
                            this.Element.Id, new System.Action<RolePlayerOrderChangedEventArgs>(OnRolePlayerMoved));
                        
                    }

                    // element link order
                    this.ElementLinkOrder.Add(relationshipInfo.Id);

                    System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(this.Element, GetSourceDomainRole(relationshipInfo).Id);
                    foreach (ElementLink link in links)
                    {
                        BaseModelElementTreeViewModel vm = AddChildElement(link, DomainRoleInfo.GetTargetRolePlayer(link), true);
                        vm.RelationshipInfo = relationshipInfo;
                        vm.ElementInfo = GetTargetDomainRole(relationshipInfo).RolePlayer;
                    }
                }
            }
        }

        #region ChildElements - Add and Delete Methods
        /// <summary>
        /// Adds a view model for the given element to the children collection of the current vm.
        /// </summary>
        /// <param name="relationship">Relationship.</param>
        /// <param name="element">Element.</param>
        /// <param name="isInDeserialization">True if deserialization is in process; False otherwise.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected virtual BaseModelElementTreeViewModel AddChildElement(ElementLink relationship, ModelElement element, bool isInDeserialization)
        {
            if (element == null || relationship == null)
                return null;

            // check if already added
            if (!isInDeserialization)
                foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree.BaseModelElementTreeViewModel vm in this.Children)
                    // this can actually happen without any error occuring, because it depends on
                    // the order of transactions.. e.g.:
                    // 1. Add parent in first transaction. Add child in second --> this clause will not occur.
                    // 2. Add parent and child in one transaction. This clause will occur, because parent
                    //    automatically adds its children and there is no easy way of preventing this method from
                    //    beeing called.
                    if (vm.Element.Id == element.Id)
                        return vm;

            // create new view model for this specified element
            ModelElementTreeViewModel viewModel = this.ViewModelStore.Factory.CreateModelElementTreeViewModel(element, relationship,
                GetTargetDomainRole(relationship.GetDomainRelationship()).Id, this, DoHookUpEvents, DoCreateContextMenus, this.MainModelTreeViewModel);

            if (viewModel == null)
                throw new System.ArgumentNullException("Could not resolve VM for " + element.ToString());

            // add new VModellvariante into children collection
            this.AddElementToCollection(relationship, viewModel);

            // set selection to new element
            if (!isInDeserialization)
                if (this.MainModelTreeViewModel != null)
                    if (this.MainModelTreeViewModel.IsActiveView && !this.ViewModelStore.InLoad)
                    {
                        //viewModel.IsSelected = true;
                        if (viewModel.Parent != null)
                            if (!viewModel.Parent.IsExpanded)
                                viewModel.Parent.IsExpanded = true;
                    }

            return viewModel;
        }

        /// <summary>
        /// Deletes a view model for the given element from the children collection of the current vm.
        /// </summary>
        /// <param name="element">Element.</param>
        protected virtual void RemoveChildElement(ModelElement element)
        {
            // remove VModellvariante from children collection
            BaseModelElementTreeViewModel viewModel = this.FindViewModel(element);
            if (viewModel != null)
                viewModel.Dispose();
            viewModel = null;
        }

        /// <summary>
        /// Called whenever a new relationship is added.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void OnChildElementAdded(ElementAddedEventArgs args)
        {
            ElementLink relationship = args.ModelElement as ElementLink;
            if (DomainRoleInfo.GetSourceRolePlayer(relationship) == Element)
            {
                AddChildElement(relationship, DomainRoleInfo.GetTargetRolePlayer(relationship), false);
            }
        }
      
        /// <summary>
        /// Called whenever an existing relationship is deleted.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void OnChildElementDeleted(ElementDeletedEventArgs args)
        {
            ElementLink relationship = args.ModelElement as ElementLink;
            if (DomainRoleInfo.GetSourceRolePlayer(relationship) == Element)
            {
                RemoveChildElement(DomainRoleInfo.GetTargetRolePlayer(relationship));
            }
        }

        /// <summary>
        /// Called whenever a role players in a relationship change.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void OnRolePlayerChanged(RolePlayerChangedEventArgs args)
        {
            ElementLink relationship = args.ElementLink as ElementLink;
            if (args.OldRolePlayer == Element)
            {
                // remove VModellvariante from children collection
                RemoveChildElement(DomainRoleInfo.GetTargetRolePlayer(relationship));
            }
            if (args.NewRolePlayer == Element)
            {
                AddChildElement(relationship, DomainRoleInfo.GetTargetRolePlayer(relationship), false);
            }
        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected virtual void OnRolePlayerMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (this.SortingProvider != null)
                if (this.SortingProvider.ModelTreeSortingState != Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree.ModelTreeSortingState.Sorted)
                    if (args.SourceElement == this.Element)
                    {
                        // find index of domain class of the required type first
                        for (int i = 0; i < this.ChildrenStorage.Count; i++)
                            if (this.ChildrenStorage[i].ElementLinkDomainClassId == args.DomainRelationship.Id)
                            {
                                this.ChildrenStorage.Move(i + args.OldOrdinal, i + args.NewOrdinal);
                                break;
                            }
                    }
            /*
            if (this.SortingProvider != null)
                if (this.SortingProvider.ModelTreeSortingState != ModelTreeSortingState.Sorted)
                {
                    if (args.SourceElement == this.Element)
                    {
                        // find index of domain class of the required type first
                        for (int i = 0; i < this.ChildrenStorage.Count; i++)
                            if (this.ChildrenStorage[i].ElementLinkDomainClassId == args.DomainRelationship.Id)
                            {
                                for (int y = i; y < this.ChildrenStorage.Count; y++)
                                {
                                    if (this.ChildrenStorage[y].Element == args.CounterpartRolePlayer)
                                    {
                                        if (args.NewOrdinal == (y - i))
                                            return;

                                        // reorder elements
                                        System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> lllinks = DomainRoleInfo.GetElementLinks<ElementLink>(this.Element, DomainModelElement.GetSourceDomainRole(args.DomainRelationship).Id);
                                        for (int ii = 0; ii < lllinks.Count; ii++)
                                            for (int iy = i; iy < this.ChildrenStorage.Count; iy++)
                                            {
                                                if (this.ChildrenStorage[iy].ElementLink == lllinks[ii])
                                                {
                                                    // need to move?
                                                    if (iy - i != ii)
                                                        this.ChildrenStorage.Move(iy, ii);

                                                    break;
                                                }
                                            }
                                    }
            
                                }
                                //this.ChildrenStorage.Move(i + args.OldOrdinal, i + args.NewOrdinal);
                                break;
                            }
                    }
                }*/

            /*
            if (args.SourceElement == this.Element)
            {
                // find index of domain class of the required type first
                for (int i = 0; i < this.ChildrenStorage.Count; i++)
                    if (this.ChildrenStorage[i].ElementLinkDomainClassId == args.DomainRelationship.Id)
                    {
                        this.ChildrenStorage.Move(i + args.OldOrdinal, i + args.NewOrdinal);
                        break;
                    }
            }*/
        }
        #endregion

        /// <summary>
        /// Verifies if a specified domain relationship is an embedding relationship.
        /// </summary>
        /// <param name="relationshipDomainClassId">Relationship DomainClassId.</param>
        /// <returns>True if a specified domain relationship is an embedding relationship; False otherwise.</returns>
        public bool IsEmbeddingRelationship(Guid relationshipDomainClassId)
        {
            if (this.Element == null)
                return false;

            DomainRelationshipAdvancedInfo info = this.Store.DomainDataAdvDirectory.FindRelationshipInfo(relationshipDomainClassId);
            if (info is EmbeddingRelationshipAdvancedInfo)
                return true;

            return false;
        }

        private DomainRoleInfo GetSourceDomainRole(DomainRelationshipInfo info)
        {
            for (int i = 0; i < info.DomainRoles.Count; i++)
                if (info.DomainRoles[i].IsSource)
                    return info.DomainRoles[i];

            throw new InvalidOperationException("Couldn't find source domain role in info " + info.Name);
        }
        private DomainRoleInfo GetTargetDomainRole(DomainRelationshipInfo info)
        {
            for (int i = 0; i < info.DomainRoles.Count; i++)
                if (!info.DomainRoles[i].IsSource)
                    return info.DomainRoles[i];

            throw new InvalidOperationException("Couldn't find target domain role in info " + info.Name);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the sorting provider which is to be used to apply a specific sorting order while inserting new elements into the children collection.
        /// </summary>
        public override IModelTreeSortingProvider SortingProvider 
        {
            get
            {
                throw new ArgumentNullException("SortingProvider needs to be specified in the derived class");
            }
        }

        /// <summary>
        /// Gets or sets the global context menu provider.
        /// </summary>
        public override IModelTreeContextMenuProvider ContextMenuProvider 
        {
            get
            {
                throw new ArgumentNullException("ContextMenuProvider needs to be specified in the derived class");
            }
        }

        /// <summary>
        /// Gets whether this view model host the root domain model element or not.
        /// </summary>
        public override bool IsDomainModel
        {
            get
            {
                if (this.ModelData.CurrentModelContext == null)
                    return false;

                if (this.ModelData.CurrentModelContext.RootElement == this.Element)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Gets whether elements can be moved within the tree or not.
        /// </summary>
        public virtual bool CanMoveElements
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region ContextMenu
        /// <summary>
        /// Context menu creation helper class.
        /// </summary>
        public class ContextMenuCreationHelper
        {
            /// <summary>
            /// Role info.
            /// </summary>
            public DomainRoleInfo RoleInfo;

            /// <summary>
            /// Role player info.
            /// </summary>
            public DomainClassInfo RolePlayerInfo;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="rInfo"></param>
            /// <param name="cInfo"></param>
            public ContextMenuCreationHelper(DomainRoleInfo rInfo, DomainClassInfo cInfo)
            {
                RoleInfo = rInfo;
                RolePlayerInfo = cInfo;
            }
        }

        /// <summary>
        /// Creates the context menu for this view model. Applies the local context menu provider than the global context menu provider.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override MenuItemViewModel CreateContextMenu()
        {
            if (!this.DoCreateContextMenus)
                return null;

            MenuItemViewModel contextMenu = new MenuItemViewModel(this.ViewModelStore);

            MenuItemViewModel menuItemAdd = new MenuItemViewModel(this.ViewModelStore);
            menuItemAdd.Text = "Add";
            menuItemAdd.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Add-16.png";

            CreateAddElementsContextMenu(menuItemAdd);

            if (menuItemAdd.Children.Count > 0)
            {
                // sort children context menu

                // add to the main context menu
                contextMenu.Children.Add(menuItemAdd);
            }

            if (this.CanMoveElements)
            {
                #region MoveUp and MoveDown
                if (contextMenu.Children.Count > 0)
                    if (!(contextMenu.Children[contextMenu.Children.Count - 1] is SeparatorMenuItemViewModel))
                        contextMenu.Children.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));

                MenuItemViewModel itemMoveUp = new MenuItemViewModel(this.ViewModelStore);
                itemMoveUp.Text = "Move Up";
                itemMoveUp.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Up-16.png";
                itemMoveUp.IsEnabled = CanMoveUp();
                itemMoveUp.Command = new DelegateCommand(MoveUp);
                contextMenu.Children.Add(itemMoveUp);

                MenuItemViewModel itemMoveDown = new MenuItemViewModel(this.ViewModelStore);
                itemMoveDown.Text = "Move Down";
                itemMoveDown.IsEnabled = CanMoveDown();
                itemMoveDown.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Down-16.png";
                itemMoveDown.Command = new DelegateCommand(MoveDown);
                contextMenu.Children.Add(itemMoveDown);
                #endregion
            }

            #region Cut, Copy, Paste
            if (contextMenu.Children.Count > 0)
                if (!(contextMenu.Children[contextMenu.Children.Count - 1] is SeparatorMenuItemViewModel))
                    contextMenu.Children.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));

            MenuItemViewModel menuItemCut = new MenuItemViewModel(this.ViewModelStore);
            menuItemCut.Text = "Cut";
            menuItemCut.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Cut-16.png";
            menuItemCut.IsEnabled = OnCutCommandCanExecute();
            menuItemCut.Command = new DelegateCommand(OnCutCommandExecuted);
            contextMenu.Children.Add(menuItemCut);

            MenuItemViewModel menuItemCopy = new MenuItemViewModel(this.ViewModelStore);
            menuItemCopy.Text = "Copy";
            menuItemCopy.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Copy-16.png";
            menuItemCopy.IsEnabled = OnCopyCommandCanExecute();
            menuItemCopy.Command = new DelegateCommand(OnCopyCommandExecuted);
            contextMenu.Children.Add(menuItemCopy);

            MenuItemViewModel menuItemPaste = new MenuItemViewModel(this.ViewModelStore);
            menuItemPaste.Text = "Paste";
            menuItemPaste.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Ribbon/Paste-16.png";
            menuItemPaste.IsEnabled = OnPasteCommandCanExecute();
            menuItemPaste.Command = new DelegateCommand(OnPasteCommandExecuted);
            contextMenu.Children.Add(menuItemPaste);
            #endregion

            if (!this.IsDomainModel)
            {
                #region Delete menu item
                if (!this.AdvancedRelationshipInfo.TargetRoleIsUIReadOnly)
                {
                    bool bShouldAdd0 = true;
                    if (this.ContextMenuProvider != null)
                        bShouldAdd0 = this.ContextMenuProvider.ShouldCreateMenuItem(ModelTreeContextMenuItemType.DeleteElementMenuItem,
                            this.Element.GetType(), this.Parent.Element, this.Element);

                    if (bShouldAdd0)
                    {
                        if (contextMenu.Children.Count > 0)
                            if (!(contextMenu.Children[contextMenu.Children.Count - 1] is SeparatorMenuItemViewModel))
                                contextMenu.Children.Add(new SeparatorMenuItemViewModel(this.ViewModelStore));

                        MenuItemViewModel item0 = new MenuItemViewModel(this.ViewModelStore);
                        item0.Text = "Delete";
                        item0.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Delete2-16.png";
                        item0.Command = new DelegateCommand(Delete);

                        contextMenu.Children.Add(item0);
                    }
                }
                #endregion
            }

            if (this.ContextMenuProvider != null)
                this.ContextMenuProvider.ProcessContextMenu(contextMenu, this);

            if (contextMenu.Children.Count == 0)
                return null;
            else
                return contextMenu;
        }

        /// <summary>
        /// Creates context menus to add child items as children of the specified menu item vm.
        /// </summary>
        /// <param name="menuItemAdd">Menu item vm to hold newly created context menu items.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override void CreateAddElementsContextMenu(MenuItemViewModel menuItemAdd)
        {
            base.CreateAddElementsContextMenu(menuItemAdd);

            List<Guid> omittedItems;
            ParentChildrenCMMapping[this.ModelData.CurrentModelContext.ModelContextId].TryGetValue(this.ElementInfo.Id, out omittedItems);

            IModelElementParentProvider parentProvider = (this.Element as IDomainModelOwnable).GetDomainModelServices().ElementParentProvider;
            DomainClassInfo info = this.Element.GetDomainClass();
            foreach (DomainRoleInfo roleInfo in info.AllDomainRolesPlayed)
            {
                if (roleInfo.IsSource)
                {
                    DomainRelationshipAdvancedInfo infoAdv = this.Store.DomainDataAdvDirectory.FindRelationshipInfo(roleInfo.DomainRelationship.Id);
                    if (infoAdv is EmbeddingRelationshipAdvancedInfo)
                        if (!infoAdv.SourceRoleIsUIReadOnly && infoAdv.SourceRoleIsUIBrowsable)
                        //if (!infoAdv.SourceRoleIsUIReadOnly && infoAdv.SourceRoleIsUIBrowsable && infoAdv.SourceRoleIsGenerated)
                        //if (!infoAdv.TargetRoleIsUIReadOnly && infoAdv.TargetRoleIsUIBrowsable && infoAdv.TargetRoleIsGenerated)
                        {
                            if (omittedItems != null)
                                if (omittedItems.Contains(roleInfo.DomainRelationship.Id))
                                    continue;

                            ProcessRoleForContextMenu(parentProvider, menuItemAdd, roleInfo);
                        }
                }
            }
        }

        private void ProcessRoleForContextMenu(IModelElementParentProvider parentProvider, MenuItemViewModel menuItemAdd, DomainRoleInfo roleInfo)
        {
            bool bShouldAdd = true;
            if (this.ContextMenuProvider != null)
                bShouldAdd = this.ContextMenuProvider.ShouldCreateMenuItem(ModelTreeContextMenuItemType.AddElementMenuItem,
                    roleInfo.OppositeDomainRole.RolePlayer.GetType(), this.Element, null);

            if( this.Store.DomainDataAdvDirectory.IsAbstractRelationship(roleInfo.DomainRelationship.Id) )
                bShouldAdd = false;
            else if (roleInfo.Multiplicity == Multiplicity.One ||
                roleInfo.Multiplicity == Multiplicity.ZeroOne)
            {
                global::System.Collections.Generic.IList<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(this.Element, roleInfo.Id);
                if (links.Count == 1)
                    bShouldAdd = false;
            }

            if (bShouldAdd)
            {
                DomainClassInfo rolePlayer = roleInfo.OppositeDomainRole.RolePlayer;
                if (!this.Store.DomainDataAdvDirectory.IsAbstractClass(rolePlayer.Id))
                {                    
                    MenuItemViewModel<ContextMenuCreationHelper> item = new MenuItemViewModel<ContextMenuCreationHelper>(this.ViewModelStore);
                    item.Text = "Add new " + (this.Element as IDomainModelOwnable).GetDomainModelServices().ElementTypeProvider.GetTypeDisplayName(this.Store, rolePlayer.Id);
                    item.Command = new DelegateCommand<ContextMenuCreationHelper>(AddNewElement);
                    //item.CommandParameter = roleInfo;
                    item.CommandParameter = new ContextMenuCreationHelper(roleInfo, rolePlayer);
                    menuItemAdd.Children.Add(item);
                }

                foreach (DomainClassInfo r in rolePlayer.AllDescendants)
                {
                    if (!this.Store.DomainDataAdvDirectory.IsAbstractClass(r.Id))
                    {
                        MenuItemViewModel<ContextMenuCreationHelper> item = new MenuItemViewModel<ContextMenuCreationHelper>(this.ViewModelStore);
                        item.Text = "Add new " + (this.Element as IDomainModelOwnable).GetDomainModelServices().ElementTypeProvider.GetTypeDisplayName(this.Store, r.Id);
                        item.Command = new DelegateCommand<ContextMenuCreationHelper>(AddNewElement);
                        //item.CommandParameter = roleInfo;
                        item.CommandParameter = new ContextMenuCreationHelper(roleInfo, r);
                        menuItemAdd.Children.Add(item);
                    }
                }
            }            
        }

        /// <summary>
        /// Add new element.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public virtual void AddNewElement(ContextMenuCreationHelper cHelper)
        {
            DomainRoleInfo info = cHelper.RoleInfo;
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Create new element"))
            {
                ModelElement modelElement = this.Store.ElementFactory.CreateElement(cHelper.RolePlayerInfo.Id);

                // create and assign name to the element if it has a property marked as "IsElementName"
                if ( (modelElement as IDomainModelOwnable).DomainElementHasName )
                    (modelElement as IDomainModelOwnable).GetDomainModelServices().ElementNameProvider.CreateAndAssignName(this.Element, modelElement);

                RoleAssignment[] roleAssignments = new RoleAssignment[2];
                roleAssignments[0] = new RoleAssignment(info.Id, this.Element);
                roleAssignments[1] = new RoleAssignment(info.OppositeDomainRole.Id, modelElement);

                this.Store.ElementFactory.CreateElementLink(info.DomainRelationship, roleAssignments);

                transaction.Commit();
            }
        }
        
        /// <summary>
        /// Delete the model element that is hosted by this view model.
        /// </summary>
        /// <param name="ensureDelete">Ensures if the user truly wants to delete the element.</param>
        public override void Delete(bool ensureDelete)
        {
            if( this.IsDomainModel )
                throw new System.InvalidOperationException("Can not delete domain model");

            // ask if user is sure, especially if there are dependencies
            DeletionViewModel vm = new DeletionViewModel(this.ViewModelStore);
            List<ModelElement> elements = new List<ModelElement>();
            elements.Add(this.Element);
            vm.Set(elements);

            bool bDelete = true;
            bool bShowDeletionModel = ensureDelete;
            if (bShowDeletionModel)
            {
                System.Collections.ObjectModel.ReadOnlyCollection<DependencyItemViewModel> activeDependencies = vm.GetActiveDependencies();
                if (activeDependencies.Count == 1)
                    if (activeDependencies[0].Category == DependencyItemCategory.Embedded)
                        bShowDeletionModel = false;
            }
            if (bShowDeletionModel)
            {
                bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("DeleteElementsPopup", vm);
                if (result != true)
                    bDelete = false;
            }
            vm.Dispose();
            System.GC.Collect();

            if (bDelete)
            {
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete"))
                {
                    this.Element.Delete();
                    transaction.Commit();
                }
            }
        }
        
        /// <summary>
        /// Moves the current item up.
        /// </summary>		
        public virtual void MoveUp()
        {
            int index = -1;
            DomainRelationshipInfo info = this.ElementLink.GetDomainRelationship();
            for (int i = 0; i < this.Parent.Children.Count; i++)
            {
                if (this.Parent.Children[i].ElementLink.GetDomainRelationship() == info)
                {
                    index++;
                    if (this.Parent.Children[i].ElementLink == this.ElementLink)
                    {
                        using (Transaction t = this.Store.TransactionManager.BeginTransaction("move up"))
                        {
                            this.ElementLink.MoveToIndex(info.DomainRoles[0], index - 1);
                            t.Commit();
                        }
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Verifies if the current item can be moved up or not.
        /// </summary>
        /// <returns>True if the current item can be moved up. False otherwise.</returns>		
        public virtual bool CanMoveUp()
        {
            if (this.Parent == null || this.ElementLink == null || this.Element == null || this.DomainRoleId == System.Guid.Empty)
                return false;

            int index = -1;
            DomainRelationshipInfo info = this.ElementLink.GetDomainRelationship();
            for (int i = 0; i < this.Parent.Children.Count; i++)
            {
                if (this.Parent.Children[i].ElementLink.GetDomainRelationship() == info)
                {
                    index++;
                    if (this.Parent.Children[i].ElementLink == this.ElementLink)
                    {
                        if (index > 0)
                            return true;

                        return false;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Moves the current item down.
        /// </summary>		
        public virtual void MoveDown()
        {
            int index = -1;
            DomainRelationshipInfo info = this.ElementLink.GetDomainRelationship();
            for (int i = 0; i < this.Parent.Children.Count; i++)
            {
                if (this.Parent.Children[i].ElementLink.GetDomainRelationship() == info)
                {
                    index++;
                    if (this.Parent.Children[i].ElementLink == this.ElementLink)
                    {
                        using (Transaction t = this.Store.TransactionManager.BeginTransaction("move down"))
                        {
                            this.ElementLink.MoveToIndex(info.DomainRoles[0], index + 1);
                            t.Commit();
                        }
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Verifies if the current item can be moved down or not.
        /// </summary>
        /// <returns>True if the current item can be moved down. False otherwise.</returns>
        public virtual bool CanMoveDown()
        {
            if (this.Parent == null || this.ElementLink == null || this.Element == null || this.DomainRoleId == System.Guid.Empty)
                return false;

            int index = -1;
            bool bFound = false;
            DomainRelationshipInfo info = this.ElementLink.GetDomainRelationship();
            for (int i = 0; i < this.Parent.Children.Count; i++)
            {
                if (this.Parent.Children[i].ElementLink.GetDomainRelationship() == info)
                {
                    index++;
                    if (bFound)
                        return true;

                    if (this.Parent.Children[i].ElementLink == this.ElementLink)
                        bFound = true;
                }
            }

            return false;
        }		
        #endregion

        #region Dispose
        /// <summary>
        /// Unregister from events although they are weak.
        /// </summary>
        protected override void OnDispose()
        {
            if (DoHookUpEvents)
            {
                List<Guid> relationshipOrder;
                ParentChildrenMapping[this.ModelData.CurrentModelContext.ModelContextId].TryGetValue(this.ElementInfo.Id, out relationshipOrder);

                if (relationshipOrder != null)
                {
                    foreach (Guid relationshipDCId in relationshipOrder)
                    {
                        DomainRelationshipInfo relationshipInfo = this.Store.DomainDataDirectory.GetDomainRelationship(relationshipDCId);

                        // Subscribe to add and delete element events
                        this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id), true,
                            this.Element.Id, new System.Action<ElementAddedEventArgs>(OnChildElementAdded));

                        this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id), true,
                            this.Element.Id, new System.Action<ElementDeletedEventArgs>(OnChildElementDeleted));

                        // Subscribe to role player change events
                        this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id), true,
                            this.Element.Id, new System.Action<RolePlayerChangedEventArgs>(OnRolePlayerChanged));

                        this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(
                            this.Store.DomainDataDirectory.GetDomainRelationship(relationshipInfo.Id),
                            this.Element.Id, new System.Action<RolePlayerOrderChangedEventArgs>(OnRolePlayerMoved));
                    }
                }
            }

            base.OnDispose();
        }
        #endregion
    }
}

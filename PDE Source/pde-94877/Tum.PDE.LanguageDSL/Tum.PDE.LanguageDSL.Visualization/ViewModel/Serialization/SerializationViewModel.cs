using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.LanguageDSL.Visualization.Commands;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    public class SerializationViewModel : BaseDockingViewModel
    {
        private SerializationModel serializationModel;

        private ObservableCollection<SerializedDomainModelViewModel> rootVMs;
        private ReadOnlyObservableCollection<SerializedDomainModelViewModel> rootVMsRO;

        private ObservableCollection<SerializedDomainModelViewModel> allVMs;

        private Collection<object> selectedVMS;
        private Collection<MenuItemViewModel> contextMenuOperations;

        private DelegateCommand selectRelationshipCommand;
        private DelegateCommand moveUpCommand;
        private DelegateCommand moveDownCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelTreeView">Diagram tree view.</param>
        public SerializationViewModel(ViewModelStore viewModelStore, SerializationModel serializationModel)
            : base(viewModelStore)
        {
            this.allVMs = new ObservableCollection<SerializedDomainModelViewModel>();
            this.serializationModel = serializationModel;
            this.selectedVMS = new Collection<object>();

            this.rootVMs = new ObservableCollection<SerializedDomainModelViewModel>();
            this.rootVMsRO = new ReadOnlyObservableCollection<SerializedDomainModelViewModel>(this.rootVMs);

            this.selectRelationshipCommand = new DelegateCommand(SelectRelationshipCommand_Executed);
            this.moveUpCommand = new DelegateCommand(MoveUpCommand_Executed, MoveUpCommand_CanExecute);
            this.moveDownCommand = new DelegateCommand(MoveDownCommand_Executed, MoveDownCommand_CanExecute);

            if (this.serializationModel.SerializedDomainModel != null)
            {
                this.rootVMs.Add(new SerializedDomainModelViewModel(this.ViewModelStore, this.serializationModel.SerializedDomainModel));
            }
            if (this.serializationModel != null)
            {
                foreach (SerializationClass c in this.serializationModel.Children)
                    if (c is SerializedDomainClass)
                        this.AddChild(c as SerializedDomainClass);

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationModelHasChildren.DomainClassId),
                    true, this.serializationModel.Id, new System.Action<ElementAddedEventArgs>(OnChildAdded));
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationModelHasChildren.DomainClassId),
                    true, this.serializationModel.Id, new System.Action<ElementDeletedEventArgs>(OnChildRemoved));
                
            }
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name.
        /// </summary>
        public override string DockingPaneName { get { return "SerializationModel"; } }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public override string DockingPaneTitle { get { return "Serialization Model"; } }
        #endregion

        /// <summary>
        /// Gets all vms.
        /// </summary>
        public ObservableCollection<SerializedDomainModelViewModel> AllVMs
        {
            get
            {
                return this.allVMs;
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
                //OnPropertyChanged("SelectedItems");

                // propagate selection
                SelectedItemsCollection col = new SelectedItemsCollection();
                if (value != null)
                    foreach (SerializationElementViewModel vm in value)
                    {
                        col.Add(vm.GetHostedElement());
                    }

                // see if we need to propagate selection --> based on what is currently selected
                bool bDiffers = false;
                foreach (SerializationElementViewModel vm in this.SelectedItems)
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
        public ReadOnlyObservableCollection<SerializedDomainModelViewModel> RootNodes
        {
            get
            {
                return this.rootVMsRO;
            }
        }

        /// <summary>
        /// Gets the SelectRelationshipCommand.
        /// </summary>
        public DelegateCommand SelectRelationshipCommand
        {
            get
            {
                return this.selectRelationshipCommand;
            }
        }

        /// <summary>
        /// Gets the MoveUpCommand.
        /// </summary>
        public DelegateCommand MoveUpCommand
        {
            get
            {
                return this.moveUpCommand;
            }
        }

        /// <summary>
        /// Gets the MoveDownCommand.
        /// </summary>
        public DelegateCommand MoveDownCommand
        {
            get
            {
                return this.moveDownCommand;
            }
        }

        /// <summary>
        /// SelectRelationshipCommand executed;
        /// </summary>
        public void SelectRelationshipCommand_Executed()
        {
            if (this.SelectedItems.Count == 1)
            {
                SerializedDomainClassViewModel classViewModel = this.SelectedItems[0] as SerializedDomainClassViewModel;
                if (classViewModel != null)
                    if (classViewModel.Parent != null)
                    {
                        SelectedItemsCollection col = new SelectedItemsCollection();
                        col.Add(classViewModel.Parent.GetHostedElement());

                        EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
                    }

                SerializedReferenceRelationshipViewModel refRelViewModel = this.SelectedItems[0] as SerializedReferenceRelationshipViewModel;
                if (refRelViewModel != null)
                    if (!refRelViewModel.IsInFullSerialization)
                    {
                        SelectedItemsCollection col = new SelectedItemsCollection();
                        col.Add(refRelViewModel.SerializationElement);
                        EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
                    }
            }
        }

        /// <summary>
        /// MoveUpCommand executed;
        /// </summary>
        public void MoveUpCommand_Executed()
        {
            MoveElementInSerilizationTree(true); 
            
            UpdateOperations();
        }

        /// <summary>
        /// MoveUpCommand can execute;
        /// </summary>
        public bool MoveUpCommand_CanExecute()
        {
            return CanMoveElementInSerializationTree(true);
        }

        /// <summary>
        /// MoveDownCommand executed;
        /// </summary>
        public void MoveDownCommand_Executed()
        {
            MoveElementInSerilizationTree(false);
            
            UpdateOperations();
        }

        /// <summary>
        /// MoveDownCommand can execute;
        /// </summary>
        public bool MoveDownCommand_CanExecute()
        {
            return CanMoveElementInSerializationTree(false);
        }

        /// <summary>
        /// Updates operation collection.
        /// </summary>
        private void UpdateOperations()
        {
            this.contextMenuOperations = new Collection<MenuItemViewModel>();

            if (this.SelectedItems.Count == 1)
            {
                SerializedDomainClassViewModel classViewModel = this.SelectedItems[0] as SerializedDomainClassViewModel;
                if( classViewModel != null )
                    if (classViewModel.Parent != null)
                    {
                        MenuItemViewModel mv = new MenuItemViewModel(this.ViewModelStore, "Select Relationship");
                        mv.Command = SelectRelationshipCommand;
                        this.contextMenuOperations.Add(mv);
                    }

                SerializedReferenceRelationshipViewModel refRelViewModel = this.SelectedItems[0] as SerializedReferenceRelationshipViewModel;
                if (refRelViewModel != null)
                    if (!refRelViewModel.IsInFullSerialization)
                    {
                        MenuItemViewModel mv = new MenuItemViewModel(this.ViewModelStore, "Select Relationship");
                        mv.Command = SelectRelationshipCommand;
                        this.contextMenuOperations.Add(mv);
                    }
            }

            if (this.SelectedItems.Count > 0)
            {
                AddSeparator();

                MenuItemViewModel mvMoveUp = new MenuItemViewModel(this.ViewModelStore, "Move up", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Up-16.png");
                mvMoveUp.Command = MoveUpCommand;
                if (!MoveUpCommand.CanExecute())
                    mvMoveUp.IsEnabled = false;
                this.contextMenuOperations.Add(mvMoveUp);

                MenuItemViewModel mvMoveDown = new MenuItemViewModel(this.ViewModelStore, "Move down", "pack://application:,,,/Tum.PDE.LanguageDSL.Visualization;component/Resources/Images/Down-16.png");
                mvMoveDown.Command = MoveDownCommand;
                if (!MoveDownCommand.CanExecute())
                    mvMoveDown.IsEnabled = false;
                this.contextMenuOperations.Add(mvMoveDown);
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

        /// <summary>
        /// Determines whether the selected elements in the serialization model can be moved up or down.
        /// </summary>
        /// <param name="bUp"></param>
        /// <returns></returns>
        private bool CanMoveElementInSerializationTree(bool bUp)
        {
            foreach (SerializationElementViewModel vm in this.SelectedItems)
            {
                if (vm is SerializedDomainModelViewModel)
                {
                    return false;
                }
                else if (vm is SerializationAttributeElementViewModel)
                {
                    SerializationAttributeElementViewModel attrVM = vm as SerializationAttributeElementViewModel;
                    if( ImmutabilityExtensionMethods.GetLocks(attrVM.Parent.Element) == Locks.All)
                        return false;

                    if (attrVM.Parent.Children.Contains(attrVM))
                    {
                        if (bUp)
                        {
                            if (attrVM.Parent.Children.Count == 0)
                                return false;

                            if (attrVM.Parent.Children[0] == attrVM)
                                return false;
                        }
                        else
                        {
                            if (attrVM.Parent.Children.Count == 0)
                                return false;

                            if (attrVM.Parent.Children[attrVM.Parent.Children.Count-1] == attrVM)
                                return false;
                        }
                    }
                    else if (attrVM.Parent.Attributes.Contains(attrVM))
                    {
                        if (bUp)
                        {
                            if (attrVM.Parent.Attributes.Count == 0)
                                return false;

                            if (attrVM.Parent.Attributes[0] == attrVM)
                                return false;
                        }
                        else
                        {
                            if (attrVM.Parent.Attributes.Count == 0)
                                return false;

                            if (attrVM.Parent.Attributes[attrVM.Parent.Attributes.Count - 1] == attrVM)
                                return false;
                        }
                    }
                }
                else if (vm is SerializedDomainClassViewModel)
                {
                    SerializedDomainClassViewModel dcVM = vm as SerializedDomainClassViewModel;
                    if (dcVM.Parent == null)
                        return false;

                    if (ImmutabilityExtensionMethods.GetLocks(dcVM.Parent.Element) == Locks.All)
                        return false;

                    if (dcVM.Parent.SerializationElement is SerializedRelationship)
                        if ((dcVM.Parent.SerializationElement as SerializedRelationship).IsInFullSerialization)
                            return false;

                    if (dcVM.Parent.Parent == null)
                        return false;

                    if (bUp)
                        {
                            if (dcVM.Parent.Parent.Children.Count == 0)
                                return false;

                            if (dcVM.Parent.Parent.Children[0] == dcVM.Parent)
                                return false;
                        }
                        else
                        {
                            if (dcVM.Parent.Parent.Children.Count == 0)
                                return false;

                            if (dcVM.Parent.Parent.Children[dcVM.Parent.Parent.Children.Count-1] == dcVM.Parent)
                                return false;
                        }
                }
                else if( vm is SerializedDomainRoleViewModel )
                {
                    return false;
                }
                else if (vm is SerializedEmbeddingRelationshipViewModel)
                {
                    SerializedEmbeddingRelationshipViewModel dcVM = vm as SerializedEmbeddingRelationshipViewModel;
                    if (dcVM.Parent == null)
                        return false;


                    if (ImmutabilityExtensionMethods.GetLocks(dcVM.Parent.Element) == Locks.All)
                        return false;

                    if (bUp)
                    {
                        if (dcVM.Parent.Children.Count == 0)
                            return false;

                        if (dcVM.Parent.Children[0] == dcVM)
                            return false;
                    }
                    else
                    {
                        if (dcVM.Parent.Children.Count == 0)
                            return false;

                        if (dcVM.Parent.Children[dcVM.Parent.Children.Count - 1] == dcVM)
                            return false;
                    }
                }
                else if (vm is SerializedReferenceRelationshipViewModel)
                {
                    SerializedReferenceRelationshipViewModel dcVM = vm as SerializedReferenceRelationshipViewModel;
                    if (dcVM.Parent == null)
                        return false;

                    if (ImmutabilityExtensionMethods.GetLocks(dcVM.Parent.Element) == Locks.All)
                        return false;

                    if (bUp)
                    {
                        if (dcVM.Parent.Children.Count == 0)
                            return false;

                        if (dcVM.Parent.Children[0] == dcVM)
                            return false;
                    }
                    else
                    {
                        if (dcVM.Parent.Children.Count == 0)
                            return false;

                        if (dcVM.Parent.Children[dcVM.Parent.Children.Count - 1] == dcVM)
                            return false;
                    }
                }
            }

            return true;
        }

        private int GetChildIndex(SerializationClassViewModel viewModel, SerializationElementViewModel childVM)
        {
            // get index of childVM in the collection of children of viewModel
            for (int i = 0; i < viewModel.Children.Count; i++)
                if (viewModel.Children[i] == childVM)
                {
                    return i;
                }

            return -1;
        }
        private int GetAttributeIndex(SerializationClassViewModel viewModel, SerializationAttributeElementViewModel attrVM)
        {
            // get index of attrVM in the collection of attributes of viewModel
            for (int i = 0; i < viewModel.Attributes.Count; i++)
                if (viewModel.Attributes[i] == attrVM)
                {
                    return i;
                }

            return -1;
        }

        /// <summary>
        /// Moves the selected elements in the serialization model up or down.
        /// </summary>
        /// <param name="bUp"></param>
        private void MoveElementInSerilizationTree(bool bUp)
        {
            Dictionary<SerializationClassViewModel, SortedDictionary<int, SerializationElementViewModel>> dictionaryChildren = new Dictionary<SerializationClassViewModel, SortedDictionary<int, SerializationElementViewModel>>();
            Dictionary<SerializationClassViewModel, SortedDictionary<int, SerializationAttributeElementViewModel>> dictionaryAttributes = new Dictionary<SerializationClassViewModel, SortedDictionary<int, SerializationAttributeElementViewModel>>();

            // gather information about selected elements, that are to be moved
            foreach (SerializationElementViewModel vm in this.SelectedItems)
            {
                if (vm is SerializationAttributeElementViewModel)
                {
                    SerializationAttributeElementViewModel attrVM = vm as SerializationAttributeElementViewModel;
                    if (attrVM.Parent.Children.Contains(attrVM))
                    {
                        if (!dictionaryChildren.ContainsKey(attrVM.Parent))
                            dictionaryChildren.Add(attrVM.Parent, new SortedDictionary<int, SerializationElementViewModel>());

                        int index = GetChildIndex(attrVM.Parent, attrVM);
                        if (index != -1)
                            dictionaryChildren[attrVM.Parent].Add(index, attrVM);

                    }
                    else if (attrVM.Parent.Attributes.Contains(attrVM))
                    {
                        if (!dictionaryAttributes.ContainsKey(attrVM.Parent))
                            dictionaryAttributes.Add(attrVM.Parent, new SortedDictionary<int, SerializationAttributeElementViewModel>());

                        int index = GetAttributeIndex(attrVM.Parent, attrVM);
                        if (index != -1)
                            dictionaryAttributes[attrVM.Parent].Add(index, attrVM);
                    }
                }
                else if (vm is SerializedDomainClassViewModel)
                {
                    SerializedDomainClassViewModel dcVM = vm as SerializedDomainClassViewModel;
                    if (dcVM.Parent == null)
                        continue;

                    if (dcVM.Parent.SerializationElement is SerializedRelationship)
                        if ((dcVM.Parent.SerializationElement as SerializedRelationship).IsInFullSerialization)
                            continue;

                    if (dcVM.Parent.Parent == null)
                        continue;

                    if (!dictionaryChildren.ContainsKey(dcVM.Parent.Parent))
                        dictionaryChildren.Add(dcVM.Parent.Parent, new SortedDictionary<int, SerializationElementViewModel>());

                    int index = GetChildIndex(dcVM.Parent.Parent, dcVM.Parent);
                    if (index != -1)
                        dictionaryChildren[dcVM.Parent.Parent].Add(index, dcVM.Parent);
                }
                else if (vm is SerializedEmbeddingRelationshipViewModel)
                {
                    SerializedEmbeddingRelationshipViewModel dcVM = vm as SerializedEmbeddingRelationshipViewModel;
                    if (dcVM.Parent == null)
                        continue;

                    if (!dictionaryChildren.ContainsKey(dcVM.Parent))
                        dictionaryChildren.Add(dcVM.Parent, new SortedDictionary<int, SerializationElementViewModel>());

                    int index = GetChildIndex(dcVM.Parent, dcVM);
                    if (index != -1)
                        dictionaryChildren[dcVM.Parent].Add(index, dcVM);
                }
                else if (vm is SerializedReferenceRelationshipViewModel)
                {
                    SerializedReferenceRelationshipViewModel dcVM = vm as SerializedReferenceRelationshipViewModel;
                    if (dcVM.Parent == null)
                        continue;

                    if (!dictionaryChildren.ContainsKey(dcVM.Parent))
                        dictionaryChildren.Add(dcVM.Parent, new SortedDictionary<int, SerializationElementViewModel>());

                    int index = GetChildIndex(dcVM.Parent, dcVM);
                    if (index != -1)
                        dictionaryChildren[dcVM.Parent].Add(index, dcVM);
                }
            }

            // move elements
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move serialization elements up/down"))
            {
                foreach (SerializationClassViewModel key in dictionaryChildren.Keys)
                {
                    SortedDictionary<int, SerializationElementViewModel> sortedDictionary = dictionaryChildren[key];
                    if (bUp)
                    {
                        for (int i = 0; i < sortedDictionary.Keys.Count; ++i)
                        {
                            key.MoveChildren(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) - 1);
                            //key.Children.Move(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) - 1);
                        }
                    }
                    else
                    {
                        for (int i = sortedDictionary.Keys.Count - 1; i >= 0; --i)
                        {
                            key.MoveChildren(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) + 1);
                            //key.Children.Move(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) + 1);
                        }
                    }
                }
                foreach (SerializationClassViewModel key in dictionaryAttributes.Keys)
                {
                    SortedDictionary<int, SerializationAttributeElementViewModel> sortedDictionary = dictionaryAttributes[key];
                    if (bUp)
                    {
                        for (int i = 0; i < sortedDictionary.Keys.Count; ++i)
                        {
                            key.MoveAttributes(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) - 1);
                            //key.Attributes.Move(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) - 1);
                        }
                    }
                    else
                    {
                        for (int i = sortedDictionary.Keys.Count - 1; i >= 0; --i)
                        {
                            key.MoveAttributes(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) + 1);
                            //key.Attributes.Move(sortedDictionary.Keys.ElementAt(i), sortedDictionary.Keys.ElementAt(i) + 1);
                        }
                    }
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Adds a new SerializationClass view model for the given element.
        /// </summary>
        /// <param name="element">ModelContext.</param>
        public void AddChild(SerializationClass element)
        {
            if (!(element is SerializedDomainClass))
                return;

            SerializedDomainClass dc = element as SerializedDomainClass;
            /*if (dc.ParentEmbeddedElements.Count > 0)
                return;*/

            // verify that node hasnt been added yet
            foreach (SerializedDomainModelViewModel viewModel in this.allVMs)
                if (viewModel.SerializationElement.Id == element.Id)
                    return;

            SerializedDomainModelViewModel vm = new SerializedDomainModelViewModel(this.ViewModelStore, dc);
            this.allVMs.Add(vm);

            IOrderedEnumerable<SerializedDomainModelViewModel> items = null;
            items = this.allVMs.OrderBy<SerializedDomainModelViewModel, string>((x) => (x.DomainElementName));

            ObservableCollection<SerializedDomainModelViewModel> temp = new ObservableCollection<SerializedDomainModelViewModel>();
            foreach (SerializedDomainModelViewModel item in items)
                temp.Add(item);

            this.allVMs = temp;

            OnPropertyChanged("AllVMs");
        }

        /// <summary>
        /// Deletes a new SerializationClass view model for the given element.
        /// </summary>
        /// <param name="element">ModelContext.</param>
        public void DeleteChild(SerializationClass element)
        {
            for (int i = this.allVMs.Count - 1; i >= 0; i--)
                if (this.allVMs[i].SerializationElement.Id == element.Id)
                {
                    this.allVMs[i].Dispose();
                    this.allVMs.RemoveAt(i);
                }

            OnPropertyChanged("AllVMs");
        }

        /// <summary>
        /// Called whenever a relationship of type SerializationModelHasChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected virtual void OnChildAdded(ElementAddedEventArgs args)
        {
            SerializationModelHasChildren con = args.ModelElement as SerializationModelHasChildren;
            if (con != null)
            {
                AddChild(con.SerializationClass);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type SerializationModelHasChildren is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
        protected virtual void OnChildRemoved(ElementDeletedEventArgs args)
        {
            SerializationModelHasChildren con = args.ModelElement as SerializationModelHasChildren;
            if (con != null)
            {
                DeleteChild(con.SerializationClass);
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.serializationModel != null)
            {
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationModelHasChildren.DomainClassId),
                    true, this.serializationModel.Id, new System.Action<ElementAddedEventArgs>(OnChildAdded));
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationModelHasChildren.DomainClassId),
                    true, this.serializationModel.Id, new System.Action<ElementDeletedEventArgs>(OnChildRemoved));
            }

            base.OnDispose();
        }
    }
}

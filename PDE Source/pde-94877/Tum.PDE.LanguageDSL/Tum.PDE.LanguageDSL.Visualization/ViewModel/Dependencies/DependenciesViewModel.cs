using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

using Tum.PDE.LanguageDSL.Visualization.Commands;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This view model is used to gather dependencies for specific model elements.
    /// </summary>
    public class DependenciesViewModel : BaseViewModel
    {
        private List<ModelElement> modelElements = null;
        private List<ModelElement> currentExcludedDomainModels = null;
        private DependencyItemCategory[] currentCategories = null;

        private DependenciesData dependenciesData = null;
        private ObservableCollection<DependencyItemViewModel> allDependencies;
        private ObservableCollection<DependencyItemViewModel> displayedDependencies;
        private ReadOnlyObservableCollection<DependencyItemViewModel> displayedDependenciesRO;
        private List<DependencyItemCategory> hiddenCategories;

        private DependenciesSortOrder sortOrder;
        private bool isAscending;

        private bool doSubscribeToEvents;
        private bool allowNavigation = true;

        DependencyItemViewModel selectedItem;

        private bool isEmbeddedCategoryVisible = true;
        private bool isEmbeddingCategoryVisible = true;
        private bool isReferencedCategoryVisible = true;
        private bool isReferencingCategoryVisible = true;

        private int embeddedCount = 0;
        private int embeddingCount = 0;
        private int referencedCount = 0;
        private int referencingCount = 0;

        private DelegateCommand toggleEmbeddedCategoryCommand;
        private DelegateCommand toggleEmbeddingCategoryCommand;
        private DelegateCommand toggleReferencedCategoryCommand;
        private DelegateCommand toggleReferencingCategoryCommand;

        private DelegateCommand sortByNumberCommand;
        private DelegateCommand sortByCategoryCommand;
        private DelegateCommand sortBySourceModelElementCommand;
        private DelegateCommand sortByTargetModelElementCommand;
        private DelegateCommand sortByLinkElementCommand;

        private DelegateCommand navigateToSourceCommand;
        private DelegateCommand navigateToTargetCommand;

        private ObservableCollection<MenuItemViewModel> menuOptions;
        private MenuItemViewModel navigateToSourceMenuItem;
        private MenuItemViewModel navigateToTargetMenuItem;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public DependenciesViewModel(ViewModelStore viewModelStore)
            : this(viewModelStore, false)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="bSubscribeToEvents">True, if changes in the model need to be reflected on this view model.</param>
        public DependenciesViewModel(ViewModelStore viewModelStore, bool bSubscribeToEvents)
            : base(viewModelStore)
        {
            this.allDependencies = new ObservableCollection<DependencyItemViewModel>();
            this.displayedDependencies = new ObservableCollection<DependencyItemViewModel>();
            this.displayedDependenciesRO = new ReadOnlyObservableCollection<DependencyItemViewModel>(displayedDependencies);

            this.sortOrder = DependenciesSortOrder.DependencyCategory;
            this.isAscending = true;

            this.doSubscribeToEvents = bSubscribeToEvents;
            this.hiddenCategories = new List<DependencyItemCategory>();
            //this.hiddenCategories.Add(DependencyItemCategory.Embedded);
            //this.hiddenCategories.Add(DependencyItemCategory.Embedding);

            toggleEmbeddedCategoryCommand = new DelegateCommand(ToggleEmbeddedCategoryCommand_Executed);
            toggleEmbeddingCategoryCommand = new DelegateCommand(ToggleEmbeddingCategoryCommand_Executed);
            toggleReferencedCategoryCommand = new DelegateCommand(ToggleReferencedCategoryCommand_Executed);
            toggleReferencingCategoryCommand = new DelegateCommand(ToggleReferencingCategoryCommand_Executed);

            sortByNumberCommand = new DelegateCommand(SortByNumberCommand_Executed);
            sortByCategoryCommand = new DelegateCommand(SortByCategoryCommand_Executed);
            sortBySourceModelElementCommand = new DelegateCommand(SortBySourceModelElementCommand_Executed);
            sortByTargetModelElementCommand = new DelegateCommand(SortByTargetModelElementCommand_Executed);
            sortByLinkElementCommand = new DelegateCommand(SortByLinkElementCommand_Executed);

            navigateToSourceCommand = new DelegateCommand(NavigateToSourceCommand_Executed);
            navigateToTargetCommand = new DelegateCommand(NavigateToTargetCommand_Executed);

            // create menu
            menuOptions = new ObservableCollection<MenuItemViewModel>();

            navigateToSourceMenuItem = new MenuItemViewModel(viewModelStore, "Navigate to source element");
            navigateToSourceMenuItem.Command = this.NavigateToSourceCommand;
            menuOptions.Add(navigateToSourceMenuItem);

            navigateToTargetMenuItem = new MenuItemViewModel(viewModelStore, "Navigate to target element");
            navigateToTargetMenuItem.Command = this.NavigateToTargetCommand;
            menuOptions.Add(navigateToTargetMenuItem);
        }

        /// <summary>
        /// Gets or sets the selected element.
        /// </summary>
        public DependencyItemViewModel SelectedItem
        {
            get { return this.selectedItem; }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets the current dependencies.
        /// </summary>
        public ReadOnlyObservableCollection<DependencyItemViewModel> DisplayedDependencies
        {
            get { return displayedDependenciesRO; }
        }

        /// <summary>
        /// Sort order in the dependencies view model.
        /// </summary>
        public DependenciesSortOrder SortOrder
        {
            get
            {
                return this.sortOrder;
            }
            protected set
            {
                this.sortOrder = value;
                OnPropertyChanged("SortOrder");
            }
        }

        /// <summary>
        /// Context menu options.
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuOptions
        {
            get 
            {
                if (!AllowNavigation)
                {
                    navigateToSourceMenuItem.IsEnabled = false;
                    navigateToTargetMenuItem.IsEnabled = false;
                }
                else
                {
                    navigateToSourceMenuItem.IsEnabled = true;
                    navigateToTargetMenuItem.IsEnabled = true;
                }
                return this.menuOptions; 
            }
        }

        /// <summary>
        /// Gets the list of all active dependencies.
        /// </summary>
        public ReadOnlyCollection<DependencyItemViewModel> ActiveDependencies
        {
            get 
            {
                List<DependencyItemViewModel> vms = new List<DependencyItemViewModel>();
                vms.AddRange(this.allDependencies);
                return vms.AsReadOnly();
            }
        }

        /// <summary>
        /// Ascending or descending sort order.
        /// </summary>
        public bool IsSortedAscending
        {
            get { return this.isAscending; }
            protected set
            {
                this.isAscending = value;
                OnPropertyChanged("IsSortedAscending");
            }
        }

        /// <summary>
        /// Gets or sets whether navigation to source or target element is allowed or not.
        /// </summary>
        public bool AllowNavigation
        {
            get { return this.allowNavigation; }
            set
            {
                this.allowNavigation = value;
            }
        }

        /// <summary>
        /// True if embedded category is currently displayed.
        /// </summary>
        public bool IsEmbeddedCategoryVisible
        {
            get { return this.isEmbeddedCategoryVisible; }
            protected set
            {
                this.isEmbeddedCategoryVisible = value;
                OnPropertyChanged("IsEmbeddedCategoryVisible");
            }
        }

        /// <summary>
        /// True if embedding category is currently displayed.
        /// </summary>
        public bool IsEmbeddingCategoryVisible
        {
            get { return this.isEmbeddingCategoryVisible; }
            protected set
            {
                this.isEmbeddingCategoryVisible = value;
                OnPropertyChanged("IsEmbeddingCategoryVisible");
            }
        }

        /// <summary>
        /// True if referenced category is currently displayed.
        /// </summary>
        public bool IsReferencedCategoryVisible
        {
            get { return this.isReferencedCategoryVisible; }
            protected set
            {
                this.isReferencedCategoryVisible = value;
                OnPropertyChanged("IsReferencedCategoryVisible");
            }
        }

        /// <summary>
        /// True if referencing category is currently displayed.
        /// </summary>
        public bool IsReferencingCategoryVisible
        {
            get { return this.isReferencingCategoryVisible; }
            protected set
            {
                this.isReferencingCategoryVisible = value;
                OnPropertyChanged("IsReferencingCategoryVisible");
            }
        }

        /// <summary>
        /// Embedded dependency items count.
        /// </summary>
        public int EmbeddedCount
        {
            get { return this.embeddedCount; }
            protected set
            {
                this.embeddedCount = value;
                OnPropertyChanged("EmbeddedCount");
            }
        }

        /// <summary>
        /// Embedding dependency items count.
        /// </summary>
        public int EmbeddingCount
        {
            get { return this.embeddingCount; }
            protected set
            {
                this.embeddingCount = value;
                OnPropertyChanged("EmbeddingCount");
            }
        }

        /// <summary>
        /// Referenced dependency items count.
        /// </summary>
        public int ReferencedCount
        {
            get { return this.referencedCount; }
            protected set
            {
                this.referencedCount = value;
                OnPropertyChanged("ReferencedCount");
            }
        }

        /// <summary>
        /// Referencing dependency items count.
        /// </summary>
        public int ReferencingCount
        {
            get { return this.referencingCount; }
            protected set
            {
                this.referencingCount = value;
                OnPropertyChanged("ReferencingCount");
            }
        }

        /// <summary>
        /// NavigateToSource Command.
        /// </summary>
        public DelegateCommand NavigateToSourceCommand
        {
            get { return this.navigateToSourceCommand; }
        }

        /// <summary>
        /// NavigateToTarget Command.
        /// </summary>
        public DelegateCommand NavigateToTargetCommand
        {
            get { return this.navigateToTargetCommand; }
        }

        /// <summary>
        /// ToggleEmbeddedCategory Command.
        /// </summary>
        public DelegateCommand ToggleEmbeddedCategoryCommand
        {
            get { return this.toggleEmbeddedCategoryCommand; }
        }

        /// <summary>
        /// ToggleEmbeddingCategory Command.
        /// </summary>
        public DelegateCommand ToggleEmbeddingCategoryCommand
        {
            get { return this.toggleEmbeddingCategoryCommand; }
        }

        /// <summary>
        /// ToggleReferencedCategory Command.
        /// </summary>
        public DelegateCommand ToggleReferencedCategoryCommand
        {
            get { return this.toggleReferencedCategoryCommand; }
        }

        /// <summary>
        /// ToggleReferencingCategory Command.
        /// </summary>
        public DelegateCommand ToggleReferencingCategoryCommand
        {
            get { return this.toggleReferencingCategoryCommand; }
        }

        /// <summary>
        /// SortByNumber Command.
        /// </summary>
        public DelegateCommand SortByNumberCommand
        {
            get { return this.sortByNumberCommand; }
        }

        /// <summary>
        /// SortByCategory Command.
        /// </summary>
        public DelegateCommand SortByCategoryCommand
        {
            get { return this.sortByCategoryCommand; }
        }

        /// <summary>
        /// SortBySourceModelElement Command.
        /// </summary>
        public DelegateCommand SortBySourceModelElementCommand
        {
            get { return this.sortBySourceModelElementCommand; }
        }

        /// <summary>
        /// SortByTargetModelElement Command.
        /// </summary>
        public DelegateCommand SortByTargetModelElementCommand
        {
            get { return this.sortByTargetModelElementCommand; }
        }

        /// <summary>
        /// SortByLinkElementCommand Command.
        /// </summary>
        public DelegateCommand SortByLinkElementCommand
        {
            get { return this.sortByLinkElementCommand; }
        }        

        /// <summary>
        /// Gathers dependencies for given model elements and and wraps them for display.
        /// </summary>
        /// <param name="elements">Model elements to display dependencies for.</param>
        public void Set(List<ModelElement> elements)
        {
            Set(elements, LanguageDSLDependenciesItemsProvider.GetAllCategories());
        }

        /// <summary>
        /// Gathers dependencies for given model elements and and wraps them for display.
        /// </summary>
        /// <param name="elements">Model elements to display dependencies for.</param>
        /// <param name="categories">List of categories to include in the search.</param>
        public void Set(List<ModelElement> elements, params DependencyItemCategory[] categories)
        {
            Set(elements, new List<ModelElement>(), categories);
        }

        /// <summary>
        /// Gathers dependencies for given model elements and and wraps them for display.
        /// </summary>
        /// <param name="elements">Model elements to display dependencies for.</param>
        /// <param name="excludedDomainModels">Exclude dependencies that belong to a domain model that is provied in this list.</param>
        public void Set(List<ModelElement> elements, List<ModelElement> excludedDomainModels)
        {
            Set(elements, excludedDomainModels, LanguageDSLDependenciesItemsProvider.GetAllCategories());
        }

        /// <summary>
        /// Gathers dependencies for given model elements and and wraps them for display.
        /// </summary>
        /// <param name="elements">Model elements to display dependencies for.</param>
        /// <param name="excludedDomainModels">Exclude dependencies that belong to a domain model that is provied in this list.</param>
        /// <param name="categories">List of categories to include in the search.</param>
        public void Set(List<ModelElement> elements, List<ModelElement> excludedDomainModels, params DependencyItemCategory[] categories)
        {
            Clear();

            if (elements == null)
                throw new ArgumentNullException("elements");

            this.modelElements = elements;
            this.currentExcludedDomainModels = excludedDomainModels;
            this.currentCategories = categories;

            UpdateCategoriesDisplay(categories);

            // gather dependencies
            //this.dependenciesData = this.ModelData.DependenciesItemsProvider.GetDependencies(modelElements, excludedDomainModels, categories);
            this.dependenciesData = LanguageDSLDependenciesItemsProvider.Instance.GetDependencies(modelElements, excludedDomainModels, categories);
            List<DependencyItem> dependencies = this.dependenciesData.ActiveDependencies;
            List<DependencyItemViewModel> dependenciesVM = new List<DependencyItemViewModel>();
            foreach(DependencyItem item in dependencies)
                dependenciesVM.Add(new DependencyItemViewModel(this.ViewModelStore, item, this.doSubscribeToEvents));

            foreach (DependencyItemViewModel item in dependenciesVM)
            {
                Add(item);
            }

            if (doSubscribeToEvents)
            {
                // subscribe to events notifying of new dependencies beeing created
                //foreach(DependencyOriginItem originItem in this.dependenciesData.OriginDependencies)
                //     this.ViewModelStore.EventManager.GetEvent<ModelElementAddedEvent>().Subscribe(originItem.RelationshipInfo, OnElementLinkAdded);
            }
            Sort(sortOrder, isAscending);

         }
        private void Add(DependencyItemViewModel item)
        {
            item.Number = allDependencies.Count;
            allDependencies.Add(item);

            if (!hiddenCategories.Contains(item.Category))
                displayedDependencies.Add(item);

            switch (item.Category)
            {
                case DependencyItemCategory.Embedded:
                    this.EmbeddedCount++;
                    break;

                case DependencyItemCategory.Embedding:
                    this.EmbeddingCount++;
                    break;

                case DependencyItemCategory.Referenced:
                    this.ReferencedCount++;
                    break;

                case DependencyItemCategory.Referencing:
                    this.ReferencingCount++;
                    break;
            }

            if (doSubscribeToEvents)
            {
                // subscribe to event notifying of a specific link beeind deleted or altered
                this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(item.DependencyItem.ElementLink.Id, OnElementLinkDeleted);
                this.ViewModelStore.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(item.DependencyItem.ElementLink.Id, OnElementLinkChanged);
            }
        }
        private void OnElementLinkDeleted(ElementDeletedEventArgs args)
        {
            // delete all items, where the link id equal args.ElementId
            for (int i = allDependencies.Count - 1; i >= 0; i--)
            {
                if (allDependencies[i].DependencyItem.ElementLink.Id == args.ElementId)
                {
                    if (displayedDependencies.Contains(allDependencies[i]))
                        displayedDependencies.Remove(allDependencies[i]);

                    allDependencies[i].Dispose();
                    allDependencies.RemoveAt(i);
                }
            }
        }
        private void OnElementLinkChanged(RolePlayerChangedEventArgs args)
        {
            Set(modelElements, currentExcludedDomainModels, currentCategories);
        }
        private void OnElementLinkAdded(ElementAddedEventArgs args)
        {
            Set(modelElements, currentExcludedDomainModels, currentCategories);
        }
        private void UpdateCategoriesDisplay(params DependencyItemCategory[] categories)
        {
            bool bDisplayEmbedded = false;
            bool bDisplayEmbedding = false;
            bool bDisplayReferenced = false;
            bool bDisplayReferencing = false;
            foreach (DependencyItemCategory category in categories)
            {
                if (category == DependencyItemCategory.Embedded)
                    bDisplayEmbedded = true;
                else if (category == DependencyItemCategory.Embedding)
                    bDisplayEmbedding = true;
                else if (category == DependencyItemCategory.Referenced)
                    bDisplayReferenced = true;
                else if (category == DependencyItemCategory.Referencing)
                    bDisplayReferencing = true;
            }

            this.IsEmbeddedCategoryVisible = bDisplayEmbedded;
            this.IsEmbeddingCategoryVisible = bDisplayEmbedding;
            this.IsReferencedCategoryVisible = bDisplayReferenced;
            this.IsReferencingCategoryVisible = bDisplayReferencing;
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void Clear()
        {
            foreach (DependencyItemViewModel item in allDependencies)
            {
                if (doSubscribeToEvents)
                {
                    // unsubscribe from event notifying of a specific link beeind deleted or altered
                    this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(item.DependencyItem.ElementLink.Id, OnElementLinkDeleted);
                    this.ViewModelStore.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(item.DependencyItem.ElementLink.Id, OnElementLinkChanged);
                }
                item.Dispose();
            }
            foreach (DependencyItemViewModel item in displayedDependencies)
            {
                if (!item.IsDisposed)
                    item.Dispose();
            }

            if (doSubscribeToEvents && dependenciesData != null)
            {
                // unsubscribe from events notifying of new dependencies beeing created
                // foreach (DependencyOriginItem originItem in this.dependenciesData.OriginDependencies)
                //    this.ViewModelStore.EventManager.GetEvent<ModelElementAddedEvent>().Unsubscribe(originItem.RelationshipInfo, OnElementLinkAdded);
            }

            allDependencies.Clear();
            displayedDependencies.Clear();
            this.modelElements = null;
            this.dependenciesData = null;

            this.EmbeddedCount = 0;
            this.EmbeddingCount = 0;
            this.ReferencedCount = 0;
            this.ReferencingCount = 0;
        }

        /// <summary>
        /// Sorts the dependencies list.
        /// </summary>
        /// <param name="order">Order to sort the dependencies list by.</param>
        /// <param name="bAscending">Ascending or descending order.</param>
        public void Sort(DependenciesSortOrder order, bool bAscending)
        {
            IOrderedEnumerable<DependencyItemViewModel> items = null;
            switch (order)
            {
                case DependenciesSortOrder.DependencyCategory:
                    if (bAscending)
                        items = this.DisplayedDependencies.OrderBy<DependencyItemViewModel, DependencyItemCategory>((x) => (x.Category));
                    else
                        items = this.DisplayedDependencies.OrderByDescending<DependencyItemViewModel, DependencyItemCategory>((x) => (x.Category));
                    break;

                case DependenciesSortOrder.NumberAdded:
                    if (bAscending)
                        items = this.DisplayedDependencies.OrderBy<DependencyItemViewModel, int>((x) => (x.Number));
                    else
                        items = this.DisplayedDependencies.OrderByDescending<DependencyItemViewModel, int>((x) => (x.Number));
                        break;

                case DependenciesSortOrder.SourceModelElement:
                        if (bAscending)
                            items = this.DisplayedDependencies.OrderBy<DependencyItemViewModel, string>((x) => (x.SourceModelElementName));
                        else
                            items = this.DisplayedDependencies.OrderByDescending<DependencyItemViewModel, string>((x) => (x.SourceModelElementName));
                        break;

                case DependenciesSortOrder.TargetModelElement:
                    if (bAscending)
                        items = this.DisplayedDependencies.OrderBy<DependencyItemViewModel, string>((x) => (x.TargetModelElementName));
                    else
                        items = this.DisplayedDependencies.OrderByDescending<DependencyItemViewModel, string>((x) => (x.TargetModelElementName));
                    break;

                case DependenciesSortOrder.LinkElement:
                    if (bAscending)
                        items = this.DisplayedDependencies.OrderBy<DependencyItemViewModel, string>((x) => (x.Message));
                    else
                        items = this.DisplayedDependencies.OrderByDescending<DependencyItemViewModel, string>((x) => (x.Message));
                    break;

                default:
                    throw new NotSupportedException();
            }

            ObservableCollection<DependencyItemViewModel> temp = new ObservableCollection<DependencyItemViewModel>();
            foreach (DependencyItemViewModel item in items)
                temp.Add(item);

            this.displayedDependencies = temp;
            this.displayedDependenciesRO = new ReadOnlyObservableCollection<DependencyItemViewModel>(this.displayedDependencies);
            OnPropertyChanged("DisplayedDependencies");        
        }

        /// <summary>
        /// ToggleEmbeddedCategoryCommand Executed
        /// </summary>
        private void ToggleEmbeddedCategoryCommand_Executed()
        {
            if (this.hiddenCategories.Contains(DependencyItemCategory.Embedded))
                ShowItems(DependencyItemCategory.Embedded);
            else
                HideItems(DependencyItemCategory.Embedded);
        }

        /// <summary>
        /// ToggleEmbeddingCategoryCommand Executed
        /// </summary>
        private void ToggleEmbeddingCategoryCommand_Executed()
        {
            if (this.hiddenCategories.Contains(DependencyItemCategory.Embedding))
                ShowItems(DependencyItemCategory.Embedding);
            else
                HideItems(DependencyItemCategory.Embedding);
        }

        /// <summary>
        /// ToggleReferencedCategoryCommand Executed
        /// </summary>
        private void ToggleReferencedCategoryCommand_Executed()
        {
            if (this.hiddenCategories.Contains(DependencyItemCategory.Referenced))
                ShowItems(DependencyItemCategory.Referenced);
            else
                HideItems(DependencyItemCategory.Referenced);
        }

        /// <summary>
        /// ToggleReferencingCategoryCommand Executed
        /// </summary>
        private void ToggleReferencingCategoryCommand_Executed()
        {
            if (this.hiddenCategories.Contains(DependencyItemCategory.Referencing))
                ShowItems(DependencyItemCategory.Referencing);
            else
                HideItems(DependencyItemCategory.Referencing);
        }

        /// <summary>
        /// SortByNumberCommand Executed
        /// </summary>
        private void SortByNumberCommand_Executed()
        {
            if (SortOrder == DependenciesSortOrder.NumberAdded)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = DependenciesSortOrder.NumberAdded;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByCategoryCommand Executed
        /// </summary>
        private void SortByCategoryCommand_Executed()
        {
            if (SortOrder == DependenciesSortOrder.DependencyCategory)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = DependenciesSortOrder.DependencyCategory;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortBySourceModelElementCommand Executed
        /// </summary>
        private void SortBySourceModelElementCommand_Executed()
        {
            if (SortOrder == DependenciesSortOrder.SourceModelElement)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = DependenciesSortOrder.SourceModelElement;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByTargetModelElementCommand Executed
        /// </summary>
        private void SortByTargetModelElementCommand_Executed()
        {
            if (SortOrder == DependenciesSortOrder.TargetModelElement)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = DependenciesSortOrder.TargetModelElement;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByLinkElementCommand Executed
        /// </summary>
        private void SortByLinkElementCommand_Executed()
        {
            if (SortOrder == DependenciesSortOrder.LinkElement)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = DependenciesSortOrder.LinkElement;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// Removes the items of a specific category from dependencies list.
        /// </summary>
        /// <param name="itemsCategory">Category of items to hide.</param>
        public void HideItems(DependencyItemCategory itemsCategory)
        {
            this.hiddenCategories.Add(itemsCategory);
            UpdateDisplayList();
        }

        /// <summary>
        /// Show items of a specific category in dependencies list.
        /// </summary>
        /// <param name="itemsCategory">Category of items to show.</param>
        public void ShowItems(DependencyItemCategory itemsCategory)
        {
            this.hiddenCategories.Remove(itemsCategory);
            UpdateDisplayList();
        }

        /// <summary>
        /// Updates the items in the display list.
        /// </summary>
        protected virtual void UpdateDisplayList()
        {
            foreach (DependencyItemViewModel item in allDependencies)
            {
                if (hiddenCategories.Contains(item.Category) && displayedDependencies.Contains(item))
                    displayedDependencies.Remove(item);
                else if (!hiddenCategories.Contains(item.Category) && !displayedDependencies.Contains(item))
                    displayedDependencies.Add(item);
            }            

            Sort(sortOrder, isAscending);
        }

        /// <summary>
        /// NvigateToSourceCommand Executed
        /// </summary>
        private void NavigateToSourceCommand_Executed()
        {
            if (this.SelectedItem != null)
                this.SelectedItem.NavigateToSource();
        }

        /// <summary>
        /// NvigateToTargetCommand Executed
        /// </summary>
        private void NavigateToTargetCommand_Executed()
        {
            if (this.SelectedItem != null)
                this.SelectedItem.NavigateToTarget();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            Clear();

            base.OnDispose();
        }
    }
}

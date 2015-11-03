using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// View model used for the error list.
    /// </summary>
    public abstract class MainErrorListViewModel : BaseDockingViewModel
    {
        private FilteredErrorListData filteredErrorListData;

        private ObservableCollection<BaseErrorListItemViewModel> unfilteredErrorListItems;
        private ObservableCollection<BaseErrorListItemViewModel> filteredErrorListItems;
        private ObservableCollection<BaseErrorListItemViewModel> displayedErrorListItems;
        private ReadOnlyObservableCollection<BaseErrorListItemViewModel> displayedErrorListItemsRO;

        private ObservableCollection<BaseErrorListItemViewModel> selectedErrorListItems;

        private List<ErrorListItemCategory> hiddenCategories;
        private bool showFilteredItems = false;

        private DelegateCommand toggleErrorCategory;
        private DelegateCommand toggleMessageCategory;
        private DelegateCommand toggleWarningCategory;
        private DelegateCommand toggleFilteredItems;

        private DelegateCommand navigateCommand;
        private DelegateCommand filterCommand;
        private DelegateCommand unfilterCommand;

        private DelegateCommand sortByDescriptionCommand;
        private DelegateCommand sortByCategoryCommand;
        private DelegateCommand sortByNumberCommand;
        private DelegateCommand sortBySourceDisplayNameCommand;        

        private int errorsCount = 0;
        private int warningsCount = 0;
        private int messagesCount = 0;
        private int filteredCount = 0;

        private ObservableCollection<MenuItemViewModel> menuOptions;
        private MenuItemViewModel navigateMenuItem;
        private MenuItemViewModel copyMenuItem;
        private MenuItemViewModel filterMenuItem;
        private MenuItemViewModel unFilterMenuItem;
        private SeparatorMenuItemViewModel separatorBeforeFilterItem;

        /// <summary>
        /// Extension name to store filtered errors information.
        /// </summary>
        public static string FilterFileNameExtension = ".filter";

        private string filterFilePath = null;

        private ErrorListSortOrder sortOrder = ErrorListSortOrder.Number;
        private bool isAscending = true;

        private bool addingMultipleItems = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainErrorListViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            filteredErrorListData = new FilteredErrorListData();

            toggleErrorCategory = new DelegateCommand(ToggleErrorCategory_Executed);
            toggleMessageCategory = new DelegateCommand(ToggleMessageCategory_Executed);
            toggleWarningCategory = new DelegateCommand(ToggleWarningCategory_Executed);
            toggleFilteredItems = new DelegateCommand(ToggleFilteredItems_Executed);

            navigateCommand = new DelegateCommand(NavigateCommand_Executed);
            filterCommand = new DelegateCommand(FilterCommand_Executed);
            unfilterCommand = new DelegateCommand(UnfilterCommand_Executed);

            sortByDescriptionCommand = new DelegateCommand(SortByDescriptionCommand_Executed);
            sortByCategoryCommand = new DelegateCommand(SortByCategoryCommand_Executed);
            sortByNumberCommand = new DelegateCommand(SortByNumberCommand_Executed);
            sortBySourceDisplayNameCommand = new DelegateCommand(SortBySourceDisplayNameCommand_Executed);

            selectedErrorListItems = new ObservableCollection<BaseErrorListItemViewModel>();
            selectedErrorListItems.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(selectedErrorListItems_CollectionChanged);

            unfilteredErrorListItems = new ObservableCollection<BaseErrorListItemViewModel>();
            filteredErrorListItems = new ObservableCollection<BaseErrorListItemViewModel>();
            displayedErrorListItems = new ObservableCollection<BaseErrorListItemViewModel>();
            displayedErrorListItemsRO = new ReadOnlyObservableCollection<BaseErrorListItemViewModel>(displayedErrorListItems);

            hiddenCategories = new List<ErrorListItemCategory>();

            if (this.ViewModelStore.Options != null)
                if (!this.ViewModelStore.Options.ErrorCategoryVisible)
                    hiddenCategories.Add(ErrorListItemCategory.Error);

            if (this.ViewModelStore.Options != null)
                if (!this.ViewModelStore.Options.InfoCategoryVisible)
                    hiddenCategories.Add(ErrorListItemCategory.Message);

            if (this.ViewModelStore.Options != null)
                if (!this.ViewModelStore.Options.WarningCategoryVisible)
                    hiddenCategories.Add(ErrorListItemCategory.Warning);

            if (this.ViewModelStore.Options != null)
                if (this.ViewModelStore.Options.FilteredCategoryVisible)
                    showFilteredItems = true;

            // create menu
            menuOptions = new ObservableCollection<MenuItemViewModel>();

            navigateMenuItem = new MenuItemViewModel(viewModelStore, "Navigate");
            navigateMenuItem.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Navigate-16.png";
            navigateMenuItem.Command = this.NavigateCommand;
            menuOptions.Add(navigateMenuItem);
            menuOptions.Add(new SeparatorMenuItemViewModel(viewModelStore));
            
            copyMenuItem = new MenuItemViewModel(viewModelStore, "Copy");
            copyMenuItem.IconUrl = "pack://application:,,,/Tum.PDE.ToolFramework.Images;component/Views/Copy-16.png";
            copyMenuItem.Command = this.CopyCommand;
            menuOptions.Add(copyMenuItem);

            separatorBeforeFilterItem = new SeparatorMenuItemViewModel(viewModelStore);
            filterMenuItem = new MenuItemViewModel(viewModelStore, "Filter");
            filterMenuItem.Command = this.FilterCommand;

            unFilterMenuItem = new MenuItemViewModel(viewModelStore, "Unfilter");
            unFilterMenuItem.Command = this.UnfilterCommand;

            this.EventManager.GetEvent<ErrorListClearItems>().Subscribe(new Action<BaseViewModel>(ClearItems));
            this.EventManager.GetEvent<ErrorListAddItem>().Subscribe(new Action<BaseErrorListItemViewModel>(AddItem));
            this.EventManager.GetEvent<ErrorListAddItems>().Subscribe(new Action<List<BaseErrorListItemViewModel>>(AddItems));
            this.EventManager.GetEvent<ErrorListRemoveItem>().Subscribe(new Action<Guid>(RemoveItem));

            this.EventManager.GetEvent<DocumentSavedEvent>().Subscribe(OnDocumentSaved);
            this.EventManager.GetEvent<DocumentClosingEvent>().Subscribe(OnDocumentClosing);
        }

        /// <summary>
        /// Document closed.
        /// </summary>
        public override void OnDocumentClosed()
        {
            base.OnDocumentClosed();
        }

        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();

            this.filteredErrorListData.Clear();

            // load filter file
            if ((this.ModelData.CurrentModelContext.RootElement as IParentModelElement) != null)
            {
                string path = (this.ModelData.CurrentModelContext.RootElement as IParentModelElement).DomainFilePath;

                if (path != null)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                    string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                    filterFilePath = fileInfo.Directory + "\\" + name + FilterFileNameExtension;

                    if (System.IO.File.Exists(filterFilePath))
                        this.filteredErrorListData = FilteredErrorListData.Deserialize(filterFilePath);
                }
                else
                    filterFilePath = null;
            }
            else
                filterFilePath = null;

            UpdateDisplayList();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            if (this.IsInitialized)
                return;

            this.OnDocumentLoaded();
            base.Initialize();
        }


        /// <summary>
        /// Document closing.
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnDocumentClosing(DocumentEventArgs args)
        {
            ClearItems(this);
        }

        /// <summary>
        /// Document saved.
        /// </summary>
        /// <param name="args"></param>
        public virtual void OnDocumentSaved(DocumentEventArgs args)
        {

            if ((this.ModelData.CurrentModelContext.RootElement as IParentModelElement) != null)
            {
                string path = (this.ModelData.CurrentModelContext.RootElement as IParentModelElement).DomainFilePath;

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                filterFilePath = fileInfo.Directory + "\\" + name + FilterFileNameExtension;
                FilteredErrorListData.Serialize(filterFilePath, this.filteredErrorListData);
            }
            this.EventManager.GetEvent<DocumentSavedEvent>().Subscribe(OnDocumentSaved);
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name of the error list docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "ErrorListDockWindow"; }
        }

        /// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Error List"; }
        }
        #endregion

        #region Default Commands Overrides
        /// <summary>
        /// Copy command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected override bool OnCopyCommandCanExecute()
        {
            if (this.SelectedItems.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Copy command execute.
        /// </summary>
        protected override void OnCopyCommandExecuted()
        {
            string copyString = string.Empty;

            for (int i = 0; i < this.SelectedItems.Count; i++)
            {
                string errorString = this.SelectedItems[i].Category.ToString() + "   ";
                errorString += this.SelectedItems[i].Number.ToString() + "   ";
                errorString += this.SelectedItems[i].SourceDisplayName + "   ";
                errorString += this.SelectedItems[i].Description;

                copyString += errorString;

                if (i != this.SelectedItems.Count - 1)
                    copyString += "\r\n";
            }

            try
            {
                System.Windows.Clipboard.SetText(copyString);
            }
            catch (Exception ex)
            {
                this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Gets the current error list.
        /// </summary>
        public ReadOnlyObservableCollection<BaseErrorListItemViewModel> DisplayedErrorList
        {
            get { return displayedErrorListItemsRO; }
        }

        /// <summary>
        /// Selected items collection.
        /// </summary>
        public ObservableCollection<BaseErrorListItemViewModel> SelectedItems
        {
            get { return this.selectedErrorListItems; }
        }
        void selectedErrorListItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateMenuOptions();
        }

        #region Menu
        private void UpdateMenuOptions()
        {
            if (SelectedItems.Count == 1)
            {
                navigateMenuItem.IsEnabled = true;
            }
            else
                navigateMenuItem.IsEnabled = false;

            bool bCanFilter = false;
            bool bCanUnfilter = false;
            foreach (BaseErrorListItemViewModel v in SelectedItems)
            {
                if (!(v is FilterableErrorListItemViewModel))
                {
                    bCanFilter = false;
                    bCanUnfilter = false;
                    break;
                }
                else
                {
                    FilterableErrorListItemViewModel filterable = v as FilterableErrorListItemViewModel;
                    if (filteredErrorListData.Contains(filterable))
                    {
                        bCanUnfilter = true;
                    }
                    else
                        bCanFilter = true;
                }

                if (bCanFilter && bCanUnfilter)
                {
                    bCanFilter = false;
                    bCanUnfilter = false;
                    break;
                }
            }

            if (bCanFilter || bCanUnfilter)
            {
                if (!MenuOptions.Contains(separatorBeforeFilterItem))
                    MenuOptions.Add(separatorBeforeFilterItem);
            }
            else
                if (MenuOptions.Contains(separatorBeforeFilterItem))
                    MenuOptions.Remove(separatorBeforeFilterItem);

            if (bCanFilter)
            {
                if (!MenuOptions.Contains(filterMenuItem))
                    MenuOptions.Add(filterMenuItem);
            }
            else
            {
                if (MenuOptions.Contains(filterMenuItem))
                    MenuOptions.Remove(filterMenuItem);
            }

            if (bCanUnfilter)
            {
                if (!MenuOptions.Contains(unFilterMenuItem))
                    MenuOptions.Add(unFilterMenuItem);
            }
            else
            {
                if (MenuOptions.Contains(unFilterMenuItem))
                    MenuOptions.Remove(unFilterMenuItem);
            }
        }

        /// <summary>
        /// Context menu options.
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuOptions
        {
            get { return this.menuOptions; }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Sort order in the error list.
        /// </summary>
        public ErrorListSortOrder SortOrder
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
        /// Ascending or descending sort order.
        /// </summary>
        public bool IsSortedAscending
        {
            get 
            { 
                return this.isAscending; 
            }
            protected set
            {
                this.isAscending = value;
                OnPropertyChanged("IsSortedAscending");
            }
        }

        /// <summary>
        /// Gets the number of errors in the list.
        /// </summary>
        public int ErrorsCount
        {
            get { return this.errorsCount; }
        }

        /// <summary>
        /// Gets the number of messages in the list.
        /// </summary>
        public int MessagesCount
        {
            get { return this.messagesCount; }
        }

        /// <summary>
        /// Gets the number of warnings in the list.
        /// </summary>
        public int WarningsCount
        {
            get { return this.warningsCount; }
        }

        /// <summary>
        /// Gets the number of filtered errors in the list.
        /// </summary>
        public int FilteredCount
        {
            get { return this.filteredCount; }
        }

        /// <summary>
        /// Gets whether the error category is visible or not.
        /// </summary>
        public bool IsErrorCategoryVisible
        {
            get
            {
                if (this.ViewModelStore.Options == null)
                    return true;

                return this.ViewModelStore.Options.ErrorCategoryVisible; 
            }
        }

        /// <summary>
        /// Gets whether the warning category is visible or not.
        /// </summary>
        public bool IsWarningCategoryVisible
        {
            get
            {
                if (this.ViewModelStore.Options == null)
                    return true;

                return this.ViewModelStore.Options.WarningCategoryVisible;
            }
        }

        /// <summary>
        /// Gets whether the message category is visible or not.
        /// </summary>
        public bool IsMessageCategoryVisible
        {
            get
            {
                if (this.ViewModelStore.Options == null)
                    return true;

                return this.ViewModelStore.Options.InfoCategoryVisible;
            }
        }

        /// <summary>
        /// Gets whether the filtered category is visible or not.
        /// </summary>
        public bool IsFilteredCategoryVisible
        {
            get
            {
                if (this.ViewModelStore.Options == null)
                    return false;

                return this.ViewModelStore.Options.FilteredCategoryVisible;
            }
        }

        #endregion

        #region Commands
        /// <summary>
        /// Toggle error category command.
        /// </summary>
        public DelegateCommand ToggleErrorCategory
        {
            get { return this.toggleErrorCategory; }
        }

        /// <summary>
        /// Toggle message category command.
        /// </summary>
        public DelegateCommand ToggleMessageCategory
        {
            get { return this.toggleMessageCategory; }
        }

        /// <summary>
        /// Toggle warning category command.
        /// </summary>
        public DelegateCommand ToggleWarningCategory
        {
            get { return this.toggleWarningCategory; }
        }

        /// <summary>
        /// Toggle filtered items command.
        /// </summary>
        public DelegateCommand ToggleFilteredItems
        {
            get { return this.toggleFilteredItems; }
        }

        /// <summary>
        /// Navigate command.
        /// </summary>
        public DelegateCommand NavigateCommand
        {
            get { return this.navigateCommand; }
        }

        /// <summary>
        /// Filter command.
        /// </summary>
        public DelegateCommand FilterCommand
        {
            get { return this.filterCommand; }
        }

        /// <summary>
        /// Unfilter command.
        /// </summary>
        public DelegateCommand UnfilterCommand
        {
            get { return this.unfilterCommand; }
        }

        /// <summary>
        /// Sort by description command.
        /// </summary>
        public DelegateCommand SortByDescriptionCommand
        {
            get { return this.sortByDescriptionCommand; }
        }

        /// <summary>
        /// Sort by number command.
        /// </summary>
        public DelegateCommand SortByNumberCommand
        {
            get { return this.sortByNumberCommand; }
        }

        /// <summary>
        /// Sort by category command.
        /// </summary>
        public DelegateCommand SortByCategoryCommand
        {
            get { return this.sortByCategoryCommand; }
        }

        /// <summary>
        /// Sort by source display name command.
        /// </summary>
        public DelegateCommand SortBySourceDisplayNameCommand
        {
            get { return this.sortBySourceDisplayNameCommand; }
        }

        /// <summary>
        /// ToggleErrorCategory executed.
        /// </summary>
        private void ToggleErrorCategory_Executed()
        {
            if (this.hiddenCategories.Contains(ErrorListItemCategory.Error))
                ShowItems(ErrorListItemCategory.Error);
            else
                HideItems(ErrorListItemCategory.Error);
        }

        /// <summary>
        /// ToggleMessageCategory executed.
        /// </summary>
        private void ToggleMessageCategory_Executed()
        {
            if (this.hiddenCategories.Contains(ErrorListItemCategory.Message))
                ShowItems(ErrorListItemCategory.Message);
            else
                HideItems(ErrorListItemCategory.Message);
        }

        /// <summary>
        /// ToggleWarningCategory executed.
        /// </summary>
        private void ToggleWarningCategory_Executed()
        {
            if (this.hiddenCategories.Contains(ErrorListItemCategory.Warning))
                ShowItems(ErrorListItemCategory.Warning);
            else
                HideItems(ErrorListItemCategory.Warning);
        }

        /// <summary>
        /// ToggleFilteredItems executed.
        /// </summary>
        private void ToggleFilteredItems_Executed()
        {
            if (showFilteredItems)
            {
                this.showFilteredItems = false;
                UpdateDisplayList();
            }
            else
            {
                this.showFilteredItems = true;
                UpdateDisplayList();
            }
            
            if (this.ViewModelStore.Options != null)
                this.ViewModelStore.Options.FilteredCategoryVisible = showFilteredItems;
        }

        /// <summary>
        /// NavigateCommand executed.
        /// </summary>
        private void NavigateCommand_Executed()
        {
            if (this.SelectedItems.Count == 1)
                this.SelectedItems[0].Navigate();
        }

        /// <summary>
        /// FilterCommand executed.
        /// </summary>
        private void FilterCommand_Executed()
        {
            foreach (BaseErrorListItemViewModel v in SelectedItems)
            {
                if (v is FilterableErrorListItemViewModel)
                {
                    FilterableErrorListItemViewModel filterable = v as FilterableErrorListItemViewModel;
                    filteredErrorListData.Add(filterable);

                    // we have to move this item from unfiltered to filtered
                    this.unfilteredErrorListItems.Remove(filterable);
                    this.filteredErrorListItems.Add(filterable);

                    DecreaseCategoryCount(filterable.Category);

                    filteredCount++;
                    OnPropertyChanged("FilteredCount");

                    filterable.IsFiltered = true;
                }
            }

            UpdateDisplayList();

            UpdateMenuOptions();
        }

        /// <summary>
        /// UnfilterCommand executed.
        /// </summary>
        private void UnfilterCommand_Executed()
        {
            foreach (BaseErrorListItemViewModel v in SelectedItems)
            {
                if (v is FilterableErrorListItemViewModel)
                {
                    FilterableErrorListItemViewModel filterable = v as FilterableErrorListItemViewModel;
                    filteredErrorListData.Remove(filterable);

                    // we have to move this item from filtered to unfiltered
                    this.filteredErrorListItems.Remove(filterable);
                    this.unfilteredErrorListItems.Add(filterable);

                    IncreaseCategoryCount(filterable.Category);
                    
                    filteredCount--;
                    OnPropertyChanged("FilteredCount");

                    filterable.IsFiltered = false;
                }
            }

            UpdateDisplayList();
            UpdateMenuOptions();
        }

        /// <summary>
        /// SortByDescriptionCommand executed.
        /// </summary>
        private void SortByDescriptionCommand_Executed()
        {
            if (SortOrder == ErrorListSortOrder.Description)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = ErrorListSortOrder.Description;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByNumberCommand executed.
        /// </summary>
        private void SortByNumberCommand_Executed()
        {
            if (SortOrder == ErrorListSortOrder.Number)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = ErrorListSortOrder.Number;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortByCategoryCommand executed.
        /// </summary>
        private void SortByCategoryCommand_Executed()
        {
            if (SortOrder == ErrorListSortOrder.Category)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = ErrorListSortOrder.Category;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// SortBySourceDisplayNameCommand executed.
        /// </summary>
        private void SortBySourceDisplayNameCommand_Executed()
        {
            if (SortOrder == ErrorListSortOrder.SourceDisplayName)
                IsSortedAscending = !IsSortedAscending;
            else
            {
                SortOrder = ErrorListSortOrder.SourceDisplayName;
                IsSortedAscending = true;
            }

            Sort(SortOrder, IsSortedAscending);
        }

        /// <summary>
        /// Sorts the error list.
        /// </summary>
        /// <param name="order">Order to sort the error list by.</param>
        /// <param name="bAscending">Ascending or descending order.</param>
        public void Sort(ErrorListSortOrder order, bool bAscending)
        {
            IOrderedEnumerable<BaseErrorListItemViewModel> items = null;
            switch (order)
            {
                case ErrorListSortOrder.Description:
                    if (bAscending)
                        items = this.DisplayedErrorList.OrderBy<BaseErrorListItemViewModel, string>((x) => (x.Description));
                    else
                        items = this.DisplayedErrorList.OrderByDescending<BaseErrorListItemViewModel, string>((x) => (x.Description));
                    break;

                case ErrorListSortOrder.Category:
                    if (bAscending)
                        items = this.DisplayedErrorList.OrderBy<BaseErrorListItemViewModel, ErrorListItemCategory>((x) => (x.Category));
                    else
                        items = this.DisplayedErrorList.OrderByDescending<BaseErrorListItemViewModel, ErrorListItemCategory>((x) => (x.Category));
                    break;

                case ErrorListSortOrder.Number:
                    if (bAscending)
                        items = this.DisplayedErrorList.OrderBy<BaseErrorListItemViewModel, int>((x) => (x.Number));
                    else
                        items = this.DisplayedErrorList.OrderByDescending<BaseErrorListItemViewModel, int>((x) => (x.Number));
                    break;

                case ErrorListSortOrder.SourceDisplayName:
                    if (bAscending)
                        items = this.DisplayedErrorList.OrderBy<BaseErrorListItemViewModel, string>((x) => (x.SourceDisplayName));
                    else
                        items = this.DisplayedErrorList.OrderByDescending<BaseErrorListItemViewModel, string>((x) => (x.SourceDisplayName));
                    break;

                default:
                    throw new NotSupportedException();
            }

            ObservableCollection<BaseErrorListItemViewModel> temp = new ObservableCollection<BaseErrorListItemViewModel>();
            foreach (BaseErrorListItemViewModel item in items)
                temp.Add(item);

            this.displayedErrorListItems = temp;
            this.displayedErrorListItemsRO = new ReadOnlyObservableCollection<BaseErrorListItemViewModel>(this.displayedErrorListItems);
            OnPropertyChanged("DisplayedErrorList");
        }
        #endregion

        /// <summary>
        /// Removes the items of a specific category from Error List window.
        /// </summary>
        /// <param name="itemsCategory">Category of items to hide.</param>
        public void HideItems(ErrorListItemCategory itemsCategory)
        {
            switch(itemsCategory)
            {
                case ErrorListItemCategory.Error: 
                    if (this.ViewModelStore.Options != null)
                        this.ViewModelStore.Options.ErrorCategoryVisible = false;
                    break;

                case ErrorListItemCategory.Warning:
                    if (this.ViewModelStore.Options != null)
                        this.ViewModelStore.Options.WarningCategoryVisible = false;
                    break;

                case ErrorListItemCategory.Message:
                    if (this.ViewModelStore.Options != null)
                        this.ViewModelStore.Options.InfoCategoryVisible = false;
                    break;
            }

            this.hiddenCategories.Add(itemsCategory);
            UpdateDisplayList();
        }

        /// <summary>
        /// Show items of a specific category in Error List window.
        /// </summary>
        /// <param name="itemsCategory">Category of items to show.</param>
        public void ShowItems(ErrorListItemCategory itemsCategory)
        {
            switch (itemsCategory)
            {
                case ErrorListItemCategory.Error:
                    if (this.ViewModelStore.Options != null)
                        this.ViewModelStore.Options.ErrorCategoryVisible = true;
                    break;

                case ErrorListItemCategory.Warning:
                    if (this.ViewModelStore.Options != null)
                        this.ViewModelStore.Options.WarningCategoryVisible = true;
                    break;

                case ErrorListItemCategory.Message:
                    if (this.ViewModelStore.Options != null)
                        this.ViewModelStore.Options.InfoCategoryVisible = true;
                    break;
            }

            this.hiddenCategories.Remove(itemsCategory);
            UpdateDisplayList();
        }

        /// <summary>
        /// Updates the items in the display list.
        /// </summary>
        protected virtual void UpdateDisplayList()
        {
            foreach (BaseErrorListItemViewModel item in unfilteredErrorListItems)
            {
                if (hiddenCategories.Contains(item.Category) && displayedErrorListItems.Contains(item))
                    displayedErrorListItems.Remove(item);
                else if (!hiddenCategories.Contains(item.Category) && !displayedErrorListItems.Contains(item))
                    displayedErrorListItems.Add(item);
            }

            foreach (BaseErrorListItemViewModel item in filteredErrorListItems)
            {
                if (displayedErrorListItems.Contains(item))
                {
                    if (!showFilteredItems)
                        displayedErrorListItems.Remove(item);
                    //else if (hiddenCategories.Contains(item.Category))
                    //    displayedErrorListItems.Remove(item);
                }
                //else if (!hiddenCategories.Contains(item.Category))
                else
                    if (showFilteredItems)
                        displayedErrorListItems.Add(item);
            }

            Sort(sortOrder, isAscending);
        }

        private void IncreaseCategoryCount(ErrorListItemCategory category)
        {
            ModifyCategoryCount(category, true);
        }
        private void DecreaseCategoryCount(ErrorListItemCategory category)
        {
            ModifyCategoryCount(category, false);
        }
        private void ModifyCategoryCount(ErrorListItemCategory category, bool bIncrease)
        {
            switch (category)
            {
                case ErrorListItemCategory.Error:
                case ErrorListItemCategory.Fatal:
                    if (bIncrease)
                        errorsCount++;
                    else
                        errorsCount--;
                    OnPropertyChanged("ErrorsCount");
                    break;

                case ErrorListItemCategory.Message:
                    if( bIncrease )
                        messagesCount++;
                    else
                        messagesCount--;
                    OnPropertyChanged("MessagesCount");
                    break;

                case ErrorListItemCategory.Warning:
                    if (bIncrease)
                        warningsCount++;
                    else
                        warningsCount--;
                    OnPropertyChanged("WarningsCount");
                    break;
            }
        }

        /// <summary>
        /// Add an error item to the error list.
        /// </summary>
        /// <param name="item">Error item to add.</param>
        protected virtual void AddItem(BaseErrorListItemViewModel item)
        {
            bool bFiltered = false;

            // filtering
            if (item is FilterableErrorListItemViewModel)
            {
                // see if it is filtered or not
                if (filteredErrorListData.Contains(item as FilterableErrorListItemViewModel))
                    bFiltered = true;
            }

            if (bFiltered)
            {
                filteredErrorListItems.Add(item);
                filteredCount++;
                OnPropertyChanged("FilteredCount");
                (item as FilterableErrorListItemViewModel).IsFiltered = true;
            }
            else
            {
                unfilteredErrorListItems.Add(item);

                IncreaseCategoryCount(item.Category);
            }
            item.Number = unfilteredErrorListItems.Count + filteredErrorListItems.Count;

            if (!hiddenCategories.Contains(item.Category))
            {
                if (!bFiltered)
                    displayedErrorListItems.Add(item);
                else if( bFiltered && showFilteredItems )
                    displayedErrorListItems.Add(item);
            }

            if(!addingMultipleItems )
                Sort(sortOrder, isAscending);
        }

        /// <summary>
        /// Add multiple error items to the error list.
        /// </summary>
        /// <param name="items">Error items to add.</param>
        protected virtual void AddItems(List<BaseErrorListItemViewModel> items)
        {
            addingMultipleItems = true;

            foreach (BaseErrorListItemViewModel item in items)
                AddItem(item);

            addingMultipleItems = false;
            Sort(sortOrder, isAscending);
        }

        /// <summary>
        /// Removes all items from the error list.
        /// </summary>
        /// <param name="model">Source view model that triggered that notification.</param>
        protected virtual void ClearItems(BaseViewModel model)
        {
            for (int i = unfilteredErrorListItems.Count - 1; i >= 0; i--)
                unfilteredErrorListItems[i].Dispose();
            for (int i = filteredErrorListItems.Count - 1; i >= 0; i--)
                filteredErrorListItems[i].Dispose();

            selectedErrorListItems.Clear();
            unfilteredErrorListItems.Clear();
            filteredErrorListItems.Clear();
            displayedErrorListItems.Clear();
            
            UpdateDisplayList();

            errorsCount = 0;
            warningsCount = 0;
            messagesCount = 0;
            filteredCount = 0;

            OnPropertyChanged("ErrorsCount");
            OnPropertyChanged("MessagesCount");
            OnPropertyChanged("WarningsCount");
            OnPropertyChanged("FilteredCount");
        }

        /// <summary>
        /// Removes a specific error list item vm from the error list.
        /// </summary>
        /// <param name="id">If of the vm to be removed.</param>
        protected virtual void RemoveItem(Guid id)
        {
            foreach (BaseErrorListItemViewModel v in unfilteredErrorListItems)
            {
                if (v.Id == id)
                {
                    if (selectedErrorListItems.Contains(v))
                        selectedErrorListItems.Remove(v);

                    if (displayedErrorListItems.Contains(v))
                        displayedErrorListItems.Remove(v);

                    DecreaseCategoryCount(v.Category);
                    v.Dispose();

                    unfilteredErrorListItems.Remove(v);
                    return;
                }
            }

            foreach (BaseErrorListItemViewModel v in filteredErrorListItems)
            {
                if (v.Id == id)
                {
                    if (selectedErrorListItems.Contains(v))
                        selectedErrorListItems.Remove(v);

                    if (displayedErrorListItems.Contains(v))
                        displayedErrorListItems.Remove(v);

                    filteredCount = 0;
                    v.Dispose();

                    filteredErrorListItems.Remove(v);

                    OnPropertyChanged("FilteredCount");
                    break;
                }
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<ErrorListAddItem>().Unsubscribe(new Action<BaseErrorListItemViewModel>(AddItem));
            this.EventManager.GetEvent<ErrorListAddItems>().Unsubscribe(new Action<List<BaseErrorListItemViewModel>>(AddItems));

            this.EventManager.GetEvent<DocumentSavedEvent>().Unsubscribe(OnDocumentSaved);


            this.EventManager.GetEvent<ErrorListClearItems>().Unsubscribe(new Action<BaseViewModel>(ClearItems));
            this.EventManager.GetEvent<ErrorListRemoveItem>().Unsubscribe(new Action<Guid>(RemoveItem));

            base.OnDispose();
        }

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void OnReset()
        {
            // clear error list
            this.ClearItems(this);
            //this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

            base.OnReset();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// View model used for the property grid.
    /// 
    /// This is the main property grid view model that is used to display properties. We need to use this model instead
    /// of the generated PropertyGridViewModels because we might have multiple elements selected at once, so that their 
    /// equal properties can be modified simultanioulsy. This beeing the main reason, this view model combines multiple
    /// PropertyGridViewModels.
    /// </summary>
    public abstract class MainPropertyGridViewModel : BaseDockingViewModel
    {
        private List<PropertyGridEditorViewModel> currentEditorViewModels = null;
        private List<PropertyGridEditorViewModel> currentEditorViewModelsAlphabetic = null;
        private List<PropertyGridEditorCategoryViewModel> currentEditorViewModelsCategorized = null;
        private PropertyGridEditorViewModel selectedEditorViewModel = null;
        private PropertyGridViewModel currentGridViewModel = null;
        private SelectedItemsCollection selectedItemsCollection = null;

        private PropertyGridSortOrder propertyGridSortOrder;
        private string searchText = "";
        private DelegateCommand searchCommand;
        private DelegateCommand toggleAlphabeticalSortOrderCommand;
        private DelegateCommand toggleCategorizedSortOrderCommand;

        /// <summary>
        /// True if ribbon menu is initialized for its editors.
        /// </summary>
        public bool IsRibbonMenuForEditorsInitialized = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public MainPropertyGridViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, false)
        {
            this.searchCommand = new DelegateCommand(SearchCommand_Executed);

            this.toggleAlphabeticalSortOrderCommand = new DelegateCommand(ToggleAlphabeticalSortOrderCommand_Executed);
            this.toggleCategorizedSortOrderCommand = new DelegateCommand(ToggleCategorizedSortOrderCommand_Executed);

            this.searchText = "Search";
            this.propertyGridSortOrder = PropertyGridSortOrder.Alphabetical;

            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));

            this.PreInitialize();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            if (!this.IsRibbonMenuForEditorsInitialized)
                if (this.IsInitialized && this.Ribbon != null)
                    this.CreateRibbonMenuBarForEditors(Ribbon);

            if( this.selectedItemsCollection != null )
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdatePropertyGrid));
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name of the property grid docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "PropertiesDockWindowPane"; }
        }

        /// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Property Grid"; }
        }
        #endregion

        #region Default Commands Overrides
        /// <summary>
        /// Called whenever the selected editor is changed.
        /// </summary>
        public virtual void SelectedEditorChanged(PropertyGridEditorViewModel selectedEditor)
        {
        }
        #endregion

        #region Search
        /// <summary>
        /// Search command.
        /// </summary>
        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
        }

        /// <summary>
        /// SearchCommand executed.
        /// </summary>
        private void SearchCommand_Executed()
        {
            if (this.CurrentEditorViewModels == null)
                return;

            if (this.CurrentEditorViewModels.Count == 0)
                return;

            List<ModelElement> elements = new List<ModelElement>();
            foreach(PropertyGridEditorViewModel vm in this.CurrentEditorViewModels)
                if (vm.Elements != null)
                {
                    foreach(object obj in vm.Elements)
                        if (obj is ModelElement)
                        {
                            ModelElement modelElement = obj as ModelElement;
                            if (!elements.Contains(modelElement))
                                elements.Add(modelElement);
                        }
                }

            SearchEventArgs args = new SearchEventArgs(this.SearchText, elements, new Search.SearchCriteria(SearchCriteriaEnum.Properties, "Properties"));
            this.EventManager.GetEvent<SearchEvent>().Publish(args);
        }

        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        public string SearchText
        {
            get
            {
                return this.searchText;
            }
            set
            {
                this.searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        #endregion

        #region Ribbon
        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();

            if (!this.IsRibbonMenuForEditorsInitialized)
                if (this.IsInitialized &&this.Ribbon != null)
                    this.CreateRibbonMenuBarForEditors(Ribbon);
        }

        /// <summary>
        /// Delay creation of ribbon menus.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void CreateRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
            base.CreateRibbonMenu(ribbonMenu);

            // delay loading to the point where we start updating the property grid (item selection)
            if (!this.IsRibbonMenuForEditorsInitialized)
                if (this.IsInitialized)
                    this.CreateRibbonMenuBarForEditors(ribbonMenu);
        }

        /// <summary>
        /// Create ribbon menu bars for editors.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public virtual void CreateRibbonMenuBarForEditors(Fluent.Ribbon ribbonMenu)
        {
            this.IsRibbonMenuForEditorsInitialized = true;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the clicked view model in the view.
        /// </summary>
        public PropertyGridEditorViewModel SelectedEditorViewModel
        {
            get
            {
                return selectedEditorViewModel;
            }
            set
            {
                if (selectedEditorViewModel != null)
                    selectedEditorViewModel.IsSelected = false;

                selectedEditorViewModel = value;
                OnPropertyChanged("SelectedEditorViewModel");

                if (selectedEditorViewModel != null)
                    selectedEditorViewModel.IsSelected = true;

                OnSelectedEditorChanged();
                OnPropertyChanged("PropertyGridDescriptionFullName");
                OnPropertyChanged("PropertyGridDescriptionText");
                OnPropertyChanged("PropertyGridDescriptionType");
            }
        }

        /// <summary>
        /// Gets or sets the current editor view models, which are to be displayed in the property grid.
        /// </summary>
        public List<PropertyGridEditorViewModel> CurrentEditorViewModels
        {
            get 
            { 
                return currentEditorViewModels; 
            }
            private set
            {
                if (this.currentEditorViewModels != null)
                {
                    foreach (PropertyGridEditorViewModel model in this.currentEditorViewModels)
                        model.Dispose();

                    this.currentEditorViewModels.Clear();
                }

                if (currentEditorViewModelsAlphabetic != null)
                {
                    foreach (PropertyGridEditorViewModel model in this.currentEditorViewModelsAlphabetic)
                        if (!model.IsDisposed)
                            model.Dispose();

                    this.currentEditorViewModelsAlphabetic.Clear();
                }

                if (currentEditorViewModelsCategorized != null)
                {
                    foreach (PropertyGridEditorCategoryViewModel model in this.currentEditorViewModelsCategorized)
                        if (!model.IsDisposed)
                            model.Dispose();

                    this.currentEditorViewModelsCategorized.Clear();
                }

                this.currentEditorViewModels = value;

                // alphabetic
                currentEditorViewModelsAlphabetic = new List<PropertyGridEditorViewModel>();
                if (this.CurrentEditorViewModels != null)
                {
                    currentEditorViewModelsAlphabetic.AddRange(this.CurrentEditorViewModels);
                    currentEditorViewModelsAlphabetic.Sort(CompareViewModels);
                }

                // categorized
                Dictionary<string, List<PropertyGridEditorViewModel>> dictionary = new Dictionary<string, List<PropertyGridEditorViewModel>>();
                if (this.CurrentEditorViewModels != null)
                    foreach (PropertyGridEditorViewModel vm in CurrentEditorViewModels)
                    {
                        string category = vm.PropertyCategory.Trim();
                        if (category == "")
                            category = "Misc";

                        if (!dictionary.Keys.Contains(category))
                            dictionary.Add(category, new List<PropertyGridEditorViewModel>());

                        dictionary[category].Add(vm);
                    }

                currentEditorViewModelsCategorized = new List<PropertyGridEditorCategoryViewModel>();
                foreach (string key in dictionary.Keys)
                {
                    dictionary[key].Sort(CompareViewModels);
                    currentEditorViewModelsCategorized.Add(new PropertyGridEditorCategoryViewModel(this.ViewModelStore, key,
                        dictionary[key]));
                }
                currentEditorViewModelsCategorized.Sort(CompareCategoryViewModels);
                dictionary.Clear();

                OnPropertyChanged("CurrentEditorViewModels");
                OnPropertyChanged("CurrentEditorViewModelsAlphabetic");
                OnPropertyChanged("CurrentEditorViewModelsCategorized");
            }
        }

        /// <summary>
        /// Gets or sets the current editor view models, which are to be displayed in the property grid.
        /// </summary>
        public List<PropertyGridEditorViewModel> CurrentEditorViewModelsAlphabetic
        {
            get
            {
                return currentEditorViewModelsAlphabetic;
            }
        }

        /// <summary>
        /// Gets or sets the current editor view models, which are to be displayed in the property grid.
        /// </summary>
        public List<PropertyGridEditorCategoryViewModel> CurrentEditorViewModelsCategorized
        {
            get
            {                
                return currentEditorViewModelsCategorized;
            }
        }

        /// <summary>
        /// Gets or sets the current grid view model. This is null, if no or multiple elements are
        /// selected for the property grid.
        /// </summary>
        protected PropertyGridViewModel CurrentGridViewModel
        { 
            get
            {
                return currentGridViewModel;
            }
            private set
            {
                if (currentGridViewModel != null)
                    currentGridViewModel.Dispose();

                currentGridViewModel = value;
                OnPropertyChanged("CurrentGridViewModel");
            }
        }

        /// <summary>
        /// Gets the property grid description name.
        /// </summary>
        public string PropertyGridDescriptionType
        {
            get 
            {
                if (CurrentEditorViewModels == null)
                    return "";
                else if (SelectedEditorViewModel != null)
                {
                    if (String.IsNullOrEmpty(SelectedEditorViewModel.PropertyType))
                        return "";

                    return "(" + SelectedEditorViewModel.PropertyType + ")";
                }
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets the property grid description name.
        /// </summary>
        public string PropertyGridDescriptionFullName
        {
            get
            {
                if (CurrentEditorViewModels == null)
                    return "";
                else if (SelectedEditorViewModel != null)
                    return SelectedEditorViewModel.PropertyDisplayName;
                else if (CurrentGridViewModel != null)
                    return CurrentGridViewModel.ElementFullName;
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets the property grid description text.
        /// </summary>
        public string PropertyGridDescriptionText
        {
            get 
            {                
                if (CurrentEditorViewModels == null)
                    return "";
                else if (SelectedEditorViewModel != null)
                    return SelectedEditorViewModel.PropertyDescription;
                else if (CurrentGridViewModel != null)
                    return CurrentGridViewModel.ElementDescription;
                else                    
                    return "";
            }
        }

        /// <summary>
        /// Gets the sort order.
        /// </summary>
        public PropertyGridSortOrder SortOrder
        {
            get
            {
                return this.propertyGridSortOrder;
            }
        }

        /// <summary>
        /// Gets the currently selected items in the property grid.
        /// </summary>
        protected SelectedItemsCollection SelectedItemsCollection
        {
            get { return selectedItemsCollection; }
        }
        #endregion

        /// <summary>
        /// Callback from SelectionChangedEvent. 
        /// Executes UpdatePropertyGrid asynchronously on the thread Dispatcher.Current is associated with.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected virtual void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            selectedItemsCollection = eventArgs.SelectedItems;

            if( this.IsInitialized && this.IsDockingPaneVisible)
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdatePropertyGrid));
        }
        
        /// <summary>
        /// Updates the property grid, based on SelectedItemsCollection.
        /// </summary>
        private void UpdatePropertyGrid()
        {
            if (SelectedItemsCollection == null)
            {
                this.OnReset();
                return;
            }
            
            CurrentEditorViewModels = null;
            CurrentGridViewModel = null;
            SelectedEditorViewModel = null;

            List<PropertyGridEditorViewModel> editorViewModels = null;
            // update current editors
            if (selectedItemsCollection.Count != 0)
            {
                List<PropertyGridViewModel> viewModels = this.ViewModelStore.Factory.CreatePropertyEditorViewModels(SelectedItemsCollection);
                if (viewModels.Count == 1)
                {
                    editorViewModels = viewModels[0].GetEditorViewModels();
                    CurrentGridViewModel = viewModels[0];
                }
                else if (viewModels.Count > 1)
                {
                    CurrentGridViewModel = new MultiplePropertyGridViewModel(this.ViewModelStore, viewModels);
                    editorViewModels = CurrentGridViewModel.GetEditorViewModels();
                }
            }
            
            List<object> elements = new List<object>();
            foreach (object obj in SelectedItemsCollection)
                elements.Add(obj);

            // apply binding
            if (editorViewModels != null)
                foreach (PropertyGridEditorViewModel e in editorViewModels)
                    e.SetElements(elements);
            CurrentEditorViewModels = editorViewModels;

            OnPropertyChanged("PropertyGridDescriptionFullName");
            OnPropertyChanged("PropertyGridDescriptionText");
            OnPropertyChanged("PropertyGridDescriptionType");
        }

        /// <summary>
        /// Called whenever the selected editor is changed.
        /// </summary>
        protected virtual void OnSelectedEditorChanged()
        {
            SelectedEditorChanged(this.SelectedEditorViewModel);
        }

        /// <summary>
        /// Gets the ToggleAlphabeticalSortOrder command.
        /// </summary>
        public DelegateCommand ToggleAlphabeticalSortOrderCommand
        {
            get
            {
                return this.toggleAlphabeticalSortOrderCommand;
            }
        }

        /// <summary>
        /// Gets the ToggleCategorizedSortOrder command.
        /// </summary>
        public DelegateCommand ToggleCategorizedSortOrderCommand
        {
            get
            {
                return this.toggleCategorizedSortOrderCommand;
            }
        }

        /// <summary>
        /// ToggleAlphabeticalSortOrder command executed.
        /// </summary>
        private void ToggleAlphabeticalSortOrderCommand_Executed()
        {
            this.propertyGridSortOrder = PropertyGridSortOrder.Alphabetical;
            OnPropertyChanged("SortOrder");
        }
        
        /// <summary>
        /// ToggleCategorizedSortOrder command executed.
        /// </summary>
        private void ToggleCategorizedSortOrderCommand_Executed()
        {
            this.propertyGridSortOrder = PropertyGridSortOrder.Categorized;
            OnPropertyChanged("SortOrder");
        }        

        /// <summary>
        /// Reset view model.
        /// </summary>
        protected override void OnReset()
        {
            base.OnReset();

            if (currentEditorViewModels != null)
            {
                for (int i = this.currentEditorViewModels.Count - 1; i >= 0; i--)
                {
                    this.currentEditorViewModels[i].IsSelected = false;
                    this.currentEditorViewModels[i].Dispose();
                }
                this.currentEditorViewModels.Clear();
            }
            if (currentEditorViewModels != null)
            {
                for (int i = this.currentEditorViewModelsAlphabetic.Count - 1; i >= 0; i--)
                {
                    this.currentEditorViewModelsAlphabetic[i].IsSelected = false;
                    this.currentEditorViewModelsAlphabetic[i].Dispose();
                }
                this.currentEditorViewModelsAlphabetic.Clear();
            }
            if (currentEditorViewModels != null)
            {
                for (int i = this.currentEditorViewModelsCategorized.Count - 1; i >= 0; i--)
                {
                    this.currentEditorViewModelsCategorized[i].Dispose();
                }
                this.currentEditorViewModelsCategorized.Clear();
            }

            SelectedEditorViewModel = null;
            CurrentEditorViewModels = null;
            CurrentGridViewModel = null;

            OnPropertyChanged("PropertyGridDescriptionFullName");
            OnPropertyChanged("PropertyGridDescriptionType");
            OnPropertyChanged("PropertyGridDescriptionText");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));

            if (currentEditorViewModels != null)
            {
                for (int i = this.currentEditorViewModels.Count - 1; i >= 0; i--)
                    this.currentEditorViewModels[i].Dispose();
                this.currentEditorViewModels.Clear();
            }
            if (currentEditorViewModels != null)
            {
                for (int i = this.currentEditorViewModelsAlphabetic.Count - 1; i >= 0; i--)
                    this.currentEditorViewModelsAlphabetic[i].Dispose();
                this.currentEditorViewModelsAlphabetic.Clear();
            }
            if (currentEditorViewModels != null)
            {
                for (int i = this.currentEditorViewModelsCategorized.Count - 1; i >= 0; i--)
                    this.currentEditorViewModelsCategorized[i].Dispose();
                this.currentEditorViewModelsCategorized.Clear();
            }

            SelectedEditorViewModel = null;
            CurrentEditorViewModels = null;
            CurrentGridViewModel = null;

            base.OnDispose();
        }

        /// <summary>
        /// Compares two view models by comparing their property display names.
        /// </summary>
        /// <param name="x">IPropertyGridEditorViewModel to be compared.</param>
        /// <param name="y">IPropertyGridEditorViewModel to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareViewModels(PropertyGridEditorViewModel x, PropertyGridEditorViewModel y)
        {
            return x.PropertyDisplayName.CompareTo(y.PropertyDisplayName);
        }

        /// <summary>
        /// Compares two PropertyGridEditorCategoryViewModels by comparing their category names.
        /// </summary>
        /// <param name="x">PropertyGridEditorCategoryViewModel to be compared.</param>
        /// <param name="y">PropertyGridEditorCategoryViewModel to be compared.</param>
        /// <returns>Int from Compare.To</returns>
        private static int CompareCategoryViewModels(PropertyGridEditorCategoryViewModel x, PropertyGridEditorCategoryViewModel y)
        {
            return x.CategoryName.CompareTo(y.CategoryName);
        }

        /// <summary>
        /// Visibility changed..
        /// </summary>
        /// <param name="bVisible"></param>
        protected override void OnVisibilityChanged(bool bVisible)
        {
            if( this.IsInitialized && bVisible )
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdatePropertyGrid));

            base.OnVisibilityChanged(bVisible);
        }

    }
}

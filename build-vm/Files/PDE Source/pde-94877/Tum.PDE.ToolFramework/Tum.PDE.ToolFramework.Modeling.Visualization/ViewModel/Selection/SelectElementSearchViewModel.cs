using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Diagrams;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Select element via search view model.
    /// </summary>
    public class SelectElementSearchViewModel : BaseViewModel, ISelectElementSubViewModel
    {
        private DelegateCommand searchCommand;
        private DelegateCommand activatedCommand;

        private IEnumerable<ModelElement> selectableElements;
        private string searchText = "";
        private bool isActive = false;

        private BaseModelElementViewModel searchSelectedElement = null;

        private ObservableCollection<BaseModelElementViewModel> searchResultViewModels;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public SelectElementSearchViewModel(ViewModelStore viewModelStore)
            : this(viewModelStore, null)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="selectableElements">
        /// List of existing elements, that are allowed to be selected. Can be null to specify that
        /// the is no such restriction needed and that all elements can be selected.
        /// </param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SelectElementSearchViewModel(ViewModelStore viewModelStore, IEnumerable<ModelElement> selectableElements)
            : base(viewModelStore)
        {
            searchResultViewModels = new ObservableCollection<BaseModelElementViewModel>();

            searchCommand = new DelegateCommand(SearchCommand_Executed);
            activatedCommand = new DelegateCommand(ActivatedCommand_Executed);

            if (selectableElements != null)
            {
                this.selectableElements = selectableElements;

                // 'search' to display all selectableElements in the search list.
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(SearchCommand_Executed));
                
            }
            else
            {
                this.selectableElements = this.Store.ElementDirectory.AllElements;
            }
        }

        /// <summary>
        /// Gets the search results list.
        /// </summary>
        public ObservableCollection<BaseModelElementViewModel> SearchResultViewModels
        {
            get { return searchResultViewModels; }
        }

        /// <summary>
        /// Gets or sets the text to search for.
        /// </summary>
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// Search command.
        /// </summary>
        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
        }

        /// <summary>
        /// Activated command.
        /// </summary>
        public DelegateCommand ActivatedCommand
        {
            get { return activatedCommand; }
        }

        /// <summary>
        /// Gets or sets whether this view is active or not.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }        

        /// <summary>
        /// Gets or sets the element, that is selected in the search list.
        /// </summary>
        public BaseModelElementViewModel SearchSelectedElement
        {
            get
            {
                return searchSelectedElement;
            }
            set
            {
                searchSelectedElement = value;
                OnPropertyChanged("SearchSelectedElement");
                OnPropertyChanged("SelectedElement");
            }
        }

        /// <summary>
        /// Gets the selected model element.
        /// </summary>
        public object SelectedElement
        {
            get
            {
                if (this.SearchSelectedElement == null)
                    return null;
                else
                    return this.SearchSelectedElement.Element;
            }
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        private void SearchCommand_Executed()
        {
            this.SearchResultViewModels.Clear();
            SearchSelectedElement = null;

            string searchString = this.SearchText.Trim();
            foreach (ModelElement modelElement in selectableElements)
            {
                // exclude diagram elements from beeing found, wouldnt be
                // a problem if our dsl was entirely based on PDE (without the
                // requirement of MS Tools Modeling..)
                if (DiagramsDSLDomainModel.IsDefinedByModel(modelElement))
                    continue;
             
                bool bFound = false;
                if (searchString == string.Empty)
                    bFound = true;

                if (!bFound)
                    if( modelElement is IDomainModelOwnable )
                        if ((modelElement as IDomainModelOwnable).DomainElementHasName)
                        {
                            string text = (modelElement as IDomainModelOwnable).DomainElementName;
                            if (text.Contains(this.SearchText))
                                bFound = true;
                        }
                if (!bFound)
                    if (modelElement is IDomainModelOwnable)
                    {
                        string text = (modelElement as IDomainModelOwnable).DomainElementTypeDisplayName;
                        if (text != null)
                            if (text.Contains(this.SearchText))
                                bFound = true;
                    }

                if (bFound)
                    SearchResultViewModels.Add(
                        this.ViewModelStore.Factory.CreateModelElementBaseViewModel(modelElement));
            }

            Sort();
        }

        /// <summary>
        /// Sorts the current results list.
        /// </summary>
        private void Sort()
        {
            IOrderedEnumerable<BaseModelElementViewModel> items = this.SearchResultViewModels.OrderBy<BaseModelElementViewModel, string>((x) => (x.DomainElementFullName));

            ObservableCollection<BaseModelElementViewModel> temp = new ObservableCollection<BaseModelElementViewModel>();
            foreach (BaseModelElementViewModel item in items)
                temp.Add(item);

            this.searchResultViewModels = temp;
            OnPropertyChanged("SearchResultViewModels");  
            
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        private void ActivatedCommand_Executed()
        {
            if( !IsActive )
                IsActive = true;
        }

        /// <summary>
        /// Tries to set the selection to the given element.
        /// </summary>
        /// <param name="element">Element to select.</param>
        public void SetSelectedElement(object element)
        {
            if (element is ModelElement)
            {
                // TODO
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            if (searchResultViewModels != null)
            {
                foreach (BaseModelElementViewModel m in searchResultViewModels)
                    m.Dispose();

                searchResultViewModels.Clear();
            }

        }
    }
}

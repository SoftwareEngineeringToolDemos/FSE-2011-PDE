using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Selects an element from the model in a new window.
    /// </summary>
    public class SelectElementViewModel : BaseWindowViewModel
    {
        private string title = "Select an element";
        private bool isSelectionValid = false;        

        private SelectElementTreeViewModel selectElementTreeViewModel;
        private SelectElementSearchViewModel selectElementSearchViewModel;

        List<object> selectableElements;

        private ISelectElementSubViewModel activeSubModel = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="selectableElements">
        /// List of existing elements, that are allowed to be selected. Can be null to specify that
        /// the is no such restriction needed and that all elements can be selected.
        /// </param>
        public SelectElementViewModel(ViewModelStore viewModelStore, List<object> selectableElements)
            : base(viewModelStore)
        {
            selectElementTreeViewModel = new SelectElementTreeViewModel(viewModelStore);
            
            if( selectableElements != null )
                selectElementSearchViewModel = new SelectElementSearchViewModel(viewModelStore, selectableElements.Cast<ModelElement>());
            else
                selectElementSearchViewModel = new SelectElementSearchViewModel(viewModelStore);

            selectElementTreeViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);
            selectElementSearchViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);

            this.selectableElements = selectableElements;            
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public SelectElementViewModel(ViewModelStore viewModelStore)
            : this(viewModelStore, null)
        {
   
        }

        /// <summary>
        /// React on sub model property changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void SubModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsActive")
            {
                ISelectElementSubViewModel v = sender as ISelectElementSubViewModel;
                if (v != null && v.IsActive)
                {
                    if (activeSubModel != null)
                        activeSubModel.IsActive = false;

                    activeSubModel = sender as ISelectElementSubViewModel;

                    // update IsSelectionValid
                    if (activeSubModel.SelectedElement == null)
                    {
                        IsSelectionValid = false;
                    }
                    else
                    {
                        if (selectableElements != null)
                        {
                            if (this.selectableElements.Contains(activeSubModel.SelectedElement))
                                IsSelectionValid = true;
                            else
                                IsSelectionValid = false;
                        }
                        else
                            IsSelectionValid = true;
                    }                    
                }
            }
            else if (e.PropertyName == "SelectedElement")
            {
                if (sender == activeSubModel && activeSubModel != null)
                {
                    if (activeSubModel.SelectedElement == null)
                    {
                        IsSelectionValid = false;
                    }
                    else
                    {
                        if (selectableElements != null)
                        {
                            if (this.selectableElements.Contains(activeSubModel.SelectedElement))
                                IsSelectionValid = true;
                            else
                                IsSelectionValid = false;
                        }
                        else
                            IsSelectionValid = true;
                    }

                }
            }
        }

        /// <summary>
        /// Tries to set the selected elements to the given object. Not all sub viewmodels might be
        /// capable of setting a selection.
        /// </summary>
        /// <param name="element">Element to select.</param>
        public virtual void SetSelectedElement(object element)
        {
            SelectElementTreeViewModel.SetSelectedElement(element);
            SelectElementSearchViewModel.SetSelectedElement(element);
        }

        /// <summary>
        /// Gets the select element tree vm.
        /// </summary>
        public SelectElementTreeViewModel SelectElementTreeViewModel
        {
            get { return this.selectElementTreeViewModel; }
        }

        /// <summary>
        /// Gets the select element search vm.
        /// </summary>
        public SelectElementSearchViewModel SelectElementSearchViewModel
        {
            get { return this.selectElementSearchViewModel; }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                OnPropertyChanged("Title");
            }
        }
        
        /// <summary>
        /// Gets or sets whether the current selection is valid or not.
        /// </summary>
        public bool IsSelectionValid
        {
            get
            {
                return isSelectionValid;
            }
            set
            {
                isSelectionValid = value;
                OnPropertyChanged("IsSelectionValid");
            }
        }

        /// <summary>
        /// Gets  the selected element.
        /// </summary>
        public object SelectedElement
        {
            get
            {
                if (activeSubModel != null)
                    return activeSubModel.SelectedElement;
                else
                    return null;
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            selectElementTreeViewModel.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);
            selectElementSearchViewModel.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);

            if (selectElementTreeViewModel != null)
                selectElementTreeViewModel.Dispose();

            if (selectElementSearchViewModel != null)
                selectElementSearchViewModel.Dispose();
        }
    }
}

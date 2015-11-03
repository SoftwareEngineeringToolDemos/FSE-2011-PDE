using System;

using System.Collections.Generic;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Selects an element within a collection.
    /// </summary>
    public class SelectGenericViewModel<T> : BaseWindowViewModel
        where T : struct
    {
        private string title = "Select an element and a relationship type";
        private bool isSelectionValid = false;

        private SelectGenericSearchViewModel<T> selectElementSearchViewModel;
        List<T> selectableElements;

        private ISelectGenericSubViewModel<T> activeSubModel = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="selectableElements">
        /// List of existing elements, that are allowed to be selected. Can be null to specify that
        /// the is no such restriction needed and that all elements can be selected.
        /// </param>
        /// <param name="searchAction">Search action.</param>
        /// <param name="sortAction">Sort action.</param>
        public SelectGenericViewModel(ViewModelStore viewModelStore, List<T> selectableElements, GenericSearchDelegate<T> searchAction, GenericSortDelegate<T> sortAction)
            : base(viewModelStore)
        {
            selectElementSearchViewModel = new SelectGenericSearchViewModel<T>(viewModelStore, selectableElements, searchAction, sortAction);
            selectElementSearchViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);

            this.selectableElements = selectableElements;            
        }

        /// <summary>
        /// React on property changes on submodels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void SubModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.IsDisposed)
                return;

            if (e.PropertyName == "IsActive")
            {
                ISelectGenericSubViewModel<T> v = sender as ISelectGenericSubViewModel<T>;
                if (v != null && v.IsActive)
                {
                    if (activeSubModel != null)
                        activeSubModel.IsActive = false;

                    activeSubModel = sender as ISelectGenericSubViewModel<T>;

                    // update IsSelectionValid
                    if (activeSubModel.SelectedElement == null)
                    {
                        IsSelectionValid = false;
                    }
                    else
                    {
                        if (selectableElements != null && activeSubModel.SelectedElement != null)
                        {
                            if (this.selectableElements.Contains(activeSubModel.SelectedElement.Value))
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
                        if (selectableElements != null && activeSubModel.SelectedElement != null)
                        {
                            if (this.selectableElements.Contains(activeSubModel.SelectedElement.Value))
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
        public virtual void SetSelectedElement(T element)
        {
            SelectGenericSearchViewModel.SetSelectedElement(element);
        }

        /// <summary>
        /// Gets the select element search vm.
        /// </summary>
        public SelectGenericSearchViewModel<T> SelectGenericSearchViewModel
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
        public Nullable<T> SelectedElement
        {
            get
            {
                if (activeSubModel != null)
                    return activeSubModel.SelectedElement;

                return null;
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            selectElementSearchViewModel.PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(SubModel_PropertyChanged);

            if (selectElementSearchViewModel != null)
                selectElementSearchViewModel.Dispose();
        }
    }
}

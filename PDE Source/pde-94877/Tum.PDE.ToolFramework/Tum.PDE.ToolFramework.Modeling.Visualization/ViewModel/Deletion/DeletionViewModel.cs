using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Deletion
{
    /// <summary>
    /// This model is used for managing the deletion of specific model elements.
    /// </summary>
    public class DeletionViewModel : BaseWindowViewModel
    {
        private DependenciesViewModel dependenciesViewModel;
        private string title;
        private string description;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public DeletionViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            this.dependenciesViewModel = new DependenciesViewModel(viewModelStore, false);

            this.title = Tum.PDE.ToolFramework.Modeling.Visualization.Properties.Resources.DeletionViewModel_Titel;
            this.description = Tum.PDE.ToolFramework.Modeling.Visualization.Properties.Resources.DeletionViewModel_Description;
        }

        /// <summary>
        /// Gets or sets the title of this view model.
        /// </summary>
        public string Title
        {
            get{ return this.title; }
            set
            {
                this.title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the description of this view model.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets the dependencies view model.
        /// </summary>
        public DependenciesViewModel DependenciesViewModel
        {
            get { return this.dependenciesViewModel; }
        }

        /// <summary>
        /// Gatheres dependencies on elements that are about to be deleted and wraps them for display.
        /// </summary>
        /// <param name="elementsToBeDeleted">Elements that are about to be deleted.</param>
        public void Set(List<ModelElement> elementsToBeDeleted)
        {
            // for each element that is about to be deleted gather child elements, so that we display all relationships that are
            // about to be deleted.
            List<ModelElement> elements = new List<ModelElement>();
            elements.AddRange(elementsToBeDeleted);
            foreach (ModelElement element in elements)
            {
                List<ModelElement> children = this.ViewModelStore.GetDomainModelServices(element).ElementChildrenProvider.GetChildren(element, false);
                foreach (ModelElement child in children)
                    if (!elementsToBeDeleted.Contains(child))
                        elementsToBeDeleted.Add(child);            
            }

            this.dependenciesViewModel.Set(elementsToBeDeleted);
        }

        /// <summary>
        /// Gatheres dependencies on elements that are about to be deleted and wraps them for display.
        /// </summary>
        /// <param name="elementsToBeDeleted">Elements that are about to be deleted.</param>
        /// <param name="options">Options</param>
        public void Set(List<ModelElement> elementsToBeDeleted, DependenciesRetrivalOptions options)
        {
            // for each element that is about to be deleted gather child elements, so that we display all relationships that are
            // about to be deleted.
            List<ModelElement> elements = new List<ModelElement>();
            elements.AddRange(elementsToBeDeleted);
            foreach (ModelElement element in elements)
            {
                List<ModelElement> children = this.ViewModelStore.GetDomainModelServices(element).ElementChildrenProvider.GetChildren(element, true);
                foreach (ModelElement child in children)
                    if (!elementsToBeDeleted.Contains(child))
                        elementsToBeDeleted.Add(child);            
            }

            this.dependenciesViewModel.Set(elementsToBeDeleted);
        }        

        /// <summary>
        /// Returns a list of active dependencies wrapped in a view model.
        /// </summary>
        /// <returns>List of dependency item view models.</returns>
        public ReadOnlyCollection<DependencyItemViewModel> GetActiveDependencies()
        {
            return this.dependenciesViewModel.ActiveDependencies;
        }
    }
}

using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This abstract base class provides methods/properties that are necessary for a propery grid view model.
    /// Classes that derive from this base class represent concrete property grid view models (for specific elements).
    /// Idealy, we would use this model for visualization in the view, but since we need to be able
    /// to edit equal properties of multiple elements at once, we can not use this for display. Thus,
    /// we combine multiple view models which derive from this class in the main property grid view 
    /// model (MainPropertyGridViewModel).
    /// </summary>
    public abstract class PropertyGridViewModel : BaseViewModel
    {
        private ModelElement element = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Model element for which this property grid view model is created.</param>
        protected PropertyGridViewModel(ViewModelStore viewModelStore, ModelElement element)
            : base(viewModelStore)
        {
            this.element = element;   
        }
        
        /// <summary>
        /// Gets the model element (part of the Model), which is represented by this view model.
        /// </summary>
        public ModelElement Element
        {
            get { return this.element; }
        }

        /// <summary>
        /// Gets or sets the full name of the element, which properties are to be added.
        /// </summary>
        public abstract string ElementFullName { get; set; }

        /// <summary>
        /// Gets the description of the element, which properties are to be added.
        /// </summary>
        public abstract string ElementDescription { get; }

        /// <summary>
        /// Returns the collection of editor view models.
        /// </summary>
        /// <returns></returns>
        public abstract List<PropertyGridEditorViewModel> GetEditorViewModels();
    }
}

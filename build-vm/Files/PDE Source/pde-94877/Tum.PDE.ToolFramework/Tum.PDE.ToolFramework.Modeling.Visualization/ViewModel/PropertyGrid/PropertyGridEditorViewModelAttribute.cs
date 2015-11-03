using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// Property grid editor vm attribute.
    /// </summary>
    public class PropertyGridEditorViewModelAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the view model type.
        /// </summary>
        public Type ViewModelType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the constructor delegate.
        /// </summary>
        public PropertyGridViewModelConstructor<ModelElement> ConstructorDelegate
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vm">Type of the editor.</param>
        public PropertyGridEditorViewModelAttribute(Type vm) : 
            this(vm, null)
        {
            
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vm">Type of the editor.</param>
        /// <param name="constructor">Constructor delegate.</param>
        public PropertyGridEditorViewModelAttribute(Type vm, PropertyGridViewModelConstructor<ModelElement> constructor)
        {
            this.ViewModelType = vm;
            this.ConstructorDelegate = constructor;
        }
    }
}

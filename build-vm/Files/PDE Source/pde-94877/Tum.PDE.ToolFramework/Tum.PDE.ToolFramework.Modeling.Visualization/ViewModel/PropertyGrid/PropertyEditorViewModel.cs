using System;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This is the base property editor class, that subscribes to property changes in the model to
    /// reflect them on the view model
    /// </summary>
    public abstract class PropertyEditorViewModel : PropertyGridEditorViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected PropertyEditorViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {

        }

        /// <summary>
        /// Subscribe to model element changes
        /// </summary>
        public override void SubscribeToModelChanges()
        {
            // subscribe to <#= domainElement.Name #>.<#= property.Name #> changes
            foreach (ModelElement modelElement in this.Elements)
            {
                Guid? propertyId = PropertyGridEditorViewModel.GetPropertyDomainObjectId(modelElement, this.PropertyName);
                if (propertyId != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainProperty(propertyId.Value),  modelElement.Id, new System.Action<ElementPropertyChangedEventArgs>(OnPropertyChanged));
            }
        }

        /// <summary>
        /// Update property current value.
        /// </summary>
        private void OnPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            OnPropertyChanged("PropertyValue");
        }

        /// <summary>
        /// Unregister from events although they are weak.
        /// </summary>
        protected override void OnDispose()
        {
            foreach (ModelElement modelElement in this.Elements)
            {
                Guid? propertyId = PropertyGridEditorViewModel.GetPropertyDomainObjectId(modelElement, this.PropertyName);
                if (propertyId != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainProperty(propertyId.Value), modelElement.Id, new System.Action<ElementPropertyChangedEventArgs>(OnPropertyChanged));
            }

            base.OnDispose();
        }
    }
}

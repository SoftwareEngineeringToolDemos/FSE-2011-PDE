using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view model hosts a serialized id property.
    /// </summary>
    public class SerializedIdPropertyViewModel : SerializationAttributeElementViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedIdProperty">SerializedIdProperty.</param>
        public SerializedIdPropertyViewModel(ViewModelStore viewModelStore, SerializedIdProperty serializedIdProperty, SerializationClassViewModel parent)
            : base(viewModelStore, serializedIdProperty, null, parent)
        {
            if (this.SerializationElement != null)
            {
                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedIdPropertyPropertyChanged));
            }
        }

        /// <summary>
        /// Gets the serialization element.
        /// </summary>
        public new SerializedIdProperty SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedIdProperty;
            }
        }
        
        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.IdProperty; }
        }

        /// <summary>
        /// Gets the serialization name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.SerializationElement.Name;
            }
        }

        /// <summary>
        /// Gets the serialization name.
        /// </summary>
        public string SerializationName
        {
            get
            {
                return this.SerializationElement.SerializationName;
            }
        }

        /// <summary>
        /// Gets the OmitProperty property value.
        /// </summary>
        public bool OmitIdProperty
        {
            get
            {
                return this.SerializationElement.OmitIdProperty;
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnSerializedIdPropertyPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == SerializedIdProperty.NameDomainPropertyId)
                OnPropertyChanged("Name");
            else
            if (args.DomainProperty.Id == SerializedIdProperty.SerializationNameDomainPropertyId)
                OnPropertyChanged("SerializationName");
            else if (args.DomainProperty.Id == SerializedIdProperty.OmitIdPropertyDomainPropertyId)
                OnPropertyChanged("OmitIdProperty");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.SerializationElement != null)
            {
                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedIdPropertyPropertyChanged));
            }

            base.OnDispose();
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            return this.SerializationElement;
        }
    }
}

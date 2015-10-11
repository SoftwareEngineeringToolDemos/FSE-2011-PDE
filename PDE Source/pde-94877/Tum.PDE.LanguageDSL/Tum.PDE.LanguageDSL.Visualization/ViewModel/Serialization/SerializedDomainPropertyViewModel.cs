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
    /// This view model hosts a serialized domain property.
    /// </summary>
    public class SerializedDomainPropertyViewModel : SerializationAttributeElementViewModel
    {       
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedDomainProperty">SerializedDomainProperty.</param>
        public SerializedDomainPropertyViewModel(ViewModelStore viewModelStore, SerializedDomainProperty serializedDomainProperty, SerializationClassViewModel parent)
            : base(viewModelStore, serializedDomainProperty, serializedDomainProperty.DomainProperty, parent)
        {
            if (this.SerializationElement != null)
            {
                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedPropertyPropertyChanged));

                if (this.SerializationElement.DomainProperty != null)
                {
                    // TODO: Add, Change, Delete property type
                }
            }
        }

        /// <summary>
        /// Gets the serialization element.
        /// </summary>
        public new SerializedDomainProperty SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedDomainProperty;
            }
        }

        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.DomainProperty; }
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
        public bool OmitProperty
        {
            get
            {
                return this.SerializationElement.OmitProperty;
            }
        }

        /// <summary>
        /// Gets the SerializationRepresentationType property value.
        /// </summary>
        public SerializationRepresentationType SerializationRepresentationType
        {
            get
            {
                return this.SerializationElement.SerializationRepresentationType;
            }
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string DomainPropertyName
        {
            get
            {
                if( this.SerializationElement.DomainProperty != null )
                    return this.SerializationElement.DomainProperty.Name;

                return "";
            }
        }

        /// <summary>
        /// Gets the property type.
        /// </summary>
        public string DomainPropertyType
        {
            get
            {
                if (this.SerializationElement.DomainProperty != null)
                    if (this.SerializationElement.DomainProperty.Type != null)
                        return this.SerializationElement.DomainProperty.Type.Name;

                return "";
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnSerializedPropertyPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == SerializedDomainProperty.SerializationNameDomainPropertyId)
                OnPropertyChanged("SerializationName");
            else if (args.DomainProperty.Id == SerializedDomainProperty.OmitPropertyDomainPropertyId)
                OnPropertyChanged("OmitProperty");
            else if (args.DomainProperty.Id == SerializedDomainProperty.SerializationRepresentationTypeDomainPropertyId)
                OnPropertyChanged("SerializationRepresentationType");            
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.SerializationElement != null)
            {
                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedPropertyPropertyChanged));
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

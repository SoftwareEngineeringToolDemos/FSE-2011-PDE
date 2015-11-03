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
    /// This view model hosts a SerializedReferenceRelationship.
    /// </summary>
    public class SerializedReferenceRelationshipViewModel : SerializedRelationshipViewModel
    {        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedRelationship">SerializedRelationship.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        public SerializedReferenceRelationshipViewModel(ViewModelStore viewModelStore, SerializedReferenceRelationship serializedRelationship, SerializationClassViewModel parent)
            : base(viewModelStore, serializedRelationship, serializedRelationship.ReferenceRelationship, parent)
        {
            if( this.SerializationElement != null )
                if (this.SerializationElement.ReferenceRelationship != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.SerializationElement.ReferenceRelationship.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedReferenceRelationshipPropertyChanged));
        }

        /// <summary>
        /// Gets the serialized rs.
        /// </summary>
        public new SerializedReferenceRelationship SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedReferenceRelationship;
            }
        }

        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.ReferenceRelationship; }
        }

        /// <summary>
        /// Gets the serialization attribute name.
        /// </summary>
        public string SerializationAttributeName
        {
            get
            {
                return this.SerializationElement.ReferenceRelationship.SerializationAttributeName;
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnSerializedReferenceRelationshipPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == ReferenceRelationship.SerializationAttributeNameDomainPropertyId)
                OnPropertyChanged("SerializationAttributeName");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.SerializationElement != null)
                if (this.SerializationElement.ReferenceRelationship != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.SerializationElement.ReferenceRelationship.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedReferenceRelationshipPropertyChanged));


            base.OnDispose();
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            if( !this.IsInFullSerialization )
                return this.TargetRole.GetHostedElement();

            return this.SerializationElement;
        }
    }
}

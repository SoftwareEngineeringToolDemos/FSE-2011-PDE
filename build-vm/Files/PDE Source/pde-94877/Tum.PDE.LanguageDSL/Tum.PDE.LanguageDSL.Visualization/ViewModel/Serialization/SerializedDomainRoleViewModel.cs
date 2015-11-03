using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view mode hosts a serialized domain role.
    /// </summary>
    public class SerializedDomainRoleViewModel : SerializationElementViewModel
    {
        SerializedRelationshipViewModel parentVM;
        private DomainRole domainRole;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedDomainRole">SerializedDomainRole.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        public SerializedDomainRoleViewModel(ViewModelStore viewModelStore, SerializedDomainRole serializedDomainRole, DomainRelationship referencedElement, SerializedRelationshipViewModel parentVM)
            : base(viewModelStore, serializedDomainRole, referencedElement)
        {
            this.parentVM = parentVM;

            if (this.SerializationElement != null)
            {
                this.domainRole = this.SerializationElement.DomainRole;

                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));

                if (domainRole != null)
                {
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.domainRole.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));

                    if (this.domainRole.RolePlayer != null)
                        this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.domainRole.RolePlayer.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));
                }
            }
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedDomainRole">SerializedDomainRole.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        public SerializedDomainRoleViewModel(ViewModelStore viewModelStore, DomainRole domainRole, DomainRelationship referencedElement, SerializedRelationshipViewModel parentVM)
            : base(viewModelStore, null, referencedElement)
        {
            this.parentVM = parentVM;
            this.domainRole = domainRole;

            if (domainRole != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.domainRole.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));

                if (this.domainRole.RolePlayer != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.domainRole.RolePlayer.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));
            }
        }

        /// <summary>
        /// Gets the parent view model.
        /// </summary>
        public SerializedRelationshipViewModel Parent
        {
            get
            {
                return this.parentVM;
            }
        }

        /// <summary>
        /// Gets the serialized role.
        /// </summary>
        public new SerializedDomainRole SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedDomainRole;
            }
        }

        /// <summary>
        /// Gets the serialized element type.
        /// </summary>
        public override SerializationElementType SerializationElementType
        {
            get { return SerializationElementType.DomainRole; }
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
        /// Gets the serialization attribute name.
        /// </summary>
        public string SerializationAttributeName
        {
            get
            {
                return this.SerializationElement.SerializationAttributeName;
            }
        }

        /// <summary>
        /// Gets whether the relationship this serialized role belongs to is a reference relationship or not.
        /// </summary>
        public bool IsReferenceRelationship
        {
            get
            {
                return this.SerializationElement.SerializedRelationship is SerializedReferenceRelationship;
            }
        }

        /// <summary>
        /// Gets the role player name.
        /// </summary>
        public string RolePlayerName
        {
            get
            {
                if (this.domainRole.RolePlayer != null)
                    return this.domainRole.RolePlayer.Name;

                return "";
            }
        }

        /// <summary>
        /// Gets the role multiplicity.
        /// </summary>
        public Multiplicity Multiplicity
        {
            get
            {
                return this.domainRole.Multiplicity;
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnSerializedRolePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == SerializedDomainRole.SerializationNameDomainPropertyId)
                OnPropertyChanged("SerializationName");
            else if (args.DomainProperty.Id == SerializedDomainRole.SerializationAttributeNameDomainPropertyId)
                OnPropertyChanged("SerializationAttributeName");
            else if (args.DomainProperty.Id == AttributedDomainElement.NameDomainPropertyId)
                OnPropertyChanged("RolePlayerName");
            else if (args.DomainProperty.Id == DomainRole.MultiplicityDomainPropertyId)
                OnPropertyChanged("Multiplicity");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.SerializationElement != null)
            {
                // unsubscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));
            }
            if (this.domainRole != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.domainRole.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));

                if (this.domainRole.RolePlayer != null)
                    this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.domainRole.RolePlayer.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializedRolePropertyChanged));
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

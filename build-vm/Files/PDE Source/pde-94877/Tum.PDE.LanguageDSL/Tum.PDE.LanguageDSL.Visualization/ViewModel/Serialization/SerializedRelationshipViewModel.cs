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
    /// This view model hosts a serialized relationship view model.
    /// </summary>
    public abstract class SerializedRelationshipViewModel : SerializationClassViewModel
    {
        protected SerializedDomainRoleViewModel sourceRoleVM;
        protected SerializedDomainRoleViewModel targetRoleVM;
        private SerializationClassViewModel targetClassVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializedRelationship">SerializedRelationship.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        protected SerializedRelationshipViewModel(ViewModelStore viewModelStore, SerializedRelationship serializedRelationship, DomainRelationship referencedElement, SerializationClassViewModel parent)
            : base(viewModelStore, serializedRelationship, referencedElement, parent)
        {
            if (this.SerializationElement != null)
            {
                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializationRelationshipropertyChanged));

                if (this.SerializationElement.SerializedDomainRoles.Count > 0)
                {
                    sourceRoleVM = new SerializedDomainRoleViewModel(this.ViewModelStore, this.SerializationElement.SerializedDomainRoles[0], referencedElement, this);
                    this.AddChild(sourceRoleVM);
                }

                if (this.SerializationElement.SerializedDomainRoles.Count > 1)
                {
                    targetRoleVM = new SerializedDomainRoleViewModel(this.ViewModelStore, this.SerializationElement.SerializedDomainRoles[1], referencedElement, this);

                    if (targetRoleVM.SerializationElement.SerializationClass is SerializedDomainClass)
                        targetClassVM = new SerializedDomainClassViewModel(this.ViewModelStore, targetRoleVM.SerializationElement.SerializationClass as SerializedDomainClass, this);
                    else if (targetRoleVM.SerializationElement.SerializationClass is SerializedReferenceRelationship)
                        targetClassVM = new SerializedReferenceRelationshipViewModel(this.ViewModelStore, targetRoleVM.SerializationElement.SerializationClass as SerializedReferenceRelationship, this);

                    this.AddChild(targetRoleVM);
                }
            }
        }

        /// <summary>
        /// Gets the serialized rs.
        /// </summary>
        public new SerializedRelationship SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializedRelationship;
            }
        }

        /// <summary>
        /// Gets the source role view model.
        /// </summary>
        public SerializedDomainRoleViewModel SourceRole
        {
            get { return this.sourceRoleVM; }
        }

        /// <summary>
        /// Gets the target role view model.
        /// </summary>
        public SerializedDomainRoleViewModel TargetRole
        {
            get { return this.targetRoleVM; }
        }

        /// <summary>
        /// Gets the target class view model.
        /// </summary>
        public SerializationClassViewModel TargetClassViewModel
        {
            get
            {
                return this.targetClassVM;
            }
        }

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public override bool HasLoadedChildren
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the IsInFullSerialization property.
        /// </summary>
        public bool IsInFullSerialization
        {
            get
            {
                return this.SerializationElement.IsInFullSerialization;
            }
        }

        /// <summary>
        /// Gets the OmitRelationship property.
        /// </summary>
        public bool OmitRelationship
        {
            get
            {
                return this.SerializationElement.OmitRelationship;
            }
        }
        
        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnSerializationRelationshipropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == SerializedRelationship.IsInFullSerializationDomainPropertyId)
                OnPropertyChanged("IsInFullSerialization");
            else if (args.DomainProperty.Id == SerializedRelationship.OmitRelationshipDomainPropertyId)
                OnPropertyChanged("OmitRelationship");
        }
        
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.SerializationElement != null)
            {
                // unsubscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializationRelationshipropertyChanged));
            }

            base.OnDispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model holds a domain property.
    /// </summary>
    public class DomainPropertyViewModel : BaseModelElementViewModel
    {
        DomainProperty domainProperty;
        BaseModelElementViewModel parentElement;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="domainProperty">Domain property.</param>
        /// <param name="parent">Parent node.</param>
        public DomainPropertyViewModel(ViewModelStore viewModelStore, DomainProperty domainProperty, BaseModelElementViewModel parent)
            : base(viewModelStore, parent.Element)
        {
            this.domainProperty = domainProperty;
            this.parentElement = parent;

            if (domainProperty != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(domainProperty.Id,
                    new System.Action<ElementPropertyChangedEventArgs>(OnPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainPropertyReferencesType.DomainClassId),
                    true, this.DomainProperty.Id, new Action<ElementAddedEventArgs>(OnTypeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainPropertyReferencesType.DomainClassId),
                    true, this.DomainProperty.Id, new Action<ElementDeletedEventArgs>(OnTypeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(DomainPropertyReferencesType.DomainTypeDomainRoleId), 
                    new Action<RolePlayerChangedEventArgs>(OnTypeChanged));
            }
        }

        public BaseModelElementViewModel Parent
        {
            get
            {
                return this.parentElement;
            }
        }

        /// <summary>
        /// Gets the domain property.
        /// </summary>
        public DomainProperty DomainProperty
        {
            get
            {
                return this.domainProperty;
            }
        }

        /// <summary>
        /// Gets the "IsRequired" property.
        /// </summary>
        public bool IsRequired
        {
            get
            {
                return this.DomainProperty.IsRequired;
            }
        }

        /// <summary>
        /// Gets the "IsElementName" property.
        /// </summary>
        public bool IsElementName
        {
            get
            {
                return this.DomainProperty.IsElementName;
            }
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return this.DomainProperty.Name;
            }
            set
            {
                if (this.PropertyName != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update property name"))
                    {
                        this.DomainProperty.Name = value;

                        transaction.Commit();
                    }

                    OnPropertyChanged("PropertyName");
                }
            }
        }

        /// <summary>
        /// Gets the property type.
        /// </summary>
        public string PropertyType
        {
            get
            {
                if (this.DomainProperty.Type != null)
                    return this.DomainProperty.Type.Name;

                return "";
            }
        }

        /// <summary>
        /// Called whenever the property Name changes its value.
        /// </summary>
        private void OnPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == DomainProperty.NameDomainPropertyId)
                OnPropertyChanged("PropertyName");
            else if (args.DomainProperty.Id == DomainProperty.IsRequiredDomainPropertyId)
                OnPropertyChanged("IsRequired");
            else if (args.DomainProperty.Id == DomainProperty.IsElementNameDomainPropertyId)
                OnPropertyChanged("IsElementName");
        }

        /// <summary>
        /// Called whenever a relationship of type DomainPropertyReferencesType is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnTypeAdded(ElementAddedEventArgs args)
        {
            OnPropertyChanged("PropertyType");
        }

        /// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args"></param>
        private void OnTypeChanged(RolePlayerChangedEventArgs args)
        {
            DomainPropertyReferencesType con = args.ElementLink as DomainPropertyReferencesType;
            if( con != null )
                if( con.DomainProperty.Id == this.DomainProperty.Id )
                    OnPropertyChanged("PropertyType");
        }

        /// <summary>
        /// Called whenever a relationship of type DomainPropertyReferencesType is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnTypeRemoved(ElementDeletedEventArgs args)
        {
            OnPropertyChanged("PropertyType");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (domainProperty != null)
            {
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(domainProperty.Id,
                    new System.Action<ElementPropertyChangedEventArgs>(OnPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainPropertyReferencesType.DomainClassId),
                    true, this.DomainProperty.Id, new Action<ElementAddedEventArgs>(OnTypeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(DomainPropertyReferencesType.DomainClassId),
                    true, this.DomainProperty.Id, new Action<ElementDeletedEventArgs>(OnTypeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(DomainPropertyReferencesType.DomainTypeDomainRoleId),
                    new Action<RolePlayerChangedEventArgs>(OnTypeChanged));
            }

            base.OnDispose();
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            return this.DomainProperty;
        }

        /// <summary>
        /// Deletes the hosted element.
        /// </summary>
        public override void DeleteHostedElement()
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete hosted element"))
            {
                this.DomainProperty.Delete();

                transaction.Commit();
            }
        }
    }
}

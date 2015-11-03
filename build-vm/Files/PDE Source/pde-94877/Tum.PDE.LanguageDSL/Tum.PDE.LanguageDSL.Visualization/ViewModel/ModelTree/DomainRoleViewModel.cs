using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree
{
    /// <summary>
    /// This view model hosts a domain role.
    /// </summary>
    public class DomainRoleViewModel : BaseModelElementViewModel
    {
        private DomainRelationshipViewModel parentVM;
        private DomainRole domainRole;
        
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="referenceRSNode">ReferenceRSNode.</param>
        /// <param name="parent">Parent.</param>
        public DomainRoleViewModel(ViewModelStore viewModelStore, DomainRole role, DomainRelationshipViewModel parent)
            : base(viewModelStore, role.Relationship)
        {
            this.parentVM = parent;
            this.domainRole = role;

            this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Role.Id, new Action<ElementPropertyChangedEventArgs>(OnRolePropertyChanged));
        }

        /// <summary>
        /// Gets the domain role.
        /// </summary>
        public DomainRole Role
        {
            get
            {
                return this.domainRole;
            }
        }

        /// <summary>
        /// Gets or sets the property "IsPropertyGenerator".
        /// </summary>
        public bool IsPropertyGenerator
        {
            get
            {
                return this.Role.IsPropertyGenerator;

            }
            set
            {
                if (this.Role.IsPropertyGenerator != value)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Set IsPropertyGenerator"))
                    {
                        this.Role.IsPropertyGenerator = value;

                        transaction.Commit();

                    }

                    OnPropertyChanged("IsPropertyGenerator");
                }
            }
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public string PropertyName
        {
            get
            {
                return this.Role.PropertyName;
            }
        }

        /// <summary>
        /// Gets the multiplicity value.
        /// </summary>
        public Multiplicity Multiplicity
        {
            get
            {
                return this.Role.Multiplicity;
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnRolePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == DomainRole.IsPropertyGeneratorDomainPropertyId)
                OnPropertyChanged("IsPropertyGenerator");
            else if (args.DomainProperty.Id == DomainRole.PropertyNameDomainPropertyId)
                OnPropertyChanged("PropertyName");
            else if (args.DomainProperty.Id == DomainRole.MultiplicityDomainPropertyId)
                OnPropertyChanged("Multiplicity");
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public override ModelElement GetHostedElement()
        {
            return this.Role;
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if( this.Role != null )
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Role.Id, new Action<ElementPropertyChangedEventArgs>(OnRolePropertyChanged));

            base.OnDispose();
        }
    }
}

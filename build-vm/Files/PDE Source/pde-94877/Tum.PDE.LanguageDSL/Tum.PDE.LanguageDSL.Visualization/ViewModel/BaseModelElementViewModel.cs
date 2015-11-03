using System;

using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    /// <summary>
    /// This is the base view model which represents a specific model element.
    /// </summary>
    public class BaseModelElementViewModel : BaseViewModel
    {
        private ModelElement element;
        private bool bHookUpEvents;
        private bool isLocked = false;
        private bool isSelected = false;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        public BaseModelElementViewModel(ViewModelStore viewModelStore, ModelElement element)
            : this(viewModelStore, element, true)
        {
        }

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        public BaseModelElementViewModel(ViewModelStore viewModelStore, ModelElement element, bool bHookUpEvents)
            : base(viewModelStore)
        {
            this.element = element;
            this.bHookUpEvents = bHookUpEvents;


            if (element != null)
                if (ImmutabilityExtensionMethods.GetLocks(element) != Locks.None)
                    this.IsLocked = true;

            if( this.bHookUpEvents )
                if (element != null)
                {
                    DomainPropertyInfo info = element.GetDomainClass().NameDomainProperty;
                    if (info != null)
                        this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(
                            info, this.Element.Id, new System.Action<ElementPropertyChangedEventArgs>(NamePropertyChanged));
                }
        }

        public bool IsLocked
        {
            get
            {
                return this.isLocked;
            }
            protected set
            {
                this.isLocked = value;
                OnPropertyChanged("IsLocked");
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// Gets the model element (part of the Model), which is represented by this view model.
        /// </summary>
        public ModelElement Element
        {
            get { return this.element; }
        }

        /// <summary>
        /// Gets the value of the property (which is marked as element name)
        /// </summary>
        public virtual string DomainElementName
        {
            get
            {
                if (this.Element is AttributedDomainElement)
                    return (this.Element as AttributedDomainElement).Name;

                if (LanguageDSLElementNameProvider.Instance.HasName(this.Element))
                    return LanguageDSLElementNameProvider.Instance.GetName(this.Element);
                
                return "";
            }
            set
            {
                if (value != this.DomainElementName && this.Element is AttributedDomainElement)
                {
                    using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("update name"))
                    {
                        (this.Element as AttributedDomainElement).Name = value;

                        transaction.Commit();
                    }

                    OnPropertyChanged("DomainElementName");
                }
            }
        }

        /// <summary>
        /// Gets the full name of the element.
        /// </summary>
        /// <remarks>
        /// This is either: ElementName (elemenType) or just ElementType.
        /// </remarks>
        public virtual string DomainElementFullName
        {
            get
            {
                if (this.DomainElementHasName)
                    return this.DomainElementName + " (" + this.DomainElementTypeDisplayName + ")";
                else
                    return this.DomainElementTypeDisplayName;
            }
        }

        /// <summary>
        /// Gets whether the domain element has a property marked as element name.
        /// </summary>
        public virtual bool DomainElementHasName
        {
            get
            {
                if (this.element == null)
                    return false;

                return this.element.GetDomainClass().NameDomainProperty != null;
            }
        }

        /// <summary>
        /// Gets the type of the ModelElement as string.
        /// </summary>
        public virtual string DomainElementType
        {
            get
            {
                if (this.element == null)
                    return "";

                return this.element.GetDomainClass().Name;
            }
        }

        /// <summary>
        /// Gets the display name of the type of the ModelElement.
        /// </summary>
        public virtual string DomainElementTypeDisplayName
        {
            get
            {
                if (this.element == null)
                    return "";

                return this.element.GetDomainClass().DisplayName;
            }
        }

        /// <summary>
        /// Called whenever the property Name changes its value.
        /// </summary>
        private void NamePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            OnPropertyChanged("DomainElementName");
            OnPropertyChanged("DomainElementFullName");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if( this.bHookUpEvents )
                if (element != null)
                {
                    DomainPropertyInfo info = element.GetDomainClass().NameDomainProperty;
                    if (info != null)
                        this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(
                            info, this.Element.Id, new System.Action<ElementPropertyChangedEventArgs>(NamePropertyChanged));
                }

            base.OnDispose();

            this.element = null;
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        /// <returns>Hosted model element.</returns>
        public virtual ModelElement GetHostedElement()
        {
            return this.Element;
        }

        /// <summary>
        /// Deletes the hosted element.
        /// </summary>
        public virtual void DeleteHostedElement()
        {
            if (this.element == null)
                return;

            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete hosted element"))
            {
                this.GetHostedElement().Delete();
                //this.Element.Delete();

                transaction.Commit();
            }
        }
    }
}

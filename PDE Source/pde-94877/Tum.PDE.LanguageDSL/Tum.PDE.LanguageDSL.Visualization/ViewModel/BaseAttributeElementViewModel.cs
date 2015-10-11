using System;

using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    /// <summary>
    /// This is the base view model which represents a specific model element.
    /// </summary>
    public class BaseAttributeElementViewModel : BaseModelElementViewModel
    {
        private ObservableCollection<DomainPropertyViewModel> propertiesVM;
        private ReadOnlyObservableCollection<DomainPropertyViewModel> propertiesVMRO;

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        public BaseAttributeElementViewModel(ViewModelStore viewModelStore, AttributedDomainElement element)
            : base(viewModelStore, element)
        {
            this.propertiesVM = new ObservableCollection<DomainPropertyViewModel>();
            this.propertiesVMRO = new ReadOnlyObservableCollection<DomainPropertyViewModel>(propertiesVM);

            if (this.Element != null)
            {
                foreach (DomainProperty p in element.Properties)
                {
                    AddProperty(p);
                }

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(AttributedDomainElementHasProperties.DomainClassId),
                    true, this.Element.Id, new Action<ElementAddedEventArgs>(OnDomainPropertyAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(AttributedDomainElementHasProperties.DomainClassId),
                    true, this.Element.Id, new Action<ElementDeletedEventArgs>(OnDomainPropertyRemoved));

                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.Element.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
            }
        }

        /// <summary>
        /// Gets a read-only collection of domain properties.
        /// </summary>
        public ReadOnlyObservableCollection<DomainPropertyViewModel> DomainProperties
        {
            get
            {
                return this.propertiesVMRO;
            }
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        public new AttributedDomainElement Element
        {
            get
            {
                return base.Element as AttributedDomainElement;
            }
        }

        /// <summary>
        /// True, if this node contains properties.
        /// </summary>
        public bool HasDomainProperties
        {
            get
            {
                if (this.DomainProperties.Count > 0)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Gets the properties description.
        /// </summary>
        public string PropertiesDescription
        {
            get
            {
                if (this.DomainProperties.Count == 1)
                    return "1 Domain Property";
                else
                    return this.DomainProperties.Count.ToString() + " Domain Properties";
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public virtual string Description
        {
            get
            {
                if (this.Element == null)
                    return "";

                return this.Element.Description;
            }
        }

        /// <summary>
        /// Gets the inheritance modifier.
        /// </summary>
        public InheritanceModifier InheritanceModifier
        {
            get
            {
                if (this.Element == null)
                    return LanguageDSL.InheritanceModifier.None;

                return this.Element.InheritanceModifier;
            }
        }

        /// <summary>
        /// Adds a new element view model for the given element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void AddProperty(DomainProperty element)
        {
            if (element == null)
                return;

            // verify that node hasnt been added yet
            foreach (DomainPropertyViewModel viewModel in this.propertiesVM)
                if (viewModel.DomainProperty.Id == element.Id)
                    return;

            DomainPropertyViewModel vm = new DomainPropertyViewModel(this.ViewModelStore, element, this);
            this.propertiesVM.Add(vm);

            OnPropertyChanged("HasDomainProperties");
            OnPropertyChanged("PropertiesDescription");
        }

        /// <summary>
        /// Deletes the element view model that is hosting the given element.
        /// </summary>
        /// <param name="node">Element.</param>
        public void DeleteProperty(DomainProperty element)
        {
            if (element == null)
                return;

            for (int i = this.propertiesVM.Count - 1; i >= 0; i--)
                if (this.propertiesVM[i].DomainProperty.Id == element.Id)
                {
                    this.propertiesVM[i].Dispose();
                    this.propertiesVM.RemoveAt(i);
                }
            
            OnPropertyChanged("HasDomainProperties");
            OnPropertyChanged("PropertiesDescription");
        }

        /// <summary>
        /// Called whenever a relationship of type AttributedDomainElementHasProperties is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnDomainPropertyAdded(ElementAddedEventArgs args)
        {
            AttributedDomainElementHasProperties con = args.ModelElement as AttributedDomainElementHasProperties;
            if (con != null)
            {
                AddProperty(con.DomainProperty);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type AttributedDomainElementHasProperties is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnDomainPropertyRemoved(ElementDeletedEventArgs args)
        {
            AttributedDomainElementHasProperties con = args.ModelElement as AttributedDomainElementHasProperties;
            if (con != null)
            {
                DeleteProperty(con.DomainProperty);
            }
        }

        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnElementPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == AttributedDomainElement.InheritanceModifierDomainPropertyId)
                OnPropertyChanged("InheritanceModifier");
            else if (args.DomainProperty.Id == AttributedDomainElement.DescriptionDomainPropertyId)
                OnPropertyChanged("Description");
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (Element != null)
            {
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(AttributedDomainElementHasProperties.DomainClassId),
                    true, this.Element.Id, new Action<ElementAddedEventArgs>(OnDomainPropertyAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(AttributedDomainElementHasProperties.DomainClassId),
                    true, this.Element.Id, new Action<ElementDeletedEventArgs>(OnDomainPropertyRemoved));

                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.Element.Id, new Action<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
            }

            base.OnDispose();
        }
    }
}

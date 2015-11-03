using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This class represents a specific item in the dependencies view model.
    /// </summary>
    public class DependencyItemViewModel : BaseViewModel
    {
        private DependencyItem dependencyItem;
        private int number = 0;
        private bool doSubscribeToEvents;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="dependencyItem">The model element that is hosted by this view model.</param>
        public DependencyItemViewModel(ViewModelStore viewModelStore, DependencyItem dependencyItem)
            : this(viewModelStore, dependencyItem, false)
        {
            this.dependencyItem = dependencyItem;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="dependencyItem">The model element that is hosted by this view model.</param>
        /// <param name="bSubscribeToEvents">True if updates on elements name changes are needed.</param>
        public DependencyItemViewModel(ViewModelStore viewModelStore, DependencyItem dependencyItem, bool bSubscribeToEvents)
            : base(viewModelStore)
        {
            if (dependencyItem == null)
                throw new ArgumentNullException("dependencyItem");

            this.dependencyItem = dependencyItem;
            this.doSubscribeToEvents = bSubscribeToEvents;

            if (this.doSubscribeToEvents)
            {
                // subscribe
                if ((dependencyItem.SourceElement is IDomainModelOwnable))
                    if ((dependencyItem.SourceElement as IDomainModelOwnable).DomainElementHasName)
                    {
                        DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(dependencyItem.SourceElement).ElementNameProvider.GetNamePropertyInfo(dependencyItem.SourceElement);
                        this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, dependencyItem.SourceElement.Id, OnSourceNamePropertyChanged);
                    }


                if ((dependencyItem.TargetElement is IDomainModelOwnable))
                    if ((dependencyItem.TargetElement as IDomainModelOwnable).DomainElementHasName)
                {
                    DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(dependencyItem.TargetElement).ElementNameProvider.GetNamePropertyInfo(dependencyItem.TargetElement);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, dependencyItem.TargetElement.Id, OnTargetNamePropertyChanged);
                }
                /*if (this.ViewModelStore.GetDomainModelServices(dependencyItem.SourceElement).ElementNameProvider.HasName(dependencyItem.SourceElement))
                {
                    DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(dependencyItem.SourceElement).ElementNameProvider.GetNamePropertyInfo(dependencyItem.SourceElement);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, dependencyItem.SourceElement.Id, OnSourceNamePropertyChanged);
                }
                if (this.ViewModelStore.GetDomainModelServices(dependencyItem.TargetElement).ElementNameProvider.HasName(dependencyItem.TargetElement))
                {
                    DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(dependencyItem.TargetElement).ElementNameProvider.GetNamePropertyInfo(dependencyItem.TargetElement);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, dependencyItem.TargetElement.Id, OnTargetNamePropertyChanged);
                }*/
            }
        }
        private void OnSourceNamePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            OnPropertyChanged("SourceModelElementName");
        }
        private void OnTargetNamePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            OnPropertyChanged("TargetModelElementName");
        }

        /// <summary>
        /// Gets the dependency items category.
        /// </summary>
        public DependencyItemCategory Category
        {
            get
            {
                return this.dependencyItem.Category;
            }
        }

        /// <summary>
        /// Gets the dependency item that is hosted by this view model.
        /// </summary>
        public DependencyItem DependencyItem
        {
            get
            {
                return this.dependencyItem;
            }
        }

        /// <summary>
        /// Gets the element link name if it has one. Otherwise the type of the link is returned.
        /// </summary>
        public string LinkElementName
        {
            get
            {
                if (this.DependencyItem != null )
                    if (this.DependencyItem.ElementLink is IDomainModelOwnable)
                    {
                        return (this.DependencyItem.ElementLink as IDomainModelOwnable).DomainElementFullName;
                    }

                return "";

                /*
                if (this.ViewModelStore.GetDomainModelServices(this.DependencyItem.ElementLink).ElementNameProvider.HasName(this.DependencyItem.ElementLink))
                    return this.ViewModelStore.GetDomainModelServices(this.DependencyItem.ElementLink).ElementNameProvider.GetName(this.DependencyItem.ElementLink) +
                        " (" + this.ViewModelStore.GetDomainModelServices(this.DependencyItem.ElementLink).ElementTypeProvider.GetTypeDisplayName(this.DependencyItem.ElementLink) + ")";
                else
                    return this.ViewModelStore.GetDomainModelServices(this.DependencyItem.ElementLink).ElementTypeProvider.GetTypeDisplayName(this.DependencyItem.ElementLink);
                */
            }
        }

        /// <summary>
        /// Gets the source model element's name.
        /// </summary>
        public string SourceModelElementName
        {
            get
            {
                if (this.DependencyItem != null)
                    if (this.DependencyItem.SourceElement is IDomainModelOwnable)
                    {
                        return (this.DependencyItem.SourceElement as IDomainModelOwnable).DomainElementFullName;
                    }

                return "";
                /*
                if (this.ViewModelStore.GetDomainModelServices(this.DependencyItem.SourceElement).ElementNameProvider.HasName(this.DependencyItem.SourceElement))
                    return this.ViewModelStore.GetDomainModelServices(this.DependencyItem.SourceElement).ElementNameProvider.GetName(this.DependencyItem.SourceElement) +
                        " (" + this.ViewModelStore.GetDomainModelServices(this.DependencyItem.SourceElement).ElementTypeProvider.GetTypeDisplayName(this.DependencyItem.SourceElement) + ")";
                else
                    return this.ViewModelStore.GetDomainModelServices(this.DependencyItem.SourceElement).ElementTypeProvider.GetTypeDisplayName(this.DependencyItem.SourceElement);
                */
            }
        }

        /// <summary>
        /// Gets the source model element's name.
        /// </summary>
        public string TargetModelElementName
        {
            get
            {
                if (this.DependencyItem != null)
                    if (this.DependencyItem.TargetElement is IDomainModelOwnable)
                    {
                        return (this.DependencyItem.TargetElement as IDomainModelOwnable).DomainElementFullName;
                    }

                return "";

                /*
                if (this.ViewModelStore.GetDomainModelServices(this.DependencyItem.TargetElement).ElementNameProvider.HasName(this.DependencyItem.TargetElement))
                    return this.ViewModelStore.GetDomainModelServices(this.DependencyItem.TargetElement).ElementNameProvider.GetName(this.DependencyItem.TargetElement) +
                        " (" + this.ViewModelStore.GetDomainModelServices(this.DependencyItem.TargetElement).ElementTypeProvider.GetTypeDisplayName(this.DependencyItem.TargetElement) + ")";
                else
                    return this.ViewModelStore.GetDomainModelServices(this.DependencyItem.TargetElement).ElementTypeProvider.GetTypeDisplayName(this.DependencyItem.TargetElement);
                */
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.doSubscribeToEvents)
                if (this.DependencyItem != null)
                {
                    // unsubscribe
                    if ((dependencyItem.SourceElement is IDomainModelOwnable))
                        if ((dependencyItem.SourceElement as IDomainModelOwnable).DomainElementHasName)
                        {
                            DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(dependencyItem.SourceElement).ElementNameProvider.GetNamePropertyInfo(dependencyItem.SourceElement);
                            this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(info, dependencyItem.SourceElement.Id, OnSourceNamePropertyChanged);
                        }

                    if ((dependencyItem.TargetElement is IDomainModelOwnable))
                        if ((dependencyItem.TargetElement as IDomainModelOwnable).DomainElementHasName)
                        {
                            DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(dependencyItem.TargetElement).ElementNameProvider.GetNamePropertyInfo(dependencyItem.TargetElement);
                            this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(info, dependencyItem.TargetElement.Id, OnTargetNamePropertyChanged);
                        }
                }

            base.OnDispose();
            this.dependencyItem = null;
        }

        /// <summary>
        /// Gets or sets the number of this item in the list.
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        /// <summary>
        /// Navigate to source model element
        /// </summary>
        public virtual void NavigateToSource()
        {
            if (this.DependencyItem == null)
                return;
            if (this.DependencyItem.SourceElement == null)
                return;
            if (this.DependencyItem.SourceElement.IsDeleted || this.DependencyItem.SourceElement.IsDeleting)
                return;

            SelectedItemsCollection col = new SelectedItemsCollection();
            col.Add(this.DependencyItem.SourceElement);

            // notify observers, that selection has changed
            this.EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
        }

        /// <summary>
        /// Navigate to target model element
        /// </summary>
        public virtual void NavigateToTarget()
        {
            if (this.DependencyItem == null)
                return;
            if (this.DependencyItem.TargetElement == null)
                return;
            if (this.DependencyItem.TargetElement.IsDeleted || this.DependencyItem.TargetElement.IsDeleting)
                return;

            SelectedItemsCollection col = new SelectedItemsCollection();
            col.Add(this.DependencyItem.TargetElement);

            // notify observers, that selection has changed
            this.EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
        }

    }
}

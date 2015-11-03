using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Dependencies
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
                if (LanguageDSLElementNameProvider.Instance.HasName(dependencyItem.SourceElement))
                {
                    DomainPropertyInfo info = LanguageDSLElementNameProvider.Instance.GetNamePropertyInfo(dependencyItem.SourceElement);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, dependencyItem.SourceElement.Id, OnSourceNamePropertyChanged);
                }
                if (LanguageDSLElementNameProvider.Instance.HasName(dependencyItem.TargetElement))
                {
                    DomainPropertyInfo info = LanguageDSLElementNameProvider.Instance.GetNamePropertyInfo(dependencyItem.TargetElement);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(info, dependencyItem.TargetElement.Id, OnTargetNamePropertyChanged);
                }
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
        public string Message
        {
            get
            {
                if (this.DependencyItem.Message != null)
                    return this.DependencyItem.Message;

                else if (this.DependencyItem.ElementLink != null)
                {

                    if (LanguageDSLElementNameProvider.Instance.HasName(this.DependencyItem.ElementLink))
                        return LanguageDSLElementNameProvider.Instance.GetName(this.DependencyItem.ElementLink) +
                            " (" + LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(this.DependencyItem.ElementLink) + ")";
                    else
                        return LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(this.DependencyItem.ElementLink);
                }
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets the source model element's name.
        /// </summary>
        public string SourceModelElementName
        {
            get
            {
                if (LanguageDSLElementNameProvider.Instance.HasName(this.DependencyItem.SourceElement))
                    return LanguageDSLElementNameProvider.Instance.GetName(this.DependencyItem.SourceElement) +
                        " (" + LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(this.DependencyItem.SourceElement) + ")";
                else
                    return LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(this.DependencyItem.SourceElement);
            }
        }

        /// <summary>
        /// Returns the full path of the parent element relative to the domain model element.
        /// </summary>
        public virtual string SourceModelElementNameFullPath
        {
            get
            {
                string fullPath = "";

                ModelElement temp = LanguageDSLElementParentProvider.Instance.GetEmbeddingParent(this.DependencyItem.SourceElement);
                while (temp != null)
                {
                    if (LanguageDSLElementNameProvider.Instance.HasName(temp))
                        fullPath = LanguageDSLElementNameProvider.Instance.GetName(temp) + "/" + fullPath;
                    else
                        fullPath = LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(temp) + "/" + fullPath;

                    temp = LanguageDSLElementParentProvider.Instance.GetEmbeddingParent(temp);
                }

                return SourceModelElementName + " (" + fullPath + SourceModelElementName + ")";
            }
        }

        /// <summary>
        /// Gets the source model element's name.
        /// </summary>
        public string TargetModelElementName
        {
            get
            {
                if (LanguageDSLElementNameProvider.Instance.HasName(this.DependencyItem.TargetElement))
                    return LanguageDSLElementNameProvider.Instance.GetName(this.DependencyItem.TargetElement) +
                        " (" + LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(this.DependencyItem.TargetElement) + ")";
                else
                    return LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(this.DependencyItem.TargetElement);
            }
        }

        /// <summary>
        /// Returns the full path of the parent element relative to the domain model element.
        /// </summary>
        public virtual string TargetModelElementNameFullPath
        {
            get
            {
                string fullPath = "";

                ModelElement temp = LanguageDSLElementParentProvider.Instance.GetEmbeddingParent(this.DependencyItem.TargetElement);
                while (temp != null)
                {
                    if (LanguageDSLElementNameProvider.Instance.HasName(temp))
                        fullPath = LanguageDSLElementNameProvider.Instance.GetName(temp) + "/" + fullPath;
                    else
                        fullPath = LanguageDSLElementTypeProvider.Instance.GetTypeDisplayName(temp) + "/" + fullPath;

                    temp = LanguageDSLElementParentProvider.Instance.GetEmbeddingParent(temp);
                }

                return TargetModelElementName + " (" + fullPath + TargetModelElementName + ")";
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.doSubscribeToEvents)
            {
                // unsubscribe
                if (LanguageDSLElementNameProvider.Instance.HasName(dependencyItem.SourceElement))
                {
                    DomainPropertyInfo info = LanguageDSLElementNameProvider.Instance.GetNamePropertyInfo(dependencyItem.SourceElement);
                    this.ViewModelStore.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(info, dependencyItem.SourceElement.Id, OnSourceNamePropertyChanged);
                }
                if (LanguageDSLElementNameProvider.Instance.HasName(dependencyItem.TargetElement))
                {
                    DomainPropertyInfo info = LanguageDSLElementNameProvider.Instance.GetNamePropertyInfo(dependencyItem.TargetElement);
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

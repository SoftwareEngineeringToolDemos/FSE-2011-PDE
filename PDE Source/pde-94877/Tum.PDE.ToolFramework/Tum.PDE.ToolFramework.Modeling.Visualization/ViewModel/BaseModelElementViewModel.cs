using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This is the base view model which represents a specific model element.
    /// </summary>
    public class BaseModelElementViewModel : BaseViewModel
    {
        private ModelElement element;
        private bool bHookUpEvents;
        private bool isInMoveMode= false;

        /// <summary>
        /// Constructor. The view model constructed this way does not react on model changes, as such DoHookUpEvents is false.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        public BaseModelElementViewModel(ViewModelStore viewModelStore, ModelElement element)
            : this(viewModelStore, element, false)
        {
        }

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseModelElementViewModel(ViewModelStore viewModelStore, ModelElement element, bool bHookUpEvents)
            : this(viewModelStore, element, bHookUpEvents, true)
        {
            
        }

        /// <summary>
        /// Constructor. This view model constructed with 'bHookUpEvents=true' does react on model changes.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element represented by this view model.</param>
        /// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
        /// <param name="bCallIntialize">True if Initiliaze method should be called.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseModelElementViewModel(ViewModelStore viewModelStore, ModelElement element, bool bHookUpEvents, bool bCallIntialize)
            : base(viewModelStore, false)
        {
            this.element = element;
            this.bHookUpEvents = bHookUpEvents;

            if (DoHookUpEvents && element != null)
            {
                if (this.DomainElementHasName)
                {
                    DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(element).ElementNameProvider.GetNamePropertyInfo(element);
                    if (info != null)
                        this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(
                            info, this.Element.Id, new System.Action<ElementPropertyChangedEventArgs>(NamePropertyChanged));
                }

                this.EventManager.GetEvent<ModelElementCustomEvent<bool>>().Subscribe(
                    ModelElementCustomEventNames.ModelElementMoveModeStatus, this.Element.Id, OnPasteStatusChanged);
            }

            if( bCallIntialize )
                this.Initialize();
        }

        /// <summary>
        /// Called whenever paste status changes.
        /// </summary>
        /// <param name="bStatus">True if the node is beeing moved. False otherwise</param>
        protected virtual void OnPasteStatusChanged(bool bStatus)
        {
            IsInMoveMode = bStatus;
        }

        /// <summary>
        /// Gets or sets the whether the element hosted by this view model is in paste mode or not.
        /// </summary>
        public bool IsInMoveMode
        {
            get { return isInMoveMode; }
            set 
            {
                isInMoveMode = value;
                OnPropertyChanged("IsInMoveMode");
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
        /// Gets or sets the value of the property (which is marked as element name)
        /// </summary>
        public string DomainElementName
        {
            get
            {
                if (element != null && element is IDomainModelOwnable)
                    return (element as IDomainModelOwnable).DomainElementName;
                else
                    return "";
            }
            set
            {
                using (Transaction t = this.Store.TransactionManager.BeginTransaction("Change name"))
                {
                    if (element != null && element is IDomainModelOwnable)
                        (element as IDomainModelOwnable).DomainElementName = value;

                    t.Commit();
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
        public bool DomainElementHasName 
        {
            get
            {
                if (element != null && element is IDomainModelOwnable)
                    return (element as IDomainModelOwnable).DomainElementHasName;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the type of the ModelElement as string.
        /// </summary>
        public string DomainElementType
        {
            get
            {
                if (element != null && element is IDomainModelOwnable)
                    return (element as IDomainModelOwnable).DomainElementType;
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets the display name of the type of the ModelElement.
        /// </summary>
        public string DomainElementTypeDisplayName
        {
            get
            {
                if (element != null && element is IDomainModelOwnable)
                    return (element as IDomainModelOwnable).DomainElementTypeDisplayName;
                else
                    return "";
            }
        }

        /// <summary>
        /// True if parent element has a name.
        /// </summary>
        public virtual bool DomainElementParentHasName
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementParentHasName;
                else
                    return false;
            }
        }

        /// <summary>
        /// Returns the parent name (or its type name, if there is no name property).
        /// If the element doesnt have a parent, null is returned.
        /// </summary>
        public virtual string DomainElementParentName
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementParentName;
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns the parent name + (type name) (or its type name, if there is no name property).
        /// If the element doesnt have a parent, null is returned.
        /// </summary>
        public virtual string DomainElementParentFullName
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementParentFullName;
                else
                    return null;
            }
        }

        /// <summary>
        /// True if there is a first parent element, which has a DomainElementName name.
        /// </summary>
        public virtual bool DomainElementParentHasFirstExistingName
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementParentHasFirstExistingName;
                else
                    return false;
            }
        }
        
        /// <summary>
        /// Returns the DomainElementName of the first parent to actually have a name.
        /// </summary>
        public virtual string DomainElementParentFirstExistingName
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementParentFirstExistingName;
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns true if this elements parent has an embedding full path.
        /// </summary>
        public virtual bool DomainElementHasParentFullPath
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementHasParentFullPath;
                else
                    return false;
            }
        }

        /// <summary>
        /// Returns the full path of the parent element relative to the domain model element.
        /// </summary>
        public virtual string DomainElementParentFullPath
        {
            get
            {
                if (element != null && element is IEmbeddableModelElement)
                    return (element as IEmbeddableModelElement).DomainElementParentFullPath;
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets whether to hook up into model events.
        /// </summary>
        protected bool DoHookUpEvents
        {
            get { return bHookUpEvents; }
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
            if (DoHookUpEvents && element != null)
            {
                if (this.DomainElementHasName)
                {
                    DomainPropertyInfo info = this.ViewModelStore.GetDomainModelServices(this.Element).ElementNameProvider.GetNamePropertyInfo(element);
                    if (info != null)
                        this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(
                            info, this.Element.Id, new System.Action<ElementPropertyChangedEventArgs>(NamePropertyChanged));
                }

                this.EventManager.GetEvent<ModelElementCustomEvent<bool>>().Unsubscribe(
                    ModelElementCustomEventNames.ModelElementMoveModeStatus, this.Element.Id, OnPasteStatusChanged);
            }

            base.OnDispose();

            this.element = null;
        }
    }
}

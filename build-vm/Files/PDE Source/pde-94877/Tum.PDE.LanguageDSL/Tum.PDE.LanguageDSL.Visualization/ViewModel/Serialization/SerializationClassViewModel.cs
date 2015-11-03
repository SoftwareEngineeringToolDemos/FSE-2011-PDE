using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization
{
    /// <summary>
    /// This view model hosts a serialization class.
    /// </summary>
    public abstract class SerializationClassViewModel : SerializationElementViewModel
    {
        private ObservableCollection<SerializationElementViewModel> childrenVMs;
        private ReadOnlyObservableCollection<SerializationElementViewModel> childrenVMsRO;

        private ObservableCollection<SerializationAttributeElementViewModel> attributesVMs;
        private ReadOnlyObservableCollection<SerializationAttributeElementViewModel> attributesVMsRO;

        private SerializationClassViewModel parent;
        private bool isExpanded = false;

        private bool loadedChildren = false;
        //private bool loadedAttributes = false;

        static readonly SerializationElementViewModel DummyChild = new SerializationElementViewModel();
        static readonly SerializationAttributeElementViewModel DummyAttribute = new SerializationAttributeElementViewModel();

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="serializationClass">SerializationClass.</param>
        /// <param name="referencedElement">Element that is referenced by the serialization element. Can be null.</param>
        protected SerializationClassViewModel(ViewModelStore viewModelStore, SerializationClass serializationClass, ModelElement referencedElement, SerializationClassViewModel parent)
            : base(viewModelStore, serializationClass, referencedElement)
        {
            this.childrenVMs = new ObservableCollection<SerializationElementViewModel>();
            this.childrenVMsRO = new ReadOnlyObservableCollection<SerializationElementViewModel>(this.childrenVMs);

            this.attributesVMs = new ObservableCollection<SerializationAttributeElementViewModel>();
            this.attributesVMsRO = new ReadOnlyObservableCollection<SerializationAttributeElementViewModel>(attributesVMs);

            this.parent = parent;

            if (this.SerializationElement != null)
            {
                // Lazy load the child items, if necessary.
                if (this.HasLoadedChildren)
                {
                    this.LoadChildren();
                }
                else if (this.SerializationElement.Children.Count > 0)
                    this.childrenVMs.Add(DummyChild);

                this.LoadAttributes();

                /*
                // Lazy load the attribute items, if necessary.
                if (!this.HasLoadedAttributes)
                {
                    this.LoadAttributes();
                }
                else if (this.SerializationElement.Attributes.Count > 0)
                    this.attributesVMs.Add(DummyAttribute);
                */
               
                // subscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializationClassPropertyChanged));
                                
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesChildren.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementAddedEventArgs>(OnChildAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesChildren.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementDeletedEventArgs>(OnChildRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesChildren.DomainClassId),
                    this.SerializationElement.Id, new Action<RolePlayerOrderChangedEventArgs>(OnChildMoved));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesAttributes.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementAddedEventArgs>(OnAttributeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesAttributes.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementDeletedEventArgs>(OnAttributeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesAttributes.DomainClassId),
                    this.SerializationElement.Id, new Action<RolePlayerOrderChangedEventArgs>(OnAttributeMoved));
            }
        }

        /// <summary>
        /// Gets the parent element.
        /// </summary>
        public SerializationClassViewModel Parent
        {
            get
            {
                return this.parent;
            }
        }

        /// <summary>
        /// Gets the serialization class.
        /// </summary>
        public new SerializationClass SerializationElement
        {
            get
            {
                return base.SerializationElement as SerializationClass;
            }
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
        /// Gets a read-only collection of children.
        /// </summary>
        public ReadOnlyObservableCollection<SerializationElementViewModel> Children
        {
            get
            {
                return this.childrenVMsRO;
            }
        }

        /// <summary>
        /// Gets a read-only collection of attributes.
        /// </summary>
        public ReadOnlyObservableCollection<SerializationAttributeElementViewModel> Attributes
        {
            get
            {
                return this.attributesVMsRO;
            }
        }

        /// <summary>
        /// Gets/sets whether the TreeViewItem associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Lazy load the child items, if necessary.
                if (!this.HasLoadedChildren)
                {
                    if( HasDummyChild )
                        this.childrenVMs.Remove(DummyChild);

                    this.LoadChildren();
                }

                /*
                // Lazy load the attribute items, if necessary.
                if (!this.HasLoadedAttributes)
                {
                    if( HasDummyAttribute )
                        this.attributesVMs.Remove(DummyAttribute);

                    this.LoadAttributes();
                }
                */
            }
        }

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public virtual bool HasLoadedChildren
        {
            get { return loadedChildren; }
        }

        /*
        /// <summary>
        /// Returns true if this object's Attributes have not yet been populated.
        /// </summary>
        public virtual bool HasLoadedAttributes
        {
            get { return this.loadedAttributes; }
        }
        */

        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public bool HasDummyChild
        {
            get { return this.Children.Count == 1 && this.Children[0] == DummyChild; }
        }

        /*
        /// <summary>
        /// Returns true if this object's Attributes have not yet been populated.
        /// </summary>
        public bool HasDummyAttribute
        {
            get { return this.Attributes.Count == 1 && this.Attributes[0] == DummyAttribute; }
        }
        */

        /// <summary>
        /// Gets whether this view model has children.
        /// </summary>
        public bool HasChildren
        {
            get
            {
                if (this.Children.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Gets whether this view model has attributes.
        /// </summary>
        public bool HasAttributes
        {
            get
            {
                if (this.Attributes.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Moves children nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveChildren(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move children nodes"))
            {
                this.SerializationElement.Children.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Moves attribute nodes.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public void MoveAttributes(int from, int to)
        {
            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Move attribute nodes"))
            {
                this.SerializationElement.Attributes.Move(from, to);

                transaction.Commit();
            }
        }

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// </summary>
        protected virtual void LoadChildren()
        {
            this.loadedChildren = true; 
            
            foreach (SerializationElement element in this.SerializationElement.Children)
                if (element != null)
                    AddChild(element);
        }

        /// <summary>
        /// Invoked when the attribute items need to be loaded on demand.
        /// </summary>
        protected virtual void LoadAttributes()
        {
            //this.loadedAttributes = true;

            foreach (SerializationAttributeElement element in this.SerializationElement.Attributes)
                if (element != null)
                    AddAttribute(element);
        }

        #region Model Methods
        /// <summary>
        /// Called whenever properties change.
        /// </summary>
        /// <param name="args"></param>
        private void OnSerializationClassPropertyChanged(ElementPropertyChangedEventArgs args)
        {
            if (args.DomainProperty.Id == SerializationClass.SerializationNameDomainPropertyId)
                OnPropertyChanged("SerializationName");
        }

        /// <summary>
        /// Adds a an element vm to the children collection
        /// </summary>
        /// <param name="elementVM">Element vm.</param>
        public void AddChild(SerializationElementViewModel elementVM)
        {
            if (!HasLoadedChildren)
            {
                if (!HasDummyChild)
                    this.childrenVMs.Add(DummyChild);
                
                return;
            }

            // verify that node hasnt been added yet
            foreach (SerializationElementViewModel viewModel in this.childrenVMs)
                if (viewModel.SerializationElement.Id == elementVM.SerializationElement.Id)
                    return;

            this.childrenVMs.Add(elementVM);

            OnPropertyChanged("HasChildren");
        }

        /// <summary>
        /// Adds a new element view model for the given element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void AddChild(SerializationElement element)
        {
            if (!HasLoadedChildren)
            {
                if (!HasDummyChild)
                    this.childrenVMs.Add(DummyChild);

                return;
            }

            // verify that node hasnt been added yet
            foreach (SerializationElementViewModel viewModel in this.childrenVMs)
                if (viewModel.SerializationElement.Id == element.Id)
                    return;

            if (element is SerializedDomainClass)
            {
                SerializedDomainClassViewModel vm = new SerializedDomainClassViewModel(this.ViewModelStore, element as SerializedDomainClass, this);
                this.childrenVMs.Add(vm);
            }
            else if (element is SerializedEmbeddingRelationship)
            {
                SerializedEmbeddingRelationshipViewModel vm = new SerializedEmbeddingRelationshipViewModel(this.ViewModelStore, element as SerializedEmbeddingRelationship, this);
                this.childrenVMs.Add(vm);
            }
            else if (element is SerializedReferenceRelationship)
            {
                SerializedReferenceRelationshipViewModel vm = new SerializedReferenceRelationshipViewModel(this.ViewModelStore, element as SerializedReferenceRelationship, this);
                this.childrenVMs.Add(vm);
            }
            else if (element is SerializedDomainProperty)
            {
                SerializedDomainPropertyViewModel vm = new SerializedDomainPropertyViewModel(this.ViewModelStore, element as SerializedDomainProperty, this);
                this.childrenVMs.Add(vm);
            }

            OnPropertyChanged("HasChildren");
        }

        /// <summary>
        /// Deletes the element view model that is hosting the given element.
        /// </summary>
        /// <param name="node">Element.</param>
        public void DeleteChild(SerializationElement element)
        {
            if (!this.HasLoadedChildren)
                return;

            for (int i = this.childrenVMs.Count - 1; i >= 0; i--)
                if (this.childrenVMs[i].SerializationElement.Id == element.Id)
                {
                    this.childrenVMs[i].Dispose();
                    this.childrenVMs.RemoveAt(i);
                }

            OnPropertyChanged("HasChildren");
        }

        /// <summary>
        /// Called whenever a relationship of type SerializationClassReferencesChildren is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnChildAdded(ElementAddedEventArgs args)
        {
            SerializationClassReferencesChildren con = args.ModelElement as SerializationClassReferencesChildren;
            if (con != null)
            {
                AddChild(con.Child);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type SerializationClassReferencesChildren is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnChildRemoved(ElementDeletedEventArgs args)
        {
            SerializationClassReferencesChildren con = args.ModelElement as SerializationClassReferencesChildren;
            if (con != null)
            {
                DeleteChild(con.Child);
            }
        }
        
        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnChildMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.SerializationElement)
            {
                if (!this.HasLoadedChildren)
                    return;

                this.childrenVMs.Move(args.OldOrdinal, args.NewOrdinal);
            }
        }

        /// <summary>
        /// Adds a new element view model for the given element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void AddAttribute(SerializationElement element)
        {
            if (element == null)
                return;

            /*
            if (!HasLoadedAttributes)
            {
                if (!HasDummyAttribute)
                    this.attributesVMs.Add(DummyAttribute);

                return;
            }*/

            // verify that node hasnt been added yet
            foreach (SerializationAttributeElementViewModel viewModel in this.attributesVMs)
                if (viewModel.SerializationElement.Id == element.Id)
                    return;

            if (element is SerializedIdProperty)
            {
                SerializedIdPropertyViewModel vm = new SerializedIdPropertyViewModel(this.ViewModelStore, element as SerializedIdProperty, this);
                this.attributesVMs.Add(vm);
            }
            else if( element is SerializedDomainProperty )
            {
                SerializedDomainPropertyViewModel vm = new SerializedDomainPropertyViewModel(this.ViewModelStore, element as SerializedDomainProperty, this);
                this.attributesVMs.Add(vm);
            }

            OnPropertyChanged("HasAttributes");
        }

        /// <summary>
        /// Deletes the element view model that is hosting the given element.
        /// </summary>
        /// <param name="node">Element.</param>
        public void DeleteAttribute(SerializationAttributeElement element)
        {
            if (element == null)
                return;

            for (int i = this.attributesVMs.Count - 1; i >= 0; i--)
                if (this.attributesVMs[i].SerializationElement.Id == element.Id)
                {
                    this.attributesVMs[i].Dispose();
                    this.attributesVMs.RemoveAt(i);
                }

            OnPropertyChanged("HasAttributes");
        }

        /// <summary>
        /// Called whenever a relationship of type SerializationClassReferencesAttributes is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnAttributeAdded(ElementAddedEventArgs args)
        {
            SerializationClassReferencesAttributes con = args.ModelElement as SerializationClassReferencesAttributes;
            if (con != null)
            {
                AddAttribute(con.Child);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type SerializationClassReferencesAttributes is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnAttributeRemoved(ElementDeletedEventArgs args)
        {
            SerializationClassReferencesAttributes con = args.ModelElement as SerializationClassReferencesAttributes;
            if (con != null)
            {
                DeleteAttribute(con.Child);
            }
        }
        
        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args"></param>
        private void OnAttributeMoved(RolePlayerOrderChangedEventArgs args)
        {
            if (args.SourceElement == this.SerializationElement)
                this.attributesVMs.Move(args.OldOrdinal, args.NewOrdinal);
        }
        #endregion

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.SerializationElement != null)
            {
                // unsubscribe
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(this.SerializationElement.Id, new Action<ElementPropertyChangedEventArgs>(OnSerializationClassPropertyChanged));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesChildren.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementAddedEventArgs>(OnChildAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesChildren.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementDeletedEventArgs>(OnChildRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesChildren.DomainClassId),
                    this.SerializationElement.Id, new Action<RolePlayerOrderChangedEventArgs>(OnChildMoved));

                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesAttributes.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementAddedEventArgs>(OnAttributeAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesAttributes.DomainClassId),
                    true, this.SerializationElement.Id, new Action<ElementDeletedEventArgs>(OnAttributeRemoved));

                this.EventManager.GetEvent<ModelRolePlayerMovedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(SerializationClassReferencesAttributes.DomainClassId),
                    this.SerializationElement.Id, new Action<RolePlayerOrderChangedEventArgs>(OnAttributeMoved));
            }

            this.childrenVMs.Clear();
            this.attributesVMs.Clear();

            base.OnDispose();
        }
    }
}

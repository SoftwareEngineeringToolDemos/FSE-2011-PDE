using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// This abstract base class contains a reference to the model as well as the view model factory class, which
    /// provides factory methods to create view models for model elements from the model.
    /// 
    /// Further it provides the mediater class, which implements the Mediator pattern for messaging.
    /// 
    /// We also hook into the event-processing of the dsl tools store class to provide a mapping of events to our view model.
    /// So far we only support ElementAdded, ElementDeleted, ElementPropertyChanged, RolePlayerChangedEventArgs
    /// </summary>
    public abstract class ViewModelStore
    {
        private ModelData modelData;
        private ViewModelEventManager viewModelEventManager;
        private Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions options = null;
        private bool isInLoad = false;
        private List<ViewModelStore> externStores;
        private ViewModelStore ownedByStore;

        private bool hasEventsHookedUp = false;
        private Dictionary<Guid, object> customDataBag;
        
        //System.Threading.ManualResetEvent storeInitializedEvent = new System.Threading.ManualResetEvent(false);
        //System.Threading.ManualResetEvent externStoresInitializedEvent = new System.Threading.ManualResetEvent(false);
        private bool areExternStoresInitialized = false;
        private object vmStoreLock = new object();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        protected ViewModelStore(ModelData modelData) : this(modelData, true)
        {
        }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        /// <param name="options">Options.</param>
        protected ViewModelStore(ModelData modelData, Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions options)
            : this(modelData, true)
        {
            this.options = options;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        /// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
        protected ViewModelStore(ModelData modelData, bool bHookUpEvents) : 
            this(modelData, bHookUpEvents, null)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        /// <param name="bHookUpEvents">True if events listeners should be initialized.</param>
        /// <param name="ownedByStore">Store owning this store.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected ViewModelStore(ModelData modelData, bool bHookUpEvents, ViewModelStore ownedByStore)
        {
            this.customDataBag = new Dictionary<Guid, object>();

            this.viewModelEventManager = new ViewModelEventManager();
            this.externStores = new List<ViewModelStore>();
            this.ownedByStore = ownedByStore;
            this.modelData = modelData;

            if (bHookUpEvents && this == this.TopMostStore)
            {

                this.modelData.StoreCreated += new EventHandler(StoreCreated);
                this.modelData.StoreDisposing += new EventHandler(StoreDisposing);
                if (modelData.IsStoreInitialized)
                {   
                HookUpEvents();
            }
            }

            this.SpecificViewModelStore = new SpecificViewModelStore();
        }

        /// <summary>
        /// Gets an extern view model store by type.
        /// </summary>
        /// <param name="type">Type of the vstore to get.</param>
        /// <returns>ViewModelStore of the specified type if found. Null otherwise.</returns>
        public ViewModelStore GetExternViewModelStore(Type type)
        {
            lock (this.vmStoreLock)
            {
                if (!areExternStoresInitialized)
                {
                    this.RegisterExternStoresHelper();
                    areExternStoresInitialized = true;
                }
            }

            foreach (ViewModelStore s in this.ExternStores)
                if( s.GetType() == type )
                    return s;

            return null;
        }

        private void RegisterExternStoresHelper()
        {
            try
            {
                this.RegisterExternStores();
            }
            catch (Exception ex)
            {
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Error during model extern store registration: " + ex.Message);

                // rethrow exception
                throw new Exception("Error during model extern store registration", ex);
            }
            finally
            {
                areExternStoresInitialized = true;
            }
        }

        /// <summary>
        /// Register extern stores.
        /// </summary>
        protected abstract void RegisterExternStores();

        /// <summary>
        /// Gets the specific view model store.
        /// </summary>
        public SpecificViewModelStore SpecificViewModelStore
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the extern stores collection.
        /// </summary>
        public List<ViewModelStore> ExternStores
        {
            get
            {
                return this.externStores;
            }
        }

        /// <summary>
        /// Gets the custom data bag.
        /// </summary>
        public Dictionary<Guid, object> CustomDataBag
        {
            get
            {
                return this.customDataBag;
            }
        }

        /// <summary>
        /// Service resolver for view models.  Allows derived types to add/remove
        /// services from mapping.
        /// </summary>
        public static readonly ServiceProvider ServiceProvider = new ServiceProvider();

        /// <summary>
        /// Gets the global service provider.
        /// </summary>
        public ServiceProvider GlobalServiceProvider
        {
            get 
            {
                if (this.TopMostStore != this)
                    return this.TopMostStore.GlobalServiceProvider;

                return ViewModelStore.ServiceProvider; 
            }
        }

        /// <summary>
        /// Gets or sets wether document data is currently loading or not.
        /// </summary>
        public bool InLoad
        {
            get
            {
                if (this.isInLoad || this.ModelData.CurrentModelContext.InLoad || this.ModelData.CurrentModelContext.InReload)
                    return true;

                return false;
            }
            set
            {
                this.isInLoad = value;
            }
        }

        /// <summary>
        /// Gets the store owning this store. Can be null indicating the top-most store.
        /// </summary>
        public ViewModelStore OwnedByStore
        {
            get
            {
                return this.ownedByStore;
            }
        }

        /// <summary>
        /// Gets the top most store.
        /// </summary>
        public ViewModelStore TopMostStore
        {
            get
            {
                if (this.ownedByStore == null)
                    return this;
                else
                    return this.ownedByStore.TopMostStore;
            }
        }

        void StoreDisposing(object sender, EventArgs e)
        {
            UnhookEvents();
        }
        void StoreCreated(object sender, EventArgs e)
        {
            GC.Collect();

            HookUpEvents();
            this.modelData.Store.StoreDisposing += new EventHandler(StoreDisposing);
        }

        /// <summary>
        /// This method provides a mapping between the event handlers in the dsl tools store and our view model.
        /// </summary>
        private void HookUpEvents()
        {
            if (hasEventsHookedUp)
                return;

            hasEventsHookedUp = true;
            
            this.Store.EventManagerDirectory.ElementAdded.Add(new EventHandler<ElementAddedEventArgs>(OnElementAdded));
            this.Store.EventManagerDirectory.ElementDeleted.Add(new EventHandler<ElementDeletedEventArgs>(OnElementDeleted));
            this.Store.EventManagerDirectory.ElementPropertyChanged.Add(new EventHandler<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
            this.Store.EventManagerDirectory.RolePlayerChanged.Add(new EventHandler<RolePlayerChangedEventArgs>(OnRolePlayerChanged));
            this.Store.EventManagerDirectory.RolePlayerOrderChanged.Add(new EventHandler<RolePlayerOrderChangedEventArgs>(OnRolePlayerMoved));
        }

        /// <summary>
        /// This method unhooks event listeners.
        /// </summary>
        private void UnhookEvents()
        {
            if (!hasEventsHookedUp)
                return;

            hasEventsHookedUp = false;

            this.Store.EventManagerDirectory.ElementAdded.Remove(new EventHandler<ElementAddedEventArgs>(OnElementAdded));
            this.Store.EventManagerDirectory.ElementDeleted.Remove(new EventHandler<ElementDeletedEventArgs>(OnElementDeleted));
            this.Store.EventManagerDirectory.ElementPropertyChanged.Remove(new EventHandler<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
            this.Store.EventManagerDirectory.RolePlayerChanged.Remove(new EventHandler<RolePlayerChangedEventArgs>(OnRolePlayerChanged));
            this.Store.EventManagerDirectory.RolePlayerOrderChanged.Remove(new EventHandler<RolePlayerOrderChangedEventArgs>(OnRolePlayerMoved));
        }

        /// <summary>
        /// Called whenever a model element is added to the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the creation of new model element.</param>
        private void OnElementAdded(object sender, ElementAddedEventArgs args)
        {
            if (!ModelData.DoSendModelEvents)
                return;

            EventManager.GetEvent<ModelElementAddedEvent>().Publish(args);

            if( args.ModelElement is ElementLink )
                EventManager.GetEvent<ModelElementLinkAddedEvent>().Publish(args);
        }

        /// <summary>
        /// Called whenever a model element is deleted from the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the removal of an ModelElement.</param>
        private void OnElementDeleted(object sender, ElementDeletedEventArgs args)
        {
            if (!ModelData.DoSendModelEvents)
                return;

            EventManager.GetEvent<ModelElementDeletedEvent>().Publish(args);

            if( args.ModelElement is ElementLink )
                EventManager.GetEvent<ModelElementLinkDeletedEvent>().Publish(args);
        }

        /// <summary>
        /// Called whenever a model element's property value is changed.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notifications that the value of an attribute has changed</param>
        private void OnElementPropertyChanged(object sender, ElementPropertyChangedEventArgs args)
        {
            if (!ModelData.DoSendModelEvents)
                return;

            EventManager.GetEvent<ModelElementPropertyChangedEvent>().Publish(args);
        }

        /// <summary>
        /// Called whenever a model element's property value is changed.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notifications that the value of an attribute has changed</param>
        private void OnRolePlayerChanged(object sender, RolePlayerChangedEventArgs args)
        {
            if (!ModelData.DoSendModelEvents)
                return;

            EventManager.GetEvent<ModelRolePlayerChangedEvent>().Publish(args);
        }

        /// <summary>
        /// Called whenever a model element is moved.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the movement of a model element.</param>
        private void OnRolePlayerMoved(object sender, RolePlayerOrderChangedEventArgs args)
        {
            if (!ModelData.DoSendModelEvents)
                return;

            EventManager.GetEvent<ModelRolePlayerMovedEvent>().Publish(args);
        }

        /// <summary>
        /// Called to load options when the application starts.
        /// </summary>
        public abstract void LoadOptions(IMessageBoxService messageBox);

        /// <summary>
        /// Called to save options when the application exits.
        /// </summary>
        public abstract void SaveOptions(IMessageBoxService messageBox);

        /// <summary>
        /// Gets the document data containing the domain model data.
        /// </summary>
        public ModelData ModelData
        {
            get
            {
                return this.modelData;
            }
        }

        /// <summary>
        /// Gets the store containing the domain model.
        /// </summary>
        public DomainModelStore Store
        {
            get { return ModelData.Store; }
        }

        /// <summary>
        /// Gets the view model factory which provides methods for the creation of view models for model elements from the model.
        /// </summary>
        public abstract ViewModelFactory Factory { get; }

        /// <summary>
        /// ViewModelEventManager = Messaging pattern
        /// </summary>
        public ViewModelEventManager EventManager
        {
            get
            {
                if (this.TopMostStore != this)
                    return this.TopMostStore.EventManager;
                
                return this.viewModelEventManager; 
            }
        }

        /// <summary>
        /// Gets the services, which are specific to the current domain model that the given element belongs to.
        /// </summary>
        /// <returns>DomainModel services</returns>
        public IDomainModelServices GetDomainModelServices()
        {
            return this.ModelData.GetDomainModelServices();
        }

        /// <summary>
        /// Gets the services, which are specific to the current domain model that the given element belongs to.
        /// </summary>
        /// <param name="m">Element.</param>
        /// <returns>DomainModel services</returns>
        public IDomainModelServices GetDomainModelServices(IDomainModelOwnable m)
        {
            if (m == null)
                return GetDomainModelServices();

            return m.GetDomainModelServices();
            //return this.ModelData.GetDomainModelServices(m);
        }

        /// <summary>
        /// Gets the services, which are specific to the current domain model that the given element belongs to.
        /// </summary>
        /// <param name="m">Element.</param>
        /// <returns>DomainModel services</returns>
        public IDomainModelServices GetDomainModelServices(ModelElement m)
        {
            return GetDomainModelServices(m as IDomainModelOwnable);
        }

        /// <summary>
        /// Gets the view model options.
        /// </summary>
        public Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModelOptions Options
        {
            get { return options; }
            protected set { options = value; }
        }       
    }
}


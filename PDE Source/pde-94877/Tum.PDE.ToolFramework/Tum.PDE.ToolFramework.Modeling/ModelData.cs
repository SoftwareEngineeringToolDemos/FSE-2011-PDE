using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Abstract base class representing a file in memory.
    /// </summary>
    public abstract class ModelData : INotifyPropertyChanged, IDisposable, Tum.PDE.ToolFramework.Modeling.Base.Contracts.IDocData
    {
        private DomainModelStore store = null;

        /// <summary>
        /// Current model context storage.
        /// </summary>
        protected ModelContext currentModelContext = null;

        /// <summary>
        /// Available model contexts storage.
        /// </summary>
        protected List<ModelContext> availableModelContexts;

        bool isStoreCreated = false;
        bool areContextsInitialized = false;

        private object storeLock = new object();
        private object contextLock = new object();
        private object eventSubscLock = new object();

        bool hasSubscribedToEvents = false;

        /// <summary>
        /// Gets or sets whether model events should be sent or not.
        /// </summary>
        public static bool DoSendModelEvents = true;

        #region Abstract Methods
        /// <summary>
        /// Returns a collection of domain models to load into the store.
        /// </summary>
        protected abstract Type[] GetDomainModels();

        /// <summary>
        /// Returns a collection of domain models to load into the store.
        /// </summary>
        internal Type[] GetDomainModelsInternal()
        {
            return this.GetDomainModels();
        }

        /// <summary>
        /// Gets the services, which belong to the current domain model.
        /// </summary>
        /// <returns>DomainModel services.</returns>
        public abstract IDomainModelServices GetDomainModelServices();

        /// <summary>
        /// Gets the services, which are specific to the current domain model that the given element belongs to.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <returns>DomainModel services</returns>
        public abstract IDomainModelServices GetDomainModelServices(IDomainModelOwnable element);
        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected ModelData()
            : this(false, false)
        {
        }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bInitAsynchronous">Initialize asynchronously.</param>
        /// <param name="bInitDelayed">Delay initialization.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected ModelData(bool bInitAsynchronous, bool bInitDelayed)
        {
            this.availableModelContexts = new List<ModelContext>();

            if (!bInitDelayed)
                Initialize(bInitAsynchronous);
            else
            {
                // init model contexts in background
                this.InitializeModelContextsHelper();
            }
        }

        void createStore_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateStore((bool)e.Argument);
        }
        void createStore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // rethrow exception
            if (e.Result is Exception)
                throw new Exception("Error during store creation", e.Result as Exception);
            if (e.Error != null)
                throw new Exception("Error during store creation", e.Error);

            if( !IsStoreInitialized )
                throw new Exception("Error during store creation: Initialization did not finish");

            lock (this.eventSubscLock)
            {
                if (!hasSubscribedToEvents)
                {
                    //Store.MainTheadManagedThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                    //Store.EventManagerDirectory.TransactionBeginning.Add(new EventHandler<Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs>(TransactionBeginning));
                    Store.EventManagerDirectory.TransactionCommitted.Add(new EventHandler<Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs>(TransactionCommitted));
                    Store.EventManagerDirectory.ElementAdded.Add(new EventHandler<Microsoft.VisualStudio.Modeling.ElementAddedEventArgs>(OnElementAdded));
                    Store.EventManagerDirectory.ElementDeleted.Add(new EventHandler<Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs>(OnElementDeleted));
                }
                hasSubscribedToEvents = true;
            }
            OnStoreCreated(new EventArgs());
        }

        void initMC_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (this.contextLock)
            {
                if (!this.areContextsInitialized)
                {
                    InitializeModelContextsHelper();
                }
            }
        }
        void initServices_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeServicesHelper();
        }

        /// <summary>
        /// Gets whether the store has been initialized.
        /// </summary>
        public bool IsStoreInitialized
        {
            get
            {
                return this.isStoreCreated;
            }
        }

        /// <summary>
        /// Gets whether the model contexts have been initialized.
        /// </summary>
        public bool AreModelContextInitialized
        {
            get
            {
                return this.areContextsInitialized;
            }
        }
        
        /// <summary>
        /// Async initialization.
        /// </summary>
        public void InitAsync()
        {
            Initialize(true);
        }

        private void Initialize(bool bInitAsynchronous)
        {
            if (bInitAsynchronous)
            {
                BackgroundWorker initServices = new BackgroundWorker();
                initServices.DoWork += new DoWorkEventHandler(initServices_DoWork);
                initServices.RunWorkerAsync();
            }
            else
                InitializeServicesHelper();
            InitializeHelper(bInitAsynchronous, true);
        }
        private void InitializeHelper(bool bInitAsynchronous, bool bInitModelContext)
        {
            if (bInitAsynchronous && bInitModelContext)
            {
                // init model contexts in background
                BackgroundWorker initMC = new BackgroundWorker();
                initMC.DoWork += new DoWorkEventHandler(initMC_DoWork);
                initMC.RunWorkerAsync();
            }
            CreateStoreHelper(bInitAsynchronous);

            // create store in background
            if (bInitAsynchronous)
            {
                // init serialization in background
                //BackgroundWorker initSer = new BackgroundWorker();
                //initSer.DoWork += new DoWorkEventHandler(initSer_DoWork);
                //initSer.RunWorkerAsync();
            }
            else
            {
                if( bInitModelContext )
                    InitializeModelContextsHelper();
                //InitializeSerializationHelper();
            }
        }

        private void CreateStoreHelper(bool bInitAsynchronous)
        {
            if (!bInitAsynchronous)
                this.CreateStore(bInitAsynchronous);
            else
            {
                BackgroundWorker createStore = new BackgroundWorker();
                createStore.DoWork += new DoWorkEventHandler(createStore_DoWork);
                createStore.RunWorkerCompleted += new RunWorkerCompletedEventHandler(createStore_RunWorkerCompleted);
                createStore.RunWorkerAsync(bInitAsynchronous);
            }

            // subscribe to change events to set isDirty flag.
            if (!bInitAsynchronous)
            {
                lock (this.eventSubscLock)
                {
                    if (!hasSubscribedToEvents)
                    {
                        //Store.MainTheadManagedThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                        //Store.EventManagerDirectory.TransactionBeginning.Add(new EventHandler<Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs>(TransactionBeginning));
                        Store.EventManagerDirectory.TransactionCommitted.Add(new EventHandler<Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs>(TransactionCommitted));
                        Store.EventManagerDirectory.ElementAdded.Add(new EventHandler<Microsoft.VisualStudio.Modeling.ElementAddedEventArgs>(OnElementAdded));
                        Store.EventManagerDirectory.ElementDeleted.Add(new EventHandler<Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs>(OnElementDeleted));
                    }
                    hasSubscribedToEvents = true;
                }

                OnStoreCreated(new EventArgs());
            }

        }
        private void InitializeModelContextsHelper()
        {
            try
            {
                this.InitializeModelContexts();
            }
            catch (Exception ex)
            {
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Error during model context init: " + ex.Message);

                // rethrow exception
                throw new Exception("Error during model context init", ex);
            }
            finally
            {
                this.areContextsInitialized = true;
            }
        }
        private void InitializeSerializationHelper(DomainModelStore store)
        {
            try
            {
                this.InitializeSerializationForStore(store);
            }
            catch (Exception ex)
            {
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Error serialization intialization: " + ex.Message);

                // rethrow exception
                throw new Exception("Error serialization intialization", ex);
            }
            finally
            {
            }
        }
        private void InitializeServicesHelper()
        {
            InitializeServices();
        }

        /// <summary>
        /// Initializes services.
        /// </summary>
        protected abstract void InitializeServices();

        /// <summary>
        /// Initializes the model contexts collection.
        /// </summary>
        protected abstract void InitializeModelContexts();

        /// <summary>
        /// Serialization initialization.
        /// </summary>
        /// <param name="store">Store.</param>
        protected abstract void InitializeSerializationForStore(DomainModelStore store);

        /// <summary>
        /// Get the Partition where model data will be loaded into. Base implementation returns the default partition of the store.
        /// </summary>
        public abstract Microsoft.VisualStudio.Modeling.Partition GetModelPartition();

        /// <summary>
        /// Gets or sets the currently selected model context.
        /// </summary>
        public ModelContext CurrentModelContext
        {
            get
            {
                lock (this.contextLock)
                {
                    if (!this.areContextsInitialized)
                    {
                        this.InitializeModelContextsHelper();
                    }
                }

                return this.currentModelContext;
            }
            set
            {
                OnBeforeModelContextChanged(new EventArgs());

                if (this.currentModelContext != null)
                    Reset();

                this.currentModelContext = value;
                OnPropertyChanged("CurrentModelContext");

                OnAfterModelContextChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Gets the list of available model contexts.
        /// </summary>
        public List<ModelContext> AvailableModelContexts
        {
            get
            {
                lock (this.contextLock)
                {
                    if (!this.areContextsInitialized)
                    {
                        this.InitializeModelContextsHelper();
                    }
                }

                return this.availableModelContexts;
            }
        }

        /// <summary>
        ///  Creates a new store
        /// </summary>
        private void CreateStore(bool bInitAsynchronous)
        {
            lock (this.storeLock)
            {
                if (!this.isStoreCreated)
                {
                    store = new DomainModelStore(bInitAsynchronous, GetDomainModels());
                    InitializeSerializationHelper(this.store);
                }

                // loading done
                this.isStoreCreated = true;
            }
        }

        private void TransactionBeginning(object source, Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs e)
        {
            /*
            if (e.Transaction.IsSerializing)
                return;

            if (!e.Transaction.IsNested)
            {
                this.Store.SetWritingLockAvailabilityAndWait(false);
            }
            else
                return;

            if( this.Store.GetWritingLockState() )
                if( ModelData.IsInDebugState )
                    LogHelper.LogEvent("Waiting on lockstate release");

            this.Store.WaitForWritingLockRelease();
            */
        }
        private void TransactionCommitted(object source, Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs e)
        {
            if (currentModelContext != null)
                currentModelContext.TransactionCommited(e);
            
            if (e.Transaction != null)
                if (e.Transaction.IsSerializing)
                    return;

            /*
            if (!e.Transaction.IsNested)
            {
                this.Store.SetWritingLockAvailabilityAndWait(true);
            }*/

            OnPropertyChanged("CanUndo");
            OnPropertyChanged("CanRedo");
        }
        private void OnElementAdded(object source, Microsoft.VisualStudio.Modeling.ElementAddedEventArgs e)
        {
            Microsoft.VisualStudio.Modeling.ModelElement m = e.ModelElement;

            // add key
            if( m is IDomainModelOwnable )
                this.GetDomainModelServices(m as IDomainModelOwnable).ElementIdProvider.AddKey(m);
        }
        private void OnElementDeleted(object source, Microsoft.VisualStudio.Modeling.ElementDeletedEventArgs e)
        {
            Microsoft.VisualStudio.Modeling.ModelElement m = e.ModelElement;
            
            // remove key
            if (m is IDomainModelOwnable)
                this.GetDomainModelServices(m as IDomainModelOwnable).ElementIdProvider.RemoveKey(m);
        }

        /// <summary>
        /// Clears undo and redo stacks.
        /// </summary>
        public void FlushUndoRedoStacks()
        {
            this.UndoManager.Flush();
        }

        /// <summary>
        /// Gets the Modeling Store associated with this DocData.
        /// </summary>
        public DomainModelStore Store
        { 
            get 
            {
                lock (this.storeLock)
                {
                    if (!this.isStoreCreated)
                    {
                        this.CreateStoreHelper(false);
                    }
                }

                return store; 
            }
        }

        /// <summary>
        /// Gets the DomainModel's ResourceManager.
        /// </summary>
        public abstract global::System.Resources.ResourceManager ResourceManager { get; }

        /// <summary>
        /// Gets the undo manager that is attached to the current store.
        /// </summary>
        public Microsoft.VisualStudio.Modeling.UndoManager UndoManager
        {
            get
            {
                if (this.Store == null)
                    return null;
                if (this.Store.Disposed)
                    return null;
                return this.Store.UndoManager;
            }
        }

        /// <summary>
        /// Resets the current document data.
        /// </summary>
        public virtual void Reset()
        {
            if (CurrentModelContext != null)
                CurrentModelContext.Reset();

            // clear undo manager stack
            if( this.UndoManager != null )
                this.UndoManager.Flush();
            
            this.OnStoreDisposing(new EventArgs());

            lock (this.eventSubscLock)
            {
                this.hasSubscribedToEvents = false;
            }

            this.Dispose();
            store = null;

            this.InitializeHelper(false, false);
            this.RaiseUndoRedoChangeEvents();
        }

        /// <summary>
        /// True if undo stack is not empty. False otherwise.
        /// </summary>
        public bool CanUndo
        {
            get {
                if( !this.IsStoreInitialized )
                    return false;
                return this.UndoManager.UndoCount >= 1; }
        }

        /// <summary>
        /// True if redo stack is not empty. False otherwise.
        /// </summary>
        public bool CanRedo
        {
            get {
                if (!this.IsStoreInitialized)
                    return false;

                return this.UndoManager.RedoCount >= 1; }
        }

        /// <summary>
        /// Undo the actions of the topmost transaction on undo stack.
        /// </summary>
        public void Undo()
        {
            this.UndoManager.Undo();
            OnPropertyChanged("CanUndo");
            OnPropertyChanged("CanRedo");
        }

        /// <summary>
        ///  the actions of the topmost transaction on the redo stack.
        /// </summary>
        public void Redo()
        {
            this.UndoManager.Redo();
            OnPropertyChanged("CanUndo");
            OnPropertyChanged("CanRedo");
        }

        /// <summary>
        /// Raises the undo redo change events.
        /// </summary>
        public void RaiseUndoRedoChangeEvents()
        {
            OnPropertyChanged("CanUndo");
            OnPropertyChanged("CanRedo");
        }

        /// <summary>
        /// Fires after a new store has been created.
        /// </summary>
        public event EventHandler StoreCreated;

        /// <summary>
        /// Fires before the store is getting disposed.
        /// </summary>
        public event EventHandler StoreDisposing;

        /// <summary>
        /// Fires before a model context change occurs.
        /// </summary>
        public event EventHandler BeforeModelContextChanged;

        /// <summary>
        /// Fires before a model context change occurs.
        /// </summary>
        public event EventHandler AfterModelContextChanged;

        /// <summary>
        /// Called before a model context is changed.
        /// </summary>
        /// <param name="e"></param>
        protected void OnBeforeModelContextChanged(EventArgs e)
        {
            if (BeforeModelContextChanged != null)
                BeforeModelContextChanged(this, e);
        }

        /// <summary>
        /// Called after a model context is changed.
        /// </summary>
        /// <param name="e"></param>
        protected void OnAfterModelContextChanged(EventArgs e)
        {
            if (AfterModelContextChanged != null)
                AfterModelContextChanged(this, e);
        }

        /// <summary>
        /// Called before the store is getting disposed.
        /// </summary>
        /// <param name="e"></param>
        protected void OnStoreDisposing(EventArgs e)
        {
            if (StoreDisposing != null)
                StoreDisposing(this, e);
        }

        /// <summary>
        /// Called after a new store has been created.
        /// </summary>
        /// <param name="e"></param>
        protected void OnStoreCreated(EventArgs e)
        {
            if (StoreCreated != null)
                StoreCreated(this, e);
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called whenever a specific property's value changed.
        /// </summary>
        /// <param name="name">Name of the property changed.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region IDispose
        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //modelDatainstance = null;
                lock (this.storeLock)
                {
                    this.isStoreCreated = false;
                    if (this.store != null)
                        this.store.Dispose();
                }


            }
        }
        #endregion
    }
}
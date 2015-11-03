using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.ComponentModel;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class wraps extension functionality for the DSL Tools Store class.
    /// </summary>
    public class DomainModelStore : Store
    {
        private List<Type> domainModelsLoaded;
        private List<Type> domainModelsNotRequired;

        private DomainDataAdvDirectory domainDataAdvDirectory;
        private Dictionary<Guid, object> customDataBag;

        /*
        private Object lockObject = new object();
        private int locksCounter = 0;
        private Dictionary<Guid, int> locksCounterById = new Dictionary<Guid, int>();

        private System.Threading.ManualResetEvent locksResetEvent = new System.Threading.ManualResetEvent(false);
        private System.Threading.ManualResetEvent locksAvailableResetEvent = new System.Threading.ManualResetEvent(false);
        */

        ///// <summary>
        ///// Id of the main thead. 
        ///// </summary>
        ///// <remarks>
        ///// If this is set to the value of the main thead, checks are performed while locking the store.
        ///// </remarks>
        //public int MainTheadManagedThreadId = -1;

        private object domainModelStoreLock = new object();
        private bool isDomainModelStoreInitialized = false;

        private Type[] domainModelTypes = null;

        /*
        /// <summary>
        /// Data processed event.
        /// </summary>
        public System.Threading.ManualResetEvent DataProcessedEvent = new System.Threading.ManualResetEvent(false);

        /// <summary>
        /// Serialization initialized event.
        /// </summary>
        public System.Threading.ManualResetEvent SerializationInitialized = new System.Threading.ManualResetEvent(false);
        */
        
        /// <summary>
        /// Creates an instance of the DomainModelStore class.
        /// </summary>
        /// <param name="domainModelTypes">List of domain models to be loaded.</param>
        public DomainModelStore(params Type[] domainModelTypes) :
            this(false, domainModelTypes)
        {
        }

        /// <summary>
        /// Creates an instance of the DomainModelStore class.
        /// </summary>
        /// <param name="bInitAsynchronous">Initialize asynchronously.</param>
        /// <param name="domainModelTypes">List of domain models to be loaded.</param>
        public DomainModelStore(bool bInitAsynchronous, params Type[] domainModelTypes)
            : this(bInitAsynchronous, false, domainModelTypes)
        {
        }

        /// <summary>
        /// Creates an instance of the DomainModelStore class.
        /// </summary>
        /// <param name="bInitAsynchronous">Initialize asynchronously.</param>
        /// <param name="bInitDelayed">Delay initialization.</param>
        /// <param name="domainModelTypes">List of domain models to be loaded.</param>
        public DomainModelStore(bool bInitAsynchronous, bool bInitDelayed, params Type[] domainModelTypes)
            : base(domainModelTypes)
        {
            this.domainModelTypes = domainModelTypes;

            // initially both true
            //this.locksResetEvent.Set();             
            //this.locksAvailableResetEvent.Set();

            this.customDataBag = new Dictionary<Guid, object>();
            this.domainDataAdvDirectory = new DomainDataAdvDirectory(this);

            this.domainModelsLoaded = new List<Type>();
            this.domainModelsNotRequired = new List<Type>();

            //MainTheadManagedThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            if (!bInitDelayed)
            {
                if (bInitAsynchronous)
                {
                    // process info in background
                    BackgroundWorker initStore = new BackgroundWorker();
                    initStore.DoWork += new DoWorkEventHandler(initStore_DoWork);
                    initStore.RunWorkerAsync(domainModelTypes);
                }
                else
                {
                    InitializeHelper(domainModelTypes);
                }
            }
        }

        void initStore_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (this.domainModelStoreLock)
            {
                if( !this.isDomainModelStoreInitialized)
                    InitializeHelper(e.Argument as Type[]);
            }
        }

        private void InitializeHelper(object domainModelTypes)
        {
            try
            {
                Type[] t = domainModelTypes as Type[];
                Initialize(t);
            }
            catch (Exception ex)
            {
                Tum.PDE.ToolFramework.Modeling.Base.LogHelper.LogError("Error during domain model store intialization: " + ex.Message);

                // rethrow exception
                throw new Exception("Error during domain model store intialization", ex);
            }
            finally
            {
                this.isDomainModelStoreInitialized = true;
            }
        }
        private void Initialize(Type[] domainModelTypes)
        {
            if (domainModelTypes != null)
            {
                foreach (Type type in domainModelTypes)
                    LoadDomainModel(type);
                
                foreach (Type type in domainModelTypes)
                    EnsureRequiredModelsLoaded(type);                
            }

            this.domainDataAdvDirectory.ProcessInfos();
        }

        /// <summary>
        /// Async initialization.
        /// </summary>
        public void InitAsync()
        {
            lock (this.domainModelStoreLock)
            {
                if (!this.isDomainModelStoreInitialized)
                {
                    BackgroundWorker initStore = new BackgroundWorker();
                    initStore.DoWork += new DoWorkEventHandler(initStore_DoWork);
                    initStore.RunWorkerAsync(domainModelTypes);
                }
            }
        }

        /// <summary>
        /// True if all store initialization routines have finished.
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                return this.isDomainModelStoreInitialized;
            }
        }

        #region WritingLock
        /*
        /// <summary>
        /// Gets whether the store is currently locked for writing or not.
        /// </summary>
        /// <returns>True if the store is locked for writing. False otherwise.</returns>
        public bool GetWritingLockState()
        {
            if (locksResetEvent.WaitOne(0))
                return false;

            return true;
        }

        /// <summary>
        /// Gets whether the store contains a writing lock of the specified id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>True if the store contains a writing lock of the specified id. False otherwise.</returns>
        public bool? GetWritingLockState(Guid id)
        {
            bool bRet = false;

            lock (this.lockObject)
            {
                if (this.locksCounterById.ContainsKey(id))
                    if (this.locksCounterById[id] > 0)
                        bRet = true;
            }
            return bRet;
        }

        /// <summary>
        /// Sets the lockstate to either enabled (true) or disabled (false) for a specific id. Waits if locks are not available and bIsEnabled = true.
        /// </summary>
        /// <param name="bIsEnabled"></param>
        /// <param name="id"></param>
        /// <remarks>
        /// If this is called from the main application thread, there is a possibility of dead locks if the WaitForWritingLockRelease method
        /// are also called from the main thread! (which is the case, if the store is modified!). Therefore, whenever this is called from 
        /// the main thread, InvalidOperationException is thrown!
        /// </remarks>
        public void SetWritingLockState(bool bIsEnabled, Guid id)
        {
            if (bIsEnabled)
                if (ModelData.IsInDebugState)
                    if (!locksAvailableResetEvent.WaitOne(0))
                        LogHelper.LogEvent("waiting for availability locks release");

            if (bIsEnabled)
            {
                if (ModelData.IsInDebugState)
                    if (!locksAvailableResetEvent.WaitOne(0))
                        LogHelper.LogEvent("waiting for availability locks release");

                locksAvailableResetEvent.WaitOne();
            }

            if (System.Threading.Thread.CurrentThread.ManagedThreadId == MainTheadManagedThreadId)
            {
                throw new InvalidOperationException("Can not be set from the main thread! Chances of deadlocks too high");
            }

            if (ModelData.IsInDebugState)
                LogHelper.LogEvent("set writing lock state for " + id.ToString() + " to " + bIsEnabled.ToString());

            lock (this.lockObject)
            {
                if (bIsEnabled)
                {
                    if (this.locksCounterById.ContainsKey(id))
                        this.locksCounterById[id] += 1;
                    else
                        this.locksCounterById.Add(id, 1);
                    this.locksCounter += 1;
                }
                else
                {
                    if (this.locksCounterById.ContainsKey(id))
                    {
                        this.locksCounterById[id] -= 1;
                        if (this.locksCounterById[id] < 0)
                            this.locksCounterById[id] = 0;

                        this.locksCounter -= 1;
                        if (this.locksCounter < 0)
                            this.locksCounter = 0;
                    }                    
                }

                if (this.locksCounter == 0)
                {
                    if (!this.locksResetEvent.WaitOne(0))
                        this.locksResetEvent.Set();
                }
                else
                {
                    if( this.locksResetEvent.WaitOne(0) )
                        this.locksResetEvent.Reset();
                }
            }
        }

        /// <summary>
        /// Sets the lockstate to either enabled (true) or disabled (false). Waits if locks are not available and bIsEnabled = true.
        /// </summary>
        /// <param name="bIsEnabled"></param>
        /// <remarks>
        /// If this is called from the main application thread, there is a possibility of dead locks if the WaitForWritingLockRelease method
        /// are also called from the main thread! (which is the case, if the store is modified!). Therefore, whenever this is called from 
        /// the main thread, InvalidOperationException is thrown!
        /// </remarks>
        public void SetWritingLockState(bool bIsEnabled)
        {
            if (System.Threading.Thread.CurrentThread.ManagedThreadId == MainTheadManagedThreadId)
            {
                throw new InvalidOperationException("Can not be set from the main thread! Chances of deadlocks too high");
            }

            if (bIsEnabled)
            {
                if (ModelData.IsInDebugState)
                    if (!locksAvailableResetEvent.WaitOne(0))
                        LogHelper.LogEvent("waiting for availability locks release");

                locksAvailableResetEvent.WaitOne();
            }

            if (ModelData.IsInDebugState)
                LogHelper.LogEvent("set writing lock state to " + bIsEnabled.ToString());

            lock (this.lockObject)
            {
                if (bIsEnabled)
                {
                    this.locksCounter += 1;
                }
                else
                {
                    this.locksCounter -= 1;
                    if (this.locksCounter < 0)
                        this.locksCounter = 0;
                }

                if (this.locksCounter == 0)
                {
                    if (!this.locksResetEvent.WaitOne(0))
                        this.locksResetEvent.Set();
                }
                else
                {
                    if( this.locksResetEvent.WaitOne(0) )
                        this.locksResetEvent.Reset();
                }
            }

        }

        /// <summary>
        /// Waits till all writing locks are released. 
        /// </summary>
        /// <remarks>
        /// If this is called from the main application thread, there is a possibility of dead locks if the SetWritingLockState methods
        /// are also called from the main thread!
        /// </remarks>
        public void WaitForWritingLockRelease()
        {
            if (ModelData.IsInDebugState)
                if (!locksResetEvent.WaitOne(0))
                    LogHelper.LogEvent("waiting for locks release");

            locksResetEvent.WaitOne();
        }

        /// <summary>
        /// Sets the availability of writing locks and waits for writing lock release if required (bIsAvailable=false).
        /// </summary>
        /// <param name="bIsAvailable">True if locks are available. False otherwise.</param>
        public void SetWritingLockAvailabilityAndWait(bool bIsAvailable)
        {
            if (!bIsAvailable)
            {
                if (locksAvailableResetEvent.WaitOne(0))
                    locksAvailableResetEvent.Reset();
            }
            else
                if (!locksAvailableResetEvent.WaitOne(0))
                    locksAvailableResetEvent.Set();
            
            if( !bIsAvailable )
                this.WaitForWritingLockRelease();

        }
        */
        #endregion

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
        /// Gets the advanced domain data directory.
        /// </summary>
        public DomainDataAdvDirectory DomainDataAdvDirectory
        {
            get
            {
                lock (this.domainModelStoreLock)
                {
                    if( !this.isDomainModelStoreInitialized )
                        this.Initialize(domainModelTypes);
                }

                return domainDataAdvDirectory;
            }
        }

        private bool IsModelLoaded(Type type)
        {
            if (domainModelsLoaded.Contains(type) || domainModelsNotRequired.Contains(type))
                return true;

            return false;
        }
        private void LoadDomainModel(Type type)
        {
            if (IsModelLoaded(type))
                return;

            DomainModel domainModel;
            DomainObjectIdAttribute attr = GetAttribute<DomainObjectIdAttribute>(type, false);
            if (attr == null)
                return;

            domainModel = this.FindDomainModel(attr.Id) as DomainModel;
            if (!(domainModel is DomainModelBase))
            {
                domainModelsNotRequired.Add(type);
                return;
            }

            if (domainModel == null)
            {
                object[] objArr = new object[] { this };
                domainModel = (DomainModelBase)System.Activator.CreateInstance(type, objArr);
            }

            this.domainDataAdvDirectory.ProcessClassInfos((domainModel as DomainModelBase).GetDomainClassAdvancedInfo());
            this.domainDataAdvDirectory.ProcessRelationshipInfos((domainModel as DomainModelBase).GetDomainRelationshipAdvancedInfo());
            this.domainDataAdvDirectory.ProcessEmbeddingRelationshipOrderInfo((domainModel as DomainModelBase).GetEmbeddingRelationshipOrderInfo());
            this.domainDataAdvDirectory.ProcessModelContextInfos((domainModel as DomainModelBase).GetModelContextInfo());
            this.domainDataAdvDirectory.ProcessDataExtensions((domainModel as DomainModelBase).GetDataExtensions());
            this.domainModelsLoaded.Add(type);
        }
        private void EnsureRequiredModelsLoaded(Type type)
        {
            List<Type> typesParsed = new List<Type>();
            DependsOnDomainModelAttribute[] dependsOnDomainModelAttributeArr = GetAttributes<DependsOnDomainModelAttribute>(type);
            if( dependsOnDomainModelAttributeArr != null )
                foreach (DependsOnDomainModelAttribute attr in dependsOnDomainModelAttributeArr)
                {
                    Type typeExt = attr.ExtendedDomainModelType;
                    if (typeExt == null)
                        throw new InvalidOperationException("Extended DomainModelType can not be null.");
                    if( typesParsed.Contains(typeExt) )
                        throw new InvalidOperationException("Duplicate base DomainModel.");

                    typesParsed.Add(typeExt);
                }

            if (type != typeof(CoreDomainModel) && !typesParsed.Contains(typeof(CoreDomainModel)))
                typesParsed.Add(typeof(CoreDomainModel));

            foreach (Type t in typesParsed)
                LoadDomainModel(t);
        }

        private static T[] GetAttributes<T>(System.Reflection.MemberInfo memberInfo)
            where T : System.Attribute
        {
            return (T[])memberInfo.GetCustomAttributes(typeof(T), false);
        }
        private static T GetAttribute<T>(System.Reflection.MemberInfo memberInfo, bool includeInherited)
            where T : System.Attribute
        {
            object[] objArr = memberInfo.GetCustomAttributes(typeof(T), includeInherited);
            if (objArr.Length == 1)
                return (T)objArr[0];
            
            return null;
        }
    }
}

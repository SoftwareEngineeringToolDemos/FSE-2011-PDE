using System;
using System.ComponentModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This abstract class represents the view model that used as a base class for each concreate view model.
    /// </summary>
    /// <remarks>
    /// ServiceProvider.. from the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public abstract class BaseViewModel : IBaseViewModel, INotifyPropertyChanged, IDisposable
    {
        private Guid id = Guid.NewGuid();
        private ViewModelStore viewModelStore;
        private bool isDisposed = false;
        private bool isDisposing = false;

        private static bool HasSetupServices = false;

        /// <summary>
        /// Setup services.
        /// </summary>
        public static void SetupServices()
        {
            if (HasSetupServices)
                return;

            HasSetupServices = true;

            // Register default services
            // TODO: Extension as in cinch (via Microsoft Unity IOC container) for testing, not needed now
            ViewModelStore.ServiceProvider.Add(typeof(IUIVisualizerService), new UIVisualizerService());
            ViewModelStore.ServiceProvider.Add(typeof(IOpenFileService), new OpenFileService());
            ViewModelStore.ServiceProvider.Add(typeof(ISaveFileService), new SaveFileService());
            ViewModelStore.ServiceProvider.Add(typeof(IMessageBoxService), new MessageBoxService());            

        }

        /// <summary>
        /// Init.
        /// </summary>
        static BaseViewModel()
        {
            SetupServices();
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected BaseViewModel(ViewModelStore viewModelStore) : this(viewModelStore, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="bCallIntialize">True if the Initialize method should be called.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected BaseViewModel(ViewModelStore viewModelStore, bool bCallIntialize)
        {
            this.viewModelStore = viewModelStore;

            if( bCallIntialize )
                Initialize();
        }
        
        /// <summary>
        /// This method is used to initalize the view model and can be overriden for customization.
        /// </summary>
        protected virtual void Initialize()
        {

        }        
        
        /// <summary>
        /// Gets the view model store this view model belongs to.
        /// </summary>
        public ViewModelStore ViewModelStore
        {
            get { return this.viewModelStore; }
        }

        /// <summary>
        /// Gets the document data containing the domain model data.
        /// </summary>
        public ModelData ModelData
        {
            get
            {
                return ViewModelStore.ModelData;
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
        /// Event manager.
        /// </summary>
        public ViewModelEventManager EventManager
        {
            get { return this.ViewModelStore.EventManager; }
        }

        /// <summary>
        /// Gets the id of this view model.
        /// </summary>
        public Guid Id
        {
            get { return this.id; }
        }



        /// <summary>
        /// Gets the global service provider.
        /// </summary>
        public ServiceProvider GlobalServiceProvider
        {
            get { return this.ViewModelStore.GlobalServiceProvider; }
        }

        /// <summary>
        /// This resolves a service type and returns the implementation.
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Implementation</returns>
        protected T ResolveService<T>()
        {
            return ViewModelStore.ServiceProvider.Resolve<T>();
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current BaseViewModel.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is BaseViewModel)
                return (obj as BaseViewModel).Id == this.Id;
            else
                return base.Equals(obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called whenever a specific property changes.
        /// </summary>
        /// <param name="name">Name of the property, which value changed.</param>
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
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            if( !this.IsDisposed )
                Dispose(true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.isDisposing = true;
                this.OnDispose();
            
                this.viewModelStore = null;
                this.PropertyChanged = null;

                this.isDisposed = true;
                this.isDisposing = false;
            }
        }

        /// <summary>
        /// Child classes can override this method to perform  clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        /// <summary>
        /// Gets whether this view model was already disposed or not.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return this.isDisposed;
            }
        }

        /// <summary>
        /// Gets whether this view model is currently beeing disposed.
        /// </summary>
        public bool IsDisposing
        {
            get
            {
                return this.isDisposing;
            }
        }
        #endregion

        /// <summary>
        /// Gets or sets user specific data.
        /// </summary>
        public object UserData
        {
            get;
            set;
        }
    }
}

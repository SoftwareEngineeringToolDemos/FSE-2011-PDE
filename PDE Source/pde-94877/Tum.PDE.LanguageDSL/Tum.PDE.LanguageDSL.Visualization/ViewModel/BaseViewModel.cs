using System;
using System.ComponentModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Services;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
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
       
        /// <summary>
        /// Init.
        /// </summary>
        static BaseViewModel()
        {
            // Register default services
            // TODO: Extension as in cinch (via Microsoft Unity IOC container) for testing, not needed now
            ServiceProvider.Add(typeof(IUIVisualizerService), new UIVisualizerService());
            ServiceProvider.Add(typeof(IOpenFileService), new OpenFileService());
            ServiceProvider.Add(typeof(ISaveFileService), new SaveFileService());
            ServiceProvider.Add(typeof(IMessageBoxService), new MessageBoxService());            
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected BaseViewModel(ViewModelStore viewModelStore)
        {
            this.viewModelStore = viewModelStore;

            Inialize();
        }
        
        /// <summary>
        /// This method is used to inialize the view model and can be overriden for customization.
        /// </summary>
        protected virtual void Inialize()
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
        public virtual ModelData ModelData
        {
            get
            {
                return ViewModelStore.ModelData;
            }
        }

        /// <summary>
        /// Gets the store containing the domain model.
        /// </summary>
        public virtual Store Store
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
        /// Service resolver for view models.  Allows derived types to add/remove
        /// services from mapping.
        /// </summary>
        public static readonly ServiceProvider ServiceProvider = new ServiceProvider();

        /// <summary>
        /// Gets the global service provider.
        /// </summary>
        public ServiceProvider GlobalServiceProvider
        {
            get { return ServiceProvider; }
        }

        /// <summary>
        /// This resolves a service type and returns the implementation.
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Implementation</returns>
        protected T ResolveService<T>()
        {
            return ServiceProvider.Resolve<T>();
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseViewModel)
                return (obj as BaseViewModel).Id == this.Id;
            else
                return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region IDisposable Members
        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.OnDispose();
            this.viewModelStore = null;
            this.PropertyChanged = null;

            isDisposed = true;
        }

        /// <summary>
        /// Child classes can override this method to perform  clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        /// <summary>
        /// Gets wether this view model was already disposed or not.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return this.isDisposed;
            }
        }

        
        #endregion
    }
}

using System;

using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    /// <summary>
    /// This is the base view model for any view model that can be activated and that can host elements.
    /// </summary>
    public abstract class BaseHostingViewModel : BaseViewModel
    {
        protected bool isActiveView = false;
        protected bool isReseting = false;

        //private DelegateCommand activatedCommand;
        private DelegateCommand loadedCommand;
        private DelegateCommand unloadedCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="ribbonViewModel">Ribbon view model to be assigned to this view.</param>
        protected BaseHostingViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            // init commands
            //activatedCommand = new DelegateCommand(OnActivated);
            loadedCommand = new DelegateCommand(OnLoaded);
            unloadedCommand = new DelegateCommand(OnUnloaded);
        }

        /// <summary>
        /// Inialize
        /// </summary>
        protected override void Inialize()
        {
            base.Inialize();

            EventManager.GetEvent<ResetViewModelEvent>().Subscribe(new Action<ViewModelEventArgs>(Reset));
        }

         /// <summary>
        /// Reset ressources.
        /// </summary>
        protected virtual void OnReset()
        {
        }
                
        /// <summary>
        /// Reset ressources.
        /// </summary>
        private void Reset(ViewModelEventArgs eventArgs)
        {
            isReseting = true;

            OnReset();

            isReseting = false;
        }

        /// <summary>
        /// True if the view model is reseting; False otherwise.
        /// </summary>
        public bool IsReseting
        {
            get { return this.isReseting; }
        }       

        /// <summary>
        /// Command, which is called from the ui whenever the view is activated or deactivated.
        /// </summary>
        /*public DelegateCommand ActivatedCommand
        {
            get { return activatedCommand; }
        }*/

        /// <summary>
        /// Command, which is called from the ui when the view is loaded.
        /// </summary>
        public DelegateCommand LoadedCommand
        {
            get { return loadedCommand; }
        }

        /// <summary>
        /// Command, which is called from the ui when the view is unloaded.
        /// </summary>
        public DelegateCommand UnloadedCommand
        {
            get { return unloadedCommand; }
        }

        /// <summary>
        /// Gets or sets whether this view is the currently active view in the application.
        /// </summary>
        public virtual bool IsActiveView
        {
            get { return isActiveView; }
            set
            {
                this.isActiveView = value;

                // notify of change
                OnPropertyChanged("IsActiveView");
            }
        }


        /// <summary>
        /// Called whenever the view is activated
        /// </summary>
        protected virtual void OnActivated()
        {
            if (this.IsActiveView != true)
                this.IsActiveView = true;
        }

        /// <summary>
        /// Called when the view is loaded.
        /// </summary>
        protected virtual void OnLoaded()
        {

        }

        /// <summary>
        /// Called when the view is unloaded
        /// </summary>
        protected virtual void OnUnloaded()
        {

        }

        /// <summary>
        /// Clean-up.
        /// </summary>
        protected override void OnDispose()
        {
            EventManager.GetEvent<ResetViewModelEvent>().Unsubscribe(new Action<ViewModelEventArgs>(Reset));

            base.OnDispose();

            //activatedCommand = null;
            loadedCommand = null;
            unloadedCommand = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Tum.PDE.ToolFramework.Modeling.Shell;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Shell.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using System.Collections;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Shell
{
    /// <summary>
    /// Main shell package controller.
    /// </summary>
    public class ShellPackageController : INotifyPropertyChanged, IDisposable
    {
        private ShellDockingManager layoutManager;

        private ModelPackage modelPackage;

        private ShellMainViewModel currenShellVM = null;
        private Dictionary<ShellMainViewModel, string> availableShellVMs;
        private Dictionary<string, ShellMainViewModel> availableShellVMsReversed;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="package">Package.</param>
        protected ShellPackageController(ModelPackage package)
        {
            this.modelPackage = package;

            
            this.availableShellVMs = new Dictionary<ShellMainViewModel, string>();
            this.availableShellVMsReversed = new Dictionary<string, ShellMainViewModel>();

            this.Initialize();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        /// Gets or sets the current shell view models.
        /// </summary>
        public ShellMainViewModel CurrentShellViewModel
        {
            get
            {
                return this.currenShellVM;
            }
            set
            {
                if (this.currenShellVM != value)
                {
                    this.currenShellVM = value;
                    this.LayoutManager.SelectedShellViewModel = this.currenShellVM;

                    OnPropertyChanged("CurrentShellViewModel");
                }
            }
        }

        /// <summary>
        /// Available shell vms.
        /// </summary>
        public Dictionary<ShellMainViewModel, string> AvailableShellVMs
        {
            get
            {
                return this.availableShellVMs;
            }
        }

        /// <summary>
        /// Available shell vms.
        /// </summary>
        public Dictionary<string, ShellMainViewModel> AvailableShellVMsReversed
        {
            get
            {
                return this.availableShellVMsReversed;
            }
        }

        /// <summary>
        /// Adds a shell vm.
        /// </summary>
        /// <param name="shellViewModel">Shell vm.</param>
        /// <param name="name">Name of the vm. (Must be the full file name of the loaded model).</param>
        public void AddShellViewModel(ShellMainViewModel shellViewModel, string name)
        {
            shellViewModel.PackageController = this;
            this.availableShellVMs.Add(shellViewModel, name);
            this.availableShellVMsReversed.Add(name, shellViewModel);
        }

        /// <summary>
        /// Set current shell vm.
        /// </summary>
        /// <param name="shellViewModel">Shell vm.</param>
        public void SetCurrentShellViewModel(ShellMainViewModel shellViewModel)
        {
            this.CurrentShellViewModel = shellViewModel;
        }

        /// <summary>
        /// Set current shell vm.
        /// </summary>
        /// <param name="name">Name of the vm.</param>
        public void SetCurrentShellViewModel(string name)
        {
            if (!availableShellVMsReversed.ContainsKey(name))
                return;

            this.SetCurrentShellViewModel(availableShellVMsReversed[name]);
        }        

        /// <summary>
        /// Removes a shell vm.
        /// </summary>
        /// <param name="shellViewModel">Shell vm.</param>
        public void RemoveShellViewModel(ShellMainViewModel shellViewModel)
        {
            shellViewModel.PackageController = null;

            this.availableShellVMsReversed.Remove(this.availableShellVMs[shellViewModel]);
            this.availableShellVMs.Remove(shellViewModel);

            if (this.availableShellVMs.Count > 0)
            {
                // close windows...
                this.LayoutManager.CloseConfiguration(shellViewModel.FullFileName); 

                this.SetCurrentShellViewModel(this.availableShellVMs.Keys.ElementAt(0));
                this.LayoutManager.UpdateView();
            }
            else
            {
                this.LayoutManager.SaveConfiguration(shellViewModel.ModelData.CurrentModelContext.Name);
                this.LayoutManager.SaveConfigurations();

                this.LayoutManager.CloseConfiguration();               

                this.CurrentShellViewModel = null;
            }
        }

        /// <summary>
        /// Restore layout.
        /// </summary>
        /// <param name="fullFileName">File name</param>
        /// <param name="dockableViews">Vms.</param>
        /// <returns></returns>
        public void RestoreLayout(string fullFileName, IEnumerable dockableViews)
        {
            if (this.LayoutManager != null)
            {
                this.LayoutManager.RestoreConfiguration(this.CurrentShellViewModel.SelectedModelContextViewModel.ModelContext.Name, dockableViews, fullFileName);
                this.LayoutManager.UpdateView();
            }
        }

        /// <summary>
        /// Restore layout.
        /// </summary>
        /// <param name="fullFileName">File name</param>
        /// <param name="dockableViews">Vms.</param>
        /// <returns></returns>
        public void RestoreLayoutIfRequired(string fullFileName, IEnumerable dockableViews)
        {
            if (this.LayoutManager != null)
            {
                this.LayoutManager.RestoreConfiguration(this.CurrentShellViewModel.SelectedModelContextViewModel.ModelContext.Name, dockableViews, false, fullFileName);
                this.LayoutManager.UpdateView();
            }
        }

        #region Method: Events
        /// <summary>
        /// Reacts on the OpenViewModel event.
        /// </summary>
        /// <param name="args">Event data.</param>
        public virtual void OpenViewModel(OpenViewModelEventArgs args)
        {
            if (args.ViewModelToOpen == null)
                return;

            if (!this.CurrentShellViewModel.AllViewModels.Contains(args.ViewModelToOpen))
            {
                this.CurrentShellViewModel.UnknownOpenedModels.Add(args.ViewModelToOpen);
            }

            this.LayoutManager.ShowWindow(args.ViewModelToOpen, args.DockingPaneStyle, args.DockingPaneAnchorStyle);
            this.LayoutManager.BringToFrontWindow(args.ViewModelToOpen);
            args.ViewModelToOpen.IsDockingPaneVisible = true;
        }

        /// <summary>
        /// Reacts on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        public virtual void ShowViewModel(ShowViewModelRequestEventArgs args)
        {

            if (args.ViewName != null)
            {
                IDockableViewModel vm = this.LayoutManager.ShowWindow(args.ViewName, args.DockingPaneStyle, args.DockingPaneAnchorStyle);
                if (vm != null)
                {
                    this.LayoutManager.BringToFrontWindow(vm);
                    vm.IsDockingPaneVisible = true;
                }
            }
            else if (args.SourceViewModel is IDockableViewModel)
            {
                this.LayoutManager.ShowWindow(args.SourceViewModel as IDockableViewModel, args.DockingPaneStyle, args.DockingPaneAnchorStyle);
                this.LayoutManager.BringToFrontWindow(args.SourceViewModel as IDockableViewModel);
                (args.SourceViewModel as IDockableViewModel).IsDockingPaneVisible = true;
            }
        }

        /// <summary>
        /// React on CloseViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        public virtual void CloseViewModel(CloseViewModelRequestEventArgs args)
        {
            if (args.SourceViewModel is IDockableViewModel)
            {
                if (!args.ShouldRemoveVM)
                {
                    this.LayoutManager.CloseWindow(args.SourceViewModel as IDockableViewModel);
                    (args.SourceViewModel as IDockableViewModel).IsDockingPaneVisible = false;
                }
                else
                    this.LayoutManager.CloseWindow(args.SourceViewModel as IDockableViewModel, true);
            }
        }

        /// <summary>
        /// React on ShowViewModelRequestEvent.
        /// </summary>
        /// <param name="args">Event data.</param>
        public virtual void BringtToFrontViewModel(BringToFrontViewModelRequestEventArgs args)
        {
            if (args.SourceViewModel is IDockableViewModel)
            {
                this.LayoutManager.BringToFrontWindow(args.SourceViewModel as IDockableViewModel);
            }
        }
        #endregion

        /// <summary>
        /// Model package.
        /// </summary>
        public ModelPackage ModelPackage
        {
            get
            {
                return this.modelPackage;
            }
        }

        /// <summary>
        /// Gets or sets the layout docking manager.
        /// </summary>
        public ShellDockingManager LayoutManager
        {
            get { return layoutManager; }
            set
            {
                if (this.layoutManager != null)
                {
                    this.layoutManager.ActivePaneChanged -= new ShellDockingManager.ActivePaneChangedEventHandler(LayoutManager_ActivePaneChanged);
                    this.layoutManager.RestoreLayoutMissingVMEncountered -= new ShellDockingManager.RestoreLayoutMissingVMEncounteredEventHandler(LayoutManager_RestoreLayoutMissingVMEncountered);
                }

                this.layoutManager = value;

                if (this.layoutManager != null)
                {
                    this.layoutManager.ActivePaneChanged += new ShellDockingManager.ActivePaneChangedEventHandler(LayoutManager_ActivePaneChanged);
                    this.layoutManager.RestoreLayoutMissingVMEncountered += new ShellDockingManager.RestoreLayoutMissingVMEncounteredEventHandler(LayoutManager_RestoreLayoutMissingVMEncountered);
                }

                this.OnPropertyChanged("LayoutManager");
            }
        }

        void LayoutManager_RestoreLayoutMissingVMEncountered(object sender, MissingViewModelEventArgs e)
        {
            /*
            DockingPaneConfiguration paneConfig = e.DockingPaneConfiguration;
            if (paneConfig.IsRestorable && paneConfig.RestoreInformation != null && paneConfig.DockingPaneType != null)
            {
                // create new modal window
                BaseDiagramSurfaceViewModel vm = this.ViewModelStore.TopMostStore.Factory.CreateRestorableViewModel(paneConfig.DockingPaneType);
                if (vm != null && vm is IRestorableDockableViewModel)
                {
                    if ((vm as IRestorableDockableViewModel).Restore(paneConfig.RestoreInformation))
                    {
                        OpenViewModelEventArgs args = new OpenViewModelEventArgs(vm);
                        args.DockingPaneStyle = PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
                        this.EventManager.GetEvent<OpenViewModelEvent>().Publish(args);
                    }
                    else
                    {
                        vm.Dispose();
                    }
                }
            }*/
        }
        void LayoutManager_ActivePaneChanged(object sender, ActivePaneChangedEventArgs e)
        {
            if (e.DockableViewModel is BaseDockingViewModel)
                (e.DockableViewModel as BaseDockingViewModel).IsActiveView = e.IsActive;
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
            Dispose(true);
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.LayoutManager != null)
                    this.LayoutManager.CloseConfiguration();

                if (this.LayoutManager != null)
                    this.LayoutManager.Dispose();
                this.LayoutManager = null;
            }
        }

        /// <summary>
        /// Child classes can override this method to perform  clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }
        #endregion
    }
}

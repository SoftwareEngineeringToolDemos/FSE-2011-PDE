using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

using Tum.PDE.ToolFramework.Modeling.Shell;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Search;


namespace Tum.PDE.ToolFramework.Modeling.Visualization.Shell.ViewModel
{
    /// <summary>
    /// Docking manager for the shell.
    /// </summary>
    public abstract class ShellDockingManager : INotifyPropertyChanged
    {
        private ModelPackage package;

        private Dictionary<string, Dictionary<string, ViewLookUp>> viewLookup;
        private const string TransientPanesKey = "889DE4362EEE4F72878E1826A764F8F1";

        private Dictionary<string, List<string>> viewTypeNameLookup;
        private Dictionary<Guid, string> paneViewLookup;

        //private Dictionary<string, ViewLookUp> viewLookup;        
        //private ObservableCollection<IDockableViewModel> visibleCollection;
        //private ObservableCollection<IDockableViewModel> hiddenCollection;

        //private IDockableViewModel selectedDocumentPane;
        private IDockableViewModel activePane;
        
        private DelegateCommand closeSelectedDocumentPaneCommand;
        private DelegateCommand documentPaneControlActivated;

        private DockingLayoutManagerConfiguration configuration;
        private ShellPackageController packageController;

        private string selectedShellVMName = null;
        private ShellMainViewModel selectedShellVM = null;
        private bool bForceLoadLayout = false;

        private class ViewLookUp
        {
            /// <summary>
            /// Gets or sets the vm.
            /// </summary>
            public IDockableViewModel View
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the pane.
            /// </summary>
            public ModelToolWindowPane Pane
            {
                get;
                set;
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="v"></param>
            public ViewLookUp(IDockableViewModel v)
            {
                this.View = v;
                this.Pane = null;
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="v"></param>
            /// <param name="p"></param>
            public ViewLookUp(IDockableViewModel v, ModelToolWindowPane p)
            {
                this.View = v;
                this.Pane = p;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="package">Visual Studio Package.</param>
        /// <param name="packageController">Package controller.</param>
        protected ShellDockingManager(ModelPackage package, ShellPackageController packageController)
        {
            this.packageController = packageController;
            this.viewLookup = new Dictionary<string, Dictionary<string, ViewLookUp>>();
            this.viewTypeNameLookup = new Dictionary<string, List<string>>();
            this.paneViewLookup = new Dictionary<Guid, string>();

            this.package = package;

            //this.visibleCollection = new ObservableCollection<IDockableViewModel>();
            //this.hiddenCollection = new ObservableCollection<IDockableViewModel>();

            this.package.ActiveWindowChangedEvent += new ModelPackage.ActiveWindowChangedEventHandler(Package_ActiveWindowChangedEvent);
            this.closeSelectedDocumentPaneCommand = new DelegateCommand(CloseSDPCommand_Execute, CloseSDPCommand_CanExecute);
            this.documentPaneControlActivated = new DelegateCommand(DocumentPaneControlActivated_Execute);
        }

        #region Window methods
        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore it position. Otherwise dock it to the right side.
        /// </summary>
        public void ShowWindow(IDockableViewModel view)
        {
            ShowWindow(view, DockingPaneStyle.Docked);
        }

        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore it position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="view">View to dock.</param>
        /// <param name="dockingSyle">Docking style.</param>
        public void ShowWindow(IDockableViewModel view, DockingPaneStyle dockingSyle)
        {
            ShowWindow(view, dockingSyle, DockingPaneAnchorStyle.None);
        }

        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore it position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="view">View to dock.</param>
        /// <param name="dockingStyle">Docking style.</param>
        /// <param name="dockingAnchorStyle">Docking anchor style. Only usefull for DockingPaneStyle.Docked.</param>
        public void ShowWindow(IDockableViewModel view, DockingPaneStyle dockingStyle, DockingPaneAnchorStyle dockingAnchorStyle)
        {
            this.ShowWindow(view, dockingStyle, dockingAnchorStyle, view.DockingPaneStyle == DockingPaneStyle.DockedInDocumentPane);
        }

        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore it position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="view">View to dock.</param>
        /// <param name="dockingStyle">Docking style.</param>
        /// <param name="dockingAnchorStyle">Docking anchor style. Only usefull for DockingPaneStyle.Docked.</param>
        /// <param name="fullFileName">File name.</param>
        public void ShowWindow(IDockableViewModel view, DockingPaneStyle dockingStyle, DockingPaneAnchorStyle dockingAnchorStyle, string fullFileName)
        {
            this.ShowWindow(view, dockingStyle, dockingAnchorStyle, view.DockingPaneStyle == DockingPaneStyle.DockedInDocumentPane, fullFileName);
        }

        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore its position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="view">View to dock.</param>
        /// <param name="dockingStyle">Docking style.</param>
        /// <param name="dockingAnchorStyle">Docking anchor style. Only usefull for DockingPaneStyle.Docked.</param>
        /// <param name="dockedInDocumentPane">True if this view should be shown in the document pane window. False otherwise.</param>
        public void ShowWindow(IDockableViewModel view, DockingPaneStyle dockingStyle, DockingPaneAnchorStyle dockingAnchorStyle, bool dockedInDocumentPane)
        {
            this.ShowWindow(view, dockingStyle, dockingAnchorStyle, dockedInDocumentPane, this.SelectedShellViewModel.FullFileName);
        }

        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore its position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="view">View to dock.</param>
        /// <param name="dockingStyle">Docking style.</param>
        /// <param name="dockingAnchorStyle">Docking anchor style. Only usefull for DockingPaneStyle.Docked.</param>
        /// <param name="dockedInDocumentPane">True if this view should be shown in the document pane window. False otherwise.</param>
        /// <param name="fullFileName">File name.</param>
        public virtual void ShowWindow(IDockableViewModel view, DockingPaneStyle dockingStyle, DockingPaneAnchorStyle dockingAnchorStyle, bool dockedInDocumentPane, string fullFileName)
        {
            if (!view.IsInitialized)
                view.InitializeVM();

            string accessKey = fullFileName;
            if (this.IsTransientViewModel(view.GetType()))
            {
                accessKey = TransientPanesKey;
                if( viewLookup.ContainsKey(TransientPanesKey) )
                    if (viewLookup[TransientPanesKey].ContainsKey(view.DockingPaneName))
                    {
                        ModelToolWindowPane p = viewLookup[TransientPanesKey][view.DockingPaneName].Pane;
                        if (p != null)
                        {
                            if (((IVsWindowFrame)p.Frame).IsVisible() != VSConstants.S_OK)
                                return;
                        }
                    }
            }
            if (!viewLookup.ContainsKey(accessKey))
                viewLookup.Add(accessKey, new Dictionary<string, ViewLookUp>());

            if (!viewLookup[accessKey].ContainsKey(view.DockingPaneName))
            {
                if (!dockedInDocumentPane)
                {
                    int key;
                    if (!this.viewTypeNameLookup.ContainsKey(view.DockingPaneType.FullName))
                        key = 0;
                    else
                        key = this.viewTypeNameLookup[view.DockingPaneType.FullName].Count;

                    ModelToolWindowPane window = this.package.FindToolWindow(this.package.GetToolWindowType(view.DockingPaneType), key, true) as ModelToolWindowPane;
                    if ((window == null) || (window.Frame == null))
                    {
                        throw new NotSupportedException("Can not show window!");
                    }
                    window.Content.DataContext = view;
                    window.Caption = view.DockingPaneTitle;

                    // subscribe to events
                    window.PaneClosed += new EventHandler(Window_PaneClosed);

                    // get window frame
                    IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;

                    // add lookup information
                    viewLookup[accessKey][view.DockingPaneName] = new ViewLookUp(view, window);
                    view.IsDockingPaneVisible = true;
                    paneViewLookup.Add(ModelPackage.GetPersistenceSlot(windowFrame), view.DockingPaneName);

                    if (!this.viewTypeNameLookup.ContainsKey(view.DockingPaneType.FullName))
                        this.viewTypeNameLookup[view.DockingPaneType.FullName] = new List<string>();
                    this.viewTypeNameLookup[view.DockingPaneType.FullName].Add(view.DockingPaneName);

                    // show window
                    windowFrame.Show();

                }
                else
                {
                    viewLookup[accessKey][view.DockingPaneName] = new ViewLookUp(view);

                    if (accessKey != TransientPanesKey)
                    {
                        this.packageController.AvailableShellVMsReversed[accessKey].VisibleDocumentPanes.Add(view);
                        if (this.packageController.AvailableShellVMsReversed[accessKey].SelectedDocumentPane == null)
                            this.packageController.AvailableShellVMsReversed[accessKey].SelectedDocumentPane = view;
                    }
                    else
                    {
                        this.SelectedShellViewModel.VisibleDocumentPanes.Add(view);
                        if (this.SelectedShellViewModel.SelectedDocumentPane == null)
                            this.SelectedShellViewModel.SelectedDocumentPane = view;
                    }
                    view.IsDockingPaneVisible = true;                    
                }
            }

            // show docking window
            if (!dockedInDocumentPane)
            {
                if (viewLookup[accessKey][view.DockingPaneName].Pane != null)
                    if (((IVsWindowFrame)viewLookup[accessKey][view.DockingPaneName].Pane.Frame).IsVisible() != VSConstants.S_OK)
                    {
                        ((IVsWindowFrame)viewLookup[accessKey][view.DockingPaneName].Pane.Frame).Show();
                        viewLookup[accessKey][view.DockingPaneName].View.IsDockingPaneVisible = true;
                    }
            }
            else
            {
                if (this.SelectedShellViewModel.HiddenDocumentPanes.Contains(view))
                {
                    this.SelectedShellViewModel.HiddenDocumentPanes.Remove(view);
                    this.SelectedShellViewModel.VisibleDocumentPanes.Add(view);

                    if (this.SelectedShellViewModel.SelectedDocumentPane == null)
                        this.SelectedShellViewModel.SelectedDocumentPane = view;
                }
                view.IsDockingPaneVisible = true;
            }

            if (this.IsTransientViewModel(view.GetType()))
            {
                // update all IsDockingPaneVisible
                foreach (ShellMainViewModel v in this.packageController.AvailableShellVMs.Keys)
                {
                    BaseDockingViewModel foundVm = v.FindViewModel(view.GetType());
                    foundVm.IsDockingPaneVisible = true;
                }
            }
        }

        /// <summary>
        /// Shows a docking window for a given view.  
        /// If is has been shown before, restore it position. Otherwise dock it to the right side.
        /// </summary>
        /// <param name="name">View to show.</param>
        /// <param name="dockingStyle">Docking style.</param>
        /// <param name="dockingAnchorStyle">Docking anchor style. Only usefull for DockingPaneStyle.Docked.</param>
        /// <returns></returns>
        public IDockableViewModel ShowWindow(string name, DockingPaneStyle dockingStyle, DockingPaneAnchorStyle dockingAnchorStyle)
        {
            IDockableViewModel d = null;
            string accessKey = this.SelectedShellViewModel.FullFileName;
            if (this.viewLookup.ContainsKey(accessKey))
                if (this.viewLookup[accessKey].ContainsKey(name))
                {
                    d = this.viewLookup[accessKey][name].View;
                }

            if (this.viewLookup.ContainsKey(TransientPanesKey))
                if (this.viewLookup[TransientPanesKey].ContainsKey(name))
                {
                    d = this.viewLookup[TransientPanesKey][name].View;
                }

            if (d != null)
            {
                ShowWindow(d, dockingStyle, dockingAnchorStyle);
                return d;
            }

            return null;
        }

        /// <summary>
        /// Tries to bring the view displaying the given view model to the front.
        /// </summary>
        /// <param name="view"></param>
        public void BringToFrontWindow(IDockableViewModel view)
        {
            string accessKey = this.SelectedShellViewModel.FullFileName;
            if (this.IsTransientViewModel(view.GetType()))
                accessKey = TransientPanesKey;

            if (!viewLookup.ContainsKey(accessKey))
                return;

            if (viewLookup[accessKey].ContainsKey(view.DockingPaneName))
            {
                ViewLookUp v = viewLookup[accessKey][view.DockingPaneName];
                if (v.Pane != null)
                {
                    (v.Pane.Frame as IVsWindowFrame).Show();
                }
                else
                {
                    this.SelectedShellViewModel.SelectedDocumentPane = view;
                }
            }
        }

        /// <summary>
        /// Tries to close a specified window..
        /// </summary>
        /// <param name="view"></param>
        public void CloseWindow(IDockableViewModel view)
        {
            this.CloseWindow(view, false);
        }

        /// <summary>
        /// Tries to close a specified window..
        /// </summary>
        /// <param name="view"></param>
        /// <param name="bRemove"></param>
        public void CloseWindow(IDockableViewModel view, bool bRemove)
        {
            string accessKey = this.SelectedShellViewModel.FullFileName;
            if (this.IsTransientViewModel(view.GetType()))
                accessKey = TransientPanesKey;

            if (!viewLookup.ContainsKey(accessKey))
                return;

            if (viewLookup[accessKey].ContainsKey(view.DockingPaneName))
            {
                ViewLookUp v = viewLookup[view.DockingPaneName][accessKey];
                if (v.Pane != null)
                {
                    (v.Pane.Frame as IVsWindowFrame).CloseFrame((uint)__FRAMECLOSE.FRAMECLOSE_NoSave);
                }
                else
                {
                    view.IsDockingPaneVisible = false;

                    if (this.SelectedShellViewModel.VisibleDocumentPanes.Contains(view))
                    {
                        this.SelectedShellViewModel.HiddenDocumentPanes.Add(this.SelectedShellViewModel.SelectedDocumentPane);
                        this.SelectedShellViewModel.VisibleDocumentPanes.Remove(this.SelectedShellViewModel.SelectedDocumentPane);
                    }

                    if (this.SelectedShellViewModel.VisibleDocumentPanes.Count == 0)
                        this.SelectedShellViewModel.SelectedDocumentPane = null;
                }

                // TODO ?
                if( bRemove )
                {
                    // remove pane from lookup
                    //this.viewLookup.Remove(view.DockingPaneName);
                }
            }

            if (this.IsTransientViewModel(view.GetType()))
            {
                // update all IsDockingPaneVisible
                foreach (ShellMainViewModel v in this.packageController.AvailableShellVMs.Keys)
                {
                    BaseDockingViewModel foundVm = v.FindViewModel(view.GetType());
                    foundVm.IsDockingPaneVisible = false;
                }
            }
        }

        /// <summary>
        /// Invalidates the titles of all docking panes.
        /// </summary>
        public void InvalidatePaneTitles()
        {
            foreach (string key in viewLookup.Keys)
            foreach (string name in viewLookup[key].Keys)
            {
                IDockableViewModel vm = viewLookup[key][name].View;
                if (viewLookup[key][name].Pane != null)
                    viewLookup[key][name].Pane.Caption = vm.DockingPaneTitle;
            }
        }
        
        private void CloseSDPCommand_Execute()
        {
            this.SelectedShellViewModel.SelectedDocumentPane.IsDockingPaneVisible = false;

            this.SelectedShellViewModel.HiddenDocumentPanes.Add(this.SelectedShellViewModel.SelectedDocumentPane);
            this.SelectedShellViewModel.VisibleDocumentPanes.Remove(this.SelectedShellViewModel.SelectedDocumentPane);

            if (this.SelectedShellViewModel.VisibleDocumentPanes.Count == 0)
                this.SelectedShellViewModel.SelectedDocumentPane = null;
        }
        private bool CloseSDPCommand_CanExecute()
        {
            if (this.SelectedShellViewModel.SelectedDocumentPane != null)
                return true;

            return false;
        }
        #endregion

        #region Window events
        private void Window_PaneClosed(object sender, EventArgs e)
        {
            if (this.viewLookup.Count == 0 || this.paneViewLookup.Count == 0)
                return;

            ModelToolWindowPane pane = (ModelToolWindowPane)sender;
            IVsWindowFrame windowFrame = (IVsWindowFrame)pane.Frame;

            Guid g = ModelPackage.GetPersistenceSlot(windowFrame);

            string accessKey = this.SelectedShellViewModel.FullFileName;
            if( this.viewLookup.ContainsKey(accessKey) )
                if (this.viewLookup[accessKey].ContainsKey(this.paneViewLookup[g]))
                {
                    ViewLookUp v = this.viewLookup[accessKey][this.paneViewLookup[g]];
                    v.View.IsDockingPaneVisible = false;
                }

            if (this.viewLookup.ContainsKey(TransientPanesKey))
                if (this.viewLookup[TransientPanesKey].ContainsKey(this.paneViewLookup[g]))
                {
                    ViewLookUp v = this.viewLookup[TransientPanesKey][this.paneViewLookup[g]];
                    v.View.IsDockingPaneVisible = false;
                }
        }

        private void Package_ActiveWindowChangedEvent(object sender, ModelPackage.WindowChangedEventArgs e)
        {
            // there is no need to deactivate a view as this is handled by the main vm

            // activate view
            if (this.SelectedShellViewModel == null)
                return;

            this.SelectedShellViewModel.IsDockingPaneActive = false;
            if (e.NewData != null)
                if (e.NewData.DoesBelongToPackage)
                {
                    if (e.NewData.IsDocumentFrame)
                    {
                        if (this.selectedShellVMName != e.NewData.FullFileName)
                        {
                            bool bLoadLayout = false;
                            if (this.selectedShellVMName == null)
                                bLoadLayout = true;
                            
                            this.selectedShellVMName = e.NewData.FullFileName;

                            // change current shell vm
                            this.packageController.SetCurrentShellViewModel(this.selectedShellVMName);

                            if (bLoadLayout)
                                this.bForceLoadLayout = true;
                            //else
                            //{
                                UpdateView();
                            //}
                        }
                        this.SelectedShellViewModel.IsDockingPaneActive = true;

                        /*
                        if (this.SelectedDocumentPane != null)
                        {
                            this.OnActivePaneChanged(this.SelectedDocumentPane, true);
                            this.activePane = this.SelectedDocumentPane;
                        }
                        else
                            DeactivateCurrentPane();
                        */
                    }
                    else
                    {
                        this.SelectedShellViewModel.TriggerDockingPaneActivated = true;
                        if (e.NewData.Key != Guid.Empty)
                        {
                            string accessKey = this.SelectedShellViewModel.FullFileName;
                            if (this.viewLookup.ContainsKey(accessKey))
                                if (this.viewLookup[accessKey].ContainsKey(this.paneViewLookup[e.NewData.Key]))
                                {
                                    this.activePane = this.viewLookup[accessKey][this.paneViewLookup[e.NewData.Key]].View;
                                }

                            if (this.viewLookup.ContainsKey(TransientPanesKey))
                                if (this.viewLookup[TransientPanesKey].ContainsKey(this.paneViewLookup[e.NewData.Key]))
                                {
                                    this.activePane = this.viewLookup[TransientPanesKey][this.paneViewLookup[e.NewData.Key]].Pane.Content.DataContext as IDockableViewModel;
                                    //this.activePane = this.viewLookup[TransientPanesKey][this.paneViewLookup[e.NewData.Key]].View;
                                }

                            this.OnActivePaneChanged(this.activePane, true);
                        }
                        else
                            DeactivateCurrentPane();
                    }
                }
                else
                {
                    if (e.NewData.IsDocumentFrame)
                    {
                        // close vms???
                    }

                    this.SelectedShellViewModel.TriggerDockingPaneActivated = true;

                    // deactivate current pane
                    DeactivateCurrentPane();
                }
        }
        private void SetViewModel(ModelToolWindowPane pane, BaseDockingViewModel vm)
        {
            if( vm != null )
                if (!vm.IsDisposed)
                {
                    pane.Content.DataContext = vm;
                    return;
                }
            pane.Content.DataContext = null;
        }

        /// <summary>
        /// Update view.
        /// </summary>
        public void UpdateView()
        {
            if( this.viewLookup.ContainsKey(TransientPanesKey) )
                foreach (ViewLookUp v in this.viewLookup[TransientPanesKey].Values)
                {
                    if (v.Pane != null)
                    {
                        if (this.IsTransientViewModel(v.View.GetType()))
                            SetViewModel(v.Pane, this.SelectedShellViewModel.FindViewModel(v.View.GetType()));
                    }
                }
        }

        /// <summary>
        /// Returns true if this is a transient view model, that is a vm for which only one tool window is created.
        /// That tool window's datacontext is updated for different documents.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>True for transient vms. False otherwise.</returns>
        protected virtual bool IsTransientViewModel(Type type)
        {
            if (type.IsSubclassOf(typeof(MainModelTreeViewModel)) || type.IsSubclassOf(typeof(MainErrorListViewModel)) ||
                type.IsSubclassOf(typeof(MainPropertyGridViewModel)) || type.IsSubclassOf(typeof(MainDependenciesViewModel)) ||
                type.IsSubclassOf(typeof(SearchViewModel)) || type.IsSubclassOf(typeof(SearchResultViewModel)))
                return true;

            return false;
        }

        private void DeactivateCurrentPane()
        {
            // deactivate current pane
            if (this.activePane != null)
                this.OnActivePaneChanged(this.activePane, false);
            this.activePane = null;
        }
        private void DocumentPaneControlActivated_Execute()
        {
            if (this.SelectedShellViewModel.IsDockingPaneActive)
                this.OnActivePaneChanged(this.SelectedShellViewModel.SelectedDocumentPane, true);

            this.SelectedShellViewModel.TriggerDockingPaneActivated = false;
        }

        /// <summary>
        /// Delegate for the ActivePaneChanged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ActivePaneChangedEventHandler(object sender, ActivePaneChangedEventArgs e);

        /// <summary>
        /// Active pane changed event. This event fires whenever the active pane changes.
        /// </summary>
        public event ActivePaneChangedEventHandler ActivePaneChanged;

        /// <summary>
        /// Called whenever the active pane changes.
        /// </summary>
        /// <param name="dockableViewModel"></param>
        /// <param name="isActive"></param>
        protected void OnActivePaneChanged(IDockableViewModel dockableViewModel, bool isActive)
        {
            if (ActivePaneChanged != null)
            {
                ActivePaneChanged(this,
                   new ActivePaneChangedEventArgs()
                   {
                       DockableViewModel = dockableViewModel,
                       IsActive = isActive
                   }
                );
            }
        }
        #endregion

        #region State methods
        /// <summary>
        /// Loads the configuration.
        /// </summary>
        public void LoadConfigurations()
        {
            this.configuration = new DockingLayoutManagerConfiguration();
            this.configuration.Load(this.SaveConfigurationFilePath);
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfigurations()
        {
            if( this.configuration != null )
                this.configuration.Save(this.SaveConfigurationFilePath);
        }

        /// <summary>
        /// Saves the current configuration under the given name.
        /// </summary>
        /// <param name="name">Configuration name.</param>
        public void SaveConfiguration(string name)
        {
            if (this.configuration == null)
                this.LoadConfigurations();

            DockingLayoutContextConfiguration config;
            if (!this.configuration.Configurations.ContainsKey(name))
            {
                config = new DockingLayoutContextConfiguration(name);
                //config.LayoutPath = "Layout_" + config.ContextName + ".xml";

                this.configuration.AddConfiguration(config);
            }
            else
            {
                config = this.configuration.Configurations[name];
                //if (config.LayoutPath == null)
                //    config.LayoutPath = "Layout_" + config.ContextName + ".xml";
                config.Configurations.Clear();
            }

            string accessKey = this.SelectedShellViewModel.FullFileName;
            if (viewLookup.ContainsKey(accessKey))
                foreach (string paneName in this.viewLookup[accessKey].Keys)
                {
                    IDockableViewModel vm = this.viewLookup[accessKey][paneName].View;
                    DockingPaneConfiguration c = new DockingPaneConfiguration(vm.DockingPaneName);
                    c.IsVisible = vm.IsDockingPaneVisible;
                    config.Configurations.Add(c.PaneName, c);

                    if (vm is IRestorableDockableViewModel)
                    {
                        IRestorableDockableViewModel rVm = vm as IRestorableDockableViewModel;

                        c.IsRestorable = true;
                        c.RestoreInformation = rVm.GetInformationForRestore();
                        c.DockingPaneType = rVm.GetDockingPaneType();
                    }
                }

            if (viewLookup.ContainsKey(TransientPanesKey))
                foreach (string paneName in this.viewLookup[TransientPanesKey].Keys)
                {
                    IDockableViewModel vm = this.viewLookup[TransientPanesKey][paneName].View;
                    DockingPaneConfiguration c = new DockingPaneConfiguration(vm.DockingPaneName);
                    c.IsVisible = vm.IsDockingPaneVisible;
                    config.Configurations.Add(c.PaneName, c);
                }

            // save layout ...
        }

        /// <summary>
        /// Loads a specific window configuration.
        /// </summary>
        /// <param name="name">Name of the configuration.</param>
        /// <param name="dockableViews">Existing dockable views.</param>
        /// <param name="fullFileName">Full file name fo the shell vm.</param>
        public void RestoreConfiguration(string name, IEnumerable dockableViews, string fullFileName)
        {
            this.RestoreConfiguration(name, dockableViews, false, fullFileName);
        }

        /// <summary>
        /// Loads a specific window configuration.
        /// </summary>
        /// <param name="name">Name of the configuration.</param>
        /// <param name="dockableViews">Existing dockable views.</param>
        /// <param name="bAckForceRestore">Acknoledge the force restore parameter that is set whenever a document is loaded for the first time (no document loaded before).</param>
        /// /// <param name="fullFileName">Full file name fo the shell vm.</param>
        public void RestoreConfiguration(string name, IEnumerable dockableViews, bool bAckForceRestore, string fullFileName)
        {
            if (this.configuration == null)
                this.LoadConfigurations();

            if (bAckForceRestore)
                if (!this.bForceLoadLayout)
                    return;

            if (!this.configuration.Configurations.ContainsKey(name))
            {
                // restore default layout
                this.RestoreDefaultWindows(dockableViews, name, fullFileName);
            }
            else
            {
                // restore windows
                Dictionary<string, IDockableViewModel> existingPanes = new Dictionary<string, IDockableViewModel>();
                foreach (IDockableViewModel p in dockableViews)
                {
                    existingPanes.Add(p.DockingPaneName, p);
                }

                DockingLayoutContextConfiguration config = this.configuration.Configurations[name];
                foreach (string n in config.Configurations.Keys)
                {
                    if (!existingPanes.ContainsKey(n))
                        this.OnRestoreLayoutMissingVMEncountered(config.Configurations[n]);
                    else
                    {
                        if (config.Configurations[n].IsVisible)
                        {
                            IDockableViewModel p = existingPanes[n];
                            if (this.IsTransientViewModel(p.GetType()))
                            {
                                if (this.viewLookup.ContainsKey(TransientPanesKey))
                                    if (this.viewLookup[TransientPanesKey].ContainsKey(p.DockingPaneName))
                                        continue;
                                ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle, TransientPanesKey);
                            }
                            else
                            {
                                if (this.viewLookup.ContainsKey(fullFileName))
                                    if (this.viewLookup[fullFileName].ContainsKey(p.DockingPaneName))
                                        continue;
                                ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle, fullFileName);
                            }
                        }
                    }
                }

                // restore layout ?
                // ..
            }
        }

        /// <summary>
        /// Closes the vistual studio windows currently opened.
        /// </summary>
        /// <param name="fullFileName"></param>
        public void CloseConfiguration(string fullFileName)
        {
            if (this.viewLookup.ContainsKey(fullFileName))
            {
                foreach (string n in this.viewLookup[fullFileName].Keys)
                    if (this.viewLookup[fullFileName][n].Pane != null)
                        if (((IVsWindowFrame)this.viewLookup[fullFileName][n].Pane.Frame).IsVisible() == VSConstants.S_OK)
                        {
                            ((IVsWindowFrame)this.viewLookup[fullFileName][n].Pane.Frame).CloseFrame((uint)__FRAMECLOSE.FRAMECLOSE_NoSave);
                        }

                this.viewLookup.Remove(fullFileName);
            }
        }

        /// <summary>
        /// Closes the vistual studio windows currently opened.
        /// </summary>
        public void CloseConfiguration()
        {
            foreach (string key in this.viewLookup.Keys)
                foreach (string n in this.viewLookup[key].Keys)
                    if (this.viewLookup[key][n].Pane != null)
                        if (((IVsWindowFrame)this.viewLookup[key][n].Pane.Frame).IsVisible() == VSConstants.S_OK)
                        {
                            ((IVsWindowFrame)this.viewLookup[key][n].Pane.Frame).CloseFrame((uint)__FRAMECLOSE.FRAMECLOSE_NoSave);
                        }

            this.viewLookup.Clear();
            this.paneViewLookup.Clear();
            this.viewTypeNameLookup.Clear();

            //this.visibleCollection.Clear();
            //this.hiddenCollection.Clear();
        }

        private void RestoreDefaultWindows(IEnumerable dockableViews, string currentCntxName, string fullFileName)
        {
            Assembly assembly = Assembly.GetAssembly(package.GetType());
            try
            {
                using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(this.EmbeddedDockingPanesFilePath)))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        int index = line.IndexOf(":::");
                        if (index < 0)
                            continue;

                        string contextName = line.Substring(0, index);
                        if (contextName == currentCntxName)
                        {
                            string dvNames = line.Substring(index + 3, line.Length - index - 3);

                            string[] names = dvNames.Split(new char[] { ',' });
                            List<string> dvNamesList = new List<string>();
                            foreach (string name in names)
                            {
                                string temp = name.Trim();
                                if (temp.Contains("\r\n"))
                                    temp = temp.Replace("\r\n", "");

                                dvNamesList.Add(temp);
                            }

                            foreach (IDockableViewModel p in dockableViews)
                            {
                                if (dvNamesList.Contains(p.DockingPaneName))
                                {
                                    if (this.IsTransientViewModel(p.GetType()))
                                    {
                                        if (this.viewLookup.ContainsKey(TransientPanesKey))
                                            if (this.viewLookup[TransientPanesKey].ContainsKey(p.DockingPaneName))
                                                continue;
                                        ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle, TransientPanesKey);
                                    }
                                    else
                                    {
                                        if (this.viewLookup.ContainsKey(fullFileName))
                                            if (this.viewLookup[fullFileName].ContainsKey(p.DockingPaneName))
                                                continue;
                                        ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle, fullFileName);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
        
        /// <summary>
        /// Delegate for the ActivePaneChanged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void RestoreLayoutMissingVMEncounteredEventHandler(object sender, MissingViewModelEventArgs e);

        /// <summary>
        /// Active pane changed event.
        /// </summary>
        public event RestoreLayoutMissingVMEncounteredEventHandler RestoreLayoutMissingVMEncountered;

        /// <summary>
        /// Called whenever the active pane changes.
        /// </summary>
        /// <param name="paneConfiguration"></param>
        protected void OnRestoreLayoutMissingVMEncountered(DockingPaneConfiguration paneConfiguration)
        {
            if (RestoreLayoutMissingVMEncountered != null)
            {
                RestoreLayoutMissingVMEncountered(this,
                   new MissingViewModelEventArgs()
                   {
                       DockingPaneConfiguration = paneConfiguration,
                   }
                );
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the close command.
        /// </summary>
        public DelegateCommand CloseSelectedDocumentPaneCommand
        {
            get
            {
                return this.closeSelectedDocumentPaneCommand;
            }
        }

        /// <summary>
        /// Gets the pane activated command.
        /// </summary>
        public DelegateCommand DocumentPaneControlActivated
        {
            get
            {
                return this.documentPaneControlActivated;
            }
        }
        
        /// <summary>
        /// Gets the selected shell view model.
        /// </summary>
        public ShellMainViewModel SelectedShellViewModel
        {
            get
            {
                return this.selectedShellVM;
            }
            set
            {
                if (this.selectedShellVM != value)
                {
                    this.selectedShellVM = value;
                    OnPropertyChanged("SelectedShellViewModel");

                    if (this.selectedShellVM == null)
                        this.selectedShellVMName = null;
                }
            }
        }

        /// <summary>
        /// FilePath to save all the visible docking panes to.
        /// </summary>
        public abstract string SaveDockingPanesFilePath { get; }

        /// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public abstract string SaveLayoutFilePath { get; }

        /// <summary>
        /// Directory to save the layouts to.
        /// </summary>
        public abstract string SaveLayoutDirectory { get; }

        /// <summary>
        /// FilePath to save the layout to.
        /// </summary>
        public abstract string SaveConfigurationFilePath { get; }

        /// <summary>
        /// Path to the embedded default layout file. By default: /GeneratedCode/UI/LayoutManagerLayout.xml.
        /// </summary>
        public abstract string EmbeddedLayoutFilePath { get; }

        /// <summary>
        /// Path to the embedded dfault visible docking panes files. By default: /GeneratedCode/UI/LayoutManagerDV.txt.
        /// </summary>
        public abstract string EmbeddedDockingPanesFilePath { get; }
        #endregion

        /// <summary>
        /// Clean up.
        /// </summary>
        public virtual void Dispose()
        {
            this.package.ActiveWindowChangedEvent -= new ModelPackage.ActiveWindowChangedEventHandler(Package_ActiveWindowChangedEvent);
            
            this.viewLookup.Clear();
            this.viewTypeNameLookup.Clear();
            this.paneViewLookup.Clear();

            //this.visibleCollection.Clear();
            //this.hiddenCollection.Clear();
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
    }
}

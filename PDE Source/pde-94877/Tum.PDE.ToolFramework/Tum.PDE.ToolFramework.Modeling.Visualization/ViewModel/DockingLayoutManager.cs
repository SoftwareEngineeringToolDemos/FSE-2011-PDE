using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

using AvalonDock;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Fluent;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    #region Helper Classes/Enums
    /// <summary>
    /// Docking pane styles.
    /// </summary>
    public enum DockingPaneStyle
    {
        /// <summary>
        /// Normally docked pane.
        /// </summary>
        Docked,

        /// <summary>
        /// Docked in the document pane.
        /// </summary>
        DockedInDocumentPane,

        /// <summary>
        /// Floating pane.
        /// </summary>
        Floating
    }

    /// <summary>
    /// Docking anchor types.
    /// </summary>
    public enum DockingPaneAnchorStyle
    {
        /// <summary>
        /// No anchor style, while content is hosted in a DocumentPane or a FloatingWindow
        /// </summary>
        None,
        /// <summary>
        /// Top border anchor
        /// </summary>
        Top,
        /// <summary>
        /// Left border anchor
        /// </summary>
        Left,
        /// <summary>
        /// Bottom border anchor
        /// </summary>
        Bottom,
        /// <summary>
        /// Right border anchor
        /// </summary>
        Right
    }

    /// <summary>
    /// Docking context change kind specifying when a docking content is to be activated.
    /// </summary>
    public enum DockingContextChangeKind
    {
        /// <summary>
        /// Activate content whenever a mouse down event occurs.
        /// </summary>
        PreviewMouseDown,

        /// <summary>
        /// Activate content whenever a mouse up event occurs.
        /// </summary>
        PreviewMouseUp
    }

    /// <summary>
    /// Event args for the activa pance changed event.
    /// </summary>
    public class ActivePaneChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the dockable vm.
        /// </summary>
        public IDockableViewModel DockableViewModel { get; set; }

        /// <summary>
        /// Gets or sets the is active field.
        /// </summary>
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// Event args for the activa pance changed event.
    /// </summary>
    public class PaneClosedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the dockable vm.
        /// </summary>
        public IDockableViewModel DockableViewModel { get; set; }
    }

    /// <summary>
    /// Event args for the activa pance changed event.
    /// </summary>
    public class MissingViewModelEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the docking pane configuration.
        /// </summary>
        public DockingPaneConfiguration DockingPaneConfiguration { get; set; }
    }
    #endregion

    #region Configuration Helper Classes
    /// <summary>
    /// Configuration info for a docking pane.
    /// </summary>
    public class DockingPaneConfiguration
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="paneName">Pane name.</param>
        public DockingPaneConfiguration(string paneName)
        {
            this.PaneName = paneName;
            this.IsVisible = true;
            this.IsRestorable = false;
            this.DockingPaneType = null;
            this.RestoreInformation = null;
        }

        /// <summary>
        /// Gets the pane name.
        /// </summary>
        public string PaneName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets whether this pane is visible or not.
        /// </summary>
        public bool IsVisible
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this pane is restorable or not.
        /// </summary>
        public bool IsRestorable
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the docking pane type. Only relevant for restorable vms.
        /// </summary>
        public string DockingPaneType
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets or sets the restore information. Can be null.
        /// </summary>
        public XElement RestoreInformation
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Docking pane context configuration.
    /// </summary>
    public class DockingLayoutContextConfiguration
    {
        private Dictionary<string, DockingPaneConfiguration> configurations;

        /// <summary>
        /// Gets or sets the context name.
        /// </summary>
        /// <param name="contextName">Context name.</param>
        public DockingLayoutContextConfiguration(string contextName)
        {
            this.ContextName = contextName;

            this.configurations = new Dictionary<string, DockingPaneConfiguration>();
        }

        /// <summary>
        /// Gets the context name.
        /// </summary>
        public string ContextName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of configurations.
        /// </summary>
        public Dictionary<string, DockingPaneConfiguration> Configurations
        {
            get
            {
                return this.configurations;
            }
        }

        /// <summary>
        /// Gets or sets the layout file path. The file may not exist.
        /// </summary>
        public string LayoutPath
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Configuration info for a layout manager.
    /// </summary>
    public class DockingLayoutManagerConfiguration
    {
        //public const string NoContextConfigurationName = "440005F9A17648EBB6FA44F3E9E1D569";
        private Dictionary<string, DockingLayoutContextConfiguration> configurations;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DockingLayoutManagerConfiguration()
        {
            this.configurations = new Dictionary<string, DockingLayoutContextConfiguration>();
        }

        /// <summary>
        /// Gets the configurations.
        /// </summary>
        public Dictionary<string, DockingLayoutContextConfiguration> Configurations
        {
            get
            {
                return this.configurations;
            }
        }

        /// <summary>
        /// Adds a configuration.
        /// </summary>
        /// <param name="config">Configuration.</param>
        public void AddConfiguration(DockingLayoutContextConfiguration config)
        {
            if (!this.Configurations.ContainsKey(config.ContextName))
                this.Configurations.Add(config.ContextName, config);
            else
                this.Configurations[config.ContextName] = config;
        }

        /// <summary>
        /// Clear configurations belonging to a specific context.
        /// </summary>
        /// <param name="name">Context name.</param>
        public void RemoveConfiguration(string name)
        {
            if (this.Configurations.ContainsKey(name))
                this.Configurations.Remove(name);
        }

        /// <summary>
        /// Clear configurations.
        /// </summary>
        public void ClearConfiguration()
        {

        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Load(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            try
            {
                XDocument doc = XDocument.Load(fileName);
                XElement rootNode = doc.Root;

                foreach (XElement node in rootNode.Elements("Config"))
                {
                    string contextName = node.Element("ContextName").Value;
                    string layoutPath = null;
                    if( node.Element("LayoutPath") != null )
                        layoutPath = node.Element("LayoutPath").Value;

                    DockingLayoutContextConfiguration config = new DockingLayoutContextConfiguration(contextName);
                    config.LayoutPath = layoutPath;

                    XElement configurationsElement = node.Element("Configurations");
                    foreach (XElement n in configurationsElement.Elements("Configuration"))
                    {
                        string paneName = n.Element("PaneName").Value;
                        bool isVisble = Boolean.Parse(n.Element("IsVisible").Value);
                        bool isRestorable = Boolean.Parse(n.Element("IsRestorable").Value);
                        
                        DockingPaneConfiguration pane = new DockingPaneConfiguration(paneName);
                        pane.IsVisible = isVisble;
                        pane.IsRestorable = isRestorable;
                        
                        if (n.Element("DockingPaneType") != null)
                            pane.DockingPaneType = n.Element("DockingPaneType").Value;

                        XElement ri = n.Element("RestoreInformation");
                        if (ri != null)
                            pane.RestoreInformation = ri.Elements().ElementAt(0);

                        config.Configurations.Add(pane.PaneName, pane);
                    }
                    
                    this.AddConfiguration(config);
                }
            }
            catch { }

        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void Save(string fileName)
        {
            XDocument doc = new XDocument();
            XElement rootNode = new XElement("DockingLayoutManagerConfiguration");
            doc.Add(rootNode);

            foreach (string key in this.Configurations.Keys)
            {
                DockingLayoutContextConfiguration config = this.Configurations[key];

                XElement node = new XElement("Config");
                AddAsElement(node, "ContextName", config.ContextName);
                if( config.LayoutPath != null )
                    AddAsElement(node, "LayoutPath", config.LayoutPath);

                XElement configurations = new XElement("Configurations");
                foreach (DockingPaneConfiguration p in config.Configurations.Values)
                {
                    XElement configuration = new XElement("Configuration");

                    AddAsElement(configuration, "PaneName", p.PaneName);
                    AddAsElement(configuration, "IsVisible", p.IsVisible.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    AddAsElement(configuration, "IsRestorable", p.IsRestorable.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    
                    if( p.DockingPaneType != null )
                        AddAsElement(configuration, "DockingPaneType", p.DockingPaneType);

                    if (p.RestoreInformation != null)
                    {
                        XElement restoreInformation = new XElement("RestoreInformation");
                        configuration.Add(restoreInformation);

                        restoreInformation.Add(p.RestoreInformation);
                    }

                    configurations.Add(configuration);
                }
                node.Add(configurations);

                rootNode.Add(node);
            }

            doc.Save(fileName);
        }

        private XElement AddAsElement(XElement node, string name, string value)
        {
            XElement n = new XElement(name);
            n.Value = value;

            node.Add(n);

            return n;
        }
    }
    #endregion

    /// <summary>
    /// This class is used to create new as well as store and restore layout of existing avalondock windows.
    /// </summary>
    public abstract class DockingLayoutManager : IDisposable
    {
        private DockingManager mainDockingManager;

        private Dictionary<string, ViewLookUp> viewLookup;

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
            public DockableContent Pane
            {
                get;
                set;
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="v"></param>
            /// <param name="p"></param>
            public ViewLookUp(IDockableViewModel v, DockableContent p)
            {
                this.View = v;
                this.Pane = p;
            }
        }

        private bool isRestoringLayout = false;
        private bool isRemoveInProcess = false;
        private DockingLayoutManagerConfiguration configuration;
        private string currentContextName = "_None_";

        private Ribbon ribbon;

        /// <summary>
        /// Gets or sets the main ribbon menu.
        /// </summary>
        public Ribbon Ribbon
        {
            get
            {
                return this.ribbon;
            }
            set
            {
                this.ribbon = value;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DockingLayoutManager()
        {
            mainDockingManager = new DockingManager();
            viewLookup = new Dictionary<string, ViewLookUp>();
        }

        /// <summary>
        /// Gets the docking manager.
        /// </summary>
        public DockingManager MainDockingManager
        {
            get {
                return mainDockingManager;
            }
        }

        /// <summary>
        /// Gets or sets the current context name.
        /// </summary>
        public string CurrentContextName
        {
            get
            {
                return this.currentContextName;
            }
            set
            {
                this.currentContextName = value;
            }
        }

        /// <summary>
        /// Gets the configuration manager.
        /// </summary>
        public DockingLayoutContextConfiguration CurrentConfiguration
        {
            get
            {
                if (!this.configuration.Configurations.ContainsKey(this.CurrentContextName))
                    this.configuration.AddConfiguration(new DockingLayoutContextConfiguration(this.CurrentContextName));

                return this.configuration.Configurations[this.CurrentContextName];
            }
        }

        /// <summary>
        /// Gets the configuration manager.
        /// </summary>
        public DockingLayoutManagerConfiguration ConfigurationManager
        {
            get
            {
                return this.configuration;
            }
        }

        /// <summary>
        /// Activates any view (the first usually) added to the manager.
        /// </summary>
        public void InitialActivate()
        {
            if (this.viewLookup != null)
                if (this.viewLookup.Keys.Count > 0)
                    this.Activate(this.viewLookup.Values.ElementAt(0).View);
        }

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
            // init resource dictionaries for plugin hosters
            if (view is IPluginHosterViewModel)
            {
                IPluginHosterViewModel pHost = (IPluginHosterViewModel)view;
                if (pHost.IsVMPlugin)
                {
                    if (!pHost.VMPluginDictionaryInitialized)
                        try
                        {
                            if (pHost.VMPlugin.GetViewModelRessourceDictionary() != null)
                                if (System.Windows.Application.Current != null)
                                {
                                    System.Windows.Application.Current.Resources.BeginInit();
                                    System.Windows.Application.Current.Resources.MergedDictionaries.Add(pHost.VMPlugin.GetViewModelRessourceDictionary());
                                    System.Windows.Application.Current.Resources.EndInit();
                                }
                            pHost.VMPluginDictionaryInitialized = true;
                        }
                        catch
                        {
                            pHost.VMPluginDictionaryInitialized = false;
                        }
                }
            }
            if (!this.isRestoringLayout)
            {
                if (!view.IsInitialized)
                    view.InitializeVM();

                if (view is IRibbonDockableViewModel && this.Ribbon != null)
                    if (!((IRibbonDockableViewModel)view).IsRibbonMenuInitialized)
                    {
                        ((IRibbonDockableViewModel)view).CreateRibbonMenu(this.Ribbon);
                    }
            }

            if (!viewLookup.ContainsKey(view.DockingPaneName))
            {
                DockableContent content = new DockableContent();
                content.Name = view.DockingPaneName;
                content.Title = view.DockingPaneTitle;
                content.Content = view;
                content.StateChanged += new System.Windows.RoutedEventHandler(content_StateChanged);
                if (view.ActivationMode == ActivationMode.Normal)
                    content.IsActiveContentChanged += new EventHandler(content_IsActiveContentChanged);
                content.ContextChangeKind = ConvertToContextChangeKind(view.DockingContextChangeKind);

                viewLookup.Add(view.DockingPaneName, new ViewLookUp(view, content));
                
                if (this.isRestoringLayout)
                {
                    this.MainDockingManager.AddPaneForLayoutRestore(content);
                }
                else
                {
                    if (dockingStyle == DockingPaneStyle.Floating)
                    {
                        content.FloatingWindowSize = new Size(view.FloatingWindowDesiredWidth, view.FloatingWindowDesiredHeight);
                        content.ShowAsFloatingWindow(this.MainDockingManager, true);
                    }
                    else if (dockingStyle == DockingPaneStyle.DockedInDocumentPane)
                        content.ShowAsDocument(this.MainDockingManager);
                    else
                    {
                        if (view.DockedWindowDesiredWidth > 0)
                            content.DesiredWidth = view.DockedWindowDesiredWidth;
                        if (view.DockedWindowDesiredHeight > 0)
                            content.DesiredHeight = view.DockedWindowDesiredHeight;

                        AnchorStyle style = ConvertToAnchorStyle(dockingAnchorStyle);
                        if (style != AnchorStyle.None)
                        {
                            content.Show(this.MainDockingManager, style);
                        }
                        else
                            content.Show(this.MainDockingManager);
                    }
                }
            }

            // show docking window
            if (!this.isRestoringLayout)
            if (!viewLookup[view.DockingPaneName].Pane.IsVisible)
            {
                if (dockingStyle == DockingPaneStyle.Floating)
                {
                    viewLookup[view.DockingPaneName].Pane.FloatingWindowSize = new Size(view.FloatingWindowDesiredWidth, view.FloatingWindowDesiredHeight);
                    viewLookup[view.DockingPaneName].Pane.ShowAsFloatingWindow(this.MainDockingManager, true);
                }
                else if (dockingStyle == DockingPaneStyle.DockedInDocumentPane)
                    viewLookup[view.DockingPaneName].Pane.ShowAsDocument(this.MainDockingManager);
                else
                    viewLookup[view.DockingPaneName].Pane.Show(this.MainDockingManager);

                view.IsDockingPaneVisible = true;
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
            if (viewLookup.ContainsKey(name))
            {
                IDockableViewModel d = viewLookup[name].View;

                ShowWindow(d, dockingStyle, dockingAnchorStyle);
                return d;
            }

            return null;

            /*
            foreach(IDockableViewModel d in viewLookup.Keys)
                if (d.DockingPaneName == name)
                {
                    ShowWindow(d, dockingStyle, dockingAnchorStyle);
                    return d;
                }

            return null;
            */
        }

        /// <summary>
        /// Shows a window if the current configuration contains it and if it is set as visible.
        /// </summary>
        /// <param name="view"></param>
        public void ShowWindowBasedOnConfiguraion(IDockableViewModel view)
        {
            if( this.CurrentConfiguration != null )
                if (this.CurrentConfiguration.Configurations.ContainsKey(view.DockingPaneName))
                {
                    DockingPaneConfiguration p = this.CurrentConfiguration.Configurations[view.DockingPaneName];
                    if (p.IsVisible)
                    {
                        this.ShowWindow(view, view.DockingPaneStyle, view.DockingPaneAnchorStyle);
                    }
                }
        }

        /// <summary>
        /// Hides a dockable window.
        /// </summary>
        /// <param name="view">Dockable window to hide.</param>
        public void HideWindow(IDockableViewModel view)
        {
            if (viewLookup.ContainsKey(view.DockingPaneName))
            {
                viewLookup[view.DockingPaneName].Pane.Hide();
            }
        }

        /// <summary>
        /// Tries to bring the view displaying the given view model to the front.
        /// </summary>
        /// <param name="view"></param>
        public void BringToFrontWindow(IDockableViewModel view)
        {
            if (viewLookup.ContainsKey(view.DockingPaneName) && !isRestoringLayout)
            {
                DockableContent content = viewLookup[view.DockingPaneName].Pane;
                content.Activate();
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
            this.isRemoveInProcess = true;
            if (viewLookup.ContainsKey(view.DockingPaneName) && !isRestoringLayout)
            {
                DockableContent content = viewLookup[view.DockingPaneName].Pane;
                content.Close();

                if (bRemove)
                {
                    // remove docking pane
                    this.MainDockingManager.RemovePane(content);

                    // notify of a pane beeing closed
                    this.OnPaneClosed(viewLookup[view.DockingPaneName].View);

                    // remove pane from lookup
                    this.viewLookup.Remove(view.DockingPaneName);
                }
            }
            this.isRemoveInProcess = false;
        }

        /// <summary>
        /// Activates a view.
        /// </summary>
        /// <param name="view"></param>
        public void Activate(IDockableViewModel view)
        {
            if (view == null)
                return;

            if (viewLookup.ContainsKey(view.DockingPaneName))
            {
                DockableContent content = viewLookup[view.DockingPaneName].Pane;
                if (!content.IsFocused)
                {
                    System.Windows.Input.Keyboard.ClearFocus();
                    content.Focus();
                }
            }
        }

        void content_IsActiveContentChanged(object sender, EventArgs e)
        {
            if (isRestoringLayout)
                return;

            DockableContent content = sender as DockableContent;
            //content.Focus();
            if (content.IsActiveContent)
                OnActivePaneChanged(content.Content as IDockableViewModel, true);

            if (content.ContainerPane != null )
                if (content.ContainerPane.SelectedItem != content)
                {

                }
        }
        void content_StateChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            DockableContent content = sender as DockableContent;
            if (content.State == DockableContentState.Hidden)
            {
                (content.Content as IDockableViewModel).IsDockingPaneVisible = false;

                if (!this.isRestoringLayout && !this.isRemoveInProcess)
                    if (!(content.Content as IDockableViewModel).HideOnClose)
                    {
                        this.CloseWindow(content.Content as IDockableViewModel, true);
                    }
            }
            else
            {
                (content.Content as IDockableViewModel).IsDockingPaneVisible = true;
            }
        }

        /// <summary>
        /// Gets whether the docking manager has a window of a specific name.
        /// </summary>
        /// <param name="name">Name of the window.</param>
        /// <returns>True if there is a window with the specified name. False otherwise.</returns>
        public bool HasWindow(string name)
        {
            if (this.viewLookup.ContainsKey(name))
                return true;

            return false;
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        public void LoadConfiguration()
        {
            this.configuration = new DockingLayoutManagerConfiguration();
            this.configuration.Load(this.SaveConfigurationFilePath);
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfiguration()
        {
            if( this.configuration != null )
                this.configuration.Save(this.SaveConfigurationFilePath);
        }

        /// <summary>
        /// Saves the current window configuration (opened windows).
        /// </summary>
        /// <param name="name">Name of the configuration.</param>
        public void SaveCurrentConfiguration(string name)
        {
            if (this.configuration == null)
                this.LoadConfiguration();

            DockingLayoutContextConfiguration config;
            if (!this.configuration.Configurations.ContainsKey(name))
            {
                config = new DockingLayoutContextConfiguration(name);
                config.LayoutPath = "Layout_" + config.ContextName + ".xml";
                
                this.configuration.AddConfiguration(config);
            }
            else
            {
                config = this.configuration.Configurations[name];
                if( config.LayoutPath == null )
                    config.LayoutPath = "Layout_" + config.ContextName + ".xml";
                config.Configurations.Clear();
            }

            List<DockableContent> excludePanels = new List<DockableContent>();
            foreach(string paneName in this.viewLookup.Keys)
            {
                IDockableViewModel vm = this.viewLookup[paneName].View;

                if (vm is IContextableDockableViewModel)
                {
                    IContextableDockableViewModel cVM = vm as IContextableDockableViewModel;
                    if (!String.IsNullOrEmpty(cVM.ModelContextName))
                        if (cVM.ModelContextName != name)
                        {
                            excludePanels.Add(this.viewLookup[paneName].Pane);
                            continue;
                        }
                }

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

            SaveCurrentLayout(SaveLayoutDirectory + Path.DirectorySeparatorChar + config.LayoutPath, excludePanels);
        }

        /// <summary>
        /// Loads a specific window configuration.
        /// </summary>
        /// <param name="name">Name of the configuration.</param>
        /// <param name="dockableViews">Existing dockable views.</param>
        public void RestoreConfiguration(string name, IEnumerable dockableViews)
        {
            this.isRestoringLayout = true;

            if (this.configuration == null)
                this.LoadConfiguration();

            if (!this.configuration.Configurations.ContainsKey(name))
            {
                // restore default layout
                RestoreDefaultWindows(dockableViews, name);
                RestoreDefaultLayout(name);
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
                        IDockableViewModel p = existingPanes[n];
                        if (!this.viewLookup.ContainsKey(p.DockingPaneName))
                            ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle);
                    }
                }

                // restore layout
                LoadLayout(SaveLayoutDirectory + Path.DirectorySeparatorChar + config.LayoutPath, name);
            }

            this.isRestoringLayout = false;

            // call initialize on opened view models
            foreach (ViewLookUp v in viewLookup.Values)
                if (v.View.IsDockingPaneVisible)
                {
                    if (!v.View.IsInitialized)
                        v.View.InitializeVM();

                    if (v.View is IRibbonDockableViewModel && this.Ribbon != null)
                        if (!((IRibbonDockableViewModel)v.View).IsRibbonMenuInitialized)
                        {
                            ((IRibbonDockableViewModel)v.View).CreateRibbonMenu(this.Ribbon);
                        }
                }
        }
 
        /// <summary>
        /// Loads a specific window configuration.
        /// </summary>
        /// <param name="name">Name of the configuration.</param>
        /// <param name="dockableViews">Existing dockable views.</param>
        public void RestoreConfigurationWindows(string name, IEnumerable dockableViews)
        {
            this.isRestoringLayout = true;
            if (this.configuration == null)
            {
                this.LoadConfiguration();
            }

            if (!this.configuration.Configurations.ContainsKey(name))
            {
                // restore default layout
                RestoreDefaultWindows(dockableViews, name);
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
                    {
                        this.OnRestoreLayoutMissingVMEncountered(config.Configurations[n]);

                    }
                    else
                    {

                        IDockableViewModel p = existingPanes[n];
                        if (!this.viewLookup.ContainsKey(p.DockingPaneName))
                            ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle);

                    }
                }
            }

            this.isRestoringLayout = false;
        }

        /// <summary>
        /// Loads a specific window configuration.
        /// </summary>
        /// <param name="name">Name of the configuration.</param>
        /// <param name="dockableViews">Existing dockable views.</param>
        public void RestoreConfigurationLayout(string name, IEnumerable dockableViews)
        {
            this.isRestoringLayout = true;

            if (this.configuration == null)
                this.LoadConfiguration();

            if (!this.configuration.Configurations.ContainsKey(name))
            {
                // restore default layout
                RestoreDefaultLayout(name);
            }
            else
            {
                DockingLayoutContextConfiguration config = this.configuration.Configurations[name];
                // restore layout
                LoadLayout(SaveLayoutDirectory + Path.DirectorySeparatorChar + config.LayoutPath, name);
            }

            this.isRestoringLayout = false;

            // call initialize on opened view models
            foreach (ViewLookUp v in viewLookup.Values)
                if (v.View.IsDockingPaneVisible)
                {
                    if (!v.View.IsInitialized)
                        v.View.InitializeVM();

                    if (v.View is IRibbonDockableViewModel && this.Ribbon != null)
                        if (!((IRibbonDockableViewModel)v.View).IsRibbonMenuInitialized)
                        {
                            ((IRibbonDockableViewModel)v.View).CreateRibbonMenu(this.Ribbon);
                        }
                }
        }
 
        private void SaveCurrentLayout(string path, List<DockableContent> excludePanels)
        {
            if (MainDockingManager.IsLoaded)
            {
                // Save layout
                MainDockingManager.SaveLayoutAdvanced(path, excludePanels);
            }
        }
        private void LoadLayout(string path, string contextName)
        {
            // restore layout
            isRestoringLayout = true;

            if (System.IO.File.Exists(path))
            {
                try
                {
                    MainDockingManager.RestoreLayout(path);
                }
                catch
                {
                    RestoreDefaultLayout(contextName);
                }
            }
            else
                RestoreDefaultLayout(contextName);

            isRestoringLayout = false;

            // select first docking window as active
            if (this.viewLookup.Keys.Count > 0)
                this.viewLookup[this.viewLookup.Keys.ElementAt(0)].Pane.Activate();
        }
        private void RestoreDefaultLayout(string name)
        {
            string path = this.SaveLayoutDirectory + Path.DirectorySeparatorChar + "DefaultLayout_" + name + ".xml";
            if (!File.Exists(path))
                RestoreDefaultLayouts();

            // try to load the default layout, if we encounter some error
            try
            {
                // save embedded layout file to SaveDockingPanesFilePath
                MainDockingManager.RestoreLayout(path);
                /*using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(this.EmbeddedLayoutFilePath)))
                {
                    MainDockingManager.RestoreLayout(reader);
                    /*
                    using (StreamWriter writer = File.CreateText(SaveLayoutFilePath))
                    {

                        while (reader.Peek() >= 0)
                        {
                            string line = reader.ReadLine().Trim();
                            if (!String.IsNullOrEmpty(line))
                                writer.WriteLine(line);
                        }
                    }
                }*/
                //MainDockingManager.RestoreLayout(SaveLayoutFilePath);
            }
            catch
            { }
        }
        private void RestoreDefaultLayouts()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(this.EmbeddedLayoutFilePath)))
            {
                try
                {
                    XDocument doc = XDocument.Load(reader);
                    XElement e = doc.Element("DefaultLayouts");
                    foreach (XElement node in e.Elements("DefaultLayout"))
                    {
                        string name = node.Attribute("name").Value;
                        XElement child = node.Elements().ElementAt(0);
                        child.Save(this.SaveLayoutDirectory + Path.DirectorySeparatorChar + "DefaultLayout_" + name + ".xml");
                    }
                }
                catch
                {
                }
            }
        }
        private void RestoreDefaultWindows(IEnumerable dockableViews, string currentCntxName)
        {
            Assembly assembly = Assembly.GetEntryAssembly();

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
                                    if (!this.viewLookup.ContainsKey(p.DockingPaneName))
                                        ShowWindow(p, p.DockingPaneStyle, p.DockingPaneAnchorStyle);
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

        /// <summary>
        /// Delegate for the PaneClosedEvent event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PaneClosedEventHandler(object sender, PaneClosedEventArgs e);

        /// <summary>
        /// Pane closed event.
        /// </summary>
        public event PaneClosedEventHandler PaneClosedEvent;

        /// <summary>
        /// Called whenever a pane has been closed (not hidden !).
        /// </summary>
        /// <param name="dockableViewModel"></param>
        protected void OnPaneClosed(IDockableViewModel dockableViewModel)
        {
            if (PaneClosedEvent != null)
            {
                PaneClosedEvent(this,
                   new PaneClosedEventArgs()
                   {
                       DockableViewModel = dockableViewModel
                   }
                );
            }
        }

        /// <summary>
        /// Delegate for the ActivePaneChanged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ActivePaneChangedEventHandler(object sender, ActivePaneChangedEventArgs e);

        /// <summary>
        /// Active pane changed event.
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
                if (this.mainDockingManager != null)
                    this.mainDockingManager.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// Converts a DockingPaneAnchorStyle to AnchorStyle.
        /// </summary>
        /// <param name="style">DockingPaneAnchorStyle to convert.</param>
        /// <returns>AnchorStyle.</returns>
        public static AnchorStyle ConvertToAnchorStyle(DockingPaneAnchorStyle style)
        {
            switch (style)
            {
                case DockingPaneAnchorStyle.Bottom:
                    return AnchorStyle.Bottom;

                case DockingPaneAnchorStyle.Left:
                    return AnchorStyle.Left;

                case DockingPaneAnchorStyle.Right:
                    return AnchorStyle.Right;

                case DockingPaneAnchorStyle.Top:
                    return AnchorStyle.Top;

                case DockingPaneAnchorStyle.None:
                default:
                    return AnchorStyle.None;
            }
        }

        /// <summary>
        /// Converts a DockingContextChangeKind to ContextChangeKind.
        /// </summary>
        /// <param name="kind">DockingContextChangeKind to convert.</param>
        /// <returns>ContextChangeKind.</returns>
        public static ContextChangeKind ConvertToContextChangeKind(DockingContextChangeKind kind)
        {
            switch (kind)
            {
                case DockingContextChangeKind.PreviewMouseUp:
                    return ContextChangeKind.PreviewMouseUp;

                case DockingContextChangeKind.PreviewMouseDown:
                default:
                    return ContextChangeKind.PreviewMouseDown;

            }
        }
        
        /// <summary>
        /// Gets the parent object of the type DockablePane or DocumentPane starting with the start dependency object.
        /// </summary>
        /// <param name="startObject">Dependency object to start the search from.</param>
        /// <returns>Parent of the specified type if found. Null otherwise.</returns>
        private DependencyObject GetParentFromVisualTree(DependencyObject startObject)
        {
            //Walk the visual tree to get the parent of this control
            DependencyObject parent = startObject;
            while (parent != null)
            {
                if (parent is DocumentPane)
                    break;
                else if (parent is DockablePane)
                    break;
                else
                    parent = VisualTreeHelper.GetParent(parent);
            }

            return parent;
        }

        /// <summary>
        /// Invalidates the titles of all docking panes.
        /// </summary>
        public void InvalidatePaneTitles()
        {
            foreach(string name in viewLookup.Keys)
            {
                IDockableViewModel vm = viewLookup[name].View;
                viewLookup[name].Pane.Title = vm.DockingPaneTitle;
            }
        }
    }
}

// © 2009 Rick Strahl. All rights reserved. 
// See http://wpflocalization.codeplex.com for related whitepaper and updates
// See http://wpfclientguidance.codeplex.com for other WPF resources

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Visualization.Properties;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Localization
{
    /// <summary>
    /// This class holds static configuration values that should
    /// be set once (or be auto-loaded once) for the application
    /// 
    /// This object becomes a static property on the ResExtension
    /// instance.
    /// </summary>
    public class LocalizationSettings : INotifyPropertyChanged
    {
        /// <summary>
        /// Global singleton instance of configuration settings
        /// </summary>
        public static LocalizationSettings Current
        {
            get
            {
                return _Current;
            }
            set
            {
                _Current = value;
            }
        }
        private static LocalizationSettings _Current = new LocalizationSettings();


        /// <summary>
        /// The default resource manager used.
        /// </summary>        
        public ResourceManager DefaultResourceManager { get; set; }


        /// <summary>
        /// The Assembly from which resources are loaded
        /// </summary>
        public Assembly DefaultResourceAssembly { get; set; }

        /// <summary>
        /// Gets or sets the CheckForCultureChange property.
        /// </summary>
        public bool CheckForCultureChange { get; set; }

        /// <summary>
        /// Hold flow direction that can be bound to dynamically:
        /// FlowDirection="{Binding Source={x:Static res:LocalizationSettings.Current},Path=FlowDirection}"  
        /// </summary>
        public FlowDirection FlowDirection
        {
            get { return _FlowDirection; }
            set
            {
                _FlowDirection = value;
                RaisePropertyChanged("FlowDirection");
            }
        }
        private FlowDirection _FlowDirection = FlowDirection.LeftToRight;

        /// <summary>
        /// Allows adding an assembly to the internal lookup list of assemblies 
        /// that can be accessed for binding. 
        /// 
        /// This method allows preloading of the assembly as opposed to when
        /// the markup extension tries to find it.
        /// </summary>
        /// <param name="assemblyName"></param>
        public static Assembly AddAssembly(string assemblyName)
        {
            return AddAssembly(assemblyName, assemblyName);
        }

        /// <summary>
        /// Allows you to directly add an assembly to the internal assembly
        /// lookup list.
        /// This method allows preloading of the assembly as opposed to when
        /// the markup extension tries to find it.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Assembly AddAssembly(string assemblyName, Assembly assembly)
        {
            AssemblyList[assemblyName] = assembly;
            return assembly;
        }

        /// <summary>
        /// Allows adding an assembly to the list of assemblies that is
        /// used for lookup up resources. This version allows 
        /// </summary>
        /// <param name="assemblyId"></param>
        /// <param name="assemblyName"></param>
        public static Assembly AddAssembly(string assemblyId, string assemblyName)
        {
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies()
                     .Where(asm => asm.GetName().Name == assemblyName || asm.FullName == assemblyName)
                     .FirstOrDefault();

            if (assembly == null)
                throw new ArgumentException(Resources.InvalidAssemblyExceptionMessage);


            AssemblyList[assemblyId] = assembly;
            return assembly;
        }



        internal static Hashtable AssemblyList = new Hashtable();

        /// <summary>
        /// Allows triggering of culture changes to rebind any active
        /// bindings.
        /// </summary>
        public CultureInfo CurrentCulture
        {
            get { return _CurrentCulture; }
            set
            {
                _CurrentCulture = value;
                FlowDirection = _CurrentCulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                this.OnCultureChanged();
                this.RaisePropertyChanged("CurrentCulture");
            }
        }
        private CultureInfo _CurrentCulture = CultureInfo.CurrentUICulture;

        /// <summary>
        /// Initialization.
        /// </summary>
        /// <param name="resourceAssembly"></param>
        /// <param name="manager"></param>
        public static void Initialize(Assembly resourceAssembly, ResourceManager manager)
        {
            LocalizationSettings.Current.DefaultResourceManager = manager;
            LocalizationSettings.Current.DefaultResourceAssembly = resourceAssembly;
        }

        /// <summary>
        /// Culture changed event.
        /// </summary>
        public event Action CultureChanged;

        /// <summary>
        /// On culture changed.
        /// </summary>
        protected void OnCultureChanged()
        {
            if (this.CultureChanged != null)
                this.CultureChanged();
        }



        /// <summary>
        /// Cached ResourceManagers for each ResourceSet supported requested.       
        /// </summary>
        internal Dictionary<string, ResourceManager> ResourceManagers = new Dictionary<string, ResourceManager>();

        private LocalizationSettings()
        {
            this.CheckForCultureChange = false;
        }

        /// <summary>
        /// Retrieves a resource manager for the appropriate ResourceSet
        /// By default the 'global' Resource
        /// </summary>
        /// <param name="resourceSet"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static ResourceManager GetResourceManager(string resourceSet, string assembly)
        {
            // If we passed an assembly on the extension we have to look it up/load it
            // if the default resource assembly is not set - try to guess where to load it
            // from - this matters primarily at design time, otherwise
            // LocalizationSettings.Initialize() should be called from App.xaml.cs
            //if (assembly != null || LocalizationSettings.Current.DefaultResourceAssembly == null)
            //this.FindDefaultResourceAssembly();

            if (string.IsNullOrEmpty(resourceSet))
                return LocalizationSettings.Current.DefaultResourceManager ?? null;

            if (LocalizationSettings.Current.ResourceManagers.ContainsKey(resourceSet))
                return LocalizationSettings.Current.ResourceManagers[resourceSet];

            // Can't load without a resource assembly
            if (LocalizationSettings.Current.DefaultResourceAssembly == null)
                return null;

            ResourceManager man = new ResourceManager(resourceSet,
                                          LocalizationSettings.Current.DefaultResourceAssembly);
            LocalizationSettings.Current.ResourceManagers.Add(resourceSet, man);
            man.GetString("");
            return man;
        }

        /// <summary>
        /// Gets the resource manager.
        /// </summary>
        /// <param name="resourceSet"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static ResourceManager GetResourceManager(string resourceSet, Assembly assembly)
        {
            if (string.IsNullOrEmpty(resourceSet))
                return LocalizationSettings.Current.DefaultResourceManager ?? null;

            if (LocalizationSettings.Current.ResourceManagers.ContainsKey(resourceSet))
                return LocalizationSettings.Current.ResourceManagers[resourceSet];

            ResourceManager man = new ResourceManager(resourceSet, assembly);
            LocalizationSettings.Current.ResourceManagers.Add(resourceSet, man);
            man.GetString("");
            return man;
        }

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

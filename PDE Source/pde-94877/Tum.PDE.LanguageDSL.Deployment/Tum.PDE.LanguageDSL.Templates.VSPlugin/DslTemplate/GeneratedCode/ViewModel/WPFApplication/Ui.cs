 
using DslEditorContracts = Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using DslEditorPopups   = Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Popups;
using DslEditorServices = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorCommands = Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorDiagramSurface = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

using WPFRibbon = Fluent;

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows.Controls;

using Tum.PDE.ModelingDSL.ViewModel;

namespace Tum.PDE.ModelingDSL.View
{
	/// <summary>
    /// This class is used as a base class for the main window of the editor.
    /// </summary>
	public abstract class DslPluginMainControl : UserControl
	{
		/// <summary>
        /// PDEModelingDSL Modeling document data.
        /// </summary>
        protected global::Tum.PDE.ModelingDSL.PDEModelingDSLDocumentData DocData = null;
		
        /// <summary>
        /// PDEModelingDSL Main view model.
        /// </summary>
        protected PDEModelingDSLMainViewModel ViewModel = null;		

		/*
        /// <summary>
        /// Imported plugins which suffice to the IPlugin interface.
        /// </summary>
		[ImportMany(typeof(DslEditorContracts::IPlugin))]
        public System.Collections.Generic.List<DslEditorContracts::IPlugin> SimplePlugins { get; set; }

		/// <summary>
        /// Imported plugins which suffice to the IPlugin interface.
        /// </summary>
		[ImportMany(typeof(DslEditorContracts::IModelPlugin))]
        public System.Collections.Generic.List<DslEditorContracts::IModelPlugin> SimpleModelPlugins { get; set; }
	
		/// <summary>
        /// Imported plugins which suffice to the IViewModelPlugin interface.
        /// </summary>
        [ImportMany(typeof(DslEditorContracts::IViewModelPlugin))]
        public System.Collections.Generic.List<DslEditorContracts::IViewModelPlugin> ViewModelPlugins { get; set; }
		*/
	
        /// <summary>
        /// Plugins directory.
        /// </summary>
        public const string PluginsDirectory = "plugins";

		/// <summary>
        /// Constructor.
        /// </summary>
		public DslPluginMainControl()
		{        
			
		}
		
		/// <summary>
        /// Sets view model.
        /// </summary>
        /// <param name="viewModel">VM.</param>
		public virtual void SetViewModel(Tum.PDE.ModelingDSL.ViewModel.PDEModelingDSLMainViewModel viewModel)
		{
			try
            {           
				this.ViewModel = viewModel;
                this.DataContext = viewModel;

            	viewModel.Ribbon = this.Ribbon;
				viewModel.RestoreLayout();
			}
			catch (System.Exception ex)
            {
				System.Windows.MessageBox.Show("Error during initialization: " + ex.Message);
			}
			
			// Register known windows
			DslEditorServices::IUIVisualizerService popupVisualizer = ViewModel.GlobalServiceProvider.Resolve<DslEditorServices::IUIVisualizerService>();				
			popupVisualizer.TryRegister("SelectElementPopup", typeof(DslEditorPopups::SelectElementPopup));
			popupVisualizer.TryRegister("DeleteElementsPopup", typeof(DslEditorPopups::DeleteElementsPopup));				
			popupVisualizer.TryRegister("SelectElementWithRSTypePopup", typeof(DslEditorPopups::SelectElementWithRSTypePopup));
			popupVisualizer.TryRegister("SelectRSTypePopup", typeof(DslEditorPopups::SelectRSTypePopup));
				
			/*
            try
            {
                // load plugins
                LoadPlugins();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show("Error during plugin loading: " + ex.Message);
            }*/
		}
		
		/*
		/// <summary>
        /// Load plugins.
        /// </summary>
		public virtual void LoadPlugins()
		{
			try
            {
				string path = Assembly.GetAssembly(this.GetType()).Location;
                string dir = new System.IO.FileInfo(path).Directory.FullName;

                string fullDir = dir + System.IO.Path.DirectorySeparatorChar + PluginsDirectory;


				// Load plugins
                if (!System.IO.Directory.Exists(fullDir))
                    System.IO.Directory.CreateDirectory(fullDir);

                DirectoryCatalog directoryCatalog = new DirectoryCatalog(fullDir);
				CompositionContainer container = new CompositionContainer(directoryCatalog);
            	container.ComposeParts(this);
				
				if( SimplePlugins.Count > 0 )
				{
					foreach(DslEditorContracts::IPlugin plugin in SimplePlugins)
						foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM in ViewModel.AvailableModelModelContextViewModels)
						{
							if( plugin.ModelContext == mcVM.ModelContext.Name || plugin.ModelContext == null)
								mcVM.AddPlugin(plugin);
						}				
				}
				
				if( SimpleModelPlugins.Count > 0 )
				{
					foreach(DslEditorContracts::IModelPlugin plugin in SimpleModelPlugins)
						foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM in ViewModel.AvailableModelModelContextViewModels)
						{
							if( plugin.ModelContext == mcVM.ModelContext.Name || plugin.ModelContext == null)
								mcVM.AddPlugin(plugin);
								
							plugin.SetViewModelStore(ViewModel.ViewModelStore);
						}				
				}
				
				if( ViewModelPlugins.Count > 0 )
				{
					foreach(DslEditorContracts::IViewModelPlugin plugin in ViewModelPlugins)
					{
						try
						{
							DslEditorDiagramSurface::BaseDiagramSurfaceViewModel vm = plugin.GetViewModel(ViewModel.ViewModelStore);
							if( vm != null )
							{
								foreach (Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelContextViewModel mcVM in ViewModel.AvailableModelModelContextViewModels)
                                    if (plugin.ModelContext == null)
                                        mcVM.AddPluginViewModel(vm);
                                    else if( plugin.ModelContext == mcVM.ModelContext.Name)
                                        mcVM.AddPluginViewModel(vm);
								
								System.Windows.ResourceDictionary dictionary = plugin.GetViewModelRessourceDictionary();
								if( dictionary != null )
								{
									System.Windows.Application.Current.Resources.BeginInit();
						            System.Windows.Application.Current.Resources.MergedDictionaries.Add(dictionary);
            						System.Windows.Application.Current.Resources.EndInit();
								}
							}
						}
						catch (System.Exception ex)
            			{
                			System.Windows.MessageBox.Show(ex.Message);
            			}
					}
				}
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
		}
		*/

		/// <summary>
        /// Gets the WPF ribbon instance.
        /// </summary>
		public abstract WPFRibbon::Ribbon Ribbon{ get; }
		
        /// <summary>
        /// Clean up.
        /// </summary>
        public virtual void Dispose()
        {
			this.DataContext = null;
		
            if (this.ViewModel != null)
            {
                // Unregister known windows
				/*
                DslEditorServices::IUIVisualizerService popupVisualizer = ViewModel.GlobalServiceProvider.Resolve<DslEditorServices::IUIVisualizerService>();
                popupVisualizer.Unregister("SelectElementPopup");
                popupVisualizer.Unregister("DeleteElementsPopup");
                popupVisualizer.Unregister("SelectElementWithRSTypePopup");
                popupVisualizer.Unregister("SelectRSTypePopup");*/

                this.ViewModel.Dispose();
            }
		}		
	}
}

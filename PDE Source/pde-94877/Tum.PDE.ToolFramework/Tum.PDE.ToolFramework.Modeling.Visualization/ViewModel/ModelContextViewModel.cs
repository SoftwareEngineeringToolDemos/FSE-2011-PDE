using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This is a view model for a model context.
    /// </summary>
    public class ModelContextViewModel : BaseViewModel
    {
        #region Fields
        private bool isSelected = false;

        private ModelContext modelContext;
        private BaseMainViewModel mainViewModel;

        private string modelTitle = null;
        private string editorTitle = "DslEditor";

        private List<BaseDiagramSurfaceViewModel> allDiagramSurfaceModels = null;
        private List<BaseDiagramSurfaceViewModel> additionalDiagramSurfaceModels = null;
        private List<BaseDiagramSurfaceViewModel> pluginDiagramSurfaceModels = null;
        private BaseDiagramSurfaceViewModel mainDiagramSurfaceModel = null;
        
        private DelegateCommand<IPlugin> executePluginCommand = null;
        private List<IPlugin> contextPlugins = new List<IPlugin>();

        private DelegateCommand selectModelContextCommand = null;
        #endregion

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Hosted model context.</param>
        /// <param name="mainViewModel">Main view model.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelContextViewModel(ViewModelStore viewModelStore, ModelContext modelContext, BaseMainViewModel mainViewModel)
            : base(viewModelStore, false)
        {
            this.modelContext = modelContext;
            this.mainViewModel = mainViewModel;

            this.selectModelContextCommand = new DelegateCommand(SelectModelContextCommand_Executed);

            this.PreInitialize();

            if (modelContext != null)
            {
                this.modelContext.DocumentClosed += new EventHandler(ModelContext_DocumentClosed);
                this.modelContext.DocumentLoaded += new EventHandler(ModelContext_DocumentLoaded);
                this.modelContext.DocumentReloaded += new EventHandler(ModelContext_DocumentLoaded);
            }

            this.executePluginCommand = new DelegateCommand<IPlugin>(ExecutePluginCommandExecuted);
        }

        /// <summary>
        /// Gets the selectModelContextCommand.
        /// </summary>
        public DelegateCommand SelectModelContextCommand
        {
            get
            {
                return this.selectModelContextCommand;
            }
        }
        private void SelectModelContextCommand_Executed()
        {
            this.IsSelected = true;
        }

        void ModelContext_DocumentLoaded(object sender, EventArgs e)
        {
            OnDocumentLoaded();
        }
        void ModelContext_DocumentClosed(object sender, EventArgs e)
        {
            OnDocumentClosed();
        }

        /// <summary>
        /// Gets the hosted contexts titel.
        /// </summary>
        public string Titel
        {
            get
            {
                return this.modelContext.Titel;
            }
        }

        /// <summary>
        /// Gets or sets the isSelected property.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
                if (this.IsSelected)
                    this.MainViewModel.SelectedModelContextViewModel = this;
                OnPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Gets the hosted model context.
        /// </summary>
        public ModelContext ModelContext
        {
            get
            {
                return this.modelContext;
            }
        }

        /// <summary>
        /// Gets the MainViewModel this vm belongs to.
        /// </summary>
        public BaseMainViewModel MainViewModel
        {
            get
            {
                return this.mainViewModel;
            }
        }
        
        /// <summary>
        /// Gets the window title.
        /// </summary>
        public string WindowTitle
        {
            get
            {
                if (ModelTitle != null)
                    return ModelTitle + " - " + EditorTitle;
                else
                    return EditorTitle;
            }
        }

        /// <summary>
        /// Gets the editor title.
        /// </summary>
        public string EditorTitle
        {
            get { return editorTitle; }
            set
            {
                this.editorTitle = value;
                OnPropertyChanged("EditorTitle");

            }
        }

        /// <summary>
        /// Gets the current model title.
        /// </summary>
        public string ModelTitle
        {
            get { return this.modelTitle; }
        }

        /// <summary>
        /// Gets or sets the view model used for the default diagram surface.
        /// </summary>
        public BaseDiagramSurfaceViewModel DiagramSurfaceModel
        {
            get { return this.mainDiagramSurfaceModel; }
            set { this.mainDiagramSurfaceModel = value; }
        }

        /// <summary>
        /// Gets all diagram surface view models.
        /// </summary>
        public ReadOnlyCollection<BaseDiagramSurfaceViewModel> AllDiagramSurfaceModels
        {
            get { return this.allDiagramSurfaceModels.AsReadOnly(); }
        }

        /// <summary>
        /// Gets additional diagram surface view models.
        /// </summary>
        public ReadOnlyCollection<BaseDiagramSurfaceViewModel> AdditionalDiagramSurfaceModels
        {
            get { return this.additionalDiagramSurfaceModels.AsReadOnly(); }
        }

        /// <summary>
        /// Gets diagram surface view model that were supplied as plugins.
        /// </summary>
        public ReadOnlyCollection<BaseDiagramSurfaceViewModel> PluginDiagramSurfaceModels
        {
            get { return this.pluginDiagramSurfaceModels.AsReadOnly(); }
        }
        
        /// <summary>
        /// Gets wether there are additional diagam surface view models or not.
        /// </summary>
        public bool HasAdditionalDiagramSurfaceModels
        {
            get
            {
                if (this.AdditionalDiagramSurfaceModels == null)
                    return false;

                if (this.AdditionalDiagramSurfaceModels.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Gets wether there are diagam surface view models that were provided as plugins or not.
        /// </summary>
        public bool HasPluginDiagramSurfaceModels
        {
            get
            {
                if (this.PluginDiagramSurfaceModels == null)
                    return false;

                if (this.PluginDiagramSurfaceModels.Count == 0)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Gets wether there are diagam surface view models that were provided as plugins or not.
        /// </summary>
        public bool HasPlugins
        {
            get
            {
                if (this.Plugins == null)
                    return false;

                if (this.Plugins.Count == 0)
                    return false;

                return true;
            }
        }
        
        /// <summary>
        /// Gets the context plugins.
        /// </summary>
        public List<IPlugin> Plugins
        {
            get
            {
                return this.contextPlugins;
            }
        }

        /// <summary>
        /// Gets the execute plugin command.
        /// </summary>
        public DelegateCommand<IPlugin> ExecutePluginCommand
        {
            get
            {
                return this.executePluginCommand;
            }
        }

        /// <summary>
        /// Adds a view model as a child model of this view model.
        /// </summary>
        /// <param name="viewModel">View model to add to the children collection.</param>
        public void AddAdditionalViewModel(BaseDiagramSurfaceViewModel viewModel)
        {
            this.allDiagramSurfaceModels.Add(viewModel);
            this.additionalDiagramSurfaceModels.Add(viewModel);

            this.MainViewModel.AddViewModel(viewModel);
        }

        /// <summary>
        /// Adds a view model as a child model of this view model.
        /// </summary>
        /// <param name="viewModel">View model to add to the children collection.</param>
        public void AddPluginViewModel(BaseDiagramSurfaceViewModel viewModel)
        {
            this.allDiagramSurfaceModels.Add(viewModel);
            this.pluginDiagramSurfaceModels.Add(viewModel);

            this.MainViewModel.AddViewModel(viewModel);

            if (this == this.MainViewModel.SelectedModelContextViewModel)
            {
                this.MainViewModel.ShowPluginIfShownBefore(viewModel);

            }

            this.OnPropertyChanged("PluginDiagramSurfaceModels");
            this.OnPropertyChanged("HasPluginDiagramSurfaceModels");
        }

        /// <summary>
        /// Adds a plugin to this context.
        /// </summary>
        /// <param name="plugin">Plugin to add to this context</param>
        public void AddPlugin(IPlugin plugin)
        {
            if (!Plugins.Contains(plugin))
                Plugins.Add(plugin);

            OnPropertyChanged("Plugins");
            OnPropertyChanged("HasPlugins");
        }

        /// <summary>
        /// Executes a plugins command.
        /// </summary>
        /// <param name="plugin">Plugin</param>
        private void ExecutePluginCommandExecuted(IPlugin plugin)
        {
            plugin.Execute(this.ModelData);
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected virtual void PreInitialize()
        {
            this.allDiagramSurfaceModels = new List<BaseDiagramSurfaceViewModel>();
            this.additionalDiagramSurfaceModels = new List<BaseDiagramSurfaceViewModel>();
            this.pluginDiagramSurfaceModels = new List<BaseDiagramSurfaceViewModel>();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        private bool isMCInitialized = false;
        
        /// <summary>
        /// Initialization.
        /// </summary>
        public void InitializeMC()
        {
            if (isMCInitialized)
                return;

            Initialize();
        }
        
        /// <summary>
        /// Reset ressources.
        /// </summary>
        public virtual void Reset()
        {
            modelTitle = null;

            OnPropertyChanged("WindowTitle");
            if (this.MainViewModel != null)
                this.MainViewModel.WindowTitle = WindowTitle;
        }
        
        /// <summary>
        /// Called whenever a document is loaded in this context.
        /// </summary>
        public virtual void OnDocumentLoaded()
        {
            //string path = this.ViewModelStore.GetDomainModelServices(this.ModelContext.RootElement).ElementParentProvider.GetDomainModelFilePath(this.ModelContext.RootElement);
            if ((this.ModelContext.RootElement as IParentModelElement) != null)
            {
                string path = (this.ModelContext.RootElement as IParentModelElement).DomainFilePath;
                if (path != null)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                    modelTitle = fileInfo.Name;
                }
                else
                    modelTitle = null;
            }
            else
                modelTitle = null;

            OnPropertyChanged("WindowTitle"); 
            if (this.MainViewModel != null)
                this.MainViewModel.WindowTitle = WindowTitle;

            /*
            if (this.MainViewModel.ActiveViewModel != null)
            {
                this.MainViewModel.ActiveViewModel.OnDocumentLoaded();
            }*/
        }

        /// <summary>
        /// Called whenever a document is closed in this context.
        /// </summary>
        public virtual void OnDocumentClosed()
        {
            modelTitle = null;

            OnPropertyChanged("WindowTitle");
            if (this.MainViewModel != null)
                this.MainViewModel.WindowTitle = WindowTitle;

            if (this.MainViewModel.ActiveViewModel == null)
                return;

            if (this.MainViewModel.ActiveViewModel.IsDisposed)
                return;

            if( this.MainViewModel.ActiveViewModel.UndoCommand != null )
                this.MainViewModel.ActiveViewModel.UndoCommand.RaiseCanExecuteChanged();

            if (this.MainViewModel.ActiveViewModel.RedoCommand != null)
                this.MainViewModel.ActiveViewModel.RedoCommand.RaiseCanExecuteChanged();
            /*
            if (this.MainViewModel.ActiveViewModel != null)
            {
                this.MainViewModel.ActiveViewModel.OnDocumentClosed();
            }*/
        }

        /// <summary>
        /// This method is called when the model context becomes active.
        /// </summary>
        public virtual void OnActivated()
        {
            OnPropertyChanged("AdditionalDiagramSurfaceModels");
            OnPropertyChanged("PluginDiagramSurfaceModels");

            foreach (BaseDiagramSurfaceViewModel vm in this.AdditionalDiagramSurfaceModels)
                vm.IsDockingPaneVisible = vm.IsDockingPaneVisible;

            foreach (BaseDiagramSurfaceViewModel vm in this.PluginDiagramSurfaceModels)
                vm.IsDockingPaneVisible = vm.IsDockingPaneVisible;
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.modelContext != null)
            {
                this.modelContext.DocumentClosed -= new EventHandler(ModelContext_DocumentClosed);
                this.modelContext.DocumentLoaded -= new EventHandler(ModelContext_DocumentLoaded);
                this.modelContext.DocumentReloaded -= new EventHandler(ModelContext_DocumentLoaded);
            }

            base.OnDispose();

        }

    }
}

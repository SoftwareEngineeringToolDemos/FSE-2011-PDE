using System;
using System.Windows;

using Tum.PDE.ToolFramework.Modeling.Diagrams;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// This is the base abstract class for a diagram surface implementation, which can either be based on the default 
    /// diagram model or be provided by the used.
    /// </summary>
    public abstract class BaseDiagramSurfaceViewModel : BaseDockingViewModel, IDropTarget, IContextableDockableViewModel, IPluginHosterViewModel
    {
        private SelectedItemsCollection selectedItemsCollection = null;
        private Diagram diagram = null;
        private string modelContextName;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Model context.</param>
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, ModelContext modelContext)
            : this(viewModelStore, null, modelContext)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Model context.</param>
        /// <param name="bCallIntialize"></param>
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, ModelContext modelContext, bool bCallIntialize)
            : this(viewModelStore, null, modelContext, bCallIntialize)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContextName">Model context name.</param>
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, string modelContextName)
            : this(viewModelStore, null, modelContextName, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContextName">Model context name.</param>  
        /// <param name="bCallIntialize"></param>
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, string modelContextName, bool bCallIntialize)
            : this(viewModelStore, null, modelContextName, bCallIntialize)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">Diagram.</param>
        /// <param name="modelContext">Model context.</param>
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext)
            : this(viewModelStore, diagram, modelContext.Name, true)
        {
            this.modelContextName = modelContext.Name;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">Diagram.</param>
        /// <param name="modelContext">Model context.</param>
        /// <param name="bCallIntialize"></param>
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext, bool bCallIntialize)
            : this(viewModelStore, diagram, modelContext.Name, bCallIntialize)
        {
            this.modelContextName = modelContext.Name;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>   
        /// <param name="diagram">Diagram.</param>
        /// <param name="modelContextName">Model context name.</param>
        /// <param name="bCallIntialize"></param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        protected BaseDiagramSurfaceViewModel(ViewModelStore viewModelStore, Diagram diagram, string modelContextName, bool bCallIntialize)
            : base(viewModelStore, false)
        {
            if (String.IsNullOrEmpty(modelContextName))
                this.modelContextName = null;
            else
                this.modelContextName = modelContextName;

            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));

            if (bCallIntialize)
            {
                //Initialize();
                PreInitialize();
            }
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public string ModelContextName
        {
            get
            {
                return this.modelContextName;
            }
        }

        /// <summary>
        /// Gets or set the diagram that is hosted by this view model.
        /// </summary>
        public virtual Diagram Diagram
        {
            get
            {
                return this.diagram;
            }
            set
            {
                this.diagram = value;
            }
        }

        /// <summary>
        /// Gets the selected model elements collection.
        /// </summary>
        public SelectedItemsCollection SelectedItemsCollection
        {
            get
            {
                return this.selectedItemsCollection;
            }
        }

        /// <summary>
        /// Gets whether this view model is visible or not.
        /// </summary>
        public virtual bool IsDiagramDesignerViewModelVisible
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected virtual void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            this.selectedItemsCollection = eventArgs.SelectedItems;
        }
                       
        /// <summary>
        /// Resets the current view.
        /// </summary>
        protected virtual void Reset()
        {
        }

        /// <summary>
        /// Called whenever this view model needs to reset itself.
        /// </summary>
        protected override void OnReset()
        {
            Reset();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            Reset();

            base.OnDispose();
        }

        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public virtual void DragOver(DropInfo dropInfo)
        {
            dropInfo.Effects = DragDropEffects.None;
        }

        /// <summary>
        /// Drop logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public virtual void Drop(DropInfo dropInfo)
        {

        }

        /// <summary>
        /// Gets or sets the vm plugin data.
        /// </summary>
        public Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.IViewModelPlugin VMPlugin
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether this vm is a VM plugin.
        /// </summary>
        public bool IsVMPlugin
        {
            get
            {
                return this.VMPlugin != null;
            }
        }

        /// <summary>
        /// True if the vmplugin has a resource dictionary.
        /// </summary>
        public bool VMPluginHasDictionary
        {
            get
            {
                if (!this.IsVMPlugin)
                    return false;

                if (this.VMPlugin.GetViewModelRessourceDictionary() != null)
                    return true;

                return false;
            }
        }

        private bool vMPluginDictionaryInitialized = false;

        /// <summary>
        /// Gets or sets whether the vm plugin dictionary has been initialized.
        /// </summary>
        public bool VMPluginDictionaryInitialized
        {
            get
            {
                return vMPluginDictionaryInitialized;
            }
            set
            {
                this.vMPluginDictionaryInitialized = value;
            }
        }
    }
}

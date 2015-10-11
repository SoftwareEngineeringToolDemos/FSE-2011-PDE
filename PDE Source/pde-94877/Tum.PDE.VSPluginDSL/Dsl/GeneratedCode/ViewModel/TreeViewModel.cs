 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorViewModelEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorTreeViewModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorViewModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel;
using DslEditorViewModelContracts = global::Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using DslEditorViewModelDeletion = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Deletion;
using DslEditorViewModelServices = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using DslEditorViewModelDependencies = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies;

namespace Tum.PDE.VSPluginDSL.ViewModel.ModelTree
{
	/// <summary>
    /// Context menu provider used to process and create additional menu items.
	///
    /// This is the double generated class for easier customization.	
    /// </summary>
	public class VSPluginDSLModelTreeContextMenuProvider : VSPluginDSLModelTreeContextMenuProviderBase
	{
		#region Singleton Instance
		private static VSPluginDSLModelTreeContextMenuProvider contextMenuProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLModelTreeContextMenuProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( contextMenuProvider == null )
				{
					contextMenuProvider = new VSPluginDSLModelTreeContextMenuProvider();
				}
				
				return contextMenuProvider;
            }
        }
		
		private VSPluginDSLModelTreeContextMenuProvider() : base()
		{
		}
		#endregion
	}

	/// <summary>
    /// Context menu provider used to process and create additional menu items.
	///
    /// This is the base abstract class.	
    /// </summary>
	public class VSPluginDSLModelTreeContextMenuProviderBase : DslEditorTreeViewModel::ModelTreeContextMenuProvider
	{

		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VSPluginDSLModelTreeContextMenuProviderBase() : base()
		{
			// add injectred context menu provider
		}
		#endregion
		#region Methods
	    /// <summary>
        /// Modify the context menu view model by adding custom menu items.
        /// </summary>
        /// <param name="contextMenu">Context menu view model containing automatically added menu items.</param>
        /// <param name="element">Host element.</param>
        public override void ProcessContextMenu(DslEditorMenuModel::MenuItemViewModel contextMenu, DslEditorTreeViewModel::ModelElementTreeViewModel element, System.Collections.Generic.List<DslEditorViewModelContracts::IModelTreeContextMenuProvider> processedProviders)
        {
			base.ProcessContextMenu(contextMenu, element, processedProviders);
			
			if(	element.Element is global::Tum.PDE.VSPluginDSL.DomainClass2	)
			{
				DslEditorMenuModel::MenuItemViewModel openModalVMs = this.FindMenuViewModel(contextMenu, "OpenModalViewsFromModelTreeId");
				if( openModalVMs == null )
				{
					openModalVMs = new DslEditorMenuModel::MenuItemViewModel(contextMenu.ViewModelStore);
					openModalVMs.Text = "Open";
					openModalVMs.UserData = "OpenModalViewsFromModelTreeId";
				
					contextMenu.Children.Insert(0, openModalVMs);
					contextMenu.Children.Insert(1, new DslEditorMenuModel::SeparatorMenuItemViewModel(contextMenu.ViewModelStore));
				}				
			
				if( element.Element is global::Tum.PDE.VSPluginDSL.DomainClass2 )
				{
					DslEditorMenuModel::MenuItemViewModel<DslEditorTreeViewModel::ModelElementTreeViewModel> openVM = new DslEditorMenuModel::MenuItemViewModel<DslEditorTreeViewModel::ModelElementTreeViewModel>(contextMenu.ViewModelStore);
                	openVM.Text = "Open " + "Modal View";
                	openVM.Command = new DslEditorCommands::DelegateCommand<DslEditorTreeViewModel::ModelElementTreeViewModel>(OpenModalDiagramTemplate);
					openVM.CommandParameter = element;

                	openModalVMs.Children.Add(openVM);
				}

			}
        }
		
		/// <summary>
		/// Opens the view model for the ModalDiagramTemplate.
		/// </summary>
		/// <param name="treeVM">Tree vm executing this command.</param>
		public virtual void OpenModalDiagramTemplate(DslEditorTreeViewModel::ModelElementTreeViewModel treeVM)
		{
			VSPluginDSLModalDiagramTemplateSurfaceViewModel vm = new VSPluginDSLModalDiagramTemplateSurfaceViewModel(treeVM.ViewModelStore, treeVM.Element as DslEditorModeling::DomainModelElement);
		
			DslEditorViewModelEvents::OpenViewModelEventArgs args = new DslEditorViewModelEvents::OpenViewModelEventArgs(vm);
			args.DockingPaneStyle = Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DockingPaneStyle.DockedInDocumentPane;
            treeVM.EventManager.GetEvent<DslEditorViewModelEvents::OpenViewModelEvent>().Publish(args);
 
		}
		#endregion	
			
	}
	
	/// <summary>
    /// Model Tree sorting provider.
    /// 
    /// This is the double generated class for easier customization.
    /// </summary>
	public partial class VSPluginDSLModelTreeSortingProvider : VSPluginDSLModelTreeSortingProviderBase
	{
		#region Singleton Instance
		private static VSPluginDSLModelTreeSortingProvider sortingProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLModelTreeSortingProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( sortingProvider == null )
				{
					sortingProvider = new VSPluginDSLModelTreeSortingProvider();
				}
				
				return sortingProvider;
            }
        }
		
		private VSPluginDSLModelTreeSortingProvider()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// Model Tree sorting provider.
    /// 
    /// This is the abstract base class.
    /// </summary>
	public abstract class VSPluginDSLModelTreeSortingProviderBase : DslEditorTreeViewModel::ModelTreeSortingProvider
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VSPluginDSLModelTreeSortingProviderBase()
		{
		}
		#endregion
	}	
}
namespace Tum.PDE.VSPluginDSL.ViewModel.ModelTree
{
	/// <summary>
    /// Tree view model for the tree view.
	///
	/// This is the double generated class for easier customization.
    /// </summary>
	public partial class ModelTreeVSPluginDSLViewModel : DslEditorTreeViewModel::ModelElementTreeViewModel
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="viewModelStore">View model store containing this view model.</param>
		/// <param name="element">Element represented by this view model.</param>
		/// <param name="link">Element link, targeting the hosted element.</param>
		/// <param name="domainRoleId">Domain role id of the role that the hosted element belongs to.</param>
		/// <param name="parent">Parent of this view model.</param>
		/// <param name="bHookUpEvents">Hook up into model events to update the created view model on changes in model if true.</param>
		/// <param name="bCreateContextMenus">Creates context menus for adding and deleting model elements if true.</param>
		/// <param name="mainModelTreeVm">Model tree view model, this element vm belongs to.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public ModelTreeVSPluginDSLViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslModeling::ModelElement element, DslModeling::ElementLink link, System.Guid domainRoleId, DslEditorTreeViewModel::ModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, DslEditorViewModel::MainModelTreeViewModel mainModelTreeVm) 
			: base(viewModelStore, element, link, domainRoleId, parent, bHookUpEvents, bCreateContextMenus, mainModelTreeVm)
		{
		}
		
		/// <summary>
        /// Gets whether elements can be moved within the tree or not.
        /// </summary>
        public override bool CanMoveElements
        {
            get
            {
                return false;
            }
        }
		
				/// <summary>
        /// Gets the sorting provider which is to be used to apply a specific sorting order while inserting new elements into the children collection.
        /// </summary>
        public override DslEditorViewModelContracts::IModelTreeSortingProvider SortingProvider
		{ 
			get
			{
				return VSPluginDSLModelTreeSortingProvider.Instance;
			}
		}
		
        /// <summary>
        /// Gets or sets the global context menu provider.
        /// </summary>
        public override DslEditorViewModelContracts::IModelTreeContextMenuProvider ContextMenuProvider 
		{ 
			get
			{
				return VSPluginDSLModelTreeContextMenuProvider.Instance;
			}
		}
	}
}


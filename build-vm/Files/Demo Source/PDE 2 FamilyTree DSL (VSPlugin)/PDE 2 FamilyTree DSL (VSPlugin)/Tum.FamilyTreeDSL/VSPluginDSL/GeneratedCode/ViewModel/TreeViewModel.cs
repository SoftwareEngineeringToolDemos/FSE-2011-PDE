 
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

namespace Tum.FamilyTreeDSL.ViewModel.ModelTree
{
	/// <summary>
    /// Context menu provider used to process and create additional menu items.
	///
    /// This is the double generated class for easier customization.	
    /// </summary>
	public class FamilyTreeDSLModelTreeContextMenuProvider : FamilyTreeDSLModelTreeContextMenuProviderBase
	{
		#region Singleton Instance
		private static FamilyTreeDSLModelTreeContextMenuProvider contextMenuProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static FamilyTreeDSLModelTreeContextMenuProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( contextMenuProvider == null )
				{
					contextMenuProvider = new FamilyTreeDSLModelTreeContextMenuProvider();
				}
				
				return contextMenuProvider;
            }
        }
		
		private FamilyTreeDSLModelTreeContextMenuProvider() : base()
		{
		}
		#endregion
	}

	/// <summary>
    /// Context menu provider used to process and create additional menu items.
	///
    /// This is the base abstract class.	
    /// </summary>
	public class FamilyTreeDSLModelTreeContextMenuProviderBase : DslEditorTreeViewModel::ModelTreeContextMenuProvider
	{

		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected FamilyTreeDSLModelTreeContextMenuProviderBase() : base()
		{
			// add injectred context menu provider
		}
		#endregion
			
	}
	
	/// <summary>
    /// Model Tree sorting provider.
    /// 
    /// This is the double generated class for easier customization.
    /// </summary>
	public partial class FamilyTreeDSLModelTreeSortingProvider : FamilyTreeDSLModelTreeSortingProviderBase
	{
		#region Singleton Instance
		private static FamilyTreeDSLModelTreeSortingProvider sortingProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static FamilyTreeDSLModelTreeSortingProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( sortingProvider == null )
				{
					sortingProvider = new FamilyTreeDSLModelTreeSortingProvider();
				}
				
				return sortingProvider;
            }
        }
		
		private FamilyTreeDSLModelTreeSortingProvider()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// Model Tree sorting provider.
    /// 
    /// This is the abstract base class.
    /// </summary>
	public abstract class FamilyTreeDSLModelTreeSortingProviderBase : DslEditorTreeViewModel::ModelTreeSortingProvider
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected FamilyTreeDSLModelTreeSortingProviderBase()
		{
		}
		#endregion
	}	
}
namespace Tum.FamilyTreeDSL.ViewModel.ModelTree
{
	/// <summary>
    /// Tree view model for the tree view.
	///
	/// This is the double generated class for easier customization.
    /// </summary>
	public partial class ModelTreeFamilyTreeDSLViewModel : DslEditorTreeViewModel::ModelElementTreeViewModel
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
		public ModelTreeFamilyTreeDSLViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslModeling::ModelElement element, DslModeling::ElementLink link, System.Guid domainRoleId, DslEditorTreeViewModel::ModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, DslEditorViewModel::MainModelTreeViewModel mainModelTreeVm) 
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
				return FamilyTreeDSLModelTreeSortingProvider.Instance;
			}
		}
		
        /// <summary>
        /// Gets or sets the global context menu provider.
        /// </summary>
        public override DslEditorViewModelContracts::IModelTreeContextMenuProvider ContextMenuProvider 
		{ 
			get
			{
				return FamilyTreeDSLModelTreeContextMenuProvider.Instance;
			}
		}
	}
}


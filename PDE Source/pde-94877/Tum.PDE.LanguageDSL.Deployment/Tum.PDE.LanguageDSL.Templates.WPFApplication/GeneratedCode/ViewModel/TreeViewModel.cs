 
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

namespace Tum.VModellXT.ViewModel.ModelTree
{
	/// <summary>
    /// Context menu provider used to process and create additional menu items.
	///
    /// This is the double generated class for easier customization.	
    /// </summary>
	public class VModellXTModelTreeContextMenuProvider : VModellXTModelTreeContextMenuProviderBase
	{
		#region Singleton Instance
		private static VModellXTModelTreeContextMenuProvider contextMenuProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTModelTreeContextMenuProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( contextMenuProvider == null )
				{
					contextMenuProvider = new VModellXTModelTreeContextMenuProvider();
				}
				
				return contextMenuProvider;
            }
        }
		
		private VModellXTModelTreeContextMenuProvider() : base()
		{
		}
		#endregion
	}

	/// <summary>
    /// Context menu provider used to process and create additional menu items.
	///
    /// This is the base abstract class.	
    /// </summary>
	public class VModellXTModelTreeContextMenuProviderBase : DslEditorTreeViewModel::ModelTreeContextMenuProvider
	{

		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VModellXTModelTreeContextMenuProviderBase() : base()
		{
			// add injectred context menu provider
			this.AddInjectedInContextMenuProvider(Tum.VModellXT.Basis.ViewModel.ModelTree.VModellXTBasisModelTreeContextMenuProvider.Instance);	
			this.AddInjectedInContextMenuProvider(Tum.VModellXT.Statik.ViewModel.ModelTree.VModellXTStatikModelTreeContextMenuProvider.Instance);	
			this.AddInjectedInContextMenuProvider(Tum.VModellXT.Dynamik.ViewModel.ModelTree.VModellXTDynamikModelTreeContextMenuProvider.Instance);	
			this.AddInjectedInContextMenuProvider(Tum.VModellXT.Anpassung.ViewModel.ModelTree.VModellXTAnpassungModelTreeContextMenuProvider.Instance);	
			this.AddInjectedInContextMenuProvider(Tum.VModellXT.Konventionsabbildungen.ViewModel.ModelTree.VModellXTKonventionsabbildungenModelTreeContextMenuProvider.Instance);	
			this.AddInjectedInContextMenuProvider(Tum.VModellXT.Aenderungsoperationen.ViewModel.ModelTree.VModellXTAenderungesoperationenModelTreeContextMenuProvider.Instance);	
		}
		#endregion
			
	}
	
	/// <summary>
    /// Model Tree sorting provider.
    /// 
    /// This is the double generated class for easier customization.
    /// </summary>
	public partial class VModellXTModelTreeSortingProvider : VModellXTModelTreeSortingProviderBase
	{
		#region Singleton Instance
		private static VModellXTModelTreeSortingProvider sortingProvider = null;
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VModellXTModelTreeSortingProvider Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
                if( sortingProvider == null )
				{
					sortingProvider = new VModellXTModelTreeSortingProvider();
				}
				
				return sortingProvider;
            }
        }
		
		private VModellXTModelTreeSortingProvider()
		{
		}
        #endregion
	}
	
	/// <summary>
    /// Model Tree sorting provider.
    /// 
    /// This is the abstract base class.
    /// </summary>
	public abstract class VModellXTModelTreeSortingProviderBase : DslEditorTreeViewModel::ModelTreeSortingProvider
	{
		#region Constructor
		/// <summary>
        /// Constructor.
        /// </summary>
		protected VModellXTModelTreeSortingProviderBase()
		{
			this.ModelTreeSortingState = DslEditorTreeViewModel::ModelTreeSortingState.None;
		}
		#endregion

		#region Methods
		        /// <summary>
        /// Method used to add a element into a sorted collection without destroying the sorting order.
        /// </summary>
        /// <param name="typeIndex">Index in the collection at which the link type's elements start.</param>
        /// <param name="collection">Sorted collection to add the new view models to.</param>
        /// <param name="link">Embedding relationship including the model element as the child (target).</param>
        /// <param name="c">View model representing the model element to be added to the collection.</param>
        protected virtual void InsertElement(int typeIndex, DslEditorTreeViewModel::BaseModelElementTreeViewModel parent, System.Collections.ObjectModel.ObservableCollection<DslEditorTreeViewModel::BaseModelElementTreeViewModel> collection, DslModeling::ElementLink link, DslEditorTreeViewModel::BaseModelElementTreeViewModel c)
        {
            System.Collections.ObjectModel.ReadOnlyCollection<DslModeling::ElementLink> lllinks = DslModeling::DomainRoleInfo.GetElementLinks<DslModeling::ElementLink>(parent.Element, DslEditorModeling::DomainModelElement.GetSourceDomainRole(link.GetDomainRelationship()).Id);
            int indexOfLink = lllinks.IndexOf(link) + typeIndex;
            if (indexOfLink >= collection.Count)
                collection.Add(c);
            else
                collection.Insert(indexOfLink, c);
        }

		/// <summary>
        /// Method used to add a element into a sorted collection without destroying the sorting order.
        /// </summary>
        /// <param name="collection">Sorted collection to add the new view models to.</param>
        /// <param name="link">Embedding relationship including the model element as the child (target).</param>
        /// <param name="c">View model representing the model element to be added to the collection.</param>
        public override void InsertElement(DslEditorTreeViewModel::BaseModelElementTreeViewModel parent, System.Collections.ObjectModel.ObservableCollection<DslEditorTreeViewModel::BaseModelElementTreeViewModel> collection, DslModeling::ElementLink link, DslEditorTreeViewModel::BaseModelElementTreeViewModel c)
        {
            if (parent.ElementLinkOrder.Count <= 1)
                InsertElement(0, parent, collection, link, c);
            else
            {
                int index = 0;
                System.Collections.Generic.List<System.Guid> typesBeforeCurrent = new System.Collections.Generic.List<System.Guid>();
                System.Guid currentType = c.ElementLinkDomainClassId;
                for (int i = 0; i < parent.ElementLinkOrder.Count; i++)
                    if (parent.ElementLinkOrder[i] == currentType)
                    {
                        index = i;
                        break;
                    }
                    else
                        typesBeforeCurrent.Add(parent.ElementLinkOrder[i]);

                if (index > 0)
                {
                    for (int i = 0; i < collection.Count; i++)
                    {
                        if (typesBeforeCurrent.Contains(collection[i].ElementLinkDomainClassId))
                            continue;

                        InsertElement(i, parent, collection, link, c);
                        return;
                    }
                    InsertElement(collection.Count, parent, collection, link, c);
                    return;
                }
                InsertElement(index, parent, collection, link, c);
			}
        }
		#endregion
		
	}	
}
namespace Tum.VModellXT.ViewModel.ModelTree
{
	/// <summary>
    /// Tree view model for the tree view.
	///
	/// This is the double generated class for easier customization.
    /// </summary>
	public partial class ModelTreeVModellXTViewModel : DslEditorTreeViewModel::ModelElementTreeViewModel
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
		public ModelTreeVModellXTViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslModeling::ModelElement element, DslModeling::ElementLink link, System.Guid domainRoleId, DslEditorTreeViewModel::ModelElementTreeViewModel parent, bool bHookUpEvents, bool bCreateContextMenus, DslEditorViewModel::MainModelTreeViewModel mainModelTreeVm) 
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
                return true;
            }
        }
		
				/// <summary>
        /// Gets the sorting provider which is to be used to apply a specific sorting order while inserting new elements into the children collection.
        /// </summary>
        public override DslEditorViewModelContracts::IModelTreeSortingProvider SortingProvider
		{ 
			get
			{
				return VModellXTModelTreeSortingProvider.Instance;
			}
		}
		
        /// <summary>
        /// Gets or sets the global context menu provider.
        /// </summary>
        public override DslEditorViewModelContracts::IModelTreeContextMenuProvider ContextMenuProvider 
		{ 
			get
			{
				return VModellXTModelTreeContextMenuProvider.Instance;
			}
		}
	}
}


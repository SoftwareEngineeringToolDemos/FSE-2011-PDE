 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorViewDiagrams = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface;
using DslEditorMenuModel = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using DslEditorCommands = global::Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using DslEditorEvents = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using DslEditorViewModelData = global::Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL.ViewModel
{
	/// <summary>
    /// View model for StateShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class StateShapeDiagramItemViewModel : StateShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public StateShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for StateShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class StateShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected StateShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
		
		#region Methods
        /// <summary>
        /// Gets whether this view model can have nested children or not.
        /// </summary>
        public override bool CanHaveNestedChildren 
		{ 
			get
			{
				return false;
			}
		}

        /// <summary>
        /// Gets whether this view model can have relative children or not.
        /// </summary>
        public override bool CanHaveRelativeChildren
		{ 
			get
			{
			
				return false;
			}
		}
		
        #endregion			

		#region Properties
        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        /// <remarks>
		/// Items need to delete their hosted element if they are themselves not directly hosted
		/// on the diagram's surface.
		/// </remarks>
        public override bool AutomaticallyDeletesHostedElement 
        {
            get
            {

				return false;
            }
        }		
		#endregion
		
	}
	
	/// <summary>
    /// View model for StartStateShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class StartStateShapeDiagramItemViewModel : StartStateShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public StartStateShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for StartStateShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class StartStateShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected StartStateShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
		
		#region Methods
        /// <summary>
        /// Gets whether this view model can have nested children or not.
        /// </summary>
        public override bool CanHaveNestedChildren 
		{ 
			get
			{
				return false;
			}
		}

        /// <summary>
        /// Gets whether this view model can have relative children or not.
        /// </summary>
        public override bool CanHaveRelativeChildren
		{ 
			get
			{
			
				return false;
			}
		}
		
        #endregion			

		#region Properties
        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        /// <remarks>
		/// Items need to delete their hosted element if they are themselves not directly hosted
		/// on the diagram's surface.
		/// </remarks>
        public override bool AutomaticallyDeletesHostedElement 
        {
            get
            {

				return false;
            }
        }		
		#endregion
		
	}
	
	/// <summary>
    /// View model for EndStateShape.
	///
	/// Double-derived class to allow easier code customization.
    /// </summary>
	public partial class EndStateShapeDiagramItemViewModel : EndStateShapeDiagramItemViewModelBase
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        public EndStateShapeDiagramItemViewModel(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
	}

	/// <summary>
    /// View model for EndStateShape.
	///
	/// This is the abstract base class.
    /// </summary>
	public partial class EndStateShapeDiagramItemViewModelBase : DslEditorViewDiagrams::DiagramItemElementViewModel
	{
		#region Constructor
		/// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="diagram">The Diagram this item belongs to.</param>
        /// <param name="shapeElement">Model element, that is hosted by this view model.</param>
        protected EndStateShapeDiagramItemViewModelBase(DslEditorViewModelData::ViewModelStore viewModelStore, DslEditorViewDiagrams::DiagramSurfaceViewModel diagram, DslEditorDiagrams::NodeShape shapeElement)
            : base(viewModelStore, diagram, shapeElement)
        {
        }
		#endregion
		
		#region Methods
        /// <summary>
        /// Gets whether this view model can have nested children or not.
        /// </summary>
        public override bool CanHaveNestedChildren 
		{ 
			get
			{
				return false;
			}
		}

        /// <summary>
        /// Gets whether this view model can have relative children or not.
        /// </summary>
        public override bool CanHaveRelativeChildren
		{ 
			get
			{
			
				return false;
			}
		}
		
        #endregion			

		#region Properties
        /// <summary>
        /// False if this item view model is directly hosted on the diagram surface and its shape can be deleted
        /// whithout the hosted model element beeing required to be deleted as well. True otherwise.
        /// </summary>
        /// <remarks>
		/// Items need to delete their hosted element if they are themselves not directly hosted
		/// on the diagram's surface.
		/// </remarks>
        public override bool AutomaticallyDeletesHostedElement 
        {
            get
            {

				return false;
            }
        }		
		#endregion
		
	}
	
}

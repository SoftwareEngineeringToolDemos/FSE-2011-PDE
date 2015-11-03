 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainClass StateMachineDomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModel.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModel.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel))]
	[DslModeling::DomainObjectId("711c0880-75fd-4e1e-af60-c319032f2d08")]
	public partial class StateMachineDomainModel : DslEditorModeling::DomainModelElement, DslEditorModeling::IParentModelElement   
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// StateMachineDomainModel domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("711c0880-75fd-4e1e-af60-c319032f2d08");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public StateMachineDomainModel(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public StateMachineDomainModel(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region State opposite domain role accessor
		
		/// <summary>
		/// Gets a list of State.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<State> State
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<State>, State>(global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId);
			}
		}
		#endregion
		#region StartState opposite domain role accessor
		/// <summary>
		/// Gets or sets StartState.
		/// </summary>
		public virtual StartState StartState
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId) as StartState;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId, value);
			}
		}
		#endregion
		#region EndState opposite domain role accessor
		/// <summary>
		/// Gets or sets EndState.
		/// </summary>
		public virtual EndState EndState
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId) as EndState;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId, value);
			}
		}
		#endregion
		#region IModelMergeElements
		#endregion
		#region DomainFilePath
		/// <summary>
		/// Gets or sets the domain file path.
		/// </summary>
		public string DomainFilePath{ get; set; }
		#endregion
		#region IDomainModelOwnable
		/*
	 	/// <summary>
	    /// Gets the document data
	    /// </summary>
	    public override DslEditorModeling::ModelData DocumentData
	    {
	        get
			{
				return global::Tum.StateMachineDSL.StateMachineLanguageDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId;
		}	
	
	    /// <summary>
	    /// Gets or sets the value of the property (which is marked as element name)
	    /// </summary>
	    public override string DomainElementName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
		
	    /// <summary>
	    /// Gets whether the domain element has a property marked as element name.
	    /// </summary>
	    public override bool DomainElementHasName 
	    {
			get
			{
				return false;
			}
	    }	
		
	    /// <summary>
	    /// Gets the domain element name info if there is one; Null otherwise.
	    /// </summary>
	    public override DslModeling::DomainPropertyInfo DomainElementNameInfo
	    {
			get
			{
				return null;
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "StateMachineDomainModel";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "State Machine Domain Model";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.StateMachineDSL.StateMachineDomainModel.DomainClassId;
	    }
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainClass StateBase
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateBase.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateBase.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel))]
	[DslModeling::DomainObjectId("19afe24e-b335-4ddc-9a4d-87e0afa439b3")]
	public abstract partial class StateBase : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// StateBase domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("19afe24e-b335-4ddc-9a4d-87e0afa439b3");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected StateBase(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region StateBaseTarget opposite domain role accessor
		
		/// <summary>
		/// Gets a list of StateBaseTarget.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<StateBase> StateBaseTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<StateBase>, StateBase>(global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId);
			}
		}
		#endregion
		#region StateBaseSource opposite domain role accessor
		
		/// <summary>
		/// Gets a list of StateBaseSource.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<StateBase> StateBaseSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<StateBase>, StateBase>(global::Tum.StateMachineDSL.Transition.StateBaseTargetDomainRoleId);
			}
		}
		#endregion
		#region IModelMergeElements
		#endregion
		#region IDomainModelOwnable
		/*
	 	/// <summary>
	    /// Gets the document data
	    /// </summary>
	    public override DslEditorModeling::ModelData DocumentData
	    {
	        get
			{
				return global::Tum.StateMachineDSL.StateMachineLanguageDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId;
		}	
	
	    /// <summary>
	    /// Gets or sets the value of the property (which is marked as element name)
	    /// </summary>
	    public override string DomainElementName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
		
	    /// <summary>
	    /// Gets whether the domain element has a property marked as element name.
	    /// </summary>
	    public override bool DomainElementHasName 
	    {
			get
			{
				return false;
			}
	    }	
		
	    /// <summary>
	    /// Gets the domain element name info if there is one; Null otherwise.
	    /// </summary>
	    public override DslModeling::DomainPropertyInfo DomainElementNameInfo
	    {
			get
			{
				return null;
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "StateBase";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "State Base";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.StateMachineDSL.StateBase.DomainClassId;
	    }
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainClass State
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.State.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.State.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("50e3fb61-bd3d-4d87-b951-2161e67d5685")]
	public partial class State : global::Tum.StateMachineDSL.StateBase 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// State domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("50e3fb61-bd3d-4d87-b951-2161e67d5685");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public State(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public State(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("477bacb3-72f6-4ffb-8468-42fbf5ee9cec") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.State/Name.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.State/Name.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("477bacb3-72f6-4ffb-8468-42fbf5ee9cec")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the State.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<State, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the State.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the State.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(State element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(State element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region StateMachineDomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets StateMachineDomainModel.
		/// </summary>
		public virtual StateMachineDomainModel StateMachineDomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateDomainRoleId) as StateMachineDomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateDomainRoleId, value);
			}
		}
		#endregion
		#region IModelMergeElements
		#endregion
		#region IDomainModelOwnable
		/*
	 	/// <summary>
	    /// Gets the document data
	    /// </summary>
	    public override DslEditorModeling::ModelData DocumentData
	    {
	        get
			{
				return global::Tum.StateMachineDSL.StateMachineLanguageDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId;
		}	
	
	    /// <summary>
	    /// Gets or sets the value of the property (which is marked as element name)
	    /// </summary>
	    public override string DomainElementName
		{
			get
			{
				return this.Name;
			}
			set
			{
				this.Name = value;
			}
		}
		
	    /// <summary>
	    /// Gets whether the domain element has a property marked as element name.
	    /// </summary>
	    public override bool DomainElementHasName 
	    {
			get
			{
				return true;
			}
	    }	
		
	    /// <summary>
	    /// Gets the domain element name info if there is one; Null otherwise.
	    /// </summary>
	    public override DslModeling::DomainPropertyInfo DomainElementNameInfo
	    {
			get
			{
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.StateMachineDSL.State.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "State";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "State";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.StateMachineDSL.State.DomainClassId;
	    }
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainClass StartState
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StartState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StartState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel))]
	[DslModeling::DomainObjectId("2d02bccc-7fc9-424e-a732-679b8bde54e5")]
	public partial class StartState : global::Tum.StateMachineDSL.StateBase 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// StartState domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("2d02bccc-7fc9-424e-a732-679b8bde54e5");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public StartState(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public StartState(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StateMachineDomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets StateMachineDomainModel.
		/// </summary>
		public virtual StateMachineDomainModel StateMachineDomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StartStateDomainRoleId) as StateMachineDomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StartStateDomainRoleId, value);
			}
		}
		#endregion
		#region IModelMergeElements
		#endregion
		#region IDomainModelOwnable
		/*
	 	/// <summary>
	    /// Gets the document data
	    /// </summary>
	    public override DslEditorModeling::ModelData DocumentData
	    {
	        get
			{
				return global::Tum.StateMachineDSL.StateMachineLanguageDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId;
		}	
	
	    /// <summary>
	    /// Gets or sets the value of the property (which is marked as element name)
	    /// </summary>
	    public override string DomainElementName
		{
			get
			{
				return base.DomainElementName;
			}
			set
			{
				base.DomainElementName = value;
			}
		}
		
	    /// <summary>
	    /// Gets whether the domain element has a property marked as element name.
	    /// </summary>
	    public override bool DomainElementHasName 
	    {
			get
			{
				return base.DomainElementHasName;
			}
	    }	
		
	    /// <summary>
	    /// Gets the domain element name info if there is one; Null otherwise.
	    /// </summary>
	    public override DslModeling::DomainPropertyInfo DomainElementNameInfo
	    {
			get
			{
				return base.DomainElementNameInfo;
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "StartState";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Start State";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.StateMachineDSL.StartState.DomainClassId;
	    }
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainClass EndState
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.EndState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.EndState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel))]
	[DslModeling::DomainObjectId("d8cb27bd-e86e-4f9a-87f3-e824e22f174f")]
	public partial class EndState : global::Tum.StateMachineDSL.StateBase 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// EndState domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("d8cb27bd-e86e-4f9a-87f3-e824e22f174f");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EndState(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EndState(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StateMachineDomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets StateMachineDomainModel.
		/// </summary>
		public virtual StateMachineDomainModel StateMachineDomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.EndStateDomainRoleId) as StateMachineDomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.EndStateDomainRoleId, value);
			}
		}
		#endregion
		#region IModelMergeElements
		#endregion
		#region IDomainModelOwnable
		/*
	 	/// <summary>
	    /// Gets the document data
	    /// </summary>
	    public override DslEditorModeling::ModelData DocumentData
	    {
	        get
			{
				return global::Tum.StateMachineDSL.StateMachineLanguageDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.StateMachineDSL.StateMachineLanguageDomainModel.DomainModelId;
		}	
	
	    /// <summary>
	    /// Gets or sets the value of the property (which is marked as element name)
	    /// </summary>
	    public override string DomainElementName
		{
			get
			{
				return base.DomainElementName;
			}
			set
			{
				base.DomainElementName = value;
			}
		}
		
	    /// <summary>
	    /// Gets whether the domain element has a property marked as element name.
	    /// </summary>
	    public override bool DomainElementHasName 
	    {
			get
			{
				return base.DomainElementHasName;
			}
	    }	
		
	    /// <summary>
	    /// Gets the domain element name info if there is one; Null otherwise.
	    /// </summary>
	    public override DslModeling::DomainPropertyInfo DomainElementNameInfo
	    {
			get
			{
				return base.DomainElementNameInfo;
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "EndState";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "End State";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.StateMachineDSL.EndState.DomainClassId;
	    }
	}
}

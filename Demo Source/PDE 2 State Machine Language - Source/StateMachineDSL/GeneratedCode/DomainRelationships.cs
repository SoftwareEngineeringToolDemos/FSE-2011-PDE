 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainRelationship StateMachineDomainModelHasState
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("c4982a3d-9bfb-4d86-b3a1-064975706d2c")]
	public partial class StateMachineDomainModelHasState : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// StateMachineDomainModelHasState domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("c4982a3d-9bfb-4d86-b3a1-064975706d2c");

				
		/// <summary>
		/// Constructor
		/// Creates a StateMachineDomainModelHasState link in the same Partition as the given StateMachineDomainModel
		/// </summary>
		/// <param name="source">StateMachineDomainModel to use as the source of the relationship.</param>
		/// <param name="target">State to use as the target of the relationship.</param>
		public StateMachineDomainModelHasState(StateMachineDomainModel source, State target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId, source), new DslModeling::RoleAssignment(StateMachineDomainModelHasState.StateDomainRoleId, target)}, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public StateMachineDomainModelHasState(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public StateMachineDomainModelHasState(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public StateMachineDomainModelHasState(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public StateMachineDomainModelHasState(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StateMachineDomainModel domain role code
		
		/// <summary>
		/// StateMachineDomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid StateMachineDomainModelDomainRoleId = new System.Guid("e2a7375e-d3c7-4e77-8d1d-1c09955695ee");
		
		/// <summary>
		/// DomainRole StateMachineDomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasState/StateMachineDomainModel.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasState/StateMachineDomainModel.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "State", PropertyDisplayNameKey="Tum.StateMachineDSL.StateMachineDomainModelHasState/StateMachineDomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("e2a7375e-d3c7-4e77-8d1d-1c09955695ee")]
		public virtual StateMachineDomainModel StateMachineDomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (StateMachineDomainModel)DslModeling::DomainRoleInfo.GetRolePlayer(this, StateMachineDomainModelDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StateMachineDomainModelDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access StateMachineDomainModel of a State
		/// <summary>
		/// Gets StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static StateMachineDomainModel GetStateMachineDomainModel(State element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, StateDomainRoleId) as StateMachineDomainModel;
		}
		
		/// <summary>
		/// Sets StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetStateMachineDomainModel(State element, StateMachineDomainModel newStateMachineDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, StateDomainRoleId, newStateMachineDomainModel);
		}
		#endregion
		#region State domain role code
		
		/// <summary>
		/// State domain role Id.
		/// </summary>
		public static readonly global::System.Guid StateDomainRoleId = new System.Guid("137870ea-548f-430e-823c-11cad8677b19");
		
		/// <summary>
		/// DomainRole State
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasState/State.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasState/State.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "StateMachineDomainModel", PropertyDisplayNameKey="Tum.StateMachineDSL.StateMachineDomainModelHasState/State.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("137870ea-548f-430e-823c-11cad8677b19")]
		public virtual State State
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (State)DslModeling::DomainRoleInfo.GetRolePlayer(this, StateDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StateDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access State of a StateMachineDomainModel
		/// <summary>
		/// Gets a list of State.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<State> GetState(StateMachineDomainModel element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<State>, State>(element, StateMachineDomainModelDomainRoleId);
		}
		#endregion
		#region StateMachineDomainModel link accessor
		/// <summary>
		/// Get the list of StateMachineDomainModelHasState links to a StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> GetLinksToState ( global::Tum.StateMachineDSL.StateMachineDomainModel stateMachineDomainModelInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasState>(stateMachineDomainModelInstance, global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId);
		}
		#endregion
		#region State link accessor
		/// <summary>
		/// Get the StateMachineDomainModelHasState link to a State.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasState GetLinkToStateMachineDomainModel (global::Tum.StateMachineDSL.State stateInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasState>(stateInstance, global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of State not obeyed.");
			if ( links.Count == 0 )
			{
				return null;
			}
			else
			{
				return links[0];
			}
		}
		#endregion
		#region StateMachineDomainModelHasState instance accessors
		
		/// <summary>
		/// Get any StateMachineDomainModelHasState links between a given StateMachineDomainModel and a State.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> GetLinks( global::Tum.StateMachineDSL.StateMachineDomainModel source, global::Tum.StateMachineDSL.State target )
		{
			global::System.Collections.Generic.List<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> outLinks = new global::System.Collections.Generic.List<global::Tum.StateMachineDSL.StateMachineDomainModelHasState>();
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasState>(source, global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.StateMachineDomainModelHasState link in links )
			{
				if ( target.Equals(link.State) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one StateMachineDomainModelHasState link between a given StateMachineDomainModeland a State.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasState GetLink( global::Tum.StateMachineDSL.StateMachineDomainModel source, global::Tum.StateMachineDSL.State target )
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasState>(source, global::Tum.StateMachineDSL.StateMachineDomainModelHasState.StateMachineDomainModelDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.StateMachineDomainModelHasState link in links )
			{
				if ( target.Equals(link.State) )
				{
					return link;
				}
			}
			return null;
		}
		
		#endregion
			
	    /// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
		{		
			return global::Tum.StateMachineDSL.StateMachineDomainModelHasState.DomainClassId;		
		}
	
	    /// <summary>
	    /// Gets whether this is an embedding relationship or not.
	    /// </summary>
	    public override bool IsEmbedding
	    {
	        get
			{
				return true;
			}
	    }
	
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
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
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
	            return "StateMachineDomainModelHasState";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "State Machine Domain Model Has State";
	        }
	    }	
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainRelationship StateMachineDomainModelHasStartState
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasStartState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasStartState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("a33fdef0-aacc-483a-ac49-5aad70ad11e9")]
	public partial class StateMachineDomainModelHasStartState : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// StateMachineDomainModelHasStartState domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a33fdef0-aacc-483a-ac49-5aad70ad11e9");

				
		/// <summary>
		/// Constructor
		/// Creates a StateMachineDomainModelHasStartState link in the same Partition as the given StateMachineDomainModel
		/// </summary>
		/// <param name="source">StateMachineDomainModel to use as the source of the relationship.</param>
		/// <param name="target">StartState to use as the target of the relationship.</param>
		public StateMachineDomainModelHasStartState(StateMachineDomainModel source, StartState target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId, source), new DslModeling::RoleAssignment(StateMachineDomainModelHasStartState.StartStateDomainRoleId, target)}, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public StateMachineDomainModelHasStartState(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public StateMachineDomainModelHasStartState(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public StateMachineDomainModelHasStartState(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public StateMachineDomainModelHasStartState(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StateMachineDomainModel domain role code
		
		/// <summary>
		/// StateMachineDomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid StateMachineDomainModelDomainRoleId = new System.Guid("827e735f-5220-4f4d-9218-268790eee94d");
		
		/// <summary>
		/// DomainRole StateMachineDomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasStartState/StateMachineDomainModel.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasStartState/StateMachineDomainModel.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "StartState", PropertyDisplayNameKey="Tum.StateMachineDSL.StateMachineDomainModelHasStartState/StateMachineDomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("827e735f-5220-4f4d-9218-268790eee94d")]
		public virtual StateMachineDomainModel StateMachineDomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (StateMachineDomainModel)DslModeling::DomainRoleInfo.GetRolePlayer(this, StateMachineDomainModelDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StateMachineDomainModelDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access StateMachineDomainModel of a StartState
		/// <summary>
		/// Gets StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static StateMachineDomainModel GetStateMachineDomainModel(StartState element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, StartStateDomainRoleId) as StateMachineDomainModel;
		}
		
		/// <summary>
		/// Sets StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetStateMachineDomainModel(StartState element, StateMachineDomainModel newStateMachineDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, StartStateDomainRoleId, newStateMachineDomainModel);
		}
		#endregion
		#region StartState domain role code
		
		/// <summary>
		/// StartState domain role Id.
		/// </summary>
		public static readonly global::System.Guid StartStateDomainRoleId = new System.Guid("b964b55e-b056-4f56-ab06-013c4d4013c1");
		
		/// <summary>
		/// DomainRole StartState
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasStartState/StartState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasStartState/StartState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "StateMachineDomainModel", PropertyDisplayNameKey="Tum.StateMachineDSL.StateMachineDomainModelHasStartState/StartState.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("b964b55e-b056-4f56-ab06-013c4d4013c1")]
		public virtual StartState StartState
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (StartState)DslModeling::DomainRoleInfo.GetRolePlayer(this, StartStateDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StartStateDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access StartState of a StateMachineDomainModel
		/// <summary>
		/// Gets StartState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static StartState GetStartState(StateMachineDomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, StateMachineDomainModelDomainRoleId) as StartState;
		}
		
		/// <summary>
		/// Sets StartState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetStartState(StateMachineDomainModel element, StartState newStartState)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, StateMachineDomainModelDomainRoleId, newStartState);
		}
		#endregion
		#region StateMachineDomainModel link accessor
		/// <summary>
		/// Get the StateMachineDomainModelHasStartState link to a StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState GetLinkToStartState (global::Tum.StateMachineDSL.StateMachineDomainModel stateMachineDomainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState>(stateMachineDomainModelInstance, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of StateMachineDomainModel not obeyed.");
			if ( links.Count == 0 )
			{
				return null;
			}
			else
			{
				return links[0];
			}
		}
		#endregion
		#region StartState link accessor
		/// <summary>
		/// Get the StateMachineDomainModelHasStartState link to a StartState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState GetLinkToStateMachineDomainModel (global::Tum.StateMachineDSL.StartState startStateInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState>(startStateInstance, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StartStateDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of StartState not obeyed.");
			if ( links.Count == 0 )
			{
				return null;
			}
			else
			{
				return links[0];
			}
		}
		#endregion
		#region StateMachineDomainModelHasStartState instance accessors
		
		/// <summary>
		/// Get any StateMachineDomainModelHasStartState links between a given StateMachineDomainModel and a StartState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> GetLinks( global::Tum.StateMachineDSL.StateMachineDomainModel source, global::Tum.StateMachineDSL.StartState target )
		{
			global::System.Collections.Generic.List<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> outLinks = new global::System.Collections.Generic.List<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState>();
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState>(source, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState link in links )
			{
				if ( target.Equals(link.StartState) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one StateMachineDomainModelHasStartState link between a given StateMachineDomainModeland a StartState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState GetLink( global::Tum.StateMachineDSL.StateMachineDomainModel source, global::Tum.StateMachineDSL.StartState target )
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState>(source, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState link in links )
			{
				if ( target.Equals(link.StartState) )
				{
					return link;
				}
			}
			return null;
		}
		
		#endregion
			
	    /// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
		{		
			return global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.DomainClassId;		
		}
	
	    /// <summary>
	    /// Gets whether this is an embedding relationship or not.
	    /// </summary>
	    public override bool IsEmbedding
	    {
	        get
			{
				return true;
			}
	    }
	
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
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
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
	            return "StateMachineDomainModelHasStartState";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "State Machine Domain Model Has Start State";
	        }
	    }	
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainRelationship StateMachineDomainModelHasEndState
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasEndState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasEndState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("4b3b4933-75eb-48e4-9d42-a309b7f74a67")]
	public partial class StateMachineDomainModelHasEndState : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// StateMachineDomainModelHasEndState domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("4b3b4933-75eb-48e4-9d42-a309b7f74a67");

				
		/// <summary>
		/// Constructor
		/// Creates a StateMachineDomainModelHasEndState link in the same Partition as the given StateMachineDomainModel
		/// </summary>
		/// <param name="source">StateMachineDomainModel to use as the source of the relationship.</param>
		/// <param name="target">EndState to use as the target of the relationship.</param>
		public StateMachineDomainModelHasEndState(StateMachineDomainModel source, EndState target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId, source), new DslModeling::RoleAssignment(StateMachineDomainModelHasEndState.EndStateDomainRoleId, target)}, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public StateMachineDomainModelHasEndState(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public StateMachineDomainModelHasEndState(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public StateMachineDomainModelHasEndState(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public StateMachineDomainModelHasEndState(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StateMachineDomainModel domain role code
		
		/// <summary>
		/// StateMachineDomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid StateMachineDomainModelDomainRoleId = new System.Guid("32a81931-4afa-4ea8-badf-63507e3306b2");
		
		/// <summary>
		/// DomainRole StateMachineDomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasEndState/StateMachineDomainModel.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasEndState/StateMachineDomainModel.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "EndState", PropertyDisplayNameKey="Tum.StateMachineDSL.StateMachineDomainModelHasEndState/StateMachineDomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("32a81931-4afa-4ea8-badf-63507e3306b2")]
		public virtual StateMachineDomainModel StateMachineDomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (StateMachineDomainModel)DslModeling::DomainRoleInfo.GetRolePlayer(this, StateMachineDomainModelDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StateMachineDomainModelDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access StateMachineDomainModel of a EndState
		/// <summary>
		/// Gets StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static StateMachineDomainModel GetStateMachineDomainModel(EndState element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, EndStateDomainRoleId) as StateMachineDomainModel;
		}
		
		/// <summary>
		/// Sets StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetStateMachineDomainModel(EndState element, StateMachineDomainModel newStateMachineDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, EndStateDomainRoleId, newStateMachineDomainModel);
		}
		#endregion
		#region EndState domain role code
		
		/// <summary>
		/// EndState domain role Id.
		/// </summary>
		public static readonly global::System.Guid EndStateDomainRoleId = new System.Guid("2332dd43-bd38-477b-80db-947129ecde2e");
		
		/// <summary>
		/// DomainRole EndState
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.StateMachineDomainModelHasEndState/EndState.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.StateMachineDomainModelHasEndState/EndState.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "StateMachineDomainModel", PropertyDisplayNameKey="Tum.StateMachineDSL.StateMachineDomainModelHasEndState/EndState.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("2332dd43-bd38-477b-80db-947129ecde2e")]
		public virtual EndState EndState
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (EndState)DslModeling::DomainRoleInfo.GetRolePlayer(this, EndStateDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, EndStateDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access EndState of a StateMachineDomainModel
		/// <summary>
		/// Gets EndState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static EndState GetEndState(StateMachineDomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, StateMachineDomainModelDomainRoleId) as EndState;
		}
		
		/// <summary>
		/// Sets EndState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetEndState(StateMachineDomainModel element, EndState newEndState)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, StateMachineDomainModelDomainRoleId, newEndState);
		}
		#endregion
		#region StateMachineDomainModel link accessor
		/// <summary>
		/// Get the StateMachineDomainModelHasEndState link to a StateMachineDomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState GetLinkToEndState (global::Tum.StateMachineDSL.StateMachineDomainModel stateMachineDomainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState>(stateMachineDomainModelInstance, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of StateMachineDomainModel not obeyed.");
			if ( links.Count == 0 )
			{
				return null;
			}
			else
			{
				return links[0];
			}
		}
		#endregion
		#region EndState link accessor
		/// <summary>
		/// Get the StateMachineDomainModelHasEndState link to a EndState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState GetLinkToStateMachineDomainModel (global::Tum.StateMachineDSL.EndState endStateInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState>(endStateInstance, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.EndStateDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of EndState not obeyed.");
			if ( links.Count == 0 )
			{
				return null;
			}
			else
			{
				return links[0];
			}
		}
		#endregion
		#region StateMachineDomainModelHasEndState instance accessors
		
		/// <summary>
		/// Get any StateMachineDomainModelHasEndState links between a given StateMachineDomainModel and a EndState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> GetLinks( global::Tum.StateMachineDSL.StateMachineDomainModel source, global::Tum.StateMachineDSL.EndState target )
		{
			global::System.Collections.Generic.List<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> outLinks = new global::System.Collections.Generic.List<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState>();
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState>(source, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState link in links )
			{
				if ( target.Equals(link.EndState) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one StateMachineDomainModelHasEndState link between a given StateMachineDomainModeland a EndState.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState GetLink( global::Tum.StateMachineDSL.StateMachineDomainModel source, global::Tum.StateMachineDSL.EndState target )
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState>(source, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState link in links )
			{
				if ( target.Equals(link.EndState) )
				{
					return link;
				}
			}
			return null;
		}
		
		#endregion
			
	    /// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
		{		
			return global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.DomainClassId;		
		}
	
	    /// <summary>
	    /// Gets whether this is an embedding relationship or not.
	    /// </summary>
	    public override bool IsEmbedding
	    {
	        get
			{
				return true;
			}
	    }
	
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
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
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
	            return "StateMachineDomainModelHasEndState";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "State Machine Domain Model Has End State";
	        }
	    }	
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
	/// DomainRelationship Transition
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.StateMachineDSL.Transition.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.StateMachineDSL.Transition.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "StateMachineDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("58b1ee23-a4e1-4880-97e7-5a9fdf63ce74")]
	public partial class Transition : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Transition domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("58b1ee23-a4e1-4880-97e7-5a9fdf63ce74");

				
		/// <summary>
		/// Constructor
		/// Creates a Transition link in the same Partition as the given StateBase
		/// </summary>
		/// <param name="source">StateBase to use as the source of the relationship.</param>
		/// <param name="target">StateBase to use as the target of the relationship.</param>
		public Transition(StateBase source, StateBase target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(Transition.StateBaseSourceDomainRoleId, source), new DslModeling::RoleAssignment(Transition.StateBaseTargetDomainRoleId, target)}, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public Transition(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public Transition(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public Transition(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public Transition(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.StateMachineDSL.StateMachineLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StateBaseSource domain role code
		
		/// <summary>
		/// StateBaseSource domain role Id.
		/// </summary>
		public static readonly global::System.Guid StateBaseSourceDomainRoleId = new System.Guid("9c272b02-7cc9-41fd-809b-64bc6a2c7f31");
		
		/// <summary>
		/// DomainRole StateBaseSource
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.Transition/StateBaseSource.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.Transition/StateBaseSource.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "StateBaseTarget", PropertyDisplayNameKey="Tum.StateMachineDSL.Transition/StateBaseSource.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("9c272b02-7cc9-41fd-809b-64bc6a2c7f31")]
		public virtual StateBase StateBaseSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (StateBase)DslModeling::DomainRoleInfo.GetRolePlayer(this, StateBaseSourceDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StateBaseSourceDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access StateBaseSource of a StateBase
		/// <summary>
		/// Gets a list of StateBaseSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<StateBase> GetStateBaseSource(StateBase element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<StateBase>, StateBase>(element, StateBaseTargetDomainRoleId);
		}
		#endregion
		#region StateBaseTarget domain role code
		
		/// <summary>
		/// StateBaseTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid StateBaseTargetDomainRoleId = new System.Guid("2dcc9d60-ff78-46a5-b988-0cd173d7e486");
		
		/// <summary>
		/// DomainRole StateBaseTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.Transition/StateBaseTarget.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.Transition/StateBaseTarget.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "StateBaseSource", PropertyDisplayNameKey="Tum.StateMachineDSL.Transition/StateBaseTarget.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("2dcc9d60-ff78-46a5-b988-0cd173d7e486")]
		public virtual StateBase StateBaseTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (StateBase)DslModeling::DomainRoleInfo.GetRolePlayer(this, StateBaseTargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, StateBaseTargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access StateBaseTarget of a StateBase
		/// <summary>
		/// Gets a list of StateBaseTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<StateBase> GetStateBaseTarget(StateBase element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<StateBase>, StateBase>(element, StateBaseSourceDomainRoleId);
		}
		#endregion
		#region Condition domain property code
		
		/// <summary>
		/// Condition domain property Id.
		/// </summary>
		public static readonly global::System.Guid ConditionDomainPropertyId = new System.Guid("dbfddb7b-7433-4e7f-a6d6-ccf7ede7ad03") ;
		
		/// <summary>
		/// Storage for Condition
		/// </summary>
		private global::System.String conditionPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Condition domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.StateMachineDSL.Transition/Condition.DisplayName", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.StateMachineDSL.Transition/Condition.Description", typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("dbfddb7b-7433-4e7f-a6d6-ccf7ede7ad03")]
		public global::System.String Condition
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return conditionPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				ConditionPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Transition.Condition domain property.
		/// </summary>
		internal sealed partial class ConditionPropertyHandler : DslModeling::DomainPropertyValueHandler<Transition, global::System.String>
		{
			private ConditionPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Transition.Condition domain property value handler.
			/// </summary>
			public static readonly ConditionPropertyHandler Instance = new ConditionPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Transition.Condition domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return ConditionDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(Transition element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.conditionPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Transition element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.conditionPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region StateBaseSource link accessor
		/// <summary>
		/// Get the list of Transition links to a StateBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.Transition> GetLinksToStateBaseTarget ( global::Tum.StateMachineDSL.StateBase stateBaseSourceInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.Transition>(stateBaseSourceInstance, global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId);
		}
		#endregion
		#region StateBaseTarget link accessor
		/// <summary>
		/// Get the list of Transition links to a StateBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.Transition> GetLinksToStateBaseSource ( global::Tum.StateMachineDSL.StateBase stateBaseTargetInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.Transition>(stateBaseTargetInstance, global::Tum.StateMachineDSL.Transition.StateBaseTargetDomainRoleId);
		}
		#endregion
		#region Transition instance accessors
		
		/// <summary>
		/// Get any Transition links between a given StateBase and a StateBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.Transition> GetLinks( global::Tum.StateMachineDSL.StateBase source, global::Tum.StateMachineDSL.StateBase target )
		{
			global::System.Collections.Generic.List<global::Tum.StateMachineDSL.Transition> outLinks = new global::System.Collections.Generic.List<global::Tum.StateMachineDSL.Transition>();
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.Transition> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.Transition>(source, global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.Transition link in links )
			{
				if ( target.Equals(link.StateBaseTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one Transition link between a given StateBaseand a StateBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.StateMachineDSL.Transition GetLink( global::Tum.StateMachineDSL.StateBase source, global::Tum.StateMachineDSL.StateBase target )
		{
			global::System.Collections.Generic.IList<global::Tum.StateMachineDSL.Transition> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.Transition>(source, global::Tum.StateMachineDSL.Transition.StateBaseSourceDomainRoleId);
			foreach ( global::Tum.StateMachineDSL.Transition link in links )
			{
				if ( target.Equals(link.StateBaseTarget) )
				{
					return link;
				}
			}
			return null;
		}
		
		#endregion
			
	    /// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
		{		
			return global::Tum.StateMachineDSL.Transition.DomainClassId;		
		}
	
	    /// <summary>
	    /// Gets whether this is an embedding relationship or not.
	    /// </summary>
	    public override bool IsEmbedding
	    {
	        get
			{
				return false;
			}
	    }
	
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
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.StateMachineDSL.StateMachineLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
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
	            return "Transition";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Transition";
	        }
	    }	
		#endregion
	}
}


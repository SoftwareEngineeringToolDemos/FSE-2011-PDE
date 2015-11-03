 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainRelationship FamilyTreeModelHasFamilyTreePerson
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("7bdb12d9-1a35-4e87-bd6f-e3036f3bc0c6")]
	public partial class FamilyTreeModelHasFamilyTreePerson : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// FamilyTreeModelHasFamilyTreePerson domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("7bdb12d9-1a35-4e87-bd6f-e3036f3bc0c6");

				
		/// <summary>
		/// Constructor
		/// Creates a FamilyTreeModelHasFamilyTreePerson link in the same Partition as the given FamilyTreeModel
		/// </summary>
		/// <param name="source">FamilyTreeModel to use as the source of the relationship.</param>
		/// <param name="target">FamilyTreePerson to use as the target of the relationship.</param>
		public FamilyTreeModelHasFamilyTreePerson(FamilyTreeModel source, FamilyTreePerson target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId, source), new DslModeling::RoleAssignment(FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId, target)}, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public FamilyTreeModelHasFamilyTreePerson(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public FamilyTreeModelHasFamilyTreePerson(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public FamilyTreeModelHasFamilyTreePerson(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public FamilyTreeModelHasFamilyTreePerson(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region FamilyTreeModel domain role code
		
		/// <summary>
		/// FamilyTreeModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid FamilyTreeModelDomainRoleId = new System.Guid("6eeff026-391b-4a93-96e9-860b61c561d0");
		
		/// <summary>
		/// DomainRole FamilyTreeModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson/FamilyTreeModel.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson/FamilyTreeModel.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "FamilyTreePerson", PropertyDisplayNameKey="Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson/FamilyTreeModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("6eeff026-391b-4a93-96e9-860b61c561d0")]
		public virtual FamilyTreeModel FamilyTreeModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreeModel)DslModeling::DomainRoleInfo.GetRolePlayer(this, FamilyTreeModelDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, FamilyTreeModelDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access FamilyTreeModel of a FamilyTreePerson
		/// <summary>
		/// Gets FamilyTreeModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static FamilyTreeModel GetFamilyTreeModel(FamilyTreePerson element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, FamilyTreePersonDomainRoleId) as FamilyTreeModel;
		}
		
		/// <summary>
		/// Sets FamilyTreeModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetFamilyTreeModel(FamilyTreePerson element, FamilyTreeModel newFamilyTreeModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, FamilyTreePersonDomainRoleId, newFamilyTreeModel);
		}
		#endregion
		#region FamilyTreePerson domain role code
		
		/// <summary>
		/// FamilyTreePerson domain role Id.
		/// </summary>
		public static readonly global::System.Guid FamilyTreePersonDomainRoleId = new System.Guid("de125b06-03b4-4fa1-98c5-649acca53db2");
		
		/// <summary>
		/// DomainRole FamilyTreePerson
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson/FamilyTreePerson.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson/FamilyTreePerson.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "FamilyTreeModel", PropertyDisplayNameKey="Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson/FamilyTreePerson.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("de125b06-03b4-4fa1-98c5-649acca53db2")]
		public virtual FamilyTreePerson FamilyTreePerson
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreePerson)DslModeling::DomainRoleInfo.GetRolePlayer(this, FamilyTreePersonDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, FamilyTreePersonDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access FamilyTreePerson of a FamilyTreeModel
		/// <summary>
		/// Gets a list of FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<FamilyTreePerson> GetFamilyTreePerson(FamilyTreeModel element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<FamilyTreePerson>, FamilyTreePerson>(element, FamilyTreeModelDomainRoleId);
		}
		#endregion
		#region FamilyTreeModel link accessor
		/// <summary>
		/// Get the list of FamilyTreeModelHasFamilyTreePerson links to a FamilyTreeModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> GetLinksToFamilyTreePerson ( global::Tum.FamilyTreeDSL.FamilyTreeModel familyTreeModelInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson>(familyTreeModelInstance, global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId);
		}
		#endregion
		#region FamilyTreePerson link accessor
		/// <summary>
		/// Get the FamilyTreeModelHasFamilyTreePerson link to a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson GetLinkToFamilyTreeModel (global::Tum.FamilyTreeDSL.FamilyTreePerson familyTreePersonInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson>(familyTreePersonInstance, global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of FamilyTreePerson not obeyed.");
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
		#region FamilyTreeModelHasFamilyTreePerson instance accessors
		
		/// <summary>
		/// Get any FamilyTreeModelHasFamilyTreePerson links between a given FamilyTreeModel and a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> GetLinks( global::Tum.FamilyTreeDSL.FamilyTreeModel source, global::Tum.FamilyTreeDSL.FamilyTreePerson target )
		{
			global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> outLinks = new global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson>();
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson>(source, global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson link in links )
			{
				if ( target.Equals(link.FamilyTreePerson) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one FamilyTreeModelHasFamilyTreePerson link between a given FamilyTreeModeland a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson GetLink( global::Tum.FamilyTreeDSL.FamilyTreeModel source, global::Tum.FamilyTreeDSL.FamilyTreePerson target )
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson>(source, global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson link in links )
			{
				if ( target.Equals(link.FamilyTreePerson) )
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
			return global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.DomainClassId;		
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.DomainModelId;
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
	            return "FamilyTreeModelHasFamilyTreePerson";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Family Tree Model Has Family Tree Person";
	        }
	    }	
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainRelationship FamilyTreePersonHasPet
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreePersonHasPet.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreePersonHasPet.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("514239ef-2f74-4a7b-a3d2-da93960ff53c")]
	public partial class FamilyTreePersonHasPet : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// FamilyTreePersonHasPet domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("514239ef-2f74-4a7b-a3d2-da93960ff53c");

				
		/// <summary>
		/// Constructor
		/// Creates a FamilyTreePersonHasPet link in the same Partition as the given FamilyTreePerson
		/// </summary>
		/// <param name="source">FamilyTreePerson to use as the source of the relationship.</param>
		/// <param name="target">Pet to use as the target of the relationship.</param>
		public FamilyTreePersonHasPet(FamilyTreePerson source, Pet target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId, source), new DslModeling::RoleAssignment(FamilyTreePersonHasPet.PetDomainRoleId, target)}, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public FamilyTreePersonHasPet(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public FamilyTreePersonHasPet(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public FamilyTreePersonHasPet(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public FamilyTreePersonHasPet(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region FamilyTreePerson domain role code
		
		/// <summary>
		/// FamilyTreePerson domain role Id.
		/// </summary>
		public static readonly global::System.Guid FamilyTreePersonDomainRoleId = new System.Guid("75225fac-6eda-4ff5-b7c3-4c472bd960b4");
		
		/// <summary>
		/// DomainRole FamilyTreePerson
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreePersonHasPet/FamilyTreePerson.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreePersonHasPet/FamilyTreePerson.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Pet", PropertyDisplayNameKey="Tum.FamilyTreeDSL.FamilyTreePersonHasPet/FamilyTreePerson.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("75225fac-6eda-4ff5-b7c3-4c472bd960b4")]
		public virtual FamilyTreePerson FamilyTreePerson
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreePerson)DslModeling::DomainRoleInfo.GetRolePlayer(this, FamilyTreePersonDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, FamilyTreePersonDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access FamilyTreePerson of a Pet
		/// <summary>
		/// Gets FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static FamilyTreePerson GetFamilyTreePerson(Pet element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, PetDomainRoleId) as FamilyTreePerson;
		}
		
		/// <summary>
		/// Sets FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetFamilyTreePerson(Pet element, FamilyTreePerson newFamilyTreePerson)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, PetDomainRoleId, newFamilyTreePerson);
		}
		#endregion
		#region Pet domain role code
		
		/// <summary>
		/// Pet domain role Id.
		/// </summary>
		public static readonly global::System.Guid PetDomainRoleId = new System.Guid("4aafc271-a696-46cf-9281-193bc9d55b36");
		
		/// <summary>
		/// DomainRole Pet
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreePersonHasPet/Pet.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreePersonHasPet/Pet.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "FamilyTreePerson", PropertyDisplayNameKey="Tum.FamilyTreeDSL.FamilyTreePersonHasPet/Pet.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("4aafc271-a696-46cf-9281-193bc9d55b36")]
		public virtual Pet Pet
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Pet)DslModeling::DomainRoleInfo.GetRolePlayer(this, PetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, PetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Pet of a FamilyTreePerson
		/// <summary>
		/// Gets a list of Pet.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Pet> GetPet(FamilyTreePerson element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Pet>, Pet>(element, FamilyTreePersonDomainRoleId);
		}
		#endregion
		#region FamilyTreePerson link accessor
		/// <summary>
		/// Get the list of FamilyTreePersonHasPet links to a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> GetLinksToPet ( global::Tum.FamilyTreeDSL.FamilyTreePerson familyTreePersonInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet>(familyTreePersonInstance, global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId);
		}
		#endregion
		#region Pet link accessor
		/// <summary>
		/// Get the FamilyTreePersonHasPet link to a Pet.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet GetLinkToFamilyTreePerson (global::Tum.FamilyTreeDSL.Pet petInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet>(petInstance, global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.PetDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Pet not obeyed.");
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
		#region FamilyTreePersonHasPet instance accessors
		
		/// <summary>
		/// Get any FamilyTreePersonHasPet links between a given FamilyTreePerson and a Pet.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> GetLinks( global::Tum.FamilyTreeDSL.FamilyTreePerson source, global::Tum.FamilyTreeDSL.Pet target )
		{
			global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> outLinks = new global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet>();
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet>(source, global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet link in links )
			{
				if ( target.Equals(link.Pet) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one FamilyTreePersonHasPet link between a given FamilyTreePersonand a Pet.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet GetLink( global::Tum.FamilyTreeDSL.FamilyTreePerson source, global::Tum.FamilyTreeDSL.Pet target )
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet>(source, global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet link in links )
			{
				if ( target.Equals(link.Pet) )
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
			return global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.DomainClassId;		
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.DomainModelId;
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
	            return "FamilyTreePersonHasPet";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Family Tree Person Has Pet";
	        }
	    }	
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainRelationship ParentOf
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.ParentOf.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.ParentOf.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("a66e20aa-2060-4bbf-bff7-e86a0b71b1a5")]
	public partial class ParentOf : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ParentOf domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a66e20aa-2060-4bbf-bff7-e86a0b71b1a5");

				
		/// <summary>
		/// Constructor
		/// Creates a ParentOf link in the same Partition as the given FamilyTreePerson
		/// </summary>
		/// <param name="source">FamilyTreePerson to use as the source of the relationship.</param>
		/// <param name="target">FamilyTreePerson to use as the target of the relationship.</param>
		public ParentOf(FamilyTreePerson source, FamilyTreePerson target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ParentOf.ParentDomainRoleId, source), new DslModeling::RoleAssignment(ParentOf.ChildDomainRoleId, target)}, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ParentOf(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ParentOf(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ParentOf(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ParentOf(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Parent domain role code
		
		/// <summary>
		/// Parent domain role Id.
		/// </summary>
		public static readonly global::System.Guid ParentDomainRoleId = new System.Guid("d235b88a-1c78-4891-9cf9-66a291491a64");
		
		/// <summary>
		/// DomainRole Parent
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.ParentOf/Parent.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.ParentOf/Parent.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Children", PropertyDisplayNameKey="Tum.FamilyTreeDSL.ParentOf/Parent.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("d235b88a-1c78-4891-9cf9-66a291491a64")]
		public virtual FamilyTreePerson Parent
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreePerson)DslModeling::DomainRoleInfo.GetRolePlayer(this, ParentDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ParentDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Parents of a FamilyTreePerson
		/// <summary>
		/// Gets a list of Parents.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<FamilyTreePerson> GetParents(FamilyTreePerson element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<FamilyTreePerson>, FamilyTreePerson>(element, ChildDomainRoleId);
		}
		#endregion
		#region Child domain role code
		
		/// <summary>
		/// Child domain role Id.
		/// </summary>
		public static readonly global::System.Guid ChildDomainRoleId = new System.Guid("155c695d-b225-4b0f-8f0a-5799fc5beebc");
		
		/// <summary>
		/// DomainRole Child
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.ParentOf/Child.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.ParentOf/Child.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Parents", PropertyDisplayNameKey="Tum.FamilyTreeDSL.ParentOf/Child.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("155c695d-b225-4b0f-8f0a-5799fc5beebc")]
		public virtual FamilyTreePerson Child
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreePerson)DslModeling::DomainRoleInfo.GetRolePlayer(this, ChildDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ChildDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Children of a FamilyTreePerson
		/// <summary>
		/// Gets a list of Children.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<FamilyTreePerson> GetChildren(FamilyTreePerson element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<FamilyTreePerson>, FamilyTreePerson>(element, ParentDomainRoleId);
		}
		#endregion
		#region Parent link accessor
		/// <summary>
		/// Get the list of ParentOf links to a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.ParentOf> GetLinksToChildren ( global::Tum.FamilyTreeDSL.FamilyTreePerson parentInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.ParentOf>(parentInstance, global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId);
		}
		#endregion
		#region Child link accessor
		/// <summary>
		/// Get the list of ParentOf links to a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.ParentOf> GetLinksToParents ( global::Tum.FamilyTreeDSL.FamilyTreePerson childInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.ParentOf>(childInstance, global::Tum.FamilyTreeDSL.ParentOf.ChildDomainRoleId);
		}
		#endregion
		#region ParentOf instance accessors
		
		/// <summary>
		/// Get any ParentOf links between a given FamilyTreePerson and a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.ParentOf> GetLinks( global::Tum.FamilyTreeDSL.FamilyTreePerson source, global::Tum.FamilyTreeDSL.FamilyTreePerson target )
		{
			global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.ParentOf> outLinks = new global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.ParentOf>();
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.ParentOf> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.ParentOf>(source, global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.ParentOf link in links )
			{
				if ( target.Equals(link.Child) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ParentOf link between a given FamilyTreePersonand a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.ParentOf GetLink( global::Tum.FamilyTreeDSL.FamilyTreePerson source, global::Tum.FamilyTreeDSL.FamilyTreePerson target )
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.ParentOf> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.ParentOf>(source, global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.ParentOf link in links )
			{
				if ( target.Equals(link.Child) )
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
			return global::Tum.FamilyTreeDSL.ParentOf.DomainClassId;		
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.DomainModelId;
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
	            return "ParentOf";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Parent Of";
	        }
	    }	
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainRelationship MarriedTo
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.MarriedTo.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.MarriedTo.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("adb58fcc-7f8c-4364-b57c-a760fc08651a")]
	public partial class MarriedTo : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// MarriedTo domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("adb58fcc-7f8c-4364-b57c-a760fc08651a");

				
		/// <summary>
		/// Constructor
		/// Creates a MarriedTo link in the same Partition as the given FamilyTreePerson
		/// </summary>
		/// <param name="source">FamilyTreePerson to use as the source of the relationship.</param>
		/// <param name="target">FamilyTreePerson to use as the target of the relationship.</param>
		public MarriedTo(FamilyTreePerson source, FamilyTreePerson target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(MarriedTo.HusbandDomainRoleId, source), new DslModeling::RoleAssignment(MarriedTo.WifeDomainRoleId, target)}, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MarriedTo(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MarriedTo(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MarriedTo(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MarriedTo(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Husband domain role code
		
		/// <summary>
		/// Husband domain role Id.
		/// </summary>
		public static readonly global::System.Guid HusbandDomainRoleId = new System.Guid("c889a44a-6854-4049-acec-275c642ba048");
		
		/// <summary>
		/// DomainRole Husband
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.MarriedTo/Husband.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.MarriedTo/Husband.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Wife", PropertyDisplayNameKey="Tum.FamilyTreeDSL.MarriedTo/Husband.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("c889a44a-6854-4049-acec-275c642ba048")]
		public virtual FamilyTreePerson Husband
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreePerson)DslModeling::DomainRoleInfo.GetRolePlayer(this, HusbandDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, HusbandDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Husband of a FamilyTreePerson
		/// <summary>
		/// Gets Husband.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static FamilyTreePerson GetHusband(FamilyTreePerson element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, WifeDomainRoleId) as FamilyTreePerson;
		}
		
		/// <summary>
		/// Sets Husband.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetHusband(FamilyTreePerson element, FamilyTreePerson newHusband)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, WifeDomainRoleId, newHusband);
		}
		#endregion
		#region Wife domain role code
		
		/// <summary>
		/// Wife domain role Id.
		/// </summary>
		public static readonly global::System.Guid WifeDomainRoleId = new System.Guid("fbf8ecb1-354a-488b-b5cc-686e63fa29f3");
		
		/// <summary>
		/// DomainRole Wife
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.MarriedTo/Wife.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.MarriedTo/Wife.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Husband", PropertyDisplayNameKey="Tum.FamilyTreeDSL.MarriedTo/Wife.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("fbf8ecb1-354a-488b-b5cc-686e63fa29f3")]
		public virtual FamilyTreePerson Wife
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FamilyTreePerson)DslModeling::DomainRoleInfo.GetRolePlayer(this, WifeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, WifeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Wife of a FamilyTreePerson
		/// <summary>
		/// Gets Wife.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static FamilyTreePerson GetWife(FamilyTreePerson element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, HusbandDomainRoleId) as FamilyTreePerson;
		}
		
		/// <summary>
		/// Sets Wife.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetWife(FamilyTreePerson element, FamilyTreePerson newWife)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, HusbandDomainRoleId, newWife);
		}
		#endregion
		#region Husband link accessor
		/// <summary>
		/// Get the MarriedTo link to a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.MarriedTo GetLinkToWife (global::Tum.FamilyTreeDSL.FamilyTreePerson husbandInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.MarriedTo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(husbandInstance, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Husband not obeyed.");
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
		#region Wife link accessor
		/// <summary>
		/// Get the MarriedTo link to a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.MarriedTo GetLinkToHusband (global::Tum.FamilyTreeDSL.FamilyTreePerson wifeInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.MarriedTo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(wifeInstance, global::Tum.FamilyTreeDSL.MarriedTo.WifeDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Wife not obeyed.");
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
		#region MarriedTo instance accessors
		
		/// <summary>
		/// Get any MarriedTo links between a given FamilyTreePerson and a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.MarriedTo> GetLinks( global::Tum.FamilyTreeDSL.FamilyTreePerson source, global::Tum.FamilyTreeDSL.FamilyTreePerson target )
		{
			global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.MarriedTo> outLinks = new global::System.Collections.Generic.List<global::Tum.FamilyTreeDSL.MarriedTo>();
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.MarriedTo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(source, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.MarriedTo link in links )
			{
				if ( target.Equals(link.Wife) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one MarriedTo link between a given FamilyTreePersonand a FamilyTreePerson.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.FamilyTreeDSL.MarriedTo GetLink( global::Tum.FamilyTreeDSL.FamilyTreePerson source, global::Tum.FamilyTreeDSL.FamilyTreePerson target )
		{
			global::System.Collections.Generic.IList<global::Tum.FamilyTreeDSL.MarriedTo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(source, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId);
			foreach ( global::Tum.FamilyTreeDSL.MarriedTo link in links )
			{
				if ( target.Equals(link.Wife) )
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
			return global::Tum.FamilyTreeDSL.MarriedTo.DomainClassId;		
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel.DomainModelId;
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
	            return "MarriedTo";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Married To";
	        }
	    }	
		#endregion
	}
}


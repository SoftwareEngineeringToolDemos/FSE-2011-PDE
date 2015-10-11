 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// DomainRelationship DomainModelHasDomainClass2
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("a38427f0-4388-4c2e-a3e4-ea5952570bb5")]
	public partial class DomainModelHasDomainClass2 : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasDomainClass2 domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a38427f0-4388-4c2e-a3e4-ea5952570bb5");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasDomainClass2 link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">DomainClass2 to use as the target of the relationship.</param>
		public DomainModelHasDomainClass2(DomainModel source, DomainClass2 target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasDomainClass2.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasDomainClass2.DomainClass2DomainRoleId, target)}, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDomainClass2(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDomainClass2(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDomainClass2(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDomainClass2(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("21e7aecb-4204-4f77-bcc2-cdc65a1287af");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2/DomainModel.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2/DomainModel.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainClass2", PropertyDisplayNameKey="Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("21e7aecb-4204-4f77-bcc2-cdc65a1287af")]
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainModel)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainModelDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainModelDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainModel of a DomainClass2
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(DomainClass2 element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainClass2DomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(DomainClass2 element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainClass2DomainRoleId, newDomainModel);
		}
		#endregion
		#region DomainClass2 domain role code
		
		/// <summary>
		/// DomainClass2 domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainClass2DomainRoleId = new System.Guid("874f595f-d0da-4507-9386-9af3e8411f15");
		
		/// <summary>
		/// DomainRole DomainClass2
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2/DomainClass2.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2/DomainClass2.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2/DomainClass2.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("874f595f-d0da-4507-9386-9af3e8411f15")]
		public virtual DomainClass2 DomainClass2
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainClass2)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainClass2DomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainClass2DomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainClass2 of a DomainModel
		/// <summary>
		/// Gets a list of DomainClass2.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DomainClass2> GetDomainClass2(DomainModel element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DomainClass2>, DomainClass2>(element, DomainModelDomainRoleId);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the list of DomainModelHasDomainClass2 links to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2> GetLinksToDomainClass2 ( global::Tum.PDE.VSPluginDSL.DomainModel domainModelInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2>(domainModelInstance, global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainModelDomainRoleId);
		}
		#endregion
		#region DomainClass2 link accessor
		/// <summary>
		/// Get the DomainModelHasDomainClass2 link to a DomainClass2.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2 GetLinkToDomainModel (global::Tum.PDE.VSPluginDSL.DomainClass2 domainClass2Instance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2>(domainClass2Instance, global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClass2DomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainClass2 not obeyed.");
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
		#region DomainModelHasDomainClass2 instance accessors
		
		/// <summary>
		/// Get any DomainModelHasDomainClass2 links between a given DomainModel and a DomainClass2.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2> GetLinks( global::Tum.PDE.VSPluginDSL.DomainModel source, global::Tum.PDE.VSPluginDSL.DomainClass2 target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2>();
			global::System.Collections.Generic.IList<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2>(source, global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2 link in links )
			{
				if ( target.Equals(link.DomainClass2) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasDomainClass2 link between a given DomainModeland a DomainClass2.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2 GetLink( global::Tum.PDE.VSPluginDSL.DomainModel source, global::Tum.PDE.VSPluginDSL.DomainClass2 target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2>(source, global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2 link in links )
			{
				if ( target.Equals(link.DomainClass2) )
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
			return global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClassId;		
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
			return typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel.DomainModelId;
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
	            return "DomainModelHasDomainClass2";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has Domain Class2";
	        }
	    }	
		#endregion
	}
}


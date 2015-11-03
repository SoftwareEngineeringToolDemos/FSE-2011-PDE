 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellHasVModellvariante
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellHasVModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellHasVModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("6d300e6e-02b6-4d29-a302-9ec9ce21b15a")]
	public partial class VModellHasVModellvariante : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellHasVModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("6d300e6e-02b6-4d29-a302-9ec9ce21b15a");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellHasVModellvariante link in the same Partition as the given VModell
		/// </summary>
		/// <param name="source">VModell to use as the source of the relationship.</param>
		/// <param name="target">VModellvariante to use as the target of the relationship.</param>
		public VModellHasVModellvariante(VModell source, VModellvariante target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellHasVModellvariante.VModellDomainRoleId, source), new DslModeling::RoleAssignment(VModellHasVModellvariante.VModellvarianteDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellHasVModellvariante(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellHasVModellvariante(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellHasVModellvariante(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellHasVModellvariante(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModell domain role code
		
		/// <summary>
		/// VModell domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellDomainRoleId = new System.Guid("ad29599c-b8a6-41b1-8b95-f219d3e40793");
		
		/// <summary>
		/// DomainRole VModell
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellHasVModellvariante/VModell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellHasVModellvariante/VModell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellHasVModellvariante/VModell.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("ad29599c-b8a6-41b1-8b95-f219d3e40793")]
		public virtual VModell VModell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModell)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModell of a VModellvariante
		/// <summary>
		/// Gets VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModell GetVModell(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as VModell;
		}
		
		/// <summary>
		/// Sets VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModell(VModellvariante element, VModell newVModell)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newVModell);
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("3e5c003c-71c6-4dbe-988f-5a5398187257");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellHasVModellvariante/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellHasVModellvariante/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModell", PropertyDisplayNameKey="Tum.VModellXT.VModellHasVModellvariante/VModellvariante.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("3e5c003c-71c6-4dbe-988f-5a5398187257")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a VModell
		/// <summary>
		/// Gets a list of VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<VModellvariante> GetVModellvariante(VModell element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<VModellvariante>, VModellvariante>(element, VModellDomainRoleId);
		}
		#endregion
		#region VModell link accessor
		/// <summary>
		/// Get the list of VModellHasVModellvariante links to a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellHasVModellvariante> GetLinksToVModellvariante ( global::Tum.VModellXT.VModell vModellInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellHasVModellvariante>(vModellInstance, global::Tum.VModellXT.VModellHasVModellvariante.VModellDomainRoleId);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellHasVModellvariante link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellHasVModellvariante GetLinkToVModell (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellHasVModellvariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellHasVModellvariante>(vModellvarianteInstance, global::Tum.VModellXT.VModellHasVModellvariante.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region VModellHasVModellvariante instance accessors
		
		/// <summary>
		/// Get any VModellHasVModellvariante links between a given VModell and a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellHasVModellvariante> GetLinks( global::Tum.VModellXT.VModell source, global::Tum.VModellXT.VModellvariante target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellHasVModellvariante> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellHasVModellvariante>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellHasVModellvariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellHasVModellvariante>(source, global::Tum.VModellXT.VModellHasVModellvariante.VModellDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellHasVModellvariante link in links )
			{
				if ( target.Equals(link.VModellvariante) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellHasVModellvariante link between a given VModelland a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellHasVModellvariante GetLink( global::Tum.VModellXT.VModell source, global::Tum.VModellXT.VModellvariante target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellHasVModellvariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellHasVModellvariante>(source, global::Tum.VModellXT.VModellHasVModellvariante.VModellDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellHasVModellvariante link in links )
			{
				if ( target.Equals(link.VModellvariante) )
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
			return global::Tum.VModellXT.VModellHasVModellvariante.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellHasVModellvariante";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModell Has VModellvariante";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasVModellStruktur
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVModellStruktur.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVModellStruktur.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("8b40db25-b92c-4858-919a-7ea41617b30a")]
	public partial class VModellvarianteHasVModellStruktur : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasVModellStruktur domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("8b40db25-b92c-4858-919a-7ea41617b30a");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasVModellStruktur link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">VModellStruktur to use as the target of the relationship.</param>
		public VModellvarianteHasVModellStruktur(VModellvariante source, global::Tum.VModellXT.Basis.VModellStruktur target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasVModellStruktur.VModellStrukturDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasVModellStruktur(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasVModellStruktur(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasVModellStruktur(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasVModellStruktur(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("582c4717-d775-4696-9292-c374aed690d2");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVModellStruktur/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVModellStruktur/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "VModellStruktur", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasVModellStruktur/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("582c4717-d775-4696-9292-c374aed690d2")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a VModellStruktur
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.VModellStruktur element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellStrukturDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.VModellStruktur element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellStrukturDomainRoleId, newVModellvariante);
		}
		#endregion
		#region VModellStruktur domain role code
		
		/// <summary>
		/// VModellStruktur domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellStrukturDomainRoleId = new System.Guid("e4250145-75e8-4dfa-8a36-22e602b74e7c");
		
		/// <summary>
		/// DomainRole VModellStruktur
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVModellStruktur/VModellStruktur.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVModellStruktur/VModellStruktur.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasVModellStruktur/VModellStruktur.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("e4250145-75e8-4dfa-8a36-22e602b74e7c")]
		public virtual global::Tum.VModellXT.Basis.VModellStruktur VModellStruktur
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.VModellStruktur)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellStrukturDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellStrukturDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellStruktur of a VModellvariante
		/// <summary>
		/// Gets VModellStruktur.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.VModellStruktur GetVModellStruktur(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.VModellStruktur;
		}
		
		/// <summary>
		/// Sets VModellStruktur.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellStruktur(VModellvariante element, global::Tum.VModellXT.Basis.VModellStruktur newVModellStruktur)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newVModellStruktur);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasVModellStruktur link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVModellStruktur GetLinkToVModellStruktur (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVModellStruktur>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region VModellStruktur link accessor
		/// <summary>
		/// Get the VModellvarianteHasVModellStruktur link to a VModellStruktur.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVModellStruktur GetLinkToVModellvariante (global::Tum.VModellXT.Basis.VModellStruktur vModellStrukturInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVModellStruktur>(vModellStrukturInstance, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellStrukturDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellStruktur not obeyed.");
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
		#region VModellvarianteHasVModellStruktur instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasVModellStruktur links between a given VModellvariante and a VModellStruktur.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.VModellStruktur target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasVModellStruktur>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVModellStruktur>(source, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasVModellStruktur link in links )
			{
				if ( target.Equals(link.VModellStruktur) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasVModellStruktur link between a given VModellvarianteand a VModellStruktur.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVModellStruktur GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.VModellStruktur target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVModellStruktur> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVModellStruktur>(source, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasVModellStruktur link in links )
			{
				if ( target.Equals(link.VModellStruktur) )
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
			return global::Tum.VModellXT.VModellvarianteHasVModellStruktur.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasVModellStruktur";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has VModell Struktur";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasTextbausteine
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasTextbausteine.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasTextbausteine.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("aa930862-1f3a-4f3d-807f-70926c652fdb")]
	public partial class VModellvarianteHasTextbausteine : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasTextbausteine domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("aa930862-1f3a-4f3d-807f-70926c652fdb");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasTextbausteine link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Textbausteine to use as the target of the relationship.</param>
		public VModellvarianteHasTextbausteine(VModellvariante source, global::Tum.VModellXT.Basis.Textbausteine target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasTextbausteine.TextbausteineDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasTextbausteine(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasTextbausteine(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasTextbausteine(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasTextbausteine(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("55cc47f2-0563-4817-a190-5683a3972a4e");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasTextbausteine/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasTextbausteine/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Textbausteine", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasTextbausteine/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("55cc47f2-0563-4817-a190-5683a3972a4e")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Textbausteine
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.Textbausteine element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, TextbausteineDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.Textbausteine element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, TextbausteineDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Textbausteine domain role code
		
		/// <summary>
		/// Textbausteine domain role Id.
		/// </summary>
		public static readonly global::System.Guid TextbausteineDomainRoleId = new System.Guid("7c694003-4ca3-4bf2-bd5f-6633ac6547e1");
		
		/// <summary>
		/// DomainRole Textbausteine
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasTextbausteine/Textbausteine.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasTextbausteine/Textbausteine.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasTextbausteine/Textbausteine.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("7c694003-4ca3-4bf2-bd5f-6633ac6547e1")]
		public virtual global::Tum.VModellXT.Basis.Textbausteine Textbausteine
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.Textbausteine)DslModeling::DomainRoleInfo.GetRolePlayer(this, TextbausteineDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, TextbausteineDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Textbausteine of a VModellvariante
		/// <summary>
		/// Gets Textbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.Textbausteine GetTextbausteine(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Textbausteine;
		}
		
		/// <summary>
		/// Sets Textbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetTextbausteine(VModellvariante element, global::Tum.VModellXT.Basis.Textbausteine newTextbausteine)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newTextbausteine);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasTextbausteine link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasTextbausteine GetLinkToTextbausteine (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasTextbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasTextbausteine>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Textbausteine link accessor
		/// <summary>
		/// Get the VModellvarianteHasTextbausteine link to a Textbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasTextbausteine GetLinkToVModellvariante (global::Tum.VModellXT.Basis.Textbausteine textbausteineInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasTextbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasTextbausteine>(textbausteineInstance, global::Tum.VModellXT.VModellvarianteHasTextbausteine.TextbausteineDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Textbausteine not obeyed.");
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
		#region VModellvarianteHasTextbausteine instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasTextbausteine links between a given VModellvariante and a Textbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasTextbausteine> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Textbausteine target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasTextbausteine> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasTextbausteine>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasTextbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasTextbausteine>(source, global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasTextbausteine link in links )
			{
				if ( target.Equals(link.Textbausteine) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasTextbausteine link between a given VModellvarianteand a Textbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasTextbausteine GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Textbausteine target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasTextbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasTextbausteine>(source, global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasTextbausteine link in links )
			{
				if ( target.Equals(link.Textbausteine) )
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
			return global::Tum.VModellXT.VModellvarianteHasTextbausteine.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasTextbausteine";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Textbausteine";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasVorgehensbausteine
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVorgehensbausteine.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVorgehensbausteine.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("c3dcae65-91dd-4148-a6bd-91b399ab39bb")]
	public partial class VModellvarianteHasVorgehensbausteine : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasVorgehensbausteine domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("c3dcae65-91dd-4148-a6bd-91b399ab39bb");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasVorgehensbausteine link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Vorgehensbausteine to use as the target of the relationship.</param>
		public VModellvarianteHasVorgehensbausteine(VModellvariante source, global::Tum.VModellXT.Statik.Vorgehensbausteine target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasVorgehensbausteine.VorgehensbausteineDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasVorgehensbausteine(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasVorgehensbausteine(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasVorgehensbausteine(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasVorgehensbausteine(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("156437ec-78d0-4c24-9d4b-7d2a6c77f92e");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVorgehensbausteine/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVorgehensbausteine/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Vorgehensbausteine", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasVorgehensbausteine/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("156437ec-78d0-4c24-9d4b-7d2a6c77f92e")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Vorgehensbausteine
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Statik.Vorgehensbausteine element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VorgehensbausteineDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Statik.Vorgehensbausteine element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VorgehensbausteineDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Vorgehensbausteine domain role code
		
		/// <summary>
		/// Vorgehensbausteine domain role Id.
		/// </summary>
		public static readonly global::System.Guid VorgehensbausteineDomainRoleId = new System.Guid("8905edde-1a81-483a-b6e5-8751a0a722d7");
		
		/// <summary>
		/// DomainRole Vorgehensbausteine
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVorgehensbausteine/Vorgehensbausteine.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVorgehensbausteine/Vorgehensbausteine.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasVorgehensbausteine/Vorgehensbausteine.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("8905edde-1a81-483a-b6e5-8751a0a722d7")]
		public virtual global::Tum.VModellXT.Statik.Vorgehensbausteine Vorgehensbausteine
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Statik.Vorgehensbausteine)DslModeling::DomainRoleInfo.GetRolePlayer(this, VorgehensbausteineDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VorgehensbausteineDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Vorgehensbausteine of a VModellvariante
		/// <summary>
		/// Gets Vorgehensbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Statik.Vorgehensbausteine GetVorgehensbausteine(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Statik.Vorgehensbausteine;
		}
		
		/// <summary>
		/// Sets Vorgehensbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVorgehensbausteine(VModellvariante element, global::Tum.VModellXT.Statik.Vorgehensbausteine newVorgehensbausteine)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newVorgehensbausteine);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasVorgehensbausteine link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine GetLinkToVorgehensbausteine (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Vorgehensbausteine link accessor
		/// <summary>
		/// Get the VModellvarianteHasVorgehensbausteine link to a Vorgehensbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine GetLinkToVModellvariante (global::Tum.VModellXT.Statik.Vorgehensbausteine vorgehensbausteineInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine>(vorgehensbausteineInstance, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VorgehensbausteineDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Vorgehensbausteine not obeyed.");
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
		#region VModellvarianteHasVorgehensbausteine instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasVorgehensbausteine links between a given VModellvariante and a Vorgehensbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Statik.Vorgehensbausteine target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine>(source, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine link in links )
			{
				if ( target.Equals(link.Vorgehensbausteine) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasVorgehensbausteine link between a given VModellvarianteand a Vorgehensbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Statik.Vorgehensbausteine target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine>(source, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine link in links )
			{
				if ( target.Equals(link.Vorgehensbausteine) )
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
			return global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasVorgehensbausteine";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Vorgehensbausteine";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasRollen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasRollen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasRollen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("02095946-8531-44bf-a716-0e5870cea7fb")]
	public partial class VModellvarianteHasRollen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasRollen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("02095946-8531-44bf-a716-0e5870cea7fb");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasRollen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Rollen to use as the target of the relationship.</param>
		public VModellvarianteHasRollen(VModellvariante source, global::Tum.VModellXT.Statik.Rollen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasRollen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasRollen.RollenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasRollen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasRollen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasRollen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasRollen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("689d8fbd-1733-40af-82f0-f10e55f35d8d");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasRollen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasRollen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Rollen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasRollen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("689d8fbd-1733-40af-82f0-f10e55f35d8d")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Rollen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Statik.Rollen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, RollenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Statik.Rollen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, RollenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Rollen domain role code
		
		/// <summary>
		/// Rollen domain role Id.
		/// </summary>
		public static readonly global::System.Guid RollenDomainRoleId = new System.Guid("bbd39139-b65b-4e72-8471-043feeeeba53");
		
		/// <summary>
		/// DomainRole Rollen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasRollen/Rollen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasRollen/Rollen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasRollen/Rollen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("bbd39139-b65b-4e72-8471-043feeeeba53")]
		public virtual global::Tum.VModellXT.Statik.Rollen Rollen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Statik.Rollen)DslModeling::DomainRoleInfo.GetRolePlayer(this, RollenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, RollenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Rollen of a VModellvariante
		/// <summary>
		/// Gets Rollen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Statik.Rollen GetRollen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Statik.Rollen;
		}
		
		/// <summary>
		/// Sets Rollen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetRollen(VModellvariante element, global::Tum.VModellXT.Statik.Rollen newRollen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newRollen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasRollen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasRollen GetLinkToRollen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasRollen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasRollen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Rollen link accessor
		/// <summary>
		/// Get the VModellvarianteHasRollen link to a Rollen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasRollen GetLinkToVModellvariante (global::Tum.VModellXT.Statik.Rollen rollenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasRollen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasRollen>(rollenInstance, global::Tum.VModellXT.VModellvarianteHasRollen.RollenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Rollen not obeyed.");
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
		#region VModellvarianteHasRollen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasRollen links between a given VModellvariante and a Rollen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasRollen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Statik.Rollen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasRollen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasRollen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasRollen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasRollen>(source, global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasRollen link in links )
			{
				if ( target.Equals(link.Rollen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasRollen link between a given VModellvarianteand a Rollen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasRollen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Statik.Rollen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasRollen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasRollen>(source, global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasRollen link in links )
			{
				if ( target.Equals(link.Rollen) )
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
			return global::Tum.VModellXT.VModellvarianteHasRollen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasRollen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Rollen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasPDSSpezifikationen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("731ab53f-bff8-4df9-8b45-941404df4022")]
	public partial class VModellvarianteHasPDSSpezifikationen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasPDSSpezifikationen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("731ab53f-bff8-4df9-8b45-941404df4022");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasPDSSpezifikationen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">PDSSpezifikationen to use as the target of the relationship.</param>
		public VModellvarianteHasPDSSpezifikationen(VModellvariante source, global::Tum.VModellXT.Dynamik.PDSSpezifikationen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasPDSSpezifikationen.PDSSpezifikationenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasPDSSpezifikationen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasPDSSpezifikationen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasPDSSpezifikationen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasPDSSpezifikationen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("95f2929b-ac95-4ea4-ba66-2626c48678d8");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasPDSSpezifikationen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasPDSSpezifikationen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "PDSSpezifikationen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasPDSSpezifikationen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("95f2929b-ac95-4ea4-ba66-2626c48678d8")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a PDSSpezifikationen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Dynamik.PDSSpezifikationen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, PDSSpezifikationenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Dynamik.PDSSpezifikationen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, PDSSpezifikationenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region PDSSpezifikationen domain role code
		
		/// <summary>
		/// PDSSpezifikationen domain role Id.
		/// </summary>
		public static readonly global::System.Guid PDSSpezifikationenDomainRoleId = new System.Guid("2f314ed8-315c-4c89-b787-0260cc20635f");
		
		/// <summary>
		/// DomainRole PDSSpezifikationen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasPDSSpezifikationen/PDSSpezifikationen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasPDSSpezifikationen/PDSSpezifikationen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasPDSSpezifikationen/PDSSpezifikationen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("2f314ed8-315c-4c89-b787-0260cc20635f")]
		public virtual global::Tum.VModellXT.Dynamik.PDSSpezifikationen PDSSpezifikationen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Dynamik.PDSSpezifikationen)DslModeling::DomainRoleInfo.GetRolePlayer(this, PDSSpezifikationenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, PDSSpezifikationenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access PDSSpezifikationen of a VModellvariante
		/// <summary>
		/// Gets PDSSpezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Dynamik.PDSSpezifikationen GetPDSSpezifikationen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Dynamik.PDSSpezifikationen;
		}
		
		/// <summary>
		/// Sets PDSSpezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetPDSSpezifikationen(VModellvariante element, global::Tum.VModellXT.Dynamik.PDSSpezifikationen newPDSSpezifikationen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newPDSSpezifikationen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasPDSSpezifikationen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen GetLinkToPDSSpezifikationen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region PDSSpezifikationen link accessor
		/// <summary>
		/// Get the VModellvarianteHasPDSSpezifikationen link to a PDSSpezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen GetLinkToVModellvariante (global::Tum.VModellXT.Dynamik.PDSSpezifikationen pDSSpezifikationenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen>(pDSSpezifikationenInstance, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.PDSSpezifikationenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of PDSSpezifikationen not obeyed.");
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
		#region VModellvarianteHasPDSSpezifikationen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasPDSSpezifikationen links between a given VModellvariante and a PDSSpezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Dynamik.PDSSpezifikationen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen>(source, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen link in links )
			{
				if ( target.Equals(link.PDSSpezifikationen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasPDSSpezifikationen link between a given VModellvarianteand a PDSSpezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Dynamik.PDSSpezifikationen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen>(source, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen link in links )
			{
				if ( target.Equals(link.PDSSpezifikationen) )
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
			return global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasPDSSpezifikationen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has PDSSpezifikationen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasAblaufbausteine
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAblaufbausteine.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAblaufbausteine.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("ec4d26aa-391e-4031-8a96-241e29d09fec")]
	public partial class VModellvarianteHasAblaufbausteine : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasAblaufbausteine domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("ec4d26aa-391e-4031-8a96-241e29d09fec");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasAblaufbausteine link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Ablaufbausteine to use as the target of the relationship.</param>
		public VModellvarianteHasAblaufbausteine(VModellvariante source, global::Tum.VModellXT.Dynamik.Ablaufbausteine target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasAblaufbausteine.AblaufbausteineDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAblaufbausteine(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAblaufbausteine(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAblaufbausteine(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAblaufbausteine(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("a839c68f-1609-483e-b0c6-058f6a364291");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAblaufbausteine/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAblaufbausteine/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Ablaufbausteine", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAblaufbausteine/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("a839c68f-1609-483e-b0c6-058f6a364291")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Ablaufbausteine
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Dynamik.Ablaufbausteine element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, AblaufbausteineDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Dynamik.Ablaufbausteine element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, AblaufbausteineDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Ablaufbausteine domain role code
		
		/// <summary>
		/// Ablaufbausteine domain role Id.
		/// </summary>
		public static readonly global::System.Guid AblaufbausteineDomainRoleId = new System.Guid("c64f4940-32c3-45f4-a9f7-6459fc0023ff");
		
		/// <summary>
		/// DomainRole Ablaufbausteine
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAblaufbausteine/Ablaufbausteine.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAblaufbausteine/Ablaufbausteine.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAblaufbausteine/Ablaufbausteine.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("c64f4940-32c3-45f4-a9f7-6459fc0023ff")]
		public virtual global::Tum.VModellXT.Dynamik.Ablaufbausteine Ablaufbausteine
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Dynamik.Ablaufbausteine)DslModeling::DomainRoleInfo.GetRolePlayer(this, AblaufbausteineDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, AblaufbausteineDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Ablaufbausteine of a VModellvariante
		/// <summary>
		/// Gets Ablaufbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Dynamik.Ablaufbausteine GetAblaufbausteine(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Dynamik.Ablaufbausteine;
		}
		
		/// <summary>
		/// Sets Ablaufbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetAblaufbausteine(VModellvariante element, global::Tum.VModellXT.Dynamik.Ablaufbausteine newAblaufbausteine)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newAblaufbausteine);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasAblaufbausteine link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAblaufbausteine GetLinkToAblaufbausteine (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Ablaufbausteine link accessor
		/// <summary>
		/// Get the VModellvarianteHasAblaufbausteine link to a Ablaufbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAblaufbausteine GetLinkToVModellvariante (global::Tum.VModellXT.Dynamik.Ablaufbausteine ablaufbausteineInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine>(ablaufbausteineInstance, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.AblaufbausteineDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Ablaufbausteine not obeyed.");
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
		#region VModellvarianteHasAblaufbausteine instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasAblaufbausteine links between a given VModellvariante and a Ablaufbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Dynamik.Ablaufbausteine target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine>(source, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAblaufbausteine link in links )
			{
				if ( target.Equals(link.Ablaufbausteine) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasAblaufbausteine link between a given VModellvarianteand a Ablaufbausteine.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAblaufbausteine GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Dynamik.Ablaufbausteine target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteine>(source, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAblaufbausteine link in links )
			{
				if ( target.Equals(link.Ablaufbausteine) )
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
			return global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasAblaufbausteine";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Ablaufbausteine";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasAblaufbausteinspezifikationen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("13b7f8c3-6dce-405c-b022-8d0ce849f48c")]
	public partial class VModellvarianteHasAblaufbausteinspezifikationen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasAblaufbausteinspezifikationen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("13b7f8c3-6dce-405c-b022-8d0ce849f48c");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasAblaufbausteinspezifikationen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Ablaufbausteinspezifikationen to use as the target of the relationship.</param>
		public VModellvarianteHasAblaufbausteinspezifikationen(VModellvariante source, global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasAblaufbausteinspezifikationen.AblaufbausteinspezifikationenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAblaufbausteinspezifikationen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAblaufbausteinspezifikationen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAblaufbausteinspezifikationen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAblaufbausteinspezifikationen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("2f697c9d-9499-4aab-ab4c-5e1845377a45");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Ablaufbausteinspezifikationen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("2f697c9d-9499-4aab-ab4c-5e1845377a45")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Ablaufbausteinspezifikationen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, AblaufbausteinspezifikationenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, AblaufbausteinspezifikationenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Ablaufbausteinspezifikationen domain role code
		
		/// <summary>
		/// Ablaufbausteinspezifikationen domain role Id.
		/// </summary>
		public static readonly global::System.Guid AblaufbausteinspezifikationenDomainRoleId = new System.Guid("6149758e-bf5b-4f01-bec6-6702035f3154");
		
		/// <summary>
		/// DomainRole Ablaufbausteinspezifikationen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen/Ablaufbausteinspezifikationen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen/Ablaufbausteinspezifikationen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen/Ablaufbausteinspezifikationen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("6149758e-bf5b-4f01-bec6-6702035f3154")]
		public virtual global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen Ablaufbausteinspezifikationen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen)DslModeling::DomainRoleInfo.GetRolePlayer(this, AblaufbausteinspezifikationenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, AblaufbausteinspezifikationenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Ablaufbausteinspezifikationen of a VModellvariante
		/// <summary>
		/// Gets Ablaufbausteinspezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen GetAblaufbausteinspezifikationen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen;
		}
		
		/// <summary>
		/// Sets Ablaufbausteinspezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetAblaufbausteinspezifikationen(VModellvariante element, global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen newAblaufbausteinspezifikationen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newAblaufbausteinspezifikationen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasAblaufbausteinspezifikationen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen GetLinkToAblaufbausteinspezifikationen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Ablaufbausteinspezifikationen link accessor
		/// <summary>
		/// Get the VModellvarianteHasAblaufbausteinspezifikationen link to a Ablaufbausteinspezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen GetLinkToVModellvariante (global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen ablaufbausteinspezifikationenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen>(ablaufbausteinspezifikationenInstance, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.AblaufbausteinspezifikationenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Ablaufbausteinspezifikationen not obeyed.");
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
		#region VModellvarianteHasAblaufbausteinspezifikationen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasAblaufbausteinspezifikationen links between a given VModellvariante and a Ablaufbausteinspezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen>(source, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen link in links )
			{
				if ( target.Equals(link.Ablaufbausteinspezifikationen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasAblaufbausteinspezifikationen link between a given VModellvarianteand a Ablaufbausteinspezifikationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen>(source, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen link in links )
			{
				if ( target.Equals(link.Ablaufbausteinspezifikationen) )
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
			return global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasAblaufbausteinspezifikationen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Ablaufbausteinspezifikationen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasProjekttypen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjekttypen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjekttypen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("fa5722a7-5e95-48e6-b602-c73b71df5f17")]
	public partial class VModellvarianteHasProjekttypen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasProjekttypen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("fa5722a7-5e95-48e6-b602-c73b71df5f17");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasProjekttypen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Projekttypen to use as the target of the relationship.</param>
		public VModellvarianteHasProjekttypen(VModellvariante source, global::Tum.VModellXT.Anpassung.Projekttypen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasProjekttypen.ProjekttypenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasProjekttypen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasProjekttypen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasProjekttypen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasProjekttypen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("74f5f231-9e85-4d49-89b3-880d21d2806a");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjekttypen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjekttypen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Projekttypen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasProjekttypen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("74f5f231-9e85-4d49-89b3-880d21d2806a")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Projekttypen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Anpassung.Projekttypen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ProjekttypenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Anpassung.Projekttypen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ProjekttypenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Projekttypen domain role code
		
		/// <summary>
		/// Projekttypen domain role Id.
		/// </summary>
		public static readonly global::System.Guid ProjekttypenDomainRoleId = new System.Guid("2cdc416b-7aa7-416f-b4de-adcaae09c9b1");
		
		/// <summary>
		/// DomainRole Projekttypen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjekttypen/Projekttypen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjekttypen/Projekttypen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasProjekttypen/Projekttypen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("2cdc416b-7aa7-416f-b4de-adcaae09c9b1")]
		public virtual global::Tum.VModellXT.Anpassung.Projekttypen Projekttypen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Anpassung.Projekttypen)DslModeling::DomainRoleInfo.GetRolePlayer(this, ProjekttypenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ProjekttypenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Projekttypen of a VModellvariante
		/// <summary>
		/// Gets Projekttypen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Anpassung.Projekttypen GetProjekttypen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Projekttypen;
		}
		
		/// <summary>
		/// Sets Projekttypen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetProjekttypen(VModellvariante element, global::Tum.VModellXT.Anpassung.Projekttypen newProjekttypen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newProjekttypen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasProjekttypen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjekttypen GetLinkToProjekttypen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Projekttypen link accessor
		/// <summary>
		/// Get the VModellvarianteHasProjekttypen link to a Projekttypen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjekttypen GetLinkToVModellvariante (global::Tum.VModellXT.Anpassung.Projekttypen projekttypenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypen>(projekttypenInstance, global::Tum.VModellXT.VModellvarianteHasProjekttypen.ProjekttypenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Projekttypen not obeyed.");
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
		#region VModellvarianteHasProjekttypen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasProjekttypen links between a given VModellvariante and a Projekttypen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasProjekttypen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Projekttypen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasProjekttypen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasProjekttypen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypen>(source, global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasProjekttypen link in links )
			{
				if ( target.Equals(link.Projekttypen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasProjekttypen link between a given VModellvarianteand a Projekttypen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjekttypen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Projekttypen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypen>(source, global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasProjekttypen link in links )
			{
				if ( target.Equals(link.Projekttypen) )
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
			return global::Tum.VModellXT.VModellvarianteHasProjekttypen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasProjekttypen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Projekttypen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasProjekttypvarianten
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjekttypvarianten.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjekttypvarianten.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("5527c522-79c6-4d16-b005-2fc280e75b37")]
	public partial class VModellvarianteHasProjekttypvarianten : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasProjekttypvarianten domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("5527c522-79c6-4d16-b005-2fc280e75b37");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasProjekttypvarianten link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Projekttypvarianten to use as the target of the relationship.</param>
		public VModellvarianteHasProjekttypvarianten(VModellvariante source, global::Tum.VModellXT.Anpassung.Projekttypvarianten target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasProjekttypvarianten.ProjekttypvariantenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasProjekttypvarianten(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasProjekttypvarianten(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasProjekttypvarianten(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasProjekttypvarianten(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("c947d7d8-86ea-4585-bdf8-1f880f43c972");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjekttypvarianten/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjekttypvarianten/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Projekttypvarianten", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasProjekttypvarianten/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("c947d7d8-86ea-4585-bdf8-1f880f43c972")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Projekttypvarianten
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Anpassung.Projekttypvarianten element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ProjekttypvariantenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Anpassung.Projekttypvarianten element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ProjekttypvariantenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Projekttypvarianten domain role code
		
		/// <summary>
		/// Projekttypvarianten domain role Id.
		/// </summary>
		public static readonly global::System.Guid ProjekttypvariantenDomainRoleId = new System.Guid("ff393e16-9c40-46a6-a9d9-58048f03f0ee");
		
		/// <summary>
		/// DomainRole Projekttypvarianten
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjekttypvarianten/Projekttypvarianten.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjekttypvarianten/Projekttypvarianten.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasProjekttypvarianten/Projekttypvarianten.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("ff393e16-9c40-46a6-a9d9-58048f03f0ee")]
		public virtual global::Tum.VModellXT.Anpassung.Projekttypvarianten Projekttypvarianten
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Anpassung.Projekttypvarianten)DslModeling::DomainRoleInfo.GetRolePlayer(this, ProjekttypvariantenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ProjekttypvariantenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Projekttypvarianten of a VModellvariante
		/// <summary>
		/// Gets Projekttypvarianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Anpassung.Projekttypvarianten GetProjekttypvarianten(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Projekttypvarianten;
		}
		
		/// <summary>
		/// Sets Projekttypvarianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetProjekttypvarianten(VModellvariante element, global::Tum.VModellXT.Anpassung.Projekttypvarianten newProjekttypvarianten)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newProjekttypvarianten);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasProjekttypvarianten link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten GetLinkToProjekttypvarianten (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Projekttypvarianten link accessor
		/// <summary>
		/// Get the VModellvarianteHasProjekttypvarianten link to a Projekttypvarianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten GetLinkToVModellvariante (global::Tum.VModellXT.Anpassung.Projekttypvarianten projekttypvariantenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten>(projekttypvariantenInstance, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.ProjekttypvariantenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Projekttypvarianten not obeyed.");
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
		#region VModellvarianteHasProjekttypvarianten instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasProjekttypvarianten links between a given VModellvariante and a Projekttypvarianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Projekttypvarianten target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten>(source, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten link in links )
			{
				if ( target.Equals(link.Projekttypvarianten) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasProjekttypvarianten link between a given VModellvarianteand a Projekttypvarianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Projekttypvarianten target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten>(source, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten link in links )
			{
				if ( target.Equals(link.Projekttypvarianten) )
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
			return global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasProjekttypvarianten";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Projekttypvarianten";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasVortailoring
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVortailoring.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVortailoring.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("3884564a-8a69-4696-8780-10937ced6fcf")]
	public partial class VModellvarianteHasVortailoring : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasVortailoring domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("3884564a-8a69-4696-8780-10937ced6fcf");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasVortailoring link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Vortailoring to use as the target of the relationship.</param>
		public VModellvarianteHasVortailoring(VModellvariante source, global::Tum.VModellXT.Anpassung.Vortailoring target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasVortailoring.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasVortailoring.VortailoringDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasVortailoring(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasVortailoring(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasVortailoring(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasVortailoring(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("74862176-63df-40c7-aef1-b26152ecc5f3");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVortailoring/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVortailoring/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Vortailoring", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasVortailoring/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("74862176-63df-40c7-aef1-b26152ecc5f3")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Vortailoring
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Anpassung.Vortailoring element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VortailoringDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Anpassung.Vortailoring element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VortailoringDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Vortailoring domain role code
		
		/// <summary>
		/// Vortailoring domain role Id.
		/// </summary>
		public static readonly global::System.Guid VortailoringDomainRoleId = new System.Guid("5adb28d8-073b-4a99-95a2-e3ae988657b8");
		
		/// <summary>
		/// DomainRole Vortailoring
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasVortailoring/Vortailoring.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasVortailoring/Vortailoring.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasVortailoring/Vortailoring.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("5adb28d8-073b-4a99-95a2-e3ae988657b8")]
		public virtual global::Tum.VModellXT.Anpassung.Vortailoring Vortailoring
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Anpassung.Vortailoring)DslModeling::DomainRoleInfo.GetRolePlayer(this, VortailoringDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VortailoringDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Vortailoring of a VModellvariante
		/// <summary>
		/// Gets Vortailoring.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Anpassung.Vortailoring GetVortailoring(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Vortailoring;
		}
		
		/// <summary>
		/// Sets Vortailoring.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVortailoring(VModellvariante element, global::Tum.VModellXT.Anpassung.Vortailoring newVortailoring)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newVortailoring);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasVortailoring link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVortailoring GetLinkToVortailoring (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVortailoring> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVortailoring>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Vortailoring link accessor
		/// <summary>
		/// Get the VModellvarianteHasVortailoring link to a Vortailoring.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVortailoring GetLinkToVModellvariante (global::Tum.VModellXT.Anpassung.Vortailoring vortailoringInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVortailoring> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVortailoring>(vortailoringInstance, global::Tum.VModellXT.VModellvarianteHasVortailoring.VortailoringDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Vortailoring not obeyed.");
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
		#region VModellvarianteHasVortailoring instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasVortailoring links between a given VModellvariante and a Vortailoring.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasVortailoring> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Vortailoring target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasVortailoring> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasVortailoring>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVortailoring> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVortailoring>(source, global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasVortailoring link in links )
			{
				if ( target.Equals(link.Vortailoring) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasVortailoring link between a given VModellvarianteand a Vortailoring.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasVortailoring GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Vortailoring target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasVortailoring> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasVortailoring>(source, global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasVortailoring link in links )
			{
				if ( target.Equals(link.Vortailoring) )
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
			return global::Tum.VModellXT.VModellvarianteHasVortailoring.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasVortailoring";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Vortailoring";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasEntscheidungspunkte
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("2291b985-0ed2-482a-a31d-40bffca0ea4d")]
	public partial class VModellvarianteHasEntscheidungspunkte : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasEntscheidungspunkte domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("2291b985-0ed2-482a-a31d-40bffca0ea4d");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasEntscheidungspunkte link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Entscheidungspunkte to use as the target of the relationship.</param>
		public VModellvarianteHasEntscheidungspunkte(VModellvariante source, global::Tum.VModellXT.Statik.Entscheidungspunkte target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasEntscheidungspunkte.EntscheidungspunkteDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasEntscheidungspunkte(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasEntscheidungspunkte(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasEntscheidungspunkte(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasEntscheidungspunkte(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("688aa038-76ed-43a2-b909-6e3a5705af77");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasEntscheidungspunkte/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasEntscheidungspunkte/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Entscheidungspunkte", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasEntscheidungspunkte/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("688aa038-76ed-43a2-b909-6e3a5705af77")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Entscheidungspunkte
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Statik.Entscheidungspunkte element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, EntscheidungspunkteDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Statik.Entscheidungspunkte element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, EntscheidungspunkteDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Entscheidungspunkte domain role code
		
		/// <summary>
		/// Entscheidungspunkte domain role Id.
		/// </summary>
		public static readonly global::System.Guid EntscheidungspunkteDomainRoleId = new System.Guid("16651390-ee5e-48a1-a2b4-d1d5f65b3683");
		
		/// <summary>
		/// DomainRole Entscheidungspunkte
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasEntscheidungspunkte/Entscheidungspunkte.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasEntscheidungspunkte/Entscheidungspunkte.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasEntscheidungspunkte/Entscheidungspunkte.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("16651390-ee5e-48a1-a2b4-d1d5f65b3683")]
		public virtual global::Tum.VModellXT.Statik.Entscheidungspunkte Entscheidungspunkte
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Statik.Entscheidungspunkte)DslModeling::DomainRoleInfo.GetRolePlayer(this, EntscheidungspunkteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, EntscheidungspunkteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Entscheidungspunkte of a VModellvariante
		/// <summary>
		/// Gets Entscheidungspunkte.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Statik.Entscheidungspunkte GetEntscheidungspunkte(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Statik.Entscheidungspunkte;
		}
		
		/// <summary>
		/// Sets Entscheidungspunkte.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetEntscheidungspunkte(VModellvariante element, global::Tum.VModellXT.Statik.Entscheidungspunkte newEntscheidungspunkte)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newEntscheidungspunkte);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasEntscheidungspunkte link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte GetLinkToEntscheidungspunkte (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Entscheidungspunkte link accessor
		/// <summary>
		/// Get the VModellvarianteHasEntscheidungspunkte link to a Entscheidungspunkte.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte GetLinkToVModellvariante (global::Tum.VModellXT.Statik.Entscheidungspunkte entscheidungspunkteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte>(entscheidungspunkteInstance, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.EntscheidungspunkteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Entscheidungspunkte not obeyed.");
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
		#region VModellvarianteHasEntscheidungspunkte instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasEntscheidungspunkte links between a given VModellvariante and a Entscheidungspunkte.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Statik.Entscheidungspunkte target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte>(source, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte link in links )
			{
				if ( target.Equals(link.Entscheidungspunkte) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasEntscheidungspunkte link between a given VModellvarianteand a Entscheidungspunkte.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Statik.Entscheidungspunkte target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte>(source, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte link in links )
			{
				if ( target.Equals(link.Entscheidungspunkte) )
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
			return global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasEntscheidungspunkte";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Entscheidungspunkte";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasProjektmerkmale
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjektmerkmale.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjektmerkmale.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("874bf8bb-d603-4775-b34b-78904a0bd9a1")]
	public partial class VModellvarianteHasProjektmerkmale : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasProjektmerkmale domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("874bf8bb-d603-4775-b34b-78904a0bd9a1");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasProjektmerkmale link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Projektmerkmale to use as the target of the relationship.</param>
		public VModellvarianteHasProjektmerkmale(VModellvariante source, global::Tum.VModellXT.Anpassung.Projektmerkmale target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasProjektmerkmale.ProjektmerkmaleDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasProjektmerkmale(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasProjektmerkmale(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasProjektmerkmale(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasProjektmerkmale(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("9de9fc76-8b50-4fa1-ad25-bd098665efaf");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjektmerkmale/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjektmerkmale/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Projektmerkmale", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasProjektmerkmale/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("9de9fc76-8b50-4fa1-ad25-bd098665efaf")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Projektmerkmale
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Anpassung.Projektmerkmale element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ProjektmerkmaleDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Anpassung.Projektmerkmale element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ProjektmerkmaleDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Projektmerkmale domain role code
		
		/// <summary>
		/// Projektmerkmale domain role Id.
		/// </summary>
		public static readonly global::System.Guid ProjektmerkmaleDomainRoleId = new System.Guid("e704c75d-e79a-44d1-93fd-9d87a773b7ee");
		
		/// <summary>
		/// DomainRole Projektmerkmale
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasProjektmerkmale/Projektmerkmale.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasProjektmerkmale/Projektmerkmale.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasProjektmerkmale/Projektmerkmale.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("e704c75d-e79a-44d1-93fd-9d87a773b7ee")]
		public virtual global::Tum.VModellXT.Anpassung.Projektmerkmale Projektmerkmale
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Anpassung.Projektmerkmale)DslModeling::DomainRoleInfo.GetRolePlayer(this, ProjektmerkmaleDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ProjektmerkmaleDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Projektmerkmale of a VModellvariante
		/// <summary>
		/// Gets Projektmerkmale.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Anpassung.Projektmerkmale GetProjektmerkmale(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Projektmerkmale;
		}
		
		/// <summary>
		/// Sets Projektmerkmale.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetProjektmerkmale(VModellvariante element, global::Tum.VModellXT.Anpassung.Projektmerkmale newProjektmerkmale)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newProjektmerkmale);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasProjektmerkmale link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjektmerkmale GetLinkToProjektmerkmale (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Projektmerkmale link accessor
		/// <summary>
		/// Get the VModellvarianteHasProjektmerkmale link to a Projektmerkmale.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjektmerkmale GetLinkToVModellvariante (global::Tum.VModellXT.Anpassung.Projektmerkmale projektmerkmaleInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale>(projektmerkmaleInstance, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.ProjektmerkmaleDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Projektmerkmale not obeyed.");
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
		#region VModellvarianteHasProjektmerkmale instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasProjektmerkmale links between a given VModellvariante and a Projektmerkmale.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Projektmerkmale target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale>(source, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasProjektmerkmale link in links )
			{
				if ( target.Equals(link.Projektmerkmale) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasProjektmerkmale link between a given VModellvarianteand a Projektmerkmale.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasProjektmerkmale GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Anpassung.Projektmerkmale target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasProjektmerkmale>(source, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasProjektmerkmale link in links )
			{
				if ( target.Equals(link.Projektmerkmale) )
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
			return global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasProjektmerkmale";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Projektmerkmale";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasKonventionsabbildungen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("f80ad9c4-0f68-44c5-9857-aecaaf674aa7")]
	public partial class VModellvarianteHasKonventionsabbildungen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasKonventionsabbildungen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("f80ad9c4-0f68-44c5-9857-aecaaf674aa7");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasKonventionsabbildungen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Konventionsabbildungen to use as the target of the relationship.</param>
		public VModellvarianteHasKonventionsabbildungen(VModellvariante source, global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasKonventionsabbildungen.KonventionsabbildungenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasKonventionsabbildungen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasKonventionsabbildungen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasKonventionsabbildungen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasKonventionsabbildungen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("47dbaeb5-4bad-40b3-a4ec-f50f36080e3b");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasKonventionsabbildungen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasKonventionsabbildungen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Konventionsabbildungen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasKonventionsabbildungen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("47dbaeb5-4bad-40b3-a4ec-f50f36080e3b")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Konventionsabbildungen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, KonventionsabbildungenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, KonventionsabbildungenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Konventionsabbildungen domain role code
		
		/// <summary>
		/// Konventionsabbildungen domain role Id.
		/// </summary>
		public static readonly global::System.Guid KonventionsabbildungenDomainRoleId = new System.Guid("dc32a7a3-dab7-4ee3-8ffe-e27938562f8c");
		
		/// <summary>
		/// DomainRole Konventionsabbildungen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasKonventionsabbildungen/Konventionsabbildungen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasKonventionsabbildungen/Konventionsabbildungen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasKonventionsabbildungen/Konventionsabbildungen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("dc32a7a3-dab7-4ee3-8ffe-e27938562f8c")]
		public virtual global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen Konventionsabbildungen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen)DslModeling::DomainRoleInfo.GetRolePlayer(this, KonventionsabbildungenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, KonventionsabbildungenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Konventionsabbildungen of a VModellvariante
		/// <summary>
		/// Gets Konventionsabbildungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen GetKonventionsabbildungen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen;
		}
		
		/// <summary>
		/// Sets Konventionsabbildungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetKonventionsabbildungen(VModellvariante element, global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen newKonventionsabbildungen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newKonventionsabbildungen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasKonventionsabbildungen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen GetLinkToKonventionsabbildungen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Konventionsabbildungen link accessor
		/// <summary>
		/// Get the VModellvarianteHasKonventionsabbildungen link to a Konventionsabbildungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen GetLinkToVModellvariante (global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen konventionsabbildungenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen>(konventionsabbildungenInstance, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.KonventionsabbildungenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Konventionsabbildungen not obeyed.");
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
		#region VModellvarianteHasKonventionsabbildungen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasKonventionsabbildungen links between a given VModellvariante and a Konventionsabbildungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen>(source, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen link in links )
			{
				if ( target.Equals(link.Konventionsabbildungen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasKonventionsabbildungen link between a given VModellvarianteand a Konventionsabbildungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen>(source, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen link in links )
			{
				if ( target.Equals(link.Konventionsabbildungen) )
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
			return global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasKonventionsabbildungen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Konventionsabbildungen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasMethodenreferenzen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasMethodenreferenzen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasMethodenreferenzen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("015106d8-b887-4923-afa7-864a680a3774")]
	public partial class VModellvarianteHasMethodenreferenzen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasMethodenreferenzen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("015106d8-b887-4923-afa7-864a680a3774");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasMethodenreferenzen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Methodenreferenzen to use as the target of the relationship.</param>
		public VModellvarianteHasMethodenreferenzen(VModellvariante source, global::Tum.VModellXT.Basis.Methodenreferenzen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasMethodenreferenzen.MethodenreferenzenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasMethodenreferenzen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasMethodenreferenzen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasMethodenreferenzen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasMethodenreferenzen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("0599ffd0-d528-497b-a488-ab15da33b4d4");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasMethodenreferenzen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasMethodenreferenzen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Methodenreferenzen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasMethodenreferenzen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("0599ffd0-d528-497b-a488-ab15da33b4d4")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Methodenreferenzen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.Methodenreferenzen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, MethodenreferenzenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.Methodenreferenzen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, MethodenreferenzenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Methodenreferenzen domain role code
		
		/// <summary>
		/// Methodenreferenzen domain role Id.
		/// </summary>
		public static readonly global::System.Guid MethodenreferenzenDomainRoleId = new System.Guid("c606b09c-dd99-47cc-a920-602c0c12c7e4");
		
		/// <summary>
		/// DomainRole Methodenreferenzen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasMethodenreferenzen/Methodenreferenzen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasMethodenreferenzen/Methodenreferenzen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasMethodenreferenzen/Methodenreferenzen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("c606b09c-dd99-47cc-a920-602c0c12c7e4")]
		public virtual global::Tum.VModellXT.Basis.Methodenreferenzen Methodenreferenzen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.Methodenreferenzen)DslModeling::DomainRoleInfo.GetRolePlayer(this, MethodenreferenzenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MethodenreferenzenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Methodenreferenzen of a VModellvariante
		/// <summary>
		/// Gets Methodenreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.Methodenreferenzen GetMethodenreferenzen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Methodenreferenzen;
		}
		
		/// <summary>
		/// Sets Methodenreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetMethodenreferenzen(VModellvariante element, global::Tum.VModellXT.Basis.Methodenreferenzen newMethodenreferenzen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newMethodenreferenzen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasMethodenreferenzen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen GetLinkToMethodenreferenzen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Methodenreferenzen link accessor
		/// <summary>
		/// Get the VModellvarianteHasMethodenreferenzen link to a Methodenreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen GetLinkToVModellvariante (global::Tum.VModellXT.Basis.Methodenreferenzen methodenreferenzenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen>(methodenreferenzenInstance, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.MethodenreferenzenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Methodenreferenzen not obeyed.");
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
		#region VModellvarianteHasMethodenreferenzen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasMethodenreferenzen links between a given VModellvariante and a Methodenreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Methodenreferenzen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen>(source, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen link in links )
			{
				if ( target.Equals(link.Methodenreferenzen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasMethodenreferenzen link between a given VModellvarianteand a Methodenreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Methodenreferenzen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen>(source, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen link in links )
			{
				if ( target.Equals(link.Methodenreferenzen) )
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
			return global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasMethodenreferenzen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Methodenreferenzen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasWerkzeugreferenzen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("0c3820d1-66de-474f-a763-8cbda474f264")]
	public partial class VModellvarianteHasWerkzeugreferenzen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasWerkzeugreferenzen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("0c3820d1-66de-474f-a763-8cbda474f264");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasWerkzeugreferenzen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Werkzeugreferenzen to use as the target of the relationship.</param>
		public VModellvarianteHasWerkzeugreferenzen(VModellvariante source, global::Tum.VModellXT.Basis.Werkzeugreferenzen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasWerkzeugreferenzen.WerkzeugreferenzenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasWerkzeugreferenzen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasWerkzeugreferenzen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasWerkzeugreferenzen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasWerkzeugreferenzen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("a677c01b-c961-4021-ab2e-5b82186ec311");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Werkzeugreferenzen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("a677c01b-c961-4021-ab2e-5b82186ec311")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Werkzeugreferenzen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.Werkzeugreferenzen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, WerkzeugreferenzenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.Werkzeugreferenzen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, WerkzeugreferenzenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Werkzeugreferenzen domain role code
		
		/// <summary>
		/// Werkzeugreferenzen domain role Id.
		/// </summary>
		public static readonly global::System.Guid WerkzeugreferenzenDomainRoleId = new System.Guid("2f4d86cf-1487-4ed7-8608-fa804bf27115");
		
		/// <summary>
		/// DomainRole Werkzeugreferenzen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen/Werkzeugreferenzen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen/Werkzeugreferenzen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen/Werkzeugreferenzen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("2f4d86cf-1487-4ed7-8608-fa804bf27115")]
		public virtual global::Tum.VModellXT.Basis.Werkzeugreferenzen Werkzeugreferenzen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.Werkzeugreferenzen)DslModeling::DomainRoleInfo.GetRolePlayer(this, WerkzeugreferenzenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, WerkzeugreferenzenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Werkzeugreferenzen of a VModellvariante
		/// <summary>
		/// Gets Werkzeugreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.Werkzeugreferenzen GetWerkzeugreferenzen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Werkzeugreferenzen;
		}
		
		/// <summary>
		/// Sets Werkzeugreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetWerkzeugreferenzen(VModellvariante element, global::Tum.VModellXT.Basis.Werkzeugreferenzen newWerkzeugreferenzen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newWerkzeugreferenzen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasWerkzeugreferenzen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen GetLinkToWerkzeugreferenzen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Werkzeugreferenzen link accessor
		/// <summary>
		/// Get the VModellvarianteHasWerkzeugreferenzen link to a Werkzeugreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen GetLinkToVModellvariante (global::Tum.VModellXT.Basis.Werkzeugreferenzen werkzeugreferenzenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen>(werkzeugreferenzenInstance, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.WerkzeugreferenzenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Werkzeugreferenzen not obeyed.");
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
		#region VModellvarianteHasWerkzeugreferenzen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasWerkzeugreferenzen links between a given VModellvariante and a Werkzeugreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Werkzeugreferenzen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen>(source, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen link in links )
			{
				if ( target.Equals(link.Werkzeugreferenzen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasWerkzeugreferenzen link between a given VModellvarianteand a Werkzeugreferenzen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Werkzeugreferenzen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen>(source, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen link in links )
			{
				if ( target.Equals(link.Werkzeugreferenzen) )
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
			return global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasWerkzeugreferenzen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Werkzeugreferenzen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasGlossar
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasGlossar.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasGlossar.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("d57a9c94-baf9-46dd-a1b7-1dbc6e083b20")]
	public partial class VModellvarianteHasGlossar : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasGlossar domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("d57a9c94-baf9-46dd-a1b7-1dbc6e083b20");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasGlossar link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Glossar to use as the target of the relationship.</param>
		public VModellvarianteHasGlossar(VModellvariante source, global::Tum.VModellXT.Basis.Glossar target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasGlossar.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasGlossar.GlossarDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasGlossar(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasGlossar(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasGlossar(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasGlossar(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("91982be1-79f7-482c-b8b9-6238ef4f5b48");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasGlossar/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasGlossar/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Glossar", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasGlossar/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("91982be1-79f7-482c-b8b9-6238ef4f5b48")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Glossar
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.Glossar element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, GlossarDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.Glossar element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, GlossarDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Glossar domain role code
		
		/// <summary>
		/// Glossar domain role Id.
		/// </summary>
		public static readonly global::System.Guid GlossarDomainRoleId = new System.Guid("a5b3120b-7968-4e63-b6eb-e5c120c1a964");
		
		/// <summary>
		/// DomainRole Glossar
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasGlossar/Glossar.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasGlossar/Glossar.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasGlossar/Glossar.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("a5b3120b-7968-4e63-b6eb-e5c120c1a964")]
		public virtual global::Tum.VModellXT.Basis.Glossar Glossar
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.Glossar)DslModeling::DomainRoleInfo.GetRolePlayer(this, GlossarDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, GlossarDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Glossar of a VModellvariante
		/// <summary>
		/// Gets Glossar.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.Glossar GetGlossar(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Glossar;
		}
		
		/// <summary>
		/// Sets Glossar.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetGlossar(VModellvariante element, global::Tum.VModellXT.Basis.Glossar newGlossar)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newGlossar);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasGlossar link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasGlossar GetLinkToGlossar (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasGlossar> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasGlossar>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Glossar link accessor
		/// <summary>
		/// Get the VModellvarianteHasGlossar link to a Glossar.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasGlossar GetLinkToVModellvariante (global::Tum.VModellXT.Basis.Glossar glossarInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasGlossar> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasGlossar>(glossarInstance, global::Tum.VModellXT.VModellvarianteHasGlossar.GlossarDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Glossar not obeyed.");
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
		#region VModellvarianteHasGlossar instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasGlossar links between a given VModellvariante and a Glossar.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasGlossar> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Glossar target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasGlossar> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasGlossar>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasGlossar> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasGlossar>(source, global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasGlossar link in links )
			{
				if ( target.Equals(link.Glossar) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasGlossar link between a given VModellvarianteand a Glossar.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasGlossar GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Glossar target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasGlossar> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasGlossar>(source, global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasGlossar link in links )
			{
				if ( target.Equals(link.Glossar) )
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
			return global::Tum.VModellXT.VModellvarianteHasGlossar.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasGlossar";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Glossar";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasAbkuerzungen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAbkuerzungen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAbkuerzungen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("2e657e6a-6384-448d-9a29-dabb03c28e12")]
	public partial class VModellvarianteHasAbkuerzungen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasAbkuerzungen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("2e657e6a-6384-448d-9a29-dabb03c28e12");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasAbkuerzungen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Abkuerzungen to use as the target of the relationship.</param>
		public VModellvarianteHasAbkuerzungen(VModellvariante source, global::Tum.VModellXT.Basis.Abkuerzungen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasAbkuerzungen.AbkuerzungenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAbkuerzungen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAbkuerzungen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAbkuerzungen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAbkuerzungen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("ace10134-9460-4eac-bafd-6a16aff007ac");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAbkuerzungen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAbkuerzungen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Abkuerzungen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAbkuerzungen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("ace10134-9460-4eac-bafd-6a16aff007ac")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Abkuerzungen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.Abkuerzungen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, AbkuerzungenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.Abkuerzungen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, AbkuerzungenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Abkuerzungen domain role code
		
		/// <summary>
		/// Abkuerzungen domain role Id.
		/// </summary>
		public static readonly global::System.Guid AbkuerzungenDomainRoleId = new System.Guid("3bf5ee29-c3dc-40bf-bb47-7ab0491777a7");
		
		/// <summary>
		/// DomainRole Abkuerzungen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAbkuerzungen/Abkuerzungen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAbkuerzungen/Abkuerzungen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAbkuerzungen/Abkuerzungen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("3bf5ee29-c3dc-40bf-bb47-7ab0491777a7")]
		public virtual global::Tum.VModellXT.Basis.Abkuerzungen Abkuerzungen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.Abkuerzungen)DslModeling::DomainRoleInfo.GetRolePlayer(this, AbkuerzungenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, AbkuerzungenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Abkuerzungen of a VModellvariante
		/// <summary>
		/// Gets Abkuerzungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.Abkuerzungen GetAbkuerzungen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Abkuerzungen;
		}
		
		/// <summary>
		/// Sets Abkuerzungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetAbkuerzungen(VModellvariante element, global::Tum.VModellXT.Basis.Abkuerzungen newAbkuerzungen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newAbkuerzungen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasAbkuerzungen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAbkuerzungen GetLinkToAbkuerzungen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Abkuerzungen link accessor
		/// <summary>
		/// Get the VModellvarianteHasAbkuerzungen link to a Abkuerzungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAbkuerzungen GetLinkToVModellvariante (global::Tum.VModellXT.Basis.Abkuerzungen abkuerzungenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen>(abkuerzungenInstance, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.AbkuerzungenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Abkuerzungen not obeyed.");
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
		#region VModellvarianteHasAbkuerzungen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasAbkuerzungen links between a given VModellvariante and a Abkuerzungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Abkuerzungen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen>(source, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAbkuerzungen link in links )
			{
				if ( target.Equals(link.Abkuerzungen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasAbkuerzungen link between a given VModellvarianteand a Abkuerzungen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAbkuerzungen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Abkuerzungen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAbkuerzungen>(source, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAbkuerzungen link in links )
			{
				if ( target.Equals(link.Abkuerzungen) )
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
			return global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasAbkuerzungen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Abkuerzungen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasQuellen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasQuellen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasQuellen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("530bd659-ea5f-445e-9f29-ae25feb6f759")]
	public partial class VModellvarianteHasQuellen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasQuellen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("530bd659-ea5f-445e-9f29-ae25feb6f759");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasQuellen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Quellen to use as the target of the relationship.</param>
		public VModellvarianteHasQuellen(VModellvariante source, global::Tum.VModellXT.Basis.Quellen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasQuellen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasQuellen.QuellenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasQuellen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasQuellen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasQuellen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasQuellen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("124d976e-57ac-4ade-9474-65e022bf7ff8");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasQuellen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasQuellen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Quellen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasQuellen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("124d976e-57ac-4ade-9474-65e022bf7ff8")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Quellen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Basis.Quellen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, QuellenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Basis.Quellen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, QuellenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Quellen domain role code
		
		/// <summary>
		/// Quellen domain role Id.
		/// </summary>
		public static readonly global::System.Guid QuellenDomainRoleId = new System.Guid("250d648d-19a1-42ad-bd81-54efe1f823f6");
		
		/// <summary>
		/// DomainRole Quellen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasQuellen/Quellen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasQuellen/Quellen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasQuellen/Quellen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("250d648d-19a1-42ad-bd81-54efe1f823f6")]
		public virtual global::Tum.VModellXT.Basis.Quellen Quellen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Basis.Quellen)DslModeling::DomainRoleInfo.GetRolePlayer(this, QuellenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, QuellenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Quellen of a VModellvariante
		/// <summary>
		/// Gets Quellen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Basis.Quellen GetQuellen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Quellen;
		}
		
		/// <summary>
		/// Sets Quellen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetQuellen(VModellvariante element, global::Tum.VModellXT.Basis.Quellen newQuellen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newQuellen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasQuellen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasQuellen GetLinkToQuellen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasQuellen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasQuellen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Quellen link accessor
		/// <summary>
		/// Get the VModellvarianteHasQuellen link to a Quellen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasQuellen GetLinkToVModellvariante (global::Tum.VModellXT.Basis.Quellen quellenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasQuellen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasQuellen>(quellenInstance, global::Tum.VModellXT.VModellvarianteHasQuellen.QuellenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Quellen not obeyed.");
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
		#region VModellvarianteHasQuellen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasQuellen links between a given VModellvariante and a Quellen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasQuellen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Quellen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasQuellen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasQuellen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasQuellen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasQuellen>(source, global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasQuellen link in links )
			{
				if ( target.Equals(link.Quellen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasQuellen link between a given VModellvarianteand a Quellen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasQuellen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Basis.Quellen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasQuellen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasQuellen>(source, global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasQuellen link in links )
			{
				if ( target.Equals(link.Quellen) )
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
			return global::Tum.VModellXT.VModellvarianteHasQuellen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasQuellen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Quellen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasAenderungsoperationen
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAenderungsoperationen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAenderungsoperationen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("abdb7b8f-5445-4596-b41b-18cf3fc93adc")]
	public partial class VModellvarianteHasAenderungsoperationen : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasAenderungsoperationen domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("abdb7b8f-5445-4596-b41b-18cf3fc93adc");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasAenderungsoperationen link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Aenderungsoperationen to use as the target of the relationship.</param>
		public VModellvarianteHasAenderungsoperationen(VModellvariante source, global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasAenderungsoperationen.AenderungsoperationenDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAenderungsoperationen(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAenderungsoperationen(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasAenderungsoperationen(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasAenderungsoperationen(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("f881b30d-ada9-47bf-aacf-d13c37f58d19");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAenderungsoperationen/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAenderungsoperationen/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Aenderungsoperationen", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAenderungsoperationen/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("f881b30d-ada9-47bf-aacf-d13c37f58d19")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Aenderungsoperationen
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, AenderungsoperationenDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, AenderungsoperationenDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Aenderungsoperationen domain role code
		
		/// <summary>
		/// Aenderungsoperationen domain role Id.
		/// </summary>
		public static readonly global::System.Guid AenderungsoperationenDomainRoleId = new System.Guid("f4c3c011-2d66-4de7-bbf6-f1573003c665");
		
		/// <summary>
		/// DomainRole Aenderungsoperationen
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasAenderungsoperationen/Aenderungsoperationen.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasAenderungsoperationen/Aenderungsoperationen.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasAenderungsoperationen/Aenderungsoperationen.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("f4c3c011-2d66-4de7-bbf6-f1573003c665")]
		public virtual global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen Aenderungsoperationen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen)DslModeling::DomainRoleInfo.GetRolePlayer(this, AenderungsoperationenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, AenderungsoperationenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Aenderungsoperationen of a VModellvariante
		/// <summary>
		/// Gets Aenderungsoperationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen GetAenderungsoperationen(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen;
		}
		
		/// <summary>
		/// Sets Aenderungsoperationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetAenderungsoperationen(VModellvariante element, global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen newAenderungsoperationen)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newAenderungsoperationen);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasAenderungsoperationen link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen GetLinkToAenderungsoperationen (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Aenderungsoperationen link accessor
		/// <summary>
		/// Get the VModellvarianteHasAenderungsoperationen link to a Aenderungsoperationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen GetLinkToVModellvariante (global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen aenderungsoperationenInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen>(aenderungsoperationenInstance, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.AenderungsoperationenDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Aenderungsoperationen not obeyed.");
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
		#region VModellvarianteHasAenderungsoperationen instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasAenderungsoperationen links between a given VModellvariante and a Aenderungsoperationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen>(source, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen link in links )
			{
				if ( target.Equals(link.Aenderungsoperationen) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasAenderungsoperationen link between a given VModellvarianteand a Aenderungsoperationen.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen>(source, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen link in links )
			{
				if ( target.Equals(link.Aenderungsoperationen) )
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
			return global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasAenderungsoperationen";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Aenderungsoperationen";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VModellvarianteHasReferenzmodell
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasReferenzmodell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasReferenzmodell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("d8d23e0c-6a7b-4453-b4bb-76186b7491b6")]
	public partial class VModellvarianteHasReferenzmodell : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvarianteHasReferenzmodell domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("d8d23e0c-6a7b-4453-b4bb-76186b7491b6");

				
		/// <summary>
		/// Constructor
		/// Creates a VModellvarianteHasReferenzmodell link in the same Partition as the given VModellvariante
		/// </summary>
		/// <param name="source">VModellvariante to use as the source of the relationship.</param>
		/// <param name="target">Referenzmodell to use as the target of the relationship.</param>
		public VModellvarianteHasReferenzmodell(VModellvariante source, Referenzmodell target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId, source), new DslModeling::RoleAssignment(VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasReferenzmodell(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasReferenzmodell(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VModellvarianteHasReferenzmodell(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VModellvarianteHasReferenzmodell(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("6fdc6981-f4cb-4d0b-86b2-d7bde6359185");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasReferenzmodell/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasReferenzmodell/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Referenzmodell", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasReferenzmodell/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("6fdc6981-f4cb-4d0b-86b2-d7bde6359185")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvariante of a Referenzmodell
		/// <summary>
		/// Gets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvariante(Referenzmodell element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ReferenzmodellDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvariante(Referenzmodell element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ReferenzmodellDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Referenzmodell domain role code
		
		/// <summary>
		/// Referenzmodell domain role Id.
		/// </summary>
		public static readonly global::System.Guid ReferenzmodellDomainRoleId = new System.Guid("e6286bad-16fe-4266-8df1-5843ac22b6b4");
		
		/// <summary>
		/// DomainRole Referenzmodell
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvarianteHasReferenzmodell/Referenzmodell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvarianteHasReferenzmodell/Referenzmodell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VModellvariante", PropertyDisplayNameKey="Tum.VModellXT.VModellvarianteHasReferenzmodell/Referenzmodell.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("e6286bad-16fe-4266-8df1-5843ac22b6b4")]
		public virtual Referenzmodell Referenzmodell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Referenzmodell)DslModeling::DomainRoleInfo.GetRolePlayer(this, ReferenzmodellDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ReferenzmodellDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Referenzmodell of a VModellvariante
		/// <summary>
		/// Gets Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Referenzmodell GetReferenzmodell(VModellvariante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellvarianteDomainRoleId) as Referenzmodell;
		}
		
		/// <summary>
		/// Sets Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetReferenzmodell(VModellvariante element, Referenzmodell newReferenzmodell)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellvarianteDomainRoleId, newReferenzmodell);
		}
		#endregion
		#region VModellvariante link accessor
		/// <summary>
		/// Get the VModellvarianteHasReferenzmodell link to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasReferenzmodell GetLinkToReferenzmodell (global::Tum.VModellXT.VModellvariante vModellvarianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasReferenzmodell>(vModellvarianteInstance, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModellvariante not obeyed.");
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
		#region Referenzmodell link accessor
		/// <summary>
		/// Get the VModellvarianteHasReferenzmodell link to a Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasReferenzmodell GetLinkToVModellvariante (global::Tum.VModellXT.Referenzmodell referenzmodellInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasReferenzmodell>(referenzmodellInstance, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Referenzmodell not obeyed.");
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
		#region VModellvarianteHasReferenzmodell instance accessors
		
		/// <summary>
		/// Get any VModellvarianteHasReferenzmodell links between a given VModellvariante and a Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> GetLinks( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Referenzmodell target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VModellvarianteHasReferenzmodell>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasReferenzmodell>(source, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasReferenzmodell link in links )
			{
				if ( target.Equals(link.Referenzmodell) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VModellvarianteHasReferenzmodell link between a given VModellvarianteand a Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VModellvarianteHasReferenzmodell GetLink( global::Tum.VModellXT.VModellvariante source, global::Tum.VModellXT.Referenzmodell target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VModellvarianteHasReferenzmodell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VModellvarianteHasReferenzmodell>(source, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId);
			foreach ( global::Tum.VModellXT.VModellvarianteHasReferenzmodell link in links )
			{
				if ( target.Equals(link.Referenzmodell) )
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
			return global::Tum.VModellXT.VModellvarianteHasReferenzmodell.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VModellvarianteHasReferenzmodell";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModellvariante Has Referenzmodell";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ReferenzmodellHasVModell
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ReferenzmodellHasVModell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ReferenzmodellHasVModell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("1e215e00-adca-4e48-a503-951102067116")]
	public partial class ReferenzmodellHasVModell : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ReferenzmodellHasVModell domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("1e215e00-adca-4e48-a503-951102067116");

				
		/// <summary>
		/// Constructor
		/// Creates a ReferenzmodellHasVModell link in the same Partition as the given Referenzmodell
		/// </summary>
		/// <param name="source">Referenzmodell to use as the source of the relationship.</param>
		/// <param name="target">VModell to use as the target of the relationship.</param>
		public ReferenzmodellHasVModell(Referenzmodell source, VModell target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ReferenzmodellHasVModell.ReferenzmodellDomainRoleId, source), new DslModeling::RoleAssignment(ReferenzmodellHasVModell.VModellDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ReferenzmodellHasVModell(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ReferenzmodellHasVModell(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ReferenzmodellHasVModell(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ReferenzmodellHasVModell(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Referenzmodell domain role code
		
		/// <summary>
		/// Referenzmodell domain role Id.
		/// </summary>
		public static readonly global::System.Guid ReferenzmodellDomainRoleId = new System.Guid("7a4ae6e8-e149-4559-aedf-f964ded62ec0");
		
		/// <summary>
		/// DomainRole Referenzmodell
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ReferenzmodellHasVModell/Referenzmodell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ReferenzmodellHasVModell/Referenzmodell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "VModell", PropertyDisplayNameKey="Tum.VModellXT.ReferenzmodellHasVModell/Referenzmodell.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("7a4ae6e8-e149-4559-aedf-f964ded62ec0")]
		public virtual Referenzmodell Referenzmodell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Referenzmodell)DslModeling::DomainRoleInfo.GetRolePlayer(this, ReferenzmodellDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ReferenzmodellDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Referenzmodell of a VModell
		/// <summary>
		/// Gets Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Referenzmodell GetReferenzmodell(VModell element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellDomainRoleId) as Referenzmodell;
		}
		
		/// <summary>
		/// Sets Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetReferenzmodell(VModell element, Referenzmodell newReferenzmodell)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellDomainRoleId, newReferenzmodell);
		}
		#endregion
		#region VModell domain role code
		
		/// <summary>
		/// VModell domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellDomainRoleId = new System.Guid("8c91b611-058f-4c9d-96aa-edfe3ed3d969");
		
		/// <summary>
		/// DomainRole VModell
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ReferenzmodellHasVModell/VModell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ReferenzmodellHasVModell/VModell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Referenzmodell", PropertyDisplayNameKey="Tum.VModellXT.ReferenzmodellHasVModell/VModell.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("8c91b611-058f-4c9d-96aa-edfe3ed3d969")]
		public virtual VModell VModell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModell)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModell of a Referenzmodell
		/// <summary>
		/// Gets VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModell GetVModell(Referenzmodell element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ReferenzmodellDomainRoleId) as VModell;
		}
		
		/// <summary>
		/// Sets VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModell(Referenzmodell element, VModell newVModell)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ReferenzmodellDomainRoleId, newVModell);
		}
		#endregion
		#region Referenzmodell link accessor
		/// <summary>
		/// Get the ReferenzmodellHasVModell link to a Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ReferenzmodellHasVModell GetLinkToVModell (global::Tum.VModellXT.Referenzmodell referenzmodellInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellHasVModell>(referenzmodellInstance, global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Referenzmodell not obeyed.");
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
		#region VModell link accessor
		/// <summary>
		/// Get the ReferenzmodellHasVModell link to a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ReferenzmodellHasVModell GetLinkToReferenzmodell (global::Tum.VModellXT.VModell vModellInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellHasVModell>(vModellInstance, global::Tum.VModellXT.ReferenzmodellHasVModell.VModellDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModell not obeyed.");
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
		#region ReferenzmodellHasVModell instance accessors
		
		/// <summary>
		/// Get any ReferenzmodellHasVModell links between a given Referenzmodell and a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ReferenzmodellHasVModell> GetLinks( global::Tum.VModellXT.Referenzmodell source, global::Tum.VModellXT.VModell target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ReferenzmodellHasVModell> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ReferenzmodellHasVModell>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellHasVModell>(source, global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId);
			foreach ( global::Tum.VModellXT.ReferenzmodellHasVModell link in links )
			{
				if ( target.Equals(link.VModell) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ReferenzmodellHasVModell link between a given Referenzmodelland a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ReferenzmodellHasVModell GetLink( global::Tum.VModellXT.Referenzmodell source, global::Tum.VModellXT.VModell target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellHasVModell>(source, global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId);
			foreach ( global::Tum.VModellXT.ReferenzmodellHasVModell link in links )
			{
				if ( target.Equals(link.VModell) )
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
			return global::Tum.VModellXT.ReferenzmodellHasVModell.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ReferenzmodellHasVModell";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Referenzmodell Has VModell";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ReferenzmodellReferencesVModellvariante
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ReferenzmodellReferencesVModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ReferenzmodellReferencesVModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("64c419e0-0043-42f4-92b3-9473dc514026")]
	public partial class ReferenzmodellReferencesVModellvariante : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ReferenzmodellReferencesVModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("64c419e0-0043-42f4-92b3-9473dc514026");

				
		/// <summary>
		/// Constructor
		/// Creates a ReferenzmodellReferencesVModellvariante link in the same Partition as the given Referenzmodell
		/// </summary>
		/// <param name="source">Referenzmodell to use as the source of the relationship.</param>
		/// <param name="target">VModellvariante to use as the target of the relationship.</param>
		public ReferenzmodellReferencesVModellvariante(Referenzmodell source, VModellvariante target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId, source), new DslModeling::RoleAssignment(ReferenzmodellReferencesVModellvariante.VModellvarianteDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ReferenzmodellReferencesVModellvariante(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ReferenzmodellReferencesVModellvariante(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ReferenzmodellReferencesVModellvariante(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ReferenzmodellReferencesVModellvariante(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Referenzmodell domain role code
		
		/// <summary>
		/// Referenzmodell domain role Id.
		/// </summary>
		public static readonly global::System.Guid ReferenzmodellDomainRoleId = new System.Guid("1d3f1927-894f-4565-ad59-4736696044a5");
		
		/// <summary>
		/// DomainRole Referenzmodell
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ReferenzmodellReferencesVModellvariante/Referenzmodell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ReferenzmodellReferencesVModellvariante/Referenzmodell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "VModellvarianteRef", PropertyDisplayNameKey="Tum.VModellXT.ReferenzmodellReferencesVModellvariante/Referenzmodell.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("1d3f1927-894f-4565-ad59-4736696044a5")]
		public virtual Referenzmodell Referenzmodell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Referenzmodell)DslModeling::DomainRoleInfo.GetRolePlayer(this, ReferenzmodellDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ReferenzmodellDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Referenzmodell of a VModellvariante
		/// <summary>
		/// Gets a list of Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Referenzmodell> GetReferenzmodell(VModellvariante element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Referenzmodell>, Referenzmodell>(element, VModellvarianteDomainRoleId);
		}
		#endregion
		#region VModellvariante domain role code
		
		/// <summary>
		/// VModellvariante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellvarianteDomainRoleId = new System.Guid("e2485c32-5199-481e-a476-a344f818f4df");
		
		/// <summary>
		/// DomainRole VModellvariante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ReferenzmodellReferencesVModellvariante/VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ReferenzmodellReferencesVModellvariante/VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Referenzmodell", PropertyDisplayNameKey="Tum.VModellXT.ReferenzmodellReferencesVModellvariante/VModellvariante.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("e2485c32-5199-481e-a476-a344f818f4df")]
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModellvariante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellvarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellvarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModellvarianteRef of a Referenzmodell
		/// <summary>
		/// Gets VModellvarianteRef.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModellvariante GetVModellvarianteRef(Referenzmodell element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ReferenzmodellDomainRoleId) as VModellvariante;
		}
		
		/// <summary>
		/// Sets VModellvarianteRef.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModellvarianteRef(Referenzmodell element, VModellvariante newVModellvariante)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ReferenzmodellDomainRoleId, newVModellvariante);
		}
		#endregion
		#region Referenzmodell link accessor
		/// <summary>
		/// Get the ReferenzmodellReferencesVModellvariante link to a Referenzmodell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante GetLinkToVModellvarianteRef (global::Tum.VModellXT.Referenzmodell referenzmodellInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante>(referenzmodellInstance, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Referenzmodell not obeyed.");
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
		#region VModellvariante link accessor
		/// <summary>
		/// Get the list of ReferenzmodellReferencesVModellvariante links to a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> GetLinksToReferenzmodell ( global::Tum.VModellXT.VModellvariante vModellvarianteInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante>(vModellvarianteInstance, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.VModellvarianteDomainRoleId);
		}
		#endregion
		#region ReferenzmodellReferencesVModellvariante instance accessors
		
		/// <summary>
		/// Get any ReferenzmodellReferencesVModellvariante links between a given Referenzmodell and a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> GetLinks( global::Tum.VModellXT.Referenzmodell source, global::Tum.VModellXT.VModellvariante target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante>(source, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId);
			foreach ( global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante link in links )
			{
				if ( target.Equals(link.VModellvariante) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ReferenzmodellReferencesVModellvariante link between a given Referenzmodelland a VModellvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante GetLink( global::Tum.VModellXT.Referenzmodell source, global::Tum.VModellXT.VModellvariante target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante>(source, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId);
			foreach ( global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante link in links )
			{
				if ( target.Equals(link.VModellvariante) )
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
			return global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ReferenzmodellReferencesVModellvariante";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Referenzmodell References VModellvariante";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship MusterbibliothekHasMustergruppe
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.MusterbibliothekHasMustergruppe.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.MusterbibliothekHasMustergruppe.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("0223c41f-e3f7-4a00-a59b-35c0984d0567")]
	public partial class MusterbibliothekHasMustergruppe : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// MusterbibliothekHasMustergruppe domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("0223c41f-e3f7-4a00-a59b-35c0984d0567");

				
		/// <summary>
		/// Constructor
		/// Creates a MusterbibliothekHasMustergruppe link in the same Partition as the given Musterbibliothek
		/// </summary>
		/// <param name="source">Musterbibliothek to use as the source of the relationship.</param>
		/// <param name="target">Mustergruppe to use as the target of the relationship.</param>
		public MusterbibliothekHasMustergruppe(Musterbibliothek source, Mustergruppe target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId, source), new DslModeling::RoleAssignment(MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MusterbibliothekHasMustergruppe(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MusterbibliothekHasMustergruppe(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MusterbibliothekHasMustergruppe(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MusterbibliothekHasMustergruppe(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Musterbibliothek domain role code
		
		/// <summary>
		/// Musterbibliothek domain role Id.
		/// </summary>
		public static readonly global::System.Guid MusterbibliothekDomainRoleId = new System.Guid("c4dc0f02-91ec-464f-9524-1dd6f171f442");
		
		/// <summary>
		/// DomainRole Musterbibliothek
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.MusterbibliothekHasMustergruppe/Musterbibliothek.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.MusterbibliothekHasMustergruppe/Musterbibliothek.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Mustergruppe", PropertyDisplayNameKey="Tum.VModellXT.MusterbibliothekHasMustergruppe/Musterbibliothek.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("c4dc0f02-91ec-464f-9524-1dd6f171f442")]
		public virtual Musterbibliothek Musterbibliothek
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Musterbibliothek)DslModeling::DomainRoleInfo.GetRolePlayer(this, MusterbibliothekDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MusterbibliothekDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Musterbibliothek of a Mustergruppe
		/// <summary>
		/// Gets Musterbibliothek.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Musterbibliothek GetMusterbibliothek(Mustergruppe element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, MustergruppeDomainRoleId) as Musterbibliothek;
		}
		
		/// <summary>
		/// Sets Musterbibliothek.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetMusterbibliothek(Mustergruppe element, Musterbibliothek newMusterbibliothek)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, MustergruppeDomainRoleId, newMusterbibliothek);
		}
		#endregion
		#region Mustergruppe domain role code
		
		/// <summary>
		/// Mustergruppe domain role Id.
		/// </summary>
		public static readonly global::System.Guid MustergruppeDomainRoleId = new System.Guid("b08f4c60-aeeb-48ee-8bc3-ac515956fc5f");
		
		/// <summary>
		/// DomainRole Mustergruppe
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.MusterbibliothekHasMustergruppe/Mustergruppe.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.MusterbibliothekHasMustergruppe/Mustergruppe.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Musterbibliothek", PropertyDisplayNameKey="Tum.VModellXT.MusterbibliothekHasMustergruppe/Mustergruppe.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("b08f4c60-aeeb-48ee-8bc3-ac515956fc5f")]
		public virtual Mustergruppe Mustergruppe
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Mustergruppe)DslModeling::DomainRoleInfo.GetRolePlayer(this, MustergruppeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MustergruppeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Mustergruppe of a Musterbibliothek
		/// <summary>
		/// Gets a list of Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Mustergruppe> GetMustergruppe(Musterbibliothek element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Mustergruppe>, Mustergruppe>(element, MusterbibliothekDomainRoleId);
		}
		#endregion
		#region Musterbibliothek link accessor
		/// <summary>
		/// Get the list of MusterbibliothekHasMustergruppe links to a Musterbibliothek.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> GetLinksToMustergruppe ( global::Tum.VModellXT.Musterbibliothek musterbibliothekInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasMustergruppe>(musterbibliothekInstance, global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId);
		}
		#endregion
		#region Mustergruppe link accessor
		/// <summary>
		/// Get the MusterbibliothekHasMustergruppe link to a Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MusterbibliothekHasMustergruppe GetLinkToMusterbibliothek (global::Tum.VModellXT.Mustergruppe mustergruppeInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasMustergruppe>(mustergruppeInstance, global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Mustergruppe not obeyed.");
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
		#region MusterbibliothekHasMustergruppe instance accessors
		
		/// <summary>
		/// Get any MusterbibliothekHasMustergruppe links between a given Musterbibliothek and a Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> GetLinks( global::Tum.VModellXT.Musterbibliothek source, global::Tum.VModellXT.Mustergruppe target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.MusterbibliothekHasMustergruppe>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasMustergruppe>(source, global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId);
			foreach ( global::Tum.VModellXT.MusterbibliothekHasMustergruppe link in links )
			{
				if ( target.Equals(link.Mustergruppe) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one MusterbibliothekHasMustergruppe link between a given Musterbibliothekand a Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MusterbibliothekHasMustergruppe GetLink( global::Tum.VModellXT.Musterbibliothek source, global::Tum.VModellXT.Mustergruppe target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasMustergruppe> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasMustergruppe>(source, global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId);
			foreach ( global::Tum.VModellXT.MusterbibliothekHasMustergruppe link in links )
			{
				if ( target.Equals(link.Mustergruppe) )
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
			return global::Tum.VModellXT.MusterbibliothekHasMustergruppe.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "MusterbibliothekHasMustergruppe";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Musterbibliothek Has Mustergruppe";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship MustergruppeHasThemenmuster
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.MustergruppeHasThemenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.MustergruppeHasThemenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("1b3bcf0e-b99c-4eeb-bee1-4604bb841133")]
	public partial class MustergruppeHasThemenmuster : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// MustergruppeHasThemenmuster domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("1b3bcf0e-b99c-4eeb-bee1-4604bb841133");

				
		/// <summary>
		/// Constructor
		/// Creates a MustergruppeHasThemenmuster link in the same Partition as the given Mustergruppe
		/// </summary>
		/// <param name="source">Mustergruppe to use as the source of the relationship.</param>
		/// <param name="target">Themenmuster to use as the target of the relationship.</param>
		public MustergruppeHasThemenmuster(Mustergruppe source, Themenmuster target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(MustergruppeHasThemenmuster.MustergruppeDomainRoleId, source), new DslModeling::RoleAssignment(MustergruppeHasThemenmuster.ThemenmusterDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MustergruppeHasThemenmuster(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MustergruppeHasThemenmuster(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MustergruppeHasThemenmuster(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MustergruppeHasThemenmuster(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Mustergruppe domain role code
		
		/// <summary>
		/// Mustergruppe domain role Id.
		/// </summary>
		public static readonly global::System.Guid MustergruppeDomainRoleId = new System.Guid("6e7eeec0-4971-4662-acad-e2dee78bd446");
		
		/// <summary>
		/// DomainRole Mustergruppe
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.MustergruppeHasThemenmuster/Mustergruppe.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.MustergruppeHasThemenmuster/Mustergruppe.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Themenmuster", PropertyDisplayNameKey="Tum.VModellXT.MustergruppeHasThemenmuster/Mustergruppe.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("6e7eeec0-4971-4662-acad-e2dee78bd446")]
		public virtual Mustergruppe Mustergruppe
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Mustergruppe)DslModeling::DomainRoleInfo.GetRolePlayer(this, MustergruppeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MustergruppeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Mustergruppe of a Themenmuster
		/// <summary>
		/// Gets Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Mustergruppe GetMustergruppe(Themenmuster element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ThemenmusterDomainRoleId) as Mustergruppe;
		}
		
		/// <summary>
		/// Sets Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetMustergruppe(Themenmuster element, Mustergruppe newMustergruppe)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ThemenmusterDomainRoleId, newMustergruppe);
		}
		#endregion
		#region Themenmuster domain role code
		
		/// <summary>
		/// Themenmuster domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterDomainRoleId = new System.Guid("8c83febe-6bc4-4bd5-97e2-9d5fcdec39ce");
		
		/// <summary>
		/// DomainRole Themenmuster
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.MustergruppeHasThemenmuster/Themenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.MustergruppeHasThemenmuster/Themenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Mustergruppe", PropertyDisplayNameKey="Tum.VModellXT.MustergruppeHasThemenmuster/Themenmuster.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("8c83febe-6bc4-4bd5-97e2-9d5fcdec39ce")]
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Themenmuster of a Mustergruppe
		/// <summary>
		/// Gets a list of Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Themenmuster> GetThemenmuster(Mustergruppe element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Themenmuster>, Themenmuster>(element, MustergruppeDomainRoleId);
		}
		#endregion
		#region Mustergruppe link accessor
		/// <summary>
		/// Get the list of MustergruppeHasThemenmuster links to a Mustergruppe.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MustergruppeHasThemenmuster> GetLinksToThemenmuster ( global::Tum.VModellXT.Mustergruppe mustergruppeInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MustergruppeHasThemenmuster>(mustergruppeInstance, global::Tum.VModellXT.MustergruppeHasThemenmuster.MustergruppeDomainRoleId);
		}
		#endregion
		#region Themenmuster link accessor
		/// <summary>
		/// Get the MustergruppeHasThemenmuster link to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MustergruppeHasThemenmuster GetLinkToMustergruppe (global::Tum.VModellXT.Themenmuster themenmusterInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MustergruppeHasThemenmuster> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MustergruppeHasThemenmuster>(themenmusterInstance, global::Tum.VModellXT.MustergruppeHasThemenmuster.ThemenmusterDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Themenmuster not obeyed.");
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
		#region MustergruppeHasThemenmuster instance accessors
		
		/// <summary>
		/// Get any MustergruppeHasThemenmuster links between a given Mustergruppe and a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MustergruppeHasThemenmuster> GetLinks( global::Tum.VModellXT.Mustergruppe source, global::Tum.VModellXT.Themenmuster target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.MustergruppeHasThemenmuster> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.MustergruppeHasThemenmuster>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MustergruppeHasThemenmuster> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MustergruppeHasThemenmuster>(source, global::Tum.VModellXT.MustergruppeHasThemenmuster.MustergruppeDomainRoleId);
			foreach ( global::Tum.VModellXT.MustergruppeHasThemenmuster link in links )
			{
				if ( target.Equals(link.Themenmuster) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one MustergruppeHasThemenmuster link between a given Mustergruppeand a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MustergruppeHasThemenmuster GetLink( global::Tum.VModellXT.Mustergruppe source, global::Tum.VModellXT.Themenmuster target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MustergruppeHasThemenmuster> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MustergruppeHasThemenmuster>(source, global::Tum.VModellXT.MustergruppeHasThemenmuster.MustergruppeDomainRoleId);
			foreach ( global::Tum.VModellXT.MustergruppeHasThemenmuster link in links )
			{
				if ( target.Equals(link.Themenmuster) )
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
			return global::Tum.VModellXT.MustergruppeHasThemenmuster.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "MustergruppeHasThemenmuster";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Mustergruppe Has Themenmuster";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ThemenmusterReferencesThema
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterReferencesThema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterReferencesThema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("7d29b8aa-7363-4be4-b124-ba80db374903")]
	public partial class ThemenmusterReferencesThema : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ThemenmusterReferencesThema domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("7d29b8aa-7363-4be4-b124-ba80db374903");

				
		/// <summary>
		/// Constructor
		/// Creates a ThemenmusterReferencesThema link in the same Partition as the given Themenmuster
		/// </summary>
		/// <param name="source">Themenmuster to use as the source of the relationship.</param>
		/// <param name="target">Thema to use as the target of the relationship.</param>
		public ThemenmusterReferencesThema(Themenmuster source, global::Tum.VModellXT.Statik.Thema target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ThemenmusterReferencesThema.ThemenmusterDomainRoleId, source), new DslModeling::RoleAssignment(ThemenmusterReferencesThema.ThemaDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterReferencesThema(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterReferencesThema(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterReferencesThema(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterReferencesThema(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Themenmuster domain role code
		
		/// <summary>
		/// Themenmuster domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterDomainRoleId = new System.Guid("a9e24e49-e719-4650-8e8e-67e215a44956");
		
		/// <summary>
		/// DomainRole Themenmuster
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterReferencesThema/Themenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterReferencesThema/Themenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Thema", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterReferencesThema/Themenmuster.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("a9e24e49-e719-4650-8e8e-67e215a44956")]
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Themenmuster of a Thema
		/// <summary>
		/// Gets a list of Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Themenmuster> GetThemenmuster(global::Tum.VModellXT.Statik.Thema element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Themenmuster>, Themenmuster>(element, ThemaDomainRoleId);
		}
		#endregion
		#region Thema domain role code
		
		/// <summary>
		/// Thema domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemaDomainRoleId = new System.Guid("f1431af2-bfea-41b4-ac53-fa0ff9b09704");
		
		/// <summary>
		/// DomainRole Thema
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterReferencesThema/Thema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterReferencesThema/Thema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Themenmuster", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterReferencesThema/Thema.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("f1431af2-bfea-41b4-ac53-fa0ff9b09704")]
		public virtual global::Tum.VModellXT.Statik.Thema Thema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Statik.Thema)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemaDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemaDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Thema of a Themenmuster
		/// <summary>
		/// Gets a list of Thema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Thema> GetThema(Themenmuster element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Thema>, global::Tum.VModellXT.Statik.Thema>(element, ThemenmusterDomainRoleId);
		}
		#endregion
		#region Themenmuster link accessor
		/// <summary>
		/// Get the list of ThemenmusterReferencesThema links to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesThema> GetLinksToThema ( global::Tum.VModellXT.Themenmuster themenmusterInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesThema>(themenmusterInstance, global::Tum.VModellXT.ThemenmusterReferencesThema.ThemenmusterDomainRoleId);
		}
		#endregion
		#region Thema link accessor
		/// <summary>
		/// Get the list of ThemenmusterReferencesThema links to a Thema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesThema> GetLinksToThemenmuster ( global::Tum.VModellXT.Statik.Thema themaInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesThema>(themaInstance, global::Tum.VModellXT.ThemenmusterReferencesThema.ThemaDomainRoleId);
		}
		#endregion
		#region ThemenmusterReferencesThema instance accessors
		
		/// <summary>
		/// Get any ThemenmusterReferencesThema links between a given Themenmuster and a Thema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesThema> GetLinks( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Statik.Thema target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterReferencesThema> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterReferencesThema>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterReferencesThema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesThema>(source, global::Tum.VModellXT.ThemenmusterReferencesThema.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterReferencesThema link in links )
			{
				if ( target.Equals(link.Thema) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ThemenmusterReferencesThema link between a given Themenmusterand a Thema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterReferencesThema GetLink( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Statik.Thema target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterReferencesThema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesThema>(source, global::Tum.VModellXT.ThemenmusterReferencesThema.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterReferencesThema link in links )
			{
				if ( target.Equals(link.Thema) )
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
			return global::Tum.VModellXT.ThemenmusterReferencesThema.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ThemenmusterReferencesThema";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Themenmuster References Thema";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ThemenmusterReferencesUnterthema
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterReferencesUnterthema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterReferencesUnterthema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("b797f206-9c06-484f-9110-5d40600143b2")]
	public partial class ThemenmusterReferencesUnterthema : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ThemenmusterReferencesUnterthema domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("b797f206-9c06-484f-9110-5d40600143b2");

				
		/// <summary>
		/// Constructor
		/// Creates a ThemenmusterReferencesUnterthema link in the same Partition as the given Themenmuster
		/// </summary>
		/// <param name="source">Themenmuster to use as the source of the relationship.</param>
		/// <param name="target">Unterthema to use as the target of the relationship.</param>
		public ThemenmusterReferencesUnterthema(Themenmuster source, global::Tum.VModellXT.Statik.Unterthema target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId, source), new DslModeling::RoleAssignment(ThemenmusterReferencesUnterthema.UnterthemaDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterReferencesUnterthema(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterReferencesUnterthema(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterReferencesUnterthema(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterReferencesUnterthema(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Themenmuster domain role code
		
		/// <summary>
		/// Themenmuster domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterDomainRoleId = new System.Guid("0e645744-4a1a-46ac-be64-de1410ecd4c3");
		
		/// <summary>
		/// DomainRole Themenmuster
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterReferencesUnterthema/Themenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterReferencesUnterthema/Themenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Unterthema", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterReferencesUnterthema/Themenmuster.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("0e645744-4a1a-46ac-be64-de1410ecd4c3")]
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Themenmuster of a Unterthema
		/// <summary>
		/// Gets a list of Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Themenmuster> GetThemenmuster(global::Tum.VModellXT.Statik.Unterthema element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Themenmuster>, Themenmuster>(element, UnterthemaDomainRoleId);
		}
		#endregion
		#region Unterthema domain role code
		
		/// <summary>
		/// Unterthema domain role Id.
		/// </summary>
		public static readonly global::System.Guid UnterthemaDomainRoleId = new System.Guid("cae80179-bac1-42e5-99f9-cea2656d85e1");
		
		/// <summary>
		/// DomainRole Unterthema
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterReferencesUnterthema/Unterthema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterReferencesUnterthema/Unterthema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Themenmuster", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterReferencesUnterthema/Unterthema.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("cae80179-bac1-42e5-99f9-cea2656d85e1")]
		public virtual global::Tum.VModellXT.Statik.Unterthema Unterthema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Tum.VModellXT.Statik.Unterthema)DslModeling::DomainRoleInfo.GetRolePlayer(this, UnterthemaDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, UnterthemaDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Unterthema of a Themenmuster
		/// <summary>
		/// Gets a list of Unterthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Unterthema> GetUnterthema(Themenmuster element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Unterthema>, global::Tum.VModellXT.Statik.Unterthema>(element, ThemenmusterDomainRoleId);
		}
		#endregion
		#region Themenmuster link accessor
		/// <summary>
		/// Get the list of ThemenmusterReferencesUnterthema links to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> GetLinksToUnterthema ( global::Tum.VModellXT.Themenmuster themenmusterInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesUnterthema>(themenmusterInstance, global::Tum.VModellXT.ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId);
		}
		#endregion
		#region Unterthema link accessor
		/// <summary>
		/// Get the list of ThemenmusterReferencesUnterthema links to a Unterthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> GetLinksToThemenmuster ( global::Tum.VModellXT.Statik.Unterthema unterthemaInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesUnterthema>(unterthemaInstance, global::Tum.VModellXT.ThemenmusterReferencesUnterthema.UnterthemaDomainRoleId);
		}
		#endregion
		#region ThemenmusterReferencesUnterthema instance accessors
		
		/// <summary>
		/// Get any ThemenmusterReferencesUnterthema links between a given Themenmuster and a Unterthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> GetLinks( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Statik.Unterthema target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterReferencesUnterthema>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesUnterthema>(source, global::Tum.VModellXT.ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterReferencesUnterthema link in links )
			{
				if ( target.Equals(link.Unterthema) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ThemenmusterReferencesUnterthema link between a given Themenmusterand a Unterthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterReferencesUnterthema GetLink( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Statik.Unterthema target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterReferencesUnterthema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterReferencesUnterthema>(source, global::Tum.VModellXT.ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterReferencesUnterthema link in links )
			{
				if ( target.Equals(link.Unterthema) )
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
			return global::Tum.VModellXT.ThemenmusterReferencesUnterthema.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ThemenmusterReferencesUnterthema";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Themenmuster References Unterthema";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ThemenmusterHasMustertext
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterHasMustertext.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterHasMustertext.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("8a62c682-6ccf-445d-a089-4ca36fc8cdc5")]
	public partial class ThemenmusterHasMustertext : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ThemenmusterHasMustertext domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("8a62c682-6ccf-445d-a089-4ca36fc8cdc5");

				
		/// <summary>
		/// Constructor
		/// Creates a ThemenmusterHasMustertext link in the same Partition as the given Themenmuster
		/// </summary>
		/// <param name="source">Themenmuster to use as the source of the relationship.</param>
		/// <param name="target">Mustertext to use as the target of the relationship.</param>
		public ThemenmusterHasMustertext(Themenmuster source, Mustertext target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ThemenmusterHasMustertext.ThemenmusterDomainRoleId, source), new DslModeling::RoleAssignment(ThemenmusterHasMustertext.MustertextDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterHasMustertext(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterHasMustertext(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterHasMustertext(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterHasMustertext(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Themenmuster domain role code
		
		/// <summary>
		/// Themenmuster domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterDomainRoleId = new System.Guid("a8ec9184-dbbc-4fe3-acb6-8a14fe65fa85");
		
		/// <summary>
		/// DomainRole Themenmuster
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterHasMustertext/Themenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterHasMustertext/Themenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Mustertext", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterHasMustertext/Themenmuster.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("a8ec9184-dbbc-4fe3-acb6-8a14fe65fa85")]
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Themenmuster of a Mustertext
		/// <summary>
		/// Gets Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Themenmuster GetThemenmuster(Mustertext element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, MustertextDomainRoleId) as Themenmuster;
		}
		
		/// <summary>
		/// Sets Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetThemenmuster(Mustertext element, Themenmuster newThemenmuster)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, MustertextDomainRoleId, newThemenmuster);
		}
		#endregion
		#region Mustertext domain role code
		
		/// <summary>
		/// Mustertext domain role Id.
		/// </summary>
		public static readonly global::System.Guid MustertextDomainRoleId = new System.Guid("d9a9feea-a4ef-4b6c-b75a-fafb7e38d089");
		
		/// <summary>
		/// DomainRole Mustertext
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterHasMustertext/Mustertext.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterHasMustertext/Mustertext.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Themenmuster", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterHasMustertext/Mustertext.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("d9a9feea-a4ef-4b6c-b75a-fafb7e38d089")]
		public virtual Mustertext Mustertext
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Mustertext)DslModeling::DomainRoleInfo.GetRolePlayer(this, MustertextDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MustertextDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Mustertext of a Themenmuster
		/// <summary>
		/// Gets a list of Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Mustertext> GetMustertext(Themenmuster element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Mustertext>, Mustertext>(element, ThemenmusterDomainRoleId);
		}
		#endregion
		#region Themenmuster link accessor
		/// <summary>
		/// Get the list of ThemenmusterHasMustertext links to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterHasMustertext> GetLinksToMustertext ( global::Tum.VModellXT.Themenmuster themenmusterInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasMustertext>(themenmusterInstance, global::Tum.VModellXT.ThemenmusterHasMustertext.ThemenmusterDomainRoleId);
		}
		#endregion
		#region Mustertext link accessor
		/// <summary>
		/// Get the ThemenmusterHasMustertext link to a Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterHasMustertext GetLinkToThemenmuster (global::Tum.VModellXT.Mustertext mustertextInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterHasMustertext> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasMustertext>(mustertextInstance, global::Tum.VModellXT.ThemenmusterHasMustertext.MustertextDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Mustertext not obeyed.");
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
		#region ThemenmusterHasMustertext instance accessors
		
		/// <summary>
		/// Get any ThemenmusterHasMustertext links between a given Themenmuster and a Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterHasMustertext> GetLinks( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Mustertext target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterHasMustertext> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterHasMustertext>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterHasMustertext> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasMustertext>(source, global::Tum.VModellXT.ThemenmusterHasMustertext.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterHasMustertext link in links )
			{
				if ( target.Equals(link.Mustertext) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ThemenmusterHasMustertext link between a given Themenmusterand a Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterHasMustertext GetLink( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Mustertext target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterHasMustertext> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasMustertext>(source, global::Tum.VModellXT.ThemenmusterHasMustertext.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterHasMustertext link in links )
			{
				if ( target.Equals(link.Mustertext) )
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
			return global::Tum.VModellXT.ThemenmusterHasMustertext.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ThemenmusterHasMustertext";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Themenmuster Has Mustertext";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ThemenmusterSourceHasThemenmusterTarget
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("e12c1547-1071-4387-9691-7d1065a5c001")]
	public partial class ThemenmusterSourceHasThemenmusterTarget : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ThemenmusterSourceHasThemenmusterTarget domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("e12c1547-1071-4387-9691-7d1065a5c001");

				
		/// <summary>
		/// Constructor
		/// Creates a ThemenmusterSourceHasThemenmusterTarget link in the same Partition as the given Themenmuster
		/// </summary>
		/// <param name="source">Themenmuster to use as the source of the relationship.</param>
		/// <param name="target">Themenmuster to use as the target of the relationship.</param>
		public ThemenmusterSourceHasThemenmusterTarget(Themenmuster source, Themenmuster target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId, source), new DslModeling::RoleAssignment(ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterSourceHasThemenmusterTarget(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterSourceHasThemenmusterTarget(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterSourceHasThemenmusterTarget(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterSourceHasThemenmusterTarget(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region ThemenmusterSource domain role code
		
		/// <summary>
		/// ThemenmusterSource domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterSourceDomainRoleId = new System.Guid("ab6923f5-6323-43f0-beaf-c43586f651c1");
		
		/// <summary>
		/// DomainRole ThemenmusterSource
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget/ThemenmusterSource.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget/ThemenmusterSource.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "ThemenmusterTarget", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget/ThemenmusterSource.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("ab6923f5-6323-43f0-beaf-c43586f651c1")]
		public virtual Themenmuster ThemenmusterSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterSourceDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterSourceDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ThemenmusterSource of a Themenmuster
		/// <summary>
		/// Gets ThemenmusterSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Themenmuster GetThemenmusterSource(Themenmuster element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ThemenmusterTargetDomainRoleId) as Themenmuster;
		}
		
		/// <summary>
		/// Sets ThemenmusterSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetThemenmusterSource(Themenmuster element, Themenmuster newThemenmusterSource)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ThemenmusterTargetDomainRoleId, newThemenmusterSource);
		}
		#endregion
		#region ThemenmusterTarget domain role code
		
		/// <summary>
		/// ThemenmusterTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterTargetDomainRoleId = new System.Guid("819bd9e7-67e9-4eea-a5ba-4cf86ac37dd9");
		
		/// <summary>
		/// DomainRole ThemenmusterTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget/ThemenmusterTarget.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget/ThemenmusterTarget.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "ThemenmusterSource", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget/ThemenmusterTarget.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("819bd9e7-67e9-4eea-a5ba-4cf86ac37dd9")]
		public virtual Themenmuster ThemenmusterTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterTargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterTargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ThemenmusterTarget of a Themenmuster
		/// <summary>
		/// Gets a list of ThemenmusterTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Themenmuster> GetThemenmusterTarget(Themenmuster element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Themenmuster>, Themenmuster>(element, ThemenmusterSourceDomainRoleId);
		}
		#endregion
		#region ThemenmusterSource link accessor
		/// <summary>
		/// Get the list of ThemenmusterSourceHasThemenmusterTarget links to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> GetLinksToThemenmusterTarget ( global::Tum.VModellXT.Themenmuster themenmusterSourceInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget>(themenmusterSourceInstance, global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId);
		}
		#endregion
		#region ThemenmusterTarget link accessor
		/// <summary>
		/// Get the ThemenmusterSourceHasThemenmusterTarget link to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget GetLinkToThemenmusterSource (global::Tum.VModellXT.Themenmuster themenmusterTargetInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget>(themenmusterTargetInstance, global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of ThemenmusterTarget not obeyed.");
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
		#region ThemenmusterSourceHasThemenmusterTarget instance accessors
		
		/// <summary>
		/// Get any ThemenmusterSourceHasThemenmusterTarget links between a given Themenmuster and a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> GetLinks( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Themenmuster target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget>(source, global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget link in links )
			{
				if ( target.Equals(link.ThemenmusterTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ThemenmusterSourceHasThemenmusterTarget link between a given Themenmusterand a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget GetLink( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Themenmuster target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget>(source, global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget link in links )
			{
				if ( target.Equals(link.ThemenmusterTarget) )
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
			return global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ThemenmusterSourceHasThemenmusterTarget";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Themenmuster Source Has Themenmuster Target";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ThemenmusterHasZusatzthema
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterHasZusatzthema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterHasZusatzthema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("0a29215f-95b8-4177-b126-53f82e3422c9")]
	public partial class ThemenmusterHasZusatzthema : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ThemenmusterHasZusatzthema domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("0a29215f-95b8-4177-b126-53f82e3422c9");

				
		/// <summary>
		/// Constructor
		/// Creates a ThemenmusterHasZusatzthema link in the same Partition as the given Themenmuster
		/// </summary>
		/// <param name="source">Themenmuster to use as the source of the relationship.</param>
		/// <param name="target">Zusatzthema to use as the target of the relationship.</param>
		public ThemenmusterHasZusatzthema(Themenmuster source, Zusatzthema target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId, source), new DslModeling::RoleAssignment(ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterHasZusatzthema(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterHasZusatzthema(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ThemenmusterHasZusatzthema(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ThemenmusterHasZusatzthema(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Themenmuster domain role code
		
		/// <summary>
		/// Themenmuster domain role Id.
		/// </summary>
		public static readonly global::System.Guid ThemenmusterDomainRoleId = new System.Guid("e738b9f5-788c-48fa-80a3-00ac9594ce5d");
		
		/// <summary>
		/// DomainRole Themenmuster
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterHasZusatzthema/Themenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterHasZusatzthema/Themenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Zusatzthema", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterHasZusatzthema/Themenmuster.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("e738b9f5-788c-48fa-80a3-00ac9594ce5d")]
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Themenmuster)DslModeling::DomainRoleInfo.GetRolePlayer(this, ThemenmusterDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ThemenmusterDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Themenmuster of a Zusatzthema
		/// <summary>
		/// Gets Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Themenmuster GetThemenmuster(Zusatzthema element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ZusatzthemaDomainRoleId) as Themenmuster;
		}
		
		/// <summary>
		/// Sets Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetThemenmuster(Zusatzthema element, Themenmuster newThemenmuster)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ZusatzthemaDomainRoleId, newThemenmuster);
		}
		#endregion
		#region Zusatzthema domain role code
		
		/// <summary>
		/// Zusatzthema domain role Id.
		/// </summary>
		public static readonly global::System.Guid ZusatzthemaDomainRoleId = new System.Guid("e4e95b9b-4a72-4246-8947-3745ee742f4a");
		
		/// <summary>
		/// DomainRole Zusatzthema
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ThemenmusterHasZusatzthema/Zusatzthema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ThemenmusterHasZusatzthema/Zusatzthema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Themenmuster", PropertyDisplayNameKey="Tum.VModellXT.ThemenmusterHasZusatzthema/Zusatzthema.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("e4e95b9b-4a72-4246-8947-3745ee742f4a")]
		public virtual Zusatzthema Zusatzthema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Zusatzthema)DslModeling::DomainRoleInfo.GetRolePlayer(this, ZusatzthemaDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ZusatzthemaDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Zusatzthema of a Themenmuster
		/// <summary>
		/// Gets a list of Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Zusatzthema> GetZusatzthema(Themenmuster element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Zusatzthema>, Zusatzthema>(element, ThemenmusterDomainRoleId);
		}
		#endregion
		#region Themenmuster link accessor
		/// <summary>
		/// Get the list of ThemenmusterHasZusatzthema links to a Themenmuster.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterHasZusatzthema> GetLinksToZusatzthema ( global::Tum.VModellXT.Themenmuster themenmusterInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasZusatzthema>(themenmusterInstance, global::Tum.VModellXT.ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId);
		}
		#endregion
		#region Zusatzthema link accessor
		/// <summary>
		/// Get the ThemenmusterHasZusatzthema link to a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterHasZusatzthema GetLinkToThemenmuster (global::Tum.VModellXT.Zusatzthema zusatzthemaInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterHasZusatzthema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasZusatzthema>(zusatzthemaInstance, global::Tum.VModellXT.ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Zusatzthema not obeyed.");
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
		#region ThemenmusterHasZusatzthema instance accessors
		
		/// <summary>
		/// Get any ThemenmusterHasZusatzthema links between a given Themenmuster and a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ThemenmusterHasZusatzthema> GetLinks( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Zusatzthema target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterHasZusatzthema> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ThemenmusterHasZusatzthema>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterHasZusatzthema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasZusatzthema>(source, global::Tum.VModellXT.ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterHasZusatzthema link in links )
			{
				if ( target.Equals(link.Zusatzthema) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ThemenmusterHasZusatzthema link between a given Themenmusterand a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ThemenmusterHasZusatzthema GetLink( global::Tum.VModellXT.Themenmuster source, global::Tum.VModellXT.Zusatzthema target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ThemenmusterHasZusatzthema> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ThemenmusterHasZusatzthema>(source, global::Tum.VModellXT.ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId);
			foreach ( global::Tum.VModellXT.ThemenmusterHasZusatzthema link in links )
			{
				if ( target.Equals(link.Zusatzthema) )
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
			return global::Tum.VModellXT.ThemenmusterHasZusatzthema.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ThemenmusterHasZusatzthema";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Themenmuster Has Zusatzthema";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ZusatzthemaHasMustertext
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ZusatzthemaHasMustertext.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ZusatzthemaHasMustertext.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("094c3681-a015-4cb8-b52b-7756b0fda9ef")]
	public partial class ZusatzthemaHasMustertext : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ZusatzthemaHasMustertext domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("094c3681-a015-4cb8-b52b-7756b0fda9ef");

				
		/// <summary>
		/// Constructor
		/// Creates a ZusatzthemaHasMustertext link in the same Partition as the given Zusatzthema
		/// </summary>
		/// <param name="source">Zusatzthema to use as the source of the relationship.</param>
		/// <param name="target">Mustertext to use as the target of the relationship.</param>
		public ZusatzthemaHasMustertext(Zusatzthema source, Mustertext target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId, source), new DslModeling::RoleAssignment(ZusatzthemaHasMustertext.MustertextDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ZusatzthemaHasMustertext(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ZusatzthemaHasMustertext(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ZusatzthemaHasMustertext(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ZusatzthemaHasMustertext(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Zusatzthema domain role code
		
		/// <summary>
		/// Zusatzthema domain role Id.
		/// </summary>
		public static readonly global::System.Guid ZusatzthemaDomainRoleId = new System.Guid("1c949d88-c259-413e-adfb-dba578ca6fce");
		
		/// <summary>
		/// DomainRole Zusatzthema
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ZusatzthemaHasMustertext/Zusatzthema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ZusatzthemaHasMustertext/Zusatzthema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Mustertext", PropertyDisplayNameKey="Tum.VModellXT.ZusatzthemaHasMustertext/Zusatzthema.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("1c949d88-c259-413e-adfb-dba578ca6fce")]
		public virtual Zusatzthema Zusatzthema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Zusatzthema)DslModeling::DomainRoleInfo.GetRolePlayer(this, ZusatzthemaDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ZusatzthemaDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Zusatzthema of a Mustertext
		/// <summary>
		/// Gets Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Zusatzthema GetZusatzthema(Mustertext element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, MustertextDomainRoleId) as Zusatzthema;
		}
		
		/// <summary>
		/// Sets Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetZusatzthema(Mustertext element, Zusatzthema newZusatzthema)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, MustertextDomainRoleId, newZusatzthema);
		}
		#endregion
		#region Mustertext domain role code
		
		/// <summary>
		/// Mustertext domain role Id.
		/// </summary>
		public static readonly global::System.Guid MustertextDomainRoleId = new System.Guid("08bfd281-82cf-4de5-9a6a-8bc5a6f2d9a7");
		
		/// <summary>
		/// DomainRole Mustertext
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ZusatzthemaHasMustertext/Mustertext.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ZusatzthemaHasMustertext/Mustertext.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Zusatzthema", PropertyDisplayNameKey="Tum.VModellXT.ZusatzthemaHasMustertext/Mustertext.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("08bfd281-82cf-4de5-9a6a-8bc5a6f2d9a7")]
		public virtual Mustertext Mustertext
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Mustertext)DslModeling::DomainRoleInfo.GetRolePlayer(this, MustertextDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MustertextDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Mustertext of a Zusatzthema
		/// <summary>
		/// Gets a list of Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Mustertext> GetMustertext(Zusatzthema element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Mustertext>, Mustertext>(element, ZusatzthemaDomainRoleId);
		}
		#endregion
		#region Zusatzthema link accessor
		/// <summary>
		/// Get the list of ZusatzthemaHasMustertext links to a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ZusatzthemaHasMustertext> GetLinksToMustertext ( global::Tum.VModellXT.Zusatzthema zusatzthemaInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaHasMustertext>(zusatzthemaInstance, global::Tum.VModellXT.ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId);
		}
		#endregion
		#region Mustertext link accessor
		/// <summary>
		/// Get the ZusatzthemaHasMustertext link to a Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ZusatzthemaHasMustertext GetLinkToZusatzthema (global::Tum.VModellXT.Mustertext mustertextInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ZusatzthemaHasMustertext> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaHasMustertext>(mustertextInstance, global::Tum.VModellXT.ZusatzthemaHasMustertext.MustertextDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Mustertext not obeyed.");
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
		#region ZusatzthemaHasMustertext instance accessors
		
		/// <summary>
		/// Get any ZusatzthemaHasMustertext links between a given Zusatzthema and a Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ZusatzthemaHasMustertext> GetLinks( global::Tum.VModellXT.Zusatzthema source, global::Tum.VModellXT.Mustertext target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ZusatzthemaHasMustertext> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ZusatzthemaHasMustertext>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ZusatzthemaHasMustertext> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaHasMustertext>(source, global::Tum.VModellXT.ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId);
			foreach ( global::Tum.VModellXT.ZusatzthemaHasMustertext link in links )
			{
				if ( target.Equals(link.Mustertext) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ZusatzthemaHasMustertext link between a given Zusatzthemaand a Mustertext.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ZusatzthemaHasMustertext GetLink( global::Tum.VModellXT.Zusatzthema source, global::Tum.VModellXT.Mustertext target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ZusatzthemaHasMustertext> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaHasMustertext>(source, global::Tum.VModellXT.ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId);
			foreach ( global::Tum.VModellXT.ZusatzthemaHasMustertext link in links )
			{
				if ( target.Equals(link.Mustertext) )
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
			return global::Tum.VModellXT.ZusatzthemaHasMustertext.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ZusatzthemaHasMustertext";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Zusatzthema Has Mustertext";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship ZusatzthemaSourceHasZusatzthemaTarget
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("bb7d78e1-6f05-4bac-a7bf-2c8d79004a33")]
	public partial class ZusatzthemaSourceHasZusatzthemaTarget : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ZusatzthemaSourceHasZusatzthemaTarget domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("bb7d78e1-6f05-4bac-a7bf-2c8d79004a33");

				
		/// <summary>
		/// Constructor
		/// Creates a ZusatzthemaSourceHasZusatzthemaTarget link in the same Partition as the given Zusatzthema
		/// </summary>
		/// <param name="source">Zusatzthema to use as the source of the relationship.</param>
		/// <param name="target">Zusatzthema to use as the target of the relationship.</param>
		public ZusatzthemaSourceHasZusatzthemaTarget(Zusatzthema source, Zusatzthema target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId, source), new DslModeling::RoleAssignment(ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ZusatzthemaSourceHasZusatzthemaTarget(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ZusatzthemaSourceHasZusatzthemaTarget(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ZusatzthemaSourceHasZusatzthemaTarget(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ZusatzthemaSourceHasZusatzthemaTarget(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region ZusatzthemaSource domain role code
		
		/// <summary>
		/// ZusatzthemaSource domain role Id.
		/// </summary>
		public static readonly global::System.Guid ZusatzthemaSourceDomainRoleId = new System.Guid("0d04078b-72a9-48a0-a2dd-af784a0dc651");
		
		/// <summary>
		/// DomainRole ZusatzthemaSource
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget/ZusatzthemaSource.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget/ZusatzthemaSource.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "ZusatzthemaTarget", PropertyDisplayNameKey="Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget/ZusatzthemaSource.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("0d04078b-72a9-48a0-a2dd-af784a0dc651")]
		public virtual Zusatzthema ZusatzthemaSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Zusatzthema)DslModeling::DomainRoleInfo.GetRolePlayer(this, ZusatzthemaSourceDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ZusatzthemaSourceDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ZusatzthemaSource of a Zusatzthema
		/// <summary>
		/// Gets ZusatzthemaSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Zusatzthema GetZusatzthemaSource(Zusatzthema element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ZusatzthemaTargetDomainRoleId) as Zusatzthema;
		}
		
		/// <summary>
		/// Sets ZusatzthemaSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetZusatzthemaSource(Zusatzthema element, Zusatzthema newZusatzthemaSource)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ZusatzthemaTargetDomainRoleId, newZusatzthemaSource);
		}
		#endregion
		#region ZusatzthemaTarget domain role code
		
		/// <summary>
		/// ZusatzthemaTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid ZusatzthemaTargetDomainRoleId = new System.Guid("989a5824-12d9-4abf-ab4a-07803bf2c832");
		
		/// <summary>
		/// DomainRole ZusatzthemaTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget/ZusatzthemaTarget.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget/ZusatzthemaTarget.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "ZusatzthemaSource", PropertyDisplayNameKey="Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget/ZusatzthemaTarget.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("989a5824-12d9-4abf-ab4a-07803bf2c832")]
		public virtual Zusatzthema ZusatzthemaTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Zusatzthema)DslModeling::DomainRoleInfo.GetRolePlayer(this, ZusatzthemaTargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ZusatzthemaTargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ZusatzthemaTarget of a Zusatzthema
		/// <summary>
		/// Gets a list of ZusatzthemaTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Zusatzthema> GetZusatzthemaTarget(Zusatzthema element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Zusatzthema>, Zusatzthema>(element, ZusatzthemaSourceDomainRoleId);
		}
		#endregion
		#region ZusatzthemaSource link accessor
		/// <summary>
		/// Get the list of ZusatzthemaSourceHasZusatzthemaTarget links to a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> GetLinksToZusatzthemaTarget ( global::Tum.VModellXT.Zusatzthema zusatzthemaSourceInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget>(zusatzthemaSourceInstance, global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId);
		}
		#endregion
		#region ZusatzthemaTarget link accessor
		/// <summary>
		/// Get the ZusatzthemaSourceHasZusatzthemaTarget link to a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget GetLinkToZusatzthemaSource (global::Tum.VModellXT.Zusatzthema zusatzthemaTargetInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget>(zusatzthemaTargetInstance, global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of ZusatzthemaTarget not obeyed.");
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
		#region ZusatzthemaSourceHasZusatzthemaTarget instance accessors
		
		/// <summary>
		/// Get any ZusatzthemaSourceHasZusatzthemaTarget links between a given Zusatzthema and a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> GetLinks( global::Tum.VModellXT.Zusatzthema source, global::Tum.VModellXT.Zusatzthema target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget>(source, global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId);
			foreach ( global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget link in links )
			{
				if ( target.Equals(link.ZusatzthemaTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one ZusatzthemaSourceHasZusatzthemaTarget link between a given Zusatzthemaand a Zusatzthema.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget GetLink( global::Tum.VModellXT.Zusatzthema source, global::Tum.VModellXT.Zusatzthema target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget>(source, global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId);
			foreach ( global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget link in links )
			{
				if ( target.Equals(link.ZusatzthemaTarget) )
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
			return global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "ZusatzthemaSourceHasZusatzthemaTarget";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Zusatzthema Source Has Zusatzthema Target";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship MusterbibliothekHasVModell
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.MusterbibliothekHasVModell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.MusterbibliothekHasVModell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("1c38f137-0224-4237-93ee-6ae566b3fb4c")]
	public partial class MusterbibliothekHasVModell : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// MusterbibliothekHasVModell domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("1c38f137-0224-4237-93ee-6ae566b3fb4c");

				
		/// <summary>
		/// Constructor
		/// Creates a MusterbibliothekHasVModell link in the same Partition as the given Musterbibliothek
		/// </summary>
		/// <param name="source">Musterbibliothek to use as the source of the relationship.</param>
		/// <param name="target">VModell to use as the target of the relationship.</param>
		public MusterbibliothekHasVModell(Musterbibliothek source, VModell target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(MusterbibliothekHasVModell.MusterbibliothekDomainRoleId, source), new DslModeling::RoleAssignment(MusterbibliothekHasVModell.VModellDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MusterbibliothekHasVModell(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MusterbibliothekHasVModell(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public MusterbibliothekHasVModell(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public MusterbibliothekHasVModell(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Musterbibliothek domain role code
		
		/// <summary>
		/// Musterbibliothek domain role Id.
		/// </summary>
		public static readonly global::System.Guid MusterbibliothekDomainRoleId = new System.Guid("30d150f0-2d90-4193-b608-b96c86c24569");
		
		/// <summary>
		/// DomainRole Musterbibliothek
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.MusterbibliothekHasVModell/Musterbibliothek.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.MusterbibliothekHasVModell/Musterbibliothek.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "VModell", PropertyDisplayNameKey="Tum.VModellXT.MusterbibliothekHasVModell/Musterbibliothek.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("30d150f0-2d90-4193-b608-b96c86c24569")]
		public virtual Musterbibliothek Musterbibliothek
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Musterbibliothek)DslModeling::DomainRoleInfo.GetRolePlayer(this, MusterbibliothekDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, MusterbibliothekDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Musterbibliothek of a VModell
		/// <summary>
		/// Gets Musterbibliothek.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Musterbibliothek GetMusterbibliothek(VModell element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VModellDomainRoleId) as Musterbibliothek;
		}
		
		/// <summary>
		/// Sets Musterbibliothek.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetMusterbibliothek(VModell element, Musterbibliothek newMusterbibliothek)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VModellDomainRoleId, newMusterbibliothek);
		}
		#endregion
		#region VModell domain role code
		
		/// <summary>
		/// VModell domain role Id.
		/// </summary>
		public static readonly global::System.Guid VModellDomainRoleId = new System.Guid("480fb5d5-c079-45c7-bd5b-a4131bb1f35a");
		
		/// <summary>
		/// DomainRole VModell
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.MusterbibliothekHasVModell/VModell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.MusterbibliothekHasVModell/VModell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Musterbibliothek", PropertyDisplayNameKey="Tum.VModellXT.MusterbibliothekHasVModell/VModell.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("480fb5d5-c079-45c7-bd5b-a4131bb1f35a")]
		public virtual VModell VModell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (VModell)DslModeling::DomainRoleInfo.GetRolePlayer(this, VModellDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VModellDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VModell of a Musterbibliothek
		/// <summary>
		/// Gets VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static VModell GetVModell(Musterbibliothek element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, MusterbibliothekDomainRoleId) as VModell;
		}
		
		/// <summary>
		/// Sets VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVModell(Musterbibliothek element, VModell newVModell)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, MusterbibliothekDomainRoleId, newVModell);
		}
		#endregion
		#region Musterbibliothek link accessor
		/// <summary>
		/// Get the MusterbibliothekHasVModell link to a Musterbibliothek.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MusterbibliothekHasVModell GetLinkToVModell (global::Tum.VModellXT.Musterbibliothek musterbibliothekInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasVModell>(musterbibliothekInstance, global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Musterbibliothek not obeyed.");
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
		#region VModell link accessor
		/// <summary>
		/// Get the MusterbibliothekHasVModell link to a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MusterbibliothekHasVModell GetLinkToMusterbibliothek (global::Tum.VModellXT.VModell vModellInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasVModell>(vModellInstance, global::Tum.VModellXT.MusterbibliothekHasVModell.VModellDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VModell not obeyed.");
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
		#region MusterbibliothekHasVModell instance accessors
		
		/// <summary>
		/// Get any MusterbibliothekHasVModell links between a given Musterbibliothek and a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.MusterbibliothekHasVModell> GetLinks( global::Tum.VModellXT.Musterbibliothek source, global::Tum.VModellXT.VModell target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.MusterbibliothekHasVModell> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.MusterbibliothekHasVModell>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasVModell>(source, global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId);
			foreach ( global::Tum.VModellXT.MusterbibliothekHasVModell link in links )
			{
				if ( target.Equals(link.VModell) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one MusterbibliothekHasVModell link between a given Musterbibliothekand a VModell.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.MusterbibliothekHasVModell GetLink( global::Tum.VModellXT.Musterbibliothek source, global::Tum.VModellXT.VModell target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.MusterbibliothekHasVModell> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.MusterbibliothekHasVModell>(source, global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId);
			foreach ( global::Tum.VModellXT.MusterbibliothekHasVModell link in links )
			{
				if ( target.Equals(link.VModell) )
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
			return global::Tum.VModellXT.MusterbibliothekHasVModell.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "MusterbibliothekHasVModell";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Musterbibliothek Has VModell";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VariantenHasVariante
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VariantenHasVariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VariantenHasVariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("a49583cd-f759-4593-83cc-4ab381ee3284")]
	public partial class VariantenHasVariante : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VariantenHasVariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a49583cd-f759-4593-83cc-4ab381ee3284");

				
		/// <summary>
		/// Constructor
		/// Creates a VariantenHasVariante link in the same Partition as the given Varianten
		/// </summary>
		/// <param name="source">Varianten to use as the source of the relationship.</param>
		/// <param name="target">Variante to use as the target of the relationship.</param>
		public VariantenHasVariante(Varianten source, Variante target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VariantenHasVariante.VariantenDomainRoleId, source), new DslModeling::RoleAssignment(VariantenHasVariante.VarianteDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VariantenHasVariante(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VariantenHasVariante(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VariantenHasVariante(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VariantenHasVariante(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Varianten domain role code
		
		/// <summary>
		/// Varianten domain role Id.
		/// </summary>
		public static readonly global::System.Guid VariantenDomainRoleId = new System.Guid("197bbe7e-b5dc-4715-b95a-84fc472a8f2c");
		
		/// <summary>
		/// DomainRole Varianten
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VariantenHasVariante/Varianten.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VariantenHasVariante/Varianten.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Variante", PropertyDisplayNameKey="Tum.VModellXT.VariantenHasVariante/Varianten.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("197bbe7e-b5dc-4715-b95a-84fc472a8f2c")]
		public virtual Varianten Varianten
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Varianten)DslModeling::DomainRoleInfo.GetRolePlayer(this, VariantenDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VariantenDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Varianten of a Variante
		/// <summary>
		/// Gets Varianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Varianten GetVarianten(Variante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VarianteDomainRoleId) as Varianten;
		}
		
		/// <summary>
		/// Sets Varianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetVarianten(Variante element, Varianten newVarianten)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VarianteDomainRoleId, newVarianten);
		}
		#endregion
		#region Variante domain role code
		
		/// <summary>
		/// Variante domain role Id.
		/// </summary>
		public static readonly global::System.Guid VarianteDomainRoleId = new System.Guid("5e174103-5809-4f36-8fdc-18b35e0508a2");
		
		/// <summary>
		/// DomainRole Variante
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VariantenHasVariante/Variante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VariantenHasVariante/Variante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Varianten", PropertyDisplayNameKey="Tum.VModellXT.VariantenHasVariante/Variante.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("5e174103-5809-4f36-8fdc-18b35e0508a2")]
		public virtual Variante Variante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Variante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VarianteDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VarianteDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Variante of a Varianten
		/// <summary>
		/// Gets a list of Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Variante> GetVariante(Varianten element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Variante>, Variante>(element, VariantenDomainRoleId);
		}
		#endregion
		#region Varianten link accessor
		/// <summary>
		/// Get the list of VariantenHasVariante links to a Varianten.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VariantenHasVariante> GetLinksToVariante ( global::Tum.VModellXT.Varianten variantenInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VariantenHasVariante>(variantenInstance, global::Tum.VModellXT.VariantenHasVariante.VariantenDomainRoleId);
		}
		#endregion
		#region Variante link accessor
		/// <summary>
		/// Get the VariantenHasVariante link to a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VariantenHasVariante GetLinkToVarianten (global::Tum.VModellXT.Variante varianteInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VariantenHasVariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VariantenHasVariante>(varianteInstance, global::Tum.VModellXT.VariantenHasVariante.VarianteDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Variante not obeyed.");
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
		#region VariantenHasVariante instance accessors
		
		/// <summary>
		/// Get any VariantenHasVariante links between a given Varianten and a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VariantenHasVariante> GetLinks( global::Tum.VModellXT.Varianten source, global::Tum.VModellXT.Variante target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VariantenHasVariante> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VariantenHasVariante>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VariantenHasVariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VariantenHasVariante>(source, global::Tum.VModellXT.VariantenHasVariante.VariantenDomainRoleId);
			foreach ( global::Tum.VModellXT.VariantenHasVariante link in links )
			{
				if ( target.Equals(link.Variante) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VariantenHasVariante link between a given Variantenand a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VariantenHasVariante GetLink( global::Tum.VModellXT.Varianten source, global::Tum.VModellXT.Variante target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VariantenHasVariante> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VariantenHasVariante>(source, global::Tum.VModellXT.VariantenHasVariante.VariantenDomainRoleId);
			foreach ( global::Tum.VModellXT.VariantenHasVariante link in links )
			{
				if ( target.Equals(link.Variante) )
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
			return global::Tum.VModellXT.VariantenHasVariante.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VariantenHasVariante";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Varianten Has Variante";
	        }
	    }	
		#endregion
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainRelationship VarianteSourceReferencesVarianteTarget
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VarianteSourceReferencesVarianteTarget.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VarianteSourceReferencesVarianteTarget.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("b247cff4-b48c-41db-9581-5cf8b5b3a77c")]
	public partial class VarianteSourceReferencesVarianteTarget : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VarianteSourceReferencesVarianteTarget domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("b247cff4-b48c-41db-9581-5cf8b5b3a77c");

				
		/// <summary>
		/// Constructor
		/// Creates a VarianteSourceReferencesVarianteTarget link in the same Partition as the given Variante
		/// </summary>
		/// <param name="source">Variante to use as the source of the relationship.</param>
		/// <param name="target">Variante to use as the target of the relationship.</param>
		public VarianteSourceReferencesVarianteTarget(Variante source, Variante target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId, source), new DslModeling::RoleAssignment(VarianteSourceReferencesVarianteTarget.VarianteTargetDomainRoleId, target)}, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VarianteSourceReferencesVarianteTarget(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VarianteSourceReferencesVarianteTarget(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public VarianteSourceReferencesVarianteTarget(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public VarianteSourceReferencesVarianteTarget(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VarianteSource domain role code
		
		/// <summary>
		/// VarianteSource domain role Id.
		/// </summary>
		public static readonly global::System.Guid VarianteSourceDomainRoleId = new System.Guid("764af70d-517f-414e-9013-3da5bc795e3c");
		
		/// <summary>
		/// DomainRole VarianteSource
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteSource.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteSource.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Referenzvariante", PropertyDisplayNameKey="Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteSource.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("764af70d-517f-414e-9013-3da5bc795e3c")]
		public virtual Variante VarianteSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Variante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VarianteSourceDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VarianteSourceDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access VarianteSource of a Variante
		/// <summary>
		/// Gets a list of VarianteSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Variante> GetVarianteSource(Variante element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Variante>, Variante>(element, VarianteTargetDomainRoleId);
		}
		#endregion
		#region VarianteTarget domain role code
		
		/// <summary>
		/// VarianteTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid VarianteTargetDomainRoleId = new System.Guid("2cc078f5-dabb-4067-9754-a921c3685502");
		
		/// <summary>
		/// DomainRole VarianteTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteTarget.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteTarget.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "VarianteSource", PropertyDisplayNameKey="Tum.VModellXT.VarianteSourceReferencesVarianteTarget/VarianteTarget.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("2cc078f5-dabb-4067-9754-a921c3685502")]
		public virtual Variante VarianteTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Variante)DslModeling::DomainRoleInfo.GetRolePlayer(this, VarianteTargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, VarianteTargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Referenzvariante of a Variante
		/// <summary>
		/// Gets Referenzvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static Variante GetReferenzvariante(Variante element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, VarianteSourceDomainRoleId) as Variante;
		}
		
		/// <summary>
		/// Sets Referenzvariante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetReferenzvariante(Variante element, Variante newVarianteTarget)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, VarianteSourceDomainRoleId, newVarianteTarget);
		}
		#endregion
		#region VarianteSource link accessor
		/// <summary>
		/// Get the VarianteSourceReferencesVarianteTarget link to a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget GetLinkToReferenzvariante (global::Tum.VModellXT.Variante varianteSourceInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget>(varianteSourceInstance, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of VarianteSource not obeyed.");
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
		#region VarianteTarget link accessor
		/// <summary>
		/// Get the list of VarianteSourceReferencesVarianteTarget links to a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> GetLinksToVarianteSource ( global::Tum.VModellXT.Variante varianteTargetInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget>(varianteTargetInstance, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteTargetDomainRoleId);
		}
		#endregion
		#region VarianteSourceReferencesVarianteTarget instance accessors
		
		/// <summary>
		/// Get any VarianteSourceReferencesVarianteTarget links between a given Variante and a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> GetLinks( global::Tum.VModellXT.Variante source, global::Tum.VModellXT.Variante target )
		{
			global::System.Collections.Generic.List<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> outLinks = new global::System.Collections.Generic.List<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget>();
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget>(source, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId);
			foreach ( global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget link in links )
			{
				if ( target.Equals(link.VarianteTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one VarianteSourceReferencesVarianteTarget link between a given Varianteand a Variante.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget GetLink( global::Tum.VModellXT.Variante source, global::Tum.VModellXT.Variante target )
		{
			global::System.Collections.Generic.IList<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget>(source, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId);
			foreach ( global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget link in links )
			{
				if ( target.Equals(link.VarianteTarget) )
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
			return global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.DomainClassId;		
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.VModellXT.VModellXTDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.VModellXT.VModellXTDomainModel.DomainModelId;
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
	            return "VarianteSourceReferencesVarianteTarget";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Variante Source References Variante Target";
	        }
	    }	
		#endregion
	}
}


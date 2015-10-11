 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship AttributedDomainElementHasDomainProperty
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("364ef4d8-11fd-4c3b-9e0b-483c1aa9b561")]
	public partial class AttributedDomainElementHasDomainProperty : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// AttributedDomainElementHasDomainProperty domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("364ef4d8-11fd-4c3b-9e0b-483c1aa9b561");

				
		/// <summary>
		/// Constructor
		/// Creates a AttributedDomainElementHasDomainProperty link in the same Partition as the given AttributedDomainElement
		/// </summary>
		/// <param name="source">AttributedDomainElement to use as the source of the relationship.</param>
		/// <param name="target">DomainProperty to use as the target of the relationship.</param>
		public AttributedDomainElementHasDomainProperty(AttributedDomainElement source, DomainProperty target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId, source), new DslModeling::RoleAssignment(AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public AttributedDomainElementHasDomainProperty(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public AttributedDomainElementHasDomainProperty(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public AttributedDomainElementHasDomainProperty(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public AttributedDomainElementHasDomainProperty(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region AttributedDomainElement domain role code
		
		/// <summary>
		/// AttributedDomainElement domain role Id.
		/// </summary>
		public static readonly global::System.Guid AttributedDomainElementDomainRoleId = new System.Guid("bb9a6cd5-218c-4e95-a1b8-99443d15ec33");
		
		/// <summary>
		/// DomainRole AttributedDomainElement
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty/AttributedDomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty/AttributedDomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainProperty", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty/AttributedDomainElement.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("bb9a6cd5-218c-4e95-a1b8-99443d15ec33")]
		public virtual AttributedDomainElement AttributedDomainElement
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (AttributedDomainElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, AttributedDomainElementDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, AttributedDomainElementDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access AttributedDomainElement of a DomainProperty
		/// <summary>
		/// Gets AttributedDomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static AttributedDomainElement GetAttributedDomainElement(DomainProperty element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainPropertyDomainRoleId) as AttributedDomainElement;
		}
		
		/// <summary>
		/// Sets AttributedDomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetAttributedDomainElement(DomainProperty element, AttributedDomainElement newAttributedDomainElement)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainPropertyDomainRoleId, newAttributedDomainElement);
		}
		#endregion
		#region DomainProperty domain role code
		
		/// <summary>
		/// DomainProperty domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainPropertyDomainRoleId = new System.Guid("d1c5f056-91f4-4538-a859-ca38845f79ae");
		
		/// <summary>
		/// DomainRole DomainProperty
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty/DomainProperty.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty/DomainProperty.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "AttributedDomainElement", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty/DomainProperty.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("d1c5f056-91f4-4538-a859-ca38845f79ae")]
		public virtual DomainProperty DomainProperty
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainProperty)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainPropertyDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainPropertyDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainProperty of a AttributedDomainElement
		/// <summary>
		/// Gets a list of DomainProperty.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DomainProperty> GetDomainProperty(AttributedDomainElement element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DomainProperty>, DomainProperty>(element, AttributedDomainElementDomainRoleId);
		}
		#endregion
		#region AttributedDomainElement link accessor
		/// <summary>
		/// Get the list of AttributedDomainElementHasDomainProperty links to a AttributedDomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> GetLinksToDomainProperty ( global::Tum.PDE.ModelingDSL.AttributedDomainElement attributedDomainElementInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty>(attributedDomainElementInstance, global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId);
		}
		#endregion
		#region DomainProperty link accessor
		/// <summary>
		/// Get the AttributedDomainElementHasDomainProperty link to a DomainProperty.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty GetLinkToAttributedDomainElement (global::Tum.PDE.ModelingDSL.DomainProperty domainPropertyInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty>(domainPropertyInstance, global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainProperty not obeyed.");
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
		#region AttributedDomainElementHasDomainProperty instance accessors
		
		/// <summary>
		/// Get any AttributedDomainElementHasDomainProperty links between a given AttributedDomainElement and a DomainProperty.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> GetLinks( global::Tum.PDE.ModelingDSL.AttributedDomainElement source, global::Tum.PDE.ModelingDSL.DomainProperty target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty>(source, global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty link in links )
			{
				if ( target.Equals(link.DomainProperty) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one AttributedDomainElementHasDomainProperty link between a given AttributedDomainElementand a DomainProperty.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty GetLink( global::Tum.PDE.ModelingDSL.AttributedDomainElement source, global::Tum.PDE.ModelingDSL.DomainProperty target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty>(source, global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty link in links )
			{
				if ( target.Equals(link.DomainProperty) )
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
			return global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "AttributedDomainElementHasDomainProperty";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Attributed Domain Element Has Domain Property";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship ReferenceRelationship
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferenceRelationship.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferenceRelationship.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship(AllowsDuplicates = true)]
	[DslModeling::DomainObjectId("ac088295-475e-4587-814b-5824771247fa")]
	public partial class ReferenceRelationship : BaseElementSourceReferencesBaseElementTarget
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ReferenceRelationship domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("ac088295-475e-4587-814b-5824771247fa");

				
		/// <summary>
		/// Constructor
		/// Creates a ReferenceRelationship link in the same Partition as the given ReferenceableElement
		/// </summary>
		/// <param name="source">ReferenceableElement to use as the source of the relationship.</param>
		/// <param name="target">ReferenceableElement to use as the target of the relationship.</param>
		public ReferenceRelationship(ReferenceableElement source, ReferenceableElement target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(ReferenceRelationship.SourceDomainRoleId, source), new DslModeling::RoleAssignment(ReferenceRelationship.TargetDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ReferenceRelationship(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ReferenceRelationship(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public ReferenceRelationship(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public ReferenceRelationship(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Source domain role code
		
		/// <summary>
		/// Source domain role Id.
		/// </summary>
		public static readonly global::System.Guid SourceDomainRoleId = new System.Guid("fa32eca9-606b-4440-9cab-812c0603ba67");
		
		/// <summary>
		/// DomainRole Source
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferenceRelationship/Source.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferenceRelationship/Source.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Targets", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.ReferenceRelationship/Source.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("fa32eca9-606b-4440-9cab-812c0603ba67")]
		public virtual ReferenceableElement Source
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (ReferenceableElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, SourceDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, SourceDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Sources of a ReferenceableElement
		/// <summary>
		/// Gets a list of Sources.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<ReferenceableElement> GetSources(ReferenceableElement element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<ReferenceableElement>, ReferenceableElement>(element, TargetDomainRoleId);
		}
		#endregion
		#region BaseElementSource domain role override
		
		/// <summary>
		/// Gets the element playing Source domain role.
		/// </summary>
		public override BaseElement BaseElementSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return this.Source;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				this.Source = (ReferenceableElement)value;
			}
		}
		
		#endregion
		#region Target domain role code
		
		/// <summary>
		/// Target domain role Id.
		/// </summary>
		public static readonly global::System.Guid TargetDomainRoleId = new System.Guid("31a7ebb0-4dcc-4478-9b36-d161f744efb5");
		
		/// <summary>
		/// DomainRole Target
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferenceRelationship/Target.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferenceRelationship/Target.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Sources", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.ReferenceRelationship/Target.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("31a7ebb0-4dcc-4478-9b36-d161f744efb5")]
		public virtual ReferenceableElement Target
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (ReferenceableElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, TargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, TargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Targets of a ReferenceableElement
		/// <summary>
		/// Gets a list of Targets.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<ReferenceableElement> GetTargets(ReferenceableElement element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<ReferenceableElement>, ReferenceableElement>(element, SourceDomainRoleId);
		}
		#endregion
		#region BaseElementTarget domain role override
		
		/// <summary>
		/// Gets the element playing Target domain role.
		/// </summary>
		public override BaseElement BaseElementTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return this.Target;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				this.Target = (ReferenceableElement)value;
			}
		}
		
		#endregion
		#region SourceMultiplicity domain property code
		
		/// <summary>
		/// SourceMultiplicity domain property Id.
		/// </summary>
		public static readonly global::System.Guid SourceMultiplicityDomainPropertyId = new System.Guid("41ebfa6a-e249-42ea-9c1c-14f508e3c214") ;
		
		/// <summary>
		/// Storage for SourceMultiplicity
		/// </summary>
		private global::Tum.PDE.ModelingDSL.Multiplicity? sourceMultiplicityPropertyStorage = global::Tum.PDE.ModelingDSL.Multiplicity.ZeroMany;
		
		/// <summary>
		/// Gets or sets the value of SourceMultiplicity domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferenceRelationship/SourceMultiplicity.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferenceRelationship/SourceMultiplicity.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(global::Tum.PDE.ModelingDSL.Multiplicity.ZeroMany)]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainObjectId("41ebfa6a-e249-42ea-9c1c-14f508e3c214")]
		public global::Tum.PDE.ModelingDSL.Multiplicity? SourceMultiplicity
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return sourceMultiplicityPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				SourceMultiplicityPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the ReferenceRelationship.SourceMultiplicity domain property.
		/// </summary>
		internal sealed partial class SourceMultiplicityPropertyHandler : DslModeling::DomainPropertyValueHandler<ReferenceRelationship, global::Tum.PDE.ModelingDSL.Multiplicity?>
		{
			private SourceMultiplicityPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the ReferenceRelationship.SourceMultiplicity domain property value handler.
			/// </summary>
			public static readonly SourceMultiplicityPropertyHandler Instance = new SourceMultiplicityPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the ReferenceRelationship.SourceMultiplicity domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return SourceMultiplicityDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ModelingDSL.Multiplicity? GetValue(ReferenceRelationship element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.sourceMultiplicityPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(ReferenceRelationship element, global::Tum.PDE.ModelingDSL.Multiplicity? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ModelingDSL.Multiplicity? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.sourceMultiplicityPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region TargetMultiplicity domain property code
		
		/// <summary>
		/// TargetMultiplicity domain property Id.
		/// </summary>
		public static readonly global::System.Guid TargetMultiplicityDomainPropertyId = new System.Guid("a34ab8e6-4986-49dd-981c-65640f40cc51") ;
		
		/// <summary>
		/// Storage for TargetMultiplicity
		/// </summary>
		private global::Tum.PDE.ModelingDSL.Multiplicity? targetMultiplicityPropertyStorage = global::Tum.PDE.ModelingDSL.Multiplicity.ZeroMany;
		
		/// <summary>
		/// Gets or sets the value of TargetMultiplicity domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferenceRelationship/TargetMultiplicity.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferenceRelationship/TargetMultiplicity.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(global::Tum.PDE.ModelingDSL.Multiplicity.ZeroMany)]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainObjectId("a34ab8e6-4986-49dd-981c-65640f40cc51")]
		public global::Tum.PDE.ModelingDSL.Multiplicity? TargetMultiplicity
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return targetMultiplicityPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				TargetMultiplicityPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the ReferenceRelationship.TargetMultiplicity domain property.
		/// </summary>
		internal sealed partial class TargetMultiplicityPropertyHandler : DslModeling::DomainPropertyValueHandler<ReferenceRelationship, global::Tum.PDE.ModelingDSL.Multiplicity?>
		{
			private TargetMultiplicityPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the ReferenceRelationship.TargetMultiplicity domain property value handler.
			/// </summary>
			public static readonly TargetMultiplicityPropertyHandler Instance = new TargetMultiplicityPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the ReferenceRelationship.TargetMultiplicity domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return TargetMultiplicityDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ModelingDSL.Multiplicity? GetValue(ReferenceRelationship element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.targetMultiplicityPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(ReferenceRelationship element, global::Tum.PDE.ModelingDSL.Multiplicity? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ModelingDSL.Multiplicity? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.targetMultiplicityPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Source link accessor
		/// <summary>
		/// Get the list of ReferenceRelationship links to a ReferenceableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.ReferenceRelationship> GetLinksToTargets ( global::Tum.PDE.ModelingDSL.ReferenceableElement sourceInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.ReferenceRelationship>(sourceInstance, global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId);
		}
		#endregion
		#region Target link accessor
		/// <summary>
		/// Get the list of ReferenceRelationship links to a ReferenceableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.ReferenceRelationship> GetLinksToSources ( global::Tum.PDE.ModelingDSL.ReferenceableElement targetInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.ReferenceRelationship>(targetInstance, global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId);
		}
		#endregion
		#region ReferenceRelationship instance accessors
		
		/// <summary>
		/// Get any ReferenceRelationship links between a given ReferenceableElement and a ReferenceableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.ReferenceRelationship> GetLinks( global::Tum.PDE.ModelingDSL.ReferenceableElement source, global::Tum.PDE.ModelingDSL.ReferenceableElement target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.ReferenceRelationship> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.ReferenceRelationship>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.ReferenceRelationship> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.ReferenceRelationship>(source, global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.ReferenceRelationship link in links )
			{
				if ( target.Equals(link.Target) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		#endregion
			
	    /// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
		{		
			return global::Tum.PDE.ModelingDSL.ReferenceRelationship.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "ReferenceRelationship";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Reference Relationship";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Double-derived base class for DomainRelationship EmbeddingRelationship
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EmbeddingRelationship.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EmbeddingRelationship.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("9c3d21cc-1f6c-492a-bd1f-5e76bdcfa915")]
	public abstract partial class EmbeddingRelationshipBase : BaseElementSourceReferencesBaseElementTarget
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// EmbeddingRelationship domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("9c3d21cc-1f6c-492a-bd1f-5e76bdcfa915");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">The Partition instance containing this ElementLink</param>
		/// <param name="roleAssignments">A set of role assignments for roleplayer initialization</param>
		/// <param name="propertyAssignments">A set of attribute assignments for attribute initialization</param>
		protected EmbeddingRelationshipBase(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, propertyAssignments)
		{
		}
		#endregion
		#region Child domain role code
		
		/// <summary>
		/// Child domain role Id.
		/// </summary>
		public static readonly global::System.Guid ChildDomainRoleId = new System.Guid("9d4d2e1a-8a57-44eb-aea4-6cb9223b67cb");
		
		/// <summary>
		/// DomainRole Child
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EmbeddingRelationship/Child.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EmbeddingRelationship/Child.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Parent", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.EmbeddingRelationship/Child.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroOne)]
		[DslModeling::DomainObjectId("9d4d2e1a-8a57-44eb-aea4-6cb9223b67cb")]
		public virtual EmbeddableElement Child
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (EmbeddableElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, ChildDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ChildDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Children of a EmbeddableElement
		/// <summary>
		/// Gets a list of Children.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<EmbeddableElement> GetChildren(EmbeddableElement element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<EmbeddableElement>, EmbeddableElement>(element, ParentDomainRoleId);
		}
		#endregion
		#region BaseElementSource domain role override
		
		/// <summary>
		/// Gets the element playing Child domain role.
		/// </summary>
		public override BaseElement BaseElementSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return this.Child;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				this.Child = (EmbeddableElement)value;
			}
		}
		
		#endregion
		#region Parent domain role code
		
		/// <summary>
		/// Parent domain role Id.
		/// </summary>
		public static readonly global::System.Guid ParentDomainRoleId = new System.Guid("44b1299b-eb2c-45f2-a1b4-503f8099226f");
		
		/// <summary>
		/// DomainRole Parent
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EmbeddingRelationship/Parent.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EmbeddingRelationship/Parent.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.Browsable(false)]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "Children", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.EmbeddingRelationship/Parent.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("44b1299b-eb2c-45f2-a1b4-503f8099226f")]
		public virtual EmbeddableElement Parent
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (EmbeddableElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, ParentDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ParentDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Parent of a EmbeddableElement
		/// <summary>
		/// Gets Parent.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static EmbeddableElement GetParent(EmbeddableElement element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ChildDomainRoleId) as EmbeddableElement;
		}
		
		/// <summary>
		/// Sets Parent.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetParent(EmbeddableElement element, EmbeddableElement newParent)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ChildDomainRoleId, newParent);
		}
		#endregion
		#region BaseElementTarget domain role override
		
		/// <summary>
		/// Gets the element playing Parent domain role.
		/// </summary>
		public override BaseElement BaseElementTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return this.Parent;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				this.Parent = (EmbeddableElement)value;
			}
		}
		
		#endregion
		#region Child link accessor
		/// <summary>
		/// Get the EmbeddingRelationship link to a EmbeddableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.EmbeddingRelationship GetLinkToParent (global::Tum.PDE.ModelingDSL.EmbeddableElement childInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>(childInstance, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Child not obeyed.");
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
		#region Parent link accessor
		/// <summary>
		/// Get the list of EmbeddingRelationship links to a EmbeddableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> GetLinksToChildren ( global::Tum.PDE.ModelingDSL.EmbeddableElement parentInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>(parentInstance, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId);
		}
		#endregion
		#region EmbeddingRelationship instance accessors
		
		/// <summary>
		/// Get any EmbeddingRelationship links between a given EmbeddableElement and a EmbeddableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> GetLinks( global::Tum.PDE.ModelingDSL.EmbeddableElement source, global::Tum.PDE.ModelingDSL.EmbeddableElement target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>(source, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.EmbeddingRelationship link in links )
			{
				if ( target.Equals(link.Parent) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one EmbeddingRelationship link between a given EmbeddableElementand a EmbeddableElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.EmbeddingRelationship GetLink( global::Tum.PDE.ModelingDSL.EmbeddableElement source, global::Tum.PDE.ModelingDSL.EmbeddableElement target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.EmbeddingRelationship> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.EmbeddingRelationship>(source, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.EmbeddingRelationship link in links )
			{
				if ( target.Equals(link.Parent) )
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
			return global::Tum.PDE.ModelingDSL.EmbeddingRelationship.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "EmbeddingRelationship";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Embedding Relationship";
	        }
	    }	
		#endregion
	}
	/// <summary>
	/// DomainRelationship EmbeddingRelationship
	/// </summary>
		public partial class EmbeddingRelationship : EmbeddingRelationshipBase
		{
			#region Constructors
					
			/// <summary>
			/// Constructor
			/// Creates a EmbeddingRelationship link in the same Partition as the given EmbeddableElement
			/// </summary>
			/// <param name="source">EmbeddableElement to use as the source of the relationship.</param>
			/// <param name="target">EmbeddableElement to use as the target of the relationship.</param>
			public EmbeddingRelationship(EmbeddableElement source, EmbeddableElement target)
				: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(EmbeddingRelationship.ChildDomainRoleId, source), new DslModeling::RoleAssignment(EmbeddingRelationship.ParentDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
			{
			}
			
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="store">Store where new link is to be created.</param>
			/// <param name="roleAssignments">List of relationship role assignments.</param>
			public EmbeddingRelationship(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
				: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
			{
			}
			
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="store">Store where new link is to be created.</param>
			/// <param name="roleAssignments">List of relationship role assignments.</param>
			/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
			public EmbeddingRelationship(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
				: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
			{
			}
			
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="partition">Partition where new link is to be created.</param>
			/// <param name="roleAssignments">List of relationship role assignments.</param>
			public EmbeddingRelationship(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
				: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
			{
			}
			
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="partition">Partition where new link is to be created.</param>
			/// <param name="roleAssignments">List of relationship role assignments.</param>
			/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
			public EmbeddingRelationship(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
				: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
			{
			}
			#endregion
		}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Double-derived base class for DomainRelationship BaseElementSourceReferencesBaseElementTarget
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship(AllowsDuplicates = true)]
	[DslModeling::DomainObjectId("096fede2-8b0c-4dda-b06d-565e799fb0b4")]
	public abstract partial class BaseElementSourceReferencesBaseElementTargetBase : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// BaseElementSourceReferencesBaseElementTarget domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("096fede2-8b0c-4dda-b06d-565e799fb0b4");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">The Partition instance containing this ElementLink</param>
		/// <param name="roleAssignments">A set of role assignments for roleplayer initialization</param>
		/// <param name="propertyAssignments">A set of attribute assignments for attribute initialization</param>
		protected BaseElementSourceReferencesBaseElementTargetBase(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, propertyAssignments)
		{
		}
		#endregion
		#region BaseElementSource domain role code
		
		/// <summary>
		/// BaseElementSource domain role Id.
		/// </summary>
		public static readonly global::System.Guid BaseElementSourceDomainRoleId = new System.Guid("4d69444e-6cfe-4a72-a9e2-18f00674c7b9");
		
		/// <summary>
		/// DomainRole BaseElementSource
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget/BaseElementSource.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget/BaseElementSource.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "BaseElementTarget", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget/BaseElementSource.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("4d69444e-6cfe-4a72-a9e2-18f00674c7b9")]
		public abstract BaseElement BaseElementSource
		{
			get;
			set;
		}
				
		#endregion
		#region Static methods to access BaseElementSource of a BaseElement
		/// <summary>
		/// Gets a list of BaseElementSource.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::ReadOnlyLinkedElementCollection<BaseElement> GetBaseElementSource(BaseElement element)
		{
			return GetRoleCollection<DslModeling::ReadOnlyLinkedElementCollection<BaseElement>, BaseElement>(element, BaseElementTargetDomainRoleId);
		}
		#endregion
		#region BaseElementTarget domain role code
		
		/// <summary>
		/// BaseElementTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid BaseElementTargetDomainRoleId = new System.Guid("13d7f58b-d67b-46b7-ac75-1fbbe28f7a58");
		
		/// <summary>
		/// DomainRole BaseElementTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget/BaseElementTarget.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget/BaseElementTarget.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "BaseElementSource", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget/BaseElementTarget.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("13d7f58b-d67b-46b7-ac75-1fbbe28f7a58")]
		public abstract BaseElement BaseElementTarget
		{
			get;
			set;
		}
				
		#endregion
		#region Static methods to access BaseElementTarget of a BaseElement
		/// <summary>
		/// Gets a list of BaseElementTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::ReadOnlyLinkedElementCollection<BaseElement> GetBaseElementTarget(BaseElement element)
		{
			return GetRoleCollection<DslModeling::ReadOnlyLinkedElementCollection<BaseElement>, BaseElement>(element, BaseElementSourceDomainRoleId);
		}
		#endregion
		#region BaseElementSource link accessor
		/// <summary>
		/// Get the list of BaseElementSourceReferencesBaseElementTarget links to a BaseElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget> GetLinksToBaseElementTarget ( global::Tum.PDE.ModelingDSL.BaseElement baseElementSourceInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget>(baseElementSourceInstance, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.BaseElementSourceDomainRoleId);
		}
		#endregion
		#region BaseElementTarget link accessor
		/// <summary>
		/// Get the list of BaseElementSourceReferencesBaseElementTarget links to a BaseElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget> GetLinksToBaseElementSource ( global::Tum.PDE.ModelingDSL.BaseElement baseElementTargetInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget>(baseElementTargetInstance, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.BaseElementTargetDomainRoleId);
		}
		#endregion
		#region BaseElementSourceReferencesBaseElementTarget instance accessors
		
		/// <summary>
		/// Get any BaseElementSourceReferencesBaseElementTarget links between a given BaseElement and a BaseElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget> GetLinks( global::Tum.PDE.ModelingDSL.BaseElement source, global::Tum.PDE.ModelingDSL.BaseElement target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget>(source, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.BaseElementSourceDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget link in links )
			{
				if ( target.Equals(link.BaseElementTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		#endregion
			
	    /// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
		{		
			return global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "BaseElementSourceReferencesBaseElementTarget";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Base Element Source References Base Element Target";
	        }
	    }	
		#endregion
	}
	/// <summary>
	/// DomainRelationship BaseElementSourceReferencesBaseElementTarget
	/// </summary>
		public abstract partial class BaseElementSourceReferencesBaseElementTarget : BaseElementSourceReferencesBaseElementTargetBase
		{
			#region Constructors
			/// <summary>
			/// Constructor.
			/// </summary>
			/// <param name="partition">The Partition instance containing this ElementLink</param>
			/// <param name="roleAssignments">A set of role assignments for roleplayer initialization</param>
			/// <param name="propertyAssignments">A set of attribute assignments for attribute initialization</param>
			protected BaseElementSourceReferencesBaseElementTarget(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
				: base(partition, roleAssignments, propertyAssignments)
			{
			}
			#endregion
		}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainModelHasDomainElements
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDomainElements.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("4e31d05e-7f7c-43c8-b5c1-dacc2438b6c6")]
	public partial class DomainModelHasDomainElements : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasDomainElements domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("4e31d05e-7f7c-43c8-b5c1-dacc2438b6c6");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasDomainElements link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">DomainElements to use as the target of the relationship.</param>
		public DomainModelHasDomainElements(DomainModel source, DomainElements target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasDomainElements.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasDomainElements.DomainElementsDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDomainElements(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDomainElements(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDomainElements(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDomainElements(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("ea03caa8-cec6-4439-bd91-668c230e73c7");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDomainElements/DomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDomainElements/DomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainElements", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDomainElements/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("ea03caa8-cec6-4439-bd91-668c230e73c7")]
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
		#region Static methods to access DomainModel of a DomainElements
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(DomainElements element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainElementsDomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(DomainElements element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainElementsDomainRoleId, newDomainModel);
		}
		#endregion
		#region DomainElements domain role code
		
		/// <summary>
		/// DomainElements domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainElementsDomainRoleId = new System.Guid("ae96a2e6-fc32-404e-9b6c-c34ec33c5b1f");
		
		/// <summary>
		/// DomainRole DomainElements
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDomainElements/DomainElements.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDomainElements/DomainElements.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDomainElements/DomainElements.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("ae96a2e6-fc32-404e-9b6c-c34ec33c5b1f")]
		public virtual DomainElements DomainElements
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainElements)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainElementsDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainElementsDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainElements of a DomainModel
		/// <summary>
		/// Gets DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainElements GetDomainElements(DomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainModelDomainRoleId) as DomainElements;
		}
		
		/// <summary>
		/// Sets DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainElements(DomainModel element, DomainElements newDomainElements)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainModelDomainRoleId, newDomainElements);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the DomainModelHasDomainElements link to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements GetLinkToDomainElements (global::Tum.PDE.ModelingDSL.DomainModel domainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements>(domainModelInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainModel not obeyed.");
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
		#region DomainElements link accessor
		/// <summary>
		/// Get the DomainModelHasDomainElements link to a DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements GetLinkToDomainModel (global::Tum.PDE.ModelingDSL.DomainElements domainElementsInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements>(domainElementsInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainElementsDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainElements not obeyed.");
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
		#region DomainModelHasDomainElements instance accessors
		
		/// <summary>
		/// Get any DomainModelHasDomainElements links between a given DomainModel and a DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> GetLinks( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DomainElements target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements link in links )
			{
				if ( target.Equals(link.DomainElements) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasDomainElements link between a given DomainModeland a DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements GetLink( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DomainElements target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements link in links )
			{
				if ( target.Equals(link.DomainElements) )
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
			return global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainModelHasDomainElements";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has Domain Elements";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainElementsHasDomainElement
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("68fffc4e-dff5-4fc1-83f2-6dbf7a433e63")]
	public partial class DomainElementsHasDomainElement : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainElementsHasDomainElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("68fffc4e-dff5-4fc1-83f2-6dbf7a433e63");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainElementsHasDomainElement link in the same Partition as the given DomainElements
		/// </summary>
		/// <param name="source">DomainElements to use as the source of the relationship.</param>
		/// <param name="target">DomainElement to use as the target of the relationship.</param>
		public DomainElementsHasDomainElement(DomainElements source, DomainElement target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainElementsHasDomainElement.DomainElementsDomainRoleId, source), new DslModeling::RoleAssignment(DomainElementsHasDomainElement.DomainElementDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainElementsHasDomainElement(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainElementsHasDomainElement(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainElementsHasDomainElement(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainElementsHasDomainElement(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainElements domain role code
		
		/// <summary>
		/// DomainElements domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainElementsDomainRoleId = new System.Guid("2714e626-7b6f-4eb1-9855-a55ab8aaef40");
		
		/// <summary>
		/// DomainRole DomainElements
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElementsHasDomainElement/DomainElements.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElementsHasDomainElement/DomainElements.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainElement", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainElementsHasDomainElement/DomainElements.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("2714e626-7b6f-4eb1-9855-a55ab8aaef40")]
		public virtual DomainElements DomainElements
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainElements)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainElementsDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainElementsDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainElements of a DomainElement
		/// <summary>
		/// Gets DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainElements GetDomainElements(DomainElement element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainElementDomainRoleId) as DomainElements;
		}
		
		/// <summary>
		/// Sets DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainElements(DomainElement element, DomainElements newDomainElements)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainElementDomainRoleId, newDomainElements);
		}
		#endregion
		#region DomainElement domain role code
		
		/// <summary>
		/// DomainElement domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainElementDomainRoleId = new System.Guid("ebaf66f4-6a72-41fd-8ff3-d0d3931bb3a8");
		
		/// <summary>
		/// DomainRole DomainElement
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElementsHasDomainElement/DomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElementsHasDomainElement/DomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainElements", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainElementsHasDomainElement/DomainElement.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("ebaf66f4-6a72-41fd-8ff3-d0d3931bb3a8")]
		public virtual DomainElement DomainElement
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainElementDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainElementDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainElement of a DomainElements
		/// <summary>
		/// Gets a list of DomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DomainElement> GetDomainElement(DomainElements element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DomainElement>, DomainElement>(element, DomainElementsDomainRoleId);
		}
		#endregion
		#region DomainElements link accessor
		/// <summary>
		/// Get the list of DomainElementsHasDomainElement links to a DomainElements.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> GetLinksToDomainElement ( global::Tum.PDE.ModelingDSL.DomainElements domainElementsInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement>(domainElementsInstance, global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementsDomainRoleId);
		}
		#endregion
		#region DomainElement link accessor
		/// <summary>
		/// Get the DomainElementsHasDomainElement link to a DomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement GetLinkToDomainElements (global::Tum.PDE.ModelingDSL.DomainElement domainElementInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement>(domainElementInstance, global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainElement not obeyed.");
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
		#region DomainElementsHasDomainElement instance accessors
		
		/// <summary>
		/// Get any DomainElementsHasDomainElement links between a given DomainElements and a DomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> GetLinks( global::Tum.PDE.ModelingDSL.DomainElements source, global::Tum.PDE.ModelingDSL.DomainElement target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement>(source, global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementsDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement link in links )
			{
				if ( target.Equals(link.DomainElement) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainElementsHasDomainElement link between a given DomainElementsand a DomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement GetLink( global::Tum.PDE.ModelingDSL.DomainElements source, global::Tum.PDE.ModelingDSL.DomainElement target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement>(source, global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementsDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement link in links )
			{
				if ( target.Equals(link.DomainElement) )
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
			return global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainElementsHasDomainElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Elements Has Domain Element";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainModelHasDomainTypes
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("da287f41-2f4b-4d6a-9e50-53e328ed5fee")]
	public partial class DomainModelHasDomainTypes : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasDomainTypes domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("da287f41-2f4b-4d6a-9e50-53e328ed5fee");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasDomainTypes link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">DomainTypes to use as the target of the relationship.</param>
		public DomainModelHasDomainTypes(DomainModel source, DomainTypes target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasDomainTypes.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasDomainTypes.DomainTypesDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDomainTypes(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDomainTypes(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDomainTypes(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDomainTypes(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("703ebb41-aff3-4b58-9d7d-8bb197509fbb");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDomainTypes/DomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDomainTypes/DomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainTypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDomainTypes/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("703ebb41-aff3-4b58-9d7d-8bb197509fbb")]
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
		#region Static methods to access DomainModel of a DomainTypes
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(DomainTypes element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainTypesDomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(DomainTypes element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainTypesDomainRoleId, newDomainModel);
		}
		#endregion
		#region DomainTypes domain role code
		
		/// <summary>
		/// DomainTypes domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainTypesDomainRoleId = new System.Guid("39718366-415f-4fa0-8804-b026ea0699dd");
		
		/// <summary>
		/// DomainRole DomainTypes
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDomainTypes/DomainTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDomainTypes/DomainTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDomainTypes/DomainTypes.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("39718366-415f-4fa0-8804-b026ea0699dd")]
		public virtual DomainTypes DomainTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainTypes)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainTypesDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainTypesDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainTypes of a DomainModel
		/// <summary>
		/// Gets DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainTypes GetDomainTypes(DomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainModelDomainRoleId) as DomainTypes;
		}
		
		/// <summary>
		/// Sets DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainTypes(DomainModel element, DomainTypes newDomainTypes)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainModelDomainRoleId, newDomainTypes);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the DomainModelHasDomainTypes link to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes GetLinkToDomainTypes (global::Tum.PDE.ModelingDSL.DomainModel domainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes>(domainModelInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainModel not obeyed.");
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
		#region DomainTypes link accessor
		/// <summary>
		/// Get the DomainModelHasDomainTypes link to a DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes GetLinkToDomainModel (global::Tum.PDE.ModelingDSL.DomainTypes domainTypesInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes>(domainTypesInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainTypesDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainTypes not obeyed.");
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
		#region DomainModelHasDomainTypes instance accessors
		
		/// <summary>
		/// Get any DomainModelHasDomainTypes links between a given DomainModel and a DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> GetLinks( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DomainTypes target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes link in links )
			{
				if ( target.Equals(link.DomainTypes) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasDomainTypes link between a given DomainModeland a DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes GetLink( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DomainTypes target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes link in links )
			{
				if ( target.Equals(link.DomainTypes) )
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
			return global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainModelHasDomainTypes";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has Domain Types";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainTypesHasDomainType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainTypesHasDomainType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("c4012e1a-1016-44c6-b98e-f26b03e9d5bd")]
	public partial class DomainTypesHasDomainType : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainTypesHasDomainType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("c4012e1a-1016-44c6-b98e-f26b03e9d5bd");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainTypesHasDomainType link in the same Partition as the given DomainTypes
		/// </summary>
		/// <param name="source">DomainTypes to use as the source of the relationship.</param>
		/// <param name="target">DomainType to use as the target of the relationship.</param>
		public DomainTypesHasDomainType(DomainTypes source, DomainType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainTypesHasDomainType.DomainTypesDomainRoleId, source), new DslModeling::RoleAssignment(DomainTypesHasDomainType.DomainTypeDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainTypesHasDomainType(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainTypesHasDomainType(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainTypesHasDomainType(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainTypesHasDomainType(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainTypes domain role code
		
		/// <summary>
		/// DomainTypes domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainTypesDomainRoleId = new System.Guid("1b82ee40-9009-45c1-90dc-eac0f1e1a801");
		
		/// <summary>
		/// DomainRole DomainTypes
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainTypesHasDomainType/DomainTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainTypesHasDomainType/DomainTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainType", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainTypesHasDomainType/DomainTypes.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("1b82ee40-9009-45c1-90dc-eac0f1e1a801")]
		public virtual DomainTypes DomainTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainTypes)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainTypesDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainTypesDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainTypes of a DomainType
		/// <summary>
		/// Gets DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainTypes GetDomainTypes(DomainType element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainTypeDomainRoleId) as DomainTypes;
		}
		
		/// <summary>
		/// Sets DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainTypes(DomainType element, DomainTypes newDomainTypes)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainTypeDomainRoleId, newDomainTypes);
		}
		#endregion
		#region DomainType domain role code
		
		/// <summary>
		/// DomainType domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainTypeDomainRoleId = new System.Guid("7522a8be-5855-4f5a-bb04-8709d55a288d");
		
		/// <summary>
		/// DomainRole DomainType
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainTypesHasDomainType/DomainType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainTypesHasDomainType/DomainType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainTypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainTypesHasDomainType/DomainType.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("7522a8be-5855-4f5a-bb04-8709d55a288d")]
		public virtual DomainType DomainType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainTypeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainTypeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainType of a DomainTypes
		/// <summary>
		/// Gets a list of DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DomainType> GetDomainType(DomainTypes element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DomainType>, DomainType>(element, DomainTypesDomainRoleId);
		}
		#endregion
		#region DomainTypes link accessor
		/// <summary>
		/// Get the list of DomainTypesHasDomainType links to a DomainTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> GetLinksToDomainType ( global::Tum.PDE.ModelingDSL.DomainTypes domainTypesInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType>(domainTypesInstance, global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypesDomainRoleId);
		}
		#endregion
		#region DomainType link accessor
		/// <summary>
		/// Get the DomainTypesHasDomainType link to a DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType GetLinkToDomainTypes (global::Tum.PDE.ModelingDSL.DomainType domainTypeInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType>(domainTypeInstance, global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypeDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainType not obeyed.");
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
		#region DomainTypesHasDomainType instance accessors
		
		/// <summary>
		/// Get any DomainTypesHasDomainType links between a given DomainTypes and a DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> GetLinks( global::Tum.PDE.ModelingDSL.DomainTypes source, global::Tum.PDE.ModelingDSL.DomainType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType>(source, global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypesDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType link in links )
			{
				if ( target.Equals(link.DomainType) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainTypesHasDomainType link between a given DomainTypesand a DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType GetLink( global::Tum.PDE.ModelingDSL.DomainTypes source, global::Tum.PDE.ModelingDSL.DomainType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType>(source, global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypesDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType link in links )
			{
				if ( target.Equals(link.DomainType) )
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
			return global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainTypesHasDomainType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Types Has Domain Type";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainEnumerationHasEnumerationLiteral
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("b32ce2ef-4bd7-43a6-a123-78d74c55633f")]
	public partial class DomainEnumerationHasEnumerationLiteral : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainEnumerationHasEnumerationLiteral domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("b32ce2ef-4bd7-43a6-a123-78d74c55633f");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainEnumerationHasEnumerationLiteral link in the same Partition as the given DomainEnumeration
		/// </summary>
		/// <param name="source">DomainEnumeration to use as the source of the relationship.</param>
		/// <param name="target">EnumerationLiteral to use as the target of the relationship.</param>
		public DomainEnumerationHasEnumerationLiteral(DomainEnumeration source, EnumerationLiteral target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId, source), new DslModeling::RoleAssignment(DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainEnumerationHasEnumerationLiteral(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainEnumerationHasEnumerationLiteral(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainEnumerationHasEnumerationLiteral(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainEnumerationHasEnumerationLiteral(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainEnumeration domain role code
		
		/// <summary>
		/// DomainEnumeration domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainEnumerationDomainRoleId = new System.Guid("ad6ab4d9-c7dd-47ba-ab99-17027a675bfd");
		
		/// <summary>
		/// DomainRole DomainEnumeration
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral/DomainEnumeration.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral/DomainEnumeration.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "EnumerationLiteral", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral/DomainEnumeration.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("ad6ab4d9-c7dd-47ba-ab99-17027a675bfd")]
		public virtual DomainEnumeration DomainEnumeration
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainEnumeration)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainEnumerationDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainEnumerationDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainEnumeration of a EnumerationLiteral
		/// <summary>
		/// Gets DomainEnumeration.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainEnumeration GetDomainEnumeration(EnumerationLiteral element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, EnumerationLiteralDomainRoleId) as DomainEnumeration;
		}
		
		/// <summary>
		/// Sets DomainEnumeration.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainEnumeration(EnumerationLiteral element, DomainEnumeration newDomainEnumeration)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, EnumerationLiteralDomainRoleId, newDomainEnumeration);
		}
		#endregion
		#region EnumerationLiteral domain role code
		
		/// <summary>
		/// EnumerationLiteral domain role Id.
		/// </summary>
		public static readonly global::System.Guid EnumerationLiteralDomainRoleId = new System.Guid("fb725383-845a-435e-8490-dce3d87e8140");
		
		/// <summary>
		/// DomainRole EnumerationLiteral
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral/EnumerationLiteral.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral/EnumerationLiteral.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainEnumeration", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral/EnumerationLiteral.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("fb725383-845a-435e-8490-dce3d87e8140")]
		public virtual EnumerationLiteral EnumerationLiteral
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (EnumerationLiteral)DslModeling::DomainRoleInfo.GetRolePlayer(this, EnumerationLiteralDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, EnumerationLiteralDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access EnumerationLiteral of a DomainEnumeration
		/// <summary>
		/// Gets a list of EnumerationLiteral.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<EnumerationLiteral> GetEnumerationLiteral(DomainEnumeration element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<EnumerationLiteral>, EnumerationLiteral>(element, DomainEnumerationDomainRoleId);
		}
		#endregion
		#region DomainEnumeration link accessor
		/// <summary>
		/// Get the list of DomainEnumerationHasEnumerationLiteral links to a DomainEnumeration.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> GetLinksToEnumerationLiteral ( global::Tum.PDE.ModelingDSL.DomainEnumeration domainEnumerationInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral>(domainEnumerationInstance, global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId);
		}
		#endregion
		#region EnumerationLiteral link accessor
		/// <summary>
		/// Get the DomainEnumerationHasEnumerationLiteral link to a EnumerationLiteral.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral GetLinkToDomainEnumeration (global::Tum.PDE.ModelingDSL.EnumerationLiteral enumerationLiteralInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral>(enumerationLiteralInstance, global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of EnumerationLiteral not obeyed.");
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
		#region DomainEnumerationHasEnumerationLiteral instance accessors
		
		/// <summary>
		/// Get any DomainEnumerationHasEnumerationLiteral links between a given DomainEnumeration and a EnumerationLiteral.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> GetLinks( global::Tum.PDE.ModelingDSL.DomainEnumeration source, global::Tum.PDE.ModelingDSL.EnumerationLiteral target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral>(source, global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral link in links )
			{
				if ( target.Equals(link.EnumerationLiteral) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainEnumerationHasEnumerationLiteral link between a given DomainEnumerationand a EnumerationLiteral.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral GetLink( global::Tum.PDE.ModelingDSL.DomainEnumeration source, global::Tum.PDE.ModelingDSL.EnumerationLiteral target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral>(source, global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral link in links )
			{
				if ( target.Equals(link.EnumerationLiteral) )
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
			return global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainEnumerationHasEnumerationLiteral";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Enumeration Has Enumeration Literal";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainPropertyReferencesDomainType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("059a82d1-7200-4b1a-90f6-87628bf875e6")]
	public partial class DomainPropertyReferencesDomainType : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainPropertyReferencesDomainType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("059a82d1-7200-4b1a-90f6-87628bf875e6");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainPropertyReferencesDomainType link in the same Partition as the given DomainProperty
		/// </summary>
		/// <param name="source">DomainProperty to use as the source of the relationship.</param>
		/// <param name="target">DomainType to use as the target of the relationship.</param>
		public DomainPropertyReferencesDomainType(DomainProperty source, DomainType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId, source), new DslModeling::RoleAssignment(DomainPropertyReferencesDomainType.DomainTypeDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainPropertyReferencesDomainType(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainPropertyReferencesDomainType(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainPropertyReferencesDomainType(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainPropertyReferencesDomainType(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainProperty domain role code
		
		/// <summary>
		/// DomainProperty domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainPropertyDomainRoleId = new System.Guid("0393ae13-3630-431f-ad53-807f8e136822");
		
		/// <summary>
		/// DomainRole DomainProperty
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainProperty.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainProperty.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainType", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainProperty.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("0393ae13-3630-431f-ad53-807f8e136822")]
		public virtual DomainProperty DomainProperty
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainProperty)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainPropertyDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainPropertyDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainProperty of a DomainType
		/// <summary>
		/// Gets a list of DomainProperty.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DomainProperty> GetDomainProperty(DomainType element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DomainProperty>, DomainProperty>(element, DomainTypeDomainRoleId);
		}
		#endregion
		#region DomainType domain role code
		
		/// <summary>
		/// DomainType domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainTypeDomainRoleId = new System.Guid("ea337131-e279-41e4-b321-9791a5a4a404");
		
		/// <summary>
		/// DomainRole DomainType
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainProperty", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType/DomainType.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("ea337131-e279-41e4-b321-9791a5a4a404")]
		public virtual DomainType DomainType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainTypeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainTypeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainType of a DomainProperty
		/// <summary>
		/// Gets DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainType GetDomainType(DomainProperty element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainPropertyDomainRoleId) as DomainType;
		}
		
		/// <summary>
		/// Sets DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainType(DomainProperty element, DomainType newDomainType)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainPropertyDomainRoleId, newDomainType);
		}
		#endregion
		#region DomainProperty link accessor
		/// <summary>
		/// Get the DomainPropertyReferencesDomainType link to a DomainProperty.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType GetLinkToDomainType (global::Tum.PDE.ModelingDSL.DomainProperty domainPropertyInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType>(domainPropertyInstance, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainProperty not obeyed.");
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
		#region DomainType link accessor
		/// <summary>
		/// Get the list of DomainPropertyReferencesDomainType links to a DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> GetLinksToDomainProperty ( global::Tum.PDE.ModelingDSL.DomainType domainTypeInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType>(domainTypeInstance, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainTypeDomainRoleId);
		}
		#endregion
		#region DomainPropertyReferencesDomainType instance accessors
		
		/// <summary>
		/// Get any DomainPropertyReferencesDomainType links between a given DomainProperty and a DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> GetLinks( global::Tum.PDE.ModelingDSL.DomainProperty source, global::Tum.PDE.ModelingDSL.DomainType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType>(source, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType link in links )
			{
				if ( target.Equals(link.DomainType) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainPropertyReferencesDomainType link between a given DomainPropertyand a DomainType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType GetLink( global::Tum.PDE.ModelingDSL.DomainProperty source, global::Tum.PDE.ModelingDSL.DomainType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType>(source, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType link in links )
			{
				if ( target.Equals(link.DomainType) )
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
			return global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainPropertyReferencesDomainType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Property References Domain Type";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainModelHasDETypes
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDETypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDETypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("42828c00-36f0-47f4-ad03-3e12d4a9acf2")]
	public partial class DomainModelHasDETypes : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasDETypes domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("42828c00-36f0-47f4-ad03-3e12d4a9acf2");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasDETypes link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">DETypes to use as the target of the relationship.</param>
		public DomainModelHasDETypes(DomainModel source, DETypes target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasDETypes.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasDETypes.DETypesDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDETypes(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDETypes(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDETypes(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDETypes(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("9e68e9c7-45d7-450c-9135-cb4c7ec1a7e9");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDETypes/DomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDETypes/DomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DETypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDETypes/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("9e68e9c7-45d7-450c-9135-cb4c7ec1a7e9")]
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
		#region Static methods to access DomainModel of a DETypes
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(DETypes element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DETypesDomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(DETypes element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DETypesDomainRoleId, newDomainModel);
		}
		#endregion
		#region DETypes domain role code
		
		/// <summary>
		/// DETypes domain role Id.
		/// </summary>
		public static readonly global::System.Guid DETypesDomainRoleId = new System.Guid("3013eb76-115a-4653-995a-154df93f7e5f");
		
		/// <summary>
		/// DomainRole DETypes
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDETypes/DETypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDETypes/DETypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDETypes/DETypes.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("3013eb76-115a-4653-995a-154df93f7e5f")]
		public virtual DETypes DETypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DETypes)DslModeling::DomainRoleInfo.GetRolePlayer(this, DETypesDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DETypesDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DETypes of a DomainModel
		/// <summary>
		/// Gets DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DETypes GetDETypes(DomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainModelDomainRoleId) as DETypes;
		}
		
		/// <summary>
		/// Sets DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDETypes(DomainModel element, DETypes newDETypes)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainModelDomainRoleId, newDETypes);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the DomainModelHasDETypes link to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDETypes GetLinkToDETypes (global::Tum.PDE.ModelingDSL.DomainModel domainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes>(domainModelInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainModel not obeyed.");
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
		#region DETypes link accessor
		/// <summary>
		/// Get the DomainModelHasDETypes link to a DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDETypes GetLinkToDomainModel (global::Tum.PDE.ModelingDSL.DETypes dETypesInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes>(dETypesInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DETypesDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DETypes not obeyed.");
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
		#region DomainModelHasDETypes instance accessors
		
		/// <summary>
		/// Get any DomainModelHasDETypes links between a given DomainModel and a DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> GetLinks( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DETypes target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDETypes link in links )
			{
				if ( target.Equals(link.DETypes) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasDETypes link between a given DomainModeland a DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDETypes GetLink( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DETypes target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDETypes>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDETypes link in links )
			{
				if ( target.Equals(link.DETypes) )
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
			return global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainModelHasDETypes";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has DETypes";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainModelHasDRTypes
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDRTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("a141e18d-2ba0-4505-9315-5b3f706c95e3")]
	public partial class DomainModelHasDRTypes : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasDRTypes domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a141e18d-2ba0-4505-9315-5b3f706c95e3");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasDRTypes link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">DRTypes to use as the target of the relationship.</param>
		public DomainModelHasDRTypes(DomainModel source, DRTypes target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasDRTypes.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasDRTypes.DRTypesDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDRTypes(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDRTypes(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasDRTypes(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasDRTypes(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("7c62e9e7-f857-4247-ab61-e0cf7227a80e");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDRTypes/DomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDRTypes/DomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DRTypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDRTypes/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("7c62e9e7-f857-4247-ab61-e0cf7227a80e")]
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
		#region Static methods to access DomainModel of a DRTypes
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(DRTypes element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DRTypesDomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(DRTypes element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DRTypesDomainRoleId, newDomainModel);
		}
		#endregion
		#region DRTypes domain role code
		
		/// <summary>
		/// DRTypes domain role Id.
		/// </summary>
		public static readonly global::System.Guid DRTypesDomainRoleId = new System.Guid("3ca2e4cd-a9d7-4bf3-ba47-154780d0243e");
		
		/// <summary>
		/// DomainRole DRTypes
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasDRTypes/DRTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasDRTypes/DRTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasDRTypes/DRTypes.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("3ca2e4cd-a9d7-4bf3-ba47-154780d0243e")]
		public virtual DRTypes DRTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DRTypes)DslModeling::DomainRoleInfo.GetRolePlayer(this, DRTypesDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DRTypesDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DRTypes of a DomainModel
		/// <summary>
		/// Gets DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DRTypes GetDRTypes(DomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainModelDomainRoleId) as DRTypes;
		}
		
		/// <summary>
		/// Sets DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDRTypes(DomainModel element, DRTypes newDRTypes)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainModelDomainRoleId, newDRTypes);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the DomainModelHasDRTypes link to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes GetLinkToDRTypes (global::Tum.PDE.ModelingDSL.DomainModel domainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes>(domainModelInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainModel not obeyed.");
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
		#region DRTypes link accessor
		/// <summary>
		/// Get the DomainModelHasDRTypes link to a DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes GetLinkToDomainModel (global::Tum.PDE.ModelingDSL.DRTypes dRTypesInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes>(dRTypesInstance, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DRTypesDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DRTypes not obeyed.");
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
		#region DomainModelHasDRTypes instance accessors
		
		/// <summary>
		/// Get any DomainModelHasDRTypes links between a given DomainModel and a DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> GetLinks( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DRTypes target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes link in links )
			{
				if ( target.Equals(link.DRTypes) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasDRTypes link between a given DomainModeland a DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes GetLink( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.DRTypes target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes>(source, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes link in links )
			{
				if ( target.Equals(link.DRTypes) )
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
			return global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainModelHasDRTypes";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has DRTypes";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DETypesHasDEType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DETypesHasDEType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DETypesHasDEType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("45a265ce-e0be-4bb1-b198-198dc2b27869")]
	public partial class DETypesHasDEType : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DETypesHasDEType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("45a265ce-e0be-4bb1-b198-198dc2b27869");

				
		/// <summary>
		/// Constructor
		/// Creates a DETypesHasDEType link in the same Partition as the given DETypes
		/// </summary>
		/// <param name="source">DETypes to use as the source of the relationship.</param>
		/// <param name="target">DEType to use as the target of the relationship.</param>
		public DETypesHasDEType(DETypes source, DEType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DETypesHasDEType.DETypesDomainRoleId, source), new DslModeling::RoleAssignment(DETypesHasDEType.DETypeDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DETypesHasDEType(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DETypesHasDEType(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DETypesHasDEType(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DETypesHasDEType(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DETypes domain role code
		
		/// <summary>
		/// DETypes domain role Id.
		/// </summary>
		public static readonly global::System.Guid DETypesDomainRoleId = new System.Guid("8fc304fb-edcd-45dc-909d-0576f62d7b4a");
		
		/// <summary>
		/// DomainRole DETypes
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DETypesHasDEType/DETypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DETypesHasDEType/DETypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainElementTypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DETypesHasDEType/DETypes.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("8fc304fb-edcd-45dc-909d-0576f62d7b4a")]
		public virtual DETypes DETypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DETypes)DslModeling::DomainRoleInfo.GetRolePlayer(this, DETypesDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DETypesDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DETypes of a DEType
		/// <summary>
		/// Gets DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DETypes GetDETypes(DEType element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DETypeDomainRoleId) as DETypes;
		}
		
		/// <summary>
		/// Sets DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDETypes(DEType element, DETypes newDETypes)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DETypeDomainRoleId, newDETypes);
		}
		#endregion
		#region DEType domain role code
		
		/// <summary>
		/// DEType domain role Id.
		/// </summary>
		public static readonly global::System.Guid DETypeDomainRoleId = new System.Guid("958f9f5e-2e44-47ff-9232-2e44252a8264");
		
		/// <summary>
		/// DomainRole DEType
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DETypesHasDEType/DEType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DETypesHasDEType/DEType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DETypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DETypesHasDEType/DEType.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("958f9f5e-2e44-47ff-9232-2e44252a8264")]
		public virtual DEType DEType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DEType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DETypeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DETypeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainElementTypes of a DETypes
		/// <summary>
		/// Gets a list of DomainElementTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DEType> GetDomainElementTypes(DETypes element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DEType>, DEType>(element, DETypesDomainRoleId);
		}
		#endregion
		#region DETypes link accessor
		/// <summary>
		/// Get the list of DETypesHasDEType links to a DETypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DETypesHasDEType> GetLinksToDomainElementTypes ( global::Tum.PDE.ModelingDSL.DETypes dETypesInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DETypesHasDEType>(dETypesInstance, global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypesDomainRoleId);
		}
		#endregion
		#region DEType link accessor
		/// <summary>
		/// Get the DETypesHasDEType link to a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DETypesHasDEType GetLinkToDETypes (global::Tum.PDE.ModelingDSL.DEType dETypeInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DETypesHasDEType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DETypesHasDEType>(dETypeInstance, global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypeDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DEType not obeyed.");
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
		#region DETypesHasDEType instance accessors
		
		/// <summary>
		/// Get any DETypesHasDEType links between a given DETypes and a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DETypesHasDEType> GetLinks( global::Tum.PDE.ModelingDSL.DETypes source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DETypesHasDEType> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DETypesHasDEType>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DETypesHasDEType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DETypesHasDEType>(source, global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypesDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DETypesHasDEType link in links )
			{
				if ( target.Equals(link.DEType) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DETypesHasDEType link between a given DETypesand a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DETypesHasDEType GetLink( global::Tum.PDE.ModelingDSL.DETypes source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DETypesHasDEType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DETypesHasDEType>(source, global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypesDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DETypesHasDEType link in links )
			{
				if ( target.Equals(link.DEType) )
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
			return global::Tum.PDE.ModelingDSL.DETypesHasDEType.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DETypesHasDEType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DETypes Has DEType";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DRTypesHasDRType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypesHasDRType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypesHasDRType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("e3074cbd-bb73-42af-b2c7-821e2a506179")]
	public partial class DRTypesHasDRType : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DRTypesHasDRType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("e3074cbd-bb73-42af-b2c7-821e2a506179");

				
		/// <summary>
		/// Constructor
		/// Creates a DRTypesHasDRType link in the same Partition as the given DRTypes
		/// </summary>
		/// <param name="source">DRTypes to use as the source of the relationship.</param>
		/// <param name="target">DRType to use as the target of the relationship.</param>
		public DRTypesHasDRType(DRTypes source, DRType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DRTypesHasDRType.DRTypesDomainRoleId, source), new DslModeling::RoleAssignment(DRTypesHasDRType.DRTypeDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypesHasDRType(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypesHasDRType(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypesHasDRType(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypesHasDRType(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DRTypes domain role code
		
		/// <summary>
		/// DRTypes domain role Id.
		/// </summary>
		public static readonly global::System.Guid DRTypesDomainRoleId = new System.Guid("9e7cad1e-f6b0-4848-828f-08426bd25687");
		
		/// <summary>
		/// DomainRole DRTypes
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypesHasDRType/DRTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypesHasDRType/DRTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "DomainRelationshipTypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypesHasDRType/DRTypes.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("9e7cad1e-f6b0-4848-828f-08426bd25687")]
		public virtual DRTypes DRTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DRTypes)DslModeling::DomainRoleInfo.GetRolePlayer(this, DRTypesDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DRTypesDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DRTypes of a DRType
		/// <summary>
		/// Gets DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DRTypes GetDRTypes(DRType element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DRTypeDomainRoleId) as DRTypes;
		}
		
		/// <summary>
		/// Sets DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDRTypes(DRType element, DRTypes newDRTypes)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DRTypeDomainRoleId, newDRTypes);
		}
		#endregion
		#region DRType domain role code
		
		/// <summary>
		/// DRType domain role Id.
		/// </summary>
		public static readonly global::System.Guid DRTypeDomainRoleId = new System.Guid("0f3c6c81-6c8a-46ea-9e10-f311e3c0aeb2");
		
		/// <summary>
		/// DomainRole DRType
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypesHasDRType/DRType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypesHasDRType/DRType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DRTypes", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypesHasDRType/DRType.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("0f3c6c81-6c8a-46ea-9e10-f311e3c0aeb2")]
		public virtual DRType DRType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DRType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DRTypeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DRTypeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainRelationshipTypes of a DRTypes
		/// <summary>
		/// Gets a list of DomainRelationshipTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DRType> GetDomainRelationshipTypes(DRTypes element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DRType>, DRType>(element, DRTypesDomainRoleId);
		}
		#endregion
		#region DRTypes link accessor
		/// <summary>
		/// Get the list of DRTypesHasDRType links to a DRTypes.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> GetLinksToDomainRelationshipTypes ( global::Tum.PDE.ModelingDSL.DRTypes dRTypesInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypesHasDRType>(dRTypesInstance, global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypesDomainRoleId);
		}
		#endregion
		#region DRType link accessor
		/// <summary>
		/// Get the DRTypesHasDRType link to a DRType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypesHasDRType GetLinkToDRTypes (global::Tum.PDE.ModelingDSL.DRType dRTypeInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypesHasDRType>(dRTypeInstance, global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypeDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DRType not obeyed.");
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
		#region DRTypesHasDRType instance accessors
		
		/// <summary>
		/// Get any DRTypesHasDRType links between a given DRTypes and a DRType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> GetLinks( global::Tum.PDE.ModelingDSL.DRTypes source, global::Tum.PDE.ModelingDSL.DRType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypesHasDRType>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypesHasDRType>(source, global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypesDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypesHasDRType link in links )
			{
				if ( target.Equals(link.DRType) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DRTypesHasDRType link between a given DRTypesand a DRType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypesHasDRType GetLink( global::Tum.PDE.ModelingDSL.DRTypes source, global::Tum.PDE.ModelingDSL.DRType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypesHasDRType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypesHasDRType>(source, global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypesDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypesHasDRType link in links )
			{
				if ( target.Equals(link.DRType) )
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
			return global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DRTypesHasDRType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DRTypes Has DRType";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainElementReferencesDEType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElementReferencesDEType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("d0a14790-6117-4ae4-b046-2bcf54e64dba")]
	public partial class DomainElementReferencesDEType : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainElementReferencesDEType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("d0a14790-6117-4ae4-b046-2bcf54e64dba");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainElementReferencesDEType link in the same Partition as the given DomainElement
		/// </summary>
		/// <param name="source">DomainElement to use as the source of the relationship.</param>
		/// <param name="target">DEType to use as the target of the relationship.</param>
		public DomainElementReferencesDEType(DomainElement source, DEType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainElementReferencesDEType.DomainElementDomainRoleId, source), new DslModeling::RoleAssignment(DomainElementReferencesDEType.DETypeDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainElementReferencesDEType(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainElementReferencesDEType(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainElementReferencesDEType(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainElementReferencesDEType(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainElement domain role code
		
		/// <summary>
		/// DomainElement domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainElementDomainRoleId = new System.Guid("d0a420aa-6435-463c-ada9-8b4647bf5945");
		
		/// <summary>
		/// DomainRole DomainElement
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "ElementType", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DomainElement.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("d0a420aa-6435-463c-ada9-8b4647bf5945")]
		public virtual DomainElement DomainElement
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DomainElement)DslModeling::DomainRoleInfo.GetRolePlayer(this, DomainElementDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DomainElementDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DomainElement of a DEType
		/// <summary>
		/// Gets a list of DomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DomainElement> GetDomainElement(DEType element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DomainElement>, DomainElement>(element, DETypeDomainRoleId);
		}
		#endregion
		#region DEType domain role code
		
		/// <summary>
		/// DEType domain role Id.
		/// </summary>
		public static readonly global::System.Guid DETypeDomainRoleId = new System.Guid("3ad62af6-db78-4932-90d4-aae94560e4ae");
		
		/// <summary>
		/// DomainRole DEType
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DEType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DEType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainElement", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainElementReferencesDEType/DEType.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("3ad62af6-db78-4932-90d4-aae94560e4ae")]
		public virtual DEType DEType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DEType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DETypeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DETypeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ElementType of a DomainElement
		/// <summary>
		/// Gets ElementType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DEType GetElementType(DomainElement element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainElementDomainRoleId) as DEType;
		}
		
		/// <summary>
		/// Sets ElementType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetElementType(DomainElement element, DEType newDEType)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainElementDomainRoleId, newDEType);
		}
		#endregion
		#region DomainElement link accessor
		/// <summary>
		/// Get the DomainElementReferencesDEType link to a DomainElement.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType GetLinkToElementType (global::Tum.PDE.ModelingDSL.DomainElement domainElementInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType>(domainElementInstance, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainElement not obeyed.");
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
		#region DEType link accessor
		/// <summary>
		/// Get the list of DomainElementReferencesDEType links to a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> GetLinksToDomainElement ( global::Tum.PDE.ModelingDSL.DEType dETypeInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType>(dETypeInstance, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId);
		}
		#endregion
		#region DomainElementReferencesDEType instance accessors
		
		/// <summary>
		/// Get any DomainElementReferencesDEType links between a given DomainElement and a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> GetLinks( global::Tum.PDE.ModelingDSL.DomainElement source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType>(source, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType link in links )
			{
				if ( target.Equals(link.DEType) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainElementReferencesDEType link between a given DomainElementand a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType GetLink( global::Tum.PDE.ModelingDSL.DomainElement source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType>(source, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType link in links )
			{
				if ( target.Equals(link.DEType) )
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
			return global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainElementReferencesDEType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Element References DEType";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DRTypeReferencesBaseElementSourceReferencesBaseElementTarget
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("175d062f-2781-49a4-8cb5-353577e5af6f")]
	public partial class DRTypeReferencesBaseElementSourceReferencesBaseElementTarget : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DRTypeReferencesBaseElementSourceReferencesBaseElementTarget domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("175d062f-2781-49a4-8cb5-353577e5af6f");

				
		/// <summary>
		/// Constructor
		/// Creates a DRTypeReferencesBaseElementSourceReferencesBaseElementTarget link in the same Partition as the given DRType
		/// </summary>
		/// <param name="source">DRType to use as the source of the relationship.</param>
		/// <param name="target">BaseElementSourceReferencesBaseElementTarget to use as the target of the relationship.</param>
		public DRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DRType source, BaseElementSourceReferencesBaseElementTarget target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId, source), new DslModeling::RoleAssignment(DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.BaseElementSourceReferencesBaseElementTargetDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypeReferencesBaseElementSourceReferencesBaseElementTarget(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DRType domain role code
		
		/// <summary>
		/// DRType domain role Id.
		/// </summary>
		public static readonly global::System.Guid DRTypeDomainRoleId = new System.Guid("f30924eb-221e-417f-8c61-eba4cf549f27");
		
		/// <summary>
		/// DomainRole DRType
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/DRType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/DRType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "ReferencedRelationships", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/DRType.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("f30924eb-221e-417f-8c61-eba4cf549f27")]
		public virtual DRType DRType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DRType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DRTypeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DRTypeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access RelationshipType of a BaseElementSourceReferencesBaseElementTarget
		/// <summary>
		/// Gets RelationshipType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DRType GetRelationshipType(BaseElementSourceReferencesBaseElementTarget element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, BaseElementSourceReferencesBaseElementTargetDomainRoleId) as DRType;
		}
		
		/// <summary>
		/// Sets RelationshipType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetRelationshipType(BaseElementSourceReferencesBaseElementTarget element, DRType newDRType)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, BaseElementSourceReferencesBaseElementTargetDomainRoleId, newDRType);
		}
		#endregion
		#region BaseElementSourceReferencesBaseElementTarget domain role code
		
		/// <summary>
		/// BaseElementSourceReferencesBaseElementTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid BaseElementSourceReferencesBaseElementTargetDomainRoleId = new System.Guid("2c20cc93-a9eb-4b74-b14a-bf2070c0c8ab");
		
		/// <summary>
		/// DomainRole BaseElementSourceReferencesBaseElementTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/BaseElementSourceReferencesBaseElementTarget.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/BaseElementSourceReferencesBaseElementTarget.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "RelationshipType", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget/BaseElementSourceReferencesBaseElementTarget.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("2c20cc93-a9eb-4b74-b14a-bf2070c0c8ab")]
		public virtual BaseElementSourceReferencesBaseElementTarget BaseElementSourceReferencesBaseElementTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (BaseElementSourceReferencesBaseElementTarget)DslModeling::DomainRoleInfo.GetRolePlayer(this, BaseElementSourceReferencesBaseElementTargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, BaseElementSourceReferencesBaseElementTargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ReferencedRelationships of a DRType
		/// <summary>
		/// Gets a list of ReferencedRelationships.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<BaseElementSourceReferencesBaseElementTarget> GetReferencedRelationships(DRType element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<BaseElementSourceReferencesBaseElementTarget>, BaseElementSourceReferencesBaseElementTarget>(element, DRTypeDomainRoleId);
		}
		#endregion
		#region DRType link accessor
		/// <summary>
		/// Get the list of DRTypeReferencesBaseElementSourceReferencesBaseElementTarget links to a DRType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> GetLinksToReferencedRelationships ( global::Tum.PDE.ModelingDSL.DRType dRTypeInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget>(dRTypeInstance, global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId);
		}
		#endregion
		#region BaseElementSourceReferencesBaseElementTarget link accessor
		/// <summary>
		/// Get the DRTypeReferencesBaseElementSourceReferencesBaseElementTarget link to a BaseElementSourceReferencesBaseElementTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget GetLinkToRelationshipType (global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget baseElementSourceReferencesBaseElementTargetInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget>(baseElementSourceReferencesBaseElementTargetInstance, global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.BaseElementSourceReferencesBaseElementTargetDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of BaseElementSourceReferencesBaseElementTarget not obeyed.");
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
		#region DRTypeReferencesBaseElementSourceReferencesBaseElementTarget instance accessors
		
		/// <summary>
		/// Get any DRTypeReferencesBaseElementSourceReferencesBaseElementTarget links between a given DRType and a BaseElementSourceReferencesBaseElementTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> GetLinks( global::Tum.PDE.ModelingDSL.DRType source, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget>(source, global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget link in links )
			{
				if ( target.Equals(link.BaseElementSourceReferencesBaseElementTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DRTypeReferencesBaseElementSourceReferencesBaseElementTarget link between a given DRTypeand a BaseElementSourceReferencesBaseElementTarget.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget GetLink( global::Tum.PDE.ModelingDSL.DRType source, global::Tum.PDE.ModelingDSL.BaseElementSourceReferencesBaseElementTarget target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget>(source, global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget link in links )
			{
				if ( target.Equals(link.BaseElementSourceReferencesBaseElementTarget) )
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
			return global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DRTypeReferencesBaseElementSourceReferencesBaseElementTarget";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DRType References Base Element Source References Base Element Target";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DRTypeReferencesDETypeSource
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("58c2639b-b960-4eee-a2f3-be1bc0919dfe")]
	public partial class DRTypeReferencesDETypeSource : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DRTypeReferencesDETypeSource domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("58c2639b-b960-4eee-a2f3-be1bc0919dfe");

				
		/// <summary>
		/// Constructor
		/// Creates a DRTypeReferencesDETypeSource link in the same Partition as the given DRType
		/// </summary>
		/// <param name="source">DRType to use as the source of the relationship.</param>
		/// <param name="target">DEType to use as the target of the relationship.</param>
		public DRTypeReferencesDETypeSource(DRType source, DEType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DRTypeReferencesDETypeSource.DRTypeSDomainRoleId, source), new DslModeling::RoleAssignment(DRTypeReferencesDETypeSource.DETypeSourceDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypeReferencesDETypeSource(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypeReferencesDETypeSource(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypeReferencesDETypeSource(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypeReferencesDETypeSource(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DRTypeS domain role code
		
		/// <summary>
		/// DRTypeS domain role Id.
		/// </summary>
		public static readonly global::System.Guid DRTypeSDomainRoleId = new System.Guid("d823f01b-07a3-47c5-bdf2-70e8258fd1fe");
		
		/// <summary>
		/// DomainRole DRTypeS
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DRTypeS.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DRTypeS.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Source", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DRTypeS.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("d823f01b-07a3-47c5-bdf2-70e8258fd1fe")]
		public virtual DRType DRTypeS
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DRType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DRTypeSDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DRTypeSDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DRTypeS of a DEType
		/// <summary>
		/// Gets a list of DRTypeS.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DRType> GetDRTypeS(DEType element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DRType>, DRType>(element, DETypeSourceDomainRoleId);
		}
		#endregion
		#region DETypeSource domain role code
		
		/// <summary>
		/// DETypeSource domain role Id.
		/// </summary>
		public static readonly global::System.Guid DETypeSourceDomainRoleId = new System.Guid("34b31421-f5a1-46b3-8a6f-79cac51d0e96");
		
		/// <summary>
		/// DomainRole DETypeSource
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DETypeSource.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DETypeSource.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DRTypeS", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource/DETypeSource.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("34b31421-f5a1-46b3-8a6f-79cac51d0e96")]
		public virtual DEType DETypeSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DEType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DETypeSourceDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DETypeSourceDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Source of a DRType
		/// <summary>
		/// Gets Source.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DEType GetSource(DRType element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DRTypeSDomainRoleId) as DEType;
		}
		
		/// <summary>
		/// Sets Source.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetSource(DRType element, DEType newDETypeSource)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DRTypeSDomainRoleId, newDETypeSource);
		}
		#endregion
		#region DRTypeS link accessor
		/// <summary>
		/// Get the DRTypeReferencesDETypeSource link to a DRType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource GetLinkToSource (global::Tum.PDE.ModelingDSL.DRType dRTypeSInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource>(dRTypeSInstance, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DRTypeS not obeyed.");
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
		#region DETypeSource link accessor
		/// <summary>
		/// Get the list of DRTypeReferencesDETypeSource links to a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> GetLinksToDRTypeS ( global::Tum.PDE.ModelingDSL.DEType dETypeSourceInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource>(dETypeSourceInstance, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DETypeSourceDomainRoleId);
		}
		#endregion
		#region DRTypeReferencesDETypeSource instance accessors
		
		/// <summary>
		/// Get any DRTypeReferencesDETypeSource links between a given DRType and a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> GetLinks( global::Tum.PDE.ModelingDSL.DRType source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource>(source, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource link in links )
			{
				if ( target.Equals(link.DETypeSource) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DRTypeReferencesDETypeSource link between a given DRTypeand a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource GetLink( global::Tum.PDE.ModelingDSL.DRType source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource>(source, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource link in links )
			{
				if ( target.Equals(link.DETypeSource) )
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
			return global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DRTypeReferencesDETypeSource";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DRType References DEType Source";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DRTypeReferencesDETypeTarget
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("48474822-dc12-4dc4-a722-e15618351381")]
	public partial class DRTypeReferencesDETypeTarget : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DRTypeReferencesDETypeTarget domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("48474822-dc12-4dc4-a722-e15618351381");

				
		/// <summary>
		/// Constructor
		/// Creates a DRTypeReferencesDETypeTarget link in the same Partition as the given DRType
		/// </summary>
		/// <param name="source">DRType to use as the source of the relationship.</param>
		/// <param name="target">DEType to use as the target of the relationship.</param>
		public DRTypeReferencesDETypeTarget(DRType source, DEType target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId, source), new DslModeling::RoleAssignment(DRTypeReferencesDETypeTarget.DETypeTargetDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypeReferencesDETypeTarget(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypeReferencesDETypeTarget(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DRTypeReferencesDETypeTarget(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DRTypeReferencesDETypeTarget(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DRTypeT domain role code
		
		/// <summary>
		/// DRTypeT domain role Id.
		/// </summary>
		public static readonly global::System.Guid DRTypeTDomainRoleId = new System.Guid("b8547e11-6592-46e0-9bb2-fb981409934a");
		
		/// <summary>
		/// DomainRole DRTypeT
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DRTypeT.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DRTypeT.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Target", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DRTypeT.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("b8547e11-6592-46e0-9bb2-fb981409934a")]
		public virtual DRType DRTypeT
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DRType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DRTypeTDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DRTypeTDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access DRTypeT of a DEType
		/// <summary>
		/// Gets a list of DRTypeT.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<DRType> GetDRTypeT(DEType element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<DRType>, DRType>(element, DETypeTargetDomainRoleId);
		}
		#endregion
		#region DETypeTarget domain role code
		
		/// <summary>
		/// DETypeTarget domain role Id.
		/// </summary>
		public static readonly global::System.Guid DETypeTargetDomainRoleId = new System.Guid("0a03cd1e-7930-4ddd-a465-25a5a24cf581");
		
		/// <summary>
		/// DomainRole DETypeTarget
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DETypeTarget.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DETypeTarget.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DRTypeT", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget/DETypeTarget.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("0a03cd1e-7930-4ddd-a465-25a5a24cf581")]
		public virtual DEType DETypeTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (DEType)DslModeling::DomainRoleInfo.GetRolePlayer(this, DETypeTargetDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, DETypeTargetDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Target of a DRType
		/// <summary>
		/// Gets Target.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DEType GetTarget(DRType element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DRTypeTDomainRoleId) as DEType;
		}
		
		/// <summary>
		/// Sets Target.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetTarget(DRType element, DEType newDETypeTarget)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DRTypeTDomainRoleId, newDETypeTarget);
		}
		#endregion
		#region DRTypeT link accessor
		/// <summary>
		/// Get the DRTypeReferencesDETypeTarget link to a DRType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget GetLinkToTarget (global::Tum.PDE.ModelingDSL.DRType dRTypeTInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget>(dRTypeTInstance, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DRTypeT not obeyed.");
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
		#region DETypeTarget link accessor
		/// <summary>
		/// Get the list of DRTypeReferencesDETypeTarget links to a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> GetLinksToDRTypeT ( global::Tum.PDE.ModelingDSL.DEType dETypeTargetInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget>(dETypeTargetInstance, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DETypeTargetDomainRoleId);
		}
		#endregion
		#region DRTypeReferencesDETypeTarget instance accessors
		
		/// <summary>
		/// Get any DRTypeReferencesDETypeTarget links between a given DRType and a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> GetLinks( global::Tum.PDE.ModelingDSL.DRType source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget>(source, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget link in links )
			{
				if ( target.Equals(link.DETypeTarget) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DRTypeReferencesDETypeTarget link between a given DRTypeand a DEType.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget GetLink( global::Tum.PDE.ModelingDSL.DRType source, global::Tum.PDE.ModelingDSL.DEType target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget>(source, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget link in links )
			{
				if ( target.Equals(link.DETypeTarget) )
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
			return global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DRTypeReferencesDETypeTarget";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DRType References DEType Target";
	        }
	    }	
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainRelationship DomainModelHasConversionModelInfo
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("967becd5-4e7f-4445-8de3-1f0a37a7997a")]
	public partial class DomainModelHasConversionModelInfo : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasConversionModelInfo domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("967becd5-4e7f-4445-8de3-1f0a37a7997a");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasConversionModelInfo link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">ConversionModelInfo to use as the target of the relationship.</param>
		public DomainModelHasConversionModelInfo(DomainModel source, ConversionModelInfo target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasConversionModelInfo.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId, target)}, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasConversionModelInfo(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasConversionModelInfo(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasConversionModelInfo(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasConversionModelInfo(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("df1baff3-ad54-48a4-96e4-82a542965d2d");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo/DomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo/DomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "ConversionModelInfo", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("df1baff3-ad54-48a4-96e4-82a542965d2d")]
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
		#region Static methods to access DomainModel of a ConversionModelInfo
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(ConversionModelInfo element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, ConversionModelInfoDomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(ConversionModelInfo element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, ConversionModelInfoDomainRoleId, newDomainModel);
		}
		#endregion
		#region ConversionModelInfo domain role code
		
		/// <summary>
		/// ConversionModelInfo domain role Id.
		/// </summary>
		public static readonly global::System.Guid ConversionModelInfoDomainRoleId = new System.Guid("390a07a8-2052-412f-ad38-2c845fbf21f2");
		
		/// <summary>
		/// DomainRole ConversionModelInfo
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo/ConversionModelInfo.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo/ConversionModelInfo.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo/ConversionModelInfo.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("390a07a8-2052-412f-ad38-2c845fbf21f2")]
		public virtual ConversionModelInfo ConversionModelInfo
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (ConversionModelInfo)DslModeling::DomainRoleInfo.GetRolePlayer(this, ConversionModelInfoDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, ConversionModelInfoDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access ConversionModelInfo of a DomainModel
		/// <summary>
		/// Gets ConversionModelInfo.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static ConversionModelInfo GetConversionModelInfo(DomainModel element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, DomainModelDomainRoleId) as ConversionModelInfo;
		}
		
		/// <summary>
		/// Sets ConversionModelInfo.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetConversionModelInfo(DomainModel element, ConversionModelInfo newConversionModelInfo)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, DomainModelDomainRoleId, newConversionModelInfo);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the DomainModelHasConversionModelInfo link to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo GetLinkToConversionModelInfo (global::Tum.PDE.ModelingDSL.DomainModel domainModelInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo>(domainModelInstance, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of DomainModel not obeyed.");
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
		#region ConversionModelInfo link accessor
		/// <summary>
		/// Get the DomainModelHasConversionModelInfo link to a ConversionModelInfo.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo GetLinkToDomainModel (global::Tum.PDE.ModelingDSL.ConversionModelInfo conversionModelInfoInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo>(conversionModelInfoInstance, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of ConversionModelInfo not obeyed.");
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
		#region DomainModelHasConversionModelInfo instance accessors
		
		/// <summary>
		/// Get any DomainModelHasConversionModelInfo links between a given DomainModel and a ConversionModelInfo.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> GetLinks( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.ConversionModelInfo target )
		{
			global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> outLinks = new global::System.Collections.Generic.List<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo>();
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo>(source, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo link in links )
			{
				if ( target.Equals(link.ConversionModelInfo) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasConversionModelInfo link between a given DomainModeland a ConversionModelInfo.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo GetLink( global::Tum.PDE.ModelingDSL.DomainModel source, global::Tum.PDE.ModelingDSL.ConversionModelInfo target )
		{
			global::System.Collections.Generic.IList<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo>(source, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId);
			foreach ( global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo link in links )
			{
				if ( target.Equals(link.ConversionModelInfo) )
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
			return global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainClassId;		
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
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel.DomainModelId;
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
	            return "DomainModelHasConversionModelInfo";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has Conversion Model Info";
	        }
	    }	
		#endregion
	}
}


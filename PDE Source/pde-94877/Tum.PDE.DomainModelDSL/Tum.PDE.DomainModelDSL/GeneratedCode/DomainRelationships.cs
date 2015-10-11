 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.TestLanguage
{
	/// <summary>
	/// DomainRelationship DomainModelHasTest
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.TestLanguage.DomainModelHasTest.DisplayName", typeof(global::Tum.TestLanguage.TestLanguageDomainModel), "Tum.PDE.DomainModelDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.TestLanguage.DomainModelHasTest.Description", typeof(global::Tum.TestLanguage.TestLanguageDomainModel), "Tum.PDE.DomainModelDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("68dd8616-7b05-4ec0-8ca0-4d555d093045")]
	public partial class DomainModelHasTest : DslEditorModeling::DomainModelLink
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModelHasTest domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("68dd8616-7b05-4ec0-8ca0-4d555d093045");

				
		/// <summary>
		/// Constructor
		/// Creates a DomainModelHasTest link in the same Partition as the given DomainModel
		/// </summary>
		/// <param name="source">DomainModel to use as the source of the relationship.</param>
		/// <param name="target">Test to use as the target of the relationship.</param>
		public DomainModelHasTest(DomainModel source, Test target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(DomainModelHasTest.DomainModelDomainRoleId, source), new DslModeling::RoleAssignment(DomainModelHasTest.TestDomainRoleId, target)}, Tum.TestLanguage.TestLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasTest(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.TestLanguage.TestLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasTest(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, roleAssignments, Tum.TestLanguage.TestLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public DomainModelHasTest(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, Tum.TestLanguage.TestLanguageDomainModelIdProvider.Instance.CreateId())
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public DomainModelHasTest(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, Tum.TestLanguage.TestLanguageDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel domain role code
		
		/// <summary>
		/// DomainModel domain role Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelDomainRoleId = new System.Guid("bafcbe91-cb2c-4f72-bdc1-fc170eff423d");
		
		/// <summary>
		/// DomainRole DomainModel
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.TestLanguage.DomainModelHasTest/DomainModel.DisplayName", typeof(global::Tum.TestLanguage.TestLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.TestLanguage.DomainModelHasTest/DomainModel.Description", typeof(global::Tum.TestLanguage.TestLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "Test", PropertyDisplayNameKey="Tum.TestLanguage.DomainModelHasTest/DomainModel.PropertyDisplayName",  PropagatesCopy = DslModeling::PropagatesCopyOption.DoNotPropagateCopy, Multiplicity = DslModeling::Multiplicity.ZeroMany)]
		[DslModeling::DomainObjectId("bafcbe91-cb2c-4f72-bdc1-fc170eff423d")]
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
		#region Static methods to access DomainModel of a Test
		/// <summary>
		/// Gets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DomainModel GetDomainModel(Test element)
		{
			return DslModeling::DomainRoleInfo.GetLinkedElement(element, TestDomainRoleId) as DomainModel;
		}
		
		/// <summary>
		/// Sets DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static void SetDomainModel(Test element, DomainModel newDomainModel)
		{
			DslModeling::DomainRoleInfo.SetLinkedElement(element, TestDomainRoleId, newDomainModel);
		}
		#endregion
		#region Test domain role code
		
		/// <summary>
		/// Test domain role Id.
		/// </summary>
		public static readonly global::System.Guid TestDomainRoleId = new System.Guid("346ab093-b241-49fb-8918-195f5ab3c4ec");
		
		/// <summary>
		/// DomainRole Test
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.TestLanguage.DomainModelHasTest/Test.DisplayName", typeof(global::Tum.TestLanguage.TestLanguageDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.TestLanguage.DomainModelHasTest/Test.Description", typeof(global::Tum.TestLanguage.TestLanguageDomainModel), "")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "DomainModel", PropertyDisplayNameKey="Tum.TestLanguage.DomainModelHasTest/Test.PropertyDisplayName", PropagatesDelete = true,  PropagatesCopy = DslModeling::PropagatesCopyOption.PropagatesCopyToLinkAndOppositeRolePlayer, Multiplicity = DslModeling::Multiplicity.One)]
		[DslModeling::DomainObjectId("346ab093-b241-49fb-8918-195f5ab3c4ec")]
		public virtual Test Test
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (Test)DslModeling::DomainRoleInfo.GetRolePlayer(this, TestDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, TestDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access Test of a DomainModel
		/// <summary>
		/// Gets a list of Test.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<Test> GetTest(DomainModel element)
		{
			return GetRoleCollection<DslModeling::LinkedElementCollection<Test>, Test>(element, DomainModelDomainRoleId);
		}
		#endregion
		#region DomainModel link accessor
		/// <summary>
		/// Get the list of DomainModelHasTest links to a DomainModel.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.TestLanguage.DomainModelHasTest> GetLinksToTest ( global::Tum.TestLanguage.DomainModel domainModelInstance )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.TestLanguage.DomainModelHasTest>(domainModelInstance, global::Tum.TestLanguage.DomainModelHasTest.DomainModelDomainRoleId);
		}
		#endregion
		#region Test link accessor
		/// <summary>
		/// Get the DomainModelHasTest link to a Test.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.TestLanguage.DomainModelHasTest GetLinkToDomainModel (global::Tum.TestLanguage.Test testInstance)
		{
			global::System.Collections.Generic.IList<global::Tum.TestLanguage.DomainModelHasTest> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.TestLanguage.DomainModelHasTest>(testInstance, global::Tum.TestLanguage.DomainModelHasTest.TestDomainRoleId);
			global::System.Diagnostics.Debug.Assert(links.Count <= 1, "Multiplicity of Test not obeyed.");
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
		#region DomainModelHasTest instance accessors
		
		/// <summary>
		/// Get any DomainModelHasTest links between a given DomainModel and a Test.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.TestLanguage.DomainModelHasTest> GetLinks( global::Tum.TestLanguage.DomainModel source, global::Tum.TestLanguage.Test target )
		{
			global::System.Collections.Generic.List<global::Tum.TestLanguage.DomainModelHasTest> outLinks = new global::System.Collections.Generic.List<global::Tum.TestLanguage.DomainModelHasTest>();
			global::System.Collections.Generic.IList<global::Tum.TestLanguage.DomainModelHasTest> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.TestLanguage.DomainModelHasTest>(source, global::Tum.TestLanguage.DomainModelHasTest.DomainModelDomainRoleId);
			foreach ( global::Tum.TestLanguage.DomainModelHasTest link in links )
			{
				if ( target.Equals(link.Test) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one DomainModelHasTest link between a given DomainModeland a Test.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Tum.TestLanguage.DomainModelHasTest GetLink( global::Tum.TestLanguage.DomainModel source, global::Tum.TestLanguage.Test target )
		{
			global::System.Collections.Generic.IList<global::Tum.TestLanguage.DomainModelHasTest> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.TestLanguage.DomainModelHasTest>(source, global::Tum.TestLanguage.DomainModelHasTest.DomainModelDomainRoleId);
			foreach ( global::Tum.TestLanguage.DomainModelHasTest link in links )
			{
				if ( target.Equals(link.Test) )
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
			return global::Tum.TestLanguage.DomainModelHasTest.DomainClassId;		
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
				return global::Tum.TestLanguage.TestLanguageDocumentData.Instance;
			}
	    }
		*/
		
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.TestLanguage.TestLanguageDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns></returns>
	    public override DslEditorModeling::IDomainModelServices GetDomainModelServices()
		{
			return global::Tum.TestLanguage.TestLanguageDomainModelServices.Instance;
		}
		
	    /// <summary>
	    /// Gets the domain model DomainClassId.
	    /// </summary>
	    /// <returns></returns>
	    public override System.Guid GetDomainModelTypeId()
		{
			return global::Tum.TestLanguage.TestLanguageDomainModel.DomainModelId;
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
	            return "DomainModelHasTest";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Model Has Test";
	        }
	    }	
		#endregion
	}
}


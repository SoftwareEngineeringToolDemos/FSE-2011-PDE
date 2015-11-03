 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainModel.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainModel.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("a765e3bd-666d-49f2-8e77-d1796069ebf6")]
	public partial class DomainModel : DslEditorModeling::DomainModelElement, DslEditorModeling::IParentModelElement   
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainModel domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a765e3bd-666d-49f2-8e77-d1796069ebf6");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainModel(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainModel(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainElements opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainElements.
		/// </summary>
		public virtual DomainElements DomainElements
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId) as DomainElements;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainModelDomainRoleId, value);
			}
		}
		#endregion
		#region DomainTypes opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainTypes.
		/// </summary>
		public virtual DomainTypes DomainTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId) as DomainTypes;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainModelDomainRoleId, value);
			}
		}
		#endregion
		#region DETypes opposite domain role accessor
		/// <summary>
		/// Gets or sets DETypes.
		/// </summary>
		public virtual DETypes DETypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId) as DETypes;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DomainModelDomainRoleId, value);
			}
		}
		#endregion
		#region DRTypes opposite domain role accessor
		/// <summary>
		/// Gets or sets DRTypes.
		/// </summary>
		public virtual DRTypes DRTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId) as DRTypes;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DomainModelDomainRoleId, value);
			}
		}
		#endregion
		#region ConversionModelInfo opposite domain role accessor
		/// <summary>
		/// Gets or sets ConversionModelInfo.
		/// </summary>
		public virtual ConversionModelInfo ConversionModelInfo
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId) as ConversionModelInfo;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.DomainModelDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DomainModel";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DomainModel";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainModel.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Double-derived base class for DomainClass DomainElement
	/// </summary>
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "Generated code.")]
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("65b28560-fb4e-45f6-a6e1-9e2292c354cf")]
	public abstract partial class DomainElementBase : global::Tum.PDE.ModelingDSL.BaseDomainElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("65b28560-fb4e-45f6-a6e1-9e2292c354cf");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected DomainElementBase(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region DomainElements opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainElements.
		/// </summary>
		public virtual DomainElements DomainElements
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementDomainRoleId) as DomainElements;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementDomainRoleId, value);
			}
		}
		#endregion
		#region ElementType opposite domain role accessor
		/// <summary>
		/// Gets or sets ElementType.
		/// </summary>
		public virtual DEType ElementType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId) as DEType;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DomainElementDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DomainElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainElement.DomainClassId;
	    }
	}
	/// <summary>
	/// DomainClass DomainElement
	/// </summary>
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "Generated code.")]
			
	public partial class DomainElement : DomainElementBase
	{
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainElement(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainElement(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass BaseElement
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("6c92eef8-ec51-4347-85c7-32139c1c81f3")]
	public abstract partial class BaseElement : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// BaseElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("6c92eef8-ec51-4347-85c7-32139c1c81f3");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected BaseElement(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "BaseElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Base Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.BaseElement.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass ReferenceableElement
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferenceableElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferenceableElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("7639e48b-f454-4b37-a57b-78a4b3c70cdd")]
	public abstract partial class ReferenceableElement : global::Tum.PDE.ModelingDSL.AttributedDomainElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ReferenceableElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("7639e48b-f454-4b37-a57b-78a4b3c70cdd");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected ReferenceableElement(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Targets opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Targets.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ReferenceableElement> Targets
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ReferenceableElement>, ReferenceableElement>(global::Tum.PDE.ModelingDSL.ReferenceRelationship.SourceDomainRoleId);
			}
		}
		#endregion
		#region Sources opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Sources.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ReferenceableElement> Sources
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ReferenceableElement>, ReferenceableElement>(global::Tum.PDE.ModelingDSL.ReferenceRelationship.TargetDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "ReferenceableElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Referenceable Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.ReferenceableElement.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass EmbeddableElement
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EmbeddableElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EmbeddableElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("210a0c25-c026-452c-ada5-f1f2a9f7ad96")]
	public abstract partial class EmbeddableElement : global::Tum.PDE.ModelingDSL.ReferenceableElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// EmbeddableElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("210a0c25-c026-452c-ada5-f1f2a9f7ad96");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected EmbeddableElement(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Parent opposite domain role accessor
		/// <summary>
		/// Gets or sets Parent.
		/// </summary>
		public virtual EmbeddableElement Parent
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId) as EmbeddableElement;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ChildDomainRoleId, value);
			}
		}
		#endregion
		#region Children opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Children.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<EmbeddableElement> Children
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<EmbeddableElement>, EmbeddableElement>(global::Tum.PDE.ModelingDSL.EmbeddingRelationship.ParentDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "EmbeddableElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Embeddable Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.EmbeddableElement.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass NamedDomainElement
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.NamedDomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.NamedDomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("aa65aca9-d0a6-4818-b586-f55cf527ce53")]
	public abstract partial class NamedDomainElement : global::Tum.PDE.ModelingDSL.BaseElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// NamedDomainElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("aa65aca9-d0a6-4818-b586-f55cf527ce53");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected NamedDomainElement(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("914d2336-fe09-4ea8-89dc-dd4f7b0069e8") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.NamedDomainElement/Name.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.NamedDomainElement/Name.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("914d2336-fe09-4ea8-89dc-dd4f7b0069e8")]
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
		/// Value handler for the NamedDomainElement.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<NamedDomainElement, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the NamedDomainElement.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the NamedDomainElement.Name domain property.
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
			public override sealed global::System.String GetValue(NamedDomainElement element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(NamedDomainElement element, global::System.String newValue)
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
		#region Description domain property code
		
		/// <summary>
		/// Description domain property Id.
		/// </summary>
		public static readonly global::System.Guid DescriptionDomainPropertyId = new System.Guid("60ec99ff-8f07-4cb0-9612-044f066c2537") ;
		
		/// <summary>
		/// Storage for Description
		/// </summary>
		private global::System.String descriptionPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Description domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.NamedDomainElement/Description.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.NamedDomainElement/Description.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("60ec99ff-8f07-4cb0-9612-044f066c2537")]
		public global::System.String Description
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return descriptionPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DescriptionPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the NamedDomainElement.Description domain property.
		/// </summary>
		internal sealed partial class DescriptionPropertyHandler : DslModeling::DomainPropertyValueHandler<NamedDomainElement, global::System.String>
		{
			private DescriptionPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the NamedDomainElement.Description domain property value handler.
			/// </summary>
			public static readonly DescriptionPropertyHandler Instance = new DescriptionPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the NamedDomainElement.Description domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return DescriptionDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(NamedDomainElement element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.descriptionPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(NamedDomainElement element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.descriptionPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.NamedDomainElement.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "NamedDomainElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Named Domain Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.NamedDomainElement.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass AttributedDomainElement
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.AttributedDomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.AttributedDomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("0ca04a8b-a845-4dc6-84b2-8572ce8bf527")]
	public abstract partial class AttributedDomainElement : global::Tum.PDE.ModelingDSL.NamedDomainElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// AttributedDomainElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("0ca04a8b-a845-4dc6-84b2-8572ce8bf527");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected AttributedDomainElement(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region DomainProperty opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainProperty.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DomainProperty> DomainProperty
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DomainProperty>, DomainProperty>(global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.AttributedDomainElementDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "AttributedDomainElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Attributed Domain Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.AttributedDomainElement.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass BaseDomainElement
	/// </summary>
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "Generated code.")]
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseDomainElement.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseDomainElement.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("a49b13df-e00e-4ff9-b2ee-666c10f5dfe4")]
	public abstract partial class BaseDomainElement : global::Tum.PDE.ModelingDSL.EmbeddableElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// BaseDomainElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a49b13df-e00e-4ff9-b2ee-666c10f5dfe4");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected BaseDomainElement(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "BaseDomainElement";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Base Domain Element";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.BaseDomainElement.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// Double-derived base class for DomainClass DomainProperty
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainProperty.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainProperty.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("762bf0e8-9885-4cb2-b653-242a61d8a6a5")]
	public abstract partial class DomainPropertyBase : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainProperty domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("762bf0e8-9885-4cb2-b653-242a61d8a6a5");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected DomainPropertyBase(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("ab79cf38-18e7-44b2-927d-5301f38d997a") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainProperty/Name.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainProperty/Name.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("ab79cf38-18e7-44b2-927d-5301f38d997a")]
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
		/// Value handler for the DomainProperty.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<DomainPropertyBase, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DomainProperty.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DomainProperty.Name domain property.
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
			public override sealed global::System.String GetValue(DomainPropertyBase element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DomainPropertyBase element, global::System.String newValue)
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
		#region Value domain property code
		
		/// <summary>
		/// Value domain property Id.
		/// </summary>
		public static readonly global::System.Guid ValueDomainPropertyId = new System.Guid("9ce2c489-6c1c-4efc-9cf7-47bf282324fe") ;
		
		/// <summary>
		/// Storage for Value
		/// </summary>
		private global::System.String valuePropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Value domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainProperty/Value.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainProperty/Value.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("9ce2c489-6c1c-4efc-9cf7-47bf282324fe")]
		public global::System.String Value
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return valuePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				ValuePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the DomainProperty.Value domain property.
		/// </summary>
		internal sealed partial class ValuePropertyHandler : DslModeling::DomainPropertyValueHandler<DomainPropertyBase, global::System.String>
		{
			private ValuePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DomainProperty.Value domain property value handler.
			/// </summary>
			public static readonly ValuePropertyHandler Instance = new ValuePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DomainProperty.Value domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return ValueDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(DomainPropertyBase element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.valuePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DomainPropertyBase element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.valuePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region AttributedDomainElement opposite domain role accessor
		/// <summary>
		/// Gets or sets AttributedDomainElement.
		/// </summary>
		public virtual AttributedDomainElement AttributedDomainElement
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId) as AttributedDomainElement;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.AttributedDomainElementHasDomainProperty.DomainPropertyDomainRoleId, value);
			}
		}
		#endregion
		#region DomainType opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainType.
		/// </summary>
		public virtual DomainType DomainType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId) as DomainType;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainPropertyReferencesDomainType.DomainPropertyDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainProperty.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "DomainProperty";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Property";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainProperty.DomainClassId;
	    }
	}
	/// <summary>
	/// DomainClass DomainProperty
	/// </summary>
			
	public partial class DomainProperty : DomainPropertyBase
	{
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainProperty(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainProperty(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DomainElements
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainElements.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainElements.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("aa127ae5-4483-4605-804a-881e360679b6")]
	public partial class DomainElements : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainElements domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("aa127ae5-4483-4605-804a-881e360679b6");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainElements(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainElements(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainModel.
		/// </summary>
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainElementsDomainRoleId) as DomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainElements.DomainElementsDomainRoleId, value);
			}
		}
		#endregion
		#region DomainElement opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainElement.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DomainElement> DomainElement
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DomainElement>, DomainElement>(global::Tum.PDE.ModelingDSL.DomainElementsHasDomainElement.DomainElementsDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DomainElements";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Elements";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainElements.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DomainTypes
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("ae3fc71d-2bd5-40d9-a485-11fa0eb11cc4")]
	public partial class DomainTypes : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainTypes domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("ae3fc71d-2bd5-40d9-a485-11fa0eb11cc4");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainTypes(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainTypes(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainModel.
		/// </summary>
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainTypesDomainRoleId) as DomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDomainTypes.DomainTypesDomainRoleId, value);
			}
		}
		#endregion
		#region DomainType opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainType.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DomainType> DomainType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DomainType>, DomainType>(global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypesDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DomainTypes";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Types";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainTypes.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DomainType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("57e30f0a-d8d6-4932-bc0c-23a8d0f26446")]
	public abstract partial class DomainType : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("57e30f0a-d8d6-4932-bc0c-23a8d0f26446");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected DomainType(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("234bfa17-d6e6-45b5-b681-d9315f277c21") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainType/Name.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainType/Name.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("234bfa17-d6e6-45b5-b681-d9315f277c21")]
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
		/// Value handler for the DomainType.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<DomainType, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DomainType.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DomainType.Name domain property.
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
			public override sealed global::System.String GetValue(DomainType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DomainType element, global::System.String newValue)
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
		#region DomainTypes opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainTypes.
		/// </summary>
		public virtual DomainTypes DomainTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypeDomainRoleId) as DomainTypes;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainTypesHasDomainType.DomainTypeDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.DomainType.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "DomainType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Type";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass ExternalType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ExternalType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ExternalType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("3cf1256d-6fad-4608-b7bd-eae68b160f81")]
	public partial class ExternalType : global::Tum.PDE.ModelingDSL.DomainType 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ExternalType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("3cf1256d-6fad-4608-b7bd-eae68b160f81");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExternalType(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExternalType(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Namespace domain property code
		
		/// <summary>
		/// Namespace domain property Id.
		/// </summary>
		public static readonly global::System.Guid NamespaceDomainPropertyId = new System.Guid("b185f02f-1e14-49a3-8b71-4fdd98646523") ;
		
		/// <summary>
		/// Storage for Namespace
		/// </summary>
		private global::System.String namespacePropertyStorage = "System";
		
		/// <summary>
		/// Gets or sets the value of Namespace domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ExternalType/Namespace.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ExternalType/Namespace.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("System")]
		[DslModeling::DomainObjectId("b185f02f-1e14-49a3-8b71-4fdd98646523")]
		public global::System.String Namespace
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namespacePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamespacePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the ExternalType.Namespace domain property.
		/// </summary>
		internal sealed partial class NamespacePropertyHandler : DslModeling::DomainPropertyValueHandler<ExternalType, global::System.String>
		{
			private NamespacePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the ExternalType.Namespace domain property value handler.
			/// </summary>
			public static readonly NamespacePropertyHandler Instance = new NamespacePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the ExternalType.Namespace domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NamespaceDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(ExternalType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namespacePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(ExternalType element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namespacePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "ExternalType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "External Type";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.ExternalType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DomainEnumeration
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainEnumeration.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainEnumeration.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("b4b982f5-721b-4294-b8d9-d565ee9262c1")]
	public partial class DomainEnumeration : global::Tum.PDE.ModelingDSL.DomainType 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainEnumeration domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("b4b982f5-721b-4294-b8d9-d565ee9262c1");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainEnumeration(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainEnumeration(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region IsFlags domain property code
		
		/// <summary>
		/// IsFlags domain property Id.
		/// </summary>
		public static readonly global::System.Guid IsFlagsDomainPropertyId = new System.Guid("c43bdb40-3cce-472e-9cea-5adf4efa1bc2") ;
		
		/// <summary>
		/// Storage for IsFlags
		/// </summary>
		private global::System.Boolean? isFlagsPropertyStorage = DslModeling::SerializationUtilities.GetValue<global::System.Boolean?>("false");
		
		/// <summary>
		/// Gets or sets the value of IsFlags domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DomainEnumeration/IsFlags.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DomainEnumeration/IsFlags.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(typeof(global::System.Boolean?), "False")]
		[DslModeling::DomainObjectId("c43bdb40-3cce-472e-9cea-5adf4efa1bc2")]
		public global::System.Boolean? IsFlags
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return isFlagsPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				IsFlagsPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the DomainEnumeration.IsFlags domain property.
		/// </summary>
		internal sealed partial class IsFlagsPropertyHandler : DslModeling::DomainPropertyValueHandler<DomainEnumeration, global::System.Boolean?>
		{
			private IsFlagsPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DomainEnumeration.IsFlags domain property value handler.
			/// </summary>
			public static readonly IsFlagsPropertyHandler Instance = new IsFlagsPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DomainEnumeration.IsFlags domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return IsFlagsDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.Boolean? GetValue(DomainEnumeration element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.isFlagsPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DomainEnumeration element, global::System.Boolean? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.Boolean? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.isFlagsPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region EnumerationLiteral opposite domain role accessor
		
		/// <summary>
		/// Gets a list of EnumerationLiteral.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<EnumerationLiteral> EnumerationLiteral
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<EnumerationLiteral>, EnumerationLiteral>(global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.DomainEnumerationDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DomainEnumeration";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Enumeration";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DomainEnumeration.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass EnumerationLiteral
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EnumerationLiteral.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EnumerationLiteral.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("7efc275b-6bf2-45b0-b7a5-ef9479989ae3")]
	public partial class EnumerationLiteral : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// EnumerationLiteral domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("7efc275b-6bf2-45b0-b7a5-ef9479989ae3");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EnumerationLiteral(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EnumerationLiteral(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("8f0e653b-791b-45d5-96dd-35d3225fc0ae") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EnumerationLiteral/Name.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EnumerationLiteral/Name.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("8f0e653b-791b-45d5-96dd-35d3225fc0ae")]
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
		/// Value handler for the EnumerationLiteral.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<EnumerationLiteral, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the EnumerationLiteral.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the EnumerationLiteral.Name domain property.
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
			public override sealed global::System.String GetValue(EnumerationLiteral element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(EnumerationLiteral element, global::System.String newValue)
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
		#region Value domain property code
		
		/// <summary>
		/// Value domain property Id.
		/// </summary>
		public static readonly global::System.Guid ValueDomainPropertyId = new System.Guid("6bc4345f-6d87-4662-9f69-98e47a2cddf0") ;
		
		/// <summary>
		/// Storage for Value
		/// </summary>
		private global::System.String valuePropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Value domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EnumerationLiteral/Value.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EnumerationLiteral/Value.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("6bc4345f-6d87-4662-9f69-98e47a2cddf0")]
		public global::System.String Value
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return valuePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				ValuePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the EnumerationLiteral.Value domain property.
		/// </summary>
		internal sealed partial class ValuePropertyHandler : DslModeling::DomainPropertyValueHandler<EnumerationLiteral, global::System.String>
		{
			private ValuePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the EnumerationLiteral.Value domain property value handler.
			/// </summary>
			public static readonly ValuePropertyHandler Instance = new ValuePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the EnumerationLiteral.Value domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return ValueDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(EnumerationLiteral element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.valuePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(EnumerationLiteral element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.valuePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region DomainEnumeration opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainEnumeration.
		/// </summary>
		public virtual DomainEnumeration DomainEnumeration
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId) as DomainEnumeration;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainEnumerationHasEnumerationLiteral.EnumerationLiteralDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.EnumerationLiteral.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "EnumerationLiteral";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Enumeration Literal";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.EnumerationLiteral.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DETypes
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DETypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DETypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("311505ca-472e-461e-ada7-061c08defbdb")]
	public partial class DETypes : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DETypes domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("311505ca-472e-461e-ada7-061c08defbdb");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DETypes(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DETypes(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainModel.
		/// </summary>
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DETypesDomainRoleId) as DomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDETypes.DETypesDomainRoleId, value);
			}
		}
		#endregion
		#region DomainElementTypes opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainElementTypes.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DEType> DomainElementTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DEType>, DEType>(global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypesDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DETypes";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Element Types";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DETypes.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DRTypes
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRTypes.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRTypes.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("de5abf3e-1fa1-4f8d-adca-6fea31174168")]
	public partial class DRTypes : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DRTypes domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("de5abf3e-1fa1-4f8d-adca-6fea31174168");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DRTypes(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DRTypes(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainModel.
		/// </summary>
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DRTypesDomainRoleId) as DomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasDRTypes.DRTypesDomainRoleId, value);
			}
		}
		#endregion
		#region DomainRelationshipTypes opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainRelationshipTypes.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DRType> DomainRelationshipTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DRType>, DRType>(global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypesDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DRTypes";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Relationship Types";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DRTypes.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DEType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DEType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DEType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("65c9ea78-4492-4e8f-a7cd-6fa10600682e")]
	public partial class DEType : global::Tum.PDE.ModelingDSL.BaseDomainElementType 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DEType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("65c9ea78-4492-4e8f-a7cd-6fa10600682e");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DEType(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DEType(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region StyleType domain property code
		
		/// <summary>
		/// StyleType domain property Id.
		/// </summary>
		public static readonly global::System.Guid StyleTypeDomainPropertyId = new System.Guid("485d6816-8cac-4485-8920-1d04d2fb1942") ;
		
		/// <summary>
		/// Storage for StyleType
		/// </summary>
		private global::Tum.PDE.ModelingDSL.ShapeStyleType? styleTypePropertyStorage = global::Tum.PDE.ModelingDSL.ShapeStyleType.Default;
		
		/// <summary>
		/// Gets or sets the value of StyleType domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DEType/StyleType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DEType/StyleType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(global::Tum.PDE.ModelingDSL.ShapeStyleType.Default)]
		[DslModeling::DomainObjectId("485d6816-8cac-4485-8920-1d04d2fb1942")]
		public global::Tum.PDE.ModelingDSL.ShapeStyleType? StyleType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return styleTypePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				StyleTypePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the DEType.StyleType domain property.
		/// </summary>
		internal sealed partial class StyleTypePropertyHandler : DslModeling::DomainPropertyValueHandler<DEType, global::Tum.PDE.ModelingDSL.ShapeStyleType?>
		{
			private StyleTypePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DEType.StyleType domain property value handler.
			/// </summary>
			public static readonly StyleTypePropertyHandler Instance = new StyleTypePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DEType.StyleType domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return StyleTypeDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ModelingDSL.ShapeStyleType? GetValue(DEType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.styleTypePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DEType element, global::Tum.PDE.ModelingDSL.ShapeStyleType? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ModelingDSL.ShapeStyleType? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.styleTypePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region ColorType domain property code
		
		/// <summary>
		/// ColorType domain property Id.
		/// </summary>
		public static readonly global::System.Guid ColorTypeDomainPropertyId = new System.Guid("778f2420-287f-4582-bfe0-1ff4f13ef0bc") ;
		
		/// <summary>
		/// Storage for ColorType
		/// </summary>
		private global::Tum.PDE.ModelingDSL.ShapeColorType? colorTypePropertyStorage = global::Tum.PDE.ModelingDSL.ShapeColorType.Color1;
		
		/// <summary>
		/// Gets or sets the value of ColorType domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DEType/ColorType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DEType/ColorType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(global::Tum.PDE.ModelingDSL.ShapeColorType.Color1)]
		[DslModeling::DomainObjectId("778f2420-287f-4582-bfe0-1ff4f13ef0bc")]
		public global::Tum.PDE.ModelingDSL.ShapeColorType? ColorType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return colorTypePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				ColorTypePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the DEType.ColorType domain property.
		/// </summary>
		internal sealed partial class ColorTypePropertyHandler : DslModeling::DomainPropertyValueHandler<DEType, global::Tum.PDE.ModelingDSL.ShapeColorType?>
		{
			private ColorTypePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DEType.ColorType domain property value handler.
			/// </summary>
			public static readonly ColorTypePropertyHandler Instance = new ColorTypePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DEType.ColorType domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return ColorTypeDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ModelingDSL.ShapeColorType? GetValue(DEType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.colorTypePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DEType element, global::Tum.PDE.ModelingDSL.ShapeColorType? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ModelingDSL.ShapeColorType? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.colorTypePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region FormType domain property code
		
		/// <summary>
		/// FormType domain property Id.
		/// </summary>
		public static readonly global::System.Guid FormTypeDomainPropertyId = new System.Guid("cb4abbec-9a43-4222-b5c4-304d7208c564") ;
		
		/// <summary>
		/// Storage for FormType
		/// </summary>
		private global::Tum.PDE.ModelingDSL.ShapeFormType? formTypePropertyStorage = global::Tum.PDE.ModelingDSL.ShapeFormType.Rectangle;
		
		/// <summary>
		/// Gets or sets the value of FormType domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DEType/FormType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DEType/FormType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(global::Tum.PDE.ModelingDSL.ShapeFormType.Rectangle)]
		[DslModeling::DomainObjectId("cb4abbec-9a43-4222-b5c4-304d7208c564")]
		public global::Tum.PDE.ModelingDSL.ShapeFormType? FormType
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return formTypePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				FormTypePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the DEType.FormType domain property.
		/// </summary>
		internal sealed partial class FormTypePropertyHandler : DslModeling::DomainPropertyValueHandler<DEType, global::Tum.PDE.ModelingDSL.ShapeFormType?>
		{
			private FormTypePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DEType.FormType domain property value handler.
			/// </summary>
			public static readonly FormTypePropertyHandler Instance = new FormTypePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DEType.FormType domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return FormTypeDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ModelingDSL.ShapeFormType? GetValue(DEType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.formTypePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DEType element, global::Tum.PDE.ModelingDSL.ShapeFormType? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ModelingDSL.ShapeFormType? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.formTypePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region FileName domain property code
		
		/// <summary>
		/// FileName domain property Id.
		/// </summary>
		public static readonly global::System.Guid FileNameDomainPropertyId = new System.Guid("7ba7e275-cb0b-44d8-9303-1180144d812a") ;
		
		/// <summary>
		/// Storage for FileName
		/// </summary>
		private global::System.String fileNamePropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of FileName domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DEType/FileName.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DEType/FileName.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("7ba7e275-cb0b-44d8-9303-1180144d812a")]
		public global::System.String FileName
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return fileNamePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				FileNamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the DEType.FileName domain property.
		/// </summary>
		internal sealed partial class FileNamePropertyHandler : DslModeling::DomainPropertyValueHandler<DEType, global::System.String>
		{
			private FileNamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DEType.FileName domain property value handler.
			/// </summary>
			public static readonly FileNamePropertyHandler Instance = new FileNamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DEType.FileName domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return FileNameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(DEType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.fileNamePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DEType element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.fileNamePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region DETypes opposite domain role accessor
		/// <summary>
		/// Gets or sets DETypes.
		/// </summary>
		public virtual DETypes DETypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypeDomainRoleId) as DETypes;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DETypesHasDEType.DETypeDomainRoleId, value);
			}
		}
		#endregion
		#region DomainElement opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainElement.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DomainElement> DomainElement
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DomainElement>, DomainElement>(global::Tum.PDE.ModelingDSL.DomainElementReferencesDEType.DETypeDomainRoleId);
			}
		}
		#endregion
		#region DRTypeS opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DRTypeS.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DRType> DRTypeS
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DRType>, DRType>(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DETypeSourceDomainRoleId);
			}
		}
		#endregion
		#region DRTypeT opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DRTypeT.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DRType> DRTypeT
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DRType>, DRType>(global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DETypeTargetDomainRoleId);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DEType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DEType";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DEType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass DRType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.DRType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.DRType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("2459b8df-44bb-4f8e-b34f-d8289f154716")]
	public abstract partial class DRType : global::Tum.PDE.ModelingDSL.BaseDomainElementType 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DRType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("2459b8df-44bb-4f8e-b34f-d8289f154716");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected DRType(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region DRTypes opposite domain role accessor
		/// <summary>
		/// Gets or sets DRTypes.
		/// </summary>
		public virtual DRTypes DRTypes
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypeDomainRoleId) as DRTypes;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DRTypesHasDRType.DRTypeDomainRoleId, value);
			}
		}
		#endregion
		#region ReferencedRelationships opposite domain role accessor
		
		/// <summary>
		/// Gets a list of ReferencedRelationships.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<BaseElementSourceReferencesBaseElementTarget> ReferencedRelationships
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<BaseElementSourceReferencesBaseElementTarget>, BaseElementSourceReferencesBaseElementTarget>(global::Tum.PDE.ModelingDSL.DRTypeReferencesBaseElementSourceReferencesBaseElementTarget.DRTypeDomainRoleId);
			}
		}
		#endregion
		#region Source opposite domain role accessor
		/// <summary>
		/// Gets or sets Source.
		/// </summary>
		public virtual DEType Source
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId) as DEType;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeSource.DRTypeSDomainRoleId, value);
			}
		}
		#endregion
		#region Target opposite domain role accessor
		/// <summary>
		/// Gets or sets Target.
		/// </summary>
		public virtual DEType Target
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId) as DEType;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DRTypeReferencesDETypeTarget.DRTypeTDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "DRType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "DRType";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.DRType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass BaseDomainElementType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseDomainElementType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseDomainElementType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("458eb0ba-0239-4dd3-9d3d-198a494e79f3")]
	public abstract partial class BaseDomainElementType : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// BaseDomainElementType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("458eb0ba-0239-4dd3-9d3d-198a494e79f3");
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		protected BaseDomainElementType(DslModeling::Partition partition, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("a0ec28b2-f390-4c34-ab5d-d062770faa03") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.BaseDomainElementType/Name.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.BaseDomainElementType/Name.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("a0ec28b2-f390-4c34-ab5d-d062770faa03")]
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
		/// Value handler for the BaseDomainElementType.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<BaseDomainElementType, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the BaseDomainElementType.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the BaseDomainElementType.Name domain property.
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
			public override sealed global::System.String GetValue(BaseDomainElementType element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(BaseDomainElementType element, global::System.String newValue)
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.ModelingDSL.BaseDomainElementType.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "BaseDomainElementType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Base Domain Element Type";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.BaseDomainElementType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass ReferencingDRType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ReferencingDRType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ReferencingDRType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("e3b62f11-c022-4696-ae5b-ac07a80d78cb")]
	public partial class ReferencingDRType : global::Tum.PDE.ModelingDSL.DRType 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ReferencingDRType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("e3b62f11-c022-4696-ae5b-ac07a80d78cb");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ReferencingDRType(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ReferencingDRType(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "ReferencingDRType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Referencing DRType";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.ReferencingDRType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass EmbeddingDRType
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.EmbeddingDRType.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.EmbeddingDRType.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("23b20ec6-99eb-4269-942f-4841253b3a89")]
	public partial class EmbeddingDRType : global::Tum.PDE.ModelingDSL.DRType 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// EmbeddingDRType domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("23b20ec6-99eb-4269-942f-4841253b3a89");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EmbeddingDRType(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public EmbeddingDRType(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "EmbeddingDRType";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Embedding DRType";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.EmbeddingDRType.DomainClassId;
	    }
	}
}
namespace Tum.PDE.ModelingDSL
{
	/// <summary>
	/// DomainClass ConversionModelInfo
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ConversionModelInfo.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ConversionModelInfo.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "Tum.PDE.ModelingDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel))]
	[DslModeling::DomainObjectId("92bd7fc9-11d5-44ab-bb9b-88a3becf549f")]
	public partial class ConversionModelInfo : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ConversionModelInfo domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("92bd7fc9-11d5-44ab-bb9b-88a3becf549f");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ConversionModelInfo(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ConversionModelInfo(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.ModelingDSL.PDEModelingDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region HasModelChanged domain property code
		
		/// <summary>
		/// HasModelChanged domain property Id.
		/// </summary>
		public static readonly global::System.Guid HasModelChangedDomainPropertyId = new System.Guid("416ab0d2-926e-4437-a4f7-f12989c38144") ;
		
		/// <summary>
		/// Storage for HasModelChanged
		/// </summary>
		private global::System.Boolean? hasModelChangedPropertyStorage = DslModeling::SerializationUtilities.GetValue<global::System.Boolean?>("false");
		
		/// <summary>
		/// Gets or sets the value of HasModelChanged domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.ModelingDSL.ConversionModelInfo/HasModelChanged.DisplayName", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.ModelingDSL.ConversionModelInfo/HasModelChanged.Description", typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(typeof(global::System.Boolean?), "false")]
		[DslModeling::DomainObjectId("416ab0d2-926e-4437-a4f7-f12989c38144")]
		public global::System.Boolean? HasModelChanged
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return hasModelChangedPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				HasModelChangedPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the ConversionModelInfo.HasModelChanged domain property.
		/// </summary>
		internal sealed partial class HasModelChangedPropertyHandler : DslModeling::DomainPropertyValueHandler<ConversionModelInfo, global::System.Boolean?>
		{
			private HasModelChangedPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the ConversionModelInfo.HasModelChanged domain property value handler.
			/// </summary>
			public static readonly HasModelChangedPropertyHandler Instance = new HasModelChangedPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the ConversionModelInfo.HasModelChanged domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return HasModelChangedDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.Boolean? GetValue(ConversionModelInfo element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.hasModelChangedPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(ConversionModelInfo element, global::System.Boolean? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.Boolean? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.hasModelChangedPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region DomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainModel.
		/// </summary>
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId) as DomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.ModelingDSL.DomainModelHasConversionModelInfo.ConversionModelInfoDomainRoleId, value);
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
				// Null because in the visual studio plugin environment there can be multiple model datas present at once. Therefore there
				// is no singleton accessor for the model data.
				return null;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.PDE.ModelingDSL.PDEModelingDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "ConversionModelInfo";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Conversion Model Info";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.ModelingDSL.ConversionModelInfo.DomainClassId;
	    }
	}
}

 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// DomainClass DomainModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.DomainModel.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.DomainModel.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel))]
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
			: base(partition, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region DomainClass2 opposite domain role accessor
		
		/// <summary>
		/// Gets a list of DomainClass2.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<DomainClass2> DomainClass2
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<DomainClass2>, DomainClass2>(global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainModelDomainRoleId);
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
			return typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	        return global::Tum.PDE.VSPluginDSL.DomainModel.DomainClassId;
	    }
	}
}
namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// DomainClass DomainClass2
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.DomainClass2.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.DomainClass2.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "Tum.PDE.VSPluginDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("707894f5-2908-4f4a-8d22-86efbe4a13bb")]
	public partial class DomainClass2 : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// DomainClass2 domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("707894f5-2908-4f4a-8d22-86efbe4a13bb");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainClass2(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public DomainClass2(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.PDE.VSPluginDSL.VSPluginDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("82e507c0-b3d6-42de-85e7-375a11303495") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.PDE.VSPluginDSL.DomainClass2/Name.DisplayName", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.PDE.VSPluginDSL.DomainClass2/Name.Description", typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("82e507c0-b3d6-42de-85e7-375a11303495")]
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
		/// Value handler for the DomainClass2.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<DomainClass2, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the DomainClass2.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the DomainClass2.Name domain property.
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
			public override sealed global::System.String GetValue(DomainClass2 element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(DomainClass2 element, global::System.String newValue)
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
		#region DomainModel opposite domain role accessor
		/// <summary>
		/// Gets or sets DomainModel.
		/// </summary>
		public virtual DomainModel DomainModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClass2DomainRoleId) as DomainModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2.DomainClass2DomainRoleId, value);
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
			return typeof(global::Tum.PDE.VSPluginDSL.VSPluginDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.PDE.VSPluginDSL.DomainClass2.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "DomainClass2";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Domain Class2";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.PDE.VSPluginDSL.DomainClass2.DomainClassId;
	    }
	}
}

 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass VModell
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[DslModeling::DomainObjectId("f2ecf54b-a9c9-47a9-bbc5-354589463c41")]
	public partial class VModell : global::Tum.VModellXT.Basis.BaseElement, DslEditorModeling::IParentModelElement   
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModell domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("f2ecf54b-a9c9-47a9-bbc5-354589463c41");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public VModell(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public VModell(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Master domain property code
		
		/// <summary>
		/// Master domain property Id.
		/// </summary>
		public static readonly global::System.Guid MasterDomainPropertyId = new System.Guid("e10b291f-afbb-4dcb-bcda-af8f99d22aad") ;
		
		/// <summary>
		/// Storage for Master
		/// </summary>
		private global::System.String masterPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Master domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModell/Master.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModell/Master.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("e10b291f-afbb-4dcb-bcda-af8f99d22aad")]
		public global::System.String Master
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return masterPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				MasterPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the VModell.Master domain property.
		/// </summary>
		internal sealed partial class MasterPropertyHandler : DslModeling::DomainPropertyValueHandler<VModell, global::System.String>
		{
			private MasterPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the VModell.Master domain property value handler.
			/// </summary>
			public static readonly MasterPropertyHandler Instance = new MasterPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the VModell.Master domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return MasterDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(VModell element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.masterPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(VModell element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.masterPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region VModellvariante opposite domain role accessor
		
		/// <summary>
		/// Gets a list of VModellvariante.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<VModellvariante> VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<VModellvariante>, VModellvariante>(global::Tum.VModellXT.VModellHasVModellvariante.VModellDomainRoleId);
			}
		}
		#endregion
		#region Referenzmodell opposite domain role accessor
		/// <summary>
		/// Gets or sets Referenzmodell.
		/// </summary>
		public virtual Referenzmodell Referenzmodell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ReferenzmodellHasVModell.VModellDomainRoleId) as Referenzmodell;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ReferenzmodellHasVModell.VModellDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "VModell";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "VModell";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.VModell.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass VModellvariante
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvariante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.VModellvariante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("cc83a783-504e-4a3d-8673-3f5395f76683")]
	public partial class VModellvariante : global::Tum.VModellXT.Basis.BaseElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// VModellvariante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("cc83a783-504e-4a3d-8673-3f5395f76683");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public VModellvariante(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public VModellvariante(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("e07a1795-f3be-490b-84c6-32412baf1f8b") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvariante/Name.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvariante/Name.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("e07a1795-f3be-490b-84c6-32412baf1f8b")]
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
		/// Value handler for the VModellvariante.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<VModellvariante, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the VModellvariante.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the VModellvariante.Name domain property.
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
			public override sealed global::System.String GetValue(VModellvariante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(VModellvariante element, global::System.String newValue)
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
		#region Version domain property code
		
		/// <summary>
		/// Version domain property Id.
		/// </summary>
		public static readonly global::System.Guid VersionDomainPropertyId = new System.Guid("1c7bdad7-334b-4fd9-a663-2225c96c67dd") ;
		
		/// <summary>
		/// Storage for Version
		/// </summary>
		private global::System.String versionPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Version domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvariante/Version.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvariante/Version.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("1c7bdad7-334b-4fd9-a663-2225c96c67dd")]
		public global::System.String Version
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return versionPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				VersionPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the VModellvariante.Version domain property.
		/// </summary>
		internal sealed partial class VersionPropertyHandler : DslModeling::DomainPropertyValueHandler<VModellvariante, global::System.String>
		{
			private VersionPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the VModellvariante.Version domain property value handler.
			/// </summary>
			public static readonly VersionPropertyHandler Instance = new VersionPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the VModellvariante.Version domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return VersionDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(VModellvariante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.versionPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(VModellvariante element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.versionPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region VersionIntern domain property code
		
		/// <summary>
		/// VersionIntern domain property Id.
		/// </summary>
		public static readonly global::System.Guid VersionInternDomainPropertyId = new System.Guid("151033e9-525e-4078-9a52-dc8fc9da3242") ;
		
		/// <summary>
		/// Storage for VersionIntern
		/// </summary>
		private global::System.String versionInternPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of VersionIntern domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvariante/VersionIntern.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvariante/VersionIntern.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("151033e9-525e-4078-9a52-dc8fc9da3242")]
		public global::System.String VersionIntern
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return versionInternPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				VersionInternPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the VModellvariante.VersionIntern domain property.
		/// </summary>
		internal sealed partial class VersionInternPropertyHandler : DslModeling::DomainPropertyValueHandler<VModellvariante, global::System.String>
		{
			private VersionInternPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the VModellvariante.VersionIntern domain property value handler.
			/// </summary>
			public static readonly VersionInternPropertyHandler Instance = new VersionInternPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the VModellvariante.VersionIntern domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return VersionInternDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(VModellvariante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.versionInternPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(VModellvariante element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.versionInternPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region CopyrightKurz domain property code
		
		/// <summary>
		/// CopyrightKurz domain property Id.
		/// </summary>
		public static readonly global::System.Guid CopyrightKurzDomainPropertyId = new System.Guid("7a72a0e5-09cb-4783-bc8e-cfe0aef67627") ;
		
		/// <summary>
		/// Storage for CopyrightKurz
		/// </summary>
		private global::System.String copyrightKurzPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of CopyrightKurz domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvariante/CopyrightKurz.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvariante/CopyrightKurz.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("7a72a0e5-09cb-4783-bc8e-cfe0aef67627")]
		public global::System.String CopyrightKurz
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return copyrightKurzPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				CopyrightKurzPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the VModellvariante.CopyrightKurz domain property.
		/// </summary>
		internal sealed partial class CopyrightKurzPropertyHandler : DslModeling::DomainPropertyValueHandler<VModellvariante, global::System.String>
		{
			private CopyrightKurzPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the VModellvariante.CopyrightKurz domain property value handler.
			/// </summary>
			public static readonly CopyrightKurzPropertyHandler Instance = new CopyrightKurzPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the VModellvariante.CopyrightKurz domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return CopyrightKurzDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(VModellvariante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.copyrightKurzPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(VModellvariante element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.copyrightKurzPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region CopyrightLang domain property code
		
		/// <summary>
		/// CopyrightLang domain property Id.
		/// </summary>
		public static readonly global::System.Guid CopyrightLangDomainPropertyId = new System.Guid("4ba15b0c-6e6f-4714-adec-820d370af25d") ;
		
		/// <summary>
		/// Storage for CopyrightLang
		/// </summary>
		private global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html copyrightLangPropertyStorage;
		
		/// <summary>
		/// Gets or sets the value of CopyrightLang domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.VModellvariante/CopyrightLang.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.VModellvariante/CopyrightLang.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainObjectId("4ba15b0c-6e6f-4714-adec-820d370af25d")]
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html CopyrightLang
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return copyrightLangPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				CopyrightLangPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the VModellvariante.CopyrightLang domain property.
		/// </summary>
		internal sealed partial class CopyrightLangPropertyHandler : DslModeling::DomainPropertyValueHandler<VModellvariante, global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html>
		{
			private CopyrightLangPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the VModellvariante.CopyrightLang domain property value handler.
			/// </summary>
			public static readonly CopyrightLangPropertyHandler Instance = new CopyrightLangPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the VModellvariante.CopyrightLang domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return CopyrightLangDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html GetValue(VModellvariante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.copyrightLangPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(VModellvariante element, global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.copyrightLangPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region VModell opposite domain role accessor
		/// <summary>
		/// Gets or sets VModell.
		/// </summary>
		public virtual VModell VModell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellHasVModellvariante.VModellvarianteDomainRoleId) as VModell;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellHasVModellvariante.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region VModellStruktur opposite domain role accessor
		/// <summary>
		/// Gets or sets VModellStruktur.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.VModellStruktur VModellStruktur
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.VModellStruktur;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasVModellStruktur.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Textbausteine opposite domain role accessor
		/// <summary>
		/// Gets or sets Textbausteine.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.Textbausteine Textbausteine
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Textbausteine;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasTextbausteine.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Vorgehensbausteine opposite domain role accessor
		/// <summary>
		/// Gets or sets Vorgehensbausteine.
		/// </summary>
		public virtual global::Tum.VModellXT.Statik.Vorgehensbausteine Vorgehensbausteine
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Statik.Vorgehensbausteine;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasVorgehensbausteine.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Rollen opposite domain role accessor
		/// <summary>
		/// Gets or sets Rollen.
		/// </summary>
		public virtual global::Tum.VModellXT.Statik.Rollen Rollen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Statik.Rollen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasRollen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region PDSSpezifikationen opposite domain role accessor
		/// <summary>
		/// Gets or sets PDSSpezifikationen.
		/// </summary>
		public virtual global::Tum.VModellXT.Dynamik.PDSSpezifikationen PDSSpezifikationen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Dynamik.PDSSpezifikationen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasPDSSpezifikationen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Ablaufbausteine opposite domain role accessor
		/// <summary>
		/// Gets or sets Ablaufbausteine.
		/// </summary>
		public virtual global::Tum.VModellXT.Dynamik.Ablaufbausteine Ablaufbausteine
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Dynamik.Ablaufbausteine;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAblaufbausteine.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Ablaufbausteinspezifikationen opposite domain role accessor
		/// <summary>
		/// Gets or sets Ablaufbausteinspezifikationen.
		/// </summary>
		public virtual global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen Ablaufbausteinspezifikationen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Dynamik.Ablaufbausteinspezifikationen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAblaufbausteinspezifikationen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Projekttypen opposite domain role accessor
		/// <summary>
		/// Gets or sets Projekttypen.
		/// </summary>
		public virtual global::Tum.VModellXT.Anpassung.Projekttypen Projekttypen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Projekttypen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasProjekttypen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Projekttypvarianten opposite domain role accessor
		/// <summary>
		/// Gets or sets Projekttypvarianten.
		/// </summary>
		public virtual global::Tum.VModellXT.Anpassung.Projekttypvarianten Projekttypvarianten
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Projekttypvarianten;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasProjekttypvarianten.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Vortailoring opposite domain role accessor
		/// <summary>
		/// Gets or sets Vortailoring.
		/// </summary>
		public virtual global::Tum.VModellXT.Anpassung.Vortailoring Vortailoring
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Vortailoring;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasVortailoring.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Entscheidungspunkte opposite domain role accessor
		/// <summary>
		/// Gets or sets Entscheidungspunkte.
		/// </summary>
		public virtual global::Tum.VModellXT.Statik.Entscheidungspunkte Entscheidungspunkte
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Statik.Entscheidungspunkte;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasEntscheidungspunkte.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Projektmerkmale opposite domain role accessor
		/// <summary>
		/// Gets or sets Projektmerkmale.
		/// </summary>
		public virtual global::Tum.VModellXT.Anpassung.Projektmerkmale Projektmerkmale
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Anpassung.Projektmerkmale;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasProjektmerkmale.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Konventionsabbildungen opposite domain role accessor
		/// <summary>
		/// Gets or sets Konventionsabbildungen.
		/// </summary>
		public virtual global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen Konventionsabbildungen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Konventionsabbildungen.Konventionsabbildungen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasKonventionsabbildungen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Methodenreferenzen opposite domain role accessor
		/// <summary>
		/// Gets or sets Methodenreferenzen.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.Methodenreferenzen Methodenreferenzen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Methodenreferenzen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasMethodenreferenzen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Werkzeugreferenzen opposite domain role accessor
		/// <summary>
		/// Gets or sets Werkzeugreferenzen.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.Werkzeugreferenzen Werkzeugreferenzen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Werkzeugreferenzen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasWerkzeugreferenzen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Glossar opposite domain role accessor
		/// <summary>
		/// Gets or sets Glossar.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.Glossar Glossar
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Glossar;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasGlossar.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Abkuerzungen opposite domain role accessor
		/// <summary>
		/// Gets or sets Abkuerzungen.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.Abkuerzungen Abkuerzungen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Abkuerzungen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAbkuerzungen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Quellen opposite domain role accessor
		/// <summary>
		/// Gets or sets Quellen.
		/// </summary>
		public virtual global::Tum.VModellXT.Basis.Quellen Quellen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Basis.Quellen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasQuellen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Aenderungsoperationen opposite domain role accessor
		/// <summary>
		/// Gets or sets Aenderungsoperationen.
		/// </summary>
		public virtual global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen Aenderungsoperationen
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId) as global::Tum.VModellXT.Aenderungsoperationen.Aenderungsoperationen;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasAenderungsoperationen.VModellvarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Referenzmodell opposite domain role accessor
		/// <summary>
		/// Gets or sets Referenzmodell.
		/// </summary>
		public virtual Referenzmodell Referenzmodell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId) as Referenzmodell;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.VModellvarianteDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.VModellvariante.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "VModellvariante";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "V-Modellvariante";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.VModellvariante.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Referenzmodell
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Referenzmodell.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Referenzmodell.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[DslModeling::DomainObjectId("49010b2c-eef4-4834-9b8e-7e8811ca5baa")]
	public partial class Referenzmodell : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Referenzmodell domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("49010b2c-eef4-4834-9b8e-7e8811ca5baa");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Referenzmodell(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Referenzmodell(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region VModellvariante opposite domain role accessor
		/// <summary>
		/// Gets or sets VModellvariante.
		/// </summary>
		public virtual VModellvariante VModellvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId) as VModellvariante;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VModellvarianteHasReferenzmodell.ReferenzmodellDomainRoleId, value);
			}
		}
		#endregion
		#region VModell opposite domain role accessor
		/// <summary>
		/// Gets or sets VModell.
		/// </summary>
		public virtual VModell VModell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId) as VModell;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ReferenzmodellHasVModell.ReferenzmodellDomainRoleId, value);
			}
		}
		#endregion
		#region VModellvarianteRef opposite domain role accessor
		/// <summary>
		/// Gets or sets VModellvarianteRef.
		/// </summary>
		public virtual VModellvariante VModellvarianteRef
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId) as VModellvariante;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ReferenzmodellReferencesVModellvariante.ReferenzmodellDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "Referenzmodell";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Referenzmodell";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Referenzmodell.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Musterbibliothek
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Musterbibliothek.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Musterbibliothek.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[DslModeling::DomainObjectId("de79fb17-0f17-43da-bad2-078d70fd0057")]
	public partial class Musterbibliothek : DslEditorModeling::DomainModelElement, DslEditorModeling::IParentModelElement   
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Musterbibliothek domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("de79fb17-0f17-43da-bad2-078d70fd0057");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Musterbibliothek(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Musterbibliothek(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Mustergruppe opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Mustergruppe.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Mustergruppe> Mustergruppe
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Mustergruppe>, Mustergruppe>(global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MusterbibliothekDomainRoleId);
			}
		}
		#endregion
		#region VModell opposite domain role accessor
		/// <summary>
		/// Gets or sets VModell.
		/// </summary>
		public virtual VModell VModell
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId) as VModell;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.MusterbibliothekHasVModell.MusterbibliothekDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "Musterbibliothek";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Musterbibliothek";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Musterbibliothek.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Mustergruppe
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Mustergruppe.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Mustergruppe.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("28b972b1-eccb-4797-ad7a-384eb4675122")]
	public partial class Mustergruppe : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Mustergruppe domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("28b972b1-eccb-4797-ad7a-384eb4675122");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Mustergruppe(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Mustergruppe(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("fcab72d0-038e-4029-ab7f-0c49feeeb459") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Mustergruppe/Name.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Mustergruppe/Name.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("fcab72d0-038e-4029-ab7f-0c49feeeb459")]
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
		/// Value handler for the Mustergruppe.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Mustergruppe, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Mustergruppe.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Mustergruppe.Name domain property.
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
			public override sealed global::System.String GetValue(Mustergruppe element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Mustergruppe element, global::System.String newValue)
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
		#region Musterbibliothek opposite domain role accessor
		/// <summary>
		/// Gets or sets Musterbibliothek.
		/// </summary>
		public virtual Musterbibliothek Musterbibliothek
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId) as Musterbibliothek;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.MusterbibliothekHasMustergruppe.MustergruppeDomainRoleId, value);
			}
		}
		#endregion
		#region Themenmuster opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Themenmuster.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Themenmuster> Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Themenmuster>, Themenmuster>(global::Tum.VModellXT.MustergruppeHasThemenmuster.MustergruppeDomainRoleId);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Mustergruppe.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Mustergruppe";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Mustergruppe";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Mustergruppe.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Themenmuster
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Themenmuster.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Themenmuster.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("278fdf53-07a9-44b8-823c-a01604aa3343")]
	public partial class Themenmuster : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Themenmuster domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("278fdf53-07a9-44b8-823c-a01604aa3343");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Themenmuster(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Themenmuster(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("bc85d209-cb3e-4e18-ab55-88336286e89f") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Themenmuster/Name.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Themenmuster/Name.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("bc85d209-cb3e-4e18-ab55-88336286e89f")]
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
		/// Value handler for the Themenmuster.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Themenmuster, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Themenmuster.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Themenmuster.Name domain property.
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
			public override sealed global::System.String GetValue(Themenmuster element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Themenmuster element, global::System.String newValue)
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
		#region Mustergruppe opposite domain role accessor
		/// <summary>
		/// Gets or sets Mustergruppe.
		/// </summary>
		public virtual Mustergruppe Mustergruppe
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.MustergruppeHasThemenmuster.ThemenmusterDomainRoleId) as Mustergruppe;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.MustergruppeHasThemenmuster.ThemenmusterDomainRoleId, value);
			}
		}
		#endregion
		#region Thema opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Thema.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Thema> Thema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Thema>, global::Tum.VModellXT.Statik.Thema>(global::Tum.VModellXT.ThemenmusterReferencesThema.ThemenmusterDomainRoleId);
			}
		}
		#endregion
		#region Unterthema opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Unterthema.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Unterthema> Unterthema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<global::Tum.VModellXT.Statik.Unterthema>, global::Tum.VModellXT.Statik.Unterthema>(global::Tum.VModellXT.ThemenmusterReferencesUnterthema.ThemenmusterDomainRoleId);
			}
		}
		#endregion
		#region Mustertext opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Mustertext.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Mustertext> Mustertext
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Mustertext>, Mustertext>(global::Tum.VModellXT.ThemenmusterHasMustertext.ThemenmusterDomainRoleId);
			}
		}
		#endregion
		#region ThemenmusterTarget opposite domain role accessor
		
		/// <summary>
		/// Gets a list of ThemenmusterTarget.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Themenmuster> ThemenmusterTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Themenmuster>, Themenmuster>(global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterSourceDomainRoleId);
			}
		}
		#endregion
		#region ThemenmusterSource opposite domain role accessor
		/// <summary>
		/// Gets or sets ThemenmusterSource.
		/// </summary>
		public virtual Themenmuster ThemenmusterSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId) as Themenmuster;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ThemenmusterSourceHasThemenmusterTarget.ThemenmusterTargetDomainRoleId, value);
			}
		}
		#endregion
		#region Zusatzthema opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Zusatzthema.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Zusatzthema> Zusatzthema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Zusatzthema>, Zusatzthema>(global::Tum.VModellXT.ThemenmusterHasZusatzthema.ThemenmusterDomainRoleId);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Themenmuster.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Themenmuster";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Themenmuster";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Themenmuster.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Mustertext
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Mustertext.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Mustertext.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("23ba5615-8aec-4cfe-a7e4-58ad079e491d")]
	public partial class Mustertext : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Mustertext domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("23ba5615-8aec-4cfe-a7e4-58ad079e491d");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Mustertext(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Mustertext(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("cc61661a-b136-4956-ad6e-fcc490508e84") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Mustertext/Name.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Mustertext/Name.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("cc61661a-b136-4956-ad6e-fcc490508e84")]
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
		/// Value handler for the Mustertext.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Mustertext, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Mustertext.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Mustertext.Name domain property.
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
			public override sealed global::System.String GetValue(Mustertext element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Mustertext element, global::System.String newValue)
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
		#region Standardauswahl domain property code
		
		/// <summary>
		/// Standardauswahl domain property Id.
		/// </summary>
		public static readonly global::System.Guid StandardauswahlDomainPropertyId = new System.Guid("8055a7cb-d9c9-4b4b-8b9d-af2ab4314c28") ;
		
		/// <summary>
		/// Storage for Standardauswahl
		/// </summary>
		private global::Tum.VModellXT.TypStandard? standardauswahlPropertyStorage;
		
		/// <summary>
		/// Gets or sets the value of Standardauswahl domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Mustertext/Standardauswahl.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Mustertext/Standardauswahl.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainObjectId("8055a7cb-d9c9-4b4b-8b9d-af2ab4314c28")]
		public global::Tum.VModellXT.TypStandard? Standardauswahl
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return standardauswahlPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				StandardauswahlPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Mustertext.Standardauswahl domain property.
		/// </summary>
		internal sealed partial class StandardauswahlPropertyHandler : DslModeling::DomainPropertyValueHandler<Mustertext, global::Tum.VModellXT.TypStandard?>
		{
			private StandardauswahlPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Mustertext.Standardauswahl domain property value handler.
			/// </summary>
			public static readonly StandardauswahlPropertyHandler Instance = new StandardauswahlPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Mustertext.Standardauswahl domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return StandardauswahlDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.VModellXT.TypStandard? GetValue(Mustertext element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.standardauswahlPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Mustertext element, global::Tum.VModellXT.TypStandard? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.VModellXT.TypStandard? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.standardauswahlPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Text domain property code
		
		/// <summary>
		/// Text domain property Id.
		/// </summary>
		public static readonly global::System.Guid TextDomainPropertyId = new System.Guid("c6bf2d17-4b2c-4a8c-a7c9-f13dff62b47e") ;
		
		/// <summary>
		/// Storage for Text
		/// </summary>
		private global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html textPropertyStorage;
		
		/// <summary>
		/// Gets or sets the value of Text domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Mustertext/Text.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Mustertext/Text.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainObjectId("c6bf2d17-4b2c-4a8c-a7c9-f13dff62b47e")]
		public global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html Text
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return textPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				TextPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Mustertext.Text domain property.
		/// </summary>
		internal sealed partial class TextPropertyHandler : DslModeling::DomainPropertyValueHandler<Mustertext, global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html>
		{
			private TextPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Mustertext.Text domain property value handler.
			/// </summary>
			public static readonly TextPropertyHandler Instance = new TextPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Mustertext.Text domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return TextDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html GetValue(Mustertext element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.textPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Mustertext element, global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Html.Html oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.textPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Themenmuster opposite domain role accessor
		/// <summary>
		/// Gets or sets Themenmuster.
		/// </summary>
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ThemenmusterHasMustertext.MustertextDomainRoleId) as Themenmuster;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ThemenmusterHasMustertext.MustertextDomainRoleId, value);
			}
		}
		#endregion
		#region Zusatzthema opposite domain role accessor
		/// <summary>
		/// Gets or sets Zusatzthema.
		/// </summary>
		public virtual Zusatzthema Zusatzthema
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ZusatzthemaHasMustertext.MustertextDomainRoleId) as Zusatzthema;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ZusatzthemaHasMustertext.MustertextDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Mustertext.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Mustertext";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Mustertext";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Mustertext.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Zusatzthema
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Zusatzthema.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Zusatzthema.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("8aef1216-8c7b-478f-84ef-76c43f9bbaa9")]
	public partial class Zusatzthema : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Zusatzthema domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("8aef1216-8c7b-478f-84ef-76c43f9bbaa9");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Zusatzthema(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Zusatzthema(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("ac64eaaa-0a84-4615-85c5-b6f1b8e75b45") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Zusatzthema/Name.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Zusatzthema/Name.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("ac64eaaa-0a84-4615-85c5-b6f1b8e75b45")]
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
		/// Value handler for the Zusatzthema.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Zusatzthema, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Zusatzthema.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Zusatzthema.Name domain property.
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
			public override sealed global::System.String GetValue(Zusatzthema element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Zusatzthema element, global::System.String newValue)
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
		#region Standardauswahl domain property code
		
		/// <summary>
		/// Standardauswahl domain property Id.
		/// </summary>
		public static readonly global::System.Guid StandardauswahlDomainPropertyId = new System.Guid("7e42c6ed-74ae-4049-894d-68c7063fe5d3") ;
		
		/// <summary>
		/// Storage for Standardauswahl
		/// </summary>
		private global::Tum.VModellXT.TypStandard? standardauswahlPropertyStorage;
		
		/// <summary>
		/// Gets or sets the value of Standardauswahl domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Zusatzthema/Standardauswahl.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Zusatzthema/Standardauswahl.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslModeling::DomainObjectId("7e42c6ed-74ae-4049-894d-68c7063fe5d3")]
		public global::Tum.VModellXT.TypStandard? Standardauswahl
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return standardauswahlPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				StandardauswahlPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Zusatzthema.Standardauswahl domain property.
		/// </summary>
		internal sealed partial class StandardauswahlPropertyHandler : DslModeling::DomainPropertyValueHandler<Zusatzthema, global::Tum.VModellXT.TypStandard?>
		{
			private StandardauswahlPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Zusatzthema.Standardauswahl domain property value handler.
			/// </summary>
			public static readonly StandardauswahlPropertyHandler Instance = new StandardauswahlPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Zusatzthema.Standardauswahl domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return StandardauswahlDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.VModellXT.TypStandard? GetValue(Zusatzthema element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.standardauswahlPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Zusatzthema element, global::Tum.VModellXT.TypStandard? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.VModellXT.TypStandard? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.standardauswahlPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Themenmuster opposite domain role accessor
		/// <summary>
		/// Gets or sets Themenmuster.
		/// </summary>
		public virtual Themenmuster Themenmuster
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId) as Themenmuster;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ThemenmusterHasZusatzthema.ZusatzthemaDomainRoleId, value);
			}
		}
		#endregion
		#region Mustertext opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Mustertext.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Mustertext> Mustertext
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Mustertext>, Mustertext>(global::Tum.VModellXT.ZusatzthemaHasMustertext.ZusatzthemaDomainRoleId);
			}
		}
		#endregion
		#region ZusatzthemaTarget opposite domain role accessor
		
		/// <summary>
		/// Gets a list of ZusatzthemaTarget.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Zusatzthema> ZusatzthemaTarget
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Zusatzthema>, Zusatzthema>(global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaSourceDomainRoleId);
			}
		}
		#endregion
		#region ZusatzthemaSource opposite domain role accessor
		/// <summary>
		/// Gets or sets ZusatzthemaSource.
		/// </summary>
		public virtual Zusatzthema ZusatzthemaSource
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId) as Zusatzthema;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.ZusatzthemaSourceHasZusatzthemaTarget.ZusatzthemaTargetDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Zusatzthema.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Zusatzthema";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Zusatzthema";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Zusatzthema.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Varianten
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Varianten.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Varianten.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[DslModeling::DomainObjectId("5a73242c-947d-4f68-8444-388303869f48")]
	public partial class Varianten : DslEditorModeling::DomainModelElement, DslEditorModeling::IParentModelElement   
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Varianten domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("5a73242c-947d-4f68-8444-388303869f48");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Varianten(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Varianten(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Variante opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Variante.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Variante> Variante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Variante>, Variante>(global::Tum.VModellXT.VariantenHasVariante.VariantenDomainRoleId);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "Varianten";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Varianten";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Varianten.DomainClassId;
	    }
	}
}
namespace Tum.VModellXT
{
	/// <summary>
	/// DomainClass Variante
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.VModellXT.Variante.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.VModellXT.Variante.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "Tum.VModellXT.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.VModellXT.VModellXTDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("932ded73-7db2-4636-b833-b8fddbaabf79")]
	public partial class Variante : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Variante domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("932ded73-7db2-4636-b833-b8fddbaabf79");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Variante(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Variante(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.VModellXT.VModellXTDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("4841b924-100c-4323-8921-cc81d81a3f76") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Variante/Name.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Variante/Name.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("4841b924-100c-4323-8921-cc81d81a3f76")]
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
		/// Value handler for the Variante.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Variante, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Variante.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Variante.Name domain property.
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
			public override sealed global::System.String GetValue(Variante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Variante element, global::System.String newValue)
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
		#region Verzeichnis domain property code
		
		/// <summary>
		/// Verzeichnis domain property Id.
		/// </summary>
		public static readonly global::System.Guid VerzeichnisDomainPropertyId = new System.Guid("24f9be53-367e-4dc9-a00b-3fca71332d51") ;
		
		/// <summary>
		/// Storage for Verzeichnis
		/// </summary>
		private global::System.String verzeichnisPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Verzeichnis domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Variante/Verzeichnis.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Variante/Verzeichnis.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("24f9be53-367e-4dc9-a00b-3fca71332d51")]
		public global::System.String Verzeichnis
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return verzeichnisPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				VerzeichnisPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Variante.Verzeichnis domain property.
		/// </summary>
		internal sealed partial class VerzeichnisPropertyHandler : DslModeling::DomainPropertyValueHandler<Variante, global::System.String>
		{
			private VerzeichnisPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Variante.Verzeichnis domain property value handler.
			/// </summary>
			public static readonly VerzeichnisPropertyHandler Instance = new VerzeichnisPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Variante.Verzeichnis domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return VerzeichnisDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(Variante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.verzeichnisPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Variante element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.verzeichnisPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Dateiname domain property code
		
		/// <summary>
		/// Dateiname domain property Id.
		/// </summary>
		public static readonly global::System.Guid DateinameDomainPropertyId = new System.Guid("b889a91c-da9b-4ff0-a074-c5414d22da24") ;
		
		/// <summary>
		/// Storage for Dateiname
		/// </summary>
		private global::System.String dateinamePropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Dateiname domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.VModellXT.Variante/Dateiname.DisplayName", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.VModellXT.Variante/Dateiname.Description", typeof(global::Tum.VModellXT.VModellXTDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("b889a91c-da9b-4ff0-a074-c5414d22da24")]
		public global::System.String Dateiname
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return dateinamePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DateinamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Variante.Dateiname domain property.
		/// </summary>
		internal sealed partial class DateinamePropertyHandler : DslModeling::DomainPropertyValueHandler<Variante, global::System.String>
		{
			private DateinamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Variante.Dateiname domain property value handler.
			/// </summary>
			public static readonly DateinamePropertyHandler Instance = new DateinamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Variante.Dateiname domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return DateinameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(Variante element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.dateinamePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Variante element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.dateinamePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Varianten opposite domain role accessor
		/// <summary>
		/// Gets or sets Varianten.
		/// </summary>
		public virtual Varianten Varianten
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VariantenHasVariante.VarianteDomainRoleId) as Varianten;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VariantenHasVariante.VarianteDomainRoleId, value);
			}
		}
		#endregion
		#region Referenzvariante opposite domain role accessor
		/// <summary>
		/// Gets or sets Referenzvariante.
		/// </summary>
		public virtual Variante Referenzvariante
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId) as Variante;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.VModellXT.VarianteSourceReferencesVarianteTarget.VarianteSourceDomainRoleId, value);
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
				return global::Tum.VModellXT.VModellXTDocumentData.Instance;
			}
	    }*/
			
		/// <summary>
	    /// Gets the domain model type.
	    /// </summary>
	    /// <returns>Domain model type.</returns>
	    public override System.Type GetDomainModelType()
		{
			return typeof(global::Tum.VModellXT.VModellXTDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.VModellXT.Variante.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Variante";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Variante";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.VModellXT.Variante.DomainClassId;
	    }
	}
}

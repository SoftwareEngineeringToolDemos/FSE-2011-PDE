 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainClass FamilyTreeModel
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreeModel.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreeModel.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel))]
	[DslModeling::DomainObjectId("67a0ab85-b72a-444d-ad42-062d4c6fd96e")]
	public partial class FamilyTreeModel : DslEditorModeling::DomainModelElement, DslEditorModeling::IParentModelElement   
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// FamilyTreeModel domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("67a0ab85-b72a-444d-ad42-062d4c6fd96e");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public FamilyTreeModel(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public FamilyTreeModel(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region FamilyTreePerson opposite domain role accessor
		
		/// <summary>
		/// Gets a list of FamilyTreePerson.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<FamilyTreePerson> FamilyTreePerson
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<FamilyTreePerson>, FamilyTreePerson>(global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreeModelDomainRoleId);
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
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "FamilyTreeModel";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Family Tree Model";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.FamilyTreeDSL.FamilyTreeModel.DomainClassId;
	    }
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainClass Person
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.Person.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Person.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("21332a00-f8e1-4b7d-98e0-faac3cf93b00")]
	public partial class Person : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Person domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("21332a00-f8e1-4b7d-98e0-faac3cf93b00");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Person(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Person(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("33a1895e-e63d-4eff-b2cf-e838c3e8a461") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.Person/Name.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Person/Name.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("33a1895e-e63d-4eff-b2cf-e838c3e8a461")]
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
		/// Value handler for the Person.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Person, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Person.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Person.Name domain property.
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
			public override sealed global::System.String GetValue(Person element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Person element, global::System.String newValue)
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
		#region Gender domain property code
		
		/// <summary>
		/// Gender domain property Id.
		/// </summary>
		public static readonly global::System.Guid GenderDomainPropertyId = new System.Guid("66e06c32-8163-447f-a7f3-9fef67dd3787") ;
		
		/// <summary>
		/// Storage for Gender
		/// </summary>
		private global::Tum.FamilyTreeDSL.Gender? genderPropertyStorage = global::Tum.FamilyTreeDSL.Gender.Male;
		
		/// <summary>
		/// Gets or sets the value of Gender domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.Person/Gender.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Person/Gender.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue(global::Tum.FamilyTreeDSL.Gender.Male)]
		[DslModeling::DomainObjectId("66e06c32-8163-447f-a7f3-9fef67dd3787")]
		public global::Tum.FamilyTreeDSL.Gender? Gender
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return genderPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				GenderPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Person.Gender domain property.
		/// </summary>
		internal sealed partial class GenderPropertyHandler : DslModeling::DomainPropertyValueHandler<Person, global::Tum.FamilyTreeDSL.Gender?>
		{
			private GenderPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Person.Gender domain property value handler.
			/// </summary>
			public static readonly GenderPropertyHandler Instance = new GenderPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Person.Gender domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return GenderDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::Tum.FamilyTreeDSL.Gender? GetValue(Person element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.genderPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Person element, global::Tum.FamilyTreeDSL.Gender? newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::Tum.FamilyTreeDSL.Gender? oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.genderPropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region Hobbies domain property code
		
		/// <summary>
		/// Hobbies domain property Id.
		/// </summary>
		public static readonly global::System.Guid HobbiesDomainPropertyId = new System.Guid("bbdd8c7d-6da7-4336-878a-19ed0ba6caf6") ;
		
		/// <summary>
		/// Storage for Hobbies
		/// </summary>
		private global::System.String hobbiesPropertyStorage = null;
		
		/// <summary>
		/// Gets or sets the value of Hobbies domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.Person/Hobbies.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Person/Hobbies.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::DomainObjectId("bbdd8c7d-6da7-4336-878a-19ed0ba6caf6")]
		public global::System.String Hobbies
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return hobbiesPropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				HobbiesPropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the Person.Hobbies domain property.
		/// </summary>
		internal sealed partial class HobbiesPropertyHandler : DslModeling::DomainPropertyValueHandler<Person, global::System.String>
		{
			private HobbiesPropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Person.Hobbies domain property value handler.
			/// </summary>
			public static readonly HobbiesPropertyHandler Instance = new HobbiesPropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Person.Hobbies domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return HobbiesDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(Person element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.hobbiesPropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Person element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.hobbiesPropertyStorage = newValue;
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
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.Person.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Person";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Person";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.FamilyTreeDSL.Person.DomainClassId;
	    }
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainClass FamilyTreePerson
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.FamilyTreePerson.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.FamilyTreePerson.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel))]
	[DslModeling::DomainObjectId("a6ef3e71-b373-4753-a220-2005f011f361")]
	public partial class FamilyTreePerson : global::Tum.FamilyTreeDSL.Person 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// FamilyTreePerson domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("a6ef3e71-b373-4753-a220-2005f011f361");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public FamilyTreePerson(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public FamilyTreePerson(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region FamilyTreeModel opposite domain role accessor
		/// <summary>
		/// Gets or sets FamilyTreeModel.
		/// </summary>
		public virtual FamilyTreeModel FamilyTreeModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId) as FamilyTreeModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson.FamilyTreePersonDomainRoleId, value);
			}
		}
		#endregion
		#region Pet opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Pet.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<Pet> Pet
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<Pet>, Pet>(global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.FamilyTreePersonDomainRoleId);
			}
		}
		#endregion
		#region Children opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Children.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<FamilyTreePerson> Children
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<FamilyTreePerson>, FamilyTreePerson>(global::Tum.FamilyTreeDSL.ParentOf.ParentDomainRoleId);
			}
		}
		#endregion
		#region Parents opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Parents.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<FamilyTreePerson> Parents
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<FamilyTreePerson>, FamilyTreePerson>(global::Tum.FamilyTreeDSL.ParentOf.ChildDomainRoleId);
			}
		}
		#endregion
		#region Wife opposite domain role accessor
		/// <summary>
		/// Gets or sets Wife.
		/// </summary>
		public virtual FamilyTreePerson Wife
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId) as FamilyTreePerson;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId, value);
			}
		}
		#endregion
		#region Husband opposite domain role accessor
		/// <summary>
		/// Gets or sets Husband.
		/// </summary>
		public virtual FamilyTreePerson Husband
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.FamilyTreeDSL.MarriedTo.WifeDomainRoleId) as FamilyTreePerson;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.FamilyTreeDSL.MarriedTo.WifeDomainRoleId, value);
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
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
	            return "FamilyTreePerson";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Family Tree Person";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.FamilyTreeDSL.FamilyTreePerson.DomainClassId;
	    }
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
	/// DomainClass Pet
	/// </summary>
	[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.Pet.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Pet.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "Tum.FamilyTreeDSL.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel))]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("b1a37134-0462-49dd-8d11-28935de0f5c6")]
	public partial class Pet : DslEditorModeling::DomainModelElement 
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// Pet domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new System.Guid("b1a37134-0462-49dd-8d11-28935de0f5c6");
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Pet(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public Pet(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, Tum.FamilyTreeDSL.FamilyTreeDSLDomainModelIdProvider.Instance.AssignId(propertyAssignments))
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new System.Guid("e4cbf5ed-1dc7-45e6-bda0-3e455672df20") ;
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = "";
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// </summary>
		[DslDesign::DisplayNameResource("Tum.FamilyTreeDSL.Pet/Name.DisplayName", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[DslDesign::DescriptionResource("Tum.FamilyTreeDSL.Pet/Name.Description", typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel), "")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("e4cbf5ed-1dc7-45e6-bda0-3e455672df20")]
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
		/// Value handler for the Pet.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<Pet, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the Pet.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the Pet.Name domain property.
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
			public override sealed global::System.String GetValue(Pet element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(Pet element, global::System.String newValue)
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
		#region FamilyTreePerson opposite domain role accessor
		/// <summary>
		/// Gets or sets FamilyTreePerson.
		/// </summary>
		public virtual FamilyTreePerson FamilyTreePerson
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.PetDomainRoleId) as FamilyTreePerson;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet.PetDomainRoleId, value);
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
			return typeof(global::Tum.FamilyTreeDSL.FamilyTreeDSLDomainModel);
		}
	
	    /// <summary>
	    /// Gets the domain model services.
	    /// </summary>
	    /// <returns>Domain model services.</returns>
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
				return this.Store.DomainDataDirectory.GetDomainProperty(global::Tum.FamilyTreeDSL.Pet.NameDomainPropertyId);
			}
	    }
		
		/// <summary>
	    /// Gets the type of the ModelElement as string.
	    /// </summary>
	    public override string DomainElementType
	    {
	        get
	        {
	            return "Pet";
	        }
	    }
	
	    /// <summary>
	    /// Gets the display name of the type of the ModelElement.
	    /// </summary>
	    public override string DomainElementTypeDisplayName
	    {
	        get
	        {
	            return "Pet";
	        }
	    }		
		#endregion
	
		/// <summary>
	    /// Gets the domain class Id of this element.
	    /// </summary>
	    /// <returns>DomainClass Id.</returns>
	    public override System.Guid GetDomainClassId()
	    {
	        return global::Tum.FamilyTreeDSL.Pet.DomainClassId;
	    }
	}
}

 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// Groups logic for model validation.
    /// </summary>
	public partial class FamilyTreeDSLValidationController : DslEditorModeling::ModelValidationController
	{
		#region Singleton Instance
		private static FamilyTreeDSLValidationController validationController = null;
        private static object domainModelValidationLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static FamilyTreeDSLValidationController Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
				lock(domainModelValidationLock)
				{
					if( validationController == null )
					{
						validationController = new FamilyTreeDSLValidationController();
						
						// initialize
						FamilyTreeDSLValidationController.Initialize(validationController, new System.Collections.Generic.List<string>());
					}
				}
				
				return validationController;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>		
		private FamilyTreeDSLValidationController() : base()
		{	
		}
        #endregion
	
		#region Initialization		
        /// <summary>
        /// Initializes the static Validation map as well as the Validation is enabled fields in the actual instance of this class.
        /// </summary>
        /// <param name="controller">Controller to initalize</param>
        /// <param name="discardController">Validation controllers to discard.</param>
        public static void Initialize(DslEditorModeling::ModelValidationController controller, System.Collections.Generic.List<string> discardController)
		{
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.FamilyTreeModel));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.Person));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.FamilyTreePerson));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.Pet));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.FamilyTreeModelHasFamilyTreePerson));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.FamilyTreePersonHasPet));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.ParentOf));
			InitializeType(controller, typeof(global::Tum.FamilyTreeDSL.MarriedTo));

			// extern controller
			discardController.Add("global::Tum.FamilyTreeDSL.FamilyTreeDSL");

		}
		#endregion
	}
}

namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
	public partial class FamilyTreeDSLValidationMessageIds : DslEditorModeling::ModelValidationMessageIds
	{
		#region Property Ids
		/// <summary>
    	/// Person_Name error ID
    	/// </summary>
		public const string Person_Name = "Person.Name";
		/// <summary>
    	/// Person_Gender error ID
    	/// </summary>
		public const string Person_Gender = "Person.Gender";
		/// <summary>
    	/// Pet_Name error ID
    	/// </summary>
		public const string Pet_Name = "Pet.Name";
		#endregion
		
		#region Relationship Ids
		/// <summary>
    	/// MarriedTo_Wife error ID
    	/// </summary>
		public const string MarriedTo_Wife = "MarriedTo.Wife";
		/// <summary>
    	/// MarriedTo_Wife error ID
    	/// </summary>
		public const string MarriedTo_Husband = "MarriedTo.Husband";
		#endregion		
	}
}

namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// Partial class used to validate Person.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Person
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Person.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidatePerson(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.FamilyTreeDSL.FamilyTreeDSLValidationMessageIds.Person_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Gender
			if( this.Gender == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.FamilyTreeDSL.FamilyTreeDSLValidationMessageIds.Person_Gender, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Gender' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// Partial class used to validate FamilyTreePerson.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class FamilyTreePerson
	{
		#region Validate
		/// <summary>
   		/// Automatically validates FamilyTreePerson.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateFamilyTreePerson(DslEditorModeling::ModelValidationContext context)
		{

			// validate reference relationship from Husband to Wife (Side: Husband)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.MarriedTo> allMMarriedToInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(this, global::Tum.FamilyTreeDSL.MarriedTo.HusbandDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMMarriedToInstances0.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.FamilyTreeDSL.FamilyTreeDSLValidationMessageIds.MarriedTo_Wife, DslEditorModeling::ModelValidationViolationType.Error, "There are multiple references to elements of type Family Tree Person, although only one is allowed. Role name: + Wife", this));
			}

			// validate reference relationship from Husband to Wife (Side: Wife)
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.FamilyTreeDSL.MarriedTo> allMMarriedToInstances1 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.FamilyTreeDSL.MarriedTo>(this, global::Tum.FamilyTreeDSL.MarriedTo.WifeDomainRoleId);
			// validate reference relationships --> see if cardinality constraints are met
			if( allMMarriedToInstances1.Count > 1 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.FamilyTreeDSL.FamilyTreeDSLValidationMessageIds.MarriedTo_Husband, DslEditorModeling::ModelValidationViolationType.Error, "There are multiple references to elements of type Family Tree Person, although only one is allowed. Role name: + Husband", this));
			}
		}
		#endregion
	}
}
namespace Tum.FamilyTreeDSL
{
	/// <summary>
    /// Partial class used to validate Pet.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Pet
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Pet.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidatePet(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.FamilyTreeDSL.FamilyTreeDSLValidationMessageIds.Pet_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}

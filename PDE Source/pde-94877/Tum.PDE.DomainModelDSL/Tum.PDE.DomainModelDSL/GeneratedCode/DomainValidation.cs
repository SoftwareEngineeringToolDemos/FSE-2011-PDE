 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.TestLanguage
{
	/// <summary>
    /// Groups logic for model validation.
    /// </summary>
	public partial class TestLanguageValidationController : DslEditorModeling::ModelValidationController
	{
		#region Singleton Instance
		private static TestLanguageValidationController validationController = null;
        private static object domainModelValidationLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static TestLanguageValidationController Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
				lock(domainModelValidationLock)
				{
					if( validationController == null )
					{
						validationController = new TestLanguageValidationController();
						
						// initialize
						TestLanguageValidationController.Initialize(validationController, new System.Collections.Generic.List<string>());
					}
				}
				
				return validationController;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>		
		private TestLanguageValidationController() : base()
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
			InitializeType(controller, typeof(global::Tum.TestLanguage.DomainModel));
			InitializeType(controller, typeof(global::Tum.TestLanguage.Test));
			InitializeType(controller, typeof(global::Tum.TestLanguage.DomainModelHasTest));

			// extern controller
			discardController.Add("global::Tum.TestLanguage.TestLanguage");

		}
		#endregion
	}
}

namespace Tum.TestLanguage
{
	/// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
	public partial class TestLanguageValidationMessageIds : DslEditorModeling::ModelValidationMessageIds
	{
		#region Property Ids
		/// <summary>
    	/// Test_Name error ID
    	/// </summary>
		public const string Test_Name = "Test.Name";
		/// <summary>
    	/// Test_Number error ID
    	/// </summary>
		public const string Test_Number = "Test.Number";
		#endregion
		
		#region Relationship Ids
		#endregion		
	}
}

namespace Tum.TestLanguage
{
	/// <summary>
    /// Partial class used to validate Test.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Test
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Test.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateTest(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.TestLanguage.TestLanguageValidationMessageIds.Test_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
			// validate required attribute Number
			if( this.Number == null )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.TestLanguage.TestLanguageValidationMessageIds.Test_Number, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Number' has no value although it is required", this));
			}
		}
		#endregion
	}
}

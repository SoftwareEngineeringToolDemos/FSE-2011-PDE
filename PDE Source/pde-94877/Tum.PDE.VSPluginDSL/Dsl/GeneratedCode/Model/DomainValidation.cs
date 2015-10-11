 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
    /// Groups logic for model validation.
    /// </summary>
	public partial class VSPluginDSLValidationController : DslEditorModeling::ModelValidationController
	{
		#region Singleton Instance
		private static VSPluginDSLValidationController validationController = null;
        private static object domainModelValidationLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static VSPluginDSLValidationController Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
				lock(domainModelValidationLock)
				{
					if( validationController == null )
					{
						validationController = new VSPluginDSLValidationController();
						
						// initialize
						VSPluginDSLValidationController.Initialize(validationController, new System.Collections.Generic.List<string>());
					}
				}
				
				return validationController;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>		
		private VSPluginDSLValidationController() : base()
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
			InitializeType(controller, typeof(global::Tum.PDE.VSPluginDSL.DomainModel));
			InitializeType(controller, typeof(global::Tum.PDE.VSPluginDSL.DomainClass2));
			InitializeType(controller, typeof(global::Tum.PDE.VSPluginDSL.DomainModelHasDomainClass2));

			// extern controller
			discardController.Add("global::Tum.PDE.VSPluginDSL.VSPluginDSL");

		}
		#endregion
	}
}

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
	public partial class VSPluginDSLValidationMessageIds : DslEditorModeling::ModelValidationMessageIds
	{
		#region Property Ids
		/// <summary>
    	/// DomainClass2_Name error ID
    	/// </summary>
		public const string DomainClass2_Name = "DomainClass2.Name";
		#endregion
		
		#region Relationship Ids
		#endregion		
	}
}

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
    /// Partial class used to validate DomainClass2.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class DomainClass2
	{
		#region Validate
		/// <summary>
   		/// Automatically validates DomainClass2.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateDomainClass2(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.PDE.VSPluginDSL.VSPluginDSLValidationMessageIds.DomainClass2_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}

 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorModeling = global::Tum.PDE.ToolFramework.Modeling;

namespace Tum.StateMachineDSL
{
	/// <summary>
    /// Groups logic for model validation.
    /// </summary>
	public partial class StateMachineLanguageValidationController : DslEditorModeling::ModelValidationController
	{
		#region Singleton Instance
		private static StateMachineLanguageValidationController validationController = null;
        private static object domainModelValidationLock = new object();
		
        /// <summary>
        /// Singleton instance.
        /// </summary>
        [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)] // Will trigger creation otherwise.
        public static StateMachineLanguageValidationController Instance
        {
            [global::System.Diagnostics.DebuggerStepThrough]
            get
            {
				lock(domainModelValidationLock)
				{
					if( validationController == null )
					{
						validationController = new StateMachineLanguageValidationController();
						
						// initialize
						StateMachineLanguageValidationController.Initialize(validationController, new System.Collections.Generic.List<string>());
					}
				}
				
				return validationController;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>		
		private StateMachineLanguageValidationController() : base()
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
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.StateMachineDomainModel));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.StateBase));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.State));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.StartState));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.EndState));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.StateMachineDomainModelHasState));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState));
			InitializeType(controller, typeof(global::Tum.StateMachineDSL.Transition));

			// extern controller
			discardController.Add("global::Tum.StateMachineDSL.StateMachineLanguage");

		}
		#endregion
	}
}

namespace Tum.StateMachineDSL
{
	/// <summary>
    /// Ids identifying model validation messages.
    /// </summary>
	public partial class StateMachineLanguageValidationMessageIds : DslEditorModeling::ModelValidationMessageIds
	{
		#region Property Ids
		/// <summary>
    	/// State_Name error ID
    	/// </summary>
		public const string State_Name = "State.Name";
		/// <summary>
    	/// Transition_Condition error ID
    	/// </summary>
		public const string Transition_Condition = "Transition.Condition";
		#endregion
		
		#region Relationship Ids
		/// <summary>
    	/// StateMachineDomainModelHasStartState_StartState error ID
    	/// </summary>
		public const string StateMachineDomainModelHasStartState_StartState = "StateMachineDomainModelHasStartState.StartState";
		/// <summary>
    	/// StateMachineDomainModelHasEndState_EndState error ID
    	/// </summary>
		public const string StateMachineDomainModelHasEndState_EndState = "StateMachineDomainModelHasEndState.EndState";
		#endregion		
	}
}

namespace Tum.StateMachineDSL
{
	/// <summary>
    /// Partial class used to validate StateMachineDomainModel.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class StateMachineDomainModel
	{
		#region Validate
		/// <summary>
   		/// Automatically validates StateMachineDomainModel.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateStateMachineDomainModel(DslEditorModeling::ModelValidationContext context)
		{

			// validate embedding relationship from StateMachineDomainModel to StartState
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState> allMStateMachineDomainModelHasStartStateInstances0 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState>(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState.StateMachineDomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMStateMachineDomainModelHasStartStateInstances0.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.StateMachineDSL.StateMachineLanguageValidationMessageIds.StateMachineDomainModelHasStartState_StartState, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type StartState is missing, although it is required.", this));
			}

			// validate embedding relationship from StateMachineDomainModel to EndState
			System.Collections.ObjectModel.ReadOnlyCollection<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState> allMStateMachineDomainModelHasEndStateInstances1 =  DslModeling::DomainRoleInfo.GetElementLinks<global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState>(this, global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState.StateMachineDomainModelDomainRoleId);
			// validate embedding relationships --> see if cardinality constraints are met
			if( allMStateMachineDomainModelHasEndStateInstances1.Count == 0 )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.StateMachineDSL.StateMachineLanguageValidationMessageIds.StateMachineDomainModelHasEndState_EndState, DslEditorModeling::ModelValidationViolationType.Error, "Embedded element of type EndState is missing, although it is required.", this));
			}
		}
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
    /// Partial class used to validate State.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class State
	{
		#region Validate
		/// <summary>
   		/// Automatically validates State.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateState(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Name
			if( System.String.IsNullOrEmpty(this.Name) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.StateMachineDSL.StateMachineLanguageValidationMessageIds.State_Name, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Name' has no value although it is required", this));
			}
		}
		#endregion
	}
}
namespace Tum.StateMachineDSL
{
	/// <summary>
    /// Partial class used to validate Transition.
    /// </summary>
	[DslEditorModeling::ModelValidationState(DslEditorModeling::ModelValidationState.Enabled)]
	public partial class Transition
	{
		#region Validate
		/// <summary>
   		/// Automatically validates Transition.
    	/// </summary>
		[DslEditorModeling::ModelValidationMethod(DslEditorModeling::ModelValidationCategories.Open | DslEditorModeling::ModelValidationCategories.Save | DslEditorModeling::ModelValidationCategories.Menu)]		
		public virtual void ValidateTransition(DslEditorModeling::ModelValidationContext context)
		{
			// validate required attribute Condition
			if( System.String.IsNullOrEmpty(this.Condition) )
			{
				context.AddMessage(new DslEditorModeling::ModelValidationMessage(Tum.StateMachineDSL.StateMachineLanguageValidationMessageIds.Transition_Condition, DslEditorModeling::ModelValidationViolationType.Error, "Property 'Condition' has no value although it is required", this));
			}
		}
		#endregion
	}
}

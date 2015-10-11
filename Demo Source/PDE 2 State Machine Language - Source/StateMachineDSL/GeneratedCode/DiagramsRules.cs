 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
    /// This AddRule is for monitoring element creation that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.State), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.StartState), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.EndState), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class StateMachineLanguageElementForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public StateMachineLanguageElementForShapesAdded() 
			: base(StateMachineLanguageElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class StateMachineLanguageElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForShapes.ShapesFactoryHelper
        {
			private static StateMachineLanguageElementForShapesFactoryHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static StateMachineLanguageElementForShapesFactoryHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new StateMachineLanguageElementForShapesFactoryHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}

    /// <summary>
    /// This RolePlayerChangeRule is for monitoring embedding relationship changes that we need to reflect
	/// onto the diagram surface by removing and recreating its specified shape class if necessary.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.StateMachineDomainModelHasState), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.StateMachineDomainModelHasStartState), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.StateMachineDomainModelHasEndState), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class StateMachineLanguageElementForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public StateMachineLanguageElementForShapesChanged() 
			: base(StateMachineLanguageRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class StateMachineLanguageRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForShapes.RolePlayerChangeHelper
        {
			private static StateMachineLanguageRolePlayerChangeHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static StateMachineLanguageRolePlayerChangeHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new StateMachineLanguageRolePlayerChangeHelper();

    	            return instanceHolder;
    	        }
    	    }
		
			/// <summary>
        	/// Constructor.
        	/// </summary>
			public StateMachineLanguageRolePlayerChangeHelper() 
				: base(StateMachineLanguageElementForShapesAdded.StateMachineLanguageElementForShapesFactoryHelper.Instance,
					   StateMachineLanguageElementForShapesDeleted.StateMachineLanguageShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring element deletin that we need to reflect
	/// onto the diagram surface by creating its specified shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.State), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.StartState), FireTime = DslModeling::TimeToFire.LocalCommit)]
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.EndState), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class StateMachineLanguageElementForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public StateMachineLanguageElementForShapesDeleted() 
			: base(StateMachineLanguageShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class StateMachineLanguageShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForShapes.ShapeDeletionHelper
        {
			private static StateMachineLanguageShapeDeletionHelper instanceHolder = null;

    	    /// <summary>
    	    /// Gets a singleton instance.
    	    /// </summary>
    	    public static StateMachineLanguageShapeDeletionHelper Instance
    	    {
    	        get
    	        {
    	            if (instanceHolder == null)
    	                instanceHolder = new StateMachineLanguageShapeDeletionHelper();

    	            return instanceHolder;
    	        }
    	    }
		}
	}
}
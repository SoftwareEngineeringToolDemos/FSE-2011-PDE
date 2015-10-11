 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslEditorDiagrams = global::Tum.PDE.ToolFramework.Modeling.Diagrams;

namespace Tum.StateMachineDSL
{
	/// <summary>
    /// This AddRule is for monitoring link creation that we need to reflect
	/// onto the diagram surface by creating its specified rs shape class.
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.Transition), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class StateMachineLanguageLinkForShapesAdded : DslEditorDiagrams::ModelLinkAddRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public StateMachineLanguageLinkForShapesAdded() 
			: base(StateMachineLanguageElementForShapesFactoryHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class StateMachineLanguageElementForShapesFactoryHelper : DslEditorDiagrams::ModelLinkAddRuleForRSShapes.RSShapesFactoryHelper
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
	/// This ChangeRule is for monitoring link role player changes that we need to reflect
	/// onto the diagram surface.
    /// </summary>	
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.Transition), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class StateMachineLanguageLinkForShapesChanged : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public StateMachineLanguageLinkForShapesChanged() 
			: base(StateMachineLanguageRolePlayerChangeHelper.Instance)
		{
		}	
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class StateMachineLanguageRolePlayerChangeHelper : DslEditorDiagrams::ModelLinkRolePlayerChangeRuleForRSShapes.RolePlayerChangeHelper
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
				: base(StateMachineLanguageLinkForShapesAdded.StateMachineLanguageElementForShapesFactoryHelper.Instance,
					   StateMachineLanguageLinkForShapesDeleted.StateMachineLanguageShapeDeletionHelper.Instance)		
			{
			}
		}		
	}	

	/// <summary>
    /// This DeleteRule is for monitoring link deletion that we need to reflect
	/// onto the diagram surface by deleting its specified rs shape clas
    /// </summary>
	[DslModeling::RuleOn(typeof(global::Tum.StateMachineDSL.Transition), FireTime = DslModeling::TimeToFire.LocalCommit)]
    public partial class StateMachineLanguageLinkForShapesDeleted : DslEditorDiagrams::ModelElementDeletingRuleForRSShapes
    {
		/// <summary>
        /// Constructor.
        /// </summary>
		public StateMachineLanguageLinkForShapesDeleted() 
			: base(StateMachineLanguageShapeDeletionHelper.Instance)
		{
		}
		
		/// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public partial class StateMachineLanguageShapeDeletionHelper : DslEditorDiagrams::ModelElementDeletingRuleForRSShapes.ShapeDeletionHelper
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


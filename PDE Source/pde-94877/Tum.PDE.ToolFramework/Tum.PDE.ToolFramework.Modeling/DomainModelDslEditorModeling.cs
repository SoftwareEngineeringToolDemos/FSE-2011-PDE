using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Base domain model.
    /// </summary>
    [DependsOnDomainModel(typeof(CoreDomainModel))]
    [DomainObjectId("94BCF0D6-2C37-41AB-BF78-C642A067739F")]
    public class DomainModelDslEditorModeling : DomainModel
    {
        #region Constructor, domain model Id

		/// <summary>
		/// VModellXTDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new System.Guid("94BCF0D6-2C37-41AB-BF78-C642A067739F");

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
        public DomainModelDslEditorModeling(Store store)
			: base(store, DomainModelId)
		{

		}
		#endregion	

        #region Domain model reflection
        /// <summary>
        /// Gets the list of generated domain model types (classes, rules, relationships).
        /// </summary>
        /// <returns>List of types.</returns>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
        protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
        {
            return new global::System.Type[]
			{
				typeof(DomainModelElement),
                typeof(DomainModelLink)
			};
        }
       
        /// <summary>
        /// Gets the list of generated domain properties.
        /// </summary>
        /// <returns>List of property data.</returns>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
        protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
        {
            return new DomainMemberInfo[]
			{
			};
        }
        
        /// <summary>
        /// Gets the list of generated domain roles.
        /// </summary>
        /// <returns>List of role data.</returns>
        protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
        {
            return new DomainRolePlayerInfo[]
			{
                new DomainRolePlayerInfo(typeof(DomainModelLink), "SourceElement", DomainModelLink.SourceElementDomainRoleId),
                new DomainRolePlayerInfo(typeof(DomainModelLink), "TargetElement", DomainModelLink.TargetElementDomainRoleId),
		    };
        }
        #endregion
    }
}

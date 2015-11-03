using System.Collections.Generic;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class is used to gather dependency items as well as additional data which may be required when dealing with dependencies.
    /// </summary>
    public class DependenciesData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DependenciesData()
        {
            ActiveDependencies = new List<DependencyItem>();
            OriginDependencies = new List<DependencyOriginItem>();
        }

        /// <summary>
        /// Gets the currently active dependencies.
        /// </summary>
        public List<DependencyItem> ActiveDependencies { get; private set; }

        /// <summary>
        /// Gets the origin depenendencies data.
        /// </summary>
        public List<DependencyOriginItem> OriginDependencies { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementLink">Relationship instance.</param>
        /// <param name="category">Category of the dependency item.</param>
        /// <param name="relationshipInfo">Relationship info.</param>
        /// <param name="roleInfo">Role info.</param>
        /// <returns></returns>
        public bool Contains(ElementLink elementLink, DependencyItemCategory category, DomainRelationshipInfo relationshipInfo, DomainRoleInfo roleInfo)
        {
            foreach (DependencyItem item in ActiveDependencies)
                if (item.ElementLink == elementLink &&
                    item.Category == category &&
                    item.RelationshipInfo == relationshipInfo &&
                    item.RoleInfo == roleInfo)
                    return true;

            return false;
        }
    }
}

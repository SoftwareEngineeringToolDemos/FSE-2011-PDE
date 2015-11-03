using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyItem : DependencyOriginItem
    {
        private DependencyItemCategory itemCategory;
        private ElementLink elementLink;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="elementLink">Relationship instance.</param>
        /// <param name="category">Category of the dependency item.</param>
        /// <param name="relationshipInfo">Relationship info.</param>
        /// <param name="roleInfo">Role info.</param>
        public DependencyItem(ElementLink elementLink, DependencyItemCategory category, DomainRelationshipInfo relationshipInfo, DomainRoleInfo roleInfo)
            : base(elementLink.Id, relationshipInfo, roleInfo)
        {
            this.elementLink = elementLink;
            this.itemCategory = category;
        }

        /// <summary>
        /// Gets the dependency items category.
        /// </summary>
        public DependencyItemCategory Category
        {
            get
            {
                return this.itemCategory;
            }
        }

        /// <summary>
        /// Gets the relationship instance.
        /// </summary>
        public ElementLink ElementLink
        {
            get
            {
                return this.elementLink;
            }
        }

        /// <summary>
        /// Gets the source element.
        /// </summary>
        public ModelElement SourceElement
        {
            get
            {
                if (ElementLink == null)
                    return null;

                if (ElementLink.Store == null)
                    return null;

                return DomainRoleInfo.GetSourceRolePlayer(ElementLink);
            }
        }

        /// <summary>
        /// Gets the target element.
        /// </summary>
        public ModelElement TargetElement
        {
            get
            {
                if (ElementLink == null)
                    return null;

                if (ElementLink.Store == null)
                    return null;

                return DomainRoleInfo.GetTargetRolePlayer(ElementLink);
            }
        }

    }
}


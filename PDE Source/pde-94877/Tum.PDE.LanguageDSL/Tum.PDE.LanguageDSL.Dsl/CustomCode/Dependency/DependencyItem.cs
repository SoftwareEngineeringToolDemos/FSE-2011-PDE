using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyItem
    {
        private DependencyItemCategory itemCategory;
        private ElementLink elementLink;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="elementLink">Relationship instance.</param>
        /// <param name="category">Category of the dependency item.</param>
        public DependencyItem(ElementLink elementLink, DependencyItemCategory category, ModelElement source, ModelElement target)
        {
            this.elementLink = elementLink;
            this.itemCategory = category;
            this.SourceElement = source;
            this.TargetElement = target;
            this.Message = null;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="elementLink">Relationship instance.</param>
        /// <param name="category">Category of the dependency item.</param>
        public DependencyItem(string message, DependencyItemCategory category, ModelElement source, ModelElement target)
        {
            this.elementLink = null;
            this.itemCategory = category;
            this.SourceElement = source;
            this.TargetElement = target;
            this.Message = message;
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
            get;
            private set;
        }

        /// <summary>
        /// Gets the target element.
        /// </summary>
        public ModelElement TargetElement
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get;
            private set;
        }

    }
}

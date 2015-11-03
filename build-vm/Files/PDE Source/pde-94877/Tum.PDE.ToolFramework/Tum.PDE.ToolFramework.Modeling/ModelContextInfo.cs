using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class contains model context reflection info.
    /// </summary>
    public class ModelContextInfo
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelContextId">Id of the model context.</param>
        /// <param name="domainModelId">DomainClassId of the root domain class.</param>
        public ModelContextInfo(Guid modelContextId, Guid domainModelId)
        {
            this.ModelContextId = modelContextId;
            this.DomainModelId = domainModelId;
        }

        /// <summary>
        /// Gets the model context id.
        /// </summary>
        public Guid ModelContextId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the domain model id.
        /// </summary>
        public Guid DomainModelId
        {
            get;
            private set;
        }
    }
}

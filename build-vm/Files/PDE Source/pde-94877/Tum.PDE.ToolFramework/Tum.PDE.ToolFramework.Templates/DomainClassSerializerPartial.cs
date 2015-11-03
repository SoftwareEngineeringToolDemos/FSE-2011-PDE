using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates
{
    public partial class DomainClassSerializer
    {
        private static DomainClassSerializer instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the domainproperty class.
        /// </summary>
        public static DomainClassSerializer Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new DomainClassSerializer();

                return instanceHolder;
            }
        }
    }
}

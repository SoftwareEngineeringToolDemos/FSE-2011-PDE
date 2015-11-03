using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates
{
    public partial class DomainEnumerationGenerator
    {
        private static DomainEnumerationGenerator instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the domainproperty class.
        /// </summary>
        public static DomainEnumerationGenerator Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new DomainEnumerationGenerator();

                return instanceHolder;
            }
        }
    }
}

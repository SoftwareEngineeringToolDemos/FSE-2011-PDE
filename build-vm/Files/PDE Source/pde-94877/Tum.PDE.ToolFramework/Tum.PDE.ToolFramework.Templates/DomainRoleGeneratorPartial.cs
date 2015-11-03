using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates
{
    public partial class DomainRoleGenerator
    {
        private static DomainRoleGenerator instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the domainrole generator class.
        /// </summary>
        public static DomainRoleGenerator Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new DomainRoleGenerator();

                return instanceHolder;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates
{
    public partial class ClosuresGenerator
    {
        private static ClosuresGenerator instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the domainproperty class.
        /// </summary>
        public static ClosuresGenerator Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new ClosuresGenerator();

                return instanceHolder;
            }
        }
    }
}

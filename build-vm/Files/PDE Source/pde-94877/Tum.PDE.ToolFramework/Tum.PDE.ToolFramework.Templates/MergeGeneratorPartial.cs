using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates
{
    public partial class MergeGenerator
    {
        private static MergeGenerator instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the MergeGenerator class.
        /// </summary>
        public static MergeGenerator Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new MergeGenerator();

                return instanceHolder;
            }
        }
    }
}

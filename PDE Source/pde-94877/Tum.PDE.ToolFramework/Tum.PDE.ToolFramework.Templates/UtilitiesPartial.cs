using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates
{
    public partial class Utilities
    {
        private static Utilities instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the utilities class.
        /// </summary>
        public static Utilities Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new Utilities();

                return instanceHolder;
            }
        }
    }
}

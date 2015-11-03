using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates.ViewModel
{
    public partial class DiagramGeneratorHelper
    {
        private static DiagramGeneratorHelper instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the DiagramGeneratorHelper class.
        /// </summary>
        public static DiagramGeneratorHelper Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new DiagramGeneratorHelper();

                return instanceHolder;
            }
        }
    }
}

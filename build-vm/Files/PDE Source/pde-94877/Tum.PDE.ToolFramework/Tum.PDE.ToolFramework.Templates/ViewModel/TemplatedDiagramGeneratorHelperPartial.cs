using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates.ViewModel
{
    public partial class TemplatedDiagramGeneratorHelper
    {
        private static TemplatedDiagramGeneratorHelper instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the TemplatedDiagramGeneratorHelper class.
        /// </summary>
        public static TemplatedDiagramGeneratorHelper Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new TemplatedDiagramGeneratorHelper();

                return instanceHolder;
            }
        }
    }
}

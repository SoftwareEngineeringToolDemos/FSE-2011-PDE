using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates.ViewModel
{
    public partial class CodeExamplesGeneratorHelper
    {
        private static CodeExamplesGeneratorHelper instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the CodeExamplesGeneratorHelper class.
        /// </summary>
        public static CodeExamplesGeneratorHelper Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new CodeExamplesGeneratorHelper();

                return instanceHolder;
            }
        }
    }
}

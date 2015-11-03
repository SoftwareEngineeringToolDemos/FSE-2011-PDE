using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Templates.ViewModel.WPFApplication
{
    public partial class RibbonGeneratorHelper
    {
        private static RibbonGeneratorHelper instanceHolder = null;

        /// <summary>
        /// Gets a singleton instance of the RibbonGeneratorHelper class.
        /// </summary>
        public static RibbonGeneratorHelper Instance
        {
            get
            {
                if (instanceHolder == null)
                    instanceHolder = new RibbonGeneratorHelper();

                return instanceHolder;
            }
        }
    }
}

using System.Collections.Generic;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// This class is used to gather dependency items as well as additional data which may be required when dealing with dependencies.
    /// </summary>
    public class DependenciesData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DependenciesData()
        {
            ActiveDependencies = new List<DependencyItem>();
        }

        /// <summary>
        /// Gets the currently active dependencies.
        /// </summary>
        public List<DependencyItem> ActiveDependencies { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data
{
    /// <summary>
    /// This class is used to register services.
    /// </summary>
    public abstract class ServiceRegistrar
    {
        /// <summary>
        /// Register services to the given store.
        /// </summary>
        /// <param name="store">ViewModelStore.</param>
        public abstract void RegisterServices(ViewModelStore store);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Contracts
{
    /// <summary>
    /// Model plugin plugin interface.
    /// </summary>
    public interface IModelPlugin : IPlugin
    {
        /// <summary>
        /// Sets the view model store.
        /// </summary>
        /// <param name="store">View model store.</param>
        void SetViewModelStore(ViewModelStore store);
    }
}

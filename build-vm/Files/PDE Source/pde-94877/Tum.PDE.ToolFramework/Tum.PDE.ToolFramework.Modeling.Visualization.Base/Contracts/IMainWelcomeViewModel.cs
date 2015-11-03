using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Contracts
{
    /// <summary>
    /// Interface identifying a main welcome vm.
    /// </summary>
    public interface IMainWelcomeViewModel
    {
        /// <summary>
        /// Event handler, called once a model open request has been initiated.
        /// </summary>
        event EventHandler<Tum.PDE.ToolFramework.Modeling.Visualization.Base.ViewModel.MainWelcomeViewModel.OpenModelEventArgs> OpenModelRequested;
    }
}

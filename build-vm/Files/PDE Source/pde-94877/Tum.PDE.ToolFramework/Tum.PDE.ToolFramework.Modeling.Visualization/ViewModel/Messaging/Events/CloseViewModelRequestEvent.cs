using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Event, requesting a docking view model to be closed by the main view model.
    /// </summary>
    public class CloseViewModelRequestEvent : ViewModelEvent<CloseViewModelRequestEventArgs>
    {
    }
}

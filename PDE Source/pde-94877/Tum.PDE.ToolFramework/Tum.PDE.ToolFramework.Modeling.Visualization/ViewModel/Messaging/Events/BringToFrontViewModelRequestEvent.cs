using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Event, requesting a docking view model to be brought to front by the main view model.
    /// </summary>
    public class BringToFrontViewModelRequestEvent : ViewModelEvent<BringToFrontViewModelRequestEventArgs>
    {
    }
}

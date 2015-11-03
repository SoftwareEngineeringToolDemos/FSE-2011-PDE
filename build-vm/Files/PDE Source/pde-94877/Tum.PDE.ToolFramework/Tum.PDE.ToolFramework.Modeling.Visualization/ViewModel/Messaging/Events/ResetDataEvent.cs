using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging;
using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Event, that notifies that data needs to be reset. This should be sent within
    /// a transaction context.
    /// </summary>
    public class ResetDataEvent : ViewModelEvent<EventArgs>
    {
    }
}

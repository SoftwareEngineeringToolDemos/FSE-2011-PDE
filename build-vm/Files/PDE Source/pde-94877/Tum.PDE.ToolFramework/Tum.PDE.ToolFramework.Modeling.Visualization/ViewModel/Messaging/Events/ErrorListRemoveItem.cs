using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Event to notify that specific error list item need to be removed from the error list.
    /// </summary>
    public class ErrorListRemoveItem : ViewModelEvent<Guid>
    {
    }
}

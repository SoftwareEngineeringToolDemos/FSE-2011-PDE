using System.Collections.Generic;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Event to notify that error list items need to be added to the error list.
    /// </summary>
    public class ErrorListAddItems : ViewModelEvent<List<BaseErrorListItemViewModel>>
    {
    }
}

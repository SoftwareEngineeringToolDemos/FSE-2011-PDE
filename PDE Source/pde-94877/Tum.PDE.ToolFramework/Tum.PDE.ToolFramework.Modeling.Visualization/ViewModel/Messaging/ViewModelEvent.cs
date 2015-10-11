using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism.Presentation;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging
{
    /// <summary>
    /// Generic Viewmodel event.
    /// </summary>
    /// <typeparam name="T">Type of the event args data..</typeparam>
    public class ViewModelEvent<T> : CompositePresentationEvent<T>
    {
    }
}

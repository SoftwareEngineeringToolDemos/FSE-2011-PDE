using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies of a new model element beeing added to the domain model.
    /// 
    /// An observer can either subscribe to the event in general (Warning, this will provide a notification for each 
    /// new domain element) or subscribe to a more specific event.
    /// 
    /// This specific event allows to provide a domain class info of the model element, on which addition the
    /// given action is called (for alle other elements, the action is ignored).
    /// </summary>
    /// <remarks>
    /// These events are treated as a weak events.
    /// </remarks>
    public class ModelElementAddedEvent : ModelElementEvent<ElementAddedEventArgs>
    {
    }
}

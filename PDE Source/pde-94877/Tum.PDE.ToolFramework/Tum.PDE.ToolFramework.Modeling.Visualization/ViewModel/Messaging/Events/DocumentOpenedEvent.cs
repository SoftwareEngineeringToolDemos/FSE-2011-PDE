using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism.Presentation;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies after a document has been opened.
    /// </summary>
    public class DocumentOpenedEvent : CompositePresentationEvent<DocumentEventArgs>
    {
    }
}

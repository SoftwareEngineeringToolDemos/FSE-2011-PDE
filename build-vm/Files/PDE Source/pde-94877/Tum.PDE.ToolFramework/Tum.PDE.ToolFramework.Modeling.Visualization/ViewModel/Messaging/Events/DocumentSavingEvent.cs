using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism.Presentation;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies during the saving process of an opened document.
    /// </summary>
    public class DocumentSavingEvent : CompositePresentationEvent<DocumentEventArgs>
    {
    }
}

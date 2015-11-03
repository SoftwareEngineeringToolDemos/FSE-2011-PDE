using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging
{
    /// <summary>
    /// This is the main event manager, that is derived from Prism's EventAggregator (EventAggregator pattern).
    /// 
    /// We use this for communication between viewmodels (Viewmodels are not aware of each other!).
    /// </summary>
    public class ViewModelEventManager : EventAggregator
    {
    }
}

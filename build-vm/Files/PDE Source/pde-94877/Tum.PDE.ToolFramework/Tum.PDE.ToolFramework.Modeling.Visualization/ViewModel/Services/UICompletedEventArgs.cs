using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services
{
    /// <summary>
    /// This is the EventArgs return value for the IUIController.Show completed event.
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public class UICompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Data passed to the Show method.
        /// </summary>
        public object State { get; set; }
        /// <summary>
        /// Final result of the UI dialog
        /// </summary>
        public bool? Result { get; set; }
    }
}

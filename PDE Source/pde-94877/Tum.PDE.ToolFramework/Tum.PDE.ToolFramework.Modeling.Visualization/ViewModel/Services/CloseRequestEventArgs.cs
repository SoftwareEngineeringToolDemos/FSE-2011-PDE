using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services
{
    /// <summary>
    /// This is used to send result parameters to a CloseRequest
    /// </summary>
    /// <remarks>
    /// From the Cinch framework by Sacha Barber: http://cinch.codeplex.com/
    /// </remarks>
    public class CloseRequestEventArgs : EventArgs
    {
        ///<summary>
        /// Final result for ShowDialog
        ///</summary>
        public bool? Result { get; private set; }

        internal CloseRequestEventArgs(bool? result)
        {
            Result = result;
        }
    }
}

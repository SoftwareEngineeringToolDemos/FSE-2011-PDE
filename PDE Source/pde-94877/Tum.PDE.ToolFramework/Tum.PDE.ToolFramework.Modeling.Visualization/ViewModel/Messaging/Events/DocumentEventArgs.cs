using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Document event arguments.
    /// </summary>
    public class DocumentEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Model data.</param>
        public DocumentEventArgs(ModelData data)
        {
            this.ModelData = data;
        }

        /// <summary>
        /// Gets or sets the model data.
        /// </summary>
        public ModelData ModelData
        {
            get;
            set;
        }
    }
}

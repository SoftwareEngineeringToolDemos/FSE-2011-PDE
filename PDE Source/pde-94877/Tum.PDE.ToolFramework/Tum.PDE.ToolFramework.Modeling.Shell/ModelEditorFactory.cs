using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling.Shell;

namespace Tum.PDE.ToolFramework.Modeling.Shell
{
    /// <summary>
    /// Factory for creating our editors
    /// </summary>
    public abstract class ModelEditorFactory : ModelingEditorFactory
    {
        /// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="serviceProvider">Service provider used to access VS services.</param>
        protected ModelEditorFactory(global::System.IServiceProvider serviceProvider)
            : base(serviceProvider)
		{
		}


        
        /// <summary>
        /// Gets or sets the model data.
        /// </summary>
        public ModelShellData ModelData
        {
            get;
            set;
        }
    }
}

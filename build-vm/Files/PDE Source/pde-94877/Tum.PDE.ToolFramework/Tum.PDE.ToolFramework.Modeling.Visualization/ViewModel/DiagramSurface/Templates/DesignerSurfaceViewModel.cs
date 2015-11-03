using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface
{
    /// <summary>
    /// This is a diagram surface view model that can display the properties of any element dragged on it.
    /// </summary>
    /// <remarks>
    /// The displayed properties include Parent element, Child elements as well as Referenced elements.
    /// </remarks>
    public abstract class DesignerSurfaceViewModel : BaseDiagramSurfaceViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Model context.</param>
        protected DesignerSurfaceViewModel(ViewModelStore viewModelStore, ModelContext modelContext)
            : base(viewModelStore, modelContext)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContextName">Model context name.</param>
        protected DesignerSurfaceViewModel(ViewModelStore viewModelStore, string modelContextName)
            : base(viewModelStore, modelContextName)
        {
        }

        // TODO
    }
}

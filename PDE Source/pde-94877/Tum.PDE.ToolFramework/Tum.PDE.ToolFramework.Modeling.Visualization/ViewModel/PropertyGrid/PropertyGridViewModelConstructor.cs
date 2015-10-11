using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// Represents the method that decides if the given element should be removed from the collection or not.
    /// </summary>
    /// <typeparam name="T">The type of the element. </typeparam>
    /// <returns>Created PropertyGridEditorViewModel for this element. False otherwise.</returns>
    public delegate PropertyGridEditorViewModel PropertyGridViewModelConstructor<T>(T modelElement);
}

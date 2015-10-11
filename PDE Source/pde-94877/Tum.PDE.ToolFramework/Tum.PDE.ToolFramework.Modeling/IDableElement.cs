using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes an element that has an id parameter and which id is 
    /// required to be tested in terms of uniqueness.
    /// </summary>
    public interface IDableElement
    {
        /// <summary>
        /// Gets the id of the element.
        /// </summary>
        Guid Id { get; }
    }
}

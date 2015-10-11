using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface describes a parent model element. There can be multiple domain model
    /// parent elements (this is because we can have multiple contexts within one dsl).
    /// </summary>
    public interface IParentModelElement
    {
        /// <summary>
        /// Gets or sets the domain file path.
        /// </summary>
        string DomainFilePath { get; set; }
    }
}

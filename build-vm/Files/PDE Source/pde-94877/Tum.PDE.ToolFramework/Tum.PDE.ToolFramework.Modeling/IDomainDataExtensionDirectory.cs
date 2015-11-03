using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Interface of an extension directory.
    /// </summary>
    public interface IDomainDataExtensionDirectory
    {
        /// <summary>
        /// Process and initialize the contained data.
        /// </summary>
        void Process();

        /// <summary>
        /// Merges the current directory with an additional directory.
        /// </summary>
        /// <param name="data">Directory</param>
        void Merge(IDomainDataExtensionDirectory data);

        /// <summary>
        /// Gets the type of the extension.
        /// </summary>
        /// <returns>Type of the extension.</returns>
        Type GetExtensionType();
    }
}

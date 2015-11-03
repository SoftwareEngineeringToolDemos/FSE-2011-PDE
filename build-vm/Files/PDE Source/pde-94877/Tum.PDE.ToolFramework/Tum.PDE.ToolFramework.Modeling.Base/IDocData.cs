using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Base.Contracts
{
    /// <summary>
    /// Interface identifying document data.
    /// </summary>
    public interface IDocData
    {
        /// <summary>
        /// Initialize asynchronous.
        /// </summary>
        void InitAsync();

        /// <summary>
        /// Dispose.
        /// </summary>
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public abstract partial class DiagramsDSLSerializationHelperBase
    {
        /// <summary>
        /// Initializes serialization.
        /// </summary>
        /// <param name="store">Store.</param>
        public void Initialize(Store store)
        {
            this.InitializeSerialization(store);
        }
    }

}

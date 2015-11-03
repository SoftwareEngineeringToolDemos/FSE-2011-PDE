using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Moniker resolver for serialization behavior TestDslDefinitionSerializationBehavior.
    /// </summary>
    public partial class TestDslDefinitionSerializationBehaviorMonikerResolver
    {
        /// <summary>
        /// Moniker resolvement logic.
        /// </summary>
        /// <param name="moniker"></param>
        /// <returns></returns>
        public override Microsoft.VisualStudio.Modeling.ModelElement ResolveMoniker(Microsoft.VisualStudio.Modeling.Moniker moniker)
        {
            Guid id = new Guid(moniker.MonikerName);
            return moniker.Store.ElementDirectory.FindElement(id);
        }
    }
}

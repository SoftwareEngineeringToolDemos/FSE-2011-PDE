using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    /// <summary>
    /// Class used to represent info needed to create model tree view model and its context menus
    /// </summary>
    public class ModelTreeChildElementCreationInfo
    {
        /// <summary>
        /// Domain Role representing the role of the embedding relationship which role player can be embedded.
        /// </summary>
        public DomainRole Role { get; set; }

        /// <summary>
        /// Target elements that can be embedded.
        /// </summary>
        public List<AttributedDomainElement> TargetElements { get; set; }
    }
}

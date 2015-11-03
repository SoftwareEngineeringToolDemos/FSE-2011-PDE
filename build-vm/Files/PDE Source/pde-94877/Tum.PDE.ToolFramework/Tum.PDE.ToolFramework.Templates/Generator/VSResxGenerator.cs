using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class VSResxGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new DomainModelResxGenerator(), "DomainModelResx.resx", T4Toolbox.BuildAction.EmbeddedResource, new UTF8Encoding());


        }
    }
}

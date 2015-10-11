using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates.Generator
{
    public class DefaultModelGenerator : BaseGenerator
    {
        /// <summary>
        /// Generates output files.
        /// </summary>
        protected override void RunCore()
        {
            this.Run(new DiagramGenerator(), "Diagrams.cs");
            this.Run(new DiagramsLinkRulesGenerator(), "DiagramsLinkRules.cs");
            this.Run(new DiagramsRulesGenerator(), "DiagramsRules.cs");
            this.Run(new DiagramsSerializerGenerator(), "DiagramsSerializer.cs");
            this.Run(new DiagramsSerializerHelperGenerator(), "DiagramsSerializerHelper.cs");
            this.Run(new DocumentDataGenerator(), "DocumentData.cs");
            this.Run(new DomainClassGenerator(), "DomainClasses.cs");
            this.Run(new DomainModelGenerator(), "DomainModel.cs");
            this.Run(new DomainModelDependenciesGenerator(), "DomainModelDependencies.cs");
            this.Run(new DomainModelIdProviderGenerator(), "DomainModelIdProvider.cs");
            this.Run(new DomainModelServicesGenerator(), "DomainModelServices.cs");
            this.Run(new DomainRelationshipGenerator(), "DomainRelationships.cs");
            this.Run(new DomainValidationGenerator(), "DomainValidation.cs");
            this.Run(new ModelContextGenerator(), "ModelContexts.cs");
            this.Run(new SearchProcessorGenerator(), "SearchProcessor.cs");
            this.Run(new SerializationHelperGenerator(), "SerializationHelper.cs");
            this.Run(new SerializerGenerator(), "Serializer.cs");
            this.Run(new ShapesGenerator(), "Shapes.cs");
            this.Run(new DomainModelResxGenerator(), "DomainModelResx.resx", T4Toolbox.BuildAction.EmbeddedResource, new UTF8Encoding());
        }
    }
}

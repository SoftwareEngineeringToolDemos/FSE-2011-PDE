using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static bool GenerateSpecificVMHandlerForRole(DomainClass domainClass, DomainRole role)
        {
            if (role.Relationship.InheritanceModifier == InheritanceModifier.Abstract)
                return false;

            if (role.Relationship.Source != role)
            {
                if (!domainClass.GenerateSpecificViewModelOppositeReferences)
                    return false;

                if (!(role.Relationship is ReferenceRelationship))
                    return false;
            }

            //if( !role.IsPropertyGenerator )
            //	continue;

            if (role.Relationship is EmbeddingRelationship && !domainClass.GenerateSpecificViewModelEmbeddings)
                return false;

            if (role.Relationship is ReferenceRelationship && !domainClass.GenerateSpecificViewModelReferences)
                if (role.Relationship.Source == role)
                    return false;

            return true;
        }
    }
}

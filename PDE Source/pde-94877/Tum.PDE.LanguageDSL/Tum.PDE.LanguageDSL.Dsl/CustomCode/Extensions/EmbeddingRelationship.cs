using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class EmbeddingRelationship
    {
        /// <summary>
        /// Generates the name of the given relationship based on the names of the embedded domain roles.
        /// </summary>
        /// <param name="rel">Relationship to generate the name for.</param>
        /// <returns>Name of the relationship as string.</returns>
        public static string GenerateDomainRelationshipName(DomainRelationship rel)
        {
            return rel.Source.Name + "Has" + rel.Target.Name;
        }
    }
}

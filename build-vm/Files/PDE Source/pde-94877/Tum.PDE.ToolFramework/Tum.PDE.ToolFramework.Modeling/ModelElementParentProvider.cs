using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class which retrieves parent elements for domain classes.
    /// </summary>
    public class ModelElementParentProvider : IModelElementParentProvider
    {
        /// <summary>
        /// Gets the embedding domain model for a given model element. The embedding domain model
        /// is the domain model that contains the given model element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the embedding domain model for.</param>
        /// <returns>Domain model as ModelElement if found. Null otherwise.</returns>
        public virtual IParentModelElement GetParentModelElement(ModelElement modelElement)
        {
            ModelElement m = modelElement;
            while (m != null)
            {
                m = GetEmbeddingParent(m);
                if (m is IParentModelElement)
                    return m as IParentModelElement;
            }

            if (modelElement is IParentModelElement)
                return modelElement as IParentModelElement;

            return null;
        }

        /// <summary>
        /// Gets the embedding domain element for a given model element. The embedding domain element
        /// is the parent domain element that is embedding the given model domain element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the embedding domain element for.</param>
        /// <returns>Domain element as ModelElement if found. Null otherwise</returns>
        public virtual ModelElement GetEmbeddingParent(ModelElement modelElement)
        {
            if (!(modelElement is DomainModelElement))
                return null;

            List<EmbeddingRelationshipAdvancedInfo> embeddings = (modelElement as DomainModelElement).Store.DomainDataAdvDirectory.FindDomainClassTargetEmbeddings((modelElement as DomainModelElement).GetDomainClassId());
            if( embeddings != null )
                foreach (EmbeddingRelationshipAdvancedInfo emb in embeddings)
                {
                    IList<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, emb.TargetRoleId);
                    if (links.Count == 1)
                    {
                        return DomainRoleInfo.GetSourceRolePlayer(links[0]);
                    }
                }
            /*
            if (!(modelElement is IDomainModelOwnable))
                return null;

            DomainClassInfo info = modelElement.GetDomainClass();
            foreach (DomainRoleInfo roleInfo in info.AllDomainRolesPlayed)
            {
                if (!roleInfo.IsSource)
                {
                    DomainRelationshipAdvancedInfo infoAdv = (modelElement as IDomainModelOwnable).Store.DomainDataAdvDirectory.FindRelationshipInfo(roleInfo.DomainRelationship.Id);
                    if (infoAdv == null)
                        return null;

                    if (infoAdv is EmbeddingRelationshipAdvancedInfo)
                    {
                        global::System.Collections.Generic.IList<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, roleInfo.Id);
                        if (links.Count == 1)
                        {
                            return DomainRoleInfo.GetSourceRolePlayer(links[0]);
                        }
                    }
                }
            }*/

            return null;
        }

        /// <summary>
        /// Gets the embedding domain element of a specific type for a given model element.
        /// </summary>
        /// <param name="modelElement">ModelElement to get the embedding domain element for.</param>
        /// <param name="parentTypeDomainClassId">Type of the embedding domain element to find.</param>
        /// <returns>Domain element as ModelElement if found. Null otherwise</returns>
        public virtual ModelElement GetEmbeddingParent(ModelElement modelElement, System.Guid parentTypeDomainClassId)
        {
            if (!(modelElement is DomainModelElement))
                return null;

            List<EmbeddingRelationshipAdvancedInfo> embeddings = (modelElement as DomainModelElement).Store.DomainDataAdvDirectory.FindDomainClassTargetEmbeddings((modelElement as DomainModelElement).GetDomainClassId());
            if( embeddings != null )
                foreach (EmbeddingRelationshipAdvancedInfo emb in embeddings)
                {
                    IList<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, emb.TargetRoleId);
                    if (links.Count == 1)
                    {
                        ModelElement m = DomainRoleInfo.GetSourceRolePlayer(links[0]);
                        if (m.GetDomainClass().IsDerivedFrom(parentTypeDomainClassId))
                            return m;

                        return GetEmbeddingParent(m, parentTypeDomainClassId);
                    }
                }

            return null;
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Class which retrieves children elements domain classes.
    /// </summary>
    public class ModelElementChildrenProvider : IModelElementChildrenProvider
    {
        /// <summary>
        /// Retrieves all children of a specific parent element. This includes all model elements that are reachable
        /// from the parent element through the embedding relationship.
        /// </summary>
        /// <param name="parentElement">Parent element to retrieve children for.</param>
        /// <param name="bOnlyLocal">Specifies if children of the found children of the given element should be processed too.</param>
        /// <returns>List of model elements that are embedded under the parent element. May be empty.</returns>
        public virtual List<ModelElement> GetChildren(ModelElement parentElement, bool bOnlyLocal)
        {
            List<ModelElement> allChildren = new List<ModelElement>();

            DomainClassInfo info = parentElement.GetDomainClass();
            ReadOnlyCollection<DomainRoleInfo> roleInfoCol = info.AllDomainRolesPlayed;

            foreach (DomainRoleInfo roleInfo in roleInfoCol)
            {
                if (roleInfo.IsSource)
                    if ((parentElement as IDomainModelOwnable).Store.DomainDataAdvDirectory.IsEmbeddingRelationship(roleInfo.DomainRelationship.Id))
                    {
                        global::System.Collections.Generic.IList<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(parentElement, roleInfo.Id);
                        foreach (ElementLink link in links)
                        {
                            ModelElement child = DomainRoleInfo.GetTargetRolePlayer(link);
                            allChildren.Add(child);

                            if (!bOnlyLocal)
                            {
                                allChildren.AddRange(
                                    (child as IDomainModelOwnable).GetDomainModelServices().ElementChildrenProvider.GetChildren(child, bOnlyLocal));

                            }
                        }
                    }
            }

            return allChildren;
        }
    }
}

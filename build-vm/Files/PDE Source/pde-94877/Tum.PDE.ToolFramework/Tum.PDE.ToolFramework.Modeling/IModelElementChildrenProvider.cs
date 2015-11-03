using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This interface ensures what methods a children provider for domain elements is bound to have. The
    /// children provider needs to be able to retrieve children elements for any domain element. 
    /// </summary>
    public interface IModelElementChildrenProvider
    {
        /*
        /// <summary>
        /// Retrieves all local children of a specific parent element.
        /// </summary>
        /// <param name="parentElement">Parent element to retrieve children for.</param>
        /// <returns>List of model elements that are embedded directly under the parent element. May be empty.</returns>
        List<ModelElement> GetChildrenLocal(ModelElement parentElement);

        /// <summary>
        /// Retrieves all local children of a specific parent element.
        /// </summary>
        /// <param name="parentElement">Parent element to retrieve children for.</param>
        /// <param name="servicesToDiscard">Services to discard.</param>
        /// <returns>List of model elements that are embedded directly under the parent element. May be empty.</returns>
        List<ModelElement> GetChildrenLocal(ModelElement parentElement, System.Collections.Generic.List<IDomainModelServices> servicesToDiscard);
        */

        /// <summary>
        /// Retrieves all children of a specific parent element. This includes all model elements that are reachable
        /// from the parent element through the embedding relationship.
        /// </summary>
        /// <param name="parentElement">Parent element to retrieve children for.</param>
        /// <param name="bOnlyLocal">Specifies if children of the found children of the given element should be processed too.</param>
        /// <returns>List of model elements that are embedded under the parent element. May be empty.</returns>
        List<ModelElement> GetChildren(ModelElement parentElement, bool bOnlyLocal);
    }
}

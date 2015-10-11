using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Helper class to store shape mapping information on the instance level.
    /// </summary>
    public static class DiagramsShapeStore
    {
        static Dictionary<Guid, List<Guid>> shapeMapping = new Dictionary<Guid, List<Guid>>();

        /// <summary>
        /// Add element and its shape mapping to store.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="shape">Shape.</param>
        public static void AddToStore(Guid element, Guid shape)
        {
            if (!shapeMapping.ContainsKey(element))
                shapeMapping.Add(element, new List<Guid>());

            if( !shapeMapping[element].Contains(shape) )
                shapeMapping[element].Add(shape);
        }

        /// <summary>
        /// Remove element and its shape mapping from store.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="shape">Shape.</param>
        public static void RemoveFromStore(Guid element, Guid shape)
        {
            if (shapeMapping.ContainsKey(element))
                if (shapeMapping[element].Contains(shape))
                {
                    shapeMapping[element].Remove(shape);
                    if (shapeMapping[element].Count == 0)
                        shapeMapping.Remove(element);
                }
        }

        /// <summary>
        /// Remove element and its shape mappings from store.
        /// </summary>
        /// <param name="element">Element.</param>
        public static void RemoveFromStore(Guid element)
        {
            if (shapeMapping.ContainsKey(element))
                shapeMapping.Remove(element);
        }

        /// <summary>
        /// Gets a list of shape mappings from store for a specified element.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <returns>List of shape Ids.</returns>
        public static List<Guid> GetFromStore(Guid element)
        {
            List<Guid> shapes;
            shapeMapping.TryGetValue(element, out shapes);

            if (shapes == null)
                return new List<Guid>();
            return shapes;
        }
    }
}

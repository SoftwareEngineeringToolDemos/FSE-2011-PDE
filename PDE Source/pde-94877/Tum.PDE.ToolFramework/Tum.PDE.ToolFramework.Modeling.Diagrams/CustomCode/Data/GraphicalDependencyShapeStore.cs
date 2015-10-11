using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public static class GraphicalDependencyShapeStore
    {
        static Dictionary<Guid, List<Guid>> shapeMapping = new Dictionary<Guid, List<Guid>>();

        public static void AddToStore(Guid element, Guid shape)
        {
            if (!shapeMapping.ContainsKey(element))
                shapeMapping.Add(element, new List<Guid>());

            if( !shapeMapping[element].Contains(shape) )
                shapeMapping[element].Add(shape);
        }
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
        public static void RemoveFromStore(Guid element)
        {
            if (shapeMapping.ContainsKey(element))
                shapeMapping.Remove(element);
        }

        public static List<Guid> GetFromStore(Guid element)
        {
            List<Guid> shapes;
            shapeMapping.TryGetValue(element, out shapes);

            return shapes;
        }
    }
}

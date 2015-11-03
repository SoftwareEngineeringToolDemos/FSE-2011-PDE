using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Graphical dependency shape.
    /// </summary>
    public partial class GraphicalDependencyShape
    {
        /// <summary>
        /// Add to shape mapping override.
        /// </summary>
        /// <param name="shapeElement"></param>
        public override void AddToShapeMapping(ShapeElement shapeElement)
        {

            GraphicalDependencyShapeStore.AddToStore(shapeElement.Element.Id, shapeElement.Id);
            //base.AddToShapeMapping(shapeElement, true);            
        }

        /// <summary>
        /// Remove from shape mapping override.
        /// </summary>
        /// <param name="shapeElement"></param>
        public override void RemoveFromShapeMapping(ShapeElement shapeElement)
        {
            if (shapeElement.Element != null)
                GraphicalDependencyShapeStore.RemoveFromStore(shapeElement.Element.Id, shapeElement.Id);
            //base.RemoveFromShapeMapping(shapeElement, true);
        }
    }
}

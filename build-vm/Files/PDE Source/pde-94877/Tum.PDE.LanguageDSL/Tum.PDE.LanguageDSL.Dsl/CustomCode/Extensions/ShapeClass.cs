using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class ShapeClass
    {
        /// <summary>
        /// Verifies if a given shape class is within the children collection.
        /// </summary>
        /// <param name="shapeClass">ShapeClass to find.</param>
        /// <returns>True if the given shape class is within the children collection; False otherwise.</returns>
        public bool ContainsChild(ShapeClass shapeClass)
        {
            foreach (ShapeClass p in this.Children)
            {
                if (p == shapeClass)
                    return true;

                if (p.ContainsChild(shapeClass))
                    return true;
            }

            return false;
        }

        public override string ShapeType
        {
            get
            {
                return "ShapeClass";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Deletes shapes bound to deleted model elements.
    /// </summary>
    public abstract class ModelElementDeletingRuleForShapes : DeletingRule
    {
        private ShapeDeletionHelper deletionHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="deletionHelper">Shapes deletion helper instance.</param>
         protected ModelElementDeletingRuleForShapes(ShapeDeletionHelper deletionHelper)
            : base()
        {
            this.deletionHelper = deletionHelper;
        }

        /// <summary>
        /// Called whenever a model element is beeing deleted.
        /// </summary>
        /// <param name="e"></param>
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            base.ElementDeleting(e);

            DomainModelElement modelElement = e.ModelElement as DomainModelElement;
            deletionHelper.DeleteShapesForElement(modelElement);
        }

        /// <summary>
        /// Helper class.
        /// </summary>
        public abstract class ShapeDeletionHelper
        {            
            /// <summary>
            /// Constructor.
            /// </summary>
            protected ShapeDeletionHelper()
            {
            }

            /// <summary>
            /// Deletes all existing shapes mapped to the specified element.
            /// </summary>
            /// <param name="modelElement">Model element.</param>
            [CLSCompliant(false)]
            public void DeleteShapesForElement(DomainModelElement modelElement)
            {
                if (modelElement != null)
                {
                    List<Guid> shapes = DiagramsShapeStore.GetFromStore(modelElement.Id);
                    if (shapes != null)
                        for (int i = shapes.Count - 1; i >= 0; i--)
                        {
                            NodeShape shape = modelElement.Store.ElementDirectory.FindElement(shapes[i]) as NodeShape;
                            if (shape != null)
                                shape.Delete();
                        }
                }
            }
        }
    }
}

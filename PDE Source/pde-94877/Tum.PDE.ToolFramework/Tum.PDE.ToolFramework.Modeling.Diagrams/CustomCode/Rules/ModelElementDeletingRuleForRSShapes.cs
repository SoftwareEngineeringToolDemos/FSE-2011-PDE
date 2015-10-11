using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{   
    /// <summary>
    /// Deletes shapes bound to deleted model links/elements.
    /// </summary>
    public abstract class ModelElementDeletingRuleForRSShapes : DeletingRule
    {
         private ShapeDeletionHelper deletionHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="deletionHelper">Shapes deletion helper instance.</param>
         protected ModelElementDeletingRuleForRSShapes(ShapeDeletionHelper deletionHelper)
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

            if (e.ModelElement is DomainModelLink)
                deletionHelper.DeleteShapesForElement(e.ModelElement as DomainModelLink);
            
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
            /// <param name="element"></param>
            [CLSCompliant(false)]
            public void DeleteShapesForElement(DomainModelLink element)
            {
                if (element == null)
                    return;

                DomainModelLink link = element;
                DiagramDomainDataDirectory data = link.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();

                if (data.HasShapeForElement(link.GetDomainClassId()))
                    this.DeleteShapesForElement(link.Store, link.Id);
            }

            /// <summary>
            /// Deletes all existing shapes mapped to the specified element.
            /// </summary>
            /// <param name="store"></param>
            /// <param name="modelElementId"></param>
            [CLSCompliant(false)]
            public void DeleteShapesForElement(Store store, Guid modelElementId)
            {
                List<Guid> shapes = DiagramsShapeStore.GetFromStore(modelElementId);
                if (shapes != null)
                    for (int i = shapes.Count - 1; i >= 0; i--)
                    {
                        ShapeElement shape = store.ElementDirectory.FindElement(shapes[i]) as ShapeElement;
                        if (shape != null)
                            shape.Delete();
                    }
            }

            /// <summary>
            /// Deletes all existing shapes mapped to the specified element.
            /// </summary>
            /// <param name="store"></param>
            /// <param name="modelElementId"></param>
            /// <param name="shapeTypeId"></param>
            [CLSCompliant(false)]
            public void DeleteShapesForElement(Store store, Guid modelElementId, Guid shapeTypeId)
            {
                List<Guid> shapes = DiagramsShapeStore.GetFromStore(modelElementId);
                if (shapes != null)
                    for (int i = shapes.Count - 1; i >= 0; i--)
                    {
                        ShapeElement shape = store.ElementDirectory.FindElement(shapes[i]) as ShapeElement;
                        if (shape != null)
                            if (shape.GetDomainClass().Id == shapeTypeId)
                                shape.Delete();
                    }
            }
        }
    }
}

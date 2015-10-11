using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// This AddRule is for monitoring element creation that we need to reflect
    /// onto the diagram surface by creating its specified shape class.
    /// </summary>
    public abstract class ModelLinkAddRuleForShapes : AddRule
    {
        private ShapesFactoryHelper factoryHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factoryHelper">Shapes factory helper instance.</param>
        protected ModelLinkAddRuleForShapes(ShapesFactoryHelper factoryHelper)
            : base()
        {
            this.factoryHelper = factoryHelper;
        }

        /// <summary>
        /// Element added logic.
        /// </summary>
        /// <param name="e"></param>
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            base.ElementAdded(e);

            if (e.ModelElement as DomainModelElement == null)
                return;

            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            this.factoryHelper.AddShapesForElement(e.ModelElement as DomainModelElement);
        }

        /// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public abstract class ShapesFactoryHelper
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            protected ShapesFactoryHelper()
            {
            }

            /// <summary>
            /// Adds shapes for a given element.
            /// </summary>
            /// <param name="modelElement">Model element.</param>
            [CLSCompliant(false)]
            public virtual void AddShapesForElement(DomainModelElement modelElement)
            {
                DomainModelElement parent = modelElement.GetDomainModelServices().ElementParentProvider.GetEmbeddingParent(modelElement) as DomainModelElement;
                DomainModelElement child = modelElement;
                
                AddShapesForElement(parent, child);
            }

            /// <summary>
            /// Adds shapes for a given element.
            /// </summary>
            /// <param name="modelElement">Model element.</param>
            [CLSCompliant(false)]
            public virtual void AddRootShapesForElement(DomainModelElement modelElement)//, bool bIgnoreVisualizationBehavior)
            {
                DiagramDomainDataDirectory data = modelElement.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
                IDomainModelServices topMost = modelElement.GetDomainModelServices().TopMostService;

                List<Guid> shapeIds = data.GetRootShapeTypesForElement(modelElement.GetDomainClassId());
                if (shapeIds != null)
                    foreach (Guid shapeId in shapeIds)
                    {
                        ShapeClassInfo shapeInfo = data.ShapeClassInfos[shapeId];
                        ReadOnlyCollection<ModelElement> diagrams = modelElement.Store.ElementDirectory.FindElements(shapeInfo.DiagramClassType);
                        if (diagrams.Count == 0)
                            continue;
                        foreach (Diagram d in diagrams)
                        {
                            if (d.IsVisible && d.CanHostShape(shapeId))
                            {
                                if (!DiagramHelper.IsElementDisplayedOn(d, shapeId, modelElement.Id))
                                {
                                    NodeShape shape = topMost.ShapeProvider.CreateShapeForElement(shapeId, modelElement) as NodeShape;
                                    d.Children.Add(shape);
                                    DiagramsShapeStore.AddToStore(shape.Element.Id, shape.Id);
                                    shape.FixUpMissingLinkShapes();
                                }
                            }
                        }
                    }
            }

            /// <summary>
            /// Adds shapes for a given element.
            /// </summary>
            /// <param name="parent">Model element.</param>
            /// <param name="child"></param>
            internal void AddShapesForElement(DomainModelElement parent, DomainModelElement child)
            {
                if (parent == null || child == null)
                    return;

                DiagramDomainDataDirectory data = child.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
                IDomainModelServices topMost = child.GetDomainModelServices().TopMostService;

                // find parent shapes
                List<Guid> shapeIds = DiagramsShapeStore.GetFromStore(parent.Id);
                if (shapeIds != null)
                    foreach (Guid shapeId in shapeIds)
                    {
                        // see if each parent shape has a child shape already added to it
                        NodeShape parentShape = child.Store.ElementDirectory.FindElement(shapeId) as NodeShape;
                        if (parentShape == null)
                            continue;

                        foreach (Guid elementShapeId in data.GetShapeTypesForElement(child.GetDomainClassId(), parentShape.GetDomainClassId()))
                        {
                            if (!DiagramHelper.IsElementDisplayedOn(parentShape, elementShapeId, child.Id))
                            {
                                NodeShape shape = topMost.ShapeProvider.CreateShapeForElement(elementShapeId, child) as NodeShape;
                                if (shape.IsRelativeChildShape)
                                    parentShape.AddRelativeChild(shape);
                                else
                                    parentShape.AddNestedChild(shape);
                                shape.SetAtFreePositionOnParent();
                            }
                        }
                    }

                //AddRootShapesForElement(child, false);
                AddRootShapesForElement(child);
            }

            /// <summary>
            /// Adds shapes for a given element.
            /// </summary>
            /// <param name="con"></param>
            internal void AddShapesForElement(DomainModelLink con)
            {
                if (con == null)
                    return;

                DomainModelElement parent = DomainRoleInfo.GetSourceRolePlayer(con) as DomainModelElement;
                DomainModelElement child = DomainRoleInfo.GetTargetRolePlayer(con) as DomainModelElement;
                AddShapesForElement(parent, child);
            }
        }        
    }
}

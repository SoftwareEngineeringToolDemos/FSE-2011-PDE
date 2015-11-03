using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using System.Collections.ObjectModel;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// This AddRule is for monitoring link creation that we need to reflect
    /// onto the diagram surface by creating its specified rs shape class.
    /// </summary>
    public abstract class ModelLinkAddRuleForRSShapes : AddRule
    {
        private RSShapesFactoryHelper factoryHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factoryHelper">Shapes factory helper instance.</param>
        protected ModelLinkAddRuleForRSShapes(RSShapesFactoryHelper factoryHelper)
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

            if (e.ModelElement == null)
                return;

            if (e.ModelElement.Store.InSerializationTransaction)
                return;

            if( e.ModelElement is DomainModelLink )
                factoryHelper.AddRSShapesForElement(e.ModelElement as DomainModelLink);
        }

        /// <summary>
        /// Helper class for model element creation.
        /// </summary>
        public abstract class RSShapesFactoryHelper
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            protected RSShapesFactoryHelper()
            {
            }

            /// <summary>
            /// Adds shapes for a given element.
            /// </summary>
            /// <param name="modelElement">Model element.</param>
            [CLSCompliant(false)]
            public virtual void AddRSShapesForElement(DomainModelLink modelElement)
            {
                if (modelElement == null)
                    return;

                DiagramDomainDataDirectory data = modelElement.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
                if (data == null)
                    throw new ArgumentNullException("DiagramDomainDataDirectory");

                List<Guid> shapes = data.GetShapeTypesForElement(modelElement.GetDomainClassId());
                if( shapes != null )
                    if (shapes.Count > 0)
                    {
                        DomainModelElement source = DomainRoleInfo.GetSourceRolePlayer(modelElement) as DomainModelElement;
                        DomainModelElement target = DomainRoleInfo.GetTargetRolePlayer(modelElement) as DomainModelElement;
                        foreach (Guid shape in shapes)
                        {
                            AddRSShapesForElement(source, target, modelElement, shape);
                        }
                    }
            }

            /// <summary>
            /// Add shapes for a given element link.
            /// </summary>
            /// <param name="sourceElement"></param>
            /// <param name="targetElement"></param>
            /// <param name="con"></param>
            /// <param name="shapeType"></param>
            [CLSCompliant(false)]
            public virtual void AddRSShapesForElement(DomainModelElement sourceElement, DomainModelElement targetElement, ModelElement con, Guid shapeType)
            {
                List<Guid> shapeIdsSource = DiagramsShapeStore.GetFromStore(sourceElement.Id);
                List<Guid> shapeIdsTarget = DiagramsShapeStore.GetFromStore(targetElement.Id);
                if (shapeIdsSource == null || shapeIdsTarget == null)
                    return;
                if (shapeIdsSource.Count == 0 || shapeIdsTarget.Count == 0)
                    return;

                IDomainModelServices topMost = sourceElement.GetDomainModelServices().TopMostService;
                foreach (Guid sourceShapeId in shapeIdsSource)
                {
                    NodeShape sourceShape = con.Store.ElementDirectory.FindElement(sourceShapeId) as NodeShape;
                    if (sourceShape == null)
                        continue;
                    foreach (Guid targetShapeId in shapeIdsTarget)
                    {
                        NodeShape targetShape = con.Store.ElementDirectory.FindElement(targetShapeId) as NodeShape;
                        if( targetShape != null )
                            if (sourceShape.Diagram == targetShape.Diagram)
                            {
                                if (!DiagramHelper.IsLinkDisplayedOn(sourceShape.Diagram, shapeType, con.Id, sourceShape.Id, targetShape.Id))
                                {
                                    LinkShape shape = topMost.ShapeProvider.CreateShapeForElementLink(shapeType, con, sourceShape, targetShape) as LinkShape;
                                    sourceShape.Diagram.LinkShapes.Add(shape);
                                    shape.Layout(FixedGeometryPoints.None);
                                }
                            }
                    }
                }
            }

        }        
    }
}

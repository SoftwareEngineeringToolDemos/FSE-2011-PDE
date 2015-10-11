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
    public abstract class ModelLinkAddRuleForMappingRSShapes : AddRule
    {
        private RSShapesFactoryHelper factoryHelper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="factoryHelper">Shapes factory helper instance.</param>
        protected ModelLinkAddRuleForMappingRSShapes(RSShapesFactoryHelper factoryHelper)
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

            if (e.ModelElement is DomainModelLink)
                factoryHelper.AddRSShapesForElement(e.ModelElement as DomainModelLink);
            else if (e.ModelElement is DomainModelElement)
                factoryHelper.AddMappingRSShapesForElement(e.ModelElement as DomainModelElement);
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

                DomainModelElement m = DomainRoleInfo.GetSourceRolePlayer(modelElement) as DomainModelElement;
                AddMappingRSShapesForElement(m);
            }

            /// <summary>
            /// Adds shapes for a given element.
            /// </summary>
            /// <param name="modelElement">Model element.</param>
            [CLSCompliant(false)]
            public virtual void AddMappingRSShapesForElement(DomainModelElement modelElement)
            {
                if (modelElement == null)
                    return;

                DiagramDomainDataDirectory data = modelElement.Store.DomainDataAdvDirectory.ResolveExtensionDirectory<DiagramDomainDataDirectory>();
                if (data == null)
                    throw new ArgumentNullException("DiagramDomainDataDirectory");


                List<Guid> shapes = data.GetShapeTypesForElement(modelElement.GetDomainClassId());
                if (shapes == null)
                    return;
                foreach (Guid g in shapes)
                    if (data.MappingRelationshipShapeInfos.ContainsKey(g))
                    {
                        MappingRelationshipShapeInfo info = data.MappingRelationshipShapeInfos[g];

                        // see if the required relationships exist
                        ReadOnlyCollection<ElementLink> colSource = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, info.SourceDomainRole);
                        if (colSource.Count != 1)
                            return;

                        ReadOnlyCollection<ElementLink> colTarget = DomainRoleInfo.GetElementLinks<ElementLink>(modelElement, info.TargetDomainRole);
                        if (colTarget.Count != 1)
                            return;

                        DomainModelElement source = DomainRoleInfo.GetTargetRolePlayer(colSource[0]) as DomainModelElement;
                        DomainModelElement target = DomainRoleInfo.GetTargetRolePlayer(colTarget[0]) as DomainModelElement;


                        AddRSShapesForElement(source, target, modelElement, g);
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
                        if (targetShape != null)
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

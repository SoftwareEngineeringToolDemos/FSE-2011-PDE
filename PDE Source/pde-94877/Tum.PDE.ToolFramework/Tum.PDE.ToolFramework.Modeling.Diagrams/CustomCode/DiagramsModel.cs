using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Diagram model class.
    /// </summary>
    public partial class DiagramsModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public DiagramsModel(Store store, params PropertyAssignment[] propertyAssignments)
        	: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
        {
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public DiagramsModel(Partition partition, params PropertyAssignment[] propertyAssignments)
        	: base(partition, propertyAssignments)
        {
            // listen to events
            this.Store.EventManagerDirectory.ElementAdded.Add(new EventHandler<ElementAddedEventArgs>(OnElementAdded));
            this.Store.EventManagerDirectory.ElementDeleted.Add(new EventHandler<ElementDeletedEventArgs>(OnElementDeleted));
        }


        /// <summary>
        /// Called whenever a model element is added to the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the creation of new model element.</param>
        private void OnElementAdded(object sender, ElementAddedEventArgs args)
        {
            if (!ModelData.DoSendModelEvents)
                return;

            // update shape mapping (this is required, becauso undo/redo does not trigger events)
            if (args.ModelElement is DiagramHasChildren)
            {
                DiagramHasChildren con = args.ModelElement as DiagramHasChildren;
                if (con != null)
                {
                    NodeShape nodeShape = con.ChildShape;
                    Diagram diagram = con.Diagram;

                    if (nodeShape != null && diagram != null)
                    {
                        if (nodeShape.IsDeleted)
                            return;

                        diagram.AddToShapeMapping(nodeShape);
                    }
                }
            }
            else if (args.ModelElement is ShapeElementContainsChildShapes)
            {
                ShapeElementContainsChildShapes con = args.ModelElement as ShapeElementContainsChildShapes;
                if (con != null)
                {
                    NodeShape childShape = con.ChildShape;
                    NodeShape parentShape = con.ParentShape;

                    if (childShape != null && parentShape != null)
                    {
                        if (childShape.IsDeleted)
                            return;
                        if (parentShape.IsDeleted)
                            return;

                        parentShape.AddToShapeMapping(childShape);
                    }
                }
            }
        }

        /// <summary>
        /// Called whenever a model element is deleted from the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the removal of an ModelElement.</param>
        private void OnElementDeleted(object sender, ElementDeletedEventArgs args)
        {
            if (args.ModelElement is DiagramHasChildren)
            {
                DiagramHasChildren con = args.ModelElement as DiagramHasChildren;
                if (con != null)
                {
                    NodeShape nodeShape = con.ChildShape;
                    Diagram diagram = con.Diagram;

                    if (nodeShape != null && diagram != null)
                        if (nodeShape.Element != null)
                        {
                            diagram.RemoveFromShapeMapping(nodeShape);
                        }
                }
            }
            else if (args.ModelElement is ShapeElementContainsChildShapes)
            {
                ShapeElementContainsChildShapes con = args.ModelElement as ShapeElementContainsChildShapes;
                if (con != null)
                {
                    NodeShape childShape = con.ChildShape;
                    NodeShape parentShape = con.ParentShape;

                    if (childShape != null && parentShape != null)
                        if (childShape.Element != null)
                        {
                            parentShape.RemoveFromShapeMapping(childShape);
                        }
                }
            }
        }

        /// <summary>
        /// Verifies if the diagrams model contains a diagram with the specified name.
        /// </summary>
        /// <param name="diagramName">Diagram name.</param>
        /// <returns>True if the diagram is found. False otherwise.</returns>
        public bool ContainsDiagram(string diagramName)
        {
            foreach (Diagram diagram in this.Diagrams)
                if (diagram.Name == diagramName)
                    return true;

            return false;
        }

        /// <summary>
        /// Gets a diagram from the diagrams model by the specified name.
        /// </summary>
        /// <param name="diagramName">Diagram name.</param>
        /// <returns>Diagram instance if found. Null otherwise.</returns>
        public Diagram GetDiagram(string diagramName)
        {
            foreach (Diagram diagram in this.Diagrams)
                if (diagram.Name == diagramName)
                    return diagram;

            return null;
        }
        
    }
}

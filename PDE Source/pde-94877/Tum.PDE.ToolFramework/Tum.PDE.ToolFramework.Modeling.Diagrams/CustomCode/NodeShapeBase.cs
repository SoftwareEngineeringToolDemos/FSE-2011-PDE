using System;
using System.Collections.Generic;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    /// <summary>
    /// Node shape base abstract class.
    /// </summary>
    public abstract partial class NodeShapeBase
    {
        private Dictionary<Guid, List<Guid>> shapeMapping = new Dictionary<Guid, List<Guid>>();

        /// <summary>
        /// Shape mapping dictionary containing the Ids of all ShapeElements that host a certain ModelElement identified by an Id.
        /// </summary>
        public Dictionary<Guid, List<Guid>> ShapeMapping
        {
            get
            {
                return this.shapeMapping;
            }
        }


        /// <summary>
        /// Gets or sets the diagram. This should only be set if this element actually is to be hosted
        /// on the diagram surface. 
        /// </summary>
        public Diagram Diagram
        {
            get
            {
                if (this.Parent != null)
                    return this.Parent.Diagram;

                return this.InternalDiagram;
            }
            set
            {
                this.InternalDiagram = value;
            }
        }

        /// <summary>
        /// Adds a ShapeElement to the shape mapping dictionary.
        /// </summary>
        /// <param name="shapeElement">Shape element to add to the shape mapping dictionary.</param>
        public virtual void AddToShapeMapping(ShapeElement shapeElement)
        {
            this.AddToShapeMapping(shapeElement, false);
        }

        /// <summary>
        /// Adds a ShapeElement to the shape mapping dictionary.
        /// </summary>
        /// <param name="shapeElement">Shape element to add to the shape mapping dictionary.</param>
        public virtual void AddToShapeMapping(ShapeElement shapeElement, bool bOnlyAddToStore)
        {
            if (shapeElement == null)
                throw new ArgumentNullException("shapeElement");

            if (shapeElement.Element == null)
                throw new ArgumentNullException("shapeElement.Element");

            if (!bOnlyAddToStore)
            {
                if (!shapeMapping.ContainsKey(shapeElement.Element.Id))
                    shapeMapping.Add(shapeElement.Element.Id, new List<Guid>());

                if (!shapeMapping[shapeElement.Element.Id].Contains(shapeElement.Id))
                    shapeMapping[shapeElement.Element.Id].Add(shapeElement.Id);
            }

            DiagramsShapeStore.AddToStore(shapeElement.Element.Id, shapeElement.Id);
        }

        /// <summary>
        /// Removes a ShapeElement from the shape mapping dictionary.
        /// </summary>
        /// <param name="shapeElement">Shape element to remove from the shape mapping dictionary.</param>
        public virtual void RemoveFromShapeMapping(ShapeElement shapeElement)
        {
            this.RemoveFromShapeMapping(shapeElement, false);
        }

        /// <summary>
        /// Removes a ShapeElement from the shape mapping dictionary.
        /// </summary>
        /// <param name="shapeElement">Shape element to remove from the shape mapping dictionary.</param>
        public virtual void RemoveFromShapeMapping(ShapeElement shapeElement, bool bOnlyRemoveFromStore)
        {
            if (shapeElement == null)
                throw new ArgumentNullException("shapeElement");

            if (shapeElement.Element == null)
                throw new ArgumentNullException("shapeElement.Element");

            if (!bOnlyRemoveFromStore)
            {
                if (shapeMapping.ContainsKey(shapeElement.Element.Id))
                    if (shapeMapping[shapeElement.Element.Id].Contains(shapeElement.Id))
                    {
                        shapeMapping[shapeElement.Element.Id].Remove(shapeElement.Id);
                        if (shapeMapping[shapeElement.Element.Id].Count == 0)
                            shapeMapping.Remove(shapeElement.Element.Id);
                    }
            }

            DiagramsShapeStore.RemoveFromStore(shapeElement.Element.Id, shapeElement.Id);
        }

        #region Property Functions that needs to be overriden in the actual instance
        /// <summary>
        /// Gets the used defined resizing behaviour value.
        /// </summary>
        /// <returns>Resizing behaviour value.</returns>
        public virtual ShapeResizingBehaviour GetResizingBehaviourValue()
        {
            return ShapeResizingBehaviour.Normal;
        }

        /// <summary>
        /// Gets the used defined movement behaviour value.
        /// </summary>
        /// <returns>Movement behaviour value.</returns>
        public virtual ShapeMovementBehaviour GetMovementBehaviourValue()
        {
            return ShapeMovementBehaviour.Normal;
        }

        /// <summary>
        /// Gets whether this shape is a relative child shape or not.
        /// </summary>
        /// <returns>True if this shape is a relative child shape. False otherwise</returns>
        public virtual bool GetIsRelativeChildShapeValue()
        {
            return false;
        }

        /// <summary>
        /// Gets whether this shape takes part in any relationship or not.
        /// </summary>
        /// <returns>True if this shape takes part in any relationship. False otherwise</returns>
        public virtual bool GetTakesPartInRelationshipValue()
        {
            return false;
        }
        #endregion
    }
}

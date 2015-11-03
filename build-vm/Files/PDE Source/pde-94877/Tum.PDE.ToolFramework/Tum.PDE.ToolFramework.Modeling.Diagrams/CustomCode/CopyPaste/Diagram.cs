using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Diagrams
{
    public partial class Diagram : IModelMergeElements
    {
        /// <summary>
        /// Decides whether the element can be copied or not.
        /// </summary>
        /// <returns>True if the element can be copied. False otherwise.</returns>
        public virtual bool ModelIsCopyAllowed()
        {
            return false;
        }

        /// <summary>
        /// Decides whether the element can be moved or not.
        /// </summary>
        /// <returns>True if the element can be moved. False otherwise.</returns>
        public virtual bool ModelIsMoveAllowed()
        {
            return false;
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Decides whether the element can be pasted or not based on the operation.
        /// </summary>
        /// <param name="protoGroupOperation">Proto group operation.</param>
        /// <returns>True if the element can be pasted. False otherwise.</returns>
        public virtual bool ModelIsPasteAllowed(ModelProtoGroupOperation protoGroupOperation)
        {
            return true;
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Create a proto element representation of the element, which can be used for paste later.
        /// </summary>
        /// <param name="protoGroup">Proto group to add the element to.</param>
        /// <returns>Proto element representation of the element.</returns>
        public virtual ModelProtoElement ModelCreateMergeCopy(ModelProtoGroup protoGroup)
        {
            if (protoGroup.Operation == ModelProtoGroupOperation.Copy)
                if (!ModelIsCopyAllowed())
                    return null;

            if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                return null;

            ModelProtoElement protoElement = new ModelProtoElement(this);
            protoGroup.AddNewElement(protoElement);
            ModelProcessMergeCopy(protoElement, protoGroup);

            return protoElement;
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Create a proto element representation of the element, which can be used for paste later.
        /// </summary>
        /// <param name="protoGroup">Proto group to add the element to.</param>
        /// <returns>Proto element representation of the element.</returns>
        public virtual ModelProtoElement ModelCreateMoveCopy(ModelProtoGroup protoGroup)
        {
            if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                if (!ModelIsMoveAllowed())
                    return null;

            if (protoGroup.Operation == ModelProtoGroupOperation.Copy)
                return null;

            ModelProtoElement protoElement = new ModelProtoElement(this);
            protoGroup.AddNewElement(protoElement);
            ModelProcessMergeCopy(protoElement, protoGroup);
            return protoElement;
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Processes a proto element representation of the element and adds required proto links. 
        /// This method is called on base classes from derived classes.
        /// 
        /// Hint: Properties do not need to be added in this method.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element.</param>
        /// <param name="protoGroup">Proto group the proto element belongs to.</param>
        public virtual void ModelProcessMergeCopy(ModelProtoElement protoElement, ModelProtoGroup protoGroup)
        {
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Decides whether the element that is represented by the proto element can be pasted or not.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element.</param>
        /// <param name="protoGroup">Proto group the proto element belongs to.</param>
        /// <returns>True if the element can be pasted. False otherwise.</returns>
        public virtual bool ModelCanMerge(ModelProtoElement protoElement, ModelProtoGroup protoGroup)
        {
            if (protoGroup.Operation == ModelProtoGroupOperation.Move)
                return false;

            if (protoElement.CustomArguments is DiagramModelMergeOptions)
            {
                DiagramModelMergeOptions options = protoElement.CustomArguments as DiagramModelMergeOptions;

                return this.CanHostShape(options.ShapeDomainClassId);
            }

            return false;
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        public virtual void ModelMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger, bool isRoot)
        {

        }

        [CLSCompliant(false)]
        /// <summary>
        /// Adds a proto link to the current element.
        /// </summary>
        /// <param name="protoLink">Proto link representation of the element link that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelMerge(ModelProtoLink protoLink, ModelProtoGroupMerger groupMerger)
        {
            (this.Element as IModelMergeElements).ModelMerge(protoLink, groupMerger);
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Moves a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelMove(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Finalize. This method is called on each copied element once all the elements and links are processed.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        public virtual void ModelFinalize(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
        }

        [CLSCompliant(false)]
        /// <summary>
        /// Finalize merge. This method is called on the root element once all the elements and links are processed. 
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <remarks>
        /// This is called after the finalize method.
        /// </remarks>
        public virtual void ModelFinalizeMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger)
        {
            (this.Element as IModelMergeElements).ModelFinalizeMerge(protoElement, groupMerger);
        }
    }
}

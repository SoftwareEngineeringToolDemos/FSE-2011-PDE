using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Interface for model elements that may be copied and that support pasting of other elements.
    /// </summary>
    public interface IModelMergeElements
    {
        /// <summary>
        /// Decides whether the element can be copied or not.
        /// </summary>
        /// <returns>True if the element can be copied. False otherwise.</returns>
        bool ModelIsCopyAllowed();

        /// <summary>
        /// Decides whether the element can be moved or not.
        /// </summary>
        /// <returns>True if the element can be moved. False otherwise.</returns>
        bool ModelIsMoveAllowed();

        /// <summary>
        /// Decides whether the element can be pasted or not based on the operation.
        /// </summary>
        /// <param name="protoGroupOperation">Proto group operation.</param>
        /// <returns>True if the element can be pasted. False otherwise.</returns>
        bool ModelIsPasteAllowed(ModelProtoGroupOperation protoGroupOperation);

        /// <summary>
        /// Create a proto element representation of the element, which can be used for paste later.
        /// </summary>
        /// <param name="protoGroup">Proto group to add the element to.</param>
        /// <returns>Proto element representation of the element.</returns>
        ModelProtoElement ModelCreateMergeCopy(ModelProtoGroup protoGroup);

        /// <summary>
        /// Create a proto element representation of the element, which can be used for paste later.
        /// </summary>
        /// <param name="protoGroup">Proto group to add the element to.</param>
        /// <returns>Proto element representation of the element.</returns>
        ModelProtoElement ModelCreateMoveCopy(ModelProtoGroup protoGroup);

        /// <summary>
        /// Processes a proto element representation of the element and adds required proto links. 
        /// This method is called on base classes from derived classes.
        /// 
        /// Hint: Properties do not need to be added in this method.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element.</param>
        /// <param name="protoGroup">Proto group the proto element belongs to.</param>
        void ModelProcessMergeCopy(ModelProtoElement protoElement, ModelProtoGroup protoGroup);

        /// <summary>
        /// Decides whether the element that is represented by the proto element can be pasted or not.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element.</param>
        /// <param name="protoGroup">Proto group the proto element belongs to.</param>
        /// <returns>True if the element can be pasted. False otherwise.</returns>
        bool ModelCanMerge(ModelProtoElement protoElement, ModelProtoGroup protoGroup);

        /// <summary>
        /// Adds a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        /// <param name="isRoot">Root element?</param>
        void ModelMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger, bool isRoot);

        /// <summary>
        /// Adds a proto link to the current element.
        /// </summary>
        /// <param name="protoLink">Proto link representation of the element link that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        void ModelMerge(ModelProtoLink protoLink, ModelProtoGroupMerger groupMerger);

        /// <summary>
        /// Moves a proto element to the current element.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        void ModelMove(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger);

        /// <summary>
        /// Finalize. This method is called on each copied element once all the elements and links are processed.
        /// </summary>
        /// <param name="protoElement">Proto element representation of the element that is to be added.</param>
        /// <param name="groupMerger">
        /// Group merger class used to track id mapping, merge errors/warnings and 
        /// postprocess merging by rebuilding reference relationships.
        /// </param>
        void ModelFinalize(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger);

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
        void ModelFinalizeMerge(ModelProtoElement protoElement, ModelProtoGroupMerger groupMerger);

    }
}

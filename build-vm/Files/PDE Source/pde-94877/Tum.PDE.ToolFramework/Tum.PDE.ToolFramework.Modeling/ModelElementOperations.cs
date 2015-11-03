using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// Helper class for copy, paste and move operations.
    /// </summary>
    public class ModelElementOperations
    {
        private class CachedModelProtoGroup
        {
            private Guid instanceID;
            private ModelProtoGroup prototype;

            /// <summary>
            /// Instance Id of the proto group.
            /// </summary>
            public Guid InstanceId
            {
                get
                {
                    return instanceID;
                }
            }

            /// <summary>
            /// Gets the proto group.
            /// </summary>
            public ModelProtoGroup Prototype
            {
                get
                {
                    return prototype;
                }
            }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="instanceID"></param>
            /// <param name="prototype"></param>
            public CachedModelProtoGroup(Guid instanceID, ModelProtoGroup prototype)
            {
                this.instanceID = instanceID;
                this.prototype = prototype;
            }
        }

        private static CachedModelProtoGroup cachedPrototype;

        /// <summary>
        /// Decides wether the given element can be copied.
        /// </summary>
        /// <param name="elements">List of model elements.</param>
        /// <returns>True if the element can be copied; False otherwise.</returns>
        public static bool CanCopy(ICollection<ModelElement> elements)
        {
            foreach (ModelElement m in elements)
            {
                if (m is IModelMergeElements)
                {
                    if (!(m as IModelMergeElements).ModelIsCopyAllowed())
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Decides wether the given element can be moved.
        /// </summary>
        /// <param name="elements">List of model elements.</param>
        /// <returns>True if the element can be moved; False otherwise.</returns>
        public static bool CanMove(ICollection<ModelElement> elements)
        {
            foreach (ModelElement m in elements)
            {
                if (m is IModelMergeElements)
                {
                    if (!(m as IModelMergeElements).ModelIsMoveAllowed())
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Copies the given elements to the dataObject.
        /// </summary>
        /// <param name="elements">Elements to copy.</param>
        /// <param name="dataObject">DataObject to add the data to.</param>
        /// <returns>DataObjects with the added data.</returns>
        public static IDataObject Copy(ICollection<ModelElement> elements, IDataObject dataObject)
        {
            Guid guid = Guid.NewGuid();

            ModelProtoGroup protoGroup = new ModelProtoGroup(elements, ModelProtoGroupOperation.Copy);
            dataObject.SetData(ModelProtoGroup.DefaultDataFormatName, protoGroup);
            dataObject.SetData(ModelProtoGroup.DefaultDataIdentifierName, guid);

            // update cached prototype
            cachedPrototype = new CachedModelProtoGroup(guid, protoGroup);
            return dataObject;
        }

        /// <summary>
        /// Copies the given elements to the dataObject for the move operation.
        /// </summary>
        /// <param name="elements">Elements to copy.</param>
        /// <param name="dataObject">DataObject to add the data to.</param>
        /// <returns>DataObjects with the added data.</returns>
        public static IDataObject CopyToMove(ICollection<ModelElement> elements, IDataObject dataObject)
        {
            ModelProtoGroup protoGroup = new ModelProtoGroup(elements, ModelProtoGroupOperation.Move);
            dataObject.SetData(ModelProtoGroup.DefaultDataFormatName, protoGroup);
            dataObject.SetData(ModelProtoGroup.DefaultDataIdentifierName, Guid.NewGuid());
            return dataObject;
        }

        /// <summary>
        /// Verifies if a paste operation can be executed in the current context.
        /// </summary>
        /// <param name="rootElement">Root element, on which to paste the current data object's data.</param>
        /// <param name="dataObject">Data to be pasted.</param>
        /// <returns>True if paste can be executed. False otherwise.</returns>
        public static bool CanMerge(ModelElement rootElement, IDataObject dataObject)
        {
            if (rootElement is IModelMergeElements)
            {
                ModelProtoGroup group = GetModelProtoGroup(dataObject);
                if (group == null)
                    return false;

                if (group.ProtoRootElements.Count == 0)
                    return false;

                foreach (ModelProtoElement p in group.ProtoRootElements)
                {
                    if (!(rootElement as IModelMergeElements).ModelCanMerge(p, group))
                        return false;
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Executes the paste operation.
        /// </summary>
        /// <param name="rootElement">Root element, on which to paste the current data object's data.</param>
        /// <param name="dataObject">Data to be pasted.</param>
        /// <returns>ValidationResult holding errors, warning or information messages.</returns>
        public static ValidationResult Merge(ModelElement rootElement, IDataObject dataObject)
        {
            if( !CanMerge(rootElement, dataObject) )
                return null;

            ModelProtoGroup group = GetModelProtoGroup(dataObject);
            ModelProtoGroupMerger protoMerger = new ModelProtoGroupMerger(group, rootElement);

            return protoMerger.MergeResult;
        }

        /// <summary>
        /// Retrieves a model proto group from the given data object if one exists.
        /// </summary>
        /// <param name="dataObject">Data objects to retrieve a model proto group from.</param>
        /// <returns>ModelProtoGroup instance or null.</returns>
        public static ModelProtoGroup GetModelProtoGroup(IDataObject dataObject)
        {
            ModelProtoGroup group = null;
            if (dataObject.GetDataPresent(ModelProtoGroup.DefaultDataFormatName))
            {
                Guid guid = Guid.Empty;
                if (dataObject.GetDataPresent(ModelProtoGroup.DefaultDataIdentifierName))
                    guid = (System.Guid)dataObject.GetData(ModelProtoGroup.DefaultDataIdentifierName);

                if ((cachedPrototype != null) && guid == cachedPrototype.InstanceId)
                    return cachedPrototype.Prototype;

                object obj = dataObject.GetData(ModelProtoGroup.DefaultDataFormatName);
                group = obj as ModelProtoGroup;
                cachedPrototype = new CachedModelProtoGroup(guid, group);
            }

            return group;
        }
    }
}

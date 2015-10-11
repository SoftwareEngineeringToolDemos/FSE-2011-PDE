using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL.CopyPaste
{
    public enum CopyAndPasteOperation
    {
        Default,
        CopyAllTree,
        CopyEmbeddingTree,
        CopyReferenceTree
    }

    /// <summary>
    /// Helper class for copy and paste operations.
    /// </summary>
    public static class CopyAndPasteOperations
    {
        public static CopyAndPasteOperation Operation = CopyAndPasteOperation.Default;

        /// <summary>
        /// List of ids of elements that are beeing moved.
        /// </summary>
        public static List<System.Guid> ElementsInMoveMode = new List<Guid>();
                
        /// <summary>
        /// Verifies if a collection of elements can be copied.
        /// </summary>
        /// <param name="modelElements">Elements.</param>
        /// <returns>True if the elements can be copied. False otherwise.</returns>
        public static bool CanExecuteCopy(Collection<ModelElement> modelElements)
        {
            return ModelElementOperations.CanCopy(modelElements);
        }

        /// <summary>
        /// Verifies if a collection of elements can be moved.
        /// </summary>
        /// <param name="modelElements">Elements.</param>
        /// <returns>True if the elements can be moved. False otherwise.</returns>
        public static bool CanExecuteMove(Collection<ModelElement> modelElements)
        {
            return ModelElementOperations.CanMove(modelElements);
        }

        /// <summary>
        /// Verifies if a paste operation can be executed.
        /// </summary>
        /// <param name="rootElement">Element to execute paste on.</param>
        /// <param name="dataObject">Data.</param>
        /// <returns>True if the paste operation can be executed. False otherwise.</returns>
        public static bool CanExecutePaste(ModelElement rootElement, System.Windows.IDataObject dataObject)
        {
            return ModelElementOperations.CanMerge(rootElement, dataObject);
        }

        /// <summary>
        /// Adds the copies of the given elements to a data object and adds it to the clipboard.
        /// </summary>
        /// <param name="modelElements">Elements to copy.</param>
        public static void ExecuteCopy(Collection<ModelElement> modelElements)
        {
            // move domain classes to the top of the list
            Collection<ModelElement> sortedME = MoveDomainClassesToTop(modelElements);

            System.Windows.IDataObject dataObject = new System.Windows.DataObject();
            ModelElementOperations.Copy(sortedME, dataObject);

            System.Windows.Clipboard.SetDataObject(dataObject, true);
        }

        /// <summary>
        /// Adds the copies of the given elements to a data object and adds it to the clipboard.
        /// </summary>
        /// <param name="modelElements">Elements to move.</param>
        public static void ExecuteCut(Collection<ModelElement> modelElements)
        {
            // move domain classes to the top of the list
            Collection<ModelElement> sortedME = MoveDomainClassesToTop(modelElements);

            System.Windows.IDataObject dataObject = new System.Windows.DataObject();
            ModelElementOperations.CopyToMove(sortedME, dataObject);

            System.Windows.Clipboard.SetDataObject(dataObject, true);
        }

        /// <summary>
        /// Executes the paste operation on the given element.
        /// </summary>
        /// <param name="modelElement">Element.</param>
        /// <returns>Validation result, indicating problems during the paste operation.</returns>
        public static ValidationResult ExecutePaste(ModelElement modelElement)
        {
            System.Windows.IDataObject idataObject = System.Windows.Clipboard.GetDataObject();

            ValidationResult result = null;
            using (Transaction transaction = modelElement.Store.TransactionManager.BeginTransaction("Paste"))
            {
                result = ModelElementOperations.Merge(modelElement, idataObject);
                transaction.Commit();
            }

            ModelProtoGroup group = ModelElementOperations.GetModelProtoGroup(idataObject);
            if (group != null)
            {
                if (group.Operation == ModelProtoGroupOperation.Move)
                {
                    System.Windows.Clipboard.Clear();
                    ElementsInMoveMode.Clear();
                }
            }

            return result;


            
        }

        /// <summary>
        /// Helper method of the cut opeation.
        /// </summary>
        /// <param name="eventManager">Event manager.</param>
        /// <param name="idataObject">Data object.</param>
        public static void ProcessMoveMode(System.Windows.IDataObject idataObject)
        {
            bool isInMoveMode = false;
            if (idataObject != null)
            {
                ModelProtoGroup group = ModelElementOperations.GetModelProtoGroup(idataObject);
                if (group != null)
                    if (group.Operation == ModelProtoGroupOperation.Move)
                    {
                        isInMoveMode = true;

                        List<System.Guid> guids = new List<System.Guid>();
                        foreach (ModelProtoElement root in group.ProtoRootElements)
                        {
                            guids.Add(root.ElementId);
                        }
                        foreach (System.Guid id in guids)
                        {
                            if (!ElementsInMoveMode.Contains(id))
                            {
                                //eventManager.GetEvent<ModelElementCustomEvent<bool>>().Publish(true, ModelElementCustomEventNames.ModelElementMoveModeStatus, id);
                                ElementsInMoveMode.Add(id);
                            }
                        }
                        for (int i = ElementsInMoveMode.Count - 1; i >= 0; i--)
                        {
                            if (!guids.Contains(ElementsInMoveMode[i]))
                            {
                                //eventManager.GetEvent<ModelElementCustomEvent<bool>>().Publish(false, ModelElementCustomEventNames.ModelElementMoveModeStatus, ElementsInMoveMode[i]);
                                ElementsInMoveMode.RemoveAt(i);
                            }
                        }

                    }
            }

            if (!isInMoveMode)
            {
                // remove all elements from the current list and notify them to change status
                //foreach (System.Guid id in ElementsInMoveMode)
                //    eventManager.GetEvent<ModelElementCustomEvent<bool>>().Publish(false, ModelElementCustomEventNames.ModelElementMoveModeStatus, id);
            }
        }


        private static Collection<ModelElement> MoveDomainClassesToTop(Collection<ModelElement> modelElements)
        {
            Collection<ModelElement> sortedME = new Collection<ModelElement>();
            for (int i = modelElements.Count - 1; i >= 0; i--)
                if (modelElements[i] is DomainClass)
                {
                    sortedME.Insert(0, modelElements[i]);
                    modelElements.RemoveAt(i);
                }
            foreach (ModelElement m in modelElements)
                sortedME.Add(m);

            return sortedME;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;
using System.Windows.Forms;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    public abstract partial class MetaModelLibraryBase
    {
        /// <summary>
        /// Gets the absolute file path.
        /// </summary>
        public string AbsoluteFilePath
        {
            get
            {
                return GetAbsoluteFilePath(this.MetaModel.BaseDirectory, this.FilePath);
            }
        }

        public MetaModel LoadLibrary()
        {
            MetaModel m = null;

            using (Transaction t = this.Store.TransactionManager.BeginTransaction("load library", true))
            {
                SerializationResult serializationResult = new SerializationResult();
                m = LoadLibrary(serializationResult);

                t.Commit();
            }

            return m;
        }
        public MetaModel LoadLibrary(Microsoft.VisualStudio.Modeling.SerializationContext context)
        {
            return LoadLibrary(context.Result);
        }
        public MetaModel LoadLibrary(Microsoft.VisualStudio.Modeling.SerializationResult serializationResult)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(this.AbsoluteFilePath);
            if (!fileInfo.Exists)
                return null;

            if (System.String.Compare(fileInfo.Extension, ".lngdsl", System.StringComparison.OrdinalIgnoreCase) != 0)
                return null;

            MetaModel dslLibrary = FindLibrary(Store, this.AbsoluteFilePath);
            if (dslLibrary != null)
            {
               
                if (dslLibrary.IsTopMost)
                {
                    MessageBox.Show("Circular dependency to the top most meta model! Can not load library.");
                    throw new ArgumentException("Circular dependency to the top most meta model! Can not load library.");
                }
                //this.ImportedLibrary = dslLibrary;
                this.Name = dslLibrary.Name;
                return dslLibrary;
            }

            
            Microsoft.VisualStudio.Modeling.Partition partition = new Microsoft.VisualStudio.Modeling.Partition(Store);
            
            MetaModel metaModel;
            try
            {
                metaModel = LanguageDSLSerializationHelper.Instance.LoadModel(serializationResult, partition, this.AbsoluteFilePath, null, null, null, false);

                ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(MetaModel.DomainClassId);
                foreach (ModelElement element in elements)
                    if (element is MetaModel && element != metaModel)
                    {
                        MetaModel m = element as MetaModel;
                        if (m.Name == metaModel.Name)
                        {
                            metaModel.Delete();
                            throw new ArgumentException("Library can not have a name of an already included library or main meta model.");
                        }
                    }
            }
            catch (System.Xml.XmlException)
            {
                metaModel = null;
            }
            if ((metaModel != null) && !serializationResult.Failed)
            {
                this.ImportedLibrary = metaModel;
                this.Name = metaModel.Name;

                if( ImmutabilityExtensionMethods.GetLocks(metaModel) != Locks.All )
                    SetLocks(metaModel, Locks.All);
            }
            else
            {
                metaModel = null;
            }
            return metaModel;
        }


        public void UnloadLibrary()
        {
            SetLocks(this.ImportedLibrary as MetaModel, Locks.None);

            this.ImportedLibrary.Delete();
            this.FilePath = "";
        }
        public static void SetLocks(MetaModel metaModel, Locks locks)
        {
            if (metaModel == null)
                return;

            ImmutabilityExtensionMethods.SetLocks(metaModel, locks);

            foreach (PropertyGridEditor p in metaModel.PropertyGridEditors)
                ImmutabilityExtensionMethods.SetLocks(p, locks);

            foreach (DomainType p in metaModel.DomainTypes)
                ImmutabilityExtensionMethods.SetLocks(p, locks);

            foreach (BaseModelContext p in metaModel.ModelContexts)
            {
                ImmutabilityExtensionMethods.SetLocks(p, locks);

                if (p is LibraryModelContext)
                {
                    foreach (DiagramClass d in (p as LibraryModelContext).DiagramClasses)
                    {
                        ImmutabilityExtensionMethods.SetLocks(d, locks);
                        foreach (PresentationElementClass pe in d.PresentationElements)
                            ImmutabilityExtensionMethods.SetLocks(pe, locks);
                    }

                    LibraryModelContext lib = p as LibraryModelContext;
                    if (lib.SerializationModel != null)
                    {
                        ImmutabilityExtensionMethods.SetLocks(lib.SerializationModel, locks);
                        foreach (SerializationClass s in lib.SerializationModel.Children)
                        {
                            if (s == null)
                                continue;

                            ImmutabilityExtensionMethods.SetLocks(s, locks);
                            foreach(SerializationAttributeElement attr in s.Attributes )
                                if( attr != null )
                                ImmutabilityExtensionMethods.SetLocks(attr, locks);

                            foreach(SerializationElement element in s.Children)
                                if( element is SerializationAttributeElement )
                                    ImmutabilityExtensionMethods.SetLocks(element, locks);

                            if (s is SerializedReferenceRelationship)
                            {
                                SerializedReferenceRelationship sRef = s as SerializedReferenceRelationship;
                                foreach(SerializedDomainRole role in sRef.SerializedDomainRoles)
                                    ImmutabilityExtensionMethods.SetLocks(role, locks);
                            }
                        }
                    }
                }
            }

            if (metaModel.AdditionalInformation != null)
            {
                ImmutabilityExtensionMethods.SetLocks(metaModel.AdditionalInformation, locks);

                if (metaModel.AdditionalInformation.FurtherInformation != null)
                {
                    ImmutabilityExtensionMethods.SetLocks(metaModel.AdditionalInformation.FurtherInformation, locks);
                    foreach (InformationItem p in metaModel.AdditionalInformation.FurtherInformation.InformationItems)
                        ImmutabilityExtensionMethods.SetLocks(p, locks);
                }

                if (metaModel.AdditionalInformation.Credits != null)
                {
                    ImmutabilityExtensionMethods.SetLocks(metaModel.AdditionalInformation.Credits, locks);
                    foreach (CreditItem p in metaModel.AdditionalInformation.Credits.CreditItems)
                        ImmutabilityExtensionMethods.SetLocks(p, locks);
                }
            }

            foreach (DomainClass p in metaModel.AllClasses)
            {
                ImmutabilityExtensionMethods.SetLocks(p, locks);
                foreach (DomainProperty prop in p.Properties)
                    ImmutabilityExtensionMethods.SetLocks(prop, locks);
            }

            foreach (DomainRelationship p in metaModel.AllRelationships)
            {
                ImmutabilityExtensionMethods.SetLocks(p, locks);
                foreach (DomainProperty prop in p.Properties)
                    ImmutabilityExtensionMethods.SetLocks(prop, locks);
                foreach (DomainRole prop in p.Roles)
                    ImmutabilityExtensionMethods.SetLocks(prop, locks);
            }

            if (metaModel.Validation != null)
                ImmutabilityExtensionMethods.SetLocks(metaModel.Validation, locks);
        }

        public void TryUnloadLibrary()
        {
            if (CanUnloadImportedLibrary())
            {
                UnloadLibrary();
            }
        }
        public bool CanUnloadImportedLibrary()
        {
            DependenciesData data = GetDependencies();
            if (data.ActiveDependencies.Count > 0)
            {
                return false;
            }

            // continue with imported imports
            foreach (MetaModelLibraryBase l in this.ImportingImports)
                if (!l.CanUnloadImportedLibrary())
                {
                    return false;
                }
            
            return true;
        }
        public MetaModel FindLibrary(Store store, string filePath)
        {
            ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(MetaModel.DomainClassId);
            foreach(ModelElement element in elements)
                if (element is MetaModel)
                {
                    MetaModel metaModel = element as MetaModel;
                    if (metaModel.FilePath == filePath)
                        return metaModel;
                }

            return null;
        }
        public HashSet<MetaModelLibraryBase> ImportingImports
        {
            get
            {
                HashSet<MetaModelLibraryBase> hashSet = new HashSet<MetaModelLibraryBase>();
                ReadOnlyCollection<ModelElement> elements = this.Store.ElementDirectory.FindElements(MetaModelLibraryBase.DomainClassId);

                foreach (ModelElement element in elements)
                {
                    MetaModelLibraryBase m = element as MetaModelLibraryBase;
                    if (m != null && m != this)
                        hashSet.Add(m);
                }

                return hashSet;
            }
        }
        internal sealed partial class FilePathPropertyHandler
        {
            protected override void OnValueChanged(MetaModelLibraryBase element, string oldValue, string newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);

                if (element.Store.InSerializationTransaction || element.Store.InUndoRedoOrRollback || (element.MetaModel == null))
                    return;

                if (!System.String.IsNullOrWhiteSpace(newValue) && (element.ImportedLibrary == null))
                    element.LoadLibrary();
            }
            protected override void OnValueChanging(MetaModelLibraryBase element, string oldValue, string newValue)
            {
                if (element.Store.InSerializationTransaction || element.Store.InUndoRedoOrRollback || (element.MetaModel == null))
                {
                    base.OnValueChanging(element, oldValue, newValue);
                    return;
                }

                if (element.ImportedLibrary != null)
                {
                    element.UnloadLibrary();
                }

                base.OnValueChanging(element, oldValue, newValue);

            }
        }

        public DependenciesData GetDependencies()
        {
            List<ModelElement> classes = new List<ModelElement>();
            foreach (ModelContext m in this.MetaModel.ModelContexts)
            {
                foreach (DomainClass d in m.Classes)
                {
                    classes.Add(d);
                    classes.AddRange(d.Properties);
                    classes.AddRange(d.RolesPlayed);
                }
            }

            List<ModelElement> metaModels = new List<ModelElement>();
            metaModels.Add(this.MetaModel);

            return LanguageDSLDependenciesItemsProvider.Instance.GetDependencies(classes, metaModels, LanguageDSLDependenciesItemsProvider.GetAllCategories());
            
        }

        /// <summary>
        /// Gets the relative file path to a base directory of an imported file path.
        /// </summary>
        /// <param name="absoluteFilePath"></param>
        /// <returns></returns>
        public static string GetRelativeFilePathGlobally(string absoluteFilePath)
        {
            return GetRelativeFilePath(MetaModel.BaseGlobalDirectory, absoluteFilePath);
        }

        /// <summary>
        /// Gets the relative file path to a base directory of an imported file path.
        /// </summary>
        /// <param name="mainDirPath"></param>
        /// <param name="absoluteFilePath"></param>
        /// <returns></returns>
        public static string GetRelativeFilePath(string mainDirPath, string absoluteFilePath)
        {
            // examine the two paths and chop off the common part at the start of the paths
            string[] firstPathParts = mainDirPath.Trim(System.IO.Path.DirectorySeparatorChar).Split(System.IO.Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(System.IO.Path.DirectorySeparatorChar).Split(System.IO.Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length, secondPathParts.Length); i++)
            {
                if (!firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            string newPath = String.Empty;

            // different drive, not expected here
            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            // calculate the number of  '../' needed
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += System.IO.Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }

            // append target directories to reach file
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += System.IO.Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }

        /// <summary>
        /// Gets the absolute file path of a relative file path.
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        public static string GetAbsoluteFilePathGlobally(string relativeFilePath)
        {
            return GetAbsoluteFilePath(MetaModel.BaseGlobalDirectory, relativeFilePath);
        }

        /// <summary>
        /// Gets the absolute file path of a relative file path.
        /// </summary>
        /// <param name="mainDir"></param>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        public static string GetAbsoluteFilePath(string mainDir, string relativeFilePath)
        {
            string filePath = mainDir + System.IO.Path.DirectorySeparatorChar + relativeFilePath;
            filePath = filePath.Replace("\\\\", "\\");
            return new System.IO.FileInfo(filePath).FullName;
        }

        /// <summary>
        /// Gets the base directory of a given file path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetBaseDirectory(string filePath)
        {
            if (!String.IsNullOrWhiteSpace(filePath) && !String.IsNullOrEmpty(filePath))
            {
                try
                {
                    Uri uri = new Uri(filePath);
                    if (uri.IsFile)
                    {
                        return System.IO.Path.GetDirectoryName(uri.LocalPath);
                    }
                }
                catch{}
            }
            return null;
        }

        public static string GetNormalizedFilePath(string baseDirectory, string importFilePath)
        {
            if (System.String.IsNullOrWhiteSpace(importFilePath))
                return null;
            char[] chArr = new char[] { '\"' };
            string s = importFilePath.Trim(chArr);
            if (!System.IO.Path.IsPathRooted(s) && !System.String.IsNullOrWhiteSpace(baseDirectory))
                s = System.IO.Path.Combine(baseDirectory, s);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(s);
            if (fileInfo.Exists)
                return fileInfo.FullName;
            return s;
        }
    }
}

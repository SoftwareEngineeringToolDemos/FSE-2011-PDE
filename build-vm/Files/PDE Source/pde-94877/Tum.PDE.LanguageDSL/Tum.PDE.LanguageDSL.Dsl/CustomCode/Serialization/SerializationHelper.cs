using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslValidation = global::Microsoft.VisualStudio.Modeling.Validation;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    /// <summary>
    /// Extension:
    /// 
    /// Save the view part of the model in a separate file. For this, wenn need to explude saving the view model part in
    /// the default serialization (done in MetaModelSerializer) and proceed saving view data in a separate file (same name 
    /// as model but different extension = DiagramExtension).
    /// </summary>
    public partial class LanguageDSLSerializationHelper
    {
        public const string DiagramExtension = ".diagram";


        public override MetaModel LoadModel(SerializationResult serializationResult, Store store, string fileName, ISchemaResolver schemaResolver, DslValidation.ValidationController validationController, ISerializerLocator serializerLocator)
        {
            return LoadModel(serializationResult, store.DefaultPartition, fileName, schemaResolver, validationController, serializerLocator, true, true);
        }
        /// <summary>
        /// Loads a MetaModel instance.
        /// </summary>
        /// <param name="serializationResult">Stores serialization result from the load operation.</param>
        /// <param name="partition">Partition in which the new MetaModel instance will be created.</param>
        /// <param name="fileName">Name of the file from which the MetaModel instance will be deserialized.</param>
        /// <param name="schemaResolver">
        /// An ISchemaResolver that allows the serializer to do schema validation on the root element (and everything inside it).
        /// If null is passed, schema validation will not be performed.
        /// </param>
        /// <param name="validationController">
        /// A ValidationController that will be used to do load-time validation (validations with validation category "Load"). If null
        /// is passed, load-time validation will not be performed.
        /// </param>
        /// <returns>The loaded MetaModel instance.</returns>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code")]
        public override MetaModel LoadModel(DslModeling::SerializationResult serializationResult, DslModeling::Partition partition, string fileName, DslModeling::ISchemaResolver schemaResolver, DslValidation::ValidationController validationController, DslModeling::ISerializerLocator serializerLocator)
        {
            return LoadModel(serializationResult, partition, fileName, schemaResolver, validationController, serializerLocator, true);
        }
        public MetaModel LoadModel(DslModeling::SerializationResult serializationResult, DslModeling::Partition partition, string fileName, DslModeling::ISchemaResolver schemaResolver, DslValidation::ValidationController validationController, DslModeling::ISerializerLocator serializerLocator, bool bStartT)
        {
            return LoadModel(serializationResult, partition, fileName, schemaResolver, validationController, serializerLocator, true, false);
        }
        public MetaModel LoadModel(DslModeling::SerializationResult serializationResult, DslModeling::Partition partition, string fileName, DslModeling::ISchemaResolver schemaResolver, DslValidation::ValidationController validationController, DslModeling::ISerializerLocator serializerLocator, bool bStartT, bool bIsTopMost)
        {
            #region Model
            #region Check Parameters
            if (serializationResult == null)
                throw new global::System.ArgumentNullException("serializationResult");
            if (partition == null)
                throw new global::System.ArgumentNullException("partition");
            if (string.IsNullOrEmpty(fileName))
                throw new global::System.ArgumentNullException("fileName");
            #endregion

            // Ensure there is a transaction for this model to Load in.
            if (!partition.Store.TransactionActive)
            {
                throw new global::System.InvalidOperationException(LanguageDSLDomainModel.SingletonResourceManager.GetString("MissingTransaction"));
            }

            MetaModel modelRoot = null;
            DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(partition.Store);
            DslModeling::DomainClassXmlSerializer modelRootSerializer = directory.GetSerializer(MetaModel.DomainClassId);
            global::System.Diagnostics.Debug.Assert(modelRootSerializer != null, "Cannot find serializer for MetaModel!");
            if (modelRootSerializer != null)
            {
                using (global::System.IO.FileStream fileStream = global::System.IO.File.OpenRead(fileName))
                {
                    DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileStream.Name, serializationResult);
                    this.InitializeSerializationContext(partition, serializationContext, true);
                    DslModeling::TransactionContext transactionContext = new DslModeling::TransactionContext();
                    transactionContext.Add(DslModeling::SerializationContext.TransactionContextKey, serializationContext);

                    DslModeling::Transaction t = null;
                    if (bStartT)
                    {
                        t = partition.Store.TransactionManager.BeginTransaction("Load Model from " + fileName, true, transactionContext);
                    }

                    // Ensure there is some content in the file.  Blank (or almost blank, to account for encoding header bytes, etc.)
                    // files will cause a new root element to be created and returned. 
                    if (fileStream.Length > 5)
                    {
                        try
                        {
                            global::System.Xml.XmlReaderSettings settings = LanguageDSLSerializationHelper.Instance.CreateXmlReaderSettings(serializationContext, false);
                            using (global::System.Xml.XmlReader reader = global::System.Xml.XmlReader.Create(fileStream, settings))
                            {
                                // Attempt to read the encoding.
                                reader.Read(); // Move to the first node - will be the XmlDeclaration if there is one.
                                global::System.Text.Encoding encoding;
                                if (this.TryGetEncoding(reader, out encoding))
                                {
                                    serializationResult.Encoding = encoding;
                                }

                                // Load any additional domain models that are required
                                DslModeling::SerializationUtilities.ResolveDomainModels(reader, serializerLocator, partition.Store);

                                reader.MoveToContent();


                                modelRoot = modelRootSerializer.TryCreateInstance(serializationContext, reader, partition) as MetaModel;
                                if (modelRoot != null && !serializationResult.Failed)
                                {
                                    modelRoot.BaseDirectory = MetaModelLibraryBase.GetBaseDirectory(fileName);
                                    modelRoot.FilePath = fileName;
                                    this.ReadRootElement(serializationContext, modelRoot, reader, schemaResolver);
                                }
                            }

                        }
                        catch (global::System.Xml.XmlException xEx)
                        {
                            DslModeling::SerializationUtilities.AddMessage(
                                serializationContext,
                                DslModeling::SerializationMessageKind.Error,
                                xEx
                            );
                        }
                    }

                    if (modelRoot == null && !serializationResult.Failed)
                    {
                        // create model root if it doesn't exist.
                        modelRoot = this.CreateModelHelper(partition);
                        modelRoot.BaseDirectory = MetaModelLibraryBase.GetBaseDirectory(fileName);
                        modelRoot.FilePath = fileName;
                    }
                    if (bStartT)
                        if (t.IsActive)
                            t.Commit();

                    // Do load-time validation if a ValidationController is provided.
                    if (!serializationResult.Failed && validationController != null)
                    {
                        using (new SerializationValidationObserver(serializationResult, validationController))
                        {
                            validationController.Validate(partition, DslValidation::ValidationCategories.Load);
                        }
                    }
                }
            }

            #endregion

            MetaModel model = modelRoot;
            if (bIsTopMost)
                model.IsTopMost = true;

            #region Diagrams

            System.IO.FileInfo info = new System.IO.FileInfo(fileName);
            string fileNameDiagram = info.DirectoryName + "\\" + info.Name.Remove(info.Name.Length - info.Extension.Length, info.Extension.Length) + DiagramExtension;

            View view = null;
            if (System.IO.File.Exists(fileNameDiagram))
            {
                //DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(partition.Store);
                DslModeling::DomainClassXmlSerializer viewSerializer = directory.GetSerializer(View.DomainClassId);
                global::System.Diagnostics.Debug.Assert(viewSerializer != null, "Cannot find serializer for View!");
                if (viewSerializer != null)
                {
                    using (global::System.IO.FileStream fileStream = global::System.IO.File.OpenRead(fileNameDiagram))
                    {
                        DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileStream.Name, serializationResult);
                        this.InitializeSerializationContext(partition, serializationContext, true);
                        DslModeling::TransactionContext transactionContext = new DslModeling::TransactionContext();
                        transactionContext.Add(DslModeling::SerializationContext.TransactionContextKey, serializationContext);

                        DslModeling::Transaction t = null;
                        if (bStartT)
                            t = partition.Store.TransactionManager.BeginTransaction("Load Model from " + fileNameDiagram, true, transactionContext);

                        // Ensure there is some content in the file.  Blank (or almost blank, to account for encoding header bytes, etc.)
                        // files will cause a new root element to be created and returned. 
                        if (fileStream.Length > 5)
                        {
                            try
                            {
                                global::System.Xml.XmlReaderSettings settings = LanguageDSLSerializationHelper.Instance.CreateXmlReaderSettings(serializationContext, false);
                                using (global::System.Xml.XmlReader reader = global::System.Xml.XmlReader.Create(fileStream, settings))
                                {
                                    // Attempt to read the encoding.
                                    reader.Read(); // Move to the first node - will be the XmlDeclaration if there is one.
                                    global::System.Text.Encoding encoding;
                                    if (this.TryGetEncoding(reader, out encoding))
                                    {
                                        serializationResult.Encoding = encoding;
                                    }
                                    reader.MoveToContent();

                                    view = viewSerializer.TryCreateInstance(serializationContext, reader, partition) as View;
                                    if (view != null && !serializationResult.Failed)
                                    {
                                        // Use a validating reader if possible
                                        viewSerializer.Read(serializationContext, view, reader);

                                        model.View = view;
                                    }
                                }
                            }

                            catch (global::System.Xml.XmlException xEx)
                            {
                                DslModeling::SerializationUtilities.AddMessage(
                                    serializationContext,
                                    DslModeling::SerializationMessageKind.Error,
                                    xEx
                                );
                            }
                        }

                        if (bStartT)
                            if (t.IsActive)
                                t.Commit();

                    }
                }
            }
            #endregion

            //if( bIsTopMost )
            SerializationPostProcessor.PostProcessModelLoad(model);

            return model;
        }

        /// <summary>
        /// Saves the given model root to the given file, with specified encoding.
        /// </summary>
        /// <param name="serializationResult">Stores serialization result from the save operation.</param>
        /// <param name="modelRoot">MetaModel instance to be saved.</param>
        /// <param name="fileName">Name of the file in which the MetaModel instance will be saved.</param>
        /// <param name="encoding">Encoding to use when saving the MetaModel instance.</param>
        /// <param name="writeOptionalPropertiesWithDefaultValue">Whether optional properties with default value will be saved.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public override void SaveModel(DslModeling::SerializationResult serializationResult, MetaModel modelRoot, string fileName, global::System.Text.Encoding encoding, bool writeOptionalPropertiesWithDefaultValue)
        {
            base.SaveModel(serializationResult, modelRoot, fileName, encoding, writeOptionalPropertiesWithDefaultValue);

            System.IO.FileInfo info = new System.IO.FileInfo(fileName);
            string fileNameDiagram = info.DirectoryName + "\\" + info.Name.Remove(info.Name.Length - info.Extension.Length, info.Extension.Length) + DiagramExtension;

            // save view information
            using (global::System.IO.MemoryStream newFileContent = new global::System.IO.MemoryStream())
            {
                DslModeling::DomainXmlSerializerDirectory directory = this.GetDirectory(modelRoot.Store);

                DslModeling::SerializationContext serializationContext = new DslModeling::SerializationContext(directory, fileName, serializationResult);
                this.InitializeSerializationContext(modelRoot.Partition, serializationContext, false);
                // MonikerResolver shouldn't be required in Save operation, so not calling SetupMonikerResolver() here.
                serializationContext.WriteOptionalPropertiesWithDefaultValue = writeOptionalPropertiesWithDefaultValue;
                global::System.Xml.XmlWriterSettings settings = LanguageDSLSerializationHelper.Instance.CreateXmlWriterSettings(serializationContext, false, encoding);
                using (global::System.Xml.XmlWriter writer = global::System.Xml.XmlWriter.Create(newFileContent, settings))
                {
                    ViewSerializer serializer = directory.GetSerializer(View.DomainClassId) as ViewSerializer;
                    serializer.Write(serializationContext, modelRoot.View, writer);
                }

                if (!serializationResult.Failed && newFileContent != null)
                {	// Only write the content if there's no error encountered during serialization.
                    using (global::System.IO.FileStream fileStream = new global::System.IO.FileStream(fileNameDiagram, global::System.IO.FileMode.Create, global::System.IO.FileAccess.Write, global::System.IO.FileShare.None))
                    {
                        using (global::System.IO.BinaryWriter writer = new global::System.IO.BinaryWriter(fileStream, encoding))
                        {
                            writer.Write(newFileContent.ToArray());
                        }
                    }
                }
            }
        }

        public void InitializeSerializationExtern(DslModeling::Store store)
        {
            base.InitializeSerialization(store);
        }
    }
}

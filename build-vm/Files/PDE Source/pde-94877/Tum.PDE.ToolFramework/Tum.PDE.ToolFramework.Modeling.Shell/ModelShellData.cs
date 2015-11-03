using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Shell;

namespace Tum.PDE.ToolFramework.Modeling.Shell
{
    /// <summary>
    /// Abstract base class representing a file in memory (VSX shell version).
    /// </summary>
    public abstract class ModelShellData : ModelingDocData
    {
   		/// <summary>
        /// Constructs a new ModelShellData.
		/// </summary>
        /// <param name="modelData">Model data.</param>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="editorFactoryId">EditorFactory id.</param>
        protected ModelShellData(ModelData modelData, IServiceProvider serviceProvider, Guid editorFactoryId)
            : base(serviceProvider, editorFactoryId)
		{
            this.ModelData = modelData;
		}

        /// <summary>
        /// Gets or sets the model data.
        /// </summary>
        public ModelData ModelData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the root element.
        /// </summary>
        public new ModelElement RootElement
        {
            get
            {
                return this.ModelData.CurrentModelContext.RootElement;
            }
        }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public new string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FullFileName
        {
            get;
            set;
        }

        /// <summary>
        /// Create and return a new store
        /// </summary>
        /// <remarks>
        /// Override the default behaviour to put the doc data's composition container into the store's property bag.
        /// By default, the runtime will add the CompositionService from the DslShell ModelingCompositionContainer
        /// if the property has not already been set.
        /// </remarks>
        protected override Store CreateStore()
        {
            return this.ModelData.Store;
        }

		/// <summary>
		/// Returns a list of file format specifiers for the Save dialog box.
		/// </summary>
		protected override string FormatList
		{
			get
			{
                return this.ModelData.ResourceManager.GetString("FormatList");
			}
		}

        /// <summary>
        /// Return the model in XML format
        /// </summary>
        protected override string SerializedModel
        {
            get
            {
                return this.ModelData.CurrentModelContext.SerializedModel;
            }
        }

        /// <summary>
        /// Loads the given file.
        /// </summary>
        protected override void Load(string fileName, bool isReload)
        {
            this.ModelData.CurrentModelContext.Load(fileName, isReload);
        }

        /// <summary>
        /// Saves the given file.
        /// </summary>
        protected override void Save(string fileName)
        {
            this.ModelData.CurrentModelContext.Save(fileName);
        }
       
		/// <summary>
		/// Returns a collection of domain models to load into the store.
		/// </summary>
		/// <remarks>The default implementation includes any extension domain models returned by the call to GetExtensionDomainModels().</remarks>
		protected override global::System.Collections.Generic.IList<global::System.Type> GetDomainModels()
		{
            List<Type> types = new List<Type>();
            types.AddRange(this.ModelData.GetDomainModelsInternal());

            return types;
		}

        /// <summary>
        /// Get the Partition where model data will be loaded into.
        /// Base implementation returns the default partition of the store.
        /// </summary>
        protected internal virtual Partition GetModelPartition()
        {
            return this.ModelData.GetModelPartition();
        }

        /// <summary>
        /// Reset the model data on close.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDocumentClosed(EventArgs e)
        {
            base.OnDocumentClosed(e);
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //    this.ModelData.Dispose();

            // delay disposing
            //base.Dispose(disposing);
        }

        /// <summary>
        /// Reset.
        /// </summary>
        public virtual void CloseData()
        {
            this.CloseDocument();

            this.ModelData.Reset();

            base.Dispose(true);
        }

        /// <summary>
        /// Close document.
        /// </summary>
        public virtual void CloseDocument()
        {
            if (this.ModelData.CurrentModelContext != null)
                this.ModelData.CurrentModelContext.Reset();
        }

    }
}

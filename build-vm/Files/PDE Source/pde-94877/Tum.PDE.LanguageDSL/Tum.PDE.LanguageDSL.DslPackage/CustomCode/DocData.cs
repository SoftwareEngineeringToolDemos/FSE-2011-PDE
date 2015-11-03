using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.View.Forms;
using Tum.PDE.LanguageDSL.Visualization.ViewModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Services;
using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling.Immutability;
using Microsoft.VisualStudio.Modeling.Shell;
using Tum.PDE.LanguageDSL.Visualization.View.Optimization;

namespace Tum.PDE.LanguageDSL
{
    internal partial class LanguageDSLDocData
    {
        public static ModelData ModelData;
        public static ViewModelStore ViewModelStore;
        public MainSurfaceViewModel ViewModel;

        /// <summary>
        /// Loads the given file.
        /// </summary>
        protected void LoadVModell(string fileName, bool isReload)
        {
            SerializationResult serializationResult = new SerializationResult();
            global::Tum.PDE.LanguageDSL.MetaModel modelRoot = null;
            ISchemaResolver schemaResolver = new ModelingSchemaResolver(this.ServiceProvider);
            //clear the current root element
            this.SetRootElement(null);
            modelRoot = global::Tum.PDE.LanguageDSL.LanguageDSLSerializationHelper.Instance.LoadModel(serializationResult, this.GetModelPartition(), fileName, schemaResolver, null /* no load-time validation */, this.SerializerLocator, true, true);

            // Report serialization messages.
            this.SuspendErrorListRefresh();
            try
            {
                foreach (SerializationMessage serializationMessage in serializationResult)
                {
                    this.AddErrorListItem(new SerializationErrorListItem(this.ServiceProvider, serializationMessage));
                }
            }
            finally
            {
                this.ResumeErrorListRefresh();
            }

            if (serializationResult.Failed)
            {
                // Load failed, can't open the file.
                throw new global::System.InvalidOperationException(global::Tum.PDE.LanguageDSL.LanguageDSLDomainModel.SingletonResourceManager.GetString("CannotOpenDocument"));
            }
            else
            {
                this.SetRootElement(modelRoot);

                // Attempt to set the encoding
                if (serializationResult.Encoding != null)
                {
                    this.ModelingDocStore.SetEncoding(serializationResult.Encoding);
                    global::Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(this.SetDocDataDirty(0)); // Setting the encoding will mark the document as dirty, so clear the dirty flag.
                }

            }
        }

        protected override void Load(string fileName, bool isReload)
        {
            MetaModel.BaseGlobalDirectory = MetaModelLibraryBase.GetBaseDirectory(fileName);
            LoadVModell(fileName, isReload);

            MetaModel model = this.RootElement as MetaModel;
            model.IsTopMost = true;

            // set locks to imported libraries
            SetLocksToImportedLibraries(model);
            
            // create model data, store and view model
            ModelData = new ModelData(model);
            ViewModelStore = new ViewModelStore(ModelData);
            ViewModel = new MainSurfaceViewModel(ViewModelStore);

            // register known windows
            try
            {
                IUIVisualizerService popupVisualizer = ViewModel.GlobalServiceProvider.Resolve<IUIVisualizerService>();
                popupVisualizer.Register("TargetSelectorForm", typeof(TargetSelectorForm));
                popupVisualizer.Register("CategorizedSelectionPopup", typeof(CategorizedSelectionPopup));
                popupVisualizer.Register("DiagramClassTemplateSelector", typeof(DiagramClassTemplateSelector));
                popupVisualizer.Register("DataTemplatePresetsPopup", typeof(DataTemplatePresetsPopup));
                popupVisualizer.Register("OptimizationControl", typeof(OptimizationControl));
            }
            catch { }
        }
        private void SetLocksToImportedLibraries(MetaModel model)
        {
            ReadOnlyCollection<ModelElement> elements = model.Store.ElementDirectory.FindElements(MetaModel.DomainClassId);
            foreach (ModelElement m in elements)
            {
                MetaModel meta = m as MetaModel;
                if( meta != model && meta != null )
                    MetaModelLibraryBase.SetLocks(meta, Locks.All);
            }
        }
    }
}

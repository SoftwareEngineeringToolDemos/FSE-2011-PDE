using System;
namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class represents a model context.
    /// </summary>
    public abstract class ModelContext : BaseModelContext
    {
        private bool bInLoad = false;
        private bool bInReload = false;
        private bool bIsDirty = false;

        /// <summary>
        /// Root model element.
        /// </summary>
        protected Microsoft.VisualStudio.Modeling.ModelElement rootModelElement = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData"></param>
        public ModelContext(ModelData modelData)
            : base(modelData)
        {
        }

        /// <summary>
        /// Serialization result.
        /// </summary>
        public abstract SerializationResult SerializationResult { get; }

        /// <summary>
        /// The Root Element that identifies the portion of the store owned by this DocData.
        /// </summary>
        public Microsoft.VisualStudio.Modeling.ModelElement RootElement { get { return rootModelElement; } }

        /// <summary>
        /// True if data is beeing loaded. False otherwise.
        /// </summary>
        public bool InLoad { get { return bInLoad; } }

        /// <summary>
        /// True if the data is beeing reloaded. False otherwise.
        /// </summary>
        public bool InReload { get { return bInReload; } }

        /// <summary>
        /// Loads the domain model from a specified file. 
        /// </summary>
        /// <param name="fileName">Filename to load the domain model from.</param>
        /// <param name="isReload">True if the document is beeing reloaded.</param>
        protected abstract void LoadDocument(string fileName, bool isReload);

        /// <summary>
        /// Loads the domain model from a specified file.  This will not replace the currently loaded domain model.
        /// </summary>
        protected abstract Microsoft.VisualStudio.Modeling.ModelElement LoadDocumentInternal(string fileName);

        /// <summary>
        /// Saves the domain model to a specified filename.
        /// </summary>
        /// <param name="fileName">Filename to save the domain model to.</param>
        protected abstract void SaveDocument(string fileName);

        /// <summary>
        /// Saves the domain model to a specified filename. This serialization is treated as temporarly and as such does
        /// not change the default saving location of the current domain model.
        /// </summary>
        /// <param name="fileName">Filename to save the domain model to.</param>
        protected abstract void SaveDocumentTemporarly(string fileName);

        /// <summary>
        /// Loads the document from a given file name.
        /// </summary>
        /// <param name="fileName">Filename from which to load the document data.</param>
        /// <param name="isReload">True if the document is reloading.</param>
        public virtual void Load(string fileName, bool isReload)
        {
            Reset();

            if (isReload)
                OnDocumentReloading(new EventArgs());

            else
                OnDocumentLoading(new EventArgs());

            //currentModelFileName = fileName;

            Microsoft.VisualStudio.Modeling.Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load Model", true);
            ModelData.DoSendModelEvents = false;
            try
            {
                LoadDocument(fileName, isReload);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                this.SerializationResult.AddMessage(new SerializationMessage(ModelValidationMessageIds.SerializationLoadErrorId, ModelValidationViolationType.Error,
                    ex.Message, fileName, 0, 0));
            }
            ModelData.DoSendModelEvents = true;

            // clear undo manager stack
            if( !this.ModelData.Store.TransactionActive )
                this.ModelData.UndoManager.Flush();
            this.ModelData.RaiseUndoRedoChangeEvents();

            this.IsDirty = false;

            OnPropertyChanged("CanUndo");
            OnPropertyChanged("CanRedo");

            if (isReload)
                OnDocumentReloaded(new EventArgs());

            else
                OnDocumentLoaded(new EventArgs());
        }

        /// <summary>
        /// Loads the document from a given file name. This will not replace the currently loaded domain model neither will it send events.
        /// </summary>
        /// <param name="fileName">Filename from which to load the document data.</param>
        public virtual Microsoft.VisualStudio.Modeling.ModelElement LoadInternal(string fileName)
        {
            Microsoft.VisualStudio.Modeling.Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Load Model Internal", true);

            try
            {
                Microsoft.VisualStudio.Modeling.ModelElement modelElement = LoadDocumentInternal(fileName);
                transaction.Commit();

                return modelElement;
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                this.SerializationResult.AddMessage(new SerializationMessage(ModelValidationMessageIds.SerializationLoadErrorId, ModelValidationViolationType.Error,
                    ex.Message, fileName, 0, 0));

                return null;
            }

        }

        /// <summary>
        /// Saves the document to a given file name.
        /// </summary>
        /// <param name="fileName">Filename to save the document data to.</param>
        public virtual void Save(string fileName)
        {
            OnDocumentSaving(new EventArgs());

            Microsoft.VisualStudio.Modeling.Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Save Model", true);
            try
            {
                SaveDocument(fileName);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                this.SerializationResult.AddMessage(new SerializationMessage(ModelValidationMessageIds.SerializationSaveErrorId, ModelValidationViolationType.Error,
                    ex.Message, fileName, 0, 0));
            }

            this.IsDirty = false;

            OnDocumentSaved(new EventArgs());
        }

        /// <summary>
        /// Saves the document to a given file name. This serialization is treated as temporarly and as such does
        /// not change the default saving location of the current domain model.
        /// </summary>
        /// <param name="fileName">Filename to save the document data to.</param>
        public virtual void SaveTemporarly(string fileName)
        {
            Microsoft.VisualStudio.Modeling.Transaction transaction = this.ModelData.Store.TransactionManager.BeginTransaction("Save Model Temporarly", true);
            try
            {
                SaveDocumentTemporarly(fileName);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                this.SerializationResult.AddMessage(new SerializationMessage(ModelValidationMessageIds.SerializationSaveErrorId, ModelValidationViolationType.Error,
                    ex.Message, fileName, 0, 0));
            }
        }

        /// <summary>
        /// Return the model in XML format (SerializationMode.InternalToString).
        /// </summary>
        public virtual string SerializedModel
        {
            get
            {
                return System.String.Empty;
            }
        }

        /// <summary>
        /// Return the model in XML format (SerializationMode.InternalFullToString).
        /// </summary>
        public virtual string SerializedFullModel
        {
            get
            {
                return System.String.Empty;
            }
        }

        /// <summary>
        /// True if the document data has changed since the last save. False otherwise.
        /// </summary>
        public virtual bool IsDirty
        {
            get { return this.bIsDirty; }
            set { this.bIsDirty = value; }
        }

        /*
        /// <summary>
        /// Gets the fileName of the currently loaded domain model.
        /// </summary>
        public virtual string CurrentModelFileName
        {
            get
            {
                return currentModelFileName;
            }
        }*/

        /// <summary>
        /// Gets a specific diagram.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract Microsoft.VisualStudio.Modeling.ModelElement GetDiagram(string name);

        /// <summary>
        /// Called whever a transaction is commited.
        /// </summary>
        /// <param name="e"></param>
        public override void TransactionCommited(Microsoft.VisualStudio.Modeling.TransactionCommitEventArgs e)
        {
            base.TransactionCommited(e);

            if (!this.IsDirty)
                this.IsDirty = true;
        }

        /// <summary>
        /// Resets the current document data.
        /// </summary>
        public override void Reset()
        {
            bool bSendClosedEvent = false;
            if (this.RootElement != null)
            {
                OnDocumentClosing(new EventArgs());
                bSendClosedEvent = true;
            }

            this.rootModelElement = null;

            if (bSendClosedEvent)
                OnDocumentClosed(new EventArgs());

            this.bIsDirty = false;
        }

        /// <summary>
        /// Fired after the document is closed.
        /// </summary>
        public event EventHandler DocumentClosed;

        /// <summary>
        /// Fired before the document is closed.
        /// </summary>
        public event EventHandler DocumentClosing;

        /// <summary>
        /// Fires after the document has been initially loaded.
        /// </summary>
        public event EventHandler DocumentLoaded;

        /// <summary>
        /// Fires before the document is intitially loaded with data.
        /// </summary>
        public event EventHandler DocumentLoading;

        /// <summary>
        /// Fires after the document has been reloaded.
        /// </summary>
        public event EventHandler DocumentReloaded;

        /// <summary>
        /// Fires before the document is reloaded.
        /// </summary>
        public event EventHandler DocumentReloading;

        /// <summary>
        /// Fires after the document has been saved.
        /// </summary>
        public event EventHandler DocumentSaved;

        /// <summary>
        /// Fires before the document is saved.
        /// </summary>
        public event EventHandler DocumentSaving;

        /// <summary>
        /// Called after the document is closed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentClosed(EventArgs e)
        {
            if (DocumentClosed != null)
                DocumentClosed(this, e);
        }

        /// <summary>
        /// Called before the document is closed
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentClosing(EventArgs e)
        {
            if (DocumentClosing != null)
                DocumentClosing(this, e);
        }

        /// <summary>
        /// Called after the document has been initially loaded.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentLoaded(EventArgs e)
        {
            if (DocumentLoaded != null)
                DocumentLoaded(this, e);
        }

        /// <summary>
        /// Called before the document is initially loaded with data.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentLoading(EventArgs e)
        {
            if (DocumentLoading != null)
                DocumentLoading(this, e);
        }

        /// <summary>
        /// Called after the document has been reloaded.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentReloaded(EventArgs e)
        {
            if (DocumentReloaded != null)
                DocumentReloaded(this, e);
        }

        /// <summary>
        /// Called before the document is reloaded.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentReloading(EventArgs e)
        {
            if (DocumentReloading != null)
                DocumentReloading(this, e);
        }

        /// <summary>
        /// Called after the document has been saved.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentSaved(EventArgs e)
        {
            if (DocumentSaved != null)
                DocumentSaved(this, e);
        }

        /// <summary>
        /// Called before the document is saved.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDocumentSaving(EventArgs e)
        {
            if (DocumentSaving != null)
                DocumentSaving(this, e);
        }
    }
}

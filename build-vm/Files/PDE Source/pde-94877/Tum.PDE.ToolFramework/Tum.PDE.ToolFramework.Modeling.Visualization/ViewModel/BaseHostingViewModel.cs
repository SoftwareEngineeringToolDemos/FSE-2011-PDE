using System;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This is the base view model for any view model that can be hosted within a docking window. As such, it can
    /// be activated to be the main activated view and it can also host elements.
    /// </summary>
    /// <remarks>
    /// This view model provides default menu commands which consist of
    /// - Delete,
    /// - Cut,
    /// - Copy,
    /// - Paste,
    /// - Undo,
    /// - Redo,
    /// - Validate
    /// 
    /// You should override the corresponding On**CanExecute and On**Executed to specify custom behaviour if needed. By default,
    /// only the undo and redo commands are binded to specific actions (Executing the ModelData undo and redo methods).
    /// </remarks>
    public abstract class BaseHostingViewModel : BaseViewModel
    {
        /// <summary>
        /// Is view active value holder.
        /// </summary>
        protected bool isActiveView = false;

        /// <summary>
        /// Is view reseting value holder.
        /// </summary>
        protected bool isReseting = false;

        private DelegateCommand loadedCommand;
        private DelegateCommand unloadedCommand;

        // default menu commands
        private DelegateCommand deleteCommand;
        private DelegateCommand cutCommand;
        private DelegateCommand copyCommand;
        private DelegateCommand pasteCommand;
        private DelegateCommand undoCommand;
        private DelegateCommand redoCommand;
        private DelegateCommand validateCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected BaseHostingViewModel(ViewModelStore viewModelStore)
            : this(viewModelStore, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="bCallIntialize">True if the Initialize method should be called.</param>
        protected BaseHostingViewModel(ViewModelStore viewModelStore, bool bCallIntialize)
            : base(viewModelStore, bCallIntialize)
        {
            // init base commands
            loadedCommand = new DelegateCommand(OnLoaded);
            unloadedCommand = new DelegateCommand(OnUnloaded);

            this.EventManager.GetEvent<DocumentClosedEvent>().Subscribe(this.OnDocumentClosedEvent);
            this.EventManager.GetEvent<DocumentOpenedEvent>().Subscribe(this.OnDocumentOpenedEvent);
        }

        private void OnDocumentClosedEvent(DocumentEventArgs args)
        {
            this.OnDocumentClosed();
        }
        private void OnDocumentOpenedEvent(DocumentEventArgs args)
        {
            this.OnDocumentLoaded();
        }

        #region Default Menu Commands
        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            // init default menu commands
            this.deleteCommand = new DelegateCommand(OnDeleteCommandExecuted, OnDeleteCommandCanExecute);

            this.cutCommand = new DelegateCommand(OnCutCommandExecuted, OnCutCommandCanExecute);
            this.copyCommand = new DelegateCommand(OnCopyCommandExecuted, OnCopyCommandCanExecute);
            this.pasteCommand = new DelegateCommand(OnPasteCommandExecuted, OnPasteCommandCanExecute);
            /*
            deleteCommand = new DelegateCommand(OnDeleteCommandExecuted, OnDeleteCommandCanExecute, true);
            
            cutCommand = new DelegateCommand(OnCutCommandExecuted, OnCutCommandCanExecute, true);
            copyCommand = new DelegateCommand(OnCopyCommandExecuted, OnCopyCommandCanExecute, true);
            pasteCommand = new DelegateCommand(OnPasteCommandExecuted, OnPasteCommandCanExecute, true);
            */

            this.undoCommand = new DelegateCommand(OnUndoCommandExecuted, OnUndoCommandCanExecute);
            this.redoCommand = new DelegateCommand(OnRedoCommandExecuted, OnRedoCommandCanExecute);
            this.validateCommand = new DelegateCommand(OnValidateCommandExecuted, OnValidateCommandCanExecute);

            this.EventManager.GetEvent<ResetViewModelEvent>().Subscribe(new Action<ViewModelEventArgs>(Reset),
                ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism.Presentation.ThreadOption.PublisherThread, false);
            this.EventManager.GetEvent<CultureInfoChangedEvent>().Subscribe(OnCultureInfoChanged);
        }

        /// <summary>
        /// Raises commands can execute event.
        /// </summary>
        public virtual void UpdateCommandsCanExecute()
        {
            if( this.DeleteCommand != null )
                DeleteCommand.RaiseCanExecuteChanged();
            if (this.CutCommand != null)
                CutCommand.RaiseCanExecuteChanged();
            if (this.CopyCommand != null)
                CopyCommand.RaiseCanExecuteChanged();
            if (this.PasteCommand != null)
                PasteCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Delete command.
        /// </summary>
        public DelegateCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        /// <summary>
        /// Cut command.
        /// </summary>
        public DelegateCommand CutCommand
        {
            get
            {
                return cutCommand;
            }
        }

        /// <summary>
        /// Copy command.
        /// </summary>
        public DelegateCommand CopyCommand
        {
            get
            {
                return copyCommand;
            }
        }

        /// <summary>
        /// Paste command.
        /// </summary>
        public DelegateCommand PasteCommand
        {
            get
            {
                return pasteCommand;
            }
        }

        /// <summary>
        /// Undo command.
        /// </summary>
        public DelegateCommand UndoCommand
        {
            get
            {
                return undoCommand;
            }
        }

        /// <summary>
        /// Redo command.
        /// </summary>
        public DelegateCommand RedoCommand
        {
            get
            {
                return redoCommand;
            }
        }

        /// <summary>
        /// Validate command.
        /// </summary>
        public DelegateCommand ValidateCommand
        {
            get
            {
                return validateCommand;
            }
        }

        /// <summary>
        /// Delete command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnDeleteCommandCanExecute()
        {
            return false;
        }

        /// <summary>
        /// Cut command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnCutCommandCanExecute()
        {
            return false;
        }

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnCopyCommandCanExecute()
        {
            return false;
        }

        /// <summary>
        /// Paste command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnPasteCommandCanExecute()
        {
            return false;
        }

        /// <summary>
        /// Undo command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnUndoCommandCanExecute()
        {
            return this.ModelData.CanUndo;
        }

        /// <summary>
        /// Redo command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnRedoCommandCanExecute()
        {
            return this.ModelData.CanRedo;
        }

        /// <summary>
        /// Validate command can execute.
        /// </summary>
        /// <returns>True if the command can be executed. False otherwise.</returns>
        protected virtual bool OnValidateCommandCanExecute()
        {
            return false;
        }

        /// <summary>
        /// Delete command execute.
        /// </summary>
        protected virtual void OnDeleteCommandExecuted()
        {
        }

        /// <summary>
        /// Cut command execute.
        /// </summary>
        protected virtual void OnCutCommandExecuted()
        {
        }

        /// <summary>
        /// Copy command execute.
        /// </summary>
        protected virtual void OnCopyCommandExecuted()
        {
        }

        /// <summary>
        /// Paste command execute.
        /// </summary>
        protected virtual void OnPasteCommandExecuted()
        {
        }

        /// <summary>
        /// Undo command execute.
        /// </summary>
        protected virtual void OnUndoCommandExecuted()
        {
            this.ModelData.Undo();
        }

        /// <summary>
        /// Redo command execute.
        /// </summary>
        protected virtual void OnRedoCommandExecuted()
        {
            this.ModelData.Redo();
        }

        /// <summary>
        /// Validate command execute.
        /// </summary>
        protected virtual void OnValidateCommandExecuted()
        {
        }
        #endregion

        /// <summary>
        /// Culture info changed event.
        /// </summary>
        /// <param name="args">CultureInfo changed event arguments.</param>
        protected virtual void OnCultureInfoChanged(CultureInfoChangedEventArgs args)
        {
        }

        /// <summary>
        /// Reset ressources.
        /// </summary>
        protected virtual void OnReset()
        {
            this.DeleteCommand.RaiseCanExecuteChanged();
            this.CutCommand.RaiseCanExecuteChanged();
            this.CopyCommand.RaiseCanExecuteChanged();
            this.PasteCommand.RaiseCanExecuteChanged();
            this.UndoCommand.RaiseCanExecuteChanged();
            this.RedoCommand.RaiseCanExecuteChanged();
            this.ValidateCommand.RaiseCanExecuteChanged();
        }
                
        /// <summary>
        /// Reset ressources.
        /// </summary>
        private void Reset(ViewModelEventArgs eventArgs)
        {
            isReseting = true;

            OnReset();

            isReseting = false;
        }

        /// <summary>
        /// True if the view model is reseting; False otherwise.
        /// </summary>
        public bool IsReseting
        {
            get { return this.isReseting; }
        }       

        /// <summary>
        /// Command, which is called from the ui when the view is loaded.
        /// </summary>
        public DelegateCommand LoadedCommand
        {
            get { return loadedCommand; }
        }

        /// <summary>
        /// Command, which is called from the ui when the view is unloaded.
        /// </summary>
        public DelegateCommand UnloadedCommand
        {
            get { return unloadedCommand; }
        }

        /// <summary>
        /// Gets or sets whether this view is the currently active view in the application.
        /// </summary>
        public virtual bool IsActiveView
        {
            get { return isActiveView; }
            set
            {
                this.isActiveView = value;

                // notify of change
                OnPropertyChanged("IsActiveView");
            }
        }

        /// <summary>
        /// Called whenever the view is activated
        /// </summary>
        protected virtual void OnActivated()
        {
            if (this.IsActiveView != true)
                this.IsActiveView = true;
        }

        /// <summary>
        /// Called when the view is loaded.
        /// </summary>
        protected virtual void OnLoaded()
        {

        }

        /// <summary>
        /// Called whenever a document is loaded in this context.
        /// </summary>
        public virtual void OnDocumentLoaded()
        {
        }

        /// <summary>
        /// Called whenever a document is closed in this context.
        /// </summary>
        public virtual void OnDocumentClosed()
        {
        }

        /// <summary>
        /// Called when the view is unloaded
        /// </summary>
        protected virtual void OnUnloaded()
        {

        }

        /// <summary>
        /// Clean-up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<ResetViewModelEvent>().Unsubscribe(new Action<ViewModelEventArgs>(Reset));
            this.EventManager.GetEvent<CultureInfoChangedEvent>().Unsubscribe(OnCultureInfoChanged);

            this.EventManager.GetEvent<DocumentClosedEvent>().Unsubscribe(this.OnDocumentClosedEvent);
            this.EventManager.GetEvent<DocumentOpenedEvent>().Unsubscribe(this.OnDocumentOpenedEvent);

            base.OnDispose();

            //activatedCommand = null;
            this.loadedCommand = null;
            this.unloadedCommand = null;
        }
    }
}

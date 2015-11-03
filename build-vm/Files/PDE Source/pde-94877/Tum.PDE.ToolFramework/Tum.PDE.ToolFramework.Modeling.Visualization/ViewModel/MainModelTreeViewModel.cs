using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Operations;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ErrorList;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Menu;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// View model used for the model tree.
    /// </summary>
    public abstract class MainModelTreeViewModel : BaseDockingViewModel
    {
        private BaseModelElementTreeViewModel clickedItemViewModel;
        private BaseModelElementTreeViewModel selectedItemViewModel;

        /// <summary>
        /// Storage for the root tree item.
        /// </summary>
        protected BaseModelElementTreeViewModel rootTreeViewItemViewModelStorage = null;
        private ObservableCollection<BaseModelElementTreeViewModel> rootViewModels = null;
        private SelectedItemsCollection selectedItemsCollection = null;

        /// <summary>
        /// Context menu.
        /// </summary>
        protected MenuItemViewModel contextMenu = null;

        /// <summary>
        /// Default context menu.
        /// </summary>
        protected MenuItemViewModel defaultContextMenu = null;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainModelTreeViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            contextMenu = defaultContextMenu;

            this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));
        }

        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();

            if (this.selectedItemViewModel != null)
                this.selectedItemViewModel.IsSelected = false;

            OnPropertyChanged("RootViewModels");
        }

        /// <summary>
        /// Gets the root elements collection for binding to the tree view. It actually consists of only one element at all times.
        /// </summary>
        public virtual ObservableCollection<BaseModelElementTreeViewModel> RootViewModels
		{
			get
			{
                if (rootViewModels == null && this.ModelData.CurrentModelContext.RootElement != null)
                {
                    rootTreeViewItemViewModelStorage = this.ViewModelStore.Factory.CreateModelElementTreeViewModel(this.ModelData.CurrentModelContext.RootElement, true, true, this);
                    rootViewModels  = new System.Collections.ObjectModel.ObservableCollection<BaseModelElementTreeViewModel>();
                    rootViewModels.Add(rootTreeViewItemViewModelStorage);
                }
                return rootViewModels;
			}
		}

        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        #region IDockableViewModel
        /// <summary>
        /// Unique name of the model tree docking window.
        /// </summary>
        public override string DockingPaneName
        {
            get { return "ModelTreeViewDockWindow"; }
        }

        /// <summary>
        /// Title of the docking windo.
        /// </summary>
        public override string DockingPaneTitle
        {
            get { return "Model Tree"; }
        }
        #endregion

        #region Default Commands Overrides
        /// <summary>
        /// Validate command can execute.
        /// </summary>
        /// <returns></returns>
        protected override bool OnValidateCommandCanExecute()
        {
            if (this.SelectedItemViewModel != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Validate command executed.
        /// </summary>
        protected override void OnValidateCommandExecuted()
        {
            if (this.SelectedItemViewModel == null)
                return;

            using (new ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
            {
                // clear error list
                this.EventManager.GetEvent<ErrorListClearItems>().Publish(this);

                List<IValidationMessage> messages = this.ModelData.CurrentModelContext.Validate(this.SelectedItemViewModel.Element);
                List<BaseErrorListItemViewModel> items = new List<BaseErrorListItemViewModel>();
                foreach (IValidationMessage message in messages)
                {
                    if (message is ModelValidationMessage)
                    {
                        ModelErrorListItemViewModel item = new ModelErrorListItemViewModel(this.ViewModelStore, message as ModelValidationMessage);
                        items.Add(item);
                    }
                    else if (message is ValidationMessage)
                    {
                        StringErrorListItemViewModel item = new StringErrorListItemViewModel(this.ViewModelStore, message.MessageId, ModelErrorListItemViewModel.ConvertCategory(message.Type), message.Description);
                        items.Add(item);
                    }
                }

                // notify of change
                this.EventManager.GetEvent<ErrorListAddItems>().Publish(items);
            }
        }

        /// <summary>
        /// Delete command can execute.
        /// </summary>
        /// <returns></returns>
        protected override bool OnDeleteCommandCanExecute()
        {
            if (this.SelectedItemViewModel != null)
            {
                if (!this.SelectedItemViewModel.IsDomainModel)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Delete command executed.
        /// </summary>
        protected override void OnDeleteCommandExecuted()
        {
            if (this.SelectedItemViewModel != null)
                if (!this.SelectedItemViewModel.IsDomainModel)
                    this.SelectedItemViewModel.Delete();
        }

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        /// <returns></returns>
        protected override bool OnCopyCommandCanExecute()
        {
            if (this.SelectedItemViewModel != null)
                return this.SelectedItemViewModel.OnCopyCommandCanExecute();

            return false;
        }

        /// <summary>
        /// Copy command executed.
        /// </summary>
        protected override void OnCopyCommandExecuted()
        {
            if (this.SelectedItemViewModel != null)
                this.SelectedItemViewModel.OnCopyCommandExecuted();
        }

        /// <summary>
        /// Paste command can execute.
        /// </summary>
        /// <returns></returns>
        protected override bool OnPasteCommandCanExecute()
        {
            if (this.SelectedItemViewModel != null)
            {
                return this.SelectedItemViewModel.OnPasteCommandCanExecute();
            }
            return false;
        }

        /// <summary>
        /// Paste command executed.
        /// </summary>
        protected override void OnPasteCommandExecuted()
        {
            if (this.SelectedItemViewModel != null)
            {
                this.SelectedItemViewModel.OnPasteCommandExecuted();
            }

            PasteCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Cut command can execute.
        /// </summary>
        /// <returns></returns>
        protected override bool OnCutCommandCanExecute()
        {
            if (this.SelectedItemViewModel != null)
                return this.SelectedItemViewModel.OnCutCommandCanExecute();

            return false;
        }

        /// <summary>
        /// Cut command executed.
        /// </summary>
        protected override void OnCutCommandExecuted()
        {
            if (this.SelectedItemViewModel != null)
                this.SelectedItemViewModel.OnCutCommandExecuted();
        }
        #endregion

        /// <summary>
        /// Gets or sets the clicked view model in the view.
        /// </summary>
        public BaseModelElementTreeViewModel ClickedItemViewModel
        {
            get { return clickedItemViewModel; }
            set
            {
                this.clickedItemViewModel = value;
                OnPropertyChanged("ClickedItemViewModel");

                if (this.clickedItemViewModel != null)
                    this.ContextMenu = this.ClickedItemViewModel.ContextMenu;
                else
                    this.ContextMenu = defaultContextMenu;
            }
        }

        /// <summary>
        /// Gets or sets the clicked view model in the view.
        /// </summary>
        public BaseModelElementTreeViewModel SelectedItemViewModel
        {
            get {
                return selectedItemViewModel;
            }
            set
            {
                if (selectedItemViewModel == value)
                    return;

                selectedItemViewModel = value;
                if( selectedItemViewModel != null )
                    selectedItemViewModel.IsSelected = true;

                // propagate selection
                SelectedItemsCollection col = new SelectedItemsCollection();
                if( value != null )
                    col.Add(selectedItemViewModel.Element);

                // notify observers, that selection has changed
                if( this.IsActiveView && !this.IsReseting )
                    EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));

                OnPropertyChanged("SelectedItemViewModel");

            }
        }

        /// <summary>
        /// Gets the context menu view model for this view model.
        /// </summary>
        public virtual MenuItemViewModel ContextMenu
        {
            get
            {
                return this.contextMenu;
            }
            set
            {
                if (this.contextMenu != value)
                {
                    if( this.contextMenu != this.defaultContextMenu )
                        this.contextMenu.Dispose();

                    this.contextMenu = value;
                    OnPropertyChanged("ContextMenu");
                }
            }
        }

        /// <summary>
        /// This context menu is used whenever no item is selected. Can be null.
        /// </summary>
        public virtual MenuItemViewModel DefaultContextMenu
        {
            get
            {
                return this.defaultContextMenu;
            }
            set
            {
                this.defaultContextMenu = value;
                OnPropertyChanged("DefaultContextMenu");
            }
        }

        /// <summary>
        /// Callback from SelectionChangedEvent.
        /// </summary>
        /// <param name="eventArgs">SelectionChangedEventArgs.</param>
        protected virtual void ReactOnViewSelection(SelectionChangedEventArgs eventArgs)
        {
            if (eventArgs.SourceViewModel != this)
            {
                this.selectedItemsCollection = eventArgs.SelectedItems;

                if( this.IsDockingPaneVisible && this.IsInitialized )
                    Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                        System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateModelTree));
            }
        }

        /// <summary>
        /// Updates the model tree, based on SelectedItemsCollection.
        /// </summary>
        private void UpdateModelTree()
        {
            if (selectedItemsCollection == null)
            {
                // clear selection
                if (this.SelectedItemViewModel != null)
                    this.SelectedItemViewModel.IsSelected = false;

                this.SelectedItemViewModel = null;

                return;
            }

            if (selectedItemsCollection.Count == 1)
            {
                // search for the view model and select it
                BaseModelElementTreeViewModel foundModel = null;
                foreach (BaseModelElementTreeViewModel m in RootViewModels)
                {
                    foundModel = m.FindViewModel(selectedItemsCollection[0] as ModelElement);
                    if (foundModel != null)
                    {
                        //foundModel.IsSelected = true;
                        this.SelectedItemViewModel = foundModel;
                    }
                }

                if (foundModel == null)
                {
                    // clear selection
                    if (this.SelectedItemViewModel != null)
                        this.SelectedItemViewModel.IsSelected = false;

                    this.SelectedItemViewModel = null;
                }

            }
            else
            {
                // clear selection
                if (this.SelectedItemViewModel != null)
                    this.SelectedItemViewModel.IsSelected = false;

                this.SelectedItemViewModel = null;
            }
        }

        /// <summary>
        /// Reset selection.
        /// </summary>
        protected override void OnReset()
        {
            if (this.selectedItemViewModel != null)
                this.selectedItemViewModel.IsSelected = false;

            this.clickedItemViewModel = null;
            this.selectedItemViewModel = null;

            this.contextMenu = null;
            this.contextMenu = this.defaultContextMenu;

            if (rootViewModels != null)
                rootViewModels.Clear();
            rootViewModels = null;

            if (rootTreeViewItemViewModelStorage != null)
                rootTreeViewItemViewModelStorage.Dispose();
            rootTreeViewItemViewModelStorage = null;

            base.OnReset();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(ReactOnViewSelection));
        }

        /// <summary>
        /// Visibility change.
        /// </summary>
        /// <param name="bVisible"></param>
        protected override void OnVisibilityChanged(bool bVisible)
        {
            base.OnVisibilityChanged(bVisible);

            if (this.IsDockingPaneVisible && this.IsInitialized)
                Threading.DispatcherExtensions.InvokeAsynchronouslyInBackground(
                    System.Windows.Threading.Dispatcher.CurrentDispatcher, new Action(UpdateModelTree));
        }
    }
}

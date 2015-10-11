using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;

using Fluent;
using System;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This is the base class for any view model, which view is displayed in a docking tab (avalon dock).
    /// 
    /// This is used for the model tree, property grid, error list and any custom view the user provides.
    /// </summary>
    public abstract class BaseDockingViewModel : BaseHostingViewModel, IDockableViewModel, IRibbonDockableViewModel
    {
        private bool isDockingPaneVisible = false;
        private DelegateCommand showDockingPaneCommand;
        private bool isRibbonMenuInitialized = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected BaseDockingViewModel(ViewModelStore viewModelStore)
            : this(viewModelStore, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="bCallIntialize">True if the Initialize method should be called.</param>
        protected BaseDockingViewModel(ViewModelStore viewModelStore, bool bCallIntialize)
            : base(viewModelStore, false)
        {
            this.showDockingPaneCommand = new DelegateCommand(ShowDockingPaneCommand_Executed);
            this.FloatingWindowDesiredWidth = 200;
            this.FloatingWindowDesiredHeight = 500;
            this.DockedWindowDesiredHeight = 0.0;
            this.DockedWindowDesiredWidth = 0.0;

            if (bCallIntialize)
                this.PreInitialize();
        }

        /// <summary>
        /// Intialization.
        /// </summary>
        protected virtual void PreInitialize()
        {
        }

        /// <summary>
        /// Gets or sets whether this vm has been initialized or not.
        /// </summary>
        public bool IsInitialized
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialize vm.
        /// </summary>
        public void InitializeVM()
        {
            this.Initialize();
        }

        /// <summary>
        /// Intialization.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.IsInitialized = true;
        }

        #region IDockableViewModel
        /// <summary>
        /// Gets whether this vm should only be hidden whenever its closed. Otherwise, the vm is removed.
        /// </summary>
        public virtual bool HideOnClose
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the header image URI.
        /// </summary>
        public virtual string DockingPaneImageUri
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the floating windows desired width;
        /// </summary>
        public double FloatingWindowDesiredWidth { get; set; }

        /// <summary>
        /// Gets the floating windows desired height;
        /// </summary>
        public double FloatingWindowDesiredHeight { get; set; }

        /// <summary>
        /// Gets the activation mode.
        /// </summary>
        public virtual ActivationMode ActivationMode 
        {
            get
            {
                return ActivationMode.Normal;
            }
        }

        /// <summary>
        /// Unique name.
        /// </summary>
        public abstract string DockingPaneName { get; }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public abstract string DockingPaneTitle { get; }

        /// <summary>
        /// Is dockable window visible.
        /// </summary>
        public bool IsDockingPaneVisible
        {
            get { return isDockingPaneVisible; }
            set
            {
                if (this.isDockingPaneVisible != value)
                {
                    isDockingPaneVisible = value;
                    OnPropertyChanged("IsDockingPaneVisible");

                    OnVisibilityChanged(value);

                    //if (!this.isDockingPaneVisible && value)
                    //    this.OnOpened();
                    //else if (this.isDockingPaneVisible && !value)
                    //    this.OnClosed();

                    if (!value)
                        if (this.IsRibbonMenuInitialized)
                            HideRibbonMenu(this.Ribbon);
                }
            }
        }

        /// <summary>
        /// Gets the docked windows desired width;  Default = 0.0 --> handle automatically.
        /// </summary>
        public double DockedWindowDesiredWidth 
        { 
            get; set; 
        }

        /// <summary>
        /// Gets the docked windows desired height; Default = 0.0 --> handle automatically.
        /// </summary>
        public double DockedWindowDesiredHeight 
        { 
            get; set; 
        }

        /// <summary>
        /// Gets the docking pane style.
        /// </summary>
        public virtual DockingPaneStyle DockingPaneStyle 
        {
            get
            {
                return DockingPaneStyle.Docked;
            }
        }

        /// <summary>
        /// Gets the docking pane anchor style.
        /// </summary>
        public virtual DockingPaneAnchorStyle DockingPaneAnchorStyle
        {
            get
            {
                return DockingPaneAnchorStyle.None;
            }
        }

        /// <summary>
        /// Gets the context change kind. The default value is PreviewMouseDown.
        /// </summary>
        public virtual DockingContextChangeKind DockingContextChangeKind
        {
            get
            {
                return DockingContextChangeKind.PreviewMouseDown;
            }
        }

        /// <summary>
        /// Type of this vm.
        /// </summary>
        public virtual Type DockingPaneType
        {
            get
            {
                return this.GetType();
            }
        }

        #endregion

        #region Ribbon
        /// <summary>
        /// Gets the ribbon menu.
        /// </summary>
        public Ribbon Ribbon
        {
            get;
            private set;
        }

        /// <summary>
        /// This method is called once this docking window becomes active. 
        /// This method needs to overriden in the actual instances of this class to show contextual ribbon bars if required.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public virtual void ShowRibbonMenu(Ribbon ribbonMenu)
        {
        }

        /// <summary>
        /// This method is called once this docking window becomes inactive. 
        /// This method needs to overriden in the actual instances of this class to hide contextual ribbon bars.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public virtual void HideRibbonMenu(Ribbon ribbonMenu)
        {
        }

        /// <summary>
        /// This method needs to overriden in the actual instances of this class to create contextual
        /// or regular ribbon bars if required.
        /// </summary>
        /// <param name="ribbonMenu">Main ribbon menu.</param>
        public virtual void CreateRibbonMenu(Ribbon ribbonMenu)
        {
            Ribbon = ribbonMenu;

            IsRibbonMenuInitialized = true;
        }

        /// <summary>
        /// Gets or sets wether the ribbon menu has been initialized or not.
        /// </summary>
        public bool IsRibbonMenuInitialized
        {
            get
            {
                return this.isRibbonMenuInitialized;
            }
            set
            {
                this.isRibbonMenuInitialized = value;
            }
        }
        #endregion

        /// <summary>
        /// Hide ribbon menu on document closed if this is the active view.
        /// </summary>
        public override void OnDocumentClosed()
        {
            base.OnDocumentClosed();

            if (this.IsActiveView)
                if (this.IsRibbonMenuInitialized)
                    HideRibbonMenu(this.Ribbon);
        }

        /// <summary>
        /// Show ribbon menu on document loaded if this is the active view.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            base.OnDocumentLoaded();

            if (this.IsActiveView)
                if (this.IsRibbonMenuInitialized)
                    ShowRibbonMenu(this.Ribbon);
        }

        /// <summary>
        /// This method is called whenever the visibility changes.
        /// </summary>
        /// <param name="bVisible"></param>
        protected virtual void OnVisibilityChanged(bool bVisible)
        {
        }

        /// <summary>
        /// Gets or sets whether this view is the currently active view in the application.
        /// </summary>
        public override bool IsActiveView
        {
            get { return base.IsActiveView; }
            set
            {
                if( !value )
                    if( this.IsRibbonMenuInitialized )
                        HideRibbonMenu(this.Ribbon);

                base.IsActiveView = value;

                if (this.IsActiveView)
                    if (this.IsRibbonMenuInitialized)
                        ShowRibbonMenu(this.Ribbon);

                // notify other views of change
                if( !this.IsDisposed )
                    if( this.ActivationMode == Contracts.ViewModel.ActivationMode.Normal )
                        EventManager.GetEvent<ActiveViewChangedEvent>().Publish(new ActiveViewChangedEventArgs(this, this.IsActiveView));
            }
        }

        /// <summary>
        /// Show docking pane command.
        /// </summary>
        public DelegateCommand ShowDockingPaneCommand
        {
            get
            {
                return this.showDockingPaneCommand;
            }
        }

        /// <summary>
        /// ShowDockingPaneCommand executed. Publishes the ShowViewModelRequestEvent, so that this view model is
        /// opened in the application.
        /// </summary>
        protected virtual void ShowDockingPaneCommand_Executed()
        {
            ShowViewModelRequestEventArgs args = new ShowViewModelRequestEventArgs(this);
            args.DockingPaneAnchorStyle = this.DockingPaneAnchorStyle;
            args.DockingPaneStyle = this.DockingPaneStyle;
            this.EventManager.GetEvent<ShowViewModelRequestEvent>().Publish(args);
        }

        /*
        /// <summary>
        /// Called if this docking vm was closed.
        /// </summary>
        public virtual void OnClosed()
        {
        }

        /// <summary>
        /// Called if this docking vm was opened.
        /// </summary>
        public virtual void OnOpened()
        {
        }*/
    }

    /// <summary>
    /// Docking view model used to represent a null vm. 
    /// </summary>
    public class NullDockingViewModel : BaseDockingViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public NullDockingViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, false)
        {
            this.Initialize();
        }

        #region IDockableViewModel

        /// <summary>
        /// Unique name.
        /// </summary>
        public override string DockingPaneName 
        {
            get
            {
                return "NullDockingViewModel";
            }
        }

        /// <summary>
        /// Title of the dockable window.
        /// </summary>
        public override string DockingPaneTitle
        {
            get
            {
                return "";
            }
        }
        #endregion 

        private static NullDockingViewModel vm = null;

        /// <summary>
        /// Gets an instance of the null docking vm.
        /// </summary>
        /// <param name="store">ViewModelStore.</param>
        /// <returns>NullDockingVM.</returns>
        public static NullDockingViewModel GetNullDockingVM(ViewModelStore store)
        {
            if( vm == null )
                vm = new NullDockingViewModel(store);

            return vm;
        }
    }
}

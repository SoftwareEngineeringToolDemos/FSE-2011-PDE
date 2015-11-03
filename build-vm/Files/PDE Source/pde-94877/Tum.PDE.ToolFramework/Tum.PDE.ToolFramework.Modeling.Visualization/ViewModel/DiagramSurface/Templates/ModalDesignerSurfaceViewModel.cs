using System;
using System.Xml.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface.Templates
{
    /// <summary>
    /// This is the class for a modal diagram surface implementation.
    /// </summary>
    /// <remarks>
    /// The idea behind this class is to create a diagram surface that is opened for a specific element such
    /// as a 'Product' or a 'Milestone'. Therefore, this view model can not be opened from the default
    /// view menu, but either via the context menu of the model tree or programatically.
    /// </remarks>
    public abstract class ModalDesignerSurfaceViewModel : BaseDiagramSurfaceViewModel, IRestorableDockableViewModel
    {
        private DomainModelElement modelElement;
        private Guid nameExtension;
        private BaseModelElementViewModel modelElementVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element.</param>
        protected ModalDesignerSurfaceViewModel(ViewModelStore viewModelStore, DomainModelElement element)
            : base(viewModelStore, null, viewModelStore.ModelData.CurrentModelContext.Name, false)
        {
            this.modelElement = element;
            this.nameExtension = Guid.NewGuid();

            this.PreInitialize();
            this.Initialize();

            // if the hosted element is deleted, we have to close this
            this.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(this.modelElement.Id, OnModelElementDeleted);
        }

        /// <summary>
        /// Constuctor. This meant to be called if the model is beeing restored. Initialize in this
        /// case is called from the restore method.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected ModalDesignerSurfaceViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, null, viewModelStore.ModelData.CurrentModelContext.Name, false)
        {
            this.nameExtension = Guid.NewGuid();
        }

        #region IRestorableDockableViewModel
        /// <summary>
        /// Get the necessary information to restore this vm after it has been closed.
        /// </summary>
        /// <returns>Restore information.</returns>
        public virtual XElement GetInformationForRestore()
        {
            XElement element = new XElement("RestoreInfo");

            element.Add(new XElement("NameExtenstion", this.nameExtension.ToString()));
            element.Add(new XElement("HostedElementId", this.HostedElement.Id.ToString()));

            return element;
        }

        /// <summary>
        /// Get the docking pane type as string.
        /// </summary>
        /// <returns>Docking pane type.</returns>
        public virtual string GetDockingPaneType()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Restore the VM based on stored information.
        /// </summary>
        /// <param name="element">Info.</param>
        /// <returns>
        /// True if the restore process was successful. False otherwise.
        /// </returns>
        public virtual bool Restore(XElement element)
        {
            try
            {
                string nameExtensionValue = element.Element("NameExtenstion").Value;
                string elementIdValue = element.Element("HostedElementId").Value;

                this.nameExtension = new Guid(nameExtensionValue);
                Guid elementId = new Guid(elementIdValue);

                DomainModelElement e = this.Store.ElementDirectory.FindElement(elementId) as DomainModelElement;
                if (e != null)
                {
                    this.modelElement = e;
                    this.Initialize();

                    return true;
                }
            }
            catch { }

            return false;
        }
        #endregion

        #region IDockableViewModel
        /// <summary>
        /// Gets whether this vm should only be hidden whenever its closed. Otherwise, the vm is removed.
        /// </summary>
        public override bool HideOnClose
        {
            get
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Initialization routine.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            if (this.modelElement != null)
            {
                this.modelElementVM = new BaseModelElementViewModel(this.ViewModelStore, this.modelElement, true);

                // if the hosted element is deleted, we have to close this
                this.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(this.modelElement.Id, OnModelElementDeleted);
            }
        }

        /// <summary>
        /// Gets the hosted element.
        /// </summary>
        public DomainModelElement HostedElement
        {
            get
            {
                return this.modelElement;
            }
        }

        /// <summary>
        /// Gets the domain model element.
        /// </summary>
        public virtual BaseModelElementViewModel HostedElementVM
        {
            get
            {
                return this.modelElementVM;
            }
            set
            {
                if (this.modelElementVM != value)
                {
                    this.modelElementVM.Dispose();
                    this.modelElementVM = value;

                    OnPropertyChanged("HostedElementVM");
                }
            }
        }

        /// <summary>
        /// Title extension that is shown after the diagram name in the docking window.
        /// </summary>
        public string TitleExtension
        {
            get
            {
                if (this.modelElement != null)
                    return " - " + modelElement.DomainElementFullName;
                else
                    return "";
            }
        }

        /// <summary>
        /// Name extension. Since this diagram can be opened multiple times for different elements of a 
        /// specific type, we need to ensure that each of those diagrams has its own unique name.
        /// </summary>
        public String NameExtension
        {
            get
            {
                return nameExtension.ToString("N");
            }
        }

        /// <summary>
        /// Callen if the hosted element is deleted.
        /// </summary>
        /// <param name="arg">Data</param>
        protected virtual void OnModelElementDeleted(ElementDeletedEventArgs arg)
        {
            if (this.IsDisposed || this.IsDisposing)
                return;

            this.EventManager.GetEvent<CloseViewModelRequestEvent>().Publish(new CloseViewModelRequestEventArgs(this, true));

            if( !this.IsDisposed && !this.IsDisposing )
                this.Dispose();
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.modelElement != null)
            {
                this.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(this.modelElement.Id, OnModelElementDeleted);

                BaseModelElementViewModel v = this.modelElementVM;
                this.modelElementVM = null;
                
                OnPropertyChanged("HostedElementVM");
                v.Dispose();
              
                this.modelElement = null;
            }

            base.OnDispose();
        }

        /// <summary>
        /// Not required.
        /// </summary>
        /// <param name="ribbonMenu"></param>
        public override void CreateRibbonMenu(Fluent.Ribbon ribbonMenu)
        {
        }
    }
}

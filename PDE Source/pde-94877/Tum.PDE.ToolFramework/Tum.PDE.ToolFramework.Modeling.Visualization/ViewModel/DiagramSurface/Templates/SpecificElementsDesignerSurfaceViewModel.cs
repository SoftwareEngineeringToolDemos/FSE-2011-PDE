using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.DiagramSurface.Templates
{
    /// <summary>
    /// This is a diagram surface view model that can display the properties of a specific element.
    /// 
    /// </summary>
    /// <remarks>
    /// The displayed properties include Parent element, Child elements as well as Referenced elements.
    /// </remarks>
    public abstract class SpecificElementsDesignerSurfaceViewModel : BaseDiagramSurfaceViewModel
    {
        private BaseModelElementViewModel hostedElement;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContext">Model context.</param>
        protected SpecificElementsDesignerSurfaceViewModel(ViewModelStore viewModelStore, ModelContext modelContext)
            : base(viewModelStore, modelContext, false)
        {
            this.PreInitialize();
            //this.Initialize();
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelContextName">Model context name.</param>
        protected SpecificElementsDesignerSurfaceViewModel(ViewModelStore viewModelStore, string modelContextName)
            : base(viewModelStore, modelContextName, false)
        {
            this.PreInitialize();
            //this.Initialize();
        }

        /// <summary>
        /// Constuctor. This meant to be called if the model is beeing restored. Initialize in this
        /// case is called from the restore method.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        protected SpecificElementsDesignerSurfaceViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore, viewModelStore.ModelData.CurrentModelContext.Name, false)
        {
        }

        /// <summary>
        /// Gets or sets the hosted element.
        /// </summary>
        public virtual BaseModelElementViewModel HostedElement
        {
            get
            {
                return this.hostedElement;
            }
            set
            {
                if (this.hostedElement != value)
                {
                    if (this.hostedElement != null)
                        if (!this.hostedElement.IsDisposed)
                            this.hostedElement.Dispose();

                    this.hostedElement = value;

                    // subscribe to model element deletion event
                    if( this.hostedElement != null )
                        if (this.hostedElement.Element != null)
                            this.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(this.hostedElement.Element.Id, OnHostedElementDeleted);

                    OnPropertyChanged("HostedElement");
                }
            }
        }

        /// <summary>
        /// Called if the hosted element was deleted.
        /// </summary>
        /// <param name="args">Data</param>
        protected virtual void OnHostedElementDeleted(ElementDeletedEventArgs args)
        {
            this.HostedElement = null;
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.HostedElement != null)
            {
                if (this.hostedElement.Element != null)
                    this.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(this.hostedElement.Element.Id, OnHostedElementDeleted);

                this.hostedElement.Dispose();
                this.HostedElement = null;
            }

            base.OnDispose();
        }

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void Reset()
        {
            if (this.HostedElement != null)
            {
                if (this.hostedElement.Element != null)
                    this.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(this.hostedElement.Element.Id, OnHostedElementDeleted);

                this.hostedElement.Dispose();
                this.HostedElement = null;
            }

            base.Reset();
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

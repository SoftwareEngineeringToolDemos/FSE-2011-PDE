using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Diagrams;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Dependencies
{
    /// <summary>
    /// This base view model is used to display graphical dependencies as well as a list of specific items.
    /// </summary>
    public abstract class SpecificDependenciesViewModel : GraphicalDependenciesViewModel
    {
        private ObservableCollection<SpecificDependenciesItemViewModel> itemViewModels;
        private SpecificDependenciesItemViewModel selectedItemViewModel;
        private DomainClassInfo domainClassInfo;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">View model store containing this view model.</param>
        /// <param name="diagram"></param>
        /// <param name="modelContext"></param>
        public SpecificDependenciesViewModel(ViewModelStore viewModelStore, Diagram diagram, ModelContext modelContext)
            : base(viewModelStore, diagram, modelContext)
        {
            this.itemViewModels = new ObservableCollection<SpecificDependenciesItemViewModel>();
        }

        /// <summary>
        /// Gets the type of the model element that specifies the elements in the list of specific items.
        /// </summary>
        public abstract Guid ModelElementType
        {
            get;
        }

        /// <summary>
        /// Gets the specific item view models.
        /// </summary>
        public ObservableCollection<SpecificDependenciesItemViewModel> SpecificItemVMs
        {
            get
            {
                return this.itemViewModels;
            }
        }

        /// <summary>
        /// Gets or sets the selected specific item view model.
        /// </summary>
        public SpecificDependenciesItemViewModel SelectedSpecificItemVM
        {
            get
            {
                return this.selectedItemViewModel;
            }
            set
            {
                if (this.selectedItemViewModel != value)
                {
                    this.selectedItemViewModel = value;
                    OnPropertyChanged("SelectedSpecificItemVM");

                    if (this.selectedItemViewModel != null)
                        this.MainElement = this.selectedItemViewModel.Element;
                    else
                        this.MainElement = null;
                }
            }
        }

        private void OnElementAdded(ElementAddedEventArgs args)
        {
            SpecificDependenciesItemViewModel vm = this.CreateSpecificViewModel(this.ViewModelStore, args.ModelElement);
            this.itemViewModels.Add(vm);

            UpdateIndices();
        }
        private void OnElementDeleted(ElementDeletedEventArgs args)
        {
            if (this.SelectedSpecificItemVM != null)
                if (this.SelectedSpecificItemVM.Element.Id == args.ElementId)
                    this.SelectedSpecificItemVM = null;

            for (int i = SpecificItemVMs.Count - 1; i >= 0; i--)
            {
                if (SpecificItemVMs[i].Element.Id == args.ElementId)
                {
                    SpecificItemVMs[i].Dispose();
                    SpecificItemVMs.RemoveAt(i);
                }
            }

            UpdateIndices();
        }
        private void UpdateIndices()
        {
            for (int i = 0; i < this.SpecificItemVMs.Count; i++)
            {
                this.SpecificItemVMs[i].Index = i + 1;
            }
        }

        /// <summary>
        /// Initialization routine.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            this.domainClassInfo = this.Store.DomainDataDirectory.FindDomainClass(this.ModelElementType);

            if (this.domainClassInfo != null)
            {
                this.ViewModelStore.EventManager.GetEvent<ModelElementAddedEvent>().Subscribe(this.domainClassInfo, OnElementAdded);
                this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Subscribe(this.domainClassInfo, OnElementDeleted);
            }

            if (this.ModelData.CurrentModelContext.RootElement != null)
                InitSpecificVMs();
        }

        /// <summary>
        /// Document loaded.
        /// </summary>
        public override void OnDocumentLoaded()
        {
            InitSpecificVMs();
        }

        /// <summary>
        /// Document closed.
        /// </summary>
        public override void OnDocumentClosed()
        {
            ResetSpecificVMs();
        }

        /// <summary>
        /// Initializes the specific vms.
        /// </summary>
        protected virtual void InitSpecificVMs()
        {
            ReadOnlyCollection<ModelElement> col = this.Store.ElementDirectory.FindElements(this.ModelElementType);
            for (int i = 0; i < col.Count; i++)
            {
                SpecificDependenciesItemViewModel vm = this.CreateSpecificViewModel(this.ViewModelStore, col[i]);
                vm.Index = i + 1;
                this.itemViewModels.Add(vm);
            }

            if (this.SpecificItemVMs.Count > 0)
                this.SelectedSpecificItemVM = this.SpecificItemVMs[0];
        }

        /// <summary>
        /// Creates a specific view model for the given model element.
        /// </summary>
        /// <param name="store">Viewmodelstore.</param>
        /// <param name="modelElement">Model element to create a specific VM for.</param>
        /// <returns>Specific VM.</returns>
        protected abstract SpecificDependenciesItemViewModel CreateSpecificViewModel(ViewModelStore store, ModelElement modelElement);

        /// <summary>
        /// Resets the specific vms.
        /// </summary>
        protected virtual void ResetSpecificVMs()
        {
            for (int i = itemViewModels.Count - 1; i >= 0; i--)
            {
                itemViewModels[i].Dispose();
                itemViewModels.RemoveAt(i);
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            ResetSpecificVMs();

            if (this.domainClassInfo != null)
            {
                this.ViewModelStore.EventManager.GetEvent<ModelElementAddedEvent>().Unsubscribe(this.domainClassInfo, OnElementAdded);
                this.ViewModelStore.EventManager.GetEvent<ModelElementDeletedEvent>().Unsubscribe(this.domainClassInfo, OnElementDeleted);
            }

            base.OnDispose();
        }

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void OnReset()
        {
            ResetSpecificVMs();

            base.OnReset();
        }

        /// <summary>
        /// Drag over logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public override void DragOver(DropInfo dropInfo)
        {           
            dropInfo.Effects = System.Windows.DragDropEffects.None;
        }

        /// <summary>
        /// Drop logic.
        /// </summary>
        /// <param name="dropInfo">Info.</param>
        public override void Drop(DropInfo dropInfo)
        {
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

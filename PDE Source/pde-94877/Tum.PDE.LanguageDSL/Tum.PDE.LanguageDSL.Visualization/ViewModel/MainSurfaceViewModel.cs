using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.Commands;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    public class MainSurfaceViewModel : BaseWindowViewModel
    {
        private ObservableCollection<ModelContextViewModel> rootNodeVMs;
        private ReadOnlyObservableCollection<ModelContextViewModel> rootNodeVMsRO;
        private ModelContextViewModel selectedItem;


        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public MainSurfaceViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            this.rootNodeVMs = new ObservableCollection<ModelContextViewModel>();
            this.rootNodeVMsRO = new ReadOnlyObservableCollection<ModelContextViewModel>(this.rootNodeVMs);

            if (this.ModelData.MetaModel != null)
            {
                foreach (BaseModelContext mc in this.ModelData.MetaModel.ModelContexts)
                    AddModelContext(mc);

                // subscribe
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(MetaModelHasModelContexts.DomainClassId),
                    true, this.ModelData.MetaModel.Id, new Action<ElementAddedEventArgs>(OnModelContextAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(MetaModelHasModelContexts.DomainClassId),
                    true, this.ModelData.MetaModel.Id, new Action<ElementDeletedEventArgs>(OnModelContextRemoved));

                if (this.ModelContextVMs.Count > 0)
                    this.selectedItem = this.ModelContextVMs[0];
            }


           this.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new Action<SelectionChangedEventArgs>(OnSelectionChanged));
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                if (this.selectedItem != value && value is ModelContextViewModel)
                {
                    this.selectedItem = value as ModelContextViewModel;
                    if (selectedItem != null)
                    {
                        SelectedItemsCollection col = new SelectedItemsCollection();
                        col.Add(selectedItem.ModelContext);
                        EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
                    }

                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        /// <summary>
        /// Gets a read-only collection of model context vms.
        /// </summary>
        public ReadOnlyObservableCollection<ModelContextViewModel> ModelContextVMs
        {
            get
            {
                return this.rootNodeVMsRO;
            }
        }

        /// <summary>
        /// Adds a new model context view model for the given node.
        /// </summary>
        /// <param name="m">ModelContext.</param>
        public void AddModelContext(BaseModelContext m)
        {
            // verify that node hasnt been added yet
            foreach (ModelContextViewModel viewModel in this.rootNodeVMs)
                if (viewModel.ModelContext.Id == m.Id)
                    return;

            ModelContextViewModel vm = new ModelContextViewModel(this.ViewModelStore, m);
            vm.Index = this.rootNodeVMs.Count +1;
            this.rootNodeVMs.Add(vm);
        }

        /// <summary>
        /// Deletes the model context view model that is hosting the given node.
        /// </summary>
        /// <param name="m">ModelContext.</param>
        public void DeleteModelContext(BaseModelContext m)
        {
            for (int i = this.rootNodeVMs.Count - 1; i >= 0; i--)
                if (this.rootNodeVMs[i].ModelContext.Id == m.Id)
                {
                    this.rootNodeVMs[i].Dispose();
                    this.rootNodeVMs.RemoveAt(i);
                }

            UpdateIndices();
        }

        private void UpdateIndices()
        {
            for (int i = 0; i < this.rootNodeVMs.Count; i++)
                if (this.rootNodeVMs[i].Index != i + 1)
                    this.rootNodeVMs[i].Index = i + 1;

        }

        /// <summary>
        /// Called whenever a relationship of type MetaModelHasModelContexts is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnModelContextAdded(ElementAddedEventArgs args)
        {
            MetaModelHasModelContexts con = args.ModelElement as MetaModelHasModelContexts;
            if (con != null)
            {
                AddModelContext(con.BaseModelContext);
            }
        }

        /// <summary>
        /// Called whenever a relationship of type MetaModelHasModelContexts is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args"></param>
        private void OnModelContextRemoved(ElementDeletedEventArgs args)
        {
            MetaModelHasModelContexts con = args.ModelElement as MetaModelHasModelContexts;
            if (con != null)
            {
                DeleteModelContext(con.BaseModelContext);
            }
        }

        /// <summary>
        /// Called whenever selection changes.
        /// </summary>
        /// <param name="args"></param>
        private void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            if (args.SelectedItems == null)
                return;

            if (args.SelectedItems.Count != 1)
            {
                this.SelectedItem = null;
            }
            else
            {
                foreach(ModelContextViewModel vm in this.ModelContextVMs)
                    if (vm.ModelContext == args.SelectedItems[0] as BaseModelContext)
                    {
                        if (this.SelectedItem != vm)
                            this.SelectedItem = vm;

                        break;
                    }
            }
        }
        
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            this.EventManager.GetEvent<SelectionChangedEvent>().Unsubscribe(new Action<SelectionChangedEventArgs>(OnSelectionChanged));

            if (this.ModelData.MetaModel != null)
            {
                // unsubscribe
                this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(MetaModelHasModelContexts.DomainClassId),
                    true, this.ModelData.MetaModel.Id, new Action<ElementAddedEventArgs>(OnModelContextAdded));

                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(MetaModelHasModelContexts.DomainClassId),
                    true, this.ModelData.MetaModel.Id, new Action<ElementDeletedEventArgs>(OnModelContextRemoved));
            }

            base.OnDispose();
        }
    }
}

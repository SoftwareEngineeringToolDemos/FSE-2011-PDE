using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.Contracts.ViewModel;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.ModelTree;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection
{
    /// <summary>
    /// Select element in tree view model.
    /// </summary>
    public class SelectElementTreeViewModel : BaseViewModel, ISelectElementSubViewModel
    {
        private ObservableCollection<BaseModelElementTreeViewModel> modelTreeRootViewModels = null;
        private BaseModelElementTreeViewModel modelTreeSelectedElement = null;

        private DelegateCommand activatedCommand;

        private bool isActive = false;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public SelectElementTreeViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            activatedCommand = new DelegateCommand(ActivatedCommand_Executed);
        }

        /// <summary>
        /// Gets the root elements collection for binding to the tree view. It actually consists of only one element at all times.
        /// </summary>
        public ObservableCollection<BaseModelElementTreeViewModel> ModelTreeRootViewModels
        {
            get
            {
                if (modelTreeRootViewModels == null)
                {
                    modelTreeRootViewModels = new ObservableCollection<BaseModelElementTreeViewModel>();
                    BaseModelElementTreeViewModel rootTreeViewItemViewModelStorage = this.ViewModelStore.TopMostStore.Factory.CreateModelElementTreeViewModel(this.ModelData.CurrentModelContext.RootElement, false, false, null);
                    modelTreeRootViewModels.Add(rootTreeViewItemViewModelStorage);
                }

                return modelTreeRootViewModels;
            }
        }

        /// <summary>
        /// Gets or sets the element, that is selected in the model tree.
        /// </summary>
        public BaseModelElementTreeViewModel ModelTreeSelectedElement
        {
            get
            {
                return modelTreeSelectedElement;
            }
            set
            {
                if (modelTreeSelectedElement != null)
                    modelTreeSelectedElement.IsSelected = false;

                modelTreeSelectedElement = value;
                if( modelTreeSelectedElement != null )
                    if (!modelTreeSelectedElement.IsSelected)
                        modelTreeSelectedElement.IsSelected = true;

                OnPropertyChanged("SelectedElement");
            }
        }

        /// <summary>
        /// Activated command.
        /// </summary>
        public DelegateCommand ActivatedCommand
        {
            get { return activatedCommand; }
        }

        /// <summary>
        /// Gets or sets whether this view is active or not.
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// Search command executed.
        /// </summary>
        private void ActivatedCommand_Executed()
        {
            if (!IsActive)
                IsActive = true;
        }

        /// <summary>
        /// Gets the selected model element.
        /// </summary>
        public object SelectedElement
        {
            get
            {
                if (this.ModelTreeSelectedElement == null)
                    return null;
                else
                    return this.ModelTreeSelectedElement.Element;
            }
        }

        /// <summary>
        /// Tries to set the selection to the given element.
        /// </summary>
        /// <param name="element">Element to select.</param>
        public void SetSelectedElement(object element)
        {
            if (element is ModelElement)
            {
                foreach (BaseModelElementTreeViewModel v in this.ModelTreeRootViewModels)
                    SetSelectedElementInTree(v, element as ModelElement);
            }
        }
        private void SetSelectedElementInTree(BaseModelElementTreeViewModel treeElement, ModelElement modelElement)
        {
            if (treeElement.Element.Id == modelElement.Id)
            {
                //ModelTreeSelectedElement = treeElement;
                treeElement.IsSelected = true;
                treeElement.IsExpanded = true;
                return;
            }

            foreach (BaseModelElementTreeViewModel v in treeElement.Children)
                SetSelectedElementInTree(v, modelElement);
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            base.OnDispose();

            if (ModelTreeRootViewModels != null)
            {
                foreach (BaseModelElementTreeViewModel v in this.ModelTreeRootViewModels)
                    if( v != null )
                        v.Dispose();
                modelTreeRootViewModels = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Menu;
using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Optimization
{
    /// <summary>
    /// View model to display the graphical model tree.
    /// </summary>
    public class OptimizationModelTreeViewModel : ModelTreeViewModel
    {
        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="modelTreeView">Domain model tree view.</param>
        public OptimizationModelTreeViewModel(ViewModelStore viewModelStore, DomainModelTreeView modelTreeView)
            : base(viewModelStore, null, modelTreeView)
        {
        }

        public override void UpdateOperations()
        {
            base.Operations = new Collection<MenuItemViewModel>();
            if (this.SelectedItems.Count == 1)
            {
                TreeNodeViewModel node = this.SelectedItems[0] as TreeNodeViewModel;
                if (node != null)
                {
                    // bring tree here
                    MenuItemViewModel mvBTH = new MenuItemViewModel(this.ViewModelStore, "Bring tree here");
                    mvBTH.Command = BringTreeHereCommand;
                    mvBTH.IsEnabled = ModelTreeOperations.CanBringTreeHere(node.TreeNode);
                    base.Operations.Add(mvBTH);

                    // split tree
                    MenuItemViewModel mvSplit = new MenuItemViewModel(this.ViewModelStore, "Split tree");
                    mvSplit.Command = SplitTreeCommand;
                    mvSplit.IsEnabled = ModelTreeOperations.CanSplitTree(node.TreeNode);
                    base.Operations.Add(mvSplit);
                }
            }
            this.OnPropertyChanged("Operations");
        }
    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Optimization;
using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Optimization
{
    public class OptimizationMainViewModel : BaseWindowViewModel
    {
        private MetamodelProcessor optOperations;
        private List<BaseOptimization> optList;
        private OptimizationViewModel currentOptimizationVM;
        private int currentOptimizationIndex = 0;

        private DelegateCommand prevOptimizationCommand;
        private DelegateCommand nextOptimizationCommand;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="store"></param>
        /// <param name="optOperations"></param>
        /// <param name="opt"></param>
        public OptimizationMainViewModel(ViewModelStore store, MetamodelProcessor optOperations, List<BaseOptimization> opt)
            : base(store)
        {
            this.optOperations = optOperations;
            this.optList = opt;

            this.prevOptimizationCommand = new DelegateCommand(PrevOptimizationCommand_Executed, PrevOptimizationCommand_CanExecute);
            this.nextOptimizationCommand = new DelegateCommand(NextOptimizationCommand_Executed, NextOptimizationCommand_CanExecute);

            this.PrevOptimizationCommand.RaiseCanExecuteChanged();
            this.NextOptimizationCommand.RaiseCanExecuteChanged();
            this.UpdateCurrentOptimization();
        }

        public DelegateCommand PrevOptimizationCommand
        {
            get
            {
                return this.prevOptimizationCommand;
            }
        }
        public DelegateCommand NextOptimizationCommand
        {
            get
            {
                return this.nextOptimizationCommand;
            }
        }

        /// <summary>
        /// Applies the current optimization to the metamodel.
        /// </summary>
        public void ApplyCurrrentOptimization()
        {
            if (this.CurrentOptimization == null)
                return;

            //using(Transaction t = this.Store.TransactionManager.BeginTransaction() )
            //{
                this.CurrentOptimization.ApplyOptimization();

            //  t.Commit();
            //}
        }

        private void UpdateCurrentOptimization()
        {
            if (this.CurrentOptimizationVM != null)
                this.CurrentOptimizationVM.Dispose();

            if (this.currentOptimizationIndex < this.optList.Count)
            {
                this.CurrentOptimization = this.optList[this.currentOptimizationIndex];
                this.CurrentOptimizationVM = new OptimizationViewModel(this.ViewModelStore, this.CurrentOptimization);
            }
        }

        /// <summary>
        /// Gets the current optimization.
        /// </summary>
        public BaseOptimization CurrentOptimization
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current optimization vm.
        /// </summary>
        public OptimizationViewModel CurrentOptimizationVM
        {
            get
            {
                return this.currentOptimizationVM;
            }
            private set
            {
                if (this.currentOptimizationVM != value)
                {
                    this.currentOptimizationVM = value;
                    OnPropertyChanged("CurrentOptimizationVM");
                }
            }
        }

        public string CurrentNumber
        {
            get
            {
                return (currentOptimizationIndex + 1).ToString() + "/" + this.optList.Count;
            }
        }

        private void PrevOptimizationCommand_Executed()
        {
            if (this.currentOptimizationIndex == 0)
                return;
            using (new Tum.PDE.LanguageDSL.Visualization.ViewModel.UI.WaitCursor())
            {
                this.currentOptimizationIndex -= 1;
                this.UpdateCurrentOptimization();

                this.PrevOptimizationCommand.RaiseCanExecuteChanged();
                this.NextOptimizationCommand.RaiseCanExecuteChanged();
            }

            this.OnPropertyChanged("CurrentNumber");
        }
        private bool PrevOptimizationCommand_CanExecute()
        {
            if (this.currentOptimizationIndex == 0)
                return false;

            return true;
        }
        private void NextOptimizationCommand_Executed()
        {
            if (this.currentOptimizationIndex + 1 >= this.optList.Count)
                return;
            using (new Tum.PDE.LanguageDSL.Visualization.ViewModel.UI.WaitCursor())
            {
                this.currentOptimizationIndex += 1;
                this.UpdateCurrentOptimization();

                this.PrevOptimizationCommand.RaiseCanExecuteChanged();
                this.NextOptimizationCommand.RaiseCanExecuteChanged();
            }

            this.OnPropertyChanged("CurrentNumber");
        }
        private bool NextOptimizationCommand_CanExecute()
        {
            if (this.currentOptimizationIndex + 1 >= this.optList.Count)
                return false;

            return true;
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.CurrentOptimizationVM != null)
                this.CurrentOptimizationVM.Dispose();

            foreach (BaseOptimization b in this.optList)
                b.Dispose();
            this.optList.Clear();

            base.OnDispose();
        }
    }
}

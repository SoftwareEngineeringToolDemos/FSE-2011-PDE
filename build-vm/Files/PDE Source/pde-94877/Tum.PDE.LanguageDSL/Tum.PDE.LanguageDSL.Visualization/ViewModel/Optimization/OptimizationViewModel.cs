using Tum.PDE.LanguageDSL.Optimization;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;



namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Optimization
{
    public class OptimizationViewModel : BaseViewModel
    {
        public OptimizationViewModel(ViewModelStore store, BaseOptimization opt)
            : base(store)
        {
            this.Optimization = opt;
            this.SourceModelVM = new OptimizationModelTreeViewModel(this.ViewModelStore, (this.Optimization.SourceModel.ModelContexts[0] as Tum.PDE.LanguageDSL.LibraryModelContext).ViewContext.DomainModelTreeView);
            this.TargetModelVM = new OptimizationModelTreeViewModel(this.ViewModelStore, (this.Optimization.TargetModel.ModelContexts[0] as Tum.PDE.LanguageDSL.LibraryModelContext).ViewContext.DomainModelTreeView);
        }

        /// <summary>
        /// Gets the optimization.
        /// </summary>
        public BaseOptimization Optimization
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the source model view model.
        /// </summary>
        public OptimizationModelTreeViewModel SourceModelVM
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the target model view model.
        /// </summary>
        public OptimizationModelTreeViewModel TargetModelVM
        {
            get;
            private set;
        }

        protected override void OnDispose()
        {
            if (this.SourceModelVM != null)
                this.SourceModelVM.Dispose();

            if (this.TargetModelVM != null)
                this.TargetModelVM.Dispose();

            //if (this.Optimization != null)
            //    this.Optimization.Dispose();

            
            base.OnDispose();
        }
    }
}

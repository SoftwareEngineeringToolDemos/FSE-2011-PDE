using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel
{
    /// <summary>
    /// This is the base vm for a specific model element vm.
    /// </summary>
    public class BaseSpecificModelElementViewModel : BaseModelElementViewModel
    {
        BaseModelElementViewModel parentVM;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        public BaseSpecificModelElementViewModel(ViewModelStore viewModelStore, ModelElement element, BaseModelElementViewModel parentVM)
            : this(viewModelStore, element, parentVM, true)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="element">Element to be hosted by this view model.</param>
		/// <param name="parentVM">Parent view model. Can be null.</param>
        /// <param name="bCallInitialize"></param>
        public BaseSpecificModelElementViewModel(ViewModelStore viewModelStore, ModelElement element, BaseModelElementViewModel parentVM, bool bCallInitialize)
            : base(viewModelStore, element, true, false)
        {
            this.parentVM = parentVM;

            if( bCallInitialize )
                this.Initialize();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            if( this.parentVM != null )
                this.ViewModelStore.SpecificViewModelStore.AddVM(this, this.parentVM.Id);
        }

        /// <summary>
        /// Initialize Relationship children.
        /// </summary>
        protected virtual void InitializeRelationships()
        {
        }

        /// <summary>
        /// Sets up subscription.
        /// </summary>
        protected virtual void InitializeSubscription()
        {
        }

        /// <summary>
        /// Gets an instance of this vm.
        /// </summary>
        public virtual BaseSpecificModelElementViewModel GetInstance()
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns></returns>
        public virtual bool ShouldCreateVMForNullElements(string type)
        {
            return false;
        }

        /// <summary>
        /// Gets the parent VM. Can be null.
        /// </summary>
        public BaseModelElementViewModel ParentViewModel
        {
            get
            {
                return this.parentVM;
            }
        }

        /// <summary>
        /// Called on a role player beeing moved.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <param name="collection">Collection to reorder.</param>
        protected virtual void HandleRolePlayerMoved<T>(RolePlayerOrderChangedEventArgs args, System.Collections.ObjectModel.ObservableCollection<T> collection) where T : BaseModelElementViewModel
        {
            /*
            if (args.SourceElement == this.Element)
            {
                for (int y = 0; y < collection.Count; y++)
                {
                    if (collection[y].Element == args.CounterpartRolePlayer)
                    {
                        if (args.NewOrdinal == y)
                            return;

                        // reorder elements
                        System.Collections.ObjectModel.ReadOnlyCollection<ElementLink> lllinks = DomainRoleInfo.GetElementLinks<ElementLink>(this.Element, DomainModelElement.GetSourceDomainRole(args.DomainRelationship).Id);
                        for (int ii = 0; ii < lllinks.Count; ii++)
                            for (int iy = 0; iy < collection.Count; iy++)
                            {
                                if (collection[iy].Element == DomainRoleInfo.GetTargetRolePlayer(lllinks[ii]))
                                {
                                    // need to move?
                                    if (iy != ii)
                                        collection.Move(iy, ii);

                                    break;
                                }
                            }
                    }
                }

            }*/
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if (this.parentVM != null)
                this.ViewModelStore.SpecificViewModelStore.RemoveVM(this, this.parentVM.Id);

            base.OnDispose();
        }
    }
}

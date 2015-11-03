using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.ModelTree;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Diagram;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Serialization;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.Commands;
using Tum.PDE.LanguageDSL.CopyPaste;
using System.Collections.ObjectModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.UI;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Services;
using Tum.PDE.LanguageDSL.Optimization;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Optimization;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel
{
    public enum ModelContextViewType
    {
        Empty,
        LibraryContext,
        ModelContext,
        ExternModelContext
    }

    public class ModelContextViewModel : BaseViewModel
    {
        private ModelTreeViewModel modelTreeViewModel = null;
        private DiagramViewModel diagramViewModel = null;
        private SerializationViewModel serializationViewModel = null;

        private ModelContextViewType modelContextType = ModelContextViewType.Empty;
        private BaseModelContext modelContext;
        private int index = 0;
        private bool isSelected = false;
        private bool isLocked = false;

        ModelContextViewModel externMCReference = null;
        BaseDockingViewModel selectedItem = null;
        int selectedIndex = 0;

        private DelegateCommand copyCommand;
        private DelegateCommand pasteCommand;

        private DelegateCommand copyAllTreeCommand;
        private DelegateCommand copyEmbeddingTreeCommand;
        private DelegateCommand copyReferenceTreeCommand;
        //private DelegateCommand cutCommand;
        private DelegateCommand optimizeCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public ModelContextViewModel(ViewModelStore viewModelStore, BaseModelContext baseModelContext)
            : this(viewModelStore, baseModelContext, false)
        {
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public ModelContextViewModel(ViewModelStore viewModelStore, BaseModelContext baseModelContext, bool isLocked)
            : base(viewModelStore)
        {
            this.modelContext = baseModelContext;
            
            this.copyCommand = new DelegateCommand(CopyCommand_Executed, CopyCommand_CanExecute);
            this.pasteCommand = new DelegateCommand(PasteCommand_Executed, PasteCommand_CanExecute);
            this.copyAllTreeCommand = new DelegateCommand(CopyAllTreeCommand_Executed, CopyAllTreeCommand_CanExecute);
            this.copyEmbeddingTreeCommand = new DelegateCommand(CopyEmbeddingTreeCommand_Executed, CopyAllTreeCommand_CanExecute);
            this.copyReferenceTreeCommand = new DelegateCommand(CopyReferenceTreeCommand_Executed, CopyAllTreeCommand_CanExecute);
            //this.cutCommand = new DelegateCommand(CutCommand_Executed, CutCommand_CanExecute);
            this.optimizeCommand = new DelegateCommand(OptimizeCommand_Executed);

            if (baseModelContext is ModelContext)
            {
                ModelContext modelContext = baseModelContext as ModelContext;

                this.modelTreeViewModel = new ModelTreeViewModel(viewModelStore, this, modelContext.ViewContext.DomainModelTreeView);
                this.modelTreeViewModel.IsLocked = isLocked;
                this.diagramViewModel = new DiagramViewModel(viewModelStore, this, modelContext.ViewContext.DiagramView);
                this.serializationViewModel = new SerializationViewModel(viewModelStore, modelContext.SerializationModel);

                this.modelContextType = ModelContextViewType.ModelContext;
            }
            else if( baseModelContext is ExternModelContext)
            {
                ExternModelContext modelContext = baseModelContext as ExternModelContext;
                if (modelContext.ModelContext != null)
                {
                    this.AddModelContext(modelContext.ModelContext);
                }

            	this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ExternModelContextReferencesModelContext.DomainClassId),
                	true, this.modelContext.Id, new System.Action<ElementAddedEventArgs>(OnModelContextAdded));
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ExternModelContextReferencesModelContext.DomainClassId),
                	true, this.modelContext.Id, new System.Action<ElementDeletedEventArgs>(OnModelContextRemoved));
                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(ExternModelContextReferencesModelContext.ExternModelContextDomainRoleId),
                	new System.Action<RolePlayerChangedEventArgs>(OnModelContextChanged));
                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Subscribe(this.Store.DomainDataDirectory.GetDomainRole(ExternModelContextReferencesModelContext.ModelContextDomainRoleId),
                	new System.Action<RolePlayerChangedEventArgs>(OnModelContextChanged));                

                this.modelContextType = ModelContextViewType.ExternModelContext;
                
            }
            else if (baseModelContext is LibraryModelContext)
            {
                LibraryModelContext modelContext = baseModelContext as LibraryModelContext;
                this.modelTreeViewModel = new ModelTreeViewModel(viewModelStore, this, modelContext.ViewContext.DomainModelTreeView);
                this.modelTreeViewModel.IsLocked = isLocked;
                this.diagramViewModel = new DiagramViewModel(viewModelStore, this, modelContext.ViewContext.DiagramView);
                this.modelContextType = ModelContextViewType.LibraryContext;
                this.serializationViewModel = new SerializationViewModel(viewModelStore, modelContext.SerializationModel);
            }

            this.selectedItem = this.ModelTreeViewModel;

            if( this.ModelContext != null )
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Subscribe(
                    this.Store.DomainDataDirectory.GetDomainProperty(BaseModelContext.NameDomainPropertyId), this.ModelContext.Id, new System.Action<ElementPropertyChangedEventArgs>(NamePropertyChanged));
        }

        public bool IsLocked
        {
            get
            {
                return this.isLocked;
            }
            set 
            {
                this.isLocked = value;
                OnPropertyChanged("IsLocked");
            }
        }

        /// <summary>
        /// Gets the model tree view model.
        /// </summary>
        public ModelTreeViewModel ModelTreeViewModel
        {
            get
            {
                return this.modelTreeViewModel;
            }
        }

        /// <summary>
        /// Gets the diagram view model.
        /// </summary>
        public DiagramViewModel DiagramViewModel
        {
            get
            {
                return this.diagramViewModel;
            }
        }

        /// <summary>
        /// Gets the serialization view model.
        /// </summary>
        public SerializationViewModel SerializationViewModel
        {
            get
            {
                return this.serializationViewModel;
            }
        }

        /// <summary>
        /// Gets the model context.
        /// </summary>
        public BaseModelContext ModelContext
        {
            get
            {
                return this.modelContext;
            }
        }

        /// <summary>
        /// Gets the model context type.
        /// </summary>
        public ModelContextViewType ModelContextViewType
        {
            get
            {
                return this.modelContextType;
            }
        }

        /// <summary>
        /// Gets the domain element name.
        /// </summary>
        public string DomainElementName
        {
            get
            {
                if (this.ModelContext != null)
                    return this.ModelContext.Name;

                return "";
            }
        }

        /// <summary>
        /// Called whenever the property Name changes its value.
        /// </summary>
        private void NamePropertyChanged(ElementPropertyChangedEventArgs args)
        {
            OnPropertyChanged("DomainElementName");
        }

        /// <summary>
        /// Gets or sets the index of this view model.
        /// </summary>
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
                OnPropertyChanged("Index");
            }
        }

        /// <summary>
        /// Gets or sets whether this item is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;

                OnPropertyChanged("IsSelected");
            }
        }

        public ModelContextViewModel ExternModelContextReference
        {
            get
            {
                return this.externMCReference;
            }
        }

        /// <summary>
        /// Copy command.
        /// </summary>
        public DelegateCommand CopyCommand
        {
            get { return this.copyCommand; }
        }

        /// <summary>
        /// Copy command.
        /// </summary>
        public DelegateCommand CopyAllTreeCommand
        {
            get { return this.copyAllTreeCommand; }
        }

        /// <summary>
        /// Copy command.
        /// </summary>
        public DelegateCommand CopyEmbeddingTreeCommand
        {
            get { return this.copyEmbeddingTreeCommand; }
        }

        /// <summary>
        /// Copy command.
        /// </summary>
        public DelegateCommand CopyReferenceTreeCommand
        {
            get { return this.copyReferenceTreeCommand; }
        }

        /// <summary>
        /// Paste command.
        /// </summary>
        public DelegateCommand PasteCommand
        {
            get { return this.pasteCommand; }
        }

        public DelegateCommand OptimizeCommand
        {
            get
            {
                return this.optimizeCommand;
            }
        }

        /*
        /// <summary>
        /// Paste command.
        /// </summary>
        public DelegateCommand CutCommand
        {
            get { return this.cutCommand; }
        }*/

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        private bool CopyCommand_CanExecute()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            else if (this.SelectedItem is DiagramViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.DiagramViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }

            if(modelElements.Count > 0 )
            {
                if( CopyAndPasteOperations.CanExecuteCopy(modelElements) )
                {
                    modelElements.Clear();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copy command can execute.
        /// </summary>
        private bool CopyAllTreeCommand_CanExecute()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    if (!(vm.GetHostedElement() is DomainClass))
                        continue;
                    
                    modelElements.Add(vm.GetHostedElement());
                }
            }

            if (modelElements.Count == 1)
            {
                if (CopyAndPasteOperations.CanExecuteCopy(modelElements))
                {
                    modelElements.Clear();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copy command executed.
        /// </summary>
        private void CopyAllTreeCommand_Executed()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    if (!(vm.GetHostedElement() is DomainClass))
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            if (modelElements.Count != 1)
            {
                return;
            }

            using (new WaitCursor())
            {
                try
                {
                    CopyAndPasteOperations.Operation = CopyAndPasteOperation.CopyAllTree;
                    CopyAndPasteOperations.ExecuteCopy(modelElements);
                    CopyAndPasteOperations.Operation = CopyAndPasteOperation.Default;
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Copy command executed.
        /// </summary>
        private void CopyEmbeddingTreeCommand_Executed()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    if (!(vm.GetHostedElement() is DomainClass))
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            if (modelElements.Count != 1)
            {
                return;
            }

            using (new WaitCursor())
            {
                try
                {
                    CopyAndPasteOperations.Operation = CopyAndPasteOperation.CopyEmbeddingTree;
                    CopyAndPasteOperations.ExecuteCopy(modelElements);
                    CopyAndPasteOperations.Operation = CopyAndPasteOperation.Default;
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Copy command executed.
        /// </summary>
        private void CopyReferenceTreeCommand_Executed()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    if (!(vm.GetHostedElement() is DomainClass))
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            if (modelElements.Count != 1)
            {
                return;
            }

            using (new WaitCursor())
            {
                try
                {
                    CopyAndPasteOperations.Operation = CopyAndPasteOperation.CopyReferenceTree;
                    CopyAndPasteOperations.ExecuteCopy(modelElements);
                    CopyAndPasteOperations.Operation = CopyAndPasteOperation.Default;
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Copy command executed.
        /// </summary>
        private void CopyCommand_Executed()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            else if (this.SelectedItem is DiagramViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.DiagramViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }

            using (new WaitCursor())
            {
                try
                {
                    CopyAndPasteOperations.ExecuteCopy(modelElements);
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// PasteCommand can execute.
        /// </summary>
        private bool PasteCommand_CanExecute()
        {
            List<ModelElement> modelElements = new List<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            else if (this.SelectedItem is DiagramViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.DiagramViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }

            if (modelElements.Count == 0)
                modelElements.Add(this.ModelContext);

            if (modelElements.Count == 1)
            {
                try
                {
                    System.Windows.IDataObject idataObject = System.Windows.Clipboard.GetDataObject();
                    if (idataObject != null)
                    {
                        CopyAndPasteOperations.ProcessMoveMode(idataObject);
                        return CopyAndPasteOperations.CanExecutePaste(modelElements[0], idataObject);
                    }
                }
                catch { }

                return false;
            }

            return false;
        }

        /// <summary>
        /// PasteCommand executed.
        /// </summary>
        private void PasteCommand_Executed()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            else if (this.SelectedItem is DiagramViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.DiagramViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }

            if (modelElements.Count == 0)
                modelElements.Add(this.ModelContext);

            using (new WaitCursor())
            {
                try
                {
                    ValidationResult result = CopyAndPasteOperations.ExecutePaste(modelElements[0]);
                    if (result != null)
                    {
                        string errors = string.Empty;
                        foreach (IValidationMessage msg in result)
                        {
                            errors += msg.Type + " " + msg.MessageId + ": " + msg.Description;
                        }

                        if (!String.IsNullOrEmpty(errors))
                        {
                            this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Pasting failed: " + errors);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Pasting failed: " + ex.Message);
                }
            }
        }

        private void OptimizeCommand_Executed()
        {
            this.OptimizeMetamodel(true);

        }

        private void OptimizeMetamodel(bool bShowMessageOnNoOpt)
        {
            MetamodelProcessor optOperations = new MetamodelProcessor(this.ModelContext.MetaModel, this.ModelContext as LibraryModelContext);
            List<BaseOptimization> opt = optOperations.GetOptimizations();
            if (opt.Count == 0)
            {
                if (bShowMessageOnNoOpt)
                {
                    IMessageBoxService msgBox = this.GlobalServiceProvider.Resolve<IMessageBoxService>();
                    msgBox.ShowInformation("No applicable optimizations found.");
                }
                return;
            }

            bool bRestartOpt = false;

            OptimizationMainViewModel vm = new OptimizationMainViewModel(this.ViewModelStore, optOperations, opt);

            IUIVisualizerService ui = this.ResolveService<IUIVisualizerService>();
            bool? result = ui.ShowDialog("OptimizationControl", vm);
            if (result == false)
            {
                vm.Dispose();
                return;
            }
            else
            {
                // apply optimization
                vm.ApplyCurrrentOptimization();

                bRestartOpt = true;
                vm.Dispose();
            }
            if (opt.Count > 0)
                for (int i = opt.Count - 1; i >= 0; i--)
                    opt[i].Dispose();

            if (bRestartOpt)
                this.OptimizeMetamodel(false);
        }

        /*
        /// <summary>
        /// CutCommand can execute.
        /// </summary>
        private bool CutCommand_CanExecute()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            else if (this.SelectedItem is DiagramViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.DiagramViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }

            if (modelElements.Count > 0)
            {
                if (CopyAndPasteOperations.CanExecuteMove(modelElements))
                {
                    modelElements.Clear();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// CutCommand executed.
        /// </summary>
        private void CutCommand_Executed()
        {
            Collection<ModelElement> modelElements = new Collection<ModelElement>();
            if (this.SelectedItem is ModelTreeViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.ModelTreeViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }
            else if (this.SelectedItem is DiagramViewModel)
            {
                foreach (BaseModelElementViewModel vm in this.DiagramViewModel.SelectedItems)
                {
                    if (vm.GetHostedElement() == null)
                        continue;

                    modelElements.Add(vm.GetHostedElement());
                }
            }

            using (new WaitCursor())
            {
                try
                {
                    CopyAndPasteOperations.ExecuteCut(modelElements);
                }
                catch (System.Exception ex)
                {
                    this.GlobalServiceProvider.Resolve<IMessageBoxService>().ShowError("Copying to clipboard failed: " + ex.Message);
                }
            }
        }
        */

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                if (this.selectedIndex != value)
                {
                    this.selectedIndex = value;
                    switch(selectedIndex)
                    {
                        case 0:
                            this.selectedItem = this.ModelTreeViewModel;
                            break;
                        
                            case 1 :
                            this.selectedItem = this.DiagramViewModel;
                            break;

                            case 2 :
                            this.selectedItem = this.SerializationViewModel;
                            break;
                    }
                    OnPropertyChanged("SelectedIndex");
                }
            }
        }

        public BaseDockingViewModel SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
        }

        /// <summary>
        /// Adds a new ModelContext view model for the given ModelContext.
        /// </summary>
        /// <param name="element">ModelContext.</param>
        public void AddModelContext(LibraryModelContext element)
        {
            if( this.externMCReference != null )
				if( this.externMCReference.ModelContext == element )
					return;
					
			this.externMCReference = new ModelContextViewModel(this.ViewModelStore, element, true);
			OnPropertyChanged("ExternModelContextReference");	
        }

        /// <summary>
        /// Deletes a new ModelContext view model for the given ModelContext.
        /// </summary>
        /// <param name="element">ModelContext.</param>
        public void DeleteModelContext(LibraryModelContext element)
        {
			if( this.externMCReference != null )
				if( this.externMCReference.ModelContext == element )
				{
					this.externMCReference.Dispose();
                    this.externMCReference = null;
				}

            OnPropertyChanged("ExternModelContextReference");	
        }

        /// <summary>
        /// Called whenever a relationship of type ExternModelContextReferencesModelContext is added and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnModelContextAdded(ElementAddedEventArgs args)
		{
			ExternModelContextReferencesModelContext con = args.ModelElement as ExternModelContextReferencesModelContext;
            if (con != null)
            {
                AddModelContext(con.ModelContext);
            }
		}

		/// <summary>
        /// Called whenever a relationship of type ExternModelContextReferencesModelContext is deleted and
        /// the element hosted by this model is the source.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnModelContextRemoved(ElementDeletedEventArgs args)
		{
			ExternModelContextReferencesModelContext con = args.ModelElement as ExternModelContextReferencesModelContext;
            if (con != null)
            {
                DeleteModelContext(con.ModelContext);
            }
		}

		/// <summary>
        /// Called on a role player changing.
        /// </summary>
        /// <param name="args">Arguments.</param>
		protected virtual void OnModelContextChanged(RolePlayerChangedEventArgs args)
		{
			ExternModelContextReferencesModelContext con = args.ElementLink as ExternModelContextReferencesModelContext;
            if (con != null)
            {
                if (args.DomainRole.Id == ExternModelContextReferencesModelContext.ExternModelContextDomainRoleId)
                {
                    if (args.OldRolePlayerId == this.ModelContext.Id)
                        DeleteModelContext(con.ModelContext);

                    if (args.NewRolePlayerId == this.ModelContext.Id)
                        AddModelContext(con.ModelContext);
                }
				else if (args.DomainRole.Id == ExternModelContextReferencesModelContext.ModelContextDomainRoleId)
				{
					if( args.OldRolePlayer != null )
                        DeleteModelContext(args.OldRolePlayer as LibraryModelContext);

                    if( args.NewRolePlayer != null )
                        AddModelContext(args.NewRolePlayer as LibraryModelContext);
				}
            }
		}
        
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnDispose()
        {
            if( this.ModelContext is ExternModelContext)
            {
                ExternModelContext modelContext = this.ModelContext as ExternModelContext;
                
            	this.EventManager.GetEvent<ModelElementLinkAddedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ExternModelContextReferencesModelContext.DomainClassId),
                	true, this.modelContext.Id, new System.Action<ElementAddedEventArgs>(OnModelContextAdded));
                this.EventManager.GetEvent<ModelElementLinkDeletedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRelationship(ExternModelContextReferencesModelContext.DomainClassId),
                	true, this.modelContext.Id, new System.Action<ElementDeletedEventArgs>(OnModelContextRemoved));
                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(ExternModelContextReferencesModelContext.ExternModelContextDomainRoleId),
                	new System.Action<RolePlayerChangedEventArgs>(OnModelContextChanged));
                this.EventManager.GetEvent<ModelRolePlayerChangedEvent>().Unsubscribe(this.Store.DomainDataDirectory.GetDomainRole(ExternModelContextReferencesModelContext.ModelContextDomainRoleId),
                	new System.Action<RolePlayerChangedEventArgs>(OnModelContextChanged));  
                        }

            if (this.ModelContext != null)
                this.EventManager.GetEvent<ModelElementPropertyChangedEvent>().Unsubscribe(
                    this.Store.DomainDataDirectory.GetDomainProperty(BaseModelContext.NameDomainPropertyId), this.ModelContext.Id, new System.Action<ElementPropertyChangedEventArgs>(NamePropertyChanged));

            base.OnDispose();
        }
    }
}

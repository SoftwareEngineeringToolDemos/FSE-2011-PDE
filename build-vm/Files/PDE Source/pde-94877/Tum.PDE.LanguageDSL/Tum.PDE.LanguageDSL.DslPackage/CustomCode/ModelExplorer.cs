using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Modeling.Shell;
using Tum.PDE.LanguageDSL.Visualization.View.Forms;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Dependencies;
using System.Collections.ObjectModel;

namespace Tum.PDE.LanguageDSL
{
    internal partial class LanguageDSLExplorer
    {
        //public static System.ComponentModel.Design.CommandID ModelExplorerCut;
        public static System.ComponentModel.Design.CommandID ModelExplorerCopy;
        public static System.ComponentModel.Design.CommandID ModelExplorerPaste;

        public Guid GuidSymbol = new Guid("ABCD048E-739A-474A-94CC-CDA7347C52E7");
        //public int CutIDSymbol = 0x805;
        public int CopyIDSymbol = 0x806;        
        public int PasteIDSymbol = 0x807;

        public override void AddCommandHandlers(IMenuCommandService menuCommandService)
        {
            //ModelExplorerCut = new CommandID(GuidSymbol, CutIDSymbol);
            ModelExplorerCopy = new CommandID(GuidSymbol, CopyIDSymbol);
            ModelExplorerPaste = new CommandID(GuidSymbol, PasteIDSymbol);

            //menuCommandService.AddCommand(
            //    new DynamicStatusMenuCommand(new EventHandler(OnStatusCut), new EventHandler(OnMenuCut), ModelExplorerCut));
            menuCommandService.AddCommand(
                new DynamicStatusMenuCommand(new EventHandler(OnStatusCopy), new EventHandler(OnMenuCopy), ModelExplorerCopy));
            menuCommandService.AddCommand(
                new DynamicStatusMenuCommand(new EventHandler(OnStatusPaste), new EventHandler(OnMenuPaste), ModelExplorerPaste));

            base.AddCommandHandlers(menuCommandService);
        }

        /*
        private void OnMenuCut(object sender, System.EventArgs e)
        {
            if (this.SelectedElement == null)
            {
                return;
            }

            Collection<ModelElement> elements = new Collection<ModelElement>();
            elements.Add(this.SelectedElement);
            CopyPaste.CopyAndPasteOperations.ExecuteCut(elements);
        }*/
        private void OnMenuCopy(object sender, System.EventArgs e)
        {
            if (this.SelectedElement == null)
            {
                return;
            }

            Collection<ModelElement> elements = new Collection<ModelElement>();
            elements.Add(this.SelectedElement);
            CopyPaste.CopyAndPasteOperations.ExecuteCopy(elements);
        }
        private void OnMenuPaste(object sender, System.EventArgs e)
        {
            if (this.SelectedElement == null && this.SelectedRole == null)
            {
                return;
            }

            try
            {
                if (this.SelectedElement != null)
                    CopyPaste.CopyAndPasteOperations.ExecutePaste(this.SelectedElement);
                else if (this.SelectedRole != null)
                {
                    CopyPaste.CopyAndPasteOperations.ExecutePaste(this.CurrentParentElement);
                }
            }
            catch
            {
            }
        }

        /*
        private void OnStatusCut(object sender, System.EventArgs e)
        {
            System.ComponentModel.Design.MenuCommand menuCommand = (System.ComponentModel.Design.MenuCommand)sender;
            if (this.SelectedElement == null)
            {
                menuCommand.Enabled = false;
                return;
            }
            
            Collection<ModelElement> elements = new Collection<ModelElement>();
            elements.Add(this.SelectedElement);

            menuCommand.Enabled = CopyPaste.CopyAndPasteOperations.CanExecuteMove(elements);
            menuCommand.Visible = true;
            
        }
        */
        private void OnStatusCopy(object sender, System.EventArgs e)
        {
            System.ComponentModel.Design.MenuCommand menuCommand = (System.ComponentModel.Design.MenuCommand)sender;
            if (this.SelectedElement == null)
            {
                menuCommand.Enabled = false;
                return;
            }

            if (this.SelectedElement is DomainType || this.SelectedElement is PropertyGridEditor ||
                this.SelectedElement is CreditItem || this.SelectedElement is InformationItem || 
                this.SelectedElement is EnumerationLiteral)
            {

                Collection<ModelElement> elements = new Collection<ModelElement>();
                elements.Add(this.SelectedElement);

                menuCommand.Enabled = CopyPaste.CopyAndPasteOperations.CanExecuteCopy(elements);

            }
            else
            {
                menuCommand.Enabled = false;
            }
            menuCommand.Visible = true;
        }
        private void OnStatusPaste(object sender, System.EventArgs e)
        {
            System.ComponentModel.Design.MenuCommand menuCommand = (System.ComponentModel.Design.MenuCommand)sender;
            if (this.SelectedElement == null && this.SelectedRole == null)
            {
                menuCommand.Enabled = false;
                return;
            }

            try
            {
                System.Windows.IDataObject idataObject = System.Windows.Clipboard.GetDataObject();
                if (idataObject != null)
                {
                    CopyPaste.CopyAndPasteOperations.ProcessMoveMode(idataObject);

                    if( this.SelectedElement != null )
                        menuCommand.Enabled = CopyPaste.CopyAndPasteOperations.CanExecutePaste(this.SelectedElement, idataObject);
                    else if (this.SelectedRole != null)
                    {
                        menuCommand.Enabled = CopyPaste.CopyAndPasteOperations.CanExecutePaste(this.CurrentParentElement, idataObject);
                    }
                    else
                        menuCommand.Enabled = false;
                }
            }
            catch 
            {
                menuCommand.Enabled = false;
            }
            menuCommand.Visible = true;
        }

        /// <summary>
        /// Executed when the model explorer creates the tree element visitor.
        /// </summary>
        /// <returns>The tree element visitor.</returns>
        protected override IElementVisitor CreateElementVisitor()
        {
            this.ObjectModelBrowser.AllowDrop = true;
            this.ObjectModelBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(ObjectModelBrowser_AfterSelect);

            return base.CreateElementVisitor();
        }
        void ObjectModelBrowser_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            SelectedItemsCollection col = new SelectedItemsCollection();
            col.Add(this.SelectedElement);

            if (LanguageDSLDocData.ViewModelStore != null)
                LanguageDSLDocData.ViewModelStore.EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(null, col));
        }
        /*
        public override void AddCommandHandlers(System.ComponentModel.Design.IMenuCommandService menuCommandService)
        {
            // NB this removes the Add command for all nodes / domain classes. Haven't
            // worked out how to be more selective than this yet!

            // Let the base class set up the command handlers
            base.AddCommandHandlers(menuCommandService);

            
            findDependencies = new MenuCommand(new EventHandler(ONFindDToImportedModels),
                new CommandID(GuidSymbol, IDSymbol));
            findDependencies.Enabled = false;
            findDependencies.Visible = false;

            menuCommandService.AddCommand(findDependencies);
/
        }
        
        
        private void ONFindDToImportedModels(object sender, EventArgs args)
        {
            if (this.SelectedElement is MetaModelLibrary)
            {
                List<ModelElement> classes = new List<ModelElement>();
                foreach (ModelContext m in (this.SelectedElement as MetaModelLibrary).MetaModel.ModelContexts)
                {
                    foreach (DomainClass d in m.Classes)
                    {
                        classes.Add(d);
                        classes.AddRange(d.Properties);
                        classes.AddRange(d.RolesPlayed);
                    }
                }

                DependenciesViewModel vm = new DependenciesViewModel(LanguageDSLDocData.ViewModelStore, false);
                List<ModelElement> metaModels = new List<ModelElement>();
                metaModels.Add((this.SelectedElement as MetaModelLibrary).MetaModel);
                vm.Set(classes, metaModels, LanguageDSLDependenciesItemsProvider.GetAllCategories());

                bool bDelete = true;
                if (vm.ActiveDependencies.Count > 0)
                {

                    DeleteElementsPopup popup = new DeleteElementsPopup();
                    popup.DataContext = vm;
                    if (popup.ShowDialog().Value != true)
                        bDelete = false;
                }

                if (bDelete)
                    (this.SelectedElement as MetaModelLibrary).UnloadLibrary();

                vm.Dispose();
                GC.Collect();
            }
        }
        */

        /// <summary>
        ///  Query whether the specified role should be considered a candidate for addition
        ///  through the explorer add menus.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        protected override bool IsAddableRoleForElement(ModelElement element, DomainRoleInfo role)
        {
            if (element is MetaModel)
            {
                /*
                if (role.Id == MetaModelHasClasses.MetaModelDomainRoleId ||
                    role.Id == MetaModelHasRelationships.MetaModelDomainRoleId ||
                    role.Id == MetaModelHasDiagramClasses.MetaModelDomainRoleId)
                    return false;
                */
            }

            if (element is DiagramClass)
                if (role.Id == DiagramClassHasPresentationElements.DiagramClassDomainRoleId)
                    return false;

            if (element is MetaModelLibrary)
                if (role.Id == MetaModelLibraryHasImportedLibrary.MetaModelLibraryDomainRoleId)
                    return false;

            return base.IsAddableRoleForElement(element, role);
        }

        /// <summary>
        /// Override to stop the "Delete" command appearing for certain elements.
        /// </summary>
        protected override void ProcessOnStatusDeleteCommand(System.ComponentModel.Design.MenuCommand command)
        {
            bool bAllowDeletion = true;

            if (this.SelectedElement is DomainClass)
                if ((this.SelectedElement as DomainClass).IsDomainModel)
                    bAllowDeletion = false;

            if (this.SelectedElement is Validation)
                bAllowDeletion = false;

            if (this.SelectedElement is DiagramClass)
               bAllowDeletion = false;

            if (this.SelectedElement is View || this.SelectedElement is ModelTree)
                bAllowDeletion = false;

            if (this.SelectedElement is MetaModelLibrary)
            {
                command.Enabled = true;
                command.Visible = true;

                //findDependencies.Enabled = true;
                //findDependencies.Visible = true;
                return;
            }

            if (bAllowDeletion)
                base.ProcessOnStatusDeleteCommand(command);
            else
            {
                // disable the menu command
                command.Enabled = false;
            }
        }
        protected override void ProcessOnStatusDeleteAllCommand(System.ComponentModel.Design.MenuCommand cmd)
        {
            bool bAllowDeletion = true;

            if (this.SelectedElement == null && this.SelectedRole != null)
            {
                
                if (this.SelectedRole.Id == LibraryModelContextHasClasses.DomainClassDomainRoleId)
                    bAllowDeletion = false;
                else if (this.SelectedRole.Id == LibraryModelContextHasDiagramClasses.DiagramClassDomainRoleId)
                    bAllowDeletion = false;
            }

            if (bAllowDeletion)
                base.ProcessOnStatusDeleteAllCommand(cmd);
            else
            {
                // disable the menu command
                cmd.Enabled = false;
            }
        }
        protected override void ProcessOnMenuDeleteCommand()
        {
            if (this.SelectedElement is MetaModelLibrary)
            {
                if ((this.SelectedElement as MetaModelLibrary).ImportedLibrary == null)
                {
                    using (Transaction transaction = this.ModelingDocData.Store.TransactionManager.BeginTransaction("Unload model library."))
                    {
                        (this.SelectedElement as MetaModelLibrary).Delete();
                        transaction.Commit();
                    }
                    return;
                }

                List<ModelElement> classes = new List<ModelElement>();
                foreach (BaseModelContext mc in (this.SelectedElement as MetaModelLibrary).MetaModel.ModelContexts)
                {
                    if (mc is LibraryModelContext)
                    {
                        LibraryModelContext m = mc as LibraryModelContext;
                        foreach (DomainClass d in m.Classes)
                        {
                            classes.Add(d);
                            classes.AddRange(d.Properties);
                        }
                        foreach (DomainRelationship r in m.Relationships)
                            classes.AddRange(r.Roles);
                    }
                    if (mc is ExternModelContext)
                        classes.Add(mc);
                }
                               

                DependenciesViewModel vm = new DependenciesViewModel(LanguageDSLDocData.ViewModelStore, false);
                List<ModelElement> metaModels = new List<ModelElement>();
                metaModels.Add((this.SelectedElement as MetaModelLibrary).MetaModel);

                System.Collections.ObjectModel.ReadOnlyCollection<ModelElement> libraries = this.SelectedElement.Store.ElementDirectory.FindElements(MetaModelLibrary.DomainClassId);
                foreach (ModelElement m in libraries)
                {
                    if (m != this.SelectedElement)
                        if ((m as MetaModelLibrary).ImportedLibrary != null)
                            metaModels.Add((m as MetaModelLibrary).ImportedLibrary);
                }

                vm.Set(classes, metaModels, LanguageDSLDependenciesItemsProvider.GetAllCategories());

                bool bDelete = true;
                if (vm.ActiveDependencies.Count > 0)
                {

                    DeleteElementsPopup popup = new DeleteElementsPopup();
                    popup.DataContext = vm;
                    if (popup.ShowDialog().Value != true)
                        bDelete = false;
                }

                if (bDelete)
                    using (Transaction transaction = this.ModelingDocData.Store.TransactionManager.BeginTransaction("Unload model library."))
                    {
                        (this.SelectedElement as MetaModelLibrary).FilePath = null;
                        (this.SelectedElement as MetaModelLibrary).Delete();
                        transaction.Commit();
                    }

                vm.Dispose();
                GC.Collect();
                return;
            }

            base.ProcessOnMenuDeleteCommand();
        }
    }
}

using System;
using System.Collections.Generic;

using HtmlAgilityPack;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Deletion;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.VMXExtensions.Path
{
    /// <summary>
    /// Path editor view model base abstract class (To add, edit or delete referenced domain models).
    /// </summary>
    public abstract class ReferencedModelRoleViewModel : StringEditorViewModel
    {
        private DelegateCommand createNewReferencedModelCommand;
        private DelegateCommand editPathCommand;
        private DelegateCommand deleteReferencedModelCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        public ReferencedModelRoleViewModel(ViewModelStore viewModelStore)
            : base(viewModelStore)
        {
            editPathCommand = new DelegateCommand(EditPathCommand_Executed);
            createNewReferencedModelCommand = new DelegateCommand(CreateNewReferencedModelCommand_Executed);
            deleteReferencedModelCommand = new DelegateCommand(DeleteReferencedModelCommand_Executed);
        }

        #region Commands
        /// <summary>
        /// Edit path command.
        /// </summary>
        public DelegateCommand EditPathCommand
        {
            get { return this.editPathCommand; }

        }

        /// <summary>
        /// CreateNewReferencedModel command.
        /// </summary>
        public DelegateCommand CreateNewReferencedModelCommand
        {
            get { return this.createNewReferencedModelCommand; }
        }

        /// <summary>
        /// DeleteReferencedModelCommand command.
        /// </summary>
        public DelegateCommand DeleteReferencedModelCommand
        {
            get { return this.deleteReferencedModelCommand; }

        }

        /// <summary>
        /// EditPathCommand executed.
        /// </summary>
        protected virtual void EditPathCommand_Executed()
        {
            EditReferencedModel();
        }
        
        /// <summary>
        /// CreateNewReferencedModelCommand executed.
        /// </summary>
        private void CreateNewReferencedModelCommand_Executed()
        {
            CreateNewReferencedModel();
        }

        /// <summary>
        /// DeleteReferencedModelCommand executed.
        /// </summary>
        private void DeleteReferencedModelCommand_Executed()
        {
            DeleteReferencedModel();
        }
        #endregion

        /// <summary>
        /// Override: Can not handle multiple elements.
        /// </summary>
        public override bool CanHandleMultipleElements
        {
            get
            {
                return false;
            }
            set
            {
                
            }
        }

        /// <summary>
        /// Gets whether a model is referenced in this reference model or not.
        /// </summary>
        public abstract bool IsReferencedModelSet
        {
            get;
        }

        /// <summary>
        /// Gets the filter string for the open/save file dialog.
        /// </summary>
        public abstract string FileDialogFilter
        {
            get;
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            
        }

        /// <summary>
        /// Converts the property value and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        public override object GetPropertyValue()
        {
            throw new NotImplementedException("Implement in derived class!");
            /*
            object obj = PropertyGridEditorViewModel.GetPropertyValue(this.Elements[0], this.PropertyName);
            if (obj != null && obj is IParentModelElement)
            {
                IParentModelElement parent = this.ViewModelStore.GetDomainModelServices(obj as ModelElement).ElementParentProvider.GetParentModelElement(this.Elements[0] as ModelElement);
                if (parent == null)
                    throw new ArgumentNullException("Parent of element " + this.Elements[0].ToString() + " can not be null");

                string path = parent.DomainFilePath;
                string dirName = new System.IO.FileInfo(path).DirectoryName;
                string curPath = PathHelper.EvaluateRelativePath(dirName, (obj as IParentModelElement).DomainFilePath);

                return curPath;
            }
            else
                return "";*/
        }

        /// <summary>
        /// Creates a new referenced model.
        /// </summary>
        protected virtual void CreateNewReferencedModel()
        {
            ISaveFileService saveFileService = this.GlobalServiceProvider.Resolve<ISaveFileService>();
            saveFileService.Filter = FileDialogFilter;
            if (saveFileService.ShowDialog(null) == true)
            {
                if (!EnsureClosing())
                    return;

                System.IO.File.CreateText(saveFileService.FileName).Close();
                SetReferencedModel(saveFileService.FileName);
            }

            OnPropertyChanged("IsReferencedModelSet");
            OnPropertyChanged("PropertyValue");
        }

        /// <summary>
        /// Deletes a referenced domain model.
        /// </summary>
        protected virtual void DeleteReferencedModel()
        {
            EnsureClosing();

            OnPropertyChanged("IsReferencedModelSet");
            OnPropertyChanged("PropertyValue");
        }

        /// <summary>
        /// Edit a referenced model.
        /// </summary>
        protected virtual void EditReferencedModel()
        {
            IOpenFileService openFileService = this.GlobalServiceProvider.Resolve<IOpenFileService>();
            openFileService.Filter = FileDialogFilter;
            if (openFileService.ShowDialog(null) == true)
            {
                if (!EnsureClosing())
                    return;

                bool bEnsureOpening;
                using (new Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI.WaitCursor())
                {
                    bEnsureOpening = EnsureOpening(openFileService.FileName);
                }
                if (!bEnsureOpening)
                    return;

                SetReferencedModel(openFileService.FileName);
            }

            OnPropertyChanged("IsReferencedModelSet");
            OnPropertyChanged("PropertyValue");
        }

        /// <summary>
        /// Loads the model from the given file path and sets it to its appropriate element.
        /// </summary>
        /// <param name="filePath">File path to load the model from. Can be null to indicate that there is no referenced domain model.</param>
        protected abstract void SetReferencedModel(string filePath);

        /// <summary>
        /// Ensures that the user truly wants to remove a reference to a domain model.
        /// </summary>
        /// <returns>True to remove; False otherwise.</returns>
        protected abstract bool EnsureClosing();

        /// <summary>
        /// Ensures that the user can open the selected file and refence the domain model.
        /// </summary>
        /// <returns>True to reference; False otherwise.</returns>
        protected abstract bool EnsureOpening(string filePath);
    }
}

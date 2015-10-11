using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.UI;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents a multiple role property style view model.
    /// </summary>
    public class MultipleRoleEditorViewModel : RoleEditorViewModel
    {
        private DelegateCommand deleteElementCommand;
        private DelegateCommand addElementCommand;
        private DelegateCommand navigateToElementCommand;

        private BaseModelElementViewModel selectedObject;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="domainRelationshipInfo">Relationship domain class info.</param>
        /// <param name="sourceRoleId">RoleId of the source role player. </param>
        public MultipleRoleEditorViewModel(ViewModelStore viewModelStore, DomainRelationshipInfo domainRelationshipInfo, Guid sourceRoleId)
            : base(viewModelStore, domainRelationshipInfo, sourceRoleId)
        {
            deleteElementCommand = new DelegateCommand(DeleteElementCommand_Executed);
            addElementCommand = new DelegateCommand(AddElementCommand_Executed);
            navigateToElementCommand = new DelegateCommand(NavigateToElementCommand_Executed);
        }

        /// <summary>
        /// Override: can not host multiple elements.
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
        /// Converts the property value (in respect to multiple source elements) and returns the converted value.
        /// </summary>
        /// <returns>Converted property value.</returns>
        /// <remarks>
        /// Converter: All equal --> use value. One differs --> null value.
        /// </remarks>
        public override object GetPropertyValue()
        {
            object value = PropertyGridEditorViewModel.GetPropertyValue(this.Elements[0], this.PropertyName);

            if (value is IEnumerable)
            {
                List<BaseModelElementViewModel> models = new List<BaseModelElementViewModel>();
                foreach (ModelElement m in (IEnumerable)value)
                {
                    models.Add(this.ViewModelStore.Factory.CreateModelElementBaseViewModel(m));
                }
                return models;
            }
            else
                return null;
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            // not needed here
        }

        /// <summary>
        /// Delete element command.
        /// </summary>
        public DelegateCommand DeleteElementCommand
        {
            get { return deleteElementCommand; }
        }

        /// <summary>
        /// Delete element executed.
        /// </summary>
        protected virtual void DeleteElementCommand_Executed()
        {
            if (SelectedObject != null)
            {
                ReadOnlyCollection<ElementLink> links = DomainRoleInfo.GetElementLinks<ElementLink>(this.Elements[0] as ModelElement, this.SourceRoleId);
                foreach (ElementLink link in links)
                {
                    ModelElement target = DomainRoleInfo.GetRolePlayer(link, this.TargetRoleId);
                    if (SelectedObject.Element == target)
                    {
                        try
                        {
                            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Delete relationship"))
                            {
                                link.Delete();
                                transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Error while deleting: " + ex.Message);
                        }
                        break;
                    }
                }
            }
            
        }

        /// <summary>
        /// Gets or sets the currently selected object
        /// </summary>
        public BaseModelElementViewModel SelectedObject
        {
            get { return selectedObject; }
            set 
            { 
                this.selectedObject = value;
                OnPropertyChanged("SelectedObject");
            }
        }

        /// <summary>
        /// Edit element command.
        /// </summary>
        public DelegateCommand AddElementCommand
        {
            get { return addElementCommand; }
        }

        /// <summary>
        /// Delete element executed.
        /// </summary>
        protected virtual void AddElementCommand_Executed()
        {
            WaitCursor cursor = new WaitCursor();
            try
            {
                // update the default values list first.
                this.UpdateDefaultValuesList();

                using (SelectElementViewModel vm = new SelectElementViewModel(this.ViewModelStore, this.DefaultValues))
                {
                    vm.Title = "Select a role player";

                    if (this.Elements.Count == 1)
                        if (this.Elements[0] is IDomainModelOwnable)
                            vm.Title += " of type " + (this.Elements[0] as IDomainModelOwnable).DomainElementTypeDisplayName;
                        //vm.Title += " of type " + this.ViewModelStore.GetDomainModelServices(this.Elements[0] as ModelElement).ElementTypeProvider.GetTypeDisplayName(
                        //    this.Elements[0] as ModelElement);

                    cursor.Dispose();
                    cursor = null;

                    bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("SelectElementPopup", vm);
                    if (result == true && vm.SelectedElement is ModelElement)
                    {
                        try
                        {
                            using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Add new relationship"))
                            {
                                RoleAssignment[] roleAssignments = new RoleAssignment[2];
                                roleAssignments[0] = new RoleAssignment(this.SourceRoleId, this.Elements[0] as ModelElement);
                                roleAssignments[1] = new RoleAssignment(this.TargetRoleId, vm.SelectedElement as ModelElement);
                                this.Store.ElementFactory.CreateElementLink(this.RelationshipDomainClassId, roleAssignments);

                                transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Error while adding: " + ex.Message);
                        }
                    }
                }
            }
            finally
            {
                if( cursor != null )
                    cursor.Dispose();
            }
            GC.Collect();
        }

        /// <summary>
        /// Navigate To Element Command.
        /// </summary>
        public DelegateCommand NavigateToElementCommand
        {
            get { return navigateToElementCommand; }
        }

        /// <summary>
        /// Navigate To Element Command executed.
        /// </summary>
        protected virtual void NavigateToElementCommand_Executed()
        {
            if (SelectedObject != null)
            {
                ModelElement selectedValue = SelectedObject.Element;
                if (selectedValue != null)
                {
                    SelectedItemsCollection col = new SelectedItemsCollection();
                    col.Add(selectedValue);
                    EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.Commands;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Data;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Selection;
using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Services;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.PropertyGrid
{
    /// <summary>
    /// This class represents an unary role property style view model.
    /// </summary>
    public class UnaryRoleEditorViewModel : RoleEditorViewModel
    {
        /// <summary>
        /// Sentinel item.
        /// </summary>
        protected static UnaryRoleEditorViewModelSentinelItem SentinelItem = new UnaryRoleEditorViewModelSentinelItem();

        private DelegateCommand deleteElementCommand;
        private DelegateCommand editElementCommand;
        private DelegateCommand navigateToElementCommand;

        /// <summary>
        /// Constuctor.
        /// </summary>
        /// <param name="viewModelStore">The store this view model belongs to.</param>
        /// <param name="domainRelationshipInfo">Relationship domain class info.</param>
        /// <param name="sourceRoleId">RoleId of the source role player. </param>
        public UnaryRoleEditorViewModel(ViewModelStore viewModelStore, DomainRelationshipInfo domainRelationshipInfo, Guid sourceRoleId)
            : base(viewModelStore, domainRelationshipInfo, sourceRoleId)
        {
            deleteElementCommand = new DelegateCommand(DeleteElementCommand_Executed);
            editElementCommand = new DelegateCommand(EditElementCommand_Executed);
            navigateToElementCommand = new DelegateCommand(NavigateToElementCommand_Executed);
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
            List<object> values = PropertyGridEditorViewModel.GetPropertyValues(this.Elements, this.PropertyName);
            if (values.Count == 0)
                return SentinelItem;

            ModelElement value = values[0] as ModelElement;
            foreach (object v in values)
            {
                if (value != v as ModelElement)
                {
                    value = null;
                    break;
                }
            }

            if (value == null)
                return SentinelItem;
            else
                return this.ViewModelStore.Factory.CreateModelElementBaseViewModel(value);
        }

        /// <summary>
        /// Assigns the property value to the property of every source element.
        /// </summary>
        /// <param name="value">Property value to be assigned.</param>
        public override void SetPropertyValue(object value)
        {
            // not needed
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
            try
            {
                using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update role value - " + this.PropertyName))
                {
                    PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, null);
                    transaction.Commit();
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        /// <summary>
        /// Edit element command.
        /// </summary>
        public DelegateCommand EditElementCommand
        {
            get { return editElementCommand; }
        }

        /// <summary>
        /// Edit element executed.
        /// </summary>
        protected virtual void EditElementCommand_Executed()
        {
            // update the default values list first.
            this.UpdateDefaultValuesList();

            using (SelectElementViewModel vm = new SelectElementViewModel(this.ViewModelStore, this.DefaultValues))
            {
                vm.Title = "Select a role player";

                //if (this.Elements.Count == 1)
                //    vm.Title += " of type " + this.ViewModelStore.ElementTypeProvider.GetTypeDisplayName(this.Elements[0] as ModelElement);

                bool? result = this.GlobalServiceProvider.Resolve<IUIVisualizerService>().ShowDialog("SelectElementPopup", vm);
                if (result == true)
                {
                    try
                    {
                        using (Transaction transaction = this.Store.TransactionManager.BeginTransaction("Update role value - " + this.PropertyName))
                        {
                            PropertyGridEditorViewModel.SetPropertyValues(this.Elements, this.PropertyName, vm.SelectedElement);
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Error while adding: " + ex.Message);
                    }
                }
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
            BaseModelElementViewModel selectedValue = GetPropertyValue() as BaseModelElementViewModel;
            if (selectedValue != null)
            {
                SelectedItemsCollection col = new SelectedItemsCollection();
                col.Add(selectedValue.Element);
                EventManager.GetEvent<SelectionChangedEvent>().Publish(new SelectionChangedEventArgs(this, col));
            }
        }
        
        /// <summary>
        /// Sentinel item class.
        /// </summary>
        protected class UnaryRoleEditorViewModelSentinelItem
        {
            /// <summary>
            /// (none) as name of the sentinel item.
            /// </summary>
            public string DomainElementFullName
            {
                get{ return "(none)"; }
            }

            /// <summary>
            /// True, indicating this is the sentinel item.
            /// </summary>
            public bool IsSentinelDomainElementItem
            {
                get{ return true; }
            }
        }
    }
        
}

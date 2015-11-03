using Tum.PDE.LanguageDSL.Visualization;
using Tum.PDE.LanguageDSL.Visualization.ViewModel;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Data;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL
{
	// Partial implementation of the class generated with the DocView.tt
	// This partial needs to be updated by the DSL author when he/she wants
	// to rename the Wpf control that represents the model.
    partial class LanguageDSLDocView
    {
		/// <summary>
		/// This methods creates the WPF control that will represent the model
		/// </summary>
		/// <returns></returns>
		global::System.Windows.UIElement CreateControl()
		{
			return new ViewControl();
		}

        /// <summary>
        /// Creates the binding between the Model and the UI via the use of ViewModels.
        /// </summary>
        public void CreateBinding()
        {
            // provide view model to UI
            this.WpfViewControl.DataContext = (this.DocData as LanguageDSLDocData).ViewModel;

            // react on selection changes
            if( LanguageDSLDocData.ViewModelStore != null )
                LanguageDSLDocData.ViewModelStore.EventManager.GetEvent<SelectionChangedEvent>().Subscribe(new System.Action<SelectionChangedEventArgs>(OnSelectionChanged));
        }

        /// <summary>
        /// Called whenever selection changes.
        /// </summary>
        /// <param name="args"></param>
        private void OnSelectionChanged(SelectionChangedEventArgs args)
        {
            this.SetSelectedComponents(args.SelectedItems);
        }

        
	}
}

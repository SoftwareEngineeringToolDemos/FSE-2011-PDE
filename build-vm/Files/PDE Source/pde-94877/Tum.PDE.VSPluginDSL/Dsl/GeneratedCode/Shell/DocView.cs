 
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;

using DslEditorShell = global::Tum.PDE.ToolFramework.Modeling.Shell;

namespace Tum.PDE.VSPluginDSL
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	[global::System.ComponentModel.ToolboxItemFilterAttribute(global::Tum.PDE.VSPluginDSL.VSPluginDSLToolboxHelperBase.ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require)]
	internal partial class VSPluginDSLDocView : VSPluginDSLDocViewBase
	{
		/// <summary>
		/// Constructs a new VSPluginDSLDocView.
		/// </summary>
		public VSPluginDSLDocView(DslEditorShell::ModelShellData docData, global::System.IServiceProvider serviceProvider)
			: base(docData, serviceProvider)
		{
		}
	}

	/// <summary>
	/// Class that hosts the diagram surface in the Visual Studio document area.
	/// </summary>
	internal abstract class VSPluginDSLDocViewBase : DslEditorShell::ModelDocView
	{
		/// <summary>
		/// Constructs a new VSPluginDSLDocView.
		/// </summary>
		protected VSPluginDSLDocViewBase(DslEditorShell::ModelShellData docData, global::System.IServiceProvider serviceProvider) 
			: base(docData, serviceProvider)
		{
			
		}
		
		/// <summary>
		/// Gets or sets the main view model.
		/// </summary>
		public Tum.PDE.VSPluginDSL.ViewModel.VSPluginDSLMainViewModel ViewModel
		{
			get;
			set;
		}
		
		/// <summary>
		/// Gets or sets the main ui control.
		/// </summary>
		public global::System.Windows.FrameworkElement ViewControl
		{
			get;
			set;
		}
		
		#region Methods
		/// <summary>
		/// This methods creates the WPF control that will represent the model
		/// </summary>
		/// <returns></returns>
		protected override global::System.Windows.FrameworkElement CreateControl()
		{
            this.ViewControl = new MainViewControl();
            this.CreateViewModel();

			// Delay initialization of the ui until other tool windows have also 
			// had a chance to be initialized
			this.ViewControl.Dispatcher.BeginInvoke((System.Action)delegate
            {
                // Populate the list view
                this.SetViewModel();
            });

			// add to main shell vm
            (this.Package as VSPluginDSLPackage).PackageController.AddShellViewModel(this.ViewModel, this.DocData.FullFileName);
			(this.Package as VSPluginDSLPackage).PackageController.SetCurrentShellViewModel(this.ViewModel);

            return this.ViewControl;
		}
		
		/// <summary>
		/// Creates the main view model.
		/// </summary>
		/// <returns></returns>
		protected virtual void CreateViewModel()
		{
            VSPluginDSLDocData docData = this.DocData as VSPluginDSLDocData;
			this.ViewModel = new Tum.PDE.VSPluginDSL.ViewModel.VSPluginDSLMainViewModel(docData.ModelData, this.Package as VSPluginDSLPackage);
			this.ViewModel.FullFileName = this.DocData.FullFileName;
		}			
		
		/// <summary>
		/// Set the vm to the data context of the view.
		/// </summary>
		/// <returns></returns>
		protected virtual void SetViewModel()
		{
			(this.ViewControl as MainViewControl).SetViewModel(this.ViewModel);
		}		
		
        /// <summary>
        /// Clean up.
        /// </summary>
        protected override void OnClose()
        {
			//(this.Package as VSPluginDSLPackage).PackageController.RemoveShellViewModel(this.ViewModel);		
		
			this.DocData.CloseDocument();
					
            (this.ViewControl as MainViewControl).Dispose();
			this.ViewModel.Dispose();
            
            this.ViewModel = null;
            this.ViewControl = null;
			
            base.OnClose();			
        }		
		#endregion
	}	
}

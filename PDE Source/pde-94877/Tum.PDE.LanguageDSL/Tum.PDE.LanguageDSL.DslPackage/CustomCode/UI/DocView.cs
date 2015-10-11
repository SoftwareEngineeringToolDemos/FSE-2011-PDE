using DslShell=global::Microsoft.VisualStudio.Modeling.Shell;
using Wpf=global::System.Windows.Controls;


namespace Tum.PDE.LanguageDSL
{
	internal partial class LanguageDSLDocView
	{
		global::System.Windows.Forms.Integration.ElementHost wpfControlHost;

		// This DSL defines a custom editor. Therefore, we must chave a partial implementation of DocView and
		// override the Window property of this class to specify the window that will be hosted as the editor.
		// In the case of a WPF view, this is a Windows.From ElementHost that can host a WPF UIElement (the WPF View control)
		public override global::System.Windows.Forms.IWin32Window Window
		{
			get
			{
				if (wpfControlHost == null)
				{
					wpfControlHost = new global::System.Windows.Forms.Integration.ElementHost();
					wpfControlHost.Child = CreateControl();

				}
				return wpfControlHost;
			}
		}

		/// <summary>
		/// Access to the Wpf View control itself
		/// </summary>
		Wpf::ContentControl WpfViewControl
		{
			get
			{
				if (wpfControlHost != null)
					return wpfControlHost.Child as Wpf::ContentControl;
				else
					return null;
			}
		}



		/// <summary>
		/// Loads the view. Creates the WPF View control, hosts its, binds it to the RootElement, and subscribes to the selection
		/// of any WPF sub-control
		/// </summary>
		/// <returns></returns>
		protected override bool LoadView()
		{
			bool returnVal = base.LoadView();
			if (returnVal)
			{
				CreateBinding();
			}
			return returnVal;
		}

		/// <summary>
		/// Called when window is closed. Overridden here to remove our objects from the selection context so 
		/// that the property browser doesn't call back on our objects after the window is closed.
		/// </summary>
        protected override void OnClose()
        {
			// notify the child wpf control that the view is closed by resetting the data context
            this.WpfViewControl.DataContext = null;

            base.OnClose();
        }

		/// <summary>
		/// Implement object selection as a simple collection.
		/// </summary>
		/// <remarks>
		/// Base class has no implementation of this method so we'll need to
		/// provide a simple one.
		/// </remarks>
		/// <param name="count"></param>
		/// <param name="objects"></param>
		/// <param name="flags"></param>
		protected override void DoSelectObjects(uint count, object[] objects, uint flags)
		{
			base.SelectedElements.Clear();
			for (int i = 0; i < count && i < objects.Length; i++)
			{
				base.SelectedElements.Add(objects[i]);
			}
			this.OnSelectionChanged(null);
		}

		private DslShell::CurrentSelectionPusher selectionPusher;

		/// <summary>
		/// Component to push the selected item on the form to the PropertiesWindow
		/// </summary>
		protected DslShell::CurrentSelectionPusher SelectionPusher
		{
			get
			{
				if (this.selectionPusher == null)
				{
					this.selectionPusher = new DslShell::CurrentSelectionPusher(this.ServiceProvider, this);
				}
				return this.selectionPusher;
			}
		}
	}
}
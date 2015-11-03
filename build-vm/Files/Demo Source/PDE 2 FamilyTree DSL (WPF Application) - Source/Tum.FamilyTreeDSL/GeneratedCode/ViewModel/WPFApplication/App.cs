 
using DslEditorBaseControls =  Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls;

namespace Tum.FamilyTreeDSL.View
{	
	/// <summary>
    /// This class is used as a base class for the app class.
    /// </summary>	
	public abstract class DslEditorApplication : DslEditorBaseControls.PDEApplication
	{
		/// <summary>
        /// Raises the System.Windows.Application.Startup event.
        /// </summary>
        /// <param name="e">A System.Windows.StartupEventArgs that contains the event data.</param>
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);

#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif
            this.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
        }

        /// <summary>
        /// Start in debug mode. No need to handle exceptions.
        /// </summary>
        private void RunInDebugMode()
        {
            System.Windows.Application.Current.MainWindow = new MainWindow();
            System.Windows.Application.Current.MainWindow.Show();
			

            //(System.Windows.Application.Current.MainWindow as DslEditorMainWindow).LoadInBackground();
        }

        /// <summary>
        /// Run in release mode. Handle exceptions.
        /// </summary>
        private void RunInReleaseMode()
        {
            System.AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            try
            {
            	System.Windows.Application.Current.MainWindow = new MainWindow();
            	System.Windows.Application.Current.MainWindow.Show();
			
            	//(System.Windows.Application.Current.MainWindow as DslEditorMainWindow).LoadInBackground();
            }
            catch (System.Exception ex)
            {
				// rethrow exception to be handled by AppDomainUnhandledException 
                throw new System.Exception(ex.Message, ex);
            }
        }

        private void AppDomainUnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
			if( System.Windows.Application.Current != null )
				if( (System.Windows.Application.Current.MainWindow as DslEditorMainWindow) != null )
            		HandleException(e.ExceptionObject as System.Exception, (System.Windows.Application.Current.MainWindow as DslEditorMainWindow).DocData as Tum.PDE.ToolFramework.Modeling.ModelData);
        }
		
		/// <summary>
        /// Handle the given unhandled exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        /// <param name="data">Current model data. If this is not null an a model is opened, the model is saved to a temporare file.</param>
        protected virtual void HandleException(System.Exception ex, Tum.PDE.ToolFramework.Modeling.ModelData data)
        {
            //MessageBox.Show("An unhandled error occured: " + ex.Message);
			HandleException(ex);

            if (data != null)
                this.SaveModelTemporarly(data);
            SaveException(ex);
        }

        /// <summary>
        /// Saves the currently opened model (ModelData.Instance.CurrentModelContext.RootElement) to a temporarly file.
        /// </summary>
        /// <param name="modelData">Current model data.</param>
        protected virtual void SaveModelTemporarly(Tum.PDE.ToolFramework.Modeling.ModelData modelData)
        {
            if (modelData.CurrentModelContext != null)
                if (modelData.CurrentModelContext.RootElement != null)
                    if (modelData.CurrentModelContext.RootElement is Tum.PDE.ToolFramework.Modeling.IParentModelElement)
                    {
                        try
                        {
                            string filename = (modelData.CurrentModelContext.RootElement as Tum.PDE.ToolFramework.Modeling.IParentModelElement).DomainFilePath;
                            int counter = 0;
                            while (true)
                            {
                                if (!(System.IO.File.Exists(filename + "_temp" + counter + ".xml")))
                                    break;

                                counter++;
                            }

                            modelData.CurrentModelContext.Save(filename + "_temp" + counter + ".xml");
                            System.Windows.MessageBox.Show("An unhandled error occured. The model was saved to " + filename + "_temp" + counter + ".xml", "Unhandled error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        }
                        catch { }
                    }
        }
	}
}

using System;
using System.Windows;
using Tum.PDE.ToolFramework.Modeling.Base;


namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls
{
    /// <summary>
    /// This is a base class for a PDE application
    /// </summary>
    public abstract class PDEApplication : Application
    {
        /// <summary>
        /// Handle the given unhandled exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        protected virtual void HandleException(Exception ex)
        {
            //this.HandleException(ex, null);
            this.SaveException(ex);
        }

        /*
        /// <summary>
        /// Handle the given unhandled exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        /// <param name="data">Current model data. If this is not null an a model is opened, the model is saved to a temporare file.</param>
        protected virtual void HandleException(Exception ex, ModelData data)
        {
            MessageBox.Show("An unhandled error occured: " + ex.Message);

            if (data != null)
                this.SaveModelTemporarly(data);
            SaveException(ex);
        }

        /// <summary>
        /// Saves the currently opened model (ModelData.Instance.CurrentModelContext.RootElement) to a temporarly file.
        /// </summary>
        /// <param name="modelData">Current model data.</param>
        protected virtual void SaveModelTemporarly(ModelData modelData)
        {
            if (modelData.CurrentModelContext != null)
                if (modelData.CurrentModelContext.RootElement != null)
                    if (modelData.CurrentModelContext.RootElement is IParentModelElement)
                    {
                        try
                        {
                            string filename = (modelData.CurrentModelContext.RootElement as IParentModelElement).DomainFilePath;
                            int counter = 0;
                            while (true)
                            {
                                if (!(System.IO.File.Exists(filename + "_temp" + counter + ".xml")))
                                    break;

                                counter++;
                            }

                            modelData.CurrentModelContext.Save(filename + "_temp" + counter + ".xml");
                            MessageBox.Show("An unhandled error occured. The model was saved to " + filename + "_temp" + counter + ".xml", "Unhandled error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        catch { }
                    }
        }
        */

        /// <summary>
        /// Save unhandled exception.
        /// </summary>
        /// <param name="ex">Exception ex.</param>
        protected virtual void SaveException(Exception ex)
        {
            try
            {
                int counter = 0;
                string name = "!error";
                string extension = ".txt";
                string fileName = name + extension;
                while (System.IO.File.Exists(fileName))
                {
                    counter++;
                    fileName = name + counter.ToString() + extension;
                }

                string msg = ex.ToString();
                msg += "\r\n";
                msg += ex.Message.ToString();
                msg += "\r\n";
                if (ModelState.IsInDebugState)
                    msg += LogHelper.GetLog();

                System.IO.File.WriteAllText(fileName, msg);
                MessageBox.Show("An unhandled error occured. The exception " + ex.ToString() + " has been saved to: " + fileName, "Unhandled error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch { }
        }

        /// <summary>
        /// Exit..
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                if (LogHelper.HasErrors())
                {
                    int counter = 0;
                    string name = "!error";
                    string extension = ".txt";
                    string fileName = name + extension;
                    while (System.IO.File.Exists(fileName))
                    {
                        counter++;
                        fileName = name + counter.ToString() + extension;
                    }

                    LogHelper.DumpLog(fileName);
                }
            }
            catch { }

            base.OnExit(e);
        }
    }
}

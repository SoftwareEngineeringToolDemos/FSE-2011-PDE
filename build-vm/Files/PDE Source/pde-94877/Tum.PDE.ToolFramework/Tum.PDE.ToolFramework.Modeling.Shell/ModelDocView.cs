using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Shell;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Forms;

namespace Tum.PDE.ToolFramework.Modeling.Shell
{
    /// <summary>
    /// Class that hosts the diagram surface in the Visual Studio document area.
    /// </summary>
    public abstract class ModelDocView : ModelingDocView
    {
        private ModelPackage package;
        private ElementHost wpfControlHost;

        /// <summary>
        /// Constructs a new ModelDocView.
		/// </summary>
        /// <param name="docData">Modeling doc data.</param>
        /// <param name="serviceProvider">Service provider.</param>
        protected ModelDocView(ModelShellData docData, IServiceProvider serviceProvider)
            : base(docData, serviceProvider)
		{
            package = serviceProvider as ModelPackage;

            this.DocData.DocumentClosing += new EventHandler(DocDataDocumentClosing);
            this.DocData.DocumentLoaded += new EventHandler(DocDataDocumentLoaded);
            this.DocData.DocumentSaved += new EventHandler(DocDataDocumentSaved);
		}
        
        /// <summary>
        /// Window.
        /// </summary>
        /// <remarks>
        /// This DSL defines a custom editor. Therefore, we must chave a partial implementation of DocView and
        /// override the Window property of this class to specify the window that will be hosted as the editor.
        /// In the case of a WPF view, this is a Windows.From ElementHost that can host a WPF UIElement (the WPF View control).
        /// </remarks>
        public override IWin32Window Window
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
        /// Gets the document this view corresponds to.
        /// </summary>
        public new ModelShellData DocData
        {
            get
            {
                return base.DocData as ModelShellData;
            }
        }

        /// <summary>
        /// Gets the model package.
        /// </summary>
        public ModelPackage Package
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// This methods creates the WPF control that will represent the model
        /// </summary>
        /// <returns></returns>
        protected abstract global::System.Windows.FrameworkElement CreateControl();

        /// <summary>
        /// Called after the document has been loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DocDataDocumentLoaded(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called after the document has been saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DocDataDocumentSaved(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called during the document closing process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DocDataDocumentClosing(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Called to initialize the view after the corresponding document has been loaded.
        /// </summary>
        protected override bool LoadView()
        {
            base.LoadView();

            global::System.Diagnostics.Debug.Assert(this.DocData.RootElement != null);
            if (this.DocData.RootElement == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Close.
        /// </summary>
        protected override void OnClose()
        {
            this.DocData.DocumentClosing -= new EventHandler(DocDataDocumentClosing);
            this.DocData.DocumentLoaded -= new EventHandler(DocDataDocumentLoaded);
            this.DocData.DocumentSaved -= new EventHandler(DocDataDocumentSaved);

            this.DocData.CloseData();
        }
    }
}

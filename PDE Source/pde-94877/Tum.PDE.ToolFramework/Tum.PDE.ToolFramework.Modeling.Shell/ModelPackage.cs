using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;

namespace Tum.PDE.ToolFramework.Modeling.Shell
{	
    /// <summary>
    /// This class implements the VS package that integrates this DSL into Visual Studio.
    /// </summary>
    public abstract class ModelPackage : ModelingPackage, IVsSelectionEvents
    {
        private List<Guid> toolWindowIDList;

        /// <summary>
        /// Gets the tool window type for the given view model type if possible. Throws NotSupportedException otherwise.
        /// </summary>
        /// <param name="vmType"></param>
        /// <returns></returns>
        public abstract Type GetToolWindowType(Type vmType);

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <remarks>
        /// Connects to the IVsMonitorSelection Service.
        /// </remarks>
        protected override void Initialize()
        {
            base.Initialize();

            IVsMonitorSelection monitorSelectionService = this.GetService(typeof(SVsShellMonitorSelection)) as IVsMonitorSelection;
            uint cookie = 0;
            monitorSelectionService.AdviseSelectionEvents(this, out cookie);

            this.toolWindowIDList = GetToolWindowIdList();
        }

        /// <summary>
        /// Gets the editor type id.
        /// </summary>
        public abstract Guid EditorTypeId
        {
            get;
        }

        /// <summary>
        /// Returns a list of guids identifying the tool windows contained in this package.
        /// </summary>
        /// <returns>List of guid of tool windows in this package.</returns>
        public abstract List<Guid> GetToolWindowIdList();

        /// <summary>
        /// Gets or sets the editor factory.
        /// </summary>
        public ModelEditorFactory EditorFactory
        {
            get;
            set;
        }

        #region IVsSelectionEvents
        /// <summary>
        /// Reports that the command UI context has changed.
        /// </summary>
        /// <param name="dwCmdUICookie">DWORD representation of the GUID identifying the command UI context passed in as the rguidCmdUI parameter in the call to GetCmdUIContextCookie.</param>
        /// <param name="fActive">Flag that is set to true if the command UI context identified by dwCmdUICookie has become active and false if it has become inactive.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnCmdUIContextChanged(uint dwCmdUICookie, int fActive)
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Reports that the project hierarchy, item and/or selection container has changed.
        /// </summary>
        /// <param name="pHierOld">Pointer to the IVsHierarchy interface of the project hierarchy for the previous selection.</param>
        /// <param name="itemidOld">Identifier of the project item for previous selection. For valid itemidOld values, see VSITEMID.</param>
        /// <param name="pMISOld">Pointer to the IVsMultiItemSelect interface to access a previous multiple selection.</param>
        /// <param name="pSCOld">Pointer to the ISelectionContainer interface to access Properties window data for the previous selection.</param>
        /// <param name="pHierNew">Pointer to the IVsHierarchy interface of the project hierarchy for the current selection.</param>
        /// <param name="itemidNew">Identifier of the project item for the current selection. For valid itemidNew values, see VSITEMID.</param>
        /// <param name="pMISNew">Pointer to the IVsMultiItemSelect interface for the current selection.</param>
        /// <param name="pSCNew">Pointer to the ISelectionContainer interface for the current selection.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnSelectionChanged(IVsHierarchy pHierOld, uint itemidOld, IVsMultiItemSelect pMISOld, ISelectionContainer pSCOld, IVsHierarchy pHierNew, uint itemidNew, IVsMultiItemSelect pMISNew, ISelectionContainer pSCNew)
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Reports that an element value has changed.
        /// </summary>
        /// <param name="elementid">DWORD value representing a particular entry in the array of element values associated with the selection context. For valid elementid values, see VSConstants.VSSELELEMID.</param>
        /// <param name="varValueOld">VARIANT that contains the previous element value. This parameter contains element-specific data, such as a pointer to the IOleCommandTarget interface if elementid is set to SEID_ResultsList or a pointer to the IOleUndoManager interface if elementid is set to SEID_UndoManager.</param>
        /// <param name="varValueNew">VARIANT that contains the new element value. This parameter contains element-specific data, such as a pointer to the IOleCommandTarget interface if elementid is set to SEID_ResultsList or a pointer to the IOleUndoManager interface if elementid is set to SEID_UndoManager.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
        public virtual int OnElementValueChanged(uint elementid, object varValueOld, object varValueNew)
        {
            if (elementid == (uint)VSConstants.VSSELELEMID.SEID_WindowFrame)
            {
                IVsWindowFrame oldFrame = (IVsWindowFrame)varValueOld;
                IVsWindowFrame newFrame = (IVsWindowFrame)varValueNew;

                WindowChangedEventArgs args = new WindowChangedEventArgs();
                if (oldFrame != null)
                {
                    args.OldData = ParseFrame(oldFrame);
                }

                if (newFrame != null)
                {
                    args.NewData = ParseFrame(newFrame);
                }

                this.OnActiveWindowChangedEvent(args);
            }
            return VSConstants.S_OK;
        }
        
        private WindowChangedData ParseFrame(IVsWindowFrame frame)
        {
            if (IsDocumentFrame(frame))
            {
                Guid key = GetEditorTypeId(frame);
                if (key == this.EditorTypeId)
                {
                    WindowChangedData w = new WindowChangedData(true, true, key);
                    w.FullFileName = GetEditorFullFileName(frame);
                    return w;
                }
                else
                    return new WindowChangedData(true, false, key);
                
            }
            else
            {
                Guid key = GetPersistenceSlot(frame);
                if (toolWindowIDList.Contains(key))
                    return new WindowChangedData(false, true, key);
                else
                    return new WindowChangedData(false, false, key);
            }
        }

        /// <summary>
        /// ActiveWindowChangedEvent delegate.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        public delegate void ActiveWindowChangedEventHandler(Object sender, WindowChangedEventArgs e);

        /// <summary>
        /// ActiveWindowChanged event. Called if the active window (that does belong to this package) changes.
        /// </summary>
        public event ActiveWindowChangedEventHandler ActiveWindowChangedEvent;

        /// <summary>
        /// Called if the active window changes.
        /// </summary>
        /// <param name="e"></param>
        protected void OnActiveWindowChangedEvent(WindowChangedEventArgs e)
        {
            if (this.ActiveWindowChangedEvent != null)
                this.ActiveWindowChangedEvent(this, e);
        }

        /// <summary>
        /// Active window changed event arguments.
        /// </summary>
        public class WindowChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public WindowChangedEventArgs()
            {
            }

            /// <summary>
            /// Gets the new data. This is the window that has been activated. Can be null.
            /// </summary>
            public WindowChangedData NewData
            {
                get;
                set;
            }

            /// <summary>
            /// Gets the new data. This is the window that was activated before the change. Can be null.
            /// </summary>
            public WindowChangedData OldData
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Data for a window.
        /// </summary>
        public class WindowChangedData
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="isDocumentFrame">True if this is document frame. False for tool frame.</param>
            /// <param name="doesBelongToPackage">True if this window does belong to this DSL package. False otherwise.</param>
            /// <param name="key">For a document frame this is the editor type id. For a tool frame this is the persistance slot id.</param>
            public WindowChangedData(bool isDocumentFrame, bool doesBelongToPackage, Guid key)
            {
                this.IsDocumentFrame = isDocumentFrame;
                this.DoesBelongToPackage = doesBelongToPackage;
                this.Key = key;
            }

            /// <summary>
            /// True if this is document frame. False for tool frame.
            /// </summary>
            public bool IsDocumentFrame
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the full file name of the document pane. Only available if IsDOcumentFrame=true and DoesBelongToPackage=true.
            /// </summary>
            public string FullFileName
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets whether this window does belong to this DSL package or not.
            /// </summary>
            public bool DoesBelongToPackage
            {
                get;
                set;
            }

            /// <summary>
            /// For a document frame this is the editor type id. For a tool frame this is the persistance slot id.
            /// </summary>
            public Guid Key
            {
                get;
                set;
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Gets the persistence slot id from a window frame.
        /// </summary>
        /// <param name="window">Window frame.</param>
        /// <returns>Persistence slot id.</returns>
        public static Guid GetPersistenceSlot(IVsWindowFrame window)
        {
            Guid guid;
            window.GetGuidProperty((int)__VSFPROPID.VSFPROPID_GuidPersistenceSlot, out guid);

            return guid;
        }

        /// <summary>
        /// Gets if the given window frame is a document or a tool frame.
        /// </summary>
        /// <param name="window">Window frame.</param>
        /// <returns>True for document frame. False for tool frame.</returns>
        public static bool IsDocumentFrame(IVsWindowFrame window)
        {
            object pvar;
            window.GetProperty((int)__VSFPROPID.VSFPROPID_Type, out pvar);

            if ((int)pvar == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets if the given window frame is a document or a tool frame.
        /// </summary>
        /// <param name="window">Window frame.</param>
        /// <returns>True for tool frame. False for document frame.</returns>
        public static bool IsToolFrame(IVsWindowFrame window)
        {
            return !IsDocumentFrame(window);
        }

        /// <summary>
        /// Gets the editor type id from a window frame.
        /// </summary>
        /// <param name="window">Window frame.</param>
        /// <returns>Editor type id.</returns>
        public static Guid GetEditorTypeId(IVsWindowFrame window)
        {
            Guid guid;
            window.GetGuidProperty((int)__VSFPROPID.VSFPROPID_guidEditorType, out guid);

            return guid;
        }

        /// <summary>
        /// Gets the editor view helper from a window frame.
        /// </summary>
        /// <param name="window">Window frame.</param>
        /// <returns>Editor view helper is it is a ModelDocView. Null otherwise.</returns>
        public static ModelDocView GetEditorViewHelper(IVsWindowFrame window)
        {
            object view;
            window.GetProperty((int)__VSFPROPID.VSFPROPID_ViewHelper, out view);

            if (view is ModelDocView)
                return (ModelDocView)view;
            return null;
        }

        /// <summary>
        /// Gets the editor full file name from a window frame.
        /// </summary>
        /// <param name="window">Window frame.</param>
        /// <returns>Editor full file name on success. Null otherwise.</returns>
        public static string GetEditorFullFileName(IVsWindowFrame window)
        {
            ModelDocView v = GetEditorViewHelper(window);
            if (v == null)
                return null;

            return v.DocData.FullFileName;
        }
        #endregion
    }
}

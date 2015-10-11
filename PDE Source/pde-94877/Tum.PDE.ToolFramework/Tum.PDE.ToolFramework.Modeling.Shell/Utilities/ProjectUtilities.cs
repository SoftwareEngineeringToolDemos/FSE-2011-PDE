using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

namespace Tum.PDE.ToolFramework.Modeling.Shell.Utilities
{
    /// <summary>
    /// Source: Microsoft CodeSweep sample.
    /// </summary>
    public class HierarchyConstants
    {
        /// <summary>
        /// 
        /// </summary>
        public const uint VSITEMID_NIL = 0xFFFFFFFF;

        /// <summary>
        /// 
        /// </summary>
        public const uint VSITEMID_ROOT = 0xFFFFFFFE;

        /// <summary>
        /// 
        /// </summary>
        public const uint VSITEMID_SELECTION = 0xFFFFFFFD;
    }
    
    /// <summary>
    /// Utilities for visual studio projects.
    /// </summary>
    public class ProjectUtilities
    {
        /// <summary>
        /// Source: Microsoft CodeSweep sample.
        /// </summary>
        /// <param name="_serviceProvider"></param>
        /// <returns></returns>
        static public IList<IVsProject> GetProjectsOfCurrentSelections(IServiceProvider _serviceProvider)
        {
            List<IVsProject> results = new List<IVsProject>();

            int hr = VSConstants.S_OK;
            IVsMonitorSelection selectionMonitor = _serviceProvider.GetService(typeof(IVsMonitorSelection)) as IVsMonitorSelection;
            IntPtr hierarchyPtr = IntPtr.Zero;
            uint itemID = 0;
            IVsMultiItemSelect multiSelect = null;
            IntPtr containerPtr = IntPtr.Zero;
            hr = selectionMonitor.GetCurrentSelection(out hierarchyPtr, out itemID, out multiSelect, out containerPtr);
            if (IntPtr.Zero != containerPtr)
            {
                Marshal.Release(containerPtr);
                containerPtr = IntPtr.Zero;
            }
            System.Diagnostics.Debug.Assert(hr == VSConstants.S_OK, "GetCurrentSelection failed.");

            if (itemID == HierarchyConstants.VSITEMID_SELECTION)
            {
                uint itemCount = 0;
                int fSingleHierarchy = 0;
                hr = multiSelect.GetSelectionInfo(out itemCount, out fSingleHierarchy);
                System.Diagnostics.Debug.Assert(hr == VSConstants.S_OK, "GetSelectionInfo failed.");

                VSITEMSELECTION[] items = new VSITEMSELECTION[itemCount];
                hr = multiSelect.GetSelectedItems(0, itemCount, items);
                System.Diagnostics.Debug.Assert(hr == VSConstants.S_OK, "GetSelectedItems failed.");

                foreach (VSITEMSELECTION item in items)
                {
                    IVsProject project = GetProjectOfItem(item.pHier, item.itemid);
                    if (!results.Contains(project))
                    {
                        results.Add(project);
                    }
                }
            }
            else
            {
                //case where no visible project is open (single file)
                if (hierarchyPtr != System.IntPtr.Zero)
                {
                    IVsHierarchy hierarchy = (IVsHierarchy)Marshal.GetUniqueObjectForIUnknown(hierarchyPtr);
                    results.Add(GetProjectOfItem(hierarchy, itemID));
                }
            }

            return results;
        }

        /// <summary>
        /// Source: Microsoft CodeSweep sample.
        /// </summary>
        /// <param name="hierarchy"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        private static IVsProject GetProjectOfItem(IVsHierarchy hierarchy, uint itemID)
        {
            return (IVsProject)hierarchy;
        }

        /// <summary>
        /// Source: Microsoft CodeSweep sample.
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        static public string GetProjectFilePath(IVsProject project)
        {
            string path = string.Empty;
            int hr = project.GetMkDocument(HierarchyConstants.VSITEMID_ROOT, out path);
            System.Diagnostics.Debug.Assert(hr == VSConstants.S_OK || hr == VSConstants.E_NOTIMPL, "GetMkDocument failed for project.");

            return path;
        }
    }
}

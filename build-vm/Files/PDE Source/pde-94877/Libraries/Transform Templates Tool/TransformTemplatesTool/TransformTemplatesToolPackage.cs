using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using EnvDTE;
using EnvDTE80;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VSLangProj;
using System.IO;
using System.Globalization;
using System.Diagnostics;

// based on: http://transftemplatetool.codeplex.com/

namespace Tum.TransformTemplatesTool
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidTransformTemplatesToolPkgString)]
    public sealed class TransformTemplatesToolPackage : Package
    {
        private System.IServiceProvider _serviceProvider;
        private EnvDTE80.DTE2 _dte;

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public TransformTemplatesToolPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            this._serviceProvider = this;
            _dte = this.GetService(typeof(DTE)) as DTE2;

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidTransformTemplatesToolCmdSet, (int)PkgCmdIDList.cmdidTransformProjectsTemplates);
                //MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                //mcs.AddCommand( menuItem );
                CommandID menuItemID = new CommandID(GuidList.guidTransformTemplatesToolCmdSet, (int)PkgCmdIDList.cmdidTransformProjectsTemplates);
                OleMenuCommand menuItem = new OleMenuCommand(this.OnTransformSelectedExec, menuItemID);
                menuItem.BeforeQueryStatus += new EventHandler(OnTransformSelectedStatus);
                mcs.AddCommand(menuItem);
            }
        }
       #endregion

        #region Transform Selected Events

        void OnTransformSelectedStatus(object sender, EventArgs e)
        {
            MenuCommand command = sender as MenuCommand;
            if (command != null)
            {
                command.Visible = command.Enabled = this.IsSelectedProjectValable();
            }
        }
        void OnTransformSelectedExec(object sender, EventArgs e)
        {
            this.SaveAllDocumentsBeforeBuild();

            _dte.ExecuteCommand("View.Output", "");
            OutputWindowHelper outHelper = new OutputWindowHelper(_dte);
            List<ProjectItem> toProcess = new List<ProjectItem>();

            //Get items to be transformed.
            Project selectedProject = ToDteProject(GetSelectedProject(_serviceProvider));
            FindProjectItems(selectedProject, toProcess);
            outHelper.Clear();
            outHelper.AddMessage(string.Format(Resources.StartCodeGen, selectedProject.Name));
            outHelper.AddMessage(Resources.Seperator);

            uint pdwCookie = 0;
            uint count = (uint)toProcess.Count;
            IVsStatusbar service = _serviceProvider.GetService(typeof(IVsStatusbar)) as IVsStatusbar;
            if (service != null)
            {
                service.Progress(ref pdwCookie, 1, Resources.TextTemplatingStatusBarLabel, 0, count);
            }

            uint complete = 1;
            bool errorFlag = false;
            foreach (ProjectItem item in toProcess)
            {
                Application.DoEvents();
                VSProjectItem vsItem = item.Object as VSProjectItem;
                if (vsItem != null)
                {
                    errorFlag |= this.RunCustomTool(item, vsItem, GetCustomTool(item), outHelper);
                }
                if (service != null)
                {
                    service.Progress(ref pdwCookie, 1, Resources.TextTemplatingStatusBarLabel, complete, count);
                }
                complete++;
                Application.DoEvents();
            }

            outHelper.AddMessage(Resources.Seperator);
            outHelper.AddMessage(Resources.EndCodeGen);
            if (service != null)
            {
                service.Progress(ref pdwCookie, 0, string.Empty, count, count);
            }
        }

        private bool IsSelectedProjectValable()
        {
            IVsHierarchy projectHierarchy = GetSelectedProject(_serviceProvider);
            if (projectHierarchy != null)
            {
                IVsProjectStartupServices startup = GetStartUpServices(projectHierarchy);
                if ((startup != null) && StartUpServicesReferencesService(startup, typeof(STextTemplating).GUID))
                {
                    return true;
                }
            }

            return false;
        }

        public static IVsHierarchy GetSelectedProject(System.IServiceProvider serviceProvider)
        {
            IVsMonitorSelection monitorSelection = serviceProvider.GetService(typeof(SVsShellMonitorSelection)) as IVsMonitorSelection;
            IntPtr hierarchyPtr;
            uint itemid;
            IVsMultiItemSelect multiItemSelect;
            IntPtr selectionContainer;
            monitorSelection.GetCurrentSelection(out hierarchyPtr, out itemid, out multiItemSelect, out selectionContainer);

            return Marshal.GetObjectForIUnknown(hierarchyPtr) as IVsHierarchy;
        }
        public static void FindProjectItems(Project project, List<ProjectItem> toProcess)
        {
            if (((project.Kind == "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") || (project.Kind == "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}")) && (project.ProjectItems != null))
            {
                foreach (ProjectItem item in project.ProjectItems)
                {
                    FindProjectItemDependents(item, toProcess);
                }
            }
            else if ((project.Object is SolutionFolder) && (project.ProjectItems != null))
            {
                foreach (ProjectItem item2 in project.ProjectItems)
                {
                    Project project2 = item2.Object as Project;
                    if (project2 != null)
                    {
                        FindProjectItems(project2, toProcess);
                    }
                }
            }
        }
        private static void FindProjectItemDependents(ProjectItem item, List<ProjectItem> toProcess)
        {
            VSProjectItem item2 = item.Object as VSProjectItem;
            bool flag = false;
            if (item2 != null)
            {
                string customTool = GetCustomTool(item);
                if ((customTool != null) && (StringComparer.OrdinalIgnoreCase.Compare(customTool, "TextTemplatingFileGenerator") == 0))
                {
                    flag = true;
                }
            }
            if (item.ProjectItems != null)
            {
                foreach (ProjectItem item3 in item.ProjectItems)
                {
                    FindProjectItemDependents(item3, toProcess);
                }
            }
            if (flag)
            {
                toProcess.Add(item);
            }
        }
        public static string GetCustomTool(ProjectItem item)
        {
            if (item.Properties != null)
            {
                Property property = null;
                try
                {
                    property = item.Properties.Item("CustomTool");
                }
                catch (ArgumentException)
                {
                }
                if (property != null)
                {
                    string str = property.Value as string;
                    if (!string.IsNullOrEmpty(str))
                    {
                        return str;
                    }
                }
            }
            return null;
        }
        public static EnvDTE.Project ToDteProject(IVsHierarchy hierarchy)
        {
            if (hierarchy == null) return null;

            object obj2 = null;
            if (hierarchy.GetProperty(0xfffffffe, -2027, out obj2) < 0)
            {
                throw new ArgumentException("Hierarchy is not a project", "hierarchy");
            }

            return (EnvDTE.Project)obj2;
        }
        private IVsProjectStartupServices GetStartUpServices(IVsHierarchy hierarchy)
        {
            object obj;
            hierarchy.GetProperty(0xfffffffe, -2040, out obj);
            if (obj != null)
            {
                return obj as IVsProjectStartupServices;
            }

            return null;
        }
        private bool StartUpServicesReferencesService(IVsProjectStartupServices startup, Guid serviceId)
        {
            int num;
            IEnumProjectStartupServices psenum = null;
            startup.GetStartupServiceEnum(out psenum);
            uint fetched = 0;
            Guid[] result = new Guid[1];
            do
            {
                num = psenum.Next(1, result, out fetched);
                if ((fetched == 1) && (result[0].CompareTo(serviceId) == 0))
                    return true;
            }
            while (num != 1);
            return false;
        }
        private bool RunCustomTool(ProjectItem item, VSProjectItem vsItem, string customTool, OutputWindowHelper outHelper)
        {
            bool flag = true;
            bool flag2 = false;
            try
            {
                string text1 = (string)item.Properties.Item("FullPath").Value;
            }
            catch (ArgumentException)
            {
                flag = false;
                outHelper.AddMessage(string.Format(Resources.SkippingNoPath, new object[] { item.Name }));
            }
            if ((flag && (item.ProjectItems != null)) && (item.ProjectItems.Count > 0))
            {
                foreach (ProjectItem item2 in item.ProjectItems)
                {
                    string str = "";
                    try
                    {
                        str = (string)item2.Properties.Item("FullPath").Value;
                    }
                    catch (ArgumentException)
                    {
                        flag = false;
                        outHelper.AddMessage(string.Format(Resources.SkippingNoPath, new object[] { item2.Name }));
                    }
                    if ((!string.IsNullOrEmpty(str) && !_dte.SourceControl.IsItemUnderSCC(str)) && (File.Exists(str) && ((File.GetAttributes(str) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)))
                    {
                        flag = false;
                        outHelper.AddMessage(string.Format(Resources.SkippingReadOnly, new object[] { str }));
                    }
                }
            }
            if (flag)
            {
                outHelper.AddMessage(string.Format(Resources.RunLine, new object[] { customTool, item.Name }));
                try
                {
                    vsItem.RunCustomTool();
                    outHelper.Add(Resources.LineSucceeded);
                }
                catch
                {
                    outHelper.Add(Resources.LineFailed);
                    flag2 = true;
                }
            }
            return flag2;
        }
        private void SaveAllDocumentsBeforeBuild()
        {
            if ((_dte != null) && (_dte.Solution != null) && (_dte.Solution.Projects != null))
            {
                uint itemid = 0xfffffffe;
                try
                {
                    IVsSolutionBuildManager2 manager = _serviceProvider.GetService(typeof(SVsSolutionBuildManager)) as IVsSolutionBuildManager2;
                    if (manager != null)
                    {
                        manager.SaveDocumentsBeforeBuild(null, itemid, 0);
                    }
                }
                catch (COMException exception)
                {
                    if ((exception.ErrorCode != -2147467260) && (exception.ErrorCode != -2147221492))
                    {
                        throw;
                    }
                    return;
                }
            }
            System.Windows.Forms.Application.DoEvents();
        }
        #endregion

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "Transform Templates Tool",
                       string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,        // false
                       out result));
        }

    }
}

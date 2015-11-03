using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE80;
using EnvDTE;

namespace Tum.TransformTemplatesTool
{
    public class OutputWindowHelper
    {
        private DTE2 _dte;
        private OutputWindowPane _instancePane;

        public OutputWindowHelper(DTE2 dte)
        {
            _dte = dte;
            _instancePane = this.InitOutputWindowPane(_dte);
        }

        public void AddTitle(string title)
        {
            _instancePane.OutputString(string.Format("=== {0} : {1} ===", title, DateTime.Now.ToShortDateString()));
        }

        public void AddMessage(string message)
        {
            _instancePane.OutputString(string.Format("{0}\n", message));
        }

        public void Add(string message)
        {
            _instancePane.OutputString(string.Format("{0}", message));
        }

        public void Clear()
        {
            _instancePane.Clear();
        }

        private OutputWindowPane InitOutputWindowPane(DTE2 dte)
        {
            Window win = dte.Windows.Item(Constants.vsWindowKindOutput);
            OutputWindow outputWindow = (OutputWindow)win.Object;
            outputWindow.Parent.Activate();
            OutputWindowPane instancePane = this.OutputWindowPaneExist(outputWindow);
            if (instancePane == null)
            {
                instancePane = outputWindow.OutputWindowPanes.Add(Resources.OutputWindowPaneName);
            }
            instancePane.Activate();

            return instancePane;
        }

        private OutputWindowPane OutputWindowPaneExist(OutputWindow outputWindow)
        {
            foreach (OutputWindowPane pane in outputWindow.OutputWindowPanes)
            {
                if (pane.Name.Equals(Resources.OutputWindowPaneName))
                {
                    return pane;
                }
            }

            return null;
        }
    }
}

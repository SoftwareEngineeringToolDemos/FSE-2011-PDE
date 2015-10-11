using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tum.PDE.LanguageDSL.Setup.Installer
{
    [RunInstaller(true)]
    public class EnvironmentVariable : System.Configuration.Install.Installer
    {
        public const string Variable = "TumPDEDSL";

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string appPath = Context.Parameters["TARGETDIR"];
            Environment.SetEnvironmentVariable(Variable, appPath, EnvironmentVariableTarget.User);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);

            Environment.SetEnvironmentVariable(Variable, null, EnvironmentVariableTarget.User);
        }

        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);

            Environment.SetEnvironmentVariable(Variable, null, EnvironmentVariableTarget.User);
        }
    }
}

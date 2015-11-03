using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Setup.VSPluginDesignerWizard
{
    public class VsPackageInfo
    {
        public readonly string Class;
        public readonly string DefaultName;

        public string EditorDisplayName
        {
            get
            {
                if (Class == null)
                    return DefaultName;
                return Class;
            }
        }

        public VsPackageInfo(Microsoft.Win32.RegistryKey packageKey)
        {
            DefaultName = packageKey.GetValue(System.String.Empty) as string;
            Class = packageKey.GetValue("Class") as string;
        }
    }
}

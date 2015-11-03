using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL.Setup.VSPluginDesignerWizard
{
    public class PDERegistry
    {
        private static Microsoft.Win32.RegistryKey VsExpHive
        {
            get
            {
                return Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\VisualStudio\\10.0Exp_Config");
            }
        }
        private static Microsoft.Win32.RegistryKey VsMainHive
        {
            get
            {
                return Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\VisualStudio\\10.0_Config");
            }
        }

        /// <summary>
        /// Source: DSL Tools
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        internal static List<string> GetNonVsApplications(string extension)
        {
            List<string> list = new List<string>();
            using (Microsoft.Win32.RegistryKey registryKey1 = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + extension))
            {
                if (registryKey1 == null)
                {
                    return list;
                }
                string s1 = registryKey1.GetValue(null, String.Empty) as string;
                if (!String.IsNullOrEmpty(s1) && !s1.StartsWith("VisualStudio", StringComparison.OrdinalIgnoreCase))
                {
                    using (Microsoft.Win32.RegistryKey registryKey2 = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(s1))
                    {
                        if (registryKey2 != null)
                        {
                            string s2 = registryKey2.GetValue(null, System.String.Empty) as string;
                            if (!System.String.IsNullOrEmpty(s2))
                            {
                                list.Add(s2);
                                return list;
                            }
                        }
                    }
                    list.Add(s1);
                    return list;
                }
                using (Microsoft.Win32.RegistryKey registryKey3 = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("." + extension + "\\OpenWithList"))
                {
                    if (registryKey3 == null)
                    {
                        return list;
                    }
                    string[] sArr = registryKey3.GetValueNames();
                    for (int i = 0; i < sArr.Length; i++)
                    {
                        string s3 = sArr[i];
                        if (s3.Length == 1)
                        {
                            string s4 = registryKey3.GetValue(s3) as string;
                            if (!System.String.IsNullOrEmpty(s4) && (System.StringComparer.OrdinalIgnoreCase.Compare(s4, "devenv") != 0) && (System.StringComparer.OrdinalIgnoreCase.Compare(s4, "devenv.exe") != 0) && !list.Contains(s4))
                                list.Add(s4);
                        }
                    }
                }
            }
            return list;
        }

        internal static List<VsPackageInfo> GetVsPackages(string extension)
        {
            Helper registry = new Helper();
            registry.extension = extension;
            registry.editors = new Dictionary<string, VsPackageInfo>();

            LoadExtensions(registry);

            return new List<VsPackageInfo>(registry.editors.Values);
        }

        private sealed class Helper
        {

            public Dictionary<string, VsPackageInfo> editors;
            public string extension;

            public Helper()
            {
            }

            public void GetVsPackages(Microsoft.Win32.RegistryKey hiveRoot, Microsoft.Win32.RegistryKey editorKey, string editorExt)
            {
                if ((extension == null) || (System.StringComparer.OrdinalIgnoreCase.Compare(editorExt, extension) == 0))
                {
                    string s = editorKey.GetValue("Package") as string;
                    if (!System.String.IsNullOrEmpty(s))
                    {
                        using (Microsoft.Win32.RegistryKey registryKey = hiveRoot.OpenSubKey("Packages\\" + s))
                        {
                            if ((registryKey != null) && !editors.ContainsKey(registryKey.Name))
                                editors.Add(registryKey.Name, new VsPackageInfo(registryKey));
                        }
                    }
                }
            }

        }

        private static void LoadExtensions(Helper registry)
        {
            LoadExtensions(VsMainHive, registry);
            LoadExtensions(VsExpHive, registry);
        }
        private static void LoadExtensions(Microsoft.Win32.RegistryKey hiveRoot, Helper registry)
        {
            if (hiveRoot == null)
                return;

            using (Microsoft.Win32.RegistryKey registryKey = hiveRoot.OpenSubKey("Editors"))
            {
                if (registryKey == null)
                    return;

                string[] sArr = registryKey.GetSubKeyNames();
                foreach (string keyName in sArr)
                {
                    using (Microsoft.Win32.RegistryKey registrySubKey = registryKey.OpenSubKey(keyName))
                    {
                        if (registrySubKey == null)
                            continue;

                        using (Microsoft.Win32.RegistryKey registryKeyExtensions = registrySubKey.OpenSubKey("Extensions"))
                        {
                            if (registryKeyExtensions == null)
                                continue;
                            string[] sArrExt = registryKeyExtensions.GetValueNames();
                            foreach (string n in sArrExt)
                            {
                                char[] chArr = new char[] { '.', ' ' };
                                string result = n.Trim(chArr).ToUpperInvariant();

                                registry.GetVsPackages(hiveRoot, registrySubKey, result);


                            }
                        }
                    }
                }
            }
        }
    }
}

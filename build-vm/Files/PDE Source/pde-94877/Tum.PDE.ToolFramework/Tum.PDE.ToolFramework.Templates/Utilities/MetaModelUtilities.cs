using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static string GetMainPropertyGridViewModelFullName(MetaModel dm)
        {
            string fullName = dm.Namespace + ".ViewModel.";
            fullName += dm.Name + "PropertyGridViewModel";
            return fullName;
        }

        public static string GetServiceRegistrarFullName(MetaModel dm)
        {
            string fullName = dm.Namespace + ".ViewModel.";
            fullName += dm.Name + "ServiceRegistrar";
            return fullName;
        }

        public static string GetModelContextFullName(LibraryModelContext m)
        {
            return m.MetaModel.Namespace + "." + m.Name + "ModelContext";
        }
    }
}

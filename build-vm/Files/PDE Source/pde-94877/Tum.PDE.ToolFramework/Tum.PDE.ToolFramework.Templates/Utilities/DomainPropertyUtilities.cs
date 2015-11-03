using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static bool HasEditor(DomainProperty p )
        {
            if (p.Type == null)
                return false;

            if (p.Type.PropertyGridEditor == null)
                return false;

            return true;
        }

        public static string GetEditorTypeName(DomainProperty p)
        {
            string n = p.Type.PropertyGridEditor.Namespace;
            n += "." + p.Type.PropertyGridEditor.Name;

            return n;
        }

        /*
        public static string GetPropertyConstructorName(DomainProperty p)
        {
            // TODO..
        }*/
    }
}

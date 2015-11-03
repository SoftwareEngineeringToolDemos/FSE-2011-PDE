using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public abstract partial class DomainType
    {
        /// <summary>
        /// Returns the full name of this element.
        /// </summary>
        public string FullName
        {
            get { return this.Namespace + "." + this.Name; }
        }

        /// <summary>
        /// Returns the name of this element relative to the current namespace.
        /// </summary>
        /// <param name="currentNamespace"></param>
        /// <param name="includeGlobal"></param>
        /// <returns></returns>
        public string GetRelativeName(string currentNamespace, bool includeGlobal)
        {
            if (System.String.IsNullOrEmpty(Namespace) || (!System.String.IsNullOrEmpty(currentNamespace) && (System.StringComparer.Ordinal.Compare(currentNamespace, Namespace) == 0)))
                return Name;
            return GetFullName(includeGlobal);
        }

        /// <summary>
        /// Returns the full name of this element.
        /// </summary>
        /// <param name="includeGlobal">If true, 'global:' is added in front of the name.</param>
        public string GetFullName(bool includeGlobal)
        {
            return ConstructFullName(Namespace, Name, includeGlobal);
        }

        /// <summary>
        /// Creates the name of an element based on the current namespace and the class name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="className"></param>
        /// <param name="includeGlobal"></param>
        /// <returns></returns>
        internal static string ConstructFullName(string namespaceName, string className, bool includeGlobal)
        {
            if (className == null)
                return System.String.Empty;
            string s = System.String.Empty;
            if (includeGlobal)
                s = "global::";
            if (System.String.IsNullOrEmpty(namespaceName))
            {
                object[] objArr1 = new object[] {
                                                  s, 
                                                  className };
                return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}{1}", objArr1);
            }
            object[] objArr2 = new object[] {
                                              s, 
                                              namespaceName, 
                                              className };
            return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}{1}.{2}", objArr2);
        }
    }
}

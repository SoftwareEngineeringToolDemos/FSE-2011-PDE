using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.LanguageDSL
{
    public partial class MetaModel
    {
        private bool isTopMost = false;
        private string filePath = "";

        /// <summary>
        /// Gets all domain classes within this meta model (excluding the imported meta models).
        /// </summary>
        public ReadOnlyCollection<DomainClass> AllClasses
        {
            get
            {
                List<DomainClass> classes = new List<DomainClass>();
                foreach (BaseModelContext m in this.ModelContexts)
                    if( m is LibraryModelContext)
                        classes.AddRange((m as LibraryModelContext).Classes);

                return classes.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all domain relationships within this meta model (excluding the imported meta models).
        /// </summary>
        public ReadOnlyCollection<DomainRelationship> AllRelationships
        {
            get
            {
                List<DomainRelationship> classes = new List<DomainRelationship>();
                foreach (BaseModelContext m in this.ModelContexts)
                    if (m is LibraryModelContext)
                        classes.AddRange((m as LibraryModelContext).Relationships);

                return classes.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all domain relationships within this meta model (excluding the imported meta models).
        /// </summary>
        public ReadOnlyCollection<DiagramClass> AllDiagramClasses
        {
            get
            {
                List<DiagramClass> classes = new List<DiagramClass>();
                foreach (BaseModelContext m in this.ModelContexts)
                    if (m is LibraryModelContext)
                        classes.AddRange((m as LibraryModelContext).DiagramClasses);

                return classes.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets all domain relationships within this meta model (excluding the imported meta models).
        /// </summary>
        public ReadOnlyCollection<AttributedDomainElement> AllElements
        {
            get
            {
                List<AttributedDomainElement> all = new List<AttributedDomainElement>();
                all.AddRange(AllClasses);
                all.AddRange(AllRelationships);

                return all.AsReadOnly();
            }
        }

        /// <summary>
        /// The base directory of the top-most library.
        /// </summary>
        public static string BaseGlobalDirectory = string.Empty;

        /// <summary>
        /// The base directory of the library.
        /// </summary>
        public string BaseDirectory { get; set; }

        /// <summary>
        /// The file path of the library.
        /// </summary>
        public string FilePath 
        {
            get
            {
                return this.filePath;
            }
            set
            {
                string s = MetaModelLibraryBase.GetNormalizedFilePath(BaseDirectory, value);
                this.filePath = s;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTopMost
        {
            get
            {
                return this.isTopMost;
            }
            set
            {
                this.isTopMost = value;
            }
        }
        
        /// <summary>
        /// Name for the domain model resx file.
        /// </summary>
        public string GeneratedResourceName
        {
            get { return "GeneratedCode.DomainModelResx"; }
        }

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

        public bool HasElement(string name)
        {
            ModelElement m = GetElementByName(name);
            if (m != null)
                return true;

            return false;
        }
        public ModelElement GetElementByName(string name)
        {
            ReadOnlyCollection<ModelElement> classes = this.Store.ElementDirectory.FindElements(DomainClass.DomainClassId);
            for (int i = 0; i < classes.Count; i++)
                if (((DomainClass)classes[i]).Name == name)
                    return classes[i];

            return null;
        }
    }
}

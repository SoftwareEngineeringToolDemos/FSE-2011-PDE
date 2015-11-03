using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class AttributedDomainElement
    {
        /// <summary>
        /// Gets the domain model embedding this element.
        /// </summary>
        public MetaModel GetMetaModel()
        {
            if (this is DomainClass)
                return (this as DomainClass).ParentModelContext.MetaModel;
            else if (this is DomainRelationship)
                return (this as DomainRelationship).ParentModelContext.MetaModel;
            else if (this is PresentationElementClass)
                return (this as PresentationElementClass).DiagramClass.ModelContext.MetaModel;
            else
                return null;
        }

        /// <summary>
        /// Gets the domain model embedding this element.
        /// </summary>
        public LibraryModelContext ParentModelContext
        {
            get
            {
                if (this is DomainClass)
                    return (this as DomainClass).ModelContext;
                else if (this is DomainRelationship)
                    return (this as DomainRelationship).ModelContext;
                else if (this is PresentationElementClass)
                    return (this as PresentationElementClass).DiagramClass.ModelContext;
                else
                    return null;
            }
        }


        /// <summary>
        /// Gets the base element this element is derived from. If there is none, null is returned.
        /// </summary>
        public AttributedDomainElement BaseElement
        {
            get
            {
                if (this is DomainClass)
                    return (this as DomainClass).BaseClass;
                else if (this is DomainRelationship)
                    return (this as DomainRelationship).BaseRelationship;
                else
                    return null;
            }
        }

        public List<AttributedDomainElement> DerivedElements
        {
            get
            {
                List<AttributedDomainElement> retList = null;
                if (this is DomainClass)
                {
                    if ((this as DomainClass).DerivedClasses != null)
                    {
                        retList = new List<AttributedDomainElement>();
                        foreach (DomainClass d in (this as DomainClass).DerivedClasses)
                            retList.Add(d);
                    }
                }
                else if (this is DomainRelationship)
                {
                    if ((this as DomainRelationship).DerivedRelationships != null)
                    {
                        retList = new List<AttributedDomainElement>();
                        foreach (DomainRelationship d in (this as DomainRelationship).DerivedRelationships)
                            retList.Add(d);
                    }
                }

                return retList;
            }
        }

        /// <summary>
        /// Returns the base class. Is called withing t4 templates.
        /// </summary>
        /// <param name="originatingClass"></param>
        /// <returns></returns>
        public AttributedDomainElement GetBaseClassSafely(AttributedDomainElement originatingClass)
        {
            if (System.Object.Equals(this.BaseElement, originatingClass))
                return null;
            return this.BaseElement;
        }

        /// <summary>
        /// Gets whether this element is a reference relationship instance or not.
        /// </summary>
        public bool IsReferenceRelationship
        {
            get { return this is ReferenceRelationship; }
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
    }
}

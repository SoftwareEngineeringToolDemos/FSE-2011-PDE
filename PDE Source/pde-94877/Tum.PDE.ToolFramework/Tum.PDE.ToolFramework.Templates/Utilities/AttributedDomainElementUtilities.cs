using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    public static partial class CodeGenerationUtilities
    {
        public static string GetPropertyGridViewModelFullName(AttributedDomainElement domainClass)
        {
            string fullName = domainClass.GetMetaModel().Namespace;
            fullName = fullName + ".ViewModel.PropertyGrid.PropertyGrid" + domainClass.Name + "ViewModel";
            return fullName;
        }
        public static string GetDependencyItemsProviderFullName(AttributedDomainElement domainClass)
        {
            string fullName = domainClass.GetMetaModel().Namespace;
            fullName = fullName + "." + domainClass.Name + "DependencyItemsProvider";
            return fullName;
        }
        public static string GetSerializerBaseName(AttributedDomainElement domainClass)
        {
            if (domainClass.BaseElement != null)
            {
                string fullName = domainClass.BaseElement.GetMetaModel().Namespace;
                fullName = fullName + "." + domainClass.BaseElement.GetMetaModel().Name + domainClass.BaseElement.Name + "Serializer";
                return fullName;
            }
            else
            {
                if( domainClass is DomainClass )
                    return "DslEditorModeling::SerializationDomainClassXmlSerializer";
                else
                    return "DslEditorModeling::SerializationDomainRelationshipXmlSerializer";
            }
        }
        public static string GetModelTreeViewModelFullName(AttributedDomainElement domainClass)
        {
            string fullName = domainClass.GetMetaModel().Namespace;
            fullName = fullName + ".ViewModel.ModelTree.ModelTree" + domainClass.Name + "ViewModel";
            return fullName;
        }

        public static bool HasProperty(AttributedDomainElement domainClass, string name)
        {
            if (domainClass == null)
                return false;

            AttributedDomainElement d = domainClass;
            while (d != null)
            {
                foreach (DomainProperty p in d.Properties)
                    if (p.Name == name)
                        return true;

                d = d.BaseElement;
            }

            return false;
        }
        public static bool HasProperty(AttributedDomainElement domainClass, string name, SerializationRepresentationType rep)
        {
            if (domainClass == null)
                return false;

            AttributedDomainElement d = domainClass;
            while (d != null)
            {
                foreach (DomainProperty p in d.Properties)
                    if (p.Name == name)
                    {
                        if (p.SerializationRepresentationType == rep)
                            return true;
                        else
                            return false;
                    }

                d = d.BaseElement;
            }

            return false;
        }
        
        
        public static bool HasRelationship(AttributedDomainElement domainClass, string name)
        {
            if (domainClass == null)
                return false;

            AttributedDomainElement d = domainClass;
            while (d != null)
            {
                foreach (DomainRole r in d.RolesPlayed)
                    if( r == r.Relationship.Source && r.Relationship.Source.RolePlayer.InheritanceModifier != InheritanceModifier.Abstract)
                        if( r.Relationship.Name == name )
                            return true;

                d = d.BaseElement;
            }

            return false;
        }
    }
}

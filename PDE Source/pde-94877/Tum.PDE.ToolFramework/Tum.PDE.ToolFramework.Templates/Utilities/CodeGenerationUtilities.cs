using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    /// <summary>
    /// The methods of this class are used as helper methods within the t4 templates for code generation.
    /// 
    /// Large potion of this class is based on the DSL-Tools CodeGenerationUtilities class.
    /// </summary>
    public static partial class CodeGenerationUtilities
    {
        public static List<DomainClass> GetAllDerivedClassesWithSelf(DomainClass d)
        {
            List<DomainClass> ret = new List<DomainClass>();
            ret.Add(d);
            ret.AddRange(d.AllDerivedClasses);
            
            return ret;
        }

        public static List<DomainRelationship> GetAllDerivedRSWithSelf(DomainRelationship d)
        {
            List<DomainRelationship> ret = new List<DomainRelationship>();
            ret.Add(d);

            foreach (DomainRelationship der in d.DerivedRelationships)
            {
                ret.AddRange(GetAllDerivedRSWithSelf(der));
            }
            return ret;
        }

        /// <summary>
        /// Returns the access modifier as a string.
        /// </summary>
        public static string GetAccessModifier(AccessModifier modifier)
        {
            switch (modifier)
            {
                case AccessModifier.Public:
                    return "public";

                case AccessModifier.Assembly:
                    return "internal";

                case AccessModifier.Private:
                    return "private";

                case AccessModifier.Family:
                    return "protected";

                case AccessModifier.FamilyOrAssembly:
                    return "protected internal";
            }

            throw new NotSupportedException("modifier");
        }
        public static string GetGeneratedLinkAccessModifier(DomainRelationship domainRelationship)
        {
            if (domainRelationship == null)
                throw new System.ArgumentNullException("domainRelationship");

            if (domainRelationship != null)
            {
                if ((domainRelationship.AccessModifier != AccessModifier.Assembly) && (domainRelationship.Source.RolePlayer.AccessModifier != AccessModifier.Assembly) && (domainRelationship.Target.RolePlayer.AccessModifier != AccessModifier.Assembly))
                    return GetAccessModifier(AccessModifier.Public);
                return GetAccessModifier(AccessModifier.Assembly);
            }
            return GetAccessModifier(AccessModifier.Public);
        }
        public static string GetGeneratedPropertyGetterAccessModifier(DomainRole role)
        {
            if (role == null)
                throw new System.ArgumentNullException("role");
            return GetGeneratedPropertySetter(role, role.PropertyGetterAccessModifier);
        }
        public static string GetGeneratedPropertySetterAccessModifier(DomainRole role)
        {
            if (role == null)
                throw new System.ArgumentNullException("role");
            return GetGeneratedPropertySetter(role, role.PropertySetterAccessModifier);
        }
        private static string GetGeneratedPropertySetter(DomainRole role, AccessModifier modifier)
        {
            if ((modifier == AccessModifier.Public) && ((role.RolePlayer.AccessModifier == AccessModifier.Assembly) || (role.Opposite.RolePlayer.AccessModifier == AccessModifier.Assembly)))
                modifier = AccessModifier.Assembly;
            return GetAccessModifier(modifier);
        }

        public static string GetPropertyKind(PropertyKind propertyKind)
        {
            switch (propertyKind)
            {
                case PropertyKind.Normal:
                    return "";

                case PropertyKind.Calculated:
                    return "Kind = DslModeling::DomainPropertyKind.Calculated";

                case PropertyKind.CustomStorage:
                    return "Kind = DslModeling::DomainPropertyKind.CustomStorage";
            }
            return "";
        }

        /// <summary>
        /// Returns the class name for a given DomainClass. If the GeneratesDoubleDerived 
        /// property is set to true, then "Base" is appended to the class name.
        /// </summary>
        public static string GetGenerationClassName(GeneratedDomainElement domainClass)
        {
            if (domainClass.GeneratesDoubleDerived)
                return domainClass.Name + "Base";
            return domainClass.Name;
        }

        /// <summary>
        /// Returns the property handler for the given domain property.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyHandlerName(DomainProperty property)
        {
            return property.Name + "PropertyHandler";
        }

        /// <summary>
        /// Return the base class name for the given domainclass as a string
        /// </summary>
        public static string GetBaseClass(DomainClass domainClass, string defaultBaseClass)
        {
            if (domainClass == null)
                throw new System.ArgumentNullException("domainClass");

            if (domainClass.BaseClass == null)
                return defaultBaseClass;

            return domainClass.BaseClass.GetFullName(true);
        }

        /// <summary>
        /// Return the base class name for the given relationship as a string
        /// </summary>
        public static string GetBaseRelationship(DomainRelationship relationship, string defaultBaseClass)
        {
            if (relationship == null)
                throw new System.ArgumentNullException("relationship");

            if (relationship.BaseRelationship != null)
                return relationship.BaseRelationship.Name;
            else
                return defaultBaseClass;
        }

        public static DomainRole GetBaseRole(DomainRole role)
        {
            DomainRelationship domainRelationship1 = role.Relationship;
            DomainRelationship domainRelationship2 = domainRelationship1.BaseRelationship;
            if (domainRelationship2 != null)
            {
                if (role != domainRelationship1.Source)
                    return domainRelationship2.Target;
                return domainRelationship2.Source;
            }
            return null;
        }

        /// <summary>
        /// Calculates the inheritance depth based on the given domain class.
        /// </summary>
        /// <param name="domainClass"></param>
        /// <returns></returns>
        public static int CalculateInheritanceDepth(AttributedDomainElement domainClass)
        {
            if (domainClass == null)
                throw new System.ArgumentNullException("domainClass");
            int i = 0;
            for (AttributedDomainElement domainClass1 = domainClass; domainClass1 != null; domainClass1 = domainClass1.BaseElement)
            {
                if (domainClass1.GeneratesDoubleDerived)
                    i += 2;
                else
                    i++;
            }
            return i;
        }

        /// <summary>
        /// Return the inheritance modifier as a string. If the given class has 
        /// GeneratesDoubleDerived set to true, then "abstract" is returned.
        /// </summary>
        public static string GetGenerationInheritanceModifier(GeneratedDomainElement domainClass)
        {
            if (domainClass.GeneratesDoubleDerived)
                return CodeGenerationUtilities.GetInheritanceModifier(InheritanceModifier.Abstract);

            return CodeGenerationUtilities.GetInheritanceModifier(domainClass.InheritanceModifier);
        }

        /// <summary>
        /// Return the inheritance modifier as a string
        /// </summary>
        public static string GetInheritanceModifier(InheritanceModifier modifier)
        {
            switch (modifier)
            {
                case InheritanceModifier.Abstract:
                    return " abstract";

                case InheritanceModifier.Sealed:
                    return " sealed";
            }
            return "";
        }

        /// <summary>
        /// Returns the given input with the first char beeing set to lower case.
        /// </summary>
        public static string GetCamelCase(string input)
        {
            if (System.String.IsNullOrEmpty(input))
                return System.String.Empty;

            char[] chArr = input.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (chArr[i] != '@')
                {
                    chArr[i] = System.Char.ToLower(chArr[i], System.Globalization.CultureInfo.InvariantCulture);
                    break;
                }
            }
            return new System.String(chArr);
        }

        /// <summary>
        /// Returns the default value for the given domain property as string.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyDefaultValue(DomainProperty property)
        {
            double d;
            if (property == null)
                throw new System.ArgumentNullException("property");

            string s1 = property.Type.GetFullName(false);
            if (System.String.IsNullOrEmpty(property.DefaultValue))
            {
                if (IsStringType(s1))
                    return "null";
                return System.String.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            if ((property.Type is DomainEnumeration))
            {
                string s2 = GetDomainTypeFullName(property, true);
                bool flag = true;
                char[] chArr = new char[] { '|' };
                string[] sArr = property.DefaultValue.Split(chArr);
                for (int i = 0; i < sArr.Length; i++)
                {
                    string s3 = sArr[i];
                    if (flag)
                        flag = false;
                    else
                        stringBuilder.Append('|');
                    stringBuilder.Append(s2);
                    stringBuilder.Append('.');
                    string s4 = s3.Trim();
                    stringBuilder.Append(s4);
                }
            }
            else if ((property.Type is ExternalType))
            {
                if (CodeGenerationUtilities.IsStringType(s1))
                {
                    stringBuilder.Append(CodeGenerationUtilities.WrapAsCSharpString(property.DefaultValue));
                }
                else if (CodeGenerationUtilities.IsBooleanType(s1))
                {
                    if (System.StringComparer.OrdinalIgnoreCase.Equals(property.DefaultValue, "false"))
                        return System.String.Empty;
                    stringBuilder.Append(property.DefaultValue);
                }
                else if (CodeGenerationUtilities.IsDecimalNumberType(s1) && TryParseDouble(property.DefaultValue, out d) && (d != 0.0))
                {
                    if (Double.IsNegativeInfinity(d))
                    {
                        stringBuilder.Append("double.NegativeInfinity");
                    }
                    else if (Double.IsPositiveInfinity(d))
                    {
                        stringBuilder.Append("double.PositiveInfinity");
                    }
                    else if (Double.IsNaN(d))
                    {
                        stringBuilder.Append("double.NaN");
                    }
                    else
                    {
                        stringBuilder.Append(d.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        stringBuilder.Append(CodeGenerationUtilities.GetNumberTypeSuffix(s1));
                        return stringBuilder.ToString();
                    }
                }
                else if (CodeGenerationUtilities.IsCharType(s1))
                {
                    stringBuilder.Append("'");
                    stringBuilder.Append(property.DefaultValue);
                    stringBuilder.Append("'");
                }
                else if (CodeGenerationUtilities.IsGuidType(s1))
                {
                    stringBuilder.Append("new global::System.Guid(\"");
                    stringBuilder.Append(property.DefaultValue);
                    stringBuilder.Append("\")");
                }
                else if (CodeGenerationUtilities.IsDateTimeType(s1))
                {
                    stringBuilder.Append("global::System.DateTime.Parse(\"");
                    stringBuilder.Append(property.DefaultValue);
                    stringBuilder.Append("\", global::System.Globalization.CultureInfo.InvariantCulture)");
                }
                else
                {
                    stringBuilder.Append(CodeGenerationUtilities.WrapAsCSharpString(property.DefaultValue));
                }
            }
            else
            {
                stringBuilder.Append(CodeGenerationUtilities.WrapAsCSharpString(property.DefaultValue));
            }
            return stringBuilder.ToString();

        }

        /// <summary>
        /// Returns the default value for the given domain property as string.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyDefaultValue(DomainProperty property, out bool needsDeserialization)
        {
            double d;
            if (property == null)
                throw new System.ArgumentNullException("property");

            needsDeserialization = false;

            string s1 = property.Type.GetFullName(false);
            if (System.String.IsNullOrEmpty(property.DefaultValue))
            {
                if (IsStringType(s1))
                    return "null";
                return System.String.Empty;
            }

            StringBuilder stringBuilder = new StringBuilder();
            if ((property.Type is DomainEnumeration))
            {
                string s2 = GetDomainTypeFullName(property, true);
                bool flag = true;
                char[] chArr = new char[] { '|' };
                string[] sArr = property.DefaultValue.Split(chArr);
                for (int i = 0; i < sArr.Length; i++)
                {
                    string s3 = sArr[i];
                    if (flag)
                        flag = false;
                    else
                        stringBuilder.Append('|');
                    stringBuilder.Append(s2);
                    stringBuilder.Append('.');
                    string s4 = s3.Trim();
                    stringBuilder.Append(s4);
                }
            }
            else if ((property.Type is ExternalType))
            {
                if (CodeGenerationUtilities.IsStringType(s1))
                {
                    stringBuilder.Append(CodeGenerationUtilities.WrapAsCSharpString(property.DefaultValue));
                }
                else if (CodeGenerationUtilities.IsBooleanType(s1))
                {
                    if (System.StringComparer.OrdinalIgnoreCase.Equals(property.DefaultValue, "false"))
                        return System.String.Empty;
                    stringBuilder.Append(property.DefaultValue);
                }
                else if (CodeGenerationUtilities.IsDecimalNumberType(s1) && TryParseDouble(property.DefaultValue, out d) && (d != 0.0))
                {
                    if (Double.IsNegativeInfinity(d))
                    {
                        stringBuilder.Append("double.NegativeInfinity");
                    }
                    else if (Double.IsPositiveInfinity(d))
                    {
                        stringBuilder.Append("double.PositiveInfinity");
                    }
                    else if (Double.IsNaN(d))
                    {
                        stringBuilder.Append("double.NaN");
                    }
                    else
                    {
                        stringBuilder.Append(d.ToString(System.Globalization.CultureInfo.InvariantCulture));
                        stringBuilder.Append(CodeGenerationUtilities.GetNumberTypeSuffix(s1));
                        return stringBuilder.ToString();
                    }
                }
                else if (CodeGenerationUtilities.IsCharType(s1))
                {
                    stringBuilder.Append("'");
                    stringBuilder.Append(property.DefaultValue);
                    stringBuilder.Append("'");
                }
                else if (CodeGenerationUtilities.IsGuidType(s1))
                {
                    stringBuilder.Append("new global::System.Guid(\"");
                    stringBuilder.Append(property.DefaultValue);
                    stringBuilder.Append("\")");
                }
                else if (CodeGenerationUtilities.IsDateTimeType(s1))
                {
                    stringBuilder.Append("global::System.DateTime.Parse(\"");
                    stringBuilder.Append(property.DefaultValue);
                    stringBuilder.Append("\", global::System.Globalization.CultureInfo.InvariantCulture)");
                }
                else
                {
                    needsDeserialization = true;
                    stringBuilder.Append(CodeGenerationUtilities.WrapAsCSharpString(property.DefaultValue));
                }
            }
            else
            {
                needsDeserialization = true;
                stringBuilder.Append(CodeGenerationUtilities.WrapAsCSharpString(property.DefaultValue));
            }
            return stringBuilder.ToString();

        }


        public static string GetPropertyDefaultValueAttribute(DomainProperty property)
        {
            if (property == null)
                throw new System.ArgumentNullException("property");
            string s1 = property.DefaultValue;
            if (s1 == null)
                return null;

            string s2 = property.Type.GetFullName(false);
            if (s1.Length == 0)
            {
                if (IsStringType(s2))
                    return "\"\"";
                return System.String.Empty;
            }

            if (IsStringType(s2) || IsBooleanType(s2) || IsDecimalNumberType(s2) || (property.Type is DomainEnumeration))
            {
                return CodeGenerationUtilities.GetPropertyDefaultValue(property);
            }
            return "typeof(" + property.Type.GetFullName(true) + "), " + CodeGenerationUtilities.WrapAsCSharpString(s1);
        }
        public static bool IsStringType(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.String"))
                return System.StringComparer.Ordinal.Equals(typeName, "string");
            return true;
        }

        /// <summary>
        /// Returns the type for the given property
        /// </summary>
        public static string GetDomainTypeFullName(DomainType type, string currentNamespace)
        {
            return GetDomainTypeFullName(type, currentNamespace, false);
        }

        public static string GetDomainTypeFullName(DomainType type, string currentNamespace, bool bForceSafeName)
        {
            if (type == null)
                throw new System.ArgumentNullException("type");
            string s = type.Name;

            if (!bForceSafeName)
            {
                if (type is DomainEnumeration)
                    s += "?";
            }
            else
            {
                if (type is DomainEnumeration)
                    if (s.Length > 0 )
                        if (s.Substring(s.Length-1, 1) == "?")
                            s = s.Substring(0, s.Length-1);
            }               

            if (System.String.IsNullOrEmpty(type.Namespace))
            {
                object[] objArr1 = new object[] { s };
                return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "global::{0}", objArr1);
            }
            //if (System.String.Compare(currentNamespace, type.Namespace, System.StringComparison.Ordinal) == 0)
            //    return s;
            object[] objArr2 = new object[] {
                                              type.Namespace, 
                                              s };
            return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "global::{0}.{1}", objArr2);
        }
        public static string GetDomainTypeFullName(DomainProperty property, bool bForceSafeName)
        {
            if (property == null)
                throw new System.ArgumentNullException("property");

            return GetDomainTypeFullName(property.Type, property.Element.Namespace, bForceSafeName);
        }
        public static string GetDomainTypeFullName(DomainProperty property)
        {
            if (property == null)
                throw new System.ArgumentNullException("property");
            return GetDomainTypeFullName(property.Type, property.Element.Namespace);
        }

        public static string GetBasePropertyHandlerName(DomainProperty property)
        {
            object[] objArr1 = new object[] {     GetGenerationClassName(property.Element), 
                                                  GetDomainTypeFullName(property) };
            return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "DslModeling::DomainPropertyValueHandler<{0}, {1}>", objArr1);
        }

        public static DomainRole GetTypeRole(DomainRole role)
        {
            return role;
        }
        public static DomainRole GetSameNameBaseRole(DomainRole role)
        {
            return null;
        }

        public static void AddSerializationResourceStrings(System.Collections.Generic.Dictionary<string, System.Collections.Generic.KeyValuePair<string, string>> resourcedStrings)
        {
            if (resourcedStrings == null)
                throw new System.ArgumentNullException("resourcedStrings");
            resourcedStrings.Add("AmbiguousSchema", new System.Collections.Generic.KeyValuePair<string, string>("More than one schema found for target namespace '{0}', use the first one at '{1}'.", "Serialization Warning: AmbiguousSchema"));
            resourcedStrings.Add("ExpectingFullFormRelationship", new System.Collections.Generic.KeyValuePair<string, string>("Element '{0}' is treated as the target role-player of a relationship '{1}' instance, which should be serialized in full-form.", "Serialization Warning: ExpectingFullFormRelationship"));
            resourcedStrings.Add("ExpectingShortFormRelationship", new System.Collections.Generic.KeyValuePair<string, string>("Instances of relationship '{0}' should be serialized in short-form.", "Serialization Warning: ExpectingShortFormRelationship"));
            resourcedStrings.Add("IgnoredPropertyValue", new System.Collections.Generic.KeyValuePair<string, string>("Invalid property value '{0}' for property '{1}' with type '{2}', ignored.", "Serialization Warning: IgnoredPropertyValue"));
            resourcedStrings.Add("MissingId", new System.Collections.Generic.KeyValuePair<string, string>("Missing 'Id' attribute, a new Guid '{0}' is auto-generated.", "Serialization Warning: MissingId"));
            resourcedStrings.Add("MonikerResolvedToDuplicateLink", new System.Collections.Generic.KeyValuePair<string, string>("Resolving moniker '{0}' causes a duplicate link to be created, so the link and the moniker are ignored.", "Serialization Warning: MonikerResolvedToDuplicateLink"));
            resourcedStrings.Add("NoSchema", new System.Collections.Generic.KeyValuePair<string, string>("Cannot find a schema that defines target namespace '{0}', schema validation skipped.", "Serialization Warning: NoSchema"));
            resourcedStrings.Add("UnexpectedXmlElement", new System.Collections.Generic.KeyValuePair<string, string>("Unexpected XML element '{0}', ignored.", "Serialization Warning: UnexpectedXmlElement"));
            resourcedStrings.Add("AmbiguousMoniker", new System.Collections.Generic.KeyValuePair<string, string>("Ambiguous moniker '{0}' encountered. It is used for both '{1}' and '{2}'.", "Serialization Error: AmbiguousMoniker"));
            resourcedStrings.Add("CannotMonikerizeElement", new System.Collections.Generic.KeyValuePair<string, string>("Instances of DomainClass '{0}' cannot be serialized as a moniker.\r\nA DomainClass can be serialized as a moniker only if \r\n1) it has a defined/inherited DomainProperty marked as IsMonikerKey=true, or \r\n2) it is marked/inherited with SerializeId=true.", "Serialization Error: CannotMonikerizeElement"));
            resourcedStrings.Add("CannotOpenDocument", new System.Collections.Generic.KeyValuePair<string, string>("Error encountered, check Error List window for details.", "Serialization Error: CannotOpenDocument"));
            resourcedStrings.Add("CannotSaveDocument", new System.Collections.Generic.KeyValuePair<string, string>("Error encountered, check Error List window for details.", "Serialization Error: CannotSaveDocument"));
            resourcedStrings.Add("DanglingRelationship", new System.Collections.Generic.KeyValuePair<string, string>("Relationship '{0}' instance is missing target role-player.", "Serialization Error: DanglingRelationship"));
            resourcedStrings.Add("InvalidPropertyValue", new System.Collections.Generic.KeyValuePair<string, string>("Invalid property value '{0}' for property '{1}' with type '{2}'.", "Serialization Error: InvalidPropertyValue"));
            resourcedStrings.Add("MissingMoniker", new System.Collections.Generic.KeyValuePair<string, string>("Missing moniker. A moniker is expected in attribute '{0}'.", "Serialization Error: MissingMoniker"));
            resourcedStrings.Add("MissingTransaction", new System.Collections.Generic.KeyValuePair<string, string>("This must be called within the context of an active transaction.", "Serialization Error: MissingTransaction"));
            resourcedStrings.Add("UnresolvedMoniker", new System.Collections.Generic.KeyValuePair<string, string>("Cannot resolve moniker '{0}'.", "Serialization Error: UnresolvedMoniker"));
            resourcedStrings.Add("VersionMismatch", new System.Collections.Generic.KeyValuePair<string, string>("Unsupported version '{0}', can only support '{1}'.", "Serialization Error: VersionMismatch"));
        }
        
        /// <summary>
        /// Returns a collection of attributed domain elements for which serialization classes will be generated.
        /// </summary>
        /// <param name="metaModel"></param>
        /// <returns></returns>
        public static IList<AttributedDomainElement> GetSerializedDomainClasses(MetaModel metaModel)
        {
            if (metaModel == null)
                throw new System.ArgumentNullException("metaModel");

            IList<AttributedDomainElement> ilist = new System.Collections.Generic.List<AttributedDomainElement>();
            foreach (DomainClass domainClass in metaModel.AllClasses)
            {
                ilist.Add(domainClass);
            }

            foreach (DomainRelationship domainRS in metaModel.AllRelationships)
            {
                ilist.Add(domainRS);
            }

            return ilist;
        }

        /// <summary>
        /// Gets all domain elements, for which a view model is to be created.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<AttributedDomainElement> GetElementsForViewModelCreation(MetaModel model)
        {
            List<AttributedDomainElement> domainElements = new List<AttributedDomainElement>();

            // we create a view model for every domain class
            domainElements.AddRange(model.AllClasses);

            // we also create view models for all reference relationships
            foreach (DomainRelationship relationship in model.AllRelationships)
                if (relationship is ReferenceRelationship)
                    domainElements.Add(relationship);

            return domainElements;
        }

        /// <summary>
        /// Gets the name property of the given domain element if the element has one. Null otherwise.
        /// </summary>
        /// <param name="domainElement"></param>
        /// <returns></returns>
        public static DomainProperty GetNameProperty(AttributedDomainElement domainElement)
        {
            AttributedDomainElement d = domainElement;

            while (d != null)
            {
                foreach (DomainProperty property in d.Properties)
                    if (property.IsElementName)
                        return property;

                d = d.BaseElement;
            }

            return null;
        }

        public static IEnumerable<AttributedDomainElement> GetElementsForPropertyGridViewModelCreation(MetaModel metaModel)
        {

            List<AttributedDomainElement> domainElements = new List<AttributedDomainElement>();
            List<AttributedDomainElement> elements = new List<AttributedDomainElement>();
            elements.AddRange(metaModel.AllClasses);
            elements.AddRange(metaModel.AllRelationships);

            foreach (AttributedDomainElement element in elements)
            {
                if (element is EmbeddingRelationship)
                    continue;

                bool bSkip = false;
                if (element.Properties.Count == 0 && element.BaseElement == null && element.DerivedElements.Count == 0)
                {
                    bool bActsInReferenceRoles = false;

                    // see if there are refence relationships we have to display
                    foreach (DomainRole rolePlayed in element.RolesPlayed)
                        if (rolePlayed.Relationship is ReferenceRelationship)
                        {
                            bActsInReferenceRoles = true;
                            break;
                        }
                        else if (rolePlayed.Relationship is EmbeddingRelationship)
                        {
                            EmbeddingRelationship em = rolePlayed.Relationship as EmbeddingRelationship;
                            if (em.SerializedEmbeddingRelationship.IsTargetIncludedSubmodel)
                            {
                                bActsInReferenceRoles = true;
                                break;
                            }
                        }

                    if (!bActsInReferenceRoles)
                        bSkip = true;

                    if (element is ReferenceRelationship)
                        if (element.InheritanceModifier != InheritanceModifier.Abstract)
                            bSkip = false;
                }

                // need more skip logic?
                if (bSkip)
                    continue;

                domainElements.Add(element);
            }

            // sort by inheritance
            return SortDomainClassesByInheritance(domainElements);
        }

        /// <summary>
        /// Returns the given domain class collection sorted by inheritance.
        /// </summary>
        public static IEnumerable<T> SortDomainClassesByInheritance<T>(System.Collections.Generic.IEnumerable<T> input)
            where T : AttributedDomainElement
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>(input);
            list.Sort(new DomainClassInheritanceComparer<T>());
            return list;
        }

        /// <summary>
        /// Returns the given domain roles collection sorted by inheritance based on their role players.
        /// </summary>
        public static IEnumerable<T> SortRolesByInheritance<T>(System.Collections.Generic.IEnumerable<T> input)
            where T : DomainRole
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>(input);
            list.Sort(new DomainRoleInheritanceComparer<T>());
            return list;
        }

        /// <summary>
        /// Finds out if the given shape class takes part in displaying the given domain class.
        /// </summary>
        /// <param name="shapeClass"></param>
        /// <param name="relationshipShape"></param>
        /// <returns></returns>
        public static bool ShapeTakesPart(ShapeClass shapeClass, DomainClass domainClass)
        {
            if (domainClass == null || shapeClass == null)
                return false;

            if (domainClass.ShapeClasses.Contains(shapeClass))
                return true;

            foreach (DomainClass derivedClass in domainClass.DerivedClasses)
                if (ShapeTakesPart(shapeClass, derivedClass))
                    return true;

            return false;
        }

        /// <summary>
        /// Finds out if the given shape class takes part in displaying the given relationship class.
        /// </summary>
        /// <param name="shapeClass"></param>
        /// <param name="relationshipShape"></param>
        /// <returns></returns>
        public static bool ShapeTakesPart(ShapeClass shapeClass, DomainRelationship relationship)
        {
            if (relationship == null || shapeClass == null)
                return false;

            DomainClass source = relationship.Source.RolePlayer as DomainClass;
            if (source != null)
            {
                if (ShapeTakesPart(shapeClass, source))
                    return true;
            }

            DomainClass target = relationship.Source.RolePlayer as DomainClass;
            if (target != null)
            {
                if (ShapeTakesPart(shapeClass, target))
                    return true;
            }

            foreach (DomainRelationship derivedCon in relationship.DerivedRelationships)
            {
                if (ShapeTakesPart(shapeClass, derivedCon))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Finds out if the given shape class takes part in displaying the given relationship class.
        /// </summary>
        /// <param name="shapeClass"></param>
        /// <param name="relationshipShape"></param>
        /// <returns></returns>
        public static bool ShapeTakesPart(ShapeClass shapeClass, ReferenceRelationship relationship)
        {
            if (relationship == null || shapeClass == null)
                return false;

            DomainClass source = relationship.Source.RolePlayer as DomainClass;
            if (source != null)
            {
                if (ShapeTakesPart(shapeClass, source))
                    return true;
            }

            DomainClass target = relationship.Source.RolePlayer as DomainClass;
            if (target != null)
            {
                if (ShapeTakesPart(shapeClass, target))
                    return true;
            }

            foreach (ReferenceRelationship derivedCon in relationship.DerivedRelationships)
            {
                if (ShapeTakesPart(shapeClass, derivedCon))
                    return true;
            }

            return false;
        }

        /*
        /// <summary>
        /// Verifies if add rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="diagram"></param>
        /// <returns></returns>
        public static bool NeedsLinkRules(DiagramClass diagram)
        {
            foreach (PresentationElementClass d in diagram.PresentationElements)
            {
                if (!(d is ShapeClass))
                {
                    if (d is RelationshipShapeClass)
                        if ((d as RelationshipShapeClass).ReferenceRelationship != null)
                            return true;

                    if (d is MappingRelationshipShapeClass)
                    {
                        MappingRelationshipShapeClass m = d as MappingRelationshipShapeClass;
                        if (m.DomainClass != null && m.Source != null && m.Target != null)
                            return true;
                    }
                }
            }

            return false;
        */

        /// <summary>
        /// Verifies if add rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="diagram"></param>
        /// <returns></returns>
        public static bool NeedsLinkRules(MetaModel dm)
        {
            foreach (DiagramClass diagram in dm.AllDiagramClasses)
                foreach (PresentationElementClass d in diagram.PresentationElements)
                {
                    if (!(d is ShapeClass))
                    {
                        if (d is RelationshipShapeClass)
                            if ((d as RelationshipShapeClass).ReferenceRelationship != null)
                                return true;
                    }
                }

            return false;
        }

        /// <summary>
        /// Verifies if add rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="diagram"></param>
        /// <returns></returns>
        public static bool NeedsMappingLinkRules(MetaModel dm)
        {
            foreach (DiagramClass diagram in dm.AllDiagramClasses)
                foreach (PresentationElementClass d in diagram.PresentationElements)
                {
                    if (!(d is ShapeClass))
                    {
                        if (d is MappingRelationshipShapeClass)
                        {
                            MappingRelationshipShapeClass m = d as MappingRelationshipShapeClass;
                            if (m.DomainClass != null && m.Source != null && m.Target != null)
                                return true;
                        }
                    }
                }

            return false;
        }

        /*
        /// <summary>
        /// Verifies if add rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="diagram"></param>
        /// <returns></returns>
        public static bool NeedsShapeAddRule(DiagramClass diagram)
        {
            foreach (PresentationElementClass d in diagram.PresentationElements)
            {
                if (d is ShapeClass)
                {
                    if ((d as ShapeClass).DomainClass != null && (d as ShapeClass).Parent != null)
                        return true;
                }
            }

            return false;
        }*/

        /// <summary>
        /// Verifies if add rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        public static bool NeedsShapeAddRule(MetaModel dm)
        {
            foreach (DiagramClass diagram in dm.AllDiagramClasses)
                if( !diagram.IsCustom )
                    foreach (PresentationElementClass d in diagram.PresentationElements)
                    {
                        if (d is ShapeClass)
                        {
                            if ((d as ShapeClass).DomainClass != null)
                            {
                                //if (diagram.VisualizationBehavior != DiagramVisualizationBehavior.Extended)
                                //    return true;
                                //else
                                //if ((d as ShapeClass).Parent != null)
                                 return true;
                            }
                        }
                    }

            return false;
        }

        /// <summary>
        /// Verifies if add rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        public static bool NeedsShapeChangeRule(MetaModel dm)
        {
            foreach (DiagramClass diagram in dm.AllDiagramClasses)
                if (!diagram.IsCustom)
                    foreach (PresentationElementClass d in diagram.PresentationElements)
                    {
                        if (d is ShapeClass)
                        {
                            if ((d as ShapeClass).DomainClass != null)
                            {
                                foreach (DomainRole rolesPlayed in (d as ShapeClass).DomainClass.RolesPlayed)
                                {
                                    if (rolesPlayed.Relationship.Target == rolesPlayed &&
                                        rolesPlayed.Relationship is EmbeddingRelationship &&
                                        rolesPlayed.Relationship.InheritanceModifier != InheritanceModifier.Abstract)
                                        return true;
                                }
                            }
                        }
                    }

            return false;
        }

        /*
        /// <summary>
        /// Verifies if delete rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="diagram"></param>
        /// <returns></returns>
        public static bool NeedsShapeDeleteRule(DiagramClass diagram)
        {
            foreach (PresentationElementClass d in diagram.PresentationElements)
            {
                if (d is ShapeClass)
                    if ((d as ShapeClass).DomainClass != null && d is ShapeClass)
                    {
                        return true;
                    }
            }

            return false;
        }
        */

        /// <summary>
        /// Verifies if delete rule needs to be generated for the given diagram.
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        public static bool NeedsShapeDeleteRule(MetaModel dm)
        {
            foreach (DiagramClass diagram in dm.AllDiagramClasses)
                if (!diagram.IsCustom)
                    foreach (PresentationElementClass d in diagram.PresentationElements)
                    {
                        if (d is ShapeClass)
                            if ((d as ShapeClass).DomainClass != null && d is ShapeClass)
                            {
                                return true;
                            }
                    }

            return false;
        }

        /// <summary>
        /// Gets all domain classes with domain relationships that can be reached from the domain model class.
        /// </summary>
        /// <param name="domainModelClass"></param>
        /// <returns></returns>
        public static Dictionary<DomainClass, List<ReferenceRelationship>> GetDomainClassesWithRefIncludedInTree(DomainClass domainModelClass)
        {
            Dictionary<DomainClass, List<ReferenceRelationship>> classes = new Dictionary<DomainClass, List<ReferenceRelationship>>();
            GetDomainClassesIncludedInTree(classes, domainModelClass);
            return classes;
        }
        private static void GetDomainClassesIncludedInTree(Dictionary<DomainClass, List<ReferenceRelationship>> classes, DomainClass domainClass)
        {
            // add domain class to dictionary first
            classes.Add(domainClass, new List<ReferenceRelationship>());

            // see reference roles of current domain class
            foreach (DomainRole role in domainClass.RolesPlayed)
                if (role.Relationship is ReferenceRelationship && role.Relationship.Source == role)
                {
                    ReferenceRelationship refRel = role.Relationship as ReferenceRelationship;
                    classes[domainClass].Add(refRel);

                    // continue with base relationship
                    if (refRel.BaseRelationship != null)
                    {
                        if (!classes[domainClass].Contains(refRel.BaseRelationship))
                            classes[domainClass].Add(refRel.BaseRelationship as ReferenceRelationship);
                    }

                    // continue with derived relationships
                    foreach (ReferenceRelationship r in refRel.DerivedRelationships)
                    {
                        if (!classes[domainClass].Contains(r))
                            classes[domainClass].Add(r);
                    }
                }

            // continue with embedding relationships
            foreach (DomainRole role in domainClass.RolesPlayed)
                if (role.Relationship is EmbeddingRelationship && role.Relationship.Source == role)
                    if (role.Opposite.RolePlayer is DomainClass)
                    {
                        EmbeddingRelationship embRel = role.Relationship as EmbeddingRelationship;
                        if (!classes.Keys.Contains(embRel.Target.RolePlayer as DomainClass))
                        {
                            GetDomainClassesIncludedInTree(classes, embRel.Target.RolePlayer as DomainClass);
                        }

                        // continue with derived relationships
                        foreach (EmbeddingRelationship r in embRel.DerivedRelationships)
                        {
                            if (!classes.Keys.Contains(r.Target.RolePlayer as DomainClass))
                            {
                                GetDomainClassesIncludedInTree(classes, r.Target.RolePlayer as DomainClass);
                            }
                        }
                    }

            // continue with base class from domain class
            if (domainClass.BaseClass != null)
            {
                if (!classes.Keys.Contains(domainClass.BaseClass))
                    GetDomainClassesIncludedInTree(classes, domainClass.BaseClass);
            }

            // continue with derived classes from domain class
            foreach (DomainClass derivedDomainClass in domainClass.DerivedClasses)
            {
                if (!classes.Keys.Contains(derivedDomainClass))
                    GetDomainClassesIncludedInTree(classes, derivedDomainClass);
            }
        }


        /// FROM: DslDefinition.dll
        internal static bool IsDateTimeType(string typeName)
        {
            if (System.String.IsNullOrEmpty(typeName))
                return false;
            return System.StringComparer.OrdinalIgnoreCase.Equals(typeName, "System.DateTime");
        }

        internal static bool IsDecimalNumberType(string typeName)
        {
            if (!CodeGenerationUtilities.IsSystemInt16(typeName) && !CodeGenerationUtilities.IsSystemInt32(typeName) &&
                !CodeGenerationUtilities.IsSystemInt64(typeName) && !CodeGenerationUtilities.IsSystemUInt16(typeName) &&
                !CodeGenerationUtilities.IsSystemUInt32(typeName) && !CodeGenerationUtilities.IsSystemUInt64(typeName) &&
                !CodeGenerationUtilities.IsSystemSByte(typeName) && !CodeGenerationUtilities.IsSystemByte(typeName) &&
                !CodeGenerationUtilities.IsSystemDouble(typeName) && !CodeGenerationUtilities.IsSystemSingle(typeName))
                return CodeGenerationUtilities.IsSystemDecimal(typeName);
            return true;
        }
        internal static bool IsSystemByte(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Byte"))
                return System.StringComparer.Ordinal.Equals(typeName, "byte");
            return true;
        }

        internal static bool IsSystemDecimal(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Decimal"))
                return System.StringComparer.Ordinal.Equals(typeName, "decimal");
            return true;
        }

        internal static bool IsSystemDouble(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Double"))
                return System.StringComparer.Ordinal.Equals(typeName, "double");
            return true;
        }

        internal static bool IsSystemInt16(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Int16"))
                return System.StringComparer.Ordinal.Equals(typeName, "short");
            return true;
        }

        internal static bool IsSystemInt32(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Int32"))
                return System.StringComparer.Ordinal.Equals(typeName, "int");
            return true;
        }

        internal static bool IsSystemInt64(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Int64"))
                return System.StringComparer.Ordinal.Equals(typeName, "long");
            return true;
        }

        internal static bool IsSystemSByte(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.SByte"))
                return System.StringComparer.Ordinal.Equals(typeName, "sbyte");
            return true;
        }

        internal static bool IsSystemSingle(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Single"))
                return System.StringComparer.Ordinal.Equals(typeName, "float");
            return true;
        }

        internal static bool IsSystemUInt16(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.UInt16"))
                return System.StringComparer.Ordinal.Equals(typeName, "ushort");
            return true;
        }

        internal static bool IsSystemUInt32(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.UInt32"))
                return System.StringComparer.Ordinal.Equals(typeName, "uint");
            return true;
        }

        internal static bool IsSystemUInt64(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.UInt64"))
                return System.StringComparer.Ordinal.Equals(typeName, "ulong");
            return true;
        }

        public static string WrapAsCSharpString(string input)
        {
            if (input == null)
                return "null";
            if (input.Length == 0)
                return "string.Empty";
            string s = input.Replace("\"", "\"\"");
            if (System.String.CompareOrdinal(input, s) == 0)
                return "\"" + input + "\"";
            return "@\"" + s + "\"";
        }

        internal static bool IsBooleanType(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "System.Boolean"))
                return System.StringComparer.Ordinal.Equals(typeName, "bool");
            return true;
        }

        internal static bool IsCharType(string typeName)
        {
            if (!System.StringComparer.Ordinal.Equals(typeName, "char"))
                return System.StringComparer.Ordinal.Equals(typeName, "System.Char");
            return true;
        }

        public static bool IsGuidType(string typeName)
        {
            return System.StringComparer.Ordinal.Equals(typeName, "System.Guid");
        }

        private static string GetNumberTypeSuffix(string typeName)
        {
            if (System.String.IsNullOrEmpty(typeName))
                return System.String.Empty;
            if (CodeGenerationUtilities.IsSystemDouble(typeName))
                return "D";
            if (CodeGenerationUtilities.IsSystemSingle(typeName))
                return "F";
            if (CodeGenerationUtilities.IsSystemDecimal(typeName))
                return "M";
            if (CodeGenerationUtilities.IsSystemInt64(typeName))
                return "L";
            if (CodeGenerationUtilities.IsSystemUInt64(typeName))
                return "UL";
            if (CodeGenerationUtilities.IsSystemUInt32(typeName))
                return "U";
            return System.String.Empty;
        }

        private static bool TryParseDouble(string textValue, System.Globalization.CultureInfo culture, out double result)
        {
            return System.Double.TryParse(textValue, System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite | System.Globalization.NumberStyles.AllowLeadingSign | System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowExponent, culture, out result);
        }
        internal static bool TryParseDouble(string textValue, out double result)
        {
            return TryParseDouble(textValue, System.Globalization.CultureInfo.InvariantCulture, out result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainPropertyTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }

        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is DomainProperty) && (type == typeof(DomainPropertyReferencesType)))
                return new DomainTypeRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }


        private DomainEnumPropertyDescriptor CreateDomainEnumPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement requestor, Microsoft.VisualStudio.Modeling.DomainPropertyInfo domainPropertyInfo, System.Attribute[] attributes)
        {
            DomainProperty domainProperty = requestor as DomainProperty;
            if (domainProperty == null)
                return null;
            if (domainPropertyInfo.Id != DomainProperty.DefaultValueDomainPropertyId)
                return null;
            DomainEnumeration domainEnumeration = domainProperty.Type as DomainEnumeration;
            if (domainEnumeration == null)
                return null;
            return new DomainEnumPropertyDescriptor(this, requestor, domainPropertyInfo, domainEnumeration, attributes);
        }

        protected override Microsoft.VisualStudio.Modeling.Design.ElementPropertyDescriptor CreatePropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement requestor, Microsoft.VisualStudio.Modeling.DomainPropertyInfo domainPropertyInfo, Attribute[] attributes)
        {
            DomainEnumPropertyDescriptor domainEnumPropertyDescriptor = CreateDomainEnumPropertyDescriptor(requestor, domainPropertyInfo, attributes);
            if (domainEnumPropertyDescriptor != null)
                return domainEnumPropertyDescriptor;

            return base.CreatePropertyDescriptor(requestor, domainPropertyInfo, attributes);
        }

        public class DomainTypeRolePlayerPropertyDescriptor : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
        {
            public DomainTypeRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
                : base(sourcePlayer, domainRole, sourceDomainRoleInfoAttributes)
            {
            }

            protected override IList<Microsoft.VisualStudio.Modeling.ModelElement> BuildElementList(object component)
            {
                Microsoft.VisualStudio.Modeling.DomainClassInfo domainClassInfo = DomainRoleInfo.RolePlayer;
                if (domainClassInfo == null || component == null)
                    return new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

                Microsoft.VisualStudio.Modeling.Store store = this.GetStore(component);

                System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement> list = new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();
                DomainProperty domainProperty = component as DomainProperty;
                if (domainProperty == null)
                    if (component is IList)
                        if ((component as IList).Count > 0)
                            domainProperty = (component as IList)[0] as DomainProperty;

                    if (domainProperty != null)
                    {
                        list.AddRange(domainProperty.Element.ParentModelContext.MetaModel.DomainTypes);

                        System.Collections.Generic.IList<Microsoft.VisualStudio.Modeling.ModelElement> ilist = store.ElementDirectory.FindElements(domainClassInfo, true);
                        foreach (Microsoft.VisualStudio.Modeling.ModelElement modelElement in ilist)
                        {
                            DomainType p = modelElement as DomainType;
                            bool bFound = false;
                            foreach (DomainType e in list)
                                if (e.Name == p.Name &&
                                    e.Namespace == p.Namespace)
                                {
                                    bFound = true;
                                    break;
                                }

                            if (!bFound)
                                list.Add(p);
                        }
                    }
                return list;
            }
        }
    }
}

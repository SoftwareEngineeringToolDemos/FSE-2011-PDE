using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainRoleTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }

        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is DomainRole) && (type == typeof(DomainRoleReferencesCustomPropertyGridEditor)))
                return new DomainRoleReferencesCustomPropertyGridEditorDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }

        public class DomainRoleReferencesCustomPropertyGridEditorDescriptor : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
        {
            public DomainRoleReferencesCustomPropertyGridEditorDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
                : base(sourcePlayer, domainRole, sourceDomainRoleInfoAttributes)
            {
            }

            protected override IList<Microsoft.VisualStudio.Modeling.ModelElement> BuildElementList(object component)
            {
                Microsoft.VisualStudio.Modeling.DomainClassInfo domainClassInfo = DomainRoleInfo.RolePlayer;
                if (domainClassInfo == null || component == null)
                    return new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

                Microsoft.VisualStudio.Modeling.Store store = this.GetStore(component);

                DomainRole domainRole = component as DomainRole;
                System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement> list = new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();
                list.AddRange(domainRole.Relationship.GetMetaModel().PropertyGridEditors);

                System.Collections.Generic.IList<Microsoft.VisualStudio.Modeling.ModelElement> ilist = store.ElementDirectory.FindElements(domainClassInfo, false);
                foreach (Microsoft.VisualStudio.Modeling.ModelElement modelElement in ilist)
                {
                    PropertyGridEditor p = modelElement as PropertyGridEditor;
                    bool bFound = false;
                    foreach (PropertyGridEditor e in list)
                        if (e.Name == p.Name)
                        {
                            bFound = true;
                            break;
                        }

                    if (!bFound)
                        list.Add(p);
                }
                return list;
            }
        }
    }
}

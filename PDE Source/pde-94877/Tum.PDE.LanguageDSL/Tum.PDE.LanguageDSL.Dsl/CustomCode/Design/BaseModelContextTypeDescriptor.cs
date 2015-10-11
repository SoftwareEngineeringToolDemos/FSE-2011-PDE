using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class BaseModelContextTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }
        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is ExternModelContext) && (type == typeof(ExternModelContextReferencesModelContext)))
                return new BaseModelContextRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }

        public class BaseModelContextRolePlayerPropertyDescriptor : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
        {
            public BaseModelContextRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
                : base(sourcePlayer, domainRole, sourceDomainRoleInfoAttributes)
            {
            }

            protected override IList<Microsoft.VisualStudio.Modeling.ModelElement> BuildElementList(object component)
            {
                Microsoft.VisualStudio.Modeling.DomainClassInfo domainClassInfo = DomainRoleInfo.RolePlayer;
                if (domainClassInfo == null || component == null)
                    return new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

                Microsoft.VisualStudio.Modeling.Store store = this.GetStore(component);

                ExternModelContext externModelContext = component as ExternModelContext;
                System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement> list = new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();
                System.Collections.Generic.IList<Microsoft.VisualStudio.Modeling.ModelElement> ilist = store.ElementDirectory.FindElements(domainClassInfo, true);
                foreach (Microsoft.VisualStudio.Modeling.ModelElement modelElement in ilist)
                {
                    BaseModelContext p = modelElement as BaseModelContext;
                    if (p.MetaModel.IsTopMost)
                        continue;

                    list.Add(p);
                }
                return list;
            }
        }
    }
}

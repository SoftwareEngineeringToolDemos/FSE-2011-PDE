using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainClassBaseTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }

        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, System.Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is DomainClass) && (type == typeof(DomainClassReferencesBaseClass)))
                return new DomainClassRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }
    }

    public class DomainClassRolePlayerPropertyDescriptor : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
    {
        public DomainClassRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
            : base(sourcePlayer, domainRole, sourceDomainRoleInfoAttributes)
        {
        }

        /// <summary>
        /// Get a list of the valid role players for this property value of the specified component.
        /// </summary>
        /// <param name="component">The represented element, or null to use the stored represented element when in instance mode.</param>
        /// <returns>List of ModelElements that could be chosen as the role player for the property</returns>
        protected override IList<Microsoft.VisualStudio.Modeling.ModelElement> BuildElementList(object component)
        {
            Microsoft.VisualStudio.Modeling.DomainClassInfo domainClassInfo = DomainRoleInfo.RolePlayer;
            if (domainClassInfo == null || component == null)
                return new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

            Microsoft.VisualStudio.Modeling.Store store = this.GetStore(component); 
            System.Collections.Generic.IList<Microsoft.VisualStudio.Modeling.ModelElement> ilist = store.ElementDirectory.FindElements(domainClassInfo, false);
            System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement> list = new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

            DomainClass domainClass1 = component as DomainClass;
            foreach (Microsoft.VisualStudio.Modeling.ModelElement modelElement in ilist)
            {
                DomainClass domainClass2 = modelElement as DomainClass;
                if ((domainClass2 != null) && ShouldIncludeCandidate(domainClass1, domainClass2))
                    list.Add(modelElement);

            }
            return list;
        }

        internal virtual bool ShouldIncludeCandidate(DomainClass currentRoleplayer, DomainClass eachCandidate)
        {
            if (eachCandidate != currentRoleplayer)
                return !eachCandidate.IsDerivedFrom(currentRoleplayer);
            return false;
        }
    }
}

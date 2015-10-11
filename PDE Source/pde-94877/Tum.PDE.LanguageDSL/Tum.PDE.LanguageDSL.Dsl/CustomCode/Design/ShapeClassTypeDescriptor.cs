using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    /*
    public partial class PresentationDomainClassElementTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }
        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, System.Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is ShapeClass) && (type == typeof(ShapeClassReferencesDomainClass)))
                return new ShapeClassRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }
    }

    public class ShapeClassRolePlayerPropertyDescriptor : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
    {
        public ShapeClassRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
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

            System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement> list = new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();
            ShapeClass domainClass1 = component as ShapeClass;
            list.AddRange(domainClass1.GetMetaModel().AllClasses);

            return list;
        }
    }
    */
}

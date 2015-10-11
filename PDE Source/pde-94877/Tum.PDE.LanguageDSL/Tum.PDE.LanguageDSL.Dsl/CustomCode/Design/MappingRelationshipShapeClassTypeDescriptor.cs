using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    /*
    public partial class MappingRelationshipShapeClassBaseTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }
        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, System.Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is MappingRelationshipShapeClass) && (type == typeof(MappingRelationshipShapeClassReferencesSource)))
                return new MappingRSShapeClassRolePlayerPropertyDescriptorSource(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            else if ((sourceRolePlayer is MappingRelationshipShapeClass) && (type == typeof(MappingRelationshipShapeClassReferencesTarget)))
                return new MappingRSShapeClassRolePlayerPropertyDescriptorTarget(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }
    }

    public class MappingRSShapeClassRolePlayerPropertyDescriptorSource : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
    {
        public MappingRSShapeClassRolePlayerPropertyDescriptorSource(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
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
            RelationshipShapeClass domainClass1 = component as RelationshipShapeClass;
            foreach (DomainRelationship r in domainClass1.GetMetaModel().AllRelationships)
                if (r is ReferenceRelationship)
                    list.Add(r);

            return list;
        }
    }
    public class MappingRSShapeClassRolePlayerPropertyDescriptorTarget : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
    {
        public MappingRSShapeClassRolePlayerPropertyDescriptorTarget(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
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
            RelationshipShapeClass domainClass1 = component as RelationshipShapeClass;
            foreach (DomainRelationship r in domainClass1.GetMetaModel().AllRelationships)
                if (r is ReferenceRelationship)
                    list.Add(r);

            return list;
        }
    }
    */
}

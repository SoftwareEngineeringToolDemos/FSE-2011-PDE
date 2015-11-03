using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainRelationshipBaseTypeDescriptor
    {
        private global::System.ComponentModel.PropertyDescriptorCollection GetCustomProperties(global::System.Attribute[] attributes)
        {
            return base.GetProperties(attributes);
        }

        protected override Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor CreateRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourceRolePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo targetRoleInfo, System.Attribute[] sourceDomainRoleInfoAttributes)
        {
            System.Type type = targetRoleInfo.DomainRelationship.ImplementationClass;
            if ((sourceRolePlayer is DomainRelationship) && (type == typeof(DomainRelationshipReferencesBaseRelationship)))
                return new DomainRelationshipRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
            return base.CreateRolePlayerPropertyDescriptor(sourceRolePlayer, targetRoleInfo, sourceDomainRoleInfoAttributes);
        }
    }

    public class DomainRelationshipRolePlayerPropertyDescriptor : Microsoft.VisualStudio.Modeling.Design.RolePlayerPropertyDescriptor
    {
        public DomainRelationshipRolePlayerPropertyDescriptor(Microsoft.VisualStudio.Modeling.ModelElement sourcePlayer, Microsoft.VisualStudio.Modeling.DomainRoleInfo domainRole, System.Attribute[] sourceDomainRoleInfoAttributes)
            : base(sourcePlayer, domainRole, sourceDomainRoleInfoAttributes)
        {
        }

        protected override IList<Microsoft.VisualStudio.Modeling.ModelElement> BuildElementList(object component)
        {

            Microsoft.VisualStudio.Modeling.DomainClassInfo domainClassInfo = DomainRoleInfo.RolePlayer;
            if (domainClassInfo == null || component == null)
                return new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

            Microsoft.VisualStudio.Modeling.Store store = this.GetStore(component);
            System.Collections.Generic.IList<Microsoft.VisualStudio.Modeling.ModelElement> ilist;
            if( component is ReferenceRelationship )
                ilist  = store.ElementDirectory.FindElements(ReferenceRelationship.DomainClassId);
            else
                ilist = store.ElementDirectory.FindElements(EmbeddingRelationship.DomainClassId);
            System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement> list = new System.Collections.Generic.List<Microsoft.VisualStudio.Modeling.ModelElement>();

            DomainRelationship domainClass1 = component as DomainRelationship;
            foreach (Microsoft.VisualStudio.Modeling.ModelElement modelElement in ilist)
            {
                DomainRelationship domainClass2 = modelElement as DomainRelationship;
                if ((domainClass2 != null) && ShouldIncludeCandidate(domainClass1, domainClass2))
                    list.Add(modelElement);

            }
            return list;
        }
        
        internal virtual bool ShouldIncludeCandidate(DomainRelationship currentRoleplayer, DomainRelationship eachCandidate)
        {
            if (currentRoleplayer.Source.RolePlayer is DomainClass && currentRoleplayer.Target.RolePlayer is DomainClass && 
                eachCandidate.Source.RolePlayer is DomainClass && eachCandidate.Target.RolePlayer is DomainClass)
            {
                if ((currentRoleplayer.Source.RolePlayer as DomainClass).IsDerivedFrom(eachCandidate.Source.RolePlayer as DomainClass) &&
                    (currentRoleplayer.Target.RolePlayer as DomainClass).IsDerivedFrom(eachCandidate.Target.RolePlayer as DomainClass))
                    if (eachCandidate != currentRoleplayer)
                        return !eachCandidate.IsDerivedFrom(currentRoleplayer);
            }
            
            return false;
        }
    }
}

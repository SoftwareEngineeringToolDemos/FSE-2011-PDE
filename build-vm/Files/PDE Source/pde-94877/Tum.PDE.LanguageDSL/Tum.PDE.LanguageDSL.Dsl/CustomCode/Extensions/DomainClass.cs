using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public partial class DomainClass
    {
        public List<DomainClass> Parents
        {
            get
            {
                List<DomainClass> parents = new List<DomainClass>();
                DomainClass domainClass = this;
                while (domainClass != null)
                {
                    foreach (DomainRole rolesPlayed in this.RolesPlayed)
                    {
                        if (rolesPlayed.Relationship.Target == rolesPlayed &&
                            rolesPlayed.Relationship is EmbeddingRelationship &&
                            rolesPlayed.Relationship.InheritanceModifier != InheritanceModifier.Abstract)
                            if( !parents.Contains(rolesPlayed.Relationship.Source.RolePlayer as DomainClass))
                                parents.Add(rolesPlayed.Relationship.Source.RolePlayer as DomainClass);
                    }
                    domainClass = domainClass.BaseClass;
                }

                return parents;
            }
        }

        /// <summary>
        /// True if this DomainClass is derived from the given class
        /// </summary>
        public bool IsDerivedFrom(DomainClass candidateBase)
        {
            for (DomainClass domainClass = this; domainClass != null; domainClass = domainClass.BaseClass)
            {
                if (domainClass.Equals(candidateBase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Finds out if this domain class is embedded somewhere.
        /// </summary>
        /// <returns>True if this domain class is embedded. False otherwise.</returns>
        public bool HasParent()
        {
            if (this.IsDomainModel)
                return false;

            foreach (DomainRole role in this.RolesPlayed)
                if (role.Relationship is EmbeddingRelationship &&
                    role == role.Relationship.Target)
                    return true;

            return false;
        }

        /// <summary>
        /// Gets all derived shape classes.
        /// </summary>
        public List<PresentationDomainClassElement> AllDerivedShapeClasses
        {
            get
            {
                List<PresentationDomainClassElement> shapeClasses = new List<PresentationDomainClassElement>();
                GetAllDerivedShapeClasses(shapeClasses);

                return shapeClasses;
            }
        }

        public void GetAllDerivedShapeClasses(List<PresentationDomainClassElement> shapeClasses)
        {
            foreach (PresentationDomainClassElement shapeClass in this.ShapeClasses)
                shapeClasses.Add(shapeClass);

            foreach (DomainClass d in this.DerivedClasses)
                d.GetAllDerivedShapeClasses(shapeClasses);
        }

        /// <summary>
        /// Gets all derived shape classes.
        /// </summary>
        public List<DomainClass> AllDerivedClasses
        {
            get
            {
                List<DomainClass> domainClasses = new List<DomainClass>();
                GetAllDerivedClasses(domainClasses);

                return domainClasses;
            }
        }

        public void GetAllDerivedClasses(List<DomainClass> domainClasses)
        {
            foreach (DomainClass d in this.DerivedClasses)
            {
                domainClasses.Add(d);

                d.GetAllDerivedClasses(domainClasses);
            }
        }
    }
}

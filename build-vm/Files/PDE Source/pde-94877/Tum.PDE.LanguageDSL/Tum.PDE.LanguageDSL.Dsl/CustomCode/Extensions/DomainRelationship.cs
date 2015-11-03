using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.LanguageDSL
{
    public abstract partial class DomainRelationship
    {
        /// <summary>
        /// Determines whether this reference relationship requires to be serialized in full form or not.
        /// </summary>
        /// <returns>True if reference relationship needs to be serialized in full form. False otherwise.</returns>
        public bool NeedsFullSerialization()
        {
            if (IsReferenced() || this.Properties.Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Returns true if this reference relationship is references somewhere in the model. False otherwise.
        /// </summary>
        public bool IsReferenced()
        {
            foreach (DomainRole role in this.RolesPlayed)
            {
                if (role.Relationship is ReferenceRelationship && role.Relationship.Target == role && role.Relationship.InheritanceModifier != InheritanceModifier.Abstract)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// True if this DomainRelationship is derived from the given class
        /// </summary>
        public bool IsDerivedFrom(DomainRelationship candidateBase)
        {
            for (DomainRelationship domainClass = this; domainClass != null; domainClass = domainClass.BaseRelationship)
            {
                if (domainClass.Equals(candidateBase))
                    return true;
            }
            return false;
        }
    }
}

using System;

using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(ReferenceRelationship), FireTime = TimeToFire.TopLevelCommit, Priority=-1)]
    [RuleOn(typeof(EmbeddingRelationship), FireTime = TimeToFire.TopLevelCommit, Priority = -1)]
    [RuleOn(typeof(DomainClassReferencesBaseClass), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    [RuleOn(typeof(DomainRelationshipReferencesBaseRelationship), FireTime = TimeToFire.TopLevelCommit, Priority = 1)]
    public class SerializationDomainRelationshipAddRule : AddRule
    {
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            if (e.ModelElement.IsDeleting || e.ModelElement.IsDeleted)
                return;

            ReferenceRelationship referenceRelationship = e.ModelElement as ReferenceRelationship;
            if (referenceRelationship != null)
            {
                if( referenceRelationship.SerializedReferenceRelationship == null )
                    OnReferenceRelationshipAdded(referenceRelationship);
            }

            EmbeddingRelationship embeddingRelationship = e.ModelElement as EmbeddingRelationship;
            if (embeddingRelationship != null)
            {
                if (embeddingRelationship.SerializedEmbeddingRelationship == null)
                    OnEmbeddingRelationshipAdded(embeddingRelationship);
            }

            DomainClassReferencesBaseClass inhRelationship = e.ModelElement as DomainClassReferencesBaseClass;
            if (inhRelationship != null)
            {
                SerializationHelper.UpdateDerivedElementsSerializationProperties(inhRelationship.DerivedClass);
                SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(inhRelationship.DerivedClass);
            }

            DomainRelationshipReferencesBaseRelationship inhRelationshipRel = e.ModelElement as DomainRelationshipReferencesBaseRelationship;
            if (inhRelationshipRel != null)
            {
                // update derived properties
                SerializationHelper.UpdateDerivedElementsSerializationProperties(inhRelationshipRel.DerivedRelationship);
            }
        }

        public static void OnReferenceRelationshipAdded(ReferenceRelationship referenceRelationship)
        {
            #region Check Paramaters
            if (referenceRelationship.Source == null)
                throw new ArgumentNullException("referenceRelationship.Source");

            if (referenceRelationship.Target == null)
                throw new ArgumentNullException("referenceRelationship.Target");

            if (!(referenceRelationship.Source.RolePlayer is DomainClass))
                throw new ArgumentNullException("referenceRelationship.Source.RolePlayer needs to be DomainClass");

            if (!(referenceRelationship.Target.RolePlayer is DomainClass) && !(referenceRelationship.Target.RolePlayer is ReferenceRelationship))
                throw new ArgumentNullException("referenceRelationship.Target.RolePlayer needs to be DomainClass or ReferenceRelationship");
            #endregion

            // Add properties and id attribute and set serialization form.
            SerializedReferenceRelationship child = new SerializedReferenceRelationship(referenceRelationship.Store);
            child.ReferenceRelationship = referenceRelationship;
            if (referenceRelationship.NeedsFullSerialization())
                child.IsInFullSerialization = true;
            else
                child.IsInFullSerialization = false;
            child.SerializationName = referenceRelationship.SerializationName;
            SerializationHelper.AddSerializationDomainProperties(referenceRelationship.Store, referenceRelationship);

            referenceRelationship.ModelContext.SerializationModel.Children.Add(child);

            SerializationClass domainClassSource = (referenceRelationship.Source.RolePlayer as DomainClass).SerializedDomainClass;
            domainClassSource.Children.Add(child);

            // Add roles players.
            SerializedDomainRole roleSource = new SerializedDomainRole(referenceRelationship.Store);
            roleSource.DomainRole = referenceRelationship.Source;
            roleSource.SerializationAttributeName = referenceRelationship.SerializationAttributeName;
            roleSource.SerializationName = referenceRelationship.SerializationSourceName;
            child.Children.Add(roleSource);

            SerializedDomainRole roleTarget = new SerializedDomainRole(referenceRelationship.Store);
            roleTarget.DomainRole = referenceRelationship.Target;
            roleTarget.SerializationAttributeName = referenceRelationship.SerializationAttributeName;
            roleTarget.SerializationName = referenceRelationship.SerializationTargetName;
            child.Children.Add(roleTarget);

            child.SerializedDomainRoles.Add(roleSource);
            child.SerializedDomainRoles.Add(roleTarget);

            // update derived roles
            SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(referenceRelationship.Source.RolePlayer);
        }
        public static void OnEmbeddingRelationshipAdded(EmbeddingRelationship embeddingRelationship)
        {
            #region Check Paramaters
            if (embeddingRelationship.Source == null)
                throw new ArgumentNullException("embeddingRelationship.Source");

            if (embeddingRelationship.Target == null)
                throw new ArgumentNullException("embeddingRelationship.Target");

            if (!(embeddingRelationship.Source.RolePlayer is DomainClass))
                throw new ArgumentNullException("embeddingRelationship.Source.RolePlayer needs to be DomainClass");

            if (!(embeddingRelationship.Target.RolePlayer is DomainClass))
                throw new ArgumentNullException("embeddingRelationship.Target.RolePlayer needs to be DomainClass");
            #endregion

            // add serialization info
            SerializedDomainClass child;
            if ((embeddingRelationship.Target.RolePlayer as DomainClass).SerializedDomainClass == null)
            {
                child = new SerializedDomainClass(embeddingRelationship.Store);
                child.DomainClass = embeddingRelationship.Target.RolePlayer as DomainClass;
                (embeddingRelationship.Target.RolePlayer as DomainClass).ModelContext.SerializationModel.Children.Add(child);

                SerializationHelper.AddSerializationDomainProperties(embeddingRelationship.Store, embeddingRelationship.Target.RolePlayer);
            }
            else
                child = (embeddingRelationship.Target.RolePlayer as DomainClass).SerializedDomainClass;

            // Add properties and id attribute and set serialization form for embedding relationship.
            SerializedEmbeddingRelationship embChild = new SerializedEmbeddingRelationship(embeddingRelationship.Store);
            embChild.EmbeddingRelationship = embeddingRelationship;
            embChild.IsInFullSerialization = false;
            embChild.SerializationName = embeddingRelationship.SerializationName;
            SerializationHelper.AddSerializationDomainProperties(embeddingRelationship.Store, embeddingRelationship);

            embeddingRelationship.ModelContext.SerializationModel.Children.Add(embChild);
            embChild.Children.Add(child);

            // Add connection between roleplayers, to reflect it onto the serialization model.
            SerializationClass sourceSerializationClass = (embeddingRelationship.Source.RolePlayer as DomainClass).SerializedDomainClass;
            sourceSerializationClass.Children.Add(embChild);

            // update derived roles
            SerializationHelper.UpdateDerivedElementsSerializationDomainRoles(embeddingRelationship.Source.RolePlayer);
        }
    }
}

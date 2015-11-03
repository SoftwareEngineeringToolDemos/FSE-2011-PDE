using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    public static class ModelTreeHelper
    {
        /// <summary>
        /// Adds a new embedding relationship instance betweend the given domain class as source and a new domain class
        /// as target (target is created by this method).
        /// </summary>
        /// <param name="source">Domain class acting as parent in the embedding relationship.</param>
        public static void AddNewEmbeddingRelationship(List<DomainClass> sources)
        {
            if (sources.Count == 0)
                return;

            using (Transaction transaction = sources[0].Store.TransactionManager.BeginTransaction("Create new embedding rs"))
            {
                foreach (DomainClass source in sources)
                {
                    // create new domain class
                    DomainClass target = source.Store.ElementFactory.CreateElement(DomainClass.DomainClassId) as DomainClass;
                    Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(source.Store as IServiceProvider, source.Store.DefaultPartition);
                    Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(source.Store.DefaultPartition);
                    elementGroup.Add(target);
                    elementGroup.MarkAsRoot(target);
                    elementOperations.MergeElementGroup(source.ModelContext, elementGroup);
                    target.Name = NameHelper.GetUniqueName(source.Store, DomainClass.DomainClassId);

                    // create a new embedding relationship
                    AddNewEmbeddingRS(source, target, true);
                }
                transaction.Commit();
            }
        }

        /// <summary>
        /// Adds a new embedding relationship instance.
        /// </summary>
        /// <param name="source">Domain class representing the parent.</param>
        /// <param name="target">Domain class representing the child.</param>
        public static void AddNewEmbeddingRelationship(List<DomainClass> sources, AttributedDomainElement target)
        {
            if (sources.Count == 0)
                return;

            using (Transaction transaction = sources[0].Store.TransactionManager.BeginTransaction("Create new embedding rs"))
            {
                foreach (DomainClass source in sources)
                {
                    // create a new embedding relationship
                    AddNewEmbeddingRS(source, target, false);
                }
                transaction.Commit();
            }
        }

        /// <summary>
        /// Adds a new embedding relationship instance. Needs to be called within a modeling transaction.
        /// </summary>
        /// <param name="source">Domain class representing the parent.</param>
        /// <param name="target">Domain class representing the child.</param>
        public static EmbeddingRelationship AddNewEmbeddingRS(DomainClass source, AttributedDomainElement target, bool bTargetElementHolder)
        {
            // create rs
            EmbeddingRelationship emb = new EmbeddingRelationship(source.Store);
            source.ModelContext.Relationships.Add(emb);

            // create roles
            DomainRole sourceRole = new DomainRole(source.Store);
            sourceRole.PropagatesDelete = false;

            DomainRole targetRole = new DomainRole(source.Store);
            targetRole.Multiplicity = Multiplicity.One;
            targetRole.PropagatesDelete = true;

            sourceRole.RolePlayer = source;
            targetRole.RolePlayer = target;

            sourceRole.Opposite = targetRole;
            targetRole.Opposite = sourceRole;

            // assign roles to rs
            emb.Roles.Add(sourceRole);
            emb.Roles.Add(targetRole);

            emb.Source = sourceRole;
            emb.Target = targetRole;

            // properties + names
            if (emb.Source.RolePlayer.Name == emb.Target.RolePlayer.Name)
                sourceRole.Name = source.Name + "Source";
            else
                sourceRole.Name = source.Name;
            sourceRole.IsNameTracking = TrackingEnum.IgnoreOnce;

            if (emb.Source.RolePlayer.Name == emb.Target.RolePlayer.Name)
                targetRole.Name = target.Name + "Target";
            else
                targetRole.Name = target.Name;
            targetRole.IsNameTracking = TrackingEnum.IgnoreOnce;

            AddNewEmbeddingRS(emb, source, target, bTargetElementHolder);

            return emb;
        }

        /// <summary>
        /// Adds a new embedding relationship instance. Needs to be called within a modeling transaction.
        /// </summary>
        /// <param name="source">Domain class representing the parent.</param>
        /// <param name="target">Domain class representing the child.</param>
        public static void AddNewEmbeddingRS(EmbeddingRelationship emb, DomainClass source, AttributedDomainElement target, bool bTargetElementHolder)
        {
            // tree nodes
            // 1. find the element holder node for source
            // 2. add new EmbeddingRSNode, connect to rs
            // 3. add new EmbeddingNode for target
            TreeNode elementHolderNode = null;
            foreach (TreeNode node in source.DomainModelTreeNodes)
                if (node.IsElementHolder)
                {
                    elementHolderNode = node;
                    break;
                }

            if (elementHolderNode == null)
                throw new ArgumentNullException("elementHolderNode");

            EmbeddingRSNode rsNode = new EmbeddingRSNode(source.Store);
            rsNode.Relationship = emb;

            EmbeddingNode embNode = new EmbeddingNode(source.Store);
            embNode.DomainElement = target;
            embNode.IsElementHolder = bTargetElementHolder;
            if (!bTargetElementHolder)
                embNode.IsExpanded = false;

            elementHolderNode.EmbeddingRSNodes.Add(rsNode);
            rsNode.EmbeddingNode = embNode;

            source.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(rsNode);
            source.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(embNode);
        }

        /// <summary>
        /// Adds a new referece relationship instance.
        /// </summary>
        /// <param name="source">Domain class representing the source.</param>
        /// <param name="target">Domain class representing the target.</param>
        public static void AddNewReferenceRelationship(List<DomainClass> sources, AttributedDomainElement target)
        {
            if (sources.Count == 0)
                return;

            using (Transaction transaction = sources[0].Store.TransactionManager.BeginTransaction("Create new reference rs"))
            {
                foreach (DomainClass source in sources)
                {
                    // create rs
                    AddNewReferenceRelationship(source, target);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Adds a new referece relationship instance.
        /// </summary>
        /// <param name="source">Domain class representing the source.</param>
        /// <param name="target">Domain class representing the target.</param>
        public static ReferenceRelationship AddNewReferenceRelationship(DomainClass source, AttributedDomainElement target)
        {
            // create rs
            ReferenceRelationship refRel = new ReferenceRelationship(source.Store);
            source.ModelContext.Relationships.Add(refRel);

            // create roles
            DomainRole sourceRole = new DomainRole(source.Store);
            sourceRole.PropagatesDelete = false;

            DomainRole targetRole = new DomainRole(source.Store);
            targetRole.PropagatesDelete = false;

            sourceRole.RolePlayer = source;
            targetRole.RolePlayer = target;

            sourceRole.Opposite = targetRole;
            targetRole.Opposite = sourceRole;

            // assign roles to rs
            refRel.Roles.Add(sourceRole);
            refRel.Roles.Add(targetRole);

            refRel.Source = sourceRole;
            refRel.Target = targetRole;

            // properties + names
            if (refRel.Source.RolePlayer.Name == refRel.Target.RolePlayer.Name)
                sourceRole.Name = source.Name + "Source";
            else
                sourceRole.Name = source.Name;
            sourceRole.IsNameTracking = TrackingEnum.IgnoreOnce;

            if (refRel.Source.RolePlayer.Name == refRel.Target.RolePlayer.Name)
                targetRole.Name = target.Name + "Target";
            else
                targetRole.Name = target.Name;
            targetRole.IsNameTracking = TrackingEnum.IgnoreOnce;

            refRel.SerializationSourceName = sourceRole.Name + "Ref";
            refRel.IsSerializationSourceNameTracking = TrackingEnum.IgnoreOnce;
            refRel.SerializationTargetName = targetRole.Name + "Ref";
            refRel.IsSerializationTargetNameTracking = TrackingEnum.IgnoreOnce;

            AddNewReferenceRelationship(refRel, source, target);

            return refRel;
        }

        /// <summary>
        /// Adds a new referece relationship instance.
        /// </summary>
        /// <param name="source">Domain class representing the source.</param>
        /// <param name="target">Domain class representing the target.</param>
        public static void AddNewReferenceRelationship(ReferenceRelationship refRel, DomainClass source, AttributedDomainElement target)
        {
            // tree nodes
            // 1. find the element holder node for source
            // 2. add new ReferenceRSNode, connect to rs
            // 3. add new ReferenceNode for target
            TreeNode elementHolderNode = null;
            foreach (TreeNode node in source.DomainModelTreeNodes)
                if (node.IsElementHolder)
                {
                    elementHolderNode = node;
                    break;
                }

            if (elementHolderNode == null)
                throw new ArgumentNullException("elementHolderNode");

            ReferenceRSNode rsNode = new ReferenceRSNode(source.Store);
            rsNode.ReferenceRelationship = refRel;

            ReferenceNode refNode = new ReferenceNode(source.Store);
            refNode.DomainElement = target;
            refNode.IsElementHolder = false;
            refNode.IsExpanded = false;

            elementHolderNode.ReferenceRSNodes.Add(rsNode);
            rsNode.ReferenceNode = refNode;

            source.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(rsNode);
            source.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(refNode);
        }

        /// <summary>
        /// Adds a new inheritance relationship instance for each source.
        /// </summary>
        /// <param name="sources">DomainClass to be the derived classes.</param>
        /// <param name="target">DomainClass to act as the base class.</param>
        public static void AddNewInheritanceRelationship(List<DomainClass> sources, DomainClass target)
        {
            if (sources.Count == 0)
                return;

            using (Transaction transaction = sources[0].Store.TransactionManager.BeginTransaction("Create new inheritance rs"))
            {
                foreach (DomainClass source in sources)
                {
                    // create a new embedding relationship
                    AddNewInheritanceRelationship(source, target, false);

                }
                transaction.Commit();
            }
        }

        /// <summary>
        /// Adds a new derived class to each of the given domain classes.
        /// </summary>
        /// <param name="sources">DomainClasses to add a derived from.</param>
        public static void AddNewInheritanceRelationshipNewDerivedClass(List<DomainClass> sources)
        {
            if (sources.Count == 0)
                return;

            using (Transaction transaction = sources[0].Store.TransactionManager.BeginTransaction("Create new inheritance rs"))
            {
                foreach (DomainClass source in sources)
                {
                    // Create new domain class to act as the derived class
                    DomainClass target = source.Store.ElementFactory.CreateElement(DomainClass.DomainClassId) as DomainClass;
                    Microsoft.VisualStudio.Modeling.ElementOperations elementOperations = new Microsoft.VisualStudio.Modeling.ElementOperations(source.Store as IServiceProvider, source.Store.DefaultPartition);
                    Microsoft.VisualStudio.Modeling.ElementGroup elementGroup = new Microsoft.VisualStudio.Modeling.ElementGroup(source.Store.DefaultPartition);
                    elementGroup.Add(target);
                    elementGroup.MarkAsRoot(target);
                    elementOperations.MergeElementGroup(source.ModelContext, elementGroup);
                    target.Name = NameHelper.GetUniqueName(source.Store, DomainClass.DomainClassId);

                    // create a new embedding relationship
                    AddNewInheritanceRelationship(target, source, true);
                }
                transaction.Commit();
            }
        }

        /// <summary>
        /// Adds a new inheritance relationship instance. Needs to be called within a modeling transaction.
        /// </summary>
        /// <param name="source">Derived class</param>
        /// <param name="target">Base class</param>
        public static void AddNewInheritanceRelationship(DomainClass source, DomainClass target, bool bTargetElementHolder)
        {
            DomainClassReferencesBaseClass con = new DomainClassReferencesBaseClass(source, target);

            AddNewInheritanceRelationship(con, source, target, bTargetElementHolder);
        }

        /// <summary>
        /// Adds a new inheritance relationship instance. Needs to be called within a modeling transaction.
        /// </summary>
        /// <param name="source">Derived class</param>
        /// <param name="target">Base class</param>
        public static void AddNewInheritanceRelationship(DomainClassReferencesBaseClass con, DomainClass source, DomainClass target, bool bTargetElementHolder)
        {
            if (ImmutabilityExtensionMethods.GetLocks(target) != Locks.None)
                return;

            // tree nodes
            // 1. find the element holder node for source
            // 2. add new InheritanceNode
            TreeNode elementHolderNode = null;
            foreach (TreeNode node in target.DomainModelTreeNodes)
                if (node.IsElementHolder)
                {
                    elementHolderNode = node;
                    break;
                }

            if (elementHolderNode == null)
                throw new ArgumentNullException("elementHolderNode");

            InheritanceNode inhNode = new InheritanceNode(source.Store);
            inhNode.DomainElement = source;
            inhNode.IsElementHolder = bTargetElementHolder;
            if (!inhNode.IsElementHolder)
                inhNode.IsExpanded = false;
            inhNode.InhRelationshipId = con.Id;
            con.InhNodeId = inhNode.Id;

            source.ModelContext.ViewContext.DomainModelTreeView.ModelTreeNodes.Add(inhNode);

            elementHolderNode.InheritanceNodes.Add(inhNode);
        }
    }
}

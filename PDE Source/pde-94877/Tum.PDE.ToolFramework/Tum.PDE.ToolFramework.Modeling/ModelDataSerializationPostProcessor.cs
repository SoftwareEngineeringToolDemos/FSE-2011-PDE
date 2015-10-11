using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Modeling;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class is used to store post process date during deseralization.
    /// </summary>
    public abstract class ModelDataSerializationPostProcessor
    {
        /// <summary>
        /// Dictionary containing the gathered information.
        /// </summary>
        protected Dictionary<Guid, List<PostProcessRelationshipData>> dictionary;

        /// <summary>
        /// List containing the gathered tracking information.
        /// </summary>
        protected List<Guid> trackDictionary;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected ModelDataSerializationPostProcessor() 
        {
            dictionary = new Dictionary<Guid, List<PostProcessRelationshipData>>();
            trackDictionary = new List<Guid>();
        }

        /// <summary>
        /// Adds a new entry into the dictionary for later postprocessing.
        /// </summary>
        /// <param name="relationshipDomainClassId">DomainClassId of the relationship.</param>
        /// <param name="relationshipId">Id of the relationship. Can be Guid.Empty, in which case a new relationship is created.</param>
        /// <param name="sourceId">Id of the source element. Can be Guid.Empty, in which case this entry needs to be updated later.</param>
        /// <param name="targetId">Id of the target element. Can be Guid.Empty, in which case this entry needs to be updated later.</param>
        public virtual void AddPostProcessData(Guid relationshipDomainClassId, Guid relationshipId, Guid sourceId, Guid targetId)
        {
            PostProcessRelationshipData p = new PostProcessRelationshipData();
            p.RelationshipId = relationshipId;
            p.ModelElementSourceId = sourceId;
            p.ModelElementTargetId = targetId;

            if (!dictionary.Keys.Contains(relationshipDomainClassId))
            {
                dictionary.Add(relationshipDomainClassId, new List<PostProcessRelationshipData>());
                dictionary[relationshipDomainClassId].Add(p);
            }
            else
            {
                // check if there already is an entry and update it
                foreach(PostProcessRelationshipData data in dictionary[relationshipDomainClassId] )
                    if (data.RelationshipId == p.RelationshipId && p.RelationshipId != Guid.Empty)
                    {
                        // update
                        if (data.ModelElementSourceId == Guid.Empty)
                            data.ModelElementSourceId = sourceId;
                        if (data.ModelElementTargetId == Guid.Empty)
                            data.ModelElementTargetId = targetId;
                        return;
                    }

                dictionary[relationshipDomainClassId].Add(p);
            }
        }

        /// <summary>
        /// Adds a new relationship to track during the post process phase. This is required for relationships that are created with
        /// placeholder role assignments. In case those are not resolved later, all relationships that are beeing tracked need to be 
        /// deleted.
        /// </summary>
        /// <param name="relationshipId">Id of the relationship. </param>
        public virtual void AddRelationshipTrackData(Guid relationshipId)
        {
            if( !trackDictionary.Contains(relationshipId) )
                trackDictionary.Add(relationshipId);
        }

        /// <summary>
        /// Post process gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already processed models.</param>
        /// <param name="serializationResult">Serialization result.</param>
        /// <param name="store">Store.</param>
        public abstract void DoPostProcess(System.Collections.Generic.List<string> alreadyProcessedModels, Microsoft.VisualStudio.Modeling.SerializationResult serializationResult, Store store);

        /// <summary>
        /// Post process gathered information.
        /// </summary>
        /// <param name="serializationResult">Serialization result.</param>
        /// <param name="store">Store.</param>
        protected virtual void DoPostProcess(Microsoft.VisualStudio.Modeling.SerializationResult serializationResult, Store store)
        {
            foreach (System.Guid domainClassId in this.dictionary.Keys)
            {
                DomainRelationshipInfo relationshipInfo = store.DomainDataDirectory.FindDomainRelationship(domainClassId);
                if (relationshipInfo == null)
                {
                    SerializationUtilities.AddMessage(serializationResult, "", SerializationMessageKind.Warning,
                                "Couldn't find domain relationship data. DomainClassId: " + domainClassId, 0, 0);
                    continue;
                }
                foreach (PostProcessRelationshipData data in this.dictionary[domainClassId])
                {
                    // get source and target elements
                    ModelElement source = store.ElementDirectory.FindElement(data.ModelElementSourceId);
                    ModelElement target = store.ElementDirectory.FindElement(data.ModelElementTargetId);
                    if (target == null)	// target is link ?
                        target = store.ElementDirectory.FindElementLink(data.ModelElementTargetId);

                    if (source == null)
                    {
                        SerializationUtilities.AddMessage(serializationResult, "", SerializationMessageKind.Warning,
                            "Couldn't find the source element of the relationship " + relationshipInfo.Name + ". Id of missing element: " + data.ModelElementSourceId, 0, 0);
                        continue;
                    }
                    if (target == null)
                    {
                        SerializationUtilities.AddMessage(serializationResult, "", SerializationMessageKind.Warning,
                            "Couldn't find the target element of the relationship " + relationshipInfo.Name + ". Id of missing element: " + data.ModelElementTargetId, 0, 0);
                        continue;
                    }

                    if (data.RelationshipId == System.Guid.Empty)
                    {
                        try
                        {
                            // create new relationship
                            RoleAssignment[] roleAssignments = new RoleAssignment[2];
                            roleAssignments[0] = new RoleAssignment(GetSourceDomainRole(relationshipInfo).Id, source);
                            roleAssignments[1] = new RoleAssignment(GetTargetDomainRole(relationshipInfo).Id, target);

                            store.ElementFactory.CreateElementLink(relationshipInfo, roleAssignments);
                        }
                        catch (System.Exception ex)
                        {
                            SerializationUtilities.AddMessage(serializationResult, "", SerializationMessageKind.Warning,
                                "Error while creating new instance of relationship " + relationshipInfo.Name + " between " + source.Id.ToString() + " and " + target.Id.ToString() + ".  Exception: " + ex.Message, 0, 0);
                        }
                    }
                    else
                    {
                        try
                        {
                            // assign role players
                            ElementLink instance = store.ElementDirectory.FindElementLink(data.RelationshipId);
                            if (instance == null)
                                throw new System.ArgumentNullException("Post processing failed because relationship (id=" + data.RelationshipId + ") is not in the store");

                            DomainRoleInfo.SetRolePlayer(instance, GetSourceDomainRole(relationshipInfo).Id, source);
                            DomainRoleInfo.SetRolePlayer(instance, GetTargetDomainRole(relationshipInfo).Id, target);

                            this.trackDictionary.Remove(instance.Id);
                        }
                        catch (System.Exception ex)
                        {
                            SerializationUtilities.AddMessage(serializationResult, "", SerializationMessageKind.Warning,
                                "Error while creating the instance of the relationship " + relationshipInfo.Name + " (id: " + data.RelationshipId + ") between " + source.Id.ToString() + " and " + target.Id.ToString() + ".  Exception: " + ex.Message, 0, 0);
                        }
                    }
                }
            }

            foreach(Guid id in this.trackDictionary)
            {
                ModelElement m = store.ElementDirectory.FindElement(id);
                if( m != null )
                    m.Delete();
            }
        }

        private DomainRoleInfo GetSourceDomainRole(DomainRelationshipInfo info)
        {
            for (int i = 0; i < info.DomainRoles.Count; i++)
                if (info.DomainRoles[i].IsSource)
                    return info.DomainRoles[i];

            throw new InvalidOperationException("Couldn't find source domain role in info " + info.Name);
        }
        private DomainRoleInfo GetTargetDomainRole(DomainRelationshipInfo info)
        {
            for (int i = 0; i < info.DomainRoles.Count; i++)
                if (!info.DomainRoles[i].IsSource)
                    return info.DomainRoles[i];

            throw new InvalidOperationException("Couldn't find target domain role in info " + info.Name);
        }

        /// <summary>
        /// Clears the gathered information.
        /// </summary>
        public void Reset()
        {
            this.Reset(new List<string>());
        }

        /// <summary>
        /// Clears the gathered information.
        /// </summary>
        /// <param name="alreadyProcessedModels">Already processed models.</param>
        public abstract void Reset(System.Collections.Generic.List<string> alreadyProcessedModels);

        /// <summary>
        /// Helper class for storing gathered information.
        /// </summary>
        protected class PostProcessRelationshipData
        {
            /// <summary>
            /// Id of the relationship.
            /// </summary>
            public Guid RelationshipId;

            /// <summary>
            /// Id of the source element.
            /// </summary>
            public Guid ModelElementSourceId;

            /// <summary>
            /// Id of the target element.
            /// </summary>
            public Guid ModelElementTargetId;
        }
    }
}

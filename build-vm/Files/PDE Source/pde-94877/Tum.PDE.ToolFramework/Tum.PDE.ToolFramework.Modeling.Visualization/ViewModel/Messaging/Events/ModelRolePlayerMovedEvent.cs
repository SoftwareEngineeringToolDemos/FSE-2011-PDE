using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies that a model role player has been moved.
    /// </summary>
    /// <remarks>
    /// These events are treated as a weak events.
    /// </remarks>
    public class ModelRolePlayerMovedEvent : ModelElementEvent<RolePlayerOrderChangedEventArgs>
    {
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionaryOnElementId = new Dictionary<Guid, List<IEventSubscription>>();
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionary = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();

        /// <summary>
        /// Subscribes to the role player changed event. Observers are notified, whenever role player changes on a
        /// specific model element.
        /// </summary>
        /// <param name="elementId">Id of the model element, on which role player changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(Guid elementId, Action<RolePlayerOrderChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<RolePlayerOrderChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<RolePlayerOrderChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnElementId)
            {
                if (!dictionaryOnElementId.Keys.Contains(elementId))
                    dictionaryOnElementId.Add(elementId, new List<IEventSubscription>());

                dictionaryOnElementId[elementId].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the role player changed event.
        /// </summary>
        /// <param name="domainRelationshipInfo">RelationshipInfo, which changes cause a notification.</param>
        /// <param name="elementId">Id of the role player, on which role changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainRelationshipInfo domainRelationshipInfo, Guid elementId, Action<RolePlayerOrderChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<RolePlayerOrderChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<RolePlayerOrderChangedEventArgs>(actionReference, filterReference);

            lock (dictionary)
            {
                Guid domainClassId = domainRelationshipInfo.Id;

                if (!dictionary.Keys.Contains(domainClassId))
                    dictionary.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                if (!dictionary[domainClassId].Keys.Contains(elementId))
                    dictionary[domainClassId].Add(elementId, new List<IEventSubscription>());
                dictionary[domainClassId][elementId].Add(subscription);

                // process descendants
                foreach (DomainClassInfo info in domainRelationshipInfo.AllDescendants)
                {
                    domainClassId = info.Id;

                    if (!dictionary.Keys.Contains(domainClassId))
                        dictionary.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionary[domainClassId].Keys.Contains(elementId))
                        dictionary[domainClassId].Add(elementId, new List<IEventSubscription>());
                    dictionary[domainClassId][elementId].Add(subscription);

                }
            }
        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public override void Publish(RolePlayerOrderChangedEventArgs payload)
        {
            base.Publish(payload);

            List<Action<object[]>> executionStrategies = PruneAndReturnStrategies(payload);
            foreach (var executionStrategy in executionStrategies)
            {
                executionStrategy(new object[] { payload });
            }
        }

        /// <summary>
        /// Evaluates the given payload and retrieves active subscribers.
        /// </summary>
        /// <param name="args">Payload, that is beeing published.</param>
        /// <returns>List of actions to call.</returns>
        private List<Action<object[]>> PruneAndReturnStrategies(RolePlayerOrderChangedEventArgs args)
        {
            List<Action<object[]>> returnList = new List<Action<object[]>>();

            #region dictionaryOnElementId
            lock (dictionaryOnElementId)
            {
                Guid id = args.ElementId;
                if (dictionaryOnElementId.Keys.Contains(id))
                {
                    List<IEventSubscription> subscriptions = dictionaryOnElementId[id];
                    for (var i = subscriptions.Count - 1; i >= 0; i--)
                    {
                        Action<object[]> listItem = subscriptions[i].GetExecutionStrategy();
                        if (listItem == null)
                        {
                            // Prune from main list. Log?
                            subscriptions.RemoveAt(i);
                        }
                        else
                        {
                            returnList.Add(listItem);
                        }
                    }

                    if (subscriptions.Count == 0)
                        dictionaryOnElementId.Remove(id);
                }
            }
            #endregion

            #region dictionary
            lock (dictionary)
            {
                Guid domainClassId = args.DomainClass.Id;
                Guid rolePlayer = args.SourceElementId;
                if (dictionary.Keys.Contains(domainClassId))
                {
                    if (dictionary[domainClassId].Keys.Contains(rolePlayer))
                    {

                        List<IEventSubscription> subscriptions = dictionary[domainClassId][rolePlayer];
                        for (var i = subscriptions.Count - 1; i >= 0; i--)
                        {
                            Action<object[]> listItem = subscriptions[i].GetExecutionStrategy();
                            if (listItem == null)
                            {
                                // Prune from main list. Log?
                                subscriptions.RemoveAt(i);
                            }
                            else
                            {
                                returnList.Add(listItem);
                            }
                        }

                        if (subscriptions.Count == 0)
                            dictionary[domainClassId].Remove(rolePlayer);
                    }

                    if (dictionary[domainClassId].Count == 0)
                        dictionary.Remove(domainClassId);
                }

                // continue with descendants
                foreach (DomainRelationshipInfo relInfo in args.DomainClass.AllDescendants)
                {
                    domainClassId = relInfo.Id;
                    if (dictionary.Keys.Contains(domainClassId))
                    {
                        if (dictionary[domainClassId].Keys.Contains(rolePlayer))
                        {

                            List<IEventSubscription> subscriptions = dictionary[domainClassId][rolePlayer];
                            for (var i = subscriptions.Count - 1; i >= 0; i--)
                            {
                                Action<object[]> listItem = subscriptions[i].GetExecutionStrategy();
                                if (listItem == null)
                                {
                                    // Prune from main list. Log?
                                    subscriptions.RemoveAt(i);
                                }
                                else
                                {
                                    returnList.Add(listItem);
                                }
                            }

                            if (subscriptions.Count == 0)
                                dictionary[domainClassId].Remove(rolePlayer);
                        }

                        if (dictionary[domainClassId].Count == 0)
                            dictionary.Remove(domainClassId);
                    }
                }
            }
            #endregion

            return returnList;
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="elementId">Model element id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(Guid elementId, Action<RolePlayerOrderChangedEventArgs> action)
        {
            lock (dictionaryOnElementId)
            {
                if (dictionaryOnElementId.Keys.Contains(elementId))
                {
                    IEventSubscription eventSubscription = dictionaryOnElementId[elementId].Cast<EventSubscription<RolePlayerOrderChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                    if (eventSubscription != null)
                    {
                        dictionaryOnElementId[elementId].Remove(eventSubscription);
                        if (dictionaryOnElementId[elementId].Count == 0)
                            dictionaryOnElementId.Remove(elementId);
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainRelationshipInfo">Domain relationship info specifying when to unsubscribe.</param>
        /// <param name="elementId">Role player id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainRelationshipInfo domainRelationshipInfo, Guid elementId, Action<RolePlayerOrderChangedEventArgs> action)
        {

            lock (dictionary)
            {
                Guid domainClassId = domainRelationshipInfo.Id;
                if (dictionary.Keys.Contains(domainClassId))
                {
                    if (dictionary[domainClassId].Keys.Contains(elementId))
                    {
                        IEventSubscription eventSubscription = dictionary[domainClassId][elementId].Cast<EventSubscription<RolePlayerOrderChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionary[domainClassId][elementId].Remove(eventSubscription);
                            if (dictionary[domainClassId][elementId].Count == 0)
                                dictionary[domainClassId].Remove(elementId);
                        }
                        if (dictionary[domainClassId].Count == 0)
                            dictionary.Remove(domainClassId);
                    }
                }

                // process descendants
                foreach (DomainRelationshipInfo info in domainRelationshipInfo.AllDescendants)
                {
                    domainClassId = info.Id;
                    if (dictionary.Keys.Contains(domainClassId))
                    {
                        if (dictionary[domainClassId].Keys.Contains(elementId))
                        {
                            IEventSubscription eventSubscription = dictionary[domainClassId][elementId].Cast<EventSubscription<RolePlayerOrderChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionary[domainClassId][elementId].Remove(eventSubscription);
                                if (dictionary[domainClassId][elementId].Count == 0)
                                    dictionary[domainClassId].Remove(elementId);
                            }
                            if (dictionary[domainClassId].Count == 0)
                                dictionary.Remove(domainClassId);
                        }
                    }
                }
            }
        }
    }
}

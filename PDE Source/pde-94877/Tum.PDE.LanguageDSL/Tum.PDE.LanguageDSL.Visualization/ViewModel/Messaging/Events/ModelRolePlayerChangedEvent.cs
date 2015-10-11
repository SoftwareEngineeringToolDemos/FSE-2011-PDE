using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies that a model role player has been changed in the domain model.
    /// </summary>
    /// <remarks>
    /// These events are treated as a weak events.
    /// </remarks>
    public class ModelRolePlayerChangedEvent : ModelElementEvent<RolePlayerChangedEventArgs>
    {
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionaryOnElementId = new Dictionary<Guid, List<IEventSubscription>>();
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionaryOnRoleInfo = new Dictionary<Guid, List<IEventSubscription>>();
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionaryOnRoleInfoElementId = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();

        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionarySource = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionaryTarget = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();

        /// <summary>
        /// Subscribes to the role player changed event. Observers are notified, whenever role player changes on a
        /// specific model element.
        /// </summary>
        /// <param name="elementId">Id of the model element, on which role player changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(Guid elementId, Action<RolePlayerChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<RolePlayerChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<RolePlayerChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnElementId)
            {
                if (!dictionaryOnElementId.Keys.Contains(elementId))
                    dictionaryOnElementId.Add(elementId, new List<IEventSubscription>());

                dictionaryOnElementId[elementId].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the property changed event. Observers are notified, whenever a role of a specific type
        /// changes.
        /// </summary>
        /// <param name="domainRoleInfo">Role info specifying a role type, which changes cause a notification.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainRoleInfo domainRoleInfo, Action<RolePlayerChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<RolePlayerChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<RolePlayerChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnRoleInfo)
            {
                if (!dictionaryOnRoleInfo.Keys.Contains(domainRoleInfo.Id))
                    dictionaryOnRoleInfo.Add(domainRoleInfo.Id, new List<IEventSubscription>());

                dictionaryOnRoleInfo[domainRoleInfo.Id].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the role player changed event. Observers are notified, whenever a role of a certain type
        /// changes on a specific element link.
        /// </summary>
        /// <param name="domainRoleInfo">Role info specifying a role type, which changes cause a notification.</param>
        /// <param name="elementLinkId">Id of the link, on which role changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainRoleInfo domainRoleInfo, Guid elementLinkId, Action<RolePlayerChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<RolePlayerChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<RolePlayerChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnRoleInfoElementId)
            {
                if (!dictionaryOnRoleInfoElementId.Keys.Contains(domainRoleInfo.Id))
                    dictionaryOnRoleInfoElementId.Add(domainRoleInfo.Id, new Dictionary<Guid, List<IEventSubscription>>());

                if (!dictionaryOnRoleInfoElementId[domainRoleInfo.Id].Keys.Contains(elementLinkId))
                    dictionaryOnRoleInfoElementId[domainRoleInfo.Id].Add(elementLinkId, new List<IEventSubscription>());

                dictionaryOnRoleInfoElementId[domainRoleInfo.Id][elementLinkId].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the role player changed event.
        /// </summary>
        /// <param name="domainRelationshipInfo">RelationshipInfo, which changes cause a notification.</param>
        /// <param name="bSourceRole"></param>
        /// <param name="elementId">Id of the role player, on which role changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainRelationshipInfo domainRelationshipInfo, bool bSourceRole, Guid elementId, Action<RolePlayerChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<RolePlayerChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<RolePlayerChangedEventArgs>(actionReference, filterReference);

            #region dictionarySource
            if (bSourceRole)
                lock (dictionarySource)
                {
                    Guid domainClassId = domainRelationshipInfo.Id;

                    if (!dictionarySource.Keys.Contains(domainClassId))
                        dictionarySource.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionarySource[domainClassId].Keys.Contains(elementId))
                        dictionarySource[domainClassId].Add(elementId, new List<IEventSubscription>());
                    dictionarySource[domainClassId][elementId].Add(subscription);

                    // process descendants
                    foreach (DomainClassInfo info in domainRelationshipInfo.AllDescendants)
                    {
                        domainClassId = info.Id;

                        if (!dictionarySource.Keys.Contains(domainClassId))
                            dictionarySource.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                        if (!dictionarySource[domainClassId].Keys.Contains(elementId))
                            dictionarySource[domainClassId].Add(elementId, new List<IEventSubscription>());
                        dictionarySource[domainClassId][elementId].Add(subscription);

                    }
                }
            #endregion

            #region dictionaryTarget
            if (!bSourceRole)
                lock (dictionaryTarget)
                {
                    Guid domainClassId = domainRelationshipInfo.Id;

                    if (!dictionaryTarget.Keys.Contains(domainClassId))
                        dictionaryTarget.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionaryTarget[domainClassId].Keys.Contains(elementId))
                        dictionaryTarget[domainClassId].Add(elementId, new List<IEventSubscription>());
                    dictionaryTarget[domainClassId][elementId].Add(subscription);

                    // process descendants
                    foreach (DomainClassInfo info in domainRelationshipInfo.AllDescendants)
                    {
                        domainClassId = info.Id;

                        if (!dictionaryTarget.Keys.Contains(domainClassId))
                            dictionaryTarget.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                        if (!dictionaryTarget[domainClassId].Keys.Contains(elementId))
                            dictionaryTarget[domainClassId].Add(elementId, new List<IEventSubscription>());
                        dictionaryTarget[domainClassId][elementId].Add(subscription);

                    }
                }
            #endregion
        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public override void Publish(RolePlayerChangedEventArgs payload)
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
        private List<Action<object[]>> PruneAndReturnStrategies(RolePlayerChangedEventArgs args)
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

            #region dictionaryOnRoleInfo
            lock (dictionaryOnRoleInfo)
            {
                if (dictionaryOnRoleInfo.Keys.Contains(args.DomainRole.Id))
                {
                    List<IEventSubscription> subscriptions = dictionaryOnRoleInfo[args.DomainRole.Id];
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
                        dictionaryOnRoleInfo.Remove(args.DomainRole.Id);
                }
            }
            #endregion

            #region dictionaryOnRoleInfoElementId
            lock (dictionaryOnRoleInfoElementId)
            {
                if (dictionaryOnRoleInfoElementId.Keys.Contains(args.DomainRole.Id))
                    if (dictionaryOnRoleInfoElementId[args.DomainRole.Id].Keys.Contains(args.ElementLinkId))
                    {
                        List<IEventSubscription> subscriptions = dictionaryOnRoleInfoElementId[args.DomainRole.Id][args.ElementLinkId];
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
                        {
                            dictionaryOnRoleInfoElementId[args.DomainRole.Id].Remove(args.ElementLinkId);
                            if (dictionaryOnRoleInfoElementId[args.DomainRole.Id].Count == 0)
                                dictionaryOnRoleInfoElementId.Remove(args.DomainRole.Id);
                        }
                    }
            }
            #endregion

            if( args.OldRolePlayer != null )
                PruneAndReturnStrategiesForRolePlayers(returnList, args, args.OldRolePlayerId);

            if( args.NewRolePlayer != null )
                PruneAndReturnStrategiesForRolePlayers(returnList, args, args.NewRolePlayerId);

            return returnList;
        }
        private void PruneAndReturnStrategiesForRolePlayers(List<Action<object[]>> returnList, RolePlayerChangedEventArgs args, Guid rolePlayer)
        {
            #region dictionarySource
            lock (dictionarySource)
            {
                Guid domainClassId = args.DomainClass.Id;
                if (dictionarySource.Keys.Contains(domainClassId))
                {
                    if (dictionarySource[domainClassId].Keys.Contains(rolePlayer))
                    {

                        List<IEventSubscription> subscriptions = dictionarySource[domainClassId][rolePlayer];
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
                            dictionarySource[domainClassId].Remove(rolePlayer);
                    }

                    if (dictionarySource[domainClassId].Count == 0)
                        dictionarySource.Remove(domainClassId);
                }

                // continue with descendants
                foreach (DomainRelationshipInfo relInfo in args.DomainClass.AllDescendants)
                {
                    domainClassId = relInfo.Id;
                    if (dictionarySource.Keys.Contains(domainClassId))
                    {
                        if (dictionarySource[domainClassId].Keys.Contains(rolePlayer))
                        {

                            List<IEventSubscription> subscriptions = dictionarySource[domainClassId][rolePlayer];
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
                                dictionarySource[domainClassId].Remove(rolePlayer);
                        }

                        if (dictionarySource[domainClassId].Count == 0)
                            dictionarySource.Remove(domainClassId);
                    }
                }
            }
            #endregion

            #region dictionaryTarget
            lock (dictionaryTarget)
            {
                Guid domainClassId = args.DomainClass.Id;
                if (dictionaryTarget.Keys.Contains(domainClassId))
                {
                    if (dictionaryTarget[domainClassId].Keys.Contains(rolePlayer))
                    {

                        List<IEventSubscription> subscriptions = dictionaryTarget[domainClassId][rolePlayer];
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
                            dictionaryTarget[domainClassId].Remove(rolePlayer);
                    }

                    if (dictionaryTarget[domainClassId].Count == 0)
                        dictionaryTarget.Remove(domainClassId);
                }

                // continue with descendants
                foreach (DomainRelationshipInfo relInfo in args.DomainClass.AllDescendants)
                {
                    domainClassId = relInfo.Id;
                    if (dictionaryTarget.Keys.Contains(domainClassId))
                    {
                        if (dictionaryTarget[domainClassId].Keys.Contains(rolePlayer))
                        {

                            List<IEventSubscription> subscriptions = dictionaryTarget[domainClassId][rolePlayer];
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
                                dictionaryTarget[domainClassId].Remove(rolePlayer);
                        }

                        if (dictionaryTarget[domainClassId].Count == 0)
                            dictionaryTarget.Remove(domainClassId);
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="elementId">Model element id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(Guid elementId, Action<RolePlayerChangedEventArgs> action)
        {
            lock (dictionaryOnElementId)
            {
                if (dictionaryOnElementId.Keys.Contains(elementId))
                {
                    IEventSubscription eventSubscription = dictionaryOnElementId[elementId].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
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
        /// <param name="domainRoleInfo">Domain role info specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainRoleInfo domainRoleInfo, Action<RolePlayerChangedEventArgs> action)
        {
            lock (dictionaryOnRoleInfo)
            {
                if (dictionaryOnRoleInfo.Keys.Contains(domainRoleInfo.Id))
                {
                    IEventSubscription eventSubscription = dictionaryOnRoleInfo[domainRoleInfo.Id].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                    if (eventSubscription != null)
                    {
                        dictionaryOnRoleInfo[domainRoleInfo.Id].Remove(eventSubscription);
                        if (dictionaryOnRoleInfo[domainRoleInfo.Id].Count == 0)
                            dictionaryOnRoleInfo.Remove(domainRoleInfo.Id);
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainRoleInfo">Domain role info specifying when to unsubscribe.</param>
        /// <param name="elementLinkId">Link id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainRoleInfo domainRoleInfo, Guid elementLinkId, Action<RolePlayerChangedEventArgs> action)
        {
            lock (dictionaryOnRoleInfoElementId)
            {
                if (dictionaryOnRoleInfoElementId.Keys.Contains(domainRoleInfo.Id))
                {
                    if (dictionaryOnRoleInfoElementId[domainRoleInfo.Id].Keys.Contains(elementLinkId))
                    {
                        IEventSubscription eventSubscription = dictionaryOnRoleInfoElementId[domainRoleInfo.Id][elementLinkId].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionaryOnRoleInfoElementId[domainRoleInfo.Id][elementLinkId].Remove(eventSubscription);
                            if (dictionaryOnRoleInfoElementId[domainRoleInfo.Id][elementLinkId].Count == 0)
                                dictionaryOnRoleInfoElementId[domainRoleInfo.Id].Remove(elementLinkId);
                            if (dictionaryOnRoleInfoElementId[domainRoleInfo.Id].Count == 0)
                                dictionaryOnRoleInfoElementId.Remove(domainRoleInfo.Id);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainRelationshipInfo">Domain relationship info specifying when to unsubscribe.</param>
        /// <param name="bSourceRole"></param>
        /// <param name="elementId">Role player id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainRelationshipInfo domainRelationshipInfo, bool bSourceRole, Guid elementId, Action<RolePlayerChangedEventArgs> action)
        {
            #region dictionarySource
            if (bSourceRole)
                lock (dictionarySource)
                {
                    Guid domainClassId = domainRelationshipInfo.Id;
                    if (dictionarySource.Keys.Contains(domainClassId))
                    {
                        if (dictionarySource[domainClassId].Keys.Contains(elementId))
                        {
                            IEventSubscription eventSubscription = dictionarySource[domainClassId][elementId].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionarySource[domainClassId][elementId].Remove(eventSubscription);
                                if (dictionarySource[domainClassId][elementId].Count == 0)
                                    dictionarySource[domainClassId].Remove(elementId);
                            }
                            if (dictionarySource[domainClassId].Count == 0)
                                dictionarySource.Remove(domainClassId);
                        }
                    }

                    // process descendants
                    foreach (DomainRelationshipInfo info in domainRelationshipInfo.AllDescendants)
                    {
                        domainClassId = info.Id;
                        if (dictionarySource.Keys.Contains(domainClassId))
                        {
                            if (dictionarySource[domainClassId].Keys.Contains(elementId))
                            {
                                IEventSubscription eventSubscription = dictionarySource[domainClassId][elementId].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                                if (eventSubscription != null)
                                {
                                    dictionarySource[domainClassId][elementId].Remove(eventSubscription);
                                    if (dictionarySource[domainClassId][elementId].Count == 0)
                                        dictionarySource[domainClassId].Remove(elementId);
                                }
                                if (dictionarySource[domainClassId].Count == 0)
                                    dictionarySource.Remove(domainClassId);
                            }
                        }
                    }
                }
            #endregion

            #region dictionaryTarget
            if (!bSourceRole)
                lock (dictionaryTarget)
                {
                    Guid domainClassId = domainRelationshipInfo.Id;
                    if (dictionaryTarget.Keys.Contains(domainClassId))
                    {
                        if (dictionaryTarget[domainClassId].Keys.Contains(elementId))
                        {
                            IEventSubscription eventSubscription = dictionaryTarget[domainClassId][elementId].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionaryTarget[domainClassId][elementId].Remove(eventSubscription);
                                if (dictionaryTarget[domainClassId][elementId].Count == 0)
                                    dictionaryTarget[domainClassId].Remove(elementId);
                            }
                            if (dictionaryTarget[domainClassId].Count == 0)
                                dictionaryTarget.Remove(domainClassId);
                        }
                    }

                    // process descendants
                    foreach (DomainRelationshipInfo info in domainRelationshipInfo.AllDescendants)
                    {
                        domainClassId = info.Id;
                        if (dictionaryTarget.Keys.Contains(domainClassId))
                        {
                            if (dictionaryTarget[domainClassId].Keys.Contains(elementId))
                            {
                                IEventSubscription eventSubscription = dictionaryTarget[domainClassId][elementId].Cast<EventSubscription<RolePlayerChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                                if (eventSubscription != null)
                                {
                                    dictionaryTarget[domainClassId][elementId].Remove(eventSubscription);
                                    if (dictionaryTarget[domainClassId][elementId].Count == 0)
                                        dictionaryTarget[domainClassId].Remove(elementId);
                                }
                                if (dictionaryTarget[domainClassId].Count == 0)
                                    dictionaryTarget.Remove(domainClassId);
                            }
                        }
                    }
                }
            #endregion
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies that a model element's property value has changed. There are multiple subscription possibilities
    /// available, which allow to subscribe to specific changes.
    /// </summary>
    /// <remarks>
    /// These events are treated as a weak events.
    /// </remarks>
    public class ModelElementPropertyChangedEvent : ModelElementEvent<ElementPropertyChangedEventArgs>
    {
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionaryOnElementId = new Dictionary<Guid, List<IEventSubscription>>();
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionaryOnPropertyInfo = new Dictionary<Guid, List<IEventSubscription>>();
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionaryOnPropertyInfoElementId = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionaryOnClassInfoPropertyInfo = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();

        /// <summary>
        /// Subscribes to the property changed event. Observers are notified, whenever a property changes on a
        /// specific model element.
        /// </summary>
        /// <param name="elementId">Id of the model element, on which property changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(Guid elementId, Action<ElementPropertyChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementPropertyChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementPropertyChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnElementId)
            {
                if (!dictionaryOnElementId.Keys.Contains(elementId))
                    dictionaryOnElementId.Add(elementId, new List<IEventSubscription>());

                dictionaryOnElementId[elementId].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the property changed event. Observers are notified, whenever a property of a specific type
        /// changes.
        /// </summary>
        /// <param name="domainPropertyInfo">Property info specifying a property type, which changes cause a notification.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainPropertyInfo domainPropertyInfo, Action<ElementPropertyChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementPropertyChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementPropertyChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnPropertyInfo)
            {
                if (!dictionaryOnPropertyInfo.Keys.Contains(domainPropertyInfo.Id))
                    dictionaryOnPropertyInfo.Add(domainPropertyInfo.Id, new List<IEventSubscription>());

                dictionaryOnPropertyInfo[domainPropertyInfo.Id].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the property changed event. Observers are notified, whenever a property type on a specific 
        /// element changes.
        /// </summary>
        /// <param name="domainPropertyInfo">Property info specifying a property type, which changes cause a notification.</param>
        /// <param name="elementId">Id of the model element, on which property changes to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainPropertyInfo domainPropertyInfo, Guid elementId, Action<ElementPropertyChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementPropertyChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementPropertyChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnPropertyInfoElementId)
            {
                if (!dictionaryOnPropertyInfoElementId.Keys.Contains(domainPropertyInfo.Id))
                    dictionaryOnPropertyInfoElementId.Add(domainPropertyInfo.Id, new Dictionary<Guid, List<IEventSubscription>>());

                if (!dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id].Keys.Contains(elementId))
                    dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id].Add(elementId, new List<IEventSubscription>());

                dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id][elementId].Add(subscription);
            }
        }

        /// <summary>
        /// Subscribes to the property changed event. Observers are notified, whenever a property of a specific type
        /// changes on a model element of a specific type.
        /// </summary>
        /// <param name="domainPropertyInfo">Property info specifying a property type, which changes cause a notification.</param>
        /// <param name="domainClassInfo">
        /// Domain class info specifying the type of model element, which property changes cause a notification (All derived
        /// model element types are included).
        /// </param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainClassInfo domainClassInfo, DomainPropertyInfo domainPropertyInfo, Action<ElementPropertyChangedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementPropertyChangedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementPropertyChangedEventArgs>(actionReference, filterReference);
            lock (dictionaryOnClassInfoPropertyInfo)
            {
                Guid domainClassId = domainClassInfo.Id;
                Guid domainPropertyId = domainPropertyInfo.Id;

                if (!dictionaryOnClassInfoPropertyInfo.Keys.Contains(domainClassId))
                    dictionaryOnClassInfoPropertyInfo.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                if (!dictionaryOnClassInfoPropertyInfo[domainClassId].Keys.Contains(domainPropertyId))
                    dictionaryOnClassInfoPropertyInfo[domainClassId].Add(domainPropertyId, new List<IEventSubscription>());

                dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Add(subscription);

                // continue with descendants
                foreach (DomainClassInfo info in domainClassInfo.AllDescendants)
                {
                    domainClassId = info.Id;

                    if (!dictionaryOnClassInfoPropertyInfo.Keys.Contains(domainClassId))
                        dictionaryOnClassInfoPropertyInfo.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionaryOnClassInfoPropertyInfo[domainClassId].Keys.Contains(domainPropertyId))
                        dictionaryOnClassInfoPropertyInfo[domainClassId].Add(domainPropertyId, new List<IEventSubscription>());

                    dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Add(subscription);
                }
            }
        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public override void Publish(ElementPropertyChangedEventArgs payload)
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
        private List<Action<object[]>> PruneAndReturnStrategies(ElementPropertyChangedEventArgs args)
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

            #region dictionaryOnPropertyInfo
            lock (dictionaryOnPropertyInfo)
            {
                if (dictionaryOnPropertyInfo.Keys.Contains(args.DomainProperty.Id))
                {
                    List<IEventSubscription> subscriptions = dictionaryOnPropertyInfo[args.DomainProperty.Id];
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
                        dictionaryOnPropertyInfo.Remove(args.DomainProperty.Id);
                }
            }
            #endregion

            #region dictionaryOnPropertyInfoElementId
            lock (dictionaryOnPropertyInfoElementId)
            {
                if (dictionaryOnPropertyInfoElementId.Keys.Contains(args.DomainProperty.Id))
                    if (dictionaryOnPropertyInfoElementId[args.DomainProperty.Id].Keys.Contains(args.ElementId))
                {
                    List<IEventSubscription> subscriptions = dictionaryOnPropertyInfoElementId[args.DomainProperty.Id][args.ElementId];
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
                        dictionaryOnPropertyInfoElementId[args.DomainProperty.Id].Remove(args.ElementId);
                        if (dictionaryOnPropertyInfoElementId[args.DomainProperty.Id].Count == 0)
                            dictionaryOnPropertyInfoElementId.Remove(args.DomainProperty.Id);
                    }
                }
            }
            #endregion

            #region dictionaryOnClassInfoPropertyInfo
            lock (dictionaryOnClassInfoPropertyInfo)
            {
                Guid domainClassId = args.DomainClass.Id;
                Guid domainPropertyId = args.DomainProperty.Id;

                if (dictionaryOnClassInfoPropertyInfo.Keys.Contains(domainClassId))
                    if (dictionaryOnClassInfoPropertyInfo[domainClassId].Keys.Contains(domainPropertyId))
                    {
                        List<IEventSubscription> subscriptions = dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId];
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
                            dictionaryOnClassInfoPropertyInfo[domainClassId].Remove(domainPropertyId);
                            if (dictionaryOnClassInfoPropertyInfo[domainClassId].Count == 0)
                                dictionaryOnClassInfoPropertyInfo.Remove(domainClassId);
                        }
                    }

                // continue with descendants
                foreach (DomainClassInfo info in args.DomainClass.AllDescendants)
                {
                    domainClassId = info.Id;

                    if (dictionaryOnClassInfoPropertyInfo.Keys.Contains(domainClassId))
                        if (dictionaryOnClassInfoPropertyInfo[domainClassId].Keys.Contains(domainPropertyId))
                        {
                            List<IEventSubscription> subscriptions = dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId];
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
                                dictionaryOnClassInfoPropertyInfo[domainClassId].Remove(domainPropertyId);
                                if (dictionaryOnClassInfoPropertyInfo[domainClassId].Count == 0)
                                    dictionaryOnClassInfoPropertyInfo.Remove(domainClassId);
                            }
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
        public void Unsubscribe(Guid elementId, Action<ElementPropertyChangedEventArgs> action)
        {
            lock (dictionaryOnElementId)
            {
                if (dictionaryOnElementId.Keys.Contains(elementId))
                {
                    IEventSubscription eventSubscription = dictionaryOnElementId[elementId].Cast<EventSubscription<ElementPropertyChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
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
        /// <param name="domainPropertyInfo">Domain property info specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainPropertyInfo domainPropertyInfo, Action<ElementPropertyChangedEventArgs> action)
        {
            lock (dictionaryOnPropertyInfo)
            {
                if (dictionaryOnPropertyInfo.Keys.Contains(domainPropertyInfo.Id))
                {
                    IEventSubscription eventSubscription = dictionaryOnPropertyInfo[domainPropertyInfo.Id].Cast<EventSubscription<ElementPropertyChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                    if (eventSubscription != null)
                    {
                        dictionaryOnPropertyInfo[domainPropertyInfo.Id].Remove(eventSubscription);
                        if (dictionaryOnPropertyInfo[domainPropertyInfo.Id].Count == 0)
                            dictionaryOnPropertyInfo.Remove(domainPropertyInfo.Id);
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainPropertyInfo">Domain property info specifying when to unsubscribe.</param>
        /// <param name="elementId">Model element id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainPropertyInfo domainPropertyInfo, Guid elementId, Action<ElementPropertyChangedEventArgs> action)
        {
            lock (dictionaryOnPropertyInfoElementId)
            {
                if (dictionaryOnPropertyInfoElementId.Keys.Contains(domainPropertyInfo.Id))
                {
                    if (dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id].Keys.Contains(elementId))
                    {
                        IEventSubscription eventSubscription = dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id][elementId].Cast<EventSubscription<ElementPropertyChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id][elementId].Remove(eventSubscription);
                            if (dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id][elementId].Count == 0)
                                dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id].Remove(elementId);
                            if (dictionaryOnPropertyInfoElementId[domainPropertyInfo.Id].Count == 0)
                                dictionaryOnPropertyInfoElementId.Remove(domainPropertyInfo.Id);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainClassInfo">Domain class info specifying when to unsubscribe.</param>
        /// <param name="domainPropertyInfo">Domain property info specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainClassInfo domainClassInfo, DomainPropertyInfo domainPropertyInfo, Action<ElementPropertyChangedEventArgs> action)
        {
            lock (dictionaryOnClassInfoPropertyInfo)
            {
                Guid domainClassId = domainClassInfo.Id;
                Guid domainPropertyId = domainPropertyInfo.Id;

                if (dictionaryOnClassInfoPropertyInfo.Keys.Contains(domainClassId))
                {
                    if (dictionaryOnClassInfoPropertyInfo[domainClassId].Keys.Contains(domainPropertyId))
                    {
                        IEventSubscription eventSubscription = dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Cast<EventSubscription<ElementPropertyChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Remove(eventSubscription);
                            if (dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Count == 0)
                                dictionaryOnClassInfoPropertyInfo[domainClassId].Remove(domainPropertyId);
                            if (dictionaryOnClassInfoPropertyInfo[domainClassId].Count == 0)
                                dictionaryOnClassInfoPropertyInfo.Remove(domainClassId);
                        }
                    }
                }

                // continue with descendants
                foreach (DomainClassInfo info in domainClassInfo.AllDescendants)
                {
                    domainClassId = info.Id;
                    if (dictionaryOnClassInfoPropertyInfo.Keys.Contains(domainClassId))
                    {
                        if (dictionaryOnClassInfoPropertyInfo[domainClassId].Keys.Contains(domainPropertyId))
                        {
                            IEventSubscription eventSubscription = dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Cast<EventSubscription<ElementPropertyChangedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Remove(eventSubscription);
                                if (dictionaryOnClassInfoPropertyInfo[domainClassId][domainPropertyId].Count == 0)
                                    dictionaryOnClassInfoPropertyInfo[domainClassId].Remove(domainPropertyId);
                                if (dictionaryOnClassInfoPropertyInfo[domainClassId].Count == 0)
                                    dictionaryOnClassInfoPropertyInfo.Remove(domainClassId);
                            }
                        }
                    }
                }
            }
        }
    }
}

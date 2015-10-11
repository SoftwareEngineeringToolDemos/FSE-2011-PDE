using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Base model element event class, which includes notifications based on DomainClassInfo.
    /// </summary>
    /// <typeparam name="T">Needs to be derived from ElementEventArgs.</typeparam>
    public abstract class ModelElementEvent<T> : ViewModelEvent<T>
        where T : GenericEventArgs
    {
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionary = new Dictionary<Guid, List<IEventSubscription>>();

        /// <summary>
        /// Subscribe to the event. The observer will be notified, whenever a model element of
        /// the given domain class type (which does include all descendants) is included in the
        /// specific event.
        /// </summary>
        /// <param name="domainClassInfo">DomainClassInfo specifying when to notify the observer.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainClassInfo domainClassInfo, Action<T> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<T>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<T>(actionReference, filterReference);

            lock (dictionary)
            {
                Guid domainClassId = domainClassInfo.Id;

                if (!dictionary.Keys.Contains(domainClassId))
                    dictionary.Add(domainClassId, new List<IEventSubscription>());

                dictionary[domainClassId].Add(subscription);

                // process descendants
                foreach (DomainClassInfo info in domainClassInfo.AllDescendants)
                {
                    domainClassId = info.Id;

                    if (!dictionary.Keys.Contains(domainClassId))
                        dictionary.Add(domainClassId, new List<IEventSubscription>());

                    dictionary[domainClassId].Add(subscription);
                }
            }

        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public override void Publish(T payload)
        {
            base.Publish(payload);

            List<Action<object[]>> executionStrategies = PruneAndReturnStrategies(payload as GenericEventArgs);
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
        private List<Action<object[]>> PruneAndReturnStrategies(GenericEventArgs args)
        {
            List<Action<object[]>> returnList = new List<Action<object[]>>();
            lock (dictionary)
            {
                Guid domainClassId = args.DomainClass.Id;
                if (dictionary.Keys.Contains(domainClassId))
                {
                    List<IEventSubscription> subscriptions = dictionary[domainClassId];
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
                        dictionary.Remove(domainClassId);
                }

                // continue with descendants
                foreach (DomainClassInfo info in args.DomainClass.AllDescendants)
                {
                    domainClassId = info.Id;
                    if (dictionary.Keys.Contains(domainClassId))
                    {
                        List<IEventSubscription> subscriptions = dictionary[domainClassId];
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
                            dictionary.Remove(domainClassId);
                    }
                }
            }

            return returnList;
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainClassInfo">DomainClassInfo specifying from what to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainClassInfo domainClassInfo, Action<T> action)
        {
            lock (dictionary)
            {
                Guid domainClassId = domainClassInfo.Id;
                if (dictionary.Keys.Contains(domainClassId))
                {
                    IEventSubscription eventSubscription = dictionary[domainClassId].Cast<EventSubscription<T>>().FirstOrDefault(evt => evt.Action == action);
                    if (eventSubscription != null)
                    {
                        dictionary[domainClassId].Remove(eventSubscription);
                        if (dictionary[domainClassId].Count == 0)
                            dictionary.Remove(domainClassId);
                    }
                }

                // process descendants
                foreach (DomainClassInfo info in domainClassInfo.AllDescendants)
                {
                    domainClassId = info.Id;
                    if (dictionary.Keys.Contains(domainClassId))
                    {
                        IEventSubscription eventSubscription = dictionary[domainClassId].Cast<EventSubscription<T>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionary[domainClassId].Remove(eventSubscription);
                            if (dictionary[domainClassId].Count == 0)
                                dictionary.Remove(domainClassId);
                        }
                    }
                }
            }
        }
    }
}

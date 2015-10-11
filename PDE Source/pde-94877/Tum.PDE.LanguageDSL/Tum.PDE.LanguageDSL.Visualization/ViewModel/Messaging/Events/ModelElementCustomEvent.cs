using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events
{
    public class ModelElementCustomEvent<T> : ViewModelEvent<T>
    {
        private readonly Dictionary<string, Dictionary<Guid, List<IEventSubscription>>> dictionary = new Dictionary<string, Dictionary<Guid, List<IEventSubscription>>>();

        /// <summary>
        /// Subscribe to a specific event. 
        /// <param name="eventName">Name of the event to subscribe to</param>
        /// <param name="elementId">ElementId of the model element, which specifies when to notify the observer.</param>
        /// <param name="action">Action to call on notification.</param>
        public void Subscribe(string eventName, Guid elementId, Action<T> action)
        {
            if( String.IsNullOrEmpty(eventName) )
                throw new ArgumentException("eventName");

            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<T>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<T>(actionReference, filterReference);

            lock (dictionary)
            {
                if (!dictionary.Keys.Contains(eventName))
                    dictionary.Add(eventName, new Dictionary<Guid, List<IEventSubscription>>());

                if (!dictionary[eventName].Keys.Contains(elementId))
                    dictionary[eventName].Add(elementId, new List<IEventSubscription>());
                dictionary[eventName][elementId].Add(subscription);
            }
        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public virtual void Publish(T payload, string eventName, Guid elementId)
        {
            base.Publish(payload);

            List<Action<object[]>> executionStrategies = PruneAndReturnStrategies(payload, eventName, elementId);
            foreach (var executionStrategy in executionStrategies)
            {
                executionStrategy(new object[] { payload });
            }
        }

        /// <summary>
        /// Evaluates the given payload and retrieves active subscribers.
        /// </summary>
        /// <param name="args">Payload, that is beeing published.</param>
        /// <param name="eventName">Event name for which to notify observers.</param>
        /// <param name="elementId">ElementId for which to notify observers.</param>
        /// <returns>List of actions to call.</returns>
        private List<Action<object[]>> PruneAndReturnStrategies(T args, string eventName, Guid elementId)
        {
            List<Action<object[]>> returnList = new List<Action<object[]>>();
            lock (dictionary)
            {
                if (dictionary.Keys.Contains(eventName))
                {
                    if (dictionary[eventName].Keys.Contains(elementId))
                    {

                        List<IEventSubscription> subscriptions = dictionary[eventName][elementId];
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
                            dictionary[eventName].Remove(elementId);
                    }

                    if (dictionary[eventName].Count == 0)
                        dictionary.Remove(eventName);
                }
            }

            return returnList;
        }

        /// <summary>
        /// Unsubscribe to a specific event. 
        /// <param name="eventName">Name of the event to unsubscribe from</param>
        /// <param name="elementId">ElementId specifying what to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(string eventName, Guid elementId, Action<T> action)
        {
            if (String.IsNullOrEmpty(eventName))
                throw new ArgumentException("eventName");

            lock (dictionary)
            {
                if (dictionary.Keys.Contains(eventName))
                {
                    if (dictionary[eventName].Keys.Contains(elementId))
                    {
                        IEventSubscription eventSubscription = dictionary[eventName][elementId].Cast<EventSubscription<T>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionary[eventName][elementId].Remove(eventSubscription);
                            if (dictionary[eventName][elementId].Count == 0)
                                dictionary[eventName].Remove(elementId);
                        }
                        if (dictionary[eventName].Count == 0)
                            dictionary.Remove(eventName);
                    }
                }
            }
        }
    }
}

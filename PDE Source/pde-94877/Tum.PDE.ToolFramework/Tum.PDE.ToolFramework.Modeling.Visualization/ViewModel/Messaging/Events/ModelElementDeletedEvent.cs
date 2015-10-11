using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies that a model element has been deleted from the domain model.
    /// 
    /// Such a notification can either be received for a domain class type (DomainClassInfo) or for
    /// specific domain classes identified by their Ids.
    /// </summary>
    /// <remarks>
    /// These events are treated as a weak events.
    /// </remarks>
    public class ModelElementDeletedEvent : ModelElementEvent<ElementDeletedEventArgs>
    {
        private readonly Dictionary<Guid, List<IEventSubscription>> dictionary = new Dictionary<Guid, List<IEventSubscription>>();

        /// <summary>
        /// Register an observer for a notification, which is fired when the model element with the given Id is deleted from
        /// the domain model.
        /// </summary>
        /// <param name="id">ModelElement Id, specifying when to notify observers.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(Guid id, Action<ElementDeletedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementDeletedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementDeletedEventArgs>(actionReference, filterReference);
            lock (dictionary)
            {
                if (!dictionary.Keys.Contains(id))
                    dictionary.Add(id, new List<IEventSubscription>());

                dictionary[id].Add(subscription);
            }
        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public override void Publish(ElementDeletedEventArgs payload)
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
        private List<Action<object[]>> PruneAndReturnStrategies(ElementDeletedEventArgs args)
        {
            List<Action<object[]>> returnList = new List<Action<object[]>>();
            lock (dictionary)
            {
                Guid id = args.ElementId;
                if (dictionary.Keys.Contains(id))
                {
                    List<IEventSubscription> subscriptions = dictionary[id];
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
                        dictionary.Remove(id);
                }
            }

            return returnList;
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="id">DomainClass id specifying when to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(Guid id, Action<ElementDeletedEventArgs> action)
        {
            lock (dictionary)
            {
                if (dictionary.Keys.Contains(id))
                {
                    IEventSubscription eventSubscription = dictionary[id].Cast<EventSubscription<ElementDeletedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                    if (eventSubscription != null)
                    {
                        dictionary[id].Remove(eventSubscription);
                        if (dictionary[id].Count == 0)
                            dictionary.Remove(id);
                    }
                }
            }
        }
    }
}

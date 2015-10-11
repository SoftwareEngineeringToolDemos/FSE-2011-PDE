using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Prism;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.ViewModel.Messaging.Events
{
    /// <summary>
    /// Notifies of a new element link beeing added to the domain model.
    /// 
    /// An observer can either subscribe to the event in general (Warning, this will provide a notification for each 
    /// new domain element) or subscribe to a more specific event.
    /// 
    /// This specific event allows to provide a domain class info of the model element, on which addition the
    /// given action is called (for alle other elements, the action is ignored).
    /// </summary>
    /// <remarks>
    /// These events are treated as a weak events.
    /// </remarks>
    public class ModelElementLinkAddedEvent : ModelElementEvent<ElementAddedEventArgs>
    {
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionarySource = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();
        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionaryTarget = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();

        private readonly Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>> dictionaryById = new Dictionary<Guid, Dictionary<Guid, List<IEventSubscription>>>();

        /// <summary>
        /// Subscribe to the event. The observer will be notified, whenever a element link of
        /// the given domain relationship type (which does include all descendants) with the specified 
        /// parent element is included in the specific event. 
        /// </summary>
        /// <param name="domainRelationshipInfo">DomainRelationshipInfo specifying when to notify the observer.</param>
        /// <param name="bSourceRole">Boolean value indicating source or target role.</param>
        /// <param name="parentElementId">ElementId of the parent element specifying when to notify.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainRelationshipInfo domainRelationshipInfo, bool bSourceRole, Guid parentElementId, Action<ElementAddedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementAddedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementAddedEventArgs>(actionReference, filterReference);

            #region dictionarySource
            if( bSourceRole )
                lock (dictionarySource)
                {
                    Guid domainClassId = domainRelationshipInfo.Id;

                    if (!dictionarySource.Keys.Contains(domainClassId))
                        dictionarySource.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionarySource[domainClassId].Keys.Contains(parentElementId))
                        dictionarySource[domainClassId].Add(parentElementId, new List<IEventSubscription>());
                    dictionarySource[domainClassId][parentElementId].Add(subscription);

                    // process descendants
                    foreach (DomainClassInfo info in domainRelationshipInfo.AllDescendants)
                    {
                        domainClassId = info.Id;

                        if (!dictionarySource.Keys.Contains(domainClassId))
                            dictionarySource.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                        if (!dictionarySource[domainClassId].Keys.Contains(parentElementId))
                            dictionarySource[domainClassId].Add(parentElementId, new List<IEventSubscription>());
                        dictionarySource[domainClassId][parentElementId].Add(subscription);

                    }
                }
            #endregion

            #region dictionaryTarget
            if( !bSourceRole )
                lock (dictionaryTarget)
                {
                    Guid domainClassId = domainRelationshipInfo.Id;

                    if (!dictionaryTarget.Keys.Contains(domainClassId))
                        dictionaryTarget.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionaryTarget[domainClassId].Keys.Contains(parentElementId))
                        dictionaryTarget[domainClassId].Add(parentElementId, new List<IEventSubscription>());
                    dictionaryTarget[domainClassId][parentElementId].Add(subscription);

                    // process descendants
                    foreach (DomainClassInfo info in domainRelationshipInfo.AllDescendants)
                    {
                        domainClassId = info.Id;

                        if (!dictionaryTarget.Keys.Contains(domainClassId))
                            dictionaryTarget.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                        if (!dictionaryTarget[domainClassId].Keys.Contains(parentElementId))
                            dictionaryTarget[domainClassId].Add(parentElementId, new List<IEventSubscription>());
                        dictionaryTarget[domainClassId][parentElementId].Add(subscription);

                    }
                }
            #endregion
        }

        /// <summary>
        /// Subscribe to the event. The observer will be notified, whenever a element link of
        /// the given domain relationship type (which does include all descendants) with the specified 
        /// element in a role is included in the specific event. 
        /// </summary>
        /// <param name="domainRelationshipInfo">DomainRelationshipInfo specifying when to notify the observer.</param>
        /// <param name="elementId">ElementId of the element specifying when to notify.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Subscribe(DomainRelationshipInfo domainRelationshipInfo, Guid elementId, Action<ElementAddedEventArgs> action)
        {
            IDelegateReference actionReference = new DelegateReference(action, false);
            IDelegateReference filterReference = new DelegateReference(new Predicate<ElementAddedEventArgs>(delegate { return true; }), true);
            IEventSubscription subscription = new EventSubscription<ElementAddedEventArgs>(actionReference, filterReference);

            #region dictionaryById
            lock (dictionarySource)
            {
                Guid domainClassId = domainRelationshipInfo.Id;

                if (!dictionaryById.Keys.Contains(domainClassId))
                    dictionaryById.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                if (!dictionaryById[domainClassId].Keys.Contains(elementId))
                    dictionaryById[domainClassId].Add(elementId, new List<IEventSubscription>());
                dictionaryById[domainClassId][elementId].Add(subscription);

                // process descendants
                foreach (DomainClassInfo info in domainRelationshipInfo.AllDescendants)
                {
                    domainClassId = info.Id;

                    if (!dictionaryById.Keys.Contains(domainClassId))
                        dictionaryById.Add(domainClassId, new Dictionary<Guid, List<IEventSubscription>>());

                    if (!dictionaryById[domainClassId].Keys.Contains(elementId))
                        dictionaryById[domainClassId].Add(elementId, new List<IEventSubscription>());
                    dictionaryById[domainClassId][elementId].Add(subscription);

                }
            }
            #endregion
        }

        /// <summary>
        /// Publish an event.
        /// </summary>
        /// <param name="payload">Message to pass to the subscribers.</param>
        public override void Publish(ElementAddedEventArgs payload)
        {
            base.Publish(payload);

            List<Action<object[]>> executionStrategies = PruneAndReturnStrategies(payload as ElementAddedEventArgs);
            foreach (var executionStrategy in executionStrategies)
            {
                executionStrategy(new object[] { payload });
            }
        }

        private ModelElement GetSourceOfRelationship(DomainRelationshipInfo info, ElementLink elementLink)
        {
            if (elementLink == null)
                return null;

            return DomainRoleInfo.GetSourceRolePlayer(elementLink);
        }
        private ModelElement GetTargetOfRelationship(DomainRelationshipInfo info, ElementLink elementLink)
        {
            if (elementLink == null)
                return null;

            return DomainRoleInfo.GetTargetRolePlayer(elementLink);
        }
        private List<ModelElement> GetSourceAndTargetOfRelationship(DomainRelationshipInfo info, ElementLink elementLink)
        {
            List<ModelElement> lst = new List<ModelElement>();

            ModelElement m = GetSourceOfRelationship(info, elementLink);
            if (m != null)
                lst.Add(m);

            ModelElement n = GetTargetOfRelationship(info, elementLink);
            if (n != null)
                lst.Add(n);

            return lst;
        }

        /// <summary>
        /// Evaluates the given payload and retrieves active subscribers.
        /// </summary>
        /// <param name="args">Payload, that is beeing published.</param>
        /// <returns>List of actions to call.</returns>
        private List<Action<object[]>> PruneAndReturnStrategies(ElementAddedEventArgs args)
        {
            List<Action<object[]>> returnList = new List<Action<object[]>>();
            
            #region dictionarySource
            lock (dictionarySource)
            {
                Guid domainClassId = args.DomainClass.Id;
                if (dictionarySource.Keys.Contains(domainClassId))
                {
                    DomainRelationshipInfo info = args.ModelElement.GetDomainClass() as DomainRelationshipInfo;
                    ModelElement modelElement = GetSourceOfRelationship(info, args.ModelElement as ElementLink);
                    if (modelElement != null)
                        if (dictionarySource[domainClassId].Keys.Contains(modelElement.Id))
                        {

                            List<IEventSubscription> subscriptions = dictionarySource[domainClassId][modelElement.Id];
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
                                dictionarySource[domainClassId].Remove(modelElement.Id);
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
                        DomainRelationshipInfo info = args.ModelElement.GetDomainClass() as DomainRelationshipInfo;
                        ModelElement modelElement = GetSourceOfRelationship(info, args.ModelElement as ElementLink);
                        if (modelElement != null)
                            if (dictionarySource[domainClassId].Keys.Contains(modelElement.Id))
                            {

                                List<IEventSubscription> subscriptions = dictionarySource[domainClassId][modelElement.Id];
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
                                    dictionarySource[domainClassId].Remove(modelElement.Id);
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
                    DomainRelationshipInfo info = args.ModelElement.GetDomainClass() as DomainRelationshipInfo;
                    ModelElement modelElement = GetTargetOfRelationship(info, args.ModelElement as ElementLink);
                    if (modelElement != null)
                        if (dictionaryTarget[domainClassId].Keys.Contains(modelElement.Id))
                        {

                            List<IEventSubscription> subscriptions = dictionaryTarget[domainClassId][modelElement.Id];
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
                                dictionaryTarget[domainClassId].Remove(modelElement.Id);
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
                        DomainRelationshipInfo info = args.ModelElement.GetDomainClass() as DomainRelationshipInfo;
                        ModelElement modelElement = GetTargetOfRelationship(info, args.ModelElement as ElementLink);
                        if (modelElement != null)
                            if (dictionaryTarget[domainClassId].Keys.Contains(modelElement.Id))
                            {

                                List<IEventSubscription> subscriptions = dictionaryTarget[domainClassId][modelElement.Id];
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
                                    dictionaryTarget[domainClassId].Remove(modelElement.Id);
                            }

                        if (dictionaryTarget[domainClassId].Count == 0)
                            dictionaryTarget.Remove(domainClassId);
                    }
                }
            }
            #endregion

            #region dictionaryById
            lock (dictionaryById)
            {
                Guid domainClassId = args.DomainClass.Id;
                if (dictionaryById.Keys.Contains(domainClassId))
                {
                    DomainRelationshipInfo info = args.ModelElement.GetDomainClass() as DomainRelationshipInfo;
                    List<ModelElement> elements = GetSourceAndTargetOfRelationship(info, args.ModelElement as ElementLink);
                    foreach (ModelElement modelElement in elements)
                        if (modelElement != null)
                            if (dictionaryById[domainClassId].Keys.Contains(modelElement.Id))
                            {
                                List<IEventSubscription> subscriptions = dictionaryById[domainClassId][modelElement.Id];
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
                                    dictionaryById[domainClassId].Remove(modelElement.Id);
                            }

                    if (dictionaryById[domainClassId].Count == 0)
                        dictionaryById.Remove(domainClassId);
                }

                // continue with descendants
                foreach (DomainRelationshipInfo relInfo in args.DomainClass.AllDescendants)
                {
                    domainClassId = relInfo.Id;
                    if (dictionaryById.Keys.Contains(domainClassId))
                    {
                        DomainRelationshipInfo info = args.ModelElement.GetDomainClass() as DomainRelationshipInfo;
                        List<ModelElement> elements = GetSourceAndTargetOfRelationship(info, args.ModelElement as ElementLink);
                        foreach (ModelElement modelElement in elements)
                            if (dictionaryById[domainClassId].Keys.Contains(modelElement.Id))
                            {

                                List<IEventSubscription> subscriptions = dictionaryById[domainClassId][modelElement.Id];
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
                                    dictionaryById[domainClassId].Remove(modelElement.Id);
                            }

                        if (dictionaryById[domainClassId].Count == 0)
                            dictionaryById.Remove(domainClassId);
                    }
                }
            }
            #endregion

            return returnList;
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainRelationshipInfo">DomainRelationshipInfo specifying from what to unsubscribe.</param>
        /// <param name="bSourceRole">Boolean value indicating source or target role.</param>
        /// <param name="parentElementId">Parent element Id specifying from what to unsubscribe.</param>
        /// <param name="action">Action identifying what to unsubscribe.</param>
        public void Unsubscribe(DomainRelationshipInfo domainRelationshipInfo, bool bSourceRole, Guid parentElementId, Action<ElementAddedEventArgs> action)
        {
            #region dictionarySource
            if( bSourceRole )
                lock (dictionarySource)
            {
                Guid domainClassId = domainRelationshipInfo.Id;
                if (dictionarySource.Keys.Contains(domainClassId))
                {
                    if (dictionarySource[domainClassId].Keys.Contains(parentElementId))
                    {
                        IEventSubscription eventSubscription = dictionarySource[domainClassId][parentElementId].Cast<EventSubscription<ElementAddedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionarySource[domainClassId][parentElementId].Remove(eventSubscription);
                            if (dictionarySource[domainClassId][parentElementId].Count == 0)
                                dictionarySource[domainClassId].Remove(parentElementId);
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
                        if (dictionarySource[domainClassId].Keys.Contains(parentElementId))
                        {
                            IEventSubscription eventSubscription = dictionarySource[domainClassId][parentElementId].Cast<EventSubscription<ElementAddedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionarySource[domainClassId][parentElementId].Remove(eventSubscription);
                                if (dictionarySource[domainClassId][parentElementId].Count == 0)
                                    dictionarySource[domainClassId].Remove(parentElementId);
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
                        if (dictionaryTarget[domainClassId].Keys.Contains(parentElementId))
                        {
                            IEventSubscription eventSubscription = dictionaryTarget[domainClassId][parentElementId].Cast<EventSubscription<ElementAddedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionaryTarget[domainClassId][parentElementId].Remove(eventSubscription);
                                if (dictionaryTarget[domainClassId][parentElementId].Count == 0)
                                    dictionaryTarget[domainClassId].Remove(parentElementId);
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
                            if (dictionaryTarget[domainClassId].Keys.Contains(parentElementId))
                            {
                                IEventSubscription eventSubscription = dictionaryTarget[domainClassId][parentElementId].Cast<EventSubscription<ElementAddedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                                if (eventSubscription != null)
                                {
                                    dictionaryTarget[domainClassId][parentElementId].Remove(eventSubscription);
                                    if (dictionaryTarget[domainClassId][parentElementId].Count == 0)
                                        dictionaryTarget[domainClassId].Remove(parentElementId);
                                }
                                if (dictionaryTarget[domainClassId].Count == 0)
                                    dictionaryTarget.Remove(domainClassId);
                            }
                        }
                    }
                }
            #endregion
        }

        /// <summary>
        /// Unsubscribes from a specific event.
        /// </summary>
        /// <param name="domainRelationshipInfo">DomainRelationshipInfo specifying when to notify the observer.</param>
        /// <param name="elementId">ElementId of the element specifying when to notify.</param>
        /// <param name="action">Action to call on the observer.</param>
        public void Unsubscribe(DomainRelationshipInfo domainRelationshipInfo, Guid elementId, Action<ElementAddedEventArgs> action)
        {
            #region dictionaryById
            lock (dictionaryById)
            {
                Guid domainClassId = domainRelationshipInfo.Id;
                if (dictionaryById.Keys.Contains(domainClassId))
                {
                    if (dictionaryById[domainClassId].Keys.Contains(elementId))
                    {
                        IEventSubscription eventSubscription = dictionaryById[domainClassId][elementId].Cast<EventSubscription<ElementAddedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                        if (eventSubscription != null)
                        {
                            dictionaryById[domainClassId][elementId].Remove(eventSubscription);
                            if (dictionaryById[domainClassId][elementId].Count == 0)
                                dictionaryById[domainClassId].Remove(elementId);
                        }
                        if (dictionaryById[domainClassId].Count == 0)
                            dictionaryById.Remove(domainClassId);
                    }
                }

                // process descendants
                foreach (DomainRelationshipInfo info in domainRelationshipInfo.AllDescendants)
                {
                    domainClassId = info.Id;
                    if (dictionaryById.Keys.Contains(domainClassId))
                    {
                        if (dictionaryById[domainClassId].Keys.Contains(elementId))
                        {
                            IEventSubscription eventSubscription = dictionaryById[domainClassId][elementId].Cast<EventSubscription<ElementAddedEventArgs>>().FirstOrDefault(evt => evt.Action == action);
                            if (eventSubscription != null)
                            {
                                dictionaryById[domainClassId][elementId].Remove(eventSubscription);
                                if (dictionaryById[domainClassId][elementId].Count == 0)
                                    dictionaryById[domainClassId].Remove(elementId);
                            }
                            if (dictionaryById[domainClassId].Count == 0)
                                dictionaryById.Remove(domainClassId);
                        }
                    }
                }
            }
            #endregion

        }
    }
}

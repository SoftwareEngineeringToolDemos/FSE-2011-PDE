using System;

using Microsoft.VisualStudio.Modeling;

using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging;
using Tum.PDE.LanguageDSL.Visualization.ViewModel.Messaging.Events;

namespace Tum.PDE.LanguageDSL.Visualization.ViewModel.Data
{
    /// <summary>
    /// This class contains a reference to the model.
    /// 
    /// Further it provides the mediater class, which implements the Mediator pattern for messaging.
    /// 
    /// We also hook into the event-processing of the dsl tools store class to provide a mapping of events to our view model.
    /// So far we only support ElementAdded, ElementDeleted, ElementPropertyChanged, RolePlayerChangedEventArgs
    /// </summary>
    public class ViewModelStore
    {
        private ModelData modelData;
        private ViewModelEventManager viewModelEventManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="modelData">Document data.</param>
        public ViewModelStore(ModelData modelData)
        {
            this.viewModelEventManager = new ViewModelEventManager();
            this.modelData = modelData;

            HookUpEvents();
        }

        /// <summary>
        /// This method provides a mapping between the event handlers in the dsl tools store and our view model.
        /// </summary>
        protected virtual void HookUpEvents()
        {
            this.Store.EventManagerDirectory.ElementAdded.Add(new EventHandler<ElementAddedEventArgs>(OnElementAdded));
            this.Store.EventManagerDirectory.ElementDeleted.Add(new EventHandler<ElementDeletedEventArgs>(OnElementDeleted));
            this.Store.EventManagerDirectory.ElementPropertyChanged.Add(new EventHandler<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
            this.Store.EventManagerDirectory.RolePlayerChanged.Add(new EventHandler<RolePlayerChangedEventArgs>(OnRolePlayerChanged));
            this.Store.EventManagerDirectory.RolePlayerOrderChanged.Add(new EventHandler<RolePlayerOrderChangedEventArgs>(OnRolePlayerMoved));
        }

        /// <summary>
        /// This method unhooks event listeners.
        /// </summary>
        protected virtual void UnhookEvents()
        {
            this.Store.EventManagerDirectory.ElementAdded.Remove(new EventHandler<ElementAddedEventArgs>(OnElementAdded));
            this.Store.EventManagerDirectory.ElementDeleted.Remove(new EventHandler<ElementDeletedEventArgs>(OnElementDeleted));
            this.Store.EventManagerDirectory.ElementPropertyChanged.Remove(new EventHandler<ElementPropertyChangedEventArgs>(OnElementPropertyChanged));
            this.Store.EventManagerDirectory.RolePlayerChanged.Remove(new EventHandler<RolePlayerChangedEventArgs>(OnRolePlayerChanged));
        }

        /// <summary>
        /// Called whenever a model element is added to the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the creation of new model element.</param>
        protected virtual void OnElementAdded(object sender, ElementAddedEventArgs args)
        {
            EventManager.GetEvent<ModelElementAddedEvent>().Publish(args);

            if( args.ModelElement is ElementLink )
                EventManager.GetEvent<ModelElementLinkAddedEvent>().Publish(args);            
        }

        /// <summary>
        /// Called whenever a model element is deleted from the store.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the removal of an ModelElement.</param>
        protected virtual void OnElementDeleted(object sender, ElementDeletedEventArgs args)
        {
            EventManager.GetEvent<ModelElementDeletedEvent>().Publish(args);

            if( args.ModelElement is ElementLink )
                EventManager.GetEvent<ModelElementLinkDeletedEvent>().Publish(args);
        }
               
        /// <summary>
        /// Called whenever a model element's property value is changed.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notifications that the value of an attribute has changed</param>
        protected virtual void OnElementPropertyChanged(object sender, ElementPropertyChangedEventArgs args)
        {
            EventManager.GetEvent<ModelElementPropertyChangedEvent>().Publish(args);
        }

        /// <summary>
        /// Called whenever a model element's property value is changed.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notifications that the value of an attribute has changed</param>
        protected virtual void OnRolePlayerChanged(object sender, RolePlayerChangedEventArgs args)
        {
            EventManager.GetEvent<ModelRolePlayerChangedEvent>().Publish(args);
        }

        /// <summary>
        /// Called whenever a model element is moved.
        /// </summary>
        /// <param name="sender">ViewModelStore</param>
        /// <param name="args">Event Arguments for notification of the movement of a model element.</param>
        protected virtual void OnRolePlayerMoved(object sender, RolePlayerOrderChangedEventArgs args)
        {
            EventManager.GetEvent<ModelRolePlayerMovedEvent>().Publish(args);
        }

        /// <summary>
        /// Gets the document data containing the domain model data.
        /// </summary>
        public virtual ModelData ModelData
        {
            get
            {
                return this.modelData;
            }
        }

        /// <summary>
        /// Gets the store containing the domain model.
        /// </summary>
        public virtual Store Store
        {
            get { return ModelData.Store; }
        }

        /// <summary>
        /// ViewModelEventManager = Messaging pattern
        /// </summary>
        public ViewModelEventManager EventManager
        {
            get { return this.viewModelEventManager; }
        }  
    }
}


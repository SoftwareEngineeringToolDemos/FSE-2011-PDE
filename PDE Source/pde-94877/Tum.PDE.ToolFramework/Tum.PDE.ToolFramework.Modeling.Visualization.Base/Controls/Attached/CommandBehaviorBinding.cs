using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Reflection;
using System.Windows;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Base.Controls.Attached
{
    /// <summary>
    /// Defines the command behavior binding
    /// </summary>
    /// <remarks>
    /// Source: http://marlongrech.wordpress.com/2008/12/13/attachedcommandbehavior-v2-aka-acb/
    /// </remarks>
    public class CommandBehaviorBinding : IDisposable
    {
        #region Properties
        /// <summary>
        /// Get the owner of the CommandBinding ex: a Button
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public DependencyObject Owner { get; private set; }
        /// <summary>
        /// The command to execute when the specified event is raised
        /// </summary>
        public ICommand Command { get; set; }
        /// <summary>
        /// Gets or sets a CommandParameter
        /// </summary>
        public object CommandParameter { get; set; }
        /// <summary>
        /// The event name to hook up to
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public string EventName { get; private set; }
        /// <summary>
        /// The event info of the event
        /// </summary>
        public EventInfo Event { get; private set; }
        /// <summary>
        /// Gets the EventHandler for the binding with the event
        /// </summary>
        public Delegate EventHandler { get; private set; }

        #endregion

        /// <summary>
        /// Creates an EventHandler on runtime and registers that handler to the Event specified.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="eventName"></param>
        public void BindEvent(DependencyObject owner, string eventName)
        {
            EventName = eventName;
            Owner = owner;
            Event = Owner.GetType().GetEvent(EventName, BindingFlags.Public | BindingFlags.Instance);
            if (Event == null)
                throw new InvalidOperationException(String.Format("Could not resolve event name {0}", EventName));

            //Create an event handler for the event that will call the ExecuteCommand method
            EventHandler = EventHandlerGenerator.CreateDelegate(
                Event.EventHandlerType, typeof(CommandBehaviorBinding).GetMethod("ExecuteCommand", BindingFlags.Public | BindingFlags.Instance), this);
            //Register the handler to the Event
            Event.AddEventHandler(Owner, EventHandler);
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public void ExecuteCommand()
        {
            if (Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        #region IDisposable Members
        bool disposed = false;
        
        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Unregisters the EventHandler from the Event
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    Event.RemoveEventHandler(Owner, EventHandler);
                    disposed = true;
                }
            }
        }

        #endregion
    }
}

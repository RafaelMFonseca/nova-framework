using System;

namespace Nova.Framework.Event
{
    /// <summary>
    /// A holder to emit custom events, and register handlers for those events
    /// by subscribing to an instance.
    /// </summary>
    public interface IEventEmitter
    {
        /// <summary>
        /// Sets a new delegate for given event to be called when he is emitted.
        /// </summary>
        /// <param name="name">The event name identifier, must be unique.</param>
        /// <param name="handler">The delegate emitted for this event.</param>
        void Subscribe(EventName name, Action<EventParameter> handler);

        /// <summary>
        /// Removes a delegate from this event.
        /// </summary>
        /// <param name="name">The event name identifier, must be unique.</param>
        /// <param name="handler">The delegate emitted for this event.</param>
        void Unsubscribe(EventName name, Action<EventParameter> handler);

        /// <summary>
        /// Removes all delegates of this event.
        /// </summary>
        /// <param name="name">The event name identifier, must be unique.</param>
        void ClearSubscriptions(EventName name);

        /// <summary>
        /// Emits all delegates from given event.
        /// </summary>
        /// <param name="name">The event name identifier, must be unique.</param>
        /// <param name="parameter">The parameter passed to all events emitted.</param>
        void Emit(EventName name, EventParameter parameter);
    }
}

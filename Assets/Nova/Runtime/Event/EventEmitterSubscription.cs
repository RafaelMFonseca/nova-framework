using System;

namespace Nova.Framework.Event
{
    /// <inheritdoc />
    public class EventEmitterSubscription : IEventEmitterSubscription
    {
        private readonly Action _unsubscribe;

        /// <summary>
        /// Create a new EventEmitterSubscription instance.
        /// </summary>
        /// <param name="unsubscribe">Delegate to disposes the resources held by the subscription.</param>
        public EventEmitterSubscription(Action unsubscribe)
        {
            _unsubscribe = unsubscribe;
        }

        /// <inheritdoc />
        void IEventEmitterSubscription.Unsubscribe()
        {
            _unsubscribe?.Invoke();
        }
    }
}

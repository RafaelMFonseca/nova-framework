using System;
using System.Collections.Generic;

namespace Nova.Framework.Event
{
    [Serializable]
    public class EventEmitter : IEventEmitter
    {
        private readonly Dictionary<EventName, List<Action<EventParameter>>> _listeners = new Dictionary<EventName, List<Action<EventParameter>>>();

        /// <inheritdoc />
        IEventEmitterSubscription IEventEmitter.Subscribe(EventName name, Action<EventParameter> handler)
        {
            List<Action<EventParameter>> listeners;

            if (!_listeners.TryGetValue(name, out listeners))
            {
                _listeners[name] = new List<Action<EventParameter>>() { handler };
            }
            else
            {
                listeners.Add(handler);
            }

            return new EventEmitterSubscription(() => (this as IEventEmitter).Unsubscribe(name, handler));
        }

        /// <inheritdoc />
        void IEventEmitter.Unsubscribe(EventName name, Action<EventParameter> handler)
        {
            if (_listeners.TryGetValue(name, out List<Action<EventParameter>> listeners))
            {
                listeners.Remove(handler);
            }
        }

        /// <inheritdoc />
        void IEventEmitter.ClearSubscriptions(EventName name)
        {
            if (_listeners.TryGetValue(name, out List<Action<EventParameter>> listeners))
            {
                listeners.Clear();
            }
        }

        /// <inheritdoc />
        void IEventEmitter.Emit(EventName name, EventParameter parameter)
        {
            if (_listeners.TryGetValue(name, out List<Action<EventParameter>> listeners))
            {
                IEventEmitterInvoker invoker = new EventEmitterInvoker();

                parameter.ChangeInvokerTo(invoker);

                invoker.Emit(listeners, parameter);
            }
        }
    }
}

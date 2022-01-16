using System;
using System.Collections.Generic;

namespace Nova.Framework.Event
{
    /// <inheritdoc />
    public class EventEmitter : IEventEmitter
    {
        private readonly Dictionary<IEventName, List<Action<IEventParameter>>> _listeners = new Dictionary<IEventName, List<Action<IEventParameter>>>();

        /// <inheritdoc />
        IEventEmitterSubscription IEventEmitter.Subscribe(IEventName name, Action<IEventParameter> handler)
        {
            List<Action<IEventParameter>> listeners;

            if (!_listeners.TryGetValue(name, out listeners))
            {
                _listeners[name] = new List<Action<IEventParameter>>() { handler };
            }
            else
            {
                listeners.Add(handler);
            }

            return new EventEmitterSubscription(() => (this as IEventEmitter).Unsubscribe(name, handler));
        }

        /// <inheritdoc />
        void IEventEmitter.Unsubscribe(IEventName name, Action<IEventParameter> handler)
        {
            if (_listeners.TryGetValue(name, out List<Action<IEventParameter>> listeners))
            {
                listeners.Remove(handler);

                if (listeners.Count == 0)
                {
                    _listeners.Remove(name);
                }
            }
        }

        /// <inheritdoc />
        void IEventEmitter.ClearSubscriptions(IEventName name)
        {
            if (_listeners.TryGetValue(name, out List<Action<IEventParameter>> listeners))
            {
                listeners.Clear();

                _listeners.Remove(name);
            }
        }

        /// <inheritdoc />
        void IEventEmitter.Emit(IEventName name, IEventParameter parameter)
        {
            if (_listeners.TryGetValue(name, out List<Action<IEventParameter>> listeners))
            {
                IEventEmitterInvoker invoker = new EventEmitterInvoker();

                parameter.ChangeInvokerTo(invoker);

                invoker.Emit(listeners, parameter);
            }
        }

        /// <inheritdoc />
        void IDisposable.Dispose()
        {
            _listeners.Clear();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Nova.Framework.Event
{
    /// <inheritdoc />
    public class EventEmitterInvoker : IEventEmitterInvoker
    {
        private bool _wasStopped;

        /// <inheritdoc />
        void IEventEmitterInvoker.StopEventInvocation()
        {
            _wasStopped = true;
        }

        /// <inheritdoc />
        void IEventEmitterInvoker.Emit(List<Action<IEventParameter>> listeners, IEventParameter parameter)
        {
            foreach (Action<IEventParameter> listener in listeners)
            {
                if (!_wasStopped)
                {
                    listener?.Invoke(parameter);
                }
            }
        }
    }
}

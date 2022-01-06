using System;
using System.Collections.Generic;

namespace Nova.Framework.Event
{
    /// <inheritdoc />
    [Serializable]
    public class EventEmitterInvoker : IEventEmitterInvoker
    {
        private bool _wasStopped;

        /// <inheritdoc />
        public void StopEventInvocation()
        {
            _wasStopped = true;
        }

        /// <inheritdoc />
        public void Emit(List<Action<EventParameter>> listeners, EventParameter parameter)
        {
            foreach (Action<EventParameter> listener in listeners)
            {
                if (!_wasStopped)
                {
                    listener?.Invoke(parameter);
                }
            }
        }
    }
}

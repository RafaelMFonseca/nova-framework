using System;
using System.Collections.Generic;

namespace Nova.Framework.Event
{
    /// <summary>
    /// Used to invoke all delegates from given event emitter.
    /// </summary>
    public interface IEventEmitterInvoker
    {
        /// <summary>
        /// Stops invocation of the next delegates from the event.
        /// </summary>
        void StopEventInvocation();

        /// <summary>
        /// Emits all delegates from given event.
        /// </summary>
        /// <param name="listeners">All delegates to be invoked.</param>
        /// <param name="parameter">The parameter passed to all delegates invoked.</param>
        void Emit(List<Action<IEventParameter>> listeners, IEventParameter parameter);
    }
}

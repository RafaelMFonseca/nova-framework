namespace Nova.Framework.Event
{
    /// <summary>
    /// Used in order to provide values to an event.
    /// </summary>
    public interface IEventParameter
    {
        /// <summary>
        /// Change the invoker to another instance.
        /// </summary>
        /// <param name="invoker">The <see cref="IEventEmitterInvoker"/>.</param>
        void ChangeInvokerTo(IEventEmitterInvoker invoker);

        /// <summary>
        /// Stops the event invocation.
        /// </summary>
        void StopEventInvocation();
    }
}

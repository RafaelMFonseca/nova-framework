namespace Nova.Framework.Event
{
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

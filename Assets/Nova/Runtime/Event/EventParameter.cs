namespace Nova.Framework.Event
{
    /// <summary>
    /// Represents a parameter passed to a event.
    /// </summary>
    public class EventParameter : IEventParameter
    {
        private IEventEmitterInvoker _invoker;

        /// <inheritdoc />
        void IEventParameter.ChangeInvokerTo(IEventEmitterInvoker invoker)
        {
            _invoker = invoker;
        }

        /// <inheritdoc />
        void IEventParameter.StopEventInvocation()
        {
            _invoker.StopEventInvocation();
        }
    }
}

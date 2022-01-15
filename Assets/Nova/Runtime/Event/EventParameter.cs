using System;

namespace Nova.Framework.Event
{
    public class EventParameter
    {
        private IEventEmitterInvoker _invoker;

        public void ChangeInvokerTo(IEventEmitterInvoker invoker)
        {
            _invoker = invoker;
        }

        public void StopEventInvocation()
        {
            _invoker.StopEventInvocation();
        }
    }
}

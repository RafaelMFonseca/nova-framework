namespace Nova.Framework.Event
{
    /// <summary>
    /// Represents a disposable event.
    /// </summary>
    public interface IEventEmitterSubscription
    {
        /// <summary>
        /// Remove the subscription from event emitter.
        /// </summary>
        void Unsubscribe();
    }
}

namespace Nova.Framework.Event
{
    /// <summary>
    /// Represents the event name.
    /// </summary>
    public class EventName : IEventName
    {
        private readonly string _name;

        /// <inheritdoc />
        public string Name => _name;

        /// <summary>
        /// Create a new EventName.
        /// </summary>
        /// <param name="name">Name of the event.</param>
        public EventName(string name)
        {
            _name = name;
        }

        /// <inheritdoc />
        public override string ToString() => Name.ToString();
    }
}

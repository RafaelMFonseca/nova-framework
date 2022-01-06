using System;

namespace Nova.Framework.Event
{
    [Serializable]
    public class EventName
    {
        private readonly string _name;
        public string Name => _name;

        public EventName(string name)
        {
            _name = name;
        }

        public override string ToString() => Name.ToString();
    }
}

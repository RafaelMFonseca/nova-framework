using System;
using System.Linq;
using NUnit.Framework;
using Nova.Framework.Event;

namespace Nova.Framework.Tests.Event
{
    public class EventEmitterTest
    {
        [Test]
        public void Should_Emit_All_Events()
        {
            int eventRaisedCount = 0;

            EventName onResolutionChange = new EventName("onResolutionChange");

            IEventEmitter eventEmitter = new EventEmitter();

            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);

            eventEmitter.Emit(onResolutionChange, new EventParameter());

            Assert.AreEqual(4, eventRaisedCount);
        }

        [Test]
        public void Should_Stop_Events()
        {
            int eventRaisedCount = 0;

            EventName onResolutionChange = new EventName("onResolutionChange");

            IEventEmitter eventEmitter = new EventEmitter();

            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => p.StopEventInvocation());
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);

            eventEmitter.Emit(onResolutionChange, new EventParameter());

            Assert.AreEqual(2, eventRaisedCount);
        }

        [Test]
        public void Should_Distinguish_Events()
        {
            int eventRaised1Count = 0;
            int eventRaised2Count = 0;
            int eventRaised3Count = 0;

            EventName onResolutionChange = new EventName("onResolutionChange");
            EventName onLanguageChange = new EventName("onLanguageChange");
            EventName onVolumeChange = new EventName("onVolumeChange");

            IEventEmitter eventEmitter = new EventEmitter();

            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaised1Count++);

            eventEmitter.Subscribe(onLanguageChange, (p) => eventRaised2Count++);
            eventEmitter.Subscribe(onLanguageChange, (p) => eventRaised2Count++);

            eventEmitter.Subscribe(onVolumeChange, (p) => eventRaised3Count++);
            eventEmitter.Subscribe(onVolumeChange, (p) => eventRaised3Count++);
            eventEmitter.Subscribe(onVolumeChange, (p) => eventRaised3Count++);

            eventEmitter.Emit(onResolutionChange, new EventParameter());
            eventEmitter.Emit(onLanguageChange, new EventParameter());
            eventEmitter.Emit(onVolumeChange, new EventParameter());

            Assert.AreEqual(1, eventRaised1Count);
            Assert.AreEqual(2, eventRaised2Count);
            Assert.AreEqual(3, eventRaised3Count);
        }

        [Test]
        public void Should_Unsubscribe_To_Events()
        {
            string eventRaisedResult = string.Empty;

            EventName onResolutionChange = new EventName("onResolutionChange");

            IEventEmitter eventEmitter = new EventEmitter();

            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedResult += (char)97);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedResult += (char)98);
            Action<EventParameter> handlerToRemove = (p) => eventRaisedResult += (char)99;
            eventEmitter.Subscribe(onResolutionChange, handlerToRemove);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedResult += (char)100);

            eventEmitter.Unsubscribe(onResolutionChange, handlerToRemove);

            eventEmitter.Emit(onResolutionChange, new EventParameter());

            Assert.AreEqual(string.Join("", (new int[] { 97, 98, 100 }).Select(c => (char)c)), eventRaisedResult);
        }

        [Test]
        public void Should_Remove_All_Events()
        {
            int eventRaisedCount = 0;

            EventName onResolutionChange = new EventName("onResolutionChange");

            IEventEmitter eventEmitter = new EventEmitter();

            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);

            eventEmitter.ClearSubscriptions(onResolutionChange);

            eventEmitter.Emit(onResolutionChange, new EventParameter());

            Assert.AreEqual(0, eventRaisedCount);
        }

        [Test]
        public void Should_Unsubscribe_With_Subscription()
        {
            int eventRaisedCount = 0;

            EventName onResolutionChange = new EventName("onResolutionChange");

            IEventEmitter eventEmitter = new EventEmitter();

            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            IEventEmitterSubscription subscription = eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);
            eventEmitter.Subscribe(onResolutionChange, (p) => eventRaisedCount++);

            subscription.Unsubscribe();

            eventEmitter.Emit(onResolutionChange, new EventParameter());

            Assert.AreEqual(3, eventRaisedCount);
        }
    }
}
using UnityEngine;
using Nova.Framework.Event;
using Nova.Framework.Dependency;

namespace Nova.Framework.Actor.Component
{
    public abstract class Actor_MonoBehaviour : MonoBehaviour, IActorComponentAdder
    {
        protected IDependencyContainer _dependencyContainer = new DependencyContainer();
        protected IEventEmitter _eventEmitter = new EventEmitter();

        public abstract ActorComponent[] GetComponentsToAdd();
    }
}
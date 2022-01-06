using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nova.Framework.Actor.Component
{
    public interface IActorComponentAdder
    {
        public ActorComponent[] GetComponentsToAdd();
    }
}
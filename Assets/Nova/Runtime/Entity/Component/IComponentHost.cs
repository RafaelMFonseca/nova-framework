using UnityEngine;

namespace Nova.Framework.Entity.Component
{
    /// <summary>
    /// Represents a component that can be used on an entity and have a reference
    /// to it's GameObject.
    /// </summary>
    public interface IComponentHost : IComponent
    {
        /// <summary>
        /// Called by <see cref="IEntity"/> for the components get the game object.
        /// </summary>
        /// <param name="host">The game object of the entity.</param>
        void SetHost(GameObject host);
    }
}

using UnityEngine;
using System.Linq;
using Nova.Framework.Entity;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Shared
{
    /// <summary>
    /// Provides extension methods for <see cref="GameObject" />
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Adds a <see cref="IEntity"/> to the game object.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <typeparam name="TComponent">The component type.</typeparam>
        /// <param name="gameObject">The game object to add the component.</param>
        /// <returns>The component of type <see cref="IComponent"/></returns>
        public static TComponent AddEntity<TEntity, TComponent>(this GameObject gameObject)
            where TEntity : MonoBehaviour, IEntity
            where TComponent : IComponent
        {
            Check.NotNull(gameObject, nameof(gameObject));

            TEntity entity = gameObject.AddComponent<TEntity>();

            return entity.OfType<TComponent>().FirstOrDefault();
        }
    }
}

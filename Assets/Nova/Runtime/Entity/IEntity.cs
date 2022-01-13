using Nova.Framework.Entity.Component;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Represents an entity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Components for this entity.
        /// </summary>
        /// <returns>Returns an array of <see cref="IComponent" />.</returns>
        IComponent[] GetComponents();
    }
}

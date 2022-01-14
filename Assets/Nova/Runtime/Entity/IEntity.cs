using System.Collections.Generic;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Represents an entity.
    /// </summary>
    public interface IEntity : IEnumerable<IComponent>
    {
        /// <summary>
        /// Components for this entity.
        /// </summary>
        /// <returns>Returns an array of <see cref="IComponent" />.</returns>
        IComponent[] GetComponents();
    }
}

using UnityEngine;

namespace Nova.Framework.Common.Spawner
{
    /// <summary>
    /// Used to instantiate <see cref="GameObject"/> at runtime.
    /// </summary>
    public interface IPrefab
    {
        /// <summary>
        /// Create the <see cref="GameObject"/>.
        /// </summary>
        /// <param name="parameter">The parameter passed to the prefab.</param>
        /// <returns>The <see cref="GameObject"/> instantiated.</returns>
        GameObject Create(IPrefabParameter parameter);
    }
}

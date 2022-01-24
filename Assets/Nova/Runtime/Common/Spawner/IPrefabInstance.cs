using UnityEngine;

namespace Nova.Framework.Common.Spawner
{
    /// <summary>
    /// Used to control a instantiated <see cref="GameObject"/> at runtime.
    /// </summary>
    public interface IPrefabInstance
    {
        /// <summary>
        /// The game object the prefab created.
        /// </summary>
        GameObject Host { get; }

        /// <summary>
        /// Destroys the prefab.
        /// </summary>
        /// <returns>True if the prefab was destroyed, false otherwise.</returns>
        void Destroy();
    }
}

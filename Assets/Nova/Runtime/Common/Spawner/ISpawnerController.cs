using Nova.Framework.Controller;

namespace Nova.Framework.Common.Spawner
{
    /// <summary>
    /// Used to spawn a <see cref="IPrefab"/>.
    /// </summary>
    public interface ISpawnerController : IController
    {
        /// <summary>
        /// Instantiates a new <see cref="IPrefab"/>.
        /// </summary>
        /// <typeparam name="T">The prefab type.</typeparam>
        /// <param name="parameter">The parameter passed to prefab.</param>
        /// <returns>A <see cref="IPrefabInstance"/> to controls the instantiated prefab.</returns>
        IPrefabInstance Spawn<T>(IPrefabParameter parameter) where T : IPrefab, new();
    }
}

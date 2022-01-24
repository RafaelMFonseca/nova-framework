using UnityEngine;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Common.Coroutiner;

namespace Nova.Framework.Common.Spawner
{
    /// <summary>
    /// Controller for spawning prefabs.
    /// </summary>
    public class SpawnerController : ISpawnerController, IStartable
    {
        private ICoroutinerController _coroutinerController;

        /// <inheritdoc />
        void IStartable.OnStart(IDependencyContainer container)
        {
            _coroutinerController = container.Inject<ICoroutinerController>();
        }

        /// <inheritdoc />
        IPrefabInstance ISpawnerController.Spawn<T>(IPrefabParameter parameter)
        {
            T prefab = new();

            GameObject host = prefab.Create(parameter);

            return new PrefabInstance(host, () => GameObject.Destroy(host));
        }
    }
}

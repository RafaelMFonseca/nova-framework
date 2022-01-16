using System.Collections;
using UnityEngine;
using Nova.Framework.Core;
using Nova.Framework.Dependency;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Controller for execute coroutines.
    /// </summary>
    public class CoroutineRunnerController : ICoroutineRunnerController, ILoadable
    {
        private ICoroutineRunnerComponent _coroutineRunnerComponent;
        private GameObject _coroutineRunnerGameObject;

        /// <inheritdoc />
        void ILoadable.OnLoad(IDependencyContainer container)
        {
            InternalCreateGameObjectHost();
        }

        /// <inheritdoc />
        ICoroutineRunnerTask ICoroutineRunnerController.Start(IEnumerator routine)
        {
            ICoroutineRunnerTask task = new CoroutineRunnerTask(routine, () => _coroutineRunnerComponent.Stop(routine));

            _coroutineRunnerComponent.Start(routine);

            return task;
        }

        /// <summary>
        /// Creates a game object for this controller.
        /// </summary>
        private void InternalCreateGameObjectHost()
        {
            _coroutineRunnerGameObject = new GameObject();
            _coroutineRunnerGameObject.name = "[NovaFramework::Coroutines]";
            _coroutineRunnerGameObject.AddComponent<CoroutineRunnerEntity>();

            GameObject.DontDestroyOnLoad(_coroutineRunnerGameObject);
        }
    }
}

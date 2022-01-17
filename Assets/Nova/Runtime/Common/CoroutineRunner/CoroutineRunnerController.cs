using UnityEngine;
using System.Collections;
using Nova.Framework.Shared;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Controller for execute coroutines.
    /// </summary>
    public class CoroutineRunnerController : ICoroutineRunnerController
    {
        private ICoroutineRunnerComponent _coroutineRunnerComponent;
        private GameObject _coroutineRunnerGameObject;
        private object _lock = new object();

        /// <inheritdoc />
        ICoroutineRunnerTask ICoroutineRunnerController.Start(IEnumerator routine)
        {
            InternalCreateGameObjectHost();

            ICoroutineRunnerTask task = new CoroutineRunnerTask(routine, () => _coroutineRunnerComponent.Stop(routine));

            _coroutineRunnerComponent.Start(routine);

            return task;
        }

        /// <summary>
        /// Creates a game object for this controller.
        /// </summary>
        private void InternalCreateGameObjectHost()
        {
            if (_coroutineRunnerGameObject != null) return;

            lock (_lock)
            {
                if (_coroutineRunnerGameObject != null) return;

                _coroutineRunnerGameObject = new GameObject();
                _coroutineRunnerGameObject.name = "[NovaFramework::Coroutines]";

                _coroutineRunnerComponent = _coroutineRunnerGameObject.AddEntity<CoroutineRunnerEntity, ICoroutineRunnerComponent>();

                GameObject.DontDestroyOnLoad(_coroutineRunnerGameObject);
            }
        }
    }
}

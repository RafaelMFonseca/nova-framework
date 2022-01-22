using UnityEngine;
using System.Collections;
using Nova.Framework.Shared;

namespace Nova.Framework.Common.Coroutiner
{
    /// <summary>
    /// Controller for execute coroutines.
    /// </summary>
    public class CoroutinerController : ICoroutinerController
    {
        private ICoroutinerComponent _coroutinerComponent;
        private GameObject _coroutinerGameObject;

        private static object _internalSyncObject = new object();

        /// <inheritdoc />
        ICoroutinerTask ICoroutinerController.Start(IEnumerator routine)
        {
            InternalCreateGameObjectHost();

            ICoroutinerTask task = new CoroutinerTask(routine, () => _coroutinerComponent.Stop(routine));

            _coroutinerComponent.Start(routine);

            return task;
        }

        /// <summary>
        /// Creates a game object for this controller.
        /// </summary>
        private void InternalCreateGameObjectHost()
        {
            lock (_internalSyncObject)
            {
                if (_coroutinerGameObject != null) return;

                _coroutinerGameObject = new GameObject();
                _coroutinerGameObject.name = "[NovaFramework::Coroutines]";

                _coroutinerComponent = _coroutinerGameObject.AddEntity<CoroutinerEntity, ICoroutinerComponent>();

                GameObject.DontDestroyOnLoad(_coroutinerGameObject);
            }
        }
    }
}

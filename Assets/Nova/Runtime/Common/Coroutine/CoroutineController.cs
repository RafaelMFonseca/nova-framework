using System.Collections;
using UnityEngine;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Entity;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Controller for execute coroutines.
    /// </summary>
    public class CoroutineController : ICoroutineController, ILoadable
    {
        private ICoroutineComponent _coroutineComponent;
        private GameObject _coroutineGameObject;

        /// <inheritdoc />
        void ILoadable.OnLoad(IDependencyContainer container)
        {
            InternalCreateGameObjectHost();
        }

        /// <inheritdoc />
        ICoroutineTask ICoroutineController.Start(IEnumerator routine)
        {
            ICoroutineTask task = new CoroutineTask(routine, () => _coroutineComponent.Stop(routine));

            _coroutineComponent.Start(routine);

            return task;
        }

        /// <summary>
        /// Creates a game object for this controller.
        /// </summary>
        private void InternalCreateGameObjectHost()
        {
            _coroutineGameObject = new GameObject();
            _coroutineGameObject.name = "[NovaFramework::Coroutines]";
            _coroutineGameObject.AddComponent<EntityGenericBase<CoroutineComponent>>();

            GameObject.DontDestroyOnLoad(_coroutineGameObject);
        }
    }
}

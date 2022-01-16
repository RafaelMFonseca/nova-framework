using System.Collections;
using UnityEngine;
using Nova.Framework.Core;
using Nova.Framework.Dependency;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Controller for execute coroutines.
    /// </summary>
    public class CoroutineController : ICoroutineController, ILoadable
    {
        private readonly ICoroutineComponent _coroutineComponent;

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
            GameObject gameObject = new GameObject();
            gameObject.name = "[NovaFramework::Coroutines]";

            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}

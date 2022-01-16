using UnityEngine;
using System.Collections;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Component to start and stop coroutines.
    /// </summary>
    public class CoroutineComponent : ICoroutineComponent
    {
        private readonly MonoBehaviour _host;

        public CoroutineComponent(MonoBehaviour host)
        {
            _host = host;
        }

        /// <inheritdoc />
        void ICoroutineComponent.Start(IEnumerator routine)
        {
            _host.StartCoroutine(routine);
        }

        /// <inheritdoc />
        void ICoroutineComponent.Stop(IEnumerator routine)
        {
            _host.StopCoroutine(routine);
        }
    }
}

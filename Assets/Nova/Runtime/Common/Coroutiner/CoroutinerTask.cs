using System;
using System.Collections;

namespace Nova.Framework.Common.Coroutiner
{
    /// <summary>
    /// Represents a running coroutine.
    /// </summary>
    public class CoroutinerTask : ICoroutinerTask
    {
        private readonly IEnumerator _enumerator;
        private readonly Action _stopCoroutine;

        /// <inheritdoc />
        IEnumerator ICoroutinerTask.Enumerator => _enumerator;

        /// <summary>
        /// Create a new CoroutineTask instance.
        /// </summary>
        /// <param name="enumerator">The coroutine enumerator.</param>
        /// <param name="stopCoroutine">An action to stop the coroutine.</param>
        public CoroutinerTask(IEnumerator enumerator, Action stopCoroutine)
        {
            _enumerator = enumerator;
            _stopCoroutine = stopCoroutine;
        }

        /// <inheritdoc />
        void ICoroutinerTask.Stop() => _stopCoroutine?.Invoke();
    }
}

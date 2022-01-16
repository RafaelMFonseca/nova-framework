using System;
using System.Collections;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Represents a running coroutine.
    /// </summary>
    public class CoroutineRunnerTask : ICoroutineRunnerTask
    {
        private readonly IEnumerator _enumerator;
        private readonly Action _stopCoroutine;

        /// <inheritdoc />
        IEnumerator ICoroutineRunnerTask.Enumerator => _enumerator;

        /// <summary>
        /// Create a new CoroutineTask instance.
        /// </summary>
        /// <param name="enumerator">The coroutine enumerator.</param>
        /// <param name="stopCoroutine">An action to stop the coroutine.</param>
        public CoroutineRunnerTask(IEnumerator enumerator, Action stopCoroutine)
        {
            _enumerator = enumerator;
            _stopCoroutine = stopCoroutine;
        }

        /// <inheritdoc />
        void ICoroutineRunnerTask.Stop() => _stopCoroutine?.Invoke();
    }
}

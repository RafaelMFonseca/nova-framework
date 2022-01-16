using System.Collections;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Component used to run coroutines.
    /// </summary>
    public interface ICoroutineRunnerComponent : IComponentHost
    {
        /// <summary>
        /// Starts a new coroutine.
        /// </summary>
        /// <param name="routine">The routine.</param>
        void Start(IEnumerator routine);

        /// <summary>
        /// Stops a coroutine.
        /// </summary>
        /// <param name="routine">The routine.</param>
        void Stop(IEnumerator routine);
    }
}

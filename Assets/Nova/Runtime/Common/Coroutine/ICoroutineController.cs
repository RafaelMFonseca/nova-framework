using System.Collections;
using Nova.Framework.Controller;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Controller for executing coroutines.
    /// </summary>
    public interface ICoroutineController : IController
    {
        /// <summary>
        /// Attempt to start the coroutine.
        /// </summary>
        /// <param name="routine">The coroutine.</param>
        /// <returns>A <see cref="ICoroutineTask"/> used to stop and retrieve information about the running coroutine.</returns>
        ICoroutineTask Start(IEnumerator routine);
    }
}

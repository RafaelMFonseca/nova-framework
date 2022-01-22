using System.Collections;
using Nova.Framework.Controller;

namespace Nova.Framework.Common.Coroutiner
{
    /// <summary>
    /// Controller for executing coroutines.
    /// </summary>
    public interface ICoroutinerController : IController
    {
        /// <summary>
        /// Attempt to start the coroutine.
        /// </summary>
        /// <param name="routine">The coroutine.</param>
        /// <returns>A <see cref="ICoroutinerTask"/> used to stop and retrieve information about the running coroutine.</returns>
        ICoroutinerTask Start(IEnumerator routine);
    }
}

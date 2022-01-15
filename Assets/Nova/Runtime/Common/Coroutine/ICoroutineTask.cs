using System.Collections;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Represents a running coroutine executed by the Unity Engine.
    /// </summary>
    public interface ICoroutineTask
    {
        /// <summary>
        /// The <see cref="IEnumerator"/> of the coroutine.
        /// </summary>
        IEnumerator Enumerator { get; set; }

        /// <summary>
        /// Attempt to stop the coroutine.
        /// </summary>
        void Stop();
    }
}

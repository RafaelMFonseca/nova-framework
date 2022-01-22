using System.Collections;

namespace Nova.Framework.Common.Coroutiner
{
    /// <summary>
    /// Represents a running coroutine executed by the Unity Engine.
    /// </summary>
    public interface ICoroutinerTask
    {
        /// <summary>
        /// The <see cref="IEnumerator"/> of the coroutine.
        /// </summary>
        IEnumerator Enumerator { get; }

        /// <summary>
        /// Attempt to stop the coroutine.
        /// </summary>
        void Stop();
    }
}

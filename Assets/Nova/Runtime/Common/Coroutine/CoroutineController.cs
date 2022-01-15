using System.Collections;
using Nova.Framework.Core;
using Nova.Framework.Dependency;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Controller for execute coroutines.
    /// </summary>
    public class CoroutineController : ICoroutineController, ILoadable
    {
        /// <inheritdoc />
        void ILoadable.OnLoad(IDependencyContainer container)
        {

        }

        /// <inheritdoc />
        ICoroutineTask ICoroutineController.Start(IEnumerator routine)
        {
            return null;
        }
    }
}

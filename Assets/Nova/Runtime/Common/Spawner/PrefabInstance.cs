using System;
using UnityEngine;

namespace Nova.Framework.Common.Spawner
{
    /// <summary>
    /// Used to control a instantiated <see cref="GameObject"/> at runtime.
    /// </summary>
    public class PrefabInstance : IPrefabInstance
    {
        private Action _actionDestroy;
        private GameObject _host;

        /// <inheritdoc />
        GameObject IPrefabInstance.Host => _host;

        public PrefabInstance(GameObject host, Action actionDestroy)
        {
            _host = host;
            _actionDestroy = actionDestroy;
        }

        /// <inheritdoc />
        void IPrefabInstance.Destroy() => _actionDestroy?.Invoke();
    }
}

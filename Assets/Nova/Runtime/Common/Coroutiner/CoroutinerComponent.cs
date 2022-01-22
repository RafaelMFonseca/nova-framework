using UnityEngine;
using System.Collections;
using Nova.Framework.Core;
using Nova.Framework.Entity;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Common.Coroutiner
{
    /// <summary>
    /// Component to start and stop coroutines.
    /// </summary>
    public class CoroutinerComponent : ICoroutinerComponent, IDestroyable
    {
        private EntityBase _entityBase;

        /// <inheritdoc />
        void IComponentHost.SetHost(GameObject host)
        {
            _entityBase = host.GetComponent<EntityBase>();
        }

        /// <inheritdoc />
        void ICoroutinerComponent.Start(IEnumerator routine)
        {
            _entityBase?.StartCoroutine(routine);
        }

        /// <inheritdoc />
        void ICoroutinerComponent.Stop(IEnumerator routine)
        {
            _entityBase?.StopCoroutine(routine);
        }

        /// <inheritdoc />
        void IDestroyable.OnDestroy()
        {
            _entityBase = null;
        }
    }
}

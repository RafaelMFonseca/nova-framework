﻿using UnityEngine;
using System.Collections;
using Nova.Framework.Core;
using Nova.Framework.Entity;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Common.Coroutine
{
    /// <summary>
    /// Component to start and stop coroutines.
    /// </summary>
    public class CoroutineComponent : ICoroutineComponent, IDestroyable
    {
        private EntityBase _entityBase;

        /// <inheritdoc />
        void IComponentHost.SetHost(GameObject host)
        {
            _entityBase = host.GetComponent<EntityBase>();
        }

        /// <inheritdoc />
        void ICoroutineComponent.Start(IEnumerator routine)
        {
            _entityBase?.StartCoroutine(routine);
        }

        /// <inheritdoc />
        void ICoroutineComponent.Stop(IEnumerator routine)
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

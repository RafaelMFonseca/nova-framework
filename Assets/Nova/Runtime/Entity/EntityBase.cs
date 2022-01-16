using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Nova.Framework.Core;
using Nova.Framework.Dependency;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Base class implementation of an <see cref="IEntity"/>.
    /// </summary>
    [Serializable]
    public abstract class EntityBase : MonoBehaviour, IEntity
    {
        protected ReadOnlyCollection<IComponent> _components;

        /// <inheritdoc />
        public abstract IComponent[] GetComponents();

        public virtual void Awake()
        {
            _components = Array.AsReadOnly(GetComponents());

            foreach (IInitializable initializable in GetInitializableComponents())
            {
                DependencyActivator.Initialize(initializable);
            }

            foreach (IAwakeable awakeable in GetAwakeableComponents())
            {
                awakeable.OnAwake();
            }
        }

        public virtual void Start()
        {
            foreach (ILoadable loadable in GetLoadableComponents())
            {
                DependencyActivator.Activate(loadable);
            }

            foreach (IStartable startable in GetStartableComponents())
            {
                startable.OnStart();
            }
        }

        public virtual void OnEnable()
        {
            foreach (IEnableable enableable in GetEnableableComponents())
            {
                enableable.OnEnable();
            }
        }

        public virtual void OnDisable()
        {
            foreach (IDisableable disableable in GetDisableableComponents())
            {
                disableable.OnDisable();
            }
        }

        public virtual void OnDestroy()
        {
            foreach (IDestroyable destroyable in GetDestroyableComponents())
            {
                destroyable.OnDestroy();
            }
        }

        /// <inheritdoc />
        IEnumerator<IComponent> IEnumerable<IComponent>.GetEnumerator() => _components.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => _components.GetEnumerator();

        /// <summary>
        /// Gets all components in the entity that directly derive from IInitializable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IInitializable> GetInitializableComponents()
            => _components.OfType<IInitializable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from ILoadable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<ILoadable> GetLoadableComponents()
            => _components.OfType<ILoadable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IAwakeable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IAwakeable> GetAwakeableComponents()
            => _components.OfType<IAwakeable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IStartable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IStartable> GetStartableComponents()
            => _components.OfType<IStartable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IEnableable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IEnableable> GetEnableableComponents()
            => _components.OfType<IEnableable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IDisableable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IDisableable> GetDisableableComponents()
            => _components.OfType<IDisableable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IDestroyable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IDestroyable> GetDestroyableComponents()
            => _components.OfType<IDestroyable>();
    }
}

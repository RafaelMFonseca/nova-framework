using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Nova.Framework.Entity.Component;
using Nova.Framework.Core;
using System.Collections.ObjectModel;
using System;

namespace Nova.Framework.Entity
{
    public abstract class EntityBase : MonoBehaviour, IEntity
    {
        private ReadOnlyCollection<IComponent> _components;

        public abstract IComponent[] GetComponents();

        public void Awake()
        {
            _components = Array.AsReadOnly(GetComponents());

            foreach (ILoadable loadable in GetLoadableComponents())
            {
                // loadable.OnPreLoad();
            }

            foreach (IStartable startable in GetStartableComponents())
            {
                startable.OnAwake();
            }
        }

        public void Start()
        {
            foreach (ILoadable loadable in GetLoadableComponents())
            {
                // loadable.OnLoad();
            }

            foreach (IStartable startable in GetStartableComponents())
            {
                startable.OnStart();
            }
        }

        public void OnEnable()
        {
            foreach (IEnableable enableable in GetEnableableComponents())
            {
                enableable.OnEnable();
            }
        }

        public void OnDisable()
        {
            foreach (IEnableable enableable in GetEnableableComponents())
            {
                enableable.OnDisable();
            }
        }

        public void OnDestroy()
        {
            foreach (IDestroyable destroyable in GetDestroyableComponents())
            {
                destroyable.OnDestroy();
            }
        }

        /// <summary>
        /// Gets all components in the entity that directly derive from IStartable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IStartable> GetStartableComponents()
            => _components.OfType<IStartable>().Cast<IStartable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from ILoadable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<ILoadable> GetLoadableComponents()
            => _components.OfType<ILoadable>().Cast<ILoadable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IEnableable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IEnableable> GetEnableableComponents()
            => _components.OfType<IEnableable>().Cast<IEnableable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IDestroyable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IDestroyable> GetDestroyableComponents()
            => _components.OfType<IDestroyable>().Cast<IDestroyable>();
    }
}

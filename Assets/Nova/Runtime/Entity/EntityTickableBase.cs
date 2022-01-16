using System;
using System.Linq;
using System.Collections.Generic;
using Nova.Framework.Core;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Class variant for <see cref="EntityBase"/> that runs the FixedUpdate(), Update() and LateUpdate() methods.
    /// </summary>
    [Serializable]
    public abstract class EntityTickableBase : EntityBase
    {
        protected IEnumerable<IFixedUpdateable> _fixedUpdateables;
        protected IEnumerable<ILateUpdateable> _lateUpdateables;
        protected IEnumerable<IUpdateable> _updateables;

        public virtual void FixedUpdate()
        {
            foreach (IFixedUpdateable fixedUpdateable in GetFixedUpdateableComponents())
            {
                fixedUpdateable.OnFixedUpdate();
            }
        }

        public virtual void Update()
        {
            foreach (IUpdateable updateable in GetUpdateableComponents())
            {
                updateable.OnUpdate();
            }
        }

        public virtual void LateUpdate()
        {
            foreach (ILateUpdateable lateUpdateable in GetLateUpdateableComponents())
            {
                lateUpdateable.OnLateUpdate();
            }
        }

        /// <summary>
        /// Gets all components in the entity that directly derive from IFixedUpdateable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IFixedUpdateable> GetFixedUpdateableComponents()
            => _fixedUpdateables ??= _components.OfType<IFixedUpdateable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from IUpdateable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IUpdateable> GetUpdateableComponents()
            => _updateables ??= _components.OfType<IUpdateable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from ILateUpdateable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<ILateUpdateable> GetLateUpdateableComponents()
            => _lateUpdateables ??= _components.OfType<ILateUpdateable>();
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using Nova.Framework.Core;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Class variant for <see cref="EntityBase"/> that runs the Update() and LateUpdate() methods.
    /// </summary>
    [Serializable]
    public abstract class EntityTickableBase : EntityBase
    {
        private IEnumerable<ILateUpdateable> _lateUpdateables;
        private IEnumerable<IUpdateable> _updateables;

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
        /// Gets all components in the entity that directly derive from IUpdateable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<IUpdateable> GetUpdateableComponents()
            => _updateables ??= _components.OfType<IUpdateable>().Cast<IUpdateable>();

        /// <summary>
        /// Gets all components in the entity that directly derive from ILateUpdateable.
        /// </summary>
        /// <returns>The derived types.</returns>
        private IEnumerable<ILateUpdateable> GetLateUpdateableComponents()
            => _lateUpdateables ??= _components.OfType<ILateUpdateable>().Cast<ILateUpdateable>();
    }
}

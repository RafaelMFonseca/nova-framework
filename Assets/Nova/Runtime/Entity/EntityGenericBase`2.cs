﻿using System;
using System.Linq;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Class variant for <see cref="EntityBase"/> that allows specify its component
    /// instead of creating a new entity class.
    /// </summary>
    [Serializable]
    public abstract class EntityGenericBase<T1, T2> : EntityBase
        where T1 : IComponent, new()
        where T2 : IComponent, new()
    {
        /// <inheritdoc />
        public override IComponent[] GetComponents()
        {
            IComponent[] components = new IComponent[] { new T1(), new T2() };

            foreach (IComponentHost component in components.OfType<IComponentHost>())
            {
                component.Host = this.gameObject;
            }

            return components;
        }
    }
}

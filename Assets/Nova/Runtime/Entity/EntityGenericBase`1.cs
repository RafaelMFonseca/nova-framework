using System;
using System.Linq;
using Nova.Framework.Entity.Component;

namespace Nova.Framework.Entity
{
    /// <summary>
    /// Class variant for <see cref="EntityBase"/> that allows specify its component
    /// instead of creating a new entity class.
    /// </summary>
    [Serializable]
    public abstract class EntityGenericBase<T1> : EntityBase
        where T1 : IComponent, new()
    {
        /// <inheritdoc />
        public override IComponent[] GetComponents()
        {
            IComponent[] components = new IComponent[] { new T1() };

            foreach(IComponentHost component in components.OfType<IComponentHost>())
            {
                component.SetHost(this.gameObject);
            }

            return components;
        }
    }
}

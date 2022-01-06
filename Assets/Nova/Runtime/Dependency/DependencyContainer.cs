using System;
using System.Collections.Generic;

namespace Nova.Framework.Dependency
{
    [Serializable]
    public class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, object> _cache = new Dictionary<Type, object>();
        private readonly IDependencyContainer _parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyContainer" /> class.
        /// </summary>
        /// <param name="parent">The parent for this container.</param>
        public DependencyContainer(IDependencyContainer parent = null)
        {
            _parent = parent;
        }

        /// <inheritdoc />
        void IDependencyContainer.Cache(Type type, object instance)
        {
            _cache.Add(type, instance);
        }

        /// <inheritdoc />
        T IDependencyContainer.Inject<T>()
        {
            if (_cache.TryGetValue(typeof(T), out object instance))
            {
                return (T) instance;
            }

            return _parent == null ? default : _parent.Inject<T>();
        }
    }
}

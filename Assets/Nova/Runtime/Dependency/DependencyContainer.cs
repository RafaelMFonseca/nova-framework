using System;
using System.Linq;
using System.Collections.Generic;

namespace Nova.Framework.Dependency
{
    [Serializable]
    public class DependencyContainer : IDependencyContainer
    {
        private readonly List<IDependencyEntry> _cache = new List<IDependencyEntry>();
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
        void IDependencyContainer.Bind(Type type, object instance)
        {
            IDependencyEntry entry = FindDependencyEntry(type);

            if (entry == null)
            {
                _cache.Add(DependencyEntry.Create(type, instance));
            }
            else
            {
                entry.AddDependency(instance);
            }
        }

        /// <inheritdoc />
        void IDependencyContainer.Unbind(object instance)
        {
            foreach (IDependencyEntry entry in _cache)
            {
                entry.RemoveDependency(instance);
            }

            if (_parent != null)
            {
                _parent.Unbind(instance);
            }
        }

        /// <inheritdoc />
        T IDependencyContainer.Inject<T>()
        {
            IDependencyEntry entry = FindDependencyEntry(typeof(T));

            if (entry != null)
            {
                return (T) entry.Dependencies[0];
            }

            return _parent == null ? default : _parent.Inject<T>();
        }

        /// <inheritdoc />
        IEnumerable<T> IDependencyContainer.InjectAll<T>()
        {
            List<T> dependencies = new List<T>();

            if (_parent != null)
            {
                IEnumerable<T> parentDependencies = _parent.InjectAll<T>();

                if (parentDependencies != null)
                {
                    dependencies.AddRange(parentDependencies);
                }
            }

            IDependencyEntry entry = FindDependencyEntry(typeof(T));

            if (entry != null)
            {
                dependencies.AddRange(entry.Dependencies.Cast<T>());
            }

            return dependencies;
        }

        /// <inheritdoc />
        void IDisposable.Dispose()
        {
            foreach (IDependencyEntry entry in _cache)
            {
                entry.ClearDependencies();
            }

            _cache.Clear();
        }

        IDependencyEntry FindDependencyEntry(Type type)
        {
            return _cache.Find(d => d.Type == type);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nova.Framework.Dependency
{
    public class DependencyEntry : IDependencyEntry
    {
        public readonly List<object> _entries;
        public readonly Type _type;

        /// <inheritdoc />
        Type IDependencyEntry.Type => _type;

        public DependencyEntry(Type type)
        {
            _type = type;
            _entries = new List<object>();
        }

        /// <inheritdoc />
        ReadOnlyCollection<object> IDependencyEntry.Dependencies => _entries.AsReadOnly();

        /// <inheritdoc />
        void IDependencyEntry.AddDependency(object dependency)
        {
            _entries.Add(dependency);
        }

        /// <inheritdoc />
        void IDependencyEntry.ClearDependencies()
        {
            _entries.Clear();
        }

        /// <inheritdoc />
        void IDependencyEntry.RemoveDependency(object dependency)
        {
            _entries.Remove(dependency);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        /// <summary>
        /// Creates a new instance of
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dependency"></param>
        public static IDependencyEntry Create(Type type, object dependency)
        {
            IDependencyEntry entry = new DependencyEntry(type);
            entry.AddDependency(dependency);

            return entry;
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nova.Framework.Dependency
{
    public class DependencyEntry : IDependencyEntry
    {
        private readonly List<object> _entries;
        private readonly Type _type;

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
        /// <param name="dependencies"></param>
        public static IDependencyEntry Create(Type type, params object[] dependencies)
        {
            IDependencyEntry entry = new DependencyEntry(type);

            foreach (object dependency in dependencies)
            {
                entry.AddDependency(dependency);
            }

            return entry;
        }
    }
}

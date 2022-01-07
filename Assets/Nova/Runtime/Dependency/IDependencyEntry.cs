using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Nova.Framework.Dependency
{
    /// <summary>
    /// A dependency entry for the container.
    /// </summary>
    public interface IDependencyEntry : IEnumerable
    {
        /// <summary>
        /// The type of the member to be injected.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// All dependencies compatible with this type.
        /// </summary>
        public ReadOnlyCollection<object> Dependencies { get; }

        /// <summary>
        /// Add a dependency to this entry.
        /// </summary>
        /// <param name="dependency">The dependency to add.</param>
        void AddDependency(object dependency);

        /// <summary>
        /// Removes a dependency from this entry.
        /// </summary>
        /// <param name="dependency">The dependency to remove.</param>
        void RemoveDependency(object dependency);

        /// <summary>
        /// Removes all dependencies.
        /// </summary>
        void ClearDependencies();
    }
}

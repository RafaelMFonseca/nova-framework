using System;
using System.Collections.Generic;

namespace Nova.Framework.Dependency
{
    /// <summary>
    /// Dependency container capable of inject and retrieve dependencies bases on types.
    /// </summary>
    public interface IDependencyContainer : IDisposable
    {
        /// <summary>
        /// Caches a dependency based on given type.
        /// </summary>
        /// <param name="type">The dependency type.</param>
        /// <param name="instance">The dependency to be cached.</param>
        void Bind(Type type, object instance);

        /// <summary>
        /// Releases a dependency from the container
        /// </summary>
        /// <param name="instance">The dependency to be released.</param>
        void Unbind(object instance);

        /// <summary>
        /// Retrieves cached dependency of type <paramref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The dependency type.</typeparam>
        /// <returns>The dependency or null if not found.</returns>
        T Inject<T>();

        /// <summary>
        /// Retrieves all cached dependency of type <paramref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The dependency type.</typeparam>
        /// <returns>All dependencies or null if none is found.</returns>
        IEnumerable<T> InjectAll<T>();
    }
}

using System;

namespace Nova.Framework.Dependency
{
    /// <summary>
    /// Dependency container capable of inject and retrieve dependencies bases on types.
    /// </summary>
    public interface IDependencyContainer
    {
        /// <summary>
        /// Caches a dependency based on given type.
        /// </summary>
        /// <param name="type">The dependency type.</param>
        /// <param name="instance">The dependency to be cached.</param>
        void Cache(Type type, object instance);

        /// <summary>
        /// Retrieves cached dependency of type <paramref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The dependency type.</typeparam>
        /// <returns>The dependency or null if not found.</returns>
        T Inject<T>();
    }
}

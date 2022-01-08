using System;

namespace Nova.Framework
{
    /// <summary>
    /// The options to be used by a <see cref="INovaFrameworkBuilder" />.
    /// </summary>
    public interface INovaFrameworkOptions
    {
        /// <summary>
        /// Instantiate and insert the given concrete type to the global dependency container.
        /// </summary>
        /// <param name="serviceType">The contract for the service.</param>
        /// <param name="concreteType">The concrete type that implements the service.</param>
        void AddScoped(Type serviceType, Type concreteType);
    }
}

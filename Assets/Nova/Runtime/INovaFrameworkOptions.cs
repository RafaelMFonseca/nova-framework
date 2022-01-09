using System;
using Nova.Framework.Dependency;

namespace Nova.Framework
{
    /// <summary>
    /// The options to be used by a <see cref="INovaFrameworkBuilder" />.
    /// </summary>
    public interface INovaFrameworkOptions
    {
        /// <summary>
        /// Instantiate and insert the given concrete type to the <see cref="IDependencyContainer"/>.
        /// </summary>
        /// <param name="serviceType">The contract for the service.</param>
        /// <param name="concreteType">The concrete type that implements the service.</param>
        void AddSingleton(Type serviceType, Type concreteType);
    }
}

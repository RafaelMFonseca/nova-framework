using System;
using Nova.Framework.Dependency;

namespace Nova.Framework
{
    /// <summary>
    /// Defines a class that provides the mechanisms to configure an nova application.
    /// </summary>
    public interface INovaFrameworkBuilder : IDisposable
    {
        /// <summary>
        /// Global container being used by this application.
        /// </summary>
        public IDependencyContainer Container { get; }

        /// <summary>
        /// The configuration. Use the settings element to configure the nova framework instance.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <see cref="INovaFrameworkBuilder"/>.</returns>
        INovaFrameworkBuilder WithSettings(Action<INovaFrameworkOptions> settings);

        /// <summary>
        /// Starts the nova application, also runs ILoadable and IStartabke of all controllers registered
        /// with the options.
        /// </summary>
        /// <returns>The new <see cref="INovaFrameworkBuilder"/>.</returns>
        INovaFrameworkBuilder Start();

        /// <summary>
        /// The application currently running and active.
        /// </summary>
        public static INovaFrameworkBuilder ActiveInstance { get; set; }
    }
}

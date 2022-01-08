using System;

namespace Nova.Framework
{
    /// <summary>
    /// Defines a class that provides the mechanisms to configure an nova application.
    /// </summary>
    public interface INovaFrameworkBuilder
    {
        /// <summary>
        /// The configuration. Use the settings element to configure the nova framework instance.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <see cref="INovaFrameworkBuilder"/>.</returns>
        INovaFrameworkBuilder WithSettings(Action<INovaFrameworkOptions> settings);

        /// <summary>
        /// Creates a new <see cref="INovaFrameworkBuilder"/>.
        /// </summary>
        /// <returns>The new <see cref="INovaFrameworkBuilder"/>.</returns>
        INovaFrameworkBuilder Build();
    }
}

using System;
using Nova.Framework.Event;
using Nova.Framework.Shared;
using Nova.Framework.Dependency;

namespace Nova.Framework
{
    /// <inheritdoc />
    public sealed class NovaApplication : INovaFrameworkBuilder
    {
        private readonly IDependencyContainer _dependencyContainer = new DependencyContainer();
        private readonly INovaFrameworkOptions _options = new NovaFrameworkOptions();
        private readonly IEventEmitter _eventEmitter = new EventEmitter();

        /// <inheritdoc />
        public INovaFrameworkBuilder WithSettings(Action<INovaFrameworkOptions> settings)
        {
            Check.NotNull(settings, nameof(settings));

            settings(_options);

            return this;
        }

        /// <inheritdoc />
        public INovaFrameworkBuilder Build()
        {
            return this;
        }
    }
}

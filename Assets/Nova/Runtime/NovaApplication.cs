using System;
using System.Linq;
using Nova.Framework.Core;
using Nova.Framework.Event;
using Nova.Framework.Shared;
using Nova.Framework.Dependency;

namespace Nova.Framework
{
    /// <summary>
    /// The nova application used to configure the container, events, etc
    /// </summary>
    public sealed class NovaApplication : INovaFrameworkBuilder
    {
        /// <inheritdoc />
        public IDependencyContainer Container => _container;

        private readonly IDependencyContainer _container;
        private readonly INovaFrameworkOptions _options;
        private readonly IEventEmitter _eventEmitter;

        /// <summary>
        /// Create a new NovaApplication instance.
        /// </summary>
        public NovaApplication()
        {
            _eventEmitter = new EventEmitter();

            _container = new DependencyContainer();
            _container.Bind(typeof(IEventEmitter), _eventEmitter);

            _options = new NovaFrameworkOptions(_container);
        }

        /// <inheritdoc />
        public INovaFrameworkBuilder WithSettings(Action<INovaFrameworkOptions> settings)
        {
            Check.NotNull(settings, nameof(settings));

            settings(_options);

            return this;
        }

        /// <inheritdoc />
        public INovaFrameworkBuilder Start()
        {
            INovaFrameworkBuilder.ActiveInstance = this;

            foreach (IAwakeable awakeable in _container.SelectMany(c => c.Dependencies).OfType<IAwakeable>()) 
            {
                awakeable.OnAwake(_container);
            }

            foreach (IStartable startable in _container.SelectMany(c => c.Dependencies).OfType<IStartable>())
            {
                startable.OnStart(_container);
            }

            return this;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _container.Dispose();
            _eventEmitter.Dispose();
        }
    }
}

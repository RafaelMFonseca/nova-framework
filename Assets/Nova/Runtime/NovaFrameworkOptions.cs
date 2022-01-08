﻿using System;
using Nova.Framework.Dependency;
using Nova.Framework.Shared;

namespace Nova.Framework
{
    /// <inheritdoc />
    public class NovaFrameworkOptions : INovaFrameworkOptions
    {
        private readonly IDependencyContainer _container;

        /// <summary>
        /// Create a new NovaFrameworkOptions instance.
        /// </summary>
        /// <param name="container">The container created on the application.</param>
        public NovaFrameworkOptions(IDependencyContainer container)
        {
            _container = container;
        }

        /// <inheritdoc />
        void INovaFrameworkOptions.AddSingleton(Type serviceType, Type concreteType)
        {
            _container.Bind(serviceType, Activator.CreateInstance(concreteType));
        }

        /// <inheritdoc />
        void INovaFrameworkOptions.Startup(Type startupType)
        {
            Check.NotNull(startupType, nameof(startupType));
        }
    }
}

using System;
using Nova.Framework.Screen;
using Nova.Framework.Shared;

namespace Nova.Framework
{
    /// <summary>
    /// Contains extensions for configuring an <see cref="INovaFrameworkOptions" />.
    /// </summary>
    public static class NovaFrameworkOptionsExtensions
    {
        /// <summary>
        /// Adds a <see cref="IScreenFinder"/> to the dependency container.
        /// </summary>
        /// <param name="options">The <see cref="INovaFrameworkOptions" /> to configure.</param>
        /// <param name="screenFinderType">The <see cref="IScreenFinder" /> concrete type.</param>
        /// <returns>The <see cref="INovaFrameworkBuilder" />.</returns>
        public static INovaFrameworkOptions WithScreenFinder(this INovaFrameworkOptions options, Type screenFinderType)
        {
            Check.NotNull(options, nameof(options));
            Check.NotNull(screenFinderType, nameof(screenFinderType));

            options.AddSingleton(typeof(IScreenFinder), screenFinderType);

            return options;
        }
    }
}

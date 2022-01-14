using Nova.Framework.Core;

namespace Nova.Framework.Dependency
{
    /// <summary>
    /// Helper class to call a method with the global dependency container.
    /// </summary>
    public static class DependencyActivator
    {
        /// <summary>
        /// Call a <see cref="ILoadable"/> passing <see cref="IDependencyContainer"/> by parameter.
        /// </summary>
        /// <param name="loadable">The object to inject the dependencies into.</param>
        public static void Activate(ILoadable loadable) => loadable.OnLoad(Container);

        /// <summary>
        /// Call a <see cref="ILoadable"/> passing <see cref="IDependencyContainer"/> by parameter.
        /// </summary>
        /// <param name="loadable">The object to inject the dependencies into.</param>
        public static void PreActivate(ILoadable loadable) => loadable.OnPreLoad(Container);

        /// <summary>
        /// The active container.
        /// </summary>
        private static IDependencyContainer Container => INovaFrameworkBuilder.ActiveInstance.Container;
    }
}

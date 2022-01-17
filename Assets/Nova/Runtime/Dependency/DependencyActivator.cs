using Nova.Framework.Core;

namespace Nova.Framework.Dependency
{
    /// <summary>
    /// Helper class to call a method with the global dependency container.
    /// </summary>
    public static class DependencyActivator
    {
        /// <summary>
        /// Call a <see cref="IAwakeable"/> passing <see cref="IDependencyContainer"/> by parameter.
        /// </summary>
        /// <param name="awakeable">The object to inject the dependencies into.</param>
        public static void Activate(IAwakeable awakeable) => awakeable.OnAwake(Container);

        /// <summary>
        /// Call a <see cref="IStartable"/> passing <see cref="IDependencyContainer"/> by parameter.
        /// </summary>
        /// <param name="startable">The object to inject the dependencies into.</param>
        public static void Activate(IStartable startable) => startable.OnStart(Container);

        /// <summary>
        /// The active container.
        /// </summary>
        private static IDependencyContainer Container => INovaFrameworkBuilder.ActiveInstance.Container;
    }
}

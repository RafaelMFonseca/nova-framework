using Nova.Framework.Dependency;

namespace Nova.Framework.Core
{
    /// <summary>
    /// Alows user to inject dependencies.
    /// </summary>
    public interface ILoadable
    {
        /// <summary>
        /// Method invoked when object is ready and has a dependency container.
        /// </summary>
        /// <param name="container">The container for this object.</param>
        void Load(IDependencyContainer container);
    }
}

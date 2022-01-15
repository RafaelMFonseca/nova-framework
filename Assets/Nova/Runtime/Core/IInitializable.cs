using Nova.Framework.Dependency;

namespace Nova.Framework.Core
{
    /// <summary>
    /// Alows user to inject dependencies.
    /// </summary>
    public interface IInitializable
    {
        /// <summary>
        /// Method invoked when object being initialized and has a dependency container.
        /// </summary>
        /// <param name="container">The container for this object.</param>
        void OnInitialize(IDependencyContainer container);
    }
}

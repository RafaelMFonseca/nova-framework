using Nova.Framework.Dependency;

namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic when this object
    /// is initialized.
    /// </summary>
    public interface IStartable
    {
        /// <summary>
        /// Method invoked when the component is ready to start, having
        /// received its initial parameters.
        /// </summary>
        void OnStart(IDependencyContainer container);
    }
}
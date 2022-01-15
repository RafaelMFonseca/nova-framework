namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic when this object
    /// is disabled.
    /// </summary>
    public interface IDisableable
    {
        /// <summary>
        /// Method invoked when the component is disabled.
        /// </summary>
        void OnDisable();
    }
}

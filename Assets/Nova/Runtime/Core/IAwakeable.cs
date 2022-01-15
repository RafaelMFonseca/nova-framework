namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic when this object
    /// is awake.
    /// </summary>
    public interface IAwakeable
    {
        /// <summary>
        /// Method invoked when the component is being loaded.
        /// </summary>
        void OnAwake();
    }
}
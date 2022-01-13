namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic when this object
    /// is destroyed.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        /// Method invoked when the component is destroyed.
        /// </summary>
        void OnDestroy();
    }
}

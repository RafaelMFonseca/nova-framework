namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic every frame.
    /// </summary>
    public interface ILateUpdateable
    {
        /// <summary>
        /// Method invoked after update.
        /// </summary>
        void OnLateUpdate();
    }
}
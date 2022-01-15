namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic every frame.
    /// </summary>
    public interface IFixedUpdateable
    {
        /// <summary>
        /// Method invoked every frame, before update.
        /// </summary>
        void OnFixedUpdate();
    }
}
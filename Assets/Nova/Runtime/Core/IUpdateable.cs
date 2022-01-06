namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic every frame.
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// Method invoked every frame.
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// Method invoked after update.
        /// </summary>
        void OnLateUpdate();
    }
}
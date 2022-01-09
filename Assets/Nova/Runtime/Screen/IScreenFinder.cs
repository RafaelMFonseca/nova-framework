namespace Nova.Framework.Screen
{
    /// <summary>
    /// Used to find IScreens when a new scene is loaded.
    /// </summary>
    public interface IScreenFinder
    {
        /// <summary>
        /// Methods to find the IScreen.
        /// </summary>
        /// <returns>The <see cref="IScreen"/> found.</returns>
        IScreen Find();
    }
}

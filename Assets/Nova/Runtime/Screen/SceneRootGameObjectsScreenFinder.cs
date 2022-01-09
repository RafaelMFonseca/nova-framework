using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nova.Framework.Screen
{
    /// <summary>
    /// Finds the IScreen at all the root game objects in the Scene.
    /// </summary>
    public class SceneRootGameObjectsScreenFinder : IScreenFinder
    {
        /// <inheritdoc />
        IScreen IScreenFinder.Find()
        {
            var scene = SceneManager.GetActiveScene();

            foreach (Object gameObject in scene.GetRootGameObjects())
            {
                if (gameObject is IScreen screen)
                {
                    return screen;
                }
            }

            return null;
        }
    }
}

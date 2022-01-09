using System;

namespace Nova.Framework.Screen
{
    /// <summary>
    /// Represents a screen that can be started with the scene.
    /// </summary>
    public interface IScreenRoot
    {
        Type GetScreenRootType();
    }
}

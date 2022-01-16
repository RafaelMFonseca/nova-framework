using UnityEngine;

namespace Nova.Framework.Common.Prefab
{
    /// <summary>
    /// Used to instantiate game objects at runtime.
    /// </summary>
    public interface IPrefab
    {
        GameObject Spawn();
    }
}

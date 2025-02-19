﻿namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic every frame.
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// Method invoked after fixed update.
        /// </summary>
        void OnUpdate();
    }
}
﻿namespace Nova.Framework.Core
{
    /// <summary>
    /// Allows user code to execute some logic when this object
    /// is enable.
    /// </summary>
    public interface IEnableable
    {
        /// <summary>
        /// Method invoked when the component is enabled.
        /// </summary>
        void OnEnable();
    }
}

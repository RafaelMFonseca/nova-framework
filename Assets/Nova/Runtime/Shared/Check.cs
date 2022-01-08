using System;

namespace Nova.Framework.Shared
{
    internal static class Check
    {
        /// <summary>
        /// Enforce that the value is not null. Returns the
        /// value if valid so that it can be used inline in
        /// base initialiser syntax.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public static T NotNull<T>(T value, string parameterName)
        {
            if (value is null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
    }
}

using Nova.Framework.Common.Spawner;

namespace Nova.Framework.Shared
{
    /// <summary>
    /// Provides extension methods for <see cref="IPrefabParameter" />
    /// </summary>
    public static class PrefabParameterExtensions
    {
        /// <summary>
        /// Try to cast <paramref name="parameter"/> to type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The parameter type to cast for.</typeparam>
        /// <param name="parameter">The prefab parameter.</param>
        /// <returns>Prefab parameter of type <typeparamref name="T"/>.</returns>
        public static T TryCastParameter<T>(this IPrefabParameter parameter)
            where T : class, IPrefabParameter
        {
            Check.NotNull(parameter, nameof(parameter));

            return parameter as T;
        }
    }
}

using Nova.Framework.Event;

namespace Nova.Framework.Shared
{
    public static class EventParameterExtensions
    {
        /// <summary>
        /// Try to cast <paramref name="parameter"/> to type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The parameter type to cast for.</typeparam>
        /// <param name="parameter">The event parameter.</param>
        /// <returns>Event parameter of type <typeparamref name="T"/>.</returns>
        public static T TryCastParameter<T>(this IEventParameter parameter)
            where T : class, IEventParameter
        {
            Check.NotNull(parameter, nameof(parameter));

            return parameter as T;
        }
    }
}

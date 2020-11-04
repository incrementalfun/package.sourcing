using System.Threading.Tasks;

namespace Incremental.Common.Sourcing.Events.Contract
{
    /// <summary>
    /// Bus for publishing events.
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Publishes an event.
        /// </summary>
        /// <param name="events"></param>
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent;
    }
}
using System.Threading;
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
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}
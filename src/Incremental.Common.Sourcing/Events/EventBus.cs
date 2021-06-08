using System.Threading;
using System.Threading.Tasks;
using Incremental.Common.Sourcing.Events.Contract;
using MediatR;

namespace Incremental.Common.Sourcing.Events
{
    /// <summary>
    /// Default implementation of IEventBus.
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly IPublisher _publisher;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="publisher"></param>
        public EventBus(IPublisher publisher)
        {
            _publisher = publisher;
        }

        /// <inheritdoc />
        public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            if (@event is IInternalEvent)
            {
                await _publisher.Publish(@event, cancellationToken);
            }
        }
    }
}
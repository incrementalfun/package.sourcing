using System.Threading;
using System.Threading.Tasks;
using Incremental.Common.Sourcing.Events.Contract;
using MassTransit;
using MediatR;

namespace Incremental.Common.Sourcing.Events
{
    /// <summary>
    /// Default implementation of IEventBus.
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly IPublisher _publisher;
        private readonly IBus _bus;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="bus"></param>
        public EventBus(IPublisher publisher, IBus bus)
        {
            _publisher = publisher;
            _bus = bus;
        }

        /// <inheritdoc />
        public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            if (@event is IInternalEvent)
            {
                await _publisher.Publish(@event, cancellationToken);
            }

            await _bus.Publish(@event, cancellationToken);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Incremental.Common.Sourcing.Abstractions.Events;
using MassTransit;
using Event = Incremental.Common.Sourcing.Abstractions.Events.Event;

namespace Incremental.Common.Sourcing.Events;

/// <summary>
/// Default implementation of IEventBus.
/// </summary>
public class EventBus : IEventBus
{
    private readonly IPublishEndpoint _provider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="provider"></param>
    public EventBus(IPublishEndpoint provider)
    {
        _provider = provider;
    }

    /// <inheritdoc />
    public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : Event
    {
        await _provider.Publish(@event, cancellationToken);
    }
}
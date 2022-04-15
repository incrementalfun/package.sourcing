using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Event handler.
/// </summary>
/// <typeparam name="TEvent"></typeparam>
public abstract class EventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : Event
{
    /// <inheritdoc />
    public abstract Task Handle(TEvent @event, CancellationToken cancellationToken);
}
using System.Threading.Tasks;
using MassTransit;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Event handler.
/// </summary>
/// <typeparam name="TEvent"></typeparam>
public abstract class EventHandler<TEvent> : IConsumer<TEvent> where TEvent : Event
{
    /// <inheritdoc />
    public abstract Task Consume(ConsumeContext<TEvent> context);
}
using MediatR;

namespace Incremental.Common.Sourcing.Events.Contract
{
    /// <summary>
    /// Event handler.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {
    }
}
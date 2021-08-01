using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Events
{
    /// <summary>
    /// Internal Event handler.
    /// </summary>
    /// <typeparam name="TInternalEvent"></typeparam>
    public interface IInternalEventHandler<in TInternalEvent> : INotificationHandler<TInternalEvent> where TInternalEvent : IInternalEvent
    {
    }
}
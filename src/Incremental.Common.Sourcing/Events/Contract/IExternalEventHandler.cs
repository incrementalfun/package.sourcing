using MassTransit;
using MediatR;

namespace Incremental.Common.Sourcing.Events.Contract
{
    /// <summary>
    /// External Event handler.
    /// </summary>
    /// <typeparam name="TExternalEvent"></typeparam>
    public interface IExternalEventHandler<TExternalEvent> : IConsumer<TExternalEvent> where TExternalEvent : class, IExternalEvent
    {
    }
}
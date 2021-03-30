using MediatR;

namespace Incremental.Common.Sourcing.Events.Contract
{
    /// <summary>
    /// Internal Event.
    /// </summary>
    public interface IInternalEvent : IEvent, INotification
    {
        
    }
}
using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Internal Event.
/// </summary>
public interface IInternalEvent : IEvent, INotification
{
        
}
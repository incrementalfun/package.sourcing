using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Event.
/// </summary>
public record Event : INotification;
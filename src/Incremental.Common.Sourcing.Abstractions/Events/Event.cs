using System;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Event.
/// </summary>
public record Event
{
    /// <summary>
    /// Id of the event.
    /// </summary>
    public required Guid Id { get; init; }
}
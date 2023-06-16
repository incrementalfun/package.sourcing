using System;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Event.
/// </summary>
public abstract record Event
{
    /// <summary>
    /// Id of the event.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();
}
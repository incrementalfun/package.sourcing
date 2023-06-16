using System;
using MassTransit;

namespace Incremental.Common.Sourcing.Abstractions.Events;

/// <summary>
/// Event.
/// </summary>
public abstract record Event
{
    /// <summary>
    /// Id of the event.
    /// </summary>
    public required Guid Id { get; init; }
}
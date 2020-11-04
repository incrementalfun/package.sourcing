using System.Collections.Generic;
using Incremental.Common.Sourcing.Events.Contract;

namespace Incremental.Common.Sourcing.Aggregates.Contract
{
    /// <summary>
    /// Event sourced aggregate.
    /// </summary>
    public interface IEventSourcedAggregate : IAggregate
    {
        /// <summary>
        /// Pending events to launch.
        /// </summary>
        Queue<IEvent> PendingEvents { get; }
    }
}
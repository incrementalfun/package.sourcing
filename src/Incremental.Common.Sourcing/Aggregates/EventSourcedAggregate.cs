using System;
using System.Collections.Generic;
using Incremental.Common.Sourcing.Aggregates.Contract;
using Incremental.Common.Sourcing.Events.Contract;

namespace Incremental.Common.Sourcing.Aggregates
{
    /// <summary>
    /// Abstract implementation of an event sourced aggregate.
    /// </summary>
    public abstract class EventSourcedAggregate : IEventSourcedAggregate
    {
        /// <inheritdoc />
        public Guid Id { get; protected set; }
        
        /// <inheritdoc />
        public Queue<IEvent> PendingEvents { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected EventSourcedAggregate()
        {
            PendingEvents = new Queue<IEvent>();
        }

        /// <summary>
        /// Appends an event to the pending events queue.
        /// </summary>
        /// <param name="event"></param>
        protected void Append(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }
    }
}
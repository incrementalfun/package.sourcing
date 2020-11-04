using System;

namespace Incremental.Common.Sourcing.Aggregates.Contract
{
    /// <summary>
    /// Aggregate.
    /// </summary>
    public interface IAggregate
    {
        /// <summary>
        /// Unique Id of the aggregate.
        /// </summary>
        Guid Id { get; }
    }
}
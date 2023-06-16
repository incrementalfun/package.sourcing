using System.Threading.Tasks;
using MassTransit;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Query handler.
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class QueryHandler<TQuery, TResponse> : IConsumer<TQuery> where TQuery : Query<TResponse>
{
    /// <inheritdoc />
    public abstract Task Consume(ConsumeContext<TQuery> context);
}
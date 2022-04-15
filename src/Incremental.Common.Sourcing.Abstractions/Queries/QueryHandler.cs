using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Query handler.
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public abstract class QueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : Query<TResponse>
{
    /// <inheritdoc />
    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}
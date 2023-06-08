using System.Threading;
using System.Threading.Tasks;
using Incremental.Common.Sourcing.Abstractions.Queries;
using MassTransit;

namespace Incremental.Common.Sourcing.Queries;

/// <summary>
/// Default implementation of IQueryBus.
/// </summary>
public class QueryBus : IQueryBus
{
    private readonly IScopedClientFactory _factory;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="factory"></param>
    public QueryBus(IScopedClientFactory factory)
    {
        _factory = factory;
    }

    /// <inheritdoc />
    public async Task<TResponse> Send<TResponse>(Query<TResponse> query, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return (await SendWithMetadata(query, cancellationToken).ConfigureAwait(false)).Message;
    }

    /// <inheritdoc />
    public async Task<Response<TResponse>> SendWithMetadata<TResponse>(Query<TResponse> query, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        return await _factory.CreateRequestClient<Query<TResponse>>().GetResponse<TResponse>(query, cancellationToken)
            .ConfigureAwait(false);
    }
}
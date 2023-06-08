using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Bus for sending query requests.
/// </summary>
public interface IQueryBus
{
    /// <summary>
    /// Sends a query and retrieves a response.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    Task<TResponse> Send<TResponse>(Query<TResponse> query, CancellationToken cancellationToken = default)
        where TResponse : class;

    /// <summary>
    /// Sends a query and retrieves a response with metadata.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    Task<Response<TResponse>> SendWithMetadata<TResponse>(Query<TResponse> query, CancellationToken cancellationToken = default)
        where TResponse : class;
}
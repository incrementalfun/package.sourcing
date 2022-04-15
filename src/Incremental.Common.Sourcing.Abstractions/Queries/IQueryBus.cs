using System.Threading;
using System.Threading.Tasks;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Bus for sending query requests.
/// </summary>
public interface IQueryBus
{
    /// <summary>
    /// Sends a query and returns a response.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    Task<TResponse> Send<TResponse>(Query<TResponse> query, CancellationToken cancellationToken = default);
}
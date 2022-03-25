using System.Threading;
using System.Threading.Tasks;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Bus for sending query requests.
/// </summary>
public interface IQueryBus
{
    /// <summary>
    /// Sends a query and returns a TResponse.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}
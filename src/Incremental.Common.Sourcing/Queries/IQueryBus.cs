using System.Threading.Tasks;

namespace Incremental.Common.Sourcing.Queries
{
    /// <summary>
    /// Bus for sending query requests.
    /// </summary>
    public interface IQueryBus
    {
        /// <summary>
        /// Sends a query and returns a TResponse.
        /// </summary>
        /// <param name="query"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query);
    }
}
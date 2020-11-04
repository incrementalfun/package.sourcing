using System.Threading.Tasks;
using MediatR;

namespace Incremental.Common.Sourcing.Queries
{
    /// <summary>
    /// Default implementation of IQueryBus.
    /// </summary>
    public class QueryBus : IQueryBus
    {
        private readonly ISender _sender;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="sender"></param>
        public QueryBus(ISender sender)
        {
            _sender = sender;
        }

        /// <inheritdoc />
        public Task<TResponse> Send<TResponse>(IQuery<TResponse> query)
        {
            return _sender.Send(query);
        }
    }
}
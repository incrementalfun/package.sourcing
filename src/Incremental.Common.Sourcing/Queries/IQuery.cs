using MediatR;

namespace Incremental.Common.Sourcing.Queries
{
    /// <summary>
    /// Query.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
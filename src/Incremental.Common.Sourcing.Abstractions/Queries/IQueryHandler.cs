using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Query handler.
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
}
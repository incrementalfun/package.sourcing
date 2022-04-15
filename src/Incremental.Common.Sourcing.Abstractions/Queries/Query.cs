using MediatR;

namespace Incremental.Common.Sourcing.Abstractions.Queries;

/// <summary>
/// Query.
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public record Query<TResponse> : IRequest<TResponse>;